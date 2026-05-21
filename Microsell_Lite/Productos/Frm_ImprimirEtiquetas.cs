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
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

namespace Microsell_Lite.Productos
{
    public partial class Frm_ImprimirEtiquetas : Form
    {
        public Frm_ImprimirEtiquetas()
        {
            InitializeComponent();

        }
        private const int ID_ALMACEN_DEFAULT = 1;

        private void Frm_ImprimirEtiquetas_Load(object sender, EventArgs e)
        {
            ConfigurarGridResultados();
            ConfigurarGridEtiquetas();

            txtCantidadDefault.Text = "1";
            chkMostrarPrecio.Checked = true;
            txtBuscar.Focus();
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

        private void ConfigurarGridResultados()
        {
            dgvResultados.Columns.Clear();
            dgvResultados.Rows.Clear();

            dgvResultados.AllowUserToAddRows = false;
            dgvResultados.AllowUserToDeleteRows = false;
            dgvResultados.ReadOnly = true;
            dgvResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResultados.MultiSelect = false;
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvResultados.Columns.Add("IdProducto", "IdProducto");
            dgvResultados.Columns["IdProducto"].Visible = false;

            dgvResultados.Columns.Add("Producto", "Producto");
            dgvResultados.Columns["Producto"].Width = 220;

            dgvResultados.Columns.Add("IdPresentacion", "IdPresentacion");
            dgvResultados.Columns["IdPresentacion"].Visible = false;

            dgvResultados.Columns.Add("Presentacion", "Presentación");
            dgvResultados.Columns["Presentacion"].Width = 120;

            dgvResultados.Columns.Add("SKU", "SKU");
            dgvResultados.Columns["SKU"].Width = 100;

            dgvResultados.Columns.Add("CodigoBarra", "Código Barra");
            dgvResultados.Columns["CodigoBarra"].Width = 130;

            dgvResultados.Columns.Add("Precio", "Precio");
            dgvResultados.Columns["Precio"].Width = 80;

            dgvResultados.Columns.Add("Stock", "Stock");
            dgvResultados.Columns["Stock"].Width = 80;
        }

        private void ConfigurarGridEtiquetas()
        {
            dgvEtiquetas.Columns.Clear();
            dgvEtiquetas.Rows.Clear();

            dgvEtiquetas.AllowUserToAddRows = false;
            dgvEtiquetas.AllowUserToDeleteRows = false;
            dgvEtiquetas.ReadOnly = false;
            dgvEtiquetas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEtiquetas.MultiSelect = false;
            dgvEtiquetas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvEtiquetas.Columns.Add("IdProducto", "IdProducto");
            dgvEtiquetas.Columns["IdProducto"].Visible = false;

            dgvEtiquetas.Columns.Add("Producto", "Producto");
            dgvEtiquetas.Columns["Producto"].Width = 220;

            dgvEtiquetas.Columns.Add("IdPresentacion", "IdPresentacion");
            dgvEtiquetas.Columns["IdPresentacion"].Visible = false;

            dgvEtiquetas.Columns.Add("Presentacion", "Presentación");
            dgvEtiquetas.Columns["Presentacion"].Width = 120;

            dgvEtiquetas.Columns.Add("SKU", "SKU");
            dgvEtiquetas.Columns["SKU"].Width = 100;

            dgvEtiquetas.Columns.Add("CodigoBarra", "Código Barra");
            dgvEtiquetas.Columns["CodigoBarra"].Width = 130;

            dgvEtiquetas.Columns.Add("Precio", "Precio");
            dgvEtiquetas.Columns["Precio"].Width = 80;

            dgvEtiquetas.Columns.Add("CantidadEtiquetas", "Cant. Etiquetas");
            dgvEtiquetas.Columns["CantidadEtiquetas"].Width = 100;

            DataGridViewCheckBoxColumn colMostrarPrecio = new DataGridViewCheckBoxColumn();
            colMostrarPrecio.Name = "MostrarPrecio";
            colMostrarPrecio.HeaderText = "Mostrar Precio";
            colMostrarPrecio.Width = 100;
            dgvEtiquetas.Columns.Add(colMostrarPrecio);

            foreach (DataGridViewColumn col in dgvEtiquetas.Columns)
            {
                col.ReadOnly = true;
            }

            dgvEtiquetas.Columns["Precio"].ReadOnly = false;
            dgvEtiquetas.Columns["CantidadEtiquetas"].ReadOnly = false;
            dgvEtiquetas.Columns["MostrarPrecio"].ReadOnly = false;
        }

        private DataTable CrearDataTableEtiquetas()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("IdProducto", typeof(string));
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("IdPresentacion", typeof(int));
            dt.Columns.Add("Presentacion", typeof(string));
            dt.Columns.Add("SKU", typeof(string));
            dt.Columns.Add("CodigoBarra", typeof(string));
            dt.Columns.Add("CodigoImprimir", typeof(string));
            dt.Columns.Add("Precio", typeof(decimal));
            dt.Columns.Add("PrecioTexto", typeof(string));
            dt.Columns.Add("MostrarPrecio", typeof(bool));
            dt.Columns.Add("CodigoBarraImagen", typeof(byte[]));

            foreach (DataGridViewRow row in dgvEtiquetas.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string idProducto = Convert.ToString(row.Cells["IdProducto"].Value);
                string producto = Convert.ToString(row.Cells["Producto"].Value);
                int idPresentacion = Convert.ToInt32(row.Cells["IdPresentacion"].Value);
                string presentacion = Convert.ToString(row.Cells["Presentacion"].Value);
                string sku = Convert.ToString(row.Cells["SKU"].Value);
                string codigoBarra = Convert.ToString(row.Cells["CodigoBarra"].Value);

                decimal precio = 0;
                decimal.TryParse(Convert.ToString(row.Cells["Precio"].Value), out precio);

                int cantidad = 0;
                int.TryParse(Convert.ToString(row.Cells["CantidadEtiquetas"].Value), out cantidad);

                bool mostrarPrecio = false;

                if (row.Cells["MostrarPrecio"].Value != null)
                    mostrarPrecio = Convert.ToBoolean(row.Cells["MostrarPrecio"].Value);

                string codigoImprimir = "";

                if (!string.IsNullOrWhiteSpace(codigoBarra))
                    codigoImprimir = codigoBarra.Trim();
                else
                    codigoImprimir = sku.Trim();

                string precioTexto = mostrarPrecio ? "S/ " + precio.ToString("0.00") : "";

                byte[] imagenBarcode = GenerarCodigoBarrasBytes(codigoImprimir);

                for (int i = 0; i < cantidad; i++)
                {
                    DataRow dr = dt.NewRow();

                    dr["IdProducto"] = idProducto;
                    dr["Producto"] = producto;
                    dr["IdPresentacion"] = idPresentacion;
                    dr["Presentacion"] = presentacion;
                    dr["SKU"] = sku;
                    dr["CodigoBarra"] = codigoBarra;
                    dr["CodigoImprimir"] = codigoImprimir;
                    dr["Precio"] = precio;
                    dr["PrecioTexto"] = precioTexto;
                    dr["MostrarPrecio"] = mostrarPrecio;
                    dr["CodigoBarraImagen"] = imagenBarcode;


                    dt.Rows.Add(dr);
                }
            }

            return dt;
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
        private void BuscarPresentaciones()
        {
            string valor = txtBuscar.Text.Trim();

            if (valor.Length == 0)
            {
                MessageBox.Show("Ingrese producto, SKU o código de barras.",
                    "Etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscar.Focus();
                return;
            }

            RN_Etiquetas obj = new RN_Etiquetas();
            DataTable dt = obj.RN_Buscar_Presentaciones_ParaEtiquetas(valor, ID_ALMACEN_DEFAULT);

            dgvResultados.Rows.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                dgvResultados.Rows.Add(
                    dr["Id_Pro"].ToString(),
                    dr["Descripcion_Larga"].ToString(),
                    Convert.ToInt32(dr["IdPresentacion"]),
                    dr["NombrePresentacion"].ToString(),
                    dr["SKU"].ToString(),
                    dr["CodigoBarra"].ToString(),
                    Convert.ToDecimal(dr["PrecioVentaMinorista"]).ToString("0.00"),
                    Convert.ToDecimal(dr["StockPresentacion"]).ToString("0.####")
                );
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron presentaciones.",
                    "Etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private byte[] GenerarCodigoBarrasBytes(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return null;

            try
            {
                BarcodeWriter writer = new BarcodeWriter
                {
                    Format = BarcodeFormat.CODE_128,
                    Options = new EncodingOptions
                    {
                        Width = 280,
                        Height = 80,
                        Margin = 1,
                        PureBarcode = true
                    }
                };

                using (Bitmap bitmap = writer.Write(texto.Trim()))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitmap.Save(ms, ImageFormat.Png);
                        return ms.ToArray();
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        private void txtBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            
        } 
        private void TxtNumeros_KeyPress(object sender,KeyPressEventArgs e)
        {
           
        } 

        private void btn_cerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarPresentaciones();
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarPresentaciones();
        }
        private void AgregarEtiqueta()
        {
            if (dgvResultados.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una presentación.",
                    "Etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = 1;

            if (!int.TryParse(txtCantidadDefault.Text.Trim(), out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.",
                    "Etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidadDefault.Focus();
                return;
            }

            DataGridViewRow row = dgvResultados.CurrentRow;

            string idProducto = row.Cells["IdProducto"].Value.ToString();
            string producto = row.Cells["Producto"].Value.ToString();
            int idPresentacion = Convert.ToInt32(row.Cells["IdPresentacion"].Value);
            string presentacion = row.Cells["Presentacion"].Value.ToString();
            string sku = row.Cells["SKU"].Value.ToString();
            string codigoBarra = row.Cells["CodigoBarra"].Value.ToString();
            string precio = row.Cells["Precio"].Value.ToString();

            if (string.IsNullOrWhiteSpace(codigoBarra) && string.IsNullOrWhiteSpace(sku))
            {
                MessageBox.Show("La presentación no tiene código de barras ni SKU.",
                    "Etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvEtiquetas.Rows.Add(
                idProducto,
                producto,
                idPresentacion,
                presentacion,
                sku,
                codigoBarra,
                precio,
                cantidad,
                chkMostrarPrecio.Checked
            );

            txtCantidadDefault.Text = "1";
            txtBuscar.Clear();
            txtBuscar.Focus();
        }

        private bool ValidarEtiquetas()
        {
            if (dgvEtiquetas.Rows.Count == 0)
            {
                MessageBox.Show("Agregue al menos una etiqueta para imprimir.",
                    "Etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            foreach (DataGridViewRow row in dgvEtiquetas.Rows)
            {
                int cantidad = 0;
                decimal precio = 0;

                if (!int.TryParse(Convert.ToString(row.Cells["CantidadEtiquetas"].Value), out cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Hay una cantidad de etiquetas inválida.",
                        "Etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (!decimal.TryParse(Convert.ToString(row.Cells["Precio"].Value), out precio) || precio < 0)
                {
                    MessageBox.Show("Hay un precio inválido.",
                        "Etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string codigoBarra = Convert.ToString(row.Cells["CodigoBarra"].Value);
                string sku = Convert.ToString(row.Cells["SKU"].Value);

                if (string.IsNullOrWhiteSpace(codigoBarra) && string.IsNullOrWhiteSpace(sku))
                {
                    MessageBox.Show("Una etiqueta no tiene código de barras ni SKU.",
                        "Etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarEtiqueta();
        }

        private void dgvResultados_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                AgregarEtiqueta();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvEtiquetas.CurrentRow == null)
                return;

            dgvEtiquetas.Rows.Remove(dgvEtiquetas.CurrentRow);
            
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!ValidarEtiquetas())
                return;

            DataTable dtEtiquetas = CrearDataTableEtiquetas();

            if (dtEtiquetas.Rows.Count == 0)
            {
                MessageBox.Show("No hay etiquetas para imprimir.",
                    "Etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Print_Etiquetas frm = new Frm_Print_Etiquetas();

            fil.Show();
            frm.dtEtiquetas = dtEtiquetas;
            frm.ShowDialog();
            fil.Hide();


        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvEtiquetas.Rows.Clear();
        }

        
    }

}
