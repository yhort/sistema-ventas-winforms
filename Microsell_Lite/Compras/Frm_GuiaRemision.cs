using businessEntities;
using CrearXML;
using DocumentFormat.OpenXml.Office.PowerPoint.Y2021.M06.Main;
using Guna.UI.WinForms;
using Microsell_Lite.Cliente;
using Microsell_Lite.GUIAREMISION;
using Microsell_Lite.Informe;
using Microsell_Lite.Productos;
using Microsell_Lite.Proveedor;
using Microsell_Lite.Utilitarios;
using Newtonsoft.Json;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using Prj_Capa_Negocio;
using Signature;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static Prj_Capa_Entidad.EN_Ubigeo;
//IMPORTACION F.E
//using BER = BusinessEntitiesNew;
using BE = businessEntities;
using EV = CPEEnvio;


namespace Microsell_Lite.Compras
{

    public partial class Frm_GuiaRemision : Form
    {


        private List<UbigeoInfo> _allUbigeos;
        //private DataView _dvUbigeos;  // <-- vista propia
        private System.Windows.Forms.Timer _debouncePartida;   // <- WinForms timer
        private System.Windows.Forms.Timer _debounceLlegada;     //private bool _rebinding; // guardia para evitar eventos durante el re-filtrado

        private bool _suppressPartida;
        private bool _suppressLlegada;

        //private EventHandler _onIndexChanged;
        private EventHandler _onIndexChangedPartida;
        private EventHandler _onIndexChangedLlegada;

