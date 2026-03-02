namespace Microsell_Lite.Proveedor
{
    partial class frm_Editar_Proveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Editar_Proveedor));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_listo = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_cancel = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.piclogo = new System.Windows.Forms.PictureBox();
            this.lbl_Abrir = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_idprovedor = new Guna.UI.WinForms.GunaTextBox();
            this.txt_nombreProve = new Guna.UI.WinForms.GunaTextBox();
            this.txt_direccion = new Guna.UI.WinForms.GunaTextBox();
            this.txt_telefono = new Guna.UI.WinForms.GunaTextBox();
            this.txt_rubro = new Guna.UI.WinForms.GunaTextBox();
            this.txt_ruc = new Guna.UI.WinForms.GunaTextBox();
            this.txt_correo = new Guna.UI.WinForms.GunaTextBox();
            this.txt_contacto = new Guna.UI.WinForms.GunaTextBox();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
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
            this.pnl_titu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(232)))));
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(598, 43);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Encode Sans Condensed Medium", 12.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Editar Proveedor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label2.Location = new System.Drawing.Point(47, 62);
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
            this.btn_listo.Location = new System.Drawing.Point(313, 636);
            this.btn_listo.Name = "btn_listo";
            this.btn_listo.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_listo.Size = new System.Drawing.Size(157, 49);
            this.btn_listo.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.TabIndex = 6;
            this.btn_listo.TextStyle.Font = new System.Drawing.Font("Encode Sans Condensed SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
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
            this.btn_cancel.Location = new System.Drawing.Point(112, 636);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.btn_cancel.Size = new System.Drawing.Size(157, 49);
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
            this.label3.Location = new System.Drawing.Point(47, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nombre de Proveedor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label4.Location = new System.Drawing.Point(47, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Direccion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label5.Location = new System.Drawing.Point(47, 319);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Telefono/Celular";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label6.Location = new System.Drawing.Point(47, 447);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Rubro";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label7.Location = new System.Drawing.Point(47, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "Ruc";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label8.Location = new System.Drawing.Point(47, 383);
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
            this.piclogo.Location = new System.Drawing.Point(226, 525);
            this.piclogo.Name = "piclogo";
            this.piclogo.Size = new System.Drawing.Size(124, 80);
            this.piclogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.piclogo.TabIndex = 22;
            this.piclogo.TabStop = false;
            this.piclogo.Tag = "";
            // 
            // lbl_Abrir
            // 
            this.lbl_Abrir.AutoSize = true;
            this.lbl_Abrir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Abrir.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Abrir.Location = new System.Drawing.Point(356, 557);
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
            this.label11.Location = new System.Drawing.Point(326, 319);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 23);
            this.label11.TabIndex = 27;
            this.label11.Text = "Nombre de Contacto";
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
            this.txt_idprovedor.Location = new System.Drawing.Point(45, 88);
            this.txt_idprovedor.MultiLine = true;
            this.txt_idprovedor.Name = "txt_idprovedor";
            this.txt_idprovedor.PasswordChar = '\0';
            this.txt_idprovedor.Radius = 5;
            this.txt_idprovedor.Size = new System.Drawing.Size(213, 29);
            this.txt_idprovedor.TabIndex = 79;
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
            this.txt_nombreProve.Location = new System.Drawing.Point(45, 220);
            this.txt_nombreProve.MultiLine = true;
            this.txt_nombreProve.Name = "txt_nombreProve";
            this.txt_nombreProve.PasswordChar = '\0';
            this.txt_nombreProve.Radius = 5;
            this.txt_nombreProve.Size = new System.Drawing.Size(488, 29);
            this.txt_nombreProve.TabIndex = 80;
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
            this.txt_direccion.Location = new System.Drawing.Point(45, 281);
            this.txt_direccion.MultiLine = true;
            this.txt_direccion.Name = "txt_direccion";
            this.txt_direccion.PasswordChar = '\0';
            this.txt_direccion.Radius = 5;
            this.txt_direccion.Size = new System.Drawing.Size(488, 29);
            this.txt_direccion.TabIndex = 81;
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
            this.txt_telefono.Location = new System.Drawing.Point(45, 345);
            this.txt_telefono.MultiLine = true;
            this.txt_telefono.Name = "txt_telefono";
            this.txt_telefono.PasswordChar = '\0';
            this.txt_telefono.Radius = 5;
            this.txt_telefono.Size = new System.Drawing.Size(206, 31);
            this.txt_telefono.TabIndex = 82;
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
            this.txt_rubro.Location = new System.Drawing.Point(45, 473);
            this.txt_rubro.MultiLine = true;
            this.txt_rubro.Name = "txt_rubro";
            this.txt_rubro.PasswordChar = '\0';
            this.txt_rubro.Radius = 5;
            this.txt_rubro.Size = new System.Drawing.Size(488, 29);
            this.txt_rubro.TabIndex = 84;
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
            this.txt_ruc.Location = new System.Drawing.Point(45, 157);
            this.txt_ruc.MultiLine = true;
            this.txt_ruc.Name = "txt_ruc";
            this.txt_ruc.PasswordChar = '\0';
            this.txt_ruc.Radius = 5;
            this.txt_ruc.Size = new System.Drawing.Size(213, 29);
            this.txt_ruc.TabIndex = 86;
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
            this.txt_correo.Location = new System.Drawing.Point(45, 409);
            this.txt_correo.MultiLine = true;
            this.txt_correo.Name = "txt_correo";
            this.txt_correo.PasswordChar = '\0';
            this.txt_correo.Radius = 5;
            this.txt_correo.Size = new System.Drawing.Size(488, 29);
            this.txt_correo.TabIndex = 87;
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
            this.txt_contacto.Location = new System.Drawing.Point(330, 345);
            this.txt_contacto.MultiLine = true;
            this.txt_contacto.Name = "txt_contacto";
            this.txt_contacto.PasswordChar = '\0';
            this.txt_contacto.Radius = 5;
            this.txt_contacto.Size = new System.Drawing.Size(203, 31);
            this.txt_contacto.TabIndex = 88;
            // 
            // frm_Editar_Proveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(598, 721);
            this.Controls.Add(this.txt_contacto);
            this.Controls.Add(this.txt_correo);
            this.Controls.Add(this.txt_ruc);
            this.Controls.Add(this.txt_rubro);
            this.Controls.Add(this.txt_telefono);
            this.Controls.Add(this.txt_direccion);
            this.Controls.Add(this.txt_nombreProve);
            this.Controls.Add(this.txt_idprovedor);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbl_Abrir);
            this.Controls.Add(this.piclogo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_listo);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Editar_Proveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Proveedor";
            this.Load += new System.EventHandler(this.Frm_Reg_Prod_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piclogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
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
        private Guna.UI.WinForms.GunaTextBox txt_idprovedor;
        private Guna.UI.WinForms.GunaTextBox txt_nombreProve;
        private Guna.UI.WinForms.GunaTextBox txt_direccion;
        private Guna.UI.WinForms.GunaTextBox txt_telefono;
        private Guna.UI.WinForms.GunaTextBox txt_rubro;
        private Guna.UI.WinForms.GunaTextBox txt_ruc;
        private Guna.UI.WinForms.GunaTextBox txt_correo;
        private Guna.UI.WinForms.GunaTextBox txt_contacto;
    }
}