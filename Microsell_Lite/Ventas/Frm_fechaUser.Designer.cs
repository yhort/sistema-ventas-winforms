namespace Microsell_Lite.Ventas
{
    partial class Frm_fechaUser
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
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titulo = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerar = new Guna.UI.WinForms.GunaButton();
            this.label7 = new System.Windows.Forms.Label();
            this.cbo_usu = new Guna.UI.WinForms.GunaComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpfechaFinal = new Guna.UI.WinForms.GunaDateTimePicker();
            this.dtpfechaInicial = new Guna.UI.WinForms.GunaDateTimePicker();
            this.btn_closed = new Guna.UI.WinForms.GunaButton();
            this.pnl_titulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titulo
            // 
            this.pnl_titulo.BackColor = System.Drawing.Color.SlateBlue;
            this.pnl_titulo.Controls.Add(this.label3);
            this.pnl_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titulo.Location = new System.Drawing.Point(0, 0);
            this.pnl_titulo.Name = "pnl_titulo";
            this.pnl_titulo.Size = new System.Drawing.Size(497, 71);
            this.pnl_titulo.TabIndex = 4;
            
            this.pnl_titulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titulo_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.SlateBlue;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(126, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(265, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Reporte de Ventas x Usuario";
            // 
            // btnGenerar
            // 
            this.btnGenerar.AnimationHoverSpeed = 0.07F;
            this.btnGenerar.AnimationSpeed = 0.03F;
            this.btnGenerar.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerar.BaseColor = System.Drawing.Color.RoyalBlue;
            this.btnGenerar.BorderColor = System.Drawing.Color.Black;
            this.btnGenerar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnGenerar.FocusedColor = System.Drawing.Color.Empty;
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Image = null;
            this.btnGenerar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnGenerar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnGenerar.Location = new System.Drawing.Point(254, 168);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnGenerar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnGenerar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnGenerar.OnHoverImage = null;
            this.btnGenerar.OnPressedColor = System.Drawing.Color.Black;
            this.btnGenerar.Radius = 15;
            this.btnGenerar.Size = new System.Drawing.Size(76, 32);
            this.btnGenerar.TabIndex = 7;
            this.btnGenerar.Text = "Consultar";
            this.btnGenerar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(12, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Usuario Caja";
            // 
            // cbo_usu
            // 
            this.cbo_usu.BackColor = System.Drawing.Color.Transparent;
            this.cbo_usu.BaseColor = System.Drawing.Color.White;
            this.cbo_usu.BorderColor = System.Drawing.Color.Silver;
            this.cbo_usu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_usu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_usu.FocusedColor = System.Drawing.Color.Empty;
            this.cbo_usu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_usu.ForeColor = System.Drawing.Color.Black;
            this.cbo_usu.FormattingEnabled = true;
            this.cbo_usu.Location = new System.Drawing.Point(12, 114);
            this.cbo_usu.Name = "cbo_usu";
            this.cbo_usu.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cbo_usu.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cbo_usu.Radius = 5;
            this.cbo_usu.Size = new System.Drawing.Size(121, 26);
            this.cbo_usu.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(324, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(159, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Desde:";
            // 
            // dtpfechaFinal
            // 
            this.dtpfechaFinal.BackColor = System.Drawing.Color.Transparent;
            this.dtpfechaFinal.BaseColor = System.Drawing.Color.White;
            this.dtpfechaFinal.BorderColor = System.Drawing.Color.Silver;
            this.dtpfechaFinal.CustomFormat = null;
            this.dtpfechaFinal.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpfechaFinal.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpfechaFinal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpfechaFinal.ForeColor = System.Drawing.Color.Black;
            this.dtpfechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechaFinal.Location = new System.Drawing.Point(327, 111);
            this.dtpfechaFinal.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpfechaFinal.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpfechaFinal.Name = "dtpfechaFinal";
            this.dtpfechaFinal.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtpfechaFinal.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpfechaFinal.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpfechaFinal.OnPressedColor = System.Drawing.Color.Black;
            this.dtpfechaFinal.Radius = 5;
            this.dtpfechaFinal.Size = new System.Drawing.Size(148, 30);
            this.dtpfechaFinal.TabIndex = 12;
            this.dtpfechaFinal.Text = "22/05/2024";
            this.dtpfechaFinal.Value = new System.DateTime(2024, 5, 22, 12, 4, 24, 560);
            // 
            // dtpfechaInicial
            // 
            this.dtpfechaInicial.BackColor = System.Drawing.Color.Transparent;
            this.dtpfechaInicial.BaseColor = System.Drawing.Color.White;
            this.dtpfechaInicial.BorderColor = System.Drawing.Color.Silver;
            this.dtpfechaInicial.CustomFormat = null;
            this.dtpfechaInicial.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpfechaInicial.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpfechaInicial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpfechaInicial.ForeColor = System.Drawing.Color.Black;
            this.dtpfechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechaInicial.Location = new System.Drawing.Point(159, 111);
            this.dtpfechaInicial.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpfechaInicial.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpfechaInicial.Name = "dtpfechaInicial";
            this.dtpfechaInicial.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtpfechaInicial.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpfechaInicial.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpfechaInicial.OnPressedColor = System.Drawing.Color.Black;
            this.dtpfechaInicial.Radius = 5;
            this.dtpfechaInicial.Size = new System.Drawing.Size(148, 30);
            this.dtpfechaInicial.TabIndex = 11;
            this.dtpfechaInicial.Text = "22/05/2024";
            this.dtpfechaInicial.Value = new System.DateTime(2024, 5, 22, 12, 4, 24, 560);
            // 
            // btn_closed
            // 
            this.btn_closed.AnimationHoverSpeed = 0.07F;
            this.btn_closed.AnimationSpeed = 0.03F;
            this.btn_closed.BackColor = System.Drawing.Color.Transparent;
            this.btn_closed.BaseColor = System.Drawing.Color.Gray;
            this.btn_closed.BorderColor = System.Drawing.Color.Black;
            this.btn_closed.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_closed.FocusedColor = System.Drawing.Color.Empty;
            this.btn_closed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_closed.ForeColor = System.Drawing.Color.White;
            this.btn_closed.Image = null;
            this.btn_closed.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_closed.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_closed.Location = new System.Drawing.Point(166, 168);
            this.btn_closed.Name = "btn_closed";
            this.btn_closed.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_closed.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_closed.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_closed.OnHoverImage = null;
            this.btn_closed.OnPressedColor = System.Drawing.Color.Black;
            this.btn_closed.Radius = 15;
            this.btn_closed.Size = new System.Drawing.Size(76, 32);
            this.btn_closed.TabIndex = 15;
            this.btn_closed.Text = "Cancelar";
            this.btn_closed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_closed.Click += new System.EventHandler(this.btn_closed_Click);
            // 
            // Frm_fechaUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(497, 229);
            this.Controls.Add(this.btn_closed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpfechaFinal);
            this.Controls.Add(this.dtpfechaInicial);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbo_usu);
            this.Controls.Add(this.pnl_titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_fechaUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_ReporteVentasFecha";
            this.Load += new System.EventHandler(this.Frm_ReporteVentasFecha_Load);
            this.pnl_titulo.ResumeLayout(false);
            this.pnl_titulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titulo;
        private Guna.UI.WinForms.GunaButton btnGenerar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private Guna.UI.WinForms.GunaComboBox cbo_usu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private Guna.UI.WinForms.GunaDateTimePicker dtpfechaFinal;
        private Guna.UI.WinForms.GunaDateTimePicker dtpfechaInicial;
        private Guna.UI.WinForms.GunaButton btn_closed;
    }
}