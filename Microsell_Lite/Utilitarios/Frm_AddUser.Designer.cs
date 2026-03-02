namespace Microsell_Lite.Utilitarios
{
    partial class Frm_AddUser
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
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle2 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AddUser));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.txt_idprovedor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_listo = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_cancel = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.txt_nombreProve = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_correo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_Abrir = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.elLabel2 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.cbo_dis = new Guna.UI.WinForms.GunaComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cbo_rol = new Guna.UI.WinForms.GunaComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.dtp_FechaVenc = new System.Windows.Forms.DateTimePicker();
            this.piclogo = new System.Windows.Forms.PictureBox();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piclogo)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.White;
            this.pnl_titu.Controls.Add(this.label15);
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(945, 43);
            this.pnl_titu.TabIndex = 1;
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Font = new System.Drawing.Font("Oxygen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Location = new System.Drawing.Point(12, 4);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(208, 31);
            this.label15.TabIndex = 44;
            this.label15.Text = "Registrar Usuario ";
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_cerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cerrar.ForeColor = System.Drawing.Color.White;
            this.btn_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cerrar.Image")));
            this.btn_cerrar.Location = new System.Drawing.Point(899, 4);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(32, 32);
            this.btn_cerrar.TabIndex = 6;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // txt_idprovedor
            // 
            this.txt_idprovedor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_idprovedor.Enabled = false;
            this.txt_idprovedor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_idprovedor.ForeColor = System.Drawing.Color.DimGray;
            this.txt_idprovedor.Location = new System.Drawing.Point(30, 80);
            this.txt_idprovedor.Name = "txt_idprovedor";
            this.txt_idprovedor.Size = new System.Drawing.Size(303, 18);
            this.txt_idprovedor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oxygen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Id ";
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
            this.btn_listo.Location = new System.Drawing.Point(519, 466);
            this.btn_listo.Name = "btn_listo";
            this.btn_listo.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_listo.Size = new System.Drawing.Size(141, 36);
            this.btn_listo.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Oxygen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.TabIndex = 6;
            this.btn_listo.TextStyle.Font = new System.Drawing.Font("Oxygen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btn_cancel.Location = new System.Drawing.Point(319, 466);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.btn_cancel.Size = new System.Drawing.Size(133, 36);
            this.btn_cancel.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.DimGray;
            this.btn_cancel.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.DimGray;
            this.btn_cancel.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Oxygen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.StateStyles.HoverStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_cancel.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_cancel.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_cancel.StateStyles.PressedStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.TextStyle.Font = new System.Drawing.Font("Oxygen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.TextStyle.Text = "Cancelar";
            this.btn_cancel.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancel.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // txt_nombreProve
            // 
            this.txt_nombreProve.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombreProve.ForeColor = System.Drawing.Color.DimGray;
            this.txt_nombreProve.Location = new System.Drawing.Point(27, 149);
            this.txt_nombreProve.Name = "txt_nombreProve";
            this.txt_nombreProve.Size = new System.Drawing.Size(322, 25);
            this.txt_nombreProve.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oxygen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nombres";
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.ForeColor = System.Drawing.Color.DimGray;
            this.txtUser.Location = new System.Drawing.Point(27, 229);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(322, 25);
            this.txtUser.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Oxygen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Usuario";
            // 
            // txt_correo
            // 
            this.txt_correo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_correo.ForeColor = System.Drawing.Color.DimGray;
            this.txt_correo.Location = new System.Drawing.Point(728, 313);
            this.txt_correo.Name = "txt_correo";
            this.txt_correo.Size = new System.Drawing.Size(192, 25);
            this.txt_correo.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Oxygen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(725, 294);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Correo";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.DodgerBlue;
            this.label9.Dock = System.Windows.Forms.DockStyle.Right;
            this.label9.Location = new System.Drawing.Point(942, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(3, 495);
            this.label9.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.DodgerBlue;
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Location = new System.Drawing.Point(0, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(3, 495);
            this.label10.TabIndex = 21;
            // 
            // lbl_Abrir
            // 
            this.lbl_Abrir.AutoSize = true;
            this.lbl_Abrir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Abrir.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Abrir.Location = new System.Drawing.Point(477, 408);
            this.lbl_Abrir.Name = "lbl_Abrir";
            this.lbl_Abrir.Size = new System.Drawing.Size(70, 15);
            this.lbl_Abrir.TabIndex = 26;
            this.lbl_Abrir.Text = "_ Examinar";
            this.lbl_Abrir.Click += new System.EventHandler(this.lbl_Abrir_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // elLabel2
            // 
            this.elLabel2.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.elLabel2.BackgroundStyle.SolidColor = System.Drawing.Color.Transparent;
            this.elLabel2.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            paintStyle2.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle2.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel2.FlashStyle = paintStyle2;
            this.elLabel2.Location = new System.Drawing.Point(25, 77);
            this.elLabel2.Name = "elLabel2";
            this.elLabel2.Size = new System.Drawing.Size(324, 25);
            this.elLabel2.TabIndex = 28;
            this.elLabel2.TabStop = false;
            this.elLabel2.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // cbo_dis
            // 
            this.cbo_dis.BackColor = System.Drawing.Color.Transparent;
            this.cbo_dis.BaseColor = System.Drawing.Color.White;
            this.cbo_dis.BorderColor = System.Drawing.Color.Silver;
            this.cbo_dis.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_dis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_dis.FocusedColor = System.Drawing.Color.Empty;
            this.cbo_dis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_dis.ForeColor = System.Drawing.Color.Black;
            this.cbo_dis.FormattingEnabled = true;
            this.cbo_dis.Location = new System.Drawing.Point(25, 313);
            this.cbo_dis.Name = "cbo_dis";
            this.cbo_dis.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cbo_dis.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cbo_dis.Radius = 10;
            this.cbo_dis.Size = new System.Drawing.Size(234, 26);
            this.cbo_dis.TabIndex = 46;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Oxygen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(742, 129);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 16);
            this.label17.TabIndex = 49;
            this.label17.Text = "Fecha Naci.";
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.ForeColor = System.Drawing.Color.DimGray;
            this.txtApellido.Location = new System.Drawing.Point(416, 149);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(260, 25);
            this.txtApellido.TabIndex = 50;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Oxygen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(413, 130);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 16);
            this.label18.TabIndex = 51;
            this.label18.Text = "Apellidos";
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.ForeColor = System.Drawing.Color.DimGray;
            this.txtPass.Location = new System.Drawing.Point(416, 240);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(260, 25);
            this.txtPass.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oxygen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(416, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 53;
            this.label1.Text = "Contraseña";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Oxygen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(742, 221);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(107, 16);
            this.label16.TabIndex = 55;
            this.label16.Text = "Roles de Usuario";
            // 
            // cbo_rol
            // 
            this.cbo_rol.BackColor = System.Drawing.Color.Transparent;
            this.cbo_rol.BaseColor = System.Drawing.Color.White;
            this.cbo_rol.BorderColor = System.Drawing.Color.Silver;
            this.cbo_rol.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_rol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_rol.FocusedColor = System.Drawing.Color.Empty;
            this.cbo_rol.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_rol.ForeColor = System.Drawing.Color.Black;
            this.cbo_rol.FormattingEnabled = true;
            this.cbo_rol.Location = new System.Drawing.Point(728, 240);
            this.cbo_rol.Name = "cbo_rol";
            this.cbo_rol.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cbo_rol.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cbo_rol.Radius = 10;
            this.cbo_rol.Size = new System.Drawing.Size(192, 26);
            this.cbo_rol.TabIndex = 54;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Oxygen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(37, 293);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 16);
            this.label19.TabIndex = 57;
            this.label19.Text = "Distrito";
            // 
            // dtp_FechaVenc
            // 
            this.dtp_FechaVenc.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_FechaVenc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_FechaVenc.Location = new System.Drawing.Point(728, 154);
            this.dtp_FechaVenc.Name = "dtp_FechaVenc";
            this.dtp_FechaVenc.Size = new System.Drawing.Size(192, 20);
            this.dtp_FechaVenc.TabIndex = 495;
            // 
            // piclogo
            // 
            this.piclogo.Image = ((System.Drawing.Image)(resources.GetObject("piclogo.Image")));
            this.piclogo.Location = new System.Drawing.Point(446, 293);
            this.piclogo.Name = "piclogo";
            this.piclogo.Size = new System.Drawing.Size(136, 99);
            this.piclogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.piclogo.TabIndex = 22;
            this.piclogo.TabStop = false;
            this.piclogo.Tag = "";
            // 
            // Frm_AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(945, 538);
            this.Controls.Add(this.dtp_FechaVenc);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cbo_rol);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cbo_dis);
            this.Controls.Add(this.lbl_Abrir);
            this.Controls.Add(this.piclogo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_correo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_nombreProve);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_idprovedor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_listo);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.elLabel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_AddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Reg_Prod";
            this.Load += new System.EventHandler(this.Frm_AddUser_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piclogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.TextBox txt_idprovedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_correo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_nombreProve;
        private System.Windows.Forms.Label label3;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_listo;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_cancel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox piclogo;
        private System.Windows.Forms.Label lbl_Abrir;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel2;
        private System.Windows.Forms.Label label15;
        private Guna.UI.WinForms.GunaComboBox cbo_dis;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label16;
        private Guna.UI.WinForms.GunaComboBox cbo_rol;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dtp_FechaVenc;
    }
}