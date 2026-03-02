using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsell_Lite.Productos
{
    public partial class Frm_Add_Cantidad_Stock : Form
    {
        public Frm_Add_Cantidad_Stock()
        {
            InitializeComponent();
        }

        private void Frm_Edit_Precio_Load(object sender, EventArgs e)
        {
            txt_cant.Focus();
        }

        private void txt_cant_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double resul = Convert.ToDouble(txt_cant.Text) - Convert.ToDouble(Lbl_stockActual.Text);
                lbl_dife.Text = resul.ToString();

                double importe = 0;
                double resul2 = Math.Abs(resul);
                importe = resul2 * Convert.ToDouble(lbl_precompra.Text);
                lbl_Importeq.Text = importe.ToString("###0.00");

            }
            catch (Exception ex )
            {

                lbl_dife.Text = "0";
                lbl_Importeq.Text = "0";
            }

        }

        private void txt_cant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lbl_TipoProd.Text.Trim().ToString() == "Producto")
                {
                    if (Convert.ToDouble(txt_cant.Text) > Convert.ToDouble(Lbl_stockActual.Text))
                    {

                        MessageBox.Show("La cantidad a vender no puede ser Mayor al Stock Disponible", "Validar Stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_cant.Text = "1";
                        return;
                    }
                    else
                    {
                        this.Tag = "A";
                        this.Close();
                    }
                }
                else
                {
                    this.Tag = "A";
                    this.Close();
                }
            }

        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pnl_titu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_procesar_Click(object sender, EventArgs e)
        {
            if(txt_cant.Text.Trim() == "")
            {
                MessageBox.Show("Ingresa una Cantidad por favor", "Validar Stocj", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                this.Tag = "A";
                this.Close();
            }
        }

        private void Frm_Add_Cantidad_Stoc_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
