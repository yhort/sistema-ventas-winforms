namespace Microsell_Lite.Proveedor
{
    partial class Frm_AddProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AddProveedor));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_listo = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_cancel = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.piclogo = new System.Windows.Forms.PictureBox();
            this.lbl_Abrir = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl_consul = new System.Windows.Forms.Label();
            this.Pic_load = new System.Windows.Forms.PictureBox();
            this.cbo_departamento = new Guna.UI.WinForms.GunaComboBox();
            this.cbo_provincia = new Guna.UI.WinForms.GunaComboBox();
            this.cbo_distrito = new Guna.UI.WinForms.GunaComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_idprovedor = new Guna.UI.WinForms.GunaTextBox();
            this.txt_nombreProve = new Guna.UI.WinForms.GunaTextBox();
            this.txt_direccion = new Guna.UI.WinForms.GunaTextBox();
            this.txt_telefono = new Guna.UI.WinForms.GunaTextBox();
            this.txt_correo = new Guna.UI.WinForms.GunaTextBox();
            this.txt_rubro = new Guna.UI.WinForms.GunaTextBox();
            this.txt_contacto = new Guna.UI.WinForms.GunaTextBox();
            this.txt_ruc = new Guna.UI.WinForms.GunaTextBox();
            this.btnBuscar = new Guna.UI.WinForms.GunaButton();
            this.txtTipo = new Guna.UI.WinForms.GunaTextBox();
            this.txtCondicion = new Guna.UI.WinForms.GunaTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piclogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_load)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(232)))));
            this.pnl_titu.Controls.Add(this.label15);
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(598, 43);
            this.pnl_titu.TabIndex = 1;
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(232)))));
            this.label15.Font = new System.Drawing.Font("Encode Sans Condensed Medium", 12.5F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(12, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(173, 27);
            this.label15.TabIndex = 44;
            this.label15.Text = "Registrar Proveedor ";
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
            this.btn_cerrar.Location = new System.Drawing.Point(552, 4);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(32, 32);
            this.btn_cerrar.TabIndex = 6;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label2.Location = new System.Drawing.Point(45, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Id Proveedor";
            // 
            // btn_listo
            // 
            this.btn_listo.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_listo.BackgroundStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(232)))));
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
            this.btn_listo.Location = new System.Drawing.Point(344, 639);
            this.btn_listo.Name = "btn_listo";
            this.btn_listo.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_listo.Size = new System.Drawing.Size(141, 48);
            this.btn_listo.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.TabIndex = 6;
            this.btn_listo.TextStyle.Font = new System.Drawing.Font("Encode Sans Condensed SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_listo.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_listo.TextStyle.Text = "Guardar";
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
            this.btn_cancel.Location = new System.Drawing.Point(97, 639);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.btn_cancel.Size = new System.Drawing.Size(147, 48);
            this.btn_cancel.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.DimGray;
            this.btn_cancel.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.DimGray;
            this.btn_cancel.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.StateStyles.HoverStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_cancel.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_cancel.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_cancel.StateStyles.PressedStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.TextStyle.Font = new System.Drawing.Font("Encode Sans Condensed SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_cancel.TextStyle.Text = "Cancelar";
            this.btn_cancel.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancel.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label3.Location = new System.Drawing.Point(45, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nombre de Proveedor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label4.Location = new System.Drawing.Point(45, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Direccion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label5.Location = new System.Drawing.Point(45, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Telefono/Celular";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label6.Location = new System.Drawing.Point(45, 413);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Rubro";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label8.Location = new System.Drawing.Point(45, 353);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 23);
            this.label8.TabIndex = 18;
            this.label8.Text = "Correo";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.DodgerBlue;
            this.label9.Dock = System.Windows.Forms.DockStyle.Right;
            this.label9.Location = new System.Drawing.Point(595, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(3, 678);
            this.label9.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.DodgerBlue;
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Location = new System.Drawing.Point(0, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(3, 678);
            this.label10.TabIndex = 21;
            // 
            // piclogo
            // 
            this.piclogo.Image = ((System.Drawing.Image)(resources.GetObject("piclogo.Image")));
            this.piclogo.Location = new System.Drawing.Point(225, 546);
            this.piclogo.Name = "piclogo";
            this.piclogo.Size = new System.Drawing.Size(134, 71);
            this.piclogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.piclogo.TabIndex = 22;
            this.piclogo.TabStop = false;
            this.piclogo.Tag = "";
            this.piclogo.Click += new System.EventHandler(this.piclogo_Click);
            // 
            // lbl_Abrir
            // 
            this.lbl_Abrir.AutoSize = true;
            this.lbl_Abrir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Abrir.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Abrir.Location = new System.Drawing.Point(365, 571);
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label11.Location = new System.Drawing.Point(328, 296);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 23);
            this.label11.TabIndex = 27;
            this.label11.Text = "Nombre de Contacto";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label12.Location = new System.Drawing.Point(45, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 23);
            this.label12.TabIndex = 35;
            this.label12.Text = "Ruc";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Image = ((System.Drawing.Image)(resources.GetObject("label13.Image")));
            this.label13.Location = new System.Drawing.Point(195, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 24);
            this.label13.TabIndex = 34;
            // 
            // lbl_consul
            // 
            this.lbl_consul.AutoSize = true;
            this.lbl_consul.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.lbl_consul.ForeColor = System.Drawing.Color.Green;
            this.lbl_consul.Location = new System.Drawing.Point(402, 100);
            this.lbl_consul.Name = "lbl_consul";
            this.lbl_consul.Size = new System.Drawing.Size(84, 23);
            this.lbl_consul.TabIndex = 37;
            this.lbl_consul.Text = "Consultando..";
            this.lbl_consul.Visible = false;
            // 
            // Pic_load
            // 
            this.Pic_load.Image = ((System.Drawing.Image)(resources.GetObject("Pic_load.Image")));
            this.Pic_load.Location = new System.Drawing.Point(401, 126);
            this.Pic_load.Name = "Pic_load";
            this.Pic_load.Size = new System.Drawing.Size(127, 51);
            this.Pic_load.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Pic_load.TabIndex = 36;
            this.Pic_load.TabStop = false;
            this.Pic_load.Visible = false;
            // 
            // cbo_departamento
            // 
            this.cbo_departamento.BackColor = System.Drawing.Color.Transparent;
            this.cbo_departamento.BaseColor = System.Drawing.Color.White;
            this.cbo_departamento.BorderColor = System.Drawing.Color.Silver;
            this.cbo_departamento.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_departamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_departamento.FocusedColor = System.Drawing.Color.Empty;
            this.cbo_departamento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_departamento.ForeColor = System.Drawing.Color.Black;
            this.cbo_departamento.FormattingEnabled = true;
            this.cbo_departamento.Location = new System.Drawing.Point(6, 14);
            this.cbo_departamento.Name = "cbo_departamento";
            this.cbo_departamento.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cbo_departamento.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cbo_departamento.Radius = 10;
            this.cbo_departamento.Size = new System.Drawing.Size(67, 26);
            this.cbo_departamento.TabIndex = 44;
            this.cbo_departamento.SelectedValueChanged += new System.EventHandler(this.cbo_departamento_SelectedValueChanged);
            // 
            // cbo_provincia
            // 
            this.cbo_provincia.BackColor = System.Drawing.Color.Transparent;
            this.cbo_provincia.BaseColor = System.Drawing.Color.White;
            this.cbo_provincia.BorderColor = System.Drawing.Color.Silver;
            this.cbo_provincia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_provincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_provincia.FocusedColor = System.Drawing.Color.Empty;
            this.cbo_provincia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_provincia.ForeColor = System.Drawing.Color.Black;
            this.cbo_provincia.FormattingEnabled = true;
            this.cbo_provincia.Location = new System.Drawing.Point(27, 68);
            this.cbo_provincia.Name = "cbo_provincia";
            this.cbo_provincia.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cbo_provincia.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cbo_provincia.Radius = 10;
            this.cbo_provincia.Size = new System.Drawing.Size(66, 26);
            this.cbo_provincia.TabIndex = 45;
            this.cbo_provincia.SelectedValueChanged += new System.EventHandler(this.cbo_provincia_SelectedValueChanged);
            // 
            // cbo_distrito
            // 
            this.cbo_distrito.BackColor = System.Drawing.Color.Transparent;
            this.cbo_distrito.BaseColor = System.Drawing.Color.White;
            this.cbo_distrito.BorderColor = System.Drawing.Color.Silver;
            this.cbo_distrito.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_distrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_distrito.FocusedColor = System.Drawing.Color.Empty;
            this.cbo_distrito.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_distrito.ForeColor = System.Drawing.Color.Black;
            this.cbo_distrito.FormattingEnabled = true;
            this.cbo_distrito.Location = new System.Drawing.Point(111, 20);
            this.cbo_distrito.Name = "cbo_distrito";
            this.cbo_distrito.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cbo_distrito.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cbo_distrito.Radius = 10;
            this.cbo_distrito.Size = new System.Drawing.Size(64, 26);
            this.cbo_distrito.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 47;
            this.label1.Text = "Departamento";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(14, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 16);
            this.label16.TabIndex = 48;
            this.label16.Text = "Provincia";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(57, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 16);
            this.label17.TabIndex = 49;
            this.label17.Text = "Distrito";
            // 
            // txt_idprovedor
            // 
            this.txt_idprovedor.BackColor = System.Drawing.Color.Transparent;
            this.txt_idprovedor.BaseColor = System.Drawing.Color.Transparent;
            this.txt_idprovedor.BorderColor = System.Drawing.Color.Silver;
            this.txt_idprovedor.BorderSize = 1;
            this.txt_idprovedor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_idprovedor.FocusedBaseColor = System.Drawing.Color.Transparent;
            this.txt_idprovedor.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_idprovedor.FocusedForeColor = System.Drawing.Color.Black;
            this.txt_idprovedor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_idprovedor.ForeColor = System.Drawing.Color.Black;
            this.txt_idprovedor.Location = new System.Drawing.Point(48, 76);
            this.txt_idprovedor.MultiLine = true;
            this.txt_idprovedor.Name = "txt_idprovedor";
            this.txt_idprovedor.PasswordChar = '\0';
            this.txt_idprovedor.Radius = 5;
            this.txt_idprovedor.Size = new System.Drawing.Size(206, 29);
            this.txt_idprovedor.TabIndex = 78;
            // 
            // txt_nombreProve
            // 
            this.txt_nombreProve.BackColor = System.Drawing.Color.Transparent;
            this.txt_nombreProve.BaseColor = System.Drawing.Color.Transparent;
            this.txt_nombreProve.BorderColor = System.Drawing.Color.Silver;
            this.txt_nombreProve.BorderSize = 1;
            this.txt_nombreProve.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_nombreProve.FocusedBaseColor = System.Drawing.Color.Transparent;
            this.txt_nombreProve.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_nombreProve.FocusedForeColor = System.Drawing.Color.Black;
            this.txt_nombreProve.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombreProve.ForeColor = System.Drawing.Color.Black;
            this.txt_nombreProve.Location = new System.Drawing.Point(48, 199);
            this.txt_nombreProve.MultiLine = true;
            this.txt_nombreProve.Name = "txt_nombreProve";
            this.txt_nombreProve.PasswordChar = '\0';
            this.txt_nombreProve.Radius = 5;
            this.txt_nombreProve.Size = new System.Drawing.Size(490, 29);
            this.txt_nombreProve.TabIndex = 79;
            // 
            // txt_direccion
            // 
            this.txt_direccion.BackColor = System.Drawing.Color.Transparent;
            this.txt_direccion.BaseColor = System.Drawing.Color.Transparent;
            this.txt_direccion.BorderColor = System.Drawing.Color.Silver;
            this.txt_direccion.BorderSize = 1;
            this.txt_direccion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_direccion.FocusedBaseColor = System.Drawing.Color.Transparent;
            this.txt_direccion.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_direccion.FocusedForeColor = System.Drawing.Color.Black;
            this.txt_direccion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_direccion.ForeColor = System.Drawing.Color.Black;
            this.txt_direccion.Location = new System.Drawing.Point(48, 261);
            this.txt_direccion.MultiLine = true;
            this.txt_direccion.Name = "txt_direccion";
            this.txt_direccion.PasswordChar = '\0';
            this.txt_direccion.Radius = 5;
            this.txt_direccion.Size = new System.Drawing.Size(490, 29);
            this.txt_direccion.TabIndex = 80;
            // 
            // txt_telefono
            // 
            this.txt_telefono.BackColor = System.Drawing.Color.Transparent;
            this.txt_telefono.BaseColor = System.Drawing.Color.Transparent;
            this.txt_telefono.BorderColor = System.Drawing.Color.Silver;
            this.txt_telefono.BorderSize = 1;
            this.txt_telefono.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_telefono.FocusedBaseColor = System.Drawing.Color.Transparent;
            this.txt_telefono.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_telefono.FocusedForeColor = System.Drawing.Color.Black;
            this.txt_telefono.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_telefono.ForeColor = System.Drawing.Color.Black;
            this.txt_telefono.Location = new System.Drawing.Point(48, 322);
            this.txt_telefono.MultiLine = true;
            this.txt_telefono.Name = "txt_telefono";
            this.txt_telefono.PasswordChar = '\0';
            this.txt_telefono.Radius = 5;
            this.txt_telefono.Size = new System.Drawing.Size(206, 31);
            this.txt_telefono.TabIndex = 81;
            // 
            // txt_correo
            // 
            this.txt_correo.BackColor = System.Drawing.Color.Transparent;
            this.txt_correo.BaseColor = System.Drawing.Color.Transparent;
            this.txt_correo.BorderColor = System.Drawing.Color.Silver;
            this.txt_correo.BorderSize = 1;
            this.txt_correo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_correo.FocusedBaseColor = System.Drawing.Color.Transparent;
            this.txt_correo.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_correo.FocusedForeColor = System.Drawing.Color.Black;
            this.txt_correo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_correo.ForeColor = System.Drawing.Color.Black;
            this.txt_correo.Location = new System.Drawing.Point(48, 379);
            this.txt_correo.MultiLine = true;
            this.txt_correo.Name = "txt_correo";
            this.txt_correo.PasswordChar = '\0';
            this.txt_correo.Radius = 5;
            this.txt_correo.Size = new System.Drawing.Size(490, 29);
            this.txt_correo.TabIndex = 82;
            // 
            // txt_rubro
            // 
            this.txt_rubro.BackColor = System.Drawing.Color.Transparent;
            this.txt_rubro.BaseColor = System.Drawing.Color.Transparent;
            this.txt_rubro.BorderColor = System.Drawing.Color.Silver;
            this.txt_rubro.BorderSize = 1;
            this.txt_rubro.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_rubro.FocusedBaseColor = System.Drawing.Color.Transparent;
            this.txt_rubro.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_rubro.FocusedForeColor = System.Drawing.Color.Black;
            this.txt_rubro.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_rubro.ForeColor = System.Drawing.Color.Black;
            this.txt_rubro.Location = new System.Drawing.Point(48, 439);
            this.txt_rubro.MultiLine = true;
            this.txt_rubro.Name = "txt_rubro";
            this.txt_rubro.PasswordChar = '\0';
            this.txt_rubro.Radius = 5;
            this.txt_rubro.Size = new System.Drawing.Size(490, 29);
            this.txt_rubro.TabIndex = 83;
            // 
            // txt_contacto
            // 
            this.txt_contacto.BackColor = System.Drawing.Color.Transparent;
            this.txt_contacto.BaseColor = System.Drawing.Color.Transparent;
            this.txt_contacto.BorderColor = System.Drawing.Color.Silver;
            this.txt_contacto.BorderSize = 1;
            this.txt_contacto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_contacto.FocusedBaseColor = System.Drawing.Color.Transparent;
            this.txt_contacto.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_contacto.FocusedForeColor = System.Drawing.Color.Black;
            this.txt_contacto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_contacto.ForeColor = System.Drawing.Color.Black;
            this.txt_contacto.Location = new System.Drawing.Point(332, 322);
            this.txt_contacto.MultiLine = true;
            this.txt_contacto.Name = "txt_contacto";
            this.txt_contacto.PasswordChar = '\0';
            this.txt_contacto.Radius = 5;
            this.txt_contacto.Size = new System.Drawing.Size(203, 31);
            this.txt_contacto.TabIndex = 84;
            // 
            // txt_ruc
            // 
            this.txt_ruc.BackColor = System.Drawing.Color.Transparent;
            this.txt_ruc.BaseColor = System.Drawing.Color.Transparent;
            this.txt_ruc.BorderColor = System.Drawing.Color.Silver;
            this.txt_ruc.BorderSize = 1;
            this.txt_ruc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_ruc.FocusedBaseColor = System.Drawing.Color.Transparent;
            this.txt_ruc.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_ruc.FocusedForeColor = System.Drawing.Color.Black;
            this.txt_ruc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ruc.ForeColor = System.Drawing.Color.Black;
            this.txt_ruc.Location = new System.Drawing.Point(48, 135);
            this.txt_ruc.MultiLine = true;
            this.txt_ruc.Name = "txt_ruc";
            this.txt_ruc.PasswordChar = '\0';
            this.txt_ruc.Radius = 5;
            this.txt_ruc.Size = new System.Drawing.Size(206, 29);
            this.txt_ruc.TabIndex = 85;
            this.txt_ruc.TextChanged += new System.EventHandler(this.txt_ruc_TextChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.AnimationHoverSpeed = 0.07F;
            this.btnBuscar.AnimationSpeed = 0.03F;
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(232)))));
            this.btnBuscar.BorderColor = System.Drawing.Color.Black;
            this.btnBuscar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBuscar.FocusedColor = System.Drawing.Color.Empty;
            this.btnBuscar.Font = new System.Drawing.Font("Encode Sans Condensed SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = null;
            this.btnBuscar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnBuscar.Location = new System.Drawing.Point(271, 135);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnBuscar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnBuscar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnBuscar.OnHoverImage = null;
            this.btnBuscar.OnPressedColor = System.Drawing.Color.Black;
            this.btnBuscar.Radius = 10;
            this.btnBuscar.Size = new System.Drawing.Size(119, 30);
            this.btnBuscar.TabIndex = 624;
            this.btnBuscar.Text = "Consultar";
            this.btnBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtTipo
            // 
            this.txtTipo.BackColor = System.Drawing.Color.Transparent;
            this.txtTipo.BaseColor = System.Drawing.Color.Transparent;
            this.txtTipo.BorderColor = System.Drawing.Color.Silver;
            this.txtTipo.BorderSize = 1;
            this.txtTipo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTipo.FocusedBaseColor = System.Drawing.Color.Transparent;
            this.txtTipo.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtTipo.FocusedForeColor = System.Drawing.Color.Black;
            this.txtTipo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipo.ForeColor = System.Drawing.Color.Black;
            this.txtTipo.Location = new System.Drawing.Point(332, 505);
            this.txtTipo.MultiLine = true;
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.PasswordChar = '\0';
            this.txtTipo.Radius = 5;
            this.txtTipo.Size = new System.Drawing.Size(206, 29);
            this.txtTipo.TabIndex = 625;
            // 
            // txtCondicion
            // 
            this.txtCondicion.BackColor = System.Drawing.Color.Transparent;
            this.txtCondicion.BaseColor = System.Drawing.Color.Transparent;
            this.txtCondicion.BorderColor = System.Drawing.Color.Silver;
            this.txtCondicion.BorderSize = 1;
            this.txtCondicion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCondicion.FocusedBaseColor = System.Drawing.Color.Transparent;
            this.txtCondicion.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtCondicion.FocusedForeColor = System.Drawing.Color.Black;
            this.txtCondicion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCondicion.ForeColor = System.Drawing.Color.Black;
            this.txtCondicion.Location = new System.Drawing.Point(48, 505);
            this.txtCondicion.MultiLine = true;
            this.txtCondicion.Name = "txtCondicion";
            this.txtCondicion.PasswordChar = '\0';
            this.txtCondicion.Radius = 5;
            this.txtCondicion.Size = new System.Drawing.Size(196, 29);
            this.txtCondicion.TabIndex = 626;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label7.Location = new System.Drawing.Point(45, 479);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 23);
            this.label7.TabIndex = 627;
            this.label7.Text = "Condición";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label14.Location = new System.Drawing.Point(328, 479);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 23);
            this.label14.TabIndex = 628;
            this.label14.Text = "Tipo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo_departamento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbo_provincia);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.cbo_distrito);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Location = new System.Drawing.Point(477, 571);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(86, 49);
            this.groupBox1.TabIndex = 629;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Visible = false;
            // 
            // Frm_AddProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(598, 721);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCondicion);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txt_ruc);
            this.Controls.Add(this.txt_contacto);
            this.Controls.Add(this.txt_rubro);
            this.Controls.Add(this.txt_correo);
            this.Controls.Add(this.txt_telefono);
            this.Controls.Add(this.txt_direccion);
            this.Controls.Add(this.txt_nombreProve);
            this.Controls.Add(this.txt_idprovedor);
            this.Controls.Add(this.lbl_consul);
            this.Controls.Add(this.Pic_load);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbl_Abrir);
            this.Controls.Add(this.piclogo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_listo);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_AddProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Reg_Prod";
            this.Load += new System.EventHandler(this.Frm_AddProveedor_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piclogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_load)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_listo;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_cancel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox piclogo;
        private System.Windows.Forms.Label lbl_Abrir;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbl_consul;
        internal System.Windows.Forms.PictureBox Pic_load;
        private System.Windows.Forms.Label label15;
        private Guna.UI.WinForms.GunaComboBox cbo_distrito;
        private Guna.UI.WinForms.GunaComboBox cbo_provincia;
        private Guna.UI.WinForms.GunaComboBox cbo_departamento;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaTextBox txt_direccion;
        private Guna.UI.WinForms.GunaTextBox txt_nombreProve;
        private Guna.UI.WinForms.GunaTextBox txt_idprovedor;
        private Guna.UI.WinForms.GunaTextBox txt_contacto;
        private Guna.UI.WinForms.GunaTextBox txt_rubro;
        private Guna.UI.WinForms.GunaTextBox txt_correo;
        private Guna.UI.WinForms.GunaTextBox txt_telefono;
        private Guna.UI.WinForms.GunaTextBox txt_ruc;
        private Guna.UI.WinForms.GunaButton btnBuscar;
        private Guna.UI.WinForms.GunaTextBox txtCondicion;
        private Guna.UI.WinForms.GunaTextBox txtTipo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
    }
}