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
using System.IO;

namespace Microsell_Lite.GUIAREMISION
{
    public partial class Frm_RegTransportista : Form
    {
        public Frm_RegTransportista()
        {
            InitializeComponent();
        }

        private void Frm_RegUsuario_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            //cargar_roles();
            //cargar_distritos();
            //cargar_conductores();
            //cargar_vehiculos();
            Cargar_Todos_losTransportista();
            txt_id.Text = RN_TipoDoc.RN_NroID(17);
            //LoadDepartamentos();
        }


        private void Configurar_listView()
        {

            var lis = lsv_usu;

            lsv_usu.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;

            //configuracion de colummnas
            lis.Columns.Add("ID Transp.", 90, HorizontalAlignment.Left);
            lis.Columns.Add("Razon Social ", 250, HorizontalAlignment.Left);
            lis.Columns.Add("RUC ", 90, HorizontalAlignment.Left);
            lis.Columns.Add("N° MTC ", 80, HorizontalAlignment.Left);
            lis.Columns.Add("Direccion", 150, HorizontalAlignment.Left);
            lis.Columns.Add("Telefono", 80, HorizontalAlignment.Left);
            lis.Columns.Add("Email", 80, HorizontalAlignment.Left);

        }

        private void Llenar_ListView(DataTable data)
        {
            lsv_usu.Items.Clear();

            for(int i= 0; i<data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Transportista"].ToString());
                list.SubItems.Add(dr["Razon_Social"].ToString());
                list.SubItems.Add(dr["RUC"].ToString());
                list.SubItems.Add(dr["Nro_Licencia_Transporte"].ToString());
                list.SubItems.Add(dr["Direccion"].ToString());
                list.SubItems.Add(dr["Telefono"].ToString());
                list.SubItems.Add(dr["E_Mail"].ToString());

                lsv_usu.Items.Add(list);
            }
        }

        private void cargar_vehiculos()
        {
            RN_Vehiculo obj = new RN_Vehiculo();
            DataTable data = new DataTable();

            data = obj.RN_Mostrar_Todos_Vehiculo();

            if (data.Rows.Count > 0)
            {
                var cbo = cbo_vehiculo;
                cbo.DataSource = data;
                cbo.ValueMember = "Id_vehiculo";
                cbo.DisplayMember = "veh_placa";
                cbo_vehiculo.SelectedIndex = -1;


            }

        }

        private void cargar_conductores()
        {
            RN_Conductor obj = new RN_Conductor();
            DataTable data = new DataTable();

            data = obj.RN_Mostrar_Conductores();

            if (data.Rows.Count > 0)
            {
                var cbo = cbo_Conductor;
                cbo.DataSource = data;
                cbo.ValueMember = "Id_Cond";
                cbo.DisplayMember = "co_nombres";
                cbo_Conductor.SelectedIndex = -1;


            }

        }

