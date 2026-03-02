using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prj_Capa_Negocio;

namespace Microsell_Lite.Proveedor
{
    public partial class Frm_ListadoProveedor : Form
    {
        public Frm_ListadoProveedor()
        {
            InitializeComponent();
        }

        private void Frm_ListadoProveedor_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_Todos_proveedores();
        }

        private void Configurar_listView()
        {

            var lis = lsv_prove;

            lsv_prove.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //Configurar las colummnas:
            lis.Columns.Add("ID", 0, HorizontalAlignment.Left); //0
            lis.Columns.Add("Nombre de Proveedor", 450, HorizontalAlignment.Left); //1
            lis.Columns.Add("RUC", 100, HorizontalAlignment.Left); //2

        }


        private void Llenar_ListView(DataTable data)
        {

            lsv_prove.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["IDPROVEE"].ToString());
                list.SubItems.Add(dr["NOMBRE"].ToString());
                list.SubItems.Add(dr["RUC"].ToString());
                lsv_prove.Items.Add(list); //si no podemos esto, el listview nunca s llenara

            }

        }

        private void Cargar_Todos_proveedores()
        {
            RN_Proveedor obj = new RN_Proveedor();
            DataTable dato = new DataTable();

            dato = obj.RN_Mostrar_Todos_Proveedores();
            if (dato.Rows.Count > 0)
            {
                Llenar_ListView(dato);
            }
            else
            {

            }
        }


        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void lsv_prove_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsv_prove.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar un Proveedor", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                lbl_id.Text = lsv_prove.SelectedItems[0].SubItems[0].Text;
                lbl_nom.Text = lsv_prove.SelectedItems[0].SubItems[1].Text;
                lbl_rucProv.Text = lsv_prove.SelectedItems[0].SubItems[2].Text;

                this.Tag = "A";
                this.Close();

            }
        }

        private void lsv_prove_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lsv_prove.SelectedIndices.Count == 0)
                {
                    MessageBox.Show("Selecciona un Proveedor", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


            }

            else
            {
                lbl_id.Text = lsv_prove.SelectedItems[0].SubItems[0].Text;
                lbl_nom.Text = lsv_prove.SelectedItems[0].SubItems[1].Text;
                lbl_rucProv.Text = lsv_prove.SelectedItems[0].SubItems[2].Text;

                this.Tag = "A";
                this.Close();
            }
        }
    }
}
