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

namespace Microsell_Lite.Usuarios
{
    public partial class Frm_RegUsuario : Form
    {
        public Frm_RegUsuario()
        {
            InitializeComponent();
        }

        private void Frm_RegUsuario_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            cargar_roles();
            cargar_distritos();
            Cargar_Todos_losUsuarios();
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
            lis.Columns.Add("ID", 40, HorizontalAlignment.Left);
            lis.Columns.Add("Nombres ", 250, HorizontalAlignment.Left);
            lis.Columns.Add("Apellido ", 250, HorizontalAlignment.Left);
            lis.Columns.Add("Distrito ", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Usu Login", 120, HorizontalAlignment.Left);
            lis.Columns.Add("Clave", 100, HorizontalAlignment.Left);
            lis.Columns.Add("Rol", 120, HorizontalAlignment.Left);
            lis.Columns.Add("Empresa", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Estado", 100, HorizontalAlignment.Left);

        }

        private void Llenar_ListView(DataTable data)
        {

            lsv_usu.Items.Clear();

            for(int i= 0; i<data.Rows.Count; i++)
            {

                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Usu"].ToString());
                list.SubItems.Add(dr["Nombres"].ToString());
                list.SubItems.Add(dr["Apellidos"].ToString());
                list.SubItems.Add(dr["Id_Dis"].ToString());
                list.SubItems.Add(dr["Usuario"].ToString());
                list.SubItems.Add(dr["Contraseña"].ToString());
                list.SubItems.Add(dr["Id_Rol"].ToString());
                list.SubItems.Add(dr["idempresa"].ToString());
                list.SubItems.Add(dr["Estado_Usu"].ToString());

                lsv_usu.Items.Add(list);
            }
        }

        private void cargar_roles()
        {
            RN_Usuario obj = new RN_Usuario();
            DataTable data = new DataTable();

            data = obj.RN_Mostrar_Roles();

            if(data.Rows.Count> 0)
            {
                var cbo = cbo_rol;
                cbo.DataSource = data;
                cbo.ValueMember = "Id_Rol";
                cbo.DisplayMember = "Rol";
                cbo_rol.SelectedIndex = -1;
            }

        }

        private void cargar_distritos()
        {

            RN_Distrito obj = new RN_Distrito();
            DataTable data = new DataTable();
            data = obj.RN_Mostrar_Todos_Distritos();

            if (data.Rows.Count > 0)
            {
                var cbo = cbo_Distrito;
                cbo.DataSource = data;
                cbo.ValueMember = "Id_Dis";
                cbo.DisplayMember = "Distrito";
                cbo_Distrito.SelectedIndex = -1;

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

        private void Cargar_Todos_losUsuarios()
        {
            RN_Usuario obj = new RN_Usuario();
            DataTable data = new DataTable();

            data = obj.RN_Listar_Todos_Usuarios(idempresa);
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
            RN_Usuario obj = new RN_Usuario();
            DataTable data = new DataTable();

            try
            {
                data = obj.RN_Buscar_Usuario_xIds(usu,idempresa);

                if (data.Rows.Count == 0) return;

                txt_id.Text = Convert.ToString(data.Rows[0]["Id_Usu"]);
                txt_nombre.Text = Convert.ToString(data.Rows[0]["Nombres"]);
                txt_apellido.Text = Convert.ToString(data.Rows[0]["Apellidos"]);
                cbo_Distrito.SelectedValue = Convert.ToInt32(data.Rows[0]["Id_Dis"]);
                txt_usu.Text = Convert.ToString(data.Rows[0]["Usuario"]);
                txt_pass.Text = Convert.ToString(data.Rows[0]["Contraseña"]);
                cbo_rol.SelectedValue = Convert.ToInt32(data.Rows[0]["Id_Rol"]);
                txt_correo.Text = Convert.ToString(data.Rows[0]["Correo"]);
                dtp_fecha.Value = Convert.ToDateTime(data.Rows[0]["Fecha_Ncmiento"]);
                //lbl_idempresa.Text = Convert.ToString(data.Rows[0]["idempresa"]);

                xfotoruta = Convert.ToString(data.Rows[0]["Ubicacion_Foto"]);
                if(File.Exists(xfotoruta) == false)
                {
                    piclogo.Load(Application.StartupPath + @"\user01.png");
                }
                else
                {
                    piclogo.Load(xfotoruta);
                }

                pnl_nuevo.Visible = true;
                editeMode = true;
                lbl_nom.Text = "Editar Datos de Usuario";
                txt_nombre.Focus();

            }
            catch (Exception ex )
            {

                MessageBox.Show("Error al Leer los Datos: " + ex.Message, "Form Add user", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool Validar_cajasText()
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (txt_id.Text.Trim().Length == 0) { fil.Show(); ver.Lbl_msm1.Text = "Ingresa id"; ver.ShowDialog(); fil.Hide(); return false; }
            if (txt_nombre.Text.Trim().Length <2) { fil.Show(); ver.Lbl_msm1.Text = "Ingresa Tu Nombre"; ver.ShowDialog(); fil.Hide(); txt_usu.Focus();  return false; }
            if (txt_apellido.Text.Trim().Length < 8) { fil.Show(); ver.Lbl_msm1.Text = "Ingresa Tu Apellido"; ver.ShowDialog(); fil.Hide(); txt_usu.Focus(); return false; }
            if (txt_usu.Text.Trim().Length < 4) { fil.Show(); ver.Lbl_msm1.Text = "Ingresa Tu Usuario Login"; ver.ShowDialog(); fil.Hide(); txt_usu.Focus(); return false; }
            if (txt_pass.Text.Trim().Length < 4) { fil.Show(); ver.Lbl_msm1.Text = "Ingresa Tu Clave Login"; ver.ShowDialog(); fil.Hide(); txt_usu.Focus(); return false; }
            if (cbo_rol.SelectedIndex == -1) { fil.Show(); ver.Lbl_msm1.Text = "Elige un Rol"; ver.ShowDialog(); fil.Hide(); cbo_rol.Focus(); return false; }
            if (cbo_Distrito.SelectedIndex == -1) { fil.Show(); ver.Lbl_msm1.Text = "Elige el Distrito"; ver.ShowDialog(); fil.Hide(); cbo_Distrito.Focus(); return false; }
            
            return true;

        }

        string xfotoruta = "-";
        private void Registrar_Usuario()
        {

            RN_Usuario obj = new RN_Usuario();
            EN_Usuario use = new EN_Usuario();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

            try
            {
                //use.IdUser = Convert.ToInt32(txt_id.Text);
                use.Nombres = txt_nombre.Text;
                use.Apellidos = txt_apellido.Text;
                use.IdDis = Convert.ToInt32(cbo_Distrito.SelectedValue);
                use.Usuario = txt_usu.Text;
                use.Password = txt_pass.Text;
                use.Foto = xfotoruta;
                use.FechaNac = dtp_fecha.Value;
                use.IdRol = Convert.ToInt32(cbo_rol.SelectedValue);
                use.Correo = txt_correo.Text;
                use.IdEmpresa = idempresa;
                use.Estado = "Activo";

                obj.RN_insertar_Usuario(use);

                if(BD_Usuario.saved == true)
                {
                    fil.Show();
                    ok.Lbl_msm1.Text = "El Usuario se ha Registrado Exitosamente";
                    ok.ShowDialog();
                    fil.Hide();

                    Limpiarform();
                    pnl_nuevo.Visible = false;

                }
            }
            catch (Exception ex )
            {
                throw;
            }
        }
        private void Editar_Usuario()
        {

            RN_Usuario obj = new RN_Usuario();
            EN_Usuario use = new EN_Usuario();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

            try
            {
                use.IdUser = Convert.ToInt32(txt_id.Text);
                use.Nombres = txt_nombre.Text;
                use.Apellidos = txt_apellido.Text;
                use.IdDis = Convert.ToInt32(cbo_Distrito.SelectedValue);
                use.Usuario = txt_usu.Text;
                use.Password = txt_pass.Text;
                use.Foto = xfotoruta;
                use.FechaNac = dtp_fecha.Value;
                use.IdRol = Convert.ToInt32(cbo_rol.SelectedValue);
                use.Correo = txt_correo.Text;
                use.IdEmpresa = idempresa;
                use.Estado = "Activo";

                obj.RN_Editar_Usuario(use);

                if (BD_Usuario.edited == true)
                {
                    fil.Show();
                    ok.Lbl_msm1.Text = "El Usuario se ha Actualizado Exitosamente";
                    ok.ShowDialog();
                    fil.Hide();

                    Limpiarform();
                    pnl_nuevo.Visible = false;
                    Cargar_Todos_losUsuarios();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Leer los Datos: " + ex.Message, "Form Add user", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        bool editeMode = false;
        private void btn_listo_Click(object sender, EventArgs e)
        {
            if(Validar_cajasText() == true)
            {
                if(editeMode == true)
                {
                    Editar_Usuario();
                }
                else
                {
                    Registrar_Usuario();
                }
            }
        }

        private void Limpiarform()
        {
            txt_apellido.Text = "";
            txt_nombre.Text = "";
            txt_pass.Text = "";
            txt_usu.Text = "";
            txt_id.Text = "";
            txt_correo.Text = "";
            cbo_Distrito.SelectedIndex = -1;
            cbo_rol.SelectedIndex = -1;
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
            int idusp = lsv_usu.Items.Count;
            txt_id.Text = idusp.ToString();
        }

        private void lsv_usu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int idusu = 0;

            //int xidempresa = 0;


            var lis = lsv_usu.SelectedItems[0];
            idusu = Convert.ToInt32(lis.SubItems[0].Text);
            //xidempresa = Convert.ToInt32(lis.SubItems[6].Text);

            Buscar_Datos_usuario(idusu, idempresa);

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
            int idusu = 0;

            var lis = lsv_usu.SelectedItems[0];
            idusu = Convert.ToInt32(lis.SubItems[0].Text);


            Frm_Sino sino = new Frm_Sino();

            sino.Lbl_msm1.Text = "¿Estas Seguro de eliminar el Usuario?";
            sino.ShowDialog();

            if (sino.Tag.ToString() == "Si")
            {
                RN_Usuario obj = new RN_Usuario();
                obj.RN_Eliminar_Usuario(idusu);
                Cargar_Todos_losUsuarios();
            }

        }
    }
}
