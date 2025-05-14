using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlEscolarCore.Bussines;
using NLog;
using ControlEscolarCore.Utilities;

namespace ControlEscolar.View
{
    public partial class frmLogin : Form
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("Proyecto1.View.frmLogin");
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            //también funciona si solo pongo Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //txtUsuario.Text tiene todo lo que introdujo el usuario
            if (string.IsNullOrWhiteSpace(txtUsuario.Text)) //si esto esta vacio, mandamos el sig msj
            {
                MessageBox.Show("El campo de usuario no puede estar vacío", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //txtUsuario.Text tiene todo lo que introdujo el usuario
            if (string.IsNullOrWhiteSpace(txtContaseña.Text)) //si esto esta vacio, mandamos el sig msj
            {
                MessageBox.Show("El campo de contraseña no puede estar vacío", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //ya solo para que se salga del método
            }

            if (!UsuariosNegocio.EsFormatoValido(txtUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario no tiene un formato correcto", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //  MessageBox.Show("Listo para iniciar sesión", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //ocultamos la pantalla del login
            // this.Hide();
            //MDI_Control_escolar mdi = new MDI_Control_escolar();
            //mdi.Show(); //mostramos el MDI

            #region SOLUCION CORRECTA DE CERRAR LA APP
            this.DialogResult = DialogResult.OK;
            this.Close();
            #endregion

            #region Ejemplo de una region
            //Solamente es para que se vea un código limpio
            #endregion


        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            _logger.Info("Usuario accedio a inisiar sesión");
            _logger.Warn("Espacio en disco bajo");
            try
            {
                //Aquí provocamos una primera excepción
                try
                {
                    int divisor = 0;
                    int resultado = 10 / divisor; //Esto genererá una DivideByZeroException
                }
                catch (DivideByZeroException ex)
                {
                     throw new ApplicationException("Error al realizar el cálculo en la aplicación", ex);
                }
            }
            catch (Exception ex)
            {
                //Aquí puedes manejar la excepción que contiene la inner exception
                _logger.Error(ex, "Se produjo un error en la operación");
                //o registrar especificamente usando la inner exception
                if (ex.InnerException != null)
                {
                    _logger.Fatal(ex, $"Error critico con detalle interno: {ex.InnerException.Message}");
                }
            }
        }
    }
}
