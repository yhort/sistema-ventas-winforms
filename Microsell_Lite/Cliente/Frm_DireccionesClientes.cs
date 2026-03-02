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

namespace Microsell_Lite.Cliente
{
    public partial class Frm_DireccionesClientes : Form
    {
        private string selectedDepartamento;
        private string selectedProvincia;
        public Frm_DireccionesClientes()
        {
            InitializeComponent();
        }
        private bool isLoading = false;  //se define una variable para controlar el evento: y no se dispare
        //se coloca en el load , 3.- luego en el cbo selectindchan
        private void Frm_DireccionesClientes_Load(object sender, EventArgs e)
        {
            isLoading = true; // Desactivar el evento
            Configurar_listView();  // Configurar las columnas del ListView
            //CargarDireccionesEnListView("C-0000001");  // Cargar las direcciones para un cliente con ID "123"
            //CargarClientesEnComboBox("Activo");
            CargarClientesCbo();
            isLoading = false;
            
            //ConfigurarComboBox();  
            LoadDepartamentos();
            

        }
        private void Configurar_listView()
        {

            var lis = lsv_direc;

            lsv_direc.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;

            //configuracion de colummnas
            lis.Columns.Add("ID Direccion", 50, HorizontalAlignment.Left);
            lis.Columns.Add("Id Cliente ", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Razon Social", 0, HorizontalAlignment.Left);
            lis.Columns.Add("RUC", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Direccion ", 300, HorizontalAlignment.Left);
            lis.Columns.Add("Distrito ", 100, HorizontalAlignment.Left);
            lis.Columns.Add("Cod Ubigeo", 80, HorizontalAlignment.Left);
            lis.Columns.Add("Departamento", 100, HorizontalAlignment.Left);
            lis.Columns.Add("Provincia", 100, HorizontalAlignment.Left);
            lis.Columns.Add("Pais", 0, HorizontalAlignment.Left);
            lis.Columns.Add("TipoDocumento", 0, HorizontalAlignment.Left);
            lis.Columns.Add("CodTipoDoc", 0, HorizontalAlignment.Left);





        }

        //private void Llenar_ListView(DataTable data)
        //{
        //    lsv_direc.Items.Clear();

        //    for (int i = 0; i < data.Rows.Count; i++)
        //    {
        //        DataRow dr = data.Rows[i];
        //        ListViewItem list = new ListViewItem(dr["direccion_id"].ToString());
        //        list.SubItems.Add(dr["cliente_id"].ToString());
        //        list.SubItems.Add(dr["direccion"].ToString());
        //        list.SubItems.Add(dr["distrito"].ToString());
        //        list.SubItems.Add(dr["cod_ubigeo"].ToString());
        //        list.SubItems.Add(dr["departamento"].ToString());
        //        list.SubItems.Add(dr["provincia"].ToString());
        //        list.SubItems.Add(dr["pais"].ToString());

        //        lsv_direc.Items.Add(list);

        //    }

        //}
        public void CargarDirecciones(string clienteId)
        {
            CargarDireccionesEnListView(clienteId);
        }
        public void CargarDireccionesEnListView(string clienteId)
        {
            RN_DireccionesCl obj = new RN_DireccionesCl();
            DataTable dato = new DataTable();
            dato = obj.RN_ObtenerDireccionesPorCliente(clienteId);
            //DataTable direcciones = obj.RN_ObtenerDireccionesPorCliente(clienteId);

            lsv_direc.Items.Clear();

            if (dato != null && dato.Rows.Count > 0)
            {
                foreach (DataRow row in dato.Rows)
                {
                    ListViewItem item = new ListViewItem(row["direccion_id"].ToString());
                    item.SubItems.Add(row["cliente_id"].ToString());
                    item.SubItems.Add(row["Razon_Social_Nombres"].ToString());
                    item.SubItems.Add(row["DNI"].ToString());
                    item.SubItems.Add(row["direccion"].ToString());
                    item.SubItems.Add(row["distrito"].ToString());
                    item.SubItems.Add(row["cod_ubigeo"].ToString());
                    item.SubItems.Add(row["departamento"].ToString());
                    item.SubItems.Add(row["provincia"].ToString());
                    item.SubItems.Add(row["pais"].ToString());
                    item.SubItems.Add(row["TipoDocumento"].ToString());
                    item.SubItems.Add(row["CodTipoDoc"].ToString());

                    lsv_direc.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("No se encontraron direcciones para este cliente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public string ObtenerDireccionSeleccionada()
        {
            if (lsv_direc.SelectedItems.Count > 0)
            {
                return lsv_direc.SelectedItems[0].SubItems[2].Text; // Asumiendo que la dirección está en la tercera columna
            }
            return string.Empty;
        }


        private void lsv_direc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsv_direc.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar una dirección", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                txt_direccioonesId.Text = lsv_direc.SelectedItems[0].SubItems[0].Text;
                lbl_id_direcClientes.Text = lsv_direc.SelectedItems[0].SubItems[1].Text;
                lbl_razonsocialCli.Text = lsv_direc.SelectedItems[0].SubItems[2].Text;
                lbl_rucCli.Text = lsv_direc.SelectedItems[0].SubItems[3].Text;
                txt_direccion.Text = lsv_direc.SelectedItems[0].SubItems[4].Text;
                lbl_distrito.Text = lsv_direc.SelectedItems[0].SubItems[5].Text;
                txt_ubigeo.Text = lsv_direc.SelectedItems[0].SubItems[6].Text;
                lbl_departamento.Text = lsv_direc.SelectedItems[0].SubItems[7].Text;
                lbl_provincia.Text = lsv_direc.SelectedItems[0].SubItems[8].Text;
                lbl_tipoDoc.Text = lsv_direc.SelectedItems[0].SubItems[10].Text;
                lbl_codTipoDoc.Text = lsv_direc.SelectedItems[0].SubItems[11].Text;

                this.Tag = "A";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        public string estado = "Activo";
        private void CargarClientesCbo()
        {
            RN_Cliente obj = new RN_Cliente();
            DataTable data = new DataTable();

            data = obj.RN_Cargar_Todos_Cliente(estado);
            if (data.Rows.Count > 0)
            {
                //Llenar_ListView(data);
                var cbo = cboCliente;
                cbo.DataSource = data;
                cbo.DisplayMember = "Razon_Social_Nombres"; //
                cbo.ValueMember = "Id_Cliente";
                cbo.SelectedIndex = -1;

            }
            else
            {
                lsv_direc.Items.Clear();
            }
        }
  
        // Método que se ejecuta cuando se selecciona un cliente en el ComboBox
        //3.-verificamoes el estado
        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Este código asegura que el evento SelectedIndexChanged del ComboBox no se dispare mientras se están cargando los datos,
            //evitando así el mensaje de error al abrir el formulario
            if (!isLoading && cboCliente.SelectedValue != null)
            {
                CargarDireccionesEnListView(cboCliente.SelectedValue.ToString());
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Validar_cajasText()
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();


            if (txt_direccion.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa la dirección"; ver.ShowDialog(); fil.Hide(); return false; }
            if (txt_ubigeo.Text.Trim().Length == 0) { fil.Show(); ver.Lbl_Msm1.Text = "no se cargo el ubigeo, seleccione distrito"; ver.ShowDialog(); fil.Hide(); return false; }
          


            return true;

        }
        private void Limpiarform()
        {
           // cboCliente.SelectedIndex = -1;
            txt_direccion.Text = "";
            txt_ubigeo.Text = "";
            //cbo_departamento.SelectedIndex = -1;
            //cboProvincia.SelectedIndex = -1;
            //cbo_Distrito.SelectedIndex = -1;
            
        }


        private void RegistrarDirecciones()
        {

            RN_DireccionesCl obj = new RN_DireccionesCl();
            EN_DireccionesCl dir = new EN_DireccionesCl();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

            try
            {
                
                    dir.ClienteId = cboCliente.SelectedValue.ToString();                    
                    dir.Direccion = txt_direccion.Text;
                    dir.Distrito = lbl_distrito.Text;
                    dir.CodUbigeo = txt_ubigeo.Text;
                    dir.Departamento = cbo_departamento.SelectedValue.ToString();
                    dir.Provincia = cboProvincia.SelectedValue.ToString();
                    dir.Pais = "Peru";

                    obj.RN_insertar_DireccionesCli(dir);

                    if (BD_DireccionesCl.saved == true)
                    {
                        fil.Show();
                        ok.Lbl_msm1.Text = "La Dirección se ha Registrado Exitosamente";
                        ok.ShowDialog();
                        fil.Hide();

                        //Limpiarform();
                        //pnl_nuevo.Visible = false;
                        CargarDireccionesEnListView(cboCliente.SelectedValue.ToString());
                        //Limpiarform();
                    }



            }
            catch (Exception ex )
            {

                MessageBox.Show("Error al guardar la dirección.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        //ubbigeos:
        private void LoadDepartamentos()
        {
            ////RN_Ubigeo obj = new RN_Ubigeo();
            //BD_Ubigeo obj = new BD_Ubigeo();
            //DataTable dato = new DataTable();


            //dato = obj.BD_Listar_Ubigeos();

            //var departamentos = dato.DefaultView.ToTable(true, "Departamento");
            //cbo_departamento.DisplayMember = "Departamento";
            //cbo_departamento.ValueMember = "Departamento";
            //cbo_departamento.DataSource = departamentos;
        }

        private void cbo_departamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selectedDepartamento = cbo_departamento.SelectedValue.ToString();
            //lbl_departamento.Text = selectedDepartamento; // Actualizar el Label
            //LoadProvincias(selectedDepartamento);//cbo_departamento.SelectedValue.ToString());

          
        }

        private void LoadProvincias(string departamento)
        {
            ////RN_Ubigeo obj = new RN_Ubigeo();
            //BD_Ubigeo obj = new BD_Ubigeo();
            //DataTable dato = new DataTable();
            //dato = obj.BD_Listar_Ubigeos();
            //var provincias = dato.Select($"Departamento = '{departamento}'").CopyToDataTable().DefaultView.ToTable(true, "Provincia");
            //cboProvincia.DisplayMember = "Provincia";
            //cboProvincia.ValueMember = "Provincia";
            //cboProvincia.DataSource = provincias;


        }
   
        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProvincia = cboProvincia.SelectedValue.ToString();
            lbl_provincia.Text = selectedProvincia; // Actualizar el Label


            LoadDistritos(selectedDepartamento,selectedProvincia);/*cbo_departamento.SelectedValue.ToString(), cboProvincia.SelectedValue.ToString()*/
           

        }

        private void LoadDistritos(string departamento, string provincia)
        {
            //RN_Ubigeo obj = new RN_Ubigeo();
            BD_Ubigeo obj = new BD_Ubigeo();
            DataTable dato = new DataTable();
            dato = obj.BD_Listar_Ubigeos();

            var distritos = dato.Select($"Departamento = '{departamento}' AND Provincia = '{provincia}'").CopyToDataTable();
            cbo_Distrito.DisplayMember = "Distrito";
            cbo_Distrito.ValueMember = "Ubigeo";
            cbo_Distrito.DataSource = distritos;
        }

        private void cbo_Distrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_Distrito.SelectedValue != null)
            {
                txt_ubigeo.Text = cbo_Distrito.SelectedValue.ToString();
                // Obtener el nombre del distrito seleccionado
                DataRowView selectedRow = cbo_Distrito.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    lbl_distrito.Text = selectedRow["Distrito"].ToString();
                }

            }
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            if( Validar_cajasText() == true)
            {
                RegistrarDirecciones();

            }
            
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utilitario usu = new Utilitario();
                usu.Mover_formulario(this);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void lsv_direc_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (lsv_direc.SelectedIndices.Count == 0)
                {
                    MessageBox.Show("Selecciona una direccion", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


            }

            else
            {
                lbl_idDirec.Text = lsv_direc.SelectedItems[0].SubItems[0].Text;
                lbl_id_direcClientes.Text = lsv_direc.SelectedItems[0].SubItems[1].Text;
                txt_direccion.Text = lsv_direc.SelectedItems[0].SubItems[2].Text;

                this.Tag = "A";
                this.Close();
            }
        }
    }
}
