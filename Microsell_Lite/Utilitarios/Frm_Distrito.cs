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
    public partial class Frm_Distrito : Form
    {
        public Frm_Distrito()
        {
            InitializeComponent();
        }

        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_todos_Distrito();
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
            this.Close();
        }

        private void Configurar_listView()
        {
            var lis = lsv_distrito;

            lsv_distrito.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las colummnas:
            lis.Columns.Add("ID", 40, HorizontalAlignment.Left); //0
            lis.Columns.Add("Nombre de Distrito", 350, HorizontalAlignment.Left); //1
        }

        private void Llenar_Listview(DataTable data)
        {

            lsv_distrito.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Dis"].ToString());
                list.SubItems.Add(dr["Distrito"].ToString());
                //list.SubItems.Add(dr["Marca"].ToString());
                lsv_distrito.Items.Add(list); //si no ponemos esto , el listview nunca se llenara
                
            }

        }

        private void buscar_Dsitrito(string valor)
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
                lsv_distrito.Items.Clear();
            }

        }

        private void Cargar_todos_Distrito()
        {

            RN_Distrito obj = new RN_Distrito();
            DataTable dato = new DataTable();

            dato = obj.RN_Mostrar_Todos_Distritos();
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);

            }
            else
            {

                lsv_distrito.Items.Clear();

            }
        }

        public bool editar = false;

        private void btn_add_Click(object sender, EventArgs e)
        {
            pnl_add.Visible = true;
            txt_nomdist.Focus();
            editar = false;
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            RN_Distrito obj = new RN_Distrito();
            
            if (txt_nomdist.Text.Trim().Length < 0) { MessageBox.Show("Ingresa el nombre deL Distrito", "Registrar Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (editar == false)
            {

                //Nuevo:
                obj.RN_Registrar_Distrito(txt_nomdist.Text);
                pnl_add.Visible = false;
                Cargar_todos_Distrito();
                txt_nomdist.Text = "";

            }
            else
            {
                //Editar:
                obj.RN_Editar_Distritos(Convert.ToInt32(txt_iddist.Text), txt_nomdist.Text);
                pnl_add.Visible = false;
                Cargar_todos_Distrito();
                txt_nomdist.Text = "";
                editar = false;


            }

        }


       
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (lsv_distrito.SelectedIndices.Count == 0)
            {

                MessageBox.Show("Selecciona el Item para Editar", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {

                var lsv = lsv_distrito.SelectedItems[0];
                txt_iddist.Text = lsv.SubItems[0].Text;
                txt_nomdist.Text = lsv.SubItems[1].Text;

                pnl_add.Visible = true;
                txt_nomdist.Focus();
                editar = true;

            }
        }

        //metodo para eliminar las marcas, cuando no esta asiganado a un producto

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (lsv_distrito.SelectedIndices.Count == 0)
            {

                MessageBox.Show("Selecciona el Item para Eliminar", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {

                var lsv = lsv_distrito.SelectedItems[0];
                txt_iddist.Text = lsv.SubItems[0].Text;

                Frm_Sino sino = new Frm_Sino();

                sino.Lbl_msm1.Text = "¿Estas Seguro de eliminar el Distrito?";
                sino.ShowDialog();

                if (sino.Tag.ToString() == "Si")
                {
                    RN_Distrito obj = new RN_Distrito();
                    obj.RN_Eliminar_Distrito(Convert.ToInt32(txt_iddist.Text));
                    Cargar_todos_Distrito();
                }

            }

        }

        private void btn_Selecc_Click(object sender, EventArgs e)
        {
            if (lsv_distrito.SelectedIndices.Count == 0)
            {

                MessageBox.Show("Selecciona una Categoria", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {

                var lsv = lsv_distrito.SelectedItems[0];
                txt_iddist.Text = lsv.SubItems[0].Text;
                txt_nomdist.Text = lsv.SubItems[1].Text;

                this.Tag = "A";
                this.Close();

            }
        }

        private void lsv_distrito_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsv_distrito.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar un Proveedor", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                txt_iddist.Text = lsv_distrito.SelectedItems[0].SubItems[0].Text;
                txt_nomdist.Text = lsv_distrito.SelectedItems[0].SubItems[1].Text;

                this.Tag = "A";
                this.Close();

            }
        }

        private void lsv_distrito_KeyDown(object sender, KeyEventArgs e)
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

        private void txt_buscar_OnValueChanged(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                buscar_Dsitrito(txt_buscar.Text);
            }
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    buscar_Dsitrito(txt_buscar.Text);
                }
                else
                {
                    Cargar_todos_Distrito();
                }
            }
        }
    }
}
