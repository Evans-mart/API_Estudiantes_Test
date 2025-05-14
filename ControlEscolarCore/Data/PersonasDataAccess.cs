using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ControlEscolarCore.Model;
using ControlEscolarCore.Utilities;
using Microsoft.Extensions.Logging;
using NLog;
using Npgsql;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControlEscolarCore.Data
{
    /// <summary>
    /// Clase que maneja las operaciones de acceso a datos para la entidad Personas
    /// en la tabla seguridad.personas de PstgresSQL
    /// </summary>
    public class PersonasDataAccess
    {
        //Logger para la clase
        private static readonly Logger _logger = LoggingManager.GetLogger("ControlEscolar.Data.PersonasDataAccess");

        //Instancia del acceso a datos de PostgreSQL
        private readonly PostgresSQLDataAccess _dbAccess;

        /// <summary>
        /// Constructor de la clase PersonasDataAccess
        /// </summary>

        public PersonasDataAccess()
        {
            try
            {
                //Obtiene la instancia única de PostgresSQLDataAccess (patrón Singleton)
                _dbAccess = PostgresSQLDataAccess.GetInstance();
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Error al inicializar PersonasDataAccess");
                throw;
            }
        }

        public int InsertarPersona(Personas persona)
        {
            try
            {
                string query = "INSERT INTO seguridad.personas (nombre_completo, correo, telefono, fecha_nacimiento, curp, estatus) " +
                    "VALUES (@NombreCompleto, @Correo, @Telefono, @FechaNacimiento, @Curp, @Estatus)" +
                    "RETURNING id";

                // Crea los parámetros
                NpgsqlParameter paramNombre = _dbAccess.CreateParameter("@NombreCompleto", persona.NombreCompleto);
                NpgsqlParameter paramCorreo = _dbAccess.CreateParameter("@Correo", persona.Correo);
                NpgsqlParameter paramTelefono = _dbAccess.CreateParameter("@Telefono", persona.Telefono);
                NpgsqlParameter paramFechaNac = _dbAccess.CreateParameter("@FechaNacimiento", persona.FechaNacimiento ?? (object)DBNull.Value);
                NpgsqlParameter paramCurp = _dbAccess.CreateParameter("@Curp", persona.Curp);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", persona.Estatus);

                // Establece la conexión a la BD 
                _dbAccess.Connect();

                // Ejecuta la inserción y obtiene el ID generado 
                object? resultado = _dbAccess.ExecuteScalar(query, paramNombre, paramCorreo, paramTelefono,
                                                          paramFechaNac, paramCurp, paramEstatus);
                // Convierte el resultado a entero 
                int idGenerado = Convert.ToInt32(resultado);
                _logger.Info($"Persona insertada correctamente con ID: {idGenerado}");
                return idGenerado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al insertar la persona {persona.NombreCompleto}");
                return -1;
            }
            finally
            {
                // Asegura que se cierre la conexión 
                _dbAccess.Disconnect();
            }
        }

        /// <summary> 
        /// Verifica si existe un CURP en la base de datos 
        /// </summary> 
        /// <param name="curp">CURP a verificar</param> 
        /// <returns>True si existe, False si no existe</returns> 
        
        public bool ExisteCurp(string curp)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM seguridad.personas WHERE curp = @Curp";
                NpgsqlParameter paramCurp = _dbAccess.CreateParameter("@Curp", curp);
                
                _dbAccess.Connect();
                
                object? resultado=_dbAccess.ExecuteScalar(query, paramCurp);
                int count = Convert.ToInt32(resultado);
                
                return count > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al verificar la existencia del CURP: {curp}");
                return false;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        public bool ActualizarPersona(Personas persona)
        {
            try
            {
                string query = "UPDATE seguridad.personas " +
                               "SET nombre_completo = @NombreCompleto, " +
                               "correo = @Correo, " +
                               "telefono = @Telefono, " +
                               "fecha_nacimiento = @FechaNacimiento, " +
                               "curp = @Curp, " +
                               "estatus = @Estatus " +
                               "WHERE id = @Id";

                //Crear los parámetros para la consulta
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@Id", persona.Id);
                NpgsqlParameter paramNombre = _dbAccess.CreateParameter("@NombreCompleto", persona.NombreCompleto);
                NpgsqlParameter paramCorreo = _dbAccess.CreateParameter("@Correo", persona.Correo);
                NpgsqlParameter paramTelefono = _dbAccess.CreateParameter("@Telefono", persona.Telefono);
                NpgsqlParameter paramFechaNac = _dbAccess.CreateParameter("@FechaNacimiento", persona.FechaNacimiento ?? (object)DBNull.Value);
                NpgsqlParameter paramCurp = _dbAccess.CreateParameter("@Curp", persona.Curp);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", persona.Estatus);

                //Establece la conexión a la base de datos
                _dbAccess.Connect();
                //Ejecuta la consulta de actualizacion
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramId, paramNombre, paramCorreo,
                                                                paramTelefono, paramFechaNac, paramCurp, paramEstatus);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Persona actualizada con ID: {persona.Id}");
                }
                else
                {
                    _logger.Warn($"No se encontró persona con ID: {persona.Id}. No se encontro el registro");
                }
                return exito;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al actualizar persona {persona.Id}");
                return false;
            }
            finally
            {
                //Cierra la conexión a la base de datos
                _dbAccess.Disconnect();
            }
        }
    }
}
