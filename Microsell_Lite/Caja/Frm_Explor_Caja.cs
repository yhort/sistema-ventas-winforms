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
using Microsell_Lite.Informe;
using System.IO;


namespace Microsell_Lite.Caja
{
    public partial class Frm_Explor_Caja : Form
    {
        public Frm_Explor_Caja()
        {
            InitializeComponent();
           
        }

        private void Frm_Explor_Proveedor_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Convert.ToDateTime(dtp_hoy.Value = DateTime.Now);
            //Cargar_Todos_Cajas();
            buscar_movCaja_pordia(dtp_hoy.Value);
            
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
            lis.Columns.Add("ID", 60, HorizontalAlignment.Left); //0
            lis.Columns.Add("Nro Doc.", 100, HorizontalAlignment.Left); //2
            lis.Columns.Add("Nombre del Cliente", 330, HorizontalAlignment.Left); //3
            lis.Columns.Add("Fecha", 180, HorizontalAlignment.Left); //4
            lis.Columns.Add("Tipo Caja", 110, HorizontalAlignment.Left);//5
            lis.Columns.Add("Concepto", 150, HorizontalAlignment.Left);//5
            lis.Columns.Add("Total S/", 100, HorizontalAlignment.Right);//5
            lis.Columns.Add("Utilid. S/", 100, HorizontalAlignment.Right);//5
            lis.Columns.Add("Tipo Pago", 90, HorizontalAlignment.Left);//5
            lis.Columns.Add("Generado Por", 100, HorizontalAlignment.Left);//5
            lis.Columns.Add("Estado", 100, HorizontalAlignment.Left);//5




        }

        //llenar el listview:

