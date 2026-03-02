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

//IMPORTACION F.E
using BE = businessEntities;
using CPEEnvio;
using CrearXML;
using Signature;




namespace Microsell_Lite.Ventas
{
    public partial class Frm_Credito : Form
    {
        public Frm_Credito()
        {
            InitializeComponent();
        }

        private void Frm_Ventana_Ventas_Load(object sender, EventArgs e)
        {

            Configurar_listView();
            Llenar_Combo_docs();
            Leer_Dato_Empresa();

            Cbo_TipoPago.SelectedIndex = 0; //para colocar cualquier textobx se inicie en primera opcion
            //Cbo_TipoDoc.SelectedIndex();
            Cbo_TipoDoc.SelectedIndex = 1;

        }

        private void Leer_Dato_Empresa()
        {
            RN_Empresa obj = new RN_Empresa();
            DataTable data = new DataTable();

            try
            {
                data = obj.RN_Buscar_Empresa_porId(1);
                if (data.Rows.Count > 0)
                {
                    Lbl_EmpresaEmisor.Text = Convert.ToString(data.Rows[0]["nombreEmpresa"]);
                    Lbl_RucEmisor.Text = Convert.ToString(data.Rows[0]["nroRuc"]);
                    Lbl_DireccionEmpresa.Text = Convert.ToString(data.Rows[0]["DireccionEmpresa"]);
                    Lbl_UsuarioSol.Text = Convert.ToString(data.Rows[0]["usuariosol"]);
                    Lbl_ClaveSol.Text = Convert.ToString(data.Rows[0]["clavesol"]);
                    Lbl_CorreoEmi.Text = Convert.ToString(data.Rows[0]["correo"]);
                    Lbl_ClaveCorreo.Text = Convert.ToString(data.Rows[0]["clavecorreo"]);
                    Lbl_ClaveCertificado.Text = Convert.ToString(data.Rows[0]["clavecertificado"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer los Datos: " + ex.Message, "Form Add Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
            lis.Columns.Add("Importe", 90, HorizontalAlignment.Right);  //4
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
        private void Llenar_Listview(DataTable data)
        {
            //lsv_Det.Items.Clear();

            //for (int i = 0; i < data.Rows.Count; i++)
            //{
            //    DataRow dr = data.Rows[i];
            //    ListViewItem list = new ListViewItem(dr["Id_Pro"].ToString());//0
            //    list.SubItems.Add(dr["Descripcion_Larga"].ToString());//1
            //    list.SubItems.Add(dr["Stock_Actual"].ToString());//2
            //    list.SubItems.Add(dr["Pre_CompraS"].ToString());//3
            //    list.SubItems.Add(dr["Frank"].ToString());//4
            //    list.SubItems.Add(dr["Pre_vntaxMenor"].ToString());//5
            //    list.SubItems.Add(dr["Pre_vntaxMayor"].ToString());//6
            //    list.SubItems.Add(dr["UtilidadUnit"].ToString());//7
            //    list.SubItems.Add(dr["Valor_porCant"].ToString());//8
            //    list.SubItems.Add(dr["Estado_Pro"].ToString());//9
            //    list.SubItems.Add(dr["Marca"].ToString());//10
            //    list.SubItems.Add(dr["TipoProdcto"].ToString());//11
            //    lsv_Det.Items.Add(list); //si no ponemos esto,. el listview  nunca se llenara
            //}
            ////Pintar_Filas();
            ////pnl_msm.Visible = false;
            ////lbl_totalItem.Text = lsv_prodcto.Items.Count.ToString();
        }


        private void buscar_Productos(string valor)
        {
            //RN_Productos obj = new RN_Productos();
            //DataTable dato = new DataTable();

            //dato = obj.RN_Buscar_Productos(valor);
            //if (dato.Rows.Count > 0)
            //{
            //    Llenar_Listview(dato);
            //}
            //else
            //{
            //    lsv_Det.Items.Clear();
            //    //pnl_msm.Visible = true;
            //    double Stock = 0;
            //    string EstadoProd = "";

            //    var lis = lsv_Det.SelectedItems[0];

            //    //continuar:
            //    lbl_NomProd.Text = lis.SubItems[1].Text;
            //    lbl_Pre_Unit.Text = lis.SubItems[5].Text; //precio de venta por menor:
            //    lbl_IdProd.Text = lis.SubItems[0].Text;
            //    Stock = Convert.ToDouble(lis.SubItems[2].Text);
            //    lbl_Uti_Unit.Text = lis.SubItems[9].Text;
            //    EstadoProd = lis.SubItems[10].Text;
            //    xxpreCom = Convert.ToDouble(lis.SubItems[3].Text);
            //    lbl_TipoProd.Text = lis.SubItems[11].Text;
            //    lbl_Und.Text = lis.SubItems[8].Text;
            //}

        }

        private void txt_buscarProd_OnValueChanged(object sender, EventArgs e)
        {
            //if (txt_buscarProd.Text.Trim().Length > 2)
            //{
            //    buscar_Productos(txt_buscarProd.Text);
            //}
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

            Frm_Filtro fil = new Frm_Filtro();
            Frm_ListadoProd_Compras xpro = new Frm_ListadoProd_Compras();

            fil.Show();
            Frm_ListadoProd_Compras.TipoVenta = "venta";
            xpro.chk_cotiza.Checked = false;
            xpro.ShowDialog();

            fil.Hide();

            if (xpro.Tag.ToString() == "A")
            {
                string _idprod;
                string _nomprod;
                double _cant = 0;
                double _precio = 0;
                double _importe = 0;
                string _und;
                string _tipoProd;
                Double _Utili_Unit;

                if (xpro.lsv_Ped.Items.Count > 0)
                {
                    for (int i = 0; i < xpro.lsv_Ped.Items.Count; i++)
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
                    //para agregar de uno en Uno:
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
                    item.SubItems.Add(xtipoProd.ToString());
                    item.SubItems.Add(xund.ToString());
                    item.SubItems.Add(xutili_unit.ToString("###0.00"));
                    item.SubItems.Add(xutili_unit.ToString("###0.00"));
                    //F.E
                    item.SubItems.Add(xafecto);
                    item.SubItems.Add("0.00");
                    item.SubItems.Add("0.00");
                    item.SubItems.Add("0.00");
                    item.SubItems.Add(xtipo);
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


            for (int i = 0; i < lsv_Det.Items.Count; i++)
            {
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
                lsv_Det.Items[i].SubItems[10].Text = preUnit_sinIgv.ToString("###0.00");


                //subtotal sin igv:
                subtotal_sinIgv = preUnit_sinIgv * xcant;
                lsv_Det.Items[i].SubItems[11].Text = subtotal_sinIgv.ToString("###0.00");

                //Calculamos el igv:
                igvProd = subtotal_sinIgv * 0.18;
                lsv_Det.Items[i].SubItems[12].Text = igvProd.ToString("###0.00");


                //*************Pie de la FE para Sunat******************//
                xsubtotal_sinIgv = xsubtotal_sinIgv + Convert.ToDouble(lsv_Det.Items[i].SubItems[12].Text);


            }
            //calcular el IGV: IVA
            xsubtotal = xtotal / 1.18;
            xigv = xsubtotal * 0.18;

            lbl_subtotal.Text = xsubtotal.ToString("###0.00");
            lbl_igv.Text = xigv.ToString("###0.00");
            lbl_TotalPagar.Text = xtotal.ToString("###0.00");


            tx_efectivo.Text = xtotal.ToString("###0.00");

            //cacular los vueltos en 1 medio de pago:

            /*
            try
            {
                
                xvuelto = Convert.ToDouble( txImporte.Text) - xtotal;
                txVuelto.Text = xvuelto.ToString("###0.00");

                txImporte.Text = ximporte.ToString("###0.00");

                //Vlto_Import = Convert.ToDouble(txImporte.Text) - Convert.ToDouble(lbl_TotalPagar.Text);
                //Precom_Sol.ToString("###0.00");
                //txVuelto.Text = Vlto_Import.ToString("###0.00");




            }
            catch (Exception ex)
            {
                string sms = ex.Message;
            }*/


            lbl_totalGanancia.Text = xTotalGanancia.ToString("###0.00");

            lbl_son.Text = Numalet.ToString(lbl_TotalPagar.Text);
            let.LetraCapital = chkCapital.Checked;
            if (!actualizado) ActualizarCong();


            //*************Totales del pie  FE para Sunat******************//
            lbl_subtotalGravado.Text = xsubtotal_sinIgv.ToString("###0.00");
            lbl_igvgravado.Text = xigv_total.ToString("###0.00");
            double totalGravado = xsubtotal_sinIgv + xigv_total;
            lbl_totalGravado.Text = totalGravado.ToString("###0.00");

            lbl_TotalItem.Text = lsv_Det.Items.Count.ToString();




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
            Frm_Filtro fil = new Frm_Filtro();
            Frm_ListadoProd_Compras xpro = new Frm_ListadoProd_Compras();

            fil.Show();
            Frm_ListadoProd_Compras.TipoVenta = "venta";
            xpro.chk_cotiza.Checked = false;
            xpro.ShowDialog();

            fil.Hide();

            //if (xpro.Tag.ToString() == "A")
            //{
            //    string _idprod = xpro.lbl_IdProd.Text;
            //    string _nomprod = xpro.lbl_NomProd.Text;
            //    double _cant = Convert.ToDouble(xpro.lbl_Cant.Text);
            //    double _precio = Convert.ToDouble(xpro.lbl_Pre_Unit.Text);
            //    double _importe = Convert.ToDouble(xpro.lbl_Pre_Unit.Text);
            //    string _und = xpro.lbl_Und.Text;
            //    string _tipoProd = xpro.lbl_TipoProd.Text;
            //    Double _Utili_Unit = Convert.ToDouble(xpro.lbl_Uti_Unit.Text);

            //    Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe, _und, _tipoProd, _Utili_Unit);


            //}



            //adicionar para agregar sin salir del carrito:
            if (xpro.Tag.ToString() == "A")
            {
                string _idprod;
                string _nomprod;
                double _cant = 0;
                double _precio = 0;
                double _importe = 0;
                string _und;
                string _tipoProd;
                Double _Utili_Unit;

                if (xpro.lsv_Ped.Items.Count > 0)
                {
                    for (int i = 0; i < xpro.lsv_Ped.Items.Count; i++)
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
                    //para agregar de uno en Uno:
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

        private void bt_editPre_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Edit_Precio pre = new Frm_Edit_Precio();

            if (lsv_Det.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar el Producto a Editar su Precio", "Editar Precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                double precio_Ingresado = 0;
                double Cant_Ingresado = 0;
                double Precio_Editado = 0;
                double Cant_Editado = 0;
                string xidProd = "";
                double xUti_Unit = 0;

                xidProd = lsv_Det.SelectedItems[0].SubItems[0].Text;
                precio_Ingresado = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[3].Text);
                Cant_Ingresado = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[2].Text);

                fil.Show();
                pre.txt_precio.Text = precio_Ingresado.ToString("###0.00");
                pre.txt_cant.Text = Cant_Ingresado.ToString("###0.00");
                pre.idProducto = xidProd.Trim();
                pre.ShowDialog();
                fil.Hide();


                if (pre.Tag.ToString() == "A")
                {
                    Precio_Editado = Convert.ToDouble(pre.txt_precio.Text);
                    Cant_Editado = Convert.ToDouble(pre.txt_cant.Text);
                    xUti_Unit = Convert.ToDouble(pre.Lbl_UtilidadUnit.Text);

                    lsv_Det.SelectedItems[0].SubItems[3].Text = Precio_Editado.ToString("###0.00");
                    lsv_Det.SelectedItems[0].SubItems[2].Text = Cant_Editado.ToString("###0.00");
                    lsv_Det.SelectedItems[0].SubItems[7].Text = xUti_Unit.ToString("###0.00");

                    Calcular();
                }

            }

        }



        //private void bt_editCant_Click(object sender, EventArgs e)
        //{
        //    Frm_Filtro fil = new Frm_Filtro();
        //    Frm_Solo_Canti solo = new Frm_Solo_Canti();

        //    if (lsv_Det.SelectedIndices.Count == 0)
        //    {
        //        MessageBox.Show("Seleccionar el Producto a Editar su Cantidad", "Editar Precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //    else
        //    {
        //        double cant_Ingresado = 0;
        //        double cant_Editado = 0;
        //        cant_Ingresado = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[2].Text);

        //        fil.Show();
        //        solo.txt_cant.Text = cant_Ingresado.ToString();
        //        solo.ShowDialog();
        //        fil.Hide();


        //        if (solo.Tag.ToString() == "A")
        //        {
        //            cant_Editado = Convert.ToDouble(solo.txt_cant.Text);
        //            lsv_Det.SelectedItems[0].SubItems[2].Text = cant_Editado.ToString("###0.00");
        //            Calcular();
        //        }

        //    }
        //}

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


        private void Guardar_Pedido_Editado()
        {
            RN_Pedido obj = new RN_Pedido();
            EN_Pedido ped = new EN_Pedido();
            EN_Det_Pedido det = new EN_Det_Pedido();

            try
            {


                ped.IdPedido = txt_nroPed.Text;
                ped.IdCliente = lbl_idcliente.Text;
                ped.SubTotal = Convert.ToDouble(lbl_subtotal.Text);
                ped.Igv = Convert.ToDouble(lbl_igv.Text);
                ped.TotalPed = Convert.ToDouble(lbl_TotalPagar.Text);
                ped.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                ped.TotalGancia = Convert.ToDouble(lbl_totalGanancia.Text);

                //FE:
                ped.Subtotal_gravado = Convert.ToDouble(lbl_subtotalGravado.Text);
                ped.IgvGravado = Convert.ToDouble(lbl_igvgravado.Text);
                ped.TotalGravado = Convert.ToDouble(lbl_totalGravado.Text);


                obj.RN_Editar_Pedido(ped);

                if (BD_Pedido.seguardo == true)
                {

                    obj.RN_Eliminar_Detalle_Pedido(txt_nroPed.Text);

                    //guardar el detalle del pedido:

                    det.IdPed = txt_nroPed.Text;

                    for (int i = 0; i < lsv_Det.Items.Count; i++)
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

                        //FE
                        det.AfectoIgv = lis.SubItems[9].Text;
                        det.Precio_sinIgv = Convert.ToDouble(lis.SubItems[10].Text);
                        det.Subtotal_SinIgv = Convert.ToDouble(lis.SubItems[11].Text);
                        det.Igv_subtotal = Convert.ToDouble(lis.SubItems[12].Text);

                        obj.RN_Registrar_Detalle_Pedido(det);
                    }
                }

            }
            catch (Exception ex)
            {
                string msm = ex.Message;
                MessageBox.Show("Error al Guardar: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


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
                ped.TotalGancia = Convert.ToDouble(lbl_totalGanancia.Text);
                //FE:
                ped.Subtotal_gravado = Convert.ToDouble(lbl_subtotalGravado.Text);
                ped.IgvGravado = Convert.ToDouble(lbl_igvgravado.Text);
                ped.TotalGravado = Convert.ToDouble(lbl_totalGravado.Text);

                obj.RN_Registrar_Pedido(ped);

                if (BD_Pedido.seguardo == true)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(10);
                    //giuardar el detalle del pedido:

                    det.IdPed = txt_nroPed.Text;

                    for (int i = 0; i < lsv_Det.Items.Count; i++)
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

                        //FE:
                        det.AfectoIgv = lis.SubItems[9].Text;
                        det.Precio_sinIgv = Convert.ToDouble(lis.SubItems[10].Text);
                        det.Subtotal_SinIgv = Convert.ToDouble(lis.SubItems[11].Text);
                        det.Igv_subtotal = Convert.ToDouble(lis.SubItems[12].Text);


                        obj.RN_Registrar_Detalle_Pedido(det);
                    }
                }

            }
            catch (Exception ex)
            {
                string msm = ex.Message;
                MessageBox.Show("Error al Guardar: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                    //para F.e
                    if (Convert.ToInt32(lbl_dni_ruc.Text.Trim().Length) == 8)
                    {
                        lbl_idDni.Text = "1"; //si es dni
                    }
                    else if (Convert.ToInt32(lbl_dni_ruc.Text.Trim().Length) == 11)
                    {
                        lbl_idDni.Text = "6"; //si es ruc
                    }
                    else
                    {
                        MessageBox.Show("El numero de DNI debe tener 8 digitos y el Ruc 11, Verifica por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }


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
            Frm_Addver ver = new Frm_Addver();

            if (lsv_Det.Items.Count == 0) { fil.Show(); ver.Lbl_Msm1.Text = "Debes agregar como minimo un producto al Carrito"; ver.ShowDialog(); fil.Hide(); return false; }
            if (Convert.ToInt32(lbl_idcliente.Text.Length) < 2) { fil.Show(); ver.Lbl_Msm1.Text = "Te falta agregar un Cliente"; ver.ShowDialog(); fil.Hide(); return false; }
            if (Cbo_TipoPago.SelectedIndex == -1) { fil.Show(); ver.Lbl_Msm1.Text = "Por favor, Elige un Tipo de Pago"; ver.ShowDialog(); fil.Hide(); Cbo_TipoPago.Focus(); return false; }

            if (Cbo_TipoDoc.SelectedIndex == -1) { fil.Show(); ver.Lbl_Msm1.Text = "Por favor, Elige un Tipo de Comprobante"; ver.ShowDialog(); fil.Hide(); Cbo_TipoDoc.Focus(); return false; }

            //if (txt_NroOperac.Text.Trim().Length <2) { fil.Show(); ver.Lbl_Msm1.Text = "Debes ingresar N° Referencia"; ver.ShowDialog(); fil.Hide(); txt_NroOperac.Focus(); return false; }

            if (lbl_server.Text.Trim() == "1" || lbl_server.Text.Trim() == "3")
            {
                if (Cbo_TipoDoc.SelectedIndex == 0 || Cbo_TipoDoc.Text.Trim() == "Nota Venta") { fil.Show(); MessageBox.Show("El documento selecccionado no es un documento valido para la sunat", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            return true;

        }


        private void Guardar_Documento()
        {
            RN_Documento obj = new RN_Documento();
            EN_Documento doc = new EN_Documento();

            try
            {

                txt_NroDoc.Text = RN_TipoDoc.RN_NroID(Convert.ToInt32(Cbo_TipoDoc.SelectedValue));
                //los parametros :
                doc.IdDoc = txt_NroDoc.Text;
                doc.IdPed = txt_nroPed.Text;
                doc.IdTipo = Convert.ToInt32(Cbo_TipoDoc.SelectedValue);
                doc.Fecha_DocEmi = dtp_FechaEmi.Value;
                doc.Importe = Convert.ToDouble(lbl_TotalPagar.Text);
                doc.Efectivo = Convert.ToDouble(tx_efectivo.Text);
                doc.Vuelto = Convert.ToDouble(lbl_vlto.Text);
                doc.TipoPago = Cbo_TipoPago.Text;
                doc.Nr_Operacion = txt_NroOperac.Text;
                doc.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                doc.Igv = Convert.ToDouble(lbl_igv.Text);
                doc.SonLetra = lbl_son.Text;
                doc.TotalGanancia = Convert.ToDouble(lbl_totalGanancia.Text);

                //campos para la FE:
                doc.CdrSunat = "Pendiente";
                doc.Hash_CPE = "-";
                doc.EstadoBaja = "Activo";
                doc.NroTicket_baja = "-";
                doc.Hash_cpeBaja = "-";


                obj.RN_Registrar_Nuevo_Documento(doc);

                if (BD_Documento.seguardo == true)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(Convert.ToInt32(Cbo_TipoDoc.SelectedValue));
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        private void Guardar_IngresoCaja()
        {
            RN_Caja obj = new RN_Caja();
            En_Caja cja = new En_Caja();

            try
            {

                cja.FechaCaja = dtp_FechaEmi.Value;
                cja.TipoCaja = "Entrada";
                cja.Concepto = "Por Ventas al Publico";
                cja.De_Para_Cliente = txt_cliente.Text;
                cja.Nro_Doc = txt_NroDoc.Text;
                cja.ImportaCaja = Convert.ToDouble(lbl_TotalPagar.Text);
                cja.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                cja.TotalUti = Convert.ToDouble(lbl_totalGanancia.Text);
                cja.TipoPago = Cbo_TipoPago.Text;
                cja.GeneradoPor = Cbo_TipoDoc.Text;

                obj.RN_Registrar_Mov_Caja(cja);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        //para nc fe implementando:
        private void Guardar_IngresoCaja_NotaCredito()
        {
            RN_Caja obj = new RN_Caja();
            En_Caja cja = new En_Caja();

            try
            {

                cja.FechaCaja = dtp_FechaEmi.Value;
                cja.TipoCaja = "Entrada";
                cja.Concepto = "Por Ventas al Publico";
                cja.De_Para_Cliente = txt_cliente.Text;
                cja.Nro_Doc = txt_NroDoc.Text;
                cja.ImportaCaja = Convert.ToDouble(lbl_saldo_Pdnte.Text);
                cja.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                cja.TotalUti = Convert.ToDouble(lbl_totalGanancia.Text);
                cja.TipoPago = Cbo_TipoPago.Text; //pendiente
                cja.GeneradoPor = Cbo_TipoDoc.Text;

                obj.RN_Registrar_Mov_Caja(cja);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        int Prod_Krd = 0;

        private void Registrar_MovimientoKardex()
        {
            RN_Kardex obj = new RN_Kardex();
            EN_Kardex kar = new EN_Kardex();
            RN_Productos objpro = new RN_Productos();
            DataTable dato = new DataTable();
            DataTable datoprod = new DataTable();

            string xidkardex = "";
            int xitem = 0;
            double stockProd = 0;
            double precioCompraProd = 0;

            string xidProd = "";
            double xcant = 0;
            string xTipoProd = "";


            try
            {

                for (int i = 0; i < lsv_Det.Items.Count; i++)
                {
                    var lis = lsv_Det.Items[i];

                    xidProd = lis.SubItems[0].Text;
                    xcant = Convert.ToDouble(lis.SubItems[2].Text);
                    xTipoProd = lis.SubItems[5].Text;

                    if (obj.RN_Verificar_Producto_siTieneKardex(xidProd) == true)
                    {
                        dato = obj.RN_Buscar_KardexDetalle_porProducto(xidProd.Trim());
                        if (dato.Rows.Count > 0)
                        {
                            xidkardex = Convert.ToString(dato.Rows[0]["Id_krdx"]);
                            xitem = dato.Rows.Count;
                            //leemos los datos del producto 
                            datoprod = objpro.RN_Buscar_Productos(xidProd.Trim());
                            stockProd = Convert.ToDouble(datoprod.Rows[0]["Stock_Actual"]);
                            precioCompraProd = Convert.ToDouble(datoprod.Rows[0]["Pre_CompraS"]);


                            //registramos el Detalle del Kardex:

                            kar.Idkardex = xidkardex;
                            kar.Item = xitem + 1;
                            kar.Doc_soporte = txt_NroDoc.Text;
                            kar.Det_Operacion = "Por Ventas al Publico";
                            //Entrada
                            kar.Cantidad_in = 0;
                            kar.Precio_In = 0;
                            kar.Total_In = 0;
                            //salida:
                            kar.Cantidad_Out = xcant;
                            kar.Precio_out = precioCompraProd;
                            kar.Total_out = xcant * precioCompraProd;
                            //saldos:   //CALCULOS DE LOS KARDEX VALORIZADOS
                            kar.Cantidad_saldo = stockProd - xcant;
                            kar.Promedio = precioCompraProd;
                            kar.Total_saldo = precioCompraProd * kar.Cantidad_saldo;

                            obj.RN_Registrar_Detalle_Kardex(kar);

                            //ahora actualizamos nuestro stock de la tabla de productos:
                            objpro.RN_Restar_Stock_Producto(xidProd.Trim(), xcant); 

                            Prod_Krd += 1;

                        }

                    }

                }//fin del for:

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reg Kardex Capa Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }



        private void btn_procesar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_TipoPago_Credito cred = new Frm_TipoPago_Credito();
            RN_Cotizacion objcoti = new RN_Cotizacion();
            //F.E
            RN_Documento objdoc = new RN_Documento();
            RN_Notacredito objnc = new RN_Notacredito();

            //impresiones ticket
            Frm_Print_NotaVenta nota = new Frm_Print_NotaVenta();
            //Frm_Print_Boleta boleta = new Frm_Print_Boleta();
            //Frm_Print_Factura fac = new Frm_Print_Factura();

           
            Frm_SendCompro_Mail enviardocventa = new Frm_SendCompro_Mail();

            int idempresa = Cls_Libreria.Idempresa;


            try
            {
                if (Validar_Antes_Vender() == true)
                {

                    if (Cbo_TipoPago.SelectedIndex == 3) //cuadno es a credito 
                    {
                        fil.Show();
                        cred.LimpiarForm();
                        cred.Lbl_Total_acobrar.Text = lbl_TotalPagar.Text;
                        cred.ShowDialog();
                        fil.Hide();

                        if (cred.Tag.ToString() == "A")
                        {
                            lbl_Acuenta.Text = cred.txt_Acuenta.Text;
                            lbl_SaldoCred.Text = cred.lbl_Saldo_PagarCred.Text;
                            dtp_Vencimnto_Credito.Value = cred.dtp_FechaVencix.Value;
                        }
                        else
                        {
                            return;
                        }

                    }


                    if (chk_coti.Checked == true)
                    {
                        Guardar_Pedido_Editado();
                    }
                    else
                    {

                        //guardar pedido:
                        Guardar_Pedido();
                    }

                    if (BD_Pedido.seguardo == true && BD_Pedido.detseguardo == true)
                    {
                        //ahora toca guardar el documento
                        Guardar_Documento();

                        if (BD_Documento.seguardo == true)
                        {
                            if (Cbo_TipoPago.SelectedIndex == 0 || Cbo_TipoPago.SelectedIndex == 1) // si es efectivo o Deposito:
                            {
                                Guardar_IngresoCaja();
                            }

                            else if (Cbo_TipoPago.SelectedIndex == 2 || Cbo_TipoPago.SelectedIndex == 4 || Cbo_TipoPago.SelectedIndex == 5)
                            {
                                Guardar_IngresoCaja();
                            }

                            else if (Cbo_TipoPago.SelectedIndex == 3)
                            {
                                //crear un movimiento de caja a credito :
                                //crear un registro de credito de cliente:
                                Crear_Registro_deCredito();
                            }

                            else if (Cbo_TipoPago.SelectedIndex == 6)
                            {
                                //para poder actualizar , cuando es nota de credito 
                                objnc.RN_Actualizar_EstadoDinero_NC(lbl_idNotaCred.Text, "No Pago");
                                Guardar_IngresoCaja_NotaCredito();

                            }


                            /* else if (Cbo_TipoPago.SelectedIndex == 3)
                             {
                                 //para poder actualizar el vale , verificar el vale, etc.
                             }*/



                            //agregando metodos de pago yape plim- 11/12/22



                            if (BD_Caja.cajaSaved == true)
                            {
                                //registramos el movimiento de kardex
                                Registrar_MovimientoKardex();

                                //se puede enviar al final de  el mensaje para que no mueestre en cada venta que se realicce: 
                                //terminar la venta:
                                /*fil.Show();
                                ok.Lbl_msm1.Text = "La Venta se ha desarrollado Exitosamente y se ha Creado el Mov de: " + Prod_Krd.ToString() + " Productos en Kardex:";
                                ok.ShowDialog();
                                fil.Hide();*/

                                //cambiar el estado de la cotzacion:
                                if (txt_NroCotiza.Text.Trim().Length > 5)
                                {
                                    objcoti.RN_Cambiar_Estado_Cotizacion(txt_NroCotiza.Text, "Atendido");
                                }
                                /*else
                                {

                                }*/

                                /*
                                 * 
                                fil.Show();
                                ok.Lbl_msm1.Text = "La Venta se ha desarrollado Exitosamente y se ha Creado el Mov de: " + Prod_Krd.ToString() + " Productos en Kardex:";
                                ok.ShowDialog();
                                fil.Hide();
                                */

                                //Validavion para F.E

                                if (lbl_server.Text.Trim() == "1" || lbl_server.Text.Trim() == "3")
                                {
                                    //llamamos al metodo EnvbiarDoucmentSunat
                                    EnviarDocumento_aSunat();

                                    if (TXTCOD_SUNAT.Text.Trim() == "0" || TXTCOD_SUNAT.Text.Trim() == "1")
                                    {
                                        objdoc.RN_CambiarEstado_CdrSunat(txt_NroDoc.Text.Trim(), "Aprobado", TXTHASH_CPE.Text.Trim());//

                                        //TERMINAR VENTA
                                        fil.Show();
                                        ok.Lbl_msm1.Text = "La Venta se Aprobó por la sunat y se guardo, Exitosamente y se ha Creado el Mov de: " + Prod_Krd.ToString() + " Productos en Kardex:";
                                        ok.ShowDialog();
                                        fil.Hide();

                                        //PARA REGISTRAR TEMPORALES:
                                        Registrar_Archivos_Temporales();

                                        //llamamos a imprimir las FE:
                                        if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 1)
                                        {
                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            //para guardar la el doc en ruta -concatenando 
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";

                                            nota.Imprimir_BoletaFactura_Ticket(txt_NroDoc.Text);
                                            nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                                            //nota.ShowDialog();
                                            fil.Hide();

                                            //trmVNETA 
                                            fil.Show();
                                            enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                                            enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                                            enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                                            enviardocventa.ShowDialog();
                                            fil.Hide();
                                            //dp.limp
                                            Limpiar_todo();
                                            pnl_sinProd.Visible = true;
                                        }

                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 2)
                                        {
                                            //GERMAN EIRL:

                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            nota.Imprimir_BoletaFactura_Ticket_GermanEIRL();
                                            nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                                            nota.ShowDialog();
                                            fil.Hide();
                                            //trmVNETA 
                                            fil.Show();
                                            enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                                            enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                                            enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                                            enviardocventa.ShowDialog();
                                            fil.Hide();
                                            //dp.limp

                                            Limpiar_todo();
                                            pnl_sinProd.Visible = true;
                                        }
                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 3)
                                        {
                                            //AIRLEE:

                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            nota.Imprimir_BoletaFactura_Ticket_Airlee();
                                            nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                                            nota.ShowDialog();
                                            fil.Hide();
                                            //trmVNETA 
                                            fil.Show();
                                            enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                                            enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                                            enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                                            enviardocventa.ShowDialog();
                                            fil.Hide();
                                            //dp.limp

                                            Limpiar_todo();
                                            pnl_sinProd.Visible = true;
                                        }
                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 4)
                                        {
                                            //AIRLEE:

                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            nota.Imprimir_BoletaFactura_Ticket_TurbInject();
                                            nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                                            nota.ShowDialog();
                                            fil.Hide();
                                            //trmVNETA 
                                            fil.Show();
                                            enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                                            enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                                            enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                                            enviardocventa.ShowDialog();
                                            fil.Hide();
                                            //dp.limp

                                            Limpiar_todo();
                                            pnl_sinProd.Visible = true;
                                        }
                                        //FIN
                                    }
                                    else
                                    {
                                        //cuando es rechazdo:

                                        objdoc.RN_CambiarEstado_CdrSunat(txt_NroDoc.Text.Trim(), "Rechazado", TXTHASH_CPE.Text.Trim());//

                                        //TERMINAR VENTA
                                        fil.Show();
                                        ok.Lbl_msm1.Text = "La Venta se ha desarrollado Exitosamente pero fue Rechazado: " + TXT_MSJ_SUNAT.Text + " Krdx: " + Prod_Krd.ToString() + " Productos en Kardex:";
                                        ok.ShowDialog();
                                        fil.Hide();

                                        //PARA REGISTRAR TEMPORALES:
                                        Registrar_Archivos_Temporales();
                                        
                                        
                                        if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 1)
                                        {
                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            nota.Imprimir_BoletaFactura_Ticket(txt_NroDoc.Text);
                                            nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                                            //nota.ShowDialog();
                                            fil.Hide();
                                            //trmVNETA 
                                            fil.Show();
                                            enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                                            enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                                            enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                                            enviardocventa.ShowDialog();
                                            fil.Hide();
                                            //dp.limp

                                            Limpiar_todo();
                                            pnl_sinProd.Visible = true;
                                        }

                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 2)
                                        {
                                            //GERMAN EIRL:

                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            nota.Imprimir_BoletaFactura_Ticket_GermanEIRL();
                                            nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                                            nota.ShowDialog();
                                            fil.Hide();
                                            //trmVNETA 
                                            fil.Show();
                                            enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                                            enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                                            enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                                            enviardocventa.ShowDialog();
                                            fil.Hide();
                                            //dp.limp
                                            Limpiar_todo();
                                            pnl_sinProd.Visible = true;
                                        }
                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 3)
                                        {
                                            //AIRLEE:

                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            nota.Imprimir_BoletaFactura_Ticket_Airlee();
                                            nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                                            nota.ShowDialog();
                                            fil.Hide();
                                            //trmVNETA 
                                            fil.Show();
                                            enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                                            enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                                            enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                                            enviardocventa.ShowDialog();
                                            fil.Hide();
                                            //dp.limp
                                            Limpiar_todo();
                                            pnl_sinProd.Visible = true;
                                        }
                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 4)
                                        {
                                            //turb:

                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            nota.Imprimir_BoletaFactura_Ticket_TurbInject();
                                            nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                                            nota.ShowDialog();
                                            fil.Hide();
                                            //trmVNETA 
                                            fil.Show();
                                            enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                                            enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                                            enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                                            enviardocventa.ShowDialog();
                                            fil.Hide();
                                            //dp.limp
                                            Limpiar_todo();
                                            pnl_sinProd.Visible = true;
                                        }

                                    }
                                }
                                else
                                {
                                    //volvemos a pregunatar : FE
                                    //TERMINAR VENTA
                                    fil.Show();
                                    ok.Lbl_msm1.Text = "La Venta se ha desarrollado Exitosamente y se ha Creado el Mov de: " + Prod_Krd.ToString() + " Productos en Kardex:";
                                    ok.ShowDialog();
                                    fil.Hide();

                                    //PARA REGISTRAR TEMPORALES:
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

                                    }
                                    else
                                    {
                                        
                                        if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 1)
                                        {
                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            nota.Imprimir_BoletaFactura_Ticket(txt_NroDoc.Text);
                                            nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                                            //nota.ShowDialog();
                                            fil.Hide();
                                            //trmVNETA 
                                            fil.Show();
                                            enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                                            enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                                            enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                                            enviardocventa.ShowDialog();
                                            fil.Hide();
                                            //dp.limp
                                            Limpiar_todo();
                                            pnl_sinProd.Visible = true;
                                        }

                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 2)
                                        {
                                            //GERMAN EIRL:

                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            nota.Imprimir_BoletaFactura_Ticket_GermanEIRL();
                                            nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                                            nota.ShowDialog();
                                            fil.Hide();
                                            //trmVNETA 
                                            fil.Show();
                                            enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                                            enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                                            enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                                            enviardocventa.ShowDialog();
                                            fil.Hide();
                                            //dp.limp
                                            Limpiar_todo();
                                            pnl_sinProd.Visible = true;
                                        }
                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 3)
                                        {
                                            //AIRLEE:

                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            nota.Imprimir_BoletaFactura_Ticket_Airlee();
                                            nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                                            nota.ShowDialog();
                                            fil.Hide();
                                            //trmVNETA 
                                            fil.Show();
                                            enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                                            enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                                            enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                                            enviardocventa.ShowDialog();
                                            fil.Hide();
                                            //dp.limp
                                            Limpiar_todo();
                                            pnl_sinProd.Visible = true;
                                        }
                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 4)
                                        {
                                            //AIRLEE:

                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            nota.Imprimir_BoletaFactura_Ticket_TurbInject();
                                            nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                                            nota.ShowDialog();
                                            fil.Hide();
                                            //trmVNETA 
                                            fil.Show();
                                            enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                                            enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                                            enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                                            enviardocventa.ShowDialog();
                                            fil.Hide();
                                            //dp.limp
                                            Limpiar_todo();
                                            pnl_sinProd.Visible = true;
                                        }
                                    }                              
                                }


                                //mandar a imprimir:
                                //Registrar_Archivos_Temporales();

                                /* se comenta este codigo revisar --original
                                if (Cbo_TipoDoc.SelectedIndex == 0)
                                {
                                    Registrar_Archivos_Temporales();
                                    fil.Show();
                                    nota.lbl_nroDoc.Text = "Nota de Venta : " + txt_NroDoc.Text;
                                    nota.Tag = txt_NroDoc.Text;
                                    nota.ShowDialog();
                                    fil.Hide();

                                    Limpiar_todo();
                                    pnl_sinProd.Visible = true;

                                }
                                else if (Cbo_TipoDoc.SelectedIndex == 1)
                                {
                                    Registrar_Archivos_Temporales();
                                    boleta.lbl_nroDoc.Text = "Boleta de Venta : " + txt_NroDoc.Text;
                                    boleta.Tag = txt_NroDoc.Text;
                                    boleta.ShowDialog();
                                    fil.Hide();

                                    Limpiar_todo();
                                    pnl_sinProd.Visible = true;
                                }

                                else if (Cbo_TipoDoc.SelectedIndex == 2)
                                {
                                    Registrar_Archivos_Temporales();
                                    fac.lbl_nroDoc.Text = "Factura de Venta : " + txt_NroDoc.Text;
                                    fac.Tag = txt_NroDoc.Text;
                                    fac.ShowDialog();
                                    fil.Hide();

                                    Limpiar_todo();
                                    pnl_sinProd.Visible = true;
                                }
                                else
                                {

                                }
                                */

                                //*******
                                //Limpiar_todo();
                                //pnl_sinProd.Visible = true;


                                //fil.Show();
                                //nota.lbl_nroDoc.Text = "Nota Venta : " + txt_NroDoc.Text;
                                //nota.Tag = txt_NroDoc.Text;

                                //nota.ShowDialog();
                                //fil.Hide();


                                //Limpiar_todo();
                                //pnl_sinProd.Visible = true;
                                //limpiar todo:


                            }

                        }


                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        DataTable objtemComprobate;
        DataRow objTemFilaComprobante;

        BE.CPE objCPE = new BE.CPE();
        BE.CPE_DETALLE objCPE_DETALLE = new BE.CPE_DETALLE();
        CPEConfig obj = new CPEConfig();

        private void EnviarDocumento_aSunat()
        {

            try
            {
                objCPE.TIPO_OPERACION = "0101"; //venta interna
                objCPE.TOTAL_GRAVADAS = Convert.ToDecimal(lbl_subtotal.Text);
                objCPE.SUB_TOTAL = Convert.ToDecimal(lbl_subtotal.Text);
                objCPE.POR_IGV = 18; //UBL2.1
                objCPE.TOTAL_IGV = Convert.ToDecimal(lbl_igv.Text);
                objCPE.TOTAL_ISC = 0; //impuesto selectivo al comsumidor //emp.importadoras
                objCPE.TOTAL_OTR_IMP = 0;
                objCPE.TOTAL_DESCUENTOGLO = 0;
                objCPE.TOTAL = Convert.ToDecimal(lbl_TotalPagar.Text);
                objCPE.TOTAL_EXPORTACION = 0;
                objCPE.TOTAL_LETRAS = lbl_son.Text.Trim();
                objCPE.NRO_GUIA_REMISION = "";
                objCPE.FECHA_GUIA_REMISION = "";
                objCPE.COD_GUIA_REMISION = "";
                objCPE.NRO_OTR_COMPROBANTE = "";
                objCPE.COD_OTR_COMPROBANTE = "";
                objCPE.NRO_COMPROBANTE = txt_NroDoc.Text.Trim(); //FE01-00001
                objCPE.FECHA_DOCUMENTO = dtp_FechaEmi.Value.ToString("yyyy-MM-dd");
                objCPE.FECHA_VTO = dtp_FechaEmi.Value.ToString("yyyy-MM-dd");
                objCPE.COD_TIPO_DOCUMENTO = lbl_id_TipodocSunat.Text; //01- factura, 03 - boleta

                objCPE.COD_MONEDA = "PEN";
                objCPE.TIPO_COMPROBANTE_MODIFICA = "";
                objCPE.COD_TIPO_MOTIVO = "";
                objCPE.DESCRIPCION_MOTIVO = "";

                //datos del cliente;
                objCPE.NRO_DOCUMENTO_CLIENTE = lbl_dni_ruc.Text.Trim();
                objCPE.RAZON_SOCIAL_CLIENTE = txt_cliente.Text.Trim();
                objCPE.TIPO_DOCUMENTO_CLIENTE = lbl_idDni.Text.Trim();
                objCPE.DIRECCION_CLIENTE = lbl_direccion.Text.Trim();

                //ubigeo:
                objCPE.CIUDAD_CLIENTE = "LIMA";
                objCPE.COD_PAIS_CLIENTE = "PE";
                objCPE.COD_UBIGEO_CLIENTE = "";
                objCPE.DEPARTAMENTO_CLIENTE = "";
                objCPE.PROVINCIA_CLIENTE = "";
                objCPE.DISTRITO_CLIENTE = "";

                //datos de la empresa:
                objCPE.NRO_DOCUMENTO_EMPRESA = Lbl_RucEmisor.Text.Trim();
                objCPE.TIPO_DOCUMENTO_EMPRESA = "6";
                objCPE.NOMBRE_COMERCIAL_EMPRESA = Lbl_EmpresaEmisor.Text.Trim();
                objCPE.CODIGO_UBIGEO_EMPRESA = "150101";
                objCPE.DIRECCION_EMPRESA = Lbl_DireccionEmpresa.Text.Trim();
                objCPE.DEPARTAMENTO_EMPRESA = "Lima";
                objCPE.PROVINCIA_EMPRESA = "Lima";
                objCPE.DISTRITO_EMPRESA = "Lima";
                objCPE.CODIGO_PAIS_EMPRESA = "PE";
                objCPE.RAZON_SOCIAL_EMPRESA = Lbl_EmpresaEmisor.Text.Trim();
                objCPE.CONTACTO_EMPRESA = "";
                objCPE.USUARIO_SOL_EMPRESA = Lbl_UsuarioSol.Text.Trim();
                objCPE.PASS_SOL_EMPRESA = Lbl_ClaveSol.Text.Trim();
                objCPE.CONTRA_FIRMA = Lbl_ClaveCertificado.Text.Trim();


                int xtipo = Convert.ToInt32(lbl_server.Text);
                objCPE.TIPO_PROCESO = xtipo;

                //al detalle f.e
                List<businessEntities.CPE_DETALLE> OBJCPEDETALLE_LIST = new List<businessEntities.CPE_DETALLE>();





                for (int i = 0; i < lsv_Det.Items.Count; i++)
                {
                    objCPE_DETALLE = new businessEntities.CPE_DETALLE();

                    objCPE_DETALLE.ITEM = i + 1;
                    objCPE_DETALLE.UNIDAD_MEDIDA = lsv_Det.Items[i].SubItems[13].Text;
                    objCPE_DETALLE.CANTIDAD = Convert.ToDecimal(lsv_Det.Items[i].SubItems[2].Text);
                    objCPE_DETALLE.PRECIO = Convert.ToDecimal(lsv_Det.Items[i].SubItems[10].Text);//sin igv
                    objCPE_DETALLE.PRECIO_CONIGV = Convert.ToDecimal(lsv_Det.Items[i].SubItems[3].Text);
                    objCPE_DETALLE.IMPORTE = Convert.ToDecimal(lsv_Det.Items[i].SubItems[11].Text); //sin igv-iva
                    objCPE_DETALLE.IMPORTE_CONIGV = Convert.ToDecimal(lsv_Det.Items[i].SubItems[4].Text);
                    objCPE_DETALLE.PRECIO_TIPO_CODIGO = "01";//todos los productos incluyen el igv.
                    objCPE_DETALLE.IGV = Convert.ToDecimal(lsv_Det.Items[i].SubItems[12].Text);
                    objCPE_DETALLE.ISC = 0; //no aplica.
                    objCPE_DETALLE.COD_TIPO_OPERACION = "10"; //10-GRAVADO, 20 -EXONERADO
                    objCPE_DETALLE.CODIGO = lsv_Det.Items[i].SubItems[0].Text;
                    objCPE_DETALLE.DESCRIPCION = lsv_Det.Items[i].SubItems[11].Text;
                    objCPE_DETALLE.SUB_TOTAL = Convert.ToDecimal(lsv_Det.Items[i].SubItems[11].Text);
                    objCPE_DETALLE.PRECIO_SIN_IMPUESTO = Convert.ToDecimal(lsv_Det.Items[i].SubItems[10].Text);


                    OBJCPEDETALLE_LIST.Add(objCPE_DETALLE);

                }

                objCPE.detalle = OBJCPEDETALLE_LIST;
                //OBTENEMOS RESPUESTAS

                Dictionary<string, string> dicionaryenvio = new Dictionary<string, string>();
                dicionaryenvio = obj.Enviar_FacturaBoleta_aSunat(objCPE);

                //respuesta sunat
                TXTCOD_SUNAT.Text = dicionaryenvio["cod_sunat"];
                TXT_MSJ_SUNAT.Text = dicionaryenvio["msj_sunat"];
                TXTHASH_CPE.Text = dicionaryenvio["hash_cpe"];
                TXTHASHCDR.Text = dicionaryenvio["hash_cdr"];
                lbl_rutaXml.Text = obj.RutaCompletaxml;





            }
            catch (Exception ex)
            {

                MessageBox.Show("Creado variable para el XML: " + "\r\n" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


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
                //imgQR.Save(rutaqr);// primera img qr en bmp
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


        string RutaPdf_export = "D:\\CPE_2\\BETA\\";



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
                        for (int x = 1; x <= totalEspacio; x++) //PROBAR SINO COMENTARLO
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
            Guardar_Cotizacion();
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
                    coti.Vigencia = 15;
                    coti.TotalCotiza = Convert.ToDouble(lbl_TotalPagar.Text);
                    coti.Condiciones = "Cotizacion creada a Partir de una Venta Pausada";

                    coti.Preciocon_Igv = "Si";

                    coti.EstadoCoti = "Pendiente";


                    obj.RN_Registrar_Cotizacion(coti);
                    if (BD_Cotizacion.seguardo == true)
                    {
                        fil.Show();
                        RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(11);
                        ok.Lbl_msm1.Text = "Se ha Creado una Cotizacion Nro: " + txt_NroCotiza.Text + "para el Cliente, mientras decide que comprar";
                        ok.ShowDialog();
                        fil.Hide();

                        txt_buscar.Text = txt_NroCotiza.Text;

                        pnl_sinProd.Visible = true;
                        lsv_Det.Items.Clear();
                        txt_cliente.Text = "";
                        txt_NroCotiza.Text = "";
                        txt_nroPed.Text = "";
                        lbl_idcliente.Text = "-";

                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void Bucar_Cotizacion_paraAtender(string nroDoc)
        {

            //RN_Documento obj = new RN_Documento();
            RN_Cotizacion objCoti = new RN_Cotizacion();
            DataTable dato = new DataTable();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();


            string idprod;
            double xcant;

            try
            {
                dato = objCoti.RN_Buscar_Cotizacion_paraEditar(nroDoc.Trim());
                if (dato.Rows.Count > 0)
                {

                    var dt = dato.Rows[0];

                    //txt_NroDoc.Text = Convert.ToString(dt["id_Doc"]);
                    txt_nroPed.Text = Convert.ToString(dt["id_Ped"]);
                    txt_NroCotiza.Text = Convert.ToString(dt["Id_Cotiza"]);
                    //Cbo_TipoDoc.SelectedValue = Convert.ToUInt32(dt["Id_Tipo"]);
                    dtp_FechaEmi.Value = Convert.ToDateTime(dt["FechaCoti"]);
                    //txt_NroOperac.Text = Convert.ToString(dt["Nro_Operacion"]);
                    //Cbo_TipoPago.Text = Convert.ToString(dt["TipoPago"]);
                    lbl_idcliente.Text = Convert.ToString(dt["Id_Cliente"]);
                    txt_cliente.Text = Convert.ToString(dt["Razon_Social_Nombres"]);
                    lbl_direccion.Text = Convert.ToString(dt["Direccion"]);
                    lbl_dni_ruc.Text = Convert.ToString(dt["DNI"]);
                    txt_EstadoCoti.Text = Convert.ToString(dt["EstadoCoti"]);
                    if (txt_EstadoCoti.Text.Trim() == "Atendido")
                    {
                        fil.Show();
                        ver.Lbl_Msm1.Text = "Esta Cotizacion ya fue atendida, por favor, cargue otra que este Pendiente";
                        ver.ShowDialog();
                        fil.Hide();
                        Limpiar_todo();
                        pnl_sinProd.Visible = true;
                        txt_buscar.Text = "";
                        chk_coti.Checked = false;
                        return;
                    }

                    lsv_Det.Items.Clear();
                    //detalle del documento:
                    foreach (DataRow xitem in dato.Rows)
                    {

                        ListViewItem xlist;
                        idprod = xitem["Id_Pro"].ToString();

                        Buscar_Producto_DeCotizacion(idprod.Trim());
                        xcant = Convert.ToDouble(xitem["Cantidad"].ToString());
                        if (xcant > Convert.ToDouble(lbl_StockProdx.Text) && lbl_tipoProdx.Text.Trim().ToString() == "Producto")
                        {
                            if (Convert.ToDouble(lbl_StockProdx.Text) > 0 && Convert.ToDouble(lbl_StockProdx.Text) < xcant)
                            {
                                xlist = lsv_Det.Items.Add(xitem["Id_Pro"].ToString());
                                xlist.SubItems.Add(xitem["Descripcion_Larga"].ToString());
                                xlist.SubItems.Add(xitem["Cantidad"].ToString());
                                xlist.SubItems.Add(xitem["Precio"].ToString());
                                xlist.SubItems.Add(xitem["Importe"].ToString());
                                xlist.SubItems.Add(xitem["Tipo_Prod"].ToString());
                                xlist.SubItems.Add(xitem["Und_Medida"].ToString());
                                xlist.SubItems.Add(xitem["Utilidad_Unit"].ToString());
                                xlist.SubItems.Add(xitem["TotalUtilidad"].ToString());
                            }
                        }
                        else
                        {
                            xlist = lsv_Det.Items.Add(xitem["Id_Pro"].ToString());
                            xlist.SubItems.Add(xitem["Descripcion_Larga"].ToString());
                            xlist.SubItems.Add(xitem["Cantidad"].ToString());
                            xlist.SubItems.Add(xitem["Precio"].ToString());
                            xlist.SubItems.Add(xitem["Importe"].ToString());
                            xlist.SubItems.Add(xitem["Tipo_Prod"].ToString());
                            xlist.SubItems.Add(xitem["Und_Medida"].ToString());
                            xlist.SubItems.Add(xitem["Utilidad_Unit"].ToString());
                            xlist.SubItems.Add(xitem["TotalUtilidad"].ToString());
                        }

                    }
                    Calcular();
                    pnl_sinProd.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        private void Buscar_Producto_DeCotizacion(string idprodcto)
        {
            RN_Productos obj = new RN_Productos();
            DataTable data = new DataTable();

            try
            {

                data = obj.RN_Buscar_Productos(idprodcto);
                if (data.Rows.Count > 0)
                {

                    lbl_StockProdx.Text = Convert.ToString(data.Rows[0]["Stock_Actual"]);
                    lbl_tipoProdx.Text = Convert.ToString(data.Rows[0]["TipoProdcto"]);


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }


        private void Bucar_Documento_paraReimprimir(string nroDoc)
        {
            /* se deshabilito , se creo venta de reimpresion: 23-02-23
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
                        xlist.SubItems.Add(xitem["Precio"].ToString());
                        xlist.SubItems.Add(xitem["Importe"].ToString());
                        xlist.SubItems.Add(xitem["Tipo_Prod"].ToString());
                        xlist.SubItems.Add(xitem["Und_Medida"].ToString());
                        xlist.SubItems.Add(xitem["Utilidad_Unit"].ToString());
                        xlist.SubItems.Add(xitem["TotalUtilidad"].ToString());


                    }
                    Calcular();
                    pnl_sinProd.Visible = false;

                }
                else
                {
                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Addver ver = new Frm_Addver();

                    fil.Show();
                    ver.Lbl_Msm1.Text = "El Documento que buscas no existe, o talvez sea una Cotizacion, Marque el Check";
                    ver.ShowDialog();
                    fil.Hide();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }*/

        }

        private void lbl_lupa_Click(object sender, EventArgs e)
        {
            /* if (txt_buscar.Text.Trim().Length > 6)
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
            else if (Cbo_TipoPago.Text.Trim() == "Nota Credito")
            {
                //buscar la N.C
                Frm_Filtro fil = new Frm_Filtro();
                Frm_Solo_letNum solo = new Frm_Solo_letNum(); //verificar para el ingreso de numeros.
                fil.Show();
                solo.ShowDialog();
                fil.Hide();
                if (solo.Tag.ToString() == "A")
                {
                    string NroNotaCred = solo.txt_nro.Text;
                    BuscarNotaCredito_ParaPagos(NroNotaCred.Trim());
                }

            }
            else if (Cbo_TipoPago.Text.Trim() == "Vale")
            {
                //BUSCAMOS EL VALE:
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

        //nuevo metodo 11-05-23 para nc :

        private void BuscarNotaCredito_ParaPagos(string nroDoc)
        {
            RN_Notacredito obj = new RN_Notacredito();
            DataTable data = new DataTable();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();

            double ImporteNc = 0;
            double SaldoaPagar = 0;

            try
            {
                if (obj.RN_Verificar_SiNotaCredito_esParaPagos(nroDoc.Trim()) == true) //primero verifica con true o false:
                {
                    data = obj.RN_Buscar_NotaCredito_PendientePago(nroDoc); //luego muestra con datatable  si hay pendientes pago
                    if (data.Rows.Count > 0)
                    {
                        lbl_idNotaCred.Text = Convert.ToString(data.Rows[0]["Id_Cre"]);
                        lbl_ImporteNC.Text = Convert.ToString(data.Rows[0]["Vlr_Total"]);
                        ImporteNc = Convert.ToDouble(lbl_ImporteNC.Text);
                        //calculamos el saldo pendiente de pago:
                        SaldoaPagar = Convert.ToDouble(lbl_TotalPagar.Text) - ImporteNc;
                        lbl_saldo_Pdnte.Text = SaldoaPagar.ToString("###0.00");

                        fil.Show();
                        ver.Lbl_Msm1.Text = "El Saldo a Pagar es de: " + SaldoaPagar.ToString("###0.00");
                        ver.ShowDialog();
                        fil.Hide();
                        lbl_totalVale.Visible = false;


                    }

                }
                else
                {
                    fil.Show();
                    ver.Lbl_Msm1.Text = "El Documento Ingresado No existe o No es Válido para Pagos";
                    ver.ShowDialog();
                    fil.Hide();
                    return;
                }
            }
            catch (Exception ex)
            {

                throw;
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

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Print_NotaVenta nota = new Frm_Print_NotaVenta();
            int idempresa = Cls_Libreria.Idempresa;

            Registrar_Archivos_Temporales();

            if (Cbo_TipoDoc.Text == "Nota Venta" && idempresa == 1)
            {

                fil.Show();
                nota.Tag = txt_NroDoc.Text;
                nota.Imprimir_NotaVenta_Ticket();
                nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                nota.ShowDialog();
                fil.Hide();
                Limpiar_todo();
                pnl_sinProd.Visible = true;


            }
            else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 1)
            {
                fil.Show();
                nota.Tag = txt_NroDoc.Text;
                nota.Imprimir_BoletaFactura_Ticket(txt_NroDoc.Text);
                nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
               // nota.ShowDialog();
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
            else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 2)
            {
                //GERMAN EIRL:

                fil.Show();
                nota.Tag = txt_NroDoc.Text;
                nota.Imprimir_BoletaFactura_Ticket_GermanEIRL();
                nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                nota.ShowDialog();
                fil.Hide();
                Limpiar_todo();
                pnl_sinProd.Visible = true;
            }



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

        private void rdb_local_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_local.Checked == true)
            {
                lbl_server.Text = "0";
            }
        }

        private void rdb_sunat_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_sunat.Checked == true)
            {
                lbl_server.Text = "1";
            }
        }

        private void rdb_Prueba_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Prueba.Checked == true)
            {
                lbl_server.Text = "3";
            }
        }

        private void Cbo_TipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_TipoDoc.SelectedIndex == 0) //nota de venta
            {
                lbl_id_TipodocSunat.Text = "00"; //00

            }
            else if (Cbo_TipoDoc.SelectedIndex == 1) //boleta
            {
                lbl_id_TipodocSunat.Text = "03";

            }
            else if (Cbo_TipoDoc.SelectedIndex == 2) //Favtura
            {
                lbl_id_TipodocSunat.Text = "01";
            }
        }

        private void btn_Comprobar_Click(object sender, EventArgs e)
        {

            txt_NroDoc.Text = RN_TipoDoc.RN_NroID(Convert.ToInt32(Cbo_TipoDoc.SelectedValue));
            EnviarDocumento_dePrueba_Sunat();

        }


        private void EnviarDocumento_dePrueba_Sunat()
        {

            try
            {

                objCPE.TIPO_OPERACION = "0101"; //venta interna
                objCPE.TOTAL_GRAVADAS = Convert.ToDecimal(lbl_subtotal.Text);
                objCPE.SUB_TOTAL = Convert.ToDecimal(lbl_subtotal.Text);
                objCPE.POR_IGV = 18; //UBL2.1
                objCPE.TOTAL_IGV = Convert.ToDecimal(lbl_igv.Text);
                objCPE.TOTAL_ISC = 0; //impuesto selectivo al comsumidor //emp.importadoras
                objCPE.TOTAL_OTR_IMP = 0;
                objCPE.TOTAL_DESCUENTOGLO = 0;
                objCPE.TOTAL = Convert.ToDecimal(lbl_TotalPagar.Text);
                objCPE.TOTAL_EXPORTACION = 0;
                objCPE.TOTAL_LETRAS = lbl_son.Text;
                objCPE.NRO_GUIA_REMISION = "";
                objCPE.FECHA_GUIA_REMISION = "";
                objCPE.COD_GUIA_REMISION = "";
                objCPE.NRO_OTR_COMPROBANTE = "";
                objCPE.COD_OTR_COMPROBANTE = "";
                objCPE.NRO_COMPROBANTE = txt_NroDoc.Text; //FE01-00001
                objCPE.FECHA_DOCUMENTO = dtp_FechaEmi.Value.ToString("yyyy-MM-dd");
                objCPE.FECHA_VTO = dtp_FechaEmi.Value.ToString("yyyy-MM-dd");
                objCPE.COD_TIPO_DOCUMENTO = lbl_id_TipodocSunat.Text; //01- factura, 03 - boleta

                objCPE.COD_MONEDA = "PEN";
                objCPE.TIPO_COMPROBANTE_MODIFICA = "";
                objCPE.COD_TIPO_MOTIVO = "";
                objCPE.DESCRIPCION_MOTIVO = "";

                //datos del cliente;
                objCPE.NRO_DOCUMENTO_CLIENTE = lbl_dni_ruc.Text.Trim();
                objCPE.RAZON_SOCIAL_CLIENTE = txt_cliente.Text.Trim();
                objCPE.TIPO_DOCUMENTO_CLIENTE = lbl_idDni.Text.Trim();
                objCPE.DIRECCION_CLIENTE = lbl_direccion.Text.Trim();

                //ubigeo:
                objCPE.CIUDAD_CLIENTE = "LIMA";
                objCPE.COD_PAIS_CLIENTE = "PE";
                objCPE.COD_UBIGEO_CLIENTE = "";
                objCPE.DEPARTAMENTO_CLIENTE = "";
                objCPE.PROVINCIA_CLIENTE = "";
                objCPE.DISTRITO_CLIENTE = "";

                //datos de la empresa:
                objCPE.NRO_DOCUMENTO_EMPRESA = Lbl_RucEmisor.Text.Trim();
                objCPE.TIPO_DOCUMENTO_EMPRESA = "6";
                objCPE.NOMBRE_COMERCIAL_EMPRESA = Lbl_EmpresaEmisor.Text.Trim();
                objCPE.CODIGO_UBIGEO_EMPRESA = "150101";
                objCPE.DIRECCION_EMPRESA = Lbl_DireccionEmpresa.Text.Trim();
                objCPE.DEPARTAMENTO_EMPRESA = "Lima";
                objCPE.PROVINCIA_EMPRESA = "Lima";
                objCPE.DISTRITO_EMPRESA = "Lima";
                objCPE.CODIGO_PAIS_EMPRESA = "PE";
                objCPE.RAZON_SOCIAL_EMPRESA = Lbl_EmpresaEmisor.Text.Trim();
                objCPE.CONTACTO_EMPRESA = "";
                objCPE.USUARIO_SOL_EMPRESA = Lbl_UsuarioSol.Text.Trim();
                objCPE.PASS_SOL_EMPRESA = Lbl_ClaveSol.Text.Trim();
                objCPE.CONTRA_FIRMA = Lbl_ClaveCertificado.Text.Trim();

                objCPE.TIPO_PROCESO = 3;

                //al detalle f.e
                List<businessEntities.CPE_DETALLE> OBJCPEDETALLE_LIST = new List<businessEntities.CPE_DETALLE>();



                for (int i = 0; i < lsv_Det.Items.Count; i++)
                {
                    objCPE_DETALLE = new businessEntities.CPE_DETALLE();

                    objCPE_DETALLE.ITEM = i + 1;
                    objCPE_DETALLE.UNIDAD_MEDIDA = lsv_Det.Items[i].SubItems[13].Text;
                    objCPE_DETALLE.CANTIDAD = Convert.ToDecimal(lsv_Det.Items[i].SubItems[2].Text);
                    objCPE_DETALLE.PRECIO = Convert.ToDecimal(lsv_Det.Items[i].SubItems[10].Text);//sin igv
                    objCPE_DETALLE.PRECIO_CONIGV = Convert.ToDecimal(lsv_Det.Items[i].SubItems[3].Text);
                    objCPE_DETALLE.IMPORTE = Convert.ToDecimal(lsv_Det.Items[i].SubItems[11].Text); //sin igv-iva
                    objCPE_DETALLE.IMPORTE_CONIGV = Convert.ToDecimal(lsv_Det.Items[i].SubItems[4].Text);
                    objCPE_DETALLE.PRECIO_TIPO_CODIGO = "01";//todos los productos incluyen el igv.
                    objCPE_DETALLE.IGV = Convert.ToDecimal(lsv_Det.Items[i].SubItems[12].Text);
                    objCPE_DETALLE.ISC = 0; //no aplica.
                    objCPE_DETALLE.COD_TIPO_OPERACION = "10"; //10-GRAVADO, 20 -EXONERADO
                    objCPE_DETALLE.CODIGO = lsv_Det.Items[i].SubItems[0].Text;
                    objCPE_DETALLE.DESCRIPCION = lsv_Det.Items[i].SubItems[11].Text;
                    objCPE_DETALLE.SUB_TOTAL = Convert.ToDecimal(lsv_Det.Items[i].SubItems[11].Text);
                    objCPE_DETALLE.PRECIO_SIN_IMPUESTO = Convert.ToDecimal(lsv_Det.Items[i].SubItems[10].Text);

                    OBJCPEDETALLE_LIST.Add(objCPE_DETALLE);

                }

                objCPE.detalle = OBJCPEDETALLE_LIST;
                //OBTENEMOS RESPUESTAS

                Dictionary<string, string> dicionaryenvio = new Dictionary<string, string>();
                dicionaryenvio = obj.Enviar_FacturaBoleta_aSunat(objCPE);

                //respuesta sunat
                TXTCOD_SUNAT.Text = dicionaryenvio["cod_sunat"];
                TXT_MSJ_SUNAT.Text = dicionaryenvio["msj_sunat"];
                TXTHASH_CPE.Text = dicionaryenvio["hash_cpe"];
                TXTHASHCDR.Text = dicionaryenvio["hash_cdr"];

                if (TXTCOD_SUNAT.Text == "0" || TXTCOD_SUNAT.Text == "1")
                {
                    MessageBox.Show("La FE ha sido aprobado y califica para ser enviado a sunat : ", "comprobacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El comprobante fue rechazado:  " + TXT_MSJ_SUNAT.Text, "comprobacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Creado variable para el XML: " + "\r\n" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lbl_id_TipodocSunat_Click(object sender, EventArgs e)
        {

        }
    }
}

