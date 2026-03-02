using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;


using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;

namespace Microsell_Lite.Ventas
{
    public partial class Frm_Metodo_Pago : Form
    {
        public Frm_Metodo_Pago()
        {
            InitializeComponent();
        }

        public bool paraImprimir = false;
        private void Frm_Metodo_Pago_Load(object sender, EventArgs e)
        {
            dtp_vence1.Value = DateTime.Today;

            lbl_idcaja.Text = RN_TipoDoc.RN_NroID(15);

            //lbl_tipopago.Text = "Efectivo";
            //xtabcon.SelectedIndex = 0;

   
            txt_efectivo.Focus();
        }

        private void btn_cobrar_print_Click(object sender, EventArgs e)
        {
            if (lbl_tipopago.Text == "Efectivo")
            {
                Guardar_IngresoCaja_Mixto("Efectivo", Convert.ToDouble(lbl_totalpagarxx.Text), " en Efectivo");

                this.Tag = "A";
                this.Close();

            }
            else if (lbl_tipopago.Text == "Tarjeta")
            {
                Guardar_IngresoCaja_Mixto("Tarjeta", Convert.ToDouble(lbl_totalpagarxx.Text), " con Tarjeta");

                this.Tag = "A";
                this.Close();

            }
            else if (lbl_tipopago.Text == "Yape")
            {
                Guardar_IngresoCaja_Mixto("Yape", Convert.ToDouble(lbl_totalpagarxx.Text), "con Yape");

                this.Tag = "A";
                this.Close();

            }
            else if (lbl_tipopago.Text == "Plin")
            {
                Guardar_IngresoCaja_Mixto("Plin", Convert.ToDouble(lbl_totalpagarxx.Text), "con Plin");

                this.Tag = "A";
                this.Close();

            }
            else if (lbl_tipopago.Text == "Credito")
            {
                Guardar_IngresoCaja_Mixto("Credito", Convert.ToDouble(lbl_totalpagarxx.Text), "a Credito");
                if (chk_dejaracuenta.Checked == true)
                {
                    Guardar_IngresoCaja_Mixto(cbo_tipopago_acuenta.Text, Convert.ToDouble(txt_montocuota.Text), "a Credito");
                }
               
                this.Tag = "A";
                this.Close();

            }

            else if (lbl_tipopago.Text == "Mixto")
            {
                if (Convert.ToDouble(txt_mxto_efectivo.Text) > 0)
                {
                    Guardar_IngresoCaja_Mixto("Efectivo", Convert.ToDouble(txt_mxto_efectivo.Text), " en Efectivo");
                }

                if (Convert.ToDouble(lbl_saldomixto.Text) > 0)
                {
                    Guardar_IngresoCaja_Mixto(cbo_pagos_digitalesmix.Text, Convert.ToDouble(lbl_saldomixto.Text), cbo_pagos_digitalesmix.Text);
                    //Guardar_IngresoCaja_Mixto("Tarjeta", Convert.ToDouble(lbl_saldomixto.Text), " en Tarjeta");
                }

                this.Tag = "A";
                this.Close();

            }

            paraImprimir = true;


        }

