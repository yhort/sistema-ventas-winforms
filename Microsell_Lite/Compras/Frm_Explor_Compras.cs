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
using Microsell_Lite.Compras;


namespace Microsell_Lite.Compras
{
    public partial class Frm_Explor_Compras : Form
    {
        public Frm_Explor_Compras()
        {
            InitializeComponent();
           
        }

        private void Frm_Explor_Proveedor_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_Todos_Compras();
        }

        //configurar nuestro listview

        private void Configurar_listView()
        {

            var lis = lsv_com;

            lsv_com.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("ID Interno", 105, HorizontalAlignment.Left); //0
            lis.Columns.Add("Nro Fisico", 110, HorizontalAlignment.Left); //3
            lis.Columns.Add("Nombre Proveedor", 350, HorizontalAlignment.Left); //2
            lis.Columns.Add("Fecha Emision", 100, HorizontalAlignment.Left); //4
            lis.Columns.Add("Total S/", 100, HorizontalAlignment.Left);//5
            lis.Columns.Add("Forma Pago", 100, HorizontalAlignment.Left);//5
            //lis.Columns.Add("Tipo Ingreso", 100, HorizontalAlignment.Left);//5 vista en base datos 
            lis.Columns.Add("Tipo Doc", 100, HorizontalAlignment.Left);//5
            lis.Columns.Add("Estado", 110, HorizontalAlignment.Left);//5
            lis.Columns.Add("Observacion", 0, HorizontalAlignment.Left);//5




        }

        //llenar el listview:

        private void Llenar_Listview(DataTable data)
        {
            lsv_com.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_DocComp"].ToString());
                list.SubItems.Add(dr["NroFac_Fisico"].ToString());
                list.SubItems.Add(dr["NOMBRE"].ToString());
                list.SubItems.Add(dr["Fecha_Ingre"].ToString());
                list.SubItems.Add(dr["Total_Ingre"].ToString());
                list.SubItems.Add(dr["ModalidadPago"].ToString());
                list.SubItems.Add(dr["TipoDoc_Compra"].ToString());
                list.SubItems.Add(dr["Estado_Ingre"].ToString());
                list.SubItems.Add(dr["Datos_Adicional"].ToString());  
                lsv_com.Items.Add(list); //si ponemos esto,. el listview  nunca se llenara
            }
            Pintar_Filas();
            pnl_msm.Visible = false;
            lbl_totalItem.Text = lsv_com.Items.Count.ToString();
        }

        private void Pintar_Filas()
        {
            int cont = 1;

            for (int i=0; i < lsv_com.Items.Count; i++)
            {
                if (cont % 2 == 0)
                {

                }
                else
                {
                    lsv_com.Items[i].BackColor = Color.WhiteSmoke;
                }
                cont += 1;
            }
        }

        private void Cargar_Todos_Compras()
        {
            RN_Ingreso_Compra obj = new RN_Ingreso_Compra();
            DataTable dato = new DataTable();

            dato = obj.RN_Cargar_Todas_Compras();
            if (dato.Rows.Count >0)
            {
                Llenar_Listview(dato);

            }
            else
            {
                lsv_com.Items.Clear();
                pnl_msm.Visible = true;
            }

        }

        private void buscar_compras(string valor)
        {
            RN_Ingreso_Compra obj = new RN_Ingreso_Compra();
            DataTable dato = new DataTable();

            dato = obj.RN_buscar_Compras_Explorador(valor);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_com.Items.Clear();
                pnl_msm.Visible = true;
            }

        }

        //por fecha
        private void buscar_compras_pordia(DateTime fechax)
        {
            RN_Ingreso_Compra obj = new RN_Ingreso_Compra();
            DataTable dato = new DataTable();

            dato = obj.RN_buscar_Compras_Explorador_Pormes_Dia("dia", fechax);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_com.Items.Clear();
                pnl_msm.Visible = true;
            }

        }

        //por mes:

   
        private void buscar_compras_porMes(DateTime fechax)
        {
            RN_Ingreso_Compra obj = new RN_Ingreso_Compra();
            DataTable dato = new DataTable();

            dato = obj.RN_buscar_Compras_Explorador_Pormes_Dia("mes", fechax);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_com.Items.Clear();
                pnl_msm.Visible = true;
            }

        }


        private void txt_buscar_OnValueChanged(object sender, EventArgs e)//se agrego como el frm_explor_cliente cambio actualizado. vid.#15
        {
           if(txt_buscar.Text.Trim().Length > 2)
            {
                buscar_compras(txt_buscar.Text);
            }
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e) //se agrego como el frm_explor_cliente cambio actualizado.
        {
            if(txt_buscar.Text.Trim().Length > 2)
            {
                buscar_compras(txt_buscar.Text);
            }
            else
            {
                Cargar_Todos_Compras();
            }

            

        }

        private void txt_buscar_OnValueChanged_1(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                buscar_compras(txt_buscar.Text);

            } 

        }

        private void elLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bt_copiarIDProveedorTool_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (lsv_com.SelectedIndices .Count == 0)
            {
                fil.Show();
                ver.Lbl_msm1.Text = "Selecciona el Item que desees copiar";
                ver.ShowDialog();
                fil.Hide();

            }
            else
            {

                var lis = lsv_com.SelectedItems[0];
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
                Cargar_Todos_Compras();

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
                Cargar_Todos_Compras();

            }

        }

        private void bt_edit_Click(object sender, EventArgs e)
        {

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Edit_Producto edi = new Frm_Edit_Producto();

            if (lsv_com.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.Lbl_msm1.Text = "Selecciona el Item que desees Editar";
                ver.ShowDialog();
                fil.Hide();

            }
            else
            {

                var lis = lsv_com.SelectedItems[0];
                string idprod = lis.SubItems[0].Text;

                fil.Show();
                edi.Tag = idprod;
                edi.ShowDialog();
                fil.Hide();

                if (edi.Tag.ToString() == "A")
                {
                    Cargar_Todos_Compras();
                }


            }


        }

        private void editarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bt_edit_Click(sender, e);
        }

        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Todos_Compras();
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

        private void elLabel14_Click(object sender, EventArgs e)
        {

        }

        private void cargarComprasDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_SoloFecha solo = new Frm_SoloFecha();

            fil.Show();
            solo.ShowDialog();
            fil.Hide();

            if (solo.Tag.ToString() =="A")
            {
                DateTime xfecha = solo.dtp_fecha.Value;

                buscar_compras_pordia(xfecha);
            }
        }

        private void buscarComprasDelMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_SoloFecha solo = new Frm_SoloFecha();

            fil.Show();
            solo.ShowDialog();
            fil.Hide();

            if (solo.Tag.ToString() == "A")
            {
                DateTime xfecha = solo.dtp_fecha.Value;

                buscar_compras_porMes (xfecha);
            }
        }

        private void lsv_com_MouseDoubleClick(object sender, MouseEventArgs e)
        {


            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_verDet_Compra edi = new Frm_verDet_Compra();

            if (lsv_com.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.Lbl_msm1.Text = "Selecciona el Item";
                ver.ShowDialog();
                fil.Hide();

            }
            else
            {

                var lis = lsv_com.SelectedItems[0];
                string idcompra = lis.SubItems[0].Text;

                fil.Show();
                edi.Tag = idcompra;
                edi.ShowDialog();
                fil.Hide();

            }


        }

        private void imprimirComprasDelMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Filtro_xFechas comp = new  Frm_Filtro_xFechas();

            fil.Show();
            
            comp.ShowDialog();
            fil.Hide();

        }
    }
}
