using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prj_Capa_Datos;
using Prj_Capa_Negocio;

namespace Microsell_Lite.Utilitarios
{
    public partial class Frm_Marca : Form
    {
        public Frm_Marca()
        {
            InitializeComponent();
        }

        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_todas_lasMarcas();
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

        private void Configurar_listView()
        {
            var lis = lsv_marca;

            lsv_marca.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las colummnas:
            lis.Columns.Add("ID", 40, HorizontalAlignment.Left); //0
            lis.Columns.Add("Nombre de Marca", 350, HorizontalAlignment.Left); //1
        }

        private void Llenar_Listview(DataTable data)
        {

            lsv_marca.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Marca"].ToString());
                list.SubItems.Add(dr["Marca"].ToString());
                lsv_marca.Items.Add(list); //si no ponemos esto , el listview nunca se llenara
                
            }

        }

        private void Cargar_todas_lasMarcas()
        {

            RN_Marca obj = new RN_Marca();
            DataTable dato = new DataTable();

            dato = obj.RN_Mostrar_Todas_Marcas();
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);

            }
            else
            {

                lsv_marca.Items.Clear();

            }
        }

        private void buscar_Marca(string valor)
        {
            RN_Marca obj = new RN_Marca();
            DataTable dato = new DataTable();

            dato = obj.BD_Buscar_Marca(valor);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_marca.Items.Clear();
            }

        }


        public bool editar = false;

        private void btn_add_Click(object sender, EventArgs e)
        {
            pnl_add.Visible = true;
            txt_nommarca.Focus();
            editar = false;
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            RN_Marca obj = new RN_Marca();
            
            if (txt_nommarca.Text.Trim().Length < 0) { MessageBox.Show("Ingresa el nombre de la Categoria", "Registrar Categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (editar == false)
            {
                //Nuevo:
                obj.RN_Registrar_Marcas(txt_nommarca.Text);
                pnl_add.Visible = false;
                Cargar_todas_lasMarcas();
                txt_nommarca.Text = "";
            }
            else
            {
                //Editar:
                obj.RN_Editar_Marcas(Convert.ToInt32(txt_idmarca.Text), txt_nommarca.Text);
                pnl_add.Visible = false;
                Cargar_todas_lasMarcas();
                txt_nommarca.Text = "";
                editar = false;
            }

        }


       
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (lsv_marca.SelectedIndices.Count == 0)
            {

                MessageBox.Show("Selecciona el Item para Editar", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {

                var lsv = lsv_marca.SelectedItems[0];
                txt_idmarca.Text = lsv.SubItems[0].Text;
                txt_nommarca.Text = lsv.SubItems[1].Text;

                pnl_add.Visible = true;
                txt_nommarca.Focus();
                editar = true;

            }
        }

        //metodo para eliminar las marcas, cuando no esta asiganado a un producto

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (lsv_marca.SelectedIndices.Count == 0)
            {

                MessageBox.Show("Selecciona el Item para Eliminar", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {

                var lsv = lsv_marca.SelectedItems[0];
                txt_idmarca.Text = lsv.SubItems[0].Text;

                Frm_Sino sino = new Frm_Sino();

                sino.Lbl_msm1.Text = "¿Estas Seguro de eliminar la Marca?";
                sino.ShowDialog();

                if (sino.Tag.ToString() == "Si")
                {
                    RN_Marca obj = new RN_Marca();
                    obj.RN_Eliminar_Marcas(Convert.ToInt32(txt_idmarca.Text));
                    Cargar_todas_lasMarcas();
                }

            }

        }

        private void btn_Selecc_Click(object sender, EventArgs e)
        {
            if (lsv_marca.SelectedIndices.Count == 0)
            {

                MessageBox.Show("Selecciona una Marca", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {

                var lsv = lsv_marca.SelectedItems[0];
                txt_idmarca.Text = lsv.SubItems[0].Text;
                txt_nommarca.Text = lsv.SubItems[1].Text;

                this.Tag = "A";
                //this.Close();
            }
        }

        private void lsv_marca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Selecc_Click(sender, e);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void bt_delete_Click_1(object sender, EventArgs e)
        {

        }

        private void lsv_marca_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsv_marca.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar un Proveedor", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                txt_idmarca.Text = lsv_marca.SelectedItems[0].SubItems[0].Text;
                txt_nommarca.Text = lsv_marca.SelectedItems[0].SubItems[1].Text;

                this.Tag = "A";
                this.Close();

            }
        }

        private void txt_buscar_OnValueChanged(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                buscar_Marca(txt_buscar.Text);
            }
        }

        //funcion tecla enter
        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    buscar_Marca(txt_buscar.Text);
                }
                else
                {
                    Cargar_todas_lasMarcas();
                }
            }
        }//fin
    }
}
