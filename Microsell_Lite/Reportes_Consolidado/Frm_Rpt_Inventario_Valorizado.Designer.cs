namespace Microsell_Lite.Reportes_Consolidado
{
    partial class Frm_Rpt_Inventario_Valorizado
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet_Reportes_Consolidado = new Microsell_Lite.Reportes_Consolidado.DataSet_Reportes_Consolidado();
            this.spListarTemporalReportKardexBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_Listar_Temporal_ReportKardexTableAdapter = new Microsell_Lite.Reportes_Consolidado.DataSet_Reportes_ConsolidadoTableAdapters.sp_Listar_Temporal_ReportKardexTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Reportes_Consolidado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spListarTemporalReportKardexBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.spListarTemporalReportKardexBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Microsell_Lite.Reportes_Consolidado.Rpt_Inventario_Valorizado.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 592);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSet_Reportes_Consolidado
            // 
            this.dataSet_Reportes_Consolidado.DataSetName = "DataSet_Reportes_Consolidado";
            this.dataSet_Reportes_Consolidado.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spListarTemporalReportKardexBindingSource
            // 
            this.spListarTemporalReportKardexBindingSource.DataMember = "sp_Listar_Temporal_ReportKardex";
            this.spListarTemporalReportKardexBindingSource.DataSource = this.dataSet_Reportes_Consolidado;
            // 
            // sp_Listar_Temporal_ReportKardexTableAdapter
            // 
            this.sp_Listar_Temporal_ReportKardexTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_Rpt_Inventario_Valorizado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 592);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Rpt_Inventario_Valorizado";
            this.Text = "Frm_Rpt_Inventario_Valorizado";
            this.Load += new System.EventHandler(this.Frm_Rpt_Inventario_Valorizado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Reportes_Consolidado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spListarTemporalReportKardexBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet_Reportes_Consolidado dataSet_Reportes_Consolidado;
        private System.Windows.Forms.BindingSource spListarTemporalReportKardexBindingSource;
        private DataSet_Reportes_ConsolidadoTableAdapters.sp_Listar_Temporal_ReportKardexTableAdapter sp_Listar_Temporal_ReportKardexTableAdapter;
    }
}