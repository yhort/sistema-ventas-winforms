using Microsell_Lite.Informe;
using Microsell_Lite.Productos;
using Microsell_Lite.Utilitarios;
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
    public partial class Frm_Explo_Prod : Form
    {
        public Frm_Explo_Prod()
        {
            InitializeComponent();
        }

        private void Frm_Explo_Prod_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            //Cargar_Todos_Productos();
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
            lis.Columns.Add("Stock", 80, HorizontalAlignment.Left); //2
            lis.Columns.Add("Pre Compra", 60, HorizontalAlignment.Left); //3
            //lis.Columns.Add("Frank", 0, HorizontalAlignment.Left);//4
            lis.Columns.Add("Precio Venta 1", 60, HorizontalAlignment.Left);//5
            lis.Columns.Add("Precio Venta 2", 80, HorizontalAlignment.Center);//6
            lis.Columns.Add("Utilidad", 80, HorizontalAlignment.Left);//7
            lis.Columns.Add("Total", 90, HorizontalAlignment.Center);//8
            lis.Columns.Add("Estado", 100, HorizontalAlignment.Center);//9
            lis.Columns.Add("marca", 120, HorizontalAlignment.Left);//10
            lis.Columns.Add("TipoProd", 0, HorizontalAlignment.Left);//11

        }

        //llenar el listview:

            
        /*private void Llenar_Listview(DataTable data)
        {
            lsv_prodcto.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Pro"].ToString());//0
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
                lsv_prodcto.Items.Add(list); //si no ponemos esto,. el listview  nunca se llenara
            }
            //Pintar_Filas();
            pnl_msm.Visible = false;
            lbl_totalItem.Text = lsv_prodcto.Items.Count.ToString();
        }
        */

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
        
        private  async void Cargar_Todos_Productos()
        {
            
            RN_Productos obj = new RN_Productos();
        
           // DataTable dato = new DataTable();


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

            timerBusqueda.Stop();
            timerBusqueda.Start();
            
            //RN_Productos obj = new RN_Productos();
            //if(txt_buscar.Text.Trim().Length > 0)
            //{
            //    await Buscar_Productos_xvalor(txt_buscar.Text);
            //}
            
            
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
                    list.SubItems.Add(dr["Pre_CompraS"].ToString());//3
                    //list.SubItems.Add(dr["Frank"].ToString());//4
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

        }
        
       


       // async
        private  async void txt_buscar_KeyDown(object sender, KeyEventArgs e) //se agrego como el frm_explor_cliente cambio actualizado.
        {
            if (e.KeyCode == Keys.Enter) 
            { 
                e.SuppressKeyPress = true;

                string valor = txt_buscar.Text.Trim()
                    .Replace("\r", "")
                    .Replace("\n", "")
                    .Replace("\t", "");

                if (valor.Length > 2) 
                {
                    await Buscar_Productos_xvalor(valor);
                }
            }


            //if (txt_buscar.Text.Trim().Length > 2)
            //{
            //    //buscar_Productos(txt_buscar.Text);
            //    await Buscar_Productos_xvalor(txt_buscar.Text);
            //}
            //else
            //{
            //    Cargar_Todos_Productos();
            //}
        }

        private void bt_copiarIDProductoTool_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (lsv_prodcto.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.Lbl_msm1.Text = "Selecciona el Item que desees copiar";
                ver.ShowDialog();
                fil.Hide();

            }
            else
            {

                var lis = lsv_prodcto.SelectedItems[0];
                string idprovee = lis.SubItems[0].Text;

                Clipboard.Clear();
                Clipboard.SetText(idprovee.Trim());


            }
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_AddProductos ad = new Frm_AddProductos();


            fil.Show();
            ad.ShowDialog();
            fil.Hide();

            if (ad.Tag.ToString() == "A")
            {
                Cargar_Todos_Productos();

            }
        }

        private void bt_nuevoProductoTool_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_AddProductos ad = new Frm_AddProductos();

            fil.Show();
            ad.ShowDialog();
            fil.Hide();

            if (ad.Tag.ToString() == "A")
            {
                Cargar_Todos_Productos();

            }
        }


        private void editarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bt_edit_Click(sender, e);

        }


        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Todos_Productos();
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


        private void bt_importar_ExcelMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Importar_Prod adx = new Frm_Importar_Prod();

            fil.Show();
            adx.ShowDialog();
            fil.Hide();

            if (adx.Tag.ToString() == "A")
            {
                Cargar_Todos_Productos();

            }
        }



        private void bt_edit_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Edit_Producto edi = new Frm_Edit_Producto();

            if (lsv_prodcto.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.Lbl_msm1.Text = "Selecciona el Item que desees Editar";
                ver.ShowDialog();
                fil.Hide();

            }
            else
            {

                var lis = lsv_prodcto.SelectedItems[0];
                string idprod = lis.SubItems[0].Text;

                fil.Show();
                edi.Tag = idprod;
                edi.ShowDialog();
                fil.Hide();

                if (edi.Tag.ToString() == "A")
                {
                    Cargar_Todos_Productos();
                }


            }
        }

        private void calcularValorDeAlmacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string idprod;
            string tipoProd;
            int contador = 0;

            int totalfila = lsv_prodcto.Items.Count;
            gunaCircleProgressBar1.Maximum = totalfila;

            RN_Productos obj = new RN_Productos();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            try
            {
                for (int i = 0; i < lsv_prodcto.Items.Count; i++)
                {
                    idprod = lsv_prodcto.Items[i].SubItems[0].Text;

                    obj.RN_calcular_Valor_almacen(idprod.Trim());
                    obj.RN_calcular_utilidad_almacen(idprod.Trim());

                    contador += 1;
                    //tipoProd = lsv_prodcto.Items[i].SubItems[11].Text;

                    //if (tipoProd.Trim() == "Producto")
                    //{
                    //    obj.RN_calcular_Valor_almacen(idprod.Trim());
                    //    contador += 1;
                    //}

                    gunaCircleProgressBar1.Value = i;
                    gunaCircleProgressBar1.Refresh();
                }

                fil.Show();
                MessageBox.Show("Un total de: " + contador.ToString() + " Productos se Calcularon su valor de Almacen y Utilidad", "Calcular Valor de Almacen y Utilidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fil.Hide();
                Cargar_Todos_Productos();
            }
            catch (Exception ex)
            {

                fil.Show();
                ver.Lbl_msm1.Text = "Algo Salió mal en la Actualización " + ex.Message; ver.ShowDialog();
                fil.Hide();

            }
        }

        private void imprimirReporteProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

       

        private void btn_eliminarProd_Click(object sender, EventArgs e)
        {

            if (lsv_prodcto.SelectedIndices.Count == 0)
            {

                MessageBox.Show("Selecciona el Producto para Eliminar", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {

                var lis = lsv_prodcto.SelectedItems[0];
                string idprod = lis.SubItems[0].Text;


                Frm_Sino sino = new Frm_Sino();

                sino.Lbl_msm1.Text = "¿Estas Seguro de eliminar el Producto?";
                sino.ShowDialog();

                if (sino.Tag.ToString() == "Si")
                {
                    RN_Productos obj = new RN_Productos();
                    obj.RN_darBaja_Producto(idprod);
                    Cargar_Todos_Productos();
                }

            }
        }

        private void btn_reporte_Click(object sender, EventArgs e)
        {
            Frm_rpt_Productos oFrm_rpt = new Frm_rpt_Productos();
            oFrm_rpt.txt_valor.Text = txt_buscar.Text;
            oFrm_rpt.ShowDialog();

        }

        private async void timerBusqueda_Tick(object sender, EventArgs e)
        {
            timerBusqueda.Stop();

            string valor = txt_buscar.Text.Trim()
            .Replace("\r", "")
            .Replace("\n", "")
            .Replace("\t", "");

            if (valor.Length > 2)
            {
                await Buscar_Productos_xvalor(valor);
            }
            else
            {
                Cargar_Todos_Productos();
            }

        }
    }
}
