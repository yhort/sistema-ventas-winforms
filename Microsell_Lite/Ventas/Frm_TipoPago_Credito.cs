using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsell_Lite.Ventas
{
    public partial class Frm_TipoPago_Credito : Form
    {
        public Frm_TipoPago_Credito()
        {
            InitializeComponent();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_Listo_Click(object sender, EventArgs e)
        {
            if(txt_Acuenta.Text == "") { MessageBox.Show("Ingrese un Monto de Adelanto", "Falta Monto a Acuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txt_Acuenta.Focus();return; }
            //if (Convert.ToDouble(txt_Acuenta.Text)==0) { MessageBox.Show("El importe a Cuenta no debe ser Cero", "Falta Monto a Acuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txt_Acuenta.Focus(); return; }

            if (Convert.ToDouble(txt_Acuenta.Text) == Convert.ToDouble(Lbl_Total_acobrar.Text)) { MessageBox.Show("El importe a Cuenta no debe ni puede ser igual al Total a Pagar, caso contrario, realice su venta en efectivo", "Falta Monto a Acuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txt_Acuenta.Focus(); return; }

            if (Convert.ToDouble(txt_Acuenta.Text) > Convert.ToDouble(Lbl_Total_acobrar.Text)) { MessageBox.Show("El importe a Cuenta no debe ni puede ser Mayor al Total a Pagar, caso contratio, realice su venta en efectivo", "Falta Monto a Acuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txt_Acuenta.Focus(); return; }
            //se puede validar fecha opcional.

            this.Tag = "A";
            this.Close();

        }

        private void Frm_TipoPago_Credito_Load(object sender, EventArgs e)
        {
            txt_Acuenta.Focus();
        }

        public void LimpiarForm()
        {
            txt_Acuenta.Text = "0";
            lbl_Saldo_PagarCred.Text = "0";
            lbl_Saldo_PagarCred.Text = "0";
        }

        private void txt_Acuenta_TextChanged(object sender, EventArgs e)
        {
            txt_Acuenta.Text = txt_Acuenta.Text.Replace("," , ".");
            txt_Acuenta.SelectionStart = txt_Acuenta.Text.Length;

            try
            {

                double saldoPdnte = 0;

                saldoPdnte = Convert.ToDouble(Lbl_Total_acobrar.Text) - Convert.ToDouble(txt_Acuenta.Text);
                lbl_Saldo_PagarCred.Text = saldoPdnte.ToString("###0.00");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_Acuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }
    }
}
