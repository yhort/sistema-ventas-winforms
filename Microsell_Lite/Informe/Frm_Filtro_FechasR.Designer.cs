namespace Microsell_Lite.Informe
{
    partial class Frm_Filtro_FechasR
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
            this.dtp_Inicio = new System.Windows.Forms.DateTimePicker();
            this.dtp_Final = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.crv_informe = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // dtp_Inicio
            // 
            this.dtp_Inicio.Location = new System.Drawing.Point(54, 43);
            this.dtp_Inicio.Name = "dtp_Inicio";
            this.dtp_Inicio.Size = new System.Drawing.Size(200, 20);
            this.dtp_Inicio.TabIndex = 0;
            // 
            // dtp_Final
            // 
            this.dtp_Final.Location = new System.Drawing.Point(54, 107);
            this.dtp_Final.Name = "dtp_Final";
            this.dtp_Final.Size = new System.Drawing.Size(200, 20);
            this.dtp_Final.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button1.Location = new System.Drawing.Point(376, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 75);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ejecutar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // crv_informe
            // 
            this.crv_informe.ActiveViewIndex = -1;
            this.crv_informe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crv_informe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv_informe.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv_informe.Location = new System.Drawing.Point(12, 147);
            this.crv_informe.Name = "crv_informe";
            this.crv_informe.ShowCloseButton = false;
            this.crv_informe.ShowGroupTreeButton = false;
            this.crv_informe.ShowLogo = false;
            this.crv_informe.ShowParameterPanelButton = false;
            this.crv_informe.Size = new System.Drawing.Size(584, 265);
            this.crv_informe.TabIndex = 3;
            this.crv_informe.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Frm_Filtro_FechasR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 424);
            this.Controls.Add(this.crv_informe);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtp_Final);
            this.Controls.Add(this.dtp_Inicio);
            this.Name = "Frm_Filtro_FechasR";
            this.Text = "Frm_Filtro_FechasR";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_Inicio;
        private System.Windows.Forms.DateTimePicker dtp_Final;
        private System.Windows.Forms.Button button1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv_informe;
    }
}