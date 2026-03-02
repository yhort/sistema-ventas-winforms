namespace Microsell_Lite.Reportes_Consolidado
{
    partial class Frm_Rpt_Ventas
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
            this.spListarDocemitoshoyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet_Reportes_Consolidado = new Microsell_Lite.Reportes_Consolidado.DataSet_Reportes_Consolidado();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Sp_Listar_Doc_emitoshoyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Sp_Listar_Doc_emitoshoyTableAdapter = new Microsell_Lite.Reportes_Consolidado.DataSet_Reportes_ConsolidadoTableAdapters.Sp_Listar_Doc_emitoshoyTableAdapter();
            this.txt_p1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.spListarDocemitoshoyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_Reportes_Consolidado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sp_Listar_Doc_emitoshoyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // spListarDocemitoshoyBindingSource
            // 
            this.spListarDocemitoshoyBindingSource.DataMember = "Sp_Listar_Doc_emitoshoy";
            this.spListarDocemitoshoyBindingSource.DataSource = this.DataSet_Reportes_Consolidado;
            // 
            // DataSet_Reportes_Consolidado
            // 
            this.DataSet_Reportes_Consolidado.DataSetName = "DataSet_Reportes_Consolidado";
            this.DataSet_Reportes_Consolidado.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.spListarDocemitoshoyBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Microsell_Lite.Reportes_Consolidado.Rpte_Mostrar_Ventas_Dia.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(811, 584);
            this.reportViewer1.TabIndex = 0;
            // 
            // Sp_Listar_Doc_emitoshoyBindingSource
            // 
            this.Sp_Listar_Doc_emitoshoyBindingSource.DataMember = "Sp_Listar_Doc_emitoshoy";
            this.Sp_Listar_Doc_emitoshoyBindingSource.DataSource = this.DataSet_Reportes_Consolidado;
            // 
            // Sp_Listar_Doc_emitoshoyTableAdapter
            // 
            this.Sp_Listar_Doc_emitoshoyTableAdapter.ClearBeforeFill = true;
            // 
            // txt_p1
            // 
            this.txt_p1.Location = new System.Drawing.Point(27, 43);
            this.txt_p1.Name = "txt_p1";
            this.txt_p1.Size = new System.Drawing.Size(123, 20);
            this.txt_p1.TabIndex = 1;
            this.txt_p1.Visible = false;
            // 
            // Frm_Rpt_Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 584);
            this.Controls.Add(this.txt_p1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Rpt_Ventas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Rpt_Ventas";
            this.Load += new System.EventHandler(this.Frm_Rpt_Ventas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spListarDocemitoshoyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_Reportes_Consolidado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sp_Listar_Doc_emitoshoyBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Sp_Listar_Doc_emitoshoyBindingSource;
        private DataSet_Reportes_Consolidado DataSet_Reportes_Consolidado;
        private DataSet_Reportes_ConsolidadoTableAdapters.Sp_Listar_Doc_emitoshoyTableAdapter Sp_Listar_Doc_emitoshoyTableAdapter;
        private System.Windows.Forms.BindingSource spListarDocemitoshoyBindingSource;
        internal System.Windows.Forms.TextBox txt_p1;
    }
}