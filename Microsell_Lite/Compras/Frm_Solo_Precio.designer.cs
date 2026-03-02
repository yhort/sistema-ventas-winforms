namespace Microsell_Lite.Compras
{
    partial class Frm_Solo_Precio
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.txt_precio = new Klik.Windows.Forms.v1.EntryLib.ELEntryBox();
            this.lbl_nom = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.elDivider1 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_precio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oxygen", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(126, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 27);
            this.label1.TabIndex = 14;
            this.label1.Text = "Precio";
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(196)))), ((int)(((byte)(228)))));
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(342, 49);
            this.pnl_titu.TabIndex = 2;
            // 
            // txt_precio
            // 
            this.txt_precio.CaptionStyle.CaptionSize = 0;
            this.txt_precio.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.txt_precio.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.txt_precio.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.txt_precio.CaptionStyle.TextStyle.Text = "elEntryBox1";
            this.txt_precio.EditBoxStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.txt_precio.EditBoxStyle.Font = new System.Drawing.Font("Oxygen", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_precio.EditBoxStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernSilver;
            this.txt_precio.Location = new System.Drawing.Point(72, 73);
            this.txt_precio.Name = "txt_precio";
            this.txt_precio.Size = new System.Drawing.Size(180, 39);
            this.txt_precio.TabIndex = 1;
            this.txt_precio.ValidationStyle.PasswordChar = '\0';
            this.txt_precio.Value = "";
            this.txt_precio.TextChanged += new System.EventHandler(this.txt_cant_TextChanged);
            this.txt_precio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_cant_KeyDown);
            this.txt_precio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cant_KeyPress);
            // 
            // lbl_nom
            // 
            this.lbl_nom.AutoSize = true;
            this.lbl_nom.Font = new System.Drawing.Font("Oxygen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nom.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_nom.Location = new System.Drawing.Point(12, 140);
            this.lbl_nom.Name = "lbl_nom";
            this.lbl_nom.Size = new System.Drawing.Size(11, 15);
            this.lbl_nom.TabIndex = 4;
            this.lbl_nom.Text = "-";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SkyBlue;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Location = new System.Drawing.Point(0, 161);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(342, 3);
            this.label4.TabIndex = 487;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // elDivider1
            // 
            this.elDivider1.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.elDivider1.Location = new System.Drawing.Point(63, 105);
            this.elDivider1.Name = "elDivider1";
            this.elDivider1.Size = new System.Drawing.Size(200, 23);
            this.elDivider1.TabIndex = 488;
            // 
            // Frm_Solo_Precio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(342, 164);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_nom);
            this.Controls.Add(this.txt_precio);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.elDivider1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Solo_Precio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cantidad";
            this.Load += new System.EventHandler(this.Frm_Solo_Canti_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Solo_Canti_KeyDown);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_precio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_titu;
        internal System.Windows.Forms.Label lbl_nom;
        internal Klik.Windows.Forms.v1.EntryLib.ELEntryBox txt_precio;
        private System.Windows.Forms.Label label4;
        private Klik.Windows.Forms.v1.EntryLib.ELDivider elDivider1;
    }
}