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
using Prj_Capa_Entidad;
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
using ClosedXML.Excel;
//using Microsoft.Office.Interop.Excel;

//using Microsoft.Office.Interop.Excel;


namespace Microsell_Lite.GUIAREMISION
{
    public partial class Frm_Listado_GrTransprt : Form
    {
        public Frm_Listado_GrTransprt()
        {
            InitializeComponent();
           
        }

        private void Frm_Explor_Documento_Load(object sender, EventArgs e)
        {
            


            Llenar_Combo_Cliente();
            Configurar_listView();
            //buscar_Documento_pordia(dtp_hoy.Value); //para que solo cargue las ventas del dia.en el form
           
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
            lis.Columns.Add("ID Doc.", 120, HorizontalAlignment.Left); //0
            lis.Columns.Add("Fecha Emi", 150, HorizontalAlignment.Left); //1
            lis.Columns.Add("Cliente", 330, HorizontalAlignment.Left); //1
            lis.Columns.Add("Estado Cdr", 90, HorizontalAlignment.Center); //1

        }
        //llenar el listview:
        private void Llenar_Listview(DataTable data)
        {
            lsv_com.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["idGuiaRemision"].ToString());
                list.SubItems.Add(dr["Fecha_emision"].ToString()); 
                list.SubItems.Add(dr["Nombre_Cliente"].ToString()); 
                list.SubItems.Add(dr["cdr_sunat"].ToString());

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
            //RN_Documento obj = new RN_Documento();
            //DataTable dato = new DataTable();

            //dato = obj.RN_Listar_Todos_Documentos();
            //if (dato.Rows.Count > 0)
            //{
            //    Llenar_Listview(dato);

            //}
            //else
            //{
            //    lsv_com.Items.Clear();
            //    pnl_msm.Visible = true;
            //}

        }

        private void buscar_Docu_GrTransport(string valor)
        {
            try
            {
                RN_GuiaRemision obj = new RN_GuiaRemision();
                DataTable dato = new DataTable();

                dato = obj.RN_Buscar_GuiaRemisionRem(valor);
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
            catch (Exception ex)
            {

                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    //buscar_Docu_Ventas(txt_buscar.Text);
                }
                else
                {
                    Cargar_Todos_Ventas();
                }
            }

        }

        private void txt_buscar_OnValueChanged_1(object sender, EventArgs e) //hay 2 onvaluechaged validar funcion en propiedades
        {

        }

        private void elLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bt_copiarIDProveedorTool_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();

