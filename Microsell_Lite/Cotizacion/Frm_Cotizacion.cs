using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//importar:
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using System.IO;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Productos;
using Microsell_Lite.Compras;
using Microsell_Lite.Cliente;
using Microsell_Lite.Informe;


namespace Microsell_Lite.Cotizacion
{
    public partial class Frm_Cotizacion : Form
    {
        public Frm_Cotizacion()
        {
            InitializeComponent();
        }

        private void Frm_Ventana_Ventas_Load(object sender, EventArgs e)
        {
            Configurar_listView();         


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
            lis.Columns.Add("Descripcion producto", 400, HorizontalAlignment.Left);  //1
            lis.Columns.Add("cantidad", 80, HorizontalAlignment.Left);  //2
            lis.Columns.Add("precio Unit", 90, HorizontalAlignment.Right);  //3
            lis.Columns.Add("Importe", 90, HorizontalAlignment.Right );  //4
            lis.Columns.Add("Tipo Producto", 0, HorizontalAlignment.Right);  //5
            lis.Columns.Add("Und", 0, HorizontalAlignment.Right);  //6
            lis.Columns.Add("Utilidad Unit", 0, HorizontalAlignment.Right);  //7
            lis.Columns.Add("Total Utilidad", 0, HorizontalAlignment.Right);  //8

            //para facturacion electronica 2023:

            lis.Columns.Add("Afect. Igv", 90, HorizontalAlignment.Left);  //9
            lis.Columns.Add("PreUni sinIgv", 100, HorizontalAlignment.Left);  //10
            lis.Columns.Add("SubTotal SinIgv", 100, HorizontalAlignment.Left);  //11
            lis.Columns.Add("Igv", 100, HorizontalAlignment.Left);  //12
            lis.Columns.Add("Tipo", 110, HorizontalAlignment.Left);  //13


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

        private bool Validar_Cotizacion()
        {
            Frm_Filtro fil = new Frm_Filtro();

            if (lsv_Det.Items.Count == 0) { fil.Show(); MessageBox.Show("Ingresa Almenos un Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); lsv_Det.Focus(); return false; }
            //if (cbo_provee.SelectedIndex ==-1) { fil.Show(); MessageBox.Show("INgresa Almenos un Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_provee.Focus(); return false; }
            //if (txt_NroFisico.Text.Trim().Length < 2) { fil.Show(); MessageBox.Show("INgresa el Nro de FActura Fisica", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); txt_NroFisico.Focus(); return false; }
            //if (cbo_tipoPago.SelectedIndex == -1) { fil.Show(); MessageBox.Show("Selecciona el Tipo de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_tipoPago.Focus(); return false; }
            //if (cbo_tipoDoc .SelectedIndex == -1) { fil.Show(); MessageBox.Show("Selecciona el Tipo de documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_tipoDoc.Focus(); return false; }

            return true;
        }

        private void Frm_Cotizacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Escape )
            {
                this.Close();
            }


        }

        private void pnl_subtitu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        private void btn_Nuevo_buscarProd_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_ListadoProd_Compras xpro = new Frm_ListadoProd_Compras();

            fil.Show();
            Frm_ListadoProd_Compras.TipoVenta = "coti";
            xpro.chk_cotiza.Checked = true;
            xpro.ShowDialog();

            fil.Hide();

            if (xpro.Tag.ToString() == "A")
            {

                string _idprod;
                string _nomprod;
                double _cant;
                double _precio;
                double _importe;
                string _und;
                string _tipoProd;
                double _Utili_Unit; // puede ser con DOUBLE. //puede ser sin 0 vid.35


                if (xpro.lsv_Ped.Items.Count > 0)
                {
                    for(int i = 0; i < xpro.lsv_Ped.Items.Count; i++)
                    {
                        var item = xpro.lsv_Ped.Items[i];
                        _idprod = item.SubItems[0].Text;
                        _nomprod = item.SubItems[1].Text;
                        _cant = Convert.ToDouble(item.SubItems[3].Text);
                        _precio = Convert.ToDouble(item.SubItems[4].Text);
                        _importe = Convert.ToDouble(item.SubItems[5].Text);
                        _und = item.SubItems[2].Text;
                        _tipoProd = item.SubItems[8].Text;
                        _Utili_Unit = Convert.ToDouble(item.SubItems[6].Text);

                        Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe, _und, _tipoProd, _Utili_Unit, "Gravado", "NIU");
                    }

                }
                else
                {
                    //PARA AGREGAR DE UNO EN UNO
                     _idprod = xpro.lbl_IdProd.Text;
                     _nomprod = xpro.lbl_NomProd.Text;
                     _cant = Convert.ToDouble(xpro.lbl_Cant.Text);
                     _precio = Convert.ToDouble(xpro.lbl_Pre_Unit.Text);
                     _importe = Convert.ToDouble(xpro.lbl_Pre_Unit.Text);
                     _und = xpro.lbl_Und.Text;
                     _tipoProd = xpro.lbl_TipoProd.Text;
                     _Utili_Unit = Convert.ToDouble(xpro.lbl_Uti_Unit.Text);

                    Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe, _und, _tipoProd, _Utili_Unit, "Gravado", "NIU");

                }

            }
        }

        



        private void Agregar_Productos_alCarrito(string xidprod, string xnomprod, double xcant, double xprecio, double ximporte, string xund, string xtipoProd, double xutili_unit, String xafecto, string xtipo)
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
                    item.SubItems.Add(xtipoProd.Trim());
                    item.SubItems.Add(xund.Trim());
                    item.SubItems.Add(xutili_unit.ToString("###0.00"));
                    item.SubItems.Add(xutili_unit.ToString("###0.00"));


                    //
                    item.SubItems.Add(xafecto);
                    item.SubItems.Add("0.00");
                    item.SubItems.Add("0.00");
                    item.SubItems.Add("0.00");
                    item.SubItems.Add(xtipo);
                    //

                    Calcular();
                    lsv_Det.Focus();
                    lsv_Det.Items[0].Selected = true;
                    pnl_sinProd.Visible = false;

                }
                else
                {
                    //validar que el producto no se ingrese dos veces
                    for (int i = 0; i < lsv_Det.Items.Count; i++)
                    {
                        if (lsv_Det.Items[i].Text.Trim() == xidprod.Trim())//xidprodcto se cambio - cla22.21:21
                        {
                            MessageBox.Show("El Producto ya fue Agregado al Carrito de Compras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    //lo añadimos 
                    ListViewItem item = new ListViewItem();
                    item = lsv_Det.Items.Add(xidprod);
                    item.SubItems.Add(xnomprod.Trim());
                    item.SubItems.Add(xcant.ToString());
                    item.SubItems.Add(xprecio.ToString("###0.00"));
                    item.SubItems.Add(ximporte.ToString("###0.00"));
                    item.SubItems.Add(xtipoProd.Trim());
                    item.SubItems.Add(xund.Trim());
                    item.SubItems.Add(xutili_unit.ToString("###0.00"));
                    item.SubItems.Add(xutili_unit.ToString("###0.00"));

                    item.SubItems.Add(xafecto);
                    item.SubItems.Add("0.00");
                    item.SubItems.Add("0.00");
                    item.SubItems.Add("0.00");
                    item.SubItems.Add(xtipo);

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
            double xigv = 0;
            double xsubtotal = 0;
            double xuti_unit = 0;
            double ximporte_Uti = 0;
            double xTotalGanan =0;
            

        


            for (int i = 0; i < lsv_Det.Items.Count; i++)
            {
                xcant = Convert.ToDouble(lsv_Det.Items[i].SubItems[2].Text);
                xprecio = Convert.ToDouble(lsv_Det.Items[i].SubItems[3].Text);

                //calculo
                ximporte = xprecio * xcant;
                lsv_Det.Items[i].SubItems[4].Text = ximporte.ToString("###0.00");

                //utilidad:
                xuti_unit = Convert.ToDouble(lsv_Det.Items[i].SubItems[7].Text);
                ximporte_Uti = xuti_unit * xcant;

                //calculo del total:
                xtotal = xtotal + Convert.ToDouble(lsv_Det.Items[i].SubItems[4].Text);

                xTotalGanan = xTotalGanan + Convert.ToDouble(lsv_Det.Items[i].SubItems[8].Text);

                /*

                //*****CALCULO PARA SUNAT :****
                preUnit_sinIgv = xprecio / 1.18;
                lsv_Det.Items[i].SubItems[10].Text = preUnit_sinIgv.ToString("###0.000000");//00


                //subtotal sin igv:
                subtotal_sinIgv = preUnit_sinIgv * xcant;
                lsv_Det.Items[i].SubItems[11].Text = subtotal_sinIgv.ToString("###0.00");

                //Calculamos el igv:
                igvProd = subtotal_sinIgv * 0.18;
                lsv_Det.Items[i].SubItems[12].Text = igvProd.ToString("###0.00");


                //*************Pie de la FE para Sunat******************///
                //xsubtotal_sinIgv = xsubtotal_sinIgv + Convert.ToDouble(lsv_Det.Items[i].SubItems[12].Text);
                


            }

            //calculo del igv:
            xsubtotal = xtotal / 1.18;
            xigv = xsubtotal * 0.18;

          

            
            lbl_subtotal.Text = xsubtotal.ToString("###0.00");
            lbl_igv.Text = xigv.ToString("###0.00");
            lbl_TotalPagar.Text = xtotal.ToString("###0.00");
            lbl_totalGanancias.Text = xTotalGanan.ToString("###0.00");

            lbl_son.Text = Numalet.ToString(lbl_TotalPagar.Text); //libreria para que el precio lo ponga en letras.
            let.LetraCapital = chkCapital.Checked;
            
            if (!actualizado) ActualizarConf();


        }



        private void chk_sinIgv_CheckedChanged(object sender, EventArgs e)
        {

        }


        Numalet let = new Numalet();
        bool actualizado = false;


        private void ActualizarConf()
        {
            actualizado = true;
            chkCapital.Checked = let.LetraCapital;

            if(lbl_son.Text.Length > 0)
            {
                lbl_son.Text = let.ToCustomString(lbl_TotalPagar.Text);
                actualizado = false;
            }
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_ListadoProd_Compras xpro = new Frm_ListadoProd_Compras();

            fil.Show();
            Frm_ListadoProd_Compras.TipoVenta = "coti";
            xpro.chk_cotiza.Checked = true;
            xpro.ShowDialog();

            fil.Hide();

            if (xpro.Tag.ToString() == "A")
            {

                string _idprod = xpro.lbl_IdProd.Text;
                string _nomprod = xpro.lbl_NomProd.Text;
                double _cant = Convert.ToDouble(xpro.lbl_Cant.Text);
                double _precio = Convert.ToDouble(xpro.lbl_Pre_Unit.Text);
                double _importe = Convert.ToDouble(xpro.lbl_Pre_Unit.Text);
                string _und = xpro.lbl_Und.Text;
                string _tipoProd = xpro.lbl_TipoProd.Text;
                double _Utili_Unit = Convert.ToDouble(xpro.lbl_Uti_Unit.Text);
                Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe, _und, _tipoProd, _Utili_Unit, "Gravado", "NIU");

            }
        }

        private void bt_editPre_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Solo_Precio solo = new Frm_Solo_Precio();

            if (lsv_Det.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar el Producto a Editar su Precio", "Editar Precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                double precio_Ingresado = 0;
                double Precio_Editado = 0;

                precio_Ingresado = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[3].Text);

                fil.Show();
                solo.txt_precio.Text = precio_Ingresado.ToString();
                solo.ShowDialog();
                fil.Hide();

                if (solo.Tag.ToString() == "A")
                {
                    Precio_Editado = Convert.ToDouble(solo.txt_precio.Text);
                    lsv_Det.SelectedItems[0].SubItems[3].Text = Precio_Editado.ToString("###0.00");
                    Calcular();
                }

            }
        }

        private void bt_editCant_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Solo_Canti solo = new Frm_Solo_Canti();

            if (lsv_Det.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar el Producto a Editar su Cantidad", "Editar Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                double cant_Ingresado = 0;
                double cant_Editado = 0;

                cant_Ingresado = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[2].Text);

                fil.Show();
                solo.txt_cant.Text = cant_Ingresado.ToString();
                solo.ShowDialog();
                fil.Hide();

                if (solo.Tag.ToString() == "A")
                {
                    cant_Editado = Convert.ToDouble(solo.txt_cant.Text);
                    lsv_Det.SelectedItems[0].SubItems[2].Text = cant_Editado.ToString("###0.00");
                    Calcular();
                }

            }
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Sino sino = new Frm_Sino();

            if (lsv_Det.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar el Producto a Quitar", "Quitar Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                fil.Show();
                sino.Lbl_msm1.Text = "Estas Seguro de Quitar este producto del POS?";
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

        private void btn_procesar_Click(object sender, EventArgs e)
        {
            if (lsv_Det.Items.Count == 0) { MessageBox.Show("Debes Agregar al menos un Producto al carrito", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            if (lbl_idcliente.Text.Trim().Length < 2) { MessageBox.Show("Agrega un Cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

            Guardar_Cotizacion();
        }

        private void Guardar_Pedido()
        {
            RN_Pedido obj = new RN_Pedido();
            EN_Pedido ped = new EN_Pedido();
            EN_Det_Pedido det = new EN_Det_Pedido();

            try
            {
                txt_nroPed.Text = RN_TipoDoc.RN_NroID(10);

                ped.IdPedido = txt_nroPed.Text;
                ped.IdCliente = lbl_idcliente.Text;
                ped.SubTotal = Convert.ToDouble(lbl_subtotal.Text);
                ped.Igv = Convert.ToDouble(lbl_igv.Text);
                ped.TotalPed = Convert.ToDouble(lbl_TotalPagar.Text);
                ped.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                ped.TotalGancia = Convert.ToDouble(lbl_totalGanancias.Text);

                obj.RN_Registrar_Pedido(ped);
                if(BD_Pedido.seguardo == true)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(10);
                    //guardar el detalle del pedido

                    det.IdPed = txt_nroPed.Text;
                    for(int i =0; i < lsv_Det.Items.Count; i++)
                    {
                        var lis = lsv_Det.Items[i];

                        det.IdPro = lis.SubItems[0].Text;
                        det.Precio = Convert.ToDouble(lis.SubItems[3].Text);
                        det.Cantidad = Convert.ToDouble(lis.SubItems[2].Text);
                        det.Importe = Convert.ToDouble(lis.SubItems[4].Text);
                        det.Tipo_Prod = lis.SubItems[5].Text;
                        det.Und = lis.SubItems[6].Text;
                        det.Utilidad_Unit = Convert.ToDouble(lis.SubItems[7].Text);
                        det.Totalutilidad = Convert.ToDouble(lis.SubItems[8].Text);

                        //fe
                        det.AfectoIgv = lis.SubItems[9].Text;
                        det.Precio_sinIgv = Convert.ToDouble(lis.SubItems[10].Text);
                        det.Subtotal_SinIgv = Convert.ToDouble(lis.SubItems[11].Text);
                        det.Igv_subtotal = Convert.ToDouble(lis.SubItems[12].Text);

                        obj.RN_Registrar_Detalle_Pedido(det);

                    }


                }

            }
            catch ( Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Guardar_Cotizacion()
        {

        

            RN_Cotizacion obj = new RN_Cotizacion();
            EN_Cotizacion coti = new EN_Cotizacion();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_Print_Cotizacion pricoti = new Frm_Print_Cotizacion();

            try
            {
                //primero guardo el pedido:
                Guardar_Pedido();

                if (BD_Pedido.seguardo == true && BD_Pedido.detseguardo == true)
                {
                    txt_NroCotiza.Text = RN_TipoDoc.RN_NroID(11);
                    coti.Id_Cotiza = txt_NroCotiza.Text;
                    coti.Id_Ped = txt_nroPed.Text;
                    coti.FechaCoti = dtp_FechaEmi.Value;
                    coti.Vigencia = Convert.ToInt32(nud_vigencia.Value);
                    coti.TotalCotiza = Convert.ToDouble(lbl_TotalPagar.Text);
                    coti.Condiciones = txt_condicion.Text;
                    if (chk_sinIgv.Checked == true)
                    {
                        coti.Preciocon_Igv = "No";
                    }
                    else
                    {
                        coti.Preciocon_Igv = "Si";
                    }
                    coti.EstadoCoti = "Pendiente";


                    obj.RN_Registrar_Cotizacion(coti);
                    if (BD_Cotizacion.seguardo == true)
                    {
                        fil.Show();
                        RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(11);
                        ok.Lbl_msm1.Text = "La Cotizacion Nro: " + txt_NroCotiza.Text + "Se Guardo con Exito";
                        ok.ShowDialog();
                        fil.Hide();

                        //mandar a imprimir 
                        fil.Show();
                        pricoti.Tag = txt_NroCotiza.Text;
                        pricoti.ShowDialog();
                        fil.Hide();

                        pnl_sinProd.Visible = true;
                        lsv_Det.Items.Clear();
                        txt_cliente.Text = "";
                        txt_NroCotiza.Text = "";
                        txt_nroPed.Text = "";
                        lbl_idcliente.Text = "-";
                        txt_condicion.Text = "";
                        chk_sinIgv.Checked = false;
                        nud_vigencia.Value = 1;

                    }
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_cliente_KeyDown(object sender, KeyEventArgs e)
        {        
            if (e.KeyCode ==Keys.Enter)
            {
                lbl_BusCli_Click(sender, e);
            }
        }

        private void lbl_BusCli_Click(object sender, EventArgs e)

        {
            Frm_Listadocliente lis = new Frm_Listadocliente();
            Frm_Filtro fil = new Frm_Filtro();

            fil.Show(); // puede ser con dialog
            Frm_Listadocliente.tipo = txt_cliente.Text;
            lis.ShowDialog();
            fil.Hide();

            if(lis.Tag .ToString () =="A")
            {
                lbl_idcliente.Text = lis.lbl_id.Text;
                txt_cliente.Text = lis.lbl_nom.Text;
            }

        }

       
    }
}
