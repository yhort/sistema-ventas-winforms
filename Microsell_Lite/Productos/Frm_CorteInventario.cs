using CapaNegocio;
using Guna.UI2.WinForms;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
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
using System.IO;
using System.Text;

namespace Microsell_Lite.Productos
{
    public partial class Frm_CorteInventario : Form
    {
        public Frm_CorteInventario()
        {
            InitializeComponent();

        }
        private const int ID_ALMACEN_DEFAULT = 1;

       
        private void Frm_CorteInventario_Load(object sender, EventArgs e)
        {
            ConfigurarGridCortes();
            ConfigurarGridDetalle();
            CargarCortes();

            this.Load += Frm_CorteInventario_Load;
            btnGenerarCorte.Click += btnGenerarCorte_Click;
            dgvCortes.CellClick += dgvCortes_CellClick;
            btnRecargar.Click += btnRecargar_Click;
            btn_cerrar.Click += btn_cerrar_Click_1;
        }

        //private void ConfigurarGridAjustes()
        //{
        //    dgvCortes.Columns.Clear();
        //    dgvCortes.Rows.Clear();

        //    // =====================================
        //    // CONFIGURACIÓN GENERAL
        //    // =====================================

        //    dgvCortes.ReadOnly = true;

        //    dgvCortes.AllowUserToAddRows = false;
        //    dgvCortes.AllowUserToDeleteRows = false;
        //    dgvCortes.AllowUserToResizeRows = false;

        //    dgvCortes.MultiSelect = false;

        //    dgvCortes.SelectionMode =
        //        DataGridViewSelectionMode.FullRowSelect;

        //    dgvCortes.AutoSizeColumnsMode =
        //        DataGridViewAutoSizeColumnsMode.Fill;

        //    dgvCortes.RowHeadersVisible = false;

        //    dgvCortes.EnableHeadersVisualStyles = false;

        //    dgvCortes.BackgroundColor = Color.White;
        //    dgvCortes.BorderStyle = BorderStyle.None;

        //    dgvCortes.CellBorderStyle =
        //        DataGridViewCellBorderStyle.SingleHorizontal;

        //    dgvCortes.GridColor =
        //        Color.FromArgb(240, 240, 240);

        //    dgvCortes.ColumnHeadersBorderStyle =
        //        DataGridViewHeaderBorderStyle.None;

        //    // =====================================
        //    // HEADER STYLE
        //    // =====================================

        //    dgvCortes.ColumnHeadersHeight = 38;

        //    dgvCortes.ColumnHeadersHeightSizeMode =
        //        DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

        //    dgvCortes.ThemeStyle.HeaderStyle.Height = 38;

        //    dgvCortes.ThemeStyle.HeaderStyle.BackColor =
        //        Color.FromArgb(45, 52, 54);

        //    dgvCortes.ThemeStyle.HeaderStyle.ForeColor =
        //        Color.White;

        //    dgvCortes.ThemeStyle.HeaderStyle.Font =
        //        new Font("Segoe UI", 9F, FontStyle.Bold);

        //    // EVITAR SOMBRA / SELECCIÓN HEADER
        //    dgvCortes.ColumnHeadersDefaultCellStyle.SelectionBackColor =
        //        Color.FromArgb(45, 52, 54);

        //    dgvCortes.ColumnHeadersDefaultCellStyle.SelectionForeColor =
        //        Color.White;

        //    // =====================================
        //    // ROW STYLE
        //    // =====================================

        //    dgvCortes.RowTemplate.Height = 30;

        //    dgvCortes.ThemeStyle.RowsStyle.Height = 30;

        //    dgvCortes.ThemeStyle.RowsStyle.Font =
        //        new Font("Segoe UI", 9F);

        //    dgvCortes.ThemeStyle.RowsStyle.BackColor =
        //        Color.White;

        //    dgvCortes.ThemeStyle.RowsStyle.ForeColor =
        //        Color.FromArgb(40, 40, 40);

        //    dgvCortes.ThemeStyle.RowsStyle.SelectionBackColor =
        //        Color.FromArgb(220, 230, 240);

        //    dgvCortes.ThemeStyle.RowsStyle.SelectionForeColor =
        //        Color.Black;

        //    dgvCortes.AlternatingRowsDefaultCellStyle.BackColor =
        //        Color.FromArgb(248, 249, 250);

        //    // =====================================
        //    // COLUMNAS
        //    // =====================================

        //    dgvCortes.Columns.Add("IdAjuste", "N°");
        //    dgvCortes.Columns["IdAjuste"].FillWeight = 40;

