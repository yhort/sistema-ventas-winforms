using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsell_Lite.Compras
{
    public partial class Frm_Solo_Canti : Form
    {
        public Frm_Solo_Canti()
        {
            InitializeComponent();
        }

        private void Frm_Solo_Canti_Load(object sender, EventArgs e)
        {
            txt_cant.Focus();
        }

        private void Frm_Solo_Canti_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }

        private void txt_cant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_cant.Text.Trim() == "0") return;
                if (Convert.ToDouble(txt_cant.Text) == 0) { MessageBox.Show("La Cantidad debe ser Mayor a Cero", "Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txt_cant.Focus(); return; }

                this.Tag = "A";
                this.Close();
            }
        }

        private void txt_cant_TextChanged(object sender, EventArgs e)
        {
            txt_cant.Text = txt_cant.Text.Replace(",", ".");
            txt_cant.SelectionStart = txt_cant.Text.Length;
        }

        private void txt_cant_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_cant_KeyDown_1(object sender, KeyEventArgs e)
        {
           
        }

        private void txt_cant_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            
        }

        private void txt_cant2_Click(object sender, EventArgs e)
        {

        }
    }
}
