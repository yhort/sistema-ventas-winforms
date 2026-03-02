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
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Net.Http;


namespace Microsell_Lite.Utilitarios
{
    public partial class Frm_AddUser : Form
    {
        public Frm_AddUser()
        {
            InitializeComponent();
        }

        private void Frm_AddUser_Load(object sender, EventArgs e)
        {
            Cargar_Roles();
            Cargar_distritos();
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

        private void Cargar_Roles()
        {
            RN_Usuario obj = new RN_Usuario();
            DataTable dato = new DataTable();

            try
            {
                dato = obj.RN_Mostrar_Roles();
                if (dato.Rows.Count > 0)
                {
                    cbo_rol.DataSource = dato;
                    cbo_rol.ValueMember = "Id_Rol";
                    cbo_rol.DisplayMember = "Rol";

                    //cbo_departamento.SelectedIndex = -1;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cargar_distritos()
        {
            RN_Distrito obj = new RN_Distrito();
            DataTable dato = new DataTable();

            try
            {
                dato = obj.RN_Mostrar_Todos_Distritos();
                if (dato.Rows.Count > 0)
                {
                    cbo_dis.DataSource = dato;
                    cbo_dis.ValueMember = "Id_Dis";
                    cbo_dis.DisplayMember = "Distrito";

                    cbo_dis.SelectedIndex = -1;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void cbo_departamento_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }


        private void Cargar_ProvinciaporDepartamentoId(int CodigoDepartamento)
        {
          
        }
        private void Cargar_Distrito_ProvinciaId(int CodigoProvincia)
        {
           
        }

        private void cbo_provincia_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        string xFotoruta;

        private void lbl_Abrir_Click(object sender, EventArgs e)
        {
            var FilePath = string.Empty;

            try
            {
                if(openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    xFotoruta = openFileDialog1.FileName;
                    piclogo.Load(xFotoruta);
                }
            }
            catch (Exception ex)
            {
                piclogo.Load(Application.StartupPath + @"\user115.png");
                xFotoruta = Application.StartupPath + @"\user115.png";
                MessageBox.Show("Error al Guardar imagen usuario" + ex.Message);
                
            }
        }

        //1-Inicio-metodo para valida las cajas de texto.
        private bool Validar_Textobox() 
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();

            if (txt_nombreProve.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el Nombre"; ver.ShowDialog(); fil.Hide(); return false; }
            if (txtApellido.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el Apellido"; ver.ShowDialog(); fil.Hide(); txt_nombreProve.Focus(); return false; }
            if (txtUser.Text.Trim().Length < 8) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el nombre de usuario"; ver.ShowDialog(); fil.Hide(); txtUser.Focus(); return false; }
            if (txtPass.Text.Trim().Length < 8) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa la contraseña"; ver.ShowDialog(); fil.Hide(); txtPass.Focus(); return false; }

            return true; //en caso la condicion no se cumpla.  --Fin
        }

        public bool editar = false;



        //2-Inicio ---Metodo para registrar datos del proveedor
        private void Registrar_Proveedor()
        {
            RN_Usuario obj = new RN_Usuario();
            EN_Usuario us = new EN_Usuario();

            //if (txt_modelo.Text.Trim().Length < 0) { MessageBox.Show("Ingresa el nombre de la Categoria", "Registrar Categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (editar == false)
            {

                //Nuevo:
                //obj.RN_Registrar_Marcas(txt_modelo.Text);
                us.Nombres = txt_nombreProve.Text;
                us.Apellidos = txtApellido.Text;
                us.IdDis = Convert.ToInt32( cbo_dis.SelectedValue.ToString());
                us.Usuario = txtUser.Text;
                us.Password = txtPass.Text;
                if (xFotoruta.Trim().Length < 5)
                {
                    us.Foto = "-";
                }
                else
                {
                    us.Foto = xFotoruta;
                }
                us.FechaNac = dtp_FechaVenc.Value;
                us.IdRol = Convert.ToInt32(cbo_rol.SelectedValue.ToString());
                us.Correo = txt_correo.Text;
                us.Estado = "Activo";
                us.IdEmpresa = Convert.ToInt32(Cls_Libreria.Idempresa);

                obj.RN_insertar_Usuario(us);

                Frm_Filtro fil = new Frm_Filtro();
                Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

                fil.Show();

                ok.ShowDialog();
                MessageBox.Show("El Usuario se ha guardado exitosamente");
                fil.Hide();

                this.Tag = "A";
                this.Close();


            }
            else
            {
                //Editar:
                //obj.RN_Editar_Marcas(Convert.ToInt32(txt_idvehiculo.Text), txt_modelo.Text);
                //pnl_add.Visible = false;
                //Cargar_todas_lasMarcas();
                //txt_modelo.Text = "";
                //editar = false;


            }

            //try
            //{

            //    RN_Usuario obj = new RN_Usuario();
            //    EN_Usuario us = new EN_Usuario();

            //    us.Nombres = txt_nombreProve.Text;
            //    us.Apellidos = txtApellido.Text;
            //    us.IdDis = Convert.ToInt32(cbo_dis.Text);
            //    us.Usuario = txtUser.Text;
            //    us.Password = txtPass.Text;
            //    if (xFotoruta.Trim().Length < 5)
            //    {
            //        us.Foto = "-";
            //    }
            //    else
            //    {
            //        us.Foto = xFotoruta;
            //    }
            //    us.FechaNac = dtp_FechaVenc.Value;
            //    us.IdRol = Convert.ToInt32(cbo_rol.Text);
            //    us.Correo = txt_correo.Text;
            //    us.Estado = "Activo";
            //    us.IdEmpresa = Convert.ToInt32(Cls_Libreria.Idempresa);

            //    obj.RN_insertar_Usuario(us);


            //    limpiarForm();

            //    this.Tag = "A";
            //    this.Close();

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //}
        }//2--Fin.


        private void limpiarForm()
        {

            //txt_nombreProve.Text = "";
            //txtApellido.Text = "";
            //txt_rubro.Text = "";
            //txt_contacto.Text = "";
            //txtUser.Text = "";
            //xFotoruta = "";
            //txt_ruc.Text = "";

        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            //if (Validar_Textobox()== true)
            //{
                
            //}
            Registrar_Proveedor();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void chk_sunat_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void ConsultarCliente_Dni()
        {
           
        }

        private void ConsultarCliente_Ruc()
        {
           
        }

    
    }
}
