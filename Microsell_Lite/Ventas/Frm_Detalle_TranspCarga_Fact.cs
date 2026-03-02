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
using static Prj_Capa_Entidad.EN_Ubigeo;

namespace Microsell_Lite.Ventas
{
    public partial class Frm_Detalle_TranspCarga_Fact : Form
    {
        RN_Ubigeo negocioUbigeo = new RN_Ubigeo();
      

        public Frm_Detalle_TranspCarga_Fact()
        {
            InitializeComponent();
        }

        private void Frm_Detalle_TranspCarga_Fact_Load(object sender, EventArgs e)
        {
            // Llamar al método asincrónico para cargar los ubigeos cuando el formulario se carga
            CargarUbigeosAsync();
            //CargarUbigeosAsync_Des();

            // Configurar el ComboBox para permitir autocompletar
            cbo_busqueda.AutoCompleteMode = AutoCompleteMode.SuggestAppend;  // Sugerir y agregar
            cbo_busqueda.AutoCompleteSource = AutoCompleteSource.ListItems;  // Fuente de datos es la lista de items

            cbo_UbigDestino.AutoCompleteMode = AutoCompleteMode.SuggestAppend;  // Sugerir y agregar
            cbo_UbigDestino.AutoCompleteSource = AutoCompleteSource.ListItems;  // Fuente de datos es la lista de items

            // Asociar el mismo evento SelectedIndexChanged a ambos ComboBox
            cbo_busqueda.SelectedIndexChanged += cbo_busqueda_SelectedIndexChanged;
            cbo_UbigDestino.SelectedIndexChanged += cbo_busqueda_SelectedIndexChanged;

        }

        // Método para cargar los ubigeos de forma asincrónica
        private async void CargarUbigeosAsync()
        {
           
            //try
            //{
            //    // Llamar al método asincrónico para obtener los ubigeos
            //    List<UbigeoInfo> ubigeos = await negocioUbigeo.RN_Listar_UbigeosAsync();

            //    // Llenar el ComboBox con los datos obtenidos
            //    cbo_busqueda.DataSource = ubigeos;
            //    cbo_busqueda.DisplayMember = "Ciudad";  // El texto que se mostrará
            //    cbo_busqueda.ValueMember = "Ubigeo";  // El valor que se guardará al seleccionar

            //    // Llenar el ComboBox con los datos obtenidos
            //    cbo_UbigDestino.DataSource = ubigeos;
            //    cbo_UbigDestino.DisplayMember = "Ciudad";  // El texto que se mostrará
            //    cbo_UbigDestino.ValueMember = "Ubigeo";  // El valor que se guardará al seleccionar


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al cargar los ubigeos: " + ex.Message);
            //}
        }
        


        private void cbo_busqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_busqueda.SelectedItem != null)
            {
                UbigeoInfo selectedUbigeo = cbo_busqueda.SelectedItem as UbigeoInfo;
                //lbl_res.Text = $"Ubigeo: {selectedUbigeo.Ubigeo}, Ciudad: {selectedUbigeo.Ciudad}, Provincia: {selectedUbigeo.Provincia}, Departamento: {selectedUbigeo.Departamento}";
                lbl_ubigOrigen.Text = selectedUbigeo.Ubigeo;
            }
            else if (cbo_UbigDestino.SelectedItem !=null)
            {
                UbigeoInfo selectedUbigeo = cbo_UbigDestino.SelectedItem as UbigeoInfo;
                //lbl_res.Text = $"Ubigeo: {selectedUbigeo.Ubigeo}, Ciudad: {selectedUbigeo.Ciudad}, Provincia: {selectedUbigeo.Provincia}, Departamento: {selectedUbigeo.Departamento}";
                lbl_ubigDestino.Text = selectedUbigeo.Ubigeo;
            }
        }
        private async void CargarUbigeosAsync_Des()
        {
            //try
            //{
            //    // Llamar al método asincrónico para obtener los ubigeos
            //    List<UbigeoInfo> ubigeos = await negocioUbigeo.RN_Listar_UbigeosAsync();

            //    cbo_UbigDestino.DataSource = ubigeos;
            //    cbo_UbigDestino.DisplayMember = "Ciudad";  // El texto que se mostrará
            //    cbo_UbigDestino.ValueMember = "Ubigeo";  // El valor que se guardará al seleccionar


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al cargar los ubigeos: " + ex.Message);
            //}
        }

        private void cbo_UbigDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbo_UbigDestino.SelectedItem != null)
            //{
            //    UbigeoInfo selectedUbigeo = cbo_UbigDestino.SelectedItem as UbigeoInfo;
            //    //lbl_res.Text = $"Ubigeo: {selectedUbigeo.Ubigeo}, Ciudad: {selectedUbigeo.Ciudad}, Provincia: {selectedUbigeo.Provincia}, Departamento: {selectedUbigeo.Departamento}";
            //    lbl_ubigDestino.Text = selectedUbigeo.Ubigeo;
            //}
        }

        private async  void cbo_busqueda_TextChanged(object sender, EventArgs e)
        {
            //string filterText = cbo_busqueda.Text;

            //if (!string.IsNullOrEmpty(filterText))
            //{
            //    // Filtrar la lista de ubigeos según el texto ingresado
            //    List<UbigeoInfo> filteredUbigeos = negocioUbigeo.RN_Listar_UbigeosAsync().Result
            //        .Where(ubigeo => ubigeo.Ciudad.Contains(filterText, StringComparison.OrdinalIgnoreCase))
            //        .ToList();

            //    // Actualizar el ComboBox con los resultados filtrados
            //    cbo_busqueda.DataSource = filteredUbigeos;
            //}
            //else
            //{
            //    // Si no hay texto, mostrar la lista completa
            //    CargarUbigeosAsync();
            //}
        }

        private void txt_ubigeo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {

        }
    }
}