        //    dgvCortes.Columns.Add("Fecha", "Fecha");
        //    dgvCortes.Columns["Fecha"].FillWeight = 90;

        //    dgvCortes.Columns.Add("Almacen", "Almacén");
        //    dgvCortes.Columns["Almacen"].FillWeight = 120;

        //    dgvCortes.Columns.Add("Motivo", "Motivo");
        //    dgvCortes.Columns["Motivo"].FillWeight = 120;

        //    dgvCortes.Columns.Add("Observacion", "Observación");
        //    dgvCortes.Columns["Observacion"].FillWeight = 180;

        //    dgvCortes.Columns.Add("Usuario", "Usuario");
        //    dgvCortes.Columns["Usuario"].FillWeight = 70;

        //    dgvCortes.Columns.Add("Estado", "Estado");
        //    dgvCortes.Columns["Estado"].FillWeight = 60;

        //    dgvCortes.Columns.Add("FechaAnulacion", "F. Anulación");
        //    dgvCortes.Columns["FechaAnulacion"].FillWeight = 90;

        //    dgvCortes.Columns.Add("MotivoAnulacion", "Motivo Anulación");
        //    dgvCortes.Columns["MotivoAnulacion"].FillWeight = 140;

        //    // =====================================
        //    // ALINEACIONES
        //    // =====================================

        //    dgvCortes.Columns["IdAjuste"]
        //        .DefaultCellStyle.Alignment =
        //        DataGridViewContentAlignment.MiddleCenter;

        //    dgvCortes.Columns["Fecha"]
        //        .DefaultCellStyle.Alignment =
        //        DataGridViewContentAlignment.MiddleCenter;

        //    dgvCortes.Columns["Estado"]
        //        .DefaultCellStyle.Alignment =
        //        DataGridViewContentAlignment.MiddleCenter;
        //}
        //private void ConfigurarGridDetalle()
        //{

        //    dgvDetalle.Columns.Clear();
        //    dgvDetalle.Rows.Clear();

        //    // =====================================
        //    // CONFIGURACIÓN GENERAL
        //    // =====================================

        //    dgvDetalle.ReadOnly = true;

        //    dgvDetalle.AllowUserToAddRows = false;
        //    dgvDetalle.AllowUserToDeleteRows = false;
        //    dgvDetalle.AllowUserToResizeRows = false;

        //    dgvDetalle.MultiSelect = false;

        //    dgvDetalle.SelectionMode =
        //        DataGridViewSelectionMode.FullRowSelect;

        //    dgvDetalle.AutoSizeColumnsMode =
        //        DataGridViewAutoSizeColumnsMode.Fill;

        //    dgvDetalle.RowHeadersVisible = false;

        //    dgvDetalle.EnableHeadersVisualStyles = false;

        //    dgvDetalle.BackgroundColor = Color.White;

        //    dgvDetalle.BorderStyle = BorderStyle.None;

        //    dgvDetalle.CellBorderStyle =
        //        DataGridViewCellBorderStyle.SingleHorizontal;

        //    dgvDetalle.GridColor =
        //        Color.FromArgb(240, 240, 240);

        //    dgvDetalle.ColumnHeadersBorderStyle =
        //        DataGridViewHeaderBorderStyle.None;

        //    // =====================================
        //    // HEADER STYLE
        //    // =====================================

        //    dgvDetalle.ColumnHeadersHeight = 38;

        //    dgvDetalle.ColumnHeadersHeightSizeMode =
        //        DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

        //    dgvDetalle.ThemeStyle.HeaderStyle.Height = 38;

        //    dgvDetalle.ThemeStyle.HeaderStyle.BackColor =
        //        Color.FromArgb(45, 52, 54);

        //    dgvDetalle.ThemeStyle.HeaderStyle.ForeColor =
        //        Color.White;

        //    dgvDetalle.ThemeStyle.HeaderStyle.Font =
        //        new Font("Segoe UI", 9F, FontStyle.Bold);

        //    // =====================================
        //    // ROW STYLE
        //    // =====================================

        //    dgvDetalle.RowTemplate.Height = 30;

        //    dgvDetalle.ThemeStyle.RowsStyle.Height = 30;

        //    dgvDetalle.ThemeStyle.RowsStyle.Font =
        //        new Font("Segoe UI", 9F);

        //    dgvDetalle.ThemeStyle.RowsStyle.BackColor =
        //        Color.White;

        //    dgvDetalle.ThemeStyle.RowsStyle.ForeColor =
        //        Color.FromArgb(40, 40, 40);

        //    dgvDetalle.ThemeStyle.RowsStyle.SelectionBackColor =
        //        Color.FromArgb(220, 230, 240);

