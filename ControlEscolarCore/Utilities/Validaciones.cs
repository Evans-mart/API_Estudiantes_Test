using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControlEscolarCore.Utilities
{
    public class Validaciones
    {
        public static bool EsCorreoValido (string correo)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch (correo, patron); //
        }
        public static bool EsCURPValido(string curp)
        {
            string patron = @"^[A-Z]{4}\d{6}[HM][A-Z]{5}[A-Z0-9]{2}$";
            return Regex.IsMatch(curp, patron); //
        }
        public static bool EsTelefonoValido(string telefono)
        {
            string patron = @"^\d{10}$"; ;
            return Regex.IsMatch(telefono, patron); //
        }
    }
}
