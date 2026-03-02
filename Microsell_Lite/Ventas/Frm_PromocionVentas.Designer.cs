namespace Microsell_Lite.Ventas
{
    partial class Frm_PromocionVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PromocionVentas));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_report_resum = new Guna.UI.WinForms.GunaButton();
            this.btnResumen = new Guna.UI.WinForms.GunaButton();
            this.lsv_resumen = new System.Windows.Forms.ListView();
            this.dtpHasta_Resumen = new Guna.UI.WinForms.GunaDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDesde_Resumen = new Guna.UI.WinForms.GunaDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnReporteDet = new Guna.UI.WinForms.GunaButton();
            this.btnDetalle = new Guna.UI.WinForms.GunaButton();
            this.dtpHasta_det = new Guna.UI.WinForms.GunaDateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDesde_Det = new Guna.UI.WinForms.GunaDateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lsv_Detalle = new System.Windows.Forms.ListView();
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_reload = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.pnl_titu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 68);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(895, 472);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_report_resum);
            this.tabPage1.Controls.Add(this.btnResumen);
            this.tabPage1.Controls.Add(this.lsv_resumen);
            this.tabPage1.Controls.Add(this.dtpHasta_Resumen);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dtpDesde_Resumen);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(887, 446);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Resumen";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_report_resum
            // 
            this.btn_report_resum.AnimationHoverSpeed = 0.07F;
            this.btn_report_resum.AnimationSpeed = 0.03F;
            this.btn_report_resum.BackColor = System.Drawing.Color.Transparent;
            this.btn_report_resum.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btn_report_resum.BorderColor = System.Drawing.Color.Black;
            this.btn_report_resum.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_report_resum.FocusedColor = System.Drawing.Color.Empty;
            this.btn_report_resum.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_report_resum.ForeColor = System.Drawing.Color.White;
            this.btn_report_resum.Image = null;
            this.btn_report_resum.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_report_resum.Location = new System.Drawing.Point(22, 402);
            this.btn_report_resum.Name = "btn_report_resum";
            this.btn_report_resum.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_report_resum.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_report_resum.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_report_resum.OnHoverImage = null;
            this.btn_report_resum.OnPressedColor = System.Drawing.Color.Black;
            this.btn_report_resum.Radius = 12;
            this.btn_report_resum.Size = new System.Drawing.Size(123, 34);
            this.btn_report_resum.TabIndex = 21;
            this.btn_report_resum.Text = "Generar Reporte";
            this.btn_report_resum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_report_resum.Click += new System.EventHandler(this.btn_report_resum_Click);
            // 
            // btnResumen
            // 
            this.btnResumen.AnimationHoverSpeed = 0.07F;
            this.btnResumen.AnimationSpeed = 0.03F;
            this.btnResumen.BackColor = System.Drawing.Color.Transparent;
            this.btnResumen.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnResumen.BorderColor = System.Drawing.Color.Black;
            this.btnResumen.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnResumen.FocusedColor = System.Drawing.Color.Empty;
            this.btnResumen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnResumen.ForeColor = System.Drawing.Color.White;
            this.btnResumen.Image = null;
            this.btnResumen.ImageSize = new System.Drawing.Size(20, 20);
            this.btnResumen.Location = new System.Drawing.Point(435, 17);
            this.btnResumen.Name = "btnResumen";
            this.btnResumen.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnResumen.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnResumen.OnHoverForeColor = System.Drawing.Color.White;
            this.btnResumen.OnHoverImage = null;
            this.btnResumen.OnPressedColor = System.Drawing.Color.Black;
            this.btnResumen.Radius = 12;
            this.btnResumen.Size = new System.Drawing.Size(123, 34);
            this.btnResumen.TabIndex = 14;
            this.btnResumen.Text = "Buscar";
            this.btnResumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnResumen.Click += new System.EventHandler(this.btnResumen_Click);
            // 
            // lsv_resumen
            // 
            this.lsv_resumen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsv_resumen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsv_resumen.HideSelection = false;
            this.lsv_resumen.Location = new System.Drawing.Point(22, 74);
            this.lsv_resumen.Name = "lsv_resumen";
            this.lsv_resumen.Size = new System.Drawing.Size(754, 322);
            this.lsv_resumen.TabIndex = 13;
            this.lsv_resumen.UseCompatibleStateImageBehavior = false;
            this.lsv_resumen.View = System.Windows.Forms.View.Details;
            // 
            // dtpHasta_Resumen
            // 
            this.dtpHasta_Resumen.BackColor = System.Drawing.Color.Transparent;
            this.dtpHasta_Resumen.BaseColor = System.Drawing.Color.White;
            this.dtpHasta_Resumen.BorderColor = System.Drawing.Color.Silver;
            this.dtpHasta_Resumen.BorderSize = 1;
            this.dtpHasta_Resumen.CustomFormat = null;
            this.dtpHasta_Resumen.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpHasta_Resumen.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpHasta_Resumen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHasta_Resumen.ForeColor = System.Drawing.Color.Black;
            this.dtpHasta_Resumen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta_Resumen.Location = new System.Drawing.Point(267, 17);
            this.dtpHasta_Resumen.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpHasta_Resumen.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpHasta_Resumen.Name = "dtpHasta_Resumen";
            this.dtpHasta_Resumen.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtpHasta_Resumen.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpHasta_Resumen.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpHasta_Resumen.OnPressedColor = System.Drawing.Color.Black;
            this.dtpHasta_Resumen.Radius = 8;
            this.dtpHasta_Resumen.Size = new System.Drawing.Size(123, 30);
            this.dtpHasta_Resumen.TabIndex = 3;
            this.dtpHasta_Resumen.Text = "17/05/2025";
            this.dtpHasta_Resumen.Value = new System.DateTime(2025, 5, 17, 10, 46, 55, 313);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(226, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hasta";
            // 
            // dtpDesde_Resumen
            // 
            this.dtpDesde_Resumen.BackColor = System.Drawing.Color.Transparent;
            this.dtpDesde_Resumen.BaseColor = System.Drawing.Color.White;
            this.dtpDesde_Resumen.BorderColor = System.Drawing.Color.Silver;
            this.dtpDesde_Resumen.BorderSize = 1;
            this.dtpDesde_Resumen.CustomFormat = null;
            this.dtpDesde_Resumen.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpDesde_Resumen.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpDesde_Resumen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDesde_Resumen.ForeColor = System.Drawing.Color.Black;
            this.dtpDesde_Resumen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde_Resumen.Location = new System.Drawing.Point(70, 17);
            this.dtpDesde_Resumen.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDesde_Resumen.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDesde_Resumen.Name = "dtpDesde_Resumen";
            this.dtpDesde_Resumen.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtpDesde_Resumen.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpDesde_Resumen.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpDesde_Resumen.OnPressedColor = System.Drawing.Color.Black;
            this.dtpDesde_Resumen.Radius = 8;
            this.dtpDesde_Resumen.Size = new System.Drawing.Size(123, 30);
            this.dtpDesde_Resumen.TabIndex = 1;
            this.dtpDesde_Resumen.Text = "17/05/2025";
            this.dtpDesde_Resumen.Value = new System.DateTime(2025, 5, 17, 10, 46, 55, 313);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnReporteDet);
            this.tabPage2.Controls.Add(this.btnDetalle);
            this.tabPage2.Controls.Add(this.dtpHasta_det);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.dtpDesde_Det);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.lsv_Detalle);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(887, 446);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnReporteDet
            // 
            this.btnReporteDet.AnimationHoverSpeed = 0.07F;
            this.btnReporteDet.AnimationSpeed = 0.03F;
            this.btnReporteDet.BackColor = System.Drawing.Color.Transparent;
            this.btnReporteDet.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnReporteDet.BorderColor = System.Drawing.Color.Black;
            this.btnReporteDet.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReporteDet.FocusedColor = System.Drawing.Color.Empty;
            this.btnReporteDet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReporteDet.ForeColor = System.Drawing.Color.White;
            this.btnReporteDet.Image = null;
            this.btnReporteDet.ImageSize = new System.Drawing.Size(20, 20);
            this.btnReporteDet.Location = new System.Drawing.Point(14, 401);
            this.btnReporteDet.Name = "btnReporteDet";
            this.btnReporteDet.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnReporteDet.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnReporteDet.OnHoverForeColor = System.Drawing.Color.White;
            this.btnReporteDet.OnHoverImage = null;
            this.btnReporteDet.OnPressedColor = System.Drawing.Color.Black;
            this.btnReporteDet.Radius = 12;
            this.btnReporteDet.Size = new System.Drawing.Size(123, 34);
            this.btnReporteDet.TabIndex = 20;
            this.btnReporteDet.Text = "Generar Reporte";
            this.btnReporteDet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnReporteDet.Click += new System.EventHandler(this.btnReporteDet_Click);
            // 
            // btnDetalle
            // 
            this.btnDetalle.AnimationHoverSpeed = 0.07F;
            this.btnDetalle.AnimationSpeed = 0.03F;
            this.btnDetalle.BackColor = System.Drawing.Color.Transparent;
            this.btnDetalle.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnDetalle.BorderColor = System.Drawing.Color.Black;
            this.btnDetalle.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDetalle.FocusedColor = System.Drawing.Color.Empty;
            this.btnDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDetalle.ForeColor = System.Drawing.Color.White;
            this.btnDetalle.Image = null;
            this.btnDetalle.ImageSize = new System.Drawing.Size(20, 20);
            this.btnDetalle.Location = new System.Drawing.Point(421, 16);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnDetalle.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnDetalle.OnHoverForeColor = System.Drawing.Color.White;
            this.btnDetalle.OnHoverImage = null;
            this.btnDetalle.OnPressedColor = System.Drawing.Color.Black;
            this.btnDetalle.Radius = 12;
            this.btnDetalle.Size = new System.Drawing.Size(123, 34);
            this.btnDetalle.TabIndex = 19;
            this.btnDetalle.Text = "Buscar";
            this.btnDetalle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // dtpHasta_det
            // 
            this.dtpHasta_det.BackColor = System.Drawing.Color.Transparent;
            this.dtpHasta_det.BaseColor = System.Drawing.Color.White;
            this.dtpHasta_det.BorderColor = System.Drawing.Color.Silver;
            this.dtpHasta_det.BorderSize = 1;
            this.dtpHasta_det.CustomFormat = null;
            this.dtpHasta_det.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpHasta_det.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpHasta_det.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHasta_det.ForeColor = System.Drawing.Color.Black;
            this.dtpHasta_det.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta_det.Location = new System.Drawing.Point(270, 16);
            this.dtpHasta_det.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpHasta_det.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpHasta_det.Name = "dtpHasta_det";
            this.dtpHasta_det.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtpHasta_det.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpHasta_det.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpHasta_det.OnPressedColor = System.Drawing.Color.Black;
            this.dtpHasta_det.Radius = 8;
            this.dtpHasta_det.Size = new System.Drawing.Size(123, 30);
            this.dtpHasta_det.TabIndex = 18;
            this.dtpHasta_det.Text = "17/05/2025";
            this.dtpHasta_det.Value = new System.DateTime(2025, 5, 17, 10, 46, 55, 313);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(229, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Hasta";
            // 
            // dtpDesde_Det
            // 
            this.dtpDesde_Det.BackColor = System.Drawing.Color.Transparent;
            this.dtpDesde_Det.BaseColor = System.Drawing.Color.White;
            this.dtpDesde_Det.BorderColor = System.Drawing.Color.Silver;
            this.dtpDesde_Det.BorderSize = 1;
            this.dtpDesde_Det.CustomFormat = null;
            this.dtpDesde_Det.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpDesde_Det.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpDesde_Det.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDesde_Det.ForeColor = System.Drawing.Color.Black;
            this.dtpDesde_Det.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde_Det.Location = new System.Drawing.Point(73, 16);
            this.dtpDesde_Det.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDesde_Det.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDesde_Det.Name = "dtpDesde_Det";
            this.dtpDesde_Det.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtpDesde_Det.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpDesde_Det.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpDesde_Det.OnPressedColor = System.Drawing.Color.Black;
            this.dtpDesde_Det.Radius = 8;
            this.dtpDesde_Det.Size = new System.Drawing.Size(123, 30);
            this.dtpDesde_Det.TabIndex = 16;
            this.dtpDesde_Det.Text = "17/05/2025";
            this.dtpDesde_Det.Value = new System.DateTime(2025, 5, 17, 10, 46, 55, 313);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Desde";
            // 
            // lsv_Detalle
            // 
            this.lsv_Detalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsv_Detalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsv_Detalle.HideSelection = false;
            this.lsv_Detalle.Location = new System.Drawing.Point(14, 67);
            this.lsv_Detalle.Name = "lsv_Detalle";
            this.lsv_Detalle.Size = new System.Drawing.Size(859, 318);
            this.lsv_Detalle.TabIndex = 14;
            this.lsv_Detalle.UseCompatibleStateImageBehavior = false;
            this.lsv_Detalle.View = System.Windows.Forms.View.Details;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.pnl_titu.Controls.Add(this.btn_reload);
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Controls.Add(this.label9);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(919, 44);
            this.pnl_titu.TabIndex = 616;
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
            this.btn_reload.Location = new System.Drawing.Point(832, 5);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(32, 32);
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
            this.btn_cerrar.Location = new System.Drawing.Point(875, 6);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(32, 32);
            this.btn_cerrar.TabIndex = 6;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Location = new System.Drawing.Point(16, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(183, 25);
            this.label9.TabIndex = 0;
            this.label9.Text = "Promociones Ventas";
            // 
            // Frm_PromocionVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 552);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_PromocionVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frm_PromocionVentas";
            this.Load += new System.EventHandler(this.Frm_PromocionVentas_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Guna.UI.WinForms.GunaDateTimePicker dtpHasta_Resumen;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaDateTimePicker dtpDesde_Resumen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lsv_resumen;
        private Guna.UI.WinForms.GunaDateTimePicker dtpHasta_det;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaDateTimePicker dtpDesde_Det;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lsv_Detalle;
        private Guna.UI.WinForms.GunaButton btnResumen;
        private Guna.UI.WinForms.GunaButton btnDetalle;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Button btn_reload;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label9;
        private Guna.UI.WinForms.GunaButton btnReporteDet;
        private Guna.UI.WinForms.GunaButton btn_report_resum;
    }
}