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

namespace Microsell_Lite.Proveedor
{
    public partial class Frm_Expl_Proveedor : Form
    {
        public Frm_Expl_Proveedor()
        {
            InitializeComponent();
        }

        private void Frm_Explo_Prod_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_Todos_Proveedores();
        }

        // Configurando el ListView
        private void Configurar_listView()
        {

            var lis = lsv_provee;

            lsv_provee.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("ID", 60, HorizontalAlignment.Left); //0
            lis.Columns.Add("Nro Ruc", 110, HorizontalAlignment.Left); //1
            lis.Columns.Add("Nombre", 400, HorizontalAlignment.Left); //2
            lis.Columns.Add("Nro Celular", 100, HorizontalAlignment.Left); //3
            lis.Columns.Add("Rubro", 150, HorizontalAlignment.Left); //4
            lis.Columns.Add("Direccion", 300, HorizontalAlignment.Left);//5


        }


        //llenar el listview:

        private void Llenar_Listview(DataTable data)
        {
            lsv_provee.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["IDPROVEE"].ToString());
                list.SubItems.Add(dr["RUC"].ToString());
                list.SubItems.Add(dr["NOMBRE"].ToString());
                list.SubItems.Add(dr["TELEFONO"].ToString());
                list.SubItems.Add(dr["RUBRO"].ToString());
                list.SubItems.Add(dr["DIRECCION"].ToString());
                lsv_provee.Items.Add(list); //si no ponemos esto, el listview  nunca se llenara

            }

        }

        private void Cargar_Todos_Proveedores()
        {
            RN_Proveedor obj = new RN_Proveedor();
            DataTable dato = new DataTable();

            dato = obj.RN_Mostrar_Todos_Proveedores();
            if(dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_provee.Items.Clear();
            }

        }

        private void buscar_Proveedores(string valor)
        {
            RN_Proveedor obj = new RN_Proveedor();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_Proveedores(valor);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_provee.Items.Clear();
            }

        }


        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button ==MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        
        //metodo final. que ejecuta cargar y buscar proveedor previamente declarados, en boton.
        private void txt_buscar_OnValueChanged(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                buscar_Proveedores(txt_buscar.Text);
            }
        }

       //funcion tecla enter
        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    buscar_Proveedores(txt_buscar.Text);
                }
                else
                {
                    Cargar_Todos_Proveedores();
                }
            }
        }//fin

        private void bt_copiarIDProveedorTool_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro(); //para copiar 
            Frm_Advertencia ver = new Frm_Advertencia();

            if (lsv_provee.SelectedIndices.Count == 0) //para copiar 
            {
                fil.Show();
                ver.Lbl_msm1.Text = "Selecciona el Item que desees copiar";
                ver.ShowDialog();
                fil.Hide();

            }
            else
            {

                var lis = lsv_provee.SelectedItems[0];
                string idprovee = lis.SubItems[0].Text; //colocar valor de la colummna a copiar

                Clipboard.Clear();
                Clipboard.SetText(idprovee.Trim());


            }
        }

        private void bt_nuevoProveedorTool_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_AddProveedor ad = new Frm_AddProveedor();

            fil.Show();
            ad.ShowDialog();
            fil.Hide();

            if (ad.Tag.ToString() == "A")
            {
                Cargar_Todos_Proveedores();

            }
        }

        private void bt_edit_Click(object sender, EventArgs e) //para capturar dato de id para editar  //frmeditar. ES LLAMADDO DESDE FRM.EDITAR
        {
            Frm_Filtro fil = new Frm_Filtro(); //para copiar 
            Frm_Advertencia ver = new Frm_Advertencia();
            frm_Editar_Proveedor edi = new frm_Editar_Proveedor();

            if (lsv_provee.SelectedIndices.Count == 0) //para copiar 
            {
                fil.Show();
                ver.Lbl_msm1.Text = "Selecciona el Item que desees Editar";
                ver.ShowDialog();
                fil.Hide();

            }
            else
            {

                var lis = lsv_provee.SelectedItems[0];
                string idprovee = lis.SubItems[0].Text; //colocar valor de la colummna a copiar

                fil.Show();
                edi.Tag = idprovee;
                edi.ShowDialog();
                fil.Hide();

                if (edi.Tag.ToString()=="A")
                {
                    Cargar_Todos_Proveedores();
                }
                
            }
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_AddProveedor ad = new Frm_AddProveedor();

            fil.Show();
            ad.ShowDialog();
            fil.Hide();

            if (ad.Tag.ToString() == "A")
            {
                Cargar_Todos_Proveedores();

            }

        }

        private void editarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