        public Frm_GuiaRemision()
        {
            InitializeComponent();
            var rn = new RN_Ubigeo();
            _allUbigeos = rn.RN_Listar_Ubigeos() ?? new List<UbigeoInfo>();
            //cboDepartamento.SelectedIndexChanged += cboDepartamento_SelectedIndexChanged;
            //cboProvincia.SelectedIndexChanged += cboProvincia_SelectedIndexChanged;
            //cboDistrito.SelectedIndexChanged += cboDistrito_SelectedIndexChanged;
            // Timers independientes
            _debouncePartida = new System.Windows.Forms.Timer { Interval = 250 };
            _debounceLlegada = new System.Windows.Forms.Timer { Interval = 250 };

            _debouncePartida.Tick += (s, e) =>
            {
                _debouncePartida.Stop();
                AplicarFiltro(txtBuscarUbigeo_Partida, cboUbigeo_Partida, ref _suppressPartida, ref _onIndexChangedPartida);
            };

            _debounceLlegada.Tick += (s, e) =>
            {
                _debounceLlegada.Stop();
                AplicarFiltro(txtBuscarUbigeo_llegada, cboUbigeo_llegada, ref _suppressLlegada, ref _onIndexChangedLlegada);
            };

            // Eventos de los TextBox (cada uno con su timer)
            txtBuscarUbigeo_Partida.TextChanged += (s, e) => { _debouncePartida.Stop(); _debouncePartida.Start(); };
            txtBuscarUbigeo_llegada.TextChanged += (s, e) => { _debounceLlegada.Stop(); _debounceLlegada.Start(); };

            // Flecha abajo abre su propio combo
            txtBuscarUbigeo_Partida.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Down && cboUbigeo_Partida.Items.Count > 0)
                {
                    cboUbigeo_Partida.DroppedDown = true;
                    cboUbigeo_Partida.Focus();
                    e.Handled = true;
                }
            };
            txtBuscarUbigeo_llegada.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Down && cboUbigeo_llegada.Items.Count > 0)
                {
                    cboUbigeo_llegada.DroppedDown = true;
                    cboUbigeo_llegada.Focus();
                    e.Handled = true;
                }
            };

            // Preparar ambos combos (sin DataSource)
            cboUbigeo_Partida.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUbigeo_llegada.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUbigeo_Partida.Items.Clear(); cboUbigeo_Partida.SelectedIndex = -1;
            cboUbigeo_llegada.Items.Clear(); cboUbigeo_llegada.SelectedIndex = -1;

            // Handlers SelectedIndexChanged independientes, con su flag
            _onIndexChangedPartida = (s, e) => { if (_suppressPartida) return; if (cboUbigeo_Partida.SelectedIndex < 0) return; /* opcional */ };
            _onIndexChangedLlegada = (s, e) => { if (_suppressLlegada) return; if (cboUbigeo_llegada.SelectedIndex < 0) return; /* opcional */ };

            cboUbigeo_Partida.SelectedIndexChanged += _onIndexChangedPartida;
            cboUbigeo_llegada.SelectedIndexChanged += _onIndexChangedLlegada;

            // Cargar códigos en sus labels cuando el usuario confirma
            cboUbigeo_Partida.SelectionChangeCommitted += (s, e) =>
            {
                if (cboUbigeo_Partida.SelectedItem is UbigeoInfo sel) lbl_cod_ubigeo_partida.Text = sel.Ubigeo;
            };
            cboUbigeo_llegada.SelectionChangeCommitted += (s, e) =>
            {
                if (cboUbigeo_llegada.SelectedItem is UbigeoInfo sel) lbl_cod_ubigeo_llegada.Text = sel.Ubigeo;
            };
        }

        static string NormalizeNoAccents(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            var sb = new StringBuilder();
            foreach (var ch in s.Normalize(NormalizationForm.FormD))
            {
                var cat = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (cat != UnicodeCategory.NonSpacingMark)
                    sb.Append(char.ToLowerInvariant(ch));
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        private void cboUbigeo_Partida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressPartida) return;
            if (cboUbigeo_Partida.Items.Count == 0 || cboUbigeo_Partida.SelectedIndex < 0) return;
            // lógica opcional segura
        }

        private void cboUbigeo_Partida_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Solo cuando el usuario selecciona un ítem válido
            if (cboUbigeo_Partida.SelectedItem is UbigeoInfo sel)
            {
                //lógica con sel.Ubigeo / sel.Etiqueta
                // Ejemplo de uso:
                string codigo = sel.Ubigeo;    // "150115"
                lbl_cod_ubigeo_partida.Text = codigo;
            }
        }
        private void AplicarFiltro(GunaTextBox txt, GunaComboBox cbo, ref bool suppressFlag, ref EventHandler onIndexChanged)
        {
            string texto = (txt.Text ?? "").Trim();

            suppressFlag = true;
            cbo.SelectedIndexChanged -= onIndexChanged;
            cbo.BeginUpdate();
            try
            {
                if (cbo.DroppedDown) cbo.DroppedDown = false;
                cbo.Items.Clear();

                // 1) Si la lista aún no está lista: no sigas
                var src = _allUbigeos ?? new List<UbigeoInfo>(0);

                if (texto.Length < 2 || src.Count == 0)
                {
                    cbo.SelectedItem = null;
                    return;
                }

                var q = NormalizeNoAccents(texto);
                var tokens = q.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // 2) Null-safe sobre cada propiedad de UbigeoInfo
                var matches = src
                    .Where(u =>
                    {
                        var key = NormalizeNoAccents($"{u?.Distrito ?? ""} {u?.Provincia ?? ""} {u?.Departamento ?? ""}");
                        return tokens.All(t => key.Contains(t));
                    })
                    .OrderBy(u => u?.Distrito ?? "")
                    .ThenBy(u => u?.Provincia ?? "")
                    .ThenBy(u => u?.Departamento ?? "")
                    .Take(200)
                    .ToList();

                foreach (var it in matches) cbo.Items.Add(it);

                cbo.SelectedItem = null;                     // no auto-seleccionar
                cbo.DroppedDown = matches.Count > 0;
            }
            finally
            {
                cbo.EndUpdate();
                cbo.SelectedIndexChanged += onIndexChanged;
                suppressFlag = false;
            }
        }

        private void cboUbigeo_llegada_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Solo cuando el usuario selecciona un ítem válido
            if (cboUbigeo_llegada.SelectedItem is UbigeoInfo sel)
            {
                //lógica con sel.Ubigeo / sel.Etiqueta
                // Ejemplo de uso:
                string codigo = sel.Ubigeo;    // "150115"
                lbl_cod_ubigeo_llegada.Text = codigo;

            }
        }

        private void cboUbigeo_llegada_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressLlegada) return;
            if (cboUbigeo_llegada.Items.Count == 0 || cboUbigeo_llegada.SelectedIndex < 0) return;
            // lógica opcional segura
        }


        private void Frm_GuiaRemision_Load(object sender, EventArgs e)
        {
            // Fecha actual
            DateTime hoy = DateTime.Today;

            // DateTimePicker para la fecha de emisión
            dtp_fechaEmision.Value = hoy;
            dtp_fechaEmision.MinDate = hoy.AddYears(-1);  // Hace un año desde hoy
            dtp_fechaEmision.MaxDate = hoy;               // Hoy

            // DateTimePicker para la fecha de inicio de traslado
            dtp_fechaTraslado.Value = hoy;
            dtp_fechaTraslado.MinDate = hoy.AddYears(-1);  // Un año antes
            dtp_fechaTraslado.MaxDate = hoy.AddYears(1);   // Un año después

            txt_IdComp.Text = RN_TipoDoc.RN_NroID(16);

            //LoadDepartamentos();
            Configurar_listView();
            Llenar_Combo_Proveedores();
            Leer_Dato_Empresa();

        }

        //private void txtBuscarUbigeo_llegada_TextChanged(object sender, EventArgs e)
        //{
        //    // Null-safe por si algo desuscribe el timer
        //    if (_debounce == null)
        //    {
        //        _debounce = new System.Windows.Forms.Timer { Interval = 250 };
        //        _debounce.Tick += Debounce_Tick;
        //    }
        //    _debounce.Stop();
        //    _debounce.Start();
        //}

        //private void Debounce_Tick(object sender, EventArgs e)
        //{
        //    _debounce.Stop();
        //    AplicarFiltro(txtBuscarUbigeo_Partida.Text);
        //}
        //private void WireEvents()
        //{
        //    txtBuscarUbigeo_Partida.TextChanged += (s, e) =>
        //    {
        //        _debounce.Stop();
        //        _debounce.Start();
        //    };

        //    txtBuscarUbigeo_Partida.KeyDown += (s, e) =>
        //    {
        //        if (e.KeyCode == Keys.Down)
        //        {
        //            if (cboUbigeo_Partida.Items.Count > 0)
        //            {
        //                cboUbigeo_Partida.DroppedDown = true;
        //                cboUbigeo_Partida.Focus();
        //            }
        //            e.Handled = true;
        //        }
        //    };
        //}
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
            //para facturacion electronica 2023:
            //lis.Columns.Add("Afect. Igv", 0, HorizontalAlignment.Left);  //9
            //lis.Columns.Add("PreUni sinIgv", 0, HorizontalAlignment.Left);  //10
            //lis.Columns.Add("SubTotal SinIgv", 0, HorizontalAlignment.Left);  //11
            //lis.Columns.Add("Igv", 0, HorizontalAlignment.Left);  //12
            //lis.Columns.Add("Tipo", 0, HorizontalAlignment.Left);  //13
            //lis.Columns.Add("CodTipo_Afecto", 0, HorizontalAlignment.Left);  //14

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
                    Lbl_CLIENT_ID.Text  = Convert.ToString(data.Rows[0]["client_id"]);
                    lbl_CLIENT_SECRET.Text  = Convert.ToString(data.Rows[0]["client_secret"]);
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
                //txt_IdComp.Text = RN_TipoDoc.RN_NroID(16);

            }
        }
        private void limpiar_textbox()
        {
            lsv_Det.Items.Clear();
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
            Frm_Advertencia ad = new Frm_Advertencia();

            if(lsv_Det.Items.Count == 0) { fil.Show();ad.Lbl_msm1.Text = "Ingresa al menos un Producto"; ad.ShowDialog(); fil.Hide(); lsv_Det.Focus(); return false; }
            if(txt_razonsocialCliente.Text == "") { fil.Show(); ad.Lbl_msm1.Text = "Ingresa el Cliente"; ad.ShowDialog(); fil.Hide(); txt_razonsocialCliente.Focus(); return false; }
            if(cbo_und.SelectedIndex == - 1) { fil.Show(); ad.Lbl_msm1.Text = "Selecciona un la unidad de Medida"; ad.ShowDialog(); fil.Hide(); cbo_und.Focus(); return false; }
            if(numericPesTotal.Value <= 0) { fil.Show(); ad.Lbl_msm1.Text = "El peso debe ser mayor que 0"; ad.ShowDialog(); fil.Hide(); numericPesTotal.Focus(); return false; }
            if(num_paquetes.Value <= 0) { fil.Show(); ad.Lbl_msm1.Text = "La cantidad de Paquetes debe ser mayor que 0"; ad.ShowDialog(); fil.Hide(); numericPesTotal.Focus(); return false; }

            if (lbl_CodModalidadTraslado.Text == "01") //publico
            {
                if(txt_rznTranPublico.Text == "") { fil.Show(); ad.Lbl_msm1.Text = "Ingrese la empresa de Transp."; ad.ShowDialog(); fil.Hide(); txt_rznTranPublico.Focus(); return false; }
                if(txt_trnMtcPublico.Text == "") { fil.Show(); ad.Lbl_msm1.Text = "Ingrese el N° Mtc de la Empresa Transp."; ad.ShowDialog(); fil.Hide(); txt_trnMtcPublico.Focus(); return false; }

            }else if (lbl_CodModalidadTraslado.Text =="02")
            {
                if(txt_veh_placa_model.Text == "") { fil.Show(); ad.Lbl_msm1.Text = "Ingrese al menos un Vehiculo"; ad.ShowDialog(); fil.Hide(); txt_veh_placa_model.Focus(); return false; }
                if(txt_concat_datos_cond.Text == "") { fil.Show(); ad.Lbl_msm1.Text = "Ingrese al menos un Conductor"; ad.ShowDialog(); fil.Hide(); txt_concat_datos_cond.Focus(); return false; }
                if (lbl_licenCond.Text == "") { fil.Show(); ad.Lbl_msm1.Text = "Registre la licencia del Conductor"; ad.ShowDialog(); fil.Hide(); txt_concat_datos_cond.Focus(); return false; }
                if (txt_dniConductor.Text == "") { fil.Show(); ad.Lbl_msm1.Text = "Registre el DNI del Conductor"; ad.ShowDialog(); fil.Hide(); txt_concat_datos_cond.Focus(); return false; }
            }

            if(lbl_cod_ubigeo_partida.Text == "") { fil.Show(); ad.Lbl_msm1.Text = "Ingrese el Ubigeo de Partida"; ad.ShowDialog(); fil.Hide(); txtBuscarUbigeo_Partida.Focus(); return false; }
            if(txt_direccion_Partida.Text == "") { fil.Show(); ad.Lbl_msm1.Text = "Ingrese la Direccion de Partida"; ad.ShowDialog(); fil.Hide(); txt_direccion_Partida.Focus(); return false; }

            if (lbl_cod_ubigeo_llegada.Text == "") { fil.Show(); ad.Lbl_msm1.Text = "Ingrese el Ubigeo de Llegada"; ad.ShowDialog(); fil.Hide(); txtBuscarUbigeo_llegada.Focus(); return false; }
            if (txt_direccion_llegada.Text == "") { fil.Show(); ad.Lbl_msm1.Text = "Ingrese la Direccion de Llegada"; ad.ShowDialog(); fil.Hide(); txt_direccion_llegada.Focus(); return false; }

            
            ////if (cbo_provee.SelectedIndex == -1) { fil.Show(); MessageBox.Show("Selecciona Almenos un Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_provee.Focus(); return false; }
            //if (txt_origen.Text.Trim().Length < 2) { fil.Show(); MessageBox.Show("Ingresa la procedencia de la mercaderia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); txt_origen.Focus(); return false; }
            ////if (txt_origen.Text.SelectedIndex == -1) { fil.Show(); MessageBox.Show("Selecciona el Tipo de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_tipoPago.Focus(); return false; }
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

        private void Registrar_Compra()
        {

            EN_GuiaRemision com = new EN_GuiaRemision();
            EN_Det_GuiaRemision det = new EN_Det_GuiaRemision();
            RN_GuiaRemision obj = new RN_GuiaRemision();
            RN_Productos pro = new RN_Productos();
            //Frm_Print_Compras imp = new 
            try
            {
                com.IdGr = txt_IdComp.Text;
                com.NroRefFac = txt_nroDoc_ref.Text.Replace(Environment.NewLine, ", "); ;
                com.IdCliente = lbl_idCliente.Text;//cbo_provee.SelectedValue.ToString();
                if(lbl_CodModalidadTraslado.Text == "01")
                {
                    com.IdTransportista = lbl_idTransportista.Text;
                    com.IdsConductores = null;
                    com.Idvehiculo = null;
                }
                else if (lbl_CodModalidadTraslado.Text == "02")
                {
                    com.IdsConductores = new List<string>();

                    // Cond. Principal
                    if (!string.IsNullOrEmpty(lbl_idConductor.Text))
                    {
                        com.IdsConductores.Add(lbl_idConductor.Text);
                        
                    }
                    // Cond. Secundario (solo si el checkbox está marcado y el campo no está vacío)
                    if (chk_conductor_secundario.Checked && !string.IsNullOrEmpty(lbl_idcond_Sec.Text))
                    {
                        com.IdsConductores.Add(lbl_idcond_Sec.Text);
                    }

                    if (!string.IsNullOrEmpty(lbl_idVehiculo.Text))
                    {
                        com.Idvehiculo=Convert.ToInt32(lbl_idVehiculo.Text);
                    }
                    else
                    {
                        com.Idvehiculo = null;//por si no se selecciono
                    }                  
                    /*
                     * cuando son vehiculos indepeendientes
                    // Llenar la lista de vehículos (se realiza los mismo si se tiene vehículos principal y secundario)
                    com.IdsVehiculos = new List<string>();
                    // Vehi. Principal
                    if (!string.IsNullOrEmpty(lbl_idVehiculo.Text))
                    {
                        //com.IdsConductores.Add(lbl_idVehiculo.Text);
                        com.IdsVehiculos.Add(lbl_idVehiculo.Text);
                    }
                    // Vehi. Secundario (solo si el checkbox está marcado y el campo no está vacío)
                    if (chk_vehiculo_secundario.Checked && !string.IsNullOrEmpty(lbl_idVehiculo_Sec.Text))
                    {
                        com.IdsVehiculos.Add(lbl_idVehiculo_Sec.Text);
                    }*/

                }
                //com.IdTransportista = lbl_idTransportista.Text;
                com.Subtotal = Convert.ToDouble(lbl_subtotal.Text);
                com.FechSyst = dtp_FechaCom.Value;
                com.FechaEmision = dtp_fechaEmision.Value; //aca se puede añadir una fecha de cuando se emitira .
                //com.Total = Convert.ToDouble(lbl_TotalPagar.Text);
                com.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                com.FechaTraslado = dtp_fechaTraslado.Value;
                com.Und = cbo_und.Text;
                com.NumPaquete = Convert.ToInt32(num_paquetes.Text);
                com.Obs = "obs";//txt_destino.Text;
                com.UbigeoPartida = lbl_cod_ubigeo_partida.Text;
                com.PuntoPartida = txt_direccion_Partida.Text;
                com.UbigeoLlegada = lbl_cod_ubigeo_llegada.Text;
                com.PuntoLlegada = txt_direccion_llegada.Text;
                com.CdrSunat = "-";
                com.NroTicket = "-";
                com.HashCpe = "-";
                com.MotivoTraslado = cbo_motivo.Text.ToString();
                com.MotivoCodigo = lbl_CodMotivo.Text;
                com.MotivoDesc = cbo_ModalidadTraslado.Text.ToString();
                com.PesoTotal = Convert.ToDouble(numericPesTotal.Text);
                com.EstadoDoc = "Activo";

                /*
                //Se trabaja con la cant de conductores y vehiculos del formulario, para simplificar, pero en bd el diseño 
                //contempla para mas de 2 cond. y vehiculos.
                // Llenar la lista de conductores
                //if (lbl_CodModalidadTraslado.Text == "02")
                //{
                //    com.IdsConductores = new List<string>();

                //    // Cond. Principal
                //    if (!string.IsNullOrEmpty(lbl_idConductor.Text))
                //    {
                //        com.IdsConductores.Add(lbl_idConductor.Text);
                //    }

                //    // Cond. Secundario (solo si el checkbox está marcado y el campo no está vacío)
                //    if (chk_conductor_secundario.Checked && !string.IsNullOrEmpty(lbl_idcond_Sec.Text))
                //    {
                //        com.IdsConductores.Add(lbl_idcond_Sec.Text);
                //    }

                //    // Llenar la lista de vehículos (se realiza los mismo si se tiene vehículos principal y secundario)
                //    com.IdsVehiculos = new List<string>();
                //    // Vehi. Principal
                //    if (!string.IsNullOrEmpty(lbl_idVehiculo.Text))
                //    {
                //        //com.IdsConductores.Add(lbl_idVehiculo.Text);
                //        com.IdsVehiculos.Add(lbl_idVehiculo.Text);
                //    }
                //    // Vehi. Secundario (solo si el checkbox está marcado y el campo no está vacío)
                //    if (chk_vehiculo_secundario.Checked && !string.IsNullOrEmpty(lbl_idVehiculo_Sec.Text))
                //    {
                //        com.IdsVehiculos.Add(lbl_idVehiculo_Sec.Text);
                //    }
                //}
                */

                obj.RN_Ingresar_GuiaRemision(com);

                if (BD_GuiaRemision.seguardo == true)
                {
                    if (lbl_CodModalidadTraslado.Text == "02")
                    {
                        // Guardar los conductores
                        foreach (var idCond in com.IdsConductores)
                        {
                            obj.RN_Ingresar_GuiaConductor(com.IdGr, Convert.ToInt32(idCond));
                        }
                        /*
                        // Guardar los vehículos
                        foreach (var idVeh in com.IdsVehiculos)
                        {
                            obj.RN_Ingresar_GuiaVehiculo(com.IdGr, Convert.ToInt32(idVeh));
                        }
                        */
                    }
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
                        obj.RN_Ingresar_Detalle_GuiaRemesion(det);
                        // Registrar_MovimientoKardex(det.Idproducto.Trim(), det.Cantidad, det.Precio);
                    }
                    /*
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
                    ¨*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Registrar_MovimientoKardex(string idprod, double xcant, double xpreCompra)
        {
            //RN_Kardex obj = new RN_Kardex();
            //EN_Kardex kar = new EN_Kardex();
            //RN_Productos objpro = new RN_Productos();
            //DataTable dato = new DataTable();
            //DataTable datoprod = new DataTable();

            //string xidkardex = "";
            //int xitem = 0;
            //double stockProd = 0;
            //double precioCompraProd = 0;


            //try
            //{
            //    if (obj.RN_Verificar_Producto_siTieneKardex(idprod) == true)
            //    {
            //        //si tiene kardex es valido:
            //        dato = obj.RN_Buscar_KardexDetalle_porProducto(idprod.Trim());
            //        if (dato.Rows.Count > 0)
            //        {
            //            xidkardex = Convert.ToString(dato.Rows[0]["Id_krdx"]);
            //            xitem = dato.Rows.Count;
            //            //leemos los datos del producto 
            //            datoprod = objpro.RN_Buscar_Productos(idprod.Trim());
            //            stockProd = Convert.ToDouble(datoprod.Rows[0]["Stock_Actual"]);
            //            precioCompraProd = Convert.ToDouble(datoprod.Rows[0]["Pre_CompraS"]);

            //            //registramos el Detalle del Kardex:

            //            kar.Idkardex = xidkardex;
            //            kar.Item = xitem + 1;
            //            kar.Doc_soporte = txt_IdComp.Text;
            //            kar.Det_Operacion = cbo_motivo.Text + " de Mercaderia";
            //            //entrada:
            //            kar.Cantidad_in = 0;
            //            kar.Precio_In = 0;
            //            kar.Total_In = 0;
            //            //salida:
            //            kar.Cantidad_Out = xcant;
            //            kar.Precio_out = xpreCompra;
            //            kar.Total_out = xcant * xpreCompra;
            //            //saldos:
            //            kar.Cantidad_saldo = stockProd - xcant;
            //            kar.Promedio = xpreCompra;
            //            kar.Total_saldo = xpreCompra * kar.Cantidad_saldo;
            //            kar.CantiDiferencial = "0";
            //            kar.ImporteDiferencial = 0;

            //            obj.RN_Registrar_Detalle_Kardex(kar);


            //            //ahora actualizamos nuestro stock de la tabla de productos:
            //            objpro.RN_Restar_Stock_Producto(idprod.Trim(), xcant);

            //        }
            //        else
            //        {
            //            MessageBox.Show("El Producto: " + idprod + "No tiene Kardex", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        }

            //    }
            //    else
            //    {
            //        MessageBox.Show("El Producto: " + idprod + "No tiene Kardex", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }
        private async void btn_procesar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
           
            int idempresa = Cls_Libreria.Idempresa;

            try
            {
                if (Validar_Compras() == true)
                {
                    Registrar_Compra();

                    if (BD_GuiaRemision.seguardo == true)
                    {

                        // Enviar el documento a SUNAT de manera asincrónica
                        await Enviar_Documento_aSunat();

                        // Ya puedes decidir qué hacer según el código de respuesta
                        //string respCodeCdr = lbl_codRespuestSunat.Text;

                        if (idempresa == 1)
                        {

                        }else if (idempresa == 2)
                        {
                            //german
                            //textil charlootte
                            if (lbl_codRespuestSunat.Text == "99")
                            {
                                fil.Show();
                                ok.Lbl_msm1.Text = "SUNAT rechazó la Guía. Verifique los datos.";
                                ok.ShowDialog();
                                fil.Hide();
                                this.Close();
                                /*
                                //// Mostrar informe
                                ////Frm_Print_Informe_GuiaRemision informe = new Frm_Print_Informe_GuiaRemision();
                                //Frm_Print_Informe_GuiaRemision informe = new Frm_Print_Informe_GuiaRemision();
                                //fil.Show();
                                //informe.NroDoc = txt_IdComp.Text;
                                //informe.tipoDoc = "Guia Remision-Charlote";
                                //informe.modalidad_traslado = lbl_CodModalidadTraslado.Text;
                                //informe.ShowDialog();
                                //informe.lbl_nroDoc.Text = txt_IdComp.Text;
                                //fil.Hide();
                                //// Limpiar los campos del formulario
                                //limpiar_textbox();
                                //this.Close();
                                ////}
                                ///*/
                            }
                            else if (lbl_codRespuestSunat.Text == "98")
                            {
                                fil.Show();
                                ok.Lbl_msm1.Text = "La Guia se envio a Sunat y se  encuentra en proceso. Intente consultar más tarde.";
                                ok.ShowDialog();
                                fil.Hide();
                                Frm_Print_Informe_GuiaRemision informe = new Frm_Print_Informe_GuiaRemision();
                                fil.Show();
                                informe.NroDoc = txt_IdComp.Text;
                                informe.tipoDoc = "Guia Remision-Charlote";
                                informe.modalidad_traslado = lbl_CodModalidadTraslado.Text;
                                informe.lbl_nroDoc.Text = txt_IdComp.Text;
                                informe.ShowDialog();
                                fil.Hide();
                                this.Close();
                                
                            }
                            else
                            {
                                fil.Show();                              
                                ok.Lbl_msm1.Text = "La Guía se aprobó por la SUNAT y se guardó exitosamente.";
                                ok.ShowDialog();
                                fil.Hide();
                                Frm_Print_Informe_GuiaRemision informe = new Frm_Print_Informe_GuiaRemision();
                                fil.Show();
                                informe.NroDoc = txt_IdComp.Text;
                                informe.tipoDoc = "Guia Remision-Charlote";
                                informe.modalidad_traslado = lbl_CodModalidadTraslado.Text;
                                informe.lbl_nroDoc.Text = txt_IdComp.Text;
                                informe.ShowDialog();
                                fil.Hide();
                                limpiar_textbox();
                                this.Close();
                                /*
                                // Mostrar informe
                                //Frm_Print_Informe_GuiaRemision informe = new Frm_Print_Informe_GuiaRemision();
                                
                                //fil.Hide();
                                //// Limpiar los campos del formulario
                                //limpiar_textbox();
                        
                                //this.Close();
                                //}
                                */
                            }
                            //Frm_Print_Informe_GuiaRemision informe = new Frm_Print_Informe_GuiaRemision();
                            //fil.Show();
                            //informe.NroDoc = txt_IdComp.Text;
                            //informe.tipoDoc = "Guia Remision-Charlote";
                            //informe.modalidad_traslado = lbl_CodModalidadTraslado.Text;
                            //informe.lbl_nroDoc.Text = txt_IdComp.Text;
                            //informe.ShowDialog();
                            //fil.Hide();
                            //limpiar_textbox();
                            //this.Close();
                        }
                        else if(idempresa == 3)
                        {
                            //comercial airlee
                        }
                        else if(idempresa == 4)
                        {
                            //turbo inject
                        }else if(idempresa == 5)
                        {
                            //inversiones mavaqui
                        }else if( idempresa == 6)
                        {
                            //pando
                        }else if(idempresa == 7)
                        {
                            //jassistore sac
                        }else if(idempresa == 8)
                        {
                            //valero apolin
                        }
                        else if(idempresa == 9)
                        {
                            //inve anelay
                        }else if(idempresa == 10)
                        {

                            //coleccionista del peru sac
                            //german
                           
                            if (lbl_codRespuestSunat.Text == "99")
                            {
                                fil.Show();
                                ok.Lbl_msm1.Text = "SUNAT rechazó la Guía. Verifique los datos.";
                                ok.ShowDialog();
                                fil.Hide();
                                this.Close();
                                /*
                                //// Mostrar informe
                                ////Frm_Print_Informe_GuiaRemision informe = new Frm_Print_Informe_GuiaRemision();
                                //Frm_Print_Informe_GuiaRemision informe = new Frm_Print_Informe_GuiaRemision();
                                //fil.Show();
                                //informe.NroDoc = txt_IdComp.Text;
                                //informe.tipoDoc = "Guia Remision-Charlote";
                                //informe.modalidad_traslado = lbl_CodModalidadTraslado.Text;
                                //informe.ShowDialog();
                                //informe.lbl_nroDoc.Text = txt_IdComp.Text;
                                //fil.Hide();
                                //// Limpiar los campos del formulario
                                //limpiar_textbox();
                                //this.Close();
                                ////}
                                ///*/
                            }
                            else if (lbl_codRespuestSunat.Text == "98")
                            {
                                fil.Show();
                                ok.Lbl_msm1.Text = "La Guia se envio a Sunat y se  encuentra en proceso. Intente consultar más tarde.";
                                ok.ShowDialog();
                                fil.Hide();
                                Frm_Print_Informe_GuiaRemision informe = new Frm_Print_Informe_GuiaRemision();
                                fil.Show();
                                informe.NroDoc = txt_IdComp.Text;
                                informe.tipoDoc = "Guia Remision-Rcp";
                                informe.modalidad_traslado = lbl_CodModalidadTraslado.Text;
                                informe.lbl_nroDoc.Text = txt_IdComp.Text;
                                informe.ShowDialog();
                                fil.Hide();
                                this.Close();

                            }
                            else
                            {
                                fil.Show();
                                ok.Lbl_msm1.Text = "La Guía se aprobó por la SUNAT y se guardó exitosamente.";
                                ok.ShowDialog();
                                fil.Hide();
                                Frm_Print_Informe_GuiaRemision informe = new Frm_Print_Informe_GuiaRemision();
                                fil.Show();
                                informe.NroDoc = txt_IdComp.Text;
                                informe.tipoDoc = "Guia Remision-Rcp";
                                informe.modalidad_traslado = lbl_CodModalidadTraslado.Text;
                                informe.lbl_nroDoc.Text = txt_IdComp.Text;
                                informe.ShowDialog();
                                fil.Hide();
                                limpiar_textbox();
                                this.Close();
                                /*
                                // Mostrar informe
                                //Frm_Print_Informe_GuiaRemision informe = new Frm_Print_Informe_GuiaRemision();
                                
                                //fil.Hide();
                                //// Limpiar los campos del formulario
                                //limpiar_textbox();
                        
                                //this.Close();
                                //}
                                */
                            }
                        }
                        else if(idempresa == 11)
                        {
                            //inversiones njt

                        }else if(idempresa == 12)
                        {
                            //textil charlootte
                            if (lbl_codRespuestSunat.Text == "99")
                            {
                                fil.Show();
                                ok.Lbl_msm1.Text = "SUNAT rechazó la Guía. Verifique los datos.";
                                ok.ShowDialog();
                                fil.Hide();
                                this.Close();
                                /*
                                //// Mostrar informe
                                ////Frm_Print_Informe_GuiaRemision informe = new Frm_Print_Informe_GuiaRemision();
                                //Frm_Print_Informe_GuiaRemision informe = new Frm_Print_Informe_GuiaRemision();
                                //fil.Show();
                                //informe.NroDoc = txt_IdComp.Text;
                                //informe.tipoDoc = "Guia Remision-Charlote";
                                //informe.modalidad_traslado = lbl_CodModalidadTraslado.Text;
                                //informe.ShowDialog();
                                //informe.lbl_nroDoc.Text = txt_IdComp.Text;
                                //fil.Hide();
                                //// Limpiar los campos del formulario
                                //limpiar_textbox();
                                //this.Close();
                                ////}
                                ///*/
                            }
                            else if (lbl_codRespuestSunat.Text == "98")
                            {
                                fil.Show();
                                ok.Lbl_msm1.Text = "La Guia se envio a Sunat y se  encuentra en proceso. Intente consultar más tarde.";
                                ok.ShowDialog();
                                fil.Hide();
                                Frm_Print_Informe_GuiaRemision informe = new Frm_Print_Informe_GuiaRemision();
                                fil.Show();
                                informe.NroDoc = txt_IdComp.Text;
                                informe.tipoDoc = "Guia Remision-Charlote";
                                informe.modalidad_traslado = lbl_CodModalidadTraslado.Text;
                                informe.lbl_nroDoc.Text = txt_IdComp.Text;
                                informe.ShowDialog();
                                fil.Hide();
                                limpiar_textbox();
                                this.Close();
                                /*
                                // Mostrar informe
                                //fil.Show();
                                //Frm_Print_Informe_GuiaRemision informe = new Frm_Print_Informe_GuiaRemision();
                                //fil.Show();
                                //informe.NroDoc = txt_IdComp.Text;
                                //informe.tipoDoc = "Guia Remision-Charlote";
                                //informe.modalidad_traslado = lbl_CodModalidadTraslado.Text;
                                //informe.ShowDialog();
                                //informe.lbl_nroDoc.Text = txt_IdComp.Text;
                                //fil.Hide();
                                //// Limpiar los campos del formulario
                                //limpiar_textbox();
                          
                                //this.Close();
                                //}
                                */
                            }
                            else
                            {
                                fil.Show();
                                ok.Lbl_msm1.Text = "La Guía se aprobó por la SUNAT y se guardó exitosamente.";
                                ok.ShowDialog();
                                fil.Hide();
                                Frm_Print_Informe_GuiaRemision informe = new Frm_Print_Informe_GuiaRemision();
                                fil.Show();
                                informe.NroDoc = txt_IdComp.Text;
                                informe.tipoDoc = "Guia Remision-Charlote";
                                informe.modalidad_traslado = lbl_CodModalidadTraslado.Text;
                                informe.lbl_nroDoc.Text = txt_IdComp.Text;
                                informe.ShowDialog();
                                fil.Hide();
                                limpiar_textbox();
                                this.Close();
                                /*
                                // Mostrar informe
                                //Frm_Print_Informe_GuiaRemision informe = new Frm_Print_Informe_GuiaRemision();
                                
                                //fil.Hide();
                                //// Limpiar los campos del formulario
                                //limpiar_textbox();
                        
                                //this.Close();
                                //}
                                */
                            }
                            //Frm_Print_Informe_GuiaRemision informe = new Frm_Print_Informe_GuiaRemision();
                            //fil.Show();
                            //informe.NroDoc = txt_IdComp.Text;
                            //informe.tipoDoc = "Guia Remision-Charlote";
                            //informe.modalidad_traslado = lbl_CodModalidadTraslado.Text;
                            //informe.lbl_nroDoc.Text = txt_IdComp.Text;
                            //informe.ShowDialog();
                            //fil.Hide();
                            //limpiar_textbox();
                            //this.Close();
                        }
                        else if (idempresa == 13)
                        {
                            //textil charlootte
                            if (lbl_codRespuestSunat.Text == "99")
                            {
                                fil.Show();
                                ok.Lbl_msm1.Text = "SUNAT rechazó la Guía. Verifique los datos.";
                                ok.ShowDialog();
                                fil.Hide();
                                this.Close();

                            }
                            else if (lbl_codRespuestSunat.Text == "98")
                            {
                                fil.Show();
                                ok.Lbl_msm1.Text = "La Guia se envio a Sunat y se  encuentra en proceso. Intente consultar más tarde.";
                                ok.ShowDialog();
                                fil.Hide();
                                Frm_Print_Informe_GuiaRemision informe = new Frm_Print_Informe_GuiaRemision();
                                fil.Show();
                                informe.NroDoc = txt_IdComp.Text;
                                informe.tipoDoc = "Guia Remision-Lucero";
                                informe.modalidad_traslado = lbl_CodModalidadTraslado.Text;
                                informe.lbl_nroDoc.Text = txt_IdComp.Text;
                                informe.ShowDialog();
                                fil.Hide();
                                limpiar_textbox();
                                this.Close();
     
                               
                            }
                            else
                            {
                                fil.Show();
                                ok.Lbl_msm1.Text = "La Guía se aprobó por la SUNAT y se guardó exitosamente.";
                                ok.ShowDialog();
                                fil.Hide();
                                Frm_Print_Informe_GuiaRemision informe = new Frm_Print_Informe_GuiaRemision();
                                fil.Show();
                                informe.NroDoc = txt_IdComp.Text;
                                informe.tipoDoc = "Guia Remision-Lucero";
                                informe.modalidad_traslado = lbl_CodModalidadTraslado.Text;
                                informe.lbl_nroDoc.Text = txt_IdComp.Text;
                                informe.ShowDialog();
                                fil.Hide();
                                limpiar_textbox();
                                this.Close();
                               
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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
                RN_GuiaRemision objGr = new RN_GuiaRemision();
                objCPE_GUIA.NRO_COMPROBANTE = txt_IdComp.Text.Trim(); //T-00001  - GRT-V((31)
                objCPE_GUIA.FECHA_DOCUMENTO = dtp_FechaCom.Value.ToString("yyyy-MM-dd");
                objCPE_GUIA.COD_TIPO_DOCUMENTO = "09";//lbl_id_TipodocSunat.Text;//tipo doc guia (09-grremitente / 31-transportista)
                objCPE_GUIA.NOTA = "-";
                //objCPE_GUIA.NRO_DOC_REFERENCIA = txt_nroDoc_ref.Text.Trim();
                //objCPE_GUIA.COD_TIPO_DOCUMENTO_REF = lbl_codComproRef.Text.Trim();
                //objCPE_GUIA.NOMBRE_DOC_REFE = lbl_nomComproRef.Text.Trim();

                // Lógica para manejar múltiples IDs del textbox
                string idsTexto = Txt_buscarFac.Text.Trim();
                List<string> ids = idsTexto.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(id => id.Trim())
                                           .ToList();

                // Crear una lista para los documentos de referencia
                List<DocumentoReferencia> docsReferencia = new List<DocumentoReferencia>();
                // Llenar la lista con los datos para cada ID
                foreach (string id in ids)
                {
                    DocumentoReferencia doc = new DocumentoReferencia();
                    doc.ID_DOC_REF = id;
                    // Determinar el tipo de documento basado en el ID
                    string valor = id.ToUpper();
                    if (valor.StartsWith("F"))
                    {
                        doc.TipoDocumento_ref = "01"; // Factura
                        doc.NombreDocumento_ref = "Factura";
                    }
                    else if (valor.StartsWith("B"))
                    {
                        doc.TipoDocumento_ref = "03"; // Boleta
                        doc.NombreDocumento_ref = "Boleta";
                    }
                    else
                    {
                        doc.TipoDocumento_ref = "";
                        doc.NombreDocumento_ref = "Tipo desconocido";
                    }
                    docsReferencia.Add(doc);
                }

                // Asignar la lista a tu objeto principal
                objCPE_GUIA.ListaDocsReferencia = docsReferencia;

                //objCPE_GUIA.ITEM_ENVIO = 1;
                //objCPE_GUIA.TIPO_DOCUMENTO_CLIENTE = lbl_codTipoDocCli.Text.Trim(); //"6";

                if(lbl_codTipoDocCli.Text == "1")
                {
                    objCPE_GUIA.TIPO_DOCUMENTO_CLIENTE = "1";//DNI
                }
                else if(lbl_codTipoDocCli.Text == "6")
                {
                    objCPE_GUIA.TIPO_DOCUMENTO_CLIENTE = "6";//RUC

                }
                else if( lbl_codTipoDocCli.Text == "4")
                {
                    objCPE_GUIA.TIPO_DOCUMENTO_CLIENTE = "4";//C/E
                }

                objCPE_GUIA.NRO_DOCUMENTO_CLIENTE = txt_rucCliente.Text.Trim();//"20606264004";
                objCPE_GUIA.RAZON_SOCIAL_CLIENTE = txt_razonsocialCliente.Text.Trim(); //"C.G CAPITAL SYSTEM S.A.C";

                objCPE_GUIA.COD_MOTIVO_TRASLADO = lbl_CodMotivo.Text; //"1"; //catal-20
                objCPE_GUIA.COD_MODALIDAD_TRASLADO = lbl_CodModalidadTraslado.Text.Trim(); // "2";//catalogo18-TRANSPORTE PRIVADO  - T.publico 1
                objCPE_GUIA.DESCRIPCION_MOTIVO_TRASLADO = cbo_motivo.Text; // "Venta"; //02compra-(03-vnta,entrega tercero)(04-traslado entre establicimiento,misma empresa)
                objCPE_GUIA.COD_UND_PESO_BRUTO = cbo_und.SelectedItem.ToString(); //"KGM";
                objCPE_GUIA.PESO_BRUTO = Convert.ToDecimal(numericPesTotal.Value);
                objCPE_GUIA.FECHA_INICIO = dtp_fechaTraslado.Value.ToString("yyyy-MM-dd");// "2024-12-20"; /*dtp_fechaTraslado.Value.ToString("yyyy-MM-dd");*/ //dtp_FechaCom.Value.ToString("yyyy-MM-dd");//"2024-11-26";

                //Transporte publico
                objCPE_GUIA.TIPO_DOCUMENTO_TRANSPORTISTA = "6";
                objCPE_GUIA.NRO_DOCUMENTO_TRANSPORTISTA = lbl_rucTransportistaPublico.Text.Trim();//"";
                objCPE_GUIA.RAZON_SOCIAL_TRANSPORTISTA = txt_rznTranPublico.Text.Trim();//"";
                objCPE_GUIA.MTC_TRANSPORTISTA = txt_trnMtcPublico.Text.Trim(); //"";

                //TRANSPORTE PRIVADO:
                //Conductores:
                objCPE_GUIA.NRO_DOC_CHOFER = txt_dniConductor.Text.Trim();// "87654321";
                objCPE_GUIA.NOMBRE_CHOFER = txt_nomConductor.Text.Trim(); //"JUAN";
                objCPE_GUIA.APELLIDO_CHOFER = txt_apellidoConductor.Text.Trim();//"PEREZ";
                objCPE_GUIA.LICENCIA_CHOFER = txt_licenciaCond.Text.Trim();//"Q87654321";

                if (chk_conductor_secundario.Checked)
                {
                    //Cond Secundario:
                    objCPE_GUIA.NRO_DOC_CHOFER_SEC = lbl_dniCond_Secund.Text.Trim();
                    objCPE_GUIA.NOMBRE_CHOFER_SEC = lbl_nomCond_secund.Text.Trim();
                    objCPE_GUIA.APELLIDO_CHOFER_SEC = lbl_apell_cond_secund.Text.Trim();
                    objCPE_GUIA.LICENCIA_CHOFER_SEC = lbl_Licen_Secund.Text.Trim();
                }

                //ORIGEN:
                objCPE_GUIA.COD_UBIGEO_ORIGEN = lbl_cod_ubigeo_partida.Text.Trim();//"070104";
                objCPE_GUIA.DIRECCION_ORIGEN = txt_direccion_Partida.Text.Trim(); //"Calle Islas Aleutinas 122";//"Direc 1";

                //direccion destino -delivery
                objCPE_GUIA.COD_UBIGEO_DESTINO = lbl_cod_ubigeo_llegada.Text.Trim(); //"140117";
                objCPE_GUIA.DIRECCION_DESTINO = txt_direccion_llegada.Text.Trim();// "av la mar, pueblo libre";

                //VEHICULO PRINCIPAL:
                objCPE_GUIA.PLACA_VEHICULO = txt_placaVeh.Text.Trim();//"123QWE";

                if (chk_vehiculo_secundario.Checked)
                {
                    //VEHICULO SECUNDARIO 
                    objCPE_GUIA.PLACA_CARRETA = lbl_placaVeh_Sec.Text.Trim();
                }

                //datos de la empresa:
                objCPE_GUIA.NRO_DOCUMENTO_EMPRESA = Lbl_RucEmisor.Text.Trim();
                objCPE_GUIA.TIPO_DOCUMENTO_EMPRESA = "6";
                objCPE_GUIA.RAZON_SOCIAL_EMPRESA = Lbl_EmpresaEmisor.Text.Trim();
                objCPE_GUIA.COD_UBIGEO_EMPRESA = "150115";//"070104";//"150101"; // -   //san miguel 150136
                objCPE_GUIA.DIRECCION_EMPRESA = Lbl_DireccionEmpresa.Text.Trim();
                objCPE_GUIA.DEPARTAMENTO_EMPRESA = "Lima";//"Callao";
                objCPE_GUIA.PROVINCIA_EMPRESA = "Lima";//"Callao";
                objCPE_GUIA.DISTRITO_EMPRESA = "La Victoria";//"La Perla";
                //objCPE.CODIGO_PAIS_EMPRESA = "PE";
                objCPE_GUIA.RAZON_SOCIAL_EMPRESA = Lbl_EmpresaEmisor.Text.Trim();
                //objCPE.CONTACTO_EMPRESA = "";
                objCPE_GUIA.USUARIO_SOL_EMPRESA = Lbl_RucEmisor.Text.Trim() + Lbl_UsuarioSol.Text.Trim();//"20608131494MODDATOS";//"20608131494GERSACFE";//"20608131494MODDATOS";//Lbl_RucEmisor.Text.Trim() + Lbl_UsuarioSol.Text.Trim();
                objCPE_GUIA.PASS_SOL_EMPRESA = Lbl_ClaveSol.Text.Trim();//"Gersac01";//"MODDATOS";//Lbl_ClaveSol.Text.Trim();
                objCPE_GUIA.CONTRA_FIRMA = Lbl_ClaveCertificado.Text.Trim();

                //DATOS TOKEN:
                objCPE_GUIA.CLIENT_ID = Lbl_CLIENT_ID.Text.Trim();//"test-85e5b0ae-255c-4891-a595-0b98c65c9854"; //"4a5a83d5-d68f-402c-bb95-a71120476671"; //Lbl_CLIENT_ID.Text.Trim();
                objCPE_GUIA.CLIENT_SECRET = lbl_CLIENT_SECRET.Text.Trim(); //"test-Hty/M6QshYvPgItX2P0+Kw=="; //"UWf82kLc4eCDrARQmsiv/A==";//lbl_CLIENT_SECRET.Text.Trim();

                // 2. Verificar si el token es válido (usando la capa de negocio)
                RN_Empresa objRN = new RN_Empresa();
                int idEmpresa = Cls_Libreria.Idempresa;
                bool esValido = objRN.RN_Token_Es_Valido(idEmpresa);

                string token;
                if (!esValido)
                {
                    // Si el token ha expirado, generar uno nuevo.
                    //aca se maneja la url de api prueba(nubefact) y original sunat
                    token = await ObtenerTokenSiEsNecesario(idEmpresa);
                }
                else
                {
                    // Si el token es válido, usar el token existente
                    token = await ObtenerTokenSiEsNecesario(idEmpresa);
                }
                objCPE_GUIA.TOKEN = token;
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

                //Dictionary<string, string> dicionaryenvio = new Dictionary<string, string>();
                //dicionaryenvio = await obj.Enviar_GuiaRemision_aSunat(objCPE_GUIA);
                //TXTHASH_CPE.Text = dicionaryenvio["hash_cpe"];
                // === Envío inicial (ya lo tienes) ===
                Dictionary<string, string> dicionaryenvio = await obj.Enviar_GuiaRemision_aSunat(objCPE_GUIA);
                TXTHASH_CPE.Text = dicionaryenvio.ContainsKey("hash_cpe") ? dicionaryenvio["hash_cpe"] : "";

                // === Validar ticket ===
                string numTicket = dicionaryenvio.ContainsKey("numTicket") ? dicionaryenvio["numTicket"] : null;
                string fecRecepcion = dicionaryenvio.ContainsKey("fecRecepcion") ? dicionaryenvio["fecRecepcion"] : null;

                if (string.IsNullOrWhiteSpace(numTicket))
                {
                    MessageBox.Show("SUNAT no devolvió numTicket. No se puede obtener CDR.");
                    return;
                }

                // Guardar ticket en tu BD
                objGr.RN_ActualizarRespuestas_GuiaRem(txt_IdComp.Text.Trim(), numTicket, TXTHASH_CPE.Text);

                // === Polling del ticket: intenta hasta 12 veces, cada 5s ===
                string rutaArchivoCdr = @"D:\\CPE_2\\PRODUCCION\\";
                string ruc = objCPE_GUIA.NRO_DOCUMENTO_EMPRESA;
                string nombreFile = objCPE_GUIA.NRO_DOCUMENTO_EMPRESA + "-" + objCPE_GUIA.COD_TIPO_DOCUMENTO + "-" + objCPE_GUIA.NRO_COMPROBANTE;

                Dictionary<string, string> rptaCdr = null;
                for (int i = 0; i < 12; i++)
                {
                    rptaCdr = await obj.EnvioTicketAsync(rutaArchivoCdr, numTicket, token, ruc, nombreFile);

                    string codTicket = rptaCdr.ContainsKey("ticket_rpta") ? rptaCdr["ticket_rpta"] : null; // "98", "99" o "0"
                    if (codTicket == "98")
                    {
                        await Task.Delay(5000);
                        continue; // seguir consultando
                    }

                    // estados terminales 0 (listo, ya hay arcCdr) o 99 (rechazado, sin CDR)
                    break;
                }

                if (rptaCdr == null)
                {
                    MessageBox.Show("No se obtuvo respuesta al consultar el ticket.");
                    return;
                }

                // === Actualiza UI/estado según respuesta ===
                string cdrHash = rptaCdr.ContainsKey("cdr_hash") ? rptaCdr["cdr_hash"] : "";
                string cdrMsjSunat = rptaCdr.ContainsKey("cdr_msj_sunat") ? rptaCdr["cdr_msj_sunat"] : "";
                string cdrResponse = rptaCdr.ContainsKey("cdr_ResponseCode") ? rptaCdr["cdr_ResponseCode"] : ""; // "0" aceptado, otros observado/rechazado
                string ticket_rpta = rptaCdr.ContainsKey("ticket_rpta") ? rptaCdr["ticket_rpta"] : ""; // "0","98","99"
                string numError = rptaCdr.ContainsKey("numerror") ? rptaCdr["numerror"] : "";
                string indCdrGenerado = rptaCdr.ContainsKey("indCdrGenerado") ? rptaCdr["indCdrGenerado"] : "";

                lbl_codRespuestSunat.Text = string.IsNullOrEmpty(cdrResponse) ? ticket_rpta : cdrResponse; // muestra algo útil

                // === Persistir estado en tu BD ===
                // Regla: si ticket_rpta == "0" hubo CDR (R- ZIP/XML en ruta). Si "99", no hay CDR.
                if (ticket_rpta == "0")
                {
                    // CDR descargado y parseado; cdrResponse == "0" aceptado, != "0" observado/rechazado
                    string estado = (cdrResponse == "0") ? "Aprobado" : "Aprobado Obs";
                    objGr.RN_CambiarEstado_CdrSunat_GuiaRem(txt_IdComp.Text.Trim(), estado, cdrHash);
                }
                else if (ticket_rpta == "99")
                {
                    // Rechazado sin CDR (ej: 1033)
                    objGr.RN_CambiarEstado_CdrSunat_GuiaRem(txt_IdComp.Text.Trim(), "Rechazado", "");
                }
                else // quedó en "98" tras agotar intentos
                {
                    objGr.RN_CambiarEstado_CdrSunat_GuiaRem(txt_IdComp.Text.Trim(), "En proceso", "");
                }

                // === Mensajes al usuario (más precisos) ===
                if (ticket_rpta == "99")
                {
                    // Muestra el detalle real, no "error general"
                    MessageBox.Show($"SUNAT rechazó el envío (99).\nCódigo: {numError}\nDetalle: {cdrMsjSunat}");
                }
                else if (ticket_rpta == "98")
                {
                    MessageBox.Show("La guía sigue en proceso en SUNAT. Vuelva a consultar más tarde.");
                }
                else // "0"
                {
                    if (cdrResponse == "0")
                        MessageBox.Show("La Guía fue aceptada por SUNAT.");
                    else
                        MessageBox.Show($"SUNAT procesó con observaciones / rechazo.\nCódigo: {cdrResponse}\nDetalle: {cdrMsjSunat}");
                }

                //PROBANDO CODIGO :
                // FIN
                /*
                // Aquí obtenemos el numTicket de la respuesta de SUNAT
                if (dicionaryenvio.ContainsKey("numTicket"))
                {
                    string numTicket = dicionaryenvio["numTicket"];
                    string fecRecepcion = dicionaryenvio["fecRecepcion"];

                    // Usar numTicket y fecRecepcion como sea necesario
                    //Console.WriteLine($"Ticket: {numTicket}, Fecha Recepción: {fecRecepcion}");
                    //Guardamso el numero de Ticket
                    objGr.RN_ActualizarRespuestas_GuiaRem(txt_IdComp.Text.Trim(), numTicket, TXTHASH_CPE.Text);

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
                        lbl_codRespuestSunat.Text = cdrResponseCode;
                        Console.WriteLine($"numerror: {numError}");

                        // Si el CDR es exitoso, proceder con la actualización
                        if (numError == string.Empty)  // Usando numError vacío para verificar éxito
                        {
                            // Realiza alguna acción con el cdrHash, como almacenar o actualizar el estado
                            // Actualizar el estado de CDR como Aprobado
                            objGr.RN_CambiarEstado_CdrSunat_GuiaRem(txt_IdComp.Text.Trim(), "Aprobado", cdrHash);
                            MessageBox.Show("El CDR ha sido aprobado.");
                        }
                        else if (cdrResponseCode == "99")  // Error con el envío //se reemplaza por el numerror
                        {
                            // Actualizar el estado de CDR - Rechazado
                            objGr.RN_CambiarEstado_CdrSunat_GuiaRem(txt_IdComp.Text.Trim(), "Rechazado", cdrHash);
                            //MessageBox.Show($"Error al procesar el CDR: {cdrMsjSunat}");
                        }
                        else if (cdrResponseCode == "98")  // Envío en proceso
                        {
                            // Actualizar el estado de CDR - en proceso
                            objGr.RN_CambiarEstado_CdrSunat_GuiaRem(txt_IdComp.Text.Trim(), "En Proceso volver a consultar mas tarde", cdrHash);
                            //MessageBox.Show("El envío del CDR.");
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
                */
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                lbl_rutaXml.Text = obj.RutaCompletaxml;
            }
            catch (Exception)
            {
                throw;
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

            }
            else if (cbo_tipoDoc_Guia.SelectedIndex == 1)
            {
                lbl_id_TipodocSunat.Text = "31"; //guia transportista
            }
        }
        private void gunaLabel2_Click(object sender, EventArgs e)
        {

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
                lbl_CodMotivo.Text = "01"; //00 venta

            }
            else if (cbo_motivo.SelectedIndex == 1)
            {
                lbl_CodMotivo.Text = "02"; //compra
            }
            else if (cbo_motivo.SelectedIndex == 2)
            {
                lbl_CodMotivo.Text = "03"; //venta con entrega a terceros
            }
            else if (cbo_motivo.SelectedIndex == 3)
            {
                lbl_CodMotivo.Text = "04";//traslado entre establecimientos de la misma empresa
            }
        }
        private void cbo_ModalidadTraslado_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Primero, deshabilitar todo lo que pueda estar habilitado de la selección anterior.
            lbl_busVeh.Enabled = false;
            
            chk_conductor_secundario.Enabled = false;
            //lbl_busVehSecundario.Enabled = false;
            lbl_buscCond.Enabled = false;
            //lbl_buscCond_Sec.Enabled = false;
            lbl_busTranspPubl.Enabled = false;

            if (cbo_ModalidadTraslado.SelectedIndex == 0)// trasnporte privado
            {
                lbl_CodModalidadTraslado.Text = "02";
                lbl_busVeh.Enabled = true;
                //chk_vehiculo_secundario.Enabled = true;
                //lbl_busVehSecundario.Enabled = true;
                //conductor prin.
                lbl_buscCond.Enabled = true;
                //conduct.secu;
                chk_conductor_secundario.Enabled = true;
                //lbl_buscCond_Sec.Enabled = true;
            }
            else if (cbo_ModalidadTraslado.SelectedIndex == 1)
            {
                lbl_CodModalidadTraslado.Text = "01";
                lbl_busTranspPubl.Enabled = true;
                //chk_vehiculo_secundario.Enabled = false;
                //chk_conductor_secundario.Enabled = false;
            }
        }
        private void lbl_busProv_Click(object sender, EventArgs e)
        {

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Listadocliente cli = new Frm_Listadocliente();

            fil.Show();
            cli.ShowDialog();
            fil.Hide();

            if (cli.Tag.ToString() == "A")
            {
                lbl_idCliente.Text = cli.lbl_id.Text.Trim();
                txt_razonsocialCliente.Text = cli.lbl_nom.Text.Trim();
                txt_rucCliente.Text = cli.lbl_ruc.Text.Trim().Replace(" ", "");
                lbl_codTipoDocCli.Text = cli.lbl_codtipoDocCli.Text.Trim();
            }

            
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

        private void lbl_buscCond_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Conductores con = new Frm_Conductores();

            fil.Show();
            con.ShowDialog();
            fil.Hide();

            if (con.Tag.ToString() == "A")
            {
                lbl_idConductor.Text = con.txt_idvehiculo.Text;
                txt_nomConductor.Text = con.txt_nombreCond.Text;
                txt_apellidoConductor.Text = con.txt_apellidos.Text;
                txt_dniConductor.Text = con.txtDni.Text;
                txt_licenciaCond.Text = con.txtLicencia.Text;

                txt_concat_datos_cond.Text = $"{txt_dniConductor.Text} - {txt_nomConductor.Text + " " + txt_apellidoConductor.Text} - {txt_licenciaCond.Text}";
            }
        }
        private void lbl_buscCond_Sec_Click(object sender, EventArgs e)
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
                txt_concat_datos_cond_sec.Text = $"{lbl_dniCond_Secund.Text} - {lbl_nomCond_secund.Text + " " + lbl_apell_cond_secund.Text} - {lbl_Licen_Secund.Text}";
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
                txt_placaVeh.Text = veh.txt_placa.Text.Trim();
                lbl_marcaVehi.Text = veh.txt_marcaVehiculo.Text;
                //datos concatenados en un solo label:
                txt_veh_placa_model.Text = $"{txt_placaVeh.Text} - {txt_vehiculo.Text} - {lbl_marcaVehi.Text}";

                lbl_placaVeh_Sec.Text = veh.txt_placaSecund.Text.Trim();
                txt_veh_placa_model_sec.Text = lbl_placaVeh_Sec.Text.Trim();

            }
        }
        private void label40_Click(object sender, EventArgs e)
        {

        }
        private void gunaTextBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void gunaGroupBox5_Click(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
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
                    txt_nroDoc_ref.Text = Convert.ToString(dt["id_Doc"]);
                    //txt_nroPed.Text = Convert.ToString(dt["id_Ped"]);
                    //Cbo_TipoDoc.SelectedValue = Convert.ToUInt32(dt["Id_Tipo"]);
                    //dtp_FechaEmi.Value = Convert.ToDateTime(dt["Fecha_Emi"]);
                    //txt_NroOperac.Text = Convert.ToString(dt["Nro_Operacion"]);
                    //tx_efectivo.Text = Convert.ToString(dt["Efectivo"]); //validar que emita el monto con el que pago. para que calcule el vuelto
                    //lbl_vlto.Text = Convert.ToString(dt["Vuelto"]);
                    //txt_vuelto.Text = Convert.ToString(dt["Vuelto"]);
                    //Cbo_TipoPago.Text = Convert.ToString(dt["TipoPago"]);
                    //lbl_idcliente.Text = Convert.ToString(dt["Id_Cliente"]);
                    //txt_cliente.Text = Convert.ToString(dt["Razon_Social_Nombres"]);
                    //lbl_direccion.Text = Convert.ToString(dt["Direccion"]);
                    //lbl_dni_ruc.Text = Convert.ToString(dt["DNI"]);
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
                        //xlist.SubItems.Add(xitem["Utilidad_Unit"].ToString());
                        //xlist.SubItems.Add(xitem["TotalUtilidad"].ToString());

                        //xlist.SubItems.Add(xitem["AfectoIgv"].ToString());
                        //xlist.SubItems.Add(xitem["Precio_sinIgv"].ToString());
                        //xlist.SubItems.Add(xitem["subtotal_SinIgv"].ToString());
                        //xlist.SubItems.Add(xitem["Igv_subtotal"].ToString());
                        //xlist.SubItems.Add("NIU");  //NIU -- ZZ
                        //xlist.SubItems.Add(xitem["CodTipo_Afectacion"].ToString());

                        /*
                            lis.Columns.Add("ID producto", 80, HorizontalAlignment.Left); //0
                            lis.Columns.Add("Descripcion Producto", 400, HorizontalAlignment.Left); //1
                            lis.Columns.Add("Cantidad", 80, HorizontalAlignment.Left); //2
                            lis.Columns.Add("Precio Unit", 90, HorizontalAlignment.Right); //3
                            lis.Columns.Add("Importe", 90, HorizontalAlignment.Right); //4
                            lis.Columns.Add("Und", 0, HorizontalAlignment.Right); //5
                         */

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
       
        public void Buscar_DocsReferencia_paraGr(List<string>ids)
        {

           //Instanciar el objeto de negocio
           RN_Documento obj = new RN_Documento();
           //DataTable dato = new DataTable();

            //1. limpiar el listview antes de llenarlo
            lsv_Det.Items.Clear();
            //si la lista de IDs esta vacia, no se hace nada
            if(ids == null || ids.Count == 0) 
            {
                pnl_sinProd.Visible = true;
                return;
            }
            //Usar una variable para saber si todos los documentos se encontraron
            bool  todosEncontrados = true;

           try
           {

                //// ----------------------------------------------------
                //// PASO 1: Obtener y Asignar Datos de CABECERA
                //// ----------------------------------------------------
                //string primerId = ids[0].Trim();
                //DataTable dtCabecera = obj.RN_Buscador_DocumentoCabecera_porID(primerId);

                //if (dtCabecera != null && dtCabecera.Rows.Count > 0)
                //{
                //    DataRow cabecera = dtCabecera.Rows[0];
                //    // Asume que tienes estos TextBox en tu formulario
                //    txt_rucCliente.Text = cabecera["RUC"].ToString();
                //    txt_razonsocialCliente.Text = cabecera["Nombre_Cliente"].ToString();
                //}
                //else
                //{
                //    // Limpiar campos si el documento no se encuentra
                //    txt_rucCliente.Text = "";
                //    txt_razonsocialCliente.Text = "Documento de referencia no encontrado.";
                //}

                foreach (string id in ids) // Recorrer cada ID de documento
               {
                   DataTable dato = obj.RN_Buscador_DocumentoDetalle_porID(id.Trim());
                   //dato = obj.RN_Buscador_DocumentoGR_Detalle_porID(nroDoc.Trim());

                   if (dato.Rows.Count > 0)
                   {
                       //var dt = dato.Rows[0];

                       //txt_nroDoc_ref.Text = Convert.ToString(dt["id_Doc"]);
                       //2. Añadir los datos del documento actual al listview
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

                       }
                        //Calcular();
                        //pnl_sinProd.Visible = false;
                    }
                    else
                    {
                        // 3. Manejar el caso de que un documento no se encuentre
                        todosEncontrados = false;

                        // Puedes mostrar una advertencia para cada documento no encontrado
                        Frm_Filtro fil = new Frm_Filtro();
                        Frm_Advertencia ver = new Frm_Advertencia();

                        fil.Show();
                        ver.Lbl_msm1.Text = $"El Documento {id} no existe o no tiene detalles.";
                        ver.ShowDialog();
                        fil.Hide();
                    }
               }
                // 4. Actualizar la UI una vez que todos los documentos han sido procesados
                Calcular();
                pnl_sinProd.Visible = lsv_Det.Items.Count == 0;
           }
           catch (Exception ex)
           {
               MessageBox.Show("Error al leer: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
           }
           
        }
       
        private void lblBuscar_factura_Click(object sender, EventArgs e)
        {
            Frm_Advertencia ad = new Frm_Advertencia();
            Frm_Filtro fil = new Frm_Filtro();

            bt_add.Enabled= false;
            bt_editCant.Enabled= false;
            bt_editPre.Enabled= false;
            bt_Delete.Enabled= false;
            
            // Obtener el texto del TextBox y limpiarlo
            string idsText = Txt_buscarFac.Text.Trim();
            if (string.IsNullOrEmpty(idsText))
            {
                fil.Show();
                //MessageBox.Show("Por favor, ingresa uno o más IDs de documentos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ad.Lbl_msm1.Text = "Por favor, ingresa uno o más IDs de documentos.";
                ad.ShowDialog();
                fil.Hide();
                return;
            }
            if(cbo_motivo.SelectedIndex == -1)
            {
                fil.Show();
                ad.Lbl_msm1.Text = "Seleccione el Motivo";
                ad.ShowDialog();
                fil.Hide();
                cbo_motivo.Focus();
                return;
            }
            if (cbo_ModalidadTraslado.SelectedIndex == -1) 
            {
                fil.Show();
                ad.Lbl_msm1.Text = "Seleccione la modalidad de Traslado";
                ad.ShowDialog();
                fil.Hide();
                cbo_motivo.Focus();
                return;
            }
            // Dividir la cadena de IDs separada por comas en una lista de strings
            List<string> ids = idsText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(id => id.Trim())
                                      .ToList();

            // Llamar al método que procesa la lista de IDs ()
            Buscar_DocsReferencia_paraGr(ids);

            // Actualizar la interfaz de usuario basándose en la lista de IDs
            if (ids.Count > 1)
            {
                // Si hay varios documentos, mostrar un mensaje genérico
                lbl_codComproRef.Text = "varios";
                lbl_nomComproRef.Text = "Documentos Varios";
            }
            else if (ids.Count == 1)
            {
                // Si es un solo documento, determinar su tipo
                string valor = ids[0].ToUpper();
                if (valor.StartsWith("F"))
                {
                    lbl_codComproRef.Text = "01";
                    lbl_nomComproRef.Text = "Factura";
                }
                else if (valor.StartsWith("B"))
                {
                    lbl_codComproRef.Text = "03";
                    lbl_nomComproRef.Text = "Boleta";
                }
                else
                {
                    lbl_codComproRef.Text = "";
                    lbl_nomComproRef.Text = "Tipo desconocido";
                }
            }
            else
            {
                // Si la lista está vacía después de procesarla
                lbl_codComproRef.Text = "";
                lbl_nomComproRef.Text = "Ningún Documento";
            }
        }

        // Método público para recibir la lista de IDs del otro formulario
        public void CargarIds(List<string> ids)
        {
            // Asegúrate de que el TextBox no sea nulo antes de usarlo.
            if (Txt_buscarFac != null)
            {
                // Unir los IDs en una cadena para mostrarlos en el TextBox.
                Txt_buscarFac.Text = string.Join(", ", ids);
              
            }

            // Opcional: Si quieres mostrar los IDs en otro panel, puedes hacerlo aquí.
            // Por ejemplo, en una etiqueta o un ListView dentro del panel.
            // lbl_idsSeleccionados.Text = string.Join(", ", ids);
            txt_nroDoc_ref.Text = string.Join(", ", ids);
        }
        private void lbl_busTranspPubl_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_RegTransportista trn = new Frm_RegTransportista();

            fil.Show();
            trn.ShowDialog();
            fil.Hide();

            if (trn.Tag.ToString() == "A")
            {
                lbl_idTransportista.Text = trn.txt_id.Text.Trim();
                txt_rznTranPublico.Text = trn.txt_nombre.Text.Trim();
                lbl_rucTransportistaPublico.Text = trn.txt_ruc.Text.Trim();
                txt_trnMtcPublico.Text = trn.txt_mtc.Text.Trim();
            }
        }

        private void lbl_busVehSecundario_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Vehiculos veh = new Frm_Vehiculos();

            fil.Show();
            veh.ShowDialog();
            fil.Hide();

            if (veh.Tag.ToString() == "A")
            {
                lbl_idVehiculo_Sec.Text = veh.txt_idvehiculo.Text;
                //txtVehiculoSec.Text = veh.txt_modelo.Text;
                lbl_placaVeh_Sec.Text = veh.txt_placaSecund.Text;
                //datos concatenados en un solo label:
                txt_veh_placa_model_sec.Text = $"{lbl_placaVeh_Sec.Text}";
            }
            else
            {
                lbl_placaVeh_Sec.Text = "";
            }
        }
        

        private void chk_vehiculo_secundario_CheckedChanged(object sender, EventArgs e)
        {
            //if (chk_vehiculo_secundario.Checked)
            //{
            //    lbl_busVehSecundario.Enabled = true;
            //}
            //else
            //{
            //    lbl_busVehSecundario.Enabled =false;
            //    txtVehiculoSec.Text = "";

            //}
        }

        private void chk_conductor_secundario_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_conductor_secundario.Checked)
            {
                lbl_buscCond_Sec.Enabled = true;
            }
            else
            {
                lbl_buscCond_Sec.Enabled = false;
            }
        }

    }
}
