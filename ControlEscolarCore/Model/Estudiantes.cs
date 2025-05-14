using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscolarCore.Model;

namespace DiseñoFormsCore.Model
{
    public class Estudiantes
    {

        /// <summary>
        /// Identificador único del estudiante
        /// </summary>
        public int Id { get; set;}

        /// <summary>
        /// Identificador de la persona asociada con el estudiante
        /// </summary>
        public int IdPersona { get; set; }

        /// <summary>
        /// Matrícula única del estudiante
        /// </summary>
        public string Matricula { get; set; }

        /// <summary>
        /// Semestre o grado en el que está inscrito el estudiante
        /// </summary>
        public string Semestre { get; set; }

        /// <summary>
        /// Fecha en que el estudiante fue dado de alta en el sistema
        /// </summary>
        public DateTime FechaAlta { get; set; }

        /// <summary>
        /// Fecha en que el estudiante fue dado de baja (null si sigue activo)
        /// </summary>
        public DateTime? FechaBaja { get; set; }

        /// <summary>
        /// Estado del estudiante: 0 = Baja, 1 = Activo, 2 = Baja Temporal
        /// </summary>
        public int Estatus { get; set; }
        /// <summary>
        /// Estado del estudiante: 0 = Baja, 1 = Activo, 2 = Baja Temporal
        /// </summary>
        public string? DescripcionEstatus { get; }

        /// <summary>
        /// Datos personales del estudiante (relación con Persona)
        /// </summary>
        public Personas DatosPersonales { get; set; }

        public Estudiantes()
        {
            Matricula = string.Empty;
            Semestre = string.Empty;
            FechaAlta = DateTime.Now;
            Estatus = 1; // Por defecto, los estudiantes se crean activos
            DatosPersonales = new Personas();
        }

        /// <summary>
        /// Constructor con los datos basicos del estudiante, por defecto. 
        /// </summary>
        ///

        public Estudiantes(string matricula, string semestre, Personas datosPersonales)
        {
            Matricula = matricula;
            Semestre = semestre;
            FechaAlta = DateTime.Now;
            Estatus = 1;
            DatosPersonales = datosPersonales;
        }

        /// <summary>
        /// Constructor completo
        /// </summary>
        public Estudiantes(int id, int idPersona, string matricula, string semestre,
                         DateTime fechaAlta, DateTime? fechaBaja, int estatus, string desc_estatus, Personas datosPersonales)
        {
            Id = id;
            IdPersona = idPersona;
            Matricula = matricula;
            Semestre = semestre;
            FechaAlta = fechaAlta;
            FechaBaja = fechaBaja;
            Estatus = estatus;
            DescripcionEstatus = desc_estatus;
            DatosPersonales = datosPersonales;
        }


    }
}