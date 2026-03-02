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
using System.IO;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Productos;
using Prj_Capa_Negocio;

namespace Microsell_Lite.Compras
{
    public partial class Frm_Compras : Form
    {
        public Frm_Compras()
        {
            InitializeComponent();
        }

        private void Frm_Ventana_Ventas_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Llenar_Combo_Proveedores();
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
            //Configurar las colummnas:
            lis.Columns.Add("ID producto", 80, HorizontalAlignment.Left); //0
            lis.Columns.Add("Descripcion Producto", 400, HorizontalAlignment.Left); //1
            lis.Columns.Add("Cantidad", 80, HorizontalAlignment.Left); //2
            lis.Columns.Add("Precio Unit", 90, HorizontalAlignment.Right); //3
            lis.Columns.Add("Importe", 90, HorizontalAlignment.Right); //4

        }

        private void Llenar_Combo_Proveedores()
        {
            RN_Proveedor obj = new RN_Proveedor();
            DataTable dato = new DataTable();

            dato = obj.RN_Mostrar_Todos_Proveedores();
            if (dato.Rows.Count > 0)
            {
                var cbo = cbo_provee;

                cbo.DataSource = dato;
                cbo.DisplayMember = "NOMBRE";
                cbo.ValueMember = "IDPROVEE";
                cbo.SelectedIndex = -1;
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

        private void pnl_sinProd_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public static string xidprodcto;
        public static string xnombreprod;
        public static double xcant;
        public static double xprecio;
        public static double ximporte;

        private void Calcular()
        {
            double xtotal = 0;
            double xcant = 0;
            double xprecio = 0;
            double ximporte = 0;
            double xigv = 0;
            double xsubtotal = 0;


            for (int i = 0; i < lsv_Det.Items.Count; i++)
            {
                xcant = Convert.ToDouble(lsv_Det.Items[i].SubItems[2].Text);
                xprecio = Convert.ToDouble(lsv_Det.Items[i].SubItems[3].Text);

                //calculo
                ximporte = xprecio * xcant;
                lsv_Det.Items[i].SubItems[4].Text = ximporte.ToString("###0.00");

                //calculo del total:
                xtotal = xtotal + Convert.ToDouble(lsv_Det.Items[i].SubItems[4].Text);


            }
            //calculo del igv:
            xsubtotal = xtotal / 1.18;
            xigv = xsubtotal * 0.18;

            lbl_subtotal.Text = xsubtotal.ToString("###0.00");
            lbl_igv.Text = xigv.ToString("###0.00");
            lbl_TotalPagar.Text = xtotal.ToString("###0.00");


        }

        private void Agregar_Productos_alCarrito(string xidprod, string xnomprod, double xcant, double xprecio, double ximporte)
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

        private void btn_Nuevo_buscarProd_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Listado_Produc_IngresoCompras pro = new Frm_Listado_Produc_IngresoCompras();

            fil.Show();
            //pro.chk_cotiza.Checked = true;
            //Frm_ListadoProd_Compras.TipoVenta = "compra";

            pro.txt_buscar.Focus();
            pro.ShowDialog();
            fil.Hide();
            ////codigo valido:
            if (pro.Tag.ToString() == "A")
            {

                //Llamamos al metodo agrgar producto al carrito
                string _idprod = pro.lbl_IdProd.Text;
                string _nomprod = pro.lbl_NomProd.Text;

                double _cant = Convert.ToDouble(pro.lbl_Cant.Text);

                double _precio = Convert.ToDouble(pro.lbl_preCom.Text);
                double _importe = Convert.ToDouble(pro.lbl_preCom.Text);

                Agregar_Productos_alCarrito(_idprod.Trim(), _nomprod, _cant, _precio, _importe);
                txt_IdComp.Text = RN_TipoDoc.RN_NroID(9);

            }
            //vaidlo

            //if (pro.Tag.ToString() == "A")
            //{
            //    string _idprod;
            //    string _nomprod;
            //    double _cant = 0;
            //    double _precio = 0;
            //    double _importe = 0;
            //    string _und;
            //    string _tipoProd;
            //    Double _Utili_Unit;

            //    if (pro.lsv_Ped_comp.Items.Count > 0)
            //    {
            //        for (int i = 0; i < pro.lsv_Ped_comp.Items.Count; i++)
            //        {
            //            var item = pro.lsv_Ped_comp.Items[i];
            //            _idprod = item.SubItems[0].Text;
            //            _nomprod = item.SubItems[1].Text;
            //            _cant = Convert.ToDouble(item.SubItems[3].Text);
            //            _precio = Convert.ToDouble(pro.lbl_preCom.Text);
            //            _importe = Convert.ToDouble(pro.lbl_preCom.Text);
            //            //_und = item.SubItems[2].Text;
            //            //_tipoProd = item.SubItems[8].Text;
            //            //_Utili_Unit = Convert.ToDouble(item.SubItems[6].Text);

            //            Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe);
            //            txt_IdComp.Text = RN_TipoDoc.RN_NroID(9);
            //        }
            //    }
            //    else
            //    {
            //        //para agregar de uno en Uno:
            //        _idprod = pro.lbl_IdProd.Text;
            //        _nomprod = pro.lbl_NomProd.Text;
            //        _cant = Convert.ToDouble(pro.lbl_Cant.Text);
            //        _precio = Convert.ToDouble(pro.lbl_preCom.Text);
            //        _importe = Convert.ToDouble(pro.lbl_preCom.Text);
            //        //_und = xpro.lbl_Und.Text;
            //        //_tipoProd = xpro.lbl_TipoProd.Text;
            //        //_Utili_Unit = Convert.ToDouble(xpro.lbl_Uti_Unit.Text);

            //        Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe);
            //        txt_IdComp.Text = RN_TipoDoc.RN_NroID(9);
            //    }

            //}

        }


        private void bt_add_Click(object sender, EventArgs e)//-----
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Listado_Produc_IngresoCompras pro = new Frm_Listado_Produc_IngresoCompras();

            fil.Show();
            pro.txt_buscar.Focus();
            //pro.chk_cotiza.Checked = true;
            //Frm_Listado_Produc_IngresoCompras.TipoVenta = "compra";
            pro.ShowDialog();
            fil.Hide();

            //--metodo original system


            if (pro.Tag.ToString() == "A")
            {
                //Llamamos al metodo agrgar producto al carrito

                string _idprod = pro.lbl_IdProd.Text;
                string _nomprod = pro.lbl_NomProd.Text;
                double _cant = Convert.ToDouble(pro.lbl_Cant.Text);
                double _precio = Convert.ToDouble(pro.lbl_preCom.Text);
                double _importe = Convert.ToDouble(pro.lbl_preCom.Text);

                Agregar_Productos_alCarrito(_idprod.Trim(), _nomprod, _cant, _precio, _importe);
            }
            //fin original-




            //if (pro.Tag.ToString() == "A")
            //{
            //    //string _idprod;
            //    //string _nomprod;
            //    //double _cant = 0;
            //    //double _precio = 0;
            //    //double _importe = 0;
            //    //string _und;
            //    //string _tipoProd;
            //    //Double _Utili_Unit;

            //    if (pro.lsv_Ped.Items.Count > 0)
            //    {
            //        for (int i = 0; i < pro.lsv_Ped.Items.Count; i++)
            //        {
            //            var item = pro.lsv_Ped.Items[i];
            //            string _idprod = pro.lbl_IdProd.Text;
            //            string _nomprod = pro.lbl_NomProd.Text;
            //            double _cant = Convert.ToDouble(pro.lbl_Cant.Text);
            //            double _precio = Convert.ToDouble(pro.lbl_Pre_Unit.Text);
            //            double _importe = Convert.ToDouble(pro.lbl_Pre_Unit.Text);
            //            //_tipoProd = item.SubItems[8].Text;
            //            //_Utili_Unit = Convert.ToDouble(item.SubItems[6].Text);

            //            Agregar_Productos_alCarrito(_idprod.Trim(), _nomprod, _cant, _precio, _importe);

            //        }
            //    }
            //    else
            //    {
            //        //para agregar de uno en Uno:
            //        string _idprod = pro.lbl_IdProd.Text;
            //        string _nomprod = pro.lbl_NomProd.Text;
            //        double _cant = Convert.ToDouble(pro.lbl_Cant.Text);
            //        double _precio = Convert.ToDouble(pro.lbl_Pre_Unit.Text);
            //        double _importe = Convert.ToDouble(pro.lbl_Pre_Unit.Text);
            //        //_und = pro.lbl_Und.Text;
            //        //_tipoProd = pro.lbl_TipoProd.Text;
            //        //_Utili_Unit = Convert.ToDouble(pro.lbl_Uti_Unit.Text);

            //        Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe);
            //    }

            //}

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
                sino.Lbl_msm1.Text = "Estas seguro de Quitar este producto del Sistema?";
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

        private void Frm_Compras_KeyDown(object sender, KeyEventArgs e)
        {
            //Para juego de teclas en el formulario
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
                   bt_editCant_Click(sender, e);
                }
            }


