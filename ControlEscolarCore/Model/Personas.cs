using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEscolarCore.Model
{
    /// <summary>
    /// Modelo que representa a una persona en el sistema de control escolar
    /// Corresponde a la tabla "personas" en la base de datos
    public class Personas
    {
        public int Id { get; set; }

        /// <summary>
        /// Nombre completo de la persona
        /// </summary>
        public string NombreCompleto { get; set; }

        /// <summary>
        /// Correo electrónico de la persona
        /// </summary>
        public string Correo { get; set; }

        /// <summary>
        /// Número de teléfono de la persona
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// CURP (Clave Única de Registro de Población) de la persona
        /// </summary>
        public string Curp { get; set; }

        /// <summary>
        /// Fecha de nacimiento de la persona
        /// </summary>
        public DateTime? FechaNacimiento { get; set; }

        /// <summary>
        /// Indica si la persona está activa en el sistema
        /// </summary>
        public bool Estatus
        {
            get; set;
        }
        public Personas()
        {
            NombreCompleto = string.Empty;
            Correo = string.Empty;
            Telefono = string.Empty;
            Curp = string.Empty;
            Estatus = true; // Por defecto, las personas se crean con estatus 
        }

        /// <summary> 
        /// Constructor con los campos obligatorios 
        /// </summary> 
        ///<param name="nombreCompleto">Nombre completo de la persona</param> 
        ///<param name="correo">Correo electrónico</param> 
        /// <param name="telefono">Número de teléfono</param> 
        /// <param name="curp">CURP de la persona</param>

        public Personas(string nombreCompleto, string correo, string telefono, string curp)
        {
            NombreCompleto = nombreCompleto;
            Correo = correo;
            Telefono = telefono;
            Curp = curp;
            Estatus = true;
        }

        public Personas(int id, string nombreCompleto, string correo, string telefono, string curp, DateTime? fechaNacimiento, bool estatus)

        {
            Id = id;
            NombreCompleto = nombreCompleto;
            Correo = correo;
            Telefono = telefono;
            Curp = curp;
            FechaNacimiento = fechaNacimiento;
            Estatus = estatus;
        }
    }
}
