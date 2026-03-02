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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net;
using System.IO;
using Guna.UI.WinForms;

namespace Microsell_Lite.Cliente
{
    public partial class Frm_Add_Cliente : Form
    {
        public Frm_Add_Cliente()
        {
            InitializeComponent();
        }

        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            btnBuscar.Enabled = false;
            txt_idcliente.Text = RN_TipoDoc.RN_NroID(8);
            Cargar_distritos();
            Cargar_CodTipoDoc();
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

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

        private void Cargar_CodTipoDoc()
        {
            RN_Cliente obj = new RN_Cliente();
            DataTable dato = new DataTable();

            try
            {
                dato = obj.RN_Listar_CodTipoDocIdent();
                if (dato.Rows.Count > 0)
                {
                    cbo_CodtipoDoc.DataSource = dato;
                    cbo_CodtipoDoc.ValueMember = "IdTipo";
                    cbo_CodtipoDoc.DisplayMember = "Doc_Ident";
                    cbo_CodtipoDoc.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = ""; 
            this.Close();
          
        }

        /*string xFotoruta;

        private void lbl_Abrir_Click(object sender, EventArgs e)
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
                MessageBox.Show("Error al Guardar el Personal" + ex.Message);

            }

        }*/


        private bool Validar_Textobox()
        {

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (txt_idcliente.Text.Trim().Length <2) { fil.Show(); ver.Lbl_msm1.Text = "Ingresa o Genera el ID del Cliente"; ver.ShowDialog(); fil.Hide(); return false; }
            if (txt_nom.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_msm1.Text = "Ingresa el Nombre del Cliente"; ver.ShowDialog(); fil.Hide(); txt_nom.Focus(); return false; }
            //if (txt_ruc.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_msm1.Text = "Ingresa el Dni o Ruc del Cliente"; ver.ShowDialog(); fil.Hide(); txt_ruc.Focus(); return false; }
            if (cbo_dis.SelectedIndex ==-1) { fil.Show(); ver.Lbl_msm1.Text = "Selecciona un Distrito"; ver.ShowDialog(); fil.Hide(); cbo_dis.Focus(); return false; }
            if (txt_LimitedCred.Text.Trim().Length == 0) { fil.Show(); ver.Lbl_msm1.Text = "Ingresa el Limite de Credito"; ver.ShowDialog(); fil.Hide(); txt_LimitedCred.Focus(); return false; }

            // --- LÓGICA DE VALIDACIÓN DNI/RUC (txt_ruc) ---
            string ruc_dni = txt_ruc.Text.Trim();
            object idDoc = cbo_CodtipoDoc.SelectedValue;

            // 3. Validar que el campo DNI/RUC no esté vacío
            if (ruc_dni.Length == 0)
            {
                fil.Show();
                ver.Lbl_msm1.Text = "Ingresa el Dni ó Ruc del Cliente";
                ver.ShowDialog();
                fil.Hide();
                txt_ruc.Focus();
                return false;
            }

            // 3. Validar que se haya seleccionado un tipo de documento (ComboBox)
            if (idDoc == null || cbo_CodtipoDoc.SelectedIndex == -1)
            {
                fil.Show();
                ver.Lbl_msm1.Text = "Debe seleccionar un Tipo de Documento.";
                ver.ShowDialog();
                fil.Hide();
                cbo_CodtipoDoc.Focus();
                return false;
            }

            string idSeleccionado = idDoc.ToString();

            // 4. Validar Longitud y Formato según el TIPO SELECCIONADO
            //Caso DNI: Debe ser EXACTAMENTE 8 y NUMÉRICO
            if (idSeleccionado == ObtenerIdTipoPorDisplayMember("DNI")?.ToString())
            {
                if (ruc_dni.Length != 8)
                {
                    fil.Show();
                    ver.Lbl_msm1.Text = "El DNI debe tener exactamente 8 dígitos.";
                    ver.ShowDialog();
                    fil.Hide();
                    txt_ruc.Focus();
                    return false;
                }
                if (!long.TryParse(ruc_dni, out long n))
                {
                    fil.Show();
                    ver.Lbl_msm1.Text = "El DNI solo puede contener números.";
                    ver.ShowDialog();
                    fil.Hide();
                    txt_ruc.Focus();
                    return false;
                }
            }

            // Caso RUC: Debe ser EXACTAMENTE 11 y NUMÉRICO
            else if (idSeleccionado == ObtenerIdTipoPorDisplayMember("RUC")?.ToString())
            {
                if (ruc_dni.Length != 11)
                {
                    fil.Show();
                    ver.Lbl_msm1.Text = "El RUC debe tener exactamente 11 dígitos.";
                    ver.ShowDialog();
                    fil.Hide();
                    txt_ruc.Focus();
                    return false;
                }
                if (!long.TryParse(ruc_dni, out long n))
                {
                    fil.Show();
                    ver.Lbl_msm1.Text = "El RUC solo puede contener números.";
                    ver.ShowDialog();
                    fil.Hide();
                    txt_ruc.Focus();
                    return false;
                }
            }

            // Caso Carnet de Extranjería: Longitud entre 6 y 12
            else if (idSeleccionado == ObtenerIdTipoPorDisplayMember("C/E")?.ToString())
            {
                // El C/E se suele validar por rango de longitud, ya que puede ser alfanumérico.
                if (ruc_dni.Length < 6 || ruc_dni.Length > 12)
                {
                    fil.Show();
                    ver.Lbl_msm1.Text = "El Carnet de Extranjería debe tener entre 6 y 12 caracteres.";
                    ver.ShowDialog();
                    fil.Hide();
                    txt_ruc.Focus();
                    return false;
                }
            }
            return true;
        }

        private void Registrar_Cliente()
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

                if (cbo_CodtipoDoc.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un Tipo de Documento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbo_CodtipoDoc.Focus();
                    return;
                }
                // Obtener el valor de "IdTipo" como string (CHAR(2))
                cli.IdTipoDoc = cbo_CodtipoDoc.SelectedValue.ToString();

                obj.RN_insertar_Cliente(cli);

                if (BD_Cliente.saved ==true)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo_Producto(8);
                    limpiarForm();
                    MessageBox.Show("El Dato del Cliente se ha Guardado Exitosamente: ", "Registro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Tag = "A";
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
          //  xFotoruta = "";
            txt_ruc.Text = "";
            txt_LimitedCred.Text = "0";
            cbo_dis.SelectedIndex = -1;
            cbo_CodtipoDoc.SelectedIndex =- 1;

        }
        private void piclogo_Click(object sender, EventArgs e)
        {

        }
        private void btn_listo_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            RN_Cliente obj = new RN_Cliente();

            if (obj.RN_Verificar_NroDni(txt_ruc.Text) == true)
            {
                fil.Show();
                ver.Lbl_msm1.Text = "Número de documento del Cliente ya se encuentra Registrado";
                ver.ShowDialog();
                fil.Hide();
                return;
            }

            if (Validar_Textobox()==true)
            {

                Registrar_Cliente();

            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
        }
        private void ConsultarCliente_Dni()
        {
            try
            {
                using (var client = new HttpClient())
                {

                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    string url = "https://api.apis.net.pe/v1/dni?numero=" + txt_ruc.Text;

                    client.DefaultRequestHeaders.Add("Authorization", "apis-token-1.aTSI1U7KEuT-6bbbCguH-4Y8TI6KS73N");

                    var response = client.GetAsync(url).Result;


                    //para controlar que no se cierre la aplicacion cuando no obtiene datos:
                    if (response.IsSuccessStatusCode)
                    {
                        var res = response.Content.ReadAsStringAsync().Result;
                        dynamic r = JObject.Parse(res);

                        if (r.nombre != null)
                        {
                            txt_nom.Text = r.nombre;
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


                    //Pic_load.Visible = false;
                    //lbl_consul.Visible = false;

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
                            txt_nom.Text = r.nombre;
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

            if (numero.Length == 8)
            {
                // DNI
                Pic_load.Visible = true;
                lbl_consul.Visible = true;
                lbl_consul.Refresh();
                ConsultarCliente_Dni();
            }
            else if (numero.Length == 11)
            {
                // RUC
                Pic_load.Visible = true;
                lbl_consul.Visible = true;
                lbl_consul.Refresh();
                ConsultarCliente_Ruc();
            }
            else
            {
                MessageBox.Show("Ingrese un número válido de DNI (8 dígitos) o RUC (11 dígitos).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_ruc_TextChanged(object sender, EventArgs e)
        {

            //if (txt_ruc.Text.Length == 8 || txt_ruc.Text.Length == 11)
            //{
            //    btnBuscar.Enabled = true;
            //}
            //else
            //{
            //    btnBuscar.Enabled = false;
            //}

            string texto = txt_ruc.Text.Trim();
            int longitud = texto.Length;
            object idSeleccionado = null;

            // ----------------------------------------------------
            // LÓGICA DE DETECCIÓN AUTOMÁTICA DEL TIPO DE DOCUMENTO
            // ----------------------------------------------------

            if (longitud == 8)
            {
                // 8 dígitos = DNI
                idSeleccionado = ObtenerIdTipoPorDisplayMember("DNI");
            }
            else if (longitud == 11)
            {
                // 11 dígitos = RUC
                idSeleccionado = ObtenerIdTipoPorDisplayMember("RUC");
            }
            // Si la longitud cae en el rango de Carnet de Extranjería (ej. 9 a 12)
            else if (longitud >= 9 && longitud <= 12)
            {
                // Carnet de Extranjería (C/E)
                idSeleccionado = ObtenerIdTipoPorDisplayMember("C/E");
            }

            // Aplicar la selección usando el IdTipo (la clave foránea)
            if (idSeleccionado != null)
            {
                cbo_CodtipoDoc.SelectedValue = idSeleccionado;
            }
            else
            {
                // Si no coincide con ninguna longitud, deselecciona
                cbo_CodtipoDoc.SelectedIndex = -1;
            }

            // ----------------------------------------------------
            // LÓGICA EXISTENTE PARA HABILITAR EL BOTÓN DE BÚSQUEDA
            // ----------------------------------------------------

            if (txt_ruc.Text.Length == 8 || txt_ruc.Text.Length == 11)
            {
                btnBuscar.Enabled = true;
            }
            else
            {
                btnBuscar.Enabled = false;
            }

        }

        // Función para encontrar el IdTipo (la Foreign Key) basado en el nombre del documento.
        private object ObtenerIdTipoPorDisplayMember(string displayValue)
        {
            // Cbo_CodtipoDoc.DataSource es la DataTable que cargaste
            DataTable datos = cbo_CodtipoDoc.DataSource as DataTable;

            if (datos == null)
            {
                return null;
            }

            // Buscamos la fila donde Doc_Ident (DNI, RUC, C/E) coincida
            DataRow[] filas = datos.Select($"Doc_Ident = '{displayValue}'");

            if (filas.Length > 0)
            {
                // Retorna el valor de IdTipo (que es el ValueMember y la Foreign Key)
                return filas[0]["IdTipo"];
            }

            return null;
        }

    }
}
