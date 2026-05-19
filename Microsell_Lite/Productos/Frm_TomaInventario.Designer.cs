namespace Microsell_Lite.Productos
{
    partial class Frm_TomaInventario
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
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle3 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_TomaInventario));
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle4 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.txtBuscarProducto = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.elLabel8 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lbl_buscarProd = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.label51 = new System.Windows.Forms.Label();
            this.lblIdProducto = new System.Windows.Forms.Label();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.txtMotivo = new Guna.UI.WinForms.GunaTextBox();
            this.txtObservacion = new Guna.UI.WinForms.GunaTextBox();
            this.dgvDetalle = new Guna.UI.WinForms.GunaDataGridView();
            this.btnBuscar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btnCalcular = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btnAplicarAjuste = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.lbl_tipoCambio = new System.Windows.Forms.Label();
            this.btn_reload = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_buscarProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCalcular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAplicarAjuste)).BeginInit();
            this.pnl_titu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
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
            this.txtBuscarProducto.Location = new System.Drawing.Point(70, 91);
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
            paintStyle3.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle3.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel8.FlashStyle = paintStyle3;
            this.elLabel8.Location = new System.Drawing.Point(58, 87);
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
            this.pictureBox4.Location = new System.Drawing.Point(253, 91);
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
            paintStyle4.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle4.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.lbl_buscarProd.FlashStyle = paintStyle4;
            this.lbl_buscarProd.Location = new System.Drawing.Point(280, 92);
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
            this.label51.Location = new System.Drawing.Point(65, 123);
            this.label51.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(180, 26);
            this.label51.TabIndex = 613;
            this.label51.Text = "Escanee el Codigo Producto";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIdProducto
            // 
            this.lblIdProducto.AutoSize = true;
            this.lblIdProducto.Location = new System.Drawing.Point(702, 134);
            this.lblIdProducto.Name = "lblIdProducto";
            this.lblIdProducto.Size = new System.Drawing.Size(35, 13);
            this.lblIdProducto.TabIndex = 617;
            this.lblIdProducto.Text = "label1";
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.Location = new System.Drawing.Point(702, 87);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(35, 13);
            this.lblNombreProducto.TabIndex = 618;
            this.lblNombreProducto.Text = "label1";
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
            this.txtMotivo.Location = new System.Drawing.Point(111, 203);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.PasswordChar = '\0';
            this.txtMotivo.Radius = 8;
            this.txtMotivo.Size = new System.Drawing.Size(160, 30);
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
            this.txtObservacion.Location = new System.Drawing.Point(401, 203);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.PasswordChar = '\0';
            this.txtObservacion.Radius = 8;
            this.txtObservacion.Size = new System.Drawing.Size(160, 30);
            this.txtObservacion.TabIndex = 620;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetalle.ColumnHeadersHeight = 4;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalle.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetalle.Location = new System.Drawing.Point(31, 253);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(994, 261);
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
            // btnBuscar
            // 
            this.btnBuscar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btnBuscar.BackgroundStyle.SolidColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btnBuscar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btnBuscar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btnBuscar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btnBuscar.BorderStyle.EdgeRadius = 7;
            this.btnBuscar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btnBuscar.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBuscar.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnBuscar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btnBuscar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btnBuscar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBuscar.Location = new System.Drawing.Point(360, 87);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btnBuscar.Size = new System.Drawing.Size(142, 41);
            this.btnBuscar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btnBuscar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btnBuscar.TabIndex = 622;
            this.btnBuscar.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.TextStyle.Text = "Buscar";
            this.btnBuscar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBuscar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
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
            this.btnCalcular.Location = new System.Drawing.Point(270, 537);
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
            this.btnAplicarAjuste.Location = new System.Drawing.Point(551, 537);
            this.btnAplicarAjuste.Margin = new System.Windows.Forms.Padding(4);
            this.btnAplicarAjuste.Name = "btnAplicarAjuste";
            this.btnAplicarAjuste.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btnAplicarAjuste.Size = new System.Drawing.Size(142, 41);
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
            this.label1.Location = new System.Drawing.Point(53, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 625;
            this.label1.Text = "Motivo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(311, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 626;
            this.label2.Text = "Observacion";
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnl_titu.Controls.Add(this.label20);
            this.pnl_titu.Controls.Add(this.lbl_tipoCambio);
            this.pnl_titu.Controls.Add(this.btn_reload);
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Controls.Add(this.label3);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(1048, 43);
            this.pnl_titu.TabIndex = 627;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Encode Sans Condensed SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(486, 2);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 20);
            this.label20.TabIndex = 65;
            this.label20.Text = "Tipo de Cambio";
            // 
            // lbl_tipoCambio
            // 
            this.lbl_tipoCambio.AutoSize = true;
            this.lbl_tipoCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tipoCambio.ForeColor = System.Drawing.Color.White;
            this.lbl_tipoCambio.Location = new System.Drawing.Point(507, 22);
            this.lbl_tipoCambio.Name = "lbl_tipoCambio";
            this.lbl_tipoCambio.Size = new System.Drawing.Size(35, 15);
            this.lbl_tipoCambio.TabIndex = 57;
            this.lbl_tipoCambio.Text = "3.31";
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
            this.btn_reload.Location = new System.Drawing.Point(948, 5);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(32, 31);
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
            this.btn_cerrar.Location = new System.Drawing.Point(993, 5);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(32, 32);
            this.btn_cerrar.TabIndex = 10;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Encode Sans Condensed SemiBold", 13F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "Registro de Producto";
            // 
            // Frm_TomaInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1048, 591);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAplicarAjuste);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.lblNombreProducto);
            this.Controls.Add(this.lblIdProducto);
            this.Controls.Add(this.txtBuscarProducto);
            this.Controls.Add(this.elLabel8);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.lbl_buscarProd);
            this.Controls.Add(this.label51);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_TomaInventario";
            this.Text = "Frm_TomaInventario";
            this.Load += new System.EventHandler(this.Frm_TomaInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.elLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_buscarProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCalcular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAplicarAjuste)).EndInit();
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Guna.UI.WinForms.GunaTextBox txtMotivo;
        private System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.Label lblIdProducto;
        internal Bunifu.Framework.UI.BunifuMaterialTextbox txtBuscarProducto;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel8;
        private System.Windows.Forms.PictureBox pictureBox4;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel lbl_buscarProd;
        private System.Windows.Forms.Label label51;
        private Guna.UI.WinForms.GunaDataGridView dgvDetalle;
        private Guna.UI.WinForms.GunaTextBox txtObservacion;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btnAplicarAjuste;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btnCalcular;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lbl_tipoCambio;
        private System.Windows.Forms.Button btn_reload;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label3;
    }
}