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
using static Prj_Capa_Entidad.EN_Ubigeo;

//IMPORTACION F.E
using BE = businessEntities;
using CPEEnvio;
using CrearXML;
using Signature;
using Microsell_Lite.GUIAREMISION;
using DevComponents.DotNetBar;
using Bunifu.Framework.UI;




namespace Microsell_Lite.Ventas
{
   
    public partial class Frm_Crear_Ventas : Form
    {
        private List<EN_Promocion_Venta> promocionesAplicadas = new List<EN_Promocion_Venta>();

        private string selectedDepartamento;
        private string selectedProvincia;

        private string selectedDepartamentoDestino;
        private string selectedProvinciaDestino;
        //private List<EN_Gr_Transportista> _guíasSeleccionadas;
        //RN_Ubigeo NegocioUbigeo = new RN_Ubigeo();

        public Frm_Crear_Ventas()
        {
            InitializeComponent();
            //_guíasSeleccionadas = guíasSeleccionadas;
        }

        // Método para cargar las guías en el DataGridView
        //private void CargarGuías()
        //{
        //    foreach (var guia in _guíasSeleccionadas)
        //    {
        //        var item = new ListViewItem(guia.Idgr_Transp);
        //        //item.SubItems.Add(guia.IdCliente);
        //        //item.SubItems.Add(guia.Subtotal.ToString());
        //        item.SubItems.Add(guia.Fecha.ToString("dd/MM/yyyy"));
        //        lsv_Det.Items.Add(item);
        //    }
        //}

