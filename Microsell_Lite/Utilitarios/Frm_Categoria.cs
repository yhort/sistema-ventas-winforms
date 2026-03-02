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
    public partial class Frm_Categoria : Form
    {
        public Frm_Categoria()
        {
            InitializeComponent();
        }

        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_todas_lascategorias();
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
            var lis = lsv_categoria;

            lsv_categoria.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = true;  //para colocar celdas-
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las colummnas:
            lis.Columns.Add("ID", 40, HorizontalAlignment.Left); //0
            lis.Columns.Add("Nombre de Categoria", 350, HorizontalAlignment.Left); //1
        }

        private void Llenar_Listview(DataTable data)
        {

            lsv_categoria.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Cat"].ToString());
                list.SubItems.Add(dr["Categoria"].ToString());
                lsv_categoria.Items.Add(list); //si no ponemos esto , el listview nunca se llenara
                
            }

        }

        private void Cargar_todas_lascategorias()
        {

            RN_Categoria obj = new RN_Categoria();
            DataTable dato = new DataTable();

            dato = obj.RN_Mostrar_Todas_Categorias();
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);

            }
            else
            {

                lsv_categoria.Items.Clear();

            }
        }


        private void buscar_Categoria(string valor)
        {
            RN_Categoria obj = new RN_Categoria();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_Categoria(valor);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_categoria.Items.Clear();
            }

        }


        public bool editar = false;

        private void btn_add_Click(object sender, EventArgs e)
        {
            pnl_add.Visible = true;
            txt_nomcateg.Focus();
            editar = false;
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            RN_Categoria obj = new RN_Categoria();
            
            if (txt_nomcateg.Text.Trim().Length < 0) { MessageBox.Show("Ingresa el nombre de la Categoria", "Registrar Categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (editar == false)
            {

                //Nuevo:
                obj.RN_Registrar_Categoria(txt_nomcateg.Text);
                pnl_add.Visible = false;
                Cargar_todas_lascategorias();
                txt_nomcateg.Text = "";

            }
            else
            {
                //Editar:
                obj.RN_Editar_Categoria(Convert.ToInt32(txt_idcateg.Text), txt_nomcateg.Text);
                pnl_add.Visible = false;
                Cargar_todas_lascategorias();
                txt_nomcateg.Text = "";
                editar = false;


            }

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (lsv_categoria.SelectedIndices.Count == 0)
            {

                MessageBox.Show("Selecciona el Item para Editar", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {

                var lsv = lsv_categoria.SelectedItems[0];
                txt_idcateg.Text = lsv.SubItems[0].Text;
                txt_nomcateg.Text = lsv.SubItems[1].Text;

                pnl_add.Visible = true;
                txt_nomcateg.Focus();
                editar = true;

            }
        }

        private void btn_Selecc_Click(object sender, EventArgs e)
        {
            if (lsv_categoria.SelectedIndices.Count == 0)
            {

                MessageBox.Show("Selecciona una Categoria", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {

                var lsv = lsv_categoria.SelectedItems[0];
                txt_idcateg.Text = lsv.SubItems[0].Text;
                txt_nomcateg.Text = lsv.SubItems[1].Text;

                this.Tag = "A";
                //this.Close();

            }
        }

        private void lsv_categoria_KeyDown(object sender, KeyEventArgs e)
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

        private void lsv_categoria_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsv_categoria.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar una Categoria", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                txt_idcateg.Text = lsv_categoria.SelectedItems[0].SubItems[0].Text;
                txt_nomcateg.Text = lsv_categoria.SelectedItems[0].SubItems[1].Text;

                this.Tag = "A";
                this.Close();

            }
        }

        private void txt_buscar_OnValueChanged(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                buscar_Categoria(txt_buscar.Text);
            }
        }


        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    buscar_Categoria(txt_buscar.Text);
                }
                else
                {
                    Cargar_todas_lascategorias();
                }
            }
        }//fin
    }
}
