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
using Prj_Capa_Entidad;
using Prj_Capa_Datos;
using Microsell_Lite.Utilitarios;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Net.Http;

namespace Microsell_Lite.Cliente
{
    public partial class Frm_Listadocliente : Form
    {
        public Frm_Listadocliente()
        {
            InitializeComponent();
        }
        private void Frm_Listadocliente_Load(object sender, EventArgs e)
        {
            btnBuscar.Enabled = false;
            Cargar_CodTipoDoc();
            txt_direc.Text = "-";

            if (tipo.Trim().Length == 0)
            {
                Configurar_listView();
                Cargar_Todos_Clientes();
            }
            else
            {
                Configurar_listView();
                buscar_Cliente(tipo);
            }


            //cbo_CodtipoDoc.SelectedIndex = -1;
        }

        private void Registrar_Cliente()
        {

            RN_Cliente obj = new RN_Cliente();
            EN_Cliente cli = new EN_Cliente();

            try
            {

                cli.Idcliente = txt_id.Text;
                cli.Razonsocial = txt_nom.Text.Trim();
                cli.Dni = txt_ruc.Text.Trim();
                cli.Direccion = txt_direc.Text;
                cli.Telefono = "0";
                cli.Email = "-";
                cli.IdDis = 1;
                cli.FechaAniver = dtp_fn.Value;
                cli.Contacto = "-";
                cli.LimiteCred = 0;
                if(cbo_CodtipoDoc.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un Tipo de Documento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbo_CodtipoDoc.Focus();
                    return;
                }
                // Obtener el valor de "IdTipo" como string (CHAR(2))
                cli.IdTipoDoc = cbo_CodtipoDoc.SelectedValue.ToString();
                
                obj.RN_insertar_Cliente(cli);

                if (BD_Cliente.saved == true)
                {

                    RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo_Producto(8);
                    MessageBox.Show("El Dato del Cliente se ha Guardado Exitosamente: ", "Registro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_buscar.Text = txt_id.Text;
                    limpiarForm();
                    pnl_add.Visible = false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void limpiarForm()
        {

            txt_id.Text = "";
            txt_nom.Text = "";
            txt_direc.Text = "";
            txt_ruc.Text = "";

        }

        private bool Validar_Textobox()
        {

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (txt_id.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_msm1.Text = "Ingresa o Genera el ID del Cliente"; ver.ShowDialog(); fil.Hide(); return false; }
            if (txt_nom.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_msm1.Text = "Ingresa el Nombre del Cliente"; ver.ShowDialog(); fil.Hide(); txt_nom.Focus(); return false; }
            
            // --- LÓGICA DE VALIDACIÓN DNI/RUC (txt_ruc) ---
            string ruc_dni = txt_ruc.Text.Trim();
            object idDoc = cbo_CodtipoDoc.SelectedValue;


            // 2. Validar que el campo no esté vacío
     

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

            // Si se pasa esta validación, el formato es correcto para el tipo seleccionado.

            //// 2. **Validación Numérica**
            //long numero;
            //if (!long.TryParse(ruc_dni, out numero))
            //{
            //    fil.Show();
            //    ver.Lbl_msm1.Text = "El DNI/RUC solo puede contener números.";
            //    ver.ShowDialog();
            //    fil.Hide();
            //    txt_ruc.Focus();
            //    return false;
            //}
            //// ----------------------------------------------------

            return true;
        }

        private void btn_saved_Click(object sender, EventArgs e)
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
            if (Validar_Textobox() == true)
            {
                Registrar_Cliente();
            }

        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            txt_id.Text = RN_TipoDoc.RN_NroID(8);
            pnl_add.Visible = true;
            txt_ruc.Focus();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            pnl_add.Visible = false;
            limpiarForm();
        }

        public static string tipo = "";

       

        private void Configurar_listView()
        {

            var lis = lsv_cli;

            lsv_cli.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("ID", 0, HorizontalAlignment.Left); //0
            lis.Columns.Add("Nombre del Cliente", 400, HorizontalAlignment.Left); //2
            lis.Columns.Add("dni", 90, HorizontalAlignment.Left); //3
            lis.Columns.Add("Estado", 100, HorizontalAlignment.Left);//5
            lis.Columns.Add("TipoDocIdent", 50, HorizontalAlignment.Left);//5
            lis.Columns.Add("CodSunDocIdent", 50, HorizontalAlignment.Left);//5

        }


        //llenar el listview:

        private void Llenar_Listview(DataTable data)
        {
            
            lsv_cli.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Cliente"].ToString());
                list.SubItems.Add(dr["Razon_Social_Nombres"].ToString());
                list.SubItems.Add(dr["DNI"].ToString());   
                list.SubItems.Add(dr["Estado_Cli"].ToString());
                list.SubItems.Add(dr["IdTipo"].ToString());
                list.SubItems.Add(dr["CodTipoDoc"].ToString());
                lsv_cli.Items.Add(list); //si no ponemos esto,. el listview  nunca se llenara
            }
            Pintar_Filas();
           
        }

        private void Pintar_Filas()
        {
            int cont = 1;

            for (int i = 0; i < lsv_cli.Items.Count; i++)
            {
                if (cont % 2 == 0)
                {

                }
                else
                {
                    lsv_cli.Items[i].BackColor = Color.WhiteSmoke;
                }
                cont += 1;
            }
        }
        private void Cargar_Todos_Clientes()
        {
            RN_Cliente obj = new RN_Cliente();
            DataTable dato = new DataTable();

            dato = obj.RN_Cargar_Todos_Cliente("Activo");
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);

            }
            else
            {
                lsv_cli.Items.Clear();
                //pnl_add.Visible = true; // se agrego 12/12/2020
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

        public void buscar_Cliente(string valor)  //private anterior al cambio
        {
            RN_Cliente obj = new RN_Cliente();
            DataTable dato = new DataTable();

            dato = obj.RN_buscar_Cliente(valor, "Activo");
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_cli.Items.Clear();
                //pnl_add.Visible = true; // se agrego 12/12/2020
            }

        }

        private void txt_buscar_OnValueChanged(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length >2)
            {
                buscar_Cliente(txt_buscar.Text);
            }
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    buscar_Cliente(txt_buscar.Text);
                }
                else
                {
                    Cargar_Todos_Clientes();
                }

            }

        }

        private void Seleccionar_Cliente()
        {
            if(lsv_cli.SelectedIndices.Count == 0)
            {

            }
            else
            {
                var lis = lsv_cli.SelectedItems[0];
                lbl_id.Text = lis.SubItems[0].Text;
                lbl_nom.Text = lis.SubItems[1].Text;
                lbl_ruc.Text = lis.SubItems[2].Text;
                lbl_codtipoDocCli.Text = lis.SubItems[5].Text;

                this.Tag = "A";
                this.Close();
            }

        }

        private void lsv_cli_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Seleccionar_Cliente();
        }

        private void lsv_cli_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Enter)
            {
                Seleccionar_Cliente();
            }
        }
        private void elButton2_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);
            }
        }

        private void pnl_add_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Frm_Listadocliente_KeyDown(object sender, KeyEventArgs e)
        {

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

        private void txt_ruc_TextChanged(object sender, EventArgs e)
        {
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

        private void Consultar_enSunat(string nroRuc)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver adv = new Frm_Addver();

            //var posData = "apis-token-1.aTSIU7KEuT-6bbbCguH-4Y8TI6KS73N";

            

           // var data = Encoding.UTF8.GetBytes("{}");
            //var data = Encoding.ASCII.GetBytes(posData);



            //string JsonSpta;

            //ServicePointManager.Expect100Continue = true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {

                //using (var client = new HttpClient())
                //{
                   

                //    string url = "https://api.apis.net.pe/v1/dni?numero=" + nroRuc;

                //    client.DefaultRequestHeaders.Add("Authorization", " Bearer apis-token-1.aTSI1U7KEuT-6bbbCguH-4Y8TI6KS73N");

                //    var response =  client.GetAsync(url).Result;
                //    var res = response.Content.ReadAsStringAsync().Result;

                //    dynamic r = JObject.Parse(res);
                //    txt_nom.Text = r.nombre;
                //    txt_direc.Text = r.tipoDocumento;

                  

                //}


                //var result_post = SendRequest("https://api.apis.net.pe/v1/ruc?numero=" + nroRuc, data ,  "application/json" ,"GET");

                //JsonSpta = JValue.Parse(result_post).ToString(Formatting.Indented);
                //JObject jResults = JObject.Parse(JsonSpta);

                //if (jResults["success"].ToString() == "True")
                //{
                //    string xruc = jResults["result"]["numeroDocumento"].ToString();


                //    string xRazonSocial = jResults["result"]["nombre"].ToString();
                //    string xCondicion = jResults["result"]["condicion"].ToString();
                //    string xTipo = jResults["result"]["tipodoDocumento"].ToString();
                //    string xEstado = jResults["result"]["estado"].ToString();
                //    string xDireccion = jResults["result"]["direccion"].ToString();

                //    txt_ruc.Text = xruc;
                //    txt_nom.Text = xRazonSocial;
                //    txt_direc.Text = xDireccion;
                //    txtCondicion.Text = xCondicion;
                //    txtTipo.Text = xTipo;

                //    Pic_load.Visible = false;
                //    lbl_consul.Visible = false;


                //}
                //else
                //{
                //    fil.Show();
                //    adv.Lbl_Msm1.Text = "El Nro de RUC no existe";
                //    adv.ShowDialog();
                //    fil.Hide();
                //    Pic_load.Visible = false;
                //    lbl_consul.Visible = false;
                //    txt_ruc.Text = "";
                //    txt_ruc.Focus();
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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

                        if(r.nombre != null)
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

        //private string SendRequest(string uri, byte[] JsonDataByte, string ContentType, string method)
        //{
        //    WebRequest req = WebRequest.Create(uri);

        //    req.ContentType = ContentType;
        //    req.Method = method;
        //    req.ContentLength = JsonDataByte.Length;

        //    var stream = req.GetRequestStream();
        //    stream.Write(JsonDataByte, 0, JsonDataByte.Length);
        //    var response = req.GetResponse().GetResponseStream();

        //    var reader = new StreamReader(response);
        //    string res = reader.ReadToEnd();

        //    reader.Close();
        //    response.Close();

        //    return res;

        //}

        private void chk_sunat_CheckedChanged(object sender, EventArgs e)
        {
            //if (chk_sunat.Checked == true && txt_ruc.Text.Trim().Length == 8)
            //{
            //    if (txt_ruc.Text.Trim().Length == 8)
            //    {
            //        //llamamos al metodo consultar en sunat:
            //        Pic_load.Visible = true;
            //        lbl_consul.Visible = true;
            //        lbl_consul.Refresh();
            //        //Consultar_enSunat(txt_ruc.Text);
            //        ConsultarCliente_Dni();
            //    }
            //}
            //else if (chk_sunat.Checked == true && txt_ruc.Text.Trim().Length == 11)
            //{
            //    if (txt_ruc.Text.Trim().Length == 11)
            //    {
            //        //llamamos al metodo consultar en sunat:
            //        Pic_load.Visible = true;
            //        lbl_consul.Visible = true;
            //        lbl_consul.Refresh();
            //        //Consultar_enSunat(txt_ruc.Text);
            //        ConsultarCliente_Ruc();
            //    }
            //}
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
                cbo_CodtipoDoc.SelectedIndex = 0;
            }
            else if (numero.Length == 11)
            {
                // RUC
                Pic_load.Visible = true;
                lbl_consul.Visible = true;
                lbl_consul.Refresh();
                ConsultarCliente_Ruc();
                cbo_CodtipoDoc.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("Ingrese un número válido de DNI (8 dígitos) o RUC (11 dígitos).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       
        private void cbo_CodtipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(cbo_CodtipoDoc.SelectedIndex == 0)
            //{
            //    lbl_codtipoDocCli.Text = "1"; //DNI

            //}else if(cbo_CodtipoDoc.SelectedIndex == 1)
            //{
            //    lbl_codtipoDocCli.Text = "6"; //RUC

            //}else
            //{
            //    lbl_codtipoDocCli.Text = "4"; //C/E
            //}
        }
    }
}
