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
using Microsell_Lite.Ventas;
using Microsell_Lite.Reportes_Consolidado;
//pdf
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp.tool.xml;
using System.IO;
//using Microsoft.Office.Interop.Excel;

//using Microsoft.Office.Interop.Excel;


namespace Microsell_Lite.Ventas
{
    public partial class Frm_Explor_Documento : Form
    {
        public Frm_Explor_Documento()
        {
            InitializeComponent();
           
        }

        private void Frm_Explor_Documento_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            buscar_Documento_pordia(dtp_hoy.Value); //para que solo cargue las ventas del dia.en el form
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
            lis.Columns.Add("ID Doc.", 110, HorizontalAlignment.Left); //82
            lis.Columns.Add("Fecha Emi", 131, HorizontalAlignment.Left); //1
            lis.Columns.Add("Nombre del Cliente", 268, HorizontalAlignment.Left); //2
            lis.Columns.Add("DNI ó RUC", 90, HorizontalAlignment.Left);//3
            lis.Columns.Add("Tipo Doc", 60, HorizontalAlignment.Left); //4 
            //lis.Columns.Add("Nro Pedido", 0, HorizontalAlignment.Left);//5
            lis.Columns.Add("Tipo Pago", 60, HorizontalAlignment.Left);//6
            lis.Columns.Add("Importe", 60, HorizontalAlignment.Left);//6

            lis.Columns.Add("Estado Doc", 60, HorizontalAlignment.Left);//3
            lis.Columns.Add("Cdr_Sunat", 60, HorizontalAlignment.Left); //4 
            lis.Columns.Add("Baja Sunat", 60, HorizontalAlignment.Left);//5
            lis.Columns.Add("Vendedor", 60, HorizontalAlignment.Left);//6

            /*

            //añadiendo nuevos campor para interfaz excel
            lis.Columns.Add("Igv", 60, HorizontalAlignment.Left);//7
            lis.Columns.Add("SubTotal", 60, HorizontalAlignment.Left);//8
            lis.Columns.Add("Total S/", 180, HorizontalAlignment.Left);//9
            lis.Columns.Add("Estado Doc", 80, HorizontalAlignment.Left);//10
            lis.Columns.Add("Vendedor", 200, HorizontalAlignment.Left);//11

            */

            //sunat

        }

        //llenar el listview:

        private void Llenar_Listview(DataTable data)
        {
            lsv_com.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["id_Doc"].ToString());
                list.SubItems.Add(dr["Fecha_Emi"].ToString());
                list.SubItems.Add(dr["Razon_Social_Nombres"].ToString());
                list.SubItems.Add(dr["DNI"].ToString());
                list.SubItems.Add(dr["Documento"].ToString());
                //list.SubItems.Add(dr["id_Ped"].ToString());
                list.SubItems.Add(dr["TipoPago"].ToString());
                list.SubItems.Add(dr["ImporteDoc"].ToString());
                list.SubItems.Add(dr["Estado_Doc"].ToString());
                list.SubItems.Add(dr["CdrSunat"].ToString());
                list.SubItems.Add(dr["EstadoBaja"].ToString());
                list.SubItems.Add(dr["Nombres"].ToString());




                /* --Para excwel
                list.SubItems.Add(dr["IgvDoc"].ToString());
                list.SubItems.Add(dr["SubTotal"].ToString());
                list.SubItems.Add(dr["ImporteDoc"].ToString());
                list.SubItems.Add(dr["Estado_Doc"].ToString());
                list.SubItems.Add(dr["Nombres"].ToString());  
                */


                lsv_com.Items.Add(list); //si no ponemos esto,. el listview  nunca se llenara
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

