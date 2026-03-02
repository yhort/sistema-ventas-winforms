using Prj_Capa_Datos;
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
using Guna.UI;
using Microsell_Lite.Utilitarios;

namespace Microsell_Lite.Ventas
{
    public partial class Frm_Promociones : Form
    {
        private DataTable productosTable;
        public Frm_Promociones()
        {
            InitializeComponent();
            //this.Load += new System.EventHandler(this.Frm_Promociones_Load);
            //this.txtBuscarProducto.TextChanged += new System.EventHandler(this.txtBuscarProducto_TextChanged);
            //this.dgvProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellDoubleClick);
        }
   

        private void Frm_Promociones_Load(object sender, EventArgs e)
        {
            //_ = Buscar_CargarProductos(txtBuscarProducto.Text);
            ConfigurarDataGridView();
            ConfigurarListView();
            CargarTiposPromocion();

            DateTime ahora = DateTime.Now;
            dtpInicio.Value = ahora.Date;
            dtpFin.Value = ahora;

            tabControl1.SelectedTab = tabPage1; // Por defecto, mostrar la lista

           
            CargarListadoPromociones();
        }

      


        private void ConfigurarDataGridView()
        {
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            if (dgvProductos.Columns.Contains("Id_Pro"))
                dgvProductos.Columns["Id_Pro"].Visible = false;

            if (dgvProductos.Columns.Contains("Descripcion_Larga"))
            {
                dgvProductos.Columns["Descripcion_Larga"].HeaderText = "Producto";
                dgvProductos.Columns["Descripcion_Larga"].Width = 250;
                dgvProductos.Columns["Descripcion_Larga"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
               

            if (dgvProductos.Columns.Contains("Stock_Actual"))
            {
                dgvProductos.Columns["Stock_Actual"].HeaderText = "Stock";
                dgvProductos.Columns["Stock_Actual"].Width =80;
                dgvProductos.Columns["Stock_Actual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
               

            if (dgvProductos.Columns.Contains("Pre_vntaxMenor"))
            {
                dgvProductos.Columns["Pre_vntaxMenor"].HeaderText = "Precio";
                dgvProductos.Columns["Pre_vntaxMenor"].DefaultCellStyle.Format = "C2"; //formato de moneda
                dgvProductos.Columns["Pre_vntaxMenor"].Width = 100;
                dgvProductos.Columns["Pre_vntaxMenor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
           
        }

        //para mostrar promo productos
        private void ConfigurarListView()
        {
            lvwPromocion.View = View.Details;
            lvwPromocion.FullRowSelect = true;
            lvwPromocion.MultiSelect = false;
            lvwPromocion.GridLines = true;
            lvwPromocion.LabelEdit = false;
            lvwPromocion.Columns.Clear();

            lvwPromocion.Columns.Add("IdProducto", 100, HorizontalAlignment.Left);
            lvwPromocion.Columns.Add("Nombre", 200, HorizontalAlignment.Left);
            lvwPromocion.Columns.Add("Cantidad", 80, HorizontalAlignment.Center);
            lvwPromocion.Columns.Add("PrecioUnitario", 100, HorizontalAlignment.Right);
        }

        //tabpag3listview
        private void ConfigurarListViewDetalleVista()
        {
            lvwDetalleVista.View = View.Details;
            lvwDetalleVista.FullRowSelect = true;
            lvwDetalleVista.GridLines = true;
            lvwDetalleVista.Columns.Clear();

            lvwDetalleVista.Columns.Add("ID Producto", 100, HorizontalAlignment.Left);
            lvwDetalleVista.Columns.Add("Descripción", 250, HorizontalAlignment.Left);
            lvwDetalleVista.Columns.Add("Cantidad", 80, HorizontalAlignment.Center);
            lvwDetalleVista.Columns.Add("Precio Unit.", 100, HorizontalAlignment.Right);
        }
        //fin
        private async Task Buscar_CargarProductos(string valor)
        {
            RN_Productos obj = new RN_Productos();
            productosTable = await Task.Run(() => obj.RN_Buscar_Productos_Promociones(valor));

            if (productosTable.Rows.Count > 0)
            {
                dgvProductos.DataSource = productosTable;
                ConfigurarDataGridView();  // Para ajustar columnas y ocultar ID
            }
            else
            {
                dgvProductos.DataSource = null;  // Limpiar grilla si no hay resultados
                MessageBox.Show("No se encontraron productos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private async void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            string valor = txtBuscarProducto.Text.Trim();
            if (valor.Length >= 2)  // Solo buscar si escribe mínimo 2 caracteres
            {
                await Buscar_CargarProductos(valor);
            }
            else
            {
                dgvProductos.DataSource = null;  // Limpiar grilla si borran el texto
            }
        }

        private async void txtBuscarProducto_OnValueChanged(object sender, EventArgs e)
        {
            string valor = txtBuscarProducto.Text.Trim();
            if (valor.Length >= 2)  // Solo buscar si escribe mínimo 2 caracteres
            {
                await Buscar_CargarProductos(valor);
            }
            else
            {
                dgvProductos.DataSource = null;  // Limpiar grilla si borran el texto
            }
            //if (productosTable != null)
            //{
            //    DataView dv = productosTable.DefaultView;
            //    string filtro = txtBuscarProducto.Text.Trim().Replace("'", "''");
            //    dv.RowFilter = $"Descripcion_Larga LIKE '%{filtro}%' OR Id_Pro LIKE '%{filtro}%'";
            //    dgvProductos.DataSource = dv;
            //}
        }

        private void AgregarProductoAPack(string idProd, string nombre, decimal precioNormal)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ad = new Frm_Advertencia();

            int cantidad = (int)numCantidad.Value;

            if (!decimal.TryParse(txtPrecioUnit.Text.Trim(), out decimal precio))
            {
               
                fil.Show();
                ad.Lbl_msm1.Text = "Ingrese un precio válido.";
                ad.ShowDialog();
                fil.Hide();
                return;
            }

            if (precio > precioNormal)
            {
                //MessageBox.Show("El precio de promoción no puede ser mayor al precio normal.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fil.Show();
                ad.Lbl_msm1.Text = "El precio de promoción no puede ser mayor al precio normal.";
                ad.ShowDialog();
                fil.Hide();
                return;
            }

            if (!ProductoYaAgregado(idProd))
            {
                var item = new ListViewItem(new[] { idProd, nombre, cantidad.ToString(), precio.ToString("C2") });
                lvwPromocion.Items.Add(item);
            }
            else
            {
                //MessageBox.Show("Este producto ya está agregado al pack.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fil.Show();
                ad.Lbl_msm1.Text = "Este producto ya está agregado al pack.";
                ad.ShowDialog();
                fil.Hide();
            }
        }


        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string idProducto = dgvProductos.Rows[e.RowIndex].Cells["Id_Pro"].Value.ToString();
                string descripcion = dgvProductos.Rows[e.RowIndex].Cells["Descripcion_Larga"].Value.ToString();
                decimal precioNormal = Convert.ToDecimal(dgvProductos.Rows[e.RowIndex].Cells["Pre_vntaxMenor"].Value);

                AgregarProductoAPack(idProducto, descripcion, precioNormal);
            }
        }

        private void CargarTiposPromocion()
        {
            cboTipoPromo.Items.Add("PACK");
            cboTipoPromo.Items.Add("DESCUENTO_CANTIDAD");
            cboTipoPromo.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                string idProd = dgvProductos.CurrentRow.Cells["Id_Pro"].Value.ToString();
                string nombre = dgvProductos.CurrentRow.Cells["Descripcion_Larga"].Value.ToString();
                decimal precioNormal = Convert.ToDecimal(dgvProductos.CurrentRow.Cells["Pre_vntaxMenor"].Value);

                AgregarProductoAPack(idProd, nombre, precioNormal);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ad = new Frm_Advertencia();
            Frm_Sino sino = new Frm_Sino();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

            string nombrePromo = txtNombrePromo.Text.Trim();
            string tipo = cboTipoPromo.SelectedItem.ToString();
            DateTime fechaInicio = dtpInicio.Value.Date + TimeSpan.FromHours(0);//dtpInicio.Value;
            DateTime fechaFin = dtpFin.Value.Date + TimeSpan.FromHours(23).Add(TimeSpan.FromMinutes(59)); //dtpFin.Value;




            if (string.IsNullOrEmpty(nombrePromo) || lvwPromocion.Items.Count == 0)
            {
                //MessageBox.Show("Debe ingresar un nombre y al menos un producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fil.Show();
                ad.Lbl_msm1.Text = "Debe ingresar un nombre y al menos un producto.";
                ad.ShowDialog();
                fil.Hide();
                return;
            }

            if (fechaFin <= fechaInicio)
            {
                //MessageBox.Show("La fecha y hora de fin deben ser mayores que la de inicio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fil.Show();
                ad.Lbl_msm1.Text = "La fecha  de fin deben ser mayores que la de inicio.";
                ad.ShowDialog();
                fil.Hide();
                return;
            }

            fil.Show();
            sino.Lbl_msm1.Text = "¿Está seguro de guardar esta promoción?";
            sino.ShowDialog();
            fil.Hide();

            //var result = MessageBox.Show("¿Está seguro de guardar esta promoción?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result != DialogResult.Yes)
            //    return;

            if (sino.Tag.ToString() != "Si")
                return;

            RN_Promocion objPromo = new RN_Promocion();
            //int idPromo = objPromo.RN_RegistrarPromocion(nombrePromo, tipo, fechaInicio, fechaFin);

            if (txtIdPromo.Text == "")
            {
                // NUEVA PROMO
                int idPromo = objPromo.RN_RegistrarPromocion(nombrePromo, tipo, fechaInicio, fechaFin);
                foreach (ListViewItem item in lvwPromocion.Items)
                {
                    objPromo.RN_RegistrarDetallePromocion(idPromo, item.SubItems[0].Text, int.Parse(item.SubItems[2].Text), decimal.Parse(item.SubItems[3].Text, System.Globalization.NumberStyles.Currency));
                }
            }
            else
            {
                // ACTUALIZAR
                int idPromo = int.Parse(txtIdPromo.Text);
                objPromo.RN_Actualizar_Promocion(idPromo, nombrePromo, tipo, fechaInicio, fechaFin);
                objPromo.RN_EliminarDetallePromocion(idPromo);
                foreach (ListViewItem item in lvwPromocion.Items)
                {
                    objPromo.RN_RegistrarDetallePromocion(idPromo, item.SubItems[0].Text, int.Parse(item.SubItems[2].Text), decimal.Parse(item.SubItems[3].Text, System.Globalization.NumberStyles.Currency));
                    
                }
            }


            //MessageBox.Show("Promoción guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fil.Show();
            ok.Lbl_msm1.Text = "Promoción guardada correctamente.";
            ok.ShowDialog();
            fil.Hide();

            // Limpiar
            lvwPromocion.Items.Clear();
            CargarListadoPromociones();
       
            tabControl1.SelectedTab = tabPage1;
            //txtNombrePromo.Text="";
            //numCantidad.Value = 1;
            //txtPrecioUnit.Text = "";
        }

        private bool ProductoYaAgregado(string idProducto)
        {
            foreach (ListViewItem item in lvwPromocion.Items)
            {
                if (item.SubItems[0].Text == idProducto)
                    return true;
            }
            return false;
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            if (lvwPromocion.SelectedItems.Count > 0)
            {
                lvwPromocion.Items.Remove(lvwPromocion.SelectedItems[0]);
            }
        }

        private void txtPrecioUnit_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtPrecioUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, una coma o punto, y borrar
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Solo permitir un separador decimal
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (sender as TextBox).Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void dgvProductos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvProductos.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(196,210,245); // Fondo al pasar el ratón
                dgvProductos.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        private void dgvProductos_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvProductos.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = dgvProductos.DefaultCellStyle.BackColor; // Restaurar color original
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {

            if(tabControl1.SelectedTab == tabPage1)
            {
                this.Close();
            }
           
        }

        // --- Limpiar campos para nueva promo
        private void LimpiarFormulario()
        {
            txtIdPromo.Text = "";
            txtNombrePromo.Text = "";
            cboTipoPromo.SelectedIndex = 0;
            dtpInicio.Value = DateTime.Today;
            dtpFin.Value = DateTime.Today;
            lvwPromocion.Items.Clear();
        }

        private void CargarListadoPromociones()
        {
            RN_Promocion objPromo = new RN_Promocion();
            var promociones = objPromo.RN_Listar_Promociones(); // Devuelve un DataTable

            dgvListadoPromos.DataSource = promociones; // DataGridView en tabPage1
        }

        private void btnNuevaPromo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            lblModo.Text = "NUEVA PROMOCIÓN";
            tabControl1.SelectedTab = tabPage2;
        }

        private void btnEditarPromo_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ad = new Frm_Advertencia();
            RN_Promocion objPromo = new RN_Promocion();
            if (dgvListadoPromos.SelectedRows.Count == 0) return;

            int idPromo = Convert.ToInt32(dgvListadoPromos.SelectedRows[0].Cells["IdPromocion"].Value);

            //Validar si ya fue usada
            if (objPromo.RN_PromocionYaUsada(idPromo))
            {
                //MessageBox.Show("⚠ No se puede editar esta promoción porque ya fue utilizada en ventas.\nPuedes crear una nueva si deseas modificar condiciones.",
                //
                // "Edición bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fil.Show();
                ad.Lbl_msm1.Text = "No se puede editar esta promoción porque ya fue utilizada en ventas. \nPuedes crear una nueva si deseas modificar condiciones";
                ad.ShowDialog();
                fil.Hide();
                return;
            }

            CargarDatosPromocion(idPromo);
            lblModo.Text = "EDITANDO PROMOCIÓN";
            tabControl1.SelectedTab = tabPage2;
        }

        // --- Cargar los datos de una promoción para editar
        private void CargarDatosPromocion(int idPromo)
        {

            RN_Promocion objPromo = new RN_Promocion();
            DataRow promo = objPromo.RN_ObtenerCabeceraPromo(idPromo);
            txtNombrePromo.Text = promo["Nombre"].ToString();
            cboTipoPromo.SelectedItem = promo["Tipo"].ToString();
            dtpInicio.Value = Convert.ToDateTime(promo["FechaInicio"]);
            dtpFin.Value = Convert.ToDateTime(promo["FechaFin"]);

            var detalle = objPromo.RN_BuscarDetallePromocion_paraActualizar(idPromo);
            lvwPromocion.Items.Clear();
            foreach (DataRow fila in detalle.Rows)
            {
                var item = new ListViewItem(fila["IdProducto"].ToString());
                item.SubItems.Add(fila["Descripcion_Larga"].ToString());
                item.SubItems.Add(fila["Cantidad"].ToString());
                item.SubItems.Add(Convert.ToDecimal(fila["PrecioUnitario"]).ToString("C2"));
                lvwPromocion.Items.Add(item);
            }
            

            txtIdPromo.Text = idPromo.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }



        private void CargarDetallePromocionVista(int idPromo)
        {
            RN_Promocion objPromo = new RN_Promocion();
            lvwDetalleVista.Items.Clear();
            ConfigurarListViewDetalleVista();
            DataTable detalle = objPromo.RN_BuscarDetallePromocion_paraActualizar(idPromo);

            foreach (DataRow fila in detalle.Rows)
            {
                var item = new ListViewItem(fila["IdProducto"].ToString());
                item.SubItems.Add(fila["Descripcion_Larga"].ToString());
                item.SubItems.Add(fila["Cantidad"].ToString());
                item.SubItems.Add(Convert.ToDecimal(fila["PrecioUnitario"]).ToString("C2"));
                lvwDetalleVista.Items.Add(item);
            }
        }

        private void btnVolverDesdeDetalle_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvListadoPromos.SelectedRows.Count == 0) return;
            int idPromo = Convert.ToInt32(dgvListadoPromos.SelectedRows[0].Cells["IdPromocion"].Value);
            CargarDetallePromocionVista(idPromo);
            tabControl1.SelectedTab = tabPage3;
        }

        // --- Limpiar campos para nueva promo

    }
}
