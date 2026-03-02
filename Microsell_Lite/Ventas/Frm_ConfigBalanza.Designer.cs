namespace Microsell_Lite.Ventas
{
    partial class Frm_ConfigBalanza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ConfigBalanza));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnProbarConexion = new Guna.UI.WinForms.GunaButton();
            this.btnGuardar = new Guna.UI.WinForms.GunaButton();
            this.cmb_PuertoCOM = new Guna.UI.WinForms.GunaComboBox();
            this.cmb_BaudRate = new Guna.UI.WinForms.GunaComboBox();
            this.cmb_DataBits = new Guna.UI.WinForms.GunaComboBox();
            this.cmb_Paridad = new Guna.UI.WinForms.GunaComboBox();
            this.cmb_StopBits = new Guna.UI.WinForms.GunaComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_reload = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pnl_titu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // btnProbarConexion
            // 
            this.btnProbarConexion.AnimationHoverSpeed = 0.07F;
            this.btnProbarConexion.AnimationSpeed = 0.03F;
            this.btnProbarConexion.BackColor = System.Drawing.Color.Transparent;
            this.btnProbarConexion.BaseColor = System.Drawing.Color.DarkCyan;
            this.btnProbarConexion.BorderColor = System.Drawing.Color.Black;
            this.btnProbarConexion.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnProbarConexion.FocusedColor = System.Drawing.Color.Empty;
            this.btnProbarConexion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnProbarConexion.ForeColor = System.Drawing.Color.White;
            this.btnProbarConexion.Image = ((System.Drawing.Image)(resources.GetObject("btnProbarConexion.Image")));
            this.btnProbarConexion.ImageSize = new System.Drawing.Size(20, 20);
            this.btnProbarConexion.Location = new System.Drawing.Point(479, 160);
            this.btnProbarConexion.Name = "btnProbarConexion";
            this.btnProbarConexion.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnProbarConexion.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnProbarConexion.OnHoverForeColor = System.Drawing.Color.White;
            this.btnProbarConexion.OnHoverImage = null;
            this.btnProbarConexion.OnPressedColor = System.Drawing.Color.Black;
            this.btnProbarConexion.Radius = 10;
            this.btnProbarConexion.Size = new System.Drawing.Size(160, 42);
            this.btnProbarConexion.TabIndex = 1;
            this.btnProbarConexion.Text = "Probar Conexion";
            this.btnProbarConexion.Click += new System.EventHandler(this.btnProbarConexion_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AnimationHoverSpeed = 0.07F;
            this.btnGuardar.AnimationSpeed = 0.03F;
            this.btnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.BaseColor = System.Drawing.Color.DodgerBlue;
            this.btnGuardar.BorderColor = System.Drawing.Color.Black;
            this.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnGuardar.FocusedColor = System.Drawing.Color.Empty;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnGuardar.Location = new System.Drawing.Point(479, 264);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnGuardar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnGuardar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnGuardar.OnHoverImage = null;
            this.btnGuardar.OnPressedColor = System.Drawing.Color.Black;
            this.btnGuardar.Radius = 10;
            this.btnGuardar.Size = new System.Drawing.Size(160, 42);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cmb_PuertoCOM
            // 
            this.cmb_PuertoCOM.BackColor = System.Drawing.Color.Transparent;
            this.cmb_PuertoCOM.BaseColor = System.Drawing.Color.White;
            this.cmb_PuertoCOM.BorderColor = System.Drawing.Color.Silver;
            this.cmb_PuertoCOM.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_PuertoCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PuertoCOM.FocusedColor = System.Drawing.Color.Empty;
            this.cmb_PuertoCOM.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmb_PuertoCOM.ForeColor = System.Drawing.Color.Black;
            this.cmb_PuertoCOM.FormattingEnabled = true;
            this.cmb_PuertoCOM.Location = new System.Drawing.Point(188, 88);
            this.cmb_PuertoCOM.Name = "cmb_PuertoCOM";
            this.cmb_PuertoCOM.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmb_PuertoCOM.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmb_PuertoCOM.Size = new System.Drawing.Size(152, 26);
            this.cmb_PuertoCOM.TabIndex = 2;
            // 
            // cmb_BaudRate
            // 
            this.cmb_BaudRate.BackColor = System.Drawing.Color.Transparent;
            this.cmb_BaudRate.BaseColor = System.Drawing.Color.White;
            this.cmb_BaudRate.BorderColor = System.Drawing.Color.Silver;
            this.cmb_BaudRate.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_BaudRate.FocusedColor = System.Drawing.Color.Empty;
            this.cmb_BaudRate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmb_BaudRate.ForeColor = System.Drawing.Color.Black;
            this.cmb_BaudRate.FormattingEnabled = true;
            this.cmb_BaudRate.Location = new System.Drawing.Point(188, 149);
            this.cmb_BaudRate.Name = "cmb_BaudRate";
            this.cmb_BaudRate.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmb_BaudRate.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmb_BaudRate.Size = new System.Drawing.Size(152, 26);
            this.cmb_BaudRate.TabIndex = 3;
            // 
            // cmb_DataBits
            // 
            this.cmb_DataBits.BackColor = System.Drawing.Color.Transparent;
            this.cmb_DataBits.BaseColor = System.Drawing.Color.White;
            this.cmb_DataBits.BorderColor = System.Drawing.Color.Silver;
            this.cmb_DataBits.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_DataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DataBits.FocusedColor = System.Drawing.Color.Empty;
            this.cmb_DataBits.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmb_DataBits.ForeColor = System.Drawing.Color.Black;
            this.cmb_DataBits.FormattingEnabled = true;
            this.cmb_DataBits.Location = new System.Drawing.Point(188, 207);
            this.cmb_DataBits.Name = "cmb_DataBits";
            this.cmb_DataBits.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmb_DataBits.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmb_DataBits.Size = new System.Drawing.Size(152, 26);
            this.cmb_DataBits.TabIndex = 4;
            // 
            // cmb_Paridad
            // 
            this.cmb_Paridad.BackColor = System.Drawing.Color.Transparent;
            this.cmb_Paridad.BaseColor = System.Drawing.Color.White;
            this.cmb_Paridad.BorderColor = System.Drawing.Color.Silver;
            this.cmb_Paridad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_Paridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Paridad.FocusedColor = System.Drawing.Color.Empty;
            this.cmb_Paridad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmb_Paridad.ForeColor = System.Drawing.Color.Black;
            this.cmb_Paridad.FormattingEnabled = true;
            this.cmb_Paridad.Location = new System.Drawing.Point(188, 259);
            this.cmb_Paridad.Name = "cmb_Paridad";
            this.cmb_Paridad.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmb_Paridad.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmb_Paridad.Size = new System.Drawing.Size(152, 26);
            this.cmb_Paridad.TabIndex = 5;
            // 
            // cmb_StopBits
            // 
            this.cmb_StopBits.BackColor = System.Drawing.Color.Transparent;
            this.cmb_StopBits.BaseColor = System.Drawing.Color.White;
            this.cmb_StopBits.BorderColor = System.Drawing.Color.Silver;
            this.cmb_StopBits.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_StopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StopBits.FocusedColor = System.Drawing.Color.Empty;
            this.cmb_StopBits.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmb_StopBits.ForeColor = System.Drawing.Color.Black;
            this.cmb_StopBits.FormattingEnabled = true;
            this.cmb_StopBits.Location = new System.Drawing.Point(188, 319);
            this.cmb_StopBits.Name = "cmb_StopBits";
            this.cmb_StopBits.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmb_StopBits.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmb_StopBits.Size = new System.Drawing.Size(152, 26);
            this.cmb_StopBits.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(102, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Puerto COM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(100, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "BaudRate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(102, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "DataBits";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(102, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Paridad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(102, 324);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "StopBits";
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.SlateGray;
            this.pnl_titu.Controls.Add(this.btn_reload);
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Controls.Add(this.label6);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(800, 50);
            this.pnl_titu.TabIndex = 12;
            // 
            // btn_reload
            // 
            this.btn_reload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_reload.FlatAppearance.BorderSize = 0;
            this.btn_reload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_reload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_reload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reload.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reload.ForeColor = System.Drawing.Color.White;
            this.btn_reload.Image = ((System.Drawing.Image)(resources.GetObject("btn_reload.Image")));
            this.btn_reload.Location = new System.Drawing.Point(713, 10);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(32, 32);
            this.btn_reload.TabIndex = 56;
            this.btn_reload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_reload.UseVisualStyleBackColor = true;
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_cerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cerrar.ForeColor = System.Drawing.Color.White;
            this.btn_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cerrar.Image")));
            this.btn_cerrar.Location = new System.Drawing.Point(756, 10);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(32, 32);
            this.btn_cerrar.TabIndex = 6;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(8, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Configuración de Balanza";
            // 
            // Frm_ConfigBalanza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_StopBits);
            this.Controls.Add(this.cmb_Paridad);
            this.Controls.Add(this.cmb_DataBits);
            this.Controls.Add(this.cmb_BaudRate);
            this.Controls.Add(this.cmb_PuertoCOM);
            this.Controls.Add(this.btnProbarConexion);
            this.Controls.Add(this.btnGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_ConfigBalanza";
            this.Text = "Frm_ConfigBalanza";
            this.Load += new System.EventHandler(this.Frm_ConfigBalanza_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Guna.UI.WinForms.GunaButton btnProbarConexion;
        private Guna.UI.WinForms.GunaButton btnGuardar;
        private Guna.UI.WinForms.GunaComboBox cmb_DataBits;
        private Guna.UI.WinForms.GunaComboBox cmb_BaudRate;
        private Guna.UI.WinForms.GunaComboBox cmb_PuertoCOM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaComboBox cmb_StopBits;
        private Guna.UI.WinForms.GunaComboBox cmb_Paridad;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Button btn_reload;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label6;
    }
}