        private void Cargar_Todos_Ventas()
        {
            RN_Documento obj = new RN_Documento();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Todos_Documentos();
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

        private void buscar_Docu_Ventas(string valor)
        {
            RN_Documento obj = new RN_Documento();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscador_Documentos_porValor(valor);
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
        private void buscar_Documento_pordia(DateTime fechax)
        {
            RN_Documento obj = new RN_Documento();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscador_Documentos_porDia(fechax);
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
        //Se cambia a public para obtener desde el main
   
        public void buscar_Ventas_porMes(DateTime fechax)
        {
            RN_Documento  obj = new RN_Documento();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscador_Documentos_porMes(fechax);
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
           //if(txt_buscar.Text.Trim().Length > 2) ACTIVADO KEYDOWN 1
           // {
           //     buscar_Docu_Ventas(txt_buscar.Text);
           // }
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e) //se agrego como el frm_explor_cliente cambio actualizado.
        {

            if(e.KeyCode == Keys.Enter)   //se agrego if e.keycode.. se puede quitar tbm clas 36 min 15:44
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    buscar_Docu_Ventas(txt_buscar.Text);
                }
                else
                {
                    Cargar_Todos_Ventas();
                }
            }
        }
        private void txt_buscar_OnValueChanged_1(object sender, EventArgs e) //hay 2 onvaluechaged validar funcion en propiedades
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                buscar_Docu_Ventas(txt_buscar.Text);

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

   
        private void toolStripSeparator2_Click(object sender, EventArgs e)
        {

        }

 
        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Todos_Ventas();
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
            this.WindowState = FormWindowState.Maximized;
        }

        private void btn_cerrar_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_cerrar_Click_2(object sender, EventArgs e)
        {

        }

