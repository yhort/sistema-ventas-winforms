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
using Guna.UI2.WinForms;
using System.IO;


namespace Microsell_Lite.Productos
{
    public partial class Frm_HistorialAjustesInventario : Form
    {
        public Frm_HistorialAjustesInventario()
        {
            InitializeComponent();

        }
        private const int ID_ALMACEN_DEFAULT = 1;

        private void Frm_HistorialAjustesInventario_Load(object sender, EventArgs e)
        {
            ConfigurarGridAjustes();
            ConfigurarGridDetalle();
            CargarEstados();
            CargarAjustes();
        }

        private void ConfigurarGridAjustes()
        {
            dgvAjustes.Columns.Clear();
            dgvAjustes.Rows.Clear();

            // =====================================
            // CONFIGURACIÓN GENERAL
            // =====================================

            dgvAjustes.ReadOnly = true;

            dgvAjustes.AllowUserToAddRows = false;
            dgvAjustes.AllowUserToDeleteRows = false;
            dgvAjustes.AllowUserToResizeRows = false;

            dgvAjustes.MultiSelect = false;

            dgvAjustes.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvAjustes.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvAjustes.RowHeadersVisible = false;

            dgvAjustes.EnableHeadersVisualStyles = false;

            dgvAjustes.BackgroundColor = Color.White;
            dgvAjustes.BorderStyle = BorderStyle.None;

            dgvAjustes.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvAjustes.GridColor =
                Color.FromArgb(240, 240, 240);

            dgvAjustes.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            // =====================================
            // HEADER STYLE
            // =====================================

            dgvAjustes.ColumnHeadersHeight = 38;

            dgvAjustes.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvAjustes.ThemeStyle.HeaderStyle.Height = 38;

            dgvAjustes.ThemeStyle.HeaderStyle.BackColor =
                Color.FromArgb(45, 52, 54);

            dgvAjustes.ThemeStyle.HeaderStyle.ForeColor =
                Color.White;

            dgvAjustes.ThemeStyle.HeaderStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            // EVITAR SOMBRA / SELECCIÓN HEADER
            dgvAjustes.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(45, 52, 54);

            dgvAjustes.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                Color.White;

            // =====================================
            // ROW STYLE
            // =====================================

            dgvAjustes.RowTemplate.Height = 30;

            dgvAjustes.ThemeStyle.RowsStyle.Height = 30;

            dgvAjustes.ThemeStyle.RowsStyle.Font =
                new Font("Segoe UI", 9F);

            dgvAjustes.ThemeStyle.RowsStyle.BackColor =
                Color.White;

            dgvAjustes.ThemeStyle.RowsStyle.ForeColor =
                Color.FromArgb(40, 40, 40);

            dgvAjustes.ThemeStyle.RowsStyle.SelectionBackColor =
                Color.FromArgb(220, 230, 240);

            dgvAjustes.ThemeStyle.RowsStyle.SelectionForeColor =
                Color.Black;

            dgvAjustes.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 249, 250);

            // =====================================
            // COLUMNAS
            // =====================================

            dgvAjustes.Columns.Add("IdAjuste", "N°");
            dgvAjustes.Columns["IdAjuste"].FillWeight = 40;

            dgvAjustes.Columns.Add("Fecha", "Fecha");
            dgvAjustes.Columns["Fecha"].FillWeight = 90;

            dgvAjustes.Columns.Add("Almacen", "Almacén");
            dgvAjustes.Columns["Almacen"].FillWeight = 120;

            dgvAjustes.Columns.Add("Motivo", "Motivo");
            dgvAjustes.Columns["Motivo"].FillWeight = 120;

            dgvAjustes.Columns.Add("Observacion", "Observación");
            dgvAjustes.Columns["Observacion"].FillWeight = 180;

            dgvAjustes.Columns.Add("Usuario", "Usuario");
            dgvAjustes.Columns["Usuario"].FillWeight = 70;

            dgvAjustes.Columns.Add("Estado", "Estado");
            dgvAjustes.Columns["Estado"].FillWeight = 60;

