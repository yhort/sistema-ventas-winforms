namespace Microsell_Lite.Informe
{
    partial class Frm_Rpte_Ventas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Rpte_Ventas));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.lbl_nroDoc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.txt_valor = new System.Windows.Forms.TextBox();
            this.rep_view_docvent = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtp_ini = new System.Windows.Forms.DateTimePicker();
            this.buscardocBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DS_Reportes = new Microsell_Lite.Informe.DS_Reportes();
            this.buscar_docBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buscardocBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_Reportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buscar_docBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_titu.Controls.Add(this.lbl_nroDoc);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Controls.Add(this.btn_actualizar);
            this.pnl_titu.Controls.Add(this.btn_export);
            this.pnl_titu.Controls.Add(this.btn_Print);
            this.pnl_titu.Controls.Add(this.btn_Cancelar);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(807, 53);
            this.pnl_titu.TabIndex = 1;
            // 
            // lbl_nroDoc
            // 
            this.lbl_nroDoc.AutoSize = true;
            this.lbl_nroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nroDoc.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_nroDoc.Location = new System.Drawing.Point(123, 10);
            this.lbl_nroDoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_nroDoc.Name = "lbl_nroDoc";
            this.lbl_nroDoc.Size = new System.Drawing.Size(102, 16);
            this.lbl_nroDoc.TabIndex = 511;
            this.lbl_nroDoc.Text = "Impresion de ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 510;
            this.label1.Text = "Impresion de ";
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_actualizar.FlatAppearance.BorderSize = 0;
            this.btn_actualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_actualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_actualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_actualizar.ForeColor = System.Drawing.Color.White;
            this.btn_actualizar.Image = ((System.Drawing.Image)(resources.GetObject("btn_actualizar.Image")));
            this.btn_actualizar.Location = new System.Drawing.Point(611, 7);
            this.btn_actualizar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Size = new System.Drawing.Size(35, 31);
            this.btn_actualizar.TabIndex = 509;
            this.btn_actualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_actualizar.UseVisualStyleBackColor = true;
            // 
            // btn_export
            // 
            this.btn_export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_export.FlatAppearance.BorderSize = 0;
            this.btn_export.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_export.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_export.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.ForeColor = System.Drawing.Color.White;
            this.btn_export.Image = ((System.Drawing.Image)(resources.GetObject("btn_export.Image")));
            this.btn_export.Location = new System.Drawing.Point(657, 7);
            this.btn_export.Margin = new System.Windows.Forms.Padding(4);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(35, 31);
            this.btn_export.TabIndex = 508;
            this.btn_export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_export.UseVisualStyleBackColor = true;
            // 
            // btn_Print
            // 
            this.btn_Print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Print.FlatAppearance.BorderSize = 0;
            this.btn_Print.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_Print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Print.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Print.ForeColor = System.Drawing.Color.White;
            this.btn_Print.Image = ((System.Drawing.Image)(resources.GetObject("btn_Print.Image")));
            this.btn_Print.Location = new System.Drawing.Point(700, 7);
            this.btn_Print.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(35, 31);
            this.btn_Print.TabIndex = 508;
            this.btn_Print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Print.UseVisualStyleBackColor = true;
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancelar.FlatAppearance.BorderSize = 0;
            this.btn_Cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.ForeColor = System.Drawing.Color.White;
            this.btn_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancelar.Image")));
            this.btn_Cancelar.Location = new System.Drawing.Point(759, 7);
            this.btn_Cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(35, 31);
            this.btn_Cancelar.TabIndex = 507;
            this.btn_Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // txt_valor
            // 
            this.txt_valor.Location = new System.Drawing.Point(18, 73);
            this.txt_valor.Name = "txt_valor";
            this.txt_valor.Size = new System.Drawing.Size(100, 20);
            this.txt_valor.TabIndex = 2;
            this.txt_valor.Visible = false;
            // 
            // rep_view_docvent
            // 
            this.rep_view_docvent.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.buscardocBindingSource;
            this.rep_view_docvent.LocalReport.DataSources.Add(reportDataSource1);
            this.rep_view_docvent.LocalReport.ReportEmbeddedResource = "Microsell_Lite.Informe.rpte_doc_ventas.rdlc";
            this.rep_view_docvent.Location = new System.Drawing.Point(0, 53);
            this.rep_view_docvent.Name = "rep_view_docvent";
            this.rep_view_docvent.ServerReport.BearerToken = null;
            this.rep_view_docvent.Size = new System.Drawing.Size(807, 448);
            this.rep_view_docvent.TabIndex = 6;
            // 
            // dtp_ini
            // 
            this.dtp_ini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ini.Location = new System.Drawing.Point(133, 97);
            this.dtp_ini.Name = "dtp_ini";
            this.dtp_ini.Size = new System.Drawing.Size(92, 20);
            this.dtp_ini.TabIndex = 7;
            this.dtp_ini.Visible = false;
            // 
            // buscardocBindingSource
            // 
            this.buscardocBindingSource.DataMember = "buscar_doc";
            this.buscardocBindingSource.DataSource = this.DS_Reportes;
            // 
            // DS_Reportes
            // 
            this.DS_Reportes.DataSetName = "DS_Reportes";
            this.DS_Reportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buscar_docBindingSource
            // 
            this.buscar_docBindingSource.DataMember = "buscar_doc";
            this.buscar_docBindingSource.DataSource = this.DS_Reportes;
            // 
            // Frm_Rpte_Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 501);
            this.Controls.Add(this.dtp_ini);
            this.Controls.Add(this.rep_view_docvent);
            this.Controls.Add(this.txt_valor);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Rpte_Ventas";
            this.Text = "Frm_Rpte_Ventas";
            this.Load += new System.EventHandler(this.Frm_Rpte_Ventas_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buscardocBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_Reportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buscar_docBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        internal System.Windows.Forms.Label lbl_nroDoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_actualizar;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_Cancelar;
        internal System.Windows.Forms.TextBox txt_valor;
        private Microsoft.Reporting.WinForms.ReportViewer rep_view_docvent;
        private System.Windows.Forms.BindingSource buscar_docBindingSource;
        private DS_Reportes DS_Reportes;
        private System.Windows.Forms.BindingSource buscardocBindingSource;
        public System.Windows.Forms.DateTimePicker dtp_ini;
    }
}