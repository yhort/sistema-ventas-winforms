namespace Microsell_Lite.Informe
{
    partial class Frm_Print_Cotizacion
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
            this.Vsr_coti = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // Vsr_coti
            // 
            this.Vsr_coti.ActiveViewIndex = -1;
            this.Vsr_coti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Vsr_coti.Cursor = System.Windows.Forms.Cursors.Default;
            this.Vsr_coti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Vsr_coti.Location = new System.Drawing.Point(0, 0);
            this.Vsr_coti.Name = "Vsr_coti";
            this.Vsr_coti.Size = new System.Drawing.Size(800, 450);
            this.Vsr_coti.TabIndex = 0;
            this.Vsr_coti.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Frm_Print_Cotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Vsr_coti);
            this.Name = "Frm_Print_Cotizacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir Cotizacion";
            this.Load += new System.EventHandler(this.Frm_Print_Cotizacion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer Vsr_coti;
    }
}