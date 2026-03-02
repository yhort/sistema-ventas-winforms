namespace Microsell_Lite
{
    partial class Frm_Login
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
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle1 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Login));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.elLabel1 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.txt_usu = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.elLabel2 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.txt_password = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btn_listo = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel2)).BeginInit();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // elLabel1
            // 
            this.elLabel1.BackgroundImageStyle.Alpha = 60;
            this.elLabel1.BackgroundImageStyle.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.elLabel1.BackgroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.elLabel1.BackgroundImageStyle.ImageIndent = new System.Drawing.Point(10, 0);
            this.elLabel1.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.elLabel1.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.elLabel1.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel1.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.DoubleSolid;
            this.elLabel1.BorderStyle.SolidColor = System.Drawing.Color.SkyBlue;
            paintStyle2.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle2.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel1.FlashStyle = paintStyle2;
            this.elLabel1.Location = new System.Drawing.Point(30, 227);
            this.elLabel1.Name = "elLabel1";
            this.elLabel1.Size = new System.Drawing.Size(182, 36);
            this.elLabel1.TabIndex = 0;
            this.elLabel1.TabStop = false;
            this.elLabel1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // txt_usu
            // 
            this.txt_usu.BackColor = System.Drawing.Color.White;
            this.txt_usu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txt_usu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_usu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_usu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_usu.HintForeColor = System.Drawing.Color.Empty;
            this.txt_usu.HintText = "Usuario";
            this.txt_usu.isPassword = false;
            this.txt_usu.LineFocusedColor = System.Drawing.Color.DodgerBlue;
            this.txt_usu.LineIdleColor = System.Drawing.Color.Gainsboro;
            this.txt_usu.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.txt_usu.LineThickness = 1;
            this.txt_usu.Location = new System.Drawing.Point(67, 231);
            this.txt_usu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_usu.Name = "txt_usu";
            this.txt_usu.Size = new System.Drawing.Size(114, 27);
            this.txt_usu.TabIndex = 1;
            this.txt_usu.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_usu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_usu_KeyDown);
            // 
            // elLabel2
            // 
            this.elLabel2.BackgroundImageStyle.Alpha = 60;
            this.elLabel2.BackgroundImageStyle.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.elLabel2.BackgroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.elLabel2.BackgroundImageStyle.ImageIndent = new System.Drawing.Point(10, 0);
            this.elLabel2.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.elLabel2.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.elLabel2.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel2.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel2.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel2.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elLabel2.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.DoubleSolid;
            this.elLabel2.BorderStyle.SolidColor = System.Drawing.Color.LightSkyBlue;
            this.elLabel2.Cursor = System.Windows.Forms.Cursors.Default;
            paintStyle1.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle1.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel2.FlashStyle = paintStyle1;
            this.elLabel2.Location = new System.Drawing.Point(30, 303);
            this.elLabel2.Name = "elLabel2";
            this.elLabel2.Size = new System.Drawing.Size(182, 36);
            this.elLabel2.TabIndex = 13;
            this.elLabel2.TabStop = false;
            this.elLabel2.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.Transparent;
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(601, 31);
            this.pnl_titu.TabIndex = 15;
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
            this.btn_cerrar.Location = new System.Drawing.Point(566, 3);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(32, 28);
            this.btn_cerrar.TabIndex = 6;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // txt_password
            // 
            this.txt_password.BackColor = System.Drawing.Color.White;
            this.txt_password.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txt_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_password.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.ForeColor = System.Drawing.Color.Black;
            this.txt_password.HintForeColor = System.Drawing.Color.Black;
            this.txt_password.HintText = "contraseña";
            this.txt_password.isPassword = true;
            this.txt_password.LineFocusedColor = System.Drawing.Color.DodgerBlue;
            this.txt_password.LineIdleColor = System.Drawing.Color.White;
            this.txt_password.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.txt_password.LineThickness = 1;
            this.txt_password.Location = new System.Drawing.Point(67, 306);
            this.txt_password.Margin = new System.Windows.Forms.Padding(4);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(114, 31);
            this.txt_password.TabIndex = 2;
            this.txt_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_password.OnValueChanged += new System.EventHandler(this.txt_password_OnValueChanged);
            this.txt_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_password_KeyDown);
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
            this.btn_listo.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_listo.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_listo.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_listo.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_listo.Location = new System.Drawing.Point(57, 372);
            this.btn_listo.Name = "btn_listo";
            this.btn_listo.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_listo.Size = new System.Drawing.Size(124, 47);
            this.btn_listo.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.TabIndex = 19;
            this.btn_listo.TextStyle.BackColor = System.Drawing.Color.White;
            this.btn_listo.TextStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_listo.TextStyle.Text = "Iniciar Sesion";
            this.btn_listo.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_listo.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_listo.Click += new System.EventHandler(this.btn_listo_Click);
            // 
            // Frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(601, 516);
            this.Controls.Add(this.btn_listo);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.elLabel2);
            this.Controls.Add(this.txt_usu);
            this.Controls.Add(this.elLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Frm_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel2)).EndInit();
            this.pnl_titu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel1;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel2;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_usu;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Button btn_cerrar;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_password;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_listo;
    }
}