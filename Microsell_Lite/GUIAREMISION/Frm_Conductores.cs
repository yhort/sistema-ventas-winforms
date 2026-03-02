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
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using Microsell_Lite.Utilitarios;

namespace Microsell_Lite.GUIAREMISION
{
    public partial class Frm_Conductores : Form
    {
        public Frm_Conductores()
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
            lis.Columns.Add("Nombres", 200, HorizontalAlignment.Left); //1
            lis.Columns.Add("Apellidos", 150, HorizontalAlignment.Left); //1
            lis.Columns.Add("Dni", 90, HorizontalAlignment.Left); //2
            lis.Columns.Add("Lincencia", 100, HorizontalAlignment.Left); //2
            lis.Columns.Add("Telefono", 90, HorizontalAlignment.Left); //2

        }
        private void Llenar_Listview(DataTable data)
        {
            lsv_marca.Items.Clear();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Cond"].ToString());
                list.SubItems.Add(dr["co_nombres"].ToString());
                list.SubItems.Add(dr["co_apellidos"].ToString());
                list.SubItems.Add(dr["co_dni"].ToString());
                list.SubItems.Add(dr["co_licencia"].ToString());
                list.SubItems.Add(dr["co_telef"].ToString());
                lsv_marca.Items.Add(list); //si no ponemos esto , el listview nunca se llenara
            }
        }
        private void Cargar_todas_lasMarcas()
        {
            RN_Conductor obj = new RN_Conductor();
            DataTable dato = new DataTable();
            dato = obj.RN_Mostrar_Conductores();
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_marca.Items.Clear();
            }
        }
        private void buscar_Marca(string valor, string estado)
        {
            RN_Conductor obj = new RN_Conductor();
            DataTable dato = new DataTable();
            dato = obj.RN_BuscarConductor(valor, "Activo");
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
            txt_nombreCond.Focus();
            editar = false;
        }
        private void btn_listo_Click(object sender, EventArgs e)
        {

            if(Validar_cajasText() == true)
            {
                if(editar == false)
                {

                    Registrar_Conductor();
                   
                }
                else
                {
                    Editar_Conductor();
                    editar = false;
                }
               
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
                txt_idvehiculo.Text = lsv.SubItems[0].Text;
                txt_nombreCond.Text = lsv.SubItems[1].Text;
                txt_apellidos.Text = lsv.SubItems[2].Text;  
                txtDni.Text = lsv.SubItems[3].Text;
                txtLicencia.Text = lsv.SubItems[4].Text;
                txtTelefono.Text = lsv.SubItems[5].Text;

                pnl_add.Visible = true;
                txt_nombreCond.Focus();
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
                txt_idvehiculo.Text = lsv.SubItems[0].Text;
                Frm_Sino sino = new Frm_Sino();
                sino.Lbl_msm1.Text = "¿Estas Seguro de eliminar ?";
                sino.ShowDialog();
                if (sino.Tag.ToString() == "Si")
                {
                    RN_Conductor obj = new RN_Conductor();
                    obj.RN_Eliminar_Conductor(Convert.ToInt32(txt_idvehiculo.Text));
                    Cargar_todas_lasMarcas();
                }
            }
        }
        private void btn_Selecc_Click(object sender, EventArgs e)
        {
            if (lsv_marca.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Selecciona un Conductor", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                var lsv = lsv_marca.SelectedItems[0];
                txt_idvehiculo.Text = lsv.SubItems[0].Text;
                txt_nombreCond.Text = lsv.SubItems[1].Text;
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
            pnl_add.Visible = false;
            Limpiarform();
            //this.Close();
        }
        private void bt_delete_Click_1(object sender, EventArgs e)
        {

        }
        private void lsv_marca_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsv_marca.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar un COnductor", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                txt_idvehiculo.Text = lsv_marca.SelectedItems[0].SubItems[0].Text;
                txt_nombreCond.Text = lsv_marca.SelectedItems[0].SubItems[1].Text;
                txt_apellidos.Text = lsv_marca.SelectedItems[0].SubItems[2].Text;
                txtDni.Text = lsv_marca.SelectedItems[0].SubItems[3].Text;
                txtLicencia.Text = lsv_marca.SelectedItems[0].SubItems[4].Text;
                this.Tag = "A";
                this.Close();
            }
        }
        private void txt_buscar_OnValueChanged(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                buscar_Marca(txt_buscar.Text,"Activo");
            }
        }

        //funcion tecla enter
        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
           
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    buscar_Marca(txt_buscar.Text, "Activo");
                }
                else
                {
                    Cargar_todas_lasMarcas();
                }
            
        }//fin
        private void txtLicencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite letras y números, y la tecla de retroceso para borrar
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si el carácter no es una letra, ni un número, ni una tecla de control,
                // cancela el evento para que el carácter no aparezca en el TextBox.
                e.Handled = true;
            }
            // Verifica que la longitud no supere los 8 caracteres
            if (txtLicencia.Text.Length >= 9 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;  // Evita que se agregue más de 8 caracteres
            }
        }
        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite letras y números, y la tecla de retroceso para borrar
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si el carácter no es una letra, ni un número, ni una tecla de control,
                // cancela el evento para que el carácter no aparezca en el TextBox.
                e.Handled = true;
            }
            // Verifica que la longitud no supere los 8 caracteres
            if (txtDni.Text.Length >= 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;  // Evita que se agregue más de 8 caracteres
            }
        }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite números, y la tecla de retroceso para borrar
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si el carácter no es un número, ni una tecla de control,(como retroceso)
                // cancela el evento para que el carácter no aparezca en el TextBox.
                e.Handled = true;
            }
            if (txtTelefono.Text.Length >= 9 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;  // Evita que se agregue más de 8 caracteres
            }
        }
        private bool Validar_cajasText()
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            //if (txt_id.Text.Trim().Length == 0) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa id"; ver.ShowDialog(); fil.Hide(); return false; }
            if (txt_nombreCond.Text =="") { fil.Show(); ver.Lbl_msm1.Text = "Ingresa el Nombre del Conductor"; ver.ShowDialog(); fil.Hide(); txt_nombreCond.Focus(); return false; }
            if (txt_apellidos.Text =="") { fil.Show(); ver.Lbl_msm1.Text = "Ingresa el Apellido"; ver.ShowDialog(); fil.Hide(); txt_apellidos.Focus(); return false; }
            if (txtDni.Text == "") { fil.Show(); ver.Lbl_msm1.Text = "Ingresa el DNI"; ver.ShowDialog(); fil.Hide(); txtDni.Focus(); return false; }
            if (txtLicencia.Text == "" ) { fil.Show(); ver.Lbl_msm1.Text = "Ingresa la licencia del Conductor"; ver.ShowDialog(); fil.Hide(); txtLicencia.Focus(); return false; }

            return true;

        }
        private void Limpiarform()
        {
            txt_nombreCond.Text = "";
            txt_apellidos.Text = "";
            txtDni.Text = "";
            txtLicencia.Text = "";
            txtTelefono.Text = "";
           
        }
        private void Registrar_Conductor()
        {

            RN_Conductor obj = new RN_Conductor();
            EN_Choferes cond = new EN_Choferes();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

            try
            {
                //use.IdUser = Convert.ToInt32(txt_id.Text);
                cond.Co_nombres = txt_nombreCond.Text;                
                cond.Dni = txtDni.Text;
                cond.Licencia = txtLicencia.Text;
                cond.IdDis = 1;
                cond.Direccion = "-";
                cond.Telef = txtTelefono.Text;
                cond.Fechacrea = dtp_fecha.Value;
                cond.Fechamod = dtp_fecha.Value;
                cond.Estado = "Activo";
                cond.Apellido = txt_apellidos.Text;
             

                obj.RN_Registrar_Conductor(cond);

                if (BD_Conductor.saved == true)
                {
                    fil.Show();
                    ok.Lbl_msm1.Text = "El Conductor se ha Registrado Exitosamente";
                    ok.ShowDialog();
                    fil.Hide();
                    pnl_add.Visible = false;
                    Cargar_todas_lasMarcas();
                    Limpiarform();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Leer los Datos: " + ex.Message, "Form Add Conductor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        bool editeMode = false;
        private void Editar_Conductor()
        {
            RN_Conductor obj = new RN_Conductor();   
            EN_Choferes cond = new EN_Choferes();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

            try
            {
                cond.IdCond = Convert.ToInt32(txt_idvehiculo.Text);
                cond.Co_nombres = txt_nombreCond.Text;
                cond.Apellido = txt_apellidos.Text;
                cond.Dni = txtDni.Text;
                cond.Licencia = txtLicencia.Text;
                cond.Telef = txtTelefono.Text;
                //cond.Direccion = "-";
                cond.Fechamod = dtp_fecha.Value;
                //cond.Estado = "Activo";

                obj.RN_Editar_Conductor(cond);

                if (BD_Conductor.edited == true)
                {
                    fil.Show();
                    ok.Lbl_msm1.Text = "El Conductor se ha Actualizado Exitosamente";
                    ok.ShowDialog();
                    fil.Hide();

                    Limpiarform();
                    pnl_add.Visible = false;
                    Cargar_todas_lasMarcas();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Leer los Datos: " + ex.Message, "Form Add Conductor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
