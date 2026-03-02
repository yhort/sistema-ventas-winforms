namespace Microsell_Lite.Reportes_Consolidado
{
    partial class Frm_Rpt_TopProd
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Rpt_TopProd));
            this.spProductosmasVendidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet_Reportes_Consolidado = new Microsell_Lite.Reportes_Consolidado.DataSet_Reportes_Consolidado();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Sp_Productos_masVendidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Sp_Productos_masVendidosTableAdapter = new Microsell_Lite.Reportes_Consolidado.DataSet_Reportes_ConsolidadoTableAdapters.Sp_Productos_masVendidosTableAdapter();
            this.btn_hoy = new Guna.UI.WinForms.GunaButton();
            this.btn_lastName = new Guna.UI.WinForms.GunaButton();
            this.btn_month = new Guna.UI.WinForms.GunaButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_aceptar = new Guna.UI.WinForms.GunaButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_end = new Guna.UI.WinForms.GunaDateTimePicker();
            this.dtp_start = new Guna.UI.WinForms.GunaDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_v1 = new System.Windows.Forms.TextBox();
            this.txt_v2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.spProductosmasVendidosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_Reportes_Consolidado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sp_Productos_masVendidosBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spProductosmasVendidosBindingSource
            // 
            this.spProductosmasVendidosBindingSource.DataMember = "Sp_Productos_masVendidos";
            this.spProductosmasVendidosBindingSource.DataSource = this.DataSet_Reportes_Consolidado;
            // 
            // DataSet_Reportes_Consolidado
            // 
            this.DataSet_Reportes_Consolidado.DataSetName = "DataSet_Reportes_Consolidado";
            this.DataSet_Reportes_Consolidado.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.spProductosmasVendidosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Microsell_Lite.Reportes_Consolidado.Rpt_TopProd.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(895, 738);
            this.reportViewer1.TabIndex = 0;
            // 
            // Sp_Productos_masVendidosBindingSource
            // 
            this.Sp_Productos_masVendidosBindingSource.DataMember = "Sp_Productos_masVendidos";
            this.Sp_Productos_masVendidosBindingSource.DataSource = this.DataSet_Reportes_Consolidado;
            // 
            // Sp_Productos_masVendidosTableAdapter
            // 
            this.Sp_Productos_masVendidosTableAdapter.ClearBeforeFill = true;
            // 
            // btn_hoy
            // 
            this.btn_hoy.AnimationHoverSpeed = 0.07F;
            this.btn_hoy.AnimationSpeed = 0.03F;
            this.btn_hoy.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btn_hoy.BorderColor = System.Drawing.Color.Black;
            this.btn_hoy.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_hoy.FocusedColor = System.Drawing.Color.Empty;
            this.btn_hoy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_hoy.ForeColor = System.Drawing.Color.White;
            this.btn_hoy.Image = ((System.Drawing.Image)(resources.GetObject("btn_hoy.Image")));
            this.btn_hoy.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_hoy.Location = new System.Drawing.Point(19, 18);
            this.btn_hoy.Name = "btn_hoy";
            this.btn_hoy.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_hoy.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_hoy.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_hoy.OnHoverImage = null;
            this.btn_hoy.OnPressedColor = System.Drawing.Color.Black;
            this.btn_hoy.Size = new System.Drawing.Size(115, 29);
            this.btn_hoy.TabIndex = 1;
            this.btn_hoy.Text = "btn_hoy";
            this.btn_hoy.Click += new System.EventHandler(this.btn_hoy_Click);
            // 
            // btn_lastName
            // 
            this.btn_lastName.AnimationHoverSpeed = 0.07F;
            this.btn_lastName.AnimationSpeed = 0.03F;
            this.btn_lastName.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btn_lastName.BorderColor = System.Drawing.Color.Black;
            this.btn_lastName.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_lastName.FocusedColor = System.Drawing.Color.Empty;
            this.btn_lastName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_lastName.ForeColor = System.Drawing.Color.White;
            this.btn_lastName.Image = ((System.Drawing.Image)(resources.GetObject("btn_lastName.Image")));
            this.btn_lastName.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_lastName.Location = new System.Drawing.Point(169, 18);
            this.btn_lastName.Name = "btn_lastName";
            this.btn_lastName.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_lastName.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_lastName.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_lastName.OnHoverImage = null;
            this.btn_lastName.OnPressedColor = System.Drawing.Color.Black;
            this.btn_lastName.Size = new System.Drawing.Size(120, 29);
            this.btn_lastName.TabIndex = 2;
            this.btn_lastName.Text = "Ultimos 7 dias";
            // 
            // btn_month
            // 
            this.btn_month.AnimationHoverSpeed = 0.07F;
            this.btn_month.AnimationSpeed = 0.03F;
            this.btn_month.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btn_month.BorderColor = System.Drawing.Color.Black;
            this.btn_month.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_month.FocusedColor = System.Drawing.Color.Empty;
            this.btn_month.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_month.ForeColor = System.Drawing.Color.White;
            this.btn_month.Image = ((System.Drawing.Image)(resources.GetObject("btn_month.Image")));
            this.btn_month.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_month.Location = new System.Drawing.Point(326, 18);
            this.btn_month.Name = "btn_month";
            this.btn_month.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_month.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_month.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_month.OnHoverImage = null;
            this.btn_month.OnPressedColor = System.Drawing.Color.Black;
            this.btn_month.Size = new System.Drawing.Size(119, 29);
            this.btn_month.TabIndex = 3;
            this.btn_month.Text = "El Mes";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_aceptar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtp_end);
            this.panel1.Controls.Add(this.dtp_start);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_month);
            this.panel1.Controls.Add(this.btn_hoy);
            this.panel1.Controls.Add(this.btn_lastName);
            this.panel1.Location = new System.Drawing.Point(820, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(54, 24);
            this.panel1.TabIndex = 4;
            this.panel1.Visible = false;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.AnimationHoverSpeed = 0.07F;
            this.btn_aceptar.AnimationSpeed = 0.03F;
            this.btn_aceptar.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btn_aceptar.BorderColor = System.Drawing.Color.Black;
            this.btn_aceptar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_aceptar.FocusedColor = System.Drawing.Color.Empty;
            this.btn_aceptar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_aceptar.ForeColor = System.Drawing.Color.White;
            this.btn_aceptar.Image = ((System.Drawing.Image)(resources.GetObject("btn_aceptar.Image")));
            this.btn_aceptar.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_aceptar.Location = new System.Drawing.Point(688, 18);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_aceptar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_aceptar.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_aceptar.OnHoverImage = null;
            this.btn_aceptar.OnPressedColor = System.Drawing.Color.Black;
            this.btn_aceptar.Size = new System.Drawing.Size(119, 29);
            this.btn_aceptar.TabIndex = 8;
            this.btn_aceptar.Text = "Consultar";
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(480, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Hasta";
            // 
            // dtp_end
            // 
            this.dtp_end.BaseColor = System.Drawing.Color.White;
            this.dtp_end.BorderColor = System.Drawing.Color.Silver;
            this.dtp_end.CustomFormat = null;
            this.dtp_end.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtp_end.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_end.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_end.ForeColor = System.Drawing.Color.Black;
            this.dtp_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_end.Location = new System.Drawing.Point(541, 39);
            this.dtp_end.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_end.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtp_end.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_end.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_end.OnPressedColor = System.Drawing.Color.Black;
            this.dtp_end.Size = new System.Drawing.Size(119, 30);
            this.dtp_end.TabIndex = 6;
            this.dtp_end.Text = "5/08/2024";
            this.dtp_end.Value = new System.DateTime(2024, 8, 5, 3, 13, 34, 224);
            // 
            // dtp_start
            // 
            this.dtp_start.BaseColor = System.Drawing.Color.White;
            this.dtp_start.BorderColor = System.Drawing.Color.Silver;
            this.dtp_start.CustomFormat = null;
            this.dtp_start.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtp_start.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_start.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_start.ForeColor = System.Drawing.Color.Black;
            this.dtp_start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_start.Location = new System.Drawing.Point(541, 3);
            this.dtp_start.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_start.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtp_start.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_start.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_start.OnPressedColor = System.Drawing.Color.Black;
            this.dtp_start.Size = new System.Drawing.Size(119, 30);
            this.dtp_start.TabIndex = 5;
            this.dtp_start.Text = "5/08/2024";
            this.dtp_start.Value = new System.DateTime(2024, 8, 5, 3, 14, 23, 259);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(480, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Desde";
            // 
            // txt_v1
            // 
            this.txt_v1.Location = new System.Drawing.Point(46, 222);
            this.txt_v1.Name = "txt_v1";
            this.txt_v1.Size = new System.Drawing.Size(100, 20);
            this.txt_v1.TabIndex = 9;
            this.txt_v1.Visible = false;
            // 
            // txt_v2
            // 
            this.txt_v2.Location = new System.Drawing.Point(201, 222);
            this.txt_v2.Name = "txt_v2";
            this.txt_v2.Size = new System.Drawing.Size(100, 20);
            this.txt_v2.TabIndex = 10;
            this.txt_v2.Visible = false;
            // 
            // Frm_Rpt_TopProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 738);
            this.Controls.Add(this.txt_v1);
            this.Controls.Add(this.txt_v2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Rpt_TopProd";
            this.Text = "Frm_Rpt_TopProd";
            this.Load += new System.EventHandler(this.Frm_Rpt_TopProd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spProductosmasVendidosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_Reportes_Consolidado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sp_Productos_masVendidosBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Sp_Productos_masVendidosBindingSource;
        private DataSet_Reportes_Consolidado DataSet_Reportes_Consolidado;
        private DataSet_Reportes_ConsolidadoTableAdapters.Sp_Productos_masVendidosTableAdapter Sp_Productos_masVendidosTableAdapter;
        private System.Windows.Forms.BindingSource spProductosmasVendidosBindingSource;
        private Guna.UI.WinForms.GunaButton btn_hoy;
        private Guna.UI.WinForms.GunaButton btn_lastName;
        private Guna.UI.WinForms.GunaButton btn_month;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaDateTimePicker dtp_end;
        private Guna.UI.WinForms.GunaDateTimePicker dtp_start;
        private Guna.UI.WinForms.GunaButton btn_aceptar;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txt_v2;
        internal System.Windows.Forms.TextBox txt_v1;
    }
}