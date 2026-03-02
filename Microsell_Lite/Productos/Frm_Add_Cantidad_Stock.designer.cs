namespace Microsell_Lite.Productos
{
    partial class Frm_Add_Cantidad_Stock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Add_Cantidad_Stock));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.Lbl_stockActual = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.elLabel1 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.txt_cant = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_Prod = new System.Windows.Forms.Label();
            this.lbl_TipoProd = new System.Windows.Forms.Label();
            this.lbl_dife = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_Importeq = new System.Windows.Forms.Label();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.btn_procesar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.lbl_precompra = new System.Windows.Forms.Label();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_procesar)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(190)))), ((int)(((byte)(5)))));
            this.pnl_titu.Controls.Add(this.Label2);
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(412, 43);
            this.pnl_titu.TabIndex = 2;
            this.pnl_titu.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_titu_Paint);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Silver;
            this.Label2.Location = new System.Drawing.Point(194, 46);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(70, 13);
            this.Label2.TabIndex = 462;
            this.Label2.Text = "Stock Actual";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Lbl_stockActual
            // 
            this.Lbl_stockActual.AutoSize = true;
            this.Lbl_stockActual.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_stockActual.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_stockActual.ForeColor = System.Drawing.Color.Silver;
            this.Lbl_stockActual.Location = new System.Drawing.Point(313, 111);
            this.Lbl_stockActual.Name = "Lbl_stockActual";
            this.Lbl_stockActual.Size = new System.Drawing.Size(19, 21);
            this.Lbl_stockActual.TabIndex = 461;
            this.Lbl_stockActual.Text = "0";
            this.Lbl_stockActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(133, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cambiar Stock";
            // 
            // elLabel1
            // 
            this.elLabel1.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.elLabel1.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            paintStyle4.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle4.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel1.FlashStyle = paintStyle4;
            this.elLabel1.ForegroundImageStyle.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.elLabel1.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.elLabel1.Location = new System.Drawing.Point(29, 69);
            this.elLabel1.Name = "elLabel1";
            this.elLabel1.Size = new System.Drawing.Size(349, 88);
            this.elLabel1.TabIndex = 3;
            this.elLabel1.TabStop = false;
            this.elLabel1.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elLabel1.TextStyle.ForeColor = System.Drawing.Color.DimGray;
            this.elLabel1.TextStyle.Text = " Stock\r\n Fisico";
            this.elLabel1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // txt_cant
            // 
            this.txt_cant.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_cant.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cant.ForeColor = System.Drawing.Color.DimGray;
            this.txt_cant.Location = new System.Drawing.Point(119, 90);
            this.txt_cant.Name = "txt_cant";
            this.txt_cant.Size = new System.Drawing.Size(154, 33);
            this.txt_cant.TabIndex = 1;
            this.txt_cant.Text = "0";
            this.txt_cant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_cant.TextChanged += new System.EventHandler(this.txt_cant_TextChanged);
            this.txt_cant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_cant_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(279, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 462;
            this.label3.Text = "Stock Sistema";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(379, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 461;
            this.label4.Text = "0";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lbl_Prod
            // 
            this.lbl_Prod.AutoSize = true;
            this.lbl_Prod.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Prod.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Prod.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_Prod.Location = new System.Drawing.Point(314, 325);
            this.lbl_Prod.Name = "lbl_Prod";
            this.lbl_Prod.Size = new System.Drawing.Size(78, 17);
            this.lbl_Prod.TabIndex = 463;
            this.lbl_Prod.Text = "Stock Actual";
            this.lbl_Prod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_TipoProd
            // 
            this.lbl_TipoProd.AutoSize = true;
            this.lbl_TipoProd.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TipoProd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TipoProd.ForeColor = System.Drawing.Color.Silver;
            this.lbl_TipoProd.Location = new System.Drawing.Point(299, 203);
            this.lbl_TipoProd.Name = "lbl_TipoProd";
            this.lbl_TipoProd.Size = new System.Drawing.Size(11, 13);
            this.lbl_TipoProd.TabIndex = 464;
            this.lbl_TipoProd.Text = "-";
            this.lbl_TipoProd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_TipoProd.Visible = false;
            // 
            // lbl_dife
            // 
            this.lbl_dife.AutoSize = true;
            this.lbl_dife.BackColor = System.Drawing.Color.Transparent;
            this.lbl_dife.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dife.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_dife.Location = new System.Drawing.Point(81, 217);
            this.lbl_dife.Name = "lbl_dife";
            this.lbl_dife.Size = new System.Drawing.Size(24, 30);
            this.lbl_dife.TabIndex = 465;
            this.lbl_dife.Text = "0";
            this.lbl_dife.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(32, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 17);
            this.label5.TabIndex = 466;
            this.label5.Text = "Diferencia de Stock";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(262, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 468;
            this.label6.Text = "Importe S/";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Importeq
            // 
            this.lbl_Importeq.AutoSize = true;
            this.lbl_Importeq.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Importeq.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Importeq.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_Importeq.Location = new System.Drawing.Point(285, 217);
            this.lbl_Importeq.Name = "lbl_Importeq";
            this.lbl_Importeq.Size = new System.Drawing.Size(24, 30);
            this.lbl_Importeq.TabIndex = 467;
            this.lbl_Importeq.Text = "0";
            this.lbl_Importeq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btn_cerrar.Location = new System.Drawing.Point(370, 4);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(32, 32);
            this.btn_cerrar.TabIndex = 6;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // btn_procesar
            // 
            this.btn_procesar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_procesar.BackgroundStyle.SolidColor = System.Drawing.Color.SlateBlue;
            this.btn_procesar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_procesar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_procesar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_procesar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_procesar.BorderStyle.EdgeRadius = 7;
            this.btn_procesar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_procesar.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.btn_procesar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_procesar.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_procesar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_procesar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_procesar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_procesar.Location = new System.Drawing.Point(119, 262);
            this.btn_procesar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_procesar.Name = "btn_procesar";
            this.btn_procesar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_procesar.Size = new System.Drawing.Size(152, 45);
            this.btn_procesar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_procesar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_procesar.TabIndex = 469;
            this.btn_procesar.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_procesar.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_procesar.TextStyle.Text = "Aceptar";
            this.btn_procesar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_procesar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_procesar.Click += new System.EventHandler(this.btn_procesar_Click);
            // 
            // lbl_precompra
            // 
            this.lbl_precompra.AutoSize = true;
            this.lbl_precompra.BackColor = System.Drawing.Color.Transparent;
            this.lbl_precompra.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_precompra.ForeColor = System.Drawing.Color.Silver;
            this.lbl_precompra.Location = new System.Drawing.Point(404, 167);
            this.lbl_precompra.Name = "lbl_precompra";
            this.lbl_precompra.Size = new System.Drawing.Size(13, 13);
            this.lbl_precompra.TabIndex = 470;
            this.lbl_precompra.Text = "0";
            this.lbl_precompra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_Add_Cantidad_Stoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 351);
            this.Controls.Add(this.lbl_precompra);
            this.Controls.Add(this.btn_procesar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_Importeq);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_dife);
            this.Controls.Add(this.Lbl_stockActual);
            this.Controls.Add(this.lbl_TipoProd);
            this.Controls.Add(this.lbl_Prod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_cant);
            this.Controls.Add(this.elLabel1);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Add_Cantidad_Stoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edicion de Precio";
            this.Load += new System.EventHandler(this.Frm_Edit_Precio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Add_Cantidad_Stoc_KeyDown);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_procesar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label1;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Lbl_stockActual;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label lbl_Prod;
        internal System.Windows.Forms.TextBox txt_cant;
        internal System.Windows.Forms.Label lbl_TipoProd;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label lbl_Importeq;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label lbl_dife;
        internal System.Windows.Forms.Label lbl_precompra;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_procesar;
    }
}