        private void Leer_Dato_Empresa()
        {
            RN_Empresa obj = new RN_Empresa();
            DataTable data = new DataTable();

            try
            {
                data = obj.RN_Buscar_Empresa_porId(Convert.ToInt32(Cls_Libreria.Idempresa)); //CONVERT.TOIN32(CLS.IDEMPRESA) Y DEMAS METODOS
                if (data.Rows.Count > 0)
                {
                    Lbl_EmpresaEmisor.Text = Convert.ToString(data.Rows[0]["nombreEmpresa"]);
                    Lbl_RucEmisor.Text = Convert.ToString(data.Rows[0]["nroRuc"]);
                    Lbl_DireccionEmpresa.Text = Convert.ToString(data.Rows[0]["DireccionEmpresa"]);
                    Lbl_UsuarioSol.Text = Convert.ToString(data.Rows[0]["usuariosol"]);
                    Lbl_ClaveSol.Text = Convert.ToString(data.Rows[0]["clavesol"]);
                    Lbl_CorreoEmi.Text = Convert.ToString(data.Rows[0]["correo"]);
                    Lbl_ClaveCorreo.Text = Convert.ToString(data.Rows[0]["clavecorreo"]);
                    Lbl_ClaveCertificado.Text = Convert.ToString(data.Rows[0]["clavecertificado"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer los Datos: " + ex.Message, "Form Add Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public int idempresa = Cls_Libreria.Idempresa;

        private void Cargar_Todos_losTransportista()
        {
            RN_Transportista obj = new RN_Transportista();
            DataTable data = new DataTable();

            data = obj.RN_Mostrar_Transportista();
            if(data.Rows.Count > 0)
            {
                Llenar_ListView(data);
            }
            else
            {
                lsv_usu.Items.Clear();
            }

        }

        private void Buscar_Datos_usuario(int usu, int idempresa)
        {
        }

        private bool Validar_cajasText()
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();

            
            //if (txt_id.Text.Trim().Length == 0) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa id"; ver.ShowDialog(); fil.Hide(); return false; }
            if (txt_nombre.Text.Trim().Length <2) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa la razon social transportista"; ver.ShowDialog(); fil.Hide(); txt_ruc.Focus();  return false; }
            if (txt_ruc.Text.Trim().Length < 8) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el ruc"; ver.ShowDialog(); fil.Hide(); txt_ruc.Focus(); return false; }
            if (txt_mtc.Text.Trim().Length < 4) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el n° mtc"; ver.ShowDialog(); fil.Hide(); txt_ruc.Focus(); return false; }

            return true;

        }

        string xfotoruta = "-";
        private void Registrar_Transportista()
        {
            RN_Transportista obj = new RN_Transportista();
            EN_Transportista tr = new EN_Transportista();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

            try
            {
                tr.IdTransportista = txt_id.Text;
                tr.RazonSocialNombres = txt_nombre.Text;
                tr.Ruc = txt_ruc.Text;               
                tr.Direccion = txtDireccion.Text;
                tr.Telefono = txt_telefono.Text;
                tr.Email = txt_correo.Text;
                tr.NroLicTransporte = txt_mtc.Text; 

                obj.RN_Insertar_Transportista(tr);

                if(BD_Transportista.saved == true)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo_Producto(17);

                    fil.Show();
                    ok.Lbl_msm1.Text = "Los datos se haN Registrado Exitosamente";
                    ok.ShowDialog();
                    fil.Hide();

                    Limpiarform();
                    pnl_nuevo.Visible = false;

                }
            }
            catch (Exception ex )
            {

                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Transportista", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        private void Editar_Transportista()
        {

            RN_Transportista obj = new RN_Transportista();
            EN_Transportista tr = new EN_Transportista();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
           // string xxidprod = "";

            try
            {

                tr.IdTransportista = txt_id.Text;
                tr.RazonSocialNombres = txt_nombre.Text;
                tr.Ruc = txt_ruc.Text;
                tr.Direccion = txtDireccion.Text;
                tr.Telefono = txt_telefono.Text;
                tr.Email = txt_correo.Text;
                tr.NroLicTransporte = txt_mtc.Text;

                obj.RN_Editar_Transportista(tr);

                if (BD_Transportista.seedito == true)
                {
                    fil.Show();
                    ok.Lbl_msm1.Text = "Se Actualizo Exitosamente";
                    ok.ShowDialog();
                    fil.Hide();

                    Limpiarform();
                    pnl_nuevo.Visible = false;
                    Cargar_Todos_losTransportista();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Leer los Datos: " + ex.Message, "Form Add Transportista", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        bool editeMode = false;
        private void btn_listo_Click(object sender, EventArgs e)
        {
            if(Validar_cajasText() == true)
            {
                if(editeMode == true)
                {
                    Editar_Transportista();
                }
                else
                {
                    Registrar_Transportista();
                }
            }
        }

        private void Limpiarform()
        {
            txt_ruc.Text = "";
            txt_nombre.Text = "";
            txt_mtc.Text = "";
            txt_id.Text = "";
            txt_correo.Text = "";
            //cbo_Conductor.SelectedIndex = -1;
            //cbo_vehiculo.SelectedIndex = -1;
            //cboDepartamento.SelectedIndex = -1;
            //cboProvincia.SelectedIndex = -1;
            //cboDistrito.SelectedIndex = -1;
            //txtUbigeo.Text = "";
            txt_telefono.Text = "";
            //txtContacto.Text = "";
        }

       

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            pnl_nuevo.Visible = false;
            Limpiarform();
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
          
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button ==MouseButtons.Left)
            {
                Utilitario usu = new Utilitario();
                usu.Mover_formulario(this);
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            pnl_nuevo.Visible = true;
            ////int idusp = lsv_usu.Items.Count;
            //string idtrn = lsv_usu.Items;
            //txt_id.Text = idusp.ToString();

            txt_id.Text = RN_TipoDoc.RN_NroID(17);

        }

        private void lsv_usu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsv_usu.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar un Empresa Transportista", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                txt_id.Text = lsv_usu.SelectedItems[0].SubItems[0].Text;
                txt_nombre.Text = lsv_usu.SelectedItems[0].SubItems[1].Text;
                txt_ruc.Text = lsv_usu.SelectedItems[0].SubItems[2].Text;
                txt_mtc.Text = lsv_usu.SelectedItems[0].SubItems[3].Text;
                //txt_placaSecund.Text = lsv_marca.SelectedItems[0].SubItems[4].Text;
                //txt_marcaVehiculo.Text = lsv_marca.SelectedItems[0].SubItems[8].Text;
                /*
                  ListViewItem list = new ListViewItem(dr["Id_Transportista"].ToString());
                list.SubItems.Add(dr["Razon_Social"].ToString());
                list.SubItems.Add(dr["RUC"].ToString());
                list.SubItems.Add(dr["Nro_Licencia_Transporte"].ToString());
                list.SubItems.Add(dr["Direccion"].ToString());
                list.SubItems.Add(dr["Telefono"].ToString());
                list.SubItems.Add(dr["E_Mail"].ToString());*/

                this.Tag = "A";
                this.Close();

            }

            //int idusu = 0;

            ////int xidempresa = 0;
            //string xxidprod = "";

            //var lis = lsv_usu.SelectedItems[0];
            //xxidprod = Convert.ToString(lis.SubItems[0].Text);
            ////xidempresa = Convert.ToInt32(lis.SubItems[6].Text);
            //txt_id.Text = xxidprod;

            //Buscar_Datos_usuario(idusu, idempresa);

        }

        private void piclogo_Click(object sender, EventArgs e)
        {
            var FilePath = string.Empty;

            try
            {
                if(openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    xfotoruta = openFileDialog1.FileName;
                    piclogo.Load(xfotoruta);
                }
            }
            catch (Exception  ex)
            {

                piclogo.Load(Application.StartupPath + @"\user01.png");
                xfotoruta = Application.StartupPath + @"\user01.png";
                MessageBox.Show("Error al Guardar el Personal" + ex.Message);
            }
        }

        private void btn_quitar_Click(object sender, EventArgs e)
        {
            //int idusu = 0;

            //var lis = lsv_usu.SelectedItems[0];
            //idusu = Convert.ToInt32(lis.SubItems[0].Text);


            //Frm_Sino sino = new Frm_Sino();

            //sino.Lbl_msm1.Text = "¿Estas Seguro de eliminar el Usuario?";
            //sino.ShowDialog();

            //if (sino.Tag.ToString() == "Si")
            //{
            //    RN_Usuario obj = new RN_Usuario();
            //    obj.RN_Eliminar_Usuario(idusu);
            //    Cargar_Todos_losTransportista();
            //}

        }

        private void LoadDepartamentos()
        {
            //RN_Ubigeo obj = new RN_Ubigeo();
            BD_Ubigeo obj = new BD_Ubigeo();
            DataTable dato = new DataTable();


            dato = obj.BD_Listar_Ubigeos();

            var departamentos = dato.DefaultView.ToTable(true, "Departamento");
            cboDepartamento.DisplayMember = "Departamento";
            cboDepartamento.ValueMember = "Departamento";
            cboDepartamento.DataSource = departamentos;
        }

        private void cbo_Departamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProvincias(cboDepartamento.SelectedValue.ToString());
        }

        private void LoadProvincias(string departamento)
        {
            //RN_Ubigeo obj = new RN_Ubigeo();
            BD_Ubigeo obj = new BD_Ubigeo();
            DataTable dato = new DataTable();
            dato = obj.BD_Listar_Ubigeos();
            var provincias = dato.Select($"Departamento = '{departamento}'").CopyToDataTable().DefaultView.ToTable(true, "Provincia");
            cboProvincia.DisplayMember = "Provincia";
            cboProvincia.ValueMember = "Provincia";
            cboProvincia.DataSource = provincias;
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDistritos(cboDepartamento.SelectedValue.ToString(), cboProvincia.SelectedValue.ToString());
        }

        private void LoadDistritos(string departamento, string provincia)
        {
            //RN_Ubigeo obj = new RN_Ubigeo();
            BD_Ubigeo obj = new BD_Ubigeo();
            DataTable dato = new DataTable();
            dato = obj.BD_Listar_Ubigeos();

            var distritos = dato.Select($"Departamento = '{departamento}' AND Provincia = '{provincia}'").CopyToDataTable();
            cboDistrito.DisplayMember = "Distrito";
            cboDistrito.ValueMember = "Ubigeo";
            cboDistrito.DataSource = distritos;
        }

        private void cboDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDistrito.SelectedValue != null)
            {
                txtUbigeo.Text = cboDistrito.SelectedValue.ToString();
            }
        }

        private void pnl_nuevo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