        private void bt_cerrar_Click(object sender, EventArgs e)
        {
            //this.Tag = "";
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
                buscar_Documento_pordia(xfecha);

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

                buscar_Ventas_porMes(xfecha);
            }
        }

        private void lsv_com_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_verDet_Documento docdet = new Frm_verDet_Documento();

            if (lsv_com.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.Lbl_msm1.Text = "Selecciona el Item para mostrar el detalle";
                ver.ShowDialog();
                fil.Hide();

            }
            else
            {

                var lis = lsv_com.SelectedItems[0];
                string idcompra = lis.SubItems[0].Text;

                fil.Show();
                docdet.Tag = idcompra;
                docdet.ShowDialog();
                fil.Hide();

            }


            /*

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();
            //Frm_verDet_Compra edi = new Frm_verDet_Compra();

            if (lsv_com.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.Lbl_Msm1.Text = "Selecciona el Item";
                ver.ShowDialog();
                fil.Hide();

            }
            else
            {

                var lis = lsv_com.SelectedItems[0];
                string idcompra = lis.SubItems[0].Text;

                fil.Show();
                //edi.Tag = idcompra;
                //edi.ShowDialog();
                fil.Hide();

                //    //if (edi.Tag.ToString() == "A") // 
                //    //{
                //    //    Cargar_Todos_Ventas();
                //    //}


            }
            */





        }

        private void bt_reimprimirDocumentoTool_Click(object sender, EventArgs e)
        {
           
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            //Frm_Crear_Ventas ven = new Frm_Crear_Ventas();
            Frm_Reimprimir r = new Frm_Reimprimir();

            if (lsv_com.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.Lbl_msm1.Text = "Selecciona el Item que deseas Reimprimir";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lis = lsv_com.SelectedItems[0];
                string iddoc = lis.SubItems[0].Text;

                fil.Show();

                r.txt_buscar.Text = iddoc;
                //r.txt_buscar.Text = iddoc;
                r.ShowDialog();
                fil.Hide();
            }
            /*
             * para seleccionar multiples docu,  se trabajo en otro form:
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();
            Frm_Reimprimir r = new Frm_Reimprimir();

            //esto funciona si selecciona con el mouse lsv_com.SelectedIndices.Count == 0

            if (lsv_com.CheckedItems.Count == 0)
            {
                fil.Show();
                ver.Lbl_Msm1.Text = "Selecciona al menos un Item que deseas Reimprimir";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                // Crear una lista para almacenar los IDs seleccionados
                List<string> ids = new List<string>();

                // Recorre los elementos seleccionados y agrega los IDs a la lista
                foreach (ListViewItem item in lsv_com.CheckedItems) //mouse elec SelectedItems
                {
                    string iddoc = item.SubItems[0].Text; // Asumiendo que el ID está en la primera columna
                    ids.Add(iddoc);
                }

                // Mostrar el filtro (si es necesario)
                fil.Show();

                // Pasar la lista de IDs al formulario principal
                r.txt_buscar.Text = string.Join(",", ids); // Puedes pasar los IDs como una cadena separada por comas

                // Mostrar el formulario de reimpresión
                r.ShowDialog();

                fil.Hide();
            }*/

        }
        private void pnl_msm_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private void btn_ExpExcel_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);

            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];


            int linea = 2, columna = 1;

            ws.Cells[1, 1] = lsv_com.Columns[0].Text;
            ws.Cells[1, 2] = lsv_com.Columns[1].Text;
            ws.Cells[1, 3] = lsv_com.Columns[2].Text;
            ws.Cells[1, 4] = lsv_com.Columns[3].Text;
            ws.Cells[1, 5] = lsv_com.Columns[4].Text;
            ws.Cells[1, 6] = lsv_com.Columns[5].Text;
            ws.Cells[1, 7] = lsv_com.Columns[6].Text;
            ws.Cells[1, 8] = lsv_com.Columns[7].Text;
            ws.Cells[1, 9] = lsv_com.Columns[8].Text;
            ws.Cells[1, 10] = lsv_com.Columns[9].Text;
            ws.Cells[1, 11] = lsv_com.Columns[10].Text;
            



            foreach (ListViewItem list in lsv_com.Items)
            {
                columna = 1;
                foreach (ListViewItem.ListViewSubItem lvs in list.SubItems)
                {
                    ws.Cells[linea, columna] = lvs.Text;
                    columna++;
                }
                linea++;
            }

        }

        private void btn_print_Click(object sender, EventArgs e)
        {

            //Reportes_Consolidado.Frm_Rpt_Ventas oRpt_Ventas = new Reportes_Consolidado.Frm_Rpt_Ventas();
            //oRpt_Ventas.txt_p1.Text = Convert.ToString(dtp_hoy.Value);
            //oRpt_Ventas.ShowDialog();
        }

        private void bt_crearGuiaDeRemisiónRemitenteTool_Click(object sender, EventArgs e)
        {

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_GuiaRemision gr = new Frm_GuiaRemision();

            if (lsv_com.CheckedItems.Count == 0)
            {
                fil.Show();
                ver.Lbl_msm1.Text = "Selecciona al menos un Item para Generar la Guía Remisión";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                // Crear una lista para almacenar los IDs seleccionados
                List<string> ids = new List<string>();

                // Recorre los elementos seleccionados y agrega los IDs a la lista
                foreach (ListViewItem item in lsv_com.CheckedItems) //mouse elec SelectedItems
                {
                    string iddoc = item.SubItems[0].Text; // Asumiendo que el ID está en la primera columna
                    ids.Add(iddoc);
                }

                gr.CargarIds(ids);

                //Mostrar el formulario de la guia de remision
                gr.btn_Nuevo_buscarProd.Enabled = false;
                //gr.bt_add.Enabled = false;
                //gr.bt_editCant.Enabled = false;
                //gr.bt_editPre.Enabled = false;
                //gr.bt_Delete.Enabled = false;
                gr.ShowDialog();
               
            }
            /*
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_GuiaRemision gr = new Frm_GuiaRemision();    
            if(lsv_com.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.Lbl_msm1.Text = "Selecciona el Item para generar la Guia De Remisión";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lis = lsv_com.SelectedItems[0];
                string iddoc = lis.SubItems[0].Text;
                fil.Show();
                gr.Txt_buscarFac.Text = iddoc;
                gr.btn_Nuevo_buscarProd.Enabled = false;
                gr.ShowDialog();
                fil.Hide();

            }*/
        }
    }
}
