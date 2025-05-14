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
using ControlEscolar.Utilities;
using ControlEscolarCore.Controller;
using ControlEscolarCore.Model;
using DiseñoFormsCore.Model;

namespace ControlEscolar.View
{
    public partial class frmEstudiantes : Form
    {
        public frmEstudiantes(Form parent) //le decimos al constructor oye yo necesito un padre 
        {
            InitializeComponent(); //se crean componentes
            Formas.Inicializarforma(this, parent); //ya nació
            //Inicializarforma(parent);
        }

        private void frmEstudiantes_Load(object sender, EventArgs e)
        {
            InicializaVentanaEstudiantes();
            dgvEstudiantes.ContextMenuStrip = csmEstudiantes;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //private void Inicializarforma(Form parent)
        //{
        //    //Inicializamos la formal

        //    //Propiedades basicas.
        //    this.MdiParent =parent; // Asignar el padre MDI
        //    this.FormBorderStyle = FormBorderStyle.Sizable; // Permitir redimensionar
        //    this.MaximizeBox = true; // Permitir maximizar
        //    this.MinimizeBox = true; // Permitir minimizar
        //    this.WindowState = FormWindowState.Normal; // Estado inicial de la ventana

        //    //Priopiedades de control
        //    this.ControlBox = true;// Mostrar botones de control (minimizar, maximizar, cerrar
        //    this.ShowIcon = true;// Mostrar icono en la barra de título
        //    this.ShowInTaskbar = false; // No mostrar en la barra de tareas (ya que es una ventana hija)

        //    //Propiedades de tamaño
        //    this.AutoScaleMode = AutoScaleMode.Font; // Modo de escalado
        //    this.ClientSize = new Size(800, 600);    // Tamaño inicial
        //    this.MinimumSize = new Size(400, 300);   // Tamaño mínimo permitido
        //    this.MaximumSize = new Size(3440, 1440); // Tamaño máximo permitido

        //    //Propiedades de inicio
        //    this.StartPosition = FormStartPosition.CenterScreen; // Posición inicial

        //    //Propiedades de comportamuento
        //    this.AutoScroll = true;// Permitir scroll si el contenido es mayor que la ventana
        //    this.KeyPreview = true;// Permitir que el formulario reciba eventos de teclado
        //}

        private void PoblaComboEstatus()
        {
            //Crear un diccionario de valores
            Dictionary<int, string> list_estatus = new Dictionary<int, string>
{
    { 1, "Activo" },
    { 0, "Baja" },
    { 2, "Baja Temporal" }
};
            //Asignar el diccionario al combo
            cBoxEstatus.DataSource = new BindingSource(list_estatus, null);
            cBoxEstatus.DisplayMember = "Value";
            cBoxEstatus.ValueMember = "Key";

            cBoxEstatus.SelectedValue = 1;
        }

        private void InicializaVentanaEstudiantes()
        {
            poblaComboTipoFecha(); //
            PoblaComboEstatus();
            scEstudiantes.Panel1Collapsed = true; //vamos a cerrar desde código el panel 
            lblFechaBaja.Visible = false;
            dtpFechaAlta.Value = DateTime.Now;
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            //
            CargarEstudiantes();
        }

        private void poblaComboTipoFecha()
        {
            //Crear un diccionario de valores
            Dictionary<int, string> list_tipofechas = new Dictionary<int, string>
{
    { 1, "Nacimiento" },
    { 2, "Alta" },
    { 3, "Baja" }
};
            //Asignar el diccionario al combo
            cBoxTipoFecha.DataSource = new BindingSource(list_tipofechas, null);
            cBoxTipoFecha.DisplayMember = "Value"; //lo que se muestra
            cBoxTipoFecha.ValueMember = "Key"; //lo q se guarda como SelectedValue

            cBoxTipoFecha.SelectedValue = 2;
        }

        private void btnMostrarCaptura_Click(object sender, EventArgs e)
        {
            if (scEstudiantes.Panel1Collapsed)//cómo esta tu panel 1? esta colapsado?
            {
                scEstudiantes.Panel1Collapsed = false;//si esta colapsado te digo que no colapses
                btnMostrarCaptura.Text = "Ocultar captura rapida";//ahora te llamaras ocultar captura rapida
            } //en caso contrario entonces colapsalo y cambia el nombre 
            else
            {
                scEstudiantes.Panel1Collapsed = true;
                btnMostrarCaptura.Text = "Mostrar captura rapida";
            }
        }

        private void btnCargaMasiva_Click(object sender, EventArgs e)
        {
            ofdArchivo.Title = "Seleccionar archivo de Excel";
            ofdArchivo.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx"; //Filtro de archivos
                                                                                 //  ofdArchivo.InitialDirectory = "C:\\"; //Carpeta de inicio
            ofdArchivo.FilterIndex = 1; //El primer filtro es el que se muestra por default
            ofdArchivo.RestoreDirectory = true; //Recuerda la ultima carpeta abierta

            if (ofdArchivo.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofdArchivo.FileName;
                string extension = Path.GetExtension(filePath).ToLower();

                if (extension == ".xls" || extension == ".xlsx")
                {
                    //Cargar el archivo
                    //CargarArchivoExcel(filePath);
                    MessageBox.Show("El archivo valido " + filePath, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El archivo seleccionado no es un archivo de Excel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Determinar si estamos en modo edición o nuevo registro
            if (btnGuardar.Text == "Actualizar")//En modo edición
            {
                ActualizarEstudiante();
            }
            else //Modo nuevo registro
            {
                GuardarEstudiante();
            }
        }

        private void GuardarEstudiante()
        {
            try
            {
                // Validaciones a nivel de interfaz 
                if (DatosVacios())
                {
                    MessageBox.Show("Por favor, llene todos los campos.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!DatosValidos())
                {
                    return;
                }

                // Crear el objeto Persona con los datos del formulario 
                Personas persona = new Personas(
                txtNombre.Text.Trim(),
                txtCorreo.Text.Trim(),
                txtTelefono.Text.Trim(),
                txtCURP.Text.Trim()
                );

                // Asignar la fecha de nacimiento 
                persona.FechaNacimiento = dtpFechaNacimiento.Value;

                // Crear el objeto Estudiante con los datos del formulario 
                Estudiantes estudiante = new Estudiantes
                {
                    Matricula = txtNoControl.Text.Trim(),
                    Semestre = upSemestre.Text.Trim(),
                    FechaAlta = dtpFechaAlta.Value,
                    Estatus = 1, // Activo por defecto. 
                    DatosPersonales = persona
                };
                // Crear instancia del controlador 
                EstudiantesController estudiantesController = new EstudiantesController();

                // Llamar al método para registrar el estudiante utilizando el modelo
                var (idEstudiante, mensaje) = estudiantesController.RegistrarEstudiante(estudiante);

                // Verificar el resultado 
                if (idEstudiante > 0)
                {
                    MessageBox.Show(mensaje, "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos(); // Método para limpiar el formulario después de guardar 

                    // Actualizar la lista de estudiantes si está presente en la misma vista 
                    CargarEstudiantes();
                }
                else
                {
                    // Mostrar mensaje de error devuelto por el controlador 
                    MessageBox.Show(mensaje, "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Enfocar el campo apropiado basado en el código de error 
                    switch (idEstudiante)
                    {
                        case -2: // Error de CURP duplicado 
                            txtCURP.Focus();
                            txtCURP.SelectAll();
                            break;
                        case -3: // Error de Matrícula duplicada 
                            txtNoControl.Focus();
                            txtNoControl.SelectAll();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                //El detalle del error ya se guardará en el log por el controlador 
                MessageBox.Show("No se pudo completar el registro del estudiante." +
                    " Por favor intente nuevamente o contacte al administrador del sistema " + ex.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()

        {

            txtNombre.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtCURP.Clear();
            txtNoControl.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;
            dtpFechaAlta.Value = DateTime.Now;
            upSemestre.Value = 1;

        }


        private bool DatosVacios()
        {
            if (txtNombre.Text == "" || txtCorreo.Text == "" || txtTelefono.Text == ""
                || txtCURP.Text == "" || upSemestre.Text == "" || txtNoControl.Text == ""
                || upSemestre.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool DatosValidos()
        {
            if (!EstudiantesNegocio.EsCorreoValido(txtCorreo.Text.Trim()))
            {
                MessageBox.Show("Correo inválido.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!EstudiantesNegocio.EsCURPValido(txtCURP.Text.Trim()))
            {
                MessageBox.Show("CURP inválida.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!EstudiantesNegocio.EsNoControlValido(txtNoControl.Text.Trim()))
            {
                MessageBox.Show("Número de control inválido.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void cBoxTipoFecha_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            CargarEstudiantes();
        }

        private void CargarEstudiantes()
        {
            try
            {
                //Mostrar indicador de carga si es necesario
                Cursor = Cursors.WaitCursor;

                ///crear instancia del controlador
                EstudiantesController estudiantesController = new EstudiantesController();

                //Obtener la losta xde estudiantes
                List<Estudiantes> estudiantes = estudiantesController.ObtenerEstudiantes(
                    soloActivos: false,
                    tipofecha: cBoxTipoFecha.SelectedValue != null ? (int)cBoxTipoFecha.SelectedValue : 0,
                   fechaInicio: dtpFechaInicio.Enabled ? dtpFechaInicio.Value : (DateTime?)null,
             fechaFin: dtpFechaFin.Enabled ? dtpFechaFin.Value : (DateTime?)null);

                //Limpiar el DataGridView
                dgvEstudiantes.DataSource = null;
                if (estudiantes.Count == 0)
                {
                    lblTotalRegistros.Text = "Total: 0 registros";

                    if (!string.IsNullOrEmpty(txtBusquedaTexto.Text))
                    {
                        MessageBox.Show("No se encontraron estudiantes con el criterio de busqueda ", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Matrícula", typeof(string));
                dt.Columns.Add("Nombre Completo", typeof(string));
                dt.Columns.Add("Semestre", typeof(string));
                dt.Columns.Add("Correo", typeof(string));
                dt.Columns.Add("Teléfono", typeof(string));
                dt.Columns.Add("CURP", typeof(string));
                dt.Columns.Add("Fecha Nacimiento", typeof(DateTime));
                dt.Columns.Add("Fecha Alta", typeof(DateTime));
                dt.Columns.Add("Estatus", typeof(string));

                foreach (Estudiantes estudiante in estudiantes)
                {
                    dt.Rows.Add(
                        estudiante.Id,
                        estudiante.Matricula,
                        estudiante.DatosPersonales.NombreCompleto,
                        estudiante.Semestre,
                        estudiante.DatosPersonales.Correo,
                        estudiante.DatosPersonales.Telefono,
                        estudiante.DatosPersonales.Curp,
                        estudiante.DatosPersonales.FechaNacimiento,
                        estudiante.FechaAlta,
                        estudiante.DescripcionEstatus
                    );
                }

                // Asignar el DataTable como origen de datos
                dgvEstudiantes.DataSource = dt;

                //Configurar la apariencia del DataGridView
                ConfigurarDataGridView();

                //  Actualizar contador de registros
                lblTotalRegistros.Text = $"Total: {estudiantes.Count} registros";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargara los estudiantes, contacta al administardor del sistema",
                    "Error del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                //restaurar cursor
                Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// Obtiene los detalles del estudiante seleccionado y los muesrra en el formulario.
        /// </summary>
        /// <param name="idEstudiante">ID del estudiante a obtener</param>
        private void ObetenerDetalleEstudiante(int idEstudiante)
        {
            try
            {
                //Llamar al controlador para obtener el estudiante
                EstudiantesController controller_estudiante = new EstudiantesController();
                Estudiantes? estudiante = controller_estudiante.ObtenerDetalleEstudiante(idEstudiante);

                if (estudiante != null)
                {
                    //Poblar los controles con la información del estudiante
                    CargarDatosEstudiante(estudiante);

                    //cambiar a modo de edición
                    ModoEdicion(true);
                }
                else
                {
                    MessageBox.Show("No se pudo obtener la información del estudiante.",
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los detalles del estudiante: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga los datos del estudiante en los controles del formulario
        /// </summary>
        /// <param name="estudiante">Objeto Estudiante con los datos a mostrar</param>
        private void CargarDatosEstudiante(Estudiantes estudiante)
        {
            //Datos personales
            txtNombre.Text = estudiante.DatosPersonales.NombreCompleto;
            txtCorreo.Text = estudiante.DatosPersonales.Correo;
            txtTelefono.Text = estudiante.DatosPersonales.Telefono;
            txtCURP.Text = estudiante.DatosPersonales.Curp;

            if (estudiante.DatosPersonales.FechaNacimiento.HasValue)
                dtpFechaNacimiento.Value = estudiante.DatosPersonales.FechaNacimiento.Value;
            else
                dtpFechaNacimiento.Value = DateTime.Now;

            //Datos del estudiante
            txtNoControl.Text = estudiante.Matricula;

            //Buscar el semestre en el control
            //for (int i = 0; i < upSemestre.Items.Count; i++)
            //{
            //    if (upSemestre.Items[i].ToString() == estudiante.Semestre)
            //    {
            //        upSemestre.SelectedIndex = i;
            //        break;
            //    }
            //}
            if (int.TryParse(estudiante.Semestre, out int semestre))
            {
                upSemestre.Value = semestre;
            }
            else
            {
                upSemestre.Value = upSemestre.Minimum; // Valor por defecto si no se puede parsear
            }
            //Fechas
            dtpFechaAlta.Value = estudiante.FechaAlta;
            if (estudiante.FechaBaja.HasValue)
            {
                dtpFechaBaja.Value = estudiante.FechaBaja.Value;
                dtpFechaBaja.Enabled = true;
            }
            else
            {
                dtpFechaBaja.Value = DateTime.Now;
                dtpFechaBaja.Enabled = false;
            }

            //Estatus
            cBoxEstatus.SelectedValue = estudiante.Estatus;

            //Guardar el ID en una propiedad o tag para usarlo al actualizar
            this.Tag = estudiante.Id;
        }

        /// <summary>
        /// Cambia el modo de operación entre nuevo registro y edición
        /// </summary>
        /// <param name="edicion">True para modo edición, False para modo nuevo registro</param>
        private void ModoEdicion(bool edicion)
        {
            //Cambiar título y configurar botones según el modo
            groupBox1.Text = edicion ? "Editar Estudiante" : "Nuevo Estudiante";
            btnGuardar.Text = edicion ? "Actualizar" : "Guardar";

            //Si es modo edición, desactivar campos que no deberían modificarse
            txtNoControl.ReadOnly = edicion;

            //Activar el panel izquierdo para mostrar los detalles
            if (scEstudiantes.Panel1Collapsed)
            {
                scEstudiantes.Panel1Collapsed = false;
                btnMostrarCaptura.Text = "Ocultar captura rápida";
            }
        }
        private void ConfigurarDataGridView()

        {

            //Ajustes generales

            dgvEstudiantes.AllowUserToAddRows = false;

            dgvEstudiantes.AllowUserToDeleteRows = false;

            dgvEstudiantes.ReadOnly = true;

            // Ajustar el ancho de las columnas

            dgvEstudiantes.Columns["Matrícula"].Width = 100;

            dgvEstudiantes.Columns["Nombre Completo"].Width = 200;

            dgvEstudiantes.Columns["Semestre"].Width = 80;

            dgvEstudiantes.Columns["Correo"].Width = 180;

            dgvEstudiantes.Columns["Teléfono"].Width = 120;

            dgvEstudiantes.Columns["CURP"].Width = 150;

            dgvEstudiantes.Columns["Fecha Nacimiento"].Width = 120;

            dgvEstudiantes.Columns["Fecha Alta"].Width = 120;

            dgvEstudiantes.Columns["Estatus"].Width = 100;

            // Ocultar columna ID si es necesario

            dgvEstudiantes.Columns["ID"].Visible = false;

            // Formato para las fechas

            dgvEstudiantes.Columns["Fecha Nacimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvEstudiantes.Columns["Fecha Alta"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Alineación

            dgvEstudiantes.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvEstudiantes.Columns["Matrícula"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvEstudiantes.Columns["Semestre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvEstudiantes.Columns["Estatus"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Color alternado de filas

            dgvEstudiantes.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Selección de fila completa

            dgvEstudiantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Estilo de cabeceras

            dgvEstudiantes.EnableHeadersVisualStyles = false;

            dgvEstudiantes.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;

            dgvEstudiantes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvEstudiantes.ColumnHeadersDefaultCellStyle.Font = new Font(dgvEstudiantes.Font, FontStyle.Bold);

            dgvEstudiantes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ordenar al hacer clic en el encabezado

            dgvEstudiantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvEstudiantes.ColumnHeadersHeight = 35;

        }

        private void editarEstudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Verificar si hay una fila seleccionada en el grid
                if (dgvEstudiantes.SelectedRows.Count > 0)
                {
                    //Obtener el ID del estudiante de la fila seleccionada
                    int idEstudiante = Convert.ToInt32(dgvEstudiantes.SelectedRows[0].Cells["id"].Value);

                    //Llamar a la función para obtener y mostrar los detalles
                    ObetenerDetalleEstudiante(idEstudiante);
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un estudiate para editar.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al preparar la edición del estudiante: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Actualiza los datos de un estudiante existente
        /// </summary>
        private void ActualizarEstudiante()
        {
            try
            {
                // Validaciones a nivel interfaz
                if (DatosVacios())
                {
                    MessageBox.Show("Por favor, llene todos los campos", "Infomración del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!DatosValidos())
                {
                    return;
                }

                //Obtener el ID del estudiante almacenado en el Tag
                if (this.Tag == null || !(this.Tag is int))
                {
                    MessageBox.Show("No se ha seleccionado un estudiante para actualizar", "Información del sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idEstudiante = (int)this.Tag;

                //Crear el objeto Persona con los datos del formulario
                Personas persona = new Personas
                {
                    Id = idEstudiante, // Se actualizará con el valor correcto en el controller
                    NombreCompleto = txtNombre.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Curp = txtCURP.Text.Trim(),
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Estatus = true //Asumimos que la persona está activa
                };

                //Crear el objeto estudiante con los datos del formulario
                Estudiantes estudiante = new Estudiantes
                {
                    Id = idEstudiante,
                    IdPersona = 0, //Se actualizará con el valor correcto en el controller
                    Matricula = txtNoControl.Text.Trim(),
                    Semestre = upSemestre.Text.Trim(),
                    FechaAlta = dtpFechaAlta.Value,
                    Estatus = cBoxEstatus.SelectedValue != null ? (int)cBoxEstatus.SelectedValue : 1, // 0=Baja, 1=Activo, 2=Baja temporal
                    DatosPersonales = persona
                };

                //Asignar fecha de baja si corresponde
                if (cBoxEstatus.SelectedIndex == 0)//si el estatus es "Baja"
                {
                    estudiante.FechaBaja = dtpFechaBaja.Value;
                }
                else if (dtpFechaBaja.Enabled && cBoxEstatus.SelectedIndex == 2)//Si es "Baja temporal" y hay fehca
                {
                    estudiante.FechaBaja = dtpFechaBaja.Value;
                }
                else
                {
                    estudiante.FechaBaja = null;
                }

                //Crear intancia del controlador
                EstudiantesController estudiantesController = new EstudiantesController();

                //Lllamar al método para actualizar el estudiante utilizando el modelo
                var (resultado, mensaje) = estudiantesController.ActualizarEstudiante(estudiante);

                //Verificar el resultado
                if (resultado)
                {
                    MessageBox.Show(mensaje, "Infromación del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Limpiar formulario y restablecer modo
                    LimpiarCampos();
                    ModoEdicion(false);

                    //Actualizar la lista de estudiantes
                    CargarEstudiantes();
                }
                else
                {
                    //Mostrar mensaje de error devuelto por el controlador
                    MessageBox.Show(mensaje, "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //El detalle del error ya se guardará en el log por el controlador
                MessageBox.Show("No se pudo completar la actualización del estudiante. Por favor, intente de nuevo o contacte al administrador del sistema",
                    "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ImportarExcel()
        {
            try
            {
                //Crear instancia del controlador
                EstudiantesController estudiantesController = new EstudiantesController();

                //Obtener los filtros actuales de la interfaz
                bool soloActivos = true; //chkSoloActivos.Checked
                int tipoFecha = cBoxTipoFecha.SelectedValue != null ?
                    (int)cBoxTipoFecha.SelectedValue : 0;
                DateTime? fechaInicio = dtpFechaInicio.Value;
                DateTime? fechaFin = dtpFechaFin.Value;

                // Mostrar diálogo para guardar archivo 
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
                    saveFileDialog.Title = "Guardar archivo de Excel";
                    saveFileDialog.FileName = $"Estudiantes_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                    saveFileDialog.InitialDirectory = Environment.GetFolderPath(
                    Environment.SpecialFolder.Desktop);
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Mostrar cursor de espera 
                        Cursor.Current = Cursors.WaitCursor;
                        // Exportar usando el método del controlador 
                        bool resultado = estudiantesController.ExportarEstudiantesExcel(
                        saveFileDialog.FileName,
                        soloActivos,
                        tipoFecha,
                        fechaInicio,
                        fechaFin);
                        // Restaurar cursor normal 
                        Cursor.Current = Cursors.Default;

                        if (resultado)
                        {
                            MessageBox.Show("Archivo Excel exportado correctamente",
                            "Éxito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                            // Preguntar si desea abrir el archivo 
                            DialogResult abrirArchivo = MessageBox.Show(
                            "¿Desea abrir el archivo Excel generado?",
                            "Abrir archivo",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                            if (abrirArchivo == DialogResult.Yes)
                            {
                                // Usar ProcessStartInfo para abrir el archivo con la aplicación asociada 
                                var startInfo = new System.Diagnostics.ProcessStartInfo
                                {
                                    FileName = saveFileDialog.FileName,
                                    UseShellExecute = true
                                };
                                System.Diagnostics.Process.Start(startInfo);
                            }
                        }

                        else
                        {
                            MessageBox.Show("No se encontraron estudiantes para exportar",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show($"Error al exportar a Excel: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                throw;
            }
        }

        private void btnExpExcel_Click(object sender, EventArgs e)
        {
            ImportarExcel();
        }
    }
}