        private void Llenar_Listview(DataTable data)
        {
          

            lsv_prodcto.Items.Clear();
            DateTime FechaCoti;
            double TotalCoti = 0;
            double saldocred = 0;

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Idcaja"].ToString());
                list.SubItems.Add(dr["Nro_Doc"].ToString());
                list.SubItems.Add(dr["De_Para"].ToString());
                list.SubItems.Add(dr["Fecha_Caja"].ToString());
                list.SubItems.Add(dr["Tipo_Caja"].ToString());
                list.SubItems.Add(dr["Concepto"].ToString());
                TotalCoti = Convert.ToDouble(dr["ImporteCaja"].ToString());
                list.SubItems.Add(TotalCoti.ToString("###0.00"));
                //saldo
                saldocred = Convert.ToDouble(dr["TotalUti"]);
                list.SubItems.Add(saldocred.ToString("###0.00"));



                list.SubItems.Add(dr["TipoPago"].ToString());
                list.SubItems.Add(dr["GeneradoPor"].ToString());
                list.SubItems.Add(dr["EstadoCaja"].ToString());

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

        private void buscar_movCaja_pordia(DateTime fechax)
        {
            RN_Caja obj = new RN_Caja();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Cajas_Del_Dia_Rep(fechax);
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

        private void Cargar_Todos_Cajas()
        {
            RN_Caja obj = new RN_Caja();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Todas_Cajas();
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

        private void buscar_Caja_porvalor(string valor)
        {
            RN_Caja obj = new RN_Caja();
            DataTable dato = new DataTable();

            dato = obj.RN_buscador_General_Cajas(valor);
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
           //if(txt_buscar.Text.Trim().Length > 2)
           // {
           //     buscar_Caja_porvalor(txt_buscar.Text);
           // }
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e) //se agrego como el frm_explor_cliente cambio actualizado.
        {

        }

        private void txt_buscar_OnValueChanged_1(object sender, EventArgs e)
        {
         

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
                string idprovee = lis.SubItems[0].Text;

                Clipboard.Clear();
                Clipboard.SetText(idprovee.Trim());


            }
        }

    

        private void bt_add_Click(object sender, EventArgs e)
        {
            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Add_Producto ad = new Frm_Add_Producto();
            

            //fil.Show();
            //ad.ShowDialog();
            //fil.Hide();

            //if (ad.Tag.ToString() =="A")
            //{
            //    Cargar_Todos_Cajas();

            //}
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
                Cargar_Todos_Cajas();

            }

        }

        private void bt_edit_Click(object sender, EventArgs e)
        {

        }

        private void editarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bt_edit_Click(sender, e);
        }

        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Todos_Cajas();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bt_edit1_Click(object sender, EventArgs e)
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
                    Cargar_Todos_Cajas();
                }


            }
        }

        private void txt_buscar1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_buscar1.Text.Trim().Length > 2)
                {
                    buscar_Caja_porvalor(txt_buscar1.Text);
                }
                else
                {
                    Cargar_Todos_Cajas();
                }
            }
        }

        private void txt_buscar1_OnValueChanged(object sender, EventArgs e)
        {
            if (txt_buscar1.Text.Trim().Length > 2)
            {
                buscar_Caja_porvalor(txt_buscar1.Text);
            }
        }

        private void lsv_prodcto_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void btn_ExpExcel_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);

            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];


            int linea = 2, columna = 1;

            ws.Cells[1, 1] = lsv_prodcto.Columns[0].Text;
            ws.Cells[1, 2] = lsv_prodcto.Columns[1].Text;
            ws.Cells[1, 3] = lsv_prodcto.Columns[2].Text;
            ws.Cells[1, 4] = lsv_prodcto.Columns[3].Text;
            ws.Cells[1, 5] = lsv_prodcto.Columns[4].Text;
            ws.Cells[1, 6] = lsv_prodcto.Columns[5].Text;
            ws.Cells[1, 7] = lsv_prodcto.Columns[6].Text;
            ws.Cells[1, 8] = lsv_prodcto.Columns[7].Text;
            ws.Cells[1, 9] = lsv_prodcto.Columns[8].Text;
            ws.Cells[1, 10] = lsv_prodcto.Columns[9].Text;
            ws.Cells[1, 11] = lsv_prodcto.Columns[10].Text;




            foreach (ListViewItem list in lsv_prodcto.Items)
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
            Frm_movCaja cja = new Frm_movCaja();
            Frm_Filtro fil = new Frm_Filtro();

           // Frm_SoloFecha fec = new Frm_SoloFecha();

            fil.Show();
            cja.Tag = dtp_hoy.Value;
            cja.Imprimir_MoviCaja(dtp_hoy.Value);
            fil.Hide();

           
          

        }

        private async void btn_consultar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ad = new Frm_Advertencia();
            Frm_FechasFiltro fec = new Frm_FechasFiltro();

            fil.Show();
            fec.lbl_nombre.Text = "Filtrar Movimientos de Caja";
            fec.ShowDialog();
            fil.Hide();

            //revisar porque al dar click en salta error 13/09/25
            if (fec.Tag?.ToString() == "A")
            {

                DateTime xfecha = fec.dtpfechaInicial.Value;
                DateTime xfecha2 = fec.dtpfechaFinal.Value;

                if (xfecha > xfecha2)
                {
                    //fil.Show();
                    ad.Lbl_msm1.Text = "La fecha Inicial no puede ser mayor a la fecha Final";
                    ad.ShowDialog();
                    //fil.Hide();
                    return;
                }

                // Ejecutar la operación de filtrado de datos en un hilo de fondo
                await Task.Run(() =>
                {
                    // Esta parte del código es segura en un hilo secundario
                    RN_Caja guiaRem = new RN_Caja();
                    DataTable tablax = guiaRem.RN_Filtrar_MoviCaja_xrangoFech(xfecha, xfecha2);

                    // Regresar al hilo principal para actualizar la UI
                    this.Invoke((MethodInvoker)delegate
                    {
                        // Este bloque de código ahora se ejecuta de forma segura en el hilo de la UI
                        if (tablax.Rows.Count > 0)
                        {
                            Llenar_Listview(tablax);
                            pnl_msm.Visible = false; // Oculta el panel de mensaje si hay datos
                        }
                        else
                        {
                            lsv_prodcto.Items.Clear();
                            pnl_msm.Visible = true; // Muestra el panel de mensaje si no hay datos
                        }
                    });
                });
            }

        }
    }
}
