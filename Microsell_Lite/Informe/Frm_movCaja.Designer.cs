namespace Microsell_Lite.Informe
{
    partial class Frm_movCaja
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
            this.crvData = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btn_cargar = new System.Windows.Forms.Button();
            this.dtp_fechaIn = new Guna.UI.WinForms.GunaDateTimePicker();
            this.SuspendLayout();
            // 
            // crvData
            // 
            this.crvData.ActiveViewIndex = -1;
            this.crvData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvData.Location = new System.Drawing.Point(12, 65);
            this.crvData.Name = "crvData";
            this.crvData.Size = new System.Drawing.Size(870, 483);
            this.crvData.TabIndex = 0;
            // 
            // btn_cargar
            // 
            this.btn_cargar.Location = new System.Drawing.Point(315, 19);
            this.btn_cargar.Name = "btn_cargar";
            this.btn_cargar.Size = new System.Drawing.Size(75, 23);
            this.btn_cargar.TabIndex = 1;
            this.btn_cargar.Text = "button1";
            this.btn_cargar.UseVisualStyleBackColor = true;
            this.btn_cargar.Click += new System.EventHandler(this.btn_cargar_Click);
            // 
            // dtp_fechaIn
            // 
            this.dtp_fechaIn.BaseColor = System.Drawing.Color.White;
            this.dtp_fechaIn.BorderColor = System.Drawing.Color.Silver;
            this.dtp_fechaIn.CustomFormat = null;
            this.dtp_fechaIn.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtp_fechaIn.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_fechaIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_fechaIn.ForeColor = System.Drawing.Color.Black;
            this.dtp_fechaIn.Location = new System.Drawing.Point(12, 12);
            this.dtp_fechaIn.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_fechaIn.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_fechaIn.Name = "dtp_fechaIn";
            this.dtp_fechaIn.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtp_fechaIn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_fechaIn.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_fechaIn.OnPressedColor = System.Drawing.Color.Black;
            this.dtp_fechaIn.Size = new System.Drawing.Size(137, 30);
            this.dtp_fechaIn.TabIndex = 2;
            this.dtp_fechaIn.Text = "jueves, 18 de julio de 2024";
            this.dtp_fechaIn.Value = new System.DateTime(2024, 7, 18, 22, 13, 25, 334);
            // 
            // Frm_movCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 560);
            this.Controls.Add(this.dtp_fechaIn);
            this.Controls.Add(this.btn_cargar);
            this.Controls.Add(this.crvData);
            this.Name = "Frm_movCaja";
            this.Text = "Frm_movCaja";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvData;
        private System.Windows.Forms.Button btn_cargar;
        private Guna.UI.WinForms.GunaDateTimePicker dtp_fechaIn;
    }
}