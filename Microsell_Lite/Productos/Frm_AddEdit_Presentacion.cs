using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsell_Lite.Utilitarios;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using Microsell_Lite.Proveedor;
using Prj_Capa_Datos;
using DocumentFormat.OpenXml.Bibliography;
using System.Runtime.ConstrainedExecution;

namespace Microsell_Lite.Productos
{
    public partial class Frm_AddEdit_Presentacion : Form
    {
        public string IdProducto = "";
        public string NombreProducto = "";
        public int IdPresentacion = 0;
        public string Modo = "N"; //N=nuevo, E=editar
        public Frm_AddEdit_Presentacion()
        {
            InitializeComponent();
            
        }

        private void Frm_AddEdit_Presentacion_Load(object sender, EventArgs e)
        {

            CargarAbreviaturas();
            ConfigurarFormulario();
            FormatoControles();
            ValoresPorDefecto();

            if (Modo == "E")
            {
                RN_ProductoPresentacion obj = new RN_ProductoPresentacion();
                DataTable dt = obj.RN_Buscar_ProductoPresentacion_porId(IdPresentacion);

                if (dt.Rows.Count > 0)
                {
                    txtNombrePresentacion.Text = dt.Rows[0]["NombrePresentacion"].ToString();
                    txtAbreviatura.Text = dt.Rows[0]["Abreviatura"].ToString();
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
            }
        }

        private void Frm_ProductoPresentaciones_Load(object sender, EventArgs e)
        {
           
            CargarDatosPresentaciones();
        }
        private void CargarDatosPresentaciones()
        {
            RN_ProductoPresentacion obj = new RN_ProductoPresentacion();
            DataTable dt = obj.RN_Buscar_ProductoPresentacion_porId(IdPresentacion);

            if (dt.Rows.Count > 0)
            {
                txtNombrePresentacion.Text = dt.Rows[0]["NombrePresentacion"].ToString();
                cboAbreviatura.Text = dt.Rows[0]["Abreviatura"].ToString();
                txtEquivalencia.Text = Convert.ToDecimal(dt.Rows[0]["Equivalencia"]).ToString("0.####");
                txtPrecioCompra.Text = Convert.ToDecimal(dt.Rows[0]["PrecioCompra"]).ToString("0.00");
                txtPrecioMinorista.Text = Convert.ToDecimal(dt.Rows[0]["PrecioVentaMinorista"]).ToString("0.00");
                txtPrecioMayorista.Text = Convert.ToDecimal(dt.Rows[0]["PrecioVentaMayorista"]).ToString("0.00");
                txtCantMinMayorista.Text = Convert.ToDecimal(dt.Rows[0]["CantMinMayorista"]).ToString("0.####");

                chkEsBase.Checked = Convert.ToBoolean(dt.Rows[0]["EsBase"]);
                chkPermiteCompra.Checked = Convert.ToBoolean(dt.Rows[0]["PermiteCompra"]);
                chkPermiteVenta.Checked = Convert.ToBoolean(dt.Rows[0]["PermiteVenta"]);
                chkActivo.Checked = Convert.ToBoolean(dt.Rows[0]["Activo"]);

                ActualizarEstadoEquivalencia();
                ActualizarTextoEquivalencia();
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

        string xFotoruta ="";

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

            //txt_idproducto.Text = "";
            //txt_nombreProduct.Text = "";
            //txt_categoria.Text = "";
            //txt_Frank.Text = "0";
            //txt_Provedr.Text = "";
            //xFotoruta = "";
            //txt_peso.Text = "0";
            //txt_Precom_Sol.Text = "";
            //txt_PreVenta_mnr.Text = "";


        }
        public bool editar = false;
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
            //if (lsv_prodPresentaciones.SelectedIndices.Count == 0)
            //{

            //    MessageBox.Show("Selecciona el Item para Editar", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            //else
            //{

            //    var lsv = lsv_prodPresentaciones.SelectedItems[0];
            //    txt_idAlmacen.Text = lsv.SubItems[0].Text;
            //    txtNombrePresentacion.Text = lsv.SubItems[1].Text;
            //    txtAbreviatura.Text = lsv.SubItems[2].Text;


            //    pnl_add.Visible = true;
            //    txtNombrePresentacion.Focus();
            //    editar = true;

            //}
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            pnl_add.Visible = true;
            txtNombrePresentacion.Focus();
            editar = false;
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
                pre.Abreviatura = txtAbreviatura.Text.Trim();
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

                this.Tag = "A";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la presentación: " + ex.Message);
            }
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

        private void ConfigurarFormulario()
        {
            lblProducto.Text = NombreProducto;
            lblIdProducto.Text = IdProducto;

            if (Modo == "N")
                lblTitulo.Text = "Registrar Presentación";
            else
                lblTitulo.Text = "Editar Presentación";
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

        private void ValoresPorDefecto()
        {
            if (Modo == "N")
            {
                txtNombrePresentacion.Text = "";
                cboAbreviatura.Text = "UND";
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
        }

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
                    if (Modo == "N")
                        return true;

                    if (Modo == "E" && id != IdPresentacion)
                        return true;
                }
            }

            return false;
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
    }
}
