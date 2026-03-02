namespace Microsell_Lite.Productos
{
    partial class Frm_Edit_Precio
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
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle4 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle3 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Edit_Precio));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.elLabel1 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.txt_precioCompra = new System.Windows.Forms.TextBox();
            this.ElDivider1 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.txt_preVenta = new System.Windows.Forms.TextBox();
            this.elLabel2 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.lbl_producto = new System.Windows.Forms.Label();
            this.pnl_precios = new System.Windows.Forms.Panel();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Lbl_UtilidadUnit = new System.Windows.Forms.Label();
            this.Lbl_precompra = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Lbl_stockActual = new System.Windows.Forms.Label();
            this.btn_aceptar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.bt_cancelar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.lbl_idProd = new System.Windows.Forms.Label();
            this.lbl_TipoProd = new System.Windows.Forms.Label();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel2)).BeginInit();
            this.pnl_precios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_aceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_cancelar)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.YellowGreen;
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(431, 51);
            this.pnl_titu.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(60, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Edicion Precio o Cantidad";
            // 
            // elLabel1
            // 
            this.elLabel1.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.elLabel1.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            paintStyle4.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle4.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel1.FlashStyle = paintStyle4;
            this.elLabel1.ForegroundImageStyle.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.elLabel1.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.elLabel1.Location = new System.Drawing.Point(52, 89);
            this.elLabel1.Name = "elLabel1";
            this.elLabel1.Size = new System.Drawing.Size(305, 66);
            this.elLabel1.TabIndex = 3;
            this.elLabel1.TabStop = false;
            this.elLabel1.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elLabel1.TextStyle.ForeColor = System.Drawing.Color.DimGray;
            this.elLabel1.TextStyle.Text = "Precio Compra S/";
            this.elLabel1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // txt_precioCompra
            // 
            this.txt_precioCompra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_precioCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_precioCompra.ForeColor = System.Drawing.Color.DimGray;
            this.txt_precioCompra.Location = new System.Drawing.Point(165, 98);
            this.txt_precioCompra.Name = "txt_precioCompra";
            this.txt_precioCompra.Size = new System.Drawing.Size(130, 42);
            this.txt_precioCompra.TabIndex = 1;
            this.txt_precioCompra.Text = "0";
            this.txt_precioCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_precioCompra.TextChanged += new System.EventHandler(this.txt_precioCompra_TextChanged);
            this.txt_precioCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_precioCompra_KeyPress);
            // 
            // ElDivider1
            // 
            this.ElDivider1.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.ElDivider1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ElDivider1.Location = new System.Drawing.Point(76, 296);
            this.ElDivider1.Name = "ElDivider1";
            this.ElDivider1.Size = new System.Drawing.Size(267, 14);
            this.ElDivider1.TabIndex = 475;
            this.ElDivider1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // txt_preVenta
            // 
            this.txt_preVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_preVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_preVenta.ForeColor = System.Drawing.Color.DimGray;
            this.txt_preVenta.Location = new System.Drawing.Point(165, 190);
            this.txt_preVenta.Name = "txt_preVenta";
            this.txt_preVenta.Size = new System.Drawing.Size(130, 41);
            this.txt_preVenta.TabIndex = 2;
            this.txt_preVenta.Text = "0";
            this.txt_preVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_preVenta.TextChanged += new System.EventHandler(this.txt_preVenta_TextChanged);
            this.txt_preVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_preVenta_KeyPress);
            // 
            // elLabel2
            // 
            this.elLabel2.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.elLabel2.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            paintStyle3.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle3.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel2.FlashStyle = paintStyle3;
            this.elLabel2.ForegroundImageStyle.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.elLabel2.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.elLabel2.Location = new System.Drawing.Point(54, 181);
            this.elLabel2.Name = "elLabel2";
            this.elLabel2.Size = new System.Drawing.Size(303, 62);
            this.elLabel2.TabIndex = 476;
            this.elLabel2.TabStop = false;
            this.elLabel2.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elLabel2.TextStyle.ForeColor = System.Drawing.Color.DimGray;
            this.elLabel2.TextStyle.Text = "Precio Venta S/";
            this.elLabel2.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // lbl_producto
            // 
            this.lbl_producto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_producto.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_producto.Location = new System.Drawing.Point(33, 256);
            this.lbl_producto.Name = "lbl_producto";
            this.lbl_producto.Size = new System.Drawing.Size(370, 37);
            this.lbl_producto.TabIndex = 478;
            this.lbl_producto.Text = "-";
            this.lbl_producto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_precios
            // 
            this.pnl_precios.Controls.Add(this.Label8);
            this.pnl_precios.Controls.Add(this.Label7);
            this.pnl_precios.Controls.Add(this.Lbl_UtilidadUnit);
            this.pnl_precios.Controls.Add(this.Lbl_precompra);
            this.pnl_precios.Controls.Add(this.Label2);
            this.pnl_precios.Controls.Add(this.Lbl_stockActual);
            this.pnl_precios.Location = new System.Drawing.Point(474, 75);
            this.pnl_precios.Name = "pnl_precios";
            this.pnl_precios.Size = new System.Drawing.Size(86, 156);
            this.pnl_precios.TabIndex = 483;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.Silver;
            this.Label8.Location = new System.Drawing.Point(11, 6);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(48, 13);
            this.Label8.TabIndex = 481;
            this.Label8.Text = "Utilidad";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.Color.Silver;
            this.Label7.Location = new System.Drawing.Point(5, 61);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(59, 13);
            this.Label7.TabIndex = 480;
            this.Label7.Text = "P. Compra";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Lbl_UtilidadUnit
            // 
            this.Lbl_UtilidadUnit.AutoSize = true;
            this.Lbl_UtilidadUnit.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_UtilidadUnit.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_UtilidadUnit.ForeColor = System.Drawing.Color.Silver;
            this.Lbl_UtilidadUnit.Location = new System.Drawing.Point(26, 24);
            this.Lbl_UtilidadUnit.Name = "Lbl_UtilidadUnit";
            this.Lbl_UtilidadUnit.Size = new System.Drawing.Size(13, 13);
            this.Lbl_UtilidadUnit.TabIndex = 470;
            this.Lbl_UtilidadUnit.Text = "0";
            this.Lbl_UtilidadUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lbl_precompra
            // 
            this.Lbl_precompra.AutoSize = true;
            this.Lbl_precompra.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_precompra.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_precompra.ForeColor = System.Drawing.Color.Silver;
            this.Lbl_precompra.Location = new System.Drawing.Point(26, 79);
            this.Lbl_precompra.Name = "Lbl_precompra";
            this.Lbl_precompra.Size = new System.Drawing.Size(13, 13);
            this.Lbl_precompra.TabIndex = 467;
            this.Lbl_precompra.Text = "0";
            this.Lbl_precompra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Silver;
            this.Label2.Location = new System.Drawing.Point(3, 120);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(70, 13);
            this.Label2.TabIndex = 460;
            this.Label2.Text = "Stock Actual";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Lbl_stockActual
            // 
            this.Lbl_stockActual.AutoSize = true;
            this.Lbl_stockActual.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_stockActual.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_stockActual.ForeColor = System.Drawing.Color.Silver;
            this.Lbl_stockActual.Location = new System.Drawing.Point(30, 137);
            this.Lbl_stockActual.Name = "Lbl_stockActual";
            this.Lbl_stockActual.Size = new System.Drawing.Size(13, 13);
            this.Lbl_stockActual.TabIndex = 459;
            this.Lbl_stockActual.Text = "0";
            this.Lbl_stockActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_aceptar.BackgroundStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.btn_aceptar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_aceptar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_aceptar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_aceptar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_aceptar.BorderStyle.EdgeRadius = 7;
            this.btn_aceptar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_aceptar.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.btn_aceptar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_aceptar.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_aceptar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_aceptar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_aceptar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_aceptar.Location = new System.Drawing.Point(219, 327);
            this.btn_aceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_aceptar.Size = new System.Drawing.Size(138, 40);
            this.btn_aceptar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_aceptar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_aceptar.TabIndex = 484;
            this.btn_aceptar.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aceptar.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_aceptar.TextStyle.Text = "Aceptar";
            this.btn_aceptar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_aceptar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // bt_cancelar
            // 
            this.bt_cancelar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.bt_cancelar.BackgroundStyle.SolidColor = System.Drawing.Color.Tomato;
            this.bt_cancelar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.bt_cancelar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.bt_cancelar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.bt_cancelar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.bt_cancelar.BorderStyle.EdgeRadius = 7;
            this.bt_cancelar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.bt_cancelar.BorderStyle.SolidColor = System.Drawing.Color.Tomato;
            this.bt_cancelar.Cursor = System.Windows.Forms.Cursors.Default;
            this.bt_cancelar.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.bt_cancelar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.bt_cancelar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.bt_cancelar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bt_cancelar.Location = new System.Drawing.Point(65, 327);
            this.bt_cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.bt_cancelar.Name = "bt_cancelar";
            this.bt_cancelar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.bt_cancelar.Size = new System.Drawing.Size(121, 40);
            this.bt_cancelar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.Salmon;
            this.bt_cancelar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.Salmon;
            this.bt_cancelar.TabIndex = 485;
            this.bt_cancelar.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_cancelar.TextStyle.ForeColor = System.Drawing.Color.White;
            this.bt_cancelar.TextStyle.Text = "Cancelar";
            this.bt_cancelar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bt_cancelar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.bt_cancelar.Click += new System.EventHandler(this.bt_cancelar_Click);
            // 
            // lbl_idProd
            // 
            this.lbl_idProd.AutoSize = true;
            this.lbl_idProd.BackColor = System.Drawing.Color.Transparent;
            this.lbl_idProd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_idProd.ForeColor = System.Drawing.Color.Silver;
            this.lbl_idProd.Location = new System.Drawing.Point(520, 256);
            this.lbl_idProd.Name = "lbl_idProd";
            this.lbl_idProd.Size = new System.Drawing.Size(13, 13);
            this.lbl_idProd.TabIndex = 486;
            this.lbl_idProd.Text = "0";
            this.lbl_idProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_TipoProd
            // 
            this.lbl_TipoProd.AutoSize = true;
            this.lbl_TipoProd.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TipoProd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TipoProd.ForeColor = System.Drawing.Color.Silver;
            this.lbl_TipoProd.Location = new System.Drawing.Point(520, 283);
            this.lbl_TipoProd.Name = "lbl_TipoProd";
            this.lbl_TipoProd.Size = new System.Drawing.Size(13, 13);
            this.lbl_TipoProd.TabIndex = 487;
            this.lbl_TipoProd.Text = "0";
            this.lbl_TipoProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_Edit_Precio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(431, 399);
            this.Controls.Add(this.lbl_TipoProd);
            this.Controls.Add(this.lbl_idProd);
            this.Controls.Add(this.bt_cancelar);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.pnl_precios);
            this.Controls.Add(this.lbl_producto);
            this.Controls.Add(this.txt_preVenta);
            this.Controls.Add(this.elLabel2);
            this.Controls.Add(this.ElDivider1);
            this.Controls.Add(this.txt_precioCompra);
            this.Controls.Add(this.elLabel1);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Edit_Precio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edicion de Precio";
            this.Load += new System.EventHandler(this.Frm_Edit_Precio_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel2)).EndInit();
            this.pnl_precios.ResumeLayout(false);
            this.pnl_precios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_aceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_cancelar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Label label1;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel1;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel2;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider ElDivider1;
        internal System.Windows.Forms.Panel pnl_precios;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Lbl_UtilidadUnit;
        internal System.Windows.Forms.Label Lbl_precompra;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Lbl_stockActual;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_aceptar;
        private Klik.Windows.Forms.v1.EntryLib.ELButton bt_cancelar;
        internal System.Windows.Forms.TextBox txt_precioCompra;
        internal System.Windows.Forms.TextBox txt_preVenta;
        internal System.Windows.Forms.Label lbl_idProd;
        internal System.Windows.Forms.Label lbl_TipoProd;
        internal System.Windows.Forms.Label lbl_producto;
    }
}