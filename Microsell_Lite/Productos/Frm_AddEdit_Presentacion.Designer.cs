namespace Microsell_Lite.Productos
{
    partial class Frm_AddEdit_Presentacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AddEdit_Presentacion));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_reload = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIdProducto = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.btnGuardar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_cancel = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkActivo = new Guna.UI.WinForms.GunaCheckBox();
            this.chkPermiteVenta = new Guna.UI.WinForms.GunaCheckBox();
            this.chkPermiteCompra = new Guna.UI.WinForms.GunaCheckBox();
            this.chkEsBase = new Guna.UI.WinForms.GunaCheckBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.txtNombrePresentacion = new Guna.UI.WinForms.GunaTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtAbreviatura = new Guna.UI.WinForms.GunaTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnl_add = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.lblEquivalenciaInfo = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.cboAbreviatura = new Guna.UI.WinForms.GunaComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCantMinMayorista = new Guna.UI.WinForms.GunaTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrecioMayorista = new Guna.UI.WinForms.GunaTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrecioMinorista = new Guna.UI.WinForms.GunaTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrecioCompra = new Guna.UI.WinForms.GunaTextBox();
            this.txtEquivalencia = new Guna.UI.WinForms.GunaTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
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
            this.pnl_titu.BackColor = System.Drawing.Color.SteelBlue;
            this.pnl_titu.Controls.Add(this.btn_reload);
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Controls.Add(this.lblTitulo);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(707, 43);
            this.pnl_titu.TabIndex = 1;
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
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
            this.btn_reload.Location = new System.Drawing.Point(607, 5);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(32, 31);
            this.btn_reload.TabIndex = 56;
            this.btn_reload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btn_reload, "Volver a cargar datos");
            this.btn_reload.UseVisualStyleBackColor = true;
            this.btn_reload.Click += new System.EventHandler(this.btn_reload_Click);
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
            this.btn_cerrar.Location = new System.Drawing.Point(652, 5);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(32, 32);
            this.btn_cerrar.TabIndex = 10;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Encode Sans Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(220, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(17, 25);
            this.lblTitulo.TabIndex = 118;
            this.lblTitulo.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Encode Sans Condensed SemiBold", 13F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Producto Presentacion";
            // 
            // lblIdProducto
            // 
            this.lblIdProducto.AutoSize = true;
            this.lblIdProducto.Font = new System.Drawing.Font("Encode Sans Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdProducto.Location = new System.Drawing.Point(303, 19);
            this.lblIdProducto.Name = "lblIdProducto";
            this.lblIdProducto.Size = new System.Drawing.Size(17, 25);
            this.lblIdProducto.TabIndex = 95;
            this.lblIdProducto.Text = "-";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Encode Sans Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.Location = new System.Drawing.Point(439, 19);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(17, 25);
            this.lblProducto.TabIndex = 97;
            this.lblProducto.Text = "-";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btnGuardar.BackgroundStyle.SolidColor = System.Drawing.Color.DodgerBlue;
            this.btnGuardar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btnGuardar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btnGuardar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btnGuardar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btnGuardar.BorderStyle.EdgeRadius = 7;
            this.btnGuardar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btnGuardar.BorderStyle.SolidColor = System.Drawing.Color.DodgerBlue;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGuardar.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnGuardar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btnGuardar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btnGuardar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGuardar.Location = new System.Drawing.Point(197, 451);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btnGuardar.Size = new System.Drawing.Size(133, 43);
            this.btnGuardar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btnGuardar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btnGuardar.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnGuardar.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.TextStyle.Font = new System.Drawing.Font("Encode Sans SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.TextStyle.Text = "Guardar";
            this.btnGuardar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGuardar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
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
            this.btn_cancel.Location = new System.Drawing.Point(395, 451);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.btn_cancel.Size = new System.Drawing.Size(144, 43);
            this.btn_cancel.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.DimGray;
            this.btn_cancel.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.DimGray;
            this.btn_cancel.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.StateStyles.HoverStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_cancel.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_cancel.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_cancel.StateStyles.PressedStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.TextStyle.Font = new System.Drawing.Font("Encode Sans SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.btn_cancel.TextStyle.ForeColor = System.Drawing.Color.DimGray;
            this.btn_cancel.TextStyle.Text = "Cancelar";
            this.btn_cancel.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancel.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Encode Sans Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nombre Presentacion";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.DodgerBlue;
            this.label9.Dock = System.Windows.Forms.DockStyle.Right;
            this.label9.Location = new System.Drawing.Point(704, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(3, 528);
            this.label9.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.DodgerBlue;
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Location = new System.Drawing.Point(0, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(3, 528);
            this.label10.TabIndex = 21;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // chkActivo
            // 
            this.chkActivo.BackColor = System.Drawing.Color.AliceBlue;
            this.chkActivo.BaseColor = System.Drawing.Color.White;
            this.chkActivo.CheckedOffColor = System.Drawing.Color.Gray;
            this.chkActivo.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.chkActivo.FillColor = System.Drawing.Color.White;
            this.chkActivo.Font = new System.Drawing.Font("Encode Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActivo.Location = new System.Drawing.Point(506, 404);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(20, 20);
            this.chkActivo.TabIndex = 89;
            this.toolTip1.SetToolTip(this.chkActivo, "Si está marcado el sistema llevará el control de inventario para este producto.");
            this.chkActivo.CheckedChanged += new System.EventHandler(this.chkControlarStock_CheckedChanged);
            // 
            // chkPermiteVenta
            // 
            this.chkPermiteVenta.BackColor = System.Drawing.Color.AliceBlue;
            this.chkPermiteVenta.BaseColor = System.Drawing.Color.White;
            this.chkPermiteVenta.CheckedOffColor = System.Drawing.Color.Gray;
            this.chkPermiteVenta.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.chkPermiteVenta.FillColor = System.Drawing.Color.White;
            this.chkPermiteVenta.Font = new System.Drawing.Font("Encode Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPermiteVenta.Location = new System.Drawing.Point(177, 404);
            this.chkPermiteVenta.Name = "chkPermiteVenta";
            this.chkPermiteVenta.Size = new System.Drawing.Size(20, 20);
            this.chkPermiteVenta.TabIndex = 105;
            this.toolTip1.SetToolTip(this.chkPermiteVenta, "Si está marcado el sistema llevará el control de inventario para este producto.");
            // 
            // chkPermiteCompra
            // 
            this.chkPermiteCompra.BackColor = System.Drawing.Color.AliceBlue;
            this.chkPermiteCompra.BaseColor = System.Drawing.Color.White;
            this.chkPermiteCompra.CheckedOffColor = System.Drawing.Color.Gray;
            this.chkPermiteCompra.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.chkPermiteCompra.FillColor = System.Drawing.Color.White;
            this.chkPermiteCompra.Font = new System.Drawing.Font("Encode Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPermiteCompra.Location = new System.Drawing.Point(506, 364);
            this.chkPermiteCompra.Name = "chkPermiteCompra";
            this.chkPermiteCompra.Size = new System.Drawing.Size(20, 20);
            this.chkPermiteCompra.TabIndex = 107;
            this.toolTip1.SetToolTip(this.chkPermiteCompra, "Si está marcado el sistema llevará el control de inventario para este producto.");
            // 
            // chkEsBase
            // 
            this.chkEsBase.BackColor = System.Drawing.Color.AliceBlue;
            this.chkEsBase.BaseColor = System.Drawing.Color.White;
            this.chkEsBase.CheckedOffColor = System.Drawing.Color.Gray;
            this.chkEsBase.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.chkEsBase.FillColor = System.Drawing.Color.White;
            this.chkEsBase.Font = new System.Drawing.Font("Encode Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEsBase.Location = new System.Drawing.Point(177, 364);
            this.chkEsBase.Name = "chkEsBase";
            this.chkEsBase.Size = new System.Drawing.Size(20, 20);
            this.chkEsBase.TabIndex = 109;
            this.toolTip1.SetToolTip(this.chkEsBase, "Si está marcado el sistema llevará el control de inventario para este producto.");
            this.chkEsBase.CheckedChanged += new System.EventHandler(this.chkEsBase_CheckedChanged);
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add.FlatAppearance.BorderSize = 0;
            this.btn_add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.Image")));
            this.btn_add.Location = new System.Drawing.Point(633, 43);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(32, 32);
            this.btn_add.TabIndex = 95;
            this.btn_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btn_add, "Agregar");
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_edit.FlatAppearance.BorderSize = 0;
            this.btn_edit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_edit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.ForeColor = System.Drawing.Color.White;
            this.btn_edit.Image = ((System.Drawing.Image)(resources.GetObject("btn_edit.Image")));
            this.btn_edit.Location = new System.Drawing.Point(575, 45);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(32, 29);
            this.btn_edit.TabIndex = 96;
            this.btn_edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btn_edit, "Editar");
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // txtNombrePresentacion
            // 
            this.txtNombrePresentacion.BackColor = System.Drawing.Color.Transparent;
            this.txtNombrePresentacion.BaseColor = System.Drawing.Color.White;
            this.txtNombrePresentacion.BorderColor = System.Drawing.Color.Silver;
            this.txtNombrePresentacion.BorderSize = 1;
            this.txtNombrePresentacion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNombrePresentacion.FocusedBaseColor = System.Drawing.Color.White;
            this.txtNombrePresentacion.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtNombrePresentacion.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNombrePresentacion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombrePresentacion.Location = new System.Drawing.Point(177, 47);
            this.txtNombrePresentacion.Name = "txtNombrePresentacion";
            this.txtNombrePresentacion.PasswordChar = '\0';
            this.txtNombrePresentacion.Radius = 5;
            this.txtNombrePresentacion.Size = new System.Drawing.Size(453, 28);
            this.txtNombrePresentacion.TabIndex = 1;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Encode Sans Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(361, 399);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(49, 25);
            this.label23.TabIndex = 90;
            this.label23.Text = "Activo";
            // 
            // txtAbreviatura
            // 
            this.txtAbreviatura.BackColor = System.Drawing.Color.Transparent;
            this.txtAbreviatura.BaseColor = System.Drawing.Color.White;
            this.txtAbreviatura.BorderColor = System.Drawing.Color.Silver;
            this.txtAbreviatura.BorderSize = 1;
            this.txtAbreviatura.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAbreviatura.FocusedBaseColor = System.Drawing.Color.White;
            this.txtAbreviatura.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtAbreviatura.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtAbreviatura.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbreviatura.Location = new System.Drawing.Point(201, 129);
            this.txtAbreviatura.Name = "txtAbreviatura";
            this.txtAbreviatura.PasswordChar = '\0';
            this.txtAbreviatura.Radius = 5;
            this.txtAbreviatura.Size = new System.Drawing.Size(50, 28);
            this.txtAbreviatura.TabIndex = 92;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Encode Sans Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 25);
            this.label4.TabIndex = 93;
            this.label4.Text = "Abreviatura";
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
            this.pnl_add.Controls.Add(this.lblProducto);
            this.pnl_add.Controls.Add(this.lblIdProducto);
            this.pnl_add.Controls.Add(this.lblEquivalenciaInfo);
            this.pnl_add.Controls.Add(this.label14);
            this.pnl_add.Controls.Add(this.label18);
            this.pnl_add.Controls.Add(this.bunifuSeparator1);
            this.pnl_add.Controls.Add(this.bunifuSeparator2);
            this.pnl_add.Controls.Add(this.cboAbreviatura);
            this.pnl_add.Controls.Add(this.label13);
            this.pnl_add.Controls.Add(this.chkEsBase);
            this.pnl_add.Controls.Add(this.label12);
            this.pnl_add.Controls.Add(this.chkPermiteCompra);
            this.pnl_add.Controls.Add(this.label11);
            this.pnl_add.Controls.Add(this.chkPermiteVenta);
            this.pnl_add.Controls.Add(this.label8);
            this.pnl_add.Controls.Add(this.txtCantMinMayorista);
            this.pnl_add.Controls.Add(this.label7);
            this.pnl_add.Controls.Add(this.txtPrecioMayorista);
            this.pnl_add.Controls.Add(this.label6);
            this.pnl_add.Controls.Add(this.txtPrecioMinorista);
            this.pnl_add.Controls.Add(this.label5);
            this.pnl_add.Controls.Add(this.txtPrecioCompra);
            this.pnl_add.Controls.Add(this.txtEquivalencia);
            this.pnl_add.Controls.Add(this.label2);
            this.pnl_add.Controls.Add(this.txtNombrePresentacion);
            this.pnl_add.Controls.Add(this.txtAbreviatura);
            this.pnl_add.Controls.Add(this.label23);
            this.pnl_add.Controls.Add(this.label3);
            this.pnl_add.Controls.Add(this.chkActivo);
            this.pnl_add.Controls.Add(this.label4);
            this.pnl_add.Controls.Add(this.btnGuardar);
            this.pnl_add.Controls.Add(this.btn_cancel);
            this.pnl_add.Location = new System.Drawing.Point(9, 45);
            this.pnl_add.Name = "pnl_add";
            this.pnl_add.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnl_add.Size = new System.Drawing.Size(675, 514);
            this.pnl_add.TabIndex = 94;
            this.pnl_add.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // lblEquivalenciaInfo
            // 
            this.lblEquivalenciaInfo.AutoSize = true;
            this.lblEquivalenciaInfo.Font = new System.Drawing.Font("Encode Sans Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquivalenciaInfo.Location = new System.Drawing.Point(561, 126);
            this.lblEquivalenciaInfo.Name = "lblEquivalenciaInfo";
            this.lblEquivalenciaInfo.Size = new System.Drawing.Size(17, 25);
            this.lblEquivalenciaInfo.TabIndex = 117;
            this.lblEquivalenciaInfo.Text = "-";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("Encode Sans Condensed SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.SteelBlue;
            this.label14.Location = new System.Drawing.Point(196, 312);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(280, 30);
            this.label14.TabIndex = 116;
            this.label14.Text = "Configuración";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.Font = new System.Drawing.Font("Encode Sans Condensed SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.SteelBlue;
            this.label18.Location = new System.Drawing.Point(196, 159);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(280, 23);
            this.label18.TabIndex = 115;
            this.label18.Text = "Precios";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.ForeColor = System.Drawing.Color.Gray;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(41, 163);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(590, 19);
            this.bunifuSeparator1.TabIndex = 114;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.ForeColor = System.Drawing.Color.Gray;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(41, 316);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(590, 19);
            this.bunifuSeparator2.TabIndex = 113;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // cboAbreviatura
            // 
            this.cboAbreviatura.BackColor = System.Drawing.Color.Transparent;
            this.cboAbreviatura.BaseColor = System.Drawing.Color.White;
            this.cboAbreviatura.BorderColor = System.Drawing.Color.Silver;
            this.cboAbreviatura.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboAbreviatura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAbreviatura.FocusedColor = System.Drawing.Color.Empty;
            this.cboAbreviatura.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboAbreviatura.ForeColor = System.Drawing.Color.Black;
            this.cboAbreviatura.FormattingEnabled = true;
            this.cboAbreviatura.Location = new System.Drawing.Point(177, 95);
            this.cboAbreviatura.Name = "cboAbreviatura";
            this.cboAbreviatura.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cboAbreviatura.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cboAbreviatura.Radius = 8;
            this.cboAbreviatura.Size = new System.Drawing.Size(124, 26);
            this.cboAbreviatura.TabIndex = 112;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Encode Sans Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(33, 359);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 25);
            this.label13.TabIndex = 110;
            this.label13.Text = "Es unidad base";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Encode Sans Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(351, 359);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 25);
            this.label12.TabIndex = 108;
            this.label12.Text = "Permite Compra";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Encode Sans Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(36, 399);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 25);
            this.label11.TabIndex = 106;
            this.label11.Text = "PermiteVenta";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Encode Sans Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(350, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 25);
            this.label8.TabIndex = 104;
            this.label8.Text = "Cantidad Min.Mayorista";
            // 
            // txtCantMinMayorista
            // 
            this.txtCantMinMayorista.BackColor = System.Drawing.Color.Transparent;
            this.txtCantMinMayorista.BaseColor = System.Drawing.Color.White;
            this.txtCantMinMayorista.BorderColor = System.Drawing.Color.Silver;
            this.txtCantMinMayorista.BorderSize = 1;
            this.txtCantMinMayorista.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCantMinMayorista.FocusedBaseColor = System.Drawing.Color.White;
            this.txtCantMinMayorista.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtCantMinMayorista.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCantMinMayorista.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantMinMayorista.Location = new System.Drawing.Point(506, 250);
            this.txtCantMinMayorista.Name = "txtCantMinMayorista";
            this.txtCantMinMayorista.PasswordChar = '\0';
            this.txtCantMinMayorista.Radius = 5;
            this.txtCantMinMayorista.Size = new System.Drawing.Size(124, 28);
            this.txtCantMinMayorista.TabIndex = 103;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Encode Sans Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 25);
            this.label7.TabIndex = 102;
            this.label7.Text = "Precio Mayorista";
            // 
            // txtPrecioMayorista
            // 
            this.txtPrecioMayorista.BackColor = System.Drawing.Color.Transparent;
            this.txtPrecioMayorista.BaseColor = System.Drawing.Color.White;
            this.txtPrecioMayorista.BorderColor = System.Drawing.Color.Silver;
            this.txtPrecioMayorista.BorderSize = 1;
            this.txtPrecioMayorista.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrecioMayorista.FocusedBaseColor = System.Drawing.Color.White;
            this.txtPrecioMayorista.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtPrecioMayorista.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPrecioMayorista.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioMayorista.Location = new System.Drawing.Point(177, 250);
            this.txtPrecioMayorista.Name = "txtPrecioMayorista";
            this.txtPrecioMayorista.PasswordChar = '\0';
            this.txtPrecioMayorista.Radius = 5;
            this.txtPrecioMayorista.Size = new System.Drawing.Size(124, 28);
            this.txtPrecioMayorista.TabIndex = 101;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Encode Sans Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(350, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 25);
            this.label6.TabIndex = 100;
            this.label6.Text = "Precio Minorista";
            // 
            // txtPrecioMinorista
            // 
            this.txtPrecioMinorista.BackColor = System.Drawing.Color.Transparent;
            this.txtPrecioMinorista.BaseColor = System.Drawing.Color.White;
            this.txtPrecioMinorista.BorderColor = System.Drawing.Color.Silver;
            this.txtPrecioMinorista.BorderSize = 1;
            this.txtPrecioMinorista.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrecioMinorista.FocusedBaseColor = System.Drawing.Color.White;
            this.txtPrecioMinorista.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtPrecioMinorista.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPrecioMinorista.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioMinorista.Location = new System.Drawing.Point(506, 204);
            this.txtPrecioMinorista.Name = "txtPrecioMinorista";
            this.txtPrecioMinorista.PasswordChar = '\0';
            this.txtPrecioMinorista.Radius = 5;
            this.txtPrecioMinorista.Size = new System.Drawing.Size(124, 28);
            this.txtPrecioMinorista.TabIndex = 99;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Encode Sans Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 25);
            this.label5.TabIndex = 98;
            this.label5.Text = "Precio Compra";
            // 
            // txtPrecioCompra
            // 
            this.txtPrecioCompra.BackColor = System.Drawing.Color.Transparent;
            this.txtPrecioCompra.BaseColor = System.Drawing.Color.White;
            this.txtPrecioCompra.BorderColor = System.Drawing.Color.Silver;
            this.txtPrecioCompra.BorderSize = 1;
            this.txtPrecioCompra.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrecioCompra.FocusedBaseColor = System.Drawing.Color.White;
            this.txtPrecioCompra.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtPrecioCompra.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPrecioCompra.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioCompra.Location = new System.Drawing.Point(177, 204);
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.PasswordChar = '\0';
            this.txtPrecioCompra.Radius = 5;
            this.txtPrecioCompra.Size = new System.Drawing.Size(124, 28);
            this.txtPrecioCompra.TabIndex = 97;
            // 
            // txtEquivalencia
            // 
            this.txtEquivalencia.BackColor = System.Drawing.Color.Transparent;
            this.txtEquivalencia.BaseColor = System.Drawing.Color.White;
            this.txtEquivalencia.BorderColor = System.Drawing.Color.Silver;
            this.txtEquivalencia.BorderSize = 1;
            this.txtEquivalencia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEquivalencia.FocusedBaseColor = System.Drawing.Color.White;
            this.txtEquivalencia.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtEquivalencia.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtEquivalencia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquivalencia.Location = new System.Drawing.Point(506, 95);
            this.txtEquivalencia.Name = "txtEquivalencia";
            this.txtEquivalencia.PasswordChar = '\0';
            this.txtEquivalencia.Radius = 5;
            this.txtEquivalencia.Size = new System.Drawing.Size(124, 28);
            this.txtEquivalencia.TabIndex = 95;
            this.txtEquivalencia.TextChanged += new System.EventHandler(this.txtEquivalencia_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Encode Sans Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(350, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 25);
            this.label2.TabIndex = 96;
            this.label2.Text = "Equivalencia";
            // 
            // Frm_AddEdit_Presentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(707, 571);
            this.Controls.Add(this.pnl_add);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_edit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_AddEdit_Presentacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Reg_Prod";
            this.Load += new System.EventHandler(this.Frm_AddEdit_Presentacion_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
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
        private System.Windows.Forms.Label label3;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btnGuardar;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_cancel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_reload;
        private System.Windows.Forms.ToolTip toolTip1;
        private Guna.UI.WinForms.GunaTextBox txtNombrePresentacion;
        private Guna.UI.WinForms.GunaCheckBox chkActivo;
        private System.Windows.Forms.Label label23;
        private Guna.UI.WinForms.GunaTextBox txtAbreviatura;
        private System.Windows.Forms.Label label4;
        internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox pnl_add;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label lblIdProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label label6;
        private Guna.UI.WinForms.GunaTextBox txtPrecioMinorista;
        private System.Windows.Forms.Label label5;
        private Guna.UI.WinForms.GunaTextBox txtPrecioCompra;
        private Guna.UI.WinForms.GunaTextBox txtEquivalencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private Guna.UI.WinForms.GunaCheckBox chkPermiteVenta;
        private System.Windows.Forms.Label label8;
        private Guna.UI.WinForms.GunaTextBox txtCantMinMayorista;
        private System.Windows.Forms.Label label7;
        private Guna.UI.WinForms.GunaTextBox txtPrecioMayorista;
        private System.Windows.Forms.Label label13;
        private Guna.UI.WinForms.GunaCheckBox chkEsBase;
        private System.Windows.Forms.Label label12;
        private Guna.UI.WinForms.GunaCheckBox chkPermiteCompra;
        private Guna.UI.WinForms.GunaComboBox cboAbreviatura;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblEquivalenciaInfo;
        private System.Windows.Forms.Label lblTitulo;
    }
}