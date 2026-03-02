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
using System.IO;
using Prj_Capa_Datos;

namespace Microsell_Lite.Proveedor
{
    public partial class frm_Editar_Proveedor : Form
    {
        public frm_Editar_Proveedor()
        {
            InitializeComponent();
        }

        private void Frm_Reg_Prod_Load(object sender, EventArgs e) //para ser llamado desde exploraador de proveedores  //editar
        {
            Buscar_Proveedorpara_Editar(this.Tag.ToString());
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



        string xFotoruta="";

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
                MessageBox.Show("Error al Guardar imagen proveedor" + ex.Message);
                
            }
        }

        private void piclogo_Click(object sender, EventArgs e)
        {
            var FilePath = string.Empty;

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    xFotoruta = openFileDialog1.FileName;
                    piclogo.Load(xFotoruta);
                }
            }
            catch (Exception ex)
            {
                piclogo.Load(Application.StartupPath + @"\user115.png");
                xFotoruta = Application.StartupPath + @"\user115.png";
                MessageBox.Show("Error al Guardar imagen proveedor" + ex.Message);

            }
        }

        //1-Inicio-metodo para valida las cajas de texto.
        private bool Validar_Textobox() 
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (txt_idprovedor.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_msm1.Text = "Ingresa o Genera el ID del Proveedor"; ver.ShowDialog(); fil.Hide(); return false; }
            if (txt_nombreProve.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_msm1.Text = "Ingresa el Nombre del Proveedor"; ver.ShowDialog(); fil.Hide(); txt_nombreProve.Focus(); return false; }
            if (txt_ruc.Text.Trim().Length < 11 || txt_ruc.Text.Trim().Length > 11) { fil.Show(); ver.Lbl_msm1.Text = "Ingresa el Nro de  RUC del Proveedor (11-digitos)"; ver.ShowDialog(); fil.Hide(); txt_ruc.Focus(); return false; }

            return true; //en caso la condicion no se cumpla.  --Fin
        }




        //2-Inicio ---Metodo para editar datos del proveedor
        private void Editar_Proveedor()
        {
            RN_Proveedor obj = new RN_Proveedor();
            EN_Proveedor pro = new EN_Proveedor();

            try
            {

                pro.Idproveedor = txt_idprovedor.Text;
                pro.Nombreproveedor = txt_nombreProve.Text;
                pro.Direccion = txt_direccion.Text;
                pro.Telefono = txt_telefono.Text;
                pro.Rubro = txt_rubro.Text;
                pro.Ruc = txt_ruc.Text;
                pro.Correo = txt_correo.Text;
                pro.Contacto = txt_contacto.Text;
                if (xFotoruta.Trim().Length < 5)
                {
                    pro.Fotologo = "-";
                }
                else
                {
                    pro.Fotologo = xFotoruta;
                }
                //pro.Fotologo = xFotoruta;

                obj.RN_Editar_Proveedor(pro);

                if(BD_Proveedor.seeditoprov == true)
                {
                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

                    fil.Show();
                    ok.Lbl_msm1.Text = "El Proveedor se ha Editado y Guardado Exitosamente";
                    ok.ShowDialog();
                    //MessageBox.Show("El Proveedor se ha guardado exitosamente");
                    fil.Hide();

                    //limpiarForm();

                    this.Tag = "A";
                    this.Close();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
        }//2--Fin.



        private void limpiarForm()
        {

            txt_contacto.Text = "";
            txt_idprovedor.Text = "";
            txt_nombreProve.Text = "";
            txt_rubro.Text = "";
            txt_contacto.Text = "";
            txt_direccion.Text = "";
            xFotoruta = "";
            txt_ruc.Text = "";

        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (Validar_Textobox()== true)
            {
                Editar_Proveedor();
            }
        }


        private void Buscar_Proveedorpara_Editar(string idprove)
        {
            RN_Proveedor obj = new RN_Proveedor();
            DataTable data = new DataTable();
            string xxidprove = "";

            try
            {

                data = obj.RN_Buscar_Proveedores(idprove);
                if (data.Rows.Count > 0)
                {

                    xxidprove = Convert.ToString(data.Rows[0]["IDPROVEE"]);
                    txt_idprovedor.Text = xxidprove.Trim();

                    txt_nombreProve.Text = Convert.ToString(data.Rows[0]["NOMBRE"]);
                    txt_direccion.Text = Convert.ToString(data.Rows[0]["DIRECCION"]);
                    txt_correo.Text = Convert.ToString(data.Rows[0]["CORREO"]);
                    txt_telefono.Text = Convert.ToString(data.Rows[0]["TELEFONO"]);
                    txt_contacto.Text = Convert.ToString(data.Rows[0]["CONTACTO"]);
                    txt_rubro.Text = Convert.ToString(data.Rows[0]["RUBRO"]);
                    txt_ruc.Text = Convert.ToString(data.Rows[0]["RUC"]);
                    //xFotoruta = Convert.ToString(data.Rows[0]["FOTO_LOGO"]);
                    if (File.Exists(xFotoruta) == false)
                    {
                        piclogo.Image = Properties.Resources.reg15;
                    }
                    else
                    {
                        piclogo.Load(xFotoruta);

                    }

                    //piclogo.Load(xFotoruta);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
    }
}