            dgvAjustes.Columns.Add("FechaAnulacion", "F. Anulación");
            dgvAjustes.Columns["FechaAnulacion"].FillWeight = 90;

            dgvAjustes.Columns.Add("MotivoAnulacion", "Motivo Anulación");
            dgvAjustes.Columns["MotivoAnulacion"].FillWeight = 140;

            // =====================================
            // ALINEACIONES
            // =====================================

            dgvAjustes.Columns["IdAjuste"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvAjustes.Columns["Fecha"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvAjustes.Columns["Estado"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
        }
        private void ConfigurarGridDetalle()
        {
            dgvDetalle.Columns.Clear();
            dgvDetalle.Rows.Clear();

            // =====================================
            // CONFIGURACIÓN GENERAL
            // =====================================

            dgvDetalle.ReadOnly = true;

            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.AllowUserToResizeRows = false;

            dgvDetalle.MultiSelect = false;

            dgvDetalle.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvDetalle.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvDetalle.RowHeadersVisible = false;

            dgvDetalle.EnableHeadersVisualStyles = false;

            dgvDetalle.BackgroundColor = Color.White;

            dgvDetalle.BorderStyle = BorderStyle.None;

            dgvDetalle.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvDetalle.GridColor =
                Color.FromArgb(240, 240, 240);

            dgvDetalle.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            // =====================================
            // HEADER STYLE
            // =====================================

            dgvDetalle.ColumnHeadersHeight = 38;

            dgvDetalle.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvDetalle.ThemeStyle.HeaderStyle.Height = 38;

            dgvDetalle.ThemeStyle.HeaderStyle.BackColor =
                Color.FromArgb(45, 52, 54);

            dgvDetalle.ThemeStyle.HeaderStyle.ForeColor =
                Color.White;

            dgvDetalle.ThemeStyle.HeaderStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            // =====================================
            // ROW STYLE
            // =====================================

            dgvDetalle.RowTemplate.Height = 30;

            dgvDetalle.ThemeStyle.RowsStyle.Height = 30;

            dgvDetalle.ThemeStyle.RowsStyle.Font =
                new Font("Segoe UI", 9F);

            dgvDetalle.ThemeStyle.RowsStyle.BackColor =
                Color.White;

            dgvDetalle.ThemeStyle.RowsStyle.ForeColor =
                Color.FromArgb(40, 40, 40);

            dgvDetalle.ThemeStyle.RowsStyle.SelectionBackColor =
                Color.FromArgb(220, 230, 240);

            dgvDetalle.ThemeStyle.RowsStyle.SelectionForeColor =
                Color.Black;

            dgvDetalle.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 249, 250);

            // =====================================
            // COLUMNAS
            // =====================================

            dgvDetalle.Columns.Add("IdProducto", "ID");
            dgvDetalle.Columns["IdProducto"].FillWeight = 50;

            dgvDetalle.Columns.Add("Producto", "Producto");
            dgvDetalle.Columns["Producto"].FillWeight = 220;

            dgvDetalle.Columns.Add("Presentacion", "Presentación");
            dgvDetalle.Columns["Presentacion"].FillWeight = 100;

            dgvDetalle.Columns.Add("Abrev", "Abrev");
            dgvDetalle.Columns["Abrev"].FillWeight = 50;

            dgvDetalle.Columns.Add("StockSistema", "Stock Sistema");
            dgvDetalle.Columns["StockSistema"].FillWeight = 80;

            dgvDetalle.Columns.Add("StockContado", "Stock Contado");
            dgvDetalle.Columns["StockContado"].FillWeight = 80;

            dgvDetalle.Columns.Add("Diferencia", "Diferencia");
            dgvDetalle.Columns["Diferencia"].FillWeight = 70;

            dgvDetalle.Columns.Add("Equivalencia", "Equiv.");
            dgvDetalle.Columns["Equivalencia"].FillWeight = 60;

            dgvDetalle.Columns.Add("DiferenciaBase", "Dif. Base");
            dgvDetalle.Columns["DiferenciaBase"].FillWeight = 70;

            // =====================================
            // FORMATOS NUMÉRICOS
            // =====================================

            dgvDetalle.Columns["StockSistema"]
                .DefaultCellStyle.Format = "N2";

            dgvDetalle.Columns["StockContado"]
                .DefaultCellStyle.Format = "N2";

            dgvDetalle.Columns["Diferencia"]
                .DefaultCellStyle.Format = "N2";

            dgvDetalle.Columns["Equivalencia"]
                .DefaultCellStyle.Format = "N2";

            dgvDetalle.Columns["DiferenciaBase"]
                .DefaultCellStyle.Format = "N2";

            // =====================================
            // ALINEACIÓN
            // =====================================

            dgvDetalle.Columns["IdProducto"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDetalle.Columns["StockSistema"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvDetalle.Columns["StockContado"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvDetalle.Columns["Diferencia"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvDetalle.Columns["Equivalencia"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvDetalle.Columns["DiferenciaBase"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
        }
        private void CargarAjustes()
        {
            RN_InventarioAjuste obj = new RN_InventarioAjuste();
            string estado = cboEstado.Text;
            DataTable dt = obj.RN_Listar_InventarioAjustes(dtpDesde.Value, dtpHasta.Value, estado);

            dgvAjustes.Rows.Clear();
            dgvDetalle.Rows.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                string usuario = dr["IdUsuario"].ToString();

                //if (dt.Columns.Contains("Usuario"))
                //    usuario = dr["Usuario"].ToString();
                //else
                //    usuario = dr["IdUsuario"].ToString();

                int rowIndex = dgvAjustes.Rows.Add(
                    dr["IdAjuste"].ToString(),
                    Convert.ToDateTime(dr["Fecha"]).ToString("dd/MM/yyyy HH:mm"),
                    dr["NombreAlmacen"].ToString(),
                    dr["Motivo"].ToString(),
                    dr["Observacion"].ToString(),
                    usuario,
                    dr["Estado"].ToString()
                );

                string estadoFila = dr["Estado"].ToString().Trim().ToUpper();

                if(estadoFila == "ANULADO")
                {
                    dgvAjustes.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                    dgvAjustes.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                }
                else
                {
                    dgvAjustes.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                    dgvAjustes.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkGreen;
                }
               
            }

            lblTotalAjustes.Text = dgvAjustes.Rows.Count.ToString();
        }
        private void CargarDetalleAjuste(int idAjuste)
        {
            RN_InventarioAjuste obj = new RN_InventarioAjuste();
            DataTable dt = obj.RN_Listar_InventarioAjusteDetalle(idAjuste);

            dgvDetalle.Rows.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                dgvDetalle.Rows.Add(
                    dr["IdProducto"].ToString(),
                    dr["Descripcion_Larga"].ToString(),
                    dr["NombrePresentacion"].ToString(),
                    dr["Abreviatura"].ToString(),
                    Convert.ToDecimal(dr["StockSistema"]).ToString("0.####"),
                    Convert.ToDecimal(dr["StockContado"]).ToString("0.####"),
                    Convert.ToDecimal(dr["Diferencia"]).ToString("0.####"),
                    Convert.ToDecimal(dr["Equivalencia"]).ToString("0.####"),
                    Convert.ToDecimal(dr["DiferenciaBase"]).ToString("0.####")
                );
            }

            lblTotalDetalle.Text = dgvDetalle.Rows.Count.ToString();
        }

        private void CargarEstados()
        {
            cboEstado.Items.Clear();
            cboEstado.Items.Add("Todos");
            cboEstado.Items.Add("Aplicado");
            cboEstado.Items.Add("Anulado");
            cboEstado.SelectedIndex = 0;
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
            if (e.RowIndex < 0)
                return;

            int idAjuste = Convert.ToInt32(dgvAjustes.Rows[e.RowIndex].Cells["IdAjuste"].Value);
            CargarDetalleAjuste(idAjuste);
        }

        private void dgvAjustes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgvAjustes.CurrentRow != null)
            {
                int idAjuste = Convert.ToInt32(dgvAjustes.CurrentRow.Cells["IdAjuste"].Value);
                CargarDetalleAjuste(idAjuste);
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarAjustes();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            AnularAjusteSeleccionado();
        }

        private void AnularAjusteSeleccionado()
        {
            if (dgvAjustes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un ajuste para anular.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idAjuste = Convert.ToInt32(dgvAjustes.CurrentRow.Cells["IdAjuste"].Value);
            string estado = dgvAjustes.CurrentRow.Cells["Estado"].Value.ToString();

            if (estado.Trim().ToUpper() == "ANULADO")
            {
                MessageBox.Show("Este ajuste ya se encuentra anulado.",
                    "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string motivo = Microsoft.VisualBasic.Interaction.InputBox(
                "Ingrese el motivo de anulación:",
                "Anular ajuste de inventario",
                "Error en conteo"
            );

            if (string.IsNullOrWhiteSpace(motivo))
            {
                MessageBox.Show("Debe ingresar un motivo de anulación.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult rpta = MessageBox.Show(
                "¿Seguro que deseas anular este ajuste?\n\n" +
                "Se revertirá el stock físico, stock base y se registrará Kardex inverso.",
                "Confirmar anulación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (rpta != DialogResult.Yes)
                return;

            try
            {
                RN_InventarioAjuste rnAjuste = new RN_InventarioAjuste();
                RN_Productos rnProd = new RN_Productos();

                DataTable dt = rnAjuste.RN_Obtener_DetalleAjuste_ParaAnular(idAjuste);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontró detalle para este ajuste.",
                        "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string estadoBD = dt.Rows[0]["Estado"].ToString();

                if (estadoBD.Trim().ToUpper() == "ANULADO")
                {
                    MessageBox.Show("Este ajuste ya fue anulado.",
                        "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataTable dtValidacion = rnAjuste.RN_Validar_AnulacionAjuste_Stock(idAjuste);

                if (dtValidacion.Rows.Count > 0)
                {
                    string mensaje = "No se puede anular este ajuste porque dejaría stock negativo.\n\n";

                    foreach (DataRow drVal in dtValidacion.Rows)
                    {
                        mensaje += "Producto: " + drVal["Descripcion_Larga"].ToString() + "\n";
                        mensaje += "Presentación: " + drVal["NombrePresentacion"].ToString() + "\n";
                        mensaje += "Stock físico actual: " + Convert.ToDecimal(drVal["StockFisicoActual"]).ToString("0.####") + "\n";
                        mensaje += "Stock físico después de anular: " + Convert.ToDecimal(drVal["StockFisicoDespues"]).ToString("0.####") + "\n";
                        mensaje += "Stock base actual: " + Convert.ToDecimal(drVal["StockBaseActual"]).ToString("0.####") + "\n";
                        mensaje += "Stock base después de anular: " + Convert.ToDecimal(drVal["StockBaseDespues"]).ToString("0.####") + "\n\n";
                    }

                    mensaje += "Recomendación: realiza un nuevo ajuste de inventario para corregir el stock actual.";

                    MessageBox.Show(mensaje, "Anulación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (DataRow dr in dt.Rows)
                {
                    int idAlmacen = Convert.ToInt32(dr["IdAlmacen"]);
                    string idProducto = dr["IdProducto"].ToString().Trim();
                    int idPresentacion = Convert.ToInt32(dr["IdPresentacion"]);

                    decimal diferencia = Convert.ToDecimal(dr["Diferencia"]);
                    decimal diferenciaBase = Convert.ToDecimal(dr["DiferenciaBase"]);

                    decimal diferenciaInversa = diferencia * -1;
                    decimal diferenciaBaseInversa = diferenciaBase * -1;

                    // 1. Kardex inverso ANTES de actualizar stock base
                    Registrar_Kardex_AnulacionAjuste(
                        idProducto,
                        Convert.ToDouble(diferenciaBaseInversa),
                        idAjuste,
                        motivo
                    );

                    // 2. Revertir stock físico por presentación
                    rnAjuste.RN_Ajustar_StockPresentacion_PorDiferencia(
                        idAlmacen,
                        idProducto,
                        idPresentacion,
                        diferenciaInversa
                    );

                    // 3. Revertir stock base global
                    rnProd.RN_Ajustar_StockBase_Producto(
                        idProducto,
                        diferenciaBaseInversa
                    );
                }

                // 4. Cambiar estado de cabecera
                rnAjuste.RN_Anular_InventarioAjuste(
                    idAjuste,
                    Convert.ToInt32(Cls_Libreria.IdUsu),
                    motivo
                );

                MessageBox.Show("Ajuste anulado correctamente.",
                    "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarAjustes();
                dgvDetalle.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al anular ajuste: " + ex.Message,
                    "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Registrar_Kardex_AnulacionAjuste(string idProducto, double diferenciaBaseInversa, int idAjuste, string motivoAnulacion)
        {

            if (diferenciaBaseInversa == 0)
                return;

            RN_Kardex obj = new RN_Kardex();
            EN_Kardex kar = new EN_Kardex();
            RN_Productos objpro = new RN_Productos();

            try
            {
                DataTable datoprod = objpro.RN_Buscar_Productos(idProducto.Trim());

                if (datoprod.Rows.Count == 0)
                    return;

                bool controlaStock = Convert.ToBoolean(datoprod.Rows[0]["ControlaStock"]);

                if (!controlaStock)
                    return;

                double stockActualAntes = Convert.ToDouble(datoprod.Rows[0]["Stock_Actual"]);
                double precioCompraProd = Convert.ToDouble(datoprod.Rows[0]["Pre_CompraS"]);

                string idKardex = "";
                int item = 1;

                if (obj.RN_Verificar_Producto_siTieneKardex(idProducto.Trim()) == true)
                {
                    DataTable dtKardex = obj.RN_Buscar_KardexDetalle_porProducto(idProducto.Trim());

                    if (dtKardex.Rows.Count > 0)
                    {
                        idKardex = Convert.ToString(dtKardex.Rows[0]["Id_krdx"]);
                        item = dtKardex.Rows.Count + 1;
                    }
                }
                else
                {
                    idKardex = RN_TipoDoc.RN_NroID(6);
                    obj.RN_Registrar_Kardex(idKardex, idProducto.Trim(), "CGRR");

                    if (BD_Kardex.seguardo == true)
                    {
                        RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(6);
                    }

                    item = 1;
                }

                if (string.IsNullOrWhiteSpace(idKardex))
                    return;

                kar.Idkardex = idKardex;
                kar.Item = item;
                kar.Doc_soporte = "ANULA-AJ-" + idAjuste.ToString();
                kar.Det_Operacion = "Anulación de Ajuste de Inventario";
                kar.TipoOperacion = "AnulacionAjusteInventario";
                kar.CantiDiferencial = "0";
                kar.ImporteDiferencial = 0;
                kar.Observacion = motivoAnulacion;

                kar.Promedio = precioCompraProd;

                if (diferenciaBaseInversa > 0)
                {
                    // Entrada por anulación
                    kar.Cantidad_in = diferenciaBaseInversa;
                    kar.Precio_In = precioCompraProd;
                    kar.Total_In = diferenciaBaseInversa * precioCompraProd;

                    kar.Cantidad_Out = 0;
                    kar.Precio_out = 0;
                    kar.Total_out = 0;

                    kar.Cantidad_saldo = stockActualAntes + diferenciaBaseInversa;
                }
                else
                {
                    // Salida por anulación
                    double salida = Math.Abs(diferenciaBaseInversa);

                    kar.Cantidad_in = 0;
                    kar.Precio_In = 0;
                    kar.Total_In = 0;

                    kar.Cantidad_Out = salida;
                    kar.Precio_out = precioCompraProd;
                    kar.Total_out = salida * precioCompraProd;

                    kar.Cantidad_saldo = stockActualAntes - salida;
                }

                kar.Total_saldo = kar.Cantidad_saldo * precioCompraProd;

                obj.RN_Registrar_Detalle_Kardex(kar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Kardex anulación ajuste: " + ex.Message,
                    "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_cerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


       
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarAjustes();
        }

        private void ExportarDetalleAjusteExcel()
        {
            if (dgvDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Primero selecciona un ajuste para exportar.",
                    "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Archivo Excel (*.xls)|*.xls";
            save.FileName = "Detalle_Ajuste_Inventario_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xls";

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

                sb.AppendLine("<h2>DETALLE DE AJUSTE DE INVENTARIO</h2>");
                sb.AppendLine("<p><b>Fecha exportación:</b> " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "</p>");

                if (dgvAjustes.CurrentRow != null)
                {
                    sb.AppendLine("<p><b>N° Ajuste:</b> " + dgvAjustes.CurrentRow.Cells["IdAjuste"].Value.ToString() + "</p>");
                    sb.AppendLine("<p><b>Fecha Ajuste:</b> " + dgvAjustes.CurrentRow.Cells["Fecha"].Value.ToString() + "</p>");
                    sb.AppendLine("<p><b>Almacén:</b> " + dgvAjustes.CurrentRow.Cells["Almacen"].Value.ToString() + "</p>");
                    sb.AppendLine("<p><b>Motivo:</b> " + dgvAjustes.CurrentRow.Cells["Motivo"].Value.ToString() + "</p>");
                    sb.AppendLine("<p><b>Estado:</b> " + dgvAjustes.CurrentRow.Cells["Estado"].Value.ToString() + "</p>");
                }

                sb.AppendLine("<p><b>Total items:</b> " + lblTotalDetalle.Text + "</p>");

                sb.AppendLine("<table border='1'>");

                sb.AppendLine("<tr style='font-weight:bold; background-color:#D9EAF7;'>");
                for (int i = 0; i < dgvDetalle.Columns.Count; i++)
                {
                    sb.AppendLine("<td>" + dgvDetalle.Columns[i].HeaderText + "</td>");
                }
                sb.AppendLine("</tr>");

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

                MessageBox.Show("Detalle exportado correctamente.",
                    "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar detalle: " + ex.Message,
                    "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ExportarHistorialAjustesExcel()
        {
            if (dgvAjustes.Rows.Count == 0)
            {
                MessageBox.Show("No hay ajustes para exportar.",
                    "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Archivo Excel (*.xls)|*.xls";
            save.FileName = "Historial_Ajustes_Inventario_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xls";

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

                sb.AppendLine("<h2>HISTORIAL DE AJUSTES DE INVENTARIO</h2>");
                sb.AppendLine("<p><b>Fecha exportación:</b> " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "</p>");
                sb.AppendLine("<p><b>Total ajustes:</b> " + lblTotalAjustes.Text + "</p>");

                sb.AppendLine("<table border='1'>");

                sb.AppendLine("<tr style='font-weight:bold; background-color:#D9EAF7;'>");
                for (int i = 0; i < dgvAjustes.Columns.Count; i++)
                {
                    sb.AppendLine("<td>" + dgvAjustes.Columns[i].HeaderText + "</td>");
                }
                sb.AppendLine("</tr>");

                foreach (DataGridViewRow row in dgvAjustes.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    sb.AppendLine("<tr>");

                    for (int i = 0; i < dgvAjustes.Columns.Count; i++)
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

                MessageBox.Show("Historial exportado correctamente.",
                    "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar historial: " + ex.Message,
                    "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnExportarDetalle_Click(object sender, EventArgs e)
        {
            ExportarDetalleAjusteExcel();
        }

        private void btnExportarHistorial_Click(object sender, EventArgs e)
        {
            ExportarHistorialAjustesExcel();
        }
    }

}
