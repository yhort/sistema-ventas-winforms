namespace Microsell_Lite.GUIAREMISION
{
    partial class Frm_Vehiculos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Vehiculos));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lsv_marca = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_Selecc = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.bt_delete = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_placaSecund = new Guna.UI.WinForms.GunaTextBox();
            this.txt_buscar = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btn_cancel = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_listo = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_fecha = new System.Windows.Forms.DateTimePicker();
            this.pnl_add = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.txt_idvehiculo = new Guna.UI.WinForms.GunaTextBox();
            this.txt_placa = new Guna.UI.WinForms.GunaTextBox();
            this.txt_marcaVehiculo = new Guna.UI.WinForms.GunaTextBox();
            this.txt_modelo = new Guna.UI.WinForms.GunaTextBox();
            this.txt_mtc_secund = new Guna.UI.WinForms.GunaTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_TUC_Secun = new Guna.UI.WinForms.GunaTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_mtc_placaPrincipal = new Guna.UI.WinForms.GunaTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_TUC = new Guna.UI.WinForms.GunaTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_add)).BeginInit();
            this.pnl_add.SuspendLayout();
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
            this.pnl_titu.Size = new System.Drawing.Size(981, 43);
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
            this.btn_cerrar.Location = new System.Drawing.Point(937, 5);
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
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar Vehiculos";
            // 
            // lsv_marca
            // 
            this.lsv_marca.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsv_marca.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lsv_marca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsv_marca.HideSelection = false;
            this.lsv_marca.Location = new System.Drawing.Point(12, 119);
            this.lsv_marca.Name = "lsv_marca";
            this.lsv_marca.Size = new System.Drawing.Size(957, 440);
            this.lsv_marca.TabIndex = 4;
            this.lsv_marca.UseCompatibleStateImageBehavior = false;
            this.lsv_marca.View = System.Windows.Forms.View.Details;
            this.lsv_marca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsv_marca_KeyDown);
            this.lsv_marca.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsv_marca_MouseDoubleClick);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Id";
            this.columnHeader8.Width = 40;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nro. de Placa";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Autorizacion placa Principal";
            this.columnHeader2.Width = 180;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "T.U.C";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Autoriz. placa secundaria";
            this.columnHeader4.Width = 170;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "T.U.C (placa secundaria)";
            this.columnHeader5.Width = 165;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Modelo";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Marca";
            this.columnHeader7.Width = 100;
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
            this.btn_Selecc.Location = new System.Drawing.Point(27, 49);
            this.btn_Selecc.Name = "btn_Selecc";
            this.btn_Selecc.Size = new System.Drawing.Size(32, 32);
            this.btn_Selecc.TabIndex = 12;
            this.btn_Selecc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btn_Selecc, "Seleccionar");
            this.btn_Selecc.UseVisualStyleBackColor = true;
            this.btn_Selecc.Visible = false;
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
            this.btn_edit.Location = new System.Drawing.Point(114, 49);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(32, 32);
            this.btn_edit.TabIndex = 11;
            this.btn_edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btn_edit, "Editar");
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
            this.btn_add.Location = new System.Drawing.Point(76, 49);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(32, 32);
            this.btn_add.TabIndex = 10;
            this.btn_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btn_add, "Agregar");
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // bt_delete
            // 
            this.bt_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_delete.FlatAppearance.BorderSize = 0;
            this.bt_delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.bt_delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.bt_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_delete.ForeColor = System.Drawing.Color.White;
            this.bt_delete.Image = ((System.Drawing.Image)(resources.GetObject("bt_delete.Image")));
            this.bt_delete.Location = new System.Drawing.Point(168, 49);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(32, 32);
            this.bt_delete.TabIndex = 13;
            this.bt_delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.bt_delete, "Eliminar");
            this.bt_delete.UseVisualStyleBackColor = true;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // label10
            // 
            this.label10.Image = ((System.Drawing.Image)(resources.GetObject("label10.Image")));
            this.label10.Location = new System.Drawing.Point(674, 276);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 21);
            this.label10.TabIndex = 585;
            this.toolTip1.SetToolTip(this.label10, "Ingres solo letras y números, no se permiten  espacios ni guiones");
            // 
            // label9
            // 
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.Location = new System.Drawing.Point(162, 273);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 21);
            this.label9.TabIndex = 586;
            this.toolTip1.SetToolTip(this.label9, "Tarjeta Única de Circulación");
            // 
            // label11
            // 
            this.label11.Image = ((System.Drawing.Image)(resources.GetObject("label11.Image")));
            this.label11.Location = new System.Drawing.Point(213, 115);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 21);
            this.label11.TabIndex = 587;
            this.toolTip1.SetToolTip(this.label11, "Ingres solo letras y números, no se permiten  espacios ni guiones");
            // 
            // label12
            // 
            this.label12.Image = ((System.Drawing.Image)(resources.GetObject("label12.Image")));
            this.label12.Location = new System.Drawing.Point(693, 366);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 21);
            this.label12.TabIndex = 590;
            this.toolTip1.SetToolTip(this.label12, "Tarjeta Única de Circulación");
            // 
            // txt_placaSecund
            // 
            this.txt_placaSecund.BackColor = System.Drawing.Color.Transparent;
            this.txt_placaSecund.BaseColor = System.Drawing.Color.White;
            this.txt_placaSecund.BorderColor = System.Drawing.Color.Silver;
            this.txt_placaSecund.BorderSize = 1;
            this.txt_placaSecund.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_placaSecund.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_placaSecund.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_placaSecund.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_placaSecund.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_placaSecund.Location = new System.Drawing.Point(523, 301);
            this.txt_placaSecund.Name = "txt_placaSecund";
            this.txt_placaSecund.PasswordChar = '\0';
            this.txt_placaSecund.Radius = 3;
            this.txt_placaSecund.Size = new System.Drawing.Size(249, 29);
            this.txt_placaSecund.TabIndex = 6;
            this.txt_placaSecund.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_placaSecund_KeyPress);
            // 
            // txt_buscar
            // 
            this.txt_buscar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txt_buscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_buscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_buscar.HintForeColor = System.Drawing.Color.Empty;
            this.txt_buscar.HintText = "Buscar";
            this.txt_buscar.isPassword = false;
            this.txt_buscar.LineFocusedColor = System.Drawing.Color.DodgerBlue;
            this.txt_buscar.LineIdleColor = System.Drawing.Color.DodgerBlue;
            this.txt_buscar.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.txt_buscar.LineThickness = 3;
            this.txt_buscar.Location = new System.Drawing.Point(711, 50);
            this.txt_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(258, 33);
            this.txt_buscar.TabIndex = 14;
            this.txt_buscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_buscar.OnValueChanged += new System.EventHandler(this.txt_buscar_OnValueChanged);
            this.txt_buscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_buscar_KeyDown);
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
            this.btn_cancel.Location = new System.Drawing.Point(269, 464);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.btn_cancel.Size = new System.Drawing.Size(150, 48);
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
            this.btn_listo.Location = new System.Drawing.Point(494, 464);
            this.btn_listo.Name = "btn_listo";
            this.btn_listo.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_listo.Size = new System.Drawing.Size(136, 48);
            this.btn_listo.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.TabIndex = 9;
            this.btn_listo.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_listo.TextStyle.Text = "Listo";
            this.btn_listo.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_listo.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_listo.Click += new System.EventHandler(this.btn_listo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(109, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Id Vehiculo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(523, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Modelo de vehículo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(109, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nro. de Placa";
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha.Location = new System.Drawing.Point(760, 476);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(92, 20);
            this.dtp_fecha.TabIndex = 15;
            this.dtp_fecha.Visible = false;
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
            this.pnl_add.Controls.Add(this.txt_idvehiculo);
            this.pnl_add.Controls.Add(this.txt_placa);
            this.pnl_add.Controls.Add(this.txt_marcaVehiculo);
            this.pnl_add.Controls.Add(this.txt_modelo);
            this.pnl_add.Controls.Add(this.txt_mtc_secund);
            this.pnl_add.Controls.Add(this.label14);
            this.pnl_add.Controls.Add(this.label12);
            this.pnl_add.Controls.Add(this.txt_TUC_Secun);
            this.pnl_add.Controls.Add(this.label13);
            this.pnl_add.Controls.Add(this.label11);
            this.pnl_add.Controls.Add(this.label9);
            this.pnl_add.Controls.Add(this.label10);
            this.pnl_add.Controls.Add(this.label8);
            this.pnl_add.Controls.Add(this.txt_placaSecund);
            this.pnl_add.Controls.Add(this.txt_mtc_placaPrincipal);
            this.pnl_add.Controls.Add(this.label7);
            this.pnl_add.Controls.Add(this.txt_TUC);
            this.pnl_add.Controls.Add(this.label6);
            this.pnl_add.Controls.Add(this.label5);
            this.pnl_add.Controls.Add(this.dtp_fecha);
            this.pnl_add.Controls.Add(this.label4);
            this.pnl_add.Controls.Add(this.label3);
            this.pnl_add.Controls.Add(this.label2);
            this.pnl_add.Controls.Add(this.btn_listo);
            this.pnl_add.Controls.Add(this.btn_cancel);
            this.pnl_add.Location = new System.Drawing.Point(12, 49);
            this.pnl_add.Name = "pnl_add";
            this.pnl_add.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnl_add.Size = new System.Drawing.Size(957, 535);
            this.pnl_add.TabIndex = 3;
            this.pnl_add.Visible = false;
            this.pnl_add.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.pnl_add.Click += new System.EventHandler(this.pnl_add_Click);
            // 
            // txt_idvehiculo
            // 
            this.txt_idvehiculo.BackColor = System.Drawing.Color.Transparent;
            this.txt_idvehiculo.BaseColor = System.Drawing.Color.White;
            this.txt_idvehiculo.BorderColor = System.Drawing.Color.Silver;
            this.txt_idvehiculo.BorderSize = 1;
            this.txt_idvehiculo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_idvehiculo.Enabled = false;
            this.txt_idvehiculo.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_idvehiculo.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_idvehiculo.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_idvehiculo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_idvehiculo.Location = new System.Drawing.Point(107, 56);
            this.txt_idvehiculo.Name = "txt_idvehiculo";
            this.txt_idvehiculo.PasswordChar = '\0';
            this.txt_idvehiculo.Radius = 3;
            this.txt_idvehiculo.Size = new System.Drawing.Size(246, 29);
            this.txt_idvehiculo.TabIndex = 0;
            // 
            // txt_placa
            // 
            this.txt_placa.BackColor = System.Drawing.Color.Transparent;
            this.txt_placa.BaseColor = System.Drawing.Color.White;
            this.txt_placa.BorderColor = System.Drawing.Color.Silver;
            this.txt_placa.BorderSize = 1;
            this.txt_placa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_placa.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_placa.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_placa.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_placa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_placa.Location = new System.Drawing.Point(107, 136);
            this.txt_placa.Name = "txt_placa";
            this.txt_placa.PasswordChar = '\0';
            this.txt_placa.Radius = 3;
            this.txt_placa.Size = new System.Drawing.Size(246, 29);
            this.txt_placa.TabIndex = 1;
            this.txt_placa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_placa_KeyPress);
            // 
            // txt_marcaVehiculo
            // 
            this.txt_marcaVehiculo.BackColor = System.Drawing.Color.Transparent;
            this.txt_marcaVehiculo.BaseColor = System.Drawing.Color.White;
            this.txt_marcaVehiculo.BorderColor = System.Drawing.Color.Silver;
            this.txt_marcaVehiculo.BorderSize = 1;
            this.txt_marcaVehiculo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_marcaVehiculo.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_marcaVehiculo.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_marcaVehiculo.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_marcaVehiculo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_marcaVehiculo.Location = new System.Drawing.Point(107, 215);
            this.txt_marcaVehiculo.Name = "txt_marcaVehiculo";
            this.txt_marcaVehiculo.PasswordChar = '\0';
            this.txt_marcaVehiculo.Radius = 3;
            this.txt_marcaVehiculo.Size = new System.Drawing.Size(249, 29);
            this.txt_marcaVehiculo.TabIndex = 3;
            // 
            // txt_modelo
            // 
            this.txt_modelo.BackColor = System.Drawing.Color.Transparent;
            this.txt_modelo.BaseColor = System.Drawing.Color.White;
            this.txt_modelo.BorderColor = System.Drawing.Color.Silver;
            this.txt_modelo.BorderSize = 1;
            this.txt_modelo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_modelo.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_modelo.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_modelo.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_modelo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_modelo.Location = new System.Drawing.Point(522, 136);
            this.txt_modelo.Name = "txt_modelo";
            this.txt_modelo.PasswordChar = '\0';
            this.txt_modelo.Radius = 3;
            this.txt_modelo.Size = new System.Drawing.Size(243, 29);
            this.txt_modelo.TabIndex = 2;
            // 
            // txt_mtc_secund
            // 
            this.txt_mtc_secund.BackColor = System.Drawing.Color.Transparent;
            this.txt_mtc_secund.BaseColor = System.Drawing.Color.White;
            this.txt_mtc_secund.BorderColor = System.Drawing.Color.Silver;
            this.txt_mtc_secund.BorderSize = 1;
            this.txt_mtc_secund.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_mtc_secund.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_mtc_secund.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_mtc_secund.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_mtc_secund.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_mtc_secund.Location = new System.Drawing.Point(110, 389);
            this.txt_mtc_secund.Name = "txt_mtc_secund";
            this.txt_mtc_secund.PasswordChar = '\0';
            this.txt_mtc_secund.Radius = 3;
            this.txt_mtc_secund.Size = new System.Drawing.Size(249, 29);
            this.txt_mtc_secund.TabIndex = 7;
            this.txt_mtc_secund.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_mtc_secund_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(109, 366);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(264, 18);
            this.label14.TabIndex = 591;
            this.label14.Text = "Autorización MTC de Placa secundaria";
            // 
            // txt_TUC_Secun
            // 
            this.txt_TUC_Secun.BackColor = System.Drawing.Color.Transparent;
            this.txt_TUC_Secun.BaseColor = System.Drawing.Color.White;
            this.txt_TUC_Secun.BorderColor = System.Drawing.Color.Silver;
            this.txt_TUC_Secun.BorderSize = 1;
            this.txt_TUC_Secun.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TUC_Secun.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_TUC_Secun.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_TUC_Secun.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_TUC_Secun.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_TUC_Secun.Location = new System.Drawing.Point(523, 389);
            this.txt_TUC_Secun.Name = "txt_TUC_Secun";
            this.txt_TUC_Secun.PasswordChar = '\0';
            this.txt_TUC_Secun.Radius = 3;
            this.txt_TUC_Secun.Size = new System.Drawing.Size(244, 29);
            this.txt_TUC_Secun.TabIndex = 8;
            this.txt_TUC_Secun.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_TUC_Secun_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(523, 366);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(164, 18);
            this.label13.TabIndex = 588;
            this.label13.Text = "T.U.C Placa secundaria";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(523, 276);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 18);
            this.label8.TabIndex = 582;
            this.label8.Text = "Nro. Placa secundaria";
            // 
            // txt_mtc_placaPrincipal
            // 
            this.txt_mtc_placaPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.txt_mtc_placaPrincipal.BaseColor = System.Drawing.Color.White;
            this.txt_mtc_placaPrincipal.BorderColor = System.Drawing.Color.Silver;
            this.txt_mtc_placaPrincipal.BorderSize = 1;
            this.txt_mtc_placaPrincipal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_mtc_placaPrincipal.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_mtc_placaPrincipal.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_mtc_placaPrincipal.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_mtc_placaPrincipal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_mtc_placaPrincipal.Location = new System.Drawing.Point(523, 215);
            this.txt_mtc_placaPrincipal.Name = "txt_mtc_placaPrincipal";
            this.txt_mtc_placaPrincipal.PasswordChar = '\0';
            this.txt_mtc_placaPrincipal.Radius = 3;
            this.txt_mtc_placaPrincipal.Size = new System.Drawing.Size(242, 29);
            this.txt_mtc_placaPrincipal.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(523, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(246, 18);
            this.label7.TabIndex = 579;
            this.label7.Text = "Autorización MTC de Placa principal";
            // 
            // txt_TUC
            // 
            this.txt_TUC.BackColor = System.Drawing.Color.Transparent;
            this.txt_TUC.BaseColor = System.Drawing.Color.White;
            this.txt_TUC.BorderColor = System.Drawing.Color.Silver;
            this.txt_TUC.BorderSize = 1;
            this.txt_TUC.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TUC.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_TUC.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_TUC.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_TUC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_TUC.Location = new System.Drawing.Point(110, 301);
            this.txt_TUC.Name = "txt_TUC";
            this.txt_TUC.PasswordChar = '\0';
            this.txt_TUC.Radius = 3;
            this.txt_TUC.Size = new System.Drawing.Size(249, 26);
            this.txt_TUC.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(109, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "T.U.C";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(107, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "Marca de vehículo";
            // 
            // Frm_Vehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(981, 596);
            this.Controls.Add(this.pnl_add);
            this.Controls.Add(this.txt_buscar);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.lsv_marca);
            this.Controls.Add(this.bt_delete);
            this.Controls.Add(this.btn_Selecc);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Vehiculos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Productos";
            this.Load += new System.EventHandler(this.Frm_Reg_Prod_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_add)).EndInit();
            this.pnl_add.ResumeLayout(false);
            this.pnl_add.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lsv_marca;
        private System.Windows.Forms.Button btn_Selecc;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.ToolTip toolTip1;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txt_buscar;
        internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox pnl_add;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_fecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_listo;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_cancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private Guna.UI.WinForms.GunaTextBox txt_mtc_placaPrincipal;
        private System.Windows.Forms.Label label7;
        private Guna.UI.WinForms.GunaTextBox txt_mtc_secund;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private Guna.UI.WinForms.GunaTextBox txt_TUC_Secun;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        internal Guna.UI.WinForms.GunaTextBox txt_TUC;
        internal Guna.UI.WinForms.GunaTextBox txt_idvehiculo;
        internal Guna.UI.WinForms.GunaTextBox txt_placa;
        internal Guna.UI.WinForms.GunaTextBox txt_marcaVehiculo;
        internal Guna.UI.WinForms.GunaTextBox txt_modelo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        internal Guna.UI.WinForms.GunaTextBox txt_placaSecund;
    }
}