        //    dgvDetalle.ThemeStyle.RowsStyle.SelectionForeColor =
        //        Color.Black;

        //    dgvDetalle.AlternatingRowsDefaultCellStyle.BackColor =
        //        Color.FromArgb(248, 249, 250);

        //    // =====================================
        //    // COLUMNAS
        //    // =====================================

        //    dgvDetalle.Columns.Add("IdProducto", "ID");
        //    dgvDetalle.Columns["IdProducto"].FillWeight = 50;

        //    dgvDetalle.Columns.Add("Producto", "Producto");
        //    dgvDetalle.Columns["Producto"].FillWeight = 220;

        //    dgvDetalle.Columns.Add("Presentacion", "Presentación");
        //    dgvDetalle.Columns["Presentacion"].FillWeight = 100;

        //    dgvDetalle.Columns.Add("Abrev", "Abrev");
        //    dgvDetalle.Columns["Abrev"].FillWeight = 50;

        //    dgvDetalle.Columns.Add("StockSistema", "Stock Sistema");
        //    dgvDetalle.Columns["StockSistema"].FillWeight = 80;

        //    dgvDetalle.Columns.Add("StockContado", "Stock Contado");
        //    dgvDetalle.Columns["StockContado"].FillWeight = 80;

        //    dgvDetalle.Columns.Add("Diferencia", "Diferencia");
        //    dgvDetalle.Columns["Diferencia"].FillWeight = 70;

        //    dgvDetalle.Columns.Add("Equivalencia", "Equiv.");
        //    dgvDetalle.Columns["Equivalencia"].FillWeight = 60;

        //    dgvDetalle.Columns.Add("DiferenciaBase", "Dif. Base");
        //    dgvDetalle.Columns["DiferenciaBase"].FillWeight = 70;

        //    // =====================================
        //    // FORMATOS NUMÉRICOS
        //    // =====================================

        //    dgvDetalle.Columns["StockSistema"]
        //        .DefaultCellStyle.Format = "N2";

        //    dgvDetalle.Columns["StockContado"]
        //        .DefaultCellStyle.Format = "N2";

        //    dgvDetalle.Columns["Diferencia"]
        //        .DefaultCellStyle.Format = "N2";

        //    dgvDetalle.Columns["Equivalencia"]
        //        .DefaultCellStyle.Format = "N2";

        //    dgvDetalle.Columns["DiferenciaBase"]
        //        .DefaultCellStyle.Format = "N2";

        //    // =====================================
        //    // ALINEACIÓN
        //    // =====================================

        //    dgvDetalle.Columns["IdProducto"]
        //        .DefaultCellStyle.Alignment =
        //        DataGridViewContentAlignment.MiddleCenter;

        //    dgvDetalle.Columns["StockSistema"]
        //        .DefaultCellStyle.Alignment =
        //        DataGridViewContentAlignment.MiddleRight;

        //    dgvDetalle.Columns["StockContado"]
        //        .DefaultCellStyle.Alignment =
        //        DataGridViewContentAlignment.MiddleRight;

        //    dgvDetalle.Columns["Diferencia"]
        //        .DefaultCellStyle.Alignment =
        //        DataGridViewContentAlignment.MiddleRight;

        //    dgvDetalle.Columns["Equivalencia"]
        //        .DefaultCellStyle.Alignment =
        //        DataGridViewContentAlignment.MiddleRight;

        //    dgvDetalle.Columns["DiferenciaBase"]
        //        .DefaultCellStyle.Alignment =
        //        DataGridViewContentAlignment.MiddleRight;
        //}

        private void ConfigurarGridCortes()
        {
            dgvCortes.Columns.Clear();
            dgvCortes.Rows.Clear();

            dgvCortes.AllowUserToAddRows = false;
            dgvCortes.AllowUserToDeleteRows = false;
            dgvCortes.ReadOnly = true;
            dgvCortes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCortes.MultiSelect = false;

            dgvCortes.Columns.Add("IdCorte", "N°");
            dgvCortes.Columns["IdCorte"].Width = 60;

            dgvCortes.Columns.Add("Fecha", "Fecha");
            dgvCortes.Columns["Fecha"].Width = 140;

            dgvCortes.Columns.Add("Almacen", "Almacén");
            dgvCortes.Columns["Almacen"].Width = 150;

            dgvCortes.Columns.Add("Descripcion", "Descripción");
            dgvCortes.Columns["Descripcion"].Width = 220;

            dgvCortes.Columns.Add("Items", "Items");
            dgvCortes.Columns["Items"].Width = 70;

            dgvCortes.Columns.Add("ValorTotal", "Valor Total");
            dgvCortes.Columns["ValorTotal"].Width = 100;

            dgvCortes.Columns.Add("Estado", "Estado");
            dgvCortes.Columns["Estado"].Width = 90;
        }

