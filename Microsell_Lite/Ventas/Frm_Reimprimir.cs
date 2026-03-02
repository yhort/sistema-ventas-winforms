using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsell_Lite.Compras;
using Gma.QrCodeNet.Encoding;
using QRCoder;
using ThoughtWorks.QRCode;
using ThoughtWorks.QRCode.Codec;
//importar:
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using System.IO;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Productos;
using Microsell_Lite.Cliente;
using Microsell_Lite.Informe;
using Microsell_Lite.Ventas;


namespace Microsell_Lite.Ventas
{
    public partial class Frm_Reimprimir : Form
    {
        public Frm_Reimprimir()
        {
            InitializeComponent();
        }

        private void Frm_Ventana_Ventas_Load(object sender, EventArgs e)
        {

            Configurar_listView();
            Llenar_Combo_docs();

            Cbo_TipoPago.SelectedIndex = 0; //para colocar cualquier textobx se inicie en primera opcion
            //Cbo_TipoDoc.SelectedIndex();
            Cbo_TipoDoc.SelectedIndex = 1;

        }

        private void Configurar_listView()
        {
            var lis = lsv_Det;

            lis.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("ID producto", 80, HorizontalAlignment.Left); //0
            lis.Columns.Add("Descripcion producto", 377, HorizontalAlignment.Left);  //1
            lis.Columns.Add("cantidad", 80, HorizontalAlignment.Left);  //2
            lis.Columns.Add("precio Unit", 90, HorizontalAlignment.Center);  //3
            lis.Columns.Add("Importe", 90, HorizontalAlignment.Center);  //4
            lis.Columns.Add("Tipo Producto", 0, HorizontalAlignment.Right);  //5
            lis.Columns.Add("Und", 0, HorizontalAlignment.Right);  //6
            lis.Columns.Add("Utilidad Unit", 0, HorizontalAlignment.Right);  //7
            lis.Columns.Add("Total Utilidad", 0, HorizontalAlignment.Right);  //8


            //para facturacion electronica 2023:

            lis.Columns.Add("Afect. Igv", 0, HorizontalAlignment.Left);  //9
            lis.Columns.Add("PreUni sinIgv", 0, HorizontalAlignment.Left);  //10
            lis.Columns.Add("SubTotal SinIgv", 0, HorizontalAlignment.Left);  //11
            lis.Columns.Add("Igv", 0, HorizontalAlignment.Left);  //12
            lis.Columns.Add("Tipo", 0, HorizontalAlignment.Left);  //13
            lis.Columns.Add("CodTipo_Afecto", 0, HorizontalAlignment.Left);  //14

        }


