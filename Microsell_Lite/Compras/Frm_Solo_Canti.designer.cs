namespace Microsell_Lite.Compras
{
    partial class Frm_Solo_Canti
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
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_stock = new System.Windows.Forms.Label();
            this.lbl_nom = new System.Windows.Forms.Label();
            this.txt_cant = new Klik.Windows.Forms.v1.EntryLib.ELEntryBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.elDivider1 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_cant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(196)))), ((int)(((byte)(228)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 43);
            this.panel1.TabIndex = 0;
            // 
            // lbl_stock
            // 
            this.lbl_stock.AutoSize = true;
            this.lbl_stock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            this.lbl_stock.Font = new System.Drawing.Font("Oxygen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stock.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_stock.Location = new System.Drawing.Point(314, 82);
            this.lbl_stock.Name = "lbl_stock";
            this.lbl_stock.Size = new System.Drawing.Size(27, 19);
            this.lbl_stock.TabIndex = 6;
            this.lbl_stock.Text = "00";
            // 
            // lbl_nom
            // 
            this.lbl_nom.AutoSize = true;
            this.lbl_nom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            this.lbl_nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nom.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_nom.Location = new System.Drawing.Point(12, 145);
            this.lbl_nom.Name = "lbl_nom";
            this.lbl_nom.Size = new System.Drawing.Size(12, 16);
            this.lbl_nom.TabIndex = 4;
            this.lbl_nom.Text = "-";
            // 
            // txt_cant
            // 
            this.txt_cant.AutoSize = false;
            this.txt_cant.CaptionStyle.CaptionSize = 0;
            this.txt_cant.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.txt_cant.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.txt_cant.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.txt_cant.CaptionStyle.TextStyle.Text = "elEntryBox1";
            this.txt_cant.Cursor = System.Windows.Forms.Cursors.Default;
            this.txt_cant.EditBoxStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.txt_cant.EditBoxStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cant.EditBoxStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernSilver;
            this.txt_cant.Location = new System.Drawing.Point(95, 74);
            this.txt_cant.Name = "txt_cant";
            this.txt_cant.Size = new System.Drawing.Size(180, 39);
            this.txt_cant.TabIndex = 1;
            this.txt_cant.ValidationStyle.PasswordChar = '\0';
            this.txt_cant.Value = "";
            this.txt_cant.TextChanged += new System.EventHandler(this.txt_cant_TextChanged);
            this.txt_cant.Click += new System.EventHandler(this.txt_cant2_Click);
            this.txt_cant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_cant_KeyDown);
            this.txt_cant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cant_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(196)))), ((int)(((byte)(228)))));
            this.label1.Font = new System.Drawing.Font("Oxygen", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(139, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 26);
            this.label1.TabIndex = 14;
            this.label1.Text = "Cantidad ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            this.label2.Font = new System.Drawing.Font("Oxygen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(303, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Stock";
            // 
            // elDivider1
            // 
            this.elDivider1.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.elDivider1.Location = new System.Drawing.Point(84, 115);
            this.elDivider1.Name = "elDivider1";
            this.elDivider1.Size = new System.Drawing.Size(200, 17);
            this.elDivider1.TabIndex = 489;
            // 
            // Frm_Solo_Canti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(365, 171);
            this.Controls.Add(this.elDivider1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_nom);
            this.Controls.Add(this.lbl_stock);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_cant);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Solo_Canti";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Solo_Canti";
            this.Load += new System.EventHandler(this.Frm_Solo_Canti_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Solo_Canti_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_cant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label lbl_nom;
        internal System.Windows.Forms.Label lbl_stock;
        private System.Windows.Forms.Panel panel1;
        public Klik.Windows.Forms.v1.EntryLib.ELEntryBox txt_cant;
        private Klik.Windows.Forms.v1.EntryLib.ELDivider elDivider1;
    }
}