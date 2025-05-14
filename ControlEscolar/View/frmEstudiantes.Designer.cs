namespace ControlEscolar.View
{
    partial class frmEstudiantes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblCtrlEstudiantes = new Label();
            scEstudiantes = new SplitContainer();
            groupBox1 = new GroupBox();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            lblDatosObligatorios = new Label();
            lblFechaBaja = new Label();
            dtpFechaBaja = new DateTimePicker();
            cBoxEstatus = new ComboBox();
            lblEstatus = new Label();
            lblFechaAlta = new Label();
            dtpFechaAlta = new DateTimePicker();
            ipbNoControl = new FontAwesome.Sharp.IconPictureBox();
            lblSemestre = new Label();
            txtNoControl = new TextBox();
            lblNoControl = new Label();
            lblFechaNac = new Label();
            upSemestre = new NumericUpDown();
            dtpFechaNacimiento = new DateTimePicker();
            txtCURP = new TextBox();
            lblCurp = new Label();
            txtTelefono = new TextBox();
            lblTeléfono = new Label();
            txtCorreo = new TextBox();
            lblCorreo = new Label();
            txtNombre = new TextBox();
            lblNombreEst = new Label();
            dgvEstudiantes = new DataGridView();
            groupBox3 = new GroupBox();
            lblTotalRegistros = new Label();
            cBoxTipoFecha = new ComboBox();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            dtpFechaFin = new DateTimePicker();
            lblFechaFin = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblFechaInicio = new Label();
            txtBusquedaTexto = new TextBox();
            lblBusquedaTexto = new Label();
            lblTipoFecha = new Label();
            groupBox2 = new GroupBox();
            lblRutaArchivo = new Label();
            btnCargaMasiva = new Button();
            btnMostrarCaptura = new Button();
            toolTip1 = new ToolTip(components);
            ofdArchivo = new OpenFileDialog();
            csmEstudiantes = new ContextMenuStrip(components);
            editarEstudianteToolStripMenuItem = new ToolStripMenuItem();
            btnExpExcel = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)scEstudiantes).BeginInit();
            scEstudiantes.Panel1.SuspendLayout();
            scEstudiantes.Panel2.SuspendLayout();
            scEstudiantes.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ipbNoControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)upSemestre).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEstudiantes).BeginInit();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            csmEstudiantes.SuspendLayout();
            SuspendLayout();
            // 
            // lblCtrlEstudiantes
            // 
            lblCtrlEstudiantes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCtrlEstudiantes.BackColor = SystemColors.ActiveCaption;
            lblCtrlEstudiantes.ForeColor = SystemColors.ButtonHighlight;
            lblCtrlEstudiantes.ImageAlign = ContentAlignment.TopCenter;
            lblCtrlEstudiantes.Location = new Point(0, 9);
            lblCtrlEstudiantes.Name = "lblCtrlEstudiantes";
            lblCtrlEstudiantes.Size = new Size(1019, 25);
            lblCtrlEstudiantes.TabIndex = 0;
            lblCtrlEstudiantes.Text = "Control de estudiantes";
            lblCtrlEstudiantes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // scEstudiantes
            // 
            scEstudiantes.Location = new Point(0, 37);
            scEstudiantes.Name = "scEstudiantes";
            // 
            // scEstudiantes.Panel1
            // 
            scEstudiantes.Panel1.Controls.Add(groupBox1);
            // 
            // scEstudiantes.Panel2
            // 
            scEstudiantes.Panel2.Controls.Add(dgvEstudiantes);
            scEstudiantes.Panel2.Controls.Add(groupBox3);
            scEstudiantes.Panel2.Controls.Add(groupBox2);
            scEstudiantes.Size = new Size(1013, 687);
            scEstudiantes.SplitterDistance = 336;
            scEstudiantes.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Controls.Add(lblDatosObligatorios);
            groupBox1.Controls.Add(lblFechaBaja);
            groupBox1.Controls.Add(dtpFechaBaja);
            groupBox1.Controls.Add(cBoxEstatus);
            groupBox1.Controls.Add(lblEstatus);
            groupBox1.Controls.Add(lblFechaAlta);
            groupBox1.Controls.Add(dtpFechaAlta);
            groupBox1.Controls.Add(ipbNoControl);
            groupBox1.Controls.Add(lblSemestre);
            groupBox1.Controls.Add(txtNoControl);
            groupBox1.Controls.Add(lblNoControl);
            groupBox1.Controls.Add(lblFechaNac);
            groupBox1.Controls.Add(upSemestre);
            groupBox1.Controls.Add(dtpFechaNacimiento);
            groupBox1.Controls.Add(txtCURP);
            groupBox1.Controls.Add(lblCurp);
            groupBox1.Controls.Add(txtTelefono);
            groupBox1.Controls.Add(lblTeléfono);
            groupBox1.Controls.Add(txtCorreo);
            groupBox1.Controls.Add(lblCorreo);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(lblNombreEst);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(330, 681);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Alta o edición";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // btnGuardar
            // 
            btnGuardar.ForeColor = SystemColors.ActiveCaptionText;
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnGuardar.IconColor = Color.Lime;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGuardar.IconSize = 32;
            btnGuardar.Location = new Point(183, 567);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(121, 36);
            btnGuardar.TabIndex = 22;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblDatosObligatorios
            // 
            lblDatosObligatorios.AutoSize = true;
            lblDatosObligatorios.Location = new Point(16, 575);
            lblDatosObligatorios.Name = "lblDatosObligatorios";
            lblDatosObligatorios.Size = new Size(143, 20);
            lblDatosObligatorios.TabIndex = 21;
            lblDatosObligatorios.Text = "Datos obligatorios *";
            // 
            // lblFechaBaja
            // 
            lblFechaBaja.AutoSize = true;
            lblFechaBaja.Location = new Point(16, 494);
            lblFechaBaja.Name = "lblFechaBaja";
            lblFechaBaja.Size = new Size(86, 20);
            lblFechaBaja.TabIndex = 20;
            lblFechaBaja.Text = "Fecha baja*";
            // 
            // dtpFechaBaja
            // 
            dtpFechaBaja.Format = DateTimePickerFormat.Short;
            dtpFechaBaja.Location = new Point(16, 517);
            dtpFechaBaja.Name = "dtpFechaBaja";
            dtpFechaBaja.Size = new Size(288, 27);
            dtpFechaBaja.TabIndex = 19;
            // 
            // cBoxEstatus
            // 
            cBoxEstatus.FormattingEnabled = true;
            cBoxEstatus.Location = new Point(16, 456);
            cBoxEstatus.Name = "cBoxEstatus";
            cBoxEstatus.Size = new Size(288, 28);
            cBoxEstatus.TabIndex = 18;
            // 
            // lblEstatus
            // 
            lblEstatus.AutoSize = true;
            lblEstatus.Location = new Point(16, 433);
            lblEstatus.Name = "lblEstatus";
            lblEstatus.Size = new Size(65, 20);
            lblEstatus.TabIndex = 17;
            lblEstatus.Text = "Estatus *";
            // 
            // lblFechaAlta
            // 
            lblFechaAlta.AutoSize = true;
            lblFechaAlta.Location = new Point(16, 366);
            lblFechaAlta.Name = "lblFechaAlta";
            lblFechaAlta.Size = new Size(86, 20);
            lblFechaAlta.TabIndex = 16;
            lblFechaAlta.Text = "Fecha alta *";
            // 
            // dtpFechaAlta
            // 
            dtpFechaAlta.Format = DateTimePickerFormat.Short;
            dtpFechaAlta.Location = new Point(16, 389);
            dtpFechaAlta.Name = "dtpFechaAlta";
            dtpFechaAlta.Size = new Size(288, 27);
            dtpFechaAlta.TabIndex = 15;
            // 
            // ipbNoControl
            // 
            ipbNoControl.BackColor = SystemColors.Control;
            ipbNoControl.ForeColor = SystemColors.ControlText;
            ipbNoControl.IconChar = FontAwesome.Sharp.IconChar.CircleArrowUp;
            ipbNoControl.IconColor = SystemColors.ControlText;
            ipbNoControl.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ipbNoControl.IconSize = 27;
            ipbNoControl.Location = new Point(264, 318);
            ipbNoControl.Name = "ipbNoControl";
            ipbNoControl.Size = new Size(29, 27);
            ipbNoControl.TabIndex = 14;
            ipbNoControl.TabStop = false;
            toolTip1.SetToolTip(ipbNoControl, "T/M-Año de ingreso-Número de alumno");
            // 
            // lblSemestre
            // 
            lblSemestre.AutoSize = true;
            lblSemestre.Location = new Point(204, 238);
            lblSemestre.Name = "lblSemestre";
            lblSemestre.Size = new Size(80, 20);
            lblSemestre.TabIndex = 13;
            lblSemestre.Text = "Semestre *";
            // 
            // txtNoControl
            // 
            txtNoControl.Location = new Point(16, 318);
            txtNoControl.MaxLength = 20;
            txtNoControl.Name = "txtNoControl";
            txtNoControl.Size = new Size(242, 27);
            txtNoControl.TabIndex = 12;
            // 
            // lblNoControl
            // 
            lblNoControl.AutoSize = true;
            lblNoControl.Location = new Point(16, 295);
            lblNoControl.Name = "lblNoControl";
            lblNoControl.Size = new Size(145, 20);
            lblNoControl.TabIndex = 11;
            lblNoControl.Text = "Número de control *";
            // 
            // lblFechaNac
            // 
            lblFechaNac.AutoSize = true;
            lblFechaNac.Location = new Point(16, 238);
            lblFechaNac.Name = "lblFechaNac";
            lblFechaNac.Size = new Size(159, 20);
            lblFechaNac.TabIndex = 10;
            lblFechaNac.Text = "Fecha de Nacimiento *";
            // 
            // upSemestre
            // 
            upSemestre.Location = new Point(204, 265);
            upSemestre.Maximum = new decimal(new int[] { 13, 0, 0, 0 });
            upSemestre.Name = "upSemestre";
            upSemestre.Size = new Size(100, 27);
            upSemestre.TabIndex = 9;
            upSemestre.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(16, 261);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(109, 27);
            dtpFechaNacimiento.TabIndex = 8;
            // 
            // txtCURP
            // 
            txtCURP.Location = new Point(16, 209);
            txtCURP.MaxLength = 18;
            txtCURP.Name = "txtCURP";
            txtCURP.Size = new Size(288, 27);
            txtCURP.TabIndex = 7;
            // 
            // lblCurp
            // 
            lblCurp.AutoSize = true;
            lblCurp.Location = new Point(16, 186);
            lblCurp.Name = "lblCurp";
            lblCurp.Size = new Size(55, 20);
            lblCurp.TabIndex = 6;
            lblCurp.Text = "CURP *";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(16, 156);
            txtTelefono.MaxLength = 15;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(288, 27);
            txtTelefono.TabIndex = 5;
            // 
            // lblTeléfono
            // 
            lblTeléfono.AutoSize = true;
            lblTeléfono.Location = new Point(16, 133);
            lblTeléfono.Name = "lblTeléfono";
            lblTeléfono.Size = new Size(77, 20);
            lblTeléfono.TabIndex = 4;
            lblTeléfono.Text = "Teléfono *";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(16, 103);
            txtCorreo.MaxLength = 100;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(288, 27);
            txtCorreo.TabIndex = 3;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(16, 80);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(64, 20);
            lblCorreo.TabIndex = 2;
            lblCorreo.Text = "Correo *";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(16, 50);
            txtNombre.MaxLength = 255;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(288, 27);
            txtNombre.TabIndex = 1;
            // 
            // lblNombreEst
            // 
            lblNombreEst.AutoSize = true;
            lblNombreEst.Location = new Point(16, 23);
            lblNombreEst.Name = "lblNombreEst";
            lblNombreEst.Size = new Size(147, 20);
            lblNombreEst.TabIndex = 0;
            lblNombreEst.Text = "Nombre estudiante *";
            // 
            // dgvEstudiantes
            // 
            dgvEstudiantes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEstudiantes.BackgroundColor = SystemColors.HighlightText;
            dgvEstudiantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEstudiantes.Location = new Point(9, 189);
            dgvEstudiantes.Name = "dgvEstudiantes";
            dgvEstudiantes.RowHeadersWidth = 51;
            dgvEstudiantes.Size = new Size(664, 495);
            dgvEstudiantes.TabIndex = 2;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblTotalRegistros);
            groupBox3.Controls.Add(cBoxTipoFecha);
            groupBox3.Controls.Add(iconButton1);
            groupBox3.Controls.Add(dtpFechaFin);
            groupBox3.Controls.Add(lblFechaFin);
            groupBox3.Controls.Add(dtpFechaInicio);
            groupBox3.Controls.Add(lblFechaInicio);
            groupBox3.Controls.Add(txtBusquedaTexto);
            groupBox3.Controls.Add(lblBusquedaTexto);
            groupBox3.Controls.Add(lblTipoFecha);
            groupBox3.Location = new Point(3, 83);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(667, 103);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Filtros";
            // 
            // lblTotalRegistros
            // 
            lblTotalRegistros.AutoSize = true;
            lblTotalRegistros.Location = new Point(13, 67);
            lblTotalRegistros.Name = "lblTotalRegistros";
            lblTotalRegistros.Size = new Size(111, 20);
            lblTotalRegistros.TabIndex = 28;
            lblTotalRegistros.Text = " Total Registros";
            // 
            // cBoxTipoFecha
            // 
            cBoxTipoFecha.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxTipoFecha.FormattingEnabled = true;
            cBoxTipoFecha.Location = new Point(99, 25);
            cBoxTipoFecha.Name = "cBoxTipoFecha";
            cBoxTipoFecha.Size = new Size(106, 28);
            cBoxTipoFecha.TabIndex = 27;
            cBoxTipoFecha.SelectedIndexChanged += cBoxTipoFecha_SelectedIndexChanged;
            // 
            // iconButton1
            // 
            iconButton1.ForeColor = SystemColors.ActiveCaptionText;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.Upwork;
            iconButton1.IconColor = Color.Cyan;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 32;
            iconButton1.Location = new Point(511, 59);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(121, 36);
            iconButton1.TabIndex = 23;
            iconButton1.Text = "Actualizar";
            iconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += iconButton1_Click;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(546, 26);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(109, 27);
            dtpFechaFin.TabIndex = 25;
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.Location = new Point(459, 30);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(68, 20);
            lblFechaFin.TabIndex = 26;
            lblFechaFin.Text = "Fecha fin";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(316, 26);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(109, 27);
            dtpFechaInicio.TabIndex = 23;
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Location = new Point(211, 26);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(87, 20);
            lblFechaInicio.TabIndex = 24;
            lblFechaInicio.Text = "Fecha inicio";
            // 
            // txtBusquedaTexto
            // 
            txtBusquedaTexto.Location = new Point(310, 60);
            txtBusquedaTexto.MaxLength = 15;
            txtBusquedaTexto.Name = "txtBusquedaTexto";
            txtBusquedaTexto.Size = new Size(195, 27);
            txtBusquedaTexto.TabIndex = 23;
            // 
            // lblBusquedaTexto
            // 
            lblBusquedaTexto.AutoSize = true;
            lblBusquedaTexto.Location = new Point(246, 63);
            lblBusquedaTexto.Name = "lblBusquedaTexto";
            lblBusquedaTexto.Size = new Size(52, 20);
            lblBusquedaTexto.TabIndex = 1;
            lblBusquedaTexto.Text = "Buscar";
            // 
            // lblTipoFecha
            // 
            lblTipoFecha.AutoSize = true;
            lblTipoFecha.Location = new Point(13, 23);
            lblTipoFecha.Name = "lblTipoFecha";
            lblTipoFecha.Size = new Size(79, 20);
            lblTipoFecha.TabIndex = 0;
            lblTipoFecha.Text = "Tipo fecha";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnExpExcel);
            groupBox2.Controls.Add(lblRutaArchivo);
            groupBox2.Controls.Add(btnCargaMasiva);
            groupBox2.Controls.Add(btnMostrarCaptura);
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(667, 77);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Herramientas";
            // 
            // lblRutaArchivo
            // 
            lblRutaArchivo.AutoSize = true;
            lblRutaArchivo.Location = new Point(319, 30);
            lblRutaArchivo.Name = "lblRutaArchivo";
            lblRutaArchivo.Size = new Size(186, 20);
            lblRutaArchivo.TabIndex = 2;
            lblRutaArchivo.Text = "Ruta de archivo a importar";
            // 
            // btnCargaMasiva
            // 
            btnCargaMasiva.Location = new Point(188, 26);
            btnCargaMasiva.Name = "btnCargaMasiva";
            btnCargaMasiva.Size = new Size(134, 29);
            btnCargaMasiva.TabIndex = 1;
            btnCargaMasiva.Text = "Carga masiva";
            btnCargaMasiva.UseVisualStyleBackColor = true;
            btnCargaMasiva.Click += btnCargaMasiva_Click;
            // 
            // btnMostrarCaptura
            // 
            btnMostrarCaptura.Location = new Point(6, 26);
            btnMostrarCaptura.Name = "btnMostrarCaptura";
            btnMostrarCaptura.Size = new Size(176, 29);
            btnMostrarCaptura.TabIndex = 0;
            btnMostrarCaptura.Text = "Mostrar captura";
            btnMostrarCaptura.UseVisualStyleBackColor = true;
            btnMostrarCaptura.Click += btnMostrarCaptura_Click;
            // 
            // ofdArchivo
            // 
            ofdArchivo.FileName = "CargaMasiva";
            // 
            // csmEstudiantes
            // 
            csmEstudiantes.ImageScalingSize = new Size(20, 20);
            csmEstudiantes.Items.AddRange(new ToolStripItem[] { editarEstudianteToolStripMenuItem });
            csmEstudiantes.Name = "csmEstudiantes";
            csmEstudiantes.Size = new Size(191, 28);
            // 
            // editarEstudianteToolStripMenuItem
            // 
            editarEstudianteToolStripMenuItem.Name = "editarEstudianteToolStripMenuItem";
            editarEstudianteToolStripMenuItem.Size = new Size(190, 24);
            editarEstudianteToolStripMenuItem.Text = "Editar estudiante";
            editarEstudianteToolStripMenuItem.Click += editarEstudianteToolStripMenuItem_Click;
            // 
            // btnExpExcel
            // 
            btnExpExcel.ForeColor = SystemColors.ActiveCaptionText;
            btnExpExcel.IconChar = FontAwesome.Sharp.IconChar.Upwork;
            btnExpExcel.IconColor = Color.Cyan;
            btnExpExcel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnExpExcel.IconSize = 32;
            btnExpExcel.Location = new Point(511, 23);
            btnExpExcel.Name = "btnExpExcel";
            btnExpExcel.Size = new Size(156, 45);
            btnExpExcel.TabIndex = 24;
            btnExpExcel.Text = "Exportar excel";
            btnExpExcel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExpExcel.UseVisualStyleBackColor = true;
            btnExpExcel.Click += btnExpExcel_Click;
            // 
            // frmEstudiantes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1016, 721);
            Controls.Add(scEstudiantes);
            Controls.Add(lblCtrlEstudiantes);
            Name = "frmEstudiantes";
            Text = "frmEstudiantes";
            Load += frmEstudiantes_Load;
            scEstudiantes.Panel1.ResumeLayout(false);
            scEstudiantes.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scEstudiantes).EndInit();
            scEstudiantes.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ipbNoControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)upSemestre).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEstudiantes).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            csmEstudiantes.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblCtrlEstudiantes;
        private SplitContainer scEstudiantes;
        private GroupBox groupBox1;
        private TextBox txtCURP;
        private Label lblCurp;
        private TextBox txtTelefono;
        private Label lblTeléfono;
        private TextBox txtCorreo;
        private Label lblCorreo;
        private TextBox txtNombre;
        private Label lblNombreEst;
        private DateTimePicker dtpFechaNacimiento;
        private NumericUpDown upSemestre;
        private Label lblFechaNac;
        private Label lblSemestre;
        private TextBox txtNoControl;
        private Label lblNoControl;
        private ToolTip toolTip1;
        private FontAwesome.Sharp.IconPictureBox ipbNoControl;
        private Label lblFechaBaja;
        private DateTimePicker dtpFechaBaja;
        private ComboBox cBoxEstatus;
        private Label lblEstatus;
        private Label lblFechaAlta;
        private DateTimePicker dtpFechaAlta;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private Label lblDatosObligatorios;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private Button btnCargaMasiva;
        private Button btnMostrarCaptura;
        private Label lblBusquedaTexto;
        private Label lblTipoFecha;
        private Label lblRutaArchivo;
        private Label lblFechaInicio;
        private TextBox txtBusquedaTexto;
        private FontAwesome.Sharp.IconButton iconButton1;
        private DateTimePicker dtpFechaFin;
        private Label lblFechaFin;
        private DateTimePicker dtpFechaInicio;
        private DataGridView dgvEstudiantes;
        private ComboBox comboBox1;
        private ComboBox cBoxTipoFecha;
        private OpenFileDialog ofdArchivo;
        private Label lblTotalRegistros;
        private ContextMenuStrip csmEstudiantes;
        private ToolStripMenuItem editarEstudianteToolStripMenuItem;
        private FontAwesome.Sharp.IconButton btnExpExcel;
    }
}