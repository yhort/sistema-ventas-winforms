using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Ventas;


namespace Microsell_Lite.Ventas
{
    public partial class Frm_Reg_AbonosdeCredito : Form
    {
        public Frm_Reg_AbonosdeCredito()
        {
            InitializeComponent();
        }

        private void Pnl_titulo_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario ui = new Utilitario();
            if (e.Button == MouseButtons.Left)
            {
                ui.Mover_formulario(this);
            }
        }

        private void Frm_Reg_otroIngresos_Load(object sender, EventArgs e)
        {
            Buscar_Credito(this.Tag.ToString()); //opcional poner arriba del try buscarclieditar 
        }



        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();

        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            Buscar_Credito(this.Tag.ToString()); //opcional po

            this.Tag = "A";
            this.Close();

        }

        int Prod_Krd = 0;

        private void Buscar_Credito(string valor)
        {
            RN_Credito obj = new RN_Credito();
            DataTable data = new DataTable();

            DataTable datodoc = new DataTable();

            RN_KardexCredito objc = new RN_KardexCredito();
            EN_Kardex_Credito kar = new EN_Kardex_Credito();
            RN_Documento objdocx = new RN_Documento();


            string xidkardex = "";
            int xitem = 0;

            double xcredito = 0;
            double xacuenta = 0;
            double xcant_Saldo = 0;
            //Cargar_distritos();
            string xxidcli = "";

            string xnombcliente;
            double xsaldo_pendiente = 0;


            try
            {



                data = obj.RN_Listar_creditos_porValor(valor);

                xxidcli = Convert.ToString(data.Rows[0]["IdNotaCred"]);
                txt_idcred.Text = xxidcli.Trim();

                xacuenta = Convert.ToDouble(txt_Acuenta.Text);

                if (objc.RN_Verificar_Documento_siTieneKardex(xxidcli) == true)
                {
                    data = objc.RN_Buscar_KardexDetalle_por_Doc(xxidcli.Trim());

                    if (data.Rows.Count > 0)
                    {
                        xxidcli = Convert.ToString(data.Rows[0]["IdNotaCred"]);
                        xitem = data.Rows.Count;


                        //xacuenta = Convert.ToDouble(txt_Acuenta.Text);

                        datodoc = objdocx.RN_Buscar_Creditos(xxidcli.Trim());
                        xcredito = Convert.ToDouble(datodoc.Rows[0]["Total_Cre"]);

                        lbl_totalcredito.Text = Convert.ToString(xcredito);

                        datodoc = objdocx.RN_Buscar_Creditos(xxidcli.Trim());
                        xsaldo_pendiente = Convert.ToDouble(datodoc.Rows[0]["Saldo_Pdnte"]);

                        lbl_saldo_Pdnte.Text = Convert.ToString(xsaldo_pendiente);

                        xnombcliente = Convert.ToString(datodoc.Rows[0]["Nom_Cliente"]);
                        txt_nombrecliente.Text = xnombcliente;



                        //registramos el Detalle del Kardex:
                        kar.Idkardex = xxidcli;
                        kar.Item = xitem + 1;
                        kar.FechaAbono = Convert.ToDateTime(dtp_fechaAbono.Text);
                        kar.Docreference = "-";
                        kar.DetOperacion = "Abono Pago";
                        kar.TotalCredito = xcredito;
                        kar.Acuenta = xacuenta;
                        //kar.SaldoPendiente = xcredito - xacuenta;
                        kar.SaldoPendiente = xsaldo_pendiente - kar.Acuenta;


                        //Entrada
                        //kar.FechaAbono 
                        ////kar.TotalCredito = xcredito;
                        //kar.Acuenta = Convert.ToDouble(txt_Acuenta.Text);
                        //kar.SaldoPendiente = 0;

                        //saldos:   //CALCULOS DE LOS KARDEX VALORIZADOS
                        //kar.SaldoPendiente = xcredito - kar.Acuenta;

                        objc.RN_Registrar_detalleKardexCredito(kar);


                        objdocx.RN_Restar_Credito(xxidcli.Trim(), xacuenta);


                        Prod_Krd += 1;

                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add detallekardexcred", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void limpiarForm()
        {

            txt_idcred.Text = "";
            dtp_fechaAbono.Text = "";
            txt_Acuenta.Text = "";
            txt_nombrecliente.Text = "";

        }


        private bool Validar_Antes_Vender()
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();

            //if (lsv_Det.Items.Count == 0) { fil.Show(); ver.Lbl_Msm1.Text = "Debes agregar como minimo un producto al Carrito"; ver.ShowDialog(); fil.Hide(); return false; }
            //if (Convert.ToInt32(lbl_idcliente.Text.Length) < 2) { fil.Show(); ver.Lbl_Msm1.Text = "Te falta agregar un Cliente"; ver.ShowDialog(); fil.Hide(); return false; }
            //if (Cbo_TipoPago.SelectedIndex == -1) { fil.Show(); ver.Lbl_Msm1.Text = "Por favor, Elige un Tipo de Pago"; ver.ShowDialog(); fil.Hide(); Cbo_TipoPago.Focus(); return false; }

            //if (Cbo_TipoDoc.SelectedIndex == -1) { fil.Show(); ver.Lbl_Msm1.Text = "Por favor, Elige un Tipo de Comprobante"; ver.ShowDialog(); fil.Hide(); Cbo_TipoDoc.Focus(); return false; }

            // if(txt_Acuenta.Text.Trim().Length < 2 ) { fil.Show(); ver.Lbl_Msm1.Text = "Debes ingresar el abono"; ver.ShowDialog(); fil.Hide(); txt_Acuenta.Focus(); return false; }


            //if (lbl_server.Text.Trim() == "1" || lbl_server.Text.Trim() == "3")
            //{
            //    if (Cbo_TipoDoc.SelectedIndex == 0 || Cbo_TipoDoc.Text.Trim() == "Nota Venta") { fil.Show(); MessageBox.Show("El documento selecccionado no es un documento valido para la sunat", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            //}
            return true;

        }
        private void Guardar_IngresoCaja()
        {
            //RN_Caja obj = new RN_Caja();
            //En_Caja cja = new En_Caja();

            //try
            //{

            //    cja.FechaCaja = dtp_fecha.Value;
            //    cja.TipoCaja = "Entrada";
            //    cja.Concepto = txt_concepto.Text;
            //    cja.De_Para_Cliente = txt_cliente.Text;
            //    cja.Nro_Doc = txt_nroDoc.Text;
            //    cja.ImportaCaja = Convert.ToDouble(txt_importe.Text);
            //    cja.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
            //    cja.TotalUti = 0;
            //    cja.TipoPago = cbo_tipoPago.Text;
            //    cja.GeneradoPor = "Otros";

            //    obj.RN_Registrar_Mov_Caja(cja);
            //    if(BD_Caja.cajaSaved == true)
            //    {
            //        Frm_Filtro fil = new Frm_Filtro();
            //        Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

            //        fil.Show();
            //        ok.Lbl_msm1.Text = "El ingreso se guardo Correctamente";
            //        ok.ShowDialog();
            //        fil.Hide();

            //        this.Tag = "A";
            //        this.Close();

            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}

        }


        private void Registrar_Abono()
        {
            //RN_KardexCredito obj = new RN_KardexCredito();
            //EN_Kardex_Credito kar = new EN_Kardex_Credito();
            //RN_Documento objdoc = new RN_Documento();

            //DataTable dato = new DataTable();
            //DataTable datodoc = new DataTable();

            //string xidkardex = "";
            //int xitem = 0;

            //double xcredito = 0;
            //double xacuenta = 0;
            //double xcant_Saldo = 0;


            //try
            //{
            //    //xidkardex = Convert.ToString(dato.Rows.Count[0]["IdNotaCred"]);

            //    if (obj.RN_Verificar_Documento_siTieneKardex(xidkardex) == true)
            //    {
            //        dato = obj.RN_Buscar_KardexDetalle_por_Doc(xidkardex.Trim());

            //        if (dato.Rows.Count > 0)
            //        {
            //            xidkardex = Convert.ToString(dato.Rows[0]["IdNotaCred"]);
            //            xitem = dato.Rows.Count;
            //            //leemos los datos del producto 
            //            datodoc = objdoc.RN_Buscar_Creditos(xidkardex.Trim());
            //            xcredito = Convert.ToDouble(datodoc.Rows[0]["Total_Cre"]);

            //            //registramos el Detalle del Kardex:
            //            kar.Idkardex = xidkardex;
            //            kar.Item = xitem + 1;
            //            kar.Docreference = "-";
            //            kar.DetOperacion = "Abono de pago";

            //            //Entrada
            //            kar.FechaAbono = Convert.ToDateTime(dtp_fechaAbono.Text);
            //            kar.TotalCredito = xcredito;
            //            kar.Acuenta = Convert.ToDouble(txt_Acuenta.Text);
            //            kar.SaldoPendiente = 0;

            //            //saldos:   //CALCULOS DE LOS KARDEX VALORIZADOS
            //            kar.SaldoPendiente = xcredito - kar.Acuenta;

            //            obj.RN_Registrar_detalleKardexCredito(kar);

            //            objdoc.RN_Restar_Credito(xidkardex.Trim(), kar.Acuenta);

            //            Prod_Krd += 1;


            //        }


            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}



        }

        private void txt_Acuenta_TextChanged(object sender, EventArgs e)
        {

        }
    }

}

