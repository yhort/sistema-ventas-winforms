namespace Microsell_Lite.Usuarios
{
    partial class Frm_RegUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_RegUsuario));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_reload = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_correo = new Guna.UI.WinForms.GunaTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_usu = new Guna.UI.WinForms.GunaTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_nombre = new Guna.UI.WinForms.GunaTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_id = new Guna.UI.WinForms.GunaTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_apellido = new Guna.UI.WinForms.GunaTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_pass = new Guna.UI.WinForms.GunaTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbo_rol = new Guna.UI.WinForms.GunaComboBox();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btn_listo = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_cancel = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbo_Distrito = new Guna.UI.WinForms.GunaComboBox();
            this.dtp_fecha = new System.Windows.Forms.DateTimePicker();
            this.piclogo = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label10 = new System.Windows.Forms.Label();
            this.elGroupBox1 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.pnl_nuevo = new System.Windows.Forms.Panel();
            this.lbl_nom = new System.Windows.Forms.Label();
            this.btn_quitar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.lsv_usu = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_idempresa = new System.Windows.Forms.Label();
            this.Lbl_ClaveCertificado = new System.Windows.Forms.Label();
            this.Lbl_ClaveCorreo = new System.Windows.Forms.Label();
            this.Lbl_CorreoEmi = new System.Windows.Forms.Label();
            this.Lbl_ClaveSol = new System.Windows.Forms.Label();
            this.Lbl_UsuarioSol = new System.Windows.Forms.Label();
            this.Lbl_DireccionEmpresa = new System.Windows.Forms.Label();
            this.Lbl_RucEmisor = new System.Windows.Forms.Label();
            this.Lbl_EmpresaEmisor = new System.Windows.Forms.Label();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piclogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elGroupBox1)).BeginInit();
            this.elGroupBox1.SuspendLayout();
            this.pnl_nuevo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(143)))), ((int)(((byte)(209)))));
            this.pnl_titu.Controls.Add(this.btn_reload);
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(657, 50);
            this.pnl_titu.TabIndex = 3;
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
            // 
            // btn_reload
            // 
            this.btn_reload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_reload.FlatAppearance.BorderSize = 0;
            this.btn_reload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_reload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_reload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reload.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reload.ForeColor = System.Drawing.Color.White;
            this.btn_reload.Image = ((System.Drawing.Image)(resources.GetObject("btn_reload.Image")));
            this.btn_reload.Location = new System.Drawing.Point(570, 10);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(32, 32);
            this.btn_reload.TabIndex = 56;
            this.btn_reload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_reload.UseVisualStyleBackColor = true;
            this.btn_reload.Click += new System.EventHandler(this.btn_reload_Click);
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
            this.btn_cerrar.Location = new System.Drawing.Point(613, 10);
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
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mantenimiento de Usuario";
            // 
            // txt_correo
            // 
            this.txt_correo.BackColor = System.Drawing.Color.Transparent;
            this.txt_correo.BaseColor = System.Drawing.Color.White;
            this.txt_correo.BorderColor = System.Drawing.Color.Silver;
            this.txt_correo.BorderSize = 1;
            this.txt_correo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_correo.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_correo.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(192)))));
            this.txt_correo.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(192)))));
            this.txt_correo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_correo.Location = new System.Drawing.Point(16, 260);
            this.txt_correo.MaxLength = 150;
            this.txt_correo.Name = "txt_correo";
            this.txt_correo.PasswordChar = '\0';
            this.txt_correo.Radius = 5;
            this.txt_correo.Size = new System.Drawing.Size(443, 30);
            this.txt_correo.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 31;
            this.label6.Text = "Correo";
            // 
            // txt_usu
            // 
            this.txt_usu.BackColor = System.Drawing.Color.Transparent;
            this.txt_usu.BaseColor = System.Drawing.Color.White;
            this.txt_usu.BorderColor = System.Drawing.Color.Silver;
            this.txt_usu.BorderSize = 1;
            this.txt_usu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_usu.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_usu.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(192)))));
            this.txt_usu.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(192)))));
            this.txt_usu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_usu.Location = new System.Drawing.Point(16, 197);
            this.txt_usu.MaxLength = 150;
            this.txt_usu.Name = "txt_usu";
            this.txt_usu.PasswordChar = '\0';
            this.txt_usu.Radius = 5;
            this.txt_usu.Size = new System.Drawing.Size(211, 30);
            this.txt_usu.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "Usuario Login";
            // 
            // txt_nombre
            // 
            this.txt_nombre.BackColor = System.Drawing.Color.Transparent;
            this.txt_nombre.BaseColor = System.Drawing.Color.White;
            this.txt_nombre.BorderColor = System.Drawing.Color.Silver;
            this.txt_nombre.BorderSize = 1;
            this.txt_nombre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_nombre.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_nombre.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(192)))));
            this.txt_nombre.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(192)))));
            this.txt_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombre.Location = new System.Drawing.Point(16, 136);
            this.txt_nombre.MaxLength = 150;
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.PasswordChar = '\0';
            this.txt_nombre.Radius = 5;
            this.txt_nombre.Size = new System.Drawing.Size(211, 30);
            this.txt_nombre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "Nombre del Usuario";
            // 
            // txt_id
            // 
            this.txt_id.BackColor = System.Drawing.Color.Transparent;
            this.txt_id.BaseColor = System.Drawing.Color.White;
            this.txt_id.BorderColor = System.Drawing.Color.Silver;
            this.txt_id.BorderSize = 1;
            this.txt_id.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_id.Enabled = false;
            this.txt_id.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_id.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(192)))));
            this.txt_id.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(192)))));
            this.txt_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_id.Location = new System.Drawing.Point(16, 75);
            this.txt_id.MaxLength = 150;
            this.txt_id.Name = "txt_id";
            this.txt_id.PasswordChar = '\0';
            this.txt_id.Radius = 5;
            this.txt_id.Size = new System.Drawing.Size(69, 30);
            this.txt_id.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Id";
            // 
            // txt_apellido
            // 
            this.txt_apellido.BackColor = System.Drawing.Color.Transparent;
            this.txt_apellido.BaseColor = System.Drawing.Color.White;
            this.txt_apellido.BorderColor = System.Drawing.Color.Silver;
            this.txt_apellido.BorderSize = 1;
            this.txt_apellido.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_apellido.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_apellido.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(192)))));
            this.txt_apellido.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(192)))));
            this.txt_apellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_apellido.Location = new System.Drawing.Point(248, 136);
            this.txt_apellido.MaxLength = 150;
            this.txt_apellido.Name = "txt_apellido";
            this.txt_apellido.PasswordChar = '\0';
            this.txt_apellido.Radius = 5;
            this.txt_apellido.Size = new System.Drawing.Size(211, 30);
            this.txt_apellido.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(252, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 34;
            this.label8.Text = "Apellidos";
            // 
            // txt_pass
            // 
            this.txt_pass.BackColor = System.Drawing.Color.Transparent;
            this.txt_pass.BaseColor = System.Drawing.Color.White;
            this.txt_pass.BorderColor = System.Drawing.Color.Silver;
            this.txt_pass.BorderSize = 1;
            this.txt_pass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_pass.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_pass.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(192)))));
            this.txt_pass.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(192)))));
            this.txt_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pass.Location = new System.Drawing.Point(248, 197);
            this.txt_pass.MaxLength = 150;
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '\0';
            this.txt_pass.Radius = 5;
            this.txt_pass.Size = new System.Drawing.Size(211, 30);
            this.txt_pass.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(252, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 16);
            this.label9.TabIndex = 36;
            this.label9.Text = "Clave Login";
            // 
            // cbo_rol
            // 
            this.cbo_rol.BackColor = System.Drawing.Color.Transparent;
            this.cbo_rol.BaseColor = System.Drawing.Color.White;
            this.cbo_rol.BorderColor = System.Drawing.Color.Silver;
            this.cbo_rol.BorderSize = 1;
            this.cbo_rol.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_rol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_rol.FocusedColor = System.Drawing.Color.Empty;
            this.cbo_rol.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_rol.ForeColor = System.Drawing.Color.Black;
            this.cbo_rol.FormattingEnabled = true;
            this.cbo_rol.Location = new System.Drawing.Point(16, 318);
            this.cbo_rol.Name = "cbo_rol";
            this.cbo_rol.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cbo_rol.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cbo_rol.Radius = 5;
            this.cbo_rol.Size = new System.Drawing.Size(211, 26);
            this.cbo_rol.TabIndex = 6;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(465, 25);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(24, 404);
            this.bunifuSeparator1.TabIndex = 98;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = true;
            // 
            // btn_listo
            // 
            this.btn_listo.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_listo.BackgroundStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(192)))));
            this.btn_listo.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo.BorderStyle.EdgeRadius = 7;
            this.btn_listo.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_listo.BorderStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(192)))));
            this.btn_listo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_listo.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_listo.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_listo.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_listo.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_listo.Location = new System.Drawing.Point(495, 126);
            this.btn_listo.Name = "btn_listo";
            this.btn_listo.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_listo.Size = new System.Drawing.Size(117, 49);
            this.btn_listo.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.TabIndex = 97;
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
            this.btn_cancel.Location = new System.Drawing.Point(495, 198);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.btn_cancel.Size = new System.Drawing.Size(117, 49);
            this.btn_cancel.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.DimGray;
            this.btn_cancel.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.DimGray;
            this.btn_cancel.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.StateStyles.HoverStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_cancel.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_cancel.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_cancel.StateStyles.PressedStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_cancel.TabIndex = 96;
            this.btn_cancel.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.TextStyle.Text = "Cancelar";
            this.btn_cancel.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancel.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 99;
            this.label5.Text = "Rol - Cargo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 362);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 101;
            this.label7.Text = "Distrito";
            // 
            // cbo_Distrito
            // 
            this.cbo_Distrito.BackColor = System.Drawing.Color.Transparent;
            this.cbo_Distrito.BaseColor = System.Drawing.Color.White;
            this.cbo_Distrito.BorderColor = System.Drawing.Color.Silver;
            this.cbo_Distrito.BorderSize = 1;
            this.cbo_Distrito.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_Distrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Distrito.FocusedColor = System.Drawing.Color.Empty;
            this.cbo_Distrito.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_Distrito.ForeColor = System.Drawing.Color.Black;
            this.cbo_Distrito.FormattingEnabled = true;
            this.cbo_Distrito.Location = new System.Drawing.Point(16, 381);
            this.cbo_Distrito.Name = "cbo_Distrito";
            this.cbo_Distrito.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cbo_Distrito.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cbo_Distrito.Radius = 5;
            this.cbo_Distrito.Size = new System.Drawing.Size(211, 26);
            this.cbo_Distrito.TabIndex = 100;
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha.Location = new System.Drawing.Point(21, 433);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(206, 20);
            this.dtp_fecha.TabIndex = 102;
            // 
            // piclogo
            // 
            this.piclogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.piclogo.Image = ((System.Drawing.Image)(resources.GetObject("piclogo.Image")));
            this.piclogo.Location = new System.Drawing.Point(302, 349);
            this.piclogo.Name = "piclogo";
            this.piclogo.Size = new System.Drawing.Size(107, 119);
            this.piclogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.piclogo.TabIndex = 103;
            this.piclogo.TabStop = false;
            this.piclogo.Click += new System.EventHandler(this.piclogo_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(305, 330);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 16);
            this.label10.TabIndex = 104;
            this.label10.Text = "Foto de Usuario";
            // 
            // elGroupBox1
            // 
            this.elGroupBox1.BackgroundStyle.GradientAngle = 45F;
            this.elGroupBox1.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.elGroupBox1.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.elGroupBox1.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.elGroupBox1.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(143)))), ((int)(((byte)(209)))));
            this.elGroupBox1.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elGroupBox1.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elGroupBox1.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elGroupBox1.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elGroupBox1.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.elGroupBox1.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.elGroupBox1.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elGroupBox1.CaptionStyle.Size = new System.Drawing.Size(120, 42);
            this.elGroupBox1.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.elGroupBox1.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.elGroupBox1.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.elGroupBox1.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.elGroupBox1.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.elGroupBox1.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.elGroupBox1.Controls.Add(this.pnl_nuevo);
            this.elGroupBox1.Controls.Add(this.btn_quitar);
            this.elGroupBox1.Controls.Add(this.btn_nuevo);
            this.elGroupBox1.Controls.Add(this.lsv_usu);
            this.elGroupBox1.Location = new System.Drawing.Point(12, 56);
            this.elGroupBox1.Name = "elGroupBox1";
            this.elGroupBox1.Padding = new System.Windows.Forms.Padding(4, 45, 4, 3);
            this.elGroupBox1.Size = new System.Drawing.Size(638, 526);
            this.elGroupBox1.TabIndex = 105;
            this.elGroupBox1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // pnl_nuevo
            // 
            this.pnl_nuevo.BackColor = System.Drawing.Color.White;
            this.pnl_nuevo.Controls.Add(this.lbl_nom);
            this.pnl_nuevo.Controls.Add(this.label3);
            this.pnl_nuevo.Controls.Add(this.btn_cancel);
            this.pnl_nuevo.Controls.Add(this.btn_listo);
            this.pnl_nuevo.Controls.Add(this.bunifuSeparator1);
            this.pnl_nuevo.Controls.Add(this.label10);
            this.pnl_nuevo.Controls.Add(this.txt_id);
            this.pnl_nuevo.Controls.Add(this.piclogo);
            this.pnl_nuevo.Controls.Add(this.label2);
            this.pnl_nuevo.Controls.Add(this.label7);
            this.pnl_nuevo.Controls.Add(this.dtp_fecha);
            this.pnl_nuevo.Controls.Add(this.cbo_Distrito);
            this.pnl_nuevo.Controls.Add(this.txt_nombre);
            this.pnl_nuevo.Controls.Add(this.label5);
            this.pnl_nuevo.Controls.Add(this.label4);
            this.pnl_nuevo.Controls.Add(this.txt_usu);
            this.pnl_nuevo.Controls.Add(this.label8);
            this.pnl_nuevo.Controls.Add(this.txt_apellido);
            this.pnl_nuevo.Controls.Add(this.cbo_rol);
            this.pnl_nuevo.Controls.Add(this.label9);
            this.pnl_nuevo.Controls.Add(this.txt_correo);
            this.pnl_nuevo.Controls.Add(this.txt_pass);
            this.pnl_nuevo.Controls.Add(this.label6);
            this.pnl_nuevo.Location = new System.Drawing.Point(0, 0);
            this.pnl_nuevo.Name = "pnl_nuevo";
            this.pnl_nuevo.Size = new System.Drawing.Size(650, 526);
            this.pnl_nuevo.TabIndex = 59;
            this.pnl_nuevo.Visible = false;
            // 
            // lbl_nom
            // 
            this.lbl_nom.AutoSize = true;
            this.lbl_nom.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nom.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_nom.Location = new System.Drawing.Point(182, 11);
            this.lbl_nom.Name = "lbl_nom";
            this.lbl_nom.Size = new System.Drawing.Size(158, 25);
            this.lbl_nom.TabIndex = 105;
            this.lbl_nom.Text = "Registrar Usuario";
            // 
            // btn_quitar
            // 
            this.btn_quitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_quitar.FlatAppearance.BorderSize = 0;
            this.btn_quitar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_quitar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_quitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_quitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_quitar.ForeColor = System.Drawing.Color.White;
            this.btn_quitar.Image = ((System.Drawing.Image)(resources.GetObject("btn_quitar.Image")));
            this.btn_quitar.Location = new System.Drawing.Point(84, 4);
            this.btn_quitar.Name = "btn_quitar";
            this.btn_quitar.Size = new System.Drawing.Size(32, 32);
            this.btn_quitar.TabIndex = 58;
            this.btn_quitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_quitar.UseVisualStyleBackColor = true;
            this.btn_quitar.Click += new System.EventHandler(this.btn_quitar_Click);
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_nuevo.FlatAppearance.BorderSize = 0;
            this.btn_nuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_nuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nuevo.ForeColor = System.Drawing.Color.White;
            this.btn_nuevo.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo.Image")));
            this.btn_nuevo.Location = new System.Drawing.Point(28, 4);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(32, 32);
            this.btn_nuevo.TabIndex = 57;
            this.btn_nuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // lsv_usu
            // 
            this.lsv_usu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsv_usu.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsv_usu.ForeColor = System.Drawing.Color.DimGray;
            this.lsv_usu.HideSelection = false;
            this.lsv_usu.Location = new System.Drawing.Point(7, 49);
            this.lsv_usu.Name = "lsv_usu";
            this.lsv_usu.Size = new System.Drawing.Size(624, 445);
            this.lsv_usu.TabIndex = 1;
            this.lsv_usu.UseCompatibleStateImageBehavior = false;
            this.lsv_usu.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsv_usu_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_idempresa);
            this.groupBox1.Controls.Add(this.Lbl_ClaveCertificado);
            this.groupBox1.Controls.Add(this.Lbl_ClaveCorreo);
            this.groupBox1.Controls.Add(this.Lbl_CorreoEmi);
            this.groupBox1.Controls.Add(this.Lbl_ClaveSol);
            this.groupBox1.Controls.Add(this.Lbl_UsuarioSol);
            this.groupBox1.Controls.Add(this.Lbl_DireccionEmpresa);
            this.groupBox1.Controls.Add(this.Lbl_RucEmisor);
            this.groupBox1.Controls.Add(this.Lbl_EmpresaEmisor);
            this.groupBox1.Location = new System.Drawing.Point(678, 253);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 169);
            this.groupBox1.TabIndex = 106;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // lbl_idempresa
            // 
            this.lbl_idempresa.AutoSize = true;
            this.lbl_idempresa.Location = new System.Drawing.Point(82, 136);
            this.lbl_idempresa.Name = "lbl_idempresa";
            this.lbl_idempresa.Size = new System.Drawing.Size(10, 13);
            this.lbl_idempresa.TabIndex = 8;
            this.lbl_idempresa.Text = "-";
            // 
            // Lbl_ClaveCertificado
            // 
            this.Lbl_ClaveCertificado.AutoSize = true;
            this.Lbl_ClaveCertificado.Location = new System.Drawing.Point(184, 64);
            this.Lbl_ClaveCertificado.Name = "Lbl_ClaveCertificado";
            this.Lbl_ClaveCertificado.Size = new System.Drawing.Size(10, 13);
            this.Lbl_ClaveCertificado.TabIndex = 7;
            this.Lbl_ClaveCertificado.Text = "-";
            // 
            // Lbl_ClaveCorreo
            // 
            this.Lbl_ClaveCorreo.AutoSize = true;
            this.Lbl_ClaveCorreo.Location = new System.Drawing.Point(184, 29);
            this.Lbl_ClaveCorreo.Name = "Lbl_ClaveCorreo";
            this.Lbl_ClaveCorreo.Size = new System.Drawing.Size(10, 13);
            this.Lbl_ClaveCorreo.TabIndex = 6;
            this.Lbl_ClaveCorreo.Text = "-";
            // 
            // Lbl_CorreoEmi
            // 
            this.Lbl_CorreoEmi.AutoSize = true;
            this.Lbl_CorreoEmi.Location = new System.Drawing.Point(53, 153);
            this.Lbl_CorreoEmi.Name = "Lbl_CorreoEmi";
            this.Lbl_CorreoEmi.Size = new System.Drawing.Size(10, 13);
            this.Lbl_CorreoEmi.TabIndex = 5;
            this.Lbl_CorreoEmi.Text = "-";
            // 
            // Lbl_ClaveSol
            // 
            this.Lbl_ClaveSol.AutoSize = true;
            this.Lbl_ClaveSol.Location = new System.Drawing.Point(53, 127);
            this.Lbl_ClaveSol.Name = "Lbl_ClaveSol";
            this.Lbl_ClaveSol.Size = new System.Drawing.Size(10, 13);
            this.Lbl_ClaveSol.TabIndex = 4;
            this.Lbl_ClaveSol.Text = "-";
            // 
            // Lbl_UsuarioSol
            // 
            this.Lbl_UsuarioSol.AutoSize = true;
            this.Lbl_UsuarioSol.Location = new System.Drawing.Point(53, 105);
            this.Lbl_UsuarioSol.Name = "Lbl_UsuarioSol";
            this.Lbl_UsuarioSol.Size = new System.Drawing.Size(10, 13);
            this.Lbl_UsuarioSol.TabIndex = 3;
            this.Lbl_UsuarioSol.Text = "-";
            // 
            // Lbl_DireccionEmpresa
            // 
            this.Lbl_DireccionEmpresa.AutoSize = true;
            this.Lbl_DireccionEmpresa.Location = new System.Drawing.Point(53, 89);
            this.Lbl_DireccionEmpresa.Name = "Lbl_DireccionEmpresa";
            this.Lbl_DireccionEmpresa.Size = new System.Drawing.Size(10, 13);
            this.Lbl_DireccionEmpresa.TabIndex = 2;
            this.Lbl_DireccionEmpresa.Text = "-";
            // 
            // Lbl_RucEmisor
            // 
            this.Lbl_RucEmisor.AutoSize = true;
            this.Lbl_RucEmisor.Location = new System.Drawing.Point(53, 58);
            this.Lbl_RucEmisor.Name = "Lbl_RucEmisor";
            this.Lbl_RucEmisor.Size = new System.Drawing.Size(10, 13);
            this.Lbl_RucEmisor.TabIndex = 1;
            this.Lbl_RucEmisor.Text = "-";
            // 
            // Lbl_EmpresaEmisor
            // 
            this.Lbl_EmpresaEmisor.AutoSize = true;
            this.Lbl_EmpresaEmisor.Location = new System.Drawing.Point(53, 29);
            this.Lbl_EmpresaEmisor.Name = "Lbl_EmpresaEmisor";
            this.Lbl_EmpresaEmisor.Size = new System.Drawing.Size(10, 13);
            this.Lbl_EmpresaEmisor.TabIndex = 0;
            this.Lbl_EmpresaEmisor.Text = "-";
            // 
            // Frm_RegUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(657, 594);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.elGroupBox1);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_RegUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Usuario";
            this.Load += new System.EventHandler(this.Frm_RegUsuario_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piclogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elGroupBox1)).EndInit();
            this.elGroupBox1.ResumeLayout(false);
            this.pnl_nuevo.ResumeLayout(false);
            this.pnl_nuevo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Button btn_reload;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaTextBox txt_pass;
        private System.Windows.Forms.Label label9;
        private Guna.UI.WinForms.GunaTextBox txt_apellido;
        private System.Windows.Forms.Label label8;
        private Guna.UI.WinForms.GunaTextBox txt_correo;
        private System.Windows.Forms.Label label6;
        private Guna.UI.WinForms.GunaTextBox txt_usu;
        private System.Windows.Forms.Label label4;
        private Guna.UI.WinForms.GunaTextBox txt_nombre;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaTextBox txt_id;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaComboBox cbo_rol;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_listo;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_cancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_fecha;
        private System.Windows.Forms.Label label7;
        private Guna.UI.WinForms.GunaComboBox cbo_Distrito;
        private System.Windows.Forms.PictureBox piclogo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label10;
        private Klik.Windows.Forms.v1.EntryLib.ELGroupBox elGroupBox1;
        private System.Windows.Forms.ListView lsv_usu;
        private System.Windows.Forms.Button btn_quitar;
        private System.Windows.Forms.Button btn_nuevo;
        private System.Windows.Forms.Panel pnl_nuevo;
        private System.Windows.Forms.Label lbl_nom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Lbl_EmpresaEmisor;
        private System.Windows.Forms.Label Lbl_CorreoEmi;
        private System.Windows.Forms.Label Lbl_ClaveSol;
        private System.Windows.Forms.Label Lbl_UsuarioSol;
        private System.Windows.Forms.Label Lbl_DireccionEmpresa;
        private System.Windows.Forms.Label Lbl_RucEmisor;
        private System.Windows.Forms.Label Lbl_ClaveCertificado;
        private System.Windows.Forms.Label Lbl_ClaveCorreo;
        private System.Windows.Forms.Label lbl_idempresa;
    }
}