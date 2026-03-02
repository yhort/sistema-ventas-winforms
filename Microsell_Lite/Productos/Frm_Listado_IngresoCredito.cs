using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsell_Lite.Productos;
using Prj_Capa_Negocio;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Compras;
using Microsell_Lite.Ventas;

namespace Microsell_Lite.Productos
{
    public partial class Frm_Listado_IngresoCredito : Form
    {
        public Frm_Listado_IngresoCredito()
        {
            InitializeComponent();
        }

        

        private void Frm_Listado_IngresoCredito_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_Todos_Productos();
        }

        //configurar nuestro listview General

        private void Configurar_listView()
        {

            var lis = lsv_prodcto_compras;

            lsv_prodcto_compras.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:

            lis.Columns.Add("IdNotaCred", 100, HorizontalAlignment.Left); //0
            lis.Columns.Add("Id_Doc", 300, HorizontalAlignment.Left); //1
            lis.Columns.Add("Fecha_Credito", 90, HorizontalAlignment.Left); //2
            lis.Columns.Add("Nom_Cliente", 90, HorizontalAlignment.Left); //3
            lis.Columns.Add("Total_Cre", 120, HorizontalAlignment.Left);//7
            lis.Columns.Add("Saldo_Pdnte", 90, HorizontalAlignment.Left); //4
            lis.Columns.Add("Fecha_Vncimnto", 100, HorizontalAlignment.Left); //5
            lis.Columns.Add("Estado_Cred", 0, HorizontalAlignment.Left); //6


        }


        //configurar nuestro listview ventana pequeña carrito
        private void Configurar_listView_Pedido()
        {

            var lis = lsv_Ped_comp;

            lsv_Ped_comp.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("IdNotaCred", 0, HorizontalAlignment.Left); //0
            lis.Columns.Add("Id_Doc", 190, HorizontalAlignment.Left); //1
            lis.Columns.Add("Fecha_Credito", 0, HorizontalAlignment.Left); //2
            lis.Columns.Add("Nom_Cliente", 50, HorizontalAlignment.Left); //3
            lis.Columns.Add("Total_Cre", 50, HorizontalAlignment.Left); //4
            lis.Columns.Add("Saldo_Pdnte", 65, HorizontalAlignment.Left); //5

            lis.Columns.Add("Fecha_Vncimnto", 0, HorizontalAlignment.Left); //6
            lis.Columns.Add("Estado_Cred", 0, HorizontalAlignment.Left);//7
         

        }


        //llenar el listview:

        private void Llenar_Listview(DataTable data)
        {

            try
            {
                string idprod = "";
                double StockReal = 0;

                lsv_prodcto_compras.Items.Clear();

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow dr = data.Rows[i];
                    idprod = dr["IdNotaCred"].ToString();
                    StockReal = Convert.ToDouble(dr["Total_Cre"]);

                    //if (chk_verTodos.Checked == true)
                    //{

                        ListViewItem list = new ListViewItem(dr["IdNotaCred"].ToString());  //0
                        list.SubItems.Add(dr["Id_Doc"].ToString());          //1          //2   
                        list.SubItems.Add(dr["Fecha_Credito"].ToString());                //3
                        list.SubItems.Add(dr["Nom_Cliente"].ToString());                      //4
                                                                                    /*list.SubItems.Add(dr["Frank"].ToString());      */
                        list.SubItems.Add(dr["Total_Cre"].ToString());             //5
                        list.SubItems.Add(dr["Saldo_Pdnte"].ToString());             //6
                        list.SubItems.Add(dr["Fecha_Vncimnto"].ToString());                       //7
                        list.SubItems.Add(dr["Estado_Cred"].ToString());                  //8


                        lsv_prodcto_compras.Items.Add(list); //si no ponemos esto,. el listview  nunca se llenara
                        //Pintar_Filas();
                        pnl_msm.Visible = false;
                        lbl_totalItem.Text = lsv_prodcto_compras.Items.Count.ToString();
                    //}
                    //else
                    //{
                    //    //en caso de que no este marcado ..quiere decir que debo agregar productos solo los que esten con stock mayor a cero:

                    //    if (StockReal > 0)
                    //    {
                    //        ListViewItem list = new ListViewItem(dr["Id_Pro"].ToString());  //0
                    //        list.SubItems.Add(dr["Descripcion_Larga"].ToString());          //1
                    //        list.SubItems.Add(dr["Stock_Actual"].ToString());               //2   
                    //        list.SubItems.Add(dr["Pre_CompraS"].ToString());                //3
                    //        list.SubItems.Add(dr["Marca"].ToString());                      //4
                    //        /*list.SubItems.Add(dr["Frank"].ToString());      */
                    //        list.SubItems.Add(dr["Pre_vntaxMenor"].ToString());             //5
                    //        list.SubItems.Add(dr["Pre_vntaxMayor"].ToString());             //6
                    //        list.SubItems.Add(dr["Foto"].ToString());                       //7
                    //        list.SubItems.Add(dr["UndMedida"].ToString());                  //8
                    //        list.SubItems.Add(dr["UtilidadUnit"].ToString());               //9              
                    //        list.SubItems.Add(dr["Estado_Pro"].ToString());                 //10
                    //        list.SubItems.Add(dr["TipoProdcto"].ToString());                //11 

                    //        lsv_prodcto_compras.Items.Add(list); //si no ponemos esto,. el listview  nunca se llenara
                    //        //Pintar_Filas();
                    //        pnl_msm.Visible = false;
                    //        lbl_totalItem.Text = lsv_prodcto_compras.Items.Count.ToString();
                    //    }
                    //}

                }

            }
            catch (Exception ex)
            {

                string sms = ex.Message;

            }

        }



        private void Agregar_Producto_alPedido_compras(string xxidpro, string xxnombre, string xxund, double xxcant_totalcred, double xxprecio, double xximporte, double xxutili_Unit, double xxgananciaTotal, string xxtipoProd)
        
        {
          
            /*
            if (lsv_Ped_comp.Items.Count == 0) //probar con selectedIndices,count
            {
                //nuestro list esta vacio, anañore por primera vez:

                ListViewItem item = new ListViewItem();
                item = lsv_Ped_comp.Items.Add(xxidpro);
                item.SubItems.Add(xxnombre.Trim());
                //item.SubItems.Add(xxund.ToString());
                item.SubItems.Add(xxcant_totalcred.ToString()); 
                item.SubItems.Add(xxprecio.ToString("###0.00"));
                item.SubItems.Add(xximporte.ToString("###0.00"));
                //item.SubItems.Add(xxutili_Unit.ToString("###0.00"));
                //item.SubItems.Add(xxgananciaTotal.ToString("###0.00"));
                //item.SubItems.Add(xxtipoProd.ToString());

                Calcular();
            }
            else
            {
                //validar que el producto no se ingrese dos veces
                for (int i = 0; i < lsv_Ped_comp.Items.Count; i++)
                {
                    if (lsv_Ped_comp.Items[i].Text.Trim() == xxidpro.Trim())//xidprodcto se cambio - cla22.21:21
                    {
                        MessageBox.Show("El Producto ya fue Agregado al Carrito ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                ListViewItem item = new ListViewItem();
                item = lsv_Ped_comp.Items.Add(xxidpro);
                item.SubItems.Add(xxnombre.Trim());
                //item.SubItems.Add(xxund.ToString());
                item.SubItems.Add(xxcant.ToString());
                item.SubItems.Add(xxprecio.ToString("###0.00"));
                item.SubItems.Add(xximporte.ToString("###0.00"));
                //item.SubItems.Add(xxutili_Unit.ToString("###0.00"));
                //item.SubItems.Add(xxgananciaTotal.ToString("###0.00"));
                //item.SubItems.Add(xxtipoProd.ToString());

                Calcular();

            }
            */


        }

        private void Calcular()
        {
            //double xtotal = 0;
            //double xcant = 0;
            //double xprecio = 0;
            //double ximporte = 0;
            //double xigv = 0;
            //double xsubtotal = 0;


            //for (int i = 0; i < lsv_Ped_comp.Items.Count; i++)
            //{
            //    xcant = Convert.ToDouble(lsv_Ped_comp.Items[i].SubItems[3].Text);
            //    xprecio = Convert.ToDouble(lsv_Ped_comp.Items[i].SubItems[4].Text);

            //    //calculo
            //    ximporte = xprecio * xcant;
            //    lsv_Ped_comp.Items[i].SubItems[5].Text = ximporte.ToString("###0.00");

            //    //calculo del total:
            //    xtotal = xtotal + Convert.ToDouble(lsv_Ped_comp.Items[i].SubItems[5].Text);


            //}


            //Lbl_Total.Text = xtotal.ToString("###0.00");
            //lbl_totalite.Text = Convert.ToString(lsv_Ped_comp.Items.Count);
            //btn_Pedido_comp.Text = Convert.ToString(lsv_Ped_comp.Items.Count);

        }


        private void Cargar_Todos_Productos()
        {
            RN_Credito obj = new RN_Credito();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Todas_Creditos();
            //se agrego && condicional para la carga de productos. no demore en listado de producto al jalar ventas.
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);

            }
            else
            {
                lsv_prodcto_compras.Items.Clear();
                pnl_msm.Visible = true;
            }

        }

        private void buscar_Productos(string valor)
        {
            RN_Credito obj = new RN_Credito();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_creditos_porValor(valor);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_prodcto_compras.Items.Clear();
                pnl_msm.Visible = true;
            }

        }


        private void Seleccionar_Producto_ModoCompras()
        {
            //servira para modo compra -CREDITO

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Solo_Canti solo = new Frm_Solo_Canti();

            if (lsv_prodcto_compras.SelectedIndices.Count == 0) { fil.Show(); MessageBox.Show("Por favor, Selecciona un Credito de la Lista", "Seleccion de Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); return; }

            double Stock_totalcred = 0;
            string EstadoProd = "";
            double xxpreCom = 0;
            double xxUtilidad_Unit = 0;


            var lis = lsv_prodcto_compras.SelectedItems[0];

            //continuar:
            lbl_NomProd.Text = lis.SubItems[1].Text;
           /* lbl_Pre_Unit.Text = lis.SubItems[5].Text;*/ //precio de venta por menor:
            lbl_IdProd.Text = lis.SubItems[0].Text;
            Stock_totalcred = Convert.ToDouble(lis.SubItems[4].Text);
            //lbl_Uti_Unit.Text = lis.SubItems[9].Text;
            //EstadoProd = lis.SubItems[10].Text;
            //xxpreCom = Convert.ToDouble(lis.SubItems[3].Text);
            lbl_preCom.Text = lis.SubItems[3].Text;
            //lbl_TipoProd.Text = lis.SubItems[11].Text;
            //lbl_Und.Text = lis.SubItems[8].Text;

            if (EstadoProd.Trim() == "Eliminado") { fil.Show(); MessageBox.Show("El Producto esta Eliminado, y no Apto para esta Transaccion, Elige otro por Favor", "Seleccionar Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); return; }

         

            if (chk_crearPed_com.Checked == true)
            {
                fil.Show();

                solo.lbl_stock.Text = Stock_totalcred.ToString();
                solo.lbl_nom.Text = lbl_NomProd.Text;
                solo.txt_cant.Text = "1";
                solo.ShowDialog();
                fil.Hide();

                if (solo.Tag.ToString() == "A")
                {
                    lbl_Cant_Abono.Text = solo.txt_cant.Text;
                    solo.txt_cant.Text = "1";//se agrego****

                    xxUtilidad_Unit = Convert.ToDouble(lbl_Cant_Abono.Text) * Convert.ToDouble(lbl_preCom.Text);
                    lbl_Uti_Unit.Text = xxUtilidad_Unit.ToString("###0.00");

                    //original:
                    //double importxx = Convert.ToDouble(lbl_Cant.Text) * Convert.ToDouble(lbl_Pre_Unit.Text);
                    //lbl_Import.Text = importxx.ToString("###0.00");

                    double importxx = Convert.ToDouble(lbl_Cant_Abono.Text) * Convert.ToDouble(lbl_preCom.Text);
                    lbl_Import.Text = importxx.ToString("###0.00");

                    //Agregar_Producto_alPedido_compras(lbl_IdProd.Text, lbl_NomProd.Text, lbl_Und.Text, Convert.ToDouble(lbl_Cant.Text), Convert.ToDouble(xxpreCom), Convert.ToDouble(lbl_Import.Text), Convert.ToDouble(lbl_Uti_Unit.Text), Convert.ToDouble(lbl_Uti_Unit.Text), lbl_TipoProd.Text);

                    //probando
                    Agregar_Producto_alPedido_compras(lbl_IdProd.Text, lbl_NomProd.Text, lbl_Und.Text, Convert.ToDouble(lbl_Cant_Abono.Text), Convert.ToDouble(lbl_preCom.Text), Convert.ToDouble(lbl_Import.Text), Convert.ToDouble(lbl_Uti_Unit.Text), Convert.ToDouble(lbl_Uti_Unit.Text), lbl_TipoProd.Text);
                    //Agregar_Producto_alPedido_compras(lbl_IdProd.Text, lbl_NomProd.Text, /*lbl_Und.Text,*/ Convert.ToDouble(lbl_Cant.Text), Convert.ToDouble(xxpreCom), Convert.ToDouble(lbl_Import.Text), Convert.ToDouble(lbl_Uti_Unit.Text), Convert.ToDouble(lbl_Uti_Unit.Text) /*lbl_TipoProd.Text*/);
                    Limpiarlabels();
                }

            }
            else
            {
                fil.Show();
                solo.lbl_stock.Text = Stock_totalcred.ToString();
                solo.lbl_nom.Text = lbl_NomProd.Text;
                solo.txt_cant.Text = "1";
                solo.ShowDialog();
                fil.Hide();

                if (solo.Tag.ToString() == "A")
                {
                    lbl_Cant_Abono.Text = solo.txt_cant.Text;
                    solo.txt_cant.Text = ""; //sehrego***

                    //xxUtilidad_Unit = Convert.ToDouble(lbl_Cant.Text) * Convert.ToDouble(lbl_preCom.Text);
                    //lbl_Uti_Unit.Text = xxUtilidad_Unit.ToString("###0.00");

                    //se agrego ultimo probar para el form compras.18/08/21
                    //double importxx = Convert.ToDouble(lbl_Cant_Abono.Text) * Convert.ToDouble(lbl_preCom.Text);
                    //lbl_Import.Text = importxx.ToString("###0.00");


                    this.Tag = "A";
                    this.Close();

                }

            }

        }


        private void Limpiarlabels()
        {
            lbl_Cant_Abono.Text = "0"; //**se agrego
            lbl_IdProd.Text = "";

            lbl_Import.Text = "0";
            lbl_Und.Text = "";
            lbl_Uti_Unit.Text = "0"; //segir agregando los label para limpiar

        }

        private void lsv_prodcto_compras_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           btn_add_comp_Click(sender, e);
        }

        private void lsv_prodcto_compras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_add_comp_Click(sender, e);
            }
        }

        private void btn_continuar_com_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Pedido_comp_Click(object sender, EventArgs e)
        {
            if (pnl_carrito.Visible == true)
            {
                pnl_carrito.Visible = false;
            }
            else
            {
                pnl_carrito.Visible = true;
            }
        }

        private void btn_add_comp_Click(object sender, EventArgs e)
        {
            Seleccionar_Producto_ModoCompras();
        }

        private void btn_continuar_com_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
            {
                btn_add_comp_Click(sender, e);
            }
        }

        private void Frm_Listado_Produc_IngresoCompras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }

            if (e.KeyCode == Keys.F7)
            {
                btn_continuar_com_Click(sender, e);
            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.A))
            {
                txt_buscar.Focus();
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        private void pnl_msm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //codigo nativo por defecto 
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    buscar_Productos(txt_buscar.Text);
                    if (lsv_prodcto_compras.Items.Count > 0)
                    {
                        lsv_prodcto_compras.Focus();
                        lsv_prodcto_compras.Items[0].Selected = true;
                    }
                }
                else
                {
                    Cargar_Todos_Productos();
                    if (lsv_prodcto_compras.Items.Count > 0)
                    {
                        lsv_prodcto_compras.Focus();
                        lsv_prodcto_compras.Items[0].Selected = true;
                    }
                }
            }
        }

        private void txt_buscar_OnValueChanged(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                buscar_Productos(txt_buscar.Text);
            }
        }

        
    }
}