        bool siguardo =false;
        private void Guardar_IngresoCaja_Mixto(string tipopago, double importepago, string concepto)
        {
            RN_Caja obj = new RN_Caja();
            En_Caja cja = new En_Caja();

            try
            {
                cja.Idcaja = lbl_idcaja.Text;
                cja.FechaCaja = dtp_Fecha.Value;
                cja.TipoCaja = "Entrada";
                cja.Concepto = "venta con pago: " + concepto;
                cja.De_Para_Cliente = lbl_cliente.Text;
                cja.Nro_Doc = lbl_nroDocx.Text;
                cja.ImportaCaja = importepago;
                cja.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                cja.TotalUti = Convert.ToDouble(lbl_totalUtili.Text);
                cja.TipoPago = tipopago;  //cbotipopago
                cja.GeneradoPor = lbl_tipoDoc.Text;

                obj.RN_Registrar_Mov_Caja(cja);

                if(BD_Caja.cajaSaved == true)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo_Producto(15);
                    siguardo = true;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

       

        private void txt_efectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario(); //evento keypress, con este codigo para ingresar solo numero, en los precios.
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void btn_cancelarOp_Click(object sender, EventArgs e)
        {
            RN_Caja obj = new RN_Caja();

            if(siguardo == true)
            {
                obj.RN_Anular_Mov_Caja2(lbl_idcaja.Text);
                siguardo = false;
            }
            this.Tag = "";
            this.Close();
        }

        //private void mnu_efectivo(object sender, EventArgs e)
        //{

        //}

        public bool dejoacuenta = false;
        private void chk_dejaracuenta_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_dejaracuenta.Checked == true)
            {
                cbo_tipopago_acuenta.Visible = true;
                dejoacuenta = true;
                cbo_tipopago_acuenta.Focus();
            }
            else
            {
                cbo_tipopago_acuenta.Visible = false;
                dejoacuenta = false;
                cbo_tipopago_acuenta.SelectedIndex = -1;
            }
        }

        private void calcular() //para vales
        {

        }

        private void num_cuota_ValueChanged(object sender, EventArgs e)
        {
            double nrocuota = 0;
            double totalventa = Convert.ToDouble(lbl_totalpagarxx.Text);

            if (num_cuota.Value == 1) 
            {
                dtp_vence1.Enabled = true;
                dtp_vence2.Enabled = false;
                dtp_vence3.Enabled = false;
                txt_montocuota.Text = totalventa.ToString("###0.00");
            }else if (num_cuota.Value == 2)
            {
                dtp_vence1.Enabled = true;
                dtp_vence2.Enabled = true;
                dtp_vence3.Enabled = false;

                nrocuota = totalventa / 2;
                txt_montocuota.Text = nrocuota.ToString("###0.00");
            }
        }

