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
using Microsell_Lite.Proveedor;
using Prj_Capa_Negocio;
using Microsell_Lite.Informe;

using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

//IMPORTACION F.E
//using BER = BusinessEntitiesNew;
using BE = businessEntities;
using EV= CPEEnvio;
using CrearXML;
using Signature;
using System.Net;



namespace Microsell_Lite.Compras
{
    public partial class Frm_SalidaMercaderia : Form
    {

        
        public Frm_SalidaMercaderia()
        {
            InitializeComponent();

            cboDepartamento.SelectedIndexChanged += cboDepartamento_SelectedIndexChanged;
            cboProvincia.SelectedIndexChanged += cboProvincia_SelectedIndexChanged;
            cboDistrito.SelectedIndexChanged += cboDistrito_SelectedIndexChanged;
        }

        private void Frm_SalidaMercaderia_Load(object sender, EventArgs e)
        {
            LoadDepartamentos();
            Configurar_listView();
            Llenar_Combo_Proveedores();
            Leer_Dato_Empresa();
            
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
            lis.Columns.Add("Und", 0, HorizontalAlignment.Right); //5

        }
        private void Leer_Dato_Empresa()
        {
            RN_Empresa obj = new RN_Empresa();
            DataTable data = new DataTable();

            try
            {
                data = obj.RN_Buscar_Empresa_porId(Convert.ToInt32(Cls_Libreria.Idempresa)); //CONVERT.TOIN32(CLS.IDEMPRESA) Y DEMAS METODOS
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
                cbo.SelectedIndex = 1;
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

        private void Agregar_Productos_alCarrito(string xidprod, string xnomprod, double xcant, double xprecio, double ximporte, string xund)
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
                    item.SubItems.Add(xund.ToString());

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
                    item.SubItems.Add(xund);

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

            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Addver ver = new Frm_Addver();

            //RN_Documento obj = new RN_Documento();



            
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Listado_Produc_IngresoCompras pro = new Frm_Listado_Produc_IngresoCompras();

            fil.Show();
        

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
                string _und = "NIU";

                Agregar_Productos_alCarrito(_idprod.Trim(), _nomprod, _cant, _precio, _importe, _und);
                txt_IdComp.Text = RN_TipoDoc.RN_NroID(9);

            }
            

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
                string _und = "NIU";

                Agregar_Productos_alCarrito(_idprod.Trim(), _nomprod, _cant, _precio, _importe, _und);
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
            //if (cbo_provee.SelectedIndex == -1) { fil.Show(); MessageBox.Show("Selecciona Almenos un Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_provee.Focus(); return false; }
            if (txt_origen.Text.Trim().Length < 2) { fil.Show(); MessageBox.Show("Ingresa la procedencia de la mercaderia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); txt_origen.Focus(); return false; }
            //if (txt_origen.Text.SelectedIndex == -1) { fil.Show(); MessageBox.Show("Selecciona el Tipo de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_tipoPago.Focus(); return false; }
            if (cbo_motivo.SelectedIndex == -1) { fil.Show(); MessageBox.Show("Selecciona un Tipo de Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_motivo.Focus(); return false; }

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
                com.NroDoc_Fisico = txt_IdComp.Text;
                com.IdProvee = cbo_provee.SelectedValue.ToString();
                com.SubTotal_Com = Convert.ToDouble(lbl_subtotal.Text);
                com.FechaIngre = dtp_FechaCom.Value;
                com.TotalCompra = Convert.ToDouble(lbl_TotalPagar.Text);
                com.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                com.ModalidadPago = "Efectivo";
                com.TiempoEspera = 0;
                com.FechaVence = dtp_FechaCom.Value;
                com.EstadoIngre = "Activo";
                com.RecibiConforme = recibiConforme;
                com.Datos_Adicional = txt_destino.Text;
                com.Tipo_Doc_Compra = "Otros";

                //para la salida 
                com.TipoRegistro = cbo_motivo.Text;
                com.LugarSalida = txt_origen.Text;
                com.TipoProceso = "Salida";
                com.TrnCodigo = "TRN-0001";

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

                       


                    }

                    Enviar_Documento_aSunat();

                    //terminamos:

                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

                    fil.Show();
                    ok.Lbl_msm1.Text = "Los Datos se han Registrado Exitosamente";
                    ok.ShowDialog();
                    fil.Hide();

                    //enviamos a imprimir

                    Frm_Print_Informe_Almacen informe = new Frm_Print_Informe_Almacen();
                    fil.Show();
                    informe.NroDoc = txt_IdComp.Text;
                    informe.lbl_nroDoc.Text = txt_IdComp.Text;
                    informe.tipoDoc = "salidaalma";
                    informe.ShowDialog();
                    fil.Hide();



                    //limpiar cajas texto
                    lsv_Det.Items.Clear();
                    //cbo_provee.SelectedIndex = -1;
                    //txt_NroFisico.Text = "";
                    //cbo_tipoDoc.Text = "";
                    

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
                        kar.Doc_soporte = txt_IdComp.Text;
                        kar.Det_Operacion = cbo_motivo.Text + " de Mercaderia";
                        //entrada:
                        kar.Cantidad_in = 0;
                        kar.Precio_In = 0;
                        kar.Total_In = 0;
                        //salida:
                        kar.Cantidad_Out = xcant;
                        kar.Precio_out = xpreCompra;
                        kar.Total_out = xcant * xpreCompra;
                        //saldos:
                        kar.Cantidad_saldo = stockProd - xcant;
                        kar.Promedio = xpreCompra;
                        kar.Total_saldo = xpreCompra * kar.Cantidad_saldo;
                        kar.CantiDiferencial = "0";
                        kar.ImporteDiferencial = 0;

                        obj.RN_Registrar_Detalle_Kardex(kar);


                        //ahora actualizamos nuestro stock de la tabla de productos:
                        objpro.RN_Restar_Stock_Producto(idprod.Trim(), xcant);

                    }
                    else
                    {
                        MessageBox.Show("El Producto: " + idprod + "No tiene Kardex", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                else
                {
                    MessageBox.Show("El Producto: " + idprod + "No tiene Kardex", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        DataTable objtemComprobate;
        DataRow objTemFilaComprobante;

        //BER.CPE_GUIA_REMISION objCPE_GUIA = new BER.CPE_GUIA_REMISION();
        //BER.CPE_GUIA_REMISION_DETALLE objCPE_DETALLE = new BER.CPE_GUIA_REMISION_DETALLE();
        BE.CPE_GUIA_REMISION objCPE_GUIA = new BE.CPE_GUIA_REMISION();
        BE.CPE_GUIA_REMISION_DETALLE objCPE_DETALLE = new BE.CPE_GUIA_REMISION_DETALLE();
        CPEConfig obj = new CPEConfig();
       


        private async void Enviar_Documento_aSunat()
        {
            objCPE_GUIA.NRO_COMPROBANTE = txt_IdComp.Text.Trim(); //T-00001  - GRT-V((31)
            objCPE_GUIA.FECHA_DOCUMENTO = dtp_FechaCom.Value.ToString("yyyy-MM-dd");
            objCPE_GUIA.COD_TIPO_DOCUMENTO = "09";//lbl_id_TipodocSunat.Text;//tipo doc guia (09-grremitente / 31-transportista)
            objCPE_GUIA.NOTA = "obs";

            //objCPE_GUIA.ITEM_ENVIO = 1;

            objCPE_GUIA.TIPO_DOCUMENTO_CLIENTE = "6";
            objCPE_GUIA.NRO_DOCUMENTO_CLIENTE = "20606264004";
            objCPE_GUIA.RAZON_SOCIAL_CLIENTE = "C.G CAPITAL SYSTEM S.A.C";

            objCPE_GUIA.COD_MOTIVO_TRASLADO = lbl_CodMotivo.Text; //"1"; //catal-20
            objCPE_GUIA.COD_MODALIDAD_TRASLADO = lbl_CodModalidadTraslado.Text; // "2";//catalogo18-TRANSPORTE PRIVADO  - T.publico 1
            objCPE_GUIA.DESCRIPCION_MOTIVO_TRASLADO = cbo_motivo.SelectedValue.ToString(); // "Venta"; //02compra-(03-vnta,entrega tercero)(04-traslado entre establicimiento,misma empresa)
            objCPE_GUIA.COD_UND_PESO_BRUTO = "KGM";
            objCPE_GUIA.PESO_BRUTO =Convert.ToDecimal(1.00);
            objCPE_GUIA.FECHA_INICIO = dtp_fechaTraslado.Value.ToString("yyyy-MM-dd"); //dtp_FechaCom.Value.ToString("yyyy-MM-dd");//"2024-11-26";
           
            //Transporte publico
            objCPE_GUIA.TIPO_DOCUMENTO_TRANSPORTISTA = "6";
            objCPE_GUIA.NRO_DOCUMENTO_TRANSPORTISTA = txt_rucTrnPublico.Text;//"";
            objCPE_GUIA.RAZON_SOCIAL_TRANSPORTISTA = txt_rznTranPublico.Text;//"";
            objCPE_GUIA.MTC_TRANSPORTISTA = txt_trnMtcPublico.Text; //"";


            //TRANSPORTE PRIVADO:
            objCPE_GUIA.NRO_DOC_CHOFER = txt_dniConductor.Text;// "87654321";
            objCPE_GUIA.NOMBRE_CHOFER = txt_nomConductor.Text; //"JUAN";
            objCPE_GUIA.APELLIDO_CHOFER = "PEREZ";
            objCPE_GUIA.LICENCIA_CHOFER = txt_licenciaCond.Text;//"Q87654321";
            objCPE_GUIA.PLACA_VEHICULO = "123QWE";

            //direccion destino -delivery
            objCPE_GUIA.COD_UBIGEO_DESTINO = txtUbigeos.Text.Trim(); //"140117";
            objCPE_GUIA.DIRECCION_DESTINO = txt_destino.Text.Trim();// "av la mar, pueblo libre";

            //ORIGEN:
            objCPE_GUIA.COD_UBIGEO_ORIGEN = "110507";
            objCPE_GUIA.DIRECCION_ORIGEN = "Direc 1";

            ////direccion destino -delivery
            //objCPE_GUIA.COD_UBIGEO_DESTINO = "140117";
            //objCPE_GUIA.DIRECCION_DESTINO = "av la mar, pueblo libre";


            //datos de la empresa:
            objCPE_GUIA.NRO_DOCUMENTO_EMPRESA = Lbl_RucEmisor.Text.Trim();
            objCPE_GUIA.TIPO_DOCUMENTO_EMPRESA = "6";
            objCPE_GUIA.RAZON_SOCIAL_EMPRESA = Lbl_EmpresaEmisor.Text.Trim();
            objCPE_GUIA.COD_UBIGEO_EMPRESA = "150101"; // -   //san miguel 150136
            objCPE_GUIA.DIRECCION_EMPRESA = Lbl_DireccionEmpresa.Text.Trim();
            objCPE_GUIA.DEPARTAMENTO_EMPRESA = "Lima";
            objCPE_GUIA.PROVINCIA_EMPRESA = "Lima";
            objCPE_GUIA.DISTRITO_EMPRESA = "Lima";
            //objCPE.CODIGO_PAIS_EMPRESA = "PE";
            objCPE_GUIA.RAZON_SOCIAL_EMPRESA = Lbl_EmpresaEmisor.Text.Trim();
            //objCPE.CONTACTO_EMPRESA = "";
            objCPE_GUIA.USUARIO_SOL_EMPRESA = "20608131494MODDATOS";//Lbl_RucEmisor.Text.Trim() + Lbl_UsuarioSol.Text.Trim();
            objCPE_GUIA.PASS_SOL_EMPRESA = "MODDATOS";//Lbl_ClaveSol.Text.Trim();
            objCPE_GUIA.CONTRA_FIRMA = Lbl_ClaveCertificado.Text.Trim();

            //DATOS TOKEN:
            objCPE_GUIA.CLIENT_ID = "test-85e5b0ae-255c-4891-a595-0b98c65c9854"; //Lbl_CLIENT_ID.Text.Trim();
            objCPE_GUIA.CLIENT_SECRET = "test-Hty/M6QshYvPgItX2P0+Kw==";//lbl_CLIENT_SECRET.Text.Trim();

            //string token = await obj.GetToken(objCPE_GUIA.CLIENT_ID, objCPE_GUIA.CLIENT_SECRET, objCPE_GUIA.USUARIO_SOL_EMPRESA, objCPE_GUIA.PASS_SOL_EMPRESA);

            objCPE_GUIA.TOKEN = "test-eyJhbGciOiJIUzUxMiJ9.ImY3MTM4NGVlLTg1YjctNDVjMC04ZGQyLTJkZjhiZDEzMmJlZSI.PIUCoQ6dkLYGSpzygLpfnbVCwxhlzercLrApn6OqPUHUgBe6wmNAcnSDcC93EPG8LiVSXYbPmM6FrHwANrLUbw";//token;
                                                                                                                                                                                                       //objCPE_GUIA.TOKEN = lbl_Token.Text.Trim();
                                                                                                                                                                                                       //objCPE.CONTRA_FIRMA = Lbl_ClaveCertificado.Text.Trim();

            //List<businessEntities.CPE_GUIA_REMISION_DETALLE> OBJCPEDETALLE_LIST = new List<businessEntities.CPE_GUIA_REMISION_DETALLE>();
            List<businessEntities.CPE_GUIA_REMISION_DETALLE> OBJCPE_LIST = new List<businessEntities.CPE_GUIA_REMISION_DETALLE>();

            double pre1 = 0;
            double import=0;

            for (int i = 0; i < lsv_Det.Items.Count; i++)
            {
                objCPE_DETALLE = new businessEntities.CPE_GUIA_REMISION_DETALLE();

                objCPE_DETALLE.ITEM = i + 1;
                objCPE_DETALLE.UNIDAD_MEDIDA = lsv_Det.Items[i].SubItems[5].Text; //"NIU"
                objCPE_DETALLE.CANTIDAD = Convert.ToDecimal( lsv_Det.Items[i].SubItems[2].Text);
                objCPE_DETALLE.ORDER_ITEM = objCPE_DETALLE.ITEM;
                pre1 =Convert.ToDouble( lsv_Det.Items[i].SubItems[3].Text);
                import = Convert.ToDouble(lsv_Det.Items[i].SubItems[4].Text);
                objCPE_DETALLE.CODIGO = lsv_Det.Items[i].SubItems[0].Text;
                objCPE_DETALLE.DESCRIPCION = lsv_Det.Items[i].SubItems[1].Text; //11
                //objCPE_DETALLE.ORDER_ITEM = i;
                

                OBJCPE_LIST.Add(objCPE_DETALLE);

            }

            objCPE_GUIA.detalle = OBJCPE_LIST;
            //OBTENEMOS RESPUESTAS

            Dictionary<string, string> dicionaryenvio = new Dictionary<string, string>();
            dicionaryenvio = await obj.Enviar_GuiaRemision_aSunat(objCPE_GUIA);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            ////respuesta sunat
            //TXTCOD_SUNAT.Text = dicionaryenvio["cod_sunat"];
            //TXT_MSJ_SUNAT.Text = dicionaryenvio["msj_sunat"];
            //TXTHASH_CPE.Text = dicionaryenvio["hash_cpe"];
            //TXTHASHCDR.Text = dicionaryenvio["hash_cdr"];
            lbl_rutaXml.Text = obj.RutaCompletaxml;

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

        private void cbo_tipoDoc_Guia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_tipoDoc_Guia.SelectedIndex == 0) //Guia remision Remitente
            {
                lbl_id_TipodocSunat.Text = "09"; //00

            }else if (cbo_tipoDoc_Guia.SelectedIndex ==1)
            {
                lbl_id_TipodocSunat.Text = "31"; //guia transportista
            }
        }





        private void gunaLabel2_Click(object sender, EventArgs e)
        {

        }

        private void LoadDepartamentos()
        {
            RN_Ubigeo obj = new RN_Ubigeo();
            //BD_Ubigeo obj = new BD_Ubigeo();
            DataTable dato = new DataTable();


           // dato = obj.RN_Listar_Ubigeos();

            var departamentos = dato.DefaultView.ToTable(true, "Departamento");
            cboDepartamento.DisplayMember = "Departamento";
            cboDepartamento.ValueMember = "Departamento";
            cboDepartamento.DataSource = departamentos;
        }


        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.SelectedValue != null)
            {
                LoadProvincias(cboDepartamento.SelectedValue.ToString());
            }
        }

        private void LoadProvincias(string departamento)
        {
            RN_Ubigeo obj = new RN_Ubigeo();
            //BD_Ubigeo obj = new BD_Ubigeo();
            DataTable dato = new DataTable();
            //dato = obj.RN_Listar_Ubigeos();
            var provincias = dato.Select($"Departamento = '{departamento}'").CopyToDataTable().DefaultView.ToTable(true, "Provincia");
            cboProvincia.DisplayMember = "Provincia";
            cboProvincia.ValueMember = "Provincia";
            cboProvincia.DataSource = provincias;
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedValue != null)
            {
                LoadDistritos(cboDepartamento.SelectedValue.ToString(), cboProvincia.SelectedValue.ToString());
            }
        }
        private void LoadDistritos(string departamento, string provincia)
        {
            RN_Ubigeo obj = new RN_Ubigeo();
            //BD_Ubigeo obj = new BD_Ubigeo();
            DataTable dato = new DataTable();
            //dato = obj.RN_Listar_Ubigeos();

            var distritos = dato.Select($"Departamento = '{departamento}' AND Provincia = '{provincia}'").CopyToDataTable();
            cboDistrito.DisplayMember = "Distrito";
            cboDistrito.ValueMember = "Ubigeo";
            cboDistrito.DataSource = distritos;
        }

        private void cboDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDistrito.SelectedValue != null)
            {
                txtUbigeos.Text = cboDistrito.SelectedValue.ToString();
            }
        }

        private void cbo_motivo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbo_motivo.SelectedIndex == 0) 
            {
                lbl_CodMotivo.Text = "1"; //00
                

            }
            else if (cbo_motivo.SelectedIndex == 1)
            {
                lbl_CodMotivo.Text = "2"; //compra
            }
            else if(cbo_motivo.SelectedIndex == 2)
            {
                lbl_CodMotivo.Text = "3"; //venta con entrega a terceros
            }
            else if(cbo_motivo.SelectedIndex == 3)
            {
                lbl_CodMotivo.Text = "4";//traslado entre establecimientos de la misma empresa
            }
        }

        private void cbo_ModalidadTraslado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_ModalidadTraslado.SelectedIndex == 0)
            {
                lbl_CodModalidadTraslado.Text = "1"; // trasnporte publico

            }else if (cbo_ModalidadTraslado.SelectedIndex == 1)
            {
                lbl_CodModalidadTraslado.Text = "2"; // trasnporte privado
            }
        }

        private void lbl_busProv_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_ListadoProveedor lis = new Frm_ListadoProveedor();

            fil.Show();
            lis.ShowDialog();

            fil.Hide();

            if (lis.Tag.ToString() == "A")
            {
                txt_razonsocialProv.Text = lis.lbl_nom.Text;
                lbl_idProvee.Text = lis.lbl_id.Text;
                txt_rucProv.Text = lis.lbl_rucProv.Text;


            }
        }
    }
}
