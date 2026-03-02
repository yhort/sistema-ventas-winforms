namespace Microsell_Lite.Compras
{
    partial class Frm_Filtro_xFechas
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
            this.dtpfechaInicial = new System.Windows.Forms.DateTimePicker();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.elButton1 = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.elButton2 = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.elButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elButton2)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpfechaInicial
            // 
            this.dtpfechaInicial.Font = new System.Drawing.Font("Oxygen", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechaInicial.Location = new System.Drawing.Point(168, 119);
            this.dtpfechaInicial.Name = "dtpfechaInicial";
            this.dtpfechaInicial.Size = new System.Drawing.Size(158, 31);
            this.dtpfechaInicial.TabIndex = 0;
            this.dtpfechaInicial.Value = new System.DateTime(2023, 6, 9, 14, 11, 0, 0);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 40);
            this.panel1.TabIndex = 3;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // elButton1
            // 
            this.elButton1.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.elButton1.BackgroundStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(191)))), ((int)(((byte)(148)))));
            this.elButton1.Cursor = System.Windows.Forms.Cursors.Default;
            this.elButton1.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.elButton1.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elButton1.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.elButton1.Location = new System.Drawing.Point(272, 184);
            this.elButton1.Name = "elButton1";
            this.elButton1.Size = new System.Drawing.Size(136, 42);
            this.elButton1.TabIndex = 4;
            this.elButton1.TextStyle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elButton1.TextStyle.ForeColor = System.Drawing.Color.White;
            this.elButton1.TextStyle.Text = "Consultar";
            this.elButton1.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.elButton1.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.elButton1.Click += new System.EventHandler(this.elButton1_Click);
            // 
            // elButton2
            // 
            this.elButton2.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.elButton2.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.elButton2.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.elButton2.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elButton2.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.elButton2.Location = new System.Drawing.Point(92, 184);
            this.elButton2.Name = "elButton2";
            this.elButton2.Size = new System.Drawing.Size(136, 42);
            this.elButton2.TabIndex = 5;
            this.elButton2.TextStyle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elButton2.TextStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(191)))), ((int)(((byte)(148)))));
            this.elButton2.TextStyle.Text = "Cancelar";
            this.elButton2.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.elButton2.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.elButton2.Click += new System.EventHandler(this.elButton2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oxygen", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(191)))), ((int)(((byte)(148)))));
            this.label1.Location = new System.Drawing.Point(76, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Digite el mes, año para consultar";
            // 
            // Frm_Filtro_xFechas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(503, 258);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.elButton2);
            this.Controls.Add(this.elButton1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtpfechaInicial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Filtro_xFechas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_ReporteVentasFecha";
            this.Load += new System.EventHandler(this.Frm_ReporteVentasFecha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.elButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elButton2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpfechaInicial;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Klik.Windows.Forms.v1.EntryLib.ELButton elButton1;
        private System.Windows.Forms.Panel panel1;
        private Klik.Windows.Forms.v1.EntryLib.ELButton elButton2;
        private System.Windows.Forms.Label label1;
    }
}