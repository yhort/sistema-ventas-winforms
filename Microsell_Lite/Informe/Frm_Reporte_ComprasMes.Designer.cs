namespace Microsell_Lite.Informe
{
    partial class Frm_Reporte_ComprasMes
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
            this.vsr_CompMes = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // vsr_CompMes
            // 
            this.vsr_CompMes.ActiveViewIndex = -1;
            this.vsr_CompMes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vsr_CompMes.Cursor = System.Windows.Forms.Cursors.Default;
            this.vsr_CompMes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsr_CompMes.Location = new System.Drawing.Point(0, 0);
            this.vsr_CompMes.Name = "vsr_CompMes";
            this.vsr_CompMes.Size = new System.Drawing.Size(800, 450);
            this.vsr_CompMes.TabIndex = 0;
            this.vsr_CompMes.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Frm_Reporte_ComprasMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.vsr_CompMes);
            this.Name = "Frm_Reporte_ComprasMes";
            this.Text = "Frm_Reporte_ComprasMes";
            this.Load += new System.EventHandler(this.Frm_Reporte_ComprasMes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer vsr_CompMes;
    }
}