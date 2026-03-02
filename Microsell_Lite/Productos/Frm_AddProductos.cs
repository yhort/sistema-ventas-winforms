using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsell_Lite.Utilitarios;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using Microsell_Lite.Proveedor;
using Prj_Capa_Datos;

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
            cbo_Und.SelectedIndex =0;
            cbo_TipoAfectSunat.SelectedIndex = 0;

            chkControlarStock_CheckedChanged(null, null);

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
            //validar los numeros

            if (txt_Precom_Sol.Text.Trim() == "") { fil.Show(); ver.Lbl_msm1.Text = "Ingresa el precio de compra en soles"; ver.ShowDialog(); fil.Hide(); txt_Precom_Sol.Focus(); return false; }
            if (Convert.ToDouble(txt_Precom_Sol.Text) == 0) { fil.Show(); ver.Lbl_msm1.Text = "Ingresa el precio de compra en soles"; ver.ShowDialog(); fil.Hide(); txt_Precom_Sol.Focus(); return false; }

            if (txt_Frank.Text.Trim() == "") { fil.Show(); ver.Lbl_msm1.Text = "Ingresa el margen de utilidad del Producto"; ver.ShowDialog(); fil.Hide(); txt_Frank.Focus(); return false; }
            if (Convert.ToDouble(txt_Frank.Text) == 0) { fil.Show(); ver.Lbl_msm1.Text = "Ingresa el margen de utilidad del Producto"; ver.ShowDialog(); fil.Hide(); txt_Frank.Focus(); return false; }

            /*
            if (txt_PreVenta_mnr.Text.Trim() == "") { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el precio de venta menor"; ver.ShowDialog(); fil.Hide(); txt_PreVenta_mnr.Focus(); return false; }
            if (Convert.ToDouble(txt_PreVenta_mnr.Text) == 0) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el precio de venta menor"; ver.ShowDialog(); fil.Hide(); txt_PreVenta_mnr.Focus(); return false; }

            if (txt_PreVenta_myr.Text.Trim() == "") { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el precio de venta mayor"; ver.ShowDialog(); fil.Hide(); txt_PreVenta_myr.Focus(); return false; }
            if (Convert.ToDouble(txt_PreVenta_myr.Text) == 0) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el precio de venta mayor"; ver.ShowDialog(); fil.Hide(); txt_PreVenta_myr.Focus(); return false; }

            if (txt_PreVenta_dlr.Text.Trim() == "") { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el precio de venta en Dolar"; ver.ShowDialog(); fil.Hide(); txt_PreVenta_dlr.Focus(); return false; }

            if (txt_PreCompra_Dlr.Text.Trim() == "") { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el precio de compra en Dolar"; ver.ShowDialog(); fil.Hide(); txt_PreCompra_Dlr.Focus(); return false; }
            */
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
            txt_PreVenta_mnr.Text = "";


        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (Validar_Textobox() == true)
            {
                registrar_Producto();
                limpiarForm();
            }

            //// Si es producto, asignamos Stock, Peso, etc. Si es servicio, asignamos solo lo necesario
            //if (cbo_tipoProductoServicio.SelectedIndex == 0) // Producto
            //{
            //    pro.Stock = Convert.ToDouble(txt_Stock.Text);
            //    pro.PesoUnit = Convert.ToDouble(txt_peso.Text);
            //    pro.UtilidadUnit = Convert.ToDouble(txt_utilidad.Text);
            //}

            //else if (cbo_tipoProductoServicio.SelectedIndex == 1) // Servicio
            //{
            //    //pro.Duracion = Convert.ToInt32(txt_duracion.Text);
            //    pro.Costo = Convert.ToDouble(txt_costoServicio.Text);
            //    pro.PrecioVenta_Servicio = Convert.ToDouble(txt_precioVentaServicio.Text);
            //}

        }


        private void registrar_Producto()
        {
            RN_Productos obj = new RN_Productos();
            EN_Producto pro = new EN_Producto();

            try
            {
                pro.Idproducto = txt_idproducto.Text;
                pro.Idproveedor = lbl_idProvee.Text;
                pro.DescripcionGeneral = txt_nombreProduct.Text;
                pro.Frank = Convert.ToDouble(txt_Frank.Text);
                pro.PreCompra_Sol = Convert.ToDouble(txt_Precom_Sol.Text);
                pro.PreCompra_Dlr = Convert.ToDouble(txt_PreCompra_Dlr.Text);
                //pro.Stock = Convert.ToDouble(txt_Stock.Text);
                // Validar y asignar stock
                double stock = 0;
                if (!double.TryParse(txt_Stock.Text, out stock))
                {
                    MessageBox.Show("El stock ingresado no es válido.");
                    return;
                }
                pro.Stock = stock;
                pro.Idcategoria = Convert.ToInt32(lbl_idcateg.Text); //enteros por id
                pro.Idmarca = Convert.ToInt32(lbl_idmarca.Text);
                if (xFotoruta.Trim().Length < 5)
                {
                    pro.Foto = "-";
                }
                else
                {
                    pro.Foto = xFotoruta;
                }
                pro.PreVenta_Mnr = Convert.ToDouble(txt_PreVenta_mnr.Text);
                pro.PreVenta_Myr = Convert.ToDouble(txt_PreVenta_myr.Text);
                pro.PreVenta_Dolr = Convert.ToDouble(txt_PreVenta_dlr.Text);
                pro.UndMedida = cbo_Und.Text;
                pro.PesoUnit = Convert.ToDouble(txt_peso.Text);
                pro.UtilidadUnit = Convert.ToDouble(txt_utilidad.Text);
                pro.TipoProducto = cbo_tipoProd.Text;
                pro.ValorGeneral = 0;
                pro.CodTipoAfectacion_Sunat =  lbl_TipoAfectacion.Text;
                pro.TipoAfectacion_Sunat = cbo_TipoAfectSunat.Text;
                pro.PreventaLista = Convert.ToDecimal(txt_PreVenta_mnr.Text);

                if (chkControlarStock.Checked)
                {
                    pro.ControlaStock = true;
                }
                else
                {
                    pro.ControlaStock = false;
                }

                //pro.TipoProd_Sunat = cbo_tipoProd_Sunat.Text;

                obj.RN_Registrar_Producto(pro);

                if (BD_Productos.seguardo == true)
                {

                    if (cbo_tipoProd.SelectedIndex == 0)
                    {
                        //PARA REGISTRAR EL KARDEX:
                        Registrar_Kardex(txt_idproducto.Text);
                    }

                    RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo_Producto(4);

                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

                    fil.Show();
                    ok.Lbl_msm1.Text = "El Producto se ha Creado y Guardado Exitosamente";
                    ok.ShowDialog();
                    //MessageBox.Show("El producto se ha guardado exitosamente");
                    fil.Hide();

                    this.Tag = "A";
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas al guardar" + ex.Message);
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
                    return; //ya tiene kardex no hace falta crear otro 
                }
                else
                {
                    bool controlaStock = chkControlarStock.Checked;
                    string idkardex = RN_TipoDoc.RN_NroID(6);

                    obj.RN_Registrar_Kardex(idkardex, idprod, lbl_idProvee.Text);

                    if (BD_Kardex.seguardo == true)
                    {
                        //actualizar el sigueinte numero correlativo
                        RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(6);
                        //trabajamos con el detalle del kardex:
                        kr.Idkardex = idkardex;
                        kr.Item = 1;
                        kr.Doc_soporte = "000";
                        kr.TipoOperacion = "Inicio Kardex";
                        //se añadio cambios para ingresar stock al crear prod: 26/04/2023
                        kr.CantiDiferencial = "-";
                        kr.ImporteDiferencial = 0;

                        if (controlaStock)
                        {
                            //entradas
                            kr.Det_Operacion = "Inicio de Kardex";
                            kr.Cantidad_in = Convert.ToDouble(txt_Stock.Text);
                            kr.Precio_In = Convert.ToDouble(txt_Precom_Sol.Text);
                            kr.Total_In = Convert.ToDouble(txt_Stock.Text) * Convert.ToDouble(txt_Precom_Sol.Text);

                            //salidas;
                            kr.Cantidad_Out = 0;
                            kr.Precio_out = 0;
                            kr.Total_out = 0;

                            //saldos:
                            kr.Cantidad_saldo = Convert.ToDouble(txt_Stock.Text);//0
                            kr.Promedio = 0;
                            kr.Total_saldo = Convert.ToDouble(txt_Precom_Sol.Text) * kr.Cantidad_saldo;
                            kr.Observacion = "-";

                        }
                        else
                        {
                            //entradas
                            kr.Det_Operacion = "Inicio de Kardex";
                            kr.Cantidad_in = Convert.ToDouble(txt_Stock.Text);
                            kr.Precio_In = Convert.ToDouble(txt_Precom_Sol.Text);
                            kr.Total_In = Convert.ToDouble(txt_Stock.Text) * Convert.ToDouble(txt_Precom_Sol.Text);

                            //salidas;
                            kr.Cantidad_Out = 0;
                            kr.Precio_out = 0;
                            kr.Total_out = 0;

                            //saldos:
                            kr.Cantidad_saldo = Convert.ToDouble(txt_Stock.Text);//0
                            kr.Promedio = 0;
                            kr.Total_saldo = Convert.ToDouble(txt_Precom_Sol.Text) * kr.Cantidad_saldo;
                            kr.Observacion = "Producto SIN Control de Stock";

                        }

                        obj.RN_Registrar_Detalle_Kardex(kr);

                        if (BD_Kardex.detsaved == true)
                        {
                            //obj.RN_Registrar_Detalle_Kardex(kr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salio mal: " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                Utilidad_Unit = Convert.ToDouble(txt_PreVenta_mnr.Text) - Convert.ToDouble(txt_Precom_Sol.Text);
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

            txt_PreVenta_mnr.Text = txt_PreVenta_mnr.Text.Replace(",", ".");
            txt_PreVenta_mnr.SelectionStart = txt_PreVenta_mnr.Text.Length;

            try
            {

                if (txt_Precom_Sol.Text.Trim() == "") return;
                if (txt_Frank.Text.Trim() == "") return;

                double Precom_Sol = 0;

                Precom_Sol = Convert.ToDouble(txt_PreVenta_mnr.Text) / Convert.ToDouble(txt_Precom_Sol.Text);
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
                txt_PreVenta_mnr.Text = Precom_Sol.ToString("###0.00");

                //hallar precio de venta en dolar
                precioVenta_dolar = Convert.ToDouble(txt_PreCompra_Dlr.Text) * Convert.ToDouble(txt_Frank.Text);
                txt_PreVenta_dlr.Text = precioVenta_dolar.ToString("###0.00");


                //calcular la utilidad
                Utilidad_Unit = Convert.ToDouble(txt_PreVenta_mnr.Text) - Convert.ToDouble(txt_Precom_Sol.Text);
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
                if (string.IsNullOrWhiteSpace(txt_Stock.Text) || txt_Stock.Text == "0")
                {
                    txt_Stock.Text = "1"; // Valor predeterminado si vas a controlar stock
                }
            }
        }
    }
}
