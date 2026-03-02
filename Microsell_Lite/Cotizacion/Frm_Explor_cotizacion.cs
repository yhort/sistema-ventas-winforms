using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prj_Capa_Negocio;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Productos;
using Microsell_Lite.Cotizacion;

namespace Microsell_Lite.Cotizacion
{
    public partial class Frm_Explor_cotizacion : Form
    {
        public Frm_Explor_cotizacion()
        {
            InitializeComponent();
           
        }

        private void Frm_Explor_Proveedor_Load(object sender, EventArgs e)
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
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("ID", 80, HorizontalAlignment.Left); //0
            lis.Columns.Add("Nombre del Producto", 400, HorizontalAlignment.Left); //2
            lis.Columns.Add("Stock", 90, HorizontalAlignment.Left); //3
            lis.Columns.Add("Pre Compra", 80, HorizontalAlignment.Left); //4
            lis.Columns.Add("Frank", 80, HorizontalAlignment.Left);//5
            lis.Columns.Add("Precio Venta 1", 80, HorizontalAlignment.Left);//5
            lis.Columns.Add("Precio Venta 2", 80, HorizontalAlignment.Left);//5
            lis.Columns.Add("Utilidad", 80, HorizontalAlignment.Left);//5
            lis.Columns.Add("Total", 80, HorizontalAlignment.Left);//5
            lis.Columns.Add("Estado", 100, HorizontalAlignment.Left);//5
            lis.Columns.Add("marca", 100, HorizontalAlignment.Left);//5



        }

        //llenar el listview:

        private void Llenar_Listview(DataTable data)
        {
            lsv_prodcto.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Pro"].ToString());
                list.SubItems.Add(dr["Descripcion_Larga"].ToString());
                list.SubItems.Add(dr["Stock_Actual"].ToString());
                list.SubItems.Add(dr["Pre_CompraS"].ToString());
                list.SubItems.Add(dr["Frank"].ToString());
                list.SubItems.Add(dr["Pre_vntaxMenor"].ToString());
                list.SubItems.Add(dr["Pre_vntaxMayor"].ToString());
                list.SubItems.Add(dr["UtilidadUnit"].ToString());
                list.SubItems.Add(dr["Valor_porCant"].ToString());
                list.SubItems.Add(dr["Estado_Pro"].ToString());
                list.SubItems.Add(dr["Marca"].ToString());
                lsv_prodcto.Items.Add(list); //si ponemos esto,. el listview  nunca se llenara
            }
            Pintar_Filas();
            pnl_msm.Visible = false;
            lbl_totalItem.Text = lsv_prodcto.Items.Count.ToString();
        }

        private void Pintar_Filas()
        {
            int cont = 1;

            for (int i=0; i < lsv_prodcto.Items.Count; i++)
            {
                if (cont % 2 == 0)
                {

                }
                else
                {
                    lsv_prodcto.Items[i].BackColor = Color.WhiteSmoke;
                }
                cont += 1;
            }
        }

        private void Cargar_Todos_Productos()
        {
            RN_Productos obj = new RN_Productos();
            DataTable dato = new DataTable();

            dato = obj.RN_Mostrar_Todos_Productos();
            if (dato.Rows.Count >0)
            {
                Llenar_Listview(dato);

            }
            else
            {
                lsv_prodcto.Items.Clear();
                pnl_msm.Visible = true;
            }

        }

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

        private void txt_buscar_OnValueChanged(object sender, EventArgs e)//se agrego como el frm_explor_cliente cambio actualizado. vid.#15
        {
           if(txt_buscar.Text.Trim().Length > 2)
            {
                buscar_Productos(txt_buscar.Text);
            }
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e) //se agrego como el frm_explor_cliente cambio actualizado.
        {
            if(txt_buscar.Text.Trim().Length > 2)
            {
                buscar_Productos(txt_buscar.Text);
            }
            else
            {
                Cargar_Todos_Productos();
            }

            

        }

        private void txt_buscar_OnValueChanged_1(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                buscar_Productos(txt_buscar.Text);

            } 

        }

        private void elLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bt_copiarIDProveedorTool_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();

            if (lsv_prodcto.SelectedIndices .Count == 0)
            {
                fil.Show();
                ver.Lbl_Msm1.Text = "Selecciona el Item que desees copiar";
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

            if (ad.Tag.ToString() =="A")
            {
                Cargar_Todos_Productos();

            }
        }

        private void toolStripSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void bt_nuevoProveedorTool_Click(object sender, EventArgs e)
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

        private void bt_edit_Click(object sender, EventArgs e)
        {

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();
            Frm_Edit_Producto edi = new Frm_Edit_Producto();

            if (lsv_prodcto.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.Lbl_Msm1.Text = "Selecciona el Item que desees Editar";
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

        private void editarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
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

            if(e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);
            }
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }

        private void btn_cerrar_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_cerrar_Click_2(object sender, EventArgs e)
        {

        }

        private void bt_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_minimi_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
