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
using Microsell_Lite.Cliente;
using Prj_Capa_Negocio;
using Microsell_Lite.GUIAREMISION;
using Microsell_Lite.Informe;
using Microsell_Lite.Compras;

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
using Guna.UI.WinForms;



namespace Microsell_Lite.GUIAREMISION
{
    public partial class Frm_GuiaRem_Transportista : Form
    {

        
        public Frm_GuiaRem_Transportista()
        {
            InitializeComponent();

            cboDepartamento.SelectedIndexChanged += cboDepartamento_SelectedIndexChanged;
            cboProvincia.SelectedIndexChanged += cboProvincia_SelectedIndexChanged;
            cboDistrito.SelectedIndexChanged += cboDistrito_SelectedIndexChanged;

            //string empresa = txt_razonsocialCliente.Text;
            //string ruc = txt_rucCliente.Text;
            //txt_concat_razonRuc.Text = $"{empresa}-{ruc}";
        }

        private void Frm_SalidaMercaderia_Load(object sender, EventArgs e)
        {
            Convert.ToDateTime(dtp_fechaTraslado.Value = DateTime.Now);
            LoadDepartamentos();
            Configurar_listView();
            Llenar_Combo_Proveedores();
            Leer_Dato_Empresa();

            InitializeGuna2NumericUpDown();


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
                    Lbl_CLIENT_ID.Text = Convert.ToString(data.Rows[0]["client_id"]);
                    lbl_CLIENT_SECRET.Text = Convert.ToString(data.Rows[0]["client_secret"]);
                    lbl_Token.Text = Convert.ToString(data.Rows[0]["token"]);
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

                double _precio = Convert.ToDouble(pro.lbl_Pre_Unit.Text); //SE COMENTA POR SERVICOO A PRECIO UNIT
                double _importe = Convert.ToDouble(pro.lbl_Pre_Unit.Text); //=
                string _und = "NIU";

                Agregar_Productos_alCarrito(_idprod.Trim(), _nomprod, _cant, _precio, _importe, _und);
                txt_IdComp.Text = RN_TipoDoc.RN_NroID(16);

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
                //if (pnl_sinProd.Visible == false)
                //{
                //    bt_Delete_Click(sender, e);
                //}
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
            if (txt_concat_razonRuc.Text.Trim().Length < 2) { fil.Show(); MessageBox.Show("Ingresa datos del Remitente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); txt_concat_razonRuc.Focus(); return false; }
            if (txt_concat_razonRucDestinat.Text.Trim().Length < 2) { fil.Show(); MessageBox.Show("Ingresa datos del Destinatario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); txt_concat_razonRucDestinat.Focus(); return false; }
            if (txt_direccion.Text.Trim().Length < 2) { fil.Show(); MessageBox.Show("Ingresa la direccion del Remitente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); txt_direccion.Focus(); return false; }
            if (txt_direcLlegada_Destinat.Text.Trim().Length < 2) { fil.Show(); MessageBox.Show("Ingresa la direccion del Destinatario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); txt_direcLlegada_Destinat.Focus(); return false; }
            if (txt_veh_placa_model.Text.Trim().Length < 2) { fil.Show(); MessageBox.Show("Selecciona un Vehiculo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); txt_veh_placa_model.Focus(); return false; }
            if (txt_concat_datos_cond.Text.Trim().Length < 2) { fil.Show(); MessageBox.Show("Selecciona un Conductor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); txt_concat_datos_cond.Focus(); return false; }

            if (txt_concat_pagadorFlete.Text.Trim().Length < 2) { fil.Show(); MessageBox.Show("Ingresa datos del Pagador del Flete", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); txt_concat_pagadorFlete.Focus(); return false; }
            if (cbo_und.SelectedIndex == -1) { fil.Show(); MessageBox.Show("Selecciona un la unidad de Medida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_und.Focus(); return false; }
            //if (txt_origen.Text.SelectedIndex == -1) { fil.Show(); MessageBox.Show("Selecciona el Tipo de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_tipoPago.Focus(); return false; }
            //if (cbo_motivo.SelectedIndex == -1) { fil.Show(); MessageBox.Show("Selecciona un Tipo de Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_motivo.Focus(); return false; }

            return true;
        }

        //Inicio-- Para calcular la utilidad del producto
        private double Buscar_Frank_Producto(string idprod)
        {
            //RN_Productos obj = new RN_Productos();
            //DataTable dato = new DataTable();

            //double frank = 0;

            //dato = obj.RN_Buscar_Productos(idprod);
            //if (dato.Rows.Count > 0)
            //{
            //    //margen de utilidad 
            //    frank = Convert.ToDouble(dato.Rows[0]["Frank"]);
            //    return frank;
            //}
            //else
            //{
                   return 0;
                //}

        }
        //Fin--


        private async Task  Registrar_Compra()
        {

            EN_Gr_Transportista com = new EN_Gr_Transportista();
            EN_Det_GR_Transportista det = new EN_Det_GR_Transportista();
            RN_GuiaRem_Transportista obj = new RN_GuiaRem_Transportista();
            RN_Productos pro = new RN_Productos();

            try
            {

                com.Idgr_Transp = txt_IdComp.Text;
                com.Id_grRem = txt_IdComp.Text; 
               /* com.IdCliente = lbl_idCliente.Text;*///cbo_provee.SelectedValue.ToString();
                com.Subtotal = Convert.ToDouble(lbl_subtotal.Text);
                com.Fecha = dtp_FechaCom.Value;
                com.Total = Convert.ToDouble(lbl_TotalPagar.Text);
                com.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                com.FechaTraslado = dtp_fechaTraslado.Value;
                com.Estado = "Activo";
                //com.REC = recibiConforme;
                com.Obs = "-";//txt_destino.Text;
                //com.TipoDocGr = cbo_tipoDoc_Guia.Text;/*"Otros"*/
                //para la salida 
                //com.TipoRegistro = cbo_motivo.Text;
                com.IdCliente = lbl_idCliente.Text; //remitente
                com.IdDireccion =Convert.ToInt32( lbl_idDireccionCl.Text); //
                com.IdCliente_sec = lbl_idCliDestinat.Text; //destinatario cliente
                com.IdDirecsec = Convert.ToInt32( lbl_idDirec_Destinat.Text);//direcc destina
                com.UnidadMedida = cbo_und.SelectedItem.ToString();// "KGM"; //COLOCAR COMBOBX PARA KGM -TNE
                com.PesoTotal = Convert.ToDouble(numericPesTotal.Value);//0.00; //textbox solo numero 
                com.NumPaquete = Convert.ToInt32(num_paquetes.Value) ; //txt para solo num entero
                com.OrdenCompra = "-";//txt para id orden compra:
                com.Obs = "-";
                com.PagadorFlete = lbl_razonsocFlete.Text.Trim(); //txt cliente pagador flete opcional
                com.IdCond =Convert.ToInt32(lbl_idConductor.Text);
                com.Idvehic =Convert.ToInt32(lbl_idVehiculo.Text);

                if (chk_conductor_secundario.Checked)
                {
                    com.IdCondsec = Convert.ToInt32(lbl_idcond_Sec.Text);
                }
                else
                {
                    
                    com.IdCondsec = null; // No asignar conductor secundario si el CheckBox no está marcado
                    lbl_dniCond_Secund.Text = "";
                }

                com.CdrSunat = "-";
                com.NroTicket = "-";
                com.HashCpe = "-";

                obj.RN_Ingresar_GuiaRemision_Transportista(com);

                if (BD_GR_Transportista.seguardo == true)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(16);

                    //GUARDAMOS EL DETALLE 
                    for (int i = 0; i < lsv_Det.Items.Count; i++)
                    {
                        var item = lsv_Det.Items[i];

                        det.Idgr = txt_IdComp.Text;
                        det.Idproducto = item.SubItems[0].Text;
                        det.Cantidad = Convert.ToDouble(item.SubItems[2].Text);
                        det.Precio = Convert.ToDouble(item.SubItems[3].Text);
                        det.Importe = Convert.ToDouble(item.SubItems[4].Text);

                        obj.RN_Ingresar_Detalle_GuiaRemIsion_Transportista(det);
                       // Registrar_MovimientoKardex(det.Idproducto.Trim(), det.Cantidad, det.Precio);


                    }

                    //Enviar_Documento_aSunat();

                    //terminamos: se comentó
                    /*
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
                    informe.tipoDoc = "doc Transportista";
                    informe.ShowDialog();
                    fil.Hide();

                    //limpiar cajas texto
                    lsv_Det.Items.Clear();
                    



                    //cbo_provee.SelectedIndex = -1;
                    //txt_NroFisico.Text = "";
                    //cbo_tipoDoc.Text = "";
                    

                    this.Tag = "A";
                    this.Close();
                    */

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void Registrar_MovimientoKardex(string idprod, double xcant, double xpreCompra)
        {
           

        }

        private async  void btn_procesar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            //Frm_Print_Informe_Almacen informe = new Frm_Print_Informe_Almacen();
            RN_GuiaRem_Transportista obj = new RN_GuiaRem_Transportista();

            //if (Validar_Compras() == true)
            //{
            //    Registrar_Compra();

            //}

            try
            {
                if (Validar_Compras() == true)
                {
                    Registrar_Compra();

                    if (BD_GR_Transportista.seguardo == true)
                    {

                        // Enviar el documento a SUNAT de manera asincrónica
                         await Enviar_Documento_aSunat();

                        // Mostrar mensaje de éxito
                        fil.Show();
                        ok.Lbl_msm1.Text = "La Guía se aprobó por la SUNAT y se guardó exitosamente.";
                        ok.ShowDialog();
                        fil.Hide();

                        // Mostrar informe
                        Frm_Print_Informe_Almacen informe = new Frm_Print_Informe_Almacen();
                        fil.Show();
                        informe.NroDoc = txt_IdComp.Text;
                        informe.lbl_nroDoc.Text = txt_IdComp.Text;
                        informe.tipoDoc = "Doc Transportista";
                        informe.ShowDialog();
                        fil.Hide();

                        // Limpiar los campos del formulario
                        limpiar_textbox();


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

        //BER.CPE_GUIA_REMISION objCPE_GUIA = new BER.CPE_GUIA_REMISION();
        //BER.CPE_GUIA_REMISION_DETALLE objCPE_DETALLE = new BER.CPE_GUIA_REMISION_DETALLE();
        BE.CPE_GUIA_REMISION objCPE_GUIA = new BE.CPE_GUIA_REMISION();
        BE.CPE_GUIA_REMISION_DETALLE objCPE_DETALLE = new BE.CPE_GUIA_REMISION_DETALLE();
        CPEConfig obj = new CPEConfig();

        private async Task Enviar_Documento_aSunat()
        {

            try
            {
                RN_GuiaRem_Transportista objRNTR = new RN_GuiaRem_Transportista();

                objCPE_GUIA.NRO_COMPROBANTE = txt_IdComp.Text.Trim(); //T-00001  - GRT-V((31)
                objCPE_GUIA.FECHA_DOCUMENTO = dtp_FechaCom.Value.ToString("yyyy-MM-dd");
                objCPE_GUIA.COD_TIPO_DOCUMENTO = "31";//lbl_id_TipodocSunat.Text;//tipo doc guia (09-grremitente / 31-transportista)
                objCPE_GUIA.NOTA = "obs";

                //objCPE_GUIA.ITEM_ENVIO = 1;
                //Supplier Party ) DATOS DEL EMISOR(TRANSPORTISTA)

                //(DESTINATARIO)Inicio
                objCPE_GUIA.TIPO_DOCUMENTO_CLIENTE = "6";
                objCPE_GUIA.NRO_DOCUMENTO_CLIENTE = lbl_rucDestinat.Text; //txt_rucCliente.Text;//"20606264004";
                objCPE_GUIA.RAZON_SOCIAL_CLIENTE = lbl_razonSocDestinat.Text; //txt_razonsocialCliente.Text; //"C.G CAPITAL SYSTEM S.A.C";
                                                                              //fin

                //shipment (de quien paga el servicio)

                //peso bruto total de la carga:
                objCPE_GUIA.COD_UND_PESO_BRUTO = cbo_und.SelectedItem.ToString();//"KGM";
                objCPE_GUIA.PESO_BRUTO = Convert.ToDecimal(numericPesTotal.Value);

                //fecha inicio de traslado:
                objCPE_GUIA.FECHA_INICIO = dtp_fechaTraslado.Value.ToString("yyyy-MM-dd"); //dtp_FechaCom.Value.ToString("yyyy-MM-dd");//"2024-11-26";

                //CONDUCTOR PRINCIPAL:
                objCPE_GUIA.NRO_DOC_CHOFER = txt_dniConductor.Text;// "87654321";
                objCPE_GUIA.NOMBRE_CHOFER = txt_nomConductor.Text; //"JUAN";
                objCPE_GUIA.APELLIDO_CHOFER = txt_apellidoConductor.Text;//"PEREZ";
                objCPE_GUIA.LICENCIA_CHOFER = txt_licenciaCond.Text;//"Q87654321";


                //CONDUCTOR SECUNDARIO:
                objCPE_GUIA.NRO_DOC_CHOFER_SEC = lbl_dniCond_Secund.Text;
                objCPE_GUIA.NOMBRE_CHOFER_SEC = lbl_nomCond_secund.Text;
                objCPE_GUIA.APELLIDO_CHOFER_SEC = lbl_apell_cond_secund.Text;
                objCPE_GUIA.LICENCIA_CHOFER_SEC = lbl_Licen_Secund.Text;

                //DIRECCION DEL PUNTO DE LLEGADA:
                objCPE_GUIA.COD_UBIGEO_DESTINO = lbl_ubigeo_destinat.Text;
                objCPE_GUIA.DIRECCION_DESTINO = txt_direcLlegada_Destinat.Text;

                //DIRECCION PUNTO DE PARTIDA:
                objCPE_GUIA.COD_UBIGEO_ORIGEN = txt_ubigeo.Text;
                objCPE_GUIA.DIRECCION_ORIGEN = txt_direccion.Text;

                //DATOS DEL REMITENTE:
                objCPE_GUIA.NRO_DOC_EMPRESA_REMITENTE = txt_rucCliente.Text;
                objCPE_GUIA.RAZON_SOC_EMP_REMITENTE = txt_razonsocialCliente.Text;

                //NUMERO DE CONTENEDOR  - , POR IMPLEMENTAR

                //VEHICULO PRINCIPAL:
                objCPE_GUIA.PLACA_VEHICULO = txt_placaVeh.Text;//"123QWE";

                //VEHICULO SECUNDARIO 
                objCPE_GUIA.PLACA_CARRETA = lbl_placa_veh_secun.Text;

                //fin


                //datos de la empresa:
                objCPE_GUIA.NRO_DOCUMENTO_EMPRESA = Lbl_RucEmisor.Text.Trim();
                objCPE_GUIA.TIPO_DOCUMENTO_EMPRESA = "6";
                objCPE_GUIA.RAZON_SOCIAL_EMPRESA = Lbl_EmpresaEmisor.Text.Trim();
                objCPE_GUIA.COD_UBIGEO_EMPRESA = "150108";//"150101"; // -   //san miguel 150136
                objCPE_GUIA.DIRECCION_EMPRESA = Lbl_DireccionEmpresa.Text.Trim();
                objCPE_GUIA.DEPARTAMENTO_EMPRESA = "Lima";
                objCPE_GUIA.PROVINCIA_EMPRESA = "Lima";
                objCPE_GUIA.DISTRITO_EMPRESA = "Chorrillos";
                //objCPE.CODIGO_PAIS_EMPRESA = "PE";
                objCPE_GUIA.RAZON_SOCIAL_EMPRESA = Lbl_EmpresaEmisor.Text.Trim();
                //objCPE.CONTACTO_EMPRESA = "";
                objCPE_GUIA.USUARIO_SOL_EMPRESA = Lbl_RucEmisor.Text.Trim() + Lbl_UsuarioSol.Text.Trim();  /*"20608131494GERSACFE";"20608131494MODDATOS";*/
                objCPE_GUIA.PASS_SOL_EMPRESA = Lbl_ClaveSol.Text.Trim();   /*"Gersac01";"MODDATOS";*/
                objCPE_GUIA.CONTRA_FIRMA = Lbl_ClaveCertificado.Text.Trim();

                //DATOS TOKEN:
                objCPE_GUIA.CLIENT_ID = Lbl_CLIENT_ID.Text.Trim();/*"4a5a83d5-d68f-402c-bb95-a71120476671"*/
                objCPE_GUIA.CLIENT_SECRET = lbl_CLIENT_SECRET.Text.Trim();/* "UWf82kLc4eCDrARQmsiv/A=="*/

                //string token = await obj.GetToken(objCPE_GUIA.CLIENT_ID, objCPE_GUIA.CLIENT_SECRET, objCPE_GUIA.USUARIO_SOL_EMPRESA, objCPE_GUIA.PASS_SOL_EMPRESA);
                // 2. Verificar si el token es válido (usando la capa de negocio)
                RN_Empresa objRN = new RN_Empresa();
                int idEmpresa = Cls_Libreria.Idempresa;
                bool esValido = objRN.RN_Token_Es_Valido(idEmpresa);

                string token;
                if (!esValido)
                {

                    // Si el token ha expirado, generar uno nuevo
                    token = await ObtenerTokenSiEsNecesario(idEmpresa);

                }
                else
                {
                    // Si el token es válido, usar el token existente
                    token = await ObtenerTokenSiEsNecesario(idEmpresa);

                }


                //string token = await ObtenerTokenSiEsNecesario(idEmpresa);

                objCPE_GUIA.TOKEN = token;
                //objCPE.CONTRA_FIRMA = Lbl_ClaveCertificado.Text.Trim();

                //List<businessEntities.CPE_GUIA_REMISION_DETALLE> OBJCPEDETALLE_LIST = new List<businessEntities.CPE_GUIA_REMISION_DETALLE>();
                List<businessEntities.CPE_GUIA_REMISION_DETALLE> OBJCPE_LIST = new List<businessEntities.CPE_GUIA_REMISION_DETALLE>();

                double pre1 = 0;
                double import = 0;

                for (int i = 0; i < lsv_Det.Items.Count; i++)
                {
                    objCPE_DETALLE = new businessEntities.CPE_GUIA_REMISION_DETALLE();

                    objCPE_DETALLE.ITEM = i + 1;
                    objCPE_DETALLE.UNIDAD_MEDIDA = lsv_Det.Items[i].SubItems[5].Text; //"NIU"
                    objCPE_DETALLE.CANTIDAD = Convert.ToDecimal(lsv_Det.Items[i].SubItems[2].Text);
                    objCPE_DETALLE.ORDER_ITEM = objCPE_DETALLE.ITEM;
                    pre1 = Convert.ToDouble(lsv_Det.Items[i].SubItems[3].Text);
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

                //PROBANDO CODIGO :

                
                
                // FIN

                // Aquí obtenemos el numTicket de la respuesta de SUNAT
                if (dicionaryenvio.ContainsKey("numTicket"))
                {
                    string numTicket = dicionaryenvio["numTicket"];
                    string fecRecepcion = dicionaryenvio["fecRecepcion"];

                    // Usar numTicket y fecRecepcion como sea necesario
                    Console.WriteLine($"Ticket: {numTicket}, Fecha Recepción: {fecRecepcion}");


                    // Ahora, invocar el método EnvioTicketAsync con los datos adecuados
                    string rutaArchivoCdr = @"D:\\CPE_2\\PRODUCCION\\"; // Aquí deberías proporcionar una ruta válida
                    string ticket = dicionaryenvio["numTicket"]; // Usar el ticket de la respuesta del primer envío
                    string ruc = objCPE_GUIA.NRO_DOCUMENTO_EMPRESA; // RUC del emisor o destinatario, según corresponda
                    string nombreFile = objCPE_GUIA.NRO_DOCUMENTO_EMPRESA + "-" + objCPE_GUIA.COD_TIPO_DOCUMENTO + "-" + objCPE_GUIA.NRO_COMPROBANTE; // El nombre del archivo que deseas usar para el CDR
                                                                                                                                                      // Llamada al segundo método
                    var resultadoEnvioTicket = await obj.EnvioTicketAsync(rutaArchivoCdr, ticket, token, ruc, nombreFile);

                    


                    // Manejo de la respuesta para obtener el cdr_hash
                    if (resultadoEnvioTicket.ContainsKey("cdr_hash"))
                    {
                        string cdrHash = resultadoEnvioTicket["cdr_hash"];
                        string cdrMsjSunat = resultadoEnvioTicket["cdr_msj_sunat"];
                        string cdrResponseCode = resultadoEnvioTicket["cdr_ResponseCode"];
                        string numError = resultadoEnvioTicket["numerror"];

                        // Mostrar los resultados en el formulario o consola
                        Console.WriteLine($"cdr_hash: {cdrHash}");
                        Console.WriteLine($"cdr_msj_sunat: {cdrMsjSunat}");
                        Console.WriteLine($"cdr_ResponseCode: {cdrResponseCode}");
                        Console.WriteLine($"numerror: {numError}");

                        // Si el CDR es exitoso, proceder con la actualización
                        if (numError == string.Empty)  // Usando numError vacío para verificar éxito
                        {
                            // Realiza alguna acción con el cdrHash, como almacenar o actualizar el estado
                            
                            // Actualizar el estado de CDR como Aprobado
                            objRNTR.RN_CambiarEstado_CdrSunat_GrTransport(txt_IdComp.Text.Trim(), "Aprobado", cdrHash);
                            MessageBox.Show("El CDR ha sido aprobado.");
                        }
                        else if (numError == "99")  // Error con el envío
                        {
                            MessageBox.Show($"Error al procesar el CDR: {cdrMsjSunat}");
                        }
                        else if (numError == "98")  // Envío en proceso
                        {
                            MessageBox.Show("El envío del CDR está en proceso.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: No se obtuvo el hash del CDR.");
                    }

                }
                else
                {
                    Console.WriteLine("Error al obtener el numTicket de la respuesta.");
                }


                //// Ahora, invocar el método EnvioTicketAsync con los datos adecuados
                //string rutaArchivoCdr = @"D:\\CPE_2\\PRODUCCION\\"; // Aquí deberías proporcionar una ruta válida
                //string ticket = dicionaryenvio["numTicket"]; // Usar el ticket de la respuesta del primer envío
                //string ruc = objCPE_GUIA.NRO_DOCUMENTO_EMPRESA; // RUC del emisor o destinatario, según corresponda
                //string nombreFile =objCPE_GUIA.NRO_DOCUMENTO_EMPRESA + "-" + objCPE_GUIA.COD_TIPO_DOCUMENTO + "-" + objCPE_GUIA.NRO_COMPROBANTE; // El nombre del archivo que deseas usar para el CDR
                //                                                 // Llamada al segundo método
                //var resultadoEnvioTicket = await obj.EnvioTicketAsync(rutaArchivoCdr, ticket, token, ruc, nombreFile);

                // Manejo de la respuesta
                //string cdrHash = resultadoEnvioTicket["cdr_hash"];
                //string cdrMsjSunat = resultadoEnvioTicket["cdr_msj_sunat"];
                //string cdrResponseCode = resultadoEnvioTicket["cdr_ResponseCode"];
                //string numError = resultadoEnvioTicket["numerror"];

                // Mostrar los resultados en el formulario
                //Console.WriteLine($"cdr_hash: {cdrHash}");
                //Console.WriteLine($"cdr_msj_sunat: {cdrMsjSunat}");
                //Console.WriteLine($"cdr_ResponseCode: {cdrResponseCode}");
                //Console.WriteLine($"numerror: {numError}");


                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

               



                // Crear una instancia de la clase XmlProcessor
                // CPEConfig xmlProcessor = new XmlProcessor();

                // Llamar al método EnvioTicketAsync
                // Crear una instancia de la clase XmlProcessor
                //XmlProcessor xmlProcessor = new XmlProcessor();

                //// Llamar al método EnvioTicketAsync
                //Dictionary<string, string> resultado = await obj.EnvioTicketAsync("rutaArchivoCdr", "ticket", "tokenAccess", "ruc", "nombreFile");

                //// Manejar los mensajes en variables
                //string cdrHash = resultado["cdr_hash"];
                //string cdrMsjSunat = resultado["cdr_msj_sunat"];
                //string cdrResponseCode = resultado["cdr_ResponseCode"];
                //string numError = resultado["numerror"];

                //// Mostrar los resultados
                //Console.WriteLine($"cdr_hash: {cdrHash}");
                //Console.WriteLine($"cdr_msj_sunat: {cdrMsjSunat}");
                //Console.WriteLine($"cdr_ResponseCode: {cdrResponseCode}");
                //Console.WriteLine($"numerror: {numError}");

                lbl_rutaXml.Text = obj.RutaCompletaxml;
            }
            catch (Exception ex )
            {

                // Manejo de excepciones
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }


        }

        bool recibiConforme = false;

        private async Task<string> ObtenerTokenSiEsNecesario(int usuarioID)
        {
            try
            {
                // Crear instancias de las clases necesarias
                RN_Empresa re = new RN_Empresa();
                BD_Empresa rn = new BD_Empresa();

                // Obtener el token y la fecha de obtención desde la base de datos
                EN_TokenInfo tokenData = rn.BD_Obtener_Token_Usuario(usuarioID);

                // Verificar si el token es nulo o ha expirado
                if (tokenData == null || tokenData.FechaObtencion.AddHours(1) < DateTime.Now)
                {
                    // Si el token no existe o ha expirado, obtener uno nuevo
                    string nuevoToken = await obj.GetToken(objCPE_GUIA.CLIENT_ID, objCPE_GUIA.CLIENT_SECRET, objCPE_GUIA.USUARIO_SOL_EMPRESA, objCPE_GUIA.PASS_SOL_EMPRESA);

                    // Guardar el nuevo token en la base de datos, asociado al usuario
                    re.RN_Guardar_Token_Usuario(usuarioID, nuevoToken, DateTime.Now, DateTime.Now.AddHours(1)); // Guardamos con la fecha y hora de obtención

                    return nuevoToken;
                }

                // Si el token es válido, lo retornamos
                return tokenData.Token;
            }
            catch (Exception ex)
            {
                // Manejo de errores, por ejemplo, loguear el error o mostrar un mensaje al usuario
                MessageBox.Show("Error al obtener el token: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void limpiar_textbox()
        {
            lsv_Det.Items.Clear();
        }

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
            if (cbo_tipoDoc_Guia.SelectedIndex == 0) //Guia remision Transportista
            {
                lbl_id_TipodocSunat.Text = "31"; //00
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


            //dato = obj.RN_Listar_Ubigeos();

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
            //if (cboDistrito.SelectedValue != null)
            //{
            //    tx.Text = cboDistrito.SelectedValue.ToString();
            //}
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
                lbl_CodModalidadTraslado.Text = "2"; // trasnporte privado

            }else if (cbo_ModalidadTraslado.SelectedIndex == 1)
            {
                lbl_CodModalidadTraslado.Text = "1"; // trasnporte publico
            }
        }

        
       
        private void lbl_busProv_Click(object sender, EventArgs e)
        {

            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Listadocliente cli = new Frm_Listadocliente();

            //fil.Show();
            //cli.ShowDialog();

            //fil.Hide();


            //if (cli.Tag.ToString() == "A")
            //{
            //    lbl_idCliente.Text = cli.lbl_id.Text;
            //    txt_razonsocialCliente.Text = cli.lbl_nom.Text;

            //}

            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_ListadoProveedor lis = new Frm_ListadoProveedor();

            //fil.Show();
            //lis.ShowDialog();

            //fil.Hide();

            //if (lis.Tag.ToString() == "A")
            //{
            //    txt_razonsocialProv.Text = lis.lbl_nom.Text;
            //    lbl_idProvee.Text = lis.lbl_id.Text;
            //    txt_rucProv.Text = lis.lbl_rucProv.Text;


            //}
        }

        private void lbl_buscarDireccionesCli_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_DireccionesClientes dir = new Frm_DireccionesClientes();

            fil.Show();
            dir.CargarDirecciones(lbl_idCliente.Text);
            dir.ShowDialog();
            fil.Hide();

            if (dir.DialogResult == DialogResult.OK)
            {
                lbl_idDireccionCl.Text = dir.txt_direccioonesId.Text;
                lbl_idCliente.Text = dir.lbl_id_direcClientes.Text;
                txt_razonsocialCliente.Text = dir.lbl_razonsocialCli.Text;
                txt_rucCliente.Text = dir.lbl_rucCli.Text;
                txt_direccion.Text = dir.txt_direccion.Text;
                txt_departamento.Text = dir.lbl_departamento.Text;
                txt_provincia.Text = dir.lbl_provincia.Text;
                txt_distrito.Text = dir.lbl_distrito.Text;
                txt_ubigeo.Text = dir.txt_ubigeo.Text;

                txt_tipoDoc.Text = dir.lbl_tipoDoc.Text; //DNI-RUC-C/E
                lbl_codTipoDoc.Text = dir.lbl_codTipoDoc.Text;//1DNI -4-C/E -6 RUC

                //datos concatenados en un solo label:
                txt_concat_razonRuc.Text = $"{txt_razonsocialCliente.Text} - {txt_rucCliente.Text}";
               
            }

        }

 
        private void lbl_buscCond_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Conductores con = new Frm_Conductores();

            fil.Show();
            con.ShowDialog();
            fil.Hide();

            if (con.Tag.ToString() =="A")
            {
                lbl_idConductor.Text = con.txt_idvehiculo.Text;
                txt_nomConductor.Text = con.txt_nombreCond.Text;
                txt_apellidoConductor.Text = con.txt_apellidos.Text;
                txt_dniConductor.Text = con.txtDni.Text;
                txt_licenciaCond.Text = con.txtLicencia.Text;

                //datos concatenados en un solo label:
                //datos concatenados en un solo label:

                txt_concat_datos_cond.Text = $"{txt_dniConductor.Text} - {txt_nomConductor.Text + " " + txt_apellidoConductor.Text } - {txt_licenciaCond.Text}";
            }

        }

        private void lbl_busVeh_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Vehiculos veh = new Frm_Vehiculos();

            fil.Show();
            veh.ShowDialog();
            fil.Hide();

            if (veh.Tag.ToString() == "A")
            {
                lbl_idVehiculo.Text = veh.txt_idvehiculo.Text;
                txt_vehiculo.Text = veh.txt_modelo.Text;
                txt_placaVeh.Text = veh.txt_placa.Text;
                lbl_marcaVehi.Text = veh.txt_marcaVehiculo.Text;
                

                //datos concatenados en un solo label:
                txt_veh_placa_model.Text = $"{txt_placaVeh.Text} - {txt_vehiculo.Text} - {lbl_marcaVehi.Text}";
            }

        }

        private void txt_direccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void gunaTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_busCli_Destinat_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_DireccionesClientes dir = new Frm_DireccionesClientes();

            fil.Show();
            dir.CargarDirecciones(lbl_idCliente.Text);
            dir.ShowDialog();
            fil.Hide();

            if (dir.DialogResult == DialogResult.OK)
            {
                lbl_idDirec_Destinat.Text = dir.txt_direccioonesId.Text;
                lbl_idCliDestinat.Text = dir.lbl_id_direcClientes.Text;
                lbl_razonSocDestinat.Text = dir.lbl_razonsocialCli.Text;
                lbl_rucDestinat.Text = dir.lbl_rucCli.Text;
                txt_direcLlegada_Destinat.Text = dir.txt_direccion.Text;
                lbl_dep_destinat.Text = dir.lbl_departamento.Text;
                lbl_provincia_destinat.Text = dir.lbl_provincia.Text;
                lbl_distrit_destinat.Text = dir.lbl_distrito.Text;
                lbl_ubigeo_destinat.Text = dir.txt_ubigeo.Text;

                lbl_tipoDocDest.Text = dir.lbl_tipoDoc.Text; //DNI-RUC-C/E
                lbl_codTipoDocDest.Text = dir.lbl_codTipoDoc.Text;//1DNI -4-C/E -6 RUC

                //datos concatenados en un solo label:
                txt_concat_razonRucDestinat.Text = $"{lbl_razonSocDestinat.Text} - {lbl_rucDestinat.Text}";

            }
        }

        private void lbl_busVehSecund_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Vehiculos veh = new Frm_Vehiculos();

            fil.Show();
            veh.ShowDialog();
            fil.Hide();

            if (veh.Tag.ToString() == "A")
            {
                lbl_idVeh_secund.Text = veh.txt_idvehiculo.Text;
                //lbl_model_veh_secun.Text = veh.txt_modelo.Text;
                lbl_placa_veh_secun.Text = veh.txt_placa.Text;
                //lbl_marcaVehSecun.Text = veh.txt_marcaVehiculo.Text;


                //datos concatenados en un solo label:
                txt_veh_placa_model_Secun.Text = $"{lbl_placa_veh_secun.Text}";
            }
            else
            {
                lbl_placa_veh_secun.Text = "";
            }
        }
        
        private void lbl_condSecund_Click(object sender, EventArgs e)
        {
            
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Conductores con = new Frm_Conductores();

            fil.Show();
            con.ShowDialog();
            fil.Hide();

            if (con.Tag.ToString() == "A")
            {
                lbl_idcond_Sec.Text = con.txt_idvehiculo.Text;
                lbl_nomCond_secund.Text = con.txt_nombreCond.Text;
                lbl_apell_cond_secund.Text = con.txt_apellidos.Text;
                lbl_dniCond_Secund.Text = con.txtDni.Text;
                lbl_Licen_Secund.Text = con.txtLicencia.Text;

                txt_concat_datos_cond_sec.Text = $"{lbl_dniCond_Secund.Text} - {lbl_nomCond_secund.Text + " " + lbl_apell_cond_secund.Text } - {lbl_Licen_Secund.Text}";
            }
        }

        private void chk_vehiculo_secundario_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_vehiculo_secundario.Checked == true)
            {
                txt_veh_placa_model_Secun.Visible = true;
                lbl_busVehSecund.Visible = true;
            }
            else
            {
                txt_veh_placa_model_Secun.Visible = false;
                lbl_busVehSecund.Visible = false;
            }
        }

        private void chk_conductor_secundario_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_conductor_secundario.Checked == true)
            {
                txt_concat_datos_cond_sec.Visible = true;
                lbl_condSecund.Visible = true;
            }
            else
            {
                txt_concat_datos_cond_sec.Visible = false;
                lbl_condSecund.Visible = false;
            }
        }

        private void lbl_busCli_PgadrFlete_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_DireccionesClientes dir = new Frm_DireccionesClientes();

            fil.Show();
            dir.CargarDirecciones(lbl_idPagFlete.Text);
            dir.ShowDialog();
            fil.Hide();

            if (dir.DialogResult == DialogResult.OK)
            {
                lbl_idDireccionCl.Text = dir.txt_direccioonesId.Text;
                lbl_idPagFlete.Text = dir.lbl_id_direcClientes.Text;
                lbl_razonsocFlete.Text = dir.lbl_razonsocialCli.Text;
                lbl_rucflete.Text = dir.lbl_rucCli.Text;
                //txt_direccion.Text = dir.txt_direccion.Text;
                //txt_departamento.Text = dir.lbl_departamento.Text;
                //txt_provincia.Text = dir.lbl_provincia.Text;
                //txt_distrito.Text = dir.lbl_distrito.Text;
                //txt_ubigeo.Text = dir.txt_ubigeo.Text;

                //txt_tipoDoc.Text = dir.lbl_tipoDoc.Text; //DNI-RUC-C/E
                //lbl_codTipoDoc.Text = dir.lbl_codTipoDoc.Text;//1DNI -4-C/E -6 RUC

                //datos concatenados en un solo label:
                txt_concat_pagadorFlete.Text = $"{lbl_razonsocFlete.Text} - {lbl_rucflete.Text}";

            }
        }

        private void InitializeGuna2NumericUpDown()
        {


            // Asumiendo que ya tienes un Guna2NumericUpDown en el diseñador
            NumericUpDown numericUpDown = numericPesTotal; // Nombre del control desde el diseñador

            // Configuración para aceptar valores con decimales
            numericUpDown.DecimalPlaces = 2;     // Número de decimales (por ejemplo, 70.50 kg)
            numericUpDown.Increment = 1.00m;      // Incremento de 0.01
            numericUpDown.Minimum = 1.00m;        // Valor mínimo (0.00 kg)
            numericUpDown.Maximum = 9999999.99m;      // Valor máximo (ajústalo a tus necesidades)

            // Opcional: Evento para capturar el valor ingresado y mostrarlo
            //numericUpDown.ValueChanged += (sender, e) =>
            //{
            //    MessageBox.Show($"Peso ingresado: {numericUpDown.Value} kg");
            //};


        }

       
    }
}
