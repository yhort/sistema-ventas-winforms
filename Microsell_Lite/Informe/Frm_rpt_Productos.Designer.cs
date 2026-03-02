namespace Microsell_Lite.Informe
{
    partial class Frm_rpt_Productos
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
            this.todoprBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DS_Reportes = new Microsell_Lite.Informe.DS_Reportes();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.todo_prBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txt_valor = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.todoprBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_Reportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.todo_prBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // todoprBindingSource
            // 
            this.todoprBindingSource.DataMember = "todo_pr";
            this.todoprBindingSource.DataSource = this.DS_Reportes;
            // 
            // DS_Reportes
            // 
            this.DS_Reportes.DataSetName = "DS_Reportes";
            this.DS_Reportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.todoprBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Microsell_Lite.Informe.rpt_tod_prod.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(872, 580);
            this.reportViewer1.TabIndex = 0;
            // 
            // todo_prBindingSource
            // 
            this.todo_prBindingSource.DataMember = "todo_pr";
            this.todo_prBindingSource.DataSource = this.DS_Reportes;
            // 
            // txt_valor
            // 
            this.txt_valor.Location = new System.Drawing.Point(25, 93);
            this.txt_valor.Name = "txt_valor";
            this.txt_valor.Size = new System.Drawing.Size(100, 20);
            this.txt_valor.TabIndex = 1;
            this.txt_valor.Visible = false;
            // 
            // Frm_rpt_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 580);
            this.Controls.Add(this.txt_valor);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_rpt_Productos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Productos";
            this.Load += new System.EventHandler(this.Frm_rpt_Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.todoprBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_Reportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.todo_prBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource todo_prBindingSource;
        private DS_Reportes DS_Reportes;
        internal System.Windows.Forms.TextBox txt_valor;
        private System.Windows.Forms.BindingSource todoprBindingSource;
    }
}