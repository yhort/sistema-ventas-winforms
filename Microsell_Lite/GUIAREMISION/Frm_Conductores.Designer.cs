namespace Microsell_Lite.GUIAREMISION
{
    partial class Frm_Conductores
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Conductores));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_add = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.lbl_idconductor = new System.Windows.Forms.Label();
            this.txt_apellidos = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gunaTextBox5 = new Guna.UI.WinForms.GunaTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDireccion = new Guna.UI.WinForms.GunaTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDni = new Guna.UI.WinForms.GunaTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLicencia = new Guna.UI.WinForms.GunaTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTelefono = new Guna.UI.WinForms.GunaTextBox();
            this.dtp_fecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_nombreCond = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_idvehiculo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_listo = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_cancel = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.lsv_marca = new System.Windows.Forms.ListView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bt_delete = new System.Windows.Forms.Button();
            this.btn_Selecc = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.txt_buscar = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_add)).BeginInit();
            this.pnl_add.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.DimGray;
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(695, 43);
            this.pnl_titu.TabIndex = 1;
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_cerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cerrar.ForeColor = System.Drawing.Color.White;
            this.btn_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cerrar.Image")));
            this.btn_cerrar.Location = new System.Drawing.Point(653, 4);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(32, 32);
            this.btn_cerrar.TabIndex = 6;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar Conductores";
            // 
            // pnl_add
            // 
            this.pnl_add.BackgroundStyle.GradientAngle = 45F;
            this.pnl_add.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.pnl_add.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.pnl_add.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.DoubleSolid;
            this.pnl_add.BorderStyle.EdgeRadius = 5;
            this.pnl_add.BorderStyle.SolidColor = System.Drawing.Color.SkyBlue;
            this.pnl_add.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.pnl_add.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnl_add.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.pnl_add.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.pnl_add.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.pnl_add.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.pnl_add.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.pnl_add.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.pnl_add.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.pnl_add.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.pnl_add.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.pnl_add.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.pnl_add.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnl_add.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.pnl_add.CaptionStyle.Visible = false;
            this.pnl_add.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.pnl_add.Controls.Add(this.lbl_idconductor);
            this.pnl_add.Controls.Add(this.txt_apellidos);
            this.pnl_add.Controls.Add(this.label9);
            this.pnl_add.Controls.Add(this.gunaTextBox5);
            this.pnl_add.Controls.Add(this.label8);
            this.pnl_add.Controls.Add(this.txtDireccion);
            this.pnl_add.Controls.Add(this.label7);
            this.pnl_add.Controls.Add(this.txtDni);
            this.pnl_add.Controls.Add(this.label6);
            this.pnl_add.Controls.Add(this.txtLicencia);
            this.pnl_add.Controls.Add(this.label5);
            this.pnl_add.Controls.Add(this.txtTelefono);
            this.pnl_add.Controls.Add(this.dtp_fecha);
            this.pnl_add.Controls.Add(this.label4);
            this.pnl_add.Controls.Add(this.txt_nombreCond);
            this.pnl_add.Controls.Add(this.label3);
            this.pnl_add.Controls.Add(this.txt_idvehiculo);
            this.pnl_add.Controls.Add(this.label2);
            this.pnl_add.Controls.Add(this.btn_listo);
            this.pnl_add.Controls.Add(this.btn_cancel);
            this.pnl_add.Location = new System.Drawing.Point(9, 52);
            this.pnl_add.Name = "pnl_add";
            this.pnl_add.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnl_add.Size = new System.Drawing.Size(674, 412);
            this.pnl_add.TabIndex = 3;
            this.pnl_add.Visible = false;
            this.pnl_add.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // lbl_idconductor
            // 
            this.lbl_idconductor.AutoSize = true;
            this.lbl_idconductor.Location = new System.Drawing.Point(181, 43);
            this.lbl_idconductor.Name = "lbl_idconductor";
            this.lbl_idconductor.Size = new System.Drawing.Size(10, 13);
            this.lbl_idconductor.TabIndex = 31;
            this.lbl_idconductor.Text = "-";
            // 
            // txt_apellidos
            // 
            this.txt_apellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_apellidos.ForeColor = System.Drawing.Color.DimGray;
            this.txt_apellidos.Location = new System.Drawing.Point(79, 155);
            this.txt_apellidos.Name = "txt_apellidos";
            this.txt_apellidos.Size = new System.Drawing.Size(493, 24);
            this.txt_apellidos.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(79, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "Apellidos";
            // 
            // gunaTextBox5
            // 
            this.gunaTextBox5.BaseColor = System.Drawing.Color.White;
            this.gunaTextBox5.BorderColor = System.Drawing.Color.Silver;
            this.gunaTextBox5.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gunaTextBox5.FocusedBaseColor = System.Drawing.Color.White;
            this.gunaTextBox5.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaTextBox5.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.gunaTextBox5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaTextBox5.Location = new System.Drawing.Point(9, 455);
            this.gunaTextBox5.Name = "gunaTextBox5";
            this.gunaTextBox5.PasswordChar = '\0';
            this.gunaTextBox5.Size = new System.Drawing.Size(59, 30);
            this.gunaTextBox5.TabIndex = 26;
            this.gunaTextBox5.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 435);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "Distrito";
            this.label8.Visible = false;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BaseColor = System.Drawing.Color.White;
            this.txtDireccion.BorderColor = System.Drawing.Color.Silver;
            this.txtDireccion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDireccion.FocusedBaseColor = System.Drawing.Color.White;
            this.txtDireccion.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtDireccion.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDireccion.Location = new System.Drawing.Point(65, 326);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.PasswordChar = '\0';
            this.txtDireccion.Size = new System.Drawing.Size(32, 30);
            this.txtDireccion.TabIndex = 24;
            this.txtDireccion.Text = "-";
            this.txtDireccion.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(62, 306);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "Direccion";
            this.label7.Visible = false;
            // 
            // txtDni
            // 
            this.txtDni.BaseColor = System.Drawing.Color.White;
            this.txtDni.BorderColor = System.Drawing.Color.Silver;
            this.txtDni.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDni.FocusedBaseColor = System.Drawing.Color.White;
            this.txtDni.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtDni.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDni.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDni.Location = new System.Drawing.Point(79, 209);
            this.txtDni.Name = "txtDni";
            this.txtDni.PasswordChar = '\0';
            this.txtDni.Size = new System.Drawing.Size(129, 30);
            this.txtDni.TabIndex = 3;
            this.txtDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDni_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(78, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Dni";
            // 
            // txtLicencia
            // 
            this.txtLicencia.BaseColor = System.Drawing.Color.White;
            this.txtLicencia.BorderColor = System.Drawing.Color.Silver;
            this.txtLicencia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLicencia.FocusedBaseColor = System.Drawing.Color.White;
            this.txtLicencia.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtLicencia.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtLicencia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLicencia.Location = new System.Drawing.Point(443, 209);
            this.txtLicencia.Name = "txtLicencia";
            this.txtLicencia.PasswordChar = '\0';
            this.txtLicencia.Size = new System.Drawing.Size(129, 30);
            this.txtLicencia.TabIndex = 4;
            this.txtLicencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicencia_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(442, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "N° Licencia";
            // 
            // txtTelefono
            // 
            this.txtTelefono.BaseColor = System.Drawing.Color.White;
            this.txtTelefono.BorderColor = System.Drawing.Color.Silver;
            this.txtTelefono.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTelefono.FocusedBaseColor = System.Drawing.Color.White;
            this.txtTelefono.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtTelefono.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTelefono.Location = new System.Drawing.Point(78, 273);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.PasswordChar = '\0';
            this.txtTelefono.Size = new System.Drawing.Size(494, 30);
            this.txtTelefono.TabIndex = 5;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha.Location = new System.Drawing.Point(91, 490);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(46, 20);
            this.dtp_fecha.TabIndex = 15;
            this.dtp_fecha.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(77, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Telefono";
            // 
            // txt_nombreCond
            // 
            this.txt_nombreCond.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombreCond.ForeColor = System.Drawing.Color.DimGray;
            this.txt_nombreCond.Location = new System.Drawing.Point(81, 96);
            this.txt_nombreCond.Name = "txt_nombreCond";
            this.txt_nombreCond.Size = new System.Drawing.Size(491, 24);
            this.txt_nombreCond.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nombres";
            // 
            // txt_idvehiculo
            // 
            this.txt_idvehiculo.Enabled = false;
            this.txt_idvehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_idvehiculo.ForeColor = System.Drawing.Color.DimGray;
            this.txt_idvehiculo.Location = new System.Drawing.Point(82, 38);
            this.txt_idvehiculo.Name = "txt_idvehiculo";
            this.txt_idvehiculo.Size = new System.Drawing.Size(86, 22);
            this.txt_idvehiculo.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Id Conductor";
            // 
            // btn_listo
            // 
            this.btn_listo.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_listo.BackgroundStyle.SolidColor = System.Drawing.Color.DodgerBlue;
            this.btn_listo.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo.BorderStyle.EdgeRadius = 7;
            this.btn_listo.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_listo.BorderStyle.SolidColor = System.Drawing.Color.DodgerBlue;
            this.btn_listo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_listo.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_listo.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_listo.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_listo.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_listo.Location = new System.Drawing.Point(345, 336);
            this.btn_listo.Name = "btn_listo";
            this.btn_listo.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_listo.Size = new System.Drawing.Size(143, 39);
            this.btn_listo.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.TabIndex = 4;
            this.btn_listo.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_listo.TextStyle.Text = "Listo";
            this.btn_listo.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_listo.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_listo.Click += new System.EventHandler(this.btn_listo_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancel.BackgroundStyle.SolidColor = System.Drawing.Color.WhiteSmoke;
            this.btn_cancel.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel.BorderStyle.EdgeRadius = 7;
            this.btn_cancel.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_cancel.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.btn_cancel.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancel.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_cancel.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancel.Location = new System.Drawing.Point(154, 336);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.btn_cancel.Size = new System.Drawing.Size(157, 39);
            this.btn_cancel.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.DimGray;
            this.btn_cancel.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.DimGray;
            this.btn_cancel.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.StateStyles.HoverStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_cancel.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_cancel.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_cancel.StateStyles.PressedStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.TextStyle.Text = "Cancelar";
            this.btn_cancel.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancel.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // lsv_marca
            // 
            this.lsv_marca.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsv_marca.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsv_marca.HideSelection = false;
            this.lsv_marca.Location = new System.Drawing.Point(12, 87);
            this.lsv_marca.Name = "lsv_marca";
            this.lsv_marca.Size = new System.Drawing.Size(602, 369);
            this.lsv_marca.TabIndex = 4;
            this.lsv_marca.UseCompatibleStateImageBehavior = false;
            this.lsv_marca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsv_marca_KeyDown);
            this.lsv_marca.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsv_marca_MouseDoubleClick);
            // 
            // bt_delete
            // 
            this.bt_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_delete.FlatAppearance.BorderSize = 0;
            this.bt_delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.bt_delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.bt_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_delete.ForeColor = System.Drawing.Color.White;
            this.bt_delete.Image = ((System.Drawing.Image)(resources.GetObject("bt_delete.Image")));
            this.bt_delete.Location = new System.Drawing.Point(145, 52);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(32, 30);
            this.bt_delete.TabIndex = 13;
            this.bt_delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.bt_delete, "Eliminar");
            this.bt_delete.UseVisualStyleBackColor = true;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // btn_Selecc
            // 
            this.btn_Selecc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Selecc.FlatAppearance.BorderSize = 0;
            this.btn_Selecc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_Selecc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_Selecc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Selecc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Selecc.ForeColor = System.Drawing.Color.White;
            this.btn_Selecc.Image = ((System.Drawing.Image)(resources.GetObject("btn_Selecc.Image")));
            this.btn_Selecc.Location = new System.Drawing.Point(283, 50);
            this.btn_Selecc.Name = "btn_Selecc";
            this.btn_Selecc.Size = new System.Drawing.Size(32, 31);
            this.btn_Selecc.TabIndex = 12;
            this.btn_Selecc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btn_Selecc, "Seleccionar");
            this.btn_Selecc.UseVisualStyleBackColor = true;
            this.btn_Selecc.Visible = false;
            this.btn_Selecc.Click += new System.EventHandler(this.btn_Selecc_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_edit.FlatAppearance.BorderSize = 0;
            this.btn_edit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_edit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.ForeColor = System.Drawing.Color.White;
            this.btn_edit.Image = ((System.Drawing.Image)(resources.GetObject("btn_edit.Image")));
            this.btn_edit.Location = new System.Drawing.Point(98, 52);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(29, 32);
            this.btn_edit.TabIndex = 11;
            this.btn_edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btn_edit, "Editar");
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add.FlatAppearance.BorderSize = 0;
            this.btn_add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.Image")));
            this.btn_add.Location = new System.Drawing.Point(47, 52);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(32, 32);
            this.btn_add.TabIndex = 10;
            this.btn_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btn_add, "Agregar");
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // txt_buscar
            // 
            this.txt_buscar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txt_buscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_buscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_buscar.HintForeColor = System.Drawing.Color.Empty;
            this.txt_buscar.HintText = "Buscar";
            this.txt_buscar.isPassword = false;
            this.txt_buscar.LineFocusedColor = System.Drawing.Color.DodgerBlue;
            this.txt_buscar.LineIdleColor = System.Drawing.Color.DodgerBlue;
            this.txt_buscar.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.txt_buscar.LineThickness = 3;
            this.txt_buscar.Location = new System.Drawing.Point(328, 47);
            this.txt_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(258, 33);
            this.txt_buscar.TabIndex = 14;
            this.txt_buscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_buscar.OnValueChanged += new System.EventHandler(this.txt_buscar_OnValueChanged);
            this.txt_buscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_buscar_KeyDown);
            // 
            // Frm_Conductores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(695, 476);
            this.Controls.Add(this.pnl_add);
            this.Controls.Add(this.txt_buscar);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.lsv_marca);
            this.Controls.Add(this.bt_delete);
            this.Controls.Add(this.btn_Selecc);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Conductores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Productos";
            this.Load += new System.EventHandler(this.Frm_Reg_Prod_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_add)).EndInit();
            this.pnl_add.ResumeLayout(false);
            this.pnl_add.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label1;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_cancel;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_listo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lsv_marca;
        private System.Windows.Forms.Button btn_Selecc;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.ToolTip toolTip1;
        internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox pnl_add;
        internal System.Windows.Forms.TextBox txt_idvehiculo;
        internal System.Windows.Forms.TextBox txt_nombreCond;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txt_buscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_fecha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Guna.UI.WinForms.GunaTextBox txtTelefono;
        private Guna.UI.WinForms.GunaTextBox gunaTextBox5;
        private System.Windows.Forms.Label label8;
        private Guna.UI.WinForms.GunaTextBox txtDireccion;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txt_apellidos;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label lbl_idconductor;
        internal Guna.UI.WinForms.GunaTextBox txtLicencia;
        internal Guna.UI.WinForms.GunaTextBox txtDni;
    }
}