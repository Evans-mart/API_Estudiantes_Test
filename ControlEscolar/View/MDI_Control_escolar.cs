using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlEscolar.View
{
    public partial class MDI_Control_escolar : Form
    {
        public MDI_Control_escolar()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void estudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbreVentanaHija("frmestudiantes");
        }

        private void reporte111ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbreVentanaHija("frmreporte111");
        }

        private void reporte21ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbreVentanaHija("frmroles");
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios forma_Usuarios = new frmUsuarios(this);
            forma_Usuarios.Show();
        }

        private void reporte12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporte12 forma_Reporte12 = new frmReporte12(this);
            forma_Reporte12.Show();
        }

        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mosaicoHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal
                );
        }

        private void mosaicoVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void AbreVentanaHija(string nombre_forma)
        {
            foreach (Form form in this.MdiChildren) //es un ciclo que va a estar preguntando la fomra ya la tienes en tu coleccion?
            {
                if(form.Name.ToLower()==nombre_forma)
                {
                    // Si la ventana ya está abierta, traerla al frnete 
                    form.WindowState = FormWindowState.Normal;
                    form.BringToFront();
                    return;
                }
            }

            //si no está abierta, crear y mostrar una nueva instancia
            Form childForm;
            switch (nombre_forma.ToLower())
            {
                case "frmestudiantes":
                    childForm = new frmEstudiantes(this);
                break;
                case "frmreporte111":
                    childForm = new frmReporte111(this);
                    break;
                case "frmreporte12":
                    childForm = new frmReporte12(this);
                    break;
                case "frmroles":
                    childForm = new frmRoles(this);
                    break;
                case "frmusuarios":
                    childForm = new frmUsuarios(this);
                    break;
                default:  return;
            }
            childForm.Show();
        }
    }
}
