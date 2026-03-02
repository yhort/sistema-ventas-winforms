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
using Prj_Capa_Datos;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Informe;
using Prj_Capa_Entidad;

namespace Microsell_Lite.Productos
{
    public partial class Frm_Editar_precios_compraVenta : Form
    {
        public Frm_Editar_precios_compraVenta()
        {
            InitializeComponent();
        }

        public string idProducto = "";
     
        private void Frm_Ajuste_Inventario_Krdx_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_Todos_Productos();
          


        }

        //configurar nuestro listview

        private void Configurar_listView()
        {

            var lis = lsv_prodcto;

            lsv_prodcto.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("ID", 120, HorizontalAlignment.Left); //0
            lis.Columns.Add("Nombre del Producto", 400, HorizontalAlignment.Left); //1
            lis.Columns.Add("Stock", 90, HorizontalAlignment.Left); //2  
            lis.Columns.Add("Pre Compra", 90, HorizontalAlignment.Left); //3
            lis.Columns.Add("Precio Venta 1", 90, HorizontalAlignment.Left);//4
            lis.Columns.Add("Estado", 100, HorizontalAlignment.Center);//5
            
          

        }

        //llenar el listview:

            
        private void Llenar_Listview(DataTable data)
        {
            lsv_prodcto.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Pro"].ToString());//0
                list.SubItems.Add(dr["Descripcion_Larga"].ToString());//1
                list.SubItems.Add(dr["Stock_Actual"].ToString());//2
                list.SubItems.Add(dr["Pre_CompraS"].ToString());//5  
                list.SubItems.Add(dr["Pre_vntaxMenor"].ToString());//3
                list.SubItems.Add(dr["Estado_Pro"].ToString());//4
                            
 
                
                lsv_prodcto.Items.Add(list); //si no ponemos esto,. el listview  nunca se llenara
            }
            //Pintar_Filas();
            pnl_msm.Visible = false;
            lbl_totalItem.Text = lsv_prodcto.Items.Count.ToString();
        }
        

        private void Pintar_Filas()
        {
            //int cont = 1;

            //for (int i = 0; i < lsv_prodcto.Items.Count; i++)
            //{
            //    if (cont % 2 == 0)
            //    {

            //    }
            //    else
            //    {
            //        lsv_prodcto.Items[i].BackColor = Color.AliceBlue;
            //    }
            //    cont += 1;
            //}
        }

        //async
        
        private   void Cargar_Todos_Productos()
        {
            
            RN_Productos obj = new RN_Productos();
        
            DataTable dato = new DataTable();

            dato = obj.RN_Mostrar_Todos_Productos();
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {

                pnl_msm.Visible = true;
                lsv_prodcto.Items.Clear();
            }

           // await Buscar_Productos_xvalor(txt_buscar.Text);

            //dato = obj.RN_Mostrar_Todos_Productos();
            //if (dato.Rows.Count > 0)
            //{
            //    Llenar_Listview(dato);

            //}
            //else
            //{
            //    lsv_prodcto.Items.Clear();
            //    pnl_msm.Visible = true;
            //}


        }

        //async
        private async void buscar_Productos(string valor)
        {
            RN_Productos obj = new RN_Productos();
            //DataTable dato = new DataTable();

            await Buscar_Productos_xvalor(txt_buscar.Text);

            //dato = obj.RN_Buscar_Productos(valor);
            //if (dato.Rows.Count > 0)
            //{
            //    Llenar_Listview(dato);
            //}
            //else
            //{
            //    lsv_prodcto.Items.Clear();
            //    pnl_msm.Visible = true;
            //}


        }

        
        //aync
        private async void txt_buscar_OnValueChanged(object sender, EventArgs e)//se agrego como el frm_explor_cliente cambio actualizado. vid.#15
        {
            //if (txt_buscar.Text.Trim().Length > 2)
            //{
            //    buscar_Productos(txt_buscar.Text);
            //}


            
            RN_Productos obj = new RN_Productos();
            await Buscar_Productos_xvalor(txt_buscar.Text);
            
        }

        private async Task Cargar_Productos_()
        {
            /*
            DataTable dt = new DataTable();
            RN_Productos obj = new RN_Productos();

            dt = await Task.Run(() => obj.RN_Mostrar_Todos_Productos());

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

            }*/



        }

        private async Task Buscar_Productos_xvalor(string valor)
        {
            
            DataTable dt = new DataTable();
            RN_Productos obj = new RN_Productos();

           
            dt = await Task.Run(() => obj.RN_Buscar_Productos(valor));

            if(dt.Rows.Count > 0)
            {
                lsv_prodcto.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    ListViewItem list = new ListViewItem(dr["Id_Pro"].ToString());
                    list.SubItems.Add(dr["Descripcion_Larga"].ToString());//1
                    list.SubItems.Add(dr["Stock_Actual"].ToString());//2
                    list.SubItems.Add(dr["Pre_vntaxMenor"].ToString());//4  
                    list.SubItems.Add(dr["Pre_CompraS"].ToString());//3  
                    list.SubItems.Add(dr["Estado_Pro"].ToString());//9



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
           
           

        }
        
       


       // async
        private  void txt_buscar_KeyDown(object sender, KeyEventArgs e) //se agrego como el frm_explor_cliente cambio actualizado.
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                buscar_Productos(txt_buscar.Text);
            }
            else
            {
                Cargar_Todos_Productos();
            }
        }

        private void bt_copiarIDProductoTool_Click(object sender, EventArgs e)
        {
            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Addver ver = new Frm_Addver();

            //if (lsv_prodcto.SelectedIndices.Count == 0)
            //{
            //    fil.Show();
            //    ver.Lbl_Msm1.Text = "Selecciona el Item que desees copiar";
            //    ver.ShowDialog();
            //    fil.Hide();

            //}
            //else
            //{

            //    var lis = lsv_prodcto.SelectedItems[0];
            //    string idprovee = lis.SubItems[0].Text;

            //    Clipboard.Clear();
            //    Clipboard.SetText(idprovee.Trim());


            //}
        }

        

        private void bt_nuevoProductoTool_Click(object sender, EventArgs e)
        {
            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_AddProductos ad = new Frm_AddProductos();

            //fil.Show();
            //ad.ShowDialog();
            //fil.Hide();

            //if (ad.Tag.ToString() == "A")
            //{
            //    Cargar_Todos_Productos();

            //}
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

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void SeleccionarProducto()
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            
            RN_Productos obj = new RN_Productos();
            Frm_Edit_Precio canti = new Frm_Edit_Precio();

            double xcanti = 0;

            if(lsv_prodcto.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.Lbl_msm1.Text = "Seleccione el Item a editar";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lis = lsv_prodcto.SelectedItems[0];
                string idprod = lis.SubItems[0].Text;
                string nomprod = lis.SubItems[1].Text;
                double stockProd = Convert.ToDouble(lis.SubItems[2].Text);
                double preCompra1 = Convert.ToDouble(lis.SubItems[3].Text);


                fil.Show();
                canti.lbl_producto.Text = nomprod;
              
                canti.ShowDialog();
                fil.Hide();

                if(canti.Tag.ToString() == "A")
                {
                    //recuperamos la informacion recepcionada;

                    double precompra = Convert.ToDouble(canti.txt_precioCompra.Text);
                    double preventa = Convert.ToDouble( canti.txt_preVenta.Text);


                    obj.RN_Actualizar_PrecioCompra_Producto(idprod, precompra, preventa, 0, 0);

                    if(BD_Productos.seedito == true)
                    {
                        //una vez que se ajuste un producto quitarlo de la lista:
                        int i;
                        var liv = lsv_prodcto.SelectedItems[0];
                        for (i = lsv_prodcto.SelectedItems.Count - 1; i >= 0; i--)
                        {
                            lsv_prodcto.Items.Remove(lsv_prodcto.SelectedItems[i]);
                        }
                    }

                    
                }


            }



        }

        private void Registrar_MovimientoKardex(string idprod, double xcant, string cantDiferen, double precioDiferen)
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

            //string xidProd = "";
            //double xcant = 0;
            string xTipoProd = "";


            try
            {

                    if (obj.RN_Verificar_Producto_siTieneKardex(idprod) == true)
                    {
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
                            kar.Doc_soporte = "AJK00-0001"; //se puede colocar codigo idcorrelativo
                            kar.Det_Operacion = "Ajuste de Kardex Manual";
                            //Entrada
                            kar.Cantidad_in = 0;
                            kar.Precio_In = 0;
                            kar.Total_In = 0;
                            //salida:
                            kar.Cantidad_Out = xcant;
                            kar.Precio_out = precioCompraProd;
                            kar.Total_out = xcant * precioCompraProd;
                            //saldos:   //CALCULOS DE LOS KARDEX VALORIZADOS
                            kar.Cantidad_saldo =  xcant;
                            kar.Promedio = precioCompraProd;
                            kar.Total_saldo = precioCompraProd * kar.Cantidad_saldo;
                            kar.TipoOperacion = "Reset";

                            kar.CantiDiferencial = cantDiferen;
                            kar.ImporteDiferencial = precioDiferen;

                            obj.RN_Registrar_Detalle_Kardex(kar);

                        }

                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reg Kardex Capa Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }



       

        private void btn_reporte_Click(object sender, EventArgs e)
        {
            Frm_rpt_Productos oFrm_rpt = new Frm_rpt_Productos();
            oFrm_rpt.txt_valor.Text = txt_buscar.Text;
            oFrm_rpt.ShowDialog();

        }

        private void lsv_prodcto_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SeleccionarProducto();
        }

        private void Frm_Ajuste_Inventario_Krdx_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void lsv_prodcto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SeleccionarProducto();
            }
        }
    }
}
