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
using Prj_Capa_Datos;

namespace Microsell_Lite.Cliente
{
    public partial class Frm_Edit_Cliente : Form
    {
        public Frm_Edit_Cliente()
        {
            InitializeComponent();
        }

        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {

            //Cargar_distritos();
            Buscar_Cliente_para_Editar(this.Tag.ToString()); //opcional poner arriba del try buscarclieditar 
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }


        private void Buscar_Cliente_para_Editar(string idcliente)
        {
            RN_Cliente obj = new RN_Cliente();
            DataTable data = new DataTable();
            Cargar_distritos();
            string xxidcli = "";

            try
            {

                data = obj.RN_buscar_Cliente(idcliente, "Activo");
                if (data.Rows.Count > 0)
                {

                    xxidcli = Convert.ToString(data.Rows[0]["Id_Cliente"]);
                    txt_idcliente.Text = xxidcli.Trim();
                    txt_nom.Text = Convert.ToString(data.Rows[0]["Razon_Social_Nombres"]);
                    txt_direc.Text = Convert.ToString(data.Rows[0]["Direccion"]);
                    txt_tel.Text = Convert.ToString(data.Rows[0]["Telefono"]);
                    txt_ruc.Text = Convert.ToString(data.Rows[0]["DNI"]);
                    txt_correo.Text = Convert.ToString(data.Rows[0]["E_Mail"]);
                    txt_contacto.Text = Convert.ToString(data.Rows[0]["Contacto"]);
                    txt_LimitedCred.Text = Convert.ToString(data.Rows[0]["Limit_Credit"]);
                    cbo_dis.SelectedValue = Convert.ToString(data.Rows[0]["Id_Dis"]);
                    dtp_fechaAniv.Value = Convert.ToDateTime(data.Rows[0]["Fcha_Ncmnto_Anivsrio"]);


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
           

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = ""; 
            this.Close();
          
        }



        //string xFotoruta;

        //private void lbl_Abrir_Click(object sender, EventArgs e)
        //{

        //    var FilePath = string.Empty;

        //    try
        //    {

        //        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //        {

        //            xFotoruta = openFileDialog1.FileName;
        //            piclogo.Load(xFotoruta);

        //        }


        //    }
        //    catch (Exception ex)
        //    {

        //        piclogo.Load(Application.StartupPath + @"\user115.png");
        //        xFotoruta = Application.StartupPath + @"\user115.png";
        //        MessageBox.Show("Error al Guardar el Personal" + ex.Message);

        //    }

        //}


        private bool Validar_Textobox()
        {

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();

            if (txt_idcliente.Text.Trim().Length <2) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa o Genera el ID del Proveedor"; ver.ShowDialog(); fil.Hide(); return false; }
            if (txt_nom.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el Nombre del Proveedor"; ver.ShowDialog(); fil.Hide(); txt_nom.Focus(); return false; }
            if (cbo_dis.SelectedIndex ==-1) { fil.Show(); ver.Lbl_Msm1.Text = "Selecciona un Distrito"; ver.ShowDialog(); fil.Hide(); cbo_dis.Focus(); return false; }
            if (txt_LimitedCred.Text.Trim().Length == 0) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el Limite de Credito"; ver.ShowDialog(); fil.Hide(); txt_LimitedCred.Focus(); return false; }

            return true;
        }

        private void Editar_Cliente()
        {

            RN_Cliente obj = new RN_Cliente();
            EN_Cliente cli = new EN_Cliente();

            try
            {

                cli.Idcliente = txt_idcliente.Text;
                cli.Razonsocial = txt_nom.Text;
                cli.Direccion = txt_direc.Text;
                cli.Dni = txt_ruc.Text;
                cli.Telefono = txt_tel.Text;
                cli.Email = txt_correo.Text;
                cli.IdDis = Convert.ToInt32(cbo_dis.SelectedValue);
                cli.FechaAniver = dtp_fechaAniv.Value;
                cli.Contacto = txt_contacto.Text;
                cli.LimiteCred =Convert.ToDouble( txt_LimitedCred.Text);

                obj.RN_Editar_Cliente(cli);


                if (BD_Cliente.edited ==true)
                {

                    limpiarForm();
                    MessageBox.Show("El Dato del Cliente se ha Editado Exitosamente: ", "Registro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Tag = "A";
                    this.Close();

                }


            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void limpiarForm()
        {

            txt_contacto.Text = "";
            txt_idcliente.Text = "";
            txt_nom.Text = "";
            txt_LimitedCred.Text = "";
            txt_contacto.Text = "";
            txt_direc.Text = "";  
            //xFotoruta = "";
            txt_ruc.Text = "";
            txt_LimitedCred.Text = "0";
            cbo_dis.SelectedIndex = -1;

        }
        private void piclogo_Click(object sender, EventArgs e)
        {

        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (Validar_Textobox()==true)
            {

                Editar_Cliente();

            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