            if (lsv_com.SelectedIndices .Count == 0)
            {
                fil.Show();
                ver.Lbl_Msm1.Text = "Selecciona el Item que desees copiar";
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
            Frm_Addver ver = new Frm_Addver();
            Frm_verDet_Documento docdet = new Frm_verDet_Documento();

            if (lsv_com.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.Lbl_Msm1.Text = "Selecciona el Item para mostrar el detalle";
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
            Frm_Addver ver = new Frm_Addver();
            //Frm_Crear_Ventas ven = new Frm_Crear_Ventas();
            Frm_Reimprimir r = new Frm_Reimprimir();

            if (lsv_com.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.Lbl_Msm1.Text = "Selecciona el Item que deseas Reimprimir";
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

        }

        private void pnl_msm_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            //Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            //app.Visible = true;
            //Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);

            //Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];


            //int linea = 2, columna = 1;

            //ws.Cells[1, 1] = lsv_com.Columns[0].Text;
            //ws.Cells[1, 2] = lsv_com.Columns[1].Text;
            //ws.Cells[1, 3] = lsv_com.Columns[2].Text;
            //ws.Cells[1, 4] = lsv_com.Columns[3].Text;
            //ws.Cells[1, 5] = lsv_com.Columns[4].Text;
            //ws.Cells[1, 6] = lsv_com.Columns[5].Text;
            //ws.Cells[1, 7] = lsv_com.Columns[6].Text;
            //ws.Cells[1, 8] = lsv_com.Columns[7].Text;
            //ws.Cells[1, 9] = lsv_com.Columns[8].Text;
            //ws.Cells[1, 10] = lsv_com.Columns[9].Text;
            //ws.Cells[1, 11] = lsv_com.Columns[10].Text;

            //foreach (ListViewItem list in lsv_com.Items)
            //{
            //    columna = 1;
            //    foreach (ListViewItem.ListViewSubItem lvs in list.SubItems)
            //    {
            //        ws.Cells[linea, columna] = lvs.Text;
            //        columna++;
            //    }
            //    linea++;
            //}
        }

        private async void btn_ExpExcel_Click(object sender, EventArgs e)
        {

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_Loading_SendMail cargando = new Frm_Loading_SendMail();
            Frm_FechasFiltro fech = new Frm_FechasFiltro();

            fil.Show();
            fech.lbl_nombre.Text = "Reporte Guias de Remision";
            fech.ShowDialog();
            fil.Hide();

            if (fech.Tag?.ToString() == "A")
            {
                DateTime desde = fech.dtpfechaInicial.Value.Date;
                DateTime hasta = fech.dtpfechaFinal.Value.Date;

                try
                {
                    // MOVER EL SaveFileDialog AL HILO PRINCIPAL
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Excel (*.xlsx)|*.xlsx";
                    sfd.FileName = $"Reporte_GuiasRem_{desde:yyyyMMdd}_{hasta:yyyyMMdd}.xlsx";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        string ruta = sfd.FileName;
                        // Mostrar el formulario de carga ANTES de iniciar la tarea
                        cargando.Show();

                        // Ejecutar la operación de exportación de forma asincrónica
                        await Task.Run(() =>
                        {
                            // Llama al método de exportación SIN el SaveFileDialog
                            ExportarDatos(desde, hasta, ruta);
                        });

                        // Cerrar el formulario de carga
                        cargando.Close();

                        ok.Lbl_msm1.Text = "Exportación Completada a Excel";
                        ok.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    cargando.Close(); // Asegurarse de cerrar el formulario de carga en caso de error
                    MessageBox.Show($"Error al exportar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportarDatos(DateTime desde, DateTime hasta, string ruta)
        {
            try
            {
                RN_GuiaRemision guiaRem = new RN_GuiaRemision();
                DataTable tabla = guiaRem.RN_Buscar_GuiasRem_Remitente_aExcel(desde, hasta);

                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Llamar al método de exportación para guardar el archivo
                ExportarExcel(tabla, ruta);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en ExportarDatos: {ex.Message}");
                MessageBox.Show($"Error al procesar la exportación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarExcel(DataTable tabla, string ruta )
        {
            try
            {
                using (var wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(tabla, "GuiasRemision");

                    // Formato de columnas específicas
                    if (tabla.Columns.Contains("Fecha Emisión"))
                        ws.Column(tabla.Columns["Fecha Emisión"].Ordinal + 1).Style.DateFormat.Format = "dd/MM/yyyy";

                    if (tabla.Columns.Contains("PesoTotal"))
                        ws.Column(tabla.Columns["PesoTotal"].Ordinal + 1).Style.NumberFormat.Format = "0.00";

                    if (tabla.Columns.Contains("Aceptado por la Sunat"))
                        ws.Column(tabla.Columns["Aceptado por la Sunat"].Ordinal + 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    ws.Columns().AdjustToContents(); // autoajustar
                    wb.SaveAs(ruta);

                    //// Mensaje de depuración para confirmar que el archivo se ha guardado
                    //Console.WriteLine($"Archivo guardado en: {ruta}");
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores durante el proceso de exportación a Excel
                //Console.WriteLine($"Error al exportar a Excel: {ex.Message}");
                MessageBox.Show($"Error al exportar a Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            //// Lista para almacenar las guías seleccionadas
            //List<EN_Gr_Transportista> guíasSeleccionadas = new List<EN_Gr_Transportista>();

            //// Iterar sobre los ítems del ListView
            //foreach (ListViewItem item in lsv_com.Items)
            //{
            //    if (item.Checked)  // Verificamos si la casilla está marcada
            //    {
            //        // Extraemos la fila guardada en el Tag
            //        DataRow row = (DataRow)item.Tag;
            //        EN_Gr_Transportista guia = new EN_Gr_Transportista
            //        {
            //            Idgr_Transp = row["Id_GrTransp"].ToString(),
            //            //IdCliente = row["Id_Cliente"].ToString(),
            //            Fecha = Convert.ToDateTime(row["Fecha"]),
            //            //Subtotal = Convert.ToDouble(row["Subtotal"]),
            //            // Otros campos según sea necesario...
            //        };

            //        guíasSeleccionadas.Add(guia);
            //    }

            //}

            //// Abrimos el formulario de ventas y le pasamos la lista de guías seleccionadas
            //Frm_Crear_Ventas ventas = new Frm_Crear_Ventas();
            //ventas.Show();

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();
            Frm_Crear_Ventas r = new Frm_Crear_Ventas();
            //Frm_Reimprimir r = new Frm_Reimprimir();
            //Frm_Crear_Ventas_conGR r = new Frm_Crear_Ventas_conGR();

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
            }



        }

        private void Llenar_Combo_Cliente()
        {
            RN_Cliente obj = new RN_Cliente();           
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Clientes();
            if (dato.Rows.Count > 0)
            {
                var cbo = cbo_usu;

                cbo.DataSource = dato;
                cbo.DisplayMember = "Razon_Social_Nombres";
                cbo.ValueMember = "Id_Cliente";
                cbo.SelectedIndex = -1;
            }
            else
            {
                // Si no hay datos, se puede mostrar un mensaje o manejar el estado del ComboBox
                cbo_usu.Items.Clear(); // Limpia el ComboBox
                cbo_usu.Items.Add("No hay clientes disponibles");
            }
        }

        private void cbo_usu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //// Verifica que se haya seleccionado un valor válido
            if (cbo_usu.SelectedIndex != -1)
            {
                // Obtener el ID del usuario seleccionado
                string usuarioId =Convert.ToString(cbo_usu.SelectedValue);

                // Llamar al método para cargar los datos en el ListView
                buscar_Docu_GrTransport(usuarioId);

            }
        }

        private void CargarGuías()
        {
            //RN_GuiaRem_Transportista negocio = new RN_GuiaRem_Transportista();
            //DataTable dt = negocio.RN_Buscar_GrTransportista("");  // Puedes agregar un filtro si lo necesitas

            //lsv_com.Items.Clear();  // Limpiar elementos previos
            //foreach (DataRow row in dt.Rows)
            //{
            //    ListViewItem item = new ListViewItem(row["Id_GrTransp"].ToString());
            //    //item.SubItems.Add(row["Id_Cliente"].ToString());
            //    item.SubItems.Add(row["Fecha"].ToString());
            //    //item.SubItems.Add(row["Subtotal"].ToString());
            //    item.Tag = row;  // Guardamos toda la fila en el Tag

            //    // Activamos la casilla de verificación por defecto si es necesario
            //    item.Checked = false;  // Las casillas se inician sin estar seleccionadas

            //    lsv_com.Items.Add(item);
            //}
        }

        private async void btn_filtroRanfoFechas_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ad = new Frm_Advertencia();
            Frm_FechasFiltro fec = new Frm_FechasFiltro();
            
            fil.Show();
            fec.lbl_nombre.Text = "Filtrar Guías De Remisión";
            fec.ShowDialog();
            fil.Hide();

            //revisar porque al dar click en salta error 13/09/25
            if (fec.Tag?.ToString() == "A")
            {

                DateTime xfecha = fec.dtpfechaInicial.Value;
                DateTime xfecha2 = fec.dtpfechaFinal.Value;

                if(xfecha > xfecha2)
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
                    RN_GuiaRemision guiaRem = new RN_GuiaRemision();
                    DataTable tablax = guiaRem.RN_Filtrar_DocsGr_RangoFechas(xfecha, xfecha2);

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
                            lsv_com.Items.Clear();
                            pnl_msm.Visible = true; // Muestra el panel de mensaje si no hay datos
                        }
                    });
                });
            }
        }

        private void Filtrar_Docs_RangoFechas(DateTime desde, DateTime hasta)
        {
            // Obtener el DataTable desde el negocio
            RN_GuiaRemision guiaRem = new RN_GuiaRemision();
            DataTable tablax = guiaRem.RN_Filtrar_DocsGr_RangoFechas(desde, hasta);

            if (tablax.Rows.Count > 0)
            {
                Llenar_Listview(tablax);
            }
            else
            {
                lsv_com.Items.Clear();
                pnl_msm.Visible = true;
            }

        }
    }
}
