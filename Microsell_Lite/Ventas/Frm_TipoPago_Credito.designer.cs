namespace Microsell_Lite.Ventas
{
    partial class Frm_TipoPago_Credito
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
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle5 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle2 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle6 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle4 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle3 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle1 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Acuenta = new System.Windows.Forms.TextBox();
            this.Lbl_Total_acobrar = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.lbl_Saldo_PagarCred = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_FechaVencix = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btn_Listo = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_Cancelar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.elLabel1 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.elLabel2 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.elLabel3 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.elLabel4 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Lbl_Total_acobrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Saldo_PagarCred)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Listo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Cancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel4)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(132)))), ((int)(((byte)(180)))));
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(371, 74);
            this.pnl_titu.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oxygen", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(87, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Venta a Crédito";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(93, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total venta S/.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(90, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "A Cuenta S/.";
            // 
            // txt_Acuenta
            // 
            this.txt_Acuenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Acuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Acuenta.ForeColor = System.Drawing.Color.DimGray;
            this.txt_Acuenta.Location = new System.Drawing.Point(129, 149);
            this.txt_Acuenta.Name = "txt_Acuenta";
            this.txt_Acuenta.Size = new System.Drawing.Size(140, 28);
            this.txt_Acuenta.TabIndex = 1;
            this.txt_Acuenta.Tag = "";
            this.txt_Acuenta.Text = "0";
            this.txt_Acuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Acuenta.TextChanged += new System.EventHandler(this.txt_Acuenta_TextChanged);
            this.txt_Acuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Acuenta_KeyPress);
            // 
            // Lbl_Total_acobrar
            // 
            this.Lbl_Total_acobrar.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.Lbl_Total_acobrar.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.Lbl_Total_acobrar.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.Lbl_Total_acobrar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
            this.Lbl_Total_acobrar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
            this.Lbl_Total_acobrar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
            this.Lbl_Total_acobrar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
            this.Lbl_Total_acobrar.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.Lbl_Total_acobrar.BorderStyle.SolidColor = System.Drawing.Color.DarkGray;
            this.Lbl_Total_acobrar.Cursor = System.Windows.Forms.Cursors.Default;
            paintStyle5.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle5.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.Lbl_Total_acobrar.FlashStyle = paintStyle5;
            this.Lbl_Total_acobrar.Location = new System.Drawing.Point(97, 234);
            this.Lbl_Total_acobrar.Name = "Lbl_Total_acobrar";
            this.Lbl_Total_acobrar.Size = new System.Drawing.Size(172, 38);
            this.Lbl_Total_acobrar.TabIndex = 5;
            this.Lbl_Total_acobrar.TabStop = false;
            this.Lbl_Total_acobrar.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Total_acobrar.TextStyle.ForeColor = System.Drawing.Color.DimGray;
            this.Lbl_Total_acobrar.TextStyle.Text = "00";
            this.Lbl_Total_acobrar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Lbl_Total_acobrar.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // lbl_Saldo_PagarCred
            // 
            this.lbl_Saldo_PagarCred.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.lbl_Saldo_PagarCred.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.lbl_Saldo_PagarCred.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.lbl_Saldo_PagarCred.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
            this.lbl_Saldo_PagarCred.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
            this.lbl_Saldo_PagarCred.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
            this.lbl_Saldo_PagarCred.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
            this.lbl_Saldo_PagarCred.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.lbl_Saldo_PagarCred.BorderStyle.SolidColor = System.Drawing.Color.DarkGray;
            this.lbl_Saldo_PagarCred.Cursor = System.Windows.Forms.Cursors.Default;
            paintStyle2.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle2.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.lbl_Saldo_PagarCred.FlashStyle = paintStyle2;
            this.lbl_Saldo_PagarCred.Location = new System.Drawing.Point(147, 329);
            this.lbl_Saldo_PagarCred.Name = "lbl_Saldo_PagarCred";
            this.lbl_Saldo_PagarCred.Size = new System.Drawing.Size(122, 28);
            this.lbl_Saldo_PagarCred.TabIndex = 7;
            this.lbl_Saldo_PagarCred.TabStop = false;
            this.lbl_Saldo_PagarCred.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Saldo_PagarCred.TextStyle.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_Saldo_PagarCred.TextStyle.Text = "00.00";
            this.lbl_Saldo_PagarCred.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Saldo_PagarCred.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(90, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Saldo S/.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(88, 382);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Vencimiento:";
            // 
            // dtp_FechaVencix
            // 
            this.dtp_FechaVencix.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_FechaVencix.Location = new System.Drawing.Point(161, 413);
            this.dtp_FechaVencix.Name = "dtp_FechaVencix";
            this.dtp_FechaVencix.Size = new System.Drawing.Size(108, 20);
            this.dtp_FechaVencix.TabIndex = 491;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(69, 442);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(237, 27);
            this.label6.TabIndex = 492;
            this.label6.Text = "(*) A cuenta no debe ser superior al Total";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(12, 467);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(349, 13);
            this.bunifuSeparator1.TabIndex = 493;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // btn_Listo
            // 
            this.btn_Listo.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_Listo.BackgroundStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(132)))), ((int)(((byte)(180)))));
            this.btn_Listo.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_Listo.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_Listo.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_Listo.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_Listo.BorderStyle.EdgeRadius = 7;
            this.btn_Listo.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_Listo.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.btn_Listo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Listo.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_Listo.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_Listo.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_Listo.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Listo.Location = new System.Drawing.Point(197, 491);
            this.btn_Listo.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Listo.Name = "btn_Listo";
            this.btn_Listo.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_Listo.Size = new System.Drawing.Size(146, 40);
            this.btn_Listo.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_Listo.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_Listo.TabIndex = 494;
            this.btn_Listo.TextStyle.Font = new System.Drawing.Font("Oxygen", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Listo.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_Listo.TextStyle.Text = "Listo";
            this.btn_Listo.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Listo.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_Listo.Click += new System.EventHandler(this.btn_Listo_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_Cancelar.BackgroundStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(132)))), ((int)(((byte)(180)))));
            this.btn_Cancelar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_Cancelar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_Cancelar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_Cancelar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_Cancelar.BorderStyle.EdgeRadius = 7;
            this.btn_Cancelar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_Cancelar.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Cancelar.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_Cancelar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_Cancelar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_Cancelar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Cancelar.Location = new System.Drawing.Point(22, 491);
            this.btn_Cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_Cancelar.Size = new System.Drawing.Size(146, 40);
            this.btn_Cancelar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_Cancelar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_Cancelar.TabIndex = 495;
            this.btn_Cancelar.TextStyle.Font = new System.Drawing.Font("Oxygen", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_Cancelar.TextStyle.Text = "Cancelar";
            this.btn_Cancelar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Cancelar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // elLabel1
            // 
            this.elLabel1.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.elLabel1.BackgroundStyle.GradientStartColor = System.Drawing.Color.Transparent;
            this.elLabel1.BackgroundStyle.SolidColor = System.Drawing.Color.Transparent;
            this.elLabel1.BorderStyle.SolidColor = System.Drawing.Color.DarkGray;
            paintStyle6.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle6.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel1.FlashStyle = paintStyle6;
            this.elLabel1.Location = new System.Drawing.Point(86, 214);
            this.elLabel1.Name = "elLabel1";
            this.elLabel1.Size = new System.Drawing.Size(188, 61);
            this.elLabel1.TabIndex = 496;
            this.elLabel1.TabStop = false;
            this.elLabel1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // elLabel2
            // 
            this.elLabel2.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.elLabel2.BackgroundStyle.GradientStartColor = System.Drawing.Color.Transparent;
            this.elLabel2.BackgroundStyle.SolidColor = System.Drawing.Color.Transparent;
            this.elLabel2.BorderStyle.SolidColor = System.Drawing.Color.DarkGray;
            paintStyle4.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle4.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel2.FlashStyle = paintStyle4;
            this.elLabel2.Location = new System.Drawing.Point(86, 122);
            this.elLabel2.Name = "elLabel2";
            this.elLabel2.Size = new System.Drawing.Size(188, 61);
            this.elLabel2.TabIndex = 497;
            this.elLabel2.TabStop = false;
            this.elLabel2.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // elLabel3
            // 
            this.elLabel3.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.elLabel3.BackgroundStyle.GradientStartColor = System.Drawing.Color.Transparent;
            this.elLabel3.BackgroundStyle.SolidColor = System.Drawing.Color.Transparent;
            this.elLabel3.BorderStyle.SolidColor = System.Drawing.Color.DarkGray;
            paintStyle3.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle3.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel3.FlashStyle = paintStyle3;
            this.elLabel3.Location = new System.Drawing.Point(86, 298);
            this.elLabel3.Name = "elLabel3";
            this.elLabel3.Size = new System.Drawing.Size(188, 61);
            this.elLabel3.TabIndex = 498;
            this.elLabel3.TabStop = false;
            this.elLabel3.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // elLabel4
            // 
            this.elLabel4.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.elLabel4.BackgroundStyle.GradientStartColor = System.Drawing.Color.Transparent;
            this.elLabel4.BackgroundStyle.SolidColor = System.Drawing.Color.Transparent;
            this.elLabel4.BorderStyle.SolidColor = System.Drawing.Color.DarkGray;
            paintStyle1.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle1.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel4.FlashStyle = paintStyle1;
            this.elLabel4.Location = new System.Drawing.Point(86, 378);
            this.elLabel4.Name = "elLabel4";
            this.elLabel4.Size = new System.Drawing.Size(188, 61);
            this.elLabel4.TabIndex = 499;
            this.elLabel4.TabStop = false;
            this.elLabel4.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // Frm_TipoPago_Credito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(371, 548);
            this.Controls.Add(this.dtp_FechaVencix);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.elLabel4);
            this.Controls.Add(this.lbl_Saldo_PagarCred);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.elLabel3);
            this.Controls.Add(this.txt_Acuenta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.elLabel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Lbl_Total_acobrar);
            this.Controls.Add(this.elLabel1);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Listo);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_TipoPago_Credito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo de Pago a Credito";
            this.Load += new System.EventHandler(this.Frm_TipoPago_Credito_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Lbl_Total_acobrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Saldo_PagarCred)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Listo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Cancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel Lbl_Total_acobrar;
        internal System.Windows.Forms.TextBox txt_Acuenta;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel lbl_Saldo_PagarCred;
        internal System.Windows.Forms.DateTimePicker dtp_FechaVencix;
        internal Klik.Windows.Forms.v1.EntryLib.ELButton btn_Cancelar;
        internal Klik.Windows.Forms.v1.EntryLib.ELButton btn_Listo;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel4;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel3;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel2;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel1;
    }
}