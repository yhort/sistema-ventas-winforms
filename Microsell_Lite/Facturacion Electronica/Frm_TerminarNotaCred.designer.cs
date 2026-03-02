namespace Microsell_Lite.Facturacion_Electronica
{
    partial class Frm_TerminarNotaCred
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
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle3 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle4 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.rdb_nada = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.rdb_salida = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.lbl_totalDoc = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.ElLabel1 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_comprobar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.lbl_op = new System.Windows.Forms.Label();
            this.rdb_vale = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdb_nada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdb_salida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_totalDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_comprobar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdb_vale)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = null;
            this.bunifuDragControl1.Vertical = true;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(516, 72);
            this.pnl_titu.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 0;
            // 
            // rdb_nada
            // 
            this.rdb_nada.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.rdb_nada.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.rdb_nada.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.rdb_nada.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.rdb_nada.BorderStyle.EdgeRadius = 7;
            this.rdb_nada.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.rdb_nada.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.rdb_nada.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.rdb_nada.Location = new System.Drawing.Point(38, 208);
            this.rdb_nada.Name = "rdb_nada";
            this.rdb_nada.Size = new System.Drawing.Size(128, 45);
            this.rdb_nada.TabIndex = 4;
            this.rdb_nada.TabStop = false;
            this.rdb_nada.TextStyle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_nada.TextStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.rdb_nada.TextStyle.Text = "Nada";
            this.rdb_nada.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdb_nada.Value = false;
            this.rdb_nada.CheckedChanged += new System.EventHandler(this.rdb_nada_CheckedChanged);
            // 
            // rdb_salida
            // 
            this.rdb_salida.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.rdb_salida.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.rdb_salida.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.rdb_salida.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.rdb_salida.BorderStyle.EdgeRadius = 7;
            this.rdb_salida.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.rdb_salida.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.rdb_salida.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.rdb_salida.Location = new System.Drawing.Point(195, 208);
            this.rdb_salida.Name = "rdb_salida";
            this.rdb_salida.Size = new System.Drawing.Size(120, 45);
            this.rdb_salida.TabIndex = 5;
            this.rdb_salida.TabStop = false;
            this.rdb_salida.TextStyle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_salida.TextStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.rdb_salida.TextStyle.Text = "Dar al Cliente";
            this.rdb_salida.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdb_salida.Value = false;
            this.rdb_salida.CheckedChanged += new System.EventHandler(this.rdb_salida_CheckedChanged);
            // 
            // lbl_totalDoc
            // 
            this.lbl_totalDoc.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.lbl_totalDoc.BackgroundStyle.SolidColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_totalDoc.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            paintStyle3.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle3.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.lbl_totalDoc.FlashStyle = paintStyle3;
            this.lbl_totalDoc.Location = new System.Drawing.Point(224, 101);
            this.lbl_totalDoc.Name = "lbl_totalDoc";
            this.lbl_totalDoc.Size = new System.Drawing.Size(120, 23);
            this.lbl_totalDoc.TabIndex = 420;
            this.lbl_totalDoc.TabStop = false;
            this.lbl_totalDoc.TextStyle.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_totalDoc.TextStyle.Text = "00";
            this.lbl_totalDoc.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_totalDoc.Visible = false;
            this.lbl_totalDoc.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElLabel1
            // 
            this.ElLabel1.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElLabel1.BackgroundStyle.SolidColor = System.Drawing.Color.WhiteSmoke;
            this.ElLabel1.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            paintStyle4.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle4.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel1.FlashStyle = paintStyle4;
            this.ElLabel1.Location = new System.Drawing.Point(186, 101);
            this.ElLabel1.Name = "ElLabel1";
            this.ElLabel1.Size = new System.Drawing.Size(38, 23);
            this.ElLabel1.TabIndex = 419;
            this.ElLabel1.TabStop = false;
            this.ElLabel1.TextStyle.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel1.TextStyle.Text = "S/.";
            this.ElLabel1.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ElLabel1.Visible = false;
            this.ElLabel1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(135, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 22);
            this.label2.TabIndex = 418;
            this.label2.Text = "Total de la Nota de Crédito";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(122, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 20);
            this.label3.TabIndex = 421;
            this.label3.Text = "Que harás con el Importe de la N.C.?";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_comprobar
            // 
            this.btn_comprobar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_comprobar.BackgroundStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.btn_comprobar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_comprobar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_comprobar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_comprobar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_comprobar.BorderStyle.EdgeRadius = 7;
            this.btn_comprobar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_comprobar.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.btn_comprobar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_comprobar.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_comprobar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_comprobar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_comprobar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_comprobar.Location = new System.Drawing.Point(186, 284);
            this.btn_comprobar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_comprobar.Name = "btn_comprobar";
            this.btn_comprobar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_comprobar.Size = new System.Drawing.Size(148, 44);
            this.btn_comprobar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_comprobar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_comprobar.TabIndex = 739;
            this.btn_comprobar.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_comprobar.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_comprobar.TextStyle.Text = "Aceptar";
            this.btn_comprobar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_comprobar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_comprobar.Click += new System.EventHandler(this.btn_comprobar_Click);
            // 
            // lbl_op
            // 
            this.lbl_op.AutoSize = true;
            this.lbl_op.BackColor = System.Drawing.Color.Transparent;
            this.lbl_op.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_op.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_op.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_op.Location = new System.Drawing.Point(12, 312);
            this.lbl_op.Name = "lbl_op";
            this.lbl_op.Size = new System.Drawing.Size(14, 20);
            this.lbl_op.TabIndex = 740;
            this.lbl_op.Text = "-";
            this.lbl_op.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdb_vale
            // 
            this.rdb_vale.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.rdb_vale.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.rdb_vale.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.rdb_vale.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.rdb_vale.BorderStyle.EdgeRadius = 7;
            this.rdb_vale.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.rdb_vale.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.rdb_vale.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.rdb_vale.Location = new System.Drawing.Point(338, 208);
            this.rdb_vale.Name = "rdb_vale";
            this.rdb_vale.Size = new System.Drawing.Size(166, 45);
            this.rdb_vale.TabIndex = 741;
            this.rdb_vale.TextStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_vale.TextStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.rdb_vale.TextStyle.Text = "Usar como Vale(medio de Pago)";
            this.rdb_vale.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdb_vale.Value = false;
            this.rdb_vale.CheckedChanged += new System.EventHandler(this.rdb_vale_CheckedChanged);
            // 
            // Frm_TerminarNotaCred
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(516, 341);
            this.Controls.Add(this.rdb_vale);
            this.Controls.Add(this.lbl_op);
            this.Controls.Add(this.btn_comprobar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_totalDoc);
            this.Controls.Add(this.ElLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdb_salida);
            this.Controls.Add(this.rdb_nada);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_TerminarNotaCred";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terminar Nota de Credito";
            this.Load += new System.EventHandler(this.Frm_TerminarNotaCred_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdb_nada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdb_salida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_totalDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_comprobar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdb_vale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label3;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel lbl_totalDoc;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel1;
        internal System.Windows.Forms.Label label2;
        private Klik.Windows.Forms.v1.EntryLib.ELRadioButton rdb_salida;
        private Klik.Windows.Forms.v1.EntryLib.ELRadioButton rdb_nada;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_comprobar;
        internal System.Windows.Forms.Label lbl_op;
        private Klik.Windows.Forms.v1.EntryLib.ELRadioButton rdb_vale;
    }
}