            if (e.KeyCode == Keys.F5)
            {
                if (pnl_sinProd.Visible == false)
                {
                    bt_Delete_Click(sender, e);
                }
            }

            if (e.KeyCode == Keys.F6)
            {
                if (pnl_sinProd.Visible == false)
                {
                    btn_procesar_Click(sender, e);
                }
            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.A))
            {
                if (pnl_sinProd.Visible == false)
                {
                    cbo_provee.Focus();
                }

            }
        }

        private bool Validar_Compras()
        {
            //se puede seguir validando mas campos opcional:
            Frm_Filtro fil = new Frm_Filtro();
            if (lsv_Det.Items.Count == 0) { fil.Show(); MessageBox.Show("Ingresa almenos un Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); lsv_Det.Focus(); return false; }
            if (cbo_provee.SelectedIndex == -1) { fil.Show(); MessageBox.Show("Selecciona Almenos un Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_provee.Focus(); return false; }
            if (txt_NroFisico.Text.Trim().Length < 2) { fil.Show(); MessageBox.Show("Ingresa el Nro de Factura Fisica", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); txt_NroFisico.Focus(); return false; }
            if (cbo_tipoPago.SelectedIndex == -1) { fil.Show(); MessageBox.Show("Selecciona el Tipo de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_tipoPago.Focus(); return false; }
            if (cbo_tipoDoc.SelectedIndex == -1) { fil.Show(); MessageBox.Show("Selecciona un Tipo de Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_tipoDoc.Focus(); return false; }

            return true;
        }

        //Inicio-- Para calcular la utilidad del producto
        private double Buscar_Frank_Producto(string idprod)
        {
            RN_Productos obj = new RN_Productos();
            DataTable dato = new DataTable();

            double frank = 0;

            dato = obj.RN_Buscar_Productos(idprod);
            if (dato.Rows.Count > 0)
            {
                //margen de utilidad 
                frank = Convert.ToDouble(dato.Rows[0]["Frank"]);
                return frank;
            }
            else
            {
                return 0;
            }

        }
        //Fin--


        private void Registrar_Compra()
        {

            EN_IngresoCompra com = new EN_IngresoCompra();
            EN_Det_IngresoCompra det = new EN_Det_IngresoCompra();
            RN_Ingreso_Compra obj = new RN_Ingreso_Compra();
            
            RN_Productos pro = new RN_Productos();

            //Frm_Print_Compras imp = new 

            try
            {

                com.IdCom = txt_IdComp.Text;
                com.NroDoc_Fisico = txt_NroFisico.Text;
                com.IdProvee = cbo_provee.SelectedValue.ToString();
                com.SubTotal_Com = Convert.ToDouble(lbl_subtotal.Text);
                com.FechaIngre = dtp_FechaCom.Value;
                com.TotalCompra = Convert.ToDouble(lbl_TotalPagar.Text);
                com.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                com.ModalidadPago = cbo_tipoPago.Text;
                com.TiempoEspera = 0;
                com.FechaVence = dtp_FechaVenc.Value;
                com.EstadoIngre = "Activo";
                com.RecibiConforme = recibiConforme;
                com.Datos_Adicional = txt_obser.Text;
                com.Tipo_Doc_Compra = cbo_tipoDoc.Text;


                /*tipo salida:
                 
                  cmd.Parameters.AddWithValue("@TipoRegistro", com.TipoRegistro);
                cmd.Parameters.AddWithValue("@LugarSalida", com.LugarSalida);
                cmd.Parameters.AddWithValue("@TipoProceso", com.TipoProceso);
                cmd.Parameters.AddWithValue("@trn_codigo", com.TrnCodigo);
                 
                 */
                com.TipoRegistro = "-";
                com.LugarSalida = "-";
                com.TipoProceso = "-";
                com.TrnCodigo = "-";

                obj.RN_Ingresar_RegistroCompra(com);

                if (BD_Ingreso_Compra.seguardo == true)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(9);

                    //GUARDAMOS EL DETALLE 
                    for (int i = 0; i < lsv_Det.Items.Count; i++)
                    {
                        var item = lsv_Det.Items[i];

                        det.Idingreso = txt_IdComp.Text;
                        det.Idproducto = item.SubItems[0].Text;
                        det.Cantidad = Convert.ToDouble(item.SubItems[2].Text);
                        det.Precio = Convert.ToDouble(item.SubItems[3].Text);
                        det.Importe = Convert.ToDouble(item.SubItems[4].Text);

                        obj.RN_Ingresar_Detalle_RegistroCompra(det);
                        Registrar_MovimientoKardex(det.Idproducto.Trim(), det.Cantidad, det.Precio);

                        //ahora actualizamos el precio del producto:
                        double utilidad = 0;
                        double valorAlmacen = 0;
                        double PreCompra = det.Precio;
                        double PreVenta = 0;
                        double xfrank = 0;

                        xfrank = Buscar_Frank_Producto(det.Idproducto.Trim());

                        PreVenta = xfrank * PreCompra; //caluclamos el valor de venta
                        utilidad = PreVenta - PreCompra; //para sacar la utilidad del producto
                        valorAlmacen = det.Cantidad * PreCompra; //valor de almacen

                        pro.RN_Actualizar_PrecioCompra_Producto(det.Idproducto.Trim(), PreCompra, PreVenta, utilidad, valorAlmacen);


                    }

                    //terminamos:

                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

                    fil.Show();
                    ok.Lbl_msm1.Text = "Los Datos de la Compra se han Registrado Exitosamente";
                    ok.ShowDialog();
                    fil.Hide();



                    //limpiar cajas texto
                    lsv_Det.Items.Clear();
                    cbo_provee.SelectedIndex = -1;
                    txt_NroFisico.Text = "";
                    cbo_tipoDoc.Text = "";
                    cbo_tipoPago.Text = "";

                    this.Tag = "A";
                    this.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Registrar_MovimientoKardex(string idprod, double xcant, double xpreCompra)
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


            try
            {
                if (obj.RN_Verificar_Producto_siTieneKardex(idprod) == true)
                {
                    //si tiene kardex es valido:
                    dato = obj.RN_Buscar_KardexDetalle_porProducto(idprod.Trim());
                    if (dato.Rows.Count > 0)
                    {
                        xidkardex = Convert.ToString(dato.Rows[0]["Id_krdx"]);
                        xitem = dato.Rows.Count;
                        //leemos los datos del producto 
                        datoprod = objpro.RN_Buscar_Productos(idprod.Trim());
                        stockProd = Convert.ToDouble(datoprod.Rows[0]["Stock_Actual"]);
                        precioCompraProd = Convert.ToDouble(datoprod.Rows[0]["Pre_CompraS"]);

                        //registramos el Detalle del Kardex:

                        kar.Idkardex = xidkardex;
                        kar.Item = xitem + 1;
                        kar.Doc_soporte = txt_NroFisico.Text;
                        kar.Det_Operacion = "Compra de Mercaderia";
                        kar.TipoOperacion = "Compra de Mercaderia";
                        //salidas:
                        kar.Cantidad_in = xcant;
                        kar.Precio_In = xpreCompra;
                        kar.Total_In = xcant * xpreCompra;
                        //salida:
                        kar.Cantidad_Out = 0;
                        kar.Precio_out = 0;
                        kar.Total_out = 0;
                        //saldos:
                        kar.Cantidad_saldo = stockProd + xcant;
                        kar.Promedio = xpreCompra;
                        kar.Total_saldo = xpreCompra * kar.Cantidad_saldo;
                        kar.CantiDiferencial = "0";
                        kar.ImporteDiferencial = 0;
                        kar.Observacion = txt_obser.Text;

                        obj.RN_Registrar_Detalle_Kardex(kar);


                        //ahora actualizamos nuestro stock de la tabla de productos:
                        objpro.RN_Sumar_Stock_Producto(idprod.Trim(), xcant);

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_procesar_Click(object sender, EventArgs e)
        {
            if (Validar_Compras() == true)
            {
                Registrar_Compra();
            }



        }

        bool recibiConforme = false;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                recibiConforme = true;
            }
            else
            {
                recibiConforme = false;
            }
        }
    }
}
