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

namespace Microsell_Lite.Productos
{
    public partial class Frm_TomaInventario : Form
    {
        public Frm_TomaInventario()
        {
            InitializeComponent();

        }
        private const int ID_ALMACEN_DEFAULT = 1;
        private void Frm_TomaInventario_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();

            dgvDetalle.CellEndEdit -= dgvDetalle_CellEndEdit;
            dgvDetalle.CellEndEdit += dgvDetalle_CellEndEdit;

            dgvDetalle.EditingControlShowing -= dgvDetalle_EditingControlShowing;
            dgvDetalle.EditingControlShowing += dgvDetalle_EditingControlShowing;

            btnAplicarAjuste.Enabled = false;

        }
        private void AplicarTemaGrid(DataGridView dgv, bool editable = false)
        {
            dgv.EnableHeadersVisualStyles = false;

            dgv.BackgroundColor = Color.White;

            dgv.BorderStyle = BorderStyle.None;

            dgv.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.GridColor =
                Color.FromArgb(240, 240, 240);

            dgv.RowHeadersVisible = false;

            dgv.RowHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgv.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;

            dgv.MultiSelect = false;

            dgv.SelectionMode = editable
                ? DataGridViewSelectionMode.CellSelect
                : DataGridViewSelectionMode.FullRowSelect;

            dgv.ReadOnly = !editable;

            // =====================================================
            // HEADER
            // =====================================================

            dgv.ColumnHeadersHeight = 40;

            dgv.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(30, 64, 175);

            dgv.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            dgv.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(30, 64, 175);

            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                Color.White;

            // =====================================================
            // FILAS
            // =====================================================

            dgv.RowTemplate.Height = 32;

            dgv.DefaultCellStyle.Font =
                new Font("Segoe UI", 9F);

            dgv.DefaultCellStyle.BackColor =
                Color.White;

            dgv.DefaultCellStyle.ForeColor =
                Color.FromArgb(40, 40, 40);

            dgv.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(219, 234, 254);

            dgv.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            dgv.DefaultCellStyle.Padding =
                new Padding(3);

            dgv.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 250, 252);
        }

        // =========================================================
        // CONFIGURAR GRID
        // =========================================================

        private void ConfigurarGrid()
        {
            dgvDetalle.Columns.Clear();
            dgvDetalle.Rows.Clear();

            // Aplicar tema visual
            AplicarTemaGrid(dgvDetalle, true);

            // Permite editar al escribir
            dgvDetalle.EditMode =
                DataGridViewEditMode.EditOnKeystrokeOrF2;

            // =====================================================
            // COLUMNAS
            // =====================================================

            dgvDetalle.Columns.Add("IdProducto", "IdProducto");
            dgvDetalle.Columns["IdProducto"].Visible = false;

            dgvDetalle.Columns.Add("Producto", "Producto");
            dgvDetalle.Columns["Producto"].FillWeight = 220;

            dgvDetalle.Columns.Add("IdPresentacion", "IdPresentacion");
            dgvDetalle.Columns["IdPresentacion"].Visible = false;

            dgvDetalle.Columns.Add("Presentacion", "Presentación");
            dgvDetalle.Columns["Presentacion"].FillWeight = 120;

            dgvDetalle.Columns.Add("Abrev", "Abrev");
            dgvDetalle.Columns["Abrev"].FillWeight = 60;

            dgvDetalle.Columns.Add("Equivalencia", "Equiv.");
            dgvDetalle.Columns["Equivalencia"].FillWeight = 70;

            dgvDetalle.Columns.Add("StockSistema", "Stock Sistema");
            dgvDetalle.Columns["StockSistema"].FillWeight = 100;

            dgvDetalle.Columns.Add("StockContado", "Stock Contado");
            dgvDetalle.Columns["StockContado"].FillWeight = 100;

            dgvDetalle.Columns.Add("Diferencia", "Diferencia");
            dgvDetalle.Columns["Diferencia"].FillWeight = 90;

            dgvDetalle.Columns.Add("DiferenciaBase", "Dif. Base");
            dgvDetalle.Columns["DiferenciaBase"].FillWeight = 90;

            // =====================================================
            // SOLO UNA COLUMNA EDITABLE
            // =====================================================

            foreach (DataGridViewColumn col in dgvDetalle.Columns)
            {
                col.ReadOnly = true;
            }

            dgvDetalle.Columns["StockContado"].ReadOnly = false;

            // =====================================================
            // RESALTAR COLUMNA EDITABLE
            // =====================================================

            dgvDetalle.Columns["StockContado"]
                .DefaultCellStyle.BackColor =
                Color.FromArgb(255, 251, 230);

            dgvDetalle.Columns["StockContado"]
                .DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(254, 240, 138);

            // =====================================================
            // FORMATOS NUMÉRICOS
            // =====================================================

            dgvDetalle.Columns["Equivalencia"]
                .DefaultCellStyle.Format = "N2";

            dgvDetalle.Columns["StockSistema"]
                .DefaultCellStyle.Format = "N2";

            dgvDetalle.Columns["StockContado"]
                .DefaultCellStyle.Format = "N2";

            dgvDetalle.Columns["Diferencia"]
                .DefaultCellStyle.Format = "N2";

            dgvDetalle.Columns["DiferenciaBase"]
                .DefaultCellStyle.Format = "N2";

            // =====================================================
            // ALINEACIÓN
            // =====================================================

            dgvDetalle.Columns["Equivalencia"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvDetalle.Columns["StockSistema"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvDetalle.Columns["StockContado"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvDetalle.Columns["Diferencia"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvDetalle.Columns["DiferenciaBase"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarProductoInventario();
        }
        private void BuscarProductoInventario()
        {
            string valor = txtBuscarProducto.Text.Trim();

            if (valor.Length == 0)
            {
                MessageBox.Show("Ingrese o escanee el código del producto.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RN_InventarioAjuste obj = new RN_InventarioAjuste();
            DataTable dt = obj.RN_Buscar_Producto_Inventario(valor, ID_ALMACEN_DEFAULT);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró el producto o presentación.",
                    "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CargarPresentacionesDesdeDataTable(dt);

            txtBuscarProducto.Text ="";
            txtBuscarProducto.Focus();
        }

        private void CargarPresentacionesDesdeDataTable(DataTable dt)
        {
            dgvDetalle.Rows.Clear();

            if (dt.Rows.Count == 0)
                return;

            lblIdProducto.Text = dt.Rows[0]["Id_Pro"].ToString();
            lblNombreProducto.Text = dt.Rows[0]["Descripcion_Larga"].ToString();

            foreach (DataRow dr in dt.Rows)
            {
                decimal stockSistema = Convert.ToDecimal(dr["StockPresentacion"]);

                dgvDetalle.Rows.Add(
                    dr["Id_Pro"].ToString(),
                    dr["Descripcion_Larga"].ToString(),
                    Convert.ToInt32(dr["IdPresentacion"]),
                    dr["NombrePresentacion"].ToString(),
                    dr["Abreviatura"].ToString(),
                    Convert.ToDecimal(dr["Equivalencia"]).ToString("0.####"),
                    stockSistema.ToString("0.####"),
                    stockSistema.ToString("0.####"),
                    "0.0000",
                    "0.0000"
                );
            }

            dgvDetalle.ReadOnly = false;
            dgvDetalle.Columns["StockContado"].ReadOnly = false;

            if (dgvDetalle.Rows.Count > 0)
            {
                dgvDetalle.CurrentCell = dgvDetalle.Rows[0].Cells["StockContado"];
                dgvDetalle.BeginEdit(true);
            }

            btnAplicarAjuste.Enabled = false;
        }
        private void CargarPresentacionesInventario(string idProducto)
        {
            RN_InventarioAjuste obj = new RN_InventarioAjuste();
            DataTable dt = obj.RN_Listar_StockPresentacion_Inventario(idProducto, ID_ALMACEN_DEFAULT);

            dgvDetalle.Rows.Clear();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron presentaciones para este producto.",
                    "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lblIdProducto.Text = dt.Rows[0]["Id_Pro"].ToString();
            lblNombreProducto.Text = dt.Rows[0]["Descripcion_Larga"].ToString();

            foreach (DataRow dr in dt.Rows)
            {
                decimal stockSistema = Convert.ToDecimal(dr["StockPresentacion"]);

                dgvDetalle.Rows.Add(
                    dr["Id_Pro"].ToString(),
                    dr["Descripcion_Larga"].ToString(),
                    Convert.ToInt32(dr["IdPresentacion"]),
                    dr["NombrePresentacion"].ToString(),
                    dr["Abreviatura"].ToString(),
                    Convert.ToDecimal(dr["Equivalencia"]).ToString("0.####"),
                    stockSistema.ToString("0.####"),
                    stockSistema.ToString("0.####"),
                    "0.0000",
                    "0.0000"
                );
            }

            btnAplicarAjuste.Enabled = false;

            dgvDetalle.ReadOnly = false;
            dgvDetalle.Columns["StockContado"].ReadOnly = false;

            if (dgvDetalle.Rows.Count > 0)
            {
                dgvDetalle.CurrentCell = dgvDetalle.Rows[0].Cells["StockContado"];
                dgvDetalle.BeginEdit(true);
            }
        }

        private void CalcularFila(int rowIndex)
        {
            DataGridViewRow row = dgvDetalle.Rows[rowIndex];

            decimal stockSistema = 0;
            decimal stockContado = 0;
            decimal equivalencia = 1;

            decimal.TryParse(Convert.ToString(row.Cells["StockSistema"].Value), out stockSistema);
            decimal.TryParse(Convert.ToString(row.Cells["StockContado"].Value), out stockContado);
            decimal.TryParse(Convert.ToString(row.Cells["Equivalencia"].Value), out equivalencia);

            if (equivalencia <= 0)
                equivalencia = 1;

            decimal diferencia = stockContado - stockSistema;
            decimal diferenciaBase = diferencia * equivalencia;

            row.Cells["Diferencia"].Value = diferencia.ToString("0.####");
            row.Cells["DiferenciaBase"].Value = diferenciaBase.ToString("0.####");
        }

        private void txtBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarProductoInventario();
            }
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvDetalle.Columns[e.ColumnIndex].Name == "StockContado")
            {
                CalcularFila(e.RowIndex);
                btnAplicarAjuste.Enabled = true;
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvDetalle.Rows.Count; i++)
            {
                CalcularFila(i);
            }

            btnAplicarAjuste.Enabled = true;
        }

        private void AplicarAjusteInventario()
        {
            if (dgvDetalle.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para ajustar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Ingrese el motivo del ajuste.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivo.Focus();
                return;
            }

            CalcularTodasLasFilas();

            bool hayDiferencias = false;

            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                decimal diferenciaBase = Convert.ToDecimal(row.Cells["DiferenciaBase"].Value);

                if (diferenciaBase != 0)
                {
                    hayDiferencias = true;
                    break;
                }
            }

            if (!hayDiferencias)
            {
                MessageBox.Show("No hay diferencias para aplicar.", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult rpta = MessageBox.Show(
                "¿Deseas aplicar el ajuste de inventario?\n\nEsto actualizará stock físico, stock base y Kardex.",
                "Confirmar ajuste",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (rpta != DialogResult.Yes)
                return;

            try
            {
                RN_InventarioAjuste rnAjuste = new RN_InventarioAjuste();
                RN_Productos rnProd = new RN_Productos();

                EN_InventarioAjuste aj = new EN_InventarioAjuste();
                aj.IdAlmacen = ID_ALMACEN_DEFAULT;
                aj.Motivo = txtMotivo.Text.Trim();
                aj.Observacion = txtObservacion.Text.Trim();
                aj.IdUsuario = Convert.ToInt32(Cls_Libreria.IdUsu);
                aj.Estado = "Aplicado";

                int idAjuste = rnAjuste.RN_Registrar_InventarioAjuste(aj);

                if (idAjuste <= 0)
                {
                    MessageBox.Show("No se pudo registrar la cabecera del ajuste.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    string idProducto = row.Cells["IdProducto"].Value.ToString();
                    int idPresentacion = Convert.ToInt32(row.Cells["IdPresentacion"].Value);

                    decimal stockSistema = Convert.ToDecimal(row.Cells["StockSistema"].Value);
                    decimal stockContado = Convert.ToDecimal(row.Cells["StockContado"].Value);
                    decimal diferencia = Convert.ToDecimal(row.Cells["Diferencia"].Value);
                    decimal equivalencia = Convert.ToDecimal(row.Cells["Equivalencia"].Value);
                    decimal diferenciaBase = Convert.ToDecimal(row.Cells["DiferenciaBase"].Value);

                    if (diferenciaBase == 0)
                        continue;

                    EN_InventarioAjusteDetalle det = new EN_InventarioAjusteDetalle();
                    det.IdAjuste = idAjuste;
                    det.IdProducto = idProducto;
                    det.IdPresentacion = idPresentacion;
                    det.StockSistema = stockSistema;
                    det.StockContado = stockContado;
                    det.Diferencia = diferencia;
                    det.Equivalencia = equivalencia;
                    det.DiferenciaBase = diferenciaBase;

                    rnAjuste.RN_Registrar_InventarioAjusteDetalle(det);

                    // 1. Registrar Kardex ANTES de actualizar stock base
                    Registrar_Kardex_Ajuste(
                        idProducto,
                        Convert.ToDouble(diferenciaBase)
                    );

                    // 2. Ajustar stock físico exacto por presentación
                    rnAjuste.RN_Ajustar_StockPresentacion_Exacto(
                        ID_ALMACEN_DEFAULT,
                        idProducto,
                        idPresentacion,
                        stockContado
                    );

                    // 3. Ajustar stock base del producto
                    rnProd.RN_Ajustar_StockBase_Producto(
                        idProducto,
                        diferenciaBase
                    );
                }

                MessageBox.Show("Ajuste aplicado correctamente.", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnAplicarAjuste.Enabled = false;
                CargarPresentacionesInventario(lblIdProducto.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar ajuste: " + ex.Message, "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CalcularTodasLasFilas()
        {
            for (int i = 0; i < dgvDetalle.Rows.Count; i++)
            {
                CalcularFila(i);
            }
        }

        private void Registrar_Kardex_Ajuste(string idProducto, double diferenciaBase)
        {
            if (diferenciaBase == 0)
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
                kar.Doc_soporte = "AJUSTE-INV";
                kar.Det_Operacion = "Ajuste de Inventario";
                kar.TipoOperacion = "AjusteInventario";
                kar.CantiDiferencial = "0";
                kar.ImporteDiferencial = 0;
                kar.Observacion = txtMotivo.Text.Trim();

                kar.Promedio = precioCompraProd;

                if (diferenciaBase > 0)
                {
                    // Entrada por ajuste
                    kar.Cantidad_in = diferenciaBase;
                    kar.Precio_In = precioCompraProd;
                    kar.Total_In = diferenciaBase * precioCompraProd;

                    kar.Cantidad_Out = 0;
                    kar.Precio_out = 0;
                    kar.Total_out = 0;

                    kar.Cantidad_saldo = stockActualAntes + diferenciaBase;
                }
                else
                {
                    // Salida por ajuste
                    double salida = Math.Abs(diferenciaBase);

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
                MessageBox.Show("Error Kardex ajuste: " + ex.Message, "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAplicarAjuste_Click(object sender, EventArgs e)
        {
            AplicarAjusteInventario();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvDetalle.CurrentCell.ColumnIndex ==
                dgvDetalle.Columns["StockContado"].Index)
            {
                TextBox txt = e.Control as TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= TxtNumeros_KeyPress;
                    txt.KeyPress += TxtNumeros_KeyPress;
                }
            }
        }

        private void TxtNumeros_KeyPress(object sender,KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            // números
            if (char.IsDigit(e.KeyChar))
                return;

            // backspace
            if (e.KeyChar == (char)Keys.Back)
                return;

            // decimal
            if (e.KeyChar == '.' &&
                !txt.Text.Contains("."))
                return;

            // bloquear resto
            e.Handled = true;
        }

        private void dgvDetalle_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }
    }


}