        private void Llenar_Combo_docs()
        {
            ////metodo para que nos aparezca en automaticas opciones a elegir, en un boton.
            //se descomento 15/07/22


            RN_TipoDoc obj = new RN_TipoDoc();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Doc_Especial();
            if (dato.Rows.Count > 0)
            {
                var cbo = Cbo_TipoDoc;

                cbo.DataSource = dato;
                cbo.DisplayMember = "Documento";
                cbo.ValueMember = "Id_Tipo";
                //cbo.SelectedIndex = -1;

            }
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {

            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }

        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_Nuevo_buscarProd_Click(object sender, EventArgs e)
        {

        }


        private void Agregar_Productos_alCarrito(string xidprod, string xnomprod, double xcant, double xprecio, double ximporte, string xund, string xtipoProd, double xutili_unit)
        {
            try
            {

                if (lsv_Det.Items.Count == 0)
                {
                    ListViewItem item = new ListViewItem();
                    item = lsv_Det.Items.Add(xidprod);
                    item.SubItems.Add(xnomprod.Trim());
                    item.SubItems.Add(xcant.ToString());
                    item.SubItems.Add(xprecio.ToString("###0.00"));
                    item.SubItems.Add(ximporte.ToString("###0.00"));
                    item.SubItems.Add(xtipoProd.ToString());
                    item.SubItems.Add(xund.ToString());
                    item.SubItems.Add(xutili_unit.ToString("###0.00"));
                    item.SubItems.Add(xutili_unit.ToString("###0.00"));

                    Calcular();
                    lsv_Det.Focus();
                    lsv_Det.Items[0].Selected = true;
                    pnl_sinProd.Visible = false;
                }
                else
                {
                    //validar de que el producvto no se ingrese dos veces
                    for (int i = 0; i < lsv_Det.Items.Count; i++)
                    {
                        if (lsv_Det.Items[i].Text.Trim() == xidprod.Trim())
                        {
                            MessageBox.Show("El Producto ya fue Agregado al Carrito de Compras", "ADveretencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    //lo añadimos:
                    ListViewItem item = new ListViewItem();
                    item = lsv_Det.Items.Add(xidprod);
                    item.SubItems.Add(xnomprod.Trim());
                    item.SubItems.Add(xcant.ToString());
                    item.SubItems.Add(xprecio.ToString("###0.00"));
                    item.SubItems.Add(ximporte.ToString("###0.00"));
                    item.SubItems.Add(xtipoProd.ToString());
                    item.SubItems.Add(xund.ToString());
                    item.SubItems.Add(xutili_unit.ToString("###0.00"));
                    item.SubItems.Add(xutili_unit.ToString("###0.00"));

                    Calcular();
                    lsv_Det.Focus();
                    lsv_Det.Items[0].Selected = true;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Calcular()
        {


            double xtotal = 0;
            double xcant = 0;

            double xprecio = 0;
            double ximporte = 0;
            double xsubtotal = 0;
            double xigv = 0;
            double xuti_unit = 0;
            double ximport_Uti = 0;
            double xTotalGanancia = 0;

            //*****Para FE.******

            double igvProd = 0;
            double subtotal_sinIgv = 0;
            double xsubtotal_sinIgv = 0;
            double preUnit_sinIgv = 0;
            double xigv_total = 0;

            double xcantMetro = 0;
            double xprecioMetro = 0;
            double ximporteMetro = 0;
            double ximport_UtiMetro = 0;
            string xund = "";

            //para detraccion: 
            double detraccion = 0;
            double tasaDetraccion = 0.04;

            string xafecto = "";

            //probando para tipos de medida:
            string xpaquete = "";
            string klg = "";

            // Variables para acumular los totales de productos gravados y exonerados
            double subtotalGravado = 0;
            double igvGravado = 0;
            double totalGravado = 0;
            double subtotalExonerado = 0;
            double totalExonerado = 0;

            for (int i = 0; i < lsv_Det.Items.Count; i++)
            {
                xund = lsv_Det.Items[i].SubItems[6].Text;

                //xafecto = lsv_Det.Items[i].SubItems[9].Text;
                if (lsv_Det.Items[i].SubItems[9].Text == "Exonerado")
                {
                    // Cuando el producto es exonerado

                    // Cálculos para productos exonerados: 
                    xcant = Convert.ToDouble(lsv_Det.Items[i].SubItems[2].Text);
                    xprecio = Convert.ToDouble(lsv_Det.Items[i].SubItems[3].Text);

                    // Cálculo del importe para productos exonerados (sin IGV)
                    ximporte = xprecio * xcant;
                    lsv_Det.Items[i].SubItems[4].Text = ximporte.ToString("###0.00");

                    // Utilidad de productos exonerados
                    xuti_unit = Convert.ToDouble(lsv_Det.Items[i].SubItems[7].Text);
                    ximport_Uti = xuti_unit * xcant;

                    // Total general para productos exonerados (sin IGV)
                    xtotal += ximporte;

                    // Total de ganancia para productos exonerados
                    xTotalGanancia += ximport_Uti;

                    // Subtotal sin IGV para productos exonerados
                    preUnit_sinIgv = xprecio;  // No se divide entre 1.18 ya que es exonerado
                    lsv_Det.Items[i].SubItems[10].Text = preUnit_sinIgv.ToString("###0.00");

                    // Subtotal sin IGV
                    subtotalExonerado += preUnit_sinIgv * xcant;
                    lsv_Det.Items[i].SubItems[11].Text = (preUnit_sinIgv * xcant).ToString("###0.00");

                    // IGV para productos exonerados (se establece en 0)
                    lsv_Det.Items[i].SubItems[12].Text = "0.00";

                    // Totales para productos exonerados
                    totalExonerado += ximporte;


                }
                else if (lsv_Det.Items[i].SubItems[9].Text == "Gravado")
                {
                    // Cálculos para productos gravados:
                    xcant = Convert.ToDouble(lsv_Det.Items[i].SubItems[2].Text);
                    xprecio = Convert.ToDouble(lsv_Det.Items[i].SubItems[3].Text);

                    // Cálculo del importe para productos gravados (con IGV)
                    ximporte = xprecio * xcant;
                    lsv_Det.Items[i].SubItems[4].Text = ximporte.ToString("###0.00");

                    // Utilidad de productos gravados
                    xuti_unit = Convert.ToDouble(lsv_Det.Items[i].SubItems[7].Text);
                    ximport_Uti = xuti_unit * xcant;

                    // Total general para productos gravados (con IGV)
                    xtotal += ximporte;

                    // Total de ganancia para productos gravados
                    xTotalGanancia += ximport_Uti;

                    // Subtotal sin IGV para productos gravados
                    preUnit_sinIgv = xprecio / 1.18;
                    lsv_Det.Items[i].SubItems[10].Text = preUnit_sinIgv.ToString("###0.00");//se quitaron 0000

                    //subtotal sin igv modo codi
                    subtotal_sinIgv = preUnit_sinIgv * xcant;
                    lsv_Det.Items[i].SubItems[11].Text = (preUnit_sinIgv * xcant).ToString("###0.00");



                    // Subtotal sin IGV
                    //subtotalGravado += preUnit_sinIgv * xcant;
                    //lsv_Det.Items[i].SubItems[11].Text = (preUnit_sinIgv * xcant).ToString("###0.00");

                    // IGV para productos gravados
                    //igvProd = subtotalGravado * 0.18;
                    igvProd = subtotal_sinIgv * 0.18;
                    lsv_Det.Items[i].SubItems[12].Text = igvProd.ToString("###0.00");

                    ////Pie de la FE para Sunat//
                    //xsubtotal_sinIgv = xsubtotal_sinIgv + Convert.ToDouble(lsv_Det.Items[i].SubItems[12].Text);

                    // Totales para productos gravados
                    totalGravado += ximporte;
                    xigv_total += igvProd;
                }

                //cuando el producto es exonerado:

                /*
                xcant = Convert.ToDouble(lsv_Det.Items[i].SubItems[2].Text);
                xprecio = Convert.ToDouble(lsv_Det.Items[i].SubItems[3].Text);


                //calculo:
                ximporte = xprecio * xcant;
                lsv_Det.Items[i].SubItems[4].Text = ximporte.ToString("###0.00");


                //utilidad:
                xuti_unit = Convert.ToDouble(lsv_Det.Items[i].SubItems[7].Text);
                ximport_Uti = xuti_unit * xcant;


                //caluclo del total:
                xtotal = xtotal + Convert.ToDouble(lsv_Det.Items[i].SubItems[4].Text);

                xTotalGanancia = xTotalGanancia + Convert.ToDouble(lsv_Det.Items[i].SubItems[8].Text);


                //*****CALCULO PARA SUNAT :****


                preUnit_sinIgv = xprecio / 1.18;
                lsv_Det.Items[i].SubItems[10].Text = preUnit_sinIgv.ToString("###0.000000");//00




                //subtotal sin igv:
                subtotal_sinIgv = preUnit_sinIgv * xcant;
                lsv_Det.Items[i].SubItems[11].Text = subtotal_sinIgv.ToString("###0.00");

                //Calculamos el igv:
                igvProd = subtotal_sinIgv * 0.18;
                lsv_Det.Items[i].SubItems[12].Text = igvProd.ToString("###0.00");


                //Pie de la FE para Sunat//
                xsubtotal_sinIgv = xsubtotal_sinIgv + Convert.ToDouble(lsv_Det.Items[i].SubItems[12].Text);

                 */

                //xcantMetro = Convert.ToDouble(lsv_Det.Items[i].SubItems[14].Text);
                //xprecioMetro = Convert.ToDouble(lsv_Det.Items[i].SubItems[15].Text);

                ////Calculo metros:
                //ximporteMetro = xprecioMetro * xcantMetro;
                //lsv_Det.Items[i].SubItems[16].Text = ximporteMetro.ToString("###0.00");

                ////utilidad x metro:
                //xuti_unit = Convert.ToDouble(lsv_Det.Items[i].SubItems[7].Text);
                //ximport_UtiMetro = xuti_unit * xcantMetro;

                ////caluclo del total:
                //xtotal = xtotal + Convert.ToDouble(lsv_Det.Items[i].SubItems[16].Text);

                //xTotalGanancia = xTotalGanancia + Convert.ToDouble(lsv_Det.Items[i].SubItems[8].Text);


            }
            //calcular el IGV: IVA
            /*
            xsubtotal = xtotal / 1.18;
            xigv = xsubtotal * 0.18;

            lbl_subtotal.Text = xsubtotal.ToString("###0.00");
            lbl_igv.Text = xigv.ToString("###0.00");
            lbl_TotalPagar.Text = xtotal.ToString("###0.00");


            tx_efectivo.Text = xtotal.ToString("###0.00"); 

            lbl_totalGanancia.Text = xTotalGanancia.ToString("###0.00");

            lbl_son.Text = Numalet.ToString(lbl_TotalPagar.Text);
            let.LetraCapital = chkCapital.Checked;
            if (!actualizado) ActualizarCong();
            */

            //*************Totales del pie  FE para Sunat******************//
            /*
            lbl_subtotalGravado.Text = xsubtotal_sinIgv.ToString("###0.00");
            lbl_igvgravado.Text = xigv_total.ToString("###0.00");
            double totalGravado = xsubtotal_sinIgv + xigv_total;
            lbl_totalGravado.Text = totalGravado.ToString("###0.00");
            */
            // Cálculos finales de totales
            xsubtotal = subtotal_sinIgv/*subtotalGravado*/ + subtotalExonerado;  // Suma de los subtotales gravados y exonerados
            xigv = xigv_total;  // Solo el IGV de productos gravados

            //mas detallae 
            lbl_subtotal_sinIgv.Text = subtotal_sinIgv.ToString("###0.00");

            lbl_subtotal.Text = xsubtotal.ToString("###0.00");
            lbl_igv.Text = xigv.ToString("###0.00");
            lbl_TotalPagar.Text = xtotal.ToString("###0.00");

            tx_efectivo.Text = xtotal.ToString("###0.00");

            lbl_totalGanancia.Text = xTotalGanancia.ToString("###0.00");

            lbl_son.Text = Numalet.ToString(lbl_TotalPagar.Text);
            let.LetraCapital = chkCapital.Checked;
            if (!actualizado) ActualizarCong();

            // Totales del pie FE para Sunat
            //lbl_subtotalGravado.Text = subtotalGravado.ToString("###0.00");
            lbl_igvgravado.Text = xigv_total.ToString("###0.00");
            double totalGravadoFinal = subtotalGravado + xigv_total;

            //dividimos el total entre 1.18
            //double xsubtotalxx = totalGravadoFinal / 1.18;
            //lbl_subtotalGravado.Text = xsubtotalxx.ToString("###0.00");

            lbl_totalGravado.Text = totalGravadoFinal.ToString("###0.00");
            lbl_TotalItem.Text = lsv_Det.Items.Count.ToString();
            lbl_TotalExonerado.Text = totalExonerado.ToString("###0.00");

            //detraccion = xtotal * tasaDetraccion;
            //lbl_detrac.Text = detraccion.ToString("###0.00");

            //double xtotal = 0;
            //double xcant = 0;
            //double xprecio = 0;
            //double ximporte = 0;
            //double xsubtotal = 0;
            //double xigv = 0;
            //double xuti_unit = 0;
            //double ximport_Uti = 0;
            //double xTotalGanancia = 0;

            //for (int i = 0; i < lsv_Det.Items.Count; i++)
            //{
            //    xcant = Convert.ToDouble(lsv_Det.Items[i].SubItems[2].Text);
            //    xprecio = Convert.ToDouble(lsv_Det.Items[i].SubItems[3].Text);

            //    //calculo:
            //    ximporte = xprecio * xcant;
            //    lsv_Det.Items[i].SubItems[4].Text = ximporte.ToString("###0.00");

            //    //utilidad:
            //    xuti_unit = Convert.ToDouble(lsv_Det.Items[i].SubItems[7].Text);
            //    ximport_Uti = xuti_unit * xcant;


            //    //caluclo del total:
            //    xtotal = xtotal + Convert.ToDouble(lsv_Det.Items[i].SubItems[4].Text);

            //    xTotalGanancia = xTotalGanancia + Convert.ToDouble(lsv_Det.Items[i].SubItems[8].Text);

            //}
            ////calcular el IGV: IVA
            //xsubtotal = xtotal / 1.18;
            //xigv = xsubtotal * 0.18;
            //lbl_subtotal.Text = xsubtotal.ToString("###0.00");
            //lbl_igv.Text = xigv.ToString("###0.00");
            //lbl_TotalPagar.Text = xtotal.ToString("###0.00");




            ////tx_efectivo.Text = xtotal.ToString("###0.00");

            ////cacular los vueltos en 1 medio de pago:

            ///*
            //try
            //{

            //    xvuelto = Convert.ToDouble( txImporte.Text) - xtotal;
            //    txVuelto.Text = xvuelto.ToString("###0.00");

            //    txImporte.Text = ximporte.ToString("###0.00");

            //    //Vlto_Import = Convert.ToDouble(txImporte.Text) - Convert.ToDouble(lbl_TotalPagar.Text);
            //    //Precom_Sol.ToString("###0.00");
            //    //txVuelto.Text = Vlto_Import.ToString("###0.00");

            //}
            //catch (Exception ex)
            //{
            //    string sms = ex.Message;
            //}*/

            //lbl_totalGanancia.Text = xTotalGanancia.ToString("###0.00");
            //lbl_son.Text = Numalet.ToString(lbl_TotalPagar.Text);
            //let.LetraCapital = chkCapital.Checked;
            //if (!actualizado) ActualizarCong();


        }

        Numalet let = new Numalet();
        Boolean actualizado = false;

        private void ActualizarCong()
        {
            actualizado = true;
            chkCapital.Checked = let.LetraCapital;
            if (lbl_son.Text.Length > 0)
            {
                lbl_son.Text = let.ToCustomString(lbl_TotalPagar.Text);
                actualizado = false;
            }
        }

        private void bt_add_Click(object sender, EventArgs e)
        {

        }

        private void bt_editPre_Click(object sender, EventArgs e)
        {

        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Sino sino = new Frm_Sino();

            if (lsv_Det.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar el Producto a Quitar", "Editar Precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                fil.Show();
                sino.Lbl_msm1.Text = "Estas Seguro de Quitar este producto del Carrito?";
                sino.ShowDialog();
                fil.Hide();

                if (sino.Tag.ToString() == "Si")
                {
                    int i;
                    var lis = lsv_Det.SelectedItems[0];
                    for (i = lsv_Det.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        lsv_Det.Items.Remove(lsv_Det.SelectedItems[i]);
                    }
                    Calcular();
                }

            }
        }

        private void lbl_BusClien_Click(object sender, EventArgs e)
        {
            Frm_Listadocliente lis = new Frm_Listadocliente();
            Frm_Filtro fil = new Frm_Filtro();

            fil.Show();
            Frm_Listadocliente.tipo = txt_cliente.Text;
            lis.ShowDialog();
            fil.Hide();

            if (lis.Tag.ToString() == "A")
            {
                lbl_idcliente.Text = lis.lbl_id.Text;
                txt_cliente.Text = lis.lbl_nom.Text;
                Leer_Datos_DelCliente(lbl_idcliente.Text);
            }
        }


        private void Leer_Datos_DelCliente(string idprove)
        {
            //manda el id cliente- 
            RN_Cliente obj = new RN_Cliente();
            DataTable data = new DataTable();

            double xlimit_cred = 0;

            try
            {
                data = obj.RN_buscar_Cliente(idprove, "Activo");
                if (data.Rows.Count > 0)
                {
                    lbl_dni_ruc.Text = Convert.ToString(data.Rows[0]["DNI"]);
                    lbl_direccion.Text = Convert.ToString(data.Rows[0]["Direccion"]);
                    xlimit_cred = Convert.ToDouble(data.Rows[0]["Limit_Credit"]);
                    lbl_Limit_Cred.Text = xlimit_cred.ToString("###0.00");

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private bool Validar_Antes_Vender()
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (lsv_Det.Items.Count == 0) { fil.Show(); ver.Lbl_msm1.Text = "Debes agregar como minimo un producto al Carrito"; ver.ShowDialog(); fil.Hide(); return false; }
            if (Convert.ToInt32(lbl_idcliente.Text.Length) < 2) { fil.Show(); ver.Lbl_msm1.Text = "Te falta agregar un Cliente"; ver.ShowDialog(); fil.Hide(); return false; }
            if (Cbo_TipoPago.SelectedIndex == -1) { fil.Show(); ver.Lbl_msm1.Text = "Por favor, Elige un Tipo de Pago"; ver.ShowDialog(); fil.Hide(); Cbo_TipoPago.Focus(); return false; }

            if (Cbo_TipoDoc.SelectedIndex == -1) { fil.Show(); ver.Lbl_msm1.Text = "Por favor, Elige un Tipo de Comprobante"; ver.ShowDialog(); fil.Hide(); Cbo_TipoDoc.Focus(); return false; }

            //if (txt_NroOperac.Text.Trim().Length <2) { fil.Show(); ver.Lbl_Msm1.Text = "Debes ingresar N° Referencia"; ver.ShowDialog(); fil.Hide(); txt_NroOperac.Focus(); return false; }

            return true;

        }

        private void btn_procesar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
           
            

            //impresiones ticket
            Frm_Print_NotaVenta nota = new Frm_Print_NotaVenta();
            //Frm_Print_Boleta boleta = new Frm_Print_Boleta();
            //Frm_Print_Factura fac = new Frm_Print_Factura();


            int idempresa = Cls_Libreria.Idempresa;

            Registrar_Archivos_Temporales();

            if (Cbo_TipoDoc.SelectedIndex == 0)
            {

                if (Cbo_TipoDoc.Text == "Nota Venta" && idempresa == 1)
                {

                    fil.Show();
                    //nota.Tag = txt_NroDoc.Text;
                    //nota.Imprimir_NotaVenta_Ticket();
                    nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    nota.Tag = txt_NroDoc.Text; //prueba
                    nota.Imprimir_NotaVenta_Ticket();//prueba
                                                     //nota.ShowDialog();//probando con comen
                    fil.Hide();
                    Limpiar_todo();
                    pnl_sinProd.Visible = true;



                }

                else if (Cbo_TipoDoc.Text == "Nota Venta" && idempresa == 2)
                {
                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    nota.Imprimir_NotaVenta_Ticket_GermanEIRL();
                    nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    nota.ShowDialog();
                    fil.Hide();
                    Limpiar_todo();
                    pnl_sinProd.Visible = true;
                }
                else if (Cbo_TipoDoc.Text == "Nota Venta" && idempresa == 3)
                {
                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    nota.Imprimir_NotaVenta_Ticket_Airlee();//crear rpt notaventa
                    nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    nota.ShowDialog();
                    fil.Hide();
                    Limpiar_todo();
                    pnl_sinProd.Visible = true;
                }
                else if (Cbo_TipoDoc.Text == "Nota Venta" && idempresa == 4)
                {
                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    nota.Imprimir_NotaVenta_Ticket_TurbInject();//crear rpt notaventa
                    nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    nota.ShowDialog();
                    fil.Hide();
                    Limpiar_todo();
                    pnl_sinProd.Visible = true;
                }
                else if (Cbo_TipoDoc.Text == "Nota Venta" && idempresa == 5)
                {
                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    nota.Imprimir_NotaVenta_Ticket_Mavaqui();//crear rpt notaventa
                    nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    nota.ShowDialog();
                    fil.Hide();
                    Limpiar_todo();
                    pnl_sinProd.Visible = true;
                }
                else if (Cbo_TipoDoc.Text == "Nota Venta" && idempresa == 6)
                {
                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    nota.Imprimir_NotaVenta_Ticket_Niko();//crear rpt notaventa
                    nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    nota.ShowDialog();
                    fil.Hide();
                    Limpiar_todo();
                    pnl_sinProd.Visible = true;
                }

                else if (Cbo_TipoDoc.Text == "Nota Venta" && idempresa == 7)
                {
                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    nota.Imprimir_NotaVenta_Ticket_JassiStore_SJL(txt_NroDoc.Text);//crear rpt notaventa
                                                                                   //nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                                                                                   //nota.ShowDialog();
                    fil.Hide();
                    Limpiar_todo();
                    pnl_sinProd.Visible = true;

                }

                else if (Cbo_TipoDoc.Text == "Nota Venta" && idempresa == 8)
                {
                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    nota.Imprimir_NotaVenta_Ticket_SoniaValero();//crear rpt notaventa
                    nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    nota.ShowDialog();
                    fil.Hide();
                    Limpiar_todo();
                    pnl_sinProd.Visible = true;
                }

                else if (Cbo_TipoDoc.Text == "Nota Venta" && idempresa == 9)
                {
                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    nota.Imprimir_NotaVenta_Ticket_InvAnelay(txt_NroDoc.Text);//crear rpt notaventa
                    //nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    //nota.ShowDialog();
                    fil.Hide();
                    Limpiar_todo();
                    pnl_sinProd.Visible = true;
                }

                else if (Cbo_TipoDoc.Text == "Nota Venta" && idempresa == 10)
                {
                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    nota.Imprimir_BoletaFactura_Ticket_ColeccionistaPeru(txt_NroDoc.Text);
                    //nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    //nota.ShowDialog();
                    fil.Hide();
                    Limpiar_todo();
                    pnl_sinProd.Visible = true;
                }

                else if (Cbo_TipoDoc.Text == "Nota Venta" && idempresa == 12)
                {
                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    nota.Imprimir_NotaVenta_Ticket_TextCharlote(txt_NroDoc.Text);
                    //nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    //nota.ShowDialog();
                    fil.Hide();
                    Limpiar_todo();
                    pnl_sinProd.Visible = true;
                }

                else if (Cbo_TipoDoc.Text == "Nota Venta" && idempresa == 13)
                {
                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    nota.Imprimir_NotaVenta_Ticket_TextilLucero(txt_NroDoc.Text);
                    //nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    //nota.ShowDialog();
                    fil.Hide();
                    Limpiar_todo();
                    pnl_sinProd.Visible = true;
                }
                else if (Cbo_TipoDoc.Text == "Nota Venta" && idempresa == 14)
                {
                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    nota.Imprimir_NotaVenta_Ticket_LucianoEIRL(txt_NroDoc.Text);
                    //nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    //nota.ShowDialog();
                    fil.Hide();
                    Limpiar_todo();
                    pnl_sinProd.Visible = true;
                }

            }
            else
            {

                if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 1)
                {
                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    //nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    //RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    nota.Imprimir_BoletaFactura_Ticket(txt_NroDoc.Text);


                    nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    //nota.ShowDialog();
                    fil.Hide();
                    //trmVNETA 
                    /*fil.Show();
                    enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                    enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                    enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                    enviardocventa.ShowDialog();
                    fil.Hide();*/
                    //dp.limp
                    Limpiar_todo();
                    pnl_sinProd.Visible = true;
                }

                else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 2)
                {
                    //GERMAN EIRL:

                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    //nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    //RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    nota.Imprimir_BoletaFactura_Ticket_GermanEIRL();
                    nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    nota.ShowDialog();
                    fil.Hide();
                    //trmVNETA 
                    /*fil.Show();
                    enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                    enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                    enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                    enviardocventa.ShowDialog();
                    fil.Hide();*/
                    //dp.limp
                    Limpiar_todo();
                    pnl_sinProd.Visible = true;
                }
                else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 3)
                {
                    //AIRLEE:

                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    //nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    //RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    nota.Imprimir_BoletaFactura_Ticket_Airlee();
                    nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    nota.ShowDialog();
                    fil.Hide();
                    //trmVNETA 
                    /*fil.Show();
                    enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                    enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                    enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                    enviardocventa.ShowDialog();
                    fil.Hide();*/
                    //dp.limp
                    Limpiar_todo();
                    pnl_sinProd.Visible = true;
                }
                else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 4)
                {
                    //AIRLEE:

                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    //nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    //RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    nota.Imprimir_BoletaFactura_Ticket_TurbInject();
                    nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    nota.ShowDialog();
                    fil.Hide();
                    //trmVNETA 
                    /*fil.Show();
                    enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                    enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                    enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                    enviardocventa.ShowDialog();
                    fil.Hide();*/
                    //dp.limp
                    Limpiar_todo();
                    pnl_sinProd.Visible = true;
                }
                else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 5)
                {
                    //AIRLEE:

                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    //nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    //RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    nota.Imprimir_BoletaFactura_Ticket_Mavaqui();
                    nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    nota.ShowDialog();
                    fil.Hide();
                    //trmVNETA 
                    /*fil.Show();
                    enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                    enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                    enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                    enviardocventa.ShowDialog();
                    fil.Hide();*/
                    //dp.limp
                    Limpiar_todo();
                    pnl_sinProd.Visible = true;
                }
                else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 6)
                {
                    //NIKO:

                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    //nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    //RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    nota.Imprimir_BoletaFactura_Ticket_Niko();
                    nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    nota.ShowDialog();
                    fil.Hide();
                    //trmVNETA 
                    /*fil.Show();
                    enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                    enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                    enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                    enviardocventa.ShowDialog();
                    fil.Hide();*/
                    //dp.limp
                    Limpiar_todo();
                    pnl_sinProd.Visible = true;
                }

                else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 7)
                {
                    //

                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    //nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    //RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    nota.Imprimir_BoletaFactura_Ticket_JassiStore_SJL(txt_NroDoc.Text);
                    //nota.Imprimir_CopAdminTicket_JassiStore_SJL(txt_NroDoc.Text);
                    //nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    //nota.ShowDialog();
                    fil.Hide();
                    //trmVNETA 
                    /*fil.Show();
                    enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                    enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                    enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                    enviardocventa.ShowDialog();
                    fil.Hide();*/
                    //dp.limp

                    Limpiar_todo();
                    //pnl_sinProd.Visible = true;
                    this.Close();
                }

                else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 8)
                {
                    //NIKO:

                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    //nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    //RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    nota.Imprimir_BoletaFactura_Ticket_SoniaValero();
                    nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    nota.ShowDialog();
                    fil.Hide();
                    //trmVNETA 
                    /*fil.Show();
                    enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                    enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                    enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                    enviardocventa.ShowDialog();
                    fil.Hide();*/
                    //dp.limp
                    Limpiar_todo();
                    pnl_sinProd.Visible = true;
                }

                else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 9)
                {
                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    //nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    //RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    nota.Imprimir_BoletaFactura_Ticket_InvAnelay(txt_NroDoc.Text);
                    //nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    //nota.ShowDialog();
                    fil.Hide();
                    //trmVNETA 
                    /*fil.Show();
                    enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                    enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                    enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                    enviardocventa.ShowDialog();
                    fil.Hide();*/
                    //dp.limp

                    Limpiar_todo();
                    //pnl_sinProd.Visible = true;
                    this.Close();
                }

                else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 10)
                {
                    //

                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    //nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    //RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    nota.Imprimir_BoletaFactura_Ticket_ColeccionistaPeru(txt_NroDoc.Text);
                    nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    nota.ShowDialog();

                    fil.Hide();

                    Limpiar_todo();
                    //pnl_sinProd.Visible = true;
                    this.Close();
                }

