namespace Microsell_Lite.Utilitarios
{
    partial class Frm_Unidad_deMedidas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Unidad_deMedidas));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_add = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.gunaComboBox1 = new Guna.UI.WinForms.GunaComboBox();
            this.txt_newid = new Guna.UI.WinForms.GunaTextBox();
            this.btn_newguardar = new Guna.UI.WinForms.GunaButton();
            this.txt_newnomcateg = new Guna.UI.WinForms.GunaTextBox();
            this.txt_nomcateg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_idcateg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_listo = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_cancel = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.lsv_categoria = new System.Windows.Forms.ListView();
            this.btn_Selecc = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
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
            this.pnl_titu.Size = new System.Drawing.Size(790, 43);
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
            this.btn_cerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cerrar.ForeColor = System.Drawing.Color.White;
            this.btn_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cerrar.Image")));
            this.btn_cerrar.Location = new System.Drawing.Point(748, 4);
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
            this.label1.Size = new System.Drawing.Size(277, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mantenimiento de Unidad de Medidas";
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
            this.pnl_add.Controls.Add(this.label6);
            this.pnl_add.Controls.Add(this.label5);
            this.pnl_add.Controls.Add(this.textBox2);
            this.pnl_add.Controls.Add(this.label4);
            this.pnl_add.Controls.Add(this.textBox1);
            this.pnl_add.Controls.Add(this.listView1);
            this.pnl_add.Controls.Add(this.gunaComboBox1);
            this.pnl_add.Controls.Add(this.txt_newid);
            this.pnl_add.Controls.Add(this.btn_newguardar);
            this.pnl_add.Controls.Add(this.txt_newnomcateg);
            this.pnl_add.Controls.Add(this.txt_nomcateg);
            this.pnl_add.Controls.Add(this.label3);
            this.pnl_add.Controls.Add(this.txt_idcateg);
            this.pnl_add.Controls.Add(this.label2);
            this.pnl_add.Controls.Add(this.btn_listo);
            this.pnl_add.Controls.Add(this.btn_cancel);
            this.pnl_add.Location = new System.Drawing.Point(4, 61);
            this.pnl_add.Name = "pnl_add";
            this.pnl_add.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnl_add.Size = new System.Drawing.Size(786, 506);
            this.pnl_add.TabIndex = 3;
            this.pnl_add.Visible = false;
            this.pnl_add.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LightCoral;
            this.label6.Location = new System.Drawing.Point(380, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 18);
            this.label6.TabIndex = 27;
            this.label6.Text = "Resultado de Busqueda";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 18);
            this.label5.TabIndex = 26;
            this.label5.Text = "Factor Conversion";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.DimGray;
            this.textBox2.Location = new System.Drawing.Point(23, 233);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(204, 24);
            this.textBox2.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 18);
            this.label4.TabIndex = 24;
            this.label4.Text = "Describa el producto  a Buscar";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.DimGray;
            this.textBox1.Location = new System.Drawing.Point(23, 96);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(328, 24);
            this.textBox1.TabIndex = 23;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(383, 75);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(289, 252);
            this.listView1.TabIndex = 22;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // gunaComboBox1
            // 
            this.gunaComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaComboBox1.BaseColor = System.Drawing.Color.White;
            this.gunaComboBox1.BorderColor = System.Drawing.Color.Silver;
            this.gunaComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gunaComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gunaComboBox1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaComboBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gunaComboBox1.ForeColor = System.Drawing.Color.Black;
            this.gunaComboBox1.FormattingEnabled = true;
            this.gunaComboBox1.Items.AddRange(new object[] {
            "Pqtes\t",
            "Kilogramos"});
            this.gunaComboBox1.Location = new System.Drawing.Point(25, 164);
            this.gunaComboBox1.Name = "gunaComboBox1";
            this.gunaComboBox1.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaComboBox1.OnHoverItemForeColor = System.Drawing.Color.White;
            this.gunaComboBox1.Size = new System.Drawing.Size(121, 26);
            this.gunaComboBox1.TabIndex = 20;
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
            this.txt_newid.Location = new System.Drawing.Point(224, 470);
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
            this.txt_newnomcateg.Location = new System.Drawing.Point(259, 469);
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
            this.txt_nomcateg.Location = new System.Drawing.Point(655, 469);
            this.txt_nomcateg.Name = "txt_nomcateg";
            this.txt_nomcateg.Size = new System.Drawing.Size(45, 24);
            this.txt_nomcateg.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Seleccione la Unidad de Medida";
            // 
            // txt_idcateg
            // 
            this.txt_idcateg.Enabled = false;
            this.txt_idcateg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_idcateg.ForeColor = System.Drawing.Color.DimGray;
            this.txt_idcateg.Location = new System.Drawing.Point(24, 37);
            this.txt_idcateg.Name = "txt_idcateg";
            this.txt_idcateg.Size = new System.Drawing.Size(156, 24);
            this.txt_idcateg.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Id ";
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
            this.btn_listo.Location = new System.Drawing.Point(420, 370);
            this.btn_listo.Name = "btn_listo";
            this.btn_listo.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_listo.Size = new System.Drawing.Size(157, 49);
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
            this.btn_cancel.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancel.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_cancel.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancel.Location = new System.Drawing.Point(162, 370);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.btn_cancel.Size = new System.Drawing.Size(157, 49);
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
            // lsv_categoria
            // 
            this.lsv_categoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsv_categoria.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsv_categoria.HideSelection = false;
            this.lsv_categoria.Location = new System.Drawing.Point(4, 99);
            this.lsv_categoria.Name = "lsv_categoria";
            this.lsv_categoria.Size = new System.Drawing.Size(723, 460);
            this.lsv_categoria.TabIndex = 4;
            this.lsv_categoria.UseCompatibleStateImageBehavior = false;
            this.lsv_categoria.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsv_categoria_KeyDown);
            this.lsv_categoria.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsv_categoria_MouseDoubleClick);
            // 
            // btn_Selecc
            // 
            this.btn_Selecc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Selecc.FlatAppearance.BorderSize = 0;
            this.btn_Selecc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_Selecc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_Selecc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Selecc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Selecc.ForeColor = System.Drawing.Color.White;
            this.btn_Selecc.Image = ((System.Drawing.Image)(resources.GetObject("btn_Selecc.Image")));
            this.btn_Selecc.Location = new System.Drawing.Point(32, 61);
            this.btn_Selecc.Name = "btn_Selecc";
            this.btn_Selecc.Size = new System.Drawing.Size(32, 32);
            this.btn_Selecc.TabIndex = 12;
            this.btn_Selecc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btn_Selecc, "Seleccione una Categoria ");
            this.btn_Selecc.UseVisualStyleBackColor = true;
            this.btn_Selecc.Click += new System.EventHandler(this.btn_Selecc_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_edit.FlatAppearance.BorderSize = 0;
            this.btn_edit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_edit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.ForeColor = System.Drawing.Color.White;
            this.btn_edit.Image = ((System.Drawing.Image)(resources.GetObject("btn_edit.Image")));
            this.btn_edit.Location = new System.Drawing.Point(189, 61);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(32, 32);
            this.btn_edit.TabIndex = 11;
            this.btn_edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btn_edit, "Editar una Categoria");
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add.FlatAppearance.BorderSize = 0;
            this.btn_add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.Image")));
            this.btn_add.Location = new System.Drawing.Point(112, 61);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(32, 32);
            this.btn_add.TabIndex = 10;
            this.btn_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btn_add, "Agregar una Categoria");
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
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
            this.txt_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_buscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_buscar.HintForeColor = System.Drawing.Color.Empty;
            this.txt_buscar.HintText = "Buscar Categoria";
            this.txt_buscar.isPassword = false;
            this.txt_buscar.LineFocusedColor = System.Drawing.Color.DodgerBlue;
            this.txt_buscar.LineIdleColor = System.Drawing.Color.DodgerBlue;
            this.txt_buscar.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.txt_buscar.LineThickness = 3;
            this.txt_buscar.Location = new System.Drawing.Point(273, 59);
            this.txt_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(258, 33);
            this.txt_buscar.TabIndex = 15;
            this.txt_buscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_buscar.OnValueChanged += new System.EventHandler(this.txt_buscar_OnValueChanged);
            this.txt_buscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_buscar_KeyDown);
            // 
            // Frm_Unidad_deMedidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(790, 571);
            this.Controls.Add(this.pnl_add);
            this.Controls.Add(this.txt_buscar);
            this.Controls.Add(this.btn_Selecc);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.lsv_categoria);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Unidad_deMedidas";
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
        private System.Windows.Forms.ListView lsv_categoria;
        private System.Windows.Forms.Button btn_Selecc;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.TextBox txt_idcateg;
        internal System.Windows.Forms.TextBox txt_nomcateg;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txt_buscar;
        private Guna.UI.WinForms.GunaButton btn_newguardar;
        private Guna.UI.WinForms.GunaTextBox txt_newid;
        private Guna.UI.WinForms.GunaTextBox txt_newnomcateg;
        private Guna.UI.WinForms.GunaComboBox gunaComboBox1;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label6;
    }
}