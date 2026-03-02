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

namespace Microsell_Lite.Productos
{
    public partial class Frm_Explor_Movim_Prod : Form
    {
        public Frm_Explor_Movim_Prod()
        {
            InitializeComponent();
           
        }

        private void Frm_Explor_Movim_Prod_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            dtp_diax.Value = DateTime.Now;
            buscar_kardex_delDia(dtp_diax.Value);


            //buscar_kardex_delDia(dtp_dia.Value);
            //buscar_kardex_delDia(dtp_diax.Value);
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
            lis.Columns.Add("ID", 0, HorizontalAlignment.Left); //0
            lis.Columns.Add("Item", 40, HorizontalAlignment.Left); //2
            lis.Columns.Add("Fecha Emis.", 150, HorizontalAlignment.Left); //3
            lis.Columns.Add("Doc Soporte", 115, HorizontalAlignment.Left); //4
            lis.Columns.Add("Detalle Movimiento", 146, HorizontalAlignment.Left);//5
            lis.Columns.Add("Entrada", 60, HorizontalAlignment.Left);//5
            lis.Columns.Add("Salida", 60, HorizontalAlignment.Left);//5
            lis.Columns.Add("Saldos", 60, HorizontalAlignment.Left);//5
            lis.Columns.Add("id prod", 0, HorizontalAlignment.Left);//5
            lis.Columns.Add("Producto", 255, HorizontalAlignment.Left);//5
            lis.Columns.Add("Observacion", 200, HorizontalAlignment.Left);

        }

        //llenar el listview:

        private void Llenar_Listview(DataTable data)
        {
            lsv_prodcto.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_krdx"].ToString());
                list.SubItems.Add(dr["Item"].ToString());
                list.SubItems.Add(dr["Fecha_Krdx"].ToString());
                list.SubItems.Add(dr["Doc_Soporte"].ToString().Trim());
                list.SubItems.Add(dr["Det_Operacion"].ToString());
                list.SubItems.Add(dr["Cantidad_In"].ToString());
                list.SubItems.Add(dr["Cantidad_Out"].ToString());
                list.SubItems.Add(dr["Cantidad_Saldo"].ToString());
                list.SubItems.Add(dr["Id_Pro"].ToString());
                list.SubItems.Add(dr["Descripcion_Larga"].ToString());
                list.SubItems.Add(dr["Observacion"].ToString());
                lsv_prodcto.Items.Add(list); //si ponemos esto,. el listview  nunca se llenara
            }
            //Pintar_Filas();
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
        private void buscar_kardex_delDia(DateTime dia)
        {
            DateTime diaSinHora = dia.Date;
            RN_Kardex obj = new RN_Kardex();
            DataTable dato = new DataTable();
            dato = obj.RN_Cargar_DetalleKardex_delDia(diaSinHora);
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

        private void buscar_kardex_PorProd(string prod)
        {
            RN_Kardex obj = new RN_Kardex();
            DataTable dato = new DataTable();
            dato = obj.RN_Buscar_KardexDetalle_porProducto(prod);

            if(dato.Rows.Count > 0)
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
                buscar_kardex_PorProd(txt_buscar.Text);
            }
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e) //se agrego como el frm_explor_cliente cambio actualizado.
        {
            if(txt_buscar.Text.Trim().Length > 2)
            {
                buscar_kardex_PorProd(txt_buscar.Text);
            }
            else
            {
                buscar_kardex_delDia(dtp_diax.Value);
            }
        }

        private void txt_buscar_OnValueChanged_1(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                buscar_kardex_PorProd(txt_buscar.Text);
            } 
        }
        private void elLabel1_Click(object sender, EventArgs e)
        {

        }
        private void bt_copiarIDProveedorTool_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (lsv_prodcto.SelectedIndices .Count == 0)
            {
                fil.Show();
                ver.Lbl_msm1.Text = "Selecciona el Item que desees copiar";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lis = lsv_prodcto.SelectedItems[0];
                string idprovee = lis.SubItems[8].Text; // se ponde desde el listview el numero de colummna a copiar

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

            }
        }

        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_SoloFecha solo = new Frm_SoloFecha();

            fil.Show();
            solo.ShowDialog();
            fil.Hide();

            if (solo.Tag.ToString() == "A")
            {

                DateTime xfecha = solo.dtp_fecha.Value;
                buscar_kardex_delDia(xfecha);

            }
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

        private void dtp_diax_ValueChanged(object sender, EventArgs e)
        {
            buscar_kardex_delDia(dtp_diax.Value);
        }
    }
}
