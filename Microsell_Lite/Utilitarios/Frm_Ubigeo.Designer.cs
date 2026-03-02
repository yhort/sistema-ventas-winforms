namespace Microsell_Lite.Utilitarios
{
    partial class Frm_Ubigeo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Ubigeo));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.cboDepartamento = new Guna.UI.WinForms.GunaComboBox();
            this.cboProvincia = new Guna.UI.WinForms.GunaComboBox();
            this.cboDistrito = new Guna.UI.WinForms.GunaComboBox();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel4 = new Guna.UI.WinForms.GunaLabel();
            this.txtUbigeo = new Guna.UI.WinForms.GunaTextBox();
            this.gunaLabel5 = new Guna.UI.WinForms.GunaLabel();
            this.btnAceptar = new Guna.UI.WinForms.GunaButton();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.BackColor = System.Drawing.Color.Transparent;
            this.cboDepartamento.BaseColor = System.Drawing.Color.White;
            this.cboDepartamento.BorderColor = System.Drawing.Color.Silver;
            this.cboDepartamento.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartamento.FocusedColor = System.Drawing.Color.Empty;
            this.cboDepartamento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboDepartamento.ForeColor = System.Drawing.Color.Black;
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Location = new System.Drawing.Point(74, 96);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cboDepartamento.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cboDepartamento.Size = new System.Drawing.Size(155, 26);
            this.cboDepartamento.TabIndex = 0;
            this.cboDepartamento.SelectedIndexChanged += new System.EventHandler(this.cboDepartamento_SelectedIndexChanged);
            // 
            // cboProvincia
            // 
            this.cboProvincia.BackColor = System.Drawing.Color.Transparent;
            this.cboProvincia.BaseColor = System.Drawing.Color.White;
            this.cboProvincia.BorderColor = System.Drawing.Color.Silver;
            this.cboProvincia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincia.FocusedColor = System.Drawing.Color.Empty;
            this.cboProvincia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboProvincia.ForeColor = System.Drawing.Color.Black;
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(74, 151);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cboProvincia.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cboProvincia.Size = new System.Drawing.Size(155, 26);
            this.cboProvincia.TabIndex = 1;
            this.cboProvincia.SelectedIndexChanged += new System.EventHandler(this.cboProvincia_SelectedIndexChanged);
            // 
            // cboDistrito
            // 
            this.cboDistrito.BackColor = System.Drawing.Color.Transparent;
            this.cboDistrito.BaseColor = System.Drawing.Color.White;
            this.cboDistrito.BorderColor = System.Drawing.Color.Silver;
            this.cboDistrito.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrito.FocusedColor = System.Drawing.Color.Empty;
            this.cboDistrito.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboDistrito.ForeColor = System.Drawing.Color.Black;
            this.cboDistrito.FormattingEnabled = true;
            this.cboDistrito.Location = new System.Drawing.Point(74, 211);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cboDistrito.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cboDistrito.Size = new System.Drawing.Size(155, 26);
            this.cboDistrito.TabIndex = 2;
            this.cboDistrito.SelectedIndexChanged += new System.EventHandler(this.cboDistrito_SelectedIndexChanged);
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel1.Location = new System.Drawing.Point(111, 78);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(83, 15);
            this.gunaLabel1.TabIndex = 3;
            this.gunaLabel1.Text = "Departamento";
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel2.Location = new System.Drawing.Point(120, 133);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(56, 15);
            this.gunaLabel2.TabIndex = 4;
            this.gunaLabel2.Text = "Provincia";
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel3.Location = new System.Drawing.Point(131, 193);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(45, 15);
            this.gunaLabel3.TabIndex = 5;
            this.gunaLabel3.Text = "Distrito";
            // 
            // gunaLabel4
            // 
            this.gunaLabel4.AutoSize = true;
            this.gunaLabel4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel4.Location = new System.Drawing.Point(130, 34);
            this.gunaLabel4.Name = "gunaLabel4";
            this.gunaLabel4.Size = new System.Drawing.Size(70, 20);
            this.gunaLabel4.TabIndex = 6;
            this.gunaLabel4.Text = "UBIGEOS";
            // 
            // txtUbigeo
            // 
            this.txtUbigeo.BaseColor = System.Drawing.Color.White;
            this.txtUbigeo.BorderColor = System.Drawing.Color.Silver;
            this.txtUbigeo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUbigeo.FocusedBaseColor = System.Drawing.Color.White;
            this.txtUbigeo.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtUbigeo.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUbigeo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUbigeo.Location = new System.Drawing.Point(74, 279);
            this.txtUbigeo.Name = "txtUbigeo";
            this.txtUbigeo.PasswordChar = '\0';
            this.txtUbigeo.Size = new System.Drawing.Size(160, 30);
            this.txtUbigeo.TabIndex = 7;
            // 
            // gunaLabel5
            // 
            this.gunaLabel5.AutoSize = true;
            this.gunaLabel5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel5.Location = new System.Drawing.Point(131, 261);
            this.gunaLabel5.Name = "gunaLabel5";
            this.gunaLabel5.Size = new System.Drawing.Size(45, 15);
            this.gunaLabel5.TabIndex = 8;
            this.gunaLabel5.Text = "Ubigeo";
            // 
            // btnAceptar
            // 
            this.btnAceptar.AnimationHoverSpeed = 0.07F;
            this.btnAceptar.AnimationSpeed = 0.03F;
            this.btnAceptar.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnAceptar.BorderColor = System.Drawing.Color.Black;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAceptar.FocusedColor = System.Drawing.Color.Empty;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnAceptar.Location = new System.Drawing.Point(93, 329);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnAceptar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnAceptar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnAceptar.OnHoverImage = null;
            this.btnAceptar.OnPressedColor = System.Drawing.Color.Black;
            this.btnAceptar.Size = new System.Drawing.Size(119, 42);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Confirmar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // Frm_Ubigeo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 422);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gunaLabel5);
            this.Controls.Add(this.txtUbigeo);
            this.Controls.Add(this.gunaLabel4);
            this.Controls.Add(this.gunaLabel3);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.cboDistrito);
            this.Controls.Add(this.cboProvincia);
            this.Controls.Add(this.cboDepartamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Ubigeo";
            this.Text = "Frm_UbigeoList";
            this.Load += new System.EventHandler(this.Frm_Ubigeo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Guna.UI.WinForms.GunaLabel gunaLabel3;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaComboBox cboDistrito;
        private Guna.UI.WinForms.GunaComboBox cboProvincia;
        private Guna.UI.WinForms.GunaComboBox cboDepartamento;
        private Guna.UI.WinForms.GunaLabel gunaLabel4;
        private Guna.UI.WinForms.GunaLabel gunaLabel5;
        private Guna.UI.WinForms.GunaTextBox txtUbigeo;
        private Guna.UI.WinForms.GunaButton btnAceptar;
    }
}