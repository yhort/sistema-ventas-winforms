namespace Microsell_Lite.Cliente
{
    partial class Frm_Add_Cliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Add_Cliente));
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
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_codtipoDocCli = new System.Windows.Forms.Label();
            this.txt_idcliente = new Guna.UI.WinForms.GunaTextBox();
            this.txt_direc = new Guna.UI.WinForms.GunaTextBox();
            this.txt_tel = new Guna.UI.WinForms.GunaTextBox();
            this.cbo_CodtipoDoc = new Guna.UI.WinForms.GunaComboBox();
            this.txt_ruc = new Guna.UI.WinForms.GunaTextBox();
            this.txt_correo = new Guna.UI.WinForms.GunaTextBox();
            this.txt_contacto = new Guna.UI.WinForms.GunaTextBox();
            this.txt_LimitedCred = new Guna.UI.WinForms.GunaTextBox();
            this.cbo_dis = new Guna.UI.WinForms.GunaComboBox();
            this.btnBuscar = new Guna.UI.WinForms.GunaButton();
            this.txtCondicion = new Guna.UI.WinForms.GunaTextBox();
            this.txtTipo = new Guna.UI.WinForms.GunaTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.lbl_consul = new System.Windows.Forms.Label();
            this.Pic_load = new System.Windows.Forms.PictureBox();
            this.txt_nom = new Guna.UI.WinForms.GunaTextBox();
            this.dtp_fechaAniv = new Guna.UI.WinForms.GunaDateTimePicker();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_load)).BeginInit();
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
            this.pnl_titu.Size = new System.Drawing.Size(559, 43);
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
            this.btn_cerrar.Location = new System.Drawing.Point(515, 5);
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
            this.label1.Size = new System.Drawing.Size(152, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registro de Clientes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(56, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Id Cliente";
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
            this.btn_listo.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(232)))));
            this.btn_listo.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_listo.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_listo.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_listo.Location = new System.Drawing.Point(307, 642);
            this.btn_listo.Name = "btn_listo";
            this.btn_listo.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_listo.Size = new System.Drawing.Size(157, 42);
            this.btn_listo.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.TabIndex = 11;
            this.btn_listo.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btn_cancel.Location = new System.Drawing.Point(98, 642);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.btn_cancel.Size = new System.Drawing.Size(157, 42);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(53, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nombre Cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(55, 376);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Direccion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(53, 491);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Telefono/Celular";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(319, 491);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Limite de Credito";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(314, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "N° Doc.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(53, 551);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 23);
            this.label8.TabIndex = 18;
            this.label8.Text = "Correo";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.DodgerBlue;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(0, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(2, 658);
            this.label9.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.DodgerBlue;
            this.label10.Dock = System.Windows.Forms.DockStyle.Right;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(557, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(2, 658);
            this.label10.TabIndex = 23;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(53, 611);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(446, 19);
            this.bunifuSeparator1.TabIndex = 24;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(314, 434);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 23);
            this.label11.TabIndex = 26;
            this.label11.Text = "Nombre de Contacto";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(55, 434);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 23);
            this.label12.TabIndex = 28;
            this.label12.Text = "Distrito";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(313, 553);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 23);
            this.label13.TabIndex = 31;
            this.label13.Text = "Fecha Naci.";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(50, 119);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 23);
            this.label14.TabIndex = 32;
            this.label14.Text = "Tipo Doc Ident.";
            // 
            // lbl_codtipoDocCli
            // 
            this.lbl_codtipoDocCli.AutoSize = true;
            this.lbl_codtipoDocCli.ForeColor = System.Drawing.Color.Black;
            this.lbl_codtipoDocCli.Location = new System.Drawing.Point(234, 145);
            this.lbl_codtipoDocCli.Name = "lbl_codtipoDocCli";
            this.lbl_codtipoDocCli.Size = new System.Drawing.Size(10, 13);
            this.lbl_codtipoDocCli.TabIndex = 34;
            this.lbl_codtipoDocCli.Text = "-";
            // 
            // txt_idcliente
            // 
            this.txt_idcliente.BackColor = System.Drawing.Color.Transparent;
            this.txt_idcliente.BaseColor = System.Drawing.Color.White;
            this.txt_idcliente.BorderColor = System.Drawing.Color.Silver;
            this.txt_idcliente.BorderSize = 1;
            this.txt_idcliente.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_idcliente.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_idcliente.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_idcliente.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_idcliente.Font = new System.Drawing.Font("Encode Sans Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_idcliente.ForeColor = System.Drawing.Color.DimGray;
            this.txt_idcliente.Location = new System.Drawing.Point(54, 78);
            this.txt_idcliente.MultiLine = true;
            this.txt_idcliente.Name = "txt_idcliente";
            this.txt_idcliente.PasswordChar = '\0';
            this.txt_idcliente.Radius = 5;
            this.txt_idcliente.Size = new System.Drawing.Size(445, 28);
            this.txt_idcliente.TabIndex = 38;
            // 
            // txt_direc
            // 
            this.txt_direc.BackColor = System.Drawing.Color.Transparent;
            this.txt_direc.BaseColor = System.Drawing.Color.Transparent;
            this.txt_direc.BorderColor = System.Drawing.Color.Silver;
            this.txt_direc.BorderSize = 1;
            this.txt_direc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_direc.FocusedBaseColor = System.Drawing.Color.Transparent;
            this.txt_direc.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_direc.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_direc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_direc.ForeColor = System.Drawing.Color.Black;
            this.txt_direc.Location = new System.Drawing.Point(56, 400);
            this.txt_direc.MultiLine = true;
            this.txt_direc.Name = "txt_direc";
            this.txt_direc.PasswordChar = '\0';
            this.txt_direc.Radius = 5;
            this.txt_direc.Size = new System.Drawing.Size(443, 30);
            this.txt_direc.TabIndex = 40;
            // 
            // txt_tel
            // 
            this.txt_tel.BackColor = System.Drawing.Color.Transparent;
            this.txt_tel.BaseColor = System.Drawing.Color.White;
            this.txt_tel.BorderColor = System.Drawing.Color.Silver;
            this.txt_tel.BorderSize = 1;
            this.txt_tel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_tel.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_tel.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_tel.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_tel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tel.ForeColor = System.Drawing.Color.Black;
            this.txt_tel.Location = new System.Drawing.Point(56, 517);
            this.txt_tel.MultiLine = true;
            this.txt_tel.Name = "txt_tel";
            this.txt_tel.PasswordChar = '\0';
            this.txt_tel.Radius = 5;
            this.txt_tel.Size = new System.Drawing.Size(193, 30);
            this.txt_tel.TabIndex = 41;
            // 
            // cbo_CodtipoDoc
            // 
            this.cbo_CodtipoDoc.BackColor = System.Drawing.Color.Transparent;
            this.cbo_CodtipoDoc.BaseColor = System.Drawing.Color.White;
            this.cbo_CodtipoDoc.BorderColor = System.Drawing.Color.Silver;
            this.cbo_CodtipoDoc.BorderSize = 1;
            this.cbo_CodtipoDoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_CodtipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_CodtipoDoc.FocusedColor = System.Drawing.Color.Empty;
            this.cbo_CodtipoDoc.Font = new System.Drawing.Font("Encode Sans Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_CodtipoDoc.ForeColor = System.Drawing.Color.Black;
            this.cbo_CodtipoDoc.FormattingEnabled = true;
            this.cbo_CodtipoDoc.Items.AddRange(new object[] {
            "DNI",
            "RUC",
            "C/E"});
            this.cbo_CodtipoDoc.Location = new System.Drawing.Point(52, 145);
            this.cbo_CodtipoDoc.Name = "cbo_CodtipoDoc";
            this.cbo_CodtipoDoc.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cbo_CodtipoDoc.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cbo_CodtipoDoc.Radius = 4;
            this.cbo_CodtipoDoc.Size = new System.Drawing.Size(171, 27);
            this.cbo_CodtipoDoc.TabIndex = 76;
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
            this.txt_ruc.Location = new System.Drawing.Point(317, 144);
            this.txt_ruc.MultiLine = true;
            this.txt_ruc.Name = "txt_ruc";
            this.txt_ruc.PasswordChar = '\0';
            this.txt_ruc.Radius = 5;
            this.txt_ruc.Size = new System.Drawing.Size(182, 30);
            this.txt_ruc.TabIndex = 77;
            this.txt_ruc.TextChanged += new System.EventHandler(this.txt_ruc_TextChanged);
            // 
            // txt_correo
            // 
            this.txt_correo.BackColor = System.Drawing.Color.Transparent;
            this.txt_correo.BaseColor = System.Drawing.Color.White;
            this.txt_correo.BorderColor = System.Drawing.Color.Silver;
            this.txt_correo.BorderSize = 1;
            this.txt_correo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_correo.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_correo.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_correo.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_correo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_correo.ForeColor = System.Drawing.Color.Black;
            this.txt_correo.Location = new System.Drawing.Point(55, 577);
            this.txt_correo.MultiLine = true;
            this.txt_correo.Name = "txt_correo";
            this.txt_correo.PasswordChar = '\0';
            this.txt_correo.Radius = 5;
            this.txt_correo.Size = new System.Drawing.Size(194, 30);
            this.txt_correo.TabIndex = 78;
            // 
            // txt_contacto
            // 
            this.txt_contacto.BackColor = System.Drawing.Color.Transparent;
            this.txt_contacto.BaseColor = System.Drawing.Color.White;
            this.txt_contacto.BorderColor = System.Drawing.Color.Silver;
            this.txt_contacto.BorderSize = 1;
            this.txt_contacto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_contacto.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_contacto.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_contacto.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_contacto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_contacto.ForeColor = System.Drawing.Color.Black;
            this.txt_contacto.Location = new System.Drawing.Point(315, 456);
            this.txt_contacto.Name = "txt_contacto";
            this.txt_contacto.PasswordChar = '\0';
            this.txt_contacto.Radius = 5;
            this.txt_contacto.Size = new System.Drawing.Size(184, 28);
            this.txt_contacto.TabIndex = 79;
            // 
            // txt_LimitedCred
            // 
            this.txt_LimitedCred.BackColor = System.Drawing.Color.Transparent;
            this.txt_LimitedCred.BaseColor = System.Drawing.Color.White;
            this.txt_LimitedCred.BorderColor = System.Drawing.Color.Silver;
            this.txt_LimitedCred.BorderSize = 1;
            this.txt_LimitedCred.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_LimitedCred.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_LimitedCred.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_LimitedCred.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_LimitedCred.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_LimitedCred.ForeColor = System.Drawing.Color.Black;
            this.txt_LimitedCred.Location = new System.Drawing.Point(318, 517);
            this.txt_LimitedCred.MultiLine = true;
            this.txt_LimitedCred.Name = "txt_LimitedCred";
            this.txt_LimitedCred.PasswordChar = '\0';
            this.txt_LimitedCred.Radius = 5;
            this.txt_LimitedCred.Size = new System.Drawing.Size(181, 30);
            this.txt_LimitedCred.TabIndex = 80;
            // 
            // cbo_dis
            // 
            this.cbo_dis.BackColor = System.Drawing.Color.Transparent;
            this.cbo_dis.BaseColor = System.Drawing.Color.White;
            this.cbo_dis.BorderColor = System.Drawing.Color.Silver;
            this.cbo_dis.BorderSize = 1;
            this.cbo_dis.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_dis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_dis.FocusedColor = System.Drawing.Color.Empty;
            this.cbo_dis.Font = new System.Drawing.Font("Encode Sans Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_dis.ForeColor = System.Drawing.Color.Black;
            this.cbo_dis.FormattingEnabled = true;
            this.cbo_dis.Location = new System.Drawing.Point(57, 456);
            this.cbo_dis.Name = "cbo_dis";
            this.cbo_dis.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cbo_dis.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cbo_dis.Radius = 4;
            this.cbo_dis.Size = new System.Drawing.Size(192, 27);
            this.cbo_dis.TabIndex = 81;
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
            this.btnBuscar.Location = new System.Drawing.Point(51, 193);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnBuscar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnBuscar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnBuscar.OnHoverImage = null;
            this.btnBuscar.OnPressedColor = System.Drawing.Color.Black;
            this.btnBuscar.Radius = 10;
            this.btnBuscar.Size = new System.Drawing.Size(452, 35);
            this.btnBuscar.TabIndex = 624;
            this.btnBuscar.Text = "Consultar";
            this.btnBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCondicion
            // 
            this.txtCondicion.BackColor = System.Drawing.Color.Transparent;
            this.txtCondicion.BaseColor = System.Drawing.Color.Transparent;
            this.txtCondicion.BorderColor = System.Drawing.Color.Silver;
            this.txtCondicion.BorderSize = 1;
            this.txtCondicion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCondicion.Enabled = false;
            this.txtCondicion.FocusedBaseColor = System.Drawing.Color.Transparent;
            this.txtCondicion.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtCondicion.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCondicion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCondicion.ForeColor = System.Drawing.Color.Black;
            this.txtCondicion.Location = new System.Drawing.Point(55, 280);
            this.txtCondicion.Name = "txtCondicion";
            this.txtCondicion.PasswordChar = '\0';
            this.txtCondicion.Radius = 5;
            this.txtCondicion.Size = new System.Drawing.Size(171, 28);
            this.txtCondicion.TabIndex = 625;
            // 
            // txtTipo
            // 
            this.txtTipo.BackColor = System.Drawing.Color.Transparent;
            this.txtTipo.BaseColor = System.Drawing.Color.Transparent;
            this.txtTipo.BorderColor = System.Drawing.Color.Silver;
            this.txtTipo.BorderSize = 1;
            this.txtTipo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTipo.Enabled = false;
            this.txtTipo.FocusedBaseColor = System.Drawing.Color.Transparent;
            this.txtTipo.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtTipo.FocusedForeColor = System.Drawing.Color.Black;
            this.txtTipo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipo.ForeColor = System.Drawing.Color.Black;
            this.txtTipo.Location = new System.Drawing.Point(316, 280);
            this.txtTipo.MultiLine = true;
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.PasswordChar = '\0';
            this.txtTipo.Radius = 5;
            this.txtTipo.Size = new System.Drawing.Size(183, 30);
            this.txtTipo.TabIndex = 626;
            this.txtTipo.Text = "-";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(53, 254);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 23);
            this.label15.TabIndex = 627;
            this.label15.Text = "Condición";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Encode Sans Condensed", 10F);
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(319, 255);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 23);
            this.label16.TabIndex = 628;
            this.label16.Text = "Tipo";
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(47, 234);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(456, 17);
            this.bunifuSeparator2.TabIndex = 629;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // lbl_consul
            // 
            this.lbl_consul.AutoSize = true;
            this.lbl_consul.ForeColor = System.Drawing.Color.Green;
            this.lbl_consul.Location = new System.Drawing.Point(234, 310);
            this.lbl_consul.Name = "lbl_consul";
            this.lbl_consul.Size = new System.Drawing.Size(72, 13);
            this.lbl_consul.TabIndex = 631;
            this.lbl_consul.Text = "Consultando..";
            this.lbl_consul.Visible = false;
            // 
            // Pic_load
            // 
            this.Pic_load.Image = ((System.Drawing.Image)(resources.GetObject("Pic_load.Image")));
            this.Pic_load.Location = new System.Drawing.Point(232, 254);
            this.Pic_load.Name = "Pic_load";
            this.Pic_load.Size = new System.Drawing.Size(74, 53);
            this.Pic_load.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Pic_load.TabIndex = 630;
            this.Pic_load.TabStop = false;
            this.Pic_load.Visible = false;
            // 
            // txt_nom
            // 
            this.txt_nom.BackColor = System.Drawing.Color.Transparent;
            this.txt_nom.BaseColor = System.Drawing.Color.Transparent;
            this.txt_nom.BorderColor = System.Drawing.Color.Silver;
            this.txt_nom.BorderSize = 1;
            this.txt_nom.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_nom.FocusedBaseColor = System.Drawing.Color.Transparent;
            this.txt_nom.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_nom.FocusedForeColor = System.Drawing.Color.Black;
            this.txt_nom.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nom.ForeColor = System.Drawing.Color.Black;
            this.txt_nom.Location = new System.Drawing.Point(55, 340);
            this.txt_nom.Name = "txt_nom";
            this.txt_nom.PasswordChar = '\0';
            this.txt_nom.Radius = 5;
            this.txt_nom.Size = new System.Drawing.Size(444, 30);
            this.txt_nom.TabIndex = 39;
            // 
            // dtp_fechaAniv
            // 
            this.dtp_fechaAniv.BackColor = System.Drawing.Color.Transparent;
            this.dtp_fechaAniv.BaseColor = System.Drawing.Color.White;
            this.dtp_fechaAniv.BorderColor = System.Drawing.Color.Silver;
            this.dtp_fechaAniv.CustomFormat = null;
            this.dtp_fechaAniv.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtp_fechaAniv.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_fechaAniv.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_fechaAniv.ForeColor = System.Drawing.Color.Black;
            this.dtp_fechaAniv.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fechaAniv.Location = new System.Drawing.Point(315, 579);
            this.dtp_fechaAniv.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_fechaAniv.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_fechaAniv.Name = "dtp_fechaAniv";
            this.dtp_fechaAniv.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtp_fechaAniv.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_fechaAniv.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_fechaAniv.OnPressedColor = System.Drawing.Color.Black;
            this.dtp_fechaAniv.Radius = 5;
            this.dtp_fechaAniv.Size = new System.Drawing.Size(184, 30);
            this.dtp_fechaAniv.TabIndex = 632;
            this.dtp_fechaAniv.Text = "6/10/2025";
            this.dtp_fechaAniv.Value = new System.DateTime(2025, 10, 6, 10, 56, 4, 995);
            // 
            // Frm_Add_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(559, 701);
            this.Controls.Add(this.dtp_fechaAniv);
            this.Controls.Add(this.lbl_consul);
            this.Controls.Add(this.Pic_load);
            this.Controls.Add(this.bunifuSeparator2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txt_idcliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.txtCondicion);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cbo_dis);
            this.Controls.Add(this.txt_LimitedCred);
            this.Controls.Add(this.txt_contacto);
            this.Controls.Add(this.txt_correo);
            this.Controls.Add(this.txt_ruc);
            this.Controls.Add(this.cbo_CodtipoDoc);
            this.Controls.Add(this.txt_tel);
            this.Controls.Add(this.txt_direc);
            this.Controls.Add(this.txt_nom);
            this.Controls.Add(this.lbl_codtipoDocCli);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.btn_listo);
            this.Controls.Add(this.btn_cancel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Add_Cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.Frm_Reg_Prod_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_load)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label1;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_cancel;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_listo;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        internal System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_codtipoDocCli;
        private Guna.UI.WinForms.GunaTextBox txt_tel;
        private Guna.UI.WinForms.GunaTextBox txt_direc;
        private Guna.UI.WinForms.GunaTextBox txt_idcliente;
        private Guna.UI.WinForms.GunaComboBox cbo_dis;
        private Guna.UI.WinForms.GunaTextBox txt_LimitedCred;
        private Guna.UI.WinForms.GunaTextBox txt_contacto;
        private Guna.UI.WinForms.GunaTextBox txt_correo;
        private Guna.UI.WinForms.GunaTextBox txt_ruc;
        private Guna.UI.WinForms.GunaComboBox cbo_CodtipoDoc;
        private Guna.UI.WinForms.GunaButton btnBuscar;
        private Guna.UI.WinForms.GunaTextBox txtCondicion;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private Guna.UI.WinForms.GunaTextBox txtTipo;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private System.Windows.Forms.Label lbl_consul;
        internal System.Windows.Forms.PictureBox Pic_load;
        private Guna.UI.WinForms.GunaTextBox txt_nom;
        private Guna.UI.WinForms.GunaDateTimePicker dtp_fechaAniv;
    }
}