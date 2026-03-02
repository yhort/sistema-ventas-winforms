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
    public partial class Frm_Solo_Precio : Form
    {
        public Frm_Solo_Precio()
        {
            InitializeComponent();
        }

        private void Frm_Solo_Canti_Load(object sender, EventArgs e)
        {
            txt_precio.Focus();
        }

        private void Frm_Solo_Canti_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Escape )
            {
                this.Tag = "";
                this.Close();
            }
        }

        private void txt_cant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Enter )
            {
                if (txt_precio.Text.Trim() == "") return;
                if (txt_precio.Text.Trim().Length ==0) { MessageBox.Show("Ingrese el Precio del Producto", "Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txt_precio.Focus(); return; }
                if (Convert.ToDouble(txt_precio.Text) == 0) { MessageBox.Show("El Precio debe ser Mayor a Cero", "Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txt_precio.Focus(); return; }

                this.Tag = "A";
                this.Close();
            }


        }

        private void txt_cant_TextChanged(object sender, EventArgs e)
        {
            txt_precio.Text = txt_precio.Text.Replace(",", ".");
            txt_precio.SelectionStart = txt_precio.Text.Length;
        }

        private void txt_cant_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros (e.KeyChar ));
        }
    }
}