                else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 12)
                {
                    //

                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    //nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    //RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    nota.Imprimir_BoletaFactura_Ticket_TextCharlote();
                    nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    nota.ShowDialog();

                    fil.Hide();

                    Limpiar_todo();
                    //pnl_sinProd.Visible = true;
                    this.Close();
                }

                else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 13)
                {
                    //

                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    //nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    //RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    nota.Imprimir_BoletaFactura_Ticket_ImportacionTextilLucero();
                    nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    nota.ShowDialog();

                    fil.Hide();

                    Limpiar_todo();
                    //pnl_sinProd.Visible = true;
                    this.Close();
                }
                else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 14)
                {
                    //

                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    //nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    //RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    nota.Imprimir_BoletaFactura_Ticket_LucianoEIRL(txt_NroDoc.Text);
                    nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                    nota.ShowDialog();

                    fil.Hide();

                    Limpiar_todo();
                    //pnl_sinProd.Visible = true;
                    this.Close();
                }

            }

            //if (Cbo_TipoDoc.SelectedIndex == 0)
            //{
            //    Registrar_Archivos_Temporales();
            //    fil.Show();
            //    nota.lbl_nroDoc.Text = "Nota de Venta : " + txt_NroDoc.Text;
            //    nota.Tag = txt_NroDoc.Text;
            //    nota.ShowDialog();
            //    fil.Hide();

            //    Limpiar_todo();
            //    pnl_sinProd.Visible = true;

            //}
            //else if (Cbo_TipoDoc.SelectedIndex == 1)
            //{
            //    Registrar_Archivos_Temporales();
            //    boleta.lbl_nroDoc.Text = "Boleta de Venta : " + txt_NroDoc.Text;
            //    boleta.Tag = txt_NroDoc.Text;
            //    boleta.ShowDialog();
            //    fil.Hide();

            //    Limpiar_todo();
            //    pnl_sinProd.Visible = true;
            //}

            //else if (Cbo_TipoDoc.SelectedIndex == 2)
            //{
            //    Registrar_Archivos_Temporales();
            //    fac.lbl_nroDoc.Text = "Factura de Venta : " + txt_NroDoc.Text;
            //    fac.Tag = txt_NroDoc.Text;
            //    fac.ShowDialog();
            //    fil.Hide();

            //    Limpiar_todo();
            //    pnl_sinProd.Visible = true;
            //}
            //else
            //{

            //}

        }

        public void GenerarQR(string tipodoc, string totalDoc, string Cliente, string nroDoc, string rutaqr)
        {

            QRCodeEncoder generarCodigoQR = new QRCodeEncoder();
            generarCodigoQR.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            generarCodigoQR.QRCodeScale = Int32.Parse("4");

            try
            {
                generarCodigoQR.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                //version 0 calcula de manera automatica tamaño
                generarCodigoQR.QRCodeVersion = 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Generar QR 1: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            string contenido;
            contenido = "Nro: " + nroDoc + "\r\n" + "Documento: " + tipodoc + "\r\n" + "Total: " + totalDoc + "\r\n" + "Cliente: " + Cliente;
            System.Drawing.Bitmap imgQR;

            try
            {
                imgQR = new System.Drawing.Bitmap(generarCodigoQR.Encode(contenido, System.Text.Encoding.UTF8));
                pic_qr.Image = imgQR;
                imgQR.Save(rutaqr);// primera img qr en bmp
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Generar QR 2: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        public static byte[] Convertir_Imagen_Bytes(Image img)
        {
            string sTemp = Path.GetTempFileName();
            FileStream fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            fs.Position = 0;


            int imgLength = Convert.ToInt32(fs.Length);
            byte[] bytes = new byte[imgLength];
            fs.Read(bytes, 0, imgLength);
            fs.Close();
            return bytes;

        }

        private void Registrar_Archivos_Temporales()
        {
            // para impresion hoja formato y no se desborde al registrar los productos en formato 
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

            pic_qr.Load(RutaQr);

            obj.RN_Eliminar_Temporal(txt_NroDoc.Text);
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
                //tem.Vuelto = txt_vuelto.Text;
                tem.Sonletra = lbl_son.Text;
                tem.Vendedor = Cls_Libreria.Nombre;
                tem.CodigoQr = Convertir_Imagen_Bytes(pic_qr.Image);
                tem.Exonerada = lbl_TotalExonerado.Text;
                //tem.Efectivo = tx_efectivo.Text;
                //tem.Vuelto = lbl_vlto.Text;
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
                tem.Hash_cpe = lblhash.Text;
                tem.MotivoEmision = lblmotivo.Text;


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
                        //{
                        det.IdTempo = txt_NroDoc.Text;
                        det.CodProd = "";
                        det.Canti = "";
                        det.Producto = "";
                        det.Precio = "";
                        det.Importe = "";

                        obj.RN_Registrar_Detalle_Temporal(det);
                        //}
                        veces += 1;
                    }


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        //Registro de venta a Credito

        private void Crear_Registro_deCredito()
        {
            RN_Credito obj = new RN_Credito();

            EN_Credito cred = new EN_Credito();


            En_Caja cja = new En_Caja();
            RN_Caja objCaja = new RN_Caja();

            string idCredito = "";

            try
            {
                idCredito = RN_TipoDoc.RN_NroID(12);

                cred.Idcredito = idCredito;
                cred.IdDoc = txt_NroDoc.Text;
                cred.Fecha_Credito = dtp_FechaEmi.Value;
                cred.NomCliente = txt_cliente.Text;
                cred.TotalCredito = Convert.ToDouble(lbl_TotalPagar.Text);

                if (Convert.ToDouble(lbl_Acuenta.Text) == 0)
                {
                    cred.Saldo_Pdnte = Convert.ToDouble(lbl_TotalPagar.Text);
                }
                else if (Convert.ToDouble(lbl_Acuenta.Text) > 0)
                {
                    cred.Saldo_Pdnte = Convert.ToDouble(lbl_SaldoCred.Text);
                }
                cred.Fecha_Vencimiento = dtp_Vencimnto_Credito.Value;

                obj.RN_Registrar_Credito(cred);

                if (BD_Credito.credSaved == true)
                {

                    RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(12);

                    if (Convert.ToDouble(lbl_Acuenta.Text) > 0)
                    {
                        Reg_Detalle_Credito(idCredito);
                        //creamos un registro de movimiento de caja por el importe que dejo a cuenta.

                        cja.FechaCaja = dtp_FechaEmi.Value;
                        cja.TipoCaja = "Entrada";
                        cja.Concepto = "Abono de Credito";
                        cja.De_Para_Cliente = txt_cliente.Text;
                        cja.Nro_Doc = txt_NroDoc.Text;
                        cja.ImportaCaja = Convert.ToDouble(lbl_Acuenta.Text);
                        cja.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                        cja.TotalUti = Convert.ToDouble(lbl_totalGanancia.Text);
                        cja.TipoPago = "Efectivo";
                        cja.GeneradoPor = "Abono";

                        objCaja.RN_Registrar_Mov_Caja(cja);

                        //otro movimiento de caja:
                        cja.FechaCaja = dtp_FechaEmi.Value;
                        cja.TipoCaja = "Entrada";
                        cja.Concepto = "Por Ventas al Publico a Credito";
                        cja.De_Para_Cliente = txt_cliente.Text;
                        cja.Nro_Doc = txt_NroDoc.Text;
                        cja.ImportaCaja = Convert.ToDouble(lbl_TotalPagar.Text);
                        cja.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                        cja.TotalUti = 0;
                        cja.TipoPago = "Credito";
                        cja.GeneradoPor = Cbo_TipoDoc.Text;

                        objCaja.RN_Registrar_Mov_Caja(cja);

                    }
                    else
                    {
                        //otro movimiento de caja:
                        cja.FechaCaja = dtp_FechaEmi.Value;
                        cja.TipoCaja = "Entrada";
                        cja.Concepto = "Por Ventas al Publico a Credito";
                        cja.De_Para_Cliente = txt_cliente.Text;
                        cja.Nro_Doc = txt_NroDoc.Text;
                        cja.ImportaCaja = Convert.ToDouble(lbl_TotalPagar.Text);
                        cja.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                        cja.TotalUti = 0;
                        cja.TipoPago = "Credito";
                        cja.GeneradoPor = Cbo_TipoDoc.Text;

                        objCaja.RN_Registrar_Mov_Caja(cja);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Detalle de credito
        private void Reg_Detalle_Credito(string idCredito)
        {
            EN_DetCredito det = new EN_DetCredito();
            RN_Credito obj = new RN_Credito();

            try
            {

                det.IdCredito = idCredito;
                det.Acuenta = Convert.ToDouble(lbl_Acuenta.Text);
                det.SaldoActual = Convert.ToDouble(lbl_SaldoCred.Text);
                det.FechaPago = dtp_FechaEmi.Value;
                det.TipoPago = "Efectivo";
                det.NroOperacion = "-";
                det.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);

                obj.RN_Registrar_Detalle_Credito(det);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Limpiar_todo()
        {
            lsv_Det.Items.Clear();
            txt_cliente.Text = "";
            lbl_idcliente.Text = "";
            lbl_totalGanancia.Text = "0";
            lbl_subtotal.Text = "0";
            lbl_igv.Text = "0";
            lbl_totalGanancia.Text = "0";
            lbl_Limit_Cred.Text = "0";
            lbl_dni_ruc.Text = "";
            Cbo_TipoPago.SelectedIndex = -1;
            Cbo_TipoDoc.SelectedIndex = -1;
            lbl_saldo_Pdnte.Text = "0";
            lbl_totalVale.Text = "0";
            tx_efectivo.Text = "";
            lbl_vlto.Text = "0";

        }

        private void btn_AtenderOtro_Click(object sender, EventArgs e)
        {

        }

        private void Bucar_Documento_paraReimprimir(string nroDoc/*List<string> nroDocs*/)
        {
            
            RN_Documento obj = new RN_Documento();
            DataTable dato = new DataTable();

            try
            {
                dato = obj.RN_Buscador_DocumentoDetalle_porID(nroDoc.Trim());
                if (dato.Rows.Count > 0)
                {

                    var dt = dato.Rows[0];

                    txt_NroDoc.Text = Convert.ToString(dt["id_Doc"]);
                    txt_nroPed.Text = Convert.ToString(dt["id_Ped"]);
                    Cbo_TipoDoc.SelectedValue = Convert.ToUInt32(dt["Id_Tipo"]);
                    dtp_FechaEmi.Value = Convert.ToDateTime(dt["Fecha_Emi"]);
                    txt_NroOperac.Text = Convert.ToString(dt["Nro_Operacion"]);
                    tx_efectivo.Text = Convert.ToString(dt["Efectivo"]); //validar que emita el monto con el que pago. para que calcule el vuelto
                    lbl_vlto.Text = Convert.ToString(dt["Vuelto"]);
                    //txt_vuelto.Text = Convert.ToString(dt["Vuelto"]);
                    Cbo_TipoPago.Text = Convert.ToString(dt["TipoPago"]);
                    lbl_idcliente.Text = Convert.ToString(dt["Id_Cliente"]);
                    txt_cliente.Text = Convert.ToString(dt["Razon_Social_Nombres"]);
                    lbl_direccion.Text = Convert.ToString(dt["Direccion"]);
                    lbl_dni_ruc.Text = Convert.ToString(dt["DNI"]);

                    //detalle del documento:
                    foreach (DataRow xitem in dato.Rows)
                    {
                        ListViewItem xlist;
                        xlist = lsv_Det.Items.Add(xitem["Id_Pro"].ToString());
                        xlist.SubItems.Add(xitem["Descripcion_Larga"].ToString());
                        xlist.SubItems.Add(xitem["Cantidad"].ToString());
                        xlist.SubItems.Add(xitem["Precio_conIgv"].ToString());
                        xlist.SubItems.Add(xitem["ImporteconIgv"].ToString());
                        xlist.SubItems.Add(xitem["Tipo_Prod"].ToString());
                        xlist.SubItems.Add(xitem["Und_Medida"].ToString());
                        xlist.SubItems.Add(xitem["Utilidad_Unit"].ToString());
                        xlist.SubItems.Add(xitem["TotalUtilidad"].ToString());

                        xlist.SubItems.Add(xitem["AfectoIgv"].ToString());
                        xlist.SubItems.Add(xitem["Precio_sinIgv"].ToString());
                        xlist.SubItems.Add(xitem["subtotal_SinIgv"].ToString());
                        xlist.SubItems.Add(xitem["Igv_subtotal"].ToString());
                        xlist.SubItems.Add("NIU");  //NIU -- ZZ
                        xlist.SubItems.Add(xitem["CodTipo_Afectacion"].ToString());

                    }
                    Calcular();
                    pnl_sinProd.Visible = false;

                }
                else
                {
                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Advertencia ver = new Frm_Advertencia();

                    fil.Show();
                    //ver.Lbl_Msm1.Text = "El Documento que buscas no existe, o talvez sea una Cotizacion, Marque el Check";
                    ver.Lbl_msm1.Text = "El Documento que buscas no existe";
                    ver.ShowDialog();
                    fil.Hide();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
            /*
            RN_GuiaRem_Transportista obj = new RN_GuiaRem_Transportista();
            DataTable dato = new DataTable();

            try
            {
              
                foreach (string nroDoc in nroDocs) // Recorrer cada ID
                {
                    dato = obj.RN_Buscador_DocumentoDetalle_porID(nroDoc.Trim());
                    //dato = obj.RN_Buscador_DocumentoGR_Detalle_porID(nroDoc.Trim());

                    if (dato.Rows.Count > 0)
                    {
                        var dt = dato.Rows[0];

                        //txt_NroDoc.Text = Convert.ToString(dt["id_Doc"]);
                        //txt_nroPed.Text = Convert.ToString(dt["id_Ped"]);
                        //Cbo_TipoDoc.SelectedValue = Convert.ToUInt32(dt["Id_Tipo"]);
                        //dtp_FechaEmi.Value = Convert.ToDateTime(dt["Fecha_Emi"]);
                        //txt_NroOperac.Text = Convert.ToString(dt["Nro_Operacion"]);
                        //tx_efectivo.Text = Convert.ToString(dt["Efectivo"]);
                        //lbl_vlto.Text = Convert.ToString(dt["Vuelto"]);
                        //Cbo_TipoPago.Text = Convert.ToString(dt["TipoPago"]);
                        //lbl_idcliente.Text = Convert.ToString(dt["Id_Cliente"]);
                        //txt_cliente.Text = Convert.ToString(dt["Razon_Social_Nombres"]);
                        //lbl_direccion.Text = Convert.ToString(dt["Direccion"]);
                        //lbl_dni_ruc.Text = Convert.ToString(dt["DNI"]);

                        foreach (DataRow xitem in dato.Rows)
                        {
                            //string gravado = "Gravado";
                            //string xtipo = "NIU"; 

                            ListViewItem xlist;
                            xlist = lsv_Det.Items.Add(xitem["Id_Pro_Detalle"].ToString());
                            xlist.SubItems.Add(xitem["Descripcion_Larga"].ToString());
                            xlist.SubItems.Add(xitem["Cantidad"].ToString());
                            xlist.SubItems.Add(xitem["PrecioUnit"].ToString());
                            xlist.SubItems.Add(xitem["Importe"].ToString());
                            xlist.SubItems.Add(xitem["TipoProdcto"].ToString());
                            xlist.SubItems.Add(xitem["UndMedida"].ToString());
                            xlist.SubItems.Add(xitem["UtilidadUnit"].ToString());
                            //xlist.SubItems.Add(xitem[gravado].ToString());
                            //xlist.SubItems.Add("0.00");
                            //xlist.SubItems.Add("0.00");
                            //xlist.SubItems.Add("0.00");
                            //xlist.SubItems.Add(xitem[xtipo].ToString());
                        }
                        Calcular();
                        pnl_sinProd.Visible = false;
                    }
                }

                if (dato.Rows.Count == 0)
                {
                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Advertencia ver = new Frm_Advertencia();

                    fil.Show();
                    ver.Lbl_msm1.Text = "El Documento que buscas no existe";
                    ver.ShowDialog();
                    fil.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            */

        }

        private void lbl_lupa_Click(object sender, EventArgs e)
        {
            Bucar_Documento_paraReimprimir(txt_buscar.Text); //original

            // Crear una lista con múltiples IDs (puedes separarlos con comas, por ejemplo)
            //List<string> ids = txt_buscar.Text.Split(',').Select(id => id.Trim()).ToList();

            //Bucar_Documento_paraReimprimir(ids);

            /*
            if (txt_buscar.Text.Trim().Length > 6)
            {
                if (chk_coti.Checked == true)
                {
                    //va cargar una cotizacion
                    Bucar_Cotizacion_paraAtender(txt_buscar.Text);
                }
                else
                {
                    //cargar el documento para reimprimir:
                    Bucar_Documento_paraReimprimir(txt_buscar.Text);
                }
            }*/
        }

        private void Cbo_TipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_TipoPago.Text == "Visa")
            {
                txt_NroOperac.ReadOnly = false;
                txt_NroOperac.Focus();
            }
            else if (Cbo_TipoPago.Text == "Mastercard")
            {
                txt_NroOperac.ReadOnly = false;
                txt_NroOperac.Focus();
            }
            //agregando nuevos metodos de pago:11/12/22
            /* else if(Cbo_TipoPago.Text == "Yape" || Cbo_TipoPago.Text == "Plin")
             {
                 txt_NroOperac.ReadOnly = false;
                 txt_NroOperac.Focus();
             }*/
            else
            {
                txt_NroOperac.Text = "-";
                txt_NroOperac.ReadOnly = true;
            }
        }


        private void txt_cliente_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F5)
            {
                lbl_BusClien_Click(sender, e);
            }


        }

        private void Frm_Crear_Ventas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (pnl_sinProd.Visible == true)
                {
                    btn_Nuevo_buscarProd_Click(sender, e);
                }
            }

            if (e.KeyCode == Keys.F2)
            {
                if (pnl_sinProd.Visible == false)
                {
                    bt_add_Click(sender, e);
                }
            }

            if (e.KeyCode == Keys.F3)
            {
                if (pnl_sinProd.Visible == false)
                {
                    bt_editPre_Click(sender, e);
                }
            }


            if (e.KeyCode == Keys.F4)
            {
                if (pnl_sinProd.Visible == false)
                {
                    bt_Delete_Click(sender, e);
                }
            }

            if (e.KeyCode == Keys.F5)
            {
                lbl_BusClien_Click(sender, e);
            }


            if (e.KeyCode == Keys.F6)
            {
                if (pnl_sinProd.Visible == false)
                {
                    btn_procesar_Click(sender, e);
                }
            }

        }

        private void gru_det_Click(object sender, EventArgs e)
        {

        }

        private void lbl_TotalPagar_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            Frm_Print_Boleta boleta = new Frm_Print_Boleta();
            Registrar_Archivos_Temporales();
            boleta.lbl_nroDoc.Text = "Boleta de Venta : " + txt_NroDoc.Text;
            boleta.Tag = txt_NroDoc.Text;*/

            //Bucar_Documento_paraReimprimir(txt_buscar.Text);
        }

        private void txImporte_TextChanged(object sender, EventArgs e)
        {

        }

        private void txdf_TextChanged(object sender, EventArgs e)
        {

        }

        private void txdf_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tx_efectivo_TextChanged(object sender, EventArgs e)
        {

            tx_efectivo.Text = tx_efectivo.Text.Replace(",", ".");
            tx_efectivo.SelectionStart = tx_efectivo.Text.Length;

            double xvuelto = 0;

            try
            {

                xvuelto = Convert.ToDouble(tx_efectivo.Text) - Convert.ToDouble(lbl_TotalPagar.Text);
                lbl_vlto.Text = xvuelto.ToString("###0.00");
            }
            catch (Exception ex)
            {
                string sms = ex.Message;
            }
        }

        private void tx_efectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_vuelto_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* Utilitario ui = new Utilitario();
             e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));*/
        }

        private void txt_buscar_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}