        private async void Frm_Ventana_Ventas_Load(object sender, EventArgs e)
        {
            //this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            Configurar_listView();
            Llenar_Combo_docs();
            Leer_Dato_Empresa();

            Cbo_TipoPago.SelectedIndex = 0; //para colocar cualquier textobx se inicie en primera opcion
            //Cbo_TipoDoc.SelectedIndex();
            Cbo_TipoDoc.SelectedIndex = 1;
            Configura_ListView_Pdet();
            txtBusquedaProd.Focus();
            cbo_tipoServer.SelectedIndex = 1;
            //LoadDepartamentos();// Cargar el departamento y seleccionar "Lima" por defecto
            //LoadProvincias("LIMA");  // Cargar las provincias para Lima
            //LoadDistritos("LIMA", "LIMA");  // Cargar los distritos para Lima


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

        private void Configurar_listView()
        {
            var lis = lsv_Det;

            lis.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("ID producto", 90, HorizontalAlignment.Left); //0
            lis.Columns.Add("Descripcion producto", 400, HorizontalAlignment.Left);  //1
            lis.Columns.Add("cantidad", 70, HorizontalAlignment.Left);  //2

           
            lis.Columns.Add("precio Unit", 60, HorizontalAlignment.Right);  //3
            lis.Columns.Add("Importe", 80, HorizontalAlignment.Right);  //4
           
            lis.Columns.Add("Tipo Producto", 0, HorizontalAlignment.Right);  //5
            lis.Columns.Add("Und", 60, HorizontalAlignment.Center);  //6
            lis.Columns.Add("Utilidad Unit", 0, HorizontalAlignment.Right);  //7
            lis.Columns.Add("Total Utilidad", 0, HorizontalAlignment.Right);  //8

            //para facturacion electronica 2023:

            lis.Columns.Add("Afect. Igv", 70, HorizontalAlignment.Left);  //9 Gravado ó Exonarado 
            lis.Columns.Add("PreUni sinIgv", 0, HorizontalAlignment.Left);  //10
            lis.Columns.Add("SubTotal SinIgv", 0, HorizontalAlignment.Left);  //11
            lis.Columns.Add("Igv", 40, HorizontalAlignment.Left);  //12
            lis.Columns.Add("Tipo", 0, HorizontalAlignment.Left);  //13
            lis.Columns.Add("CodTipo_Afecto", 0, HorizontalAlignment.Left);  //14
            lis.Columns.Add("Promo", 80, HorizontalAlignment.Center); //informativo cuando se aplica una promo
            //lis.Columns.Add("Precio Original", 0, HorizontalAlignment.Center); //informativo cuando se aplica una promo

            //lis.Columns.Add("Control stock", 0, HorizontalAlignment.Left);  //15

            //lis.Columns.Add("cantidad enMetros", 80, HorizontalAlignment.Left);  //14
            //lis.Columns.Add("Precio Metro", 80, HorizontalAlignment.Left);  //15
            //lis.Columns.Add("Importe enMetros", 80, HorizontalAlignment.Left); // 16
        }

        private void Configura_ListView_Pdet()
        {
            var lis = lsv_Pdet;

            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;

            lis.Columns.Add("ID producto", 0, HorizontalAlignment.Left); //0
            lis.Columns.Add("Descripcion producto", 200, HorizontalAlignment.Left);  //1
            lis.Columns.Add("Stock", 50, HorizontalAlignment.Center);  //2
            lis.Columns.Add("precio Vnta", 60, HorizontalAlignment.Center);  //3
            lis.Columns.Add("precio compra", 0, HorizontalAlignment.Right);  //4 ver opcion para anñador pr_compra
            lis.Columns.Add("estado prod", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Und", 40, HorizontalAlignment.Left);
        }

        //private void Agregar_Productos_alCarrito(string xidprod, string xnomprod, double xcant,  double xprecio, double ximporte,  string xund, string xtipoProd, double xutili_unit, String xafecto, string xtipo, string cod_afecto)
        //{
        //    try
        //    {

        //        if (lsv_Det.Items.Count == 0)
        //        {
        //            ListViewItem item = new ListViewItem();

        //            item = lsv_Det.Items.Add(xidprod);
        //            item.SubItems.Add(xnomprod.Trim());

        //            item.SubItems.Add(xcant.ToString());
        //            //item.SubItems.Add(xcant.ToString());

        //            item.SubItems.Add(xprecio.ToString("###0.00"));//00
        //            item.SubItems.Add(ximporte.ToString("###0.00"));//00

        //            item.SubItems.Add(xtipoProd.ToString());
        //            item.SubItems.Add(xund.ToString());

        //            item.SubItems.Add(xutili_unit.ToString("###0.00"));
        //            item.SubItems.Add(xutili_unit.ToString("###0.00"));//importe de utilidad uni * cant = importUtilida
        //            //F.E
        //            item.SubItems.Add(xafecto);
        //            item.SubItems.Add("0.00");
        //            item.SubItems.Add("0.00");
        //            item.SubItems.Add("0.00");
        //            item.SubItems.Add(xtipo);

        //            item.SubItems.Add(cod_afecto);

        //            //item.SubItems.Add(xcantMetro.ToString());
        //            //item.SubItems.Add(ximporteMetros.ToString("###0.00"));//00
        //            Calcular();
        //            //lsv_Det.Focus();
        //            lsv_Det.Items[0].Selected = true;
        //            pnl_sinProd.Visible = false;

        //            // ✅ Agregado → verificar promociones después de calcular
        //            VerificarPromocionesEnCarrito();
        //        }
        //        else
        //        {
        //            //validar de que el producvto no se ingrese dos veces
        //            for (int i = 0; i < lsv_Det.Items.Count; i++)
        //            {
        //                if (lsv_Det.Items[i].Text.Trim() == xidprod.Trim())
        //                {
        //                    MessageBox.Show("El Producto ya fue Agregado al Carrito de Compras", "ADveretencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                    return;
        //                }
        //            }

        //            //lo añadimos:
        //            ListViewItem item = new ListViewItem();
        //            item = lsv_Det.Items.Add(xidprod);
        //            item.SubItems.Add(xnomprod.Trim());
        //            item.SubItems.Add(xcant.ToString());

        //            //item.SubItems.Add(xcantMetro.ToString());
        //            item.SubItems.Add(xprecio.ToString("###0.00"));//
        //            item.SubItems.Add(ximporte.ToString("###0.00"));
        //            item.SubItems.Add(xtipoProd.ToString());
        //            item.SubItems.Add(xund.ToString());
        //            item.SubItems.Add(xutili_unit.ToString("###0.00"));
        //            item.SubItems.Add(xutili_unit.ToString("###0.00"));
        //            item.SubItems.Add(xafecto);
        //            item.SubItems.Add("0.00");
        //            item.SubItems.Add("0.00");
        //            item.SubItems.Add("0.00");
        //            item.SubItems.Add(xtipo);
        //            item.SubItems.Add(cod_afecto);

        //            Calcular();
        //            //lsv_Det.Focus();
        //            lsv_Det.Items[0].Selected = true;
        //            // ✅ Agregado → verificar promociones después de calcular
        //            VerificarPromocionesEnCarrito();

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}


        private void Agregar_Productos_alCarrito(string xidprod, string xnomprod, double xcant, double xprecio, double ximporte,string xund, string xtipoProd, double xutili_unit, string xafecto, string xtipo, string cod_afecto, double precioOriginal)
        {
            xidprod = xidprod.Trim().ToUpper();

            //foreach (ListViewItem item in lsv_Det.Items)
            //{
            //    if (item.SubItems[0].Text.Trim().ToUpper() == xidprod)
            //    {
            //        MessageBox.Show("El Producto ya fue Agregado al Carrito de Compras", "Advertencia",
            //            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return;
            //    }
            //}

            ListViewItem newItem = lsv_Det.Items.Add(xidprod); // ✅ Guarda el ID en la columna 0         
            newItem.SubItems.Add(xnomprod.Trim());
            newItem.SubItems.Add(xcant.ToString());
            newItem.SubItems.Add(xprecio.ToString("###0.00"));
            newItem.SubItems.Add(ximporte.ToString("###0.00"));
            newItem.SubItems.Add(xtipoProd);
            newItem.SubItems.Add(xund);
            newItem.SubItems.Add(xutili_unit.ToString("###0.00"));
            newItem.SubItems.Add(xutili_unit.ToString("###0.00"));
            newItem.SubItems.Add(xafecto);
            newItem.SubItems.Add("0.00");
            newItem.SubItems.Add("0.00");
            newItem.SubItems.Add("0.00");
            newItem.SubItems.Add(xtipo);
            newItem.SubItems.Add(cod_afecto);
            newItem.SubItems.Add(""); // 15 Promo
            //newItem.SubItems.Add(precioOriginal.ToString("###0.00")); // precio original

            newItem.Tag = precioOriginal; // 👈 Aquí guardas el precio original ✅ Guardamos el precio original de forma segura
            //Calcular();
            lsv_Det.Items[0].Selected = true;
            RecalcularTodo(); //metodo original para aplicar promociones, contemplar que cuando se pase un producto en kg, mt, 
            //no entre a este metodo y solo para las und enteras.
            Calcular();
           
        }
        private void RecalcularTodo()
        {
            promocionesAplicadas.Clear();
            RestaurarSoloLíneasNormales(); // No destruye las líneas que ya tienen promo
            VerificarPromocionesEnCarrito();  // Esta función ya llama internamente a Calcular()
        }


        private void VerificarPromocionesEnCarrito()
        {
            try
            {
                RN_Promocion objPromo = new RN_Promocion();
                DataTable promocionesActivas = objPromo.RN_Buscar_Promociones_Activas(null);

                //Limpia y revierte antes de evaluar nuevas promos
                promocionesAplicadas.Clear();
                //RestaurarPreciosOriginales();
                RestaurarSoloLíneasNormales(); // ✅ Solo restaura líneas sin promoción



                if (promocionesActivas == null || promocionesActivas.Rows.Count == 0)
                {
                    lblPromocionesAplicadas.Text = "Sin promociones aplicadas.";
                    return;
                }

                List<string> promosAplicadasTexto = new List<string>();

                foreach (DataRow promo in promocionesActivas.Rows)
                {
                    int idPromocion = Convert.ToInt32(promo["IdPromocion"]);
                    string nombrePromocion = promo["Nombre"].ToString();
                    string tipoPromocion = promo["Tipo"].ToString();

                    DataTable detallePromo = objPromo.RN_BuscarDetallePromocion(idPromocion);
                    if (detallePromo == null || detallePromo.Rows.Count == 0)
                        continue;

                    // ✅ CASO 1: Promoción de tipo DESCUENTO_CANTIDAD
                    if (detallePromo.Rows.Count == 1 && tipoPromocion == "DESCUENTO_CANTIDAD")
                    {
                        DataRow fila = detallePromo.Rows[0];
                        string idProducto = fila["IdProducto"].ToString().Trim();
                        int cantidadRequerida = Convert.ToInt32(fila["Cantidad"]);
                        //double cantidadRequerida = Convert.ToInt32(fila["Cantidad"]);
                        double precioEspecial = Convert.ToDouble(fila["PrecioUnitario"]);
                        int cantidadEnCarrito = ContarProductoEnCarrito(idProducto);
                        double precioOriginal = ObtenerPrecioProductoEnCarrito(idProducto);

                        if (cantidadEnCarrito >= cantidadRequerida && precioOriginal > precioEspecial)
                        {
                            double descuentoLinea = (precioOriginal - precioEspecial) * cantidadRequerida;

                            if (!promocionesAplicadas.Any(p => p.IdPromocion == idPromocion))
                            {
                                promocionesAplicadas.Add(new EN_Promocion_Venta
                                {
                                    IdPromocion = idPromocion,
                                    Descuento = descuentoLinea
                                });

                                promosAplicadasTexto.Add($"{nombrePromocion}: descuento S/ {descuentoLinea:0.00}");
                                AplicarPrecioEspecialEnListView(idProducto, precioEspecial, cantidadRequerida);
                                Calcular(); // 🔁 fuerza el recálculo completo con los precios actualizados

                            }
                        }

                        continue; // saltar al siguiente ciclo
                    }



                    // ✅ CASO 2: Promoción tipo PACK (múltiples productos con lote)
                    bool cumplePack = true;
                    int lotesPosibles = int.MaxValue;

                    foreach (DataRow detalle in detallePromo.Rows)
                    {
                        string idProducto = detalle["IdProducto"].ToString().Trim();
                        int cantidadRequerida = Convert.ToInt32(detalle["Cantidad"]);
                        //double cantidadRequerida = Convert.ToDouble(detalle["Cantidad"]);
                        int cantidadEnCarrito = ContarProductoEnCarrito(idProducto);

                        if (cantidadEnCarrito < cantidadRequerida)
                        {
                            cumplePack = false;
                            break;
                        }

                        //int lotesPorProducto = cantidadEnCarrito / cantidadRequerida;
                        int lotesPorProducto = cantidadEnCarrito / cantidadRequerida;
                        lotesPosibles =  Math.Min(lotesPosibles, lotesPorProducto);
                    }

                    if (cumplePack && lotesPosibles > 0)
                    {
                        for (int l = 0; l < lotesPosibles; l++)
                        {
                            double descuento = 0;

                            foreach (DataRow fila in detallePromo.Rows)
                            {
                                string idProducto = fila["IdProducto"].ToString().Trim();
                                int cantidadRequerida = Convert.ToInt32(fila["Cantidad"]);
                                double precioEspecial = Convert.ToDouble(fila["PrecioUnitario"]);
                                double precioOriginal = ObtenerPrecioProductoEnCarrito(idProducto);

                                if (precioOriginal > precioEspecial)
                                {
                                    descuento += (precioOriginal - precioEspecial) * cantidadRequerida;

                                    // ✅ Aplica la promo a esta parte
                                    AplicarPrecioEspecialEnListView(idProducto, precioEspecial, cantidadRequerida,"PACK");
                                }
                            }

                            if (descuento > 0)
                            {
                                promocionesAplicadas.Add(new EN_Promocion_Venta
                                {
                                    IdPromocion = idPromocion,
                                    Descuento = descuento
                                });

                                promosAplicadasTexto.Add($"{nombrePromocion} (PACK): descuento S/ {descuento:0.00}");
                            }
                        }

                        Calcular(); // ✅ aplica solo una vez después de todos los lotes
                    }

                }

                if (promosAplicadasTexto.Count > 0)
                {
                    lblPromocionesAplicadas.Text = "Promociones aplicadas:\n" + string.Join("\n", promosAplicadasTexto);
                }
                else
                {
                    lblPromocionesAplicadas.Text = "Sin promociones aplicadas.";
                }
            }
            catch (Exception ex)
            {
                lblPromocionesAplicadas.Text = "Error al verificar promociones.";
                MessageBox.Show("❌ Error al verificar promociones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double ObtenerPrecioProductoOriginal(ListViewItem item)
        {
            if (item.Tag != null && double.TryParse(item.Tag.ToString(), out double precioOriginal))
            {
                return precioOriginal;
            }
            return 0;
        }

        private void AplicarPrecioEspecialEnListView(string idProducto, double precioEspecial, int cantidadPromo, string tipoPromo = "PROMO")
        {
            for (int i = 0; i < lsv_Det.Items.Count; i++)
            {
                var item = lsv_Det.Items[i];

                if (item.SubItems[0].Text.Trim().Equals(idProducto.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    int cantidadActual = int.Parse(item.SubItems[2].Text);
                    double precioOriginal = ObtenerPrecioProductoOriginal(item);

                    if (cantidadActual < cantidadPromo) continue;

                    int lotes = cantidadActual / cantidadPromo;
                    int restante = cantidadActual % cantidadPromo;

                    // Eliminar línea actual antes de dividir
                    lsv_Det.Items.RemoveAt(i);
                    i--; // ajustamos índice por eliminación

                    // Agregar líneas por cada lote de promoción
                    for (int j = 0; j < lotes; j++)
                    {
                        ListViewItem promoItem = (ListViewItem)item.Clone();
                        promoItem.SubItems[2].Text = cantidadPromo.ToString();
                        promoItem.SubItems[3].Text = precioEspecial.ToString("###0.00");
                        promoItem.SubItems[4].Text = (precioEspecial * cantidadPromo).ToString("###0.00");
                        item.SubItems[15].Text = tipoPromo == "PACK" ? "✔ PACK" : "✔ PROMO";
                        promoItem.BackColor = Color.LightYellow;
                        //promoItem.Font = new Font(lsv_Det.Font, FontStyle.Bold);
                        promoItem.Tag = item.Tag;

                        lsv_Det.Items.Add(promoItem);
                    }

                    // Agregar línea restante con precio original si sobra
                    if (restante > 0)
                    {
                        ListViewItem resto = (ListViewItem)item.Clone();
                        resto.SubItems[2].Text = restante.ToString();
                        resto.SubItems[3].Text = precioOriginal.ToString("###0.00");
                        resto.SubItems[4].Text = (precioOriginal * restante).ToString("###0.00");
                        resto.SubItems[15].Text = "";
                        resto.BackColor = Color.White;
                        resto.Font = new Font(lsv_Det.Font, FontStyle.Regular);
                        resto.Tag = item.Tag;

                        lsv_Det.Items.Add(resto);
                    }

                    break; // solo aplicamos sobre la primera coincidencia
                }
            }
        }

        //private void AplicarPrecioEspecialEnListView(string idProducto, double precioEspecial, int cantidadPromo)
        //{
        //    foreach (ListViewItem item in lsv_Det.Items)
        //    {
        //        if (item.SubItems[0].Text.Trim().Equals(idProducto.Trim(), StringComparison.OrdinalIgnoreCase))
        //        {

        //            int cantidadActual = int.Parse(item.SubItems[2].Text);

        //            //agregando para la validacion de porducto agregado a promo exter

        //            double precioOriginal = ObtenerPrecioProductoOriginal(item);
        //            // Solo aplicar si la cantidad del carrito cumple o supera
        //            if (cantidadActual >= cantidadPromo)
        //            {
        //                int cantidadExtra = cantidadActual - cantidadPromo;

        //                //Linea 1: solo la cantidad en promo 
        //                item.SubItems[2].Text = cantidadPromo.ToString(); //CANT
        //                item.SubItems[3].Text = precioEspecial.ToString("###0.00"); //PR.UNIT
        //                item.SubItems[4].Text = (cantidadPromo * precioEspecial).ToString("###0.00"); //IMMPO TOTAL comeente el precioOrigina
        //                item.SubItems[15].Text = "✔ PROMO"; // Marca de promoción
        //                item.BackColor = Color.LightYellow;
        //                item.Font = new Font(lsv_Det.Font, FontStyle.Bold);

        //                if (cantidadExtra > 0)
        //                {
        //                    //Linea 2 : cantidad restante a precio Original
        //                    ListViewItem extra = (ListViewItem)item.Clone();
        //                    extra.Tag = item.Tag; // 👈 Asegura que el precio original se conserve
        //                    extra.SubItems[2].Text = cantidadExtra.ToString(); //CANT
        //                    extra.SubItems[3].Text = precioOriginal.ToString("###0.00"); //PR.UNIT
        //                    extra.SubItems[4].Text = (cantidadExtra * precioOriginal).ToString("###0.00"); //IMPORTE TOTAL
        //                    extra.SubItems[15].Text = ""; //sin promo
        //                    extra.BackColor = Color.White;
        //                    extra.Font = new Font(lsv_Det.Font, FontStyle.Regular);
        //                    extra.Tag = item.Tag; // Mantiene el precio original

        //                    lsv_Det.Items.Add(extra);

        //                }

        //                break; // solo una coincidencia debe procesarse


        //                //item.SubItems[3].Text = precioEspecial.ToString("###0.00"); // PR.UNIT
        //                //double nuevoImporte = precioEspecial * cantidadActual;
        //                //item.SubItems[4].Text = nuevoImporte.ToString("###0.00"); // IMP.TOTAL
        //                //item.SubItems[14].Text = "✔ PROMO"; //se agrego solo informativo

        //            }
        //        }
        //    }
        //}

        private double CalcularDescuentoPromocion(int idPromocion)
        {
            double descuentoTotal = 0;

            RN_Promocion objPromo = new RN_Promocion();
            DataTable detallePromo = objPromo.RN_BuscarDetallePromocion(idPromocion);

            if (detallePromo == null || detallePromo.Rows.Count == 0)
            {
                MessageBox.Show($"⚠ PROMO {idPromocion} no tiene detalle en la BD.");
                return 0;
            }

            foreach (DataRow fila in detallePromo.Rows)
            {
                string idProducto = fila["IdProducto"].ToString().Trim().ToUpper();
                int cantidadRequerida = Convert.ToInt32(fila["Cantidad"]);
                double precioEspecial = Convert.ToDouble(fila["PrecioUnitario"]);
                int cantidadEnCarrito = ContarProductoEnCarrito(idProducto);
                double precioOriginal = ObtenerPrecioProductoEnCarrito(idProducto);

                MessageBox.Show(
                    $"✅ PROMO {idPromocion}\n" +
                    $"Producto BD: {idProducto}\n" +
                    $"Cantidad Requerida: {cantidadRequerida}\n" +
                    $"Cantidad en Carrito: {cantidadEnCarrito}\n" +
                    $"Precio Original: {precioOriginal}\n" +
                    $"Precio Especial: {precioEspecial}"
                );

                if (cantidadEnCarrito >= cantidadRequerida)
                {
                    if (precioOriginal > precioEspecial)
                    {
                        double descuentoLinea = (precioOriginal - precioEspecial) * cantidadRequerida;
                        descuentoTotal += descuentoLinea;
                        MessageBox.Show($"💥 Descuento aplicado a {idProducto}: {descuentoLinea:C2}");
                    }
                    else
                    {
                        MessageBox.Show($"⚠ Precio original no es mayor al especial en {idProducto}");
                    }
                }
                else
                {
                    MessageBox.Show($"⚠ No cumple cantidad en carrito para {idProducto}");
                }
            }

            if (descuentoTotal == 0)
            {
                MessageBox.Show($"❌ PROMO {idPromocion} → Descuento total calculado: 0");
            }

            return descuentoTotal;
        }

        private int ContarProductoEnCarrito(string idProducto)
        {
            int total = 0;
            string idProductoNormalizado = idProducto.Trim().ToUpper();

            foreach (ListViewItem item in lsv_Det.Items)
            {
                string idCarrito = item.SubItems[0].Text.Trim().ToUpper();

                if (string.Equals(idCarrito, idProductoNormalizado, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (double.TryParse(item.SubItems[2].Text, out double cantidad))
                    {
                        total += (int)cantidad;
                    }
                }
            }

            return total;
        }

        private void RestaurarPreciosOriginales()
        {
            foreach (ListViewItem item in lsv_Det.Items)
            {
                // Recuperar precio original desde el Tag
                double precioOriginal = ObtenerPrecioProductoOriginal(item);
                if (precioOriginal <= 0) continue; // seguridad

                // Restaurar cantidad
                int cantidad = int.Parse(item.SubItems[2].Text);

                // Actualizar datos
                item.SubItems[3].Text = precioOriginal.ToString("###0.00"); // PR.UNIT
                item.SubItems[4].Text = (precioOriginal * cantidad).ToString("###0.00"); // IMP.TOTAL
                item.SubItems[15].Text = ""; // Borrar marca de promo

                // Restaurar estilos visuales
                item.BackColor = Color.White;
                item.Font = new Font(lsv_Det.Font, FontStyle.Regular);


                //if (item.SubItems.Count > 15 && double.TryParse(item.SubItems[15].Text, out double precioOriginal))
                //{
                //    double cantidad = Convert.ToDouble(item.SubItems[2].Text);
                //    item.SubItems[3].Text = precioOriginal.ToString("###0.00"); // PR.UNIT
                //    item.SubItems[4].Text = (precioOriginal * cantidad).ToString("###0.00"); // IMP.TOTAL
                //    item.SubItems[14].Text = ""; //limpia la marca
                //}
            }
        }
        private double ObtenerPrecioProductoEnCarrito(string idProducto)
        {
            string idProductoNormalizado = idProducto.Trim().ToUpper();

            foreach (ListViewItem item in lsv_Det.Items)
            {
                string idCarrito = item.SubItems[0].Text.Trim().ToUpper();

                if (string.Equals(idCarrito, idProductoNormalizado, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (item.Tag != null && double.TryParse(item.Tag.ToString(), out double precioOriginal))
                    {
                        return precioOriginal;
                    }
                }
            }
            return 0;
        }
        private void RestaurarSoloLíneasNormales()
        {
            foreach (ListViewItem item in lsv_Det.Items)
            {
                if (string.IsNullOrWhiteSpace(item.SubItems[15].Text)) // Solo las líneas sin promo
                {
                    double precioOriginal = ObtenerPrecioProductoOriginal(item);
                    if (precioOriginal <= 0) continue;

                   // int cantidad = int.Parse(item.SubItems[2].Text);//para market
                    //probando
                    double cantidad = Convert.ToDouble(item.SubItems[2].Text);
                    //double cantidad = int.Parse(item.SubItems[2].Text); //para tela

                    item.SubItems[3].Text = precioOriginal.ToString("###0.00");
                    item.SubItems[4].Text = (precioOriginal * cantidad).ToString("###0.00");
                    item.BackColor = Color.White;
                    item.Font = new Font(lsv_Det.Font, FontStyle.Regular);
                }
            }
        }


        //private double ObtenerPrecioProductoEnCarrito(string idProducto)
        //{
        //    string idProductoNormalizado = idProducto.Trim().ToUpper();

        //    foreach (ListViewItem item in lsv_Det.Items)
        //    {
        //        string idCarrito = item.SubItems[0].Text.Trim().ToUpper();

        //        if (string.Equals(idCarrito, idProductoNormalizado, StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            if (item.SubItems.Count > 15 && double.TryParse(item.SubItems[15].Text, out double precioOriginal))
        //            {
        //                return precioOriginal;
        //            }
        //        }
        //    }
        //    return 0;
        //}




        /*
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
        }*/


        //private void buscar_Productos(string valor)
        //{
        //    RN_Productos obj = new RN_Productos();
        //    DataTable data = new DataTable();
        //    Frm_Add_Cantidad cant = new Frm_Add_Cantidad();
        //    Frm_Filtro fil = new Frm_Filtro();

        //    string xidprod = "";
        //    string xproducto = "";
        //    double cantidad = 1;
        //    double xstock = 0;
        //    double PreVenta = 0;
        //    double PreCompra = 0;
        //    double UtiliUnitaria = 0;
        //    string und;
        //    string tipoAfectacion;
        //    string cod_afectox;

        //    try
        //    {
        //        data = obj.RN_Buscar_Productos(valor);
        //        if (data.Rows.Count == 1)
        //        {
        //            xidprod = Convert.ToString(data.Rows[0]["Id_Pro"]).Trim().ToUpper();  // ✅ limpieza aquí
        //            xproducto = Convert.ToString(data.Rows[0]["Descripcion_Larga"]);
        //            xstock = Convert.ToDouble(data.Rows[0]["Stock_Actual"]);
        //            bool controlaStock = Convert.ToBoolean(data.Rows[0]["ControlaStock"]);
        //            PreCompra = Convert.ToDouble(data.Rows[0]["Pre_CompraS"]);
        //            PreVenta = Convert.ToDouble(data.Rows[0]["Pre_vntaxMenor"]);
        //            und = Convert.ToString(data.Rows[0]["UndMedida"]);
        //            tipoAfectacion = Convert.ToString(data.Rows[0]["Tipo_Afectacion"]);
        //            cod_afectox = Convert.ToString(data.Rows[0]["CodTipo_Afectacion"]);
        //            UtiliUnitaria = PreVenta - PreCompra;

        //            if (controlaStock)
        //            {
        //                if (xstock <= 0)
        //                {
        //                    MessageBox.Show("El producto no tiene stock disponible", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                    return;
        //                }

        //                fil.Show();
        //                cant.Lbl_stockActual.Text = xstock.ToString();
        //                cant.lbl_Prod.Text = xproducto;
        //                cant.ShowDialog();
        //                fil.Hide();

        //                if (cant.Tag.ToString() == "A")
        //                {
        //                    cantidad = Convert.ToDouble(cant.txt_cant.Text);
        //                    Agregar_Productos_alCarrito(xidprod, xproducto, cantidad, PreVenta, PreVenta, und, "Producto", UtiliUnitaria, tipoAfectacion, "NIU", cod_afectox);
        //                }
        //            }
        //            else
        //            {
        //                fil.Show();
        //                cant.lbl_Prod.Text = xproducto;
        //                cant.ShowDialog();
        //                fil.Hide();

        //                if (cant.Tag.ToString() == "A")
        //                {
        //                    cantidad = Convert.ToDouble(cant.txt_cant.Text);
        //                    Agregar_Productos_alCarrito(xidprod, xproducto, cantidad, PreVenta, PreVenta, und, "Producto", UtiliUnitaria, tipoAfectacion, "NIU", cod_afectox);
        //                }
        //            }
        //        }
        //        else if (data.Rows.Count > 1)
        //        {
        //            Llenar_ListView_Prod_aVender(data, "Activo");
        //        }
        //        else
        //        {
        //            MessageBox.Show("El Producto no Existe!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            return;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    txtBusquedaProd.Text = "";
        //    txtBusquedaProd.Focus();
        //    txtBusquedaProd.Refresh();
        //}

        private void buscar_Productos(string valor)
        {
            RN_Productos obj = new RN_Productos();
            DataTable data = obj.RN_Buscar_Productos(valor);

            if (data.Rows.Count == 1)
            {
                string xidprod = Convert.ToString(data.Rows[0]["Id_Pro"]).Trim().ToUpper();
                string xproducto = Convert.ToString(data.Rows[0]["Descripcion_Larga"]);
                double xstock = Convert.ToDouble(data.Rows[0]["Stock_Actual"]);
                bool controlaStock = Convert.ToBoolean(data.Rows[0]["ControlaStock"]);
                double PreCompra = Convert.ToDouble(data.Rows[0]["Pre_CompraS"]);
                double PreVenta = Convert.ToDouble(data.Rows[0]["Pre_vntaxMenor"]);
                double PreVentaOriginal = Convert.ToDouble(data.Rows[0]["Pre_vntaLista"]); // ⚡ nuevo campo
                string und = Convert.ToString(data.Rows[0]["UndMedida"]);
                string tipoAfectacion = Convert.ToString(data.Rows[0]["Tipo_Afectacion"]);
                string cod_afectox = Convert.ToString(data.Rows[0]["CodTipo_Afectacion"]);
                double UtiliUnitaria = PreVenta - PreCompra;

                double cantidad = 1;
                Frm_Add_Cantidad cant = new Frm_Add_Cantidad();
                Frm_Filtro fil = new Frm_Filtro();

                if (controlaStock && xstock <= 0)
                {
                    MessageBox.Show("El producto no tiene stock disponible", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                fil.Show();
                cant.lbl_Prod.Text = xproducto;
                if (controlaStock)
                    cant.Lbl_stockActual.Text = xstock.ToString();
                cant.ShowDialog();
                fil.Hide();

                if (cant.Tag?.ToString() == "A")
                {
                    cantidad = Convert.ToDouble(cant.txt_cant.Text);
                    Agregar_Productos_alCarrito(xidprod, xproducto, cantidad, PreVenta, PreVenta, und, "Producto", UtiliUnitaria, tipoAfectacion, "NIU", cod_afectox, PreVentaOriginal);
                }
            }
            else if (data.Rows.Count > 1)
            {
                Llenar_ListView_Prod_aVender(data, "Activo");
            }
            else
            {
                MessageBox.Show("El Producto no Existe!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            txtBusquedaProd.Text = "";
            txtBusquedaProd.Focus();
        }


        private void Llenar_ListView_Prod_aVender(DataTable data, string tipo)
        {
            lsv_Pdet.Items.Clear();
            double stockActual = 0;


            for (int i = 0; i < data.Rows.Count; i++)
            {


                DataRow dr = data.Rows[i];

                stockActual = Convert.ToDouble(dr["Stock_Actual"]);

                if (tipo == "todo")
                {
                    if (stockActual > 0)
                    {
                        ListViewItem lis = new ListViewItem(dr[0].ToString());
                        lis.SubItems.Add(dr["Descripcion_Larga"].ToString());
                        lis.SubItems.Add(stockActual.ToString());
                        double preventa = Convert.ToDouble(dr["Pre_vntaxMenor"]);
                        lis.SubItems.Add(preventa.ToString("###0.00"));
                        double precompra = Convert.ToDouble(dr["Pre_CompraS"]);
                        lis.SubItems.Add(precompra.ToString("###0.00"));
                        lis.SubItems.Add(dr["Estado_Pro"].ToString());
                        lis.SubItems.Add(dr["UndMedida"].ToString());

                        lsv_Pdet.Items.Add(lis);
                    }

                }

                else
                {

                    ListViewItem lis = new ListViewItem(dr[0].ToString());
                    lis.SubItems.Add(dr["Descripcion_Larga"].ToString());
                    lis.SubItems.Add(stockActual.ToString());
                    double preventa = Convert.ToDouble(dr["Pre_vntaxMenor"]);
                    lis.SubItems.Add(preventa.ToString("###0.00"));
                    double precompra = Convert.ToDouble(dr["Pre_CompraS"]);
                    lis.SubItems.Add(precompra.ToString("###0.00"));
                    lis.SubItems.Add(dr["Estado_Pro"].ToString());
                    lis.SubItems.Add(dr["UndMedida"].ToString());

                    lsv_Pdet.Items.Add(lis);
                }
            }
            lsv_Pdet.Visible = true;

        }

        private void Cargar_todos_Productos_aVender()
        {
            RN_Productos obj = new RN_Productos();
            DataTable data = new DataTable();

            data = obj.RN_Mostrar_Todos_Productos();

            if (data.Rows.Count > 0)
            {
                Llenar_ListView_Prod_aVender(data, "todo");
                if (lsv_Pdet.Items.Count > 0)
                {
                    lsv_Pdet.Items[0].Selected = true;
                    lsv_Pdet.Focus();
                }
            }
            else
            {
                lsv_Pdet.Visible = false;
                lsv_Pdet.Items.Clear();
            }

        }

        private void lbl_buscarProd_Click(object sender, EventArgs e)
        {

            if (txtBusquedaProd.Text.Trim().Length == 0)
            {
                Cargar_todos_Productos_aVender();
            }


            else
            {
                buscar_Productos(txtBusquedaProd.Text);
            }


        }

        private void txt_buscarProd_OnValueChanged(object sender, EventArgs e)
        {
            if (txtBusquedaProd.Text.Trim().Length > 2)
            {
                buscar_Productos(txtBusquedaProd.Text);
            }
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

        private void txt_buscarP_TextChanged(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_ListadoProd_Compras xpro = new Frm_ListadoProd_Compras();
            fil.Show();

        }


        //private void btn_Nuevo_buscarProd_Click(object sender, EventArgs e)
        //{


        //    Frm_Filtro fil = new Frm_Filtro();
        //    Frm_ListadoProd_Compras xpro = new Frm_ListadoProd_Compras();

        //    fil.Show();
        //    Frm_ListadoProd_Compras.TipoVenta = "venta";
        //    xpro.chk_cotiza.Checked = false;
        //    xpro.ShowDialog();

        //    fil.Hide();

        //    if (xpro.Tag.ToString() == "A")
        //    {
        //        string _idprod;
        //        string _nomprod;
        //        double _cant = 0;
        //        double _precio = 0;
        //        double _importe = 0;
        //        string _und;
        //        string _tipoProd;
        //        Double _Utili_Unit;

        //        string tipoAfectacion;
        //        string cod_afectox;

        //        decimal preventLista = 0;

        //        if (xpro.lsv_Ped.Items.Count > 0)
        //        {
        //            for (int i = 0; i < xpro.lsv_Ped.Items.Count; i++)
        //            {
        //                var item = xpro.lsv_Ped.Items[i];
        //                _idprod = item.SubItems[0].Text;
        //                _nomprod = item.SubItems[1].Text;
        //                _cant = Convert.ToDouble(item.SubItems[3].Text);
        //                _precio = Convert.ToDouble(item.SubItems[4].Text);
        //                _importe = Convert.ToDouble(item.SubItems[5].Text);
        //                _und = item.SubItems[2].Text;
        //                _tipoProd = item.SubItems[8].Text;
        //                _Utili_Unit = Convert.ToDouble(item.SubItems[6].Text);

        //                Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe, _und, _tipoProd, _Utili_Unit,_tipoProd /*"Gravado"*/, "NIU","pr");
        //            }
        //        }
        //        else
        //        {
        //            //para agregar de uno en Uno:
        //            _idprod = xpro.lbl_IdProd.Text;
        //            _nomprod = xpro.lbl_NomProd.Text;
        //            _cant = Convert.ToDouble(xpro.lbl_Cant.Text);
        //            _precio = Convert.ToDouble(xpro.lbl_Pre_Unit.Text);
        //            _importe = Convert.ToDouble(xpro.lbl_Pre_Unit.Text);
        //            _und = xpro.lbl_Und.Text;
        //            _tipoProd = xpro.lbl_TipoProd.Text;
        //            _Utili_Unit = Convert.ToDouble(xpro.lbl_Uti_Unit.Text);

        //            Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe, _und, _tipoProd, _Utili_Unit, "Gravado", "NIU","pr");
        //        }

        //    }

        //}


        private void Calcular()
        {
            double xtotal = 0;
            double xTotalGanancia = 0;
            double subtotal_sinIgv = 0;
            double xigv_total = 0;
            double totalExonerado = 0;
            double totalGravado = 0;

            foreach (ListViewItem item in lsv_Det.Items)
            {
                string tipoAfecto = item.SubItems[9].Text; // "Gravado" o "Exonerado"
                double cantidad = Convert.ToDouble(item.SubItems[2].Text);
                double precioUnitario = Convert.ToDouble(item.SubItems[3].Text);
                double utilidadUnidad = Convert.ToDouble(item.SubItems[7].Text);

                double importe = cantidad * precioUnitario;
                item.SubItems[4].Text = importe.ToString("###0.00"); // Importe Total

                xtotal += importe;
                double utilidadTotal = utilidadUnidad * cantidad;
                xTotalGanancia += utilidadTotal;

                if (tipoAfecto == "Exonerado")
                {
                    // Precios sin IGV (porque está exonerado)
                    item.SubItems[10].Text = precioUnitario.ToString("###0.00"); // Precio sin IGV
                    item.SubItems[11].Text = importe.ToString("###0.00");        // Subtotal sin IGV
                    item.SubItems[12].Text = "0.00";                              // IGV
                    totalExonerado += importe;
                }
                else if (tipoAfecto == "Gravado")
                {
                    double precioSinIGV = precioUnitario / 1.18;
                    double subtotalLinea = precioSinIGV * cantidad;
                    double igvLinea = subtotalLinea * 0.18;

                    subtotal_sinIgv += subtotalLinea;
                    xigv_total += igvLinea;
                    totalGravado += importe;

                    item.SubItems[10].Text = precioSinIGV.ToString("###0.00");
                    item.SubItems[11].Text = subtotalLinea.ToString("###0.00");
                    item.SubItems[12].Text = igvLinea.ToString("###0.00");
                }
            }

            // Subtotal (solo productos gravados)
            lbl_subtotal_sinIgv.Text = subtotal_sinIgv.ToString("###0.00");
            double xsubtotal = subtotal_sinIgv + totalExonerado;

            // Mostrar totales
            lbl_subtotal.Text = xsubtotal.ToString("###0.00");
            lbl_igv.Text = xigv_total.ToString("###0.00");
            lbl_totalGanancia.Text = xTotalGanancia.ToString("###0.00");
            lbl_TotalItem.Text = lsv_Det.Items.Count.ToString();
            lbl_TotalExonerado.Text = totalExonerado.ToString("###0.00");

            // Total con promoción
            //double descuentoTotal = promocionesAplicadas?.Sum(p => p.Descuento) ?? 0;
            //if (descuentoTotal > xtotal) descuentoTotal = xtotal;

            //double totalConDescuento = xtotal - descuentoTotal;

            lbl_TotalPagar.Text = xtotal.ToString("###0.00");
            tx_efectivo.Text = xtotal.ToString("###0.00");
            lbl_son.Text = Numalet.ToString(lbl_TotalPagar.Text);

            lbl_igvgravado.Text = xigv_total.ToString("###0.00");
            lbl_totalGravado.Text = (subtotal_sinIgv + xigv_total).ToString("###0.00");

            if (!actualizado) ActualizarCong();
        }



        //private void Calcular()
        //{

        //    double xtotal = 0;
        //    double xcant = 0;

        //    double xprecio = 0;
        //    double ximporte = 0;
        //    double xsubtotal = 0;
        //    double xigv = 0;
        //    double xuti_unit = 0;
        //    double ximport_Uti = 0;
        //    double xTotalGanancia = 0;

        //    //*****Para FE.******

        //    double igvProd = 0;
        //    double subtotal_sinIgv = 0;
        //    double xsubtotal_sinIgv = 0;
        //    double preUnit_sinIgv = 0;
        //    double xigv_total = 0;

        //    double xcantMetro = 0;
        //    double xprecioMetro = 0;
        //    double ximporteMetro = 0;
        //    double ximport_UtiMetro = 0;
        //    string xund = "";

        //    //para detraccion: 
        //    double detraccion = 0;
        //    double tasaDetraccion = 0.04;

        //    string xafecto = "";

        //    //probando para tipos de medida:
        //    string xpaquete = "";
        //    string klg = "";

        //    // Variables para acumular los totales de productos gravados y exonerados
        //    double subtotalGravado = 0;
        //    double igvGravado = 0;
        //    double totalGravado = 0;
        //    double subtotalExonerado = 0;
        //    double totalExonerado = 0;

        //    for (int i = 0; i < lsv_Det.Items.Count; i++)
        //    {
        //        xund = lsv_Det.Items[i].SubItems[6].Text;

        //        //xafecto = lsv_Det.Items[i].SubItems[9].Text;
        //        if (lsv_Det.Items[i].SubItems[9].Text == "Exonerado")
        //        {
        //            // Cuando el producto es exonerado

        //            // Cálculos para productos exonerados: 
        //            xcant = Convert.ToDouble(lsv_Det.Items[i].SubItems[2].Text);
        //            xprecio = Convert.ToDouble(lsv_Det.Items[i].SubItems[3].Text);

        //            // Cálculo del importe para productos exonerados (sin IGV)
        //            ximporte = xprecio * xcant;
        //            lsv_Det.Items[i].SubItems[4].Text = ximporte.ToString("###0.00");

        //            // Utilidad de productos exonerados
        //            xuti_unit = Convert.ToDouble(lsv_Det.Items[i].SubItems[7].Text);
        //            ximport_Uti = xuti_unit * xcant;

        //            // Total general para productos exonerados (sin IGV)
        //            xtotal += ximporte;

        //            // Total de ganancia para productos exonerados
        //            xTotalGanancia += ximport_Uti;

        //            // Subtotal sin IGV para productos exonerados
        //            preUnit_sinIgv = xprecio;  // No se divide entre 1.18 ya que es exonerado
        //            lsv_Det.Items[i].SubItems[10].Text = preUnit_sinIgv.ToString("###0.00");

        //            // Subtotal sin IGV
        //            subtotalExonerado += preUnit_sinIgv * xcant;
        //            lsv_Det.Items[i].SubItems[11].Text = (preUnit_sinIgv * xcant).ToString("###0.00");

        //            // IGV para productos exonerados (se establece en 0)
        //            lsv_Det.Items[i].SubItems[12].Text = "0.00";

        //            // Totales para productos exonerados
        //            totalExonerado += ximporte;


        //        }else if (lsv_Det.Items[i].SubItems[9].Text == "Gravado")
        //        {
        //            // Cálculos para productos gravados:
        //            xcant = Convert.ToDouble(lsv_Det.Items[i].SubItems[2].Text);
        //            xprecio = Convert.ToDouble(lsv_Det.Items[i].SubItems[3].Text);

        //            // Cálculo del importe para productos gravados (con IGV)
        //            ximporte = xprecio * xcant;
        //            lsv_Det.Items[i].SubItems[4].Text = ximporte.ToString("###0.00");

        //            // Utilidad de productos gravados
        //            xuti_unit = Convert.ToDouble(lsv_Det.Items[i].SubItems[7].Text);
        //            ximport_Uti = xuti_unit * xcant;

        //            // Total general para productos gravados (con IGV)
        //            xtotal += ximporte;

        //            // Total de ganancia para productos gravados
        //            xTotalGanancia += ximport_Uti;

        //            // Subtotal sin IGV para productos gravados
        //            preUnit_sinIgv = xprecio / 1.18;
        //            lsv_Det.Items[i].SubItems[10].Text = preUnit_sinIgv.ToString("###0.00");//se quitaron 0000

        //            //subtotal sin igv modo codi
        //            subtotal_sinIgv = preUnit_sinIgv * xcant;
        //            lsv_Det.Items[i].SubItems[11].Text = (preUnit_sinIgv * xcant).ToString("###0.00");



        //            // Subtotal sin IGV
        //            //subtotalGravado += preUnit_sinIgv * xcant;
        //            //lsv_Det.Items[i].SubItems[11].Text = (preUnit_sinIgv * xcant).ToString("###0.00");

        //            // IGV para productos gravados
        //            //igvProd = subtotalGravado * 0.18;
        //            igvProd = subtotal_sinIgv * 0.18;
        //            lsv_Det.Items[i].SubItems[12].Text = igvProd.ToString("###0.00");

        //            ////Pie de la FE para Sunat//
        //            //xsubtotal_sinIgv = xsubtotal_sinIgv + Convert.ToDouble(lsv_Det.Items[i].SubItems[12].Text);

        //            // Totales para productos gravados
        //            totalGravado += ximporte;
        //            xigv_total += igvProd;
        //        }



        //    }

        //    // Cálculos finales de totales
        //    xsubtotal = subtotal_sinIgv/*subtotalGravado*/ + subtotalExonerado;  // Suma de los subtotales gravados y exonerados
        //    xigv = xigv_total;  // Solo el IGV de productos gravados

        //    //mas detallae 
        //    lbl_subtotal_sinIgv.Text = subtotal_sinIgv.ToString("###0.00");

        //    lbl_subtotal.Text = xsubtotal.ToString("###0.00");
        //    lbl_igv.Text = xigv.ToString("###0.00");
        //    lbl_TotalPagar.Text = xtotal.ToString("###0.00");

        //    tx_efectivo.Text = xtotal.ToString("###0.00");

        //    lbl_totalGanancia.Text = xTotalGanancia.ToString("###0.00");

        //    lbl_son.Text = Numalet.ToString(lbl_TotalPagar.Text);
        //    let.LetraCapital = chkCapital.Checked;
        //    if (!actualizado) ActualizarCong();

        //    // Totales del pie FE para Sunat
        //    //lbl_subtotalGravado.Text = subtotalGravado.ToString("###0.00");
        //    lbl_igvgravado.Text = xigv_total.ToString("###0.00");
        //    double totalGravadoFinal = subtotalGravado + xigv_total;

        //    //dividimos el total entre 1.18
        //    //double xsubtotalxx = totalGravadoFinal / 1.18;
        //    //lbl_subtotalGravado.Text = xsubtotalxx.ToString("###0.00");

        //    lbl_totalGravado.Text = totalGravadoFinal.ToString("###0.00");
        //    lbl_TotalItem.Text = lsv_Det.Items.Count.ToString();
        //    lbl_TotalExonerado.Text = totalExonerado.ToString("###0.00");

        //    // ✅ Agregar cálculo de promociones al final, sin romper lo demás
        //    if (promocionesAplicadas == null)
        //        promocionesAplicadas = new List<EN_Promocion_Venta>();

        //    double descuentoTotal = Convert.ToDouble(promocionesAplicadas.Sum(p => p.Descuento));
        //    if (descuentoTotal > xtotal)
        //        descuentoTotal = xtotal;

        //    double totalConDescuento = xtotal - descuentoTotal;
        //    //lbl_TotalPagar.Text = totalConDescuento.ToString("###0.00");
        //    //tx_efectivo.Text = totalConDescuento.ToString("###0.00");
        //    //lbl_son.Text = Numalet.ToString(lbl_TotalPagar.Text);

        //    //detraccion = xtotal * tasaDetraccion;
        //    //lbl_detrac.Text = detraccion.ToString("###0.00");
        //}


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

                        //Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe, _und, _tipoProd, _Utili_Unit, "Gravado", "ZZ", "pr");
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

                    //Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe, _und, _tipoProd, _Utili_Unit, "Gravado", "ZZ","pr");
                }

            }


        }

        //nueva codificacion para metodos pagos mixtos
        private void btn_pagos_Click(object sender, EventArgs e)
        {
            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Metodo_Pago mp = new Frm_Metodo_Pago();

            //double efectivoTotal = 0;
            //double efectivo = 0;
            //double visa = 0;

            //if(mp.Tag.ToString() == "A")
            //{
            //    txt_metodoEfec.Text = mp.lbl_EfectivoMet.Text;
            //}

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
                pre.txt_cant.Text = Cant_Ingresado.ToString("###0.000");
                pre.idProducto = xidProd.Trim();
                pre.ShowDialog();
                fil.Hide();


                if (pre.Tag.ToString() == "A")
                {
                    Precio_Editado = Convert.ToDouble(pre.txt_precio.Text);
                    Cant_Editado = Convert.ToDouble(pre.txt_cant.Text);
                    xUti_Unit = Convert.ToDouble(pre.Lbl_UtilidadUnit.Text);

                    lsv_Det.SelectedItems[0].SubItems[3].Text = Precio_Editado.ToString("###0.00");
                    lsv_Det.SelectedItems[0].SubItems[2].Text = Cant_Editado.ToString("###0.000");
                    lsv_Det.SelectedItems[0].SubItems[7].Text = xUti_Unit.ToString("###0.00");

                    Calcular();
                    RecalcularTodo();
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
                    //Calcular();
                    RecalcularTodo();
                    //Calcular();
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
                //aca seria las exonerada 
                ped.Exonerada = Convert.ToDouble(lbl_TotalExonerado.Text);

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
            Frm_Advertencia ver = new Frm_Advertencia();

            if (lsv_Det.Items.Count == 0) { fil.Show(); ver.Lbl_msm1.Text = "Debes agregar como minimo un producto al Carrito"; ver.ShowDialog(); fil.Hide(); return false; }
            if (Convert.ToInt32(lbl_idcliente.Text.Length) < 2) { fil.Show(); ver.Lbl_msm1.Text = "Te falta agregar un Cliente"; ver.ShowDialog(); fil.Hide(); return false; }
            if (Cbo_TipoPago.SelectedIndex == -1) { fil.Show(); ver.Lbl_msm1.Text = "Por favor, Elige un Tipo de Pago"; ver.ShowDialog(); fil.Hide(); Cbo_TipoPago.Focus(); return false; }

            if (Cbo_TipoDoc.SelectedIndex == -1) { fil.Show(); ver.Lbl_msm1.Text = "Por favor, Elige un Tipo de Comprobante"; ver.ShowDialog(); fil.Hide(); Cbo_TipoDoc.Focus(); return false; }

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
            Frm_Metodo_Pago finx = new Frm_Metodo_Pago();

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

                ////probando:
                //if(Convert.ToDouble( txt_metodoEfec.Text )> 0 )
                //{
                //     doc.TipoPago = lbl_mtefec.Text = "Efectivo";
                //     doc.Efectivo = Convert.ToDouble(txt_metodoEfec.Text);
                //}
                //else
                //{
                //    doc.TipoPago = lbl_mtefec.Text = "-";
                //}
                ////2
                //if(Convert.ToDouble(txt_mtyape.Text) > 0)
                //{
                //    doc.TipoPago2 = lbl_yape.Text = "Yape";
                //    doc.Efec2 = Convert.ToDouble(txt_mtyape.Text);
                //}
                //else
                //{
                //    doc.TipoPago2 = lbl_yape.Text = "-";
                //}

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
                    RegistrarPromocionesAplicadas(txt_NroDoc.Text);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void RegistrarPromocionesAplicadas(string idDocumento)
        {
            RN_PromocionVenta objPromoVenta = new RN_PromocionVenta();

            foreach (var promo in promocionesAplicadas)
            {
                EN_Promocion_Venta venta = new EN_Promocion_Venta
                {
                    IdDoc = idDocumento,
                    IdPromocion = promo.IdPromocion,
                    Descuento = promo.Descuento
                };
                objPromoVenta.RN_Registrar_PromocionVenta(venta);
            }
        }

        private void Guardar_IngresoCaja()
        {
            RN_Caja obj = new RN_Caja();
            En_Caja cja = new En_Caja();
            Frm_Metodo_Pago pag = new Frm_Metodo_Pago();

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
                //cja.TipoPago2 = lbl;
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

                    //añadadiendo funcionabiliddad si el prod maneja stock
                    // Leer si controla stock
                    //datoprod = objpro.RN_Buscar_Productos(xidProd.Trim());
                    //bool controlaStock = Convert.ToBoolean(datoprod.Rows[0]["ControlaStock"]);

                    //if (!controlaStock)
                    //    continue; // saltamos este producto, no registra en kardex

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

                            kar.TipoOperacion = "Venta";
                            kar.CantiDiferencial = "0";
                            kar.ImporteDiferencial = 0;

                            bool controlaStock = Convert.ToBoolean(datoprod.Rows[0]["ControlaStock"]);
                           
                            if (!controlaStock)
                            {
                                kar.Observacion = "Producto SIN Control de Stock";

                                //Entradas y salidas como referencia(no se considera saldo)
                                kar.Cantidad_in = 0;
                                kar.Precio_In = 0;
                                kar.Total_In = 0;

                                //salida:
                                kar.Cantidad_Out = xcant;
                                kar.Precio_out = precioCompraProd;
                                kar.Total_out = xcant * precioCompraProd;

                                //saldos:   //CALCULOS DE LOS KARDEX VALORIZADOS
                                kar.Cantidad_saldo = stockProd;
                                kar.Promedio = precioCompraProd;
                                kar.Total_saldo = precioCompraProd * kar.Cantidad_saldo;
                            }
                            else
                            {
                                kar.Observacion = "-";

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

                            }
                           
                            obj.RN_Registrar_Detalle_Kardex(kar);

                            if (controlaStock)
                            {
                                //ahora actualizamos nuestro stock de la tabla de productos:
                                objpro.RN_Restar_Stock_Producto(xidProd.Trim(), xcant);
                            }
                            //ahora actualizamos nuestro stock de la tabla de productos:
                            //objpro.RN_Restar_Stock_Producto(xidProd.Trim(), xcant);

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
            Frm_Metodo_Pago fin = new Frm_Metodo_Pago();

            int idempresa = Cls_Libreria.Idempresa;

            try
            {
                if (Validar_Antes_Vender() == true)
                {

                    txt_NroDoc.Text = RN_TipoDoc.RN_NroID(Convert.ToInt32(Cbo_TipoDoc.SelectedValue));

                    fil.Show();
                    fin.lbl_cliente.Text = txt_cliente.Text;
                    fin.lbl_dni.Text = lbl_dni_ruc.Text;
                    fin.lbl_totalpagarxx.Text = lbl_TotalPagar.Text;
                    fin.lbl_totalUtili.Text = lbl_totalGanancia.Text;
                    fin.lbl_nroDocx.Text = txt_NroDoc.Text;
                    fin.lbl_tipoDoc.Text = Cbo_TipoDoc.Text;
                    //añadiendo
                    fin.lbl_tipopago.Text = Cbo_TipoPago.Text;
                    if (Cbo_TipoPago.SelectedIndex == 1)
                    {
                        //tarjeta
                        fin.xtabcon.SelectedIndex = 1;
                    }
                    else if (Cbo_TipoPago.SelectedIndex == 2)
                    {
                        //yape 
                        fin.xtabcon.SelectedIndex = 2;
                    }
                    else if (Cbo_TipoPago.SelectedIndex == 3)
                    {
                        //plin
                        fin.xtabcon.SelectedIndex = 3;
                    }
                    else if (Cbo_TipoPago.SelectedIndex == 4)
                    {
                        //mixto
                        fin.xtabcon.SelectedIndex = 5;
                    }
                    else if (Cbo_TipoPago.SelectedIndex == 5)
                    {
                        //a credito
                        fin.xtabcon.SelectedIndex = 4;
                    }
                    fin.ShowDialog();
                    fil.Hide();

                    chk_printtick.Checked = fin.paraImprimir;

                    if (fin.Tag.ToString() == "A")
                    {

                        if (fin.lbl_tipopago.Text == "Credito")
                        {

                            Cbo_TipoPago.Text = fin.lbl_tipopago.Text;
                            dtp_cred_vence1.Value = fin.dtp_vence1.Value;
                            dtp_vence_cred2.Value = fin.dtp_vence2.Value;
                            dtp_vence_cred3.Value = fin.dtp_vence3.Value;
                            lbl_nrocuota.Text = fin.num_cuota.Value.ToString();
                            lbl_nrocuota.Text = fin.txt_montocuota.Text;

                        }

                    }

                    else
                    {
                        MessageBox.Show("operacion cancelada por el usuario");
                        return;
                    }

                    /*if (Cbo_TipoPago.SelectedIndex == 3) //cuadno es a credito 
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

                    }*/

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
                                    //EnviarDocumento_dePrueba_Sunat();

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
                                            //1nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                                            //configurando sin vista previo impresion directo:
                                            //nota.ShowDialog(); //opcion para aparece vista previa ticket
                                            fil.Hide();
                                            //trmVNETA 
                                            /* fil.Show(); para enviar correos ticket
                                            enviardocventa.lbl_nroDoc.Text = txt_NroDoc.Text;
                                            enviardocventa.lbl_rutDoc.Text = RutaPdf_export;
                                            enviardocventa.lbl_rutxml.Text = lbl_rutaXml.Text;
                                            enviardocventa.ShowDialog();
                                            fil.Hide();*/
                                            //dp.limp
                                            Limpiar_todo();
                                            //pnl_sinProd.Visible = true;
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
                                            /*fil.Show(); coorreo ticket
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
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
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

                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
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

                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 8)
                                        {
                                            //soniavalero:

                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            nota.Imprimir_BoletaFactura_Ticket_SoniaValero();
                                            nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                                            nota.ShowDialog();
                                            fil.Hide();
                                            //trmVNETA 
                                            /* fil.Show();
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
                                            if (fin.paraImprimir)
                                            {

                                                fil.Show();
                                                nota.Tag = txt_NroDoc.Text;
                                                nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                                RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
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
                                            }
                                                Limpiar_todo();
                                        }

                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 10)
                                        {
                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            nota.Imprimir_BoletaFactura_Ticket_ColeccionistaPeru(txt_NroDoc.Text);
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
                                        }
                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 12)
                                        {
                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            nota.Imprimir_BoletaFactura_Ticket_TextCharlote();
                                            nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                                            nota.ShowDialog();
                                            fil.Hide();
                                        }
                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 13)
                                        {
                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            nota.Imprimir_BoletaFactura_Ticket_ImportacionTextilLucero();
                                            nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                                            nota.ShowDialog();
                                            fil.Hide();
                                        }
                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 14)
                                        {
                                            if (fin.paraImprimir)
                                            {

                                                fil.Show();
                                                nota.Tag = txt_NroDoc.Text;
                                                nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                                RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                                nota.Imprimir_BoletaFactura_Ticket_LucianoEIRL(txt_NroDoc.Text);
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
                                            }
                                            Limpiar_todo();
                                        }

                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 15)
                                        {
                                            if (fin.paraImprimir)
                                            {

                                                fil.Show();
                                                nota.Tag = txt_NroDoc.Text;
                                                nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                                RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";

                                                //** POR ARMAR EL METODO, Y EN TAB_MIEMPRESA TAMBIEN AÑADIR SUS ,
                                                //NUEVO CLIENTE CON SU RESPECTIVOS DATOS , CREAR SU RPT PARA TICKET Y LLAMARLO AQUI:

                                                nota.Imprimir_BoletaFactura_Ticket_LucianoEIRL(txt_NroDoc.Text);
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
                                            }
                                            Limpiar_todo();
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
                                            //*nota.ShowDialog();
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
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
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
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
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
                                            //pnl_sinProd.Visible = true;
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

                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 8)
                                        {
                                            //tnik:

                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
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
                                            if (fin.paraImprimir)
                                            {
                                                fil.Show();
                                                nota.Tag = txt_NroDoc.Text;
                                                nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                                RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
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
                                            }
                                                Limpiar_todo();
                                        }

                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 10)
                                        {
                                            //tnik:
                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            nota.Imprimir_BoletaFactura_Ticket_ColeccionistaPeru(txt_NroDoc.Text);
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
                                        }
                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 12)
                                        {
                                            //tnik:
                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            nota.Imprimir_NotaVenta_Ticket_TextCharlote(txt_NroDoc.Text);
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
                                        }
                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 13)
                                        {
                                            //tnik:
                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            nota.Imprimir_NotaVenta_Ticket_TextilLucero(txt_NroDoc.Text);
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
                                        }
                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 14)
                                        {
                                            if (fin.paraImprimir)
                                            {
                                                fil.Show();
                                                nota.Tag = txt_NroDoc.Text;
                                                nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                                RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                                nota.Imprimir_BoletaFactura_Ticket_LucianoEIRL(txt_NroDoc.Text);
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
                                            }
                                            Limpiar_todo();
                                        }
                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 15)
                                        {
                                            if (fin.paraImprimir)
                                            {
                                                fil.Show();
                                                nota.Tag = txt_NroDoc.Text;
                                                nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                                RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";

                                                //** POR ARMAR EL METODO, Y EN TAB_MIEMPRESA TAMBIEN AÑADIR SUS ,
                                                //NUEVO CLIENTE CON SU RESPECTIVOS DATOS , CREAR SU RPT PARA TICKET Y LLAMARLO AQUI:
                                                nota.Imprimir_BoletaFactura_Ticket_LucianoEIRL(txt_NroDoc.Text); // 
                                                
                                                
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
                                            }
                                            Limpiar_todo();
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
                                            nota.ShowDialog();//probando con comen
                                            fil.Hide();
                                            Limpiar_todo();
                                            //pnl_sinProd.Visible = true;
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
                                            if (fin.paraImprimir)
                                            {
                                                fil.Show();
                                                nota.Tag = txt_NroDoc.Text;
                                                nota.Imprimir_NotaVenta_Ticket_InvAnelay(txt_NroDoc.Text);//crear rpt notaventa
                                                                                                          //nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                                                                                                          //nota.ShowDialog();
                                                fil.Hide();
                                                Limpiar_todo();
                                                //pnl_sinProd.Visible = true;
                                            }
                                                Limpiar_todo();
                                                //pnl_sinProd.Visible = true;
                                        }

                                        else if (Cbo_TipoDoc.Text == "Nota Venta" && idempresa == 10)
                                        {
                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Imprimir_NotaVenta_Ticket_ColeccionistaPeru(txt_NroDoc.Text);
                                            //nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                                            //nota.ShowDialog();
                                            fil.Hide();
                                            Limpiar_todo();
                                            //pnl_sinProd.Visible = true;
                                        }

                                      
                                        else if (Cbo_TipoDoc.Text == "Nota Venta" && idempresa == 12)
                                        {
                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Imprimir_NotaVenta_Ticket_TextCharlote(txt_NroDoc.Text);//crear rpt notaventa
                                            nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                                            nota.ShowDialog();
                                            fil.Hide();
                                            Limpiar_todo();
                                            pnl_sinProd.Visible = true;
                                        }

                                        else if (Cbo_TipoDoc.Text == "Nota Venta" && idempresa == 13)
                                        {
                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Imprimir_NotaVenta_Ticket_TextilLucero(txt_NroDoc.Text);//crear rpt notaventa
                                            nota.lbl_nroDoc.Text = Cbo_TipoDoc.Text.Trim() + " " + txt_NroDoc.Text;
                                            nota.ShowDialog();
                                            fil.Hide();
                                            Limpiar_todo();
                                            pnl_sinProd.Visible = true;
                                        }

                                        else if (Cbo_TipoDoc.Text == "Nota Venta" && idempresa == 14)
                                        {
                                            if (fin.paraImprimir)
                                            {
                                                fil.Show();
                                                nota.Tag = txt_NroDoc.Text;
                                                nota.Imprimir_NotaVenta_Ticket_LucianoEIRL(txt_NroDoc.Text);//crear rpt notaventa
                                                fil.Hide();
                                                Limpiar_todo();
                                            }
                                            Limpiar_todo();
                                        }

                                        else if (Cbo_TipoDoc.Text == "Nota Venta" && idempresa == 15)
                                        {
                                            if (fin.paraImprimir)
                                            {
                                                fil.Show();
                                                nota.Tag = txt_NroDoc.Text;
                                                //crear rpt notaventa , Y SU METODO 
                                                //nota.Imprimir_NotaVenta_Ticket_LucianoEIRL(txt_NroDoc.Text);
                                                fil.Hide();
                                                Limpiar_todo();
                                            }
                                            Limpiar_todo();
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
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
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
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
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

                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
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

                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 8)
                                        {
                                            //NIKO:
                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
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
                                            if (fin.paraImprimir)
                                            {
                                                fil.Show();
                                                nota.Tag = txt_NroDoc.Text;
                                                nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                                RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
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
                                                Limpiar_todo();
                                                //this.Close();
                                        }
                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 10)
                                        {
                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            nota.Imprimir_BoletaFactura_Ticket_ColeccionistaPeru(txt_NroDoc.Text);
                                            fil.Hide();
                                            Limpiar_todo();
                                            //pnl_sinProd.Visible = true;
                                            this.Close();
                                        }
                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 12)
                                        {                                         
                                            fil.Show();
                                            nota.Tag = txt_NroDoc.Text;
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            nota.Imprimir_BoletaFactura_Ticket_TextCharlote();
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
                                            nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                            nota.Imprimir_BoletaFactura_Ticket_TextCharlote();
                                            fil.Hide();
                                            Limpiar_todo();
                                            //pnl_sinProd.Visible = true;
                                            this.Close();
                                        }
                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 14)
                                        {
                                            if (fin.paraImprimir)
                                            {
                                                fil.Show();
                                                nota.Tag = txt_NroDoc.Text;
                                                nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                                RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                                nota.Imprimir_BoletaFactura_Ticket_LucianoEIRL(txt_NroDoc.Text);
                                                fil.Hide();
                                                Limpiar_todo();                                               
                                                this.Close();
                                            }
                                            Limpiar_todo();                                          
                                        }
                                        else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 15)
                                        {
                                            if (fin.paraImprimir)
                                            {
                                                fil.Show();
                                                nota.Tag = txt_NroDoc.Text;
                                                nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                                RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                                                nota.Imprimir_BoletaFactura_Ticket_LucianoEIRL(txt_NroDoc.Text);
                                                fil.Hide();
                                                Limpiar_todo();
                                                this.Close();
                                            }
                                            Limpiar_todo();
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
                objCPE.TIPO_OPERACION = "0101"; //venta interna 0101
                objCPE.TOTAL_GRAVADAS = Convert.ToDecimal(lbl_subtotal_sinIgv.Text);//Convert.ToDecimal(lbl_subtotal.Text);
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
                objCPE.TOTAL_EXONERADAS = Convert.ToDecimal(lbl_TotalExonerado.Text);


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
                objCPE.CODIGO_UBIGEO_EMPRESA = "150115";// ("070104"-la perla);//"150101";
                objCPE.DIRECCION_EMPRESA = Lbl_DireccionEmpresa.Text.Trim();
                objCPE.DEPARTAMENTO_EMPRESA = "Lima";//"Callao";
                objCPE.PROVINCIA_EMPRESA = "Lima";//"Callao";
                objCPE.DISTRITO_EMPRESA = "La Victoria";//"La Perla";
                objCPE.CODIGO_PAIS_EMPRESA = "PE";
                objCPE.RAZON_SOCIAL_EMPRESA = Lbl_EmpresaEmisor.Text.Trim();
                objCPE.CONTACTO_EMPRESA = "";
                objCPE.USUARIO_SOL_EMPRESA = Lbl_UsuarioSol.Text.Trim();
                objCPE.PASS_SOL_EMPRESA = Lbl_ClaveSol.Text.Trim();
                objCPE.CONTRA_FIRMA = Lbl_ClaveCertificado.Text.Trim();


                int xtipo = Convert.ToInt32(lbl_server.Text);
                objCPE.TIPO_PROCESO = xtipo;

                //Detraccion:
                //objCPE.TOTAL_DETRACCIONES = Convert.ToDecimal(lbl_detrac.Text);

                //DETALLE DETRAC: SERVICO TRANSPO, CARGA: 1004

                //
                //objCPE.REGISTRO_MTC = "15M22004022E";

                //objCPE.COD_UBIGEO_DESTINO = lbl_ubigDestino.Text.Trim();//"150136";
                //objCPE.DIRECCION_DESTINO = txt_direccDestino.Text.Trim(); //"471 - LIMA - LIMA - SAN MIGUEL";
                //objCPE.DETALLE_VIAJE = txtDetalleViaje.Text.Trim();//"TRANSPORTE DE ACONDICIONADORES";
                //objCPE.COD_UBIGEO_ORIGEN = lbl_ubigOrigen.Text.Trim();// "150108";
                //objCPE.DIRECCION_ORIGEN = txt_direccionoOrigen.Text.Trim();// "170 - LIMA - LIMA - CHORRILLOS";

                //objCPE.VALOR_REF_SERV_TRANSP = Convert.ToDecimal(txt_valorRef_ServTransp.Text);
                //objCPE.VALOR_REF_CARG_EFEC = Convert.ToDecimal(txt_valorRef_CargaEfect.Text);//Convert.ToDecimal(3000.00);
                //objCPE.VALOR_REF_CARG_UTIL = Convert.ToDecimal(txt_valorRef_CargaUtil.Text); //Convert.ToDecimal(2100.00);

                //objCPE.CONFIG_VEHICULAR = "N1";
                //objCPE.CARGA_UTIL_TONE_METRIC_VEHICULO = Convert.ToDecimal(txt_carga_UtilTonMetrica.Text);



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

                    // Asignación del código de tipo de operación
                    string tipoOperacion = lsv_Det.Items[i].SubItems[9].Text;  // "Gravado" o "Exonerada"
                    if (tipoOperacion == "Gravado")
                    {
                        objCPE_DETALLE.COD_TIPO_OPERACION = "10"; // Gravado
                    }
                    else if (tipoOperacion == "Exonerado")
                    {
                        objCPE_DETALLE.COD_TIPO_OPERACION = "20"; // Exonerado

                    }

                    objCPE_DETALLE.CODIGO = lsv_Det.Items[i].SubItems[0].Text;
                    objCPE_DETALLE.DESCRIPCION = lsv_Det.Items[i].SubItems[1].Text;
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

        private void EnviarDocumento_dePrueba_Sunat()
        {

            try
            {

                objCPE.TIPO_OPERACION = "0101"; //venta interna --cambiar a operacion a detraccion catalog 51 (1004) - venta interna origina (0101)
                objCPE.TOTAL_GRAVADAS = Convert.ToDecimal(lbl_subtotal_sinIgv.Text);//Convert.ToDecimal(lbl_subtotal.Text); 400
                objCPE.SUB_TOTAL = Convert.ToDecimal(lbl_subtotal.Text);//410 
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
                objCPE.TOTAL_EXONERADAS = Convert.ToDecimal(lbl_TotalExonerado.Text);
                //se añade forma de pago:
                //objCPE.FORMA_PAGO = "contado";

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
                objCPE.CODIGO_UBIGEO_EMPRESA = "150108";//"150101"; // -   //san miguel 150136
                objCPE.DIRECCION_EMPRESA = Lbl_DireccionEmpresa.Text.Trim();
                objCPE.DEPARTAMENTO_EMPRESA = "Callao";
                objCPE.PROVINCIA_EMPRESA = "Callao";
                objCPE.DISTRITO_EMPRESA = "La Perla";
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

                    // Asignación del código de tipo de operación
                    string tipoOperacion = lsv_Det.Items[i].SubItems[9].Text;  // "Gravado" o "Exonerada"
                    if (tipoOperacion == "Gravado")
                    {
                        objCPE_DETALLE.COD_TIPO_OPERACION = "10"; // Gravado
                    }
                    else if (tipoOperacion == "Exonerado")
                    {
                        objCPE_DETALLE.COD_TIPO_OPERACION = "20"; // Exonerado

                    }

                    //objCPE_DETALLE.COD_TIPO_OPERACION = "10"; //10-GRAVADO, 20 -EXONERADO

                    objCPE_DETALLE.CODIGO = lsv_Det.Items[i].SubItems[0].Text;
                    objCPE_DETALLE.DESCRIPCION = lsv_Det.Items[i].SubItems[1].Text; //11
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

            pic_qr.Load(RutaQr);

            //AÑADIENDO CODIGO PARA ELIMINAR TEMPORALES REIMP:

            //obj.RN_Eliminar_Temporal(txt_NroDoc.Text);

            //FIN
            try
            {
                tem.IdTemporal = txt_NroDoc.Text;
                tem.FechaEmi = dtp_FechaEmi.Value.ToString();
                tem.Nomcliente = txt_cliente.Text;
                tem.Ruc = lbl_dni_ruc.Text;
                tem.Direccion = lbl_direccion.Text;
                tem.Subtotal = lbl_subtotal_sinIgv.Text;//esta variable viene ser la gravada de los prod con igv //lbl_subtotal.Text;
                tem.Igv = lbl_igv.Text;
                tem.Total = lbl_TotalPagar.Text;
                tem.TipoPago = Cbo_TipoPago.Text;
                tem.NroOperacion = txt_NroOperac.Text;
                tem.Efectivo = tx_efectivo.Text;
                tem.Vuelto = lbl_vlto.Text;
                tem.Sonletra = lbl_son.Text;
                tem.Vendedor = Cls_Libreria.Nombre;
                tem.CodigoQr = Convertir_Imagen_Bytes(pic_qr.Image);
                tem.Exonerada = lbl_TotalExonerado.Text;
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
                MessageBox.Show("Error: " + ex.Message, "Advertencia,Reg.Temporal V", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            lsv_Pdet.Items.Clear();
            txtBusquedaProd.Text = "";
            //txt_cliente.Text = "";
            //lbl_idcliente.Text = "";
            lbl_totalGanancia.Text = "0";
            lbl_subtotal.Text = "0";
            lbl_igv.Text = "0";
            lbl_totalGanancia.Text = "0";
            lbl_Limit_Cred.Text = "0";
            //lbl_dni_ruc.Text = "";
            //Cbo_TipoPago.SelectedIndex = -1;
            //Cbo_TipoDoc.SelectedIndex = -1;
            lbl_saldo_Pdnte.Text = "0";
            lbl_totalVale.Text = "0";
            lbl_TotalExonerado.Text = "0";
            lbl_TotalPagar.Text = "0";
            //tx_efectivo.Text = "";
            //lbl_vlto.Text = "0";

            btnReimprimir.Enabled = false;
            btn_procesar.Enabled = true;

            bt_add.Enabled = true;
            bt_editPre.Enabled = true;
            bt_Delete.Enabled = true;
            panel1.Enabled = true;

            lblPromocionesAplicadas.Text = "Sin promociones aplicadas.";
            promocionesAplicadas.Clear();
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
            Frm_Advertencia ver = new Frm_Advertencia();


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
                        ver.Lbl_msm1.Text = "Esta Cotizacion ya fue atendida, por favor, cargue otra que este Pendiente";
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
                                xlist.SubItems.Add(xitem["Precio_conIgv"].ToString());
                                xlist.SubItems.Add(xitem["ImporteconIgv"].ToString());
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
                            xlist.SubItems.Add(xitem["Precio_conIgv"].ToString());
                            xlist.SubItems.Add(xitem["ImporteconIgv"].ToString());
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


        private void Bucar_Documento_paraReimprimir(/*string nroDoc*/List<string> nroDocs)
        {

            RN_GuiaRem_Transportista obj = new RN_GuiaRem_Transportista();
            DataTable dato = new DataTable();

            try
            {
                foreach (string nroDoc in nroDocs)
                {
                    //dato = obj.RN_Buscador_DocumentoGR_Detalle_porID(nroDoc.Trim()); se comenteo revisar esta linea

                    if (dato.Rows.Count > 0)
                    {

                        var dt = dato.Rows[0];

                        //txt_nroGr.Text = Convert.ToString(dt["Id_GrTransp_Guia"]);
                        //txt_nroPed.Text = Convert.ToString(dt["id_Ped"]);
                        //Cbo_TipoDoc.SelectedValue = Convert.ToUInt32(dt["Id_Tipo"]);
                        //dtp_FechaEmi.Value = Convert.ToDateTime(dt["Fecha"]);
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


                            string idProducto = xitem["Id_Pro_Detalle"].ToString();
                            string descripcion = xitem["Descripcion_Larga"].ToString();
                            string cantidad = xitem["Cantidad"].ToString();
                            string precioUnit = xitem["PrecioUnit"].ToString();
                            string importe = xitem["Importe"].ToString();
                            string tipoProducto = xitem["TipoProdcto"].ToString();
                            string undMedida = xitem["UndMedida"].ToString();
                            string utilidadUnit = xitem["UtilidadUnit"].ToString();


                            // Busca si ya existe el producto en el ListView
                            bool encontrado = false;
                            foreach (ListViewItem item in lsv_Det.Items)
                            {
                                if (item.Text == idProducto)  // Si el código de producto ya existe
                                {
                                    // Sumar las cantidades
                                    double cantidadExistente = Convert.ToDouble(item.SubItems[2].Text);
                                    double cantidadNueva = Convert.ToDouble(cantidad);
                                    item.SubItems[2].Text = (cantidadExistente + cantidadNueva).ToString();

                                    // Puedes también actualizar el importe si lo necesitas
                                    double precioExistente = Convert.ToDouble(item.SubItems[3].Text);
                                    double importeExistente = Convert.ToDouble(item.SubItems[4].Text);
                                    item.SubItems[4].Text = (importeExistente + (precioExistente * cantidadNueva)).ToString();

                                    encontrado = true;
                                    break;
                                }
                            }
                            // Si no se encontró el producto, lo agrega
                            if (!encontrado)
                            {
                                ListViewItem xlist = lsv_Det.Items.Add(idProducto);
                                xlist.SubItems.Add(descripcion);
                                xlist.SubItems.Add(cantidad);
                                xlist.SubItems.Add(precioUnit);
                                xlist.SubItems.Add(importe);
                                xlist.SubItems.Add(tipoProducto);
                                xlist.SubItems.Add(undMedida);
                                xlist.SubItems.Add(utilidadUnit);
                                xlist.SubItems.Add(utilidadUnit);

                                xlist.SubItems.Add("Gravado");  // Índice 9
                                xlist.SubItems.Add("0.00");     // Índice 10
                                xlist.SubItems.Add("0.00");     // Índice 11
                                xlist.SubItems.Add("0.00");     // Índice 12
                                xlist.SubItems.Add("NIU");      // Índice 13
                            }



                            /*original

                            ListViewItem xlist;
                            xlist = lsv_Det.Items.Add(xitem["Id_Pro_Detalle"].ToString());
                            xlist.SubItems.Add(xitem["Descripcion_Larga"].ToString());
                            xlist.SubItems.Add(xitem["Cantidad"].ToString());
                            xlist.SubItems.Add(xitem["PrecioUnit"].ToString());
                            xlist.SubItems.Add(xitem["Importe"].ToString());
                            xlist.SubItems.Add(xitem["TipoProdcto"].ToString());
                            xlist.SubItems.Add(xitem["UndMedida"].ToString());
                            xlist.SubItems.Add(xitem["UtilidadUnit"].ToString());
                            xlist.SubItems.Add(xitem["UtilidadUnit"].ToString());

                            xlist.SubItems.Add("Gravado");  // Índice 9
                            xlist.SubItems.Add("0.00");     // Índice 10
                            xlist.SubItems.Add("0.00");     // Índice 11
                            xlist.SubItems.Add("0.00");     // Índice 12
                            xlist.SubItems.Add("NIU");      // Índice 13
                            */
                        }
                        Calcular();
                        pnl_sinProd.Visible = false;
                        btnReimprimir.Enabled = true;
                        //btn_procesar.Enabled = false;

                        //bt_add.Enabled = false;
                        //bt_editPre.Enabled = false;
                        //bt_Delete.Enabled = false;
                        //panel1.Enabled = false;

                    }
                    
                    //else
                    //{
                    //    Frm_Filtro fil = new Frm_Filtro();
                    //    Frm_Addver ver = new Frm_Addver();

                    //    fil.Show();
                    //    ver.Lbl_Msm1.Text = "El Documento que buscas no existe, o talvez sea una Cotizacion, Marque el Check";
                    //    ver.ShowDialog();
                    //    fil.Hide();
                    //    return;
                    //}
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



            /*
            // se deshabilito , se creo venta de reimpresion: 23-02-23
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


                    }
                    Calcular();
                    pnl_sinProd.Visible = false;
                    btnReimprimir.Enabled = true;
                    btn_procesar.Enabled = false;

                    bt_add.Enabled = false;
                    bt_editPre.Enabled = false;
                    bt_Delete.Enabled = false;
                    panel1.Enabled = false;

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
            }
            */

        }

        private void lbl_lupa_Click(object sender, EventArgs e)
        {
            // Crear una lista con múltiples IDs (puedes separarlos con comas, por ejemplo)
            List<string> ids = txt_buscar.Text.Split(',').Select(id => id.Trim()).ToList();

            Bucar_Documento_paraReimprimir(ids);

            //if (txt_buscar.Text.Trim().Length > 6)
            //{
            //    if (chk_coti.Checked == true)
            //    {
            //        //va cargar una cotizacion
            //        Bucar_Cotizacion_paraAtender(txt_buscar.Text);
            //    }
            //    else
            //    {
            //        //cargar el documento para reimprimir:
            //        Bucar_Documento_paraReimprimir(txt_buscar.Text);
            //    }
            //}

        }

        private void Cbo_TipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (Cbo_TipoPago.Text == "Visa")
            //{
            //    txt_NroOperac.ReadOnly = false;
            //    txt_NroOperac.Focus();
            //}
            //else if (Cbo_TipoPago.Text == "Mastercard")
            //{
            //    txt_NroOperac.ReadOnly = false;
            //    txt_NroOperac.Focus();
            //}
            if (Cbo_TipoPago.Text.Trim() == "Nota Credito")
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
            //else if (Cbo_TipoPago.Text.Trim() == "Vale")
            //{
            //    //BUSCAMOS EL VALE:
            //}
            //agregando nuevos metodos de pago:11/12/22
            /* else if(Cbo_TipoPago.Text == "Yape" || Cbo_TipoPago.Text == "Plin")
             {
                 txt_NroOperac.ReadOnly = false;
                 txt_NroOperac.Focus();
             }*/
            else
            {
                //txt_NroOperac.Text = "-";
                //txt_NroOperac.ReadOnly = true;
            }
        }

        //nuevo metodo 11-05-23 para nc :

        private void BuscarNotaCredito_ParaPagos(string nroDoc)
        {
            RN_Notacredito obj = new RN_Notacredito();
            DataTable data = new DataTable();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

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
                        ver.Lbl_msm1.Text = "El Saldo a Pagar es de: " + SaldoaPagar.ToString("###0.00");
                        ver.ShowDialog();
                        fil.Hide();
                        lbl_totalVale.Visible = false;


                    }

                }
                else
                {
                    fil.Show();
                    ver.Lbl_msm1.Text = "El Documento Ingresado No existe o No es Válido para Pagos";
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
                //if (pnl_sinProd.Visible == true)
                //{
                //    btn_Nuevo_buscarProd_Click(sender, e);
                //}

                //if (pnl_sinProd.Visible == false)
                //{
                    
                //    bt_editPre_Click(sender, e);
                //}
            }

            if (e.KeyCode == Keys.F2)
            {
                //if (pnl_sinProd.Visible == false)
                //{
                //    bt_add_Click(sender, e);
                //}
            }

            if (e.KeyCode == Keys.F3)
            {
                bt_editPre_Click(sender, e);
            }

            if (e.KeyCode == Keys.F4)
            {
                bt_Delete_Click(sender, e);
            }


            //if (e.KeyCode == Keys.Delete)
            //{
            //    if (pnl_sinProd.Visible == false)
            //    {
            //        bt_Delete_Click(sender, e);
            //    }
            //}

            if (e.KeyCode == Keys.F5)
            {
                lblBuscarCliente_Click(sender, e);
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
                    nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
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
                    nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
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
                    nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
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
                    nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
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
                    nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
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
                    nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
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
                    nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
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
                    nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    nota.Imprimir_BoletaFactura_Ticket_InvAnelay(txt_NroDoc.Text);
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
                    //pnl_sinProd.Visible = true;
                    this.Close();
                }

                else if (Cbo_TipoDoc.Text != "Nota Venta" && idempresa == 10)
                {
                    //

                    fil.Show();
                    nota.Tag = txt_NroDoc.Text;
                    nota.Rutdapdf = RutaPdf_export + Lbl_RucEmisor.Text + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    RutaPdf_export = RutaPdf_export + Lbl_RucEmisor.Text.Trim() + "-" + lbl_id_TipodocSunat.Text + "-" + txt_NroDoc.Text + ".pdf";
                    nota.Imprimir_BoletaFactura_Ticket_ColeccionistaPeru(txt_NroDoc.Text);

                    fil.Hide();

                    Limpiar_todo();
                    //pnl_sinProd.Visible = true;
                    this.Close();
                }

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
            /*
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
            }*/
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
                //lbl_server.Text = "0";
            }
        }

        private void rdb_sunat_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_sunat.Checked == true)
            {
                //lbl_server.Text = "1";

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


       

        private void lbl_id_TipodocSunat_Click(object sender, EventArgs e)
        {

        }

        private void txt_cliente_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void rdb_Prueba_Click(object sender, EventArgs e)
        {

        }

        private void rdb_local_Click(object sender, EventArgs e)
        {

        }


        /*
        private async Task  buscar_Productos(string valor)
        {
            /*
            DataTable dt = new DataTable();
            RN_Productos obj = new RN_Productos();

            dt = await Task.Run(() => obj.RN_Buscar_Productos(valor));

            if (dt.Rows.Count > 0)
            {
                lsv_prodcto.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    ListViewItem list = new ListViewItem(dr["Id_Pro"].ToString());
                    list.SubItems.Add(dr["Descripcion_Larga"].ToString());//1
                    list.SubItems.Add(dr["Stock_Actual"].ToString());//2
                    list.SubItems.Add(dr["Pre_CompraS"].ToString());//3
                    list.SubItems.Add(dr["Frank"].ToString());//4
                    list.SubItems.Add(dr["Pre_vntaxMenor"].ToString());//5
                    list.SubItems.Add(dr["Pre_vntaxMayor"].ToString());//6
                    list.SubItems.Add(dr["UtilidadUnit"].ToString());//7
                    list.SubItems.Add(dr["Valor_porCant"].ToString());//8
                    list.SubItems.Add(dr["Estado_Pro"].ToString());//9
                    list.SubItems.Add(dr["Marca"].ToString());//10
                    list.SubItems.Add(dr["TipoProdcto"].ToString());//11

                    lsv_prodcto.Items.Add(list);

                }
                //Pintar_Filas();
                pnl_msm.Visible = false;
                lbl_totalItem.Text = lsv_prodcto.Items.Count.ToString();
            }
            else
            {
                MessageBox.Show("no se cargo los productos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }*/

        private void horafecha_Tick(object sender, EventArgs e)
        {
            dtp_FechaEmi.Value = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
        }

        private void rdb_sunat_Click(object sender, EventArgs e)
        {

        }

        private void txt_buscar_Producto_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void SeleccionarProducto_Carrito()
        {
            //para que desde el listview seleccione y envie a listview carrito de ventas:
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Add_Cantidad cant = new Frm_Add_Cantidad();

            double stk2 = 0;

            


            if(lsv_Pdet.SelectedIndices.Count == 0) { fil.Show(); ver.Lbl_msm1.Text = "Por favor Selecciona el Producto que deseas Agregar"; ver.ShowDialog(); fil.Hide(); return; }

            string idProducto = "";
            idProducto = lsv_Pdet.SelectedItems[0].SubItems[0].Text;
            //stk2 = Convert.ToDouble(lsv_Pdet.SelectedItems[0].SubItems[2].Text);

            buscar_Productos(idProducto);

        }
        private void lsv_Pdet_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SeleccionarProducto_Carrito();
        }

        private void lsv_Pdet_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SeleccionarProducto_Carrito();
            }
        }
        
        private void AumentarCantidad()
        {
            BD_Productos obj = new BD_Productos();
            DataTable Datos = new DataTable();

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            double cant_Edit = 0;
            string idProd = "";
            double cant_add = 0; //stock que no se mueve
            double stock_Actual = 0;
            


            if(lsv_Det.SelectedIndices.Count == 0) { fil.Show(); ver.Lbl_msm1.Text = "Selecciona un Producto"; ver.ShowDialog(); fil.Hide(); return; }

            idProd = lsv_Det.SelectedItems[0].SubItems[0].Text;

            cant_Edit = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[2].Text);
            cant_add = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[2].Text);

            //leemos algunos datos;
            Datos = obj.BD_Buscar_Productos(idProd);

            if (Datos.Rows.Count > 0)
            {
                stock_Actual = Convert.ToDouble(Datos.Rows[0]["Stock_Actual"]);
                bool controlaStock = Convert.ToBoolean(Datos.Rows[0]["ControlaStock"]);

                if (controlaStock && cant_Edit >= stock_Actual)
                {
                    fil.Show();
                    ver.Lbl_msm1.Text = "Has llegado al tope del Stock Disponible [ " + stock_Actual + " ]";
                    ver.ShowDialog();
                    fil.Hide();

                    lsv_Det.SelectedItems[0].SubItems[2].Text = cant_add.ToString("###0.00");
                    Calcular();
                    return;
                }
                else
                {
                    double newCanti = cant_Edit + 1;
                    lsv_Det.SelectedItems[0].SubItems[2].Text = newCanti.ToString("###0.00");
                    Calcular();
                }
            }


        }

        private void QuitarCantidad()
        {
            BD_Productos obj = new BD_Productos();
            DataTable Datos = new DataTable();

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            double cant_Edit = 0;
            string idProd = "";
            double cant_add = 0; //stock que no se mueve
            double stock_Actual = 0;



            if (lsv_Det.SelectedIndices.Count == 0) { fil.Show(); ver.Lbl_msm1.Text = "Selecciona un Producto"; ver.ShowDialog(); fil.Hide(); return; }

            idProd = lsv_Det.SelectedItems[0].SubItems[0].Text;

            cant_Edit = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[2].Text);
            cant_add = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[2].Text);

            //leemos algunos datos;
            Datos = obj.BD_Buscar_Productos(idProd);

            if (Datos.Rows.Count > 0)
            {
                stock_Actual = Convert.ToDouble(Datos.Rows[0]["Stock_Actual"]);
            }
            else
            {
                fil.Show();
                ver.Lbl_msm1.Text = "No se puede leer los datos de este producto: Utilice otro metodo"; ver.ShowDialog(); fil.Hide(); return;
            }

            if (cant_Edit <= 1)
            {
                
            }
            else
            {
                double newCanti = cant_Edit - 1;
                lsv_Det.SelectedItems[0].SubItems[2].Text = newCanti.ToString("###0.00");
                Calcular();
            }


        }

        private void lsv_Det_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Add)
            {
                AumentarCantidad();
            }
            if(e.KeyData == Keys.Subtract)
            {
                QuitarCantidad();
            }
            //if(e.KeyData == Keys.F1)
            //{
            //    AumentarCantidad();
            //}

        }

        private void txt_buscar_Producto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBusquedaProd_OnValueChanged(object sender, EventArgs e)
        {
            timerBusqueda.Stop();
            timerBusqueda.Start();
            //if (txtBusquedaProd.Text.Trim().Length > 2)
            //{
            //   buscar_Productos(txtBusquedaProd.Text);
            //}
        }

        private void txtBusquedaProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                e.SuppressKeyPress = true;
                //lbl_buscarProd_Click(sender, e);
                string valor = txtBusquedaProd.Text.Trim()
                    .Replace("\r","")
                    .Replace("\n", "")
                    .Replace("\t", "");
                
                if(valor.Length > 2)
                {
                    buscar_Productos(valor);
                    
                }


                //txtBusquedaProd.Text = "";
                //txtBusquedaProd.Focus();
                // Coloca el cursor al inicio del texto (en la primera posición)
                //txtBusquedaProd.Select(); // El cursor se coloca al principio del texto
                
            }
        }

