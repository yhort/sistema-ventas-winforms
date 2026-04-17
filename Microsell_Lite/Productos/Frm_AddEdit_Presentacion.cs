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
        public int IdPresentacion = 0;
        public string Modo = "N"; //N=nuevo, E=editar
        public Frm_AddEdit_Presentacion()
        {
            InitializeComponent();
            
        }

        private void Frm_AddEdit_Presentacion_Load(object sender, EventArgs e)
        {
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
           
            CargarPresentaciones();
        }
        private void CargarPresentaciones()
        {
            //RN_ProductoPresentacion obj = new RN_ProductoPresentacion();
            //DataTable dt = obj.RN_Listar_ProductoPresentacion_porProducto(IdProducto);

            //lsv_prodPresentaciones.Items.Clear();

            //foreach(DataRow dr in dt.Rows)
            //{
            //    ListViewItem item = new ListViewItem(dr["IdPresentacion"].ToString());
            //    item.SubItems.Add(dr["NombrePresentacion"].ToString());
            //    item.SubItems.Add(dr["Abreviatura"].ToString());
            //    item.SubItems.Add(Convert.ToDecimal(dr["Equivalencia"]).ToString());
            //    item.SubItems.Add(Convert.ToDecimal(dr["PrecioCompra"]).ToString());
            //    item.SubItems.Add(Convert.ToDecimal(dr["PrecioVentaMinorista"]).ToString());
            //    item.SubItems.Add(Convert.ToDecimal(dr["PrecioVentaMayorista"]).ToString());
            //    item.SubItems.Add(Convert.ToBoolean(dr["EsBase"]) ? "Sí" : "No");
            //    item.SubItems.Add(Convert.ToBoolean(dr["PermiteCompra"]) ? "Sí" : "No");
            //    item.SubItems.Add(Convert.ToBoolean(dr["PermiteVenta"]) ? "Sí" : "No");
            //    item.SubItems.Add(Convert.ToBoolean(dr["Activo"]) ? "Sí" : "No");

            //    lsv_prodPresentaciones.Items.Add(item);

            //}
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
            RN_ProductoPresentacion obj = new RN_ProductoPresentacion();
            EN_ProductoPresentacion pre = new EN_ProductoPresentacion();

            try
            {
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
    }
}