        private void ConfigurarGridDetalle()
        {
            dgvDetalle.Columns.Clear();
            dgvDetalle.Rows.Clear();

            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.ReadOnly = true;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.MultiSelect = false;

            dgvDetalle.Columns.Add("IdProducto", "ID Producto");
            dgvDetalle.Columns["IdProducto"].Width = 90;

            dgvDetalle.Columns.Add("Producto", "Producto");
            dgvDetalle.Columns["Producto"].Width = 220;

            dgvDetalle.Columns.Add("Presentacion", "Presentación");
            dgvDetalle.Columns["Presentacion"].Width = 120;

            dgvDetalle.Columns.Add("Abrev", "Abrev");
            dgvDetalle.Columns["Abrev"].Width = 60;

            dgvDetalle.Columns.Add("StockPresentacion", "Stock Físico");
            dgvDetalle.Columns["StockPresentacion"].Width = 100;

            dgvDetalle.Columns.Add("Equivalencia", "Equiv.");
            dgvDetalle.Columns["Equivalencia"].Width = 70;

            dgvDetalle.Columns.Add("StockBase", "Stock Base");
            dgvDetalle.Columns["StockBase"].Width = 100;

            dgvDetalle.Columns.Add("CostoBase", "Costo Base");
            dgvDetalle.Columns["CostoBase"].Width = 90;

            dgvDetalle.Columns.Add("Valor", "Valor");
            dgvDetalle.Columns["Valor"].Width = 100;
        }
        //private void CargarDetalleAjuste(int idAjuste)
        //{
        //    RN_InventarioAjuste obj = new RN_InventarioAjuste();
        //    DataTable dt = obj.RN_Listar_InventarioAjusteDetalle(idAjuste);

