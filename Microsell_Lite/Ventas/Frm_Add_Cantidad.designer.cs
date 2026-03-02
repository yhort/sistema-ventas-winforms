namespace Microsell_Lite.Ventas
{
    partial class Frm_Add_Cantidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Add_Cantidad));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.Lbl_stockActual = new System.Windows.Forms.Label();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.elLabel1 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.txt_cant = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_Prod = new System.Windows.Forms.Label();
            this.lbl_TipoProd = new System.Windows.Forms.Label();
            this.lbl_und = new System.Windows.Forms.Label();
            this.lbl_Debug = new System.Windows.Forms.Label();
            this.lbl_estado = new System.Windows.Forms.Label();
            this.timerBalanza = new System.Windows.Forms.Timer(this.components);
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.DimGray;
            this.pnl_titu.Controls.Add(this.Label2);
            this.pnl_titu.Controls.Add(this.Lbl_stockActual);
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(481, 43);
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
            this.Lbl_stockActual.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_stockActual.ForeColor = System.Drawing.Color.Silver;
            this.Lbl_stockActual.Location = new System.Drawing.Point(221, 63);
            this.Lbl_stockActual.Name = "Lbl_stockActual";
            this.Lbl_stockActual.Size = new System.Drawing.Size(13, 13);
            this.Lbl_stockActual.TabIndex = 461;
            this.Lbl_stockActual.Text = "0";
            this.Lbl_stockActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btn_cerrar.Location = new System.Drawing.Point(439, 4);
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
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Editar Cantidad";
            // 
            // elLabel1
            // 
            this.elLabel1.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.elLabel1.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            paintStyle2.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle2.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel1.FlashStyle = paintStyle2;
            this.elLabel1.ForegroundImageStyle.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.elLabel1.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.elLabel1.Location = new System.Drawing.Point(102, 79);
            this.elLabel1.Name = "elLabel1";
            this.elLabel1.Size = new System.Drawing.Size(240, 73);
            this.elLabel1.TabIndex = 3;
            this.elLabel1.TabStop = false;
            this.elLabel1.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elLabel1.TextStyle.ForeColor = System.Drawing.Color.DimGray;
            this.elLabel1.TextStyle.Text = "Cantidad";
            this.elLabel1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // txt_cant
            // 
            this.txt_cant.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_cant.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cant.ForeColor = System.Drawing.Color.DimGray;
            this.txt_cant.Location = new System.Drawing.Point(169, 90);
            this.txt_cant.Name = "txt_cant";
            this.txt_cant.Size = new System.Drawing.Size(125, 31);
            this.txt_cant.TabIndex = 1;
            this.txt_cant.Text = "1";
            this.txt_cant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_cant.TextChanged += new System.EventHandler(this.txt_cant_TextChanged);
            this.txt_cant.Enter += new System.EventHandler(this.txt_cant_Enter);
            this.txt_cant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_cant_KeyDown);
            this.txt_cant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cant_KeyPress);
            this.txt_cant.Leave += new System.EventHandler(this.txt_cant_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(327, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 462;
            this.label3.Text = "Stock Actual";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(364, 63);
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
            this.lbl_Prod.Location = new System.Drawing.Point(2, 173);
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
            this.lbl_TipoProd.Location = new System.Drawing.Point(69, 63);
            this.lbl_TipoProd.Name = "lbl_TipoProd";
            this.lbl_TipoProd.Size = new System.Drawing.Size(11, 13);
            this.lbl_TipoProd.TabIndex = 464;
            this.lbl_TipoProd.Text = "-";
            this.lbl_TipoProd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_TipoProd.Visible = false;
            // 
            // lbl_und
            // 
            this.lbl_und.AutoSize = true;
            this.lbl_und.BackColor = System.Drawing.Color.Transparent;
            this.lbl_und.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_und.ForeColor = System.Drawing.Color.Silver;
            this.lbl_und.Location = new System.Drawing.Point(348, 108);
            this.lbl_und.Name = "lbl_und";
            this.lbl_und.Size = new System.Drawing.Size(11, 13);
            this.lbl_und.TabIndex = 465;
            this.lbl_und.Text = "-";
            this.lbl_und.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_und.Visible = false;
            // 
            // lbl_Debug
            // 
            this.lbl_Debug.AutoSize = true;
            this.lbl_Debug.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Debug.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Debug.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_Debug.Location = new System.Drawing.Point(10, 46);
            this.lbl_Debug.Name = "lbl_Debug";
            this.lbl_Debug.Size = new System.Drawing.Size(13, 17);
            this.lbl_Debug.TabIndex = 466;
            this.lbl_Debug.Text = "-";
            this.lbl_Debug.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_estado
            // 
            this.lbl_estado.AutoSize = true;
            this.lbl_estado.BackColor = System.Drawing.Color.Transparent;
            this.lbl_estado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_estado.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_estado.Location = new System.Drawing.Point(115, 170);
            this.lbl_estado.Name = "lbl_estado";
            this.lbl_estado.Size = new System.Drawing.Size(13, 17);
            this.lbl_estado.TabIndex = 467;
            this.lbl_estado.Text = "-";
            this.lbl_estado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerBalanza
            // 
            this.timerBalanza.Interval = 5000;
            // 
            // Frm_Add_Cantidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 199);
            this.Controls.Add(this.lbl_estado);
            this.Controls.Add(this.lbl_Debug);
            this.Controls.Add(this.lbl_und);
            this.Controls.Add(this.lbl_TipoProd);
            this.Controls.Add(this.lbl_Prod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_cant);
            this.Controls.Add(this.elLabel1);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Add_Cantidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edicion de Precio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Add_Cantidad_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Add_Cantidad_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).EndInit();
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
        internal System.Windows.Forms.Label lbl_und;
        internal System.Windows.Forms.Label lbl_Debug;
        internal System.Windows.Forms.Label lbl_estado;
        private System.Windows.Forms.Timer timerBalanza;
    }
}