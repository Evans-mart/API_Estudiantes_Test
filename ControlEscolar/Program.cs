using ControlEscolar.View;
using NLog;
using ControlEscolarCore.Utilities;
using OfficeOpenXml;

namespace ControlEscolar
{
    internal static class Program
    {

        //Logger para el programa principal
        private static Logger? _logger;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
            _logger = LoggingManager.GetLogger("ControlEscolar.Program");
            _logger.Info("Aplicación iniciada");
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new View.MDI_Control_escolar());


            //frmLogin login_form = new frmLogin();

            //la forma esta en espera de una respuesta 
            //if(login_form.ShowDialog() == DialogResult.OK )
            //{
            //    Application.Run(new MDI_Control_escolar()); //Cuando se produce el ok, se levanat el MDI
            //}


        }
    }
}