        //    dgvDetalle.Rows.Clear();

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        dgvDetalle.Rows.Add(
        //            dr["IdProducto"].ToString(),
        //            dr["Descripcion_Larga"].ToString(),
        //            dr["NombrePresentacion"].ToString(),
        //            dr["Abreviatura"].ToString(),
        //            Convert.ToDecimal(dr["StockSistema"]).ToString("0.####"),
        //            Convert.ToDecimal(dr["StockContado"]).ToString("0.####"),
        //            Convert.ToDecimal(dr["Diferencia"]).ToString("0.####"),
        //            Convert.ToDecimal(dr["Equivalencia"]).ToString("0.####"),
        //            Convert.ToDecimal(dr["DiferenciaBase"]).ToString("0.####")
        //        );
        //    }

        //    lblTotalCortes.Text = dgvDetalle.Rows.Count.ToString();
        //}

        private void GenerarCorte()
        {
            if (txtDescripcion.Text.Trim().Length < 3)
            {
                MessageBox.Show("Ingrese una descripción para el corte.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return;
            }

            DialogResult rpta = MessageBox.Show(
                "¿Deseas generar el corte de inventario?\n\nSe guardará una foto del stock actual.",
                "Confirmar corte",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (rpta != DialogResult.Yes)
                return;

            try
            {
                RN_InventarioCorte rn = new RN_InventarioCorte();
                EN_InventarioCorte corte = new EN_InventarioCorte();

                corte.IdAlmacen = ID_ALMACEN_DEFAULT;
                corte.Descripcion = txtDescripcion.Text.Trim();
                corte.Observacion = txtObservacion.Text.Trim();
                corte.IdUsuario = Convert.ToInt32(Cls_Libreria.IdUsu);
                corte.Estado = "Generado";

                int idCorte = rn.RN_Registrar_InventarioCorte(corte);

                if (idCorte <= 0)
                {
                    MessageBox.Show("No se pudo registrar el corte.",
                        "Corte Inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                rn.RN_Generar_Detalle_InventarioCorte(idCorte, ID_ALMACEN_DEFAULT);

                MessageBox.Show("Corte generado correctamente.",
                    "Corte Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtDescripcion.Clear();
                txtObservacion.Text ="";

                CargarCortes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar corte: " + ex.Message,
                    "Corte Inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CargarCortes()
        {
            RN_InventarioCorte rn = new RN_InventarioCorte();
            DataTable dt = rn.RN_Listar_InventarioCortes();

            dgvCortes.Rows.Clear();
            dgvDetalle.Rows.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                dgvCortes.Rows.Add(
                    dr["IdCorte"].ToString(),
                    Convert.ToDateTime(dr["FechaCorte"]).ToString("dd/MM/yyyy HH:mm"),
                    dr["NombreAlmacen"].ToString(),
                    dr["Descripcion"].ToString(),
                    Convert.ToDecimal(dr["TotalItems"]).ToString("0"),
                    Convert.ToDecimal(dr["ValorTotal"]).ToString("0.00"),
                    dr["Estado"].ToString()
                );
            }

            lblTotalCortes.Text = dgvCortes.Rows.Count.ToString();
        }

        private void CargarDetalleCorte(int idCorte)
        {
            RN_InventarioCorte rn = new RN_InventarioCorte();
            DataTable dt = rn.RN_Listar_InventarioCorteDetalle(idCorte);

            dgvDetalle.Rows.Clear();

            decimal valorTotal = 0;

            foreach (DataRow dr in dt.Rows)
            {
                decimal valor = Convert.ToDecimal(dr["ValorInventario"]);
                valorTotal += valor;

                dgvDetalle.Rows.Add(
                    dr["IdProducto"].ToString(),
                    dr["Descripcion_Larga"].ToString(),
                    dr["NombrePresentacion"].ToString(),
                    dr["Abreviatura"].ToString(),
                    Convert.ToDecimal(dr["StockPresentacion"]).ToString("0.####"),
                    Convert.ToDecimal(dr["Equivalencia"]).ToString("0.####"),
                    Convert.ToDecimal(dr["StockBaseEquivalente"]).ToString("0.####"),
                    Convert.ToDecimal(dr["CostoPromedioBase"]).ToString("0.00"),
                    valor.ToString("0.00")
                );
            }

            lblTotalItems.Text = dgvDetalle.Rows.Count.ToString();
            lblValorTotal.Text = valorTotal.ToString("0.00");
        }

        private void txtBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {
           
        }
        private void btnAplicarAjuste_Click(object sender, EventArgs e)
        {
            
        }
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           
        }
        private void TxtNumeros_KeyPress(object sender,KeyPressEventArgs e)
        {
           
        }
        private void dgvDetalle_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void dgvAjustes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvAjustes_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarCortes();
        }


        private void btn_cerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


       
        private void btnBuscar_Click(object sender, EventArgs e)
        {
           ExportarCorteExcel();
        }

        private void btnGenerarCorte_Click(object sender, EventArgs e)
        {
            GenerarCorte();
        }

        private void dgvCortes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int idCorte = Convert.ToInt32(dgvCortes.Rows[e.RowIndex].Cells["IdCorte"].Value);
            CargarDetalleCorte(idCorte);
        }

        private void ExportarCorteExcel()
        {
            if (dgvDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Primero selecciona un corte para exportar.",
                    "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Archivo Excel (*.xls)|*.xls";
            save.FileName = "Corte_Inventario_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xls";

            if (save.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("<html>");
                sb.AppendLine("<head>");
                sb.AppendLine("<meta charset='UTF-8'>");
                sb.AppendLine("</head>");
                sb.AppendLine("<body>");

                sb.AppendLine("<h2>CORTE DE INVENTARIO</h2>");
                sb.AppendLine("<p><b>Fecha exportación:</b> " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "</p>");
                sb.AppendLine("<p><b>Total items:</b> " + lblTotalItems.Text + "</p>");
                sb.AppendLine("<p><b>Valor total:</b> " + lblValorTotal.Text + "</p>");

                sb.AppendLine("<table border='1'>");

                // Cabecera
                sb.AppendLine("<tr style='font-weight:bold; background-color:#D9EAF7;'>");
                for (int i = 0; i < dgvDetalle.Columns.Count; i++)
                {
                    sb.AppendLine("<td>" + dgvDetalle.Columns[i].HeaderText + "</td>");
                }
                sb.AppendLine("</tr>");

                // Filas
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    sb.AppendLine("<tr>");

                    for (int i = 0; i < dgvDetalle.Columns.Count; i++)
                    {
                        string valor = "";

                        if (row.Cells[i].Value != null)
                            valor = row.Cells[i].Value.ToString();

                        sb.AppendLine("<td>" + valor + "</td>");
                    }

                    sb.AppendLine("</tr>");
                }

                sb.AppendLine("</table>");
                sb.AppendLine("</body>");
                sb.AppendLine("</html>");

                File.WriteAllText(save.FileName, sb.ToString(), Encoding.UTF8);

                MessageBox.Show("Excel generado correctamente.",
                    "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar Excel: " + ex.Message,
                    "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

      
    }

}
