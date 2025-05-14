using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using NLog; //depura conforme al error que se presente
using ControlEscolarCore.Utilities; //tenemos el login manager
using ControlEscolarCore.Model;
using DiseñoFormsCore.Model; // clase de estudiantes

namespace ControlEscolarCore.Data
{
    class EstudiantesDataAccess
    {
        //Logger para la clase
        private static readonly Logger _logger = LoggingManager.GetLogger("ControlEscolar.Data.EstudiantesDataAccess");

        //Instancia del acceso a datos de PostgreSQL
        private readonly PostgresSQLDataAccess _dbAccess;

        //Instancia de la clase para el manejo de personas
        private readonly PersonasDataAccess _personasData;

        public EstudiantesDataAccess()
        {
            try
            {
                //Obtiene la instancia única de PostgresSQLDataAccess (patrón Singleton)
                _dbAccess = PostgresSQLDataAccess.GetInstance();
                //Instancia de acceso a datos de personas para operaciones relacionadas
                _personasData = new PersonasDataAccess(); // Inicialización
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al inicializar EstudiantesDataAccess");
                throw;
            }
        }

        public List<Estudiantes> ObtnerTodosLosEstudiantes(bool soloActivos = true, int tipofecha = 0,
    DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            List<Estudiantes> estudiantes = new List<Estudiantes>();
            try
            {
                string query = @"
                SELECT e.id, e.matricula, e.semestre, e.fecha_alta, e.fecha_baja, e.estatus,
            	CASE
               	WHEN e.estatus = 0 THEN 'Baja'
	            WHEN e.estatus = 1 THEN 'Activo'
	            WHEN e.estatus = 2 THEN 'Baja temporal'
	            ELSE
	        	'Desconocido'
            	END AS descestatus_estudiante,
                e.id_persona, p.nombre_completo, p.correo, p.telefono, p.fecha_nacimiento, p.curp, p.estatus as estatus_persona
                FROM escolar.estudiantes e
                INNER JOIN seguridad.personas p ON e.id_persona = p.id
                WHERE 1=1"; //Iniciamos con una condición siempre verdadera para facilitar la edición de filtros

                List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();
                //Filtro por estatus (activos/inactivos)
                if (soloActivos)
                {
                    query += " AND e.estatus = 1"; //Es un dato seguro y por eso s epone el numero uno especificacmente 
                }
                //Filtro por rango de fechas
                if (fechaInicio != null && fechaFin != null)
                {
                    switch (tipofecha)
                    {
                        case 1: //fecha de nacimiento
                            query += " AND p.fecha_nacimiento BETWEEN @fechaInicio AND @fechaFin";
                            break;
                        case 2: //fecha de alta
                            query += " AND e.fecha_alta BETWEEN @fechaInicio AND @fechaFin";
                            break;
                        case 3: //fecha de  baja
                            query += " AND e.fecha_baja BETWEEN @fechaInicio AND @fechaFin";
                            break;
                    }
                    parametros.Add(_dbAccess.CreateParameter("@FechaInicio", fechaInicio.Value));
                    parametros.Add(_dbAccess.CreateParameter("@FechaFin", fechaFin.Value));
                }
                query += " ORDER BY e.id";

                //ejecuta conexión con la bd
                _dbAccess.Connect();

                //ejecuta la consulta de los parametros
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, parametros.ToArray());

                //Convertir los resultados a objetos Estudiante
                foreach (DataRow row in resultado.Rows)
                {
                    //crear un objeto persona
                    Personas personas = new Personas(
                        Convert.ToInt32(row["id_persona"]),
                        row["nombre_completo"].ToString() ?? "",
                        row["correo"].ToString() ?? "",
                        row["telefono"].ToString() ?? "",
                        row["curp"].ToString() ?? "",
                        row["fecha_nacimiento"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["fecha_nacimiento"]) : null,
                        Convert.ToBoolean(row["estatus_persona"]));

                    //crear objeto estudiante
                    Estudiantes estudiante = new Estudiantes(
                            Convert.ToInt32(row["id"]),
                            Convert.ToInt32(row["id_persona"]),
                            row["matricula"].ToString() ?? "",
                            row["semestre"].ToString() ?? "",
                            Convert.ToDateTime(row["fecha_alta"]),
                            row["fecha_baja"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["fecha_baja"]) : null,
                            Convert.ToInt32(row["estatus"]),
                            row["descestatus_estudiante"].ToString() ?? "Desconocido",
                            personas
                        );
                    estudiantes.Add(estudiante);
                }
                _logger.Debug($"Se obtuvieron {estudiantes.Count}registro de estudiantes");

                return estudiantes;
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Ocurrio un error al obtener estudiantes de la base de datos");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
            //return estudiantes;
        }

