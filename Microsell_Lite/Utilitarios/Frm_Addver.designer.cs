namespace Microsell_Lite.Utilitarios
{
    partial class Frm_Addver
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
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle1 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Addver));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_acept = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.Lbl_Msm1 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.Pnl_titulo = new System.Windows.Forms.Panel();
            this.lbl_Nomalgo = new System.Windows.Forms.Label();
            this.ElDivider1 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.elDivider2 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_acept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lbl_Msm1)).BeginInit();
            this.Pnl_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider2)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // btn_acept
            // 
            resources.ApplyResources(this.btn_acept, "btn_acept");
            this.btn_acept.BackgroundStyle.GradientEndColor = System.Drawing.Color.DarkCyan;
            this.btn_acept.BackgroundStyle.GradientStartColor = System.Drawing.Color.DarkCyan;
            this.btn_acept.BackgroundStyle.SolidColor = System.Drawing.Color.Transparent;
            this.btn_acept.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_acept.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_acept.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_acept.Name = "btn_acept";
            this.btn_acept.TextStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_acept.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_acept.TextStyle.Text = resources.GetString("resource.Text1");
            this.btn_acept.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_acept.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_acept.Click += new System.EventHandler(this.btn_acept_Click);
            // 
            // Lbl_Msm1
            // 
            resources.ApplyResources(this.Lbl_Msm1, "Lbl_Msm1");
            this.Lbl_Msm1.BackgroundStyle.GradientEndColor = System.Drawing.SystemColors.ControlLightLight;
            this.Lbl_Msm1.BackgroundStyle.GradientStartColor = System.Drawing.SystemColors.ControlLightLight;
            this.Lbl_Msm1.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            paintStyle1.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle1.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.Lbl_Msm1.FlashStyle = paintStyle1;
            this.Lbl_Msm1.Name = "Lbl_Msm1";
            this.Lbl_Msm1.TabStop = false;
            this.Lbl_Msm1.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Msm1.TextStyle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Lbl_Msm1.TextStyle.Text = resources.GetString("resource.Text");
            this.Lbl_Msm1.TextStyle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Lbl_Msm1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // Pnl_titulo
            // 
            resources.ApplyResources(this.Pnl_titulo, "Pnl_titulo");
            this.Pnl_titulo.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Pnl_titulo.Controls.Add(this.ElDivider1);
            this.Pnl_titulo.Controls.Add(this.pictureBox1);
            this.Pnl_titulo.Controls.Add(this.lbl_Nomalgo);
            this.Pnl_titulo.Name = "Pnl_titulo";
            // 
            // lbl_Nomalgo
            // 
            resources.ApplyResources(this.lbl_Nomalgo, "lbl_Nomalgo");
            this.lbl_Nomalgo.ForeColor = System.Drawing.Color.White;
            this.lbl_Nomalgo.Name = "lbl_Nomalgo";
            // 
            // ElDivider1
            // 
            resources.ApplyResources(this.ElDivider1, "ElDivider1");
            this.ElDivider1.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.ElDivider1.LineColor = System.Drawing.Color.White;
            this.ElDivider1.LineSize = 1;
            this.ElDivider1.Name = "ElDivider1";
            this.ElDivider1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // elDivider2
            // 
            resources.ApplyResources(this.elDivider2, "elDivider2");
            this.elDivider2.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.elDivider2.LineColor = System.Drawing.Color.Gray;
            this.elDivider2.LineSize = 1;
            this.elDivider2.Name = "elDivider2";
            this.elDivider2.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // Frm_Addver
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ControlBox = false;
            this.Controls.Add(this.elDivider2);
            this.Controls.Add(this.Pnl_titulo);
            this.Controls.Add(this.Lbl_Msm1);
            this.Controls.Add(this.btn_acept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Addver";
            this.Load += new System.EventHandler(this.Frm_Addver_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Addver_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Frm_Addver_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_acept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lbl_Msm1)).EndInit();
            this.Pnl_titulo.ResumeLayout(false);
            this.Pnl_titulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_acept;
        private System.Windows.Forms.PictureBox pictureBox1;
        public Klik.Windows.Forms.v1.EntryLib.ELLabel Lbl_Msm1;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider elDivider2;
        internal System.Windows.Forms.Panel Pnl_titulo;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider ElDivider1;
        internal System.Windows.Forms.Label lbl_Nomalgo;
    }
}