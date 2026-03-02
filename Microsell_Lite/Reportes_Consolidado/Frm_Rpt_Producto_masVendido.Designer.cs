namespace Microsell_Lite.Reportes_Consolidado
{
    partial class Frm_Rpt_Producto_masVendido
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_aceptar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.dtp_end = new Guna.UI.WinForms.GunaDateTimePicker();
            this.dtp_start = new Guna.UI.WinForms.GunaDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.btn_aceptar)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 501;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 500;
            this.label1.Text = "Desde";
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_aceptar.BackgroundStyle.SolidColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_aceptar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_aceptar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_aceptar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_aceptar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_aceptar.BorderStyle.EdgeRadius = 7;
            this.btn_aceptar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_aceptar.BorderStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.btn_aceptar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_aceptar.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_aceptar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_aceptar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_aceptar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_aceptar.Location = new System.Drawing.Point(215, 42);
            this.btn_aceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_aceptar.Size = new System.Drawing.Size(113, 29);
            this.btn_aceptar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_aceptar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_aceptar.TabIndex = 499;
            this.btn_aceptar.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aceptar.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_aceptar.TextStyle.Text = "Aplicar";
            this.btn_aceptar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_aceptar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
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
            this.dtp_end.Location = new System.Drawing.Point(76, 60);
            this.dtp_end.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_end.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtp_end.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_end.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_end.OnPressedColor = System.Drawing.Color.Black;
            this.dtp_end.Size = new System.Drawing.Size(117, 30);
            this.dtp_end.TabIndex = 498;
            this.dtp_end.Text = "5/08/2024";
            this.dtp_end.Value = new System.DateTime(2024, 8, 5, 1, 24, 24, 381);
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
            this.dtp_start.Location = new System.Drawing.Point(76, 25);
            this.dtp_start.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_start.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtp_start.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_start.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_start.OnPressedColor = System.Drawing.Color.Black;
            this.dtp_start.Size = new System.Drawing.Size(117, 30);
            this.dtp_start.TabIndex = 497;
            this.dtp_start.Text = "5/08/2024";
            this.dtp_start.Value = new System.DateTime(2024, 8, 5, 1, 24, 49, 331);
            // 
            // Frm_Rpt_Producto_masVendido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 224);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.dtp_end);
            this.Controls.Add(this.dtp_start);
            this.Name = "Frm_Rpt_Producto_masVendido";
            this.Text = "Frm_Rpt_Producto_masVendido";
            ((System.ComponentModel.ISupportInitialize)(this.btn_aceptar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_aceptar;
        private Guna.UI.WinForms.GunaDateTimePicker dtp_end;
        private Guna.UI.WinForms.GunaDateTimePicker dtp_start;
    }
}