        public int InsertarEstudiante(Estudiantes estudiante)
        {
            try
            {
                if (estudiante?.DatosPersonales == null)
                {
                    _logger.Error("Los datos personales del estudiante son nulos");
                    return -1;
                }
                // Primero insertamos la persona 
                int idPersona = _personasData.InsertarPersona(estudiante.DatosPersonales);
                if (idPersona <= 0)
                {
                    _logger.Error($"No se pudo insertar la persona para el estudiante {estudiante.Matricula}");
                    return -1;
                }
                // Actualizar el IdPersona en el objeto estudiante 
                estudiante.IdPersona = idPersona;

                // Luego insertamos el estudiante 
                string query = @" 
                    INSERT INTO escolar.estudiantes (id_persona, matricula, semestre, fecha_alta, estatus) 
                    VALUES (@IdPersona, @Matricula, @Semestre, @FechaAlta, @Estatus) 
                    RETURNING id";

                // Crea los parámetros 
                NpgsqlParameter paramIdPersona = _dbAccess.CreateParameter("@IdPersona", estudiante.IdPersona);
                NpgsqlParameter paramMatricula = _dbAccess.CreateParameter("@Matricula", estudiante.Matricula);
                NpgsqlParameter paramSemestre = _dbAccess.CreateParameter("@Semestre", estudiante.Semestre);
                NpgsqlParameter paramFechaAlta = _dbAccess.CreateParameter("@FechaAlta", estudiante.FechaAlta);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", estudiante.Estatus);

                // Establece la conexión a la BD 
                _dbAccess.Connect();

                // Ejecuta la inserción y obtiene el ID generado 
                object? resultado = _dbAccess.ExecuteScalar(query, paramIdPersona, paramMatricula,
                                                            paramSemestre, paramFechaAlta, paramEstatus);
                // Convierte el resultado a entero 
                int idestudiante_generado = Convert.ToInt32(resultado);
                _logger.Info($"Estudiante insertado correctamente con ID: {idestudiante_generado}");

                // Actualizar el Id en el objeto estudiante 
                //estudiante.Id idestudiante_generado; 

                return idestudiante_generado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al insertar el estudiante con matricula {estudiante.Matricula}");
                return -1;
            }
            finally
            {
                // Asegura que se cierre la conexión 
                _dbAccess.Disconnect();
            }
        }

        /// <summary> 
        /// Verifica si una matrícula ya está registrada en la base de datos. 
        ///</summary> 
        /// <param name="matricula">Matricula a verificar</param> 
        /// <returns>True si la matrícula ya existe, false en caso contrario</returns> 
        public bool ExisteMatricula(string matricula)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM escolar.estudiantes WHERE matricula = @Matricula";
                
                // Crea el parámetro 
                NpgsqlParameter paramMatricula = _dbAccess.CreateParameter("@Matricula", matricula);
                
                // Establece la conexión a la BD 
                _dbAccess.Connect();
                
                // Ejecuta la consulta 
                object? resultado = _dbAccess.ExecuteScalar(query, paramMatricula);
                
                int cantidad = Convert.ToInt32(resultado);
                bool existe = cantidad > 0;
                return existe;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al verificar la existencia de la matrícula {matricula}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión 
                _dbAccess.Disconnect();
            }
        }

        public Estudiantes? ObtenerEstudiantePorId(int id)
        {
            try
            {
                string query = @"
                SELECT e.id, e.matricula, e.semestre, e.fecha_alta, e.fecha_baja, e.estatus,
                       e.id_persona, p.nombre_completo, p.correo, p.telefono, p.fecha_nacimiento, p.curp, p.estatus as estatus_persona
                FROM escolar.estudiantes e
                INNER JOIN seguridad.personas p ON e.id_persona = p.id
                WHERE e.id = @Id";

                //Crear los parámetros para la consulta
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@Id", id);

                //Establece la conexion a la BD
                _dbAccess.Connect();

                //Ejecutar la consulta con el parametro
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramId);

                if (resultado.Rows.Count == 0)
                {
                    _logger.Warn($"No se encontró el estudiante con ID {id}");
                    return null;
                }

                //Obtener la primera fila del resultado
                DataRow row = resultado.Rows[0];

                //Crear un objeto Personas con los datos de la fila
                Personas persona = new Personas(
                    Convert.ToInt32(row["id_persona"]),
                    row["nombre_completo"].ToString() ?? "",
                    row["correo"].ToString() ?? "",
                    row["telefono"].ToString() ?? "",
                    row["curp"].ToString() ?? "",
                    row["fecha_nacimiento"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["fecha_nacimiento"]) : null,
                    Convert.ToBoolean(row["estatus_persona"])
                );
                //Crear un objeto Estudiantes con los datos de la fila
                Estudiantes estudiante = new Estudiantes(
                    Convert.ToInt32(row["id"]),
                    Convert.ToInt32(row["id_persona"]),
                    row["matricula"].ToString() ?? "",
                    row["semestre"].ToString() ?? "",
                    Convert.ToDateTime(row["fecha_alta"]),
                    row["fecha_baja"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["fecha_baja"]) : null,
                    Convert.ToInt32(row["estatus"]),
                    row["estatus"].ToString() ?? "Desconocido",
                    persona
                );

                return estudiante;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener el estudiante con ID {id}");
                return null;
            }
            finally
            {
                //Desconectar de la base de datos
                _dbAccess.Disconnect();
            }
        }

        public bool ActualizarEstudiante(Estudiantes estudiante)
        {
            try
            {
                _logger.Debug($"Actualizando estudiante con ID {estudiante.Id} y persona con ID {estudiante.IdPersona}");

                //Primero actualizamos los datos de  la persona
                bool actulizacionPersonaExitosa = _personasData.ActualizarPersona(estudiante.DatosPersonales);

                if (!actulizacionPersonaExitosa)
                {
                    _logger.Error($"Error al actualizar la persona asociada al  ID estudiante {estudiante.IdPersona}");
                    return false;
                }

                //Actualizar el estudiante
                string queryEstudiante = @"
                       UPDATE escolar.estudiantes
                          SET matricula = @Matricula,
                            semestre = @Semestre,
                            fecha_alta = @FechaAlta,
                            estatus = @Estatus,
                            fecha_baja = @FechaBaja
                          WHERE id = @IdEstudiante";

                //Establecemos la conexion en la BD
                _dbAccess.Connect();

                //Crear los parámetros para la consulta
                NpgsqlParameter paramIdEstudiante = _dbAccess.CreateParameter("@IdEstudiante", estudiante.Id);
                NpgsqlParameter paramMatricula = _dbAccess.CreateParameter("@Matricula", estudiante.Matricula);
                NpgsqlParameter paramSemestre = _dbAccess.CreateParameter("@Semestre", estudiante.Semestre);
                NpgsqlParameter paramFechaAlta = _dbAccess.CreateParameter("@FechaAlta", estudiante.FechaAlta);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", estudiante.Estatus);
                NpgsqlParameter paramFechaBaja = _dbAccess.CreateParameter("@FechaBaja",
                    estudiante.FechaBaja.HasValue ? (object)estudiante.FechaBaja.Value : DBNull.Value);

                //Ejecutar la consulta de actualización del estudiante
                int filasAfectadasEstudiantes = _dbAccess.ExecuteNonQuery(queryEstudiante, paramIdEstudiante, paramMatricula,
                                                                paramSemestre, paramFechaAlta, paramEstatus, paramFechaBaja);
                bool exito = filasAfectadasEstudiantes > 0;

                if (!exito)
                {
                    _logger.Warn($"No se actualizó el estudiante con ID {estudiante.Id}. No se encontró el registro");

                }
                else
                {
                    _logger.Info($"Estudiante actualizado con ID: {estudiante.Id}");

                }
                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al actualizar el estudiante con ID {estudiante.Id}");
                return false;
            }
            finally
            {
                //Desconectar de la base de datos
                _dbAccess.Disconnect();
            }
        }
    }
}

