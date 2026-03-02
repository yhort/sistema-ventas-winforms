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
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Productos;

namespace Microsell_Lite.Cliente
{
    public partial class Frm_Explor_Cliente : Form
    {
        public Frm_Explor_Cliente()
        {
            InitializeComponent();
           
        }

        private void Frm_Explor_Proveedor_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_Todos_Clientes();
        }

        //configurar nuestro listview

        private void Configurar_listView()
        {

            var lis = lsv_cli;

            lsv_cli.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("ID", 80, HorizontalAlignment.Left); //0
            lis.Columns.Add("Nombre del Cliente", 400, HorizontalAlignment.Left); //2
            lis.Columns.Add("dni", 110, HorizontalAlignment.Left); //3
            lis.Columns.Add("Direccion", 280, HorizontalAlignment.Left); //4
            lis.Columns.Add("telefono", 90, HorizontalAlignment.Left);//5
            lis.Columns.Add("Limite Cred.", 80, HorizontalAlignment.Left);//5
            lis.Columns.Add("Estado", 80, HorizontalAlignment.Left);//5
    

        }

        //llenar el listview:

        private void Llenar_Listview(DataTable data)
        {
            lsv_cli.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Cliente"].ToString());
                list.SubItems.Add(dr["Razon_Social_Nombres"].ToString());
                list.SubItems.Add(dr["DNI"].ToString());
                list.SubItems.Add(dr["Direccion"].ToString());
                list.SubItems.Add(dr["Telefono"].ToString());
                list.SubItems.Add(dr["Limit_Credit"].ToString());
                list.SubItems.Add(dr["Estado_Cli"].ToString());
              
              
                lsv_cli.Items.Add(list); //si no ponemos esto,. el listview  nunca se llenara
            }
            Pintar_Filas();
            pnl_msm.Visible = false;
            lbl_totalItem.Text = lsv_cli.Items.Count.ToString();
        }

        private void Pintar_Filas()
        {
            int cont = 1;

            for (int i=0; i < lsv_cli.Items.Count; i++)
            {
                if (cont % 2 == 0)
                {

                }
                else
                {
                    lsv_cli.Items[i].BackColor = Color.WhiteSmoke;
                }
                cont += 1;
            }
        }

        private void Cargar_Todos_Clientes()
        {
            RN_Cliente obj = new RN_Cliente();
            DataTable dato = new DataTable();

            dato = obj.RN_Cargar_Todos_Cliente("Activo");
            if (dato.Rows.Count >0)
            {
                Llenar_Listview(dato);

            }
            else
            {
                lsv_cli.Items.Clear();
                pnl_msm.Visible = true;
            }

        }

        private void buscar_Cliente(string valor)
        {
            RN_Cliente obj = new RN_Cliente();
            DataTable dato = new DataTable();

            dato = obj.RN_buscar_Cliente(valor, "Activo");
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_cli.Items.Clear();
                pnl_msm.Visible = true;
            }

        }

        private void txt_buscar_OnValueChanged(object sender, EventArgs e)
        {
            //if (txt_buscar.Text.Trim().Length > 2)
            //{
            //    buscar_Cliente(txt_buscar.Text);
            //}

        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        { 
            if(e.KeyCode == Keys.Enter)
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    buscar_Cliente(txt_buscar.Text);
                }
                else
                {
                    Cargar_Todos_Clientes();
                }
            }

        }

        private void txt_buscar_OnValueChanged_1(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                buscar_Cliente(txt_buscar.Text);

            }

        }

        private void elLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bt_copiarIDProveedorTool_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (lsv_cli.SelectedIndices .Count == 0)
            {
                fil.Show();
                ver.Lbl_msm1.Text = "Selecciona el Item que desees copiar";
                ver.ShowDialog();
                fil.Hide();

            }
            else
            {

                var lis = lsv_cli.SelectedItems[0];
                string idprovee = lis.SubItems[0].Text;

                Clipboard.Clear();
                Clipboard.SetText(idprovee.Trim());


            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = ""; 
            this.Close();
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Add_Cliente ad = new Frm_Add_Cliente();
            

            fil.Show();
            ad.ShowDialog();
            fil.Hide();

            if (ad.Tag.ToString() =="A")
            {
                Cargar_Todos_Clientes();

            }
        }

        private void toolStripSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void bt_nuevoProveedorTool_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Add_Cliente ad = new Frm_Add_Cliente();

            fil.Show();
            ad.ShowDialog();
            fil.Hide();

            if (ad.Tag.ToString() == "A")
            {
                Cargar_Todos_Clientes();

            }

        }

        private void bt_edit_Click(object sender, EventArgs e)
        {

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();
            Frm_Edit_Cliente edi = new Frm_Edit_Cliente();

            if (lsv_cli.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.Lbl_Msm1.Text = "Selecciona el Item que desees Editar";
                ver.ShowDialog();
                fil.Hide();

            }
            else
            {

                var lis = lsv_cli.SelectedItems[0];
                string idclie = lis.SubItems[0].Text;

                fil.Show();
                edi.Tag = idclie;
                edi.ShowDialog();
                fil.Hide();

                if (edi.Tag.ToString() == "A")
                {
                    Cargar_Todos_Clientes();
                }


            }


        }

        private void editarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bt_edit_Click(sender, e);
        }

        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Todos_Clientes();
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if(e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);
            }
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
