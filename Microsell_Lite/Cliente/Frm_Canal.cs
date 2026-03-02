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
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;

namespace Microsell_Lite.Cliente
{
    public partial class Frm_Canal : Form
    {
        public Frm_Canal()
        {
            InitializeComponent();
        }

        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_todas_lasMarcas();
            CargarClientesCbo();
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);
            }
        }
        public string estado = "Activo";
        private void CargarClientesCbo()
        {
            RN_Cliente obj = new RN_Cliente();
            DataTable data = new DataTable();

            data = obj.RN_Cargar_Todos_Cliente(estado);
            if (data.Rows.Count > 0)
            {
                //Llenar_ListView(data);
                var cbo = cboCliente;
                cbo.DataSource = data;
                cbo.DisplayMember = "Razon_Social_Nombres"; //
                cbo.ValueMember = "Id_Cliente";
                cbo.SelectedIndex = -1;

            }
            else
            {
                //lsv_direc.Items.Clear();
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
            lis.Columns.Add("Nombre de Canal", 350, HorizontalAlignment.Left); //1
            lis.Columns.Add("Cliente asignado canal", 350, HorizontalAlignment.Left); //1
        }

        private void Llenar_Listview(DataTable data)
        {

            lsv_marca.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Canal"].ToString());
                list.SubItems.Add(dr["Nombre_Canal"].ToString());
                list.SubItems.Add(dr["Razon_Social_Nombres"].ToString());
                lsv_marca.Items.Add(list); //si no ponemos esto , el listview nunca se llenara
                
            }

        }

        private void Cargar_todas_lasMarcas()
        {

            RN_Canal obj = new RN_Canal();
            DataTable dato = new DataTable();

            dato = obj.RN_Mostrar_Canales();
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
            RN_Canal obj = new RN_Canal();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_Canal(valor);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_marca.Items.Clear();
            }

        }
        private bool Validar_cajasText()
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();


            if (txt_nommarca.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa Descripcion Canal"; ver.ShowDialog(); fil.Hide(); txt_nommarca.Focus(); return false; }     
            if (cboCliente.SelectedIndex == -1) { fil.Show(); ver.Lbl_Msm1.Text = "Elige Empresa relacionada para Canal"; ver.ShowDialog(); fil.Hide(); cboCliente.Focus(); return false; }
        

            return true;

        }

        public bool editar = false;

        private void btn_add_Click(object sender, EventArgs e)
        {
            pnl_add.Visible = true;
            txt_nommarca.Focus();
            editar = false;
        }

        //bool editeMode = false;
        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (Validar_cajasText() == true)
            {
                if (editar == true)
                {
                    Editar_Canal();
                }
                else
                {
                    Registrar_Canal();
                }
            }

        }

        private void Registrar_Canal()
        {
            RN_Canal obj = new RN_Canal();
            EN_Canal cl = new EN_Canal();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

            try
            {
                cl.NombreCanal = txt_nommarca.Text;
                cl.ClienteId = cboCliente.SelectedValue.ToString();
                cl.Estado = "Activo";

                obj.RN_Registrar_Canal(cl);

                if(BD_Canal.saved == true)
                {
                    fil.Show();
                    ok.Lbl_msm1.Text = "El Canal se ha Registrado Exitosamente";
                    ok.ShowDialog();
                    fil.Hide();

                    Limpiarform();
                    pnl_add.Visible = false;
                }

            }
            catch (Exception ex )
            {

                throw;
            }

        }

        private void Editar_Canal()
        {

            RN_Canal obj = new RN_Canal();
            EN_Canal cln = new EN_Canal();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

            try
            {
                cln.IdCanal = Convert.ToInt32(txt_idmarca.Text);
                cln.NombreCanal = txt_nommarca.Text;
                cln.ClienteId = cboCliente.SelectedValue.ToString();
                cln.Estado = "Activo";
                

                obj.RN_Editar_Canal(cln);

                if (BD_Canal.edited == true)
                {
                    fil.Show();
                    ok.Lbl_msm1.Text = "El Canal se ha Actualizado Exitosamente";
                    ok.ShowDialog();
                    fil.Hide();

                    Limpiarform();
                    pnl_add.Visible = false;
                    Cargar_todas_lasMarcas();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Leer los Datos: " + ex.Message, "Form Add Canal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Limpiarform()
        {
            txt_nommarca.Text = "";
            cboCliente.SelectedIndex = -1;
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
                MessageBox.Show("Seleccionar un Canal", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