        private void lblBuscarCliente_Click(object sender, EventArgs e)
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

        //ubbigeos:
        private void LoadDepartamentos()
        {
            ////RN_Ubigeo obj = new RN_Ubigeo();
            //BD_Ubigeo obj = new BD_Ubigeo();
            //DataTable dato = new DataTable();


            //dato = obj.BD_Listar_Ubigeos();

            //var departamentos = dato.DefaultView.ToTable(true, "Departamento");
            //cbo_departamento.DisplayMember = "Departamento";
            //cbo_departamento.ValueMember = "Departamento";
            //cbo_departamento.DataSource = departamentos;

            

            //// Seleccionar "Lima" como valor predeterminado
            //DataRow row = departamentos.Select("Departamento = 'LIMA'").FirstOrDefault();
            //if (row != null)
            //{
            //    cbo_departamento.SelectedValue = row["Departamento"].ToString();
            //}

        }

        private void cbo_departamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selectedDepartamento = cbo_departamento.SelectedValue.ToString();
            //lbl_departamento.Text = selectedDepartamento; // Actualizar el Label
            //LoadProvincias(selectedDepartamento);//cbo_departamento.SelectedValue.ToString());


        }

        private void LoadProvincias(string departamento)
        {
            ////RN_Ubigeo obj = new RN_Ubigeo();
            //BD_Ubigeo obj = new BD_Ubigeo();
            //DataTable dato = new DataTable();
            //dato = obj.BD_Listar_Ubigeos();
            //// Filtrar las provincias según el departamento seleccionado
            //var provincias = dato.Select($"Departamento = '{departamento}'").CopyToDataTable().DefaultView.ToTable(true, "Provincia");
            //cboProvincia.DisplayMember = "Provincia";
            //cboProvincia.ValueMember = "Provincia";
            //cboProvincia.DataSource = provincias;



            //// Seleccionar "Lima" como valor predeterminado para la provincia
            //DataRow row = provincias.Select("Provincia = 'LIMA'").FirstOrDefault();
            //if (row != null)
            //{
            //    cboProvincia.SelectedValue = row["Provincia"].ToString();
            //}

        }

        private void LoadDistritos(string departamento, string provincia)
        {
            ////RN_Ubigeo obj = new RN_Ubigeo();
            //BD_Ubigeo obj = new BD_Ubigeo();
            //DataTable dato = new DataTable();
            //dato = obj.BD_Listar_Ubigeos();

            //var distritos = dato.Select($"Departamento = '{departamento}' AND Provincia = '{provincia}'").CopyToDataTable();
            //cbo_Distrito.DisplayMember = "Distrito";
            //cbo_Distrito.ValueMember = "Ubigeo";
            //cbo_Distrito.DataSource = distritos;

            //// Seleccionar "Lima" como valor predeterminado para el distrito
            //DataRow row = distritos.Select("Distrito = 'LIMA'").FirstOrDefault();
            //if (row != null)
            //{
            //    cbo_Distrito.SelectedValue = row["Ubigeo"].ToString();
            //}
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selectedProvincia = cboProvincia.SelectedValue.ToString();
            //lbl_provincia.Text = selectedProvincia; // Actualizar el Label

            //selectedDepartamento = cbo_departamento.SelectedValue.ToString();

            //LoadDistritos(selectedDepartamento, selectedProvincia);/*cbo_departamento.SelectedValue.ToString(), cboProvincia.SelectedValue.ToString()*/
        }

        private void cbo_Distrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbo_Distrito.SelectedValue != null)
            //{
            //    lbl_ubigOrigen.Text = cbo_Distrito.SelectedValue.ToString();
            //    // Obtener el nombre del distrito seleccionado
            //    DataRowView selectedRow = cbo_Distrito.SelectedItem as DataRowView;
            //    if (selectedRow != null)
            //    {
            //        lbl_distrito.Text = selectedRow["Distrito"].ToString();
            //    }

            //}
        }

        private void txtBusqProd_2_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{

            //    //lbl_buscarProd_Click(sender, e);
            //    if (txtBusqProd_2.Text.Trim().Length > 2)
            //    {
            //        buscar_Productos(txtBusqProd_2.Text);

            //    }
            //    txtBusqProd_2.Focus();
            //    // Coloca el cursor al inicio del texto (en la primera posición)
            //    txtBusqProd_2.Select(0, 0); // El cursor se coloca al principio del texto

            //}
        }

        private void txtBusqProd_2_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqProd_2.Text.Trim().Length > 2)
            {
                buscar_Productos(txtBusqProd_2.Text);
            }
        }

        private void txtBusqProd_2_Enter(object sender, EventArgs e)
        {

         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DiagnosticoPromocionesDesdeCSharp();
        }

        private void DiagnosticoPromocionesDesdeCSharp()
        {
            try
            {
                RN_Promocion objPromo = new RN_Promocion();
                DataTable promocionesActivas = objPromo.RN_Buscar_Promociones_Activas(null);

                if (promocionesActivas == null || promocionesActivas.Rows.Count == 0)
                {
                    MessageBox.Show("⚠️ No se recibieron promociones desde SQL.");
                    return;
                }

                MessageBox.Show($"✅ Total promociones recibidas en C#: {promocionesActivas.Rows.Count}");

                foreach (DataRow row in promocionesActivas.Rows)
                {
                    string idPromo = row.Table.Columns.Contains("IdPromocion") ? row["IdPromocion"].ToString() : "NULL";
                    string nombrePromo = row.Table.Columns.Contains("Nombre") ? row["Nombre"].ToString() : "NULL";
                    string tipo = row.Table.Columns.Contains("Tipo") ? row["Tipo"].ToString() : "NULL";

                    MessageBox.Show($"📦 IdPromocion: {idPromo}, Nombre: {nombrePromo}, Tipo: {tipo}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al hacer diagnóstico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void group_dp_Click(object sender, EventArgs e)
        {

        }

        private void cbo_tipoServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_tipoServer.SelectedIndex == 0)
            {
                lbl_server.Text = "0"; //server local 
            }
            if(cbo_tipoServer.SelectedIndex == 1)
            {
                lbl_server.Text = "1"; //server sunat 
            }
            if(cbo_tipoServer.SelectedIndex == 2)
            {
                lbl_server.Text = "3"; // server prueba
            }
        }

        private void timerBusqueda_Tick(object sender, EventArgs e)
        {
            timerBusqueda.Stop();

            string valor = txtBusquedaProd.Text.Trim()
                .Replace("\r", "")
                .Replace("\n", "")
                .Replace("\t", "");

            if(valor.Length > 2)
            {
                buscar_Productos(valor);
            }
            
        }
    }
}

