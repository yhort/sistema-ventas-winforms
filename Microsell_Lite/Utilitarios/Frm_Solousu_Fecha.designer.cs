namespace Microsell_Lite.Utilitarios
{
    partial class Frm_Solousu_Fecha
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
            this.pnl_titulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.dtp_fecha = new System.Windows.Forms.DateTimePicker();
            this.btn_Generar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_cancelPago = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_usu = new Guna.UI.WinForms.GunaComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnl_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Generar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancelPago)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_titulo
            // 
            this.pnl_titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(192)))));
            this.pnl_titulo.Controls.Add(this.label1);
            this.pnl_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titulo.Location = new System.Drawing.Point(0, 0);
            this.pnl_titulo.Name = "pnl_titulo";
            this.pnl_titulo.Size = new System.Drawing.Size(386, 63);
            this.pnl_titulo.TabIndex = 727;
            this.pnl_titulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titulo_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(129, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Consultas";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 12;
            this.bunifuElipse1.TargetControl = this;
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha.Location = new System.Drawing.Point(83, 169);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(217, 40);
            this.dtp_fecha.TabIndex = 728;
            // 
            // btn_Generar
            // 
            this.btn_Generar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_Generar.BackgroundStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(192)))));
            this.btn_Generar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_Generar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_Generar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_Generar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_Generar.BorderStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(192)))));
            this.btn_Generar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_Generar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_Generar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Generar.Location = new System.Drawing.Point(199, 240);
            this.btn_Generar.Name = "btn_Generar";
            this.btn_Generar.Size = new System.Drawing.Size(134, 39);
            this.btn_Generar.StateStyles.HoverStyle.BackgroundGradientEndColor = System.Drawing.Color.YellowGreen;
            this.btn_Generar.StateStyles.HoverStyle.BackgroundGradientStartColor = System.Drawing.Color.YellowGreen;
            this.btn_Generar.StateStyles.HoverStyle.BackgroundImageFilterColor = System.Drawing.Color.YellowGreen;
            this.btn_Generar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_Generar.StateStyles.HoverStyle.BorderGradientEndColor = System.Drawing.Color.YellowGreen;
            this.btn_Generar.StateStyles.HoverStyle.BorderGradientStartColor = System.Drawing.Color.YellowGreen;
            this.btn_Generar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_Generar.TabIndex = 729;
            this.btn_Generar.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Generar.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_Generar.TextStyle.Text = "Aceptar";
            this.btn_Generar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Generar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_Generar.Click += new System.EventHandler(this.btn_Generar_Click);
            // 
            // btn_cancelPago
            // 
            this.btn_cancelPago.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancelPago.BackgroundStyle.SolidColor = System.Drawing.Color.WhiteSmoke;
            this.btn_cancelPago.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancelPago.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancelPago.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancelPago.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancelPago.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.btn_cancelPago.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancelPago.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_cancelPago.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancelPago.Location = new System.Drawing.Point(40, 240);
            this.btn_cancelPago.Name = "btn_cancelPago";
            this.btn_cancelPago.Size = new System.Drawing.Size(124, 39);
            this.btn_cancelPago.StateStyles.HoverStyle.BackgroundGradientEndColor = System.Drawing.Color.LightGray;
            this.btn_cancelPago.StateStyles.HoverStyle.BackgroundGradientStartColor = System.Drawing.Color.LightGray;
            this.btn_cancelPago.StateStyles.HoverStyle.BackgroundImageFilterColor = System.Drawing.Color.LightGray;
            this.btn_cancelPago.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.LightGray;
            this.btn_cancelPago.StateStyles.HoverStyle.BorderGradientEndColor = System.Drawing.Color.LightGray;
            this.btn_cancelPago.StateStyles.HoverStyle.BorderGradientStartColor = System.Drawing.Color.LightGray;
            this.btn_cancelPago.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.LightGray;
            this.btn_cancelPago.TabIndex = 780;
            this.btn_cancelPago.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelPago.TextStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(192)))));
            this.btn_cancelPago.TextStyle.Text = "Cancelar";
            this.btn_cancelPago.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancelPago.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_cancelPago.Click += new System.EventHandler(this.btn_cancelPago_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(80, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 15);
            this.label2.TabIndex = 784;
            this.label2.Text = "Elige un Usuario";
            // 
            // cbo_usu
            // 
            this.cbo_usu.BackColor = System.Drawing.Color.Transparent;
            this.cbo_usu.BaseColor = System.Drawing.Color.White;
            this.cbo_usu.BorderColor = System.Drawing.Color.Silver;
            this.cbo_usu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_usu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_usu.FocusedColor = System.Drawing.Color.Empty;
            this.cbo_usu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_usu.ForeColor = System.Drawing.Color.Black;
            this.cbo_usu.FormattingEnabled = true;
            this.cbo_usu.Location = new System.Drawing.Point(83, 104);
            this.cbo_usu.Name = "cbo_usu";
            this.cbo_usu.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cbo_usu.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cbo_usu.Radius = 5;
            this.cbo_usu.Size = new System.Drawing.Size(217, 30);
            this.cbo_usu.TabIndex = 783;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(80, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 15);
            this.label3.TabIndex = 785;
            this.label3.Text = "Elige un Mes y Año";
            // 
            // Frm_Solousu_Fecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(386, 315);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbo_usu);
            this.Controls.Add(this.btn_cancelPago);
            this.Controls.Add(this.btn_Generar);
            this.Controls.Add(this.dtp_fecha);
            this.Controls.Add(this.pnl_titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Solousu_Fecha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solo Fecha";
            this.Load += new System.EventHandler(this.Frm_Solousu_Fecha_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_SoloFecha_KeyDown);
            this.pnl_titulo.ResumeLayout(false);
            this.pnl_titulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Generar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancelPago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_titulo;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_Generar;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_cancelPago;
        internal System.Windows.Forms.DateTimePicker dtp_fecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        internal Guna.UI.WinForms.GunaComboBox cbo_usu;
    }
}