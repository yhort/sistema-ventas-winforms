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
    public partial class Frm_ListadoProd_Compras : Form
    {
        public Frm_ListadoProd_Compras()
        {
            InitializeComponent();
        }

        public static string TipoVenta = "";
        public static string BuscarProducto = "";

        private void Frm_ListadoProd_Compras_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Configurar_listView_Pedido();

            if (TipoVenta.Trim() == "compra" || TipoVenta == "coti")
            {
                chk_verTodos.Checked = true;
            }
            else 
            {
                chk_verTodos.Checked = false;
            }

            

            Cargar_Todos_Productos();
            txt_buscar.Focus();
        }



        //configurar nuestro listview General

        private void Configurar_listView()
        {

            var lis = lsv_prodcto;

            lsv_prodcto.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            
            lis.Columns.Add("ID", 100, HorizontalAlignment.Left); //0
            lis.Columns.Add("Nombre del Producto", 300, HorizontalAlignment.Left); //1
            lis.Columns.Add("Stock", 90, HorizontalAlignment.Left); //2
            lis.Columns.Add("Pre Compra", 90, HorizontalAlignment.Left); //3
            lis.Columns.Add("marca", 120, HorizontalAlignment.Left);//7
            lis.Columns.Add("Venta Menor", 90, HorizontalAlignment.Left); //4
            lis.Columns.Add("Venta Mayor", 100, HorizontalAlignment.Left); //5
            //lis.Columns.Add("Foto", 0, HorizontalAlignment.Left); //6
            lis.Columns.Add("Und", 0, HorizontalAlignment.Left); //8 -7
            lis.Columns.Add("Utilidad Unit", 0, HorizontalAlignment.Left); //9 -8
            lis.Columns.Add("Estado", 100, HorizontalAlignment.Left);//10 -9
            lis.Columns.Add("TipoProd", 0, HorizontalAlignment.Left);//11 -10

        }

        //configurar nuestro listview ventana pequeña carrito
        private void Configurar_listView_Pedido()
        {

            var lis = lsv_Ped;

            lsv_Ped.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("ID producto", 0, HorizontalAlignment.Left); //0
            lis.Columns.Add("Nombre del Producto", 190, HorizontalAlignment.Left); //1
            lis.Columns.Add("Und", 0, HorizontalAlignment.Left); //2
            lis.Columns.Add("Cant", 50, HorizontalAlignment.Left); //3
            lis.Columns.Add("Pre", 50, HorizontalAlignment.Left); //4
            lis.Columns.Add("Importe", 65, HorizontalAlignment.Left); //5

            lis.Columns.Add("Utilidad Unit", 0, HorizontalAlignment.Left); //6
            lis.Columns.Add("Ganancia Total", 0, HorizontalAlignment.Left);//7
            lis.Columns.Add("Tipo Prod", 0, HorizontalAlignment.Left); //8

        }

        private void Agregar_Producto_alPedido(string xxidpro, string xxnombre, string xxund, double xxcant, double xxprecio, double xximporte, double xxutili_Unit, double xxgananciaTotal, string xxtipoProd)
        {
            if (lsv_Ped.Items.Count == 0) //probar con selectedIndices,count
            {
                //nuestro list esta vacio, anañore por primera vez:

                ListViewItem item = new ListViewItem();
                item = lsv_Ped.Items.Add(xxidpro);
                item.SubItems.Add(xxnombre.Trim());
                item.SubItems.Add(xxund.ToString());
                item.SubItems.Add(xxcant.ToString()); //***/se quit"0"
                item.SubItems.Add(xxprecio.ToString("###0.00"));//00
                item.SubItems.Add(xximporte.ToString("###0.00"));//00
                item.SubItems.Add(xxutili_Unit.ToString("###0.00"));
                item.SubItems.Add(xxgananciaTotal.ToString("###0.00"));
                item.SubItems.Add(xxtipoProd.ToString());

                Calcular();
            }
            else
            {
                //validar que el producto no se ingrese dos veces
                for (int i = 0; i < lsv_Ped.Items.Count; i++)
                {
                    if (lsv_Ped.Items[i].Text.Trim() == xxidpro.Trim())//xidprodcto se cambio - cla22.21:21
                    {
                        MessageBox.Show("El Producto ya fue Agregado al Carrito ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                ListViewItem item = new ListViewItem();
                item = lsv_Ped.Items.Add(xxidpro);
                item.SubItems.Add(xxnombre.Trim());
                item.SubItems.Add(xxund.ToString());
                item.SubItems.Add(xxcant.ToString());
                item.SubItems.Add(xxprecio.ToString("###0.00"));//00
                item.SubItems.Add(xximporte.ToString("###0.00"));//00
                item.SubItems.Add(xxutili_Unit.ToString("###0.00"));
                item.SubItems.Add(xxgananciaTotal.ToString("###0.00"));
                item.SubItems.Add(xxtipoProd.ToString());

                Calcular();

            }

        }

        private void Calcular()
        {
            double xtotal = 0;
            double xcant = 0;
            double xprecio = 0;
            double ximporte = 0;
            double xigv = 0;
            double xsubtotal = 0;


            for (int i = 0; i < lsv_Ped.Items.Count; i++)
            {
                
                xcant = Convert.ToDouble(lsv_Ped.Items[i].SubItems[3].Text);
                xprecio = Convert.ToDouble(lsv_Ped.Items[i].SubItems[4].Text);
                lsv_Ped.Items[i].SubItems[4].Text = xprecio.ToString("###0.000000");

                //calculo
                ximporte = xprecio * xcant;
                lsv_Ped.Items[i].SubItems[5].Text = ximporte.ToString("###0.000000");//00

                //calculo del total:
                xtotal = xtotal + Convert.ToDouble(lsv_Ped.Items[i].SubItems[5].Text);


            }


            Lbl_Total.Text = xtotal.ToString("###0.00");
            lbl_totalite.Text = Convert.ToString(lsv_Ped.Items.Count);
            btn_Pedido.Text = Convert.ToString(lsv_Ped.Items.Count);

        }

        private void Calcular_Compras()
        {

        }

        //llenar el listview:

        private void Llenar_Listview(DataTable data)
        {

            try
            {
                string idprod = "";
                double StockReal = 0;

                lsv_prodcto.Items.Clear();

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow dr = data.Rows[i];
                    idprod = dr["Id_Pro"].ToString();
                    StockReal = Convert.ToDouble(dr["Stock_Actual"]);

                    if (chk_verTodos.Checked == true)
                    {
                       
                        ListViewItem list = new ListViewItem(dr["Id_Pro"].ToString());  //0
                        list.SubItems.Add(dr["Descripcion_Larga"].ToString());          //1
                        list.SubItems.Add(dr["Stock_Actual"].ToString());               //2   
                        list.SubItems.Add(dr["Pre_CompraS"].ToString());                //3
                        list.SubItems.Add(dr["Marca"].ToString());                      //4
                        /*list.SubItems.Add(dr["Frank"].ToString());      */                               
                        list.SubItems.Add(dr["Pre_vntaxMenor"].ToString());             //5
                        list.SubItems.Add(dr["Pre_vntaxMayor"].ToString());             //6
                        //list.SubItems.Add(dr["Foto"].ToString());                       //7
                        list.SubItems.Add(dr["UndMedida"].ToString());                  //8 -7
                        list.SubItems.Add(dr["UtilidadUnit"].ToString());               //9 -8             
                        list.SubItems.Add(dr["Estado_Pro"].ToString());                 //10 -9
                        list.SubItems.Add(dr["TipoProdcto"].ToString());                //11 -10 

                        lsv_prodcto.Items.Add(list); //si no ponemos esto,. el listview  nunca se llenara
                        //Pintar_Filas();
                        pnl_msm.Visible = false;
                        lbl_totalItem.Text = lsv_prodcto.Items.Count.ToString();
                    }
                    else
                    {
                        //en caso de que no este marcado ..quiere decir que debo agregar productos solo los que esten con stock mayor a cero:

                        if (StockReal > 0)
                        {
                            ListViewItem list = new ListViewItem(dr["Id_Pro"].ToString());  //0
                            list.SubItems.Add(dr["Descripcion_Larga"].ToString());          //1
                            list.SubItems.Add(dr["Stock_Actual"].ToString());               //2   
                            list.SubItems.Add(dr["Pre_CompraS"].ToString());                //3
                            list.SubItems.Add(dr["Marca"].ToString());                      //4
                            /*list.SubItems.Add(dr["Frank"].ToString());      */
                            list.SubItems.Add(dr["Pre_vntaxMenor"].ToString());             //5
                            list.SubItems.Add(dr["Pre_vntaxMayor"].ToString());             //6
                            //list.SubItems.Add(dr["Foto"].ToString());                       //7
                            list.SubItems.Add(dr["UndMedida"].ToString());                  //8 -7
                            list.SubItems.Add(dr["UtilidadUnit"].ToString());               //9  -8            
                            list.SubItems.Add(dr["Estado_Pro"].ToString());                 //10 -9
                            list.SubItems.Add(dr["TipoProdcto"].ToString());                //11 -10 

                            lsv_prodcto.Items.Add(list); //si no ponemos esto,. el listview  nunca se llenara
                            //Pintar_Filas();
                            pnl_msm.Visible = false;
                            //lbl_totalItem.Text = lsv_prodcto.Items.Count.ToString();
                        }
                    }
                    
                }
                    
            }
            catch (Exception ex)
            {

                string sms = ex.Message;

            }
           
        }

        //private void Pintar_Filas()
        //{
        //    for (int i = 0; i < lsv_prodcto.Items.Count; i++)
        //    {
        //        lsv_prodcto.Items[i].SubItems[2].BackColor = Color.Linen; //columna stock, pintado
        //        lsv_prodcto.Items[i].SubItems[3].BackColor = Color.Beige; // precio compra pintado

        //        lsv_prodcto.Items[i].SubItems[5].BackColor = Color.MintCream;
        //        lsv_prodcto.Items[i].SubItems[6].BackColor = Color.AliceBlue;

        //        lsv_prodcto.Items[i].SubItems[2].Font = new System.Drawing.Font("Oxygen", 10, FontStyle.Bold);
        //        lsv_prodcto.Items[i].SubItems[5].Font = new System.Drawing.Font("Oxygen", 10, FontStyle.Bold);

        //        lsv_prodcto.Items[i].UseItemStyleForSubItems = false;

        //    }
        //}

        private void Cargar_Todos_Productos()
        {
            RN_Productos obj = new RN_Productos();
            DataTable dato = new DataTable();

            dato = obj.RN_Mostrar_Todos_Productos();
            //se agrego && condicional para la carga de productos. no demore en listado de producto al jalar ventas.
            if (dato.Rows.Count >0  )
            {
                Llenar_Listview(dato);

            }
            else
            {
                lsv_prodcto.Items.Clear();
                pnl_msm.Visible = true;
            }

        }

        //codigo original:
        
        private void buscar_Productos(string valor)
        {
            RN_Productos obj = new RN_Productos();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_Productos(valor);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_prodcto.Items.Clear();
                pnl_msm.Visible = true;
            }

        }
        
        /*
        private async Task Buscar_Productos_xvalor(string valor)
        {

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

            if (e.Button ==MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        private void txt_buscar_OnValueChanged(object sender, EventArgs e)//se agrego como el frm_explor_cliente cambio actualizado. vid.#15
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                buscar_Productos(txt_buscar.Text);
            }
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e) //se agrego como el frm_explor_cliente cambio actualizado.
        {
            if (e.KeyCode == Keys.Enter) //codigo nativo por defecto 
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    buscar_Productos(txt_buscar.Text);
                    if (lsv_prodcto.Items.Count > 0)
                    {
                        lsv_prodcto.Focus();
                        lsv_prodcto.Items[0].Selected = true;
                    }
                }
                else
                {
                    Cargar_Todos_Productos();
                    if (lsv_prodcto.Items.Count > 0)
                    {
                        lsv_prodcto.Focus();
                        lsv_prodcto.Items[0].Selected = true;
                    }
                }
            }
        }

        private void Seleccionar_Producto_Para_Vender()
        {
            

            Frm_Filtro fil = new Frm_Filtro();
            //Frm_Solo_Canti solo = new Frm_Solo_Canti();
            Frm_Add_Cantidad can = new Frm_Add_Cantidad();

            if (lsv_prodcto.SelectedIndices.Count == 0) { fil.Show(); MessageBox.Show("Por favor, Selecciona un Producto de la Lista", "Seleccion de Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); return; }

            if (chk_cotiza.Checked == true)
            {
                Seleccionar_Producto_ModoCotizacion();
            }
            else
            {
                double Stock = 0;
                string EstadoProd = "";
                double xxpreCom = 0;
                double xxUtilidad_Unit = 0;


                var lis = lsv_prodcto.SelectedItems[0];

                //continuar:
                lbl_NomProd.Text = lis.SubItems[1].Text;
                lbl_Pre_Unit.Text = lis.SubItems[5].Text; //precio de venta por menor:
                lbl_IdProd.Text = lis.SubItems[0].Text;
                Stock = Convert.ToDouble(lis.SubItems[2].Text);
                lbl_Uti_Unit.Text = lis.SubItems[8].Text;
                EstadoProd = lis.SubItems[9].Text;
                xxpreCom = Convert.ToDouble(lis.SubItems[3].Text);
                lbl_TipoProd.Text = lis.SubItems[10].Text;
                lbl_Und.Text = lis.SubItems[7].Text;


                if (EstadoProd.Trim() == "Eliminado") { fil.Show(); MessageBox.Show("El Producto  esta Eliminado, y no Apto para esta Transaccion, Elige otro por Favor", "Seleccionar Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); return; }

                if (lbl_TipoProd.Text.Trim().ToString() == "Producto")
                {
                    if (Stock == 0) { fil.Show(); MessageBox.Show("El Producto, no tiene suficiente Stock para la Venta", "Seleccionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); return; }
                }

                if (chk_crearPed.Checked == true)
                {
                    fil.Show();
                    can.lbl_TipoProd.Text = lbl_TipoProd.Text;
                    can.Lbl_stockActual.Text = Stock.ToString();
                    can.lbl_Prod.Text = lbl_NomProd.Text;
                    can.txt_cant.Text = "1";

                    can.ShowDialog();
                    fil.Hide();

                    if (can.Tag.ToString() == "A")
                    {
                        lbl_Cant.Text = can.txt_cant.Text;
                        can.txt_cant.Text = "";

                        //xxUtilidad_Unit = Convert.ToDouble(lbl_Cant.Text) * Convert.ToDouble(xxpreCom);
                        //lbl_Uti_Unit.Text = xxUtilidad_Unit.ToString("###0.00");//cooreccion utiliunit

                        double importxx = Convert.ToDouble(lbl_Cant.Text) * Convert.ToDouble(lbl_Pre_Unit.Text);
                        lbl_Import.Text = importxx.ToString("###0.00");

                        Agregar_Producto_alPedido(lbl_IdProd.Text, lbl_NomProd.Text, lbl_Und.Text, Convert.ToDouble(lbl_Cant.Text), Convert.ToDouble(lbl_Pre_Unit.Text), Convert.ToDouble(lbl_Import.Text), Convert.ToDouble(lbl_Uti_Unit.Text), Convert.ToDouble(lbl_Uti_Unit.Text), lbl_TipoProd.Text);
                        Limpiarlabels();
                    }

                }
                else
                {
                    fil.Show();

                    can.lbl_TipoProd.Text = lbl_TipoProd.Text;
                    can.Lbl_stockActual.Text = Stock.ToString();
                    can.lbl_Prod.Text = lbl_NomProd.Text;
                    can.txt_cant.Text = "1";
                    can.ShowDialog();
                    fil.Hide();


                    if (can.Tag.ToString() == "A")
                    {
                        lbl_Cant.Text = can.txt_cant.Text;
                        can.txt_cant.Text = "";

                        //xxUtilidad_Unit = Convert.ToDouble(lbl_Cant.Text) * Convert.ToDouble(xxpreCom);
                        //lbl_Uti_Unit.Text = xxUtilidad_Unit.ToString("###0.00"); cooreccion utiliunit

                        double importxx = Convert.ToDouble(lbl_Cant.Text) * Convert.ToDouble(lbl_Pre_Unit.Text);
                        lbl_Import.Text = importxx.ToString("###0.00");

                        this.Tag = "A";
                        this.Close();

                    }

                }

            }   

        }

        private void Seleccionar_Producto_ModoCotizacion()
        {
            //tambien servira para modo compra

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Solo_Canti solo = new Frm_Solo_Canti();

            if (lsv_prodcto.SelectedIndices.Count == 0) { fil.Show(); MessageBox.Show("Por favor, Selecciona un Producto de la Lista", "Seleccion de Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); return; }

            double Stock = 0;
            string EstadoProd = "";
            double xxpreCom = 0;
            double xxUtilidad_Unit = 0;


            var lis = lsv_prodcto.SelectedItems[0];

            //continuar:
            lbl_NomProd.Text = lis.SubItems[1].Text;
            lbl_Pre_Unit.Text = lis.SubItems[5].Text; //precio de venta por menor:
            lbl_IdProd.Text = lis.SubItems[0].Text;
            Stock = Convert.ToDouble(lis.SubItems[2].Text);
            lbl_Uti_Unit.Text = lis.SubItems[8].Text;
            EstadoProd = lis.SubItems[9].Text;
            xxpreCom = Convert.ToDouble(lis.SubItems[3].Text);
            lbl_TipoProd.Text = lis.SubItems[10].Text;
            lbl_Und.Text = lis.SubItems[7].Text;

            if (EstadoProd.Trim() == "Eliminado") { fil.Show(); MessageBox.Show("El Producto esta Eliminado, y no Apto para esta Transaccion, Elige otro por Favor", "Seleccionar Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); return; }

            //if (lbl_TipoProd.Text.Trim().ToString() == "Producto")
            //{
            //    if (Stock == 0) { fil.Show(); MessageBox.Show("El Producto No tiene Suficiente Stock para la Venta", "Seleccionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); return; }
            //}

            if (chk_crearPed.Checked == true)
            {
                fil.Show();

                solo.lbl_stock.Text = Stock.ToString();
                solo.lbl_nom.Text = lbl_NomProd.Text;
                solo.txt_cant.Text = "1";
                solo.ShowDialog();
                fil.Hide();

                if (solo.Tag.ToString() == "A")
                {
                    lbl_Cant.Text = solo.txt_cant.Text;
                    solo.txt_cant.Text = "1";//se agrego****

                    xxUtilidad_Unit = Convert.ToDouble(lbl_Cant.Text) * Convert.ToDouble(xxpreCom);
                    lbl_Uti_Unit.Text = xxUtilidad_Unit.ToString("###0.00");

                    //original:
                    //double importxx = Convert.ToDouble(lbl_Cant.Text) * Convert.ToDouble(lbl_Pre_Unit.Text);
                    //lbl_Import.Text = importxx.ToString("###0.00");

                    double importxx = Convert.ToDouble(lbl_Cant.Text) * Convert.ToDouble(lbl_Pre_Unit.Text);
                    lbl_Import.Text = importxx.ToString("###0.00");

                    Agregar_Producto_alPedido(lbl_IdProd.Text, lbl_NomProd.Text, lbl_Und.Text, Convert.ToDouble(lbl_Cant.Text), Convert.ToDouble(lbl_Pre_Unit.Text), Convert.ToDouble(lbl_Import.Text), Convert.ToDouble(lbl_Uti_Unit.Text), Convert.ToDouble(lbl_Uti_Unit.Text), lbl_TipoProd.Text);
                    Limpiarlabels();
                }

            }
            else
            {
                fil.Show();
                solo.lbl_stock.Text = Stock.ToString();
                solo.lbl_nom.Text = lbl_NomProd.Text;
                solo.txt_cant.Text = "1";
                solo.ShowDialog();
                fil.Hide();

                if (solo.Tag.ToString() == "A")
                {
                    lbl_Cant.Text = solo.txt_cant.Text;
                    solo.txt_cant.Text = ""; //sehrego***

                    xxUtilidad_Unit = Convert.ToDouble(lbl_Cant.Text) * Convert.ToDouble(xxpreCom);
                    lbl_Uti_Unit.Text = xxUtilidad_Unit.ToString("###0.00");

                    this.Tag = "A";
                    this.Close();

                }

            }

        }

        private void Limpiarlabels()
        {
            lbl_Cant.Text = "0"; //**se agrego
            lbl_IdProd.Text = "";

            lbl_Import.Text = "0";
            lbl_Und.Text = "";
            lbl_Uti_Unit.Text = "0"; //segir agregando los label para limpiar

        }

        private void Frm_ListadoProd_Compra_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }

            if (e.KeyCode == Keys.F7)
            {
                btn_continuar_Click(sender, e);
            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.A))
            {
                txt_buscar.Focus();
            }

        }

        private void chk_verTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_verTodos.Checked == true)
            {
                Cargar_Todos_Productos();
            }
            else
            {
                Cargar_Todos_Productos();
            }
        }

        private void lsv_Ped_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //para quitar un producto de la lista :
            Frm_Filtro fil = new Frm_Filtro();


            if (lsv_Ped.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar el Producto a Quitar", "Quitar Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                int i;

                var lis = lsv_Ped.SelectedItems[0];
                for (i = lsv_Ped.SelectedItems.Count - 1; i >= 0; i--)
                {
                    lsv_Ped.Items.Remove(lsv_Ped.SelectedItems[i]);
                }
                Calcular();
            }
        }

        private void btn_Pedido_Click(object sender, EventArgs e)
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

        private void btn_continuar_Click(object sender, EventArgs e)
        {
            if (lsv_Ped.Items.Count > 0)
            {
                chk_crearPed.Checked = true;
                this.Tag = "A";
                this.Close();
            }
        }

       

        private void btn_add_Click(object sender, EventArgs e)
        {
            Seleccionar_Producto_Para_Vender();
        }

        private void lsv_prodcto_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btn_add_Click(sender, e);
        }
        private void lsv_prodcto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_add_Click(sender, e);
            }
        }

        private void lsv_Ped_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chk_cotiza_CheckedChanged(object sender, EventArgs e) //se agrego opcional..
        {
            if (chk_cotiza.Checked == true)
            {
                Cargar_Todos_Productos();
            }
            else
            {
                Cargar_Todos_Productos();
            }
        }

        private void btn_continuar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
            {
                btn_continuar_Click(sender, e);
            }
        }

        private void pnl_carrito_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnl_carrito_Click(object sender, EventArgs e)
        {

        }

        //private void bt_add_Click(object sender, EventArgs e)
        //{
        //    Frm_Filtro fil = new Frm_Filtro();
        //    Frm_AddProductos ad = new Frm_AddProductos();


        //    fil.Show();
        //    ad.ShowDialog();
        //    fil.Hide();

        //    if (ad.Tag.ToString() == "A")
        //    {
        //        Cargar_Todos_Productos();

        //    }
        //}
        //private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Cargar_Todos_Productos();
        //}

        //private void bt_nuevoProductoTool_Click(object sender, EventArgs e)
        //{
        //    Frm_Filtro fil = new Frm_Filtro();
        //    Frm_AddProductos ad = new Frm_AddProductos();

        //    fil.Show();
        //    ad.ShowDialog();
        //    fil.Hide();

        //    if (ad.Tag.ToString() == "A")
        //    {
        //        Cargar_Todos_Productos();

        //    }
        //}


        //private void editarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Frm_Filtro fil = new Frm_Filtro();
        //    Frm_Addver ver = new Frm_Addver();
        //    Frm_Edit_Producto edi = new Frm_Edit_Producto();

        //    if (lsv_prodcto.SelectedIndices.Count == 0)
        //    {
        //        fil.Show();
        //        ver.Lbl_Msm1.Text = "Selecciona el Item que desees Editar";
        //        ver.ShowDialog();
        //        fil.Hide();

        //    }
        //    else
        //    {

        //        var lis = lsv_prodcto.SelectedItems[0];
        //        string idprod = lis.SubItems[0].Text;

        //        fil.Show();
        //        edi.Tag = idprod;
        //        edi.ShowDialog();
        //        fil.Hide();

        //        if (edi.Tag.ToString() == "A")
        //        {
        //            Cargar_Todos_Productos();
        //        }


        //    }

        //}

        //private void bt_edit_Click(object sender, EventArgs e)
        //{
        //    Frm_Filtro fil = new Frm_Filtro();
        //    Frm_Addver ver = new Frm_Addver();
        //    Frm_Edit_Producto edi = new Frm_Edit_Producto();

        //    if (lsv_prodcto.SelectedIndices.Count == 0)
        //    {
        //        fil.Show();
        //        ver.Lbl_Msm1.Text = "Selecciona el Item que desees Editar";
        //        ver.ShowDialog();
        //        fil.Hide();

        //    }
        //    else
        //    {

        //        var lis = lsv_prodcto.SelectedItems[0];
        //        string idprod = lis.SubItems[0].Text;

        //        fil.Show();
        //        edi.Tag = idprod;
        //        edi.ShowDialog();
        //        fil.Hide();

        //        if (edi.Tag.ToString() == "A")
        //        {
        //            Cargar_Todos_Productos();
        //        }


        //    }
        //}

        //private void bt_copiarIDProductoTool_Click(object sender, EventArgs e)
        //{
        //    Frm_Filtro fil = new Frm_Filtro();
        //    Frm_Addver ver = new Frm_Addver();

        //    if (lsv_prodcto.SelectedIndices.Count == 0)
        //    {
        //        fil.Show();
        //        ver.Lbl_Msm1.Text = "Selecciona el Item que desees copiar";
        //        ver.ShowDialog();
        //        fil.Hide();

        //    }
        //    else
        //    {

        //        var lis = lsv_prodcto.SelectedItems[0];
        //        string idprovee = lis.SubItems[0].Text;

        //        Clipboard.Clear();
        //        Clipboard.SetText(idprovee.Trim());


        //    }
        //}
    }
}
