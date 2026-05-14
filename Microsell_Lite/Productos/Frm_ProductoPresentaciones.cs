using DocumentFormat.OpenXml.Bibliography;
using Gma.QrCodeNet.Encoding.DataEncodation;
using Microsell_Lite.Proveedor;
using Microsell_Lite.Utilitarios;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsell_Lite.Productos
{
    public partial class Frm_ProductoPresentaciones : Form
    {
        public string IdProducto = "";
        public string NombreProducto = "";
        public int IdPresentacion = 0;
        public string Modo = "N"; //N=nuevo, E=editar
        public string Abrev_und ="";

        public bool EsFlujoProducto = false;          //  viene de form producto
        public bool AbrirEnRegistroDirecto = false;   // abre panel directo
        public Frm_ProductoPresentaciones()
        {
            InitializeComponent();
            
        }

        private void Frm_ProductoPresentaciones_Load(object sender, EventArgs e)
        {
            ConfigurarFormulario();
            FormatoControles();
            Configurar_listView();
            CargarPresentaciones();
            CargarAbreviaturas();

            if (AbrirEnRegistroDirecto)
            {
                pnl_add.Visible = true;
                limpiarForm();
                ValoresPorDefecto();

                lsv_prodPresentaciones.Enabled = false;
            }
            else
            {
                pnl_add.Visible = false;
            }
        }

        //======================
        //CONFIGURACIONES
        //======================
        private void ConfigurarFormulario()
        {
            lblNombProducto.Text = NombreProducto;
            lblIdProducto.Text = IdProducto;
            lblTitulo.Text = (Modo == "N") ? "Registrar Presentación" : "Editar Presentación";
        }

        private void FormatoControles()
        {
            txtEquivalencia.TextAlign = HorizontalAlignment.Right;
            txtPrecioCompra.TextAlign = HorizontalAlignment.Right;
            txtPrecioMinorista.TextAlign = HorizontalAlignment.Right;
            txtPrecioMayorista.TextAlign = HorizontalAlignment.Right;
            txtCantMinMayorista.TextAlign = HorizontalAlignment.Right;

            lblEquivalenciaInfo.Text = "";
        }
        private void Configurar_listView()
        {
            lsv_prodPresentaciones.Items.Clear();
            lsv_prodPresentaciones.Columns.Clear();
            lsv_prodPresentaciones.View = View.Details;
            lsv_prodPresentaciones.FullRowSelect = true;
            lsv_prodPresentaciones.GridLines = true;

            lsv_prodPresentaciones.Columns.Add("ID", 60);
            lsv_prodPresentaciones.Columns.Add("Presentacion", 140);           
            lsv_prodPresentaciones.Columns.Add("Equiv.", 80);
            lsv_prodPresentaciones.Columns.Add("Stock Físico", 90);
            lsv_prodPresentaciones.Columns.Add("Stock Base Eq.", 100);
            lsv_prodPresentaciones.Columns.Add("Abrev.", 70);
            lsv_prodPresentaciones.Columns.Add("P. Compra", 90);
            lsv_prodPresentaciones.Columns.Add("P. Minorista", 100);
            lsv_prodPresentaciones.Columns.Add("P. Mayorista", 100);
            lsv_prodPresentaciones.Columns.Add("Min. May", 80);
            lsv_prodPresentaciones.Columns.Add("Base", 60);
            lsv_prodPresentaciones.Columns.Add("Compra", 70);
            lsv_prodPresentaciones.Columns.Add("Venta", 70);
            lsv_prodPresentaciones.Columns.Add("Activo", 70);
           
        }

        private void CargarAbreviaturas()
        {
            cboAbreviatura.Items.Clear();
            cboAbreviatura.Items.Add("UND");
            cboAbreviatura.Items.Add("CJA");
            cboAbreviatura.Items.Add("PCK");
            cboAbreviatura.Items.Add("FDO");
            cboAbreviatura.Items.Add("DOC");
            cboAbreviatura.Items.Add("BLS");
            cboAbreviatura.Items.Add("SAC");
            cboAbreviatura.Items.Add("PQT");

            cboAbreviatura.DropDownStyle = ComboBoxStyle.DropDown;
        }

        // =============================
        // LISTAR
        // =============================

        private void CargarPresentaciones()
        {
            RN_ProductoPresentacion obj = new RN_ProductoPresentacion();
            DataTable dt = obj.RN_Listar_ProductoPresentacion_porProducto(IdProducto);

            lsv_prodPresentaciones.Items.Clear();

            foreach(DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["IdPresentacion"].ToString());
                item.SubItems.Add(dr["NombrePresentacion"].ToString());              
                item.SubItems.Add(Convert.ToDecimal(dr["Equivalencia"]).ToString());
                item.SubItems.Add(Convert.ToDecimal(dr["StockPresentacion"]).ToString("0.####"));
                item.SubItems.Add(Convert.ToDecimal(dr["StockBaseEquivalente"]).ToString("0.####"));
                item.SubItems.Add(dr["Abreviatura"].ToString());
                item.SubItems.Add(Convert.ToDecimal(dr["PrecioCompra"]).ToString());
                item.SubItems.Add(Convert.ToDecimal(dr["PrecioVentaMinorista"]).ToString());
                item.SubItems.Add(Convert.ToDecimal(dr["PrecioVentaMayorista"]).ToString());
                item.SubItems.Add(Convert.ToDecimal(dr["CantMinMayorista"]).ToString());
                item.SubItems.Add(Convert.ToBoolean(dr["EsBase"]) ? "Sí" : "No");
                item.SubItems.Add(Convert.ToBoolean(dr["PermiteCompra"]) ? "Sí" : "No");
                item.SubItems.Add(Convert.ToBoolean(dr["PermiteVenta"]) ? "Sí" : "No");
                item.SubItems.Add(Convert.ToBoolean(dr["Activo"]) ? "Sí" : "No");
                

                lsv_prodPresentaciones.Items.Add(item);

            }
        }


        private void Llenar_Listview(DataTable data)
        {
            lsv_prodPresentaciones.Items.Clear();

            foreach (DataRow dr in data.Rows)
            {
                ListViewItem item = new ListViewItem(dr["IdPresentacion"].ToString());

                item.SubItems.Add(dr["NombrePresentacion"].ToString());
                item.SubItems.Add(dr["Abreviatura"].ToString());
                item.SubItems.Add(Convert.ToDecimal(dr["Equivalencia"]).ToString("0.####"));

                item.SubItems.Add(Convert.ToDecimal(dr["PrecioCompra"]).ToString("0.00"));
                item.SubItems.Add(Convert.ToDecimal(dr["PrecioVentaMinorista"]).ToString("0.00"));
                item.SubItems.Add(Convert.ToDecimal(dr["PrecioVentaMayorista"]).ToString("0.00"));

                item.SubItems.Add(Convert.ToDecimal(dr["CantMinMayorista"]).ToString("0.####"));

                item.SubItems.Add(Convert.ToBoolean(dr["EsBase"]) ? "Sí" : "No");
                item.SubItems.Add(Convert.ToBoolean(dr["PermiteCompra"]) ? "Sí" : "No");
                item.SubItems.Add(Convert.ToBoolean(dr["PermiteVenta"]) ? "Sí" : "No");
                item.SubItems.Add(Convert.ToBoolean(dr["Activo"]) ? "Sí" : "No");

                lsv_prodPresentaciones.Items.Add(item);
            }
        }
        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void lbl_Abrir_Click(object sender, EventArgs e)
        {
           
        }

        private void piclogo_Click(object sender, EventArgs e)
        {
           
        }

        //1-Inicio-metodo para valida las cajas de texto.
        private bool Validar_Textobox()
        {
            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Advertencia ver = new Frm_Advertencia();

            //if (txt_nombreAlmacen.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_msm1.Text = "Ingresa el Nombre del Almacen"; ver.ShowDialog(); fil.Hide(); txt_nombreAlmacen.Focus(); return false; }
            return true; //en caso la condicion no se cumpla.  --Fin
        }

        private void limpiarForm()
        {
            txtNombrePresentacion.Text ="";
            cboAbreviatura.Text = "";
            txtEquivalencia.Text = "1";
            txtPrecioCompra.Text = "0.00";
            txtPrecioMinorista.Text = "0.00";
            txtPrecioMayorista.Text = "0.00";
            txtCantMinMayorista.Text = "0";

            chkEsBase.Checked = false;
            chkPermiteCompra.Checked = true;
            chkPermiteVenta.Checked = true;
            chkActivo.Checked = true;

        }
       
        private void btn_listo_Click(object sender, EventArgs e)
        {

        }
        private void btnAgregar_Ser_Click(object sender, EventArgs e)
        {
        }
        private void btn_reload_Click(object sender, EventArgs e)
        {
           
        }
        private void lbl_busProve_Click(object sender, EventArgs e)
        {
        }
        private void lbl_busMarca_Click(object sender, EventArgs e)
        {
           
        }
        private void lbl_busCat_Click(object sender, EventArgs e)
        {
            
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
        private void chkControlarStock_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (lsv_prodPresentaciones.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecciona una presentación.");
                return;
            }

            pnl_add.Visible = true;

            Modo = "E";
            IdPresentacion = Convert.ToInt32(lsv_prodPresentaciones.SelectedItems[0].Text);

            RN_ProductoPresentacion obj = new RN_ProductoPresentacion();
            DataTable dt = obj.RN_Buscar_ProductoPresentacion_porId(IdPresentacion);

            if (dt.Rows.Count > 0)
            {
                txtNombrePresentacion.Text = dt.Rows[0]["NombrePresentacion"].ToString();
                cboAbreviatura.Text = dt.Rows[0]["Abreviatura"].ToString();
                txtEquivalencia.Text = dt.Rows[0]["Equivalencia"].ToString();
                txtPrecioCompra.Text = dt.Rows[0]["PrecioCompra"].ToString();
                txtPrecioMinorista.Text = dt.Rows[0]["PrecioVentaMinorista"].ToString();
                txtPrecioMayorista.Text = dt.Rows[0]["PrecioVentaMayorista"].ToString();
                txtCantMinMayorista.Text = dt.Rows[0]["CantMinMayorista"].ToString();

                chkEsBase.Checked = Convert.ToBoolean(dt.Rows[0]["EsBase"]);
                chkPermiteCompra.Checked = Convert.ToBoolean(dt.Rows[0]["PermiteCompra"]);
                chkPermiteVenta.Checked = Convert.ToBoolean(dt.Rows[0]["PermiteVenta"]);
                chkActivo.Checked = Convert.ToBoolean(dt.Rows[0]["Activo"]);
            }
            ConfigurarFormulario();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            pnl_add.Visible = true;
            lsv_prodPresentaciones.Enabled = false;

            Modo = "N";
            IdPresentacion = 0;

            limpiarForm();
            ConfigurarFormulario();

        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (lsv_prodPresentaciones.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecciona una presentación.");
                return;
            }

            int idPresentacion = Convert.ToInt32(lsv_prodPresentaciones.SelectedItems[0].Text);

            RN_ProductoPresentacion obj = new RN_ProductoPresentacion();
            obj.RN_Desactivar_ProductoPresentacion(idPresentacion);

            CargarPresentaciones();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            try
            {
                RN_ProductoPresentacion obj = new RN_ProductoPresentacion();
                EN_ProductoPresentacion pre = new EN_ProductoPresentacion();

                pre.IdProducto = IdProducto;
                pre.NombrePresentacion = txtNombrePresentacion.Text.Trim();
                pre.Abreviatura = cboAbreviatura.Text.Trim().ToUpper();
                pre.Equivalencia = Convert.ToDecimal(txtEquivalencia.Text);
                pre.PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                pre.PrecioVentaMinorista = Convert.ToDecimal(txtPrecioMinorista.Text);
                pre.PrecioVentaMayorista = Convert.ToDecimal(txtPrecioMayorista.Text);
                pre.CantMinMayorista = Convert.ToDecimal(txtCantMinMayorista.Text);
                pre.EsBase = chkEsBase.Checked;
                pre.PermiteCompra = chkPermiteCompra.Checked;
                pre.PermiteVenta = chkPermiteVenta.Checked;
                pre.Activo = chkActivo.Checked;

                if (Modo == "N")
                {
                    obj.RN_Registrar_ProductoPresentacion(pre);
                }
                else
                {
                    pre.IdPresentacion = IdPresentacion;
                    obj.RN_Editar_ProductoPresentacion(pre);
                }
                pnl_add.Visible = false;
                lsv_prodPresentaciones.Enabled = true;
                CargarPresentaciones();
                limpiarForm();
               
                Modo = "N";
                IdPresentacion = 0;
                ConfigurarFormulario();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la presentación: " + ex.Message);
            }
        }

     
        // VALIDACIONES      
        private bool ValidarFormulario()
        {
            if (txtNombrePresentacion.Text.Trim().Length < 2)
            {
                MessageBox.Show("Ingrese el nombre de la presentación.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombrePresentacion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboAbreviatura.Text))
            {
                MessageBox.Show("Seleccione o escriba una abreviatura.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboAbreviatura.Focus();
                return false;
            }

            if (!decimal.TryParse(txtEquivalencia.Text, out decimal equivalencia) || equivalencia <= 0)
            {
                MessageBox.Show("Ingrese una equivalencia válida mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEquivalencia.Focus();
                return false;
            }

            if (chkEsBase.Checked && equivalencia != 1)
            {
                MessageBox.Show("La presentación base debe tener equivalencia 1.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEquivalencia.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrecioCompra.Text, out decimal precioCompra) || precioCompra < 0)
            {
                MessageBox.Show("Ingrese un precio de compra válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioCompra.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrecioMinorista.Text, out decimal precioMinorista) || precioMinorista < 0)
            {
                MessageBox.Show("Ingrese un precio minorista válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioMinorista.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrecioMayorista.Text, out decimal precioMayorista) || precioMayorista < 0)
            {
                MessageBox.Show("Ingrese un precio mayorista válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioMayorista.Focus();
                return false;
            }

            if (precioMayorista > precioMinorista && precioMinorista > 0)
            {
                MessageBox.Show("El precio mayorista no puede ser mayor al precio minorista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioMayorista.Focus();
                return false;
            }

            if (!decimal.TryParse(txtCantMinMayorista.Text, out decimal cantMinMayorista) || cantMinMayorista < 0)
            {
                MessageBox.Show("Ingrese una cantidad mínima mayorista válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantMinMayorista.Focus();
                return false;
            }

            if (chkEsBase.Checked && ExisteOtraPresentacionBase())
            {
                MessageBox.Show("Ya existe otra presentación base para este producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ExisteOtraPresentacionBase()
        {
            RN_ProductoPresentacion obj = new RN_ProductoPresentacion();
            DataTable dt = obj.RN_Listar_ProductoPresentacion_porProducto(IdProducto);

            foreach (DataRow dr in dt.Rows)
            {
                int id = Convert.ToInt32(dr["IdPresentacion"]);
                bool esBase = Convert.ToBoolean(dr["EsBase"]);

                if (esBase)
                {
                    if (Modo == "N") return true;
                    if (Modo == "E" && id != IdPresentacion) return true;
                }
            }

            return false;
        }

        private void ValoresPorDefecto()
        {
            if (Modo == "N")
            {
                txtNombrePresentacion.Text = "";

                cboAbreviatura.Text = string.IsNullOrWhiteSpace(Abrev_und) ? "UND" : Abrev_und;

                txtPrecioCompra.Text = "0.00";
                txtPrecioMinorista.Text = "0.00";
                txtPrecioMayorista.Text = "0.00";
                txtCantMinMayorista.Text = "0";

                chkPermiteCompra.Checked = true;
                chkPermiteVenta.Checked = true;
                chkActivo.Checked = true;

                AplicarReglasUnidad();
            }
        }

        private void AplicarReglasUnidad()
        {
            string und = cboAbreviatura.Text;

            if (und == "UND")
            {
                chkEsBase.Checked = true;
                txtEquivalencia.Text = "1";
                txtEquivalencia.Enabled = false;
            }
            else
            {
                chkEsBase.Checked = false;
                txtEquivalencia.Enabled = true;

                if (txtEquivalencia.Text == "1" || txtEquivalencia.Text == "")
                    txtEquivalencia.Text = "";
            }
        }

        private void chkEsBase_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarEstadoEquivalencia();
            ActualizarTextoEquivalencia();
        }

        private void ActualizarEstadoEquivalencia()
        {
            if (chkEsBase.Checked)
            {
                txtEquivalencia.Text = "1";
                txtEquivalencia.Enabled = false;
            }
            else
            {
                txtEquivalencia.Enabled = true;
            }
        }

        private void txtEquivalencia_TextChanged(object sender, EventArgs e)
        {
            ActualizarTextoEquivalencia();
        }

        private void ActualizarTextoEquivalencia()
        {
            if (decimal.TryParse(txtEquivalencia.Text, out decimal equiv))
            {
                if (equiv == 1)
                    lblEquivalenciaInfo.Text = "Equivale a 1 unidad base.";
                else
                    lblEquivalenciaInfo.Text = $"Equivale a {equiv:0.####} unidades base.";
            }
            else
            {
                lblEquivalenciaInfo.Text = "";
            }
        }

        private void SoloNumerosDecimales(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (char.IsControl(e.KeyChar))
                return;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && txt.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
        private void pnl_titu_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btn_cancel_Click_1(object sender, EventArgs e)
        {
            if (pnl_add.Visible)
            {
                pnl_add.Visible = false;
                limpiarForm();

                lsv_prodPresentaciones.Enabled = true;
                return;
            }

            this.Close();
   
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void pnl_add_Click(object sender, EventArgs e)
        {

        }
        private void cboAbreviatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarReglasUnidad();
        }
    }
}
