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


namespace Microsell_Lite
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
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
            Application.Exit();
            
        }

        private void txt_password_OnValueChanged(object sender, EventArgs e)
        {
                txt_password.isPassword = true;
            
        }

        private bool Validar_texto()
        {
            Frm_Filtro fil = new Frm_Filtro();

            if (txt_usu.Text.Trim().Length < 2) {fil.Show(); MessageBox.Show("Ingresa tu Nombre de Usuario", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txt_usu.Focus(); return false; }
            if (txt_password.Text.Trim().Length < 2) {fil.Show(); MessageBox.Show("Ingresa tu Clave", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txt_password.Focus(); return false; }

            return true;
        }

        
        private void Hacer_Login()
        {
            RN_Usuario obj = new RN_Usuario();
            DataTable dato = new DataTable();

            string usu = txt_usu.Text;
            string pass = txt_password.Text;

            int veces =0;

            if (Validar_texto() == false) return;
            
            if(obj.RN_Login (usu, pass) == true)
            {
                dato = obj.RN_Buscar_Usuario(usu);

                if (dato.Rows.Count > 0)
                {
                    DataRow dr = dato.Rows[0];
                    Cls_Libreria.IdRol = dr["Id_Rol"].ToString();
                    Cls_Libreria.Nombre = dr["Nombres"].ToString();
                    Cls_Libreria.Foto = dr["Ubicacion_Foto"].ToString();
                    Cls_Libreria.Rol = dr["Rol"].ToString();
                    Cls_Libreria.IdUsu = dr["id_Usu"].ToString();
                    Cls_Libreria.Idempresa = Convert.ToInt32(dr["idempresa"]);

                 
                  
                }

                if (Cls_Libreria.Rol == "Administrador")
                {
                    this.Hide();

                    Frm_Principal prix = new Frm_Principal();
                    prix.bt_MenuPrinci.Enabled = true;
                    prix.Bt_Config.Enabled = true;
                    prix.bt_compras.Enabled = true;
                    prix.Bt_ventas.Enabled = true;
                    prix.Bt_cotizar.Enabled = true;
                    prix.bt_almacen.Enabled = true;
                    prix.bt_cliente.Enabled = true;
                    prix.bt_DocEmitidos.Enabled = true;

                    //this.Hide();
                    prix.Show();
                    prix.Cargar_datos_Usuario();
                }

                else if(Cls_Libreria.Rol == "Operario")
                {

                }
                else
                {
                    this.Hide();


                    Frm_Principal prix = new Frm_Principal();

                    prix.bt_MenuPrinci.Enabled = false;
                    prix.Bt_Config.Enabled = false;
                    prix.bt_compras.Enabled = false;
                    prix.Bt_ventas.Enabled = false;
                    prix.Bt_cotizar.Enabled = false;
                    prix.bt_almacen.Enabled = false;
                    prix.bt_cliente.Enabled = false;
                    prix.bt_DocEmitidos.Enabled = false;

                    prix.Show();
                    prix.Cargar_datos_Usuario();
                }

                //this.Hide();

                
                //Frm_Principal pri = new Frm_Principal();

                //pri.Show();
                //pri.Cargar_datos_Usuario();
                
            }
            else
            {
                veces += 1;
                txt_password.Text = "";
                txt_usu.Text = "";
                txt_usu.Focus();
                MessageBox.Show("El usuario o clave con incorrectos, intentalo nuevamente.", "Advertencia de Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (veces == 3)
                {
                    MessageBox.Show("Ud ha Sobrepasado los Limites permitidos de Intentos", "Advertencia de Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Exit();
                }

            }

            

        }



        private void Frm_Login_Load(object sender, EventArgs e)
        {

        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            Hacer_Login();
        }

        private void txt_usu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_password.Focus();
            }
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_listo_Click(sender, e);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
