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
using Microsell_Lite.Informe;




namespace Microsell_Lite.Caja
{
    public partial class Frm_CerrarCaja : Form
    {
        public Frm_CerrarCaja()
        {
            InitializeComponent();
        }

        private void Frm_CerrarCaja_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            buscar_caja_porDia(dtp_FechaHoy.Value);
            Listar_Caja_Deldia();
            Buscar_caja_porBoleta();
            Buscar_caja_porFactura();
            Buscar_caja_porNotaPedido();
            Buscar_caja_porOtrosIngresos();
            Buscar_caja_porAbonos();
            Buscar_caja_porDeposito();
            Buscar_caja_porOtrosIngresos();
            Buscar_caja_porEfectivo();
            Buscar_caja_porTarjetas();
            Buscar_caja_porTarjetaVisa();
            Buscar_caja_porTarjetaMastercard();
            Buscar_caja_porYape();
            Buscar_caja_porPlin();

            Buscar_Salidas_porEfectivo();
            Buscar_Salidas_porDeposito();
            Buscar_Ventas_Acredito();
            Calcular_Ganancias_delDia();
        }

        private void Pnl_Titulo_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario ui = new Utilitario();
            if (e.Button ==MouseButtons.Left )
            {
                ui.Mover_formulario(this);
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public string nombrepc = Environment.MachineName;

        private void Configurar_listView()
        {
            var lis = lsv_caja;

            lis.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;

            lis.Columns.Add("ID Caja", 80, HorizontalAlignment.Left);
            lis.Columns.Add("Tipo Caja", 100, HorizontalAlignment.Left);
            lis.Columns.Add("Tipo Pago", 80, HorizontalAlignment.Left);
            lis.Columns.Add("Importe", 80, HorizontalAlignment.Left);
            lis.Columns.Add("Estado", 80, HorizontalAlignment.Left);

        }

        private void Llenar_ListView(DataTable data)
        {
            lsv_caja.Items.Clear();

            for(int i = 0; i<data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Idcaja"].ToString(), 1);
                list.SubItems.Add(dr["Tipo_Caja"].ToString());
                list.SubItems.Add(dr["TipoPago"].ToString());
                list.SubItems.Add(dr["ImporteCaja"].ToString());
                list.SubItems.Add(dr["EstadoCaja"].ToString());

                lsv_caja.Items.Add(list);
            }
        }

        private void buscar_caja_porDia(DateTime xdia)
        {
            RN_Caja obj = new RN_Caja();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Cajas_Del_Dia(xdia);
            if(dato.Rows.Count > 0)
            {
                Llenar_ListView(dato);
            }
            else
            {
                lsv_caja.Items.Clear();
            }
        }

        private void Listar_Caja_Deldia()
        {

            DataTable dato = new DataTable();
            RN_Cierre_Caja obj = new RN_Cierre_Caja( );

            try
            {
                
                 dato = obj.RN_Listar_Cierre_Caja_delDia(dtp_FechaHoy.Value,"Abierto");
                 if (dato.Rows.Count > 0)
                 {

                    lbl_idcaja.Text = dato.Rows[0]["Id_cierre"].ToString();
                    Lbl_aperturaCaja.Text = dato.Rows[0]["Apertura_Caja"].ToString();
                    Lbl_estado.Text = dato.Rows[0]["Estado_cierre"].ToString();
                    Lbl_fechaCaja.Text = dato.Rows[0]["Fecha_Cierre"].ToString();
                    //lbl_codcaja.Text = dato.Rows[0]["NombreDesktop"].ToString();


                    if (Lbl_estado.Text.Trim() == "Cerrado")
                    {
                        btn_aceptar.Enabled = false;
                    }
                    else
                    {
                        btn_aceptar.Enabled = true; // true puede ser modificable
                    }


                    //if (Lbl_estado.Text.Trim() == "Cerrado")
                    //{
                    //    btn_imprimir.Enabled = true;
                    //}
                    //else
                    //{
                    //    btn_imprimir.Enabled = false;
                    //}



                }
                else
                {
                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Advertencia ver = new Frm_Advertencia();

                    fil.Show();
                    ver.Lbl_msm1.Text = "Por favor, tienes que iniciar caja, para poder acceder al cierre";
                    ver.ShowDialog();
                    fil.Hide();

                    btn_aceptar.Enabled = false;


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message , "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Buscar_caja_porBoleta()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Ventas_PorTipo_Doc("Boleta");

            if(dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);
   
                }
                Lbl_Efectivo_boleta.Text = subImporte.ToString("###0.00");
            }
            else
            {
                Lbl_Efectivo_boleta.Text = "00";
            }
        }

        private void Buscar_caja_porFactura()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Ventas_PorTipo_Doc("Factura");

            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                Lbl_Efectivo_factura.Text = subImporte.ToString("###0.00");
            }
            else
            {
                Lbl_Efectivo_factura.Text = "00";
            }
        }


        private void Buscar_caja_porNotaPedido()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Ventas_PorTipo_Doc("Nota Venta");

            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                Lbl_Efectivo_Notas.Text = subImporte.ToString("###0.00");
            }
            else
            {
                Lbl_Efectivo_Notas.Text = "00";
            }
        }



        private void Buscar_caja_porOtrosIngresos()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;
            double totalIngresos = 0;

            dato = obj.RN_Calcular_Ventas_PorTipo_Doc("Otros");
            //dato = obj.RN_Calcular_Ventas_PorTipo_Pagox("Efectivo", "Deposito");


            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                Lbl_otroIngresoEfectivo.Text = subImporte.ToString("###0.00");
            }
            else
            {
                Lbl_otroIngresoEfectivo.Text = "00";
            }
        }

        //private void Buscar_caja_porOtrosIngresos()
        //{
        //    RN_Cierre_Caja obj = new RN_Cierre_Caja();
        //    DataTable dato = new DataTable();

        //    double subImporte = 0;
        //    double totalIngresos = 0;

        //    // Llamada al método
        //    dato = obj.RN_Calcular_Ventas_PorTipo_Pagox("Efectivo", "Deposito");

        //    // Verificación: Mostrar la cantidad de registros obtenidos
        //    MessageBox.Show("Registros obtenidos: " + dato.Rows.Count);

        //    if (dato.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dato.Rows.Count; i++)
        //        {
        //            DataRow dr = dato.Rows[i];
        //            subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);
        //        }

        //        Lbl_otroIngresoEfectivo.Text = subImporte.ToString("###0.00");
        //    }
        //    else
        //    {
        //        Lbl_otroIngresoEfectivo.Text = "00";
        //    }
        //}




        private void Buscar_caja_porAbonos()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Ventas_PorTipo_Doc("Abono");

            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                Lbl_CreditoAbonado.Text = subImporte.ToString("###0.00");
            }
            else
            {
                Lbl_CreditoAbonado.Text = "00";
            }
        }

        //11/12/22


        private void Buscar_caja_porDeposito()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            //dato = obj.RN_Calcular_Ventas_PorTipo_Doc("Deposito");
            dato = obj.RN_Calcular_Ventas_PorTipo_Pagox("Deposito");

            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                Lbl_Ingreso_Deposito.Text = subImporte.ToString("###0.00");
            }
            else
            {
                Lbl_Ingreso_Deposito.Text = "00";
            }
        }

        private void Buscar_caja_porEfectivo()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Ventas_PorTipo_Pagox("Efectivo");

            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                lblEfectivo.Text = subImporte.ToString("###0.00");
            }
            else
            {
                lblEfectivo.Text = "00";
            }
        }

        private void Buscar_caja_porTarjetas()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Ventas_PorTipo_Pagox("Tarjeta");

            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                lbl_tarjeta.Text = subImporte.ToString("###0.00");
            }
            else
            {
                lbl_tarjeta.Text = "00";
            }
        }

        private void Buscar_caja_porTarjetaVisa()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Ventas_PorTipo_Pagox("Visa");

            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                lblVisa.Text = subImporte.ToString("###0.00");
            }
            else
            {
                lblVisa.Text = "00";
            }
        }


        //2.-Mastercard
        private void Buscar_caja_porTarjetaMastercard()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Ventas_PorTipo_Pagox("Mastercard");

            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                lblMastercard.Text = subImporte.ToString("###0.00");
            }
            else
            {
                lblMastercard.Text = "00";
            }
        }

        //3.-YAPE

        private void Buscar_caja_porYape()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Ventas_PorTipo_Pagox("Yape");

            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                lblYape.Text = subImporte.ToString("###0.00");
            }
            else
            {
                lblYape.Text = "00";
            }
        }

        //4- PLIN
        private void Buscar_caja_porPlin()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Ventas_PorTipo_Pagox("Plin");

            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                lblPlinx.Text = subImporte.ToString("###0.00");
            }
            else
            {
                lblPlinx.Text = "00";
            }
        }



        //agregando caja_portipo de pagos 24-02-23

        private void Buscar_caja_porVisa()
        {
           /* RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;
            dato = obj.
            */

        }

        private void Buscar_Ventas_Acredito()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Ventas_Acredito();

            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                Lbl_TotalCreditos.Text = subImporte.ToString("###0.00");
            }
            else
            {
                Lbl_TotalCreditos.Text = "00";
            }
        }


        private void Buscar_Salidas_porEfectivo()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Gastos_PorTipo_Pago("Efectivo");

            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                Lbl_SalidaEfectivo.Text = subImporte.ToString("###0.00");
            }
            else
            {
                Lbl_SalidaEfectivo.Text = "00";
            }
        }

        

        private void Buscar_Salidas_porDeposito()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Gastos_PorTipo_Pago("Deposito");

            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];
                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                lbl_SalienDeposi.Text = subImporte.ToString("###0.00");

            }
            else
            {
                lbl_SalienDeposi.Text = "00";
            }
        }

        private void Btn_calcular_Click(object sender, EventArgs e)
        {


            double xxtotalingreso = 0;
            double xxtotalegreso = 0;
            double IngresoBruto = 0;

            double VentaTotalNeto = 0;

            double TotalCobranza = 0;

            try
            {

                //// Verificar que los Labels tengan un valor válido antes de hacer los cálculos
                //if (string.IsNullOrWhiteSpace(Lbl_otroIngresoEfectivo.Text) || Lbl_otroIngresoEfectivo.Text == "00")
                //{
                //    // Si el Label está vacío o tiene "00", mostrar un mensaje o asignar un valor predeterminado
                //    MessageBox.Show("No se ha calculado el otro ingreso efectivo. Verifique los datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return; // Detener la ejecución si el dato es inválido
                //}
                //total de ingreso bruto:

                IngresoBruto = Convert.ToDouble(Lbl_Efectivo_boleta.Text) + Convert.ToDouble(Lbl_Efectivo_factura.Text) +  Convert.ToDouble(Lbl_Efectivo_Notas.Text) + Convert.ToDouble(Lbl_otroIngresoEfectivo.Text) + Convert.ToDouble(Lbl_Ingreso_Deposito.Text);
                Lbl_totalIngreso.Text = IngresoBruto.ToString("###0.00");
                xxtotalingreso = IngresoBruto + Convert.ToDouble(Lbl_aperturaCaja.Text);

                lbl_totalingre_bruto.Text = xxtotalingreso.ToString("###0.00");

                //salids:
                xxtotalegreso = Convert.ToDouble(Lbl_SalidaEfectivo.Text);
                Lbl_Total_Salida.Text = Convert.ToString(xxtotalegreso + Convert.ToDouble(lbl_SalienDeposi.Text));
                lbl_xTotalEgreso.Text = Convert.ToString(xxtotalegreso + Convert.ToDouble(lbl_SalienDeposi.Text));


                //ahora el neto a pagar:
                VentaTotalNeto = Convert.ToDouble(lbl_totalingre_bruto.Text) - Convert.ToDouble(Lbl_Total_Salida.Text);
                lbl_IngresoEfectivo_Neto.Text = VentaTotalNeto.ToString("###0.00");

                //resumen de cobranza medios de pagos:
                TotalCobranza = Convert.ToDouble(lblEfectivo.Text) + Convert.ToDouble(lbl_tarjeta.Text)  + Convert.ToDouble(lblYape.Text) + Convert.ToDouble(lblPlinx.Text)/* + Convert.ToDouble(Lbl_otroIngresoEfectivo.Text)*/;
                lblTotalCobranza.Text = TotalCobranza.ToString("###0.00");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



        }

        private void txt_totalEntregar_KeyDown(object sender, KeyEventArgs e)
        {
            //if(e.KeyCode == Keys.Enter)
            //{
            //    double saldonext = 0;
            //    saldonext = Convert.ToDouble(lbl_IngresoEfectivo_Neto.Text) - Convert.ToDouble(txt_totalEntregar.Text);
            //    txt_SaldoNext.Text = saldonext.ToString("###0.00");
            //}
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
           

            Guardar_cierre_caja();


        }


        private void Guardar_cierre_caja()
        {

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ad = new Frm_Advertencia();

            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            EN_Cierre_Caja ci = new EN_Cierre_Caja();
            RN_Caja objca = new RN_Caja();
            string idcaja = "";
            double totalOtrosIngr;
            totalOtrosIngr =Convert.ToDouble( Lbl_otroIngresoEfectivo.Text) + Convert.ToDouble(Lbl_Ingreso_Deposito.Text);
            //double xtotalEntregrar = 0;
            
            //xtotalEntregrar = Convert.ToDouble(txt_totalEntregar.Text);

            // Validar que txt_totalEntregar tenga un valor numérico válido
            double xtotalEntregrar = 0;
            if (!double.TryParse(txt_totalEntregar.Text, out xtotalEntregrar))
            {
                // Si no es válido, mostramos mensaje y retornamos
                fil.Show();
                ad.Lbl_msm1.Text = "Debe ingresar el Monto de Dinero a entregar al Administrador de Tienda";
                ad.ShowDialog();
                fil.Hide();
                txt_totalEntregar.Focus();
                return;
            }

            try
            {
                //if(xtotalEntregrar > 0)
                //{
                //    ci.TotalEntregado = xtotalEntregrar;//Convert.ToDouble(txt_totalEntregar.Text);
                //}
                //else
                //{
                //    fil.Show();
                //    ad.Lbl_msm1.Text = "Debe ingresar el Monto de Dinero a entregar al Administrador de Tienda";
                //    ad.ShowDialog();
                //    fil.Hide();

                //    return;
                //}

                ci.Idcierre = lbl_idcaja.Text;
                ci.AperturaCaja = Convert.ToDouble(Lbl_aperturaCaja.Text);
                ci.TotalIngreso = Convert.ToDouble(Lbl_totalIngreso.Text);
                ci.TotalEgreso = Convert.ToDouble(Lbl_Total_Salida.Text);
                ci.IdUsu = Convert.ToInt32 ( Cls_Libreria.IdUsu);
                ci.TodoDeposito = Convert.ToDouble(Lbl_Ingreso_Deposito.Text);
                ci.TotalGanancia = Convert.ToDouble(Lbl_UtilidadTotal.Text);
                if ( xtotalEntregrar > 0)
                {
                    ci.TotalEntregado = xtotalEntregrar;//Convert.ToDouble(txt_totalEntregar.Text);
                }
                else
                {
                    fil.Show();
                    ad.Lbl_msm1.Text = "Debe ingresar el Monto de Dinero a entregar al Administrador de Tienda";
                    ad.ShowDialog();
                    fil.Hide();
                    txt_totalEntregar.Focus();
                    return;
                }

                //ci.TotalEntregado = xtotalEntregrar;//Convert.ToDouble(txt_totalEntregar.Text);
                ci.SaldoSiguiente = Convert.ToDouble(txt_SaldoNext.Text);
                ci.TotalBoleta = Convert.ToDouble(Lbl_Efectivo_boleta.Text);
                ci.TotalFactura = Convert.ToDouble(Lbl_Efectivo_factura.Text);
                ci.TotalNota = Convert.ToDouble( Lbl_Efectivo_Notas.Text);
                ci.TotalCreditoCobrado = Convert.ToDouble(Lbl_CreditoAbonado.Text);
                ci.TotalCreditoEmitido = Convert.ToDouble( Lbl_TotalCreditos.Text);
                ci.TotalEfectivo = Convert.ToDouble(lblEfectivo.Text);
                ci.TotalYape = Convert.ToDouble(lblYape.Text);
                ci.TotalPlin = Convert.ToDouble(lblPlinx.Text);
                ci.TotalTarjetasCred = Convert.ToDouble(lbl_tarjeta.Text);
                ci.TotalOtrosIngresos = totalOtrosIngr;
                //se agrega parametro en tabla cierrecaja y sp - para otrosingreso:

                //ci.NomnbreDesktop = lbl_codcaja.Text;
                

                obj.RN_Registrar_Cierrede_Caja(ci);
                if(BD_Cierre_Caja.saved == true)
                {

                    //actualizamos el campo: modoCierre
                    for(int i = 0; i < lsv_caja.Items.Count; i++)
                    {
                        var lis = lsv_caja.Items[i];
                        idcaja =lis.SubItems[0].Text;

                        objca.RN_CambiarModo_Caja(idcaja);
                        
                        
                    }

                    //btn_imprimir.Enabled = true;
                   

                    Frm_Print_Informe_Almacen inf = new Frm_Print_Informe_Almacen();
                    Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
                         
                    fil.Show();
                    inf.NroDoc = lbl_idcaja.Text;
                    inf.tipoDoc = "cierrecaja";
                    inf.ShowDialog();
                    fil.Hide();

                    fil.Show();
                    ok.Lbl_msm1.Text = "El Cierre de Caja se ha realizado Exitosamente";
                    ok.ShowDialog();
                    fil.Hide();

                    this.Close();

                    //MessageBox.Show("El cierre de caja se ha Guardado correctamente");
                  


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        private void Calcular_Ganancias_delDia()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Ganancias_Deldia();

            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["TotalUti"]);

                }
                Lbl_UtilidadTotal.Text = subImporte.ToString("###0.00");
            }
            else
            {
                Lbl_UtilidadTotal.Text = "00";
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            //Frm_Print_ReporteCaja rep = new Frm_Print_ReporteCaja();

            
           
            //    btn_imprimir.Enabled = Enabled;

            //    fil.Show();
            //    rep.Tag = lbl_idcaja.Text;
            //    rep.Imprimir_ReporteCaja();
            //    rep.lbl_nroDoc.Text = lbl_idcaja.Text;
            //    rep.ShowDialog();
            //    fil.Hide();
          

        
        }

        private void Registrar_Archivos_Temporales()
        {
            // para impresion hoja formato y no se desborde al registrar los productos en formato 

            /*
            RN_Temporal obj = new RN_Temporal();
            EN_Temporal tem = new EN_Temporal();
            EN_Det_Temporal det = new EN_Det_Temporal();


            string dias = dtp_FechaEmi.Value.Day.ToString();
            string mes = dtp_FechaEmi.Value.Month.ToString();
            string año = dtp_FechaEmi.Value.Year.ToString();
            //string fechacompleta = "";

            int totalEspacio = 0;
            int totalFila = lsv_Det.Items.Count;

            //PARA GUARDAR EN DISCO D :
            string RutaQr = "D:\\CPE\\QR_TEMP\\" + txt_NroDoc.Text + ".BMP";
            GenerarQR(Cbo_TipoDoc.Text, lbl_TotalPagar.Text, txt_cliente.Text, txt_NroDoc.Text, RutaQr);

            //pic_qr.Load(RutaQr);

            try
            {
                tem.IdTemporal = txt_NroDoc.Text;
                tem.FechaEmi = dtp_FechaEmi.Value.ToString();
                tem.Nomcliente = txt_cliente.Text;
                tem.Ruc = lbl_dni_ruc.Text;
                tem.Direccion = lbl_direccion.Text;
                tem.Subtotal = lbl_subtotal.Text;
                tem.Igv = lbl_igv.Text;
                tem.Total = lbl_TotalPagar.Text;
                tem.TipoPago = Cbo_TipoPago.Text;
                tem.NroOperacion = txt_NroOperac.Text;
                tem.Efectivo = tx_efectivo.Text;
                tem.Vuelto = lbl_vlto.Text;
                tem.Sonletra = lbl_son.Text;
                tem.Vendedor = Cls_Libreria.Nombre;
                tem.CodigoQr = Convertir_Imagen_Bytes(pic_qr.Image);

                //FE:
                if (Cbo_TipoDoc.Text.Trim() == "Factura")
                {
                    tem.Tipocomprobante = "FACTURA ELECTRONICA";
                }
                else if (Cbo_TipoDoc.Text.Trim() == "Boleta")
                {
                    tem.Tipocomprobante = "BOLETA VENTA ELECTRONICA";
                }
                else //se añadio 
                {
                    tem.Tipocomprobante = "NOTA VENTA";
                }

                tem.Hash_cpe = TXTHASH_CPE.Text;
                tem.MotivoEmision = "-";
                tem.TipoPago = Cbo_TipoPago.Text;

                obj.RN_Registrar_Temporal(tem);



                if (BD_Temporal.saved == true)
                {
                    //guardar el detalle        for (int i =0; i < lsv_Det.Items.Count; i++)
                    for (int i = 0; i < lsv_Det.Items.Count; i++)
                    {
                        var lis = lsv_Det.Items[i];

                        det.IdTempo = txt_NroDoc.Text;
                        det.CodProd = lis.SubItems[0].Text;
                        det.Canti = lis.SubItems[2].Text;
                        det.Producto = lis.SubItems[1].Text;
                        det.Precio = lis.SubItems[3].Text;
                        det.Importe = lis.SubItems[4].Text;
                        obj.RN_Registrar_Detalle_Temporal(det);

                    }

                    int veces = 0;
                    totalEspacio = 11 - totalFila; //8 PARA LOS ESPACIOS EN HOJA
                    if (totalEspacio < 11)
                    {
                        //for (int x = 1; x <= totalEspacio; x++) //PROBAR SINO COMENTARLO
                        {
                            det.IdTempo = txt_NroDoc.Text;
                            det.CodProd = "";
                            det.Canti = "";
                            det.Producto = "";
                            det.Precio = "";
                            det.Importe = "";

                            obj.RN_Registrar_Detalle_Temporal(det);
                        }
                        veces += 1;
                    }


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            */

        }

        private void btn_reload_Click(object sender, EventArgs e)
        {

        }

        private void txt_totalEntregar_TextChanged(object sender, EventArgs e)
        {
            txt_totalEntregar.Text = txt_totalEntregar.Text.Replace(",", ".");
            //txt_totalEntregar.se = txt_totalEntregar.Text.Length;
            double totalEntregar;
            double ingresoNeto;
            // Validamos primero si ambos valores se pueden convertir correctamente
            if (double.TryParse(txt_totalEntregar.Text, out totalEntregar) &&
                double.TryParse(lbl_IngresoEfectivo_Neto.Text, out ingresoNeto))
            {
                double saldonext = ingresoNeto - totalEntregar;
                txt_SaldoNext.Text = saldonext.ToString("###0.00");
            }
            else
            {
                // Opcional: puedes mostrar 0 o limpiar el resultado si la entrada no es válida
                txt_SaldoNext.Text = "";
            }

            //try
            //{
            //    double saldonext = 0;
            //    saldonext = Convert.ToDouble(lbl_IngresoEfectivo_Neto.Text) - Convert.ToDouble(txt_totalEntregar.Text);
            //    txt_SaldoNext.Text = saldonext.ToString("###0.00");
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}

        }

        private void txt_totalEntregar_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }
    }
}
