namespace Microsell_Lite.Productos
{
    partial class Frm_Importar_Prod
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
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle2 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle3 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle1 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Importar_Prod));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_save = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.txt_ruta = new System.Windows.Forms.TextBox();
            this.elLabel1 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_nombook = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.txt_nomhoja = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_cargarfile = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_quitarfile = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.dtg_datos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_Nrofila = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.Lbl_registrado = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.btn_Presentaciones = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.btn_salir = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_save)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_nombook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cargarfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_quitarfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Nrofila)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lbl_registrado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_salir)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.btn_cerrar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 49);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 21);
            this.label1.TabIndex = 487;
            this.label1.Text = "Importar Productos de Excel";
            // 
            // btn_save
            // 
            this.btn_save.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_save.BackgroundStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.btn_save.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_save.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_save.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_save.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_save.BorderStyle.EdgeRadius = 7;
            this.btn_save.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_save.BorderStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.btn_save.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_save.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_save.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_save.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_save.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_save.Location = new System.Drawing.Point(418, 585);
            this.btn_save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_save.Name = "btn_save";
            this.btn_save.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_save.Size = new System.Drawing.Size(96, 37);
            this.btn_save.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_save.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_save.TabIndex = 485;
            this.btn_save.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_save.TextStyle.Text = "Save";
            this.btn_save.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_save.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = null;
            this.bunifuDragControl1.Vertical = true;
            // 
            // txt_ruta
            // 
            this.txt_ruta.BackColor = System.Drawing.Color.White;
            this.txt_ruta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ruta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ruta.Location = new System.Drawing.Point(40, 141);
            this.txt_ruta.Name = "txt_ruta";
            this.txt_ruta.Size = new System.Drawing.Size(171, 17);
            this.txt_ruta.TabIndex = 1;
            // 
            // elLabel1
            // 
            this.elLabel1.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.elLabel1.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.elLabel1.BorderStyle.SolidColor = System.Drawing.Color.DarkGray;
            paintStyle4.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle4.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel1.FlashStyle = paintStyle4;
            this.elLabel1.Location = new System.Drawing.Point(12, 133);
            this.elLabel1.Name = "elLabel1";
            this.elLabel1.Size = new System.Drawing.Size(210, 31);
            this.elLabel1.TabIndex = 2;
            this.elLabel1.TabStop = false;
            this.elLabel1.TextStyle.Text = "C:\\";
            this.elLabel1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(12, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ruta del Excel";
            // 
            // txt_nombook
            // 
            this.txt_nombook.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.txt_nombook.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.txt_nombook.BorderStyle.SolidColor = System.Drawing.Color.DarkGray;
            this.txt_nombook.Cursor = System.Windows.Forms.Cursors.Default;
            paintStyle2.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle2.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.txt_nombook.FlashStyle = paintStyle2;
            this.txt_nombook.Location = new System.Drawing.Point(17, 194);
            this.txt_nombook.Name = "txt_nombook";
            this.txt_nombook.Size = new System.Drawing.Size(620, 33);
            this.txt_nombook.TabIndex = 5;
            this.txt_nombook.TabStop = false;
            this.txt_nombook.TextStyle.Text = "Hoja1";
            this.txt_nombook.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // txt_nomhoja
            // 
            this.txt_nomhoja.BackColor = System.Drawing.Color.White;
            this.txt_nomhoja.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_nomhoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nomhoja.Location = new System.Drawing.Point(58, 258);
            this.txt_nomhoja.Name = "txt_nomhoja";
            this.txt_nomhoja.Size = new System.Drawing.Size(167, 15);
            this.txt_nomhoja.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(13, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nombre del Libro";
            // 
            // btn_cargarfile
            // 
            this.btn_cargarfile.BackgroundStyle.GradientEndColor = System.Drawing.Color.LimeGreen;
            this.btn_cargarfile.BackgroundStyle.GradientStartColor = System.Drawing.Color.LimeGreen;
            this.btn_cargarfile.BackgroundStyle.SolidColor = System.Drawing.Color.LimeGreen;
            this.btn_cargarfile.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cargarfile.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cargarfile.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cargarfile.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cargarfile.BorderStyle.SolidColor = System.Drawing.Color.GreenYellow;
            this.btn_cargarfile.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_cargarfile.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cargarfile.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_cargarfile.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cargarfile.Location = new System.Drawing.Point(16, 67);
            this.btn_cargarfile.Name = "btn_cargarfile";
            this.btn_cargarfile.Size = new System.Drawing.Size(110, 31);
            this.btn_cargarfile.TabIndex = 7;
            this.btn_cargarfile.TextStyle.BackColor = System.Drawing.Color.White;
            this.btn_cargarfile.TextStyle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cargarfile.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_cargarfile.TextStyle.Text = "Cargar Excel";
            this.btn_cargarfile.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cargarfile.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_cargarfile.Click += new System.EventHandler(this.btn_cargarfile_Click);
            // 
            // btn_quitarfile
            // 
            this.btn_quitarfile.BackgroundStyle.GradientEndColor = System.Drawing.Color.LightCoral;
            this.btn_quitarfile.BackgroundStyle.GradientStartColor = System.Drawing.Color.LightCoral;
            this.btn_quitarfile.BackgroundStyle.SolidColor = System.Drawing.Color.LimeGreen;
            this.btn_quitarfile.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_quitarfile.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_quitarfile.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_quitarfile.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_quitarfile.BorderStyle.SolidColor = System.Drawing.Color.LightCoral;
            this.btn_quitarfile.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_quitarfile.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_quitarfile.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_quitarfile.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_quitarfile.Location = new System.Drawing.Point(256, 67);
            this.btn_quitarfile.Name = "btn_quitarfile";
            this.btn_quitarfile.Size = new System.Drawing.Size(85, 31);
            this.btn_quitarfile.TabIndex = 8;
            this.btn_quitarfile.TextStyle.BackColor = System.Drawing.Color.White;
            this.btn_quitarfile.TextStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_quitarfile.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_quitarfile.TextStyle.Text = "Quitar Fila";
            this.btn_quitarfile.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_quitarfile.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_quitarfile.Click += new System.EventHandler(this.btn_quitarfile_Click);
            // 
            // dtg_datos
            // 
            this.dtg_datos.AllowUserToAddRows = false;
            this.dtg_datos.AllowUserToOrderColumns = true;
            this.dtg_datos.AllowUserToResizeRows = false;
            this.dtg_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_datos.ColumnHeadersVisible = false;
            this.dtg_datos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dtg_datos.Location = new System.Drawing.Point(12, 258);
            this.dtg_datos.Name = "dtg_datos";
            this.dtg_datos.Size = new System.Drawing.Size(625, 309);
            this.dtg_datos.TabIndex = 9;
            this.dtg_datos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_datos_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 180F;
            this.Column1.HeaderText = "ALMACEN RED C.";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(347, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nro Fila:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(507, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Nro Saved";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(504, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(56, 15);
            this.textBox1.TabIndex = 12;
            // 
            // lbl_Nrofila
            // 
            this.lbl_Nrofila.BackgroundStyle.GradientEndColor = System.Drawing.Color.DimGray;
            this.lbl_Nrofila.BackgroundStyle.GradientStartColor = System.Drawing.Color.DimGray;
            this.lbl_Nrofila.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.lbl_Nrofila.BackgroundStyle.SolidColor = System.Drawing.Color.DimGray;
            this.lbl_Nrofila.BorderStyle.GradientEndColor = System.Drawing.Color.DimGray;
            this.lbl_Nrofila.BorderStyle.GradientStartColor = System.Drawing.Color.DimGray;
            this.lbl_Nrofila.BorderStyle.SolidColor = System.Drawing.Color.DimGray;
            this.lbl_Nrofila.Cursor = System.Windows.Forms.Cursors.Default;
            paintStyle3.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle3.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.lbl_Nrofila.FlashStyle = paintStyle3;
            this.lbl_Nrofila.Location = new System.Drawing.Point(418, 137);
            this.lbl_Nrofila.Name = "lbl_Nrofila";
            this.lbl_Nrofila.Size = new System.Drawing.Size(59, 25);
            this.lbl_Nrofila.TabIndex = 13;
            this.lbl_Nrofila.TabStop = false;
            this.lbl_Nrofila.TextStyle.BackColor = System.Drawing.Color.DimGray;
            this.lbl_Nrofila.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Nrofila.TextStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Nrofila.TextStyle.Text = "000";
            this.lbl_Nrofila.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Nrofila.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // Lbl_registrado
            // 
            this.Lbl_registrado.BackgroundStyle.GradientEndColor = System.Drawing.Color.DimGray;
            this.Lbl_registrado.BackgroundStyle.GradientStartColor = System.Drawing.Color.DimGray;
            this.Lbl_registrado.BackgroundStyle.SolidColor = System.Drawing.Color.DimGray;
            this.Lbl_registrado.BorderStyle.SolidColor = System.Drawing.Color.DimGray;
            this.Lbl_registrado.Cursor = System.Windows.Forms.Cursors.Default;
            paintStyle1.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle1.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.Lbl_registrado.FlashStyle = paintStyle1;
            this.Lbl_registrado.Location = new System.Drawing.Point(578, 137);
            this.Lbl_registrado.Name = "Lbl_registrado";
            this.Lbl_registrado.Size = new System.Drawing.Size(59, 25);
            this.Lbl_registrado.TabIndex = 14;
            this.Lbl_registrado.TabStop = false;
            this.Lbl_registrado.TextStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Lbl_registrado.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_registrado.TextStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Lbl_registrado.TextStyle.Text = "000";
            this.Lbl_registrado.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Lbl_registrado.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // btn_Presentaciones
            // 
            this.btn_Presentaciones.BackColor = System.Drawing.Color.White;
            this.btn_Presentaciones.FlatAppearance.BorderSize = 0;
            this.btn_Presentaciones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_Presentaciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_Presentaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Presentaciones.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Presentaciones.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Presentaciones.Image = ((System.Drawing.Image)(resources.GetObject("btn_Presentaciones.Image")));
            this.btn_Presentaciones.Location = new System.Drawing.Point(438, 63);
            this.btn_Presentaciones.Name = "btn_Presentaciones";
            this.btn_Presentaciones.Size = new System.Drawing.Size(199, 35);
            this.btn_Presentaciones.TabIndex = 24;
            this.btn_Presentaciones.Text = " Importar Presentaciones";
            this.btn_Presentaciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Presentaciones.UseVisualStyleBackColor = false;
            this.btn_Presentaciones.Click += new System.EventHandler(this.btn_Presentaciones_Click);
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
            this.btn_cerrar.Location = new System.Drawing.Point(614, 10);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(25, 29);
            this.btn_cerrar.TabIndex = 488;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            // 
            // btn_salir
            // 
            this.btn_salir.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_salir.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.btn_salir.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_salir.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_salir.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_salir.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_salir.BorderStyle.EdgeRadius = 7;
            this.btn_salir.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_salir.BorderStyle.SolidColor = System.Drawing.Color.White;
            this.btn_salir.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_salir.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_salir.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_salir.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_salir.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_salir.Location = new System.Drawing.Point(170, 585);
            this.btn_salir.Margin = new System.Windows.Forms.Padding(4);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_salir.Size = new System.Drawing.Size(104, 37);
            this.btn_salir.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_salir.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_salir.TabIndex = 486;
            this.btn_salir.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salir.TextStyle.ForeColor = System.Drawing.Color.DimGray;
            this.btn_salir.TextStyle.Text = "Salir";
            this.btn_salir.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_salir.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // Frm_Importar_Prod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(649, 650);
            this.Controls.Add(this.btn_Presentaciones);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.Lbl_registrado);
            this.Controls.Add(this.txt_nombook);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtg_datos);
            this.Controls.Add(this.btn_quitarfile);
            this.Controls.Add(this.btn_cargarfile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_nomhoja);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ruta);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_Nrofila);
            this.Controls.Add(this.elLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Importar_Prod";
            this.Text = "Frm_Importar_Prod";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_save)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_nombook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cargarfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_quitarfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Nrofila)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lbl_registrado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_salir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_save;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel1;
        private System.Windows.Forms.TextBox txt_ruta;
        private System.Windows.Forms.DataGridView dtg_datos;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_quitarfile;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_cargarfile;
        private System.Windows.Forms.Label label3;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel txt_nombook;
        private System.Windows.Forms.TextBox txt_nomhoja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel lbl_Nrofila;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel Lbl_registrado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button btn_Presentaciones;
        internal System.Windows.Forms.Button btn_cerrar;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_salir;
    }
}