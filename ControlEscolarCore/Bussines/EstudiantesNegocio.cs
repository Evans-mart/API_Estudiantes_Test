using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ControlEscolarCore.Utilities;

namespace ControlEscolarCore.Bussines
{
    public class EstudiantesNegocio
    {
        public static bool EsCorreoValido (string correo)
        {
            return Validaciones.EsCorreoValido(correo);
        }
        public static bool EsCURPValido(string curp)
        {
            return Validaciones.EsCURPValido(curp);
        }
        public static bool EsNoControlValido(string control)
        {
            string patron = @"^(T|M)-\d{4}-\d{3,5}$";
            return Regex.IsMatch(control, patron);
        }

    }
}
