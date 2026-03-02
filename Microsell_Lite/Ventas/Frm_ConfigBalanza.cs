using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsell_Lite.Ventas
{
    public partial class Frm_ConfigBalanza : Form
    {
        public Frm_ConfigBalanza()
        {
            InitializeComponent();
        }

        private void Frm_ConfigBalanza_Load(object sender, EventArgs e)
        {
            // 🔥 Cargar puertos COM disponibles y llenar el ComboBox
            string[] puertosDisponibles = SerialPort.GetPortNames();
            cmb_PuertoCOM.Items.Clear();
            cmb_PuertoCOM.Items.AddRange(puertosDisponibles);
            cmb_PuertoCOM.DropDownStyle = ComboBoxStyle.DropDownList;

            if (puertosDisponibles.Length > 0)
                cmb_PuertoCOM.SelectedIndex = 0;  // Seleccionamos el primer puerto disponible

            // 🔥 Configuración predeterminada para BaudRate
            cmb_BaudRate.Items.Clear();
            cmb_BaudRate.Items.AddRange(new string[] { "2400", "4800", "9600", "19200", "38400", "57600", "115200" });
            cmb_BaudRate.SelectedIndex = 2;  // 9600 como predeterminado
            cmb_BaudRate.DropDownStyle = ComboBoxStyle.DropDownList;

            // 🔥 Configuración predeterminada para DataBits
            cmb_DataBits.Items.Clear();
            cmb_DataBits.Items.AddRange(new string[] { "5", "6", "7", "8" });
            cmb_DataBits.SelectedIndex = 3;  // 8 bits como predeterminado
            cmb_DataBits.DropDownStyle = ComboBoxStyle.DropDownList;

            // 🔥 Configuración predeterminada para Paridad
            cmb_Paridad.Items.Clear();
            cmb_Paridad.Items.AddRange(new string[] { "None", "Odd", "Even", "Mark", "Space" });
            cmb_Paridad.SelectedIndex = 0;  // None como predeterminado
            cmb_Paridad.DropDownStyle = ComboBoxStyle.DropDownList;

            // 🔥 Configuración predeterminada para StopBits
            cmb_StopBits.Items.Clear();
            cmb_StopBits.Items.AddRange(new string[] { "One", "Two" });
            cmb_StopBits.SelectedIndex = 0;  // One como predeterminado
            cmb_StopBits.DropDownStyle = ComboBoxStyle.DropDownList;

            // 🔥 Intentar cargar configuración guardada
            var config = new RN_ConfigBalanza().RN_ObtenerConfiguracion();

            if (config != null)  // Si hay configuración guardada, la mostramos
            {
                // Verificar si el puerto COM configurado está disponible actualmente
                if (puertosDisponibles.Contains(config.PuertoCOM))
                    cmb_PuertoCOM.Text = config.PuertoCOM;
                else
                    MessageBox.Show("El puerto COM configurado anteriormente no está disponible. Verifíquelo.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Cargar configuración previa
                cmb_BaudRate.Text = config.BaudRate.ToString();
                cmb_DataBits.Text = config.DataBits.ToString();
                cmb_Paridad.Text = config.Paridad;
                cmb_StopBits.Text = config.StopBits;

                MessageBox.Show("Configuración previa de la balanza cargada.", "Configuración Cargada",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se encontró configuración previa. Configure y guarde los parámetros de la balanza.",
                                "Configuración Inicial", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmb_PuertoCOM.Text))
            {
                MessageBox.Show("Seleccione un puerto COM válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var config = new EN_ConfigBalanza
            {
                NombreEquipo = Environment.MachineName,
                PuertoCOM = cmb_PuertoCOM.Text,
                BaudRate = int.Parse(cmb_BaudRate.Text),
                DataBits = int.Parse(cmb_DataBits.Text),
                Paridad = cmb_Paridad.Text,
                StopBits = cmb_StopBits.Text
            };

            new RN_ConfigBalanza().RN_GuardarConfiguracion(config);
            MessageBox.Show("Configuración guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnProbarConexion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmb_PuertoCOM.Text))
            {
                MessageBox.Show("Seleccione un puerto COM válido para probar la conexión.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SerialPort sp = new SerialPort(cmb_PuertoCOM.Text, int.Parse(cmb_BaudRate.Text)))
                {
                    sp.DataBits = int.Parse(cmb_DataBits.Text);
                    sp.Parity = (Parity)Enum.Parse(typeof(Parity), cmb_Paridad.Text);
                    sp.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmb_StopBits.Text);
                    sp.Handshake = Handshake.None;
                    sp.Open();
                    MessageBox.Show("¡Conexión exitosa con la balanza!", "Conexión Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sp.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la balanza: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
