namespace Microsell_Lite.Ventas
{
    partial class Frm_Reimpresiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Reimpresiones));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_add = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.txt_newid = new Guna.UI.WinForms.GunaTextBox();
            this.btn_newguardar = new Guna.UI.WinForms.GunaButton();
            this.txt_newnomcateg = new Guna.UI.WinForms.GunaTextBox();
            this.txt_nomcateg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_idcateg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_listo = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_cancel = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txt_buscar = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_add)).BeginInit();
            this.pnl_add.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.DimGray;
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(475, 43);
            this.pnl_titu.TabIndex = 1;
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_cerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cerrar.ForeColor = System.Drawing.Color.White;
            this.btn_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cerrar.Image")));
            this.btn_cerrar.Location = new System.Drawing.Point(433, 4);
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
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reimprimir Ticket";
            // 
            // pnl_add
            // 
            this.pnl_add.BackgroundStyle.GradientAngle = 45F;
            this.pnl_add.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.pnl_add.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.pnl_add.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.DoubleSolid;
            this.pnl_add.BorderStyle.EdgeRadius = 5;
            this.pnl_add.BorderStyle.SolidColor = System.Drawing.Color.SkyBlue;
            this.pnl_add.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.pnl_add.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnl_add.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.pnl_add.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.pnl_add.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.pnl_add.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.pnl_add.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.pnl_add.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.pnl_add.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.pnl_add.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.pnl_add.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.pnl_add.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.pnl_add.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnl_add.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.pnl_add.CaptionStyle.Visible = false;
            this.pnl_add.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.pnl_add.Controls.Add(this.txt_newid);
            this.pnl_add.Controls.Add(this.btn_newguardar);
            this.pnl_add.Controls.Add(this.txt_newnomcateg);
            this.pnl_add.Controls.Add(this.txt_nomcateg);
            this.pnl_add.Controls.Add(this.label3);
            this.pnl_add.Controls.Add(this.txt_idcateg);
            this.pnl_add.Controls.Add(this.label2);
            this.pnl_add.Location = new System.Drawing.Point(284, 441);
            this.pnl_add.Name = "pnl_add";
            this.pnl_add.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnl_add.Size = new System.Drawing.Size(163, 118);
            this.pnl_add.TabIndex = 3;
            this.pnl_add.Visible = false;
            this.pnl_add.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // txt_newid
            // 
            this.txt_newid.BaseColor = System.Drawing.Color.White;
            this.txt_newid.BorderColor = System.Drawing.Color.Silver;
            this.txt_newid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_newid.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_newid.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_newid.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_newid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_newid.Location = new System.Drawing.Point(41, 433);
            this.txt_newid.Name = "txt_newid";
            this.txt_newid.PasswordChar = '\0';
            this.txt_newid.Size = new System.Drawing.Size(19, 30);
            this.txt_newid.TabIndex = 17;
            this.txt_newid.Text = "0";
            this.txt_newid.Visible = false;
            // 
            // btn_newguardar
            // 
            this.btn_newguardar.AnimationHoverSpeed = 0.07F;
            this.btn_newguardar.AnimationSpeed = 0.03F;
            this.btn_newguardar.BackColor = System.Drawing.Color.Transparent;
            this.btn_newguardar.BaseColor = System.Drawing.Color.White;
            this.btn_newguardar.BorderColor = System.Drawing.Color.DarkOrchid;
            this.btn_newguardar.BorderSize = 1;
            this.btn_newguardar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_newguardar.FocusedColor = System.Drawing.Color.Empty;
            this.btn_newguardar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_newguardar.ForeColor = System.Drawing.Color.White;
            this.btn_newguardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_newguardar.Image")));
            this.btn_newguardar.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_newguardar.Location = new System.Drawing.Point(28, 469);
            this.btn_newguardar.Name = "btn_newguardar";
            this.btn_newguardar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_newguardar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_newguardar.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_newguardar.OnHoverImage = null;
            this.btn_newguardar.OnPressedColor = System.Drawing.Color.Black;
            this.btn_newguardar.Radius = 5;
            this.btn_newguardar.Size = new System.Drawing.Size(49, 31);
            this.btn_newguardar.TabIndex = 18;
            this.btn_newguardar.Text = "gunaButton1";
            this.btn_newguardar.Visible = false;
            // 
            // txt_newnomcateg
            // 
            this.txt_newnomcateg.BackColor = System.Drawing.Color.Transparent;
            this.txt_newnomcateg.BaseColor = System.Drawing.Color.White;
            this.txt_newnomcateg.BorderColor = System.Drawing.Color.Silver;
            this.txt_newnomcateg.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_newnomcateg.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_newnomcateg.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_newnomcateg.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_newnomcateg.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_newnomcateg.Location = new System.Drawing.Point(68, 433);
            this.txt_newnomcateg.Name = "txt_newnomcateg";
            this.txt_newnomcateg.PasswordChar = '\0';
            this.txt_newnomcateg.Radius = 5;
            this.txt_newnomcateg.Size = new System.Drawing.Size(381, 30);
            this.txt_newnomcateg.TabIndex = 16;
            this.txt_newnomcateg.Text = "gunaTextBox1";
            this.txt_newnomcateg.Visible = false;
            // 
            // txt_nomcateg
            // 
            this.txt_nomcateg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nomcateg.ForeColor = System.Drawing.Color.DimGray;
            this.txt_nomcateg.Location = new System.Drawing.Point(28, 123);
            this.txt_nomcateg.Name = "txt_nomcateg";
            this.txt_nomcateg.Size = new System.Drawing.Size(421, 24);
            this.txt_nomcateg.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nombre de Categoria";
            // 
            // txt_idcateg
            // 
            this.txt_idcateg.Enabled = false;
            this.txt_idcateg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_idcateg.ForeColor = System.Drawing.Color.DimGray;
            this.txt_idcateg.Location = new System.Drawing.Point(28, 50);
            this.txt_idcateg.Name = "txt_idcateg";
            this.txt_idcateg.Size = new System.Drawing.Size(156, 24);
            this.txt_idcateg.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Id Categoria";
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
            this.btn_listo.Location = new System.Drawing.Point(202, 317);
            this.btn_listo.Name = "btn_listo";
            this.btn_listo.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_listo.Size = new System.Drawing.Size(167, 49);
            this.btn_listo.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.TabIndex = 4;
            this.btn_listo.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_listo.TextStyle.Text = "Guardar";
            this.btn_listo.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_listo.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_listo.Click += new System.EventHandler(this.btn_listo_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancel.BackgroundStyle.SolidColor = System.Drawing.Color.WhiteSmoke;
            this.btn_cancel.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel.BorderStyle.EdgeRadius = 7;
            this.btn_cancel.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_cancel.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.btn_cancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_cancel.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancel.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_cancel.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancel.Location = new System.Drawing.Point(12, 317);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.btn_cancel.Size = new System.Drawing.Size(127, 49);
            this.btn_cancel.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.DimGray;
            this.btn_cancel.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.DimGray;
            this.btn_cancel.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.StateStyles.HoverStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_cancel.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_cancel.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_cancel.StateStyles.PressedStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.TextStyle.Text = "Cancelar";
            this.btn_cancel.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancel.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // txt_buscar
            // 
            this.txt_buscar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txt_buscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_buscar.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_buscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_buscar.HintForeColor = System.Drawing.Color.Empty;
            this.txt_buscar.HintText = "Buscar Categoria";
            this.txt_buscar.isPassword = false;
            this.txt_buscar.LineFocusedColor = System.Drawing.Color.DodgerBlue;
            this.txt_buscar.LineIdleColor = System.Drawing.Color.DodgerBlue;
            this.txt_buscar.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.txt_buscar.LineThickness = 3;
            this.txt_buscar.Location = new System.Drawing.Point(35, 60);
            this.txt_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(258, 33);
            this.txt_buscar.TabIndex = 15;
            this.txt_buscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_buscar.OnValueChanged += new System.EventHandler(this.txt_buscar_OnValueChanged);
            this.txt_buscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_buscar_KeyDown);
            // 
            // Frm_Reimpresiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(475, 571);
            this.Controls.Add(this.pnl_add);
            this.Controls.Add(this.txt_buscar);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.btn_listo);
            this.Controls.Add(this.btn_cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Reimpresiones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categorias";
            this.Load += new System.EventHandler(this.Frm_Reg_Prod_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_add)).EndInit();
            this.pnl_add.ResumeLayout(false);
            this.pnl_add.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label1;
        private Klik.Windows.Forms.v1.EntryLib.ELGroupBox pnl_add;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_cancel;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_listo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.TextBox txt_idcateg;
        internal System.Windows.Forms.TextBox txt_nomcateg;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txt_buscar;
        private Guna.UI.WinForms.GunaButton btn_newguardar;
        private Guna.UI.WinForms.GunaTextBox txt_newid;
        private Guna.UI.WinForms.GunaTextBox txt_newnomcateg;
    }
}