namespace Microsell_Lite.Proveedor
{
    partial class Frm_ListadoProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ListadoProveedor));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lsv_prove = new System.Windows.Forms.ListView();
            this.lbl_id = new System.Windows.Forms.Label();
            this.lbl_nom = new System.Windows.Forms.Label();
            this.lbl_rucProv = new System.Windows.Forms.Label();
            this.pnl_titu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.DimGray;
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(519, 49);
            this.pnl_titu.TabIndex = 3;
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_cerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cerrar.ForeColor = System.Drawing.Color.White;
            this.btn_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cerrar.Image")));
            this.btn_cerrar.Location = new System.Drawing.Point(475, 6);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(32, 32);
            this.btn_cerrar.TabIndex = 6;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listado de Proveedores";
            // 
            // lsv_prove
            // 
            this.lsv_prove.ForeColor = System.Drawing.Color.DimGray;
            this.lsv_prove.HideSelection = false;
            this.lsv_prove.Location = new System.Drawing.Point(0, 96);
            this.lsv_prove.Name = "lsv_prove";
            this.lsv_prove.Size = new System.Drawing.Size(515, 521);
            this.lsv_prove.TabIndex = 4;
            this.lsv_prove.UseCompatibleStateImageBehavior = false;
            this.lsv_prove.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsv_prove_KeyDown);
            this.lsv_prove.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsv_prove_MouseDoubleClick);
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(211, 559);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(10, 13);
            this.lbl_id.TabIndex = 5;
            this.lbl_id.Text = "-";
            // 
            // lbl_nom
            // 
            this.lbl_nom.AutoSize = true;
            this.lbl_nom.Location = new System.Drawing.Point(268, 70);
            this.lbl_nom.Name = "lbl_nom";
            this.lbl_nom.Size = new System.Drawing.Size(10, 13);
            this.lbl_nom.TabIndex = 6;
            this.lbl_nom.Text = "-";
            // 
            // lbl_rucProv
            // 
            this.lbl_rucProv.AutoSize = true;
            this.lbl_rucProv.Location = new System.Drawing.Point(324, 70);
            this.lbl_rucProv.Name = "lbl_rucProv";
            this.lbl_rucProv.Size = new System.Drawing.Size(10, 13);
            this.lbl_rucProv.TabIndex = 7;
            this.lbl_rucProv.Text = "-";
            // 
            // Frm_ListadoProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 580);
            this.Controls.Add(this.lbl_rucProv);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.lbl_nom);
            this.Controls.Add(this.lsv_prove);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_ListadoProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_ListadoProveedor";
            this.Load += new System.EventHandler(this.Frm_ListadoProveedor_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        internal System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lsv_prove;
        internal System.Windows.Forms.Label lbl_id;
        internal System.Windows.Forms.Label lbl_nom;
        internal System.Windows.Forms.Label lbl_rucProv;
    }
}