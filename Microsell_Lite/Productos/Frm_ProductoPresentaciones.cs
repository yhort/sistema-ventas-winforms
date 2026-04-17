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
    public partial class Frm_ProductoPresentaciones : Form
    {
        public string IdProducto = "";
        public string NombreProducto = "";
        public Frm_ProductoPresentaciones()
        {
            InitializeComponent();
            
        }

        private void Frm_ProductoPresentaciones_Load(object sender, EventArgs e)
        {
            lblIdProducto.Text = IdProducto;
            lblProducto.Text = NombreProducto;
            Configurar_listView();
            CargarPresentaciones();
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
            lsv_prodPresentaciones.Columns.Add("Abrev.", 70);
            lsv_prodPresentaciones.Columns.Add("Equiv.", 80);
            lsv_prodPresentaciones.Columns.Add("P. Compra.", 90);
            lsv_prodPresentaciones.Columns.Add("P.Minorista", 100);
            lsv_prodPresentaciones.Columns.Add("P. Mayorista", 100);
            lsv_prodPresentaciones.Columns.Add("Min. May", 80);
            lsv_prodPresentaciones.Columns.Add("Base", 60);
            lsv_prodPresentaciones.Columns.Add("Compra", 70);
            lsv_prodPresentaciones.Columns.Add("Venta", 70);
            lsv_prodPresentaciones.Columns.Add("Activo", 70);
        }

        private void CargarPresentaciones()
        {
            RN_ProductoPresentacion obj = new RN_ProductoPresentacion();
            DataTable dt = obj.RN_Listar_ProductoPresentacion_porProducto(IdProducto);

            lsv_prodPresentaciones.Items.Clear();

            foreach(DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["IdPresentacion"].ToString());
                item.SubItems.Add(dr["NombrePresentacion"].ToString());
                item.SubItems.Add(dr["Abreviatura"].ToString());
                item.SubItems.Add(Convert.ToDecimal(dr["Equivalencia"]).ToString());
                item.SubItems.Add(Convert.ToDecimal(dr["PrecioCompra"]).ToString());
                item.SubItems.Add(Convert.ToDecimal(dr["PrecioVentaMinorista"]).ToString());
                item.SubItems.Add(Convert.ToDecimal(dr["PrecioVentaMayorista"]).ToString());
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

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Almacen"].ToString());
                list.SubItems.Add(dr["Nombre"].ToString());
                list.SubItems.Add(dr["Direccion"].ToString());
                list.SubItems.Add(dr["Estado"].ToString());
                lsv_prodPresentaciones.Items.Add(list); //si no ponemos esto , el listview nunca se llenara

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
            if (lsv_prodPresentaciones.SelectedIndices.Count == 0)
            {

                MessageBox.Show("Selecciona el Item para Editar", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {

                var lsv = lsv_prodPresentaciones.SelectedItems[0];
                txt_idAlmacen.Text = lsv.SubItems[0].Text;
                txt_nombreAlmacen.Text = lsv.SubItems[1].Text;
                txt_direccionAlmacen.Text = lsv.SubItems[2].Text;


                pnl_add.Visible = true;
                txt_nombreAlmacen.Focus();
                editar = true;

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            pnl_add.Visible = true;
            txt_nombreAlmacen.Focus();
            editar = false;
        }

       
    }
}