        private void Frm_Metodo_Pago_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                mnu_efectivo_Click(sender, e);
            }
            if (e.KeyCode == Keys.F2)
            {
                mnu_tarjeta_Click(sender, e);
            }
            if (e.KeyCode == Keys.F3)
            {
                mnu_yape_Click(sender, e);
            }
            if (e.KeyCode == Keys.F4)
            {
                mnu_plin_Click(sender, e);
            }
            if (e.KeyCode == Keys.F5)
            {
                mnu_credito_Click(sender, e);
            }
            if (e.KeyCode == Keys.F6)
            {
                mnu_mixto_Click(sender, e);
            }
        }

        private void mnu_credito_Click(object sender, KeyEventArgs e)
        {
            xtabcon.SelectedIndex = 2;
            lbl_tipopago.Text = "Credito";

            if (Convert.ToDouble(lbl_xrecordCred.Text) >= Convert.ToDouble(lbl_xlimitecred.Text))
            {
               // highlighter1.SetHighlightColor(pn)
            }
        }

        private void mnu_efectivo_Click(object sender, EventArgs e)
        {
            xtabcon.SelectedIndex = 0;
            lbl_tipopago.Text = "Efectivo";
            
        }

        private void mnu_tarjeta_Click(object sender, EventArgs e)
        {
            xtabcon.SelectedIndex = 1;
            lbl_tipopago.Text = "Tarjeta";
            txt_tarjeta.Text = lbl_totalpagarxx.Text;
        }
        private void mnu_yape_Click(object sender, EventArgs e)
        {
            xtabcon.SelectedIndex = 2;
            lbl_tipopago.Text = "Yape";
            txt_yape.Text = lbl_totalpagarxx.Text;
        }

        private void mnu_plin_Click(object sender, EventArgs e)
        {
            xtabcon.SelectedIndex = 3;
            lbl_tipopago.Text = "Plin";
            txt_plin.Text = lbl_totalpagarxx.Text;
        }

        private void mnu_credito_Click(object sender, EventArgs e)
        {
            xtabcon.SelectedIndex = 4;
            lbl_tipopago.Text = "Credito";
        }
        private void mnu_mixto_Click(object sender, EventArgs e)
        {
            xtabcon.SelectedIndex = 5;
            lbl_tipopago.Text = "Mixto";
            txt_mxto_efectivo.Focus();

        }

        private void txt_mxto_efectivo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txt_mxto_efectivo.Text) >= Convert.ToDouble(lbl_totalpagarxx.Text))
                {
                    highlighter1.SetHighlightColor(elLabel2, DevComponents.DotNetBar.Validator.eHighlightColor.None);
                    errorProvider1.SetError(elLabel2, "El importe no debe ser mayor al Total");
                }
                else
                {
                    highlighter1.SetHighlightColor(elLabel2, DevComponents.DotNetBar.Validator.eHighlightColor.None);
                    errorProvider1.SetError(elLabel2, "");
                }

                double saldox = 0;
                saldox = Convert.ToDouble(lbl_totalpagarxx.Text) - Convert.ToDouble(txt_mxto_efectivo.Text);
                lbl_saldomixto.Text = saldox.ToString("###0.00");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();
            if(e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);
            }
        }

        private void btn_cobrar_sinImprimir_Click(object sender, EventArgs e)
        {
            paraImprimir = false;

            if (lbl_tipopago.Text == "Efectivo")
            {
                Guardar_IngresoCaja_Mixto("Efectivo", Convert.ToDouble(lbl_totalpagarxx.Text), " en Efectivo");

                this.Tag = "A";
                this.Close();

            }
            else if (lbl_tipopago.Text == "Tarjeta")
            {
                Guardar_IngresoCaja_Mixto("Tarjeta", Convert.ToDouble(lbl_totalpagarxx.Text), "con Tarjeta");

                this.Tag = "A";
                this.Close();

            }
            else if (lbl_tipopago.Text == "Credito")
            {
                Guardar_IngresoCaja_Mixto("Credito", Convert.ToDouble(lbl_totalpagarxx.Text), "a Credito");
                if (chk_dejaracuenta.Checked == true)
                {
                    Guardar_IngresoCaja_Mixto(cbo_tipopago_acuenta.Text, Convert.ToDouble(txt_montocuota.Text), "a Credito");
                }

                this.Tag = "A";
                this.Close();

            }

            else if (lbl_tipopago.Text == "Mixto")
            {
                if (Convert.ToDouble(txt_mxto_efectivo.Text) > 0)
                {
                    Guardar_IngresoCaja_Mixto("Efectivo", Convert.ToDouble(txt_mxto_efectivo.Text), " en Efectivo");
                }

                if (Convert.ToDouble(lbl_saldomixto.Text) > 0)
                {
                    Guardar_IngresoCaja_Mixto(cbo_pagos_digitalesmix.Text, Convert.ToDouble(lbl_saldomixto.Text), "con " + cbo_pagos_digitalesmix.Text);
                }

                this.Tag = "A";
                this.Close();

            }

            //paraImprimir = false;
        }

        private void txt_efectivo_TextChanged(object sender, EventArgs e)
        {
            //tx_efectivo.Text = tx_efectivo.Text.Replace(",", ".");
            //tx_efectivo.SelectionStart = tx_efectivo.Text.Length;
            double vuelto = 0;

            try
            {
                vuelto = Convert.ToDouble(txt_efectivo.Text) - Convert.ToDouble(lbl_totalpagarxx.Text);
                lbl_vuelto.Text = vuelto.ToString("###0.00");
            }
            catch (Exception ex)
            {

                string sms = ex.Message;
            }
           
           
        }

        private void txt_tarjeta_TextChanged(object sender, EventArgs e)
        {
            txt_tarjeta.Text = lbl_totalpagarxx.Text;
        }
        private void txt_yape_TextChanged(object sender, EventArgs e)
        {
            txt_yape.Text = lbl_totalpagarxx.Text;
        }
        

        private void txt_plin_TextChanged(object sender, EventArgs e)
        {
            txt_plin.Text = lbl_totalpagarxx.Text;
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
            xtabcon.SelectedIndex = 4;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
