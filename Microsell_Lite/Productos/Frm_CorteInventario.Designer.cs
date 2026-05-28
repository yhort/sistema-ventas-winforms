namespace Microsell_Lite.Productos
{
    partial class Frm_CorteInventario
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
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle13 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_CorteInventario));
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle14 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtBuscarProducto = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.elLabel8 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lbl_buscarProd = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.label51 = new System.Windows.Forms.Label();
            this.lblTotalCortes = new System.Windows.Forms.Label();
            this.lblTotalAjustes = new System.Windows.Forms.Label();
            this.txtMotivo = new Guna.UI.WinForms.GunaTextBox();
            this.txtObservacion = new Guna.UI.WinForms.GunaTextBox();
            this.dgvDetalle = new Guna.UI.WinForms.GunaDataGridView();
            this.btnCalcular = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btnAplicarAjuste = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboEstado = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDesde = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpHasta = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvCortes = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnRecargar = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnGenerarCorte = new Guna.UI2.WinForms.Guna2Button();
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_reload = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExportarExcel = new Guna.UI2.WinForms.Guna2Button();
            this.txtDescripcion = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_buscarProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCalcular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAplicarAjuste)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCortes)).BeginInit();
            this.pnl_titu.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.BackColor = System.Drawing.Color.White;
            this.txtBuscarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBuscarProducto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarProducto.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBuscarProducto.HintForeColor = System.Drawing.Color.Empty;
            this.txtBuscarProducto.HintText = "";
            this.txtBuscarProducto.isPassword = false;
            this.txtBuscarProducto.LineFocusedColor = System.Drawing.Color.DodgerBlue;
            this.txtBuscarProducto.LineIdleColor = System.Drawing.Color.WhiteSmoke;
            this.txtBuscarProducto.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.txtBuscarProducto.LineThickness = 1;
            this.txtBuscarProducto.Location = new System.Drawing.Point(324, 111);
            this.txtBuscarProducto.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(167, 23);
            this.txtBuscarProducto.TabIndex = 615;
            this.txtBuscarProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBuscarProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarProducto_KeyDown);
            // 
            // elLabel8
            // 
            this.elLabel8.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.elLabel8.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.elLabel8.BorderStyle.SolidColor = System.Drawing.Color.DarkViolet;
            paintStyle13.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle13.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel8.FlashStyle = paintStyle13;
            this.elLabel8.Location = new System.Drawing.Point(312, 107);
            this.elLabel8.Name = "elLabel8";
            this.elLabel8.Size = new System.Drawing.Size(189, 33);
            this.elLabel8.TabIndex = 614;
            this.elLabel8.TabStop = false;
            this.elLabel8.TextStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elLabel8.TextStyle.ForeColor = System.Drawing.Color.DimGray;
            this.elLabel8.TextStyle.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.elLabel8.TransparentStyle.BackColor = System.Drawing.Color.White;
            this.elLabel8.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.Location = new System.Drawing.Point(507, 111);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(26, 24);
            this.pictureBox4.TabIndex = 616;
            this.pictureBox4.TabStop = false;
            // 
            // lbl_buscarProd
            // 
            this.lbl_buscarProd.BackgroundImageStyle.Alpha = 60;
            this.lbl_buscarProd.BackgroundImageStyle.FadeStart = 60;
            this.lbl_buscarProd.BackgroundImageStyle.FilterColor = System.Drawing.Color.Black;
            this.lbl_buscarProd.BackgroundImageStyle.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.lbl_buscarProd.BackgroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_buscarProd.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.lbl_buscarProd.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.lbl_buscarProd.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.lbl_buscarProd.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.lbl_buscarProd.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.lbl_buscarProd.Cursor = System.Windows.Forms.Cursors.Default;
            paintStyle14.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle14.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.lbl_buscarProd.FlashStyle = paintStyle14;
            this.lbl_buscarProd.Location = new System.Drawing.Point(534, 112);
            this.lbl_buscarProd.Name = "lbl_buscarProd";
            this.lbl_buscarProd.Size = new System.Drawing.Size(31, 23);
            this.lbl_buscarProd.TabIndex = 612;
            this.lbl_buscarProd.TabStop = false;
            this.lbl_buscarProd.TextStyle.BackColor = System.Drawing.Color.White;
            this.lbl_buscarProd.TextStyle.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl_buscarProd.Visible = false;
            this.lbl_buscarProd.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Encode Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.Indigo;
            this.label51.Location = new System.Drawing.Point(307, 78);
            this.label51.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(180, 26);
            this.label51.TabIndex = 613;
            this.label51.Text = "Escanee el Codigo Producto";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalCortes
            // 
            this.lblTotalCortes.AutoSize = true;
            this.lblTotalCortes.Location = new System.Drawing.Point(965, 346);
            this.lblTotalCortes.Name = "lblTotalCortes";
            this.lblTotalCortes.Size = new System.Drawing.Size(35, 13);
            this.lblTotalCortes.TabIndex = 617;
            this.lblTotalCortes.Text = "label1";
            this.lblTotalCortes.Visible = false;
            // 
            // lblTotalAjustes
            // 
            this.lblTotalAjustes.AutoSize = true;
            this.lblTotalAjustes.Location = new System.Drawing.Point(74, 16);
            this.lblTotalAjustes.Name = "lblTotalAjustes";
            this.lblTotalAjustes.Size = new System.Drawing.Size(35, 13);
            this.lblTotalAjustes.TabIndex = 618;
            this.lblTotalAjustes.Text = "label1";
            // 
            // txtMotivo
            // 
            this.txtMotivo.BackColor = System.Drawing.Color.Transparent;
            this.txtMotivo.BaseColor = System.Drawing.Color.White;
            this.txtMotivo.BorderColor = System.Drawing.Color.Silver;
            this.txtMotivo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMotivo.FocusedBaseColor = System.Drawing.Color.White;
            this.txtMotivo.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtMotivo.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMotivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMotivo.Location = new System.Drawing.Point(104, 64);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.PasswordChar = '\0';
            this.txtMotivo.Radius = 8;
            this.txtMotivo.Size = new System.Drawing.Size(90, 30);
            this.txtMotivo.TabIndex = 619;
            // 
            // txtObservacion
            // 
            this.txtObservacion.BackColor = System.Drawing.Color.Transparent;
            this.txtObservacion.BaseColor = System.Drawing.Color.White;
            this.txtObservacion.BorderColor = System.Drawing.Color.Silver;
            this.txtObservacion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtObservacion.FocusedBaseColor = System.Drawing.Color.White;
            this.txtObservacion.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtObservacion.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtObservacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtObservacion.Location = new System.Drawing.Point(104, 28);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.PasswordChar = '\0';
            this.txtObservacion.Radius = 8;
            this.txtObservacion.Size = new System.Drawing.Size(75, 30);
            this.txtObservacion.TabIndex = 620;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            dataGridViewCellStyle43.BackColor = System.Drawing.Color.White;
            this.dgvDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle43;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle44.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle44.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle44.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle44.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle44.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle44;
            this.dgvDetalle.ColumnHeadersHeight = 4;
            dataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle45.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle45.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle45.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle45.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle45.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle45.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalle.DefaultCellStyle = dataGridViewCellStyle45;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetalle.Location = new System.Drawing.Point(14, 15);
            this.dgvDetalle.Name = "dgvDetalle";
            dataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle46.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle46.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle46.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle46.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle46.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle46;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(969, 170);
            this.dgvDetalle.TabIndex = 621;
            this.dgvDetalle.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.dgvDetalle.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetalle.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDetalle.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDetalle.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDetalle.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDetalle.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetalle.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetalle.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDetalle.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDetalle.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvDetalle.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDetalle.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDetalle.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvDetalle.ThemeStyle.ReadOnly = false;
            this.dgvDetalle.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetalle.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDetalle.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvDetalle.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDetalle.ThemeStyle.RowsStyle.Height = 22;
            this.dgvDetalle.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetalle.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellEndEdit);
            this.dgvDetalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvDetalle_KeyPress);
            // 
            // btnCalcular
            // 
            this.btnCalcular.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btnCalcular.BackgroundStyle.SolidColor = System.Drawing.Color.DodgerBlue;
            this.btnCalcular.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btnCalcular.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btnCalcular.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btnCalcular.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btnCalcular.BorderStyle.EdgeRadius = 7;
            this.btnCalcular.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btnCalcular.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.btnCalcular.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCalcular.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnCalcular.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btnCalcular.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btnCalcular.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCalcular.Location = new System.Drawing.Point(28, 111);
            this.btnCalcular.Margin = new System.Windows.Forms.Padding(4);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btnCalcular.Size = new System.Drawing.Size(142, 41);
            this.btnCalcular.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btnCalcular.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btnCalcular.TabIndex = 623;
            this.btnCalcular.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcular.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btnCalcular.TextStyle.Text = "Calcular";
            this.btnCalcular.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCalcular.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnAplicarAjuste
            // 
            this.btnAplicarAjuste.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btnAplicarAjuste.BackgroundStyle.SolidColor = System.Drawing.Color.DodgerBlue;
            this.btnAplicarAjuste.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btnAplicarAjuste.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btnAplicarAjuste.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btnAplicarAjuste.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btnAplicarAjuste.BorderStyle.EdgeRadius = 7;
            this.btnAplicarAjuste.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btnAplicarAjuste.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.btnAplicarAjuste.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAplicarAjuste.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnAplicarAjuste.Enabled = false;
            this.btnAplicarAjuste.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btnAplicarAjuste.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btnAplicarAjuste.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAplicarAjuste.Location = new System.Drawing.Point(236, 28);
            this.btnAplicarAjuste.Margin = new System.Windows.Forms.Padding(4);
            this.btnAplicarAjuste.Name = "btnAplicarAjuste";
            this.btnAplicarAjuste.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btnAplicarAjuste.Size = new System.Drawing.Size(32, 41);
            this.btnAplicarAjuste.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btnAplicarAjuste.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btnAplicarAjuste.TabIndex = 624;
            this.btnAplicarAjuste.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarAjuste.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btnAplicarAjuste.TextStyle.Text = "Aplicar Ajuste";
            this.btnAplicarAjuste.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAplicarAjuste.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btnAplicarAjuste.Click += new System.EventHandler(this.btnAplicarAjuste_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 625;
            this.label1.Text = "Motivo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 626;
            this.label2.Text = "Observacion";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMotivo);
            this.groupBox1.Controls.Add(this.txtObservacion);
            this.groupBox1.Controls.Add(this.btnCalcular);
            this.groupBox1.Controls.Add(this.lblTotalAjustes);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtBuscarProducto);
            this.groupBox1.Controls.Add(this.elLabel8);
            this.groupBox1.Controls.Add(this.cboEstado);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpDesde);
            this.groupBox1.Controls.Add(this.lbl_buscarProd);
            this.groupBox1.Controls.Add(this.btnAplicarAjuste);
            this.groupBox1.Controls.Add(this.dtpHasta);
            this.groupBox1.Controls.Add(this.label51);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(991, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(26, 29);
            this.groupBox1.TabIndex = 628;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.label6.Location = new System.Drawing.Point(258, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 644;
            this.label6.Text = "Estado";
            // 
            // cboEstado
            // 
            this.cboEstado.BackColor = System.Drawing.Color.Transparent;
            this.cboEstado.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.cboEstado.BorderRadius = 15;
            this.cboEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FocusedColor = System.Drawing.Color.Empty;
            this.cboEstado.FocusedState.Parent = this.cboEstado;
            this.cboEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.HoverState.Parent = this.cboEstado;
            this.cboEstado.ItemHeight = 30;
            this.cboEstado.ItemsAppearance.Parent = this.cboEstado;
            this.cboEstado.Location = new System.Drawing.Point(250, 125);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.ShadowDecoration.Parent = this.cboEstado;
            this.cboEstado.Size = new System.Drawing.Size(140, 36);
            this.cboEstado.TabIndex = 643;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.label4.Location = new System.Drawing.Point(322, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 641;
            this.label4.Text = "Desde";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.label5.Location = new System.Drawing.Point(190, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 642;
            this.label5.Text = "Hasta";
            // 
            // dtpDesde
            // 
            this.dtpDesde.BorderRadius = 15;
            this.dtpDesde.CheckedState.Parent = this.dtpDesde;
            this.dtpDesde.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.dtpDesde.ForeColor = System.Drawing.Color.White;
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDesde.HoverState.Parent = this.dtpDesde;
            this.dtpDesde.Location = new System.Drawing.Point(312, 39);
            this.dtpDesde.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDesde.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.ShadowDecoration.Parent = this.dtpDesde;
            this.dtpDesde.Size = new System.Drawing.Size(55, 36);
            this.dtpDesde.TabIndex = 637;
            this.dtpDesde.Value = new System.DateTime(2026, 5, 19, 13, 29, 15, 849);
            // 
            // dtpHasta
            // 
            this.dtpHasta.BorderRadius = 15;
            this.dtpHasta.CheckedState.Parent = this.dtpHasta;
            this.dtpHasta.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.dtpHasta.ForeColor = System.Drawing.Color.White;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpHasta.HoverState.Parent = this.dtpHasta;
            this.dtpHasta.Location = new System.Drawing.Point(181, 125);
            this.dtpHasta.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpHasta.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.ShadowDecoration.Parent = this.dtpHasta;
            this.dtpHasta.Size = new System.Drawing.Size(63, 36);
            this.dtpHasta.TabIndex = 638;
            this.dtpHasta.Value = new System.DateTime(2026, 5, 19, 13, 29, 15, 849);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 50;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.dgvDetalle);
            this.guna2Panel1.Location = new System.Drawing.Point(35, 364);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(999, 198);
            this.guna2Panel1.TabIndex = 631;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.dgvCortes);
            this.guna2Panel2.Location = new System.Drawing.Point(34, 152);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(999, 187);
            this.guna2Panel2.TabIndex = 633;
            // 
            // dgvCortes
            // 
            dataGridViewCellStyle47.BackColor = System.Drawing.Color.White;
            this.dgvCortes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle47;
            this.dgvCortes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCortes.BackgroundColor = System.Drawing.Color.White;
            this.dgvCortes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCortes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCortes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle48.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle48.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle48.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle48.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCortes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle48;
            this.dgvCortes.ColumnHeadersHeight = 4;
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle49.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle49.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle49.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle49.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle49.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCortes.DefaultCellStyle = dataGridViewCellStyle49;
            this.dgvCortes.EnableHeadersVisualStyles = false;
            this.dgvCortes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCortes.Location = new System.Drawing.Point(14, 14);
            this.dgvCortes.Name = "dgvCortes";
            this.dgvCortes.RowHeadersVisible = false;
            this.dgvCortes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCortes.Size = new System.Drawing.Size(969, 150);
            this.dgvCortes.TabIndex = 637;
            this.dgvCortes.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvCortes.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCortes.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCortes.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCortes.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCortes.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCortes.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCortes.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCortes.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvCortes.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCortes.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvCortes.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCortes.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCortes.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvCortes.ThemeStyle.ReadOnly = false;
            this.dgvCortes.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCortes.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCortes.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvCortes.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCortes.ThemeStyle.RowsStyle.Height = 22;
            this.dgvCortes.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCortes.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCortes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCortes_CellClick);
            // 
            // btnRecargar
            // 
            this.btnRecargar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnRecargar.BorderRadius = 20;
            this.btnRecargar.BorderThickness = 1;
            this.btnRecargar.CheckedState.Parent = this.btnRecargar;
            this.btnRecargar.CustomImages.Parent = this.btnRecargar;
            this.btnRecargar.FillColor = System.Drawing.Color.White;
            this.btnRecargar.FillColor2 = System.Drawing.Color.Empty;
            this.btnRecargar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecargar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnRecargar.HoverState.Parent = this.btnRecargar;
            this.btnRecargar.Location = new System.Drawing.Point(366, 584);
            this.btnRecargar.Name = "btnRecargar";
            this.btnRecargar.ShadowDecoration.Parent = this.btnRecargar;
            this.btnRecargar.Size = new System.Drawing.Size(141, 42);
            this.btnRecargar.TabIndex = 634;
            this.btnRecargar.Text = "Recargar";
            this.btnRecargar.Click += new System.EventHandler(this.btnRecargar_Click);
            // 
            // btnGenerarCorte
            // 
            this.btnGenerarCorte.BorderRadius = 8;
            this.btnGenerarCorte.CheckedState.Parent = this.btnGenerarCorte;
            this.btnGenerarCorte.CustomImages.Parent = this.btnGenerarCorte;
            this.btnGenerarCorte.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnGenerarCorte.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarCorte.ForeColor = System.Drawing.Color.White;
            this.btnGenerarCorte.HoverState.Parent = this.btnGenerarCorte;
            this.btnGenerarCorte.Location = new System.Drawing.Point(366, 92);
            this.btnGenerarCorte.Name = "btnGenerarCorte";
            this.btnGenerarCorte.ShadowDecoration.Parent = this.btnGenerarCorte;
            this.btnGenerarCorte.Size = new System.Drawing.Size(158, 41);
            this.btnGenerarCorte.TabIndex = 635;
            this.btnGenerarCorte.Text = "Generar Corte";
            this.btnGenerarCorte.Click += new System.EventHandler(this.btnGenerarCorte_Click);
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.pnl_titu.Controls.Add(this.btn_reload);
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Controls.Add(this.label3);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(1046, 43);
            this.pnl_titu.TabIndex = 636;
            // 
            // btn_reload
            // 
            this.btn_reload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_reload.FlatAppearance.BorderSize = 0;
            this.btn_reload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_reload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_reload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reload.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reload.ForeColor = System.Drawing.Color.White;
            this.btn_reload.Image = ((System.Drawing.Image)(resources.GetObject("btn_reload.Image")));
            this.btn_reload.Location = new System.Drawing.Point(955, 10);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(30, 25);
            this.btn_reload.TabIndex = 56;
            this.btn_reload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_reload.UseVisualStyleBackColor = true;
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
            this.btn_cerrar.Location = new System.Drawing.Point(991, 5);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(42, 35);
            this.btn_cerrar.TabIndex = 10;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Encode Sans Condensed SemiBold", 13F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "Historial Ajuste de Inventario";
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.BorderRadius = 20;
            this.btnExportarExcel.CheckedState.Parent = this.btnExportarExcel;
            this.btnExportarExcel.CustomImages.Parent = this.btnExportarExcel;
            this.btnExportarExcel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnExportarExcel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportarExcel.HoverState.Parent = this.btnExportarExcel;
            this.btnExportarExcel.Location = new System.Drawing.Point(619, 584);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.ShadowDecoration.Parent = this.btnExportarExcel;
            this.btnExportarExcel.Size = new System.Drawing.Size(141, 42);
            this.btnExportarExcel.TabIndex = 640;
            this.btnExportarExcel.Text = "Exportar Excel";
            this.btnExportarExcel.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            this.txtDescripcion.BorderRadius = 15;
            this.txtDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescripcion.DefaultText = "";
            this.txtDescripcion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDescripcion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDescripcion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescripcion.DisabledState.Parent = this.txtDescripcion;
            this.txtDescripcion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescripcion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescripcion.FocusedState.Parent = this.txtDescripcion;
            this.txtDescripcion.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescripcion.HoverState.Parent = this.txtDescripcion;
            this.txtDescripcion.Location = new System.Drawing.Point(34, 97);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.PasswordChar = '\0';
            this.txtDescripcion.PlaceholderText = "";
            this.txtDescripcion.SelectedText = "";
            this.txtDescripcion.ShadowDecoration.Parent = this.txtDescripcion;
            this.txtDescripcion.Size = new System.Drawing.Size(292, 36);
            this.txtDescripcion.TabIndex = 645;
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.Location = new System.Drawing.Point(878, 567);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(35, 13);
            this.lblTotalItems.TabIndex = 646;
            this.lblTotalItems.Text = "label1";
            this.lblTotalItems.Visible = false;
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Location = new System.Drawing.Point(996, 567);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(35, 13);
            this.lblValorTotal.TabIndex = 647;
            this.lblValorTotal.Text = "label1";
            this.lblValorTotal.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(878, 346);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 648;
            this.label7.Text = "Total Cortes";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.label8.Location = new System.Drawing.Point(44, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 20);
            this.label8.TabIndex = 649;
            this.label8.Text = "Ingrese la descripción";
            // 
            // Frm_CorteInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1046, 656);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.lblTotalItems);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.btnGenerarCorte);
            this.Controls.Add(this.btnRecargar);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.lblTotalCortes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_CorteInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frm_TomaInventario";
            this.Load += new System.EventHandler(this.Frm_CorteInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.elLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_buscarProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCalcular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAplicarAjuste)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCortes)).EndInit();
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI.WinForms.GunaTextBox txtMotivo;
        private System.Windows.Forms.Label lblTotalAjustes;
        private System.Windows.Forms.Label lblTotalCortes;
        internal Bunifu.Framework.UI.BunifuMaterialTextbox txtBuscarProducto;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel8;
        private System.Windows.Forms.PictureBox pictureBox4;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel lbl_buscarProd;
        private System.Windows.Forms.Label label51;
        private Guna.UI.WinForms.GunaDataGridView dgvDetalle;
        private Guna.UI.WinForms.GunaTextBox txtObservacion;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btnAplicarAjuste;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btnCalcular;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2GradientButton btnRecargar;
        private Guna.UI2.WinForms.Guna2Button btnGenerarCorte;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Button btn_reload;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCortes;
        private Guna.UI2.WinForms.Guna2Button btnExportarExcel;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpHasta;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cboEstado;
        private Guna.UI2.WinForms.Guna2TextBox txtDescripcion;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}