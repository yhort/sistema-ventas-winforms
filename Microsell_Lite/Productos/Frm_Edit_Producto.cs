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
using Microsell_Lite.Proveedor;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using Prj_Capa_Datos;
using System.IO;

namespace Microsell_Lite.Productos
{
    public partial class Frm_Edit_Producto : Form
    {
        public  Frm_Edit_Producto()
        {
            InitializeComponent();
        }

        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            Double tipocambio = 0;
            tipocambio = RN_TipoDoc.RN_Leer_TipoCambio(7);
            lbl_tipoCambio.Text = tipocambio.ToString("###0.00");
            Buscar_Productopara_Editar(this.Tag.ToString());
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

        private void Buscar_Productopara_Editar(string idprodcto)
        {
            RN_Productos obj = new RN_Productos();
            DataTable data = new DataTable();
            string xxidprod = "";

            try
            {

                data = obj.RN_Buscar_Productos(idprodcto);
                if (data.Rows.Count > 0)
                {

                    xxidprod = Convert.ToString(data.Rows[0]["Id_Pro"]);
                    txt_idprodcto.Text = xxidprod.Trim(); //para quitar espacios vacio en blanco
                    txt_nomProd.Text = Convert.ToString(data.Rows[0]["Descripcion_Larga"]);
                    cbo_tipoProd.Text = Convert.ToString(data.Rows[0]["TipoProdcto"]);
                    Cbo_Und.Text = Convert.ToString(data.Rows[0]["UndMedida"]).Trim();//cuando el campo es char, usar trim() para borrar espacios                  
                    txt_PreCompra_Sol.Text = Convert.ToString(data.Rows[0]["Pre_CompraS"]);
                    txt_PreCompra_Dlr.Text = Convert.ToString(data.Rows[0]["Pre_Compra$"]);
                    txt_Frank.Text = Convert.ToString(data.Rows[0]["FRANK"]);
                    txt_PreVenta_mnr.Text = Convert.ToString(data.Rows[0]["Pre_vntaxMenor"]);
                    txt_PreVenta_myr.Text = Convert.ToString(data.Rows[0]["Pre_vntaxMayor"]);
                    txt_PreVenta_dlr.Text = Convert.ToString(data.Rows[0]["Pre_Vntadolar"]);
                    txt_peso.Text = Convert.ToString(data.Rows[0]["PesoUnit"]);
                    txt_utili.Text = Convert.ToString(data.Rows[0]["UtilidadUnit"]);

                    lbl_idcat.Text = Convert.ToString(data.Rows[0]["Id_Cat"]);
                    lbl_idmar.Text = Convert.ToString(data.Rows[0]["Id_Marca"]);
                    lbl_idProvee.Text = Convert.ToString(data.Rows[0]["IDPROVEE"]);

                    txt_provee.Text = Convert.ToString(data.Rows[0]["NOMBRE"]);
                    txt_marca.Text = Convert.ToString(data.Rows[0]["Marca"]);
                    txt_categoria.Text = Convert.ToString(data.Rows[0]["Categoria"]);
                    cbo_TipoAfectSunat.Text = Convert.ToString(data.Rows[0]["Tipo_Afectacion"]);
                    cbo_TipoAfectSunat.Text = Convert.ToString(data.Rows[0]["CodTipo_Afectacion"]);

                    //xFotoruta = Convert.ToString(data.Rows[0]["FOTO"]);

                    if (File.Exists(xFotoruta) == false)
                    {
                        piclogo.Image = Properties.Resources.reg15;
                    }
                    else
                    {
                        piclogo.Load(xFotoruta);

                    }

                    txt_nomProd.Focus();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Leer los Datos: " + ex.Message, "Form Add Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        string xFotoruta="";

        private void lbl_Abrir_Click(object sender, EventArgs e)
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
                MessageBox.Show("Error al Guardar el Personal" + ex.Message);

            }


        }


        private bool Validar_Textobox()
        {

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();

            if (txt_idprodcto.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa o Genera el ID del Producto"; ver.ShowDialog(); fil.Hide(); txt_idprodcto.Focus(); return false; }
            if (txt_nomProd.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el Nombre "; ver.ShowDialog(); fil.Hide(); txt_nomProd.Focus(); return false; }
            if (lbl_idProvee.Text.Trim() == "-") { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el ID del Proveedor"; ver.ShowDialog(); fil.Hide(); lbl_busProve.Focus(); return false; }
            if (lbl_idmar.Text.Trim() == "-") { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el ID de la marca"; ver.ShowDialog(); fil.Hide(); lbl_busProve.Focus(); return false; }

            if (lbl_idcat.Text.Trim() == "-") { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el ID de la Categoria"; ver.ShowDialog(); fil.Hide(); lbl_busProve.Focus(); return false; }

            if (cbo_tipoProd.SelectedIndex == -1) { fil.Show(); ver.Lbl_Msm1.Text = "Selecciona el Tipo de Producto"; ver.ShowDialog(); fil.Hide(); cbo_tipoProd.Focus(); return false; }
            //if (Cbo_Und.SelectedIndex == -1) { fil.Show(); ver.Lbl_Msm1.Text = "Selecciona el Tipo de Unidad de medidad del Producto"; ver.ShowDialog(); fil.Hide(); Cbo_Und.Focus(); return false; }
            if (cbo_TipoAfectSunat.SelectedIndex == -1) { fil.Show(); ver.Lbl_Msm1.Text = "Selecciona el Tipo Producto si es Gravado o Exonerado para le Venta"; ver.ShowDialog(); fil.Hide(); cbo_TipoAfectSunat.Focus(); return false; }

            //validar los numeros

            if (txt_PreCompra_Sol.Text.Trim ()=="") { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el precio de compra en soles";ver.ShowDialog(); fil.Hide(); txt_PreCompra_Sol.Focus(); return false; }
            if (Convert.ToDouble( txt_PreCompra_Sol.Text) == 0) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el precio de compra en soles";ver.ShowDialog(); fil.Hide(); txt_PreCompra_Sol.Focus(); return false; }

            if (txt_Frank.Text.Trim() == "") { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el margen de utilidad del Producto"; ver.ShowDialog(); fil.Hide(); txt_Frank.Focus(); return false; }
            if (Convert.ToDouble(txt_Frank.Text) == 0) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el margen de utilidad del Producto"; ver.ShowDialog(); fil.Hide(); txt_Frank.Focus(); return false; }


            if (txt_PreVenta_mnr.Text.Trim() == "") { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el precio de venta menor"; ver.ShowDialog(); fil.Hide(); txt_PreVenta_mnr.Focus(); return false; }
            if (Convert.ToDouble(txt_PreVenta_mnr.Text) == 0) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el precio de venta menor"; ver.ShowDialog(); fil.Hide(); txt_PreVenta_mnr.Focus(); return false; }

            //if (txt_PreVenta_myr.Text.Trim() == "") { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el precio de venta mayor"; ver.ShowDialog(); fil.Hide(); txt_PreVenta_myr.Focus(); return false; }
            //if (Convert.ToDouble(txt_PreVenta_myr.Text) == 0) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el precio de venta mayor"; ver.ShowDialog(); fil.Hide(); txt_PreVenta_myr.Focus(); return false; }

            //if (txt_PreVenta_dlr.Text.Trim() == "") { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el precio de venta en Dolar"; ver.ShowDialog(); fil.Hide(); txt_PreVenta_dlr.Focus(); return false; }

            //if (txt_PreCompra_Dlr.Text.Trim() == "") { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el precio de compra en Dolar"; ver.ShowDialog(); fil.Hide(); txt_PreCompra_Dlr.Focus(); return false; }            

            return true;
        }

      

        private void limpiarForm()
        {

            txt_Frank.Text = "";
            txt_idprodcto.Text = "";
            txt_nomProd.Text = "";
            txt_categoria.Text = "";
            
            txt_Frank.Text = "";
            txt_provee.Text = "";  
            xFotoruta = "";
            txt_peso.Text = "";

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
                MessageBox.Show("Error al Guardar el Personal" + ex.Message);

            }
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (Validar_Textobox() == true)
            {
                registrar_Producto();
            }
        }

        private void registrar_Producto()
        {

            RN_Productos obj = new RN_Productos();
            EN_Producto pro = new EN_Producto();

            try
            {
                pro.Idproducto = txt_idprodcto.Text;
                pro.Idproveedor = lbl_idProvee.Text;
                pro.DescripcionGeneral = txt_nomProd.Text;
                pro.Frank = Convert.ToDouble(txt_Frank.Text);
                pro.PreCompra_Sol = Convert.ToDouble(txt_PreCompra_Sol.Text);
                pro.PreCompra_Dlr = Convert.ToDouble(txt_PreCompra_Dlr.Text);
                pro.Idcategoria = Convert.ToInt32 (lbl_idcat.Text);
                pro.Idmarca = Convert.ToInt32 ( lbl_idmar.Text);
                if(xFotoruta.Trim().Length <5)
                {
                    pro.Foto = "";
                }
                else
                {
                    pro.Foto = xFotoruta;
                }
                pro.PreVenta_Mnr = Convert.ToDouble(txt_PreVenta_mnr.Text);
                pro.PreVenta_Myr = Convert.ToDouble(txt_PreVenta_myr.Text);
                pro.PreVenta_Dolr = Convert.ToDouble(txt_PreVenta_dlr.Text);
                pro.UndMedida = Cbo_Und.Text;
                pro.PesoUnit = Convert.ToDouble(txt_peso.Text);
                pro.UtilidadUnit = Convert.ToDouble(txt_utili.Text);
                pro.TipoProducto = cbo_tipoProd.Text;
                pro.CodTipoAfectacion_Sunat = lbl_TipoAfectacion.Text;
                pro.TipoAfectacion_Sunat = cbo_TipoAfectSunat.Text;
                pro.PreventaLista = Convert.ToDecimal(txt_PreVenta_mnr.Text);

                obj.RN_Editar_Producto(pro);

                if(BD_Productos.seedito == true)
                {


                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

                    fil.Show();
                    ok.Lbl_msm1.Text = "El Producto se ha Actualizado correctamente";
                    ok.ShowDialog();
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


        //////private void Registrar_Kardex(string idprod)
        ////{
        ////    RN_Kardex obj = new RN_Kardex();
        ////    EN_Kardex kr = new EN_Kardex();

        ////    try
        ////    {
        ////        if(obj.BD_Verificar_Producto_siTieneKardex(idprod)== true)
        ////        {

        ////            return; //ya tiene kardex no hace falta crear otro 

        ////        }
        ////        else
        ////        {
        ////            string idkardex = RN_TipoDoc.RN_NroID(6);

        ////            obj.RN_Registrar_Kardex(idkardex, idprod, lbl_idProvee.Text);

        ////            if (BD_Kardex.seguardo == true)
        ////            {
        ////                //actualizar el sigueinte numero correlativo
        ////                RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(6);


        ////                //trabajamos con el detalle del kardex:
        ////                kr.Idkardex = idkardex;
        ////                kr.Item = 1;
        ////                kr.Doc_soporte = "000";
        ////                kr.Det_Operacion = "Inicio de Kardex";

        ////                //entradas
        ////                kr.Cantidad_in = 0;
        ////                kr.Precio_In = 0;
        ////                kr.Total_In = 0;
        ////                //salidas;
        ////                kr.Cantidad_Out = 0;
        ////                kr.Precio_out = 0;
        ////                kr.Total_out = 0;

        ////                //saldos:
        ////                kr.Cantidad_saldo = 0;
        ////                kr.Promedio = 0;
        ////                kr.Total_saldo = 0;

        ////                obj.RN_Registrar_Detalle_Kardex(kr);

        ////                if(BD_Kardex.detsaved == true)
        ////                {

        ////                }

        ////            }

        ////        }



        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show("Algo salio mal: " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }

        //}



        private void lbl_busProve_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_ListadoProveedor lis = new Frm_ListadoProveedor();

            fil.Show();
            lis.ShowDialog();

            fil.Hide();

            if (lis.Tag.ToString() == "A")
            {
                txt_provee.Text = lis.lbl_nom.Text;
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
                lbl_idmar.Text = mar.txt_idmarca.Text;

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
                lbl_idcat.Text = cat.txt_idcateg.Text;

            }
        }

        private void piclogo_Click_1(object sender, EventArgs e)
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
                MessageBox.Show("Error al Guardar el Personal" + ex.Message);

            }
        }

        private void txt_PreCompra_Sol_TextChanged(object sender, EventArgs e)
        {

            txt_PreCompra_Sol.Text = txt_PreCompra_Sol.Text.Replace(",", ".");
            txt_PreCompra_Sol.SelectionStart = txt_PreCompra_Sol.Text.Length;

 
        }

        private void txt_PreCompra_Sol_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_Frank_KeyPress(object sender, KeyPressEventArgs e)
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
                if (txt_PreCompra_Sol.Text.Trim() == "") return;

                double Precom_Sol = 0;
                double Utilidad_Unit = 0;

                //Precom_Sol = Convert.ToDouble(txt_PreCompra_Sol.Text) * Convert.ToDouble(txt_Frank.Text);
                //txt_PreVenta_mnr.Text = Precom_Sol.ToString("###0.00");

                //calcular la utilidad

                Utilidad_Unit = Convert.ToDouble(txt_PreVenta_mnr.Text) - Convert.ToDouble(txt_PreCompra_Sol.Text);
                //10.50 - 12.0 saca utilidad ejmplo ganancia
                txt_utili.Text = Utilidad_Unit.ToString("###0.00");
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

                if (txt_PreCompra_Sol.Text.Trim() == "") return;
                if (txt_Frank.Text.Trim() == "") return;

                double Precom_Sol = 0;

                Precom_Sol = Convert.ToDouble(txt_PreVenta_mnr.Text) / Convert.ToDouble(txt_PreCompra_Sol.Text);
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
                txt_PreCompra_Sol.Text = Precom_Sol.ToString("###0.00");

                //hallar el precio de venta al por menor
                Precom_Sol = Convert.ToDouble(txt_PreCompra_Sol.Text) * Convert.ToDouble(txt_Frank.Text);
                txt_PreVenta_mnr.Text = Precom_Sol.ToString("###0.00");

                //hallar precio de venta en dolar
                precioVenta_dolar = Convert.ToDouble(txt_PreCompra_Dlr.Text) * Convert.ToDouble(txt_Frank.Text);
                txt_PreVenta_dlr.Text = precioVenta_dolar.ToString("###0.00");


                //calcular la utilidad
                Utilidad_Unit = Convert.ToDouble(txt_PreVenta_mnr.Text) - Convert.ToDouble(txt_PreCompra_Sol.Text);
                //10.50 - 12.0 saca utilidad ejmplo ganancia
                txt_utili.Text = Utilidad_Unit.ToString("###0.00");
            }
            catch (Exception ex)
            {
                string sms = ex.Message;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked == true)
            {
                txt_PreCompra_Dlr.Enabled = true;
                txt_PreCompra_Dlr.Focus();
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
    }
}
