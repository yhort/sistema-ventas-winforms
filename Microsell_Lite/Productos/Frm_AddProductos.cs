using DocumentFormat.OpenXml.Presentation;
using Microsell_Lite.Proveedor;
using Microsell_Lite.Utilitarios;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsell_Lite.Productos
{
    public partial class Frm_AddProductos : Form
    {
        public Frm_AddProductos()
        {
            InitializeComponent();
            
        }
        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            double tipocambio = 0;
            tipocambio = RN_TipoDoc.RN_Leer_TipoCambio(7);
            lbl_tipoCambio.Text = tipocambio.ToString("###0.00");
            txt_idproducto.Text = RN_TipoDoc.RN_NroID(4);

            //datos por defecto:
            txt_Provedr.Text = "OTROS";
            lbl_idProvee.Text = "CGRR";

            txt_marca.Text = "GENERAL";
            lbl_idmarca.Text = "1";
            txt_categoria.Text = "GENERAL";
            lbl_idcateg.Text = "1";
            cbo_tipoProd.SelectedIndex = 0; 
            //cbo_Und.SelectedIndex =0;
            cbo_TipoAfectSunat.SelectedIndex = 0;

            chkControlarStock_CheckedChanged(null, null);
            CargarAbreviaturas();
        }

        private void CargarAbreviaturas()
        {
            cbo_Und.Items.Clear();
            cbo_Und.Items.Add("UND");
            cbo_Und.Items.Add("CJA");
            cbo_Und.Items.Add("PCK");
            cbo_Und.Items.Add("FDO");
            cbo_Und.Items.Add("DOC");
            cbo_Und.Items.Add("BLS");
            cbo_Und.Items.Add("SAC");
            cbo_Und.Items.Add("PQT");

            cbo_Und.DropDownStyle = ComboBoxStyle.DropDown;
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
            this.Tag = "";
            this.Close();
        }

        string xFotoruta ="";
        private void lbl_Abrir_Click(object sender, EventArgs e)
        {
            var FilePath = string.Empty;

            try
            {
                if(openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    xFotoruta = openFileDialog1.FileName;
                    piclogo.Load(xFotoruta);
                }
            }
            catch (Exception ex)
            {
                piclogo.Load(Application.StartupPath + @"\user115.png");
                xFotoruta = Application.StartupPath + @"\user115.png";
                MessageBox.Show("Error al Guardar imagen de productos" + ex.Message);
                
            }
        }

        private void piclogo_Click(object sender, EventArgs e)
        {
            var FilePath = string.Empty;

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    xFotoruta = openFileDialog1.FileName;
                    piclogo.Load(xFotoruta);
                }
            }
            catch (Exception ex)
            {
                piclogo.Load(Application.StartupPath + @"\user115.png");
                xFotoruta = Application.StartupPath + @"\user115.png";
                MessageBox.Show("Error al Guardar imagen productos" + ex.Message);

            }
        }

        //1-Inicio-metodo para valida las cajas de texto.
        private bool Validar_Textobox() 
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (txt_idproducto.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_msm1.Text = "Ingresa o Genera el ID del Producto"; ver.ShowDialog(); fil.Hide(); txt_idproducto.Focus(); return false; }
            if (txt_nombreProduct.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_msm1.Text = "Ingresa el Nombre del Producto"; ver.ShowDialog(); fil.Hide(); txt_nombreProduct.Focus(); return false; }
            if (lbl_idProvee.Text.Trim() == "-") { fil.Show(); ver.Lbl_msm1.Text = "Ingresa el ID del Proveedor"; ver.ShowDialog(); fil.Hide(); lbl_busProve.Focus(); return false; }
            if (lbl_idmarca.Text.Trim() == "-") { fil.Show(); ver.Lbl_msm1.Text = "Ingresa el ID de la marca"; ver.ShowDialog(); fil.Hide(); lbl_busMarca.Focus(); return false; }

            if (lbl_idcateg.Text.Trim() == "-") { fil.Show(); ver.Lbl_msm1.Text = "Ingresa el ID de la Categoria"; ver.ShowDialog(); fil.Hide(); lbl_busProve.Focus(); return false; }

            if (cbo_tipoProd.SelectedIndex == -1) { fil.Show(); ver.Lbl_msm1.Text = "Selecciona el Tipo de Producto"; ver.ShowDialog(); fil.Hide(); cbo_tipoProd.Focus(); return false; }
            //if (cbo_tipoProd_Sunat.SelectedIndex == -1) { fil.Show(); ver.Lbl_Msm1.Text = "Selecciona el Tipo de Producto Sunat - NIU PRODUCTO - ZZ SERVICIO"; ver.ShowDialog(); fil.Hide(); cbo_tipoProd_Sunat.Focus(); return false; }
            if (cbo_Und.SelectedIndex == -1) { fil.Show(); ver.Lbl_msm1.Text = "Selecciona el Tipo de Unidad de medidad del Producto"; ver.ShowDialog(); fil.Hide(); cbo_Und.Focus(); return false; }
            if (cbo_TipoAfectSunat.SelectedIndex == -1) { fil.Show(); ver.Lbl_msm1.Text = "Selecciona el Tipo Producto si es Gravado o Exonerado para le Venta"; ver.ShowDialog(); fil.Hide(); cbo_TipoAfectSunat.Focus(); return false; }
           
            return true; //en caso la condicion no se cumpla.  --Fin
        }

        //2-Inicio ---Metodo para registrar datos del proveedor
 
        private void limpiarForm()
        {

            txt_idproducto.Text = "";
            txt_nombreProduct.Text = "";
            txt_categoria.Text = "";
            txt_Frank.Text = "0";
            txt_Provedr.Text = "";
            xFotoruta = "";
            txt_peso.Text = "0";
            txt_Precom_Sol.Text = "";
            txt_PrecioVentaBase.Text = "";
            txt_Stock.Text = "0";

        }
        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (Validar_Textobox() == true)
            {
                bool guardado = registrar_Producto();

                if (guardado)
                {
                    decimal stockInicial = 0;
                    decimal.TryParse(txt_Stock.Text.Trim(), out stockInicial);

                    // Siempre crear presentación base automática
                    int idPresentacionBase = Crear_Presentacion_Base();

                    if (idPresentacionBase > 0)
                    {
                        if (chkControlarStock.Checked && stockInicial > 0)
                        {
                            Registrar_StockFisico_Base(
                                txt_idproducto.Text.Trim(),
                                idPresentacionBase,
                                stockInicial
                            );

                            Registrar_Kardex(txt_idproducto.Text.Trim());
                        }
                    }

                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Sino sino = new Frm_Sino();

                    fil.Show();
                    sino.lbl_Nomalgo.Text = "";
                    sino.Lbl_msm1.Text = "Producto registrado correctamente.\n¿Deseas agregar más presentaciones?";
                    sino.ShowDialog();
                    fil.Hide();

                    if (sino.Tag != null && sino.Tag.ToString() == "Si")
                    {
                        Abrir_Form_Presentaciones();
                    }

                    limpiarForm();
                    this.Tag = "A";
                    this.Close();
                }
            }
        }

        private bool registrar_Producto()
        {
            RN_Productos obj = new RN_Productos();
            EN_Producto pro = new EN_Producto();

            try
            {
                double stock = 0;
                double costoBase = 0;
                double precioVentaBase = 0;
                double peso = 0;

                if (!double.TryParse(txt_Stock.Text.Trim(), out stock))
                {
                    MessageBox.Show("El stock ingresado no es válido.");
                    txt_Stock.Focus();
                    return false;
                }

                if (!double.TryParse(txt_Precom_Sol.Text.Trim(), out costoBase))
                {
                    costoBase = 0;
                }

                if (!double.TryParse(txt_PrecioVentaBase.Text.Trim(), out precioVentaBase))
                {
                    precioVentaBase = 0;
                }

                if (!double.TryParse(txt_peso.Text.Trim(), out peso))
                {
                    peso = 0;
                }

                string idProducto = txt_idproducto.Text.Trim();
                string skuProducto = GenerarSKUProducto(idProducto);

                pro.Idproducto = idProducto;
                pro.Idproveedor = lbl_idProvee.Text;
                pro.DescripcionGeneral = txt_nombreProduct.Text.Trim();

                pro.Frank = costoBase > 0 ? precioVentaBase / costoBase : 0;

                pro.PreCompra_Sol = costoBase;
                pro.PreCompra_Dlr = 0;

                pro.Stock = stock;

                pro.Idcategoria = Convert.ToInt32(lbl_idcateg.Text);
                pro.Idmarca = Convert.ToInt32(lbl_idmarca.Text);

                pro.Foto = xFotoruta.Trim().Length < 5 ? "-" : xFotoruta;

                pro.PreVenta_Mnr = precioVentaBase;
                pro.PreVenta_Myr = 0;
                pro.PreVenta_Dolr = 0;

                pro.UndMedida = cbo_Und.Text.Trim().ToUpper();
                pro.PesoUnit = peso;

                pro.UtilidadUnit = precioVentaBase - costoBase;
                pro.TipoProducto = cbo_tipoProd.Text;
                pro.ValorGeneral = stock * costoBase;

                pro.CodTipoAfectacion_Sunat = lbl_TipoAfectacion.Text;
                pro.TipoAfectacion_Sunat = cbo_TipoAfectSunat.Text;
                pro.PreventaLista = Convert.ToDecimal(precioVentaBase);

                // SKU y código interno del producto maestro
                pro.SkuProducto = skuProducto;
                pro.CodgioBarraPrincipal = skuProducto;

                pro.ControlaStock = chkControlarStock.Checked;

                obj.RN_Registrar_Producto(pro);

                if (BD_Productos.seguardo == true)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo_Producto(4);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas al guardar: " + ex.Message);
                return false;
            }
        }

        private void Abrir_Form_Presentaciones()
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_ProductoPresentaciones frm = new Frm_ProductoPresentaciones();

            frm.IdProducto = txt_idproducto.Text.Trim();
            frm.NombreProducto = txt_nombreProduct.Text.Trim();
            frm.EsFlujoProducto = true;
            frm.AbrirEnRegistroDirecto = true;
            frm.Abrev_und = cbo_Und.Text; 


            fil.Show();
            frm.ShowDialog();
            fil.Hide();
        }

        private int Crear_Presentacion_Base()
        {
            try
            {
                RN_ProductoPresentacion obj = new RN_ProductoPresentacion();
                EN_ProductoPresentacion pre = new EN_ProductoPresentacion();

                string idProducto = txt_idproducto.Text.Trim();
                string unidadBase = cbo_Und.Text.Trim().ToUpper();

                decimal costoBase = 0;
                decimal precioVentaBase = 0;

                decimal.TryParse(txt_Precom_Sol.Text.Trim(), out costoBase);
                decimal.TryParse(txt_PrecioVentaBase.Text.Trim(), out precioVentaBase);

                decimal equivalencia = 1;

                string sku = GenerarSKUProductoPresentacion(
                    idProducto,
                    unidadBase,
                    equivalencia
                );

                string codigoBarra = GenerarCodigoBarraInterno(sku);

                pre.IdProducto = idProducto;
                pre.NombrePresentacion = unidadBase;
                pre.Abreviatura = unidadBase;
                pre.Equivalencia = equivalencia;

                pre.PrecioCompra = costoBase;
                pre.PrecioVentaMinorista = precioVentaBase;
                pre.PrecioVentaMayorista = 0;
                pre.CantMinMayorista = 0;

                pre.SKU = sku;
                pre.CodigoBarra = codigoBarra;

                pre.EsBase = true;
                pre.PermiteCompra = true;
                pre.PermiteVenta = true;
                pre.Activo = true;

                obj.RN_Registrar_ProductoPresentacion(pre);

                DataTable dt = obj.RN_Listar_ProductoPresentacion_porProducto(idProducto, 1);

                foreach (DataRow dr in dt.Rows)
                {
                    bool esBase = Convert.ToBoolean(dr["EsBase"]);

                    if (esBase)
                    {
                        return Convert.ToInt32(dr["IdPresentacion"]);
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear presentación base: " + ex.Message,
                    "Presentación Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
        }
        private void Registrar_StockFisico_Base(string idProducto, int idPresentacion, decimal stockInicial)
        {
            try
            {
                RN_Productos obj = new RN_Productos();

                obj.RN_Sumar_StockPresentacion(
                    1,
                    idProducto.Trim(),
                    idPresentacion,
                    stockInicial
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar stock físico base: " + ex.Message,
                    "Stock Presentación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnAgregar_Ser_Click(object sender, EventArgs e)
        {
        }
        private void Registrar_Kardex(string idprod)
        {
            RN_Kardex obj = new RN_Kardex();
            EN_Kardex kr = new EN_Kardex();

            try
            {
                if (obj.RN_Verificar_Producto_siTieneKardex(idprod) == true)
                {
                    return;
                }

                double stockInicial = 0;
                double costoBase = 0;

                double.TryParse(txt_Stock.Text.Trim(), out stockInicial);
                double.TryParse(txt_Precom_Sol.Text.Trim(), out costoBase);

                if (!chkControlarStock.Checked || stockInicial <= 0)
                {
                    return;
                }

                string idkardex = RN_TipoDoc.RN_NroID(6);

                obj.RN_Registrar_Kardex(idkardex, idprod, lbl_idProvee.Text);

                if (BD_Kardex.seguardo == true)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(6);

                    kr.Idkardex = idkardex;
                    kr.Item = 1;
                    kr.Doc_soporte = "000";
                    kr.TipoOperacion = "InicioKardex";
                    kr.Det_Operacion = "Inicio de Kardex";

                    kr.Cantidad_in = stockInicial;
                    kr.Precio_In = costoBase;
                    kr.Total_In = stockInicial * costoBase;

                    kr.Cantidad_Out = 0;
                    kr.Precio_out = 0;
                    kr.Total_out = 0;

                    kr.Cantidad_saldo = stockInicial;
                    kr.Promedio = costoBase;
                    kr.Total_saldo = stockInicial * costoBase;

                    kr.CantiDiferencial = "-";
                    kr.ImporteDiferencial = 0;
                    kr.Observacion = "Stock inicial desde registro de producto";

                    obj.RN_Registrar_Detalle_Kardex(kr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salió mal: " + ex.Message,
                    "Kardex", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            double tipocambio = 0;
            tipocambio = RN_TipoDoc.RN_Leer_TipoCambio(7);
            lbl_tipoCambio.Text = tipocambio.ToString("###0.00");
            txt_idproducto.Text = RN_TipoDoc.RN_NroID(4);
        }

        private void lbl_busProve_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_ListadoProveedor lis = new Frm_ListadoProveedor();

            fil.Show();
            lis.ShowDialog();

            fil.Hide();

            if (lis.Tag.ToString() == "A")
            {
                txt_Provedr.Text = lis.lbl_nom.Text;
                lbl_idProvee.Text = lis.lbl_id.Text;
            }
        }

        private void lbl_busMarca_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Marca mar = new Frm_Marca();

            fil.Show();
            mar.ShowDialog();
            fil.Hide();

            if (mar.Tag.ToString() == "A")
            {
                txt_marca.Text = mar.txt_nommarca.Text;
                lbl_idmarca.Text = mar.txt_idmarca.Text;

            }
        }

        private void lbl_busCat_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Categoria cat = new Frm_Categoria();

            fil.Show();
            cat.ShowDialog();
            fil.Hide();

            if (cat.Tag.ToString() == "A")
            {
                txt_categoria.Text = cat.txt_nomcateg.Text;
                lbl_idcateg.Text = cat.txt_idcateg.Text;

            }
        }

        private void txt_Precom_Sol_TextChanged(object sender, EventArgs e)
        {
            txt_Precom_Sol.Text = txt_Precom_Sol.Text.Replace(",", ".");
            txt_Precom_Sol.SelectionStart = txt_Precom_Sol.Text.Length;
        }

        //metodo para ingresar solo numeros desde asci utilitarios
        private void txt_Precom_Sol_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_Frank_TextChanged(object sender, EventArgs e)
        {
            txt_Frank.Text = txt_Frank.Text.Replace(",", ".");
            txt_Frank.SelectionStart = txt_Frank.Text.Length;


            try
            {
                if (txt_Frank.Text.Trim() == "") return;
                if (txt_Precom_Sol.Text.Trim() == "") return;

                double Precom_Sol = 0;
                double Utilidad_Unit = 0;

                //Precom_Sol = Convert.ToDouble(txt_Precom_Sol.Text) * Convert.ToDouble(txt_Frank.Text);
                //txt_PreVenta_mnr.Text = Precom_Sol.ToString("###0.00");

                //Precom_Sol = Convert.ToDouble(txt_PreVenta_mnr.Text) / Convert.ToDouble(txt_Precom_Sol.Text);
                //txt_Frank.Text = Precom_Sol.ToString("###0.00");

                //calcular la utilidad :
                Utilidad_Unit = Convert.ToDouble(txt_PrecioVentaBase.Text) - Convert.ToDouble(txt_Precom_Sol.Text);
                txt_utilidad.Text = Utilidad_Unit.ToString("###0.00");

                //nw calculo para colocar el precio de venta y calcular automatico el margen.


            }
            catch (Exception ex)
            {

                string sms = ex.Message;
                
            }
        }

        private void txt_PreVenta_mnr_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_PreVenta_mnr_TextChanged(object sender, EventArgs e)
        {

            txt_PrecioVentaBase.Text = txt_PrecioVentaBase.Text.Replace(",", ".");
            txt_PrecioVentaBase.SelectionStart = txt_PrecioVentaBase.Text.Length;

            try
            {

                if (txt_Precom_Sol.Text.Trim() == "") return;
                if (txt_Frank.Text.Trim() == "") return;

                double Precom_Sol = 0;

                Precom_Sol = Convert.ToDouble(txt_PrecioVentaBase.Text) / Convert.ToDouble(txt_Precom_Sol.Text);
                txt_Frank.Text = Precom_Sol.ToString();

            }
            catch (Exception ex)
            {
                string sms = ex.Message;
            }

        }

        private void txt_PreVenta_myr_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_PreVenta_myr_TextChanged(object sender, EventArgs e)
        {
            txt_PreVenta_myr.Text = txt_PreVenta_myr.Text.Replace(",", ".");
            txt_PreVenta_myr.SelectionStart = txt_PreVenta_myr.Text.Length;
        }

        private void txt_PreVenta_dlr_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_PreVenta_dlr_TextChanged(object sender, EventArgs e)
        {
            txt_PreVenta_dlr.Text = txt_PreVenta_dlr.Text.Replace(",", ".");
            txt_PreVenta_dlr.SelectionStart = txt_PreVenta_dlr.Text.Length;
        }

        private void txt_PreCompra_Dlr_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_PreCompra_Dlr_TextChanged(object sender, EventArgs e)
        {
            //calcular el precio de venta en soles:
            try
            {
                if (txt_Frank.Text.Trim() == "") return;
                if (txt_PreCompra_Dlr.Text.Trim() == "") return;

                double Precom_Sol = 0;
                double precioVenta_dolar = 0;
                double Utilidad_Unit = 0;

                //Hallar el precio de compra en soles
                Precom_Sol = Convert.ToDouble(txt_PreCompra_Dlr.Text) * Convert.ToDouble(lbl_tipoCambio.Text);
                txt_Precom_Sol.Text = Precom_Sol.ToString("###0.00");

                //hallar el precio de venta al por menor
                Precom_Sol = Convert.ToDouble(txt_Precom_Sol.Text) * Convert.ToDouble(txt_Frank.Text);
                txt_PrecioVentaBase.Text = Precom_Sol.ToString("###0.00");

                //hallar precio de venta en dolar
                precioVenta_dolar = Convert.ToDouble(txt_PreCompra_Dlr.Text) * Convert.ToDouble(txt_Frank.Text);
                txt_PreVenta_dlr.Text = precioVenta_dolar.ToString("###0.00");


                //calcular la utilidad
                Utilidad_Unit = Convert.ToDouble(txt_PrecioVentaBase.Text) - Convert.ToDouble(txt_Precom_Sol.Text);
                //10.50 - 12.0 saca utilidad ejmplo ganancia
                txt_utilidad.Text = Utilidad_Unit.ToString("###0.00");
            }
            catch (Exception ex)
            {
                string sms = ex.Message;
            }
        }

        private void chkbx_Dolar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_Dolar.Checked == true)
            {
                txt_PreCompra_Dlr.Enabled = true;
                txt_PreCompra_Dlr.Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txt_idproducto.Text = "";
                txt_idproducto.Enabled = true;
                txt_idproducto.Focus();

            }
            else
            {
                txt_idproducto.Text = "";
                txt_idproducto.Enabled = false;
                txt_idproducto.Text = RN_TipoDoc.RN_NroID(4);
            }
        }

        private void cbo_tipoProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_tipoProd.SelectedIndex == 0)
            {
                cbo_Und.SelectedIndex = 0;
                txt_peso.Enabled = true; // se agrega deacuerdo a la necesidad del cliente
            }
            else
            {
                txt_peso.Enabled = false;
                cbo_Und.SelectedIndex = 0;

            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void cbo_TipoAfectSunat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_TipoAfectSunat.SelectedIndex == 0)
            {
                lbl_TipoAfectacion.Text = "10"; //10-Gravaado

            }
            else if (cbo_TipoAfectSunat.SelectedIndex == 1)
            {
                lbl_TipoAfectacion.Text = "20";//20-Exonerado
            }
        }

        private void chkControlarStock_CheckedChanged(object sender, EventArgs e)
        {
            bool controla = chkControlarStock.Checked;
            txt_Stock.Enabled = controla;
            label19.Enabled = controla;

            if (!controla)
            {
                txt_Stock.Text = "0";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txt_Stock.Text)) //|| txt_Stock.Text == "0")
                {
                    /*txt_Stock.Text = "1";*/ // Valor predeterminado si vas a controlar stock
                    txt_Stock.Text = "0";
                    //txt_Stock.Enabled = false;
                }
            }
        }

        private void btnPresentaciones_Click(object sender, EventArgs e)
        {
            if (txt_idproducto.Text.Trim() == "")
            {
                MessageBox.Show("Primero registra o selecciona el producto.");
                return;
            }

            Frm_Filtro fil = new Frm_Filtro();
            Frm_ProductoPresentaciones frm = new Frm_ProductoPresentaciones();
            frm.IdProducto = txt_idproducto.Text.Trim();
            frm.NombreProducto = txt_nombreProduct.Text.Trim();
            //frm.lblTitulo.Text = "Registrar presentación del Producto";
            frm.EsFlujoProducto = true;
            frm.AbrirEnRegistroDirecto = true;
            frm.cboAbreviatura.SelectedIndex = cbo_Und.SelectedIndex;

            fil.Show();
            frm.ShowDialog();
            fil.Hide();
  
            
        }

        private string LimpiarTextoCodigo(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return "";

            string limpio = texto.Trim().ToUpper();

            limpio = limpio.Replace("Á", "A")
                           .Replace("É", "E")
                           .Replace("Í", "I")
                           .Replace("Ó", "O")
                           .Replace("Ú", "U")
                           .Replace("Ñ", "N");

            limpio = limpio.Replace(" ", "")
                           .Replace("/", "")
                           .Replace(".", "")
                           .Replace(",", "");

            return limpio;
        }

        private string GenerarSKUProducto(string idProducto)
        {
            return LimpiarTextoCodigo(idProducto);
        }

        private string GenerarSKUProductoPresentacion(string idProducto, string abreviatura, decimal equivalencia)
        {
            string id = LimpiarTextoCodigo(idProducto);
            string abrev = LimpiarTextoCodigo(abreviatura);

            if (string.IsNullOrWhiteSpace(abrev))
                abrev = "UND";

            if (equivalencia > 1)
            {
                string equivTexto = equivalencia.ToString("0.####")
                                                .Replace(".", "")
                                                .Replace(",", "");

                return id + "-" + abrev + equivTexto;
            }

            return id + "-" + abrev;
        }

        private string GenerarCodigoBarraInterno(string sku)
        {
            return sku; // Code128 permite letras y números
        }
    }
}
