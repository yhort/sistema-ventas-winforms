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
using Prj_Capa_Datos;

namespace Microsell_Lite.Proveedor
{
    public partial class Frm_AddProveedor : Form
    {
        public Frm_AddProveedor()
        {
            InitializeComponent();
        }

        private void Frm_AddProveedor_Load(object sender, EventArgs e)
        {
            btnBuscar.Enabled = false;
            //Cargar_Departamento();
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


        private void Cargar_Departamento()
        {
            //RN_Operaciones_Ubigeo  obj = new RN_Operaciones_Ubigeo();
            //DataTable dato = new DataTable();

            //try
            //{
            //    dato = obj.RN_ListarDepartamentos();
            //    if (dato.Rows.Count > 0)
            //    {
            //        cbo_departamento.DataSource = dato;
            //        cbo_departamento.ValueMember = "CodigoDepartamento";
            //        cbo_departamento.DisplayMember = "Nombre";

            //        //cbo_departamento.SelectedIndex = -1;

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void cbo_departamento_SelectedValueChanged(object sender, EventArgs e)
        {
            ////para tomar el indice del comboco en int
            //int depid;
            //bool parseOK = Int32.TryParse(cbo_departamento.SelectedValue.ToString(), out depid);

           
            //Cargar_ProvinciaporDepartamentoId(depid);
        }


        private void Cargar_ProvinciaporDepartamentoId(int CodigoDepartamento)
        {
            //RN_Operaciones_Ubigeo obj = new RN_Operaciones_Ubigeo();
            //DataTable dato = new DataTable();

            //try
            //{
            //    dato = obj.RN_ListarProvinciaporDepartamentoId(CodigoDepartamento);
            //    if (dato.Rows.Count > 0)
            //    {
            //        cbo_provincia.DataSource = dato;
            //        cbo_provincia.ValueMember = "CodigoProvincia";
            //        cbo_provincia.DisplayMember = "Nombre";

            //       //cbo_provincia.SelectedIndex = -1;

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private void Cargar_Distrito_ProvinciaId(int CodigoProvincia)
        {
            //RN_Operaciones_Ubigeo obj = new RN_Operaciones_Ubigeo();
            //DataTable dato = new DataTable();

            //try
            //{
            //    dato = obj.RN_ListarDistrito_ProvinciaId(CodigoProvincia);
            //    if (dato.Rows.Count > 0)
            //    {
            //        cbo_distrito.DataSource = dato;
            //        cbo_distrito.ValueMember = "CodigoDistrito";
            //        cbo_distrito.DisplayMember = "Nombre";

            //        //cbo_provincia.SelectedIndex = -1;

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void cbo_provincia_SelectedValueChanged(object sender, EventArgs e)
        {
            //para seleccionar y cargar el siguiente combobox 
            //para tomar el indice del comboco en int
            int disId;
            bool parseOK = Int32.TryParse(cbo_provincia.SelectedValue.ToString(), out disId);


            Cargar_Distrito_ProvinciaId(disId);
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
            if (txt_ruc.Text.Trim().Length < 8) { fil.Show(); ver.Lbl_msm1.Text = "Ingresa el Nro de DNI o RUC del Proveedor"; ver.ShowDialog(); fil.Hide(); txt_ruc.Focus(); return false; }

            return true; //en caso la condicion no se cumpla.  --Fin
        }




        //2-Inicio ---Metodo para registrar datos del proveedor
        private void Registrar_Proveedor()
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

                obj.RN_Registrar_Proveedor(pro);

                if(BD_Proveedor.seguardoprov == true)
                {
                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

                    fil.Show();
                    ok.Lbl_msm1.Text = "El Proveedor se ha Creado y Guardado Exitosamente";
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
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            RN_Proveedor obj = new RN_Proveedor();

            if (obj.RN_Verificar_NroRucProveedor(txt_ruc.Text) == true)
            {
                fil.Show();
                ver.Lbl_msm1.Text = "Número de documento del Proveedor ya se encuentra Registrado";
                ver.ShowDialog();
                fil.Hide();
                return;
            }

            if (Validar_Textobox()== true)
            {
                Registrar_Proveedor();
                limpiarForm();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

      

        //private void ConsultarCliente_Dni()
        //{
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {

        //            ServicePointManager.Expect100Continue = true;
        //            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;



        //            string url = "https://api.apis.net.pe/v1/dni?numero=" + txt_ruc.Text;

        //            client.DefaultRequestHeaders.Add("Authorization", "apis-token-1.aTSI1U7KEuT-6bbbCguH-4Y8TI6KS73N");

        //            var response = client.GetAsync(url).Result;
        //            var res = response.Content.ReadAsStringAsync().Result;

        //            dynamic r = JObject.Parse(res);
        //            txt_nombreProve.Text = r.nombre;
        //            txtCondicion.Text = r.condicion;

        //            Pic_load.Visible = false;
        //            lbl_consul.Visible = false;

        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //private void ConsultarCliente_Ruc()
        //{
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {

        //            ServicePointManager.Expect100Continue = true;
        //            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


        //            //string dn = "74326715";

        //            //Console.WriteLine("Ingresa el numero de DNI");
        //            //dn =  int.Parse(Console.ReadLine()); 

        //            string url = "https://api.apis.net.pe/v1/ruc?numero=" + txt_ruc.Text;


        //            client.DefaultRequestHeaders.Add("Authorization", "apis-token-1.aTSI1U7KEuT-6bbbCguH-4Y8TI6KS73N");

        //            var response = client.GetAsync(url).Result;
        //            var res = response.Content.ReadAsStringAsync().Result;

        //            dynamic r = JObject.Parse(res);
        //            txt_nombreProve.Text = r.nombre;
        //            txt_direccion.Text = r.direccion;
        //            txtCondicion.Text = r.condicion;

        //            Pic_load.Visible = false;
        //            lbl_consul.Visible = false;


        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        private void ConsultarCliente_Ruc()
        {
            try
            {
                using (var client = new HttpClient())
                {

                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


                    //string dn = "74326715";

                    //Console.WriteLine("Ingresa el numero de DNI");
                    //dn =  int.Parse(Console.ReadLine()); 

                    string url = "https://api.apis.net.pe/v1/ruc?numero=" + txt_ruc.Text;

                    client.DefaultRequestHeaders.Add("Authorization", "apis-token-1.aTSI1U7KEuT-6bbbCguH-4Y8TI6KS73N");

                    var response = client.GetAsync(url).Result;
                    //para controlar que no se cierre la aplicacion cuando no obtiene datos:
                    if (response.IsSuccessStatusCode)
                    {
                        var res = response.Content.ReadAsStringAsync().Result;
                        dynamic r = JObject.Parse(res);

                        if (r.nombre != null)
                        {
                            txt_nombreProve.Text = r.nombre;
                            txtCondicion.Text = r.condicion != null ? r.condicion : "";
                        }
                        else
                        {
                            MessageBox.Show("No se encontró información para el DNI ingresado.", "Consulta SUNAT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró información para el DNI ingresado o hubo un error en la consulta.", "Consulta SUNAT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un error al consultar el DNI: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Pic_load.Visible = false;
                lbl_consul.Visible = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string numero = txt_ruc.Text.Trim();

            if (numero.Length == 11)
            {
                // RUC
                Pic_load.Visible = true;
                lbl_consul.Visible = true;
                lbl_consul.Refresh();
                ConsultarCliente_Ruc();
            }
            else
            {
                MessageBox.Show("Ingrese un número válido de RUC (11 dígitos).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_ruc_TextChanged(object sender, EventArgs e)
        {
            if (txt_ruc.Text.Length == 11)
            {
                btnBuscar.Enabled = true;
            }
            else
            {
                btnBuscar.Enabled = false;
            }
        }

      
    }
}
