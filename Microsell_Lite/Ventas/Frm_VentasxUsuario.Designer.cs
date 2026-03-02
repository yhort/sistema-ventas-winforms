namespace Microsell_Lite.Ventas
{
    partial class Frm_VentasxUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_VentasxUsuario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpfechaFinal = new Guna.UI.WinForms.GunaDateTimePicker();
            this.dtpfechaInicial = new Guna.UI.WinForms.GunaDateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cbo_usu = new Guna.UI.WinForms.GunaComboBox();
            this.btnGenerar = new Guna.UI.WinForms.GunaButton();
            this.label5 = new System.Windows.Forms.Label();
            this.l = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.lblEfectivo = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.lblYape = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.lblPlin = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.lblTarjeta = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotal = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Pnl_Titulo = new System.Windows.Forms.Panel();
            this.ElDivider7 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.btn_minimi = new System.Windows.Forms.Button();
            this.Lbl_titulo = new System.Windows.Forms.Label();
            this.lblMixto = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.elPanel2 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.dgv_ventas = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.lblEfectivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblYape)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTarjeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).BeginInit();
            this.Pnl_Titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMixto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elPanel2)).BeginInit();
            this.elPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ventas)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(331, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(166, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Desde:";
            // 
            // dtpfechaFinal
            // 
            this.dtpfechaFinal.BackColor = System.Drawing.Color.Transparent;
            this.dtpfechaFinal.BaseColor = System.Drawing.Color.White;
            this.dtpfechaFinal.BorderColor = System.Drawing.Color.Silver;
            this.dtpfechaFinal.CustomFormat = null;
            this.dtpfechaFinal.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpfechaFinal.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpfechaFinal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpfechaFinal.ForeColor = System.Drawing.Color.Black;
            this.dtpfechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechaFinal.Location = new System.Drawing.Point(334, 28);
            this.dtpfechaFinal.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpfechaFinal.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpfechaFinal.Name = "dtpfechaFinal";
            this.dtpfechaFinal.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtpfechaFinal.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpfechaFinal.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpfechaFinal.OnPressedColor = System.Drawing.Color.Black;
            this.dtpfechaFinal.Radius = 5;
            this.dtpfechaFinal.Size = new System.Drawing.Size(148, 30);
            this.dtpfechaFinal.TabIndex = 18;
            this.dtpfechaFinal.Text = "22/05/2024";
            this.dtpfechaFinal.Value = new System.DateTime(2024, 5, 22, 12, 4, 24, 560);
            // 
            // dtpfechaInicial
            // 
            this.dtpfechaInicial.BackColor = System.Drawing.Color.Transparent;
            this.dtpfechaInicial.BaseColor = System.Drawing.Color.White;
            this.dtpfechaInicial.BorderColor = System.Drawing.Color.Silver;
            this.dtpfechaInicial.CustomFormat = null;
            this.dtpfechaInicial.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpfechaInicial.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpfechaInicial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpfechaInicial.ForeColor = System.Drawing.Color.Black;
            this.dtpfechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechaInicial.Location = new System.Drawing.Point(166, 28);
            this.dtpfechaInicial.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpfechaInicial.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpfechaInicial.Name = "dtpfechaInicial";
            this.dtpfechaInicial.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtpfechaInicial.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpfechaInicial.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpfechaInicial.OnPressedColor = System.Drawing.Color.Black;
            this.dtpfechaInicial.Radius = 5;
            this.dtpfechaInicial.Size = new System.Drawing.Size(148, 30);
            this.dtpfechaInicial.TabIndex = 17;
            this.dtpfechaInicial.Text = "26/06/2024";
            this.dtpfechaInicial.Value = new System.DateTime(2024, 6, 26, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(19, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Usuario Caja";
            // 
            // cbo_usu
            // 
            this.cbo_usu.BackColor = System.Drawing.Color.Transparent;
            this.cbo_usu.BaseColor = System.Drawing.Color.White;
            this.cbo_usu.BorderColor = System.Drawing.Color.Silver;
            this.cbo_usu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_usu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_usu.FocusedColor = System.Drawing.Color.Empty;
            this.cbo_usu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_usu.ForeColor = System.Drawing.Color.Black;
            this.cbo_usu.FormattingEnabled = true;
            this.cbo_usu.Location = new System.Drawing.Point(19, 31);
            this.cbo_usu.Name = "cbo_usu";
            this.cbo_usu.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cbo_usu.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cbo_usu.Radius = 5;
            this.cbo_usu.Size = new System.Drawing.Size(121, 26);
            this.cbo_usu.TabIndex = 15;
            // 
            // btnGenerar
            // 
            this.btnGenerar.AnimationHoverSpeed = 0.07F;
            this.btnGenerar.AnimationSpeed = 0.03F;
            this.btnGenerar.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerar.BaseColor = System.Drawing.Color.RoyalBlue;
            this.btnGenerar.BorderColor = System.Drawing.Color.Black;
            this.btnGenerar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnGenerar.FocusedColor = System.Drawing.Color.Empty;
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Image = null;
            this.btnGenerar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnGenerar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnGenerar.Location = new System.Drawing.Point(506, 28);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnGenerar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnGenerar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnGenerar.OnHoverImage = null;
            this.btnGenerar.OnPressedColor = System.Drawing.Color.Black;
            this.btnGenerar.Radius = 15;
            this.btnGenerar.Size = new System.Drawing.Size(101, 32);
            this.btnGenerar.TabIndex = 21;
            this.btnGenerar.Text = "Consultar";
            this.btnGenerar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(160, 397);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Yape:";
            // 
            // l
            // 
            this.l.AutoSize = true;
            this.l.BackColor = System.Drawing.Color.White;
            this.l.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l.ForeColor = System.Drawing.Color.DimGray;
            this.l.Location = new System.Drawing.Point(293, 397);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(36, 20);
            this.l.TabIndex = 27;
            this.l.Text = "Plin:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(10, 398);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "Efectivo:";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.lblEfectivo.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.lblEfectivo.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.lblEfectivo.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.lblEfectivo.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
            this.lblEfectivo.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
            this.lblEfectivo.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.lblEfectivo.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.lblEfectivo.Cursor = System.Windows.Forms.Cursors.No;
            this.lblEfectivo.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEfectivo.Location = new System.Drawing.Point(16, 417);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.lblEfectivo.Size = new System.Drawing.Size(100, 25);
            this.lblEfectivo.TabIndex = 546;
            this.lblEfectivo.TabStop = false;
            this.lblEfectivo.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfectivo.TextStyle.ForeColor = System.Drawing.Color.Black;
            this.lblEfectivo.TextStyle.Text = "0,00";
            this.lblEfectivo.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // lblYape
            // 
            this.lblYape.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.lblYape.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.lblYape.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.lblYape.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.lblYape.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
            this.lblYape.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
            this.lblYape.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.lblYape.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.lblYape.Cursor = System.Windows.Forms.Cursors.No;
            this.lblYape.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblYape.Location = new System.Drawing.Point(164, 417);
            this.lblYape.Name = "lblYape";
            this.lblYape.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.lblYape.Size = new System.Drawing.Size(100, 25);
            this.lblYape.TabIndex = 547;
            this.lblYape.TabStop = false;
            this.lblYape.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYape.TextStyle.ForeColor = System.Drawing.Color.Black;
            this.lblYape.TextStyle.Text = "0,00";
            this.lblYape.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // lblPlin
            // 
            this.lblPlin.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.lblPlin.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.lblPlin.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.lblPlin.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.lblPlin.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
            this.lblPlin.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
            this.lblPlin.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.lblPlin.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.lblPlin.Cursor = System.Windows.Forms.Cursors.No;
            this.lblPlin.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPlin.Location = new System.Drawing.Point(297, 417);
            this.lblPlin.Name = "lblPlin";
            this.lblPlin.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.lblPlin.Size = new System.Drawing.Size(100, 25);
            this.lblPlin.TabIndex = 548;
            this.lblPlin.TabStop = false;
            this.lblPlin.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlin.TextStyle.ForeColor = System.Drawing.Color.Black;
            this.lblPlin.TextStyle.Text = "0,00";
            this.lblPlin.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // lblTarjeta
            // 
            this.lblTarjeta.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.lblTarjeta.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.lblTarjeta.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.lblTarjeta.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.lblTarjeta.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
            this.lblTarjeta.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
            this.lblTarjeta.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.lblTarjeta.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.lblTarjeta.Cursor = System.Windows.Forms.Cursors.No;
            this.lblTarjeta.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTarjeta.Location = new System.Drawing.Point(434, 418);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.lblTarjeta.Size = new System.Drawing.Size(100, 25);
            this.lblTarjeta.TabIndex = 550;
            this.lblTarjeta.TabStop = false;
            this.lblTarjeta.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarjeta.TextStyle.ForeColor = System.Drawing.Color.Black;
            this.lblTarjeta.TextStyle.Text = "0,00";
            this.lblTarjeta.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(430, 397);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 549;
            this.label6.Text = "Tarjeta:";
            // 
            // lblTotal
            // 
            this.lblTotal.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.lblTotal.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.lblTotal.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.lblTotal.BackgroundStyle.SolidColor = System.Drawing.Color.YellowGreen;
            this.lblTotal.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
            this.lblTotal.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
            this.lblTotal.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.lblTotal.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.lblTotal.Cursor = System.Windows.Forms.Cursors.No;
            this.lblTotal.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotal.Location = new System.Drawing.Point(830, 417);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.lblTotal.Size = new System.Drawing.Size(100, 25);
            this.lblTotal.TabIndex = 552;
            this.lblTotal.TabStop = false;
            this.lblTotal.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.TextStyle.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.TextStyle.Text = "0,00";
            this.lblTotal.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(810, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 551;
            this.label3.Text = "Total:";
            // 
            // Label13
            // 
            this.Label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.ForeColor = System.Drawing.Color.Gray;
            this.Label13.Location = new System.Drawing.Point(811, 425);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(131, 18);
            this.Label13.TabIndex = 571;
            this.Label13.Text = "_________________________";
            // 
            // Pnl_Titulo
            // 
            this.Pnl_Titulo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Pnl_Titulo.Controls.Add(this.ElDivider7);
            this.Pnl_Titulo.Controls.Add(this.btn_cerrar);
            this.Pnl_Titulo.Controls.Add(this.btn_minimi);
            this.Pnl_Titulo.Controls.Add(this.Lbl_titulo);
            this.Pnl_Titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_Titulo.Location = new System.Drawing.Point(0, 0);
            this.Pnl_Titulo.Name = "Pnl_Titulo";
            this.Pnl_Titulo.Size = new System.Drawing.Size(993, 48);
            this.Pnl_Titulo.TabIndex = 572;
            this.Pnl_Titulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pnl_Titulo_MouseMove);
            // 
            // ElDivider7
            // 
            this.ElDivider7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ElDivider7.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.None;
            this.ElDivider7.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ElDivider7.LineSize = 1;
            this.ElDivider7.Location = new System.Drawing.Point(0, 36);
            this.ElDivider7.Name = "ElDivider7";
            this.ElDivider7.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElDivider7.Size = new System.Drawing.Size(993, 12);
            this.ElDivider7.TabIndex = 556;
            this.ElDivider7.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
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
            this.btn_cerrar.Location = new System.Drawing.Point(941, 4);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(32, 32);
            this.btn_cerrar.TabIndex = 7;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // btn_minimi
            // 
            this.btn_minimi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_minimi.FlatAppearance.BorderSize = 0;
            this.btn_minimi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_minimi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_minimi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_minimi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_minimi.ForeColor = System.Drawing.Color.White;
            this.btn_minimi.Image = ((System.Drawing.Image)(resources.GetObject("btn_minimi.Image")));
            this.btn_minimi.Location = new System.Drawing.Point(903, 5);
            this.btn_minimi.Name = "btn_minimi";
            this.btn_minimi.Size = new System.Drawing.Size(32, 32);
            this.btn_minimi.TabIndex = 8;
            this.btn_minimi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_minimi.UseVisualStyleBackColor = true;
            this.btn_minimi.Click += new System.EventHandler(this.btn_minimi_Click);
            // 
            // Lbl_titulo
            // 
            this.Lbl_titulo.AutoSize = true;
            this.Lbl_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_titulo.ForeColor = System.Drawing.Color.DimGray;
            this.Lbl_titulo.Location = new System.Drawing.Point(5, 10);
            this.Lbl_titulo.Name = "Lbl_titulo";
            this.Lbl_titulo.Size = new System.Drawing.Size(232, 25);
            this.Lbl_titulo.TabIndex = 0;
            this.Lbl_titulo.Text = "Resumen de Cobranza";
            // 
            // lblMixto
            // 
            this.lblMixto.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.lblMixto.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.lblMixto.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.lblMixto.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.lblMixto.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
            this.lblMixto.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
            this.lblMixto.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.lblMixto.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.lblMixto.Cursor = System.Windows.Forms.Cursors.No;
            this.lblMixto.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMixto.Location = new System.Drawing.Point(593, 417);
            this.lblMixto.Name = "lblMixto";
            this.lblMixto.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.lblMixto.Size = new System.Drawing.Size(88, 25);
            this.lblMixto.TabIndex = 574;
            this.lblMixto.TabStop = false;
            this.lblMixto.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMixto.TextStyle.ForeColor = System.Drawing.Color.Black;
            this.lblMixto.TextStyle.Text = "0,00";
            this.lblMixto.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(589, 394);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 20);
            this.label8.TabIndex = 573;
            this.label8.Text = "Mixto:";
            // 
            // elPanel2
            // 
            this.elPanel2.AutoSize = true;
            this.elPanel2.BackgroundStyle.GradientAngle = 45F;
            this.elPanel2.BackgroundStyle.GradientEndColor = System.Drawing.Color.WhiteSmoke;
            this.elPanel2.BackgroundStyle.GradientStartColor = System.Drawing.Color.WhiteSmoke;
            this.elPanel2.Controls.Add(this.dtpfechaFinal);
            this.elPanel2.Controls.Add(this.cbo_usu);
            this.elPanel2.Controls.Add(this.label7);
            this.elPanel2.Controls.Add(this.dtpfechaInicial);
            this.elPanel2.Controls.Add(this.label4);
            this.elPanel2.Controls.Add(this.label2);
            this.elPanel2.Controls.Add(this.btnGenerar);
            this.elPanel2.Location = new System.Drawing.Point(0, 54);
            this.elPanel2.Name = "elPanel2";
            this.elPanel2.Size = new System.Drawing.Size(996, 78);
            this.elPanel2.TabIndex = 575;
            this.elPanel2.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // dgv_ventas
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_ventas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ventas.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_ventas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_ventas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ventas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ventas.DoubleBuffered = true;
            this.dgv_ventas.EnableHeadersVisualStyles = false;
            this.dgv_ventas.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.dgv_ventas.HeaderForeColor = System.Drawing.Color.SeaGreen;
            this.dgv_ventas.Location = new System.Drawing.Point(19, 144);
            this.dgv_ventas.Name = "dgv_ventas";
            this.dgv_ventas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_ventas.Size = new System.Drawing.Size(961, 247);
            this.dgv_ventas.TabIndex = 576;
            // 
            // Frm_VentasxUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(993, 445);
            this.Controls.Add(this.dgv_ventas);
            this.Controls.Add(this.elPanel2);
            this.Controls.Add(this.lblMixto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Pnl_Titulo);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTarjeta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblPlin);
            this.Controls.Add(this.lblYape);
            this.Controls.Add(this.lblEfectivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.l);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Label13);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_VentasxUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_VentasxUsuario";
            this.Load += new System.EventHandler(this.Frm_VentasxUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblEfectivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblYape)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTarjeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).EndInit();
            this.Pnl_Titulo.ResumeLayout(false);
            this.Pnl_Titulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMixto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elPanel2)).EndInit();
            this.elPanel2.ResumeLayout(false);
            this.elPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ventas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private Guna.UI.WinForms.GunaDateTimePicker dtpfechaFinal;
        private Guna.UI.WinForms.GunaDateTimePicker dtpfechaInicial;
        private System.Windows.Forms.Label label7;
        private Guna.UI.WinForms.GunaComboBox cbo_usu;
        private Guna.UI.WinForms.GunaButton btnGenerar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel lblPlin;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel lblYape;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel lblEfectivo;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel lblTarjeta;
        private System.Windows.Forms.Label label6;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel lblTotal;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Panel Pnl_Titulo;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider ElDivider7;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Button btn_minimi;
        internal System.Windows.Forms.Label Lbl_titulo;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel lblMixto;
        private System.Windows.Forms.Label label8;
        private Klik.Windows.Forms.v1.EntryLib.ELPanel elPanel2;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgv_ventas;
    }
}