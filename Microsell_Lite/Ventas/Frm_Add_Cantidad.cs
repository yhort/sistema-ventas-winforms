using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;

namespace Microsell_Lite.Ventas
{
    public partial class Frm_Add_Cantidad : Form
    {
        private SerialPort serialPort1;
        private string bufferDatos = string.Empty;
        private bool usuarioEditando = false;

        public Frm_Add_Cantidad()
        {
            InitializeComponent();
            
        }


        private async void Frm_Add_Cantidad_Load(object sender, EventArgs e)
        {
            txt_cant.Focus();
            ConfigurarBalanza();
        }

        private bool balanzaActiva = false; // Nueva bandera de control

        private void EjecutarEnUI(Action accion)
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(accion));
            else
                accion();
        }
        private async Task ConfigurarBalanza()
        {
            try
            {
                RN_ConfigBalanza configNegocio = new RN_ConfigBalanza();
                EN_ConfigBalanza config = configNegocio.RN_ObtenerConfiguracion();

                if (config == null)
                {
                    EjecutarEnUI(() =>
                    {
                        lbl_estado.Text = "⚠️ No se encontró configuración de la balanza.";
                        lbl_estado.ForeColor = Color.Orange;
                    });
                    balanzaActiva = false;
                    return;
                }

                bufferDatos = string.Empty;

                // Cerrar y limpiar puerto anterior si existe
                if (serialPort1 != null)
                {
                    serialPort1.DataReceived -= sp_DataReceived;
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Dispose();
                    serialPort1 = null;
                }

                //añadiendo cambio 190425
                // Solo configuramos el puerto si hay configuración de la balanza

                if (config != null)
                {
                    serialPort1 = new SerialPort(config.PuertoCOM, config.BaudRate,
                                           (Parity)Enum.Parse(typeof(Parity), config.Paridad),
                                           config.DataBits,
                                           (StopBits)Enum.Parse(typeof(StopBits), config.StopBits))
                    {
                        Handshake = Handshake.None,
                        ReadTimeout = 500,
                        WriteTimeout = 500
                    };

                    serialPort1.DataReceived += sp_DataReceived;

                    // Intentar abrir el puerto
                    bool puertoAbierto = false;

                    await Task.Run(() =>
                    {
                        try
                        {
                            serialPort1.Open();
                            puertoAbierto = true;
                        }
                        catch (UnauthorizedAccessException)
                        {
                            EjecutarEnUI(() =>
                            {
                                lbl_estado.Text = "❌ Puerto COM en uso o no accesible.";
                                lbl_estado.ForeColor = Color.Orange;
                            });
                        }
                        catch (Exception ex)
                        {
                            EjecutarEnUI(() =>
                            {
                                lbl_estado.Text = "❌ Error al abrir el puerto: " + ex.Message;
                                lbl_estado.ForeColor = Color.Orange;
                            });
                        }
                    });


                    if (!puertoAbierto)
                    {
                        balanzaActiva = false;
                        return;
                    }

                    // Verificar si la balanza responde
                    bool balanzaResponde = false;
                    int intentos = 3;
                    while (intentos-- > 0)
                    {
                        if (serialPort1.BytesToRead > 0)
                        {
                            balanzaResponde = true;
                            break;
                        }
                        await Task.Delay(1000);
                    }


                    if (balanzaResponde)
                    {
                        balanzaActiva = true;
                        EjecutarEnUI(() =>
                        {
                            lbl_estado.Text = "✅ Balanza conectada correctamente.";
                            lbl_estado.ForeColor = Color.Green;
                        });
                    }
                    else
                    {
                        balanzaActiva = false;
                        EjecutarEnUI(() =>
                        {
                            lbl_estado.Text = "❌ Balanza no responde. Verifique que esté encendida.";
                            lbl_estado.ForeColor = Color.Red;
                        });

                        serialPort1.Close();
                    }

                }

            }
            catch (Exception ex)
            {
                balanzaActiva = false;
                EjecutarEnUI(() =>
                {
                    lbl_estado.Text = "❌ Error inesperado: " + ex.Message;
                    lbl_estado.ForeColor = Color.Red;
                });
               
            }

        }

        private void ActualizarEstadoBalanza(string mensaje, Color color)
        {
            if (lbl_estado.InvokeRequired)
            {
                lbl_estado.Invoke(new Action(() => {
                    lbl_estado.Text = mensaje;
                    lbl_estado.ForeColor = color;
                }));
            }
            else
            {
                lbl_estado.Text = mensaje;
                lbl_estado.ForeColor = color;
            }
        }

        private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (!balanzaActiva) return; //Si la balanza no está activa, no hacer nada.

                string datos = serialPort1.ReadExisting();
                bufferDatos += datos;

                // Intentamos procesar los datos recibidos
                ProcesarDatos(bufferDatos);
            }
            catch (Exception ex)
            {
                EjecutarEnUI(() =>
                {
                    lbl_estado.Text = "❌ Error al recibir datos de la balanza: " + ex.Message;
                    lbl_estado.ForeColor = Color.Red;
                });
            }
        }

       


        private void timerBalanza_Tick(object sender, EventArgs e)
        {
            //string[] puertosDisponibles = SerialPort.GetPortNames();

            //if (serialPort1 == null || !serialPort1.IsOpen || !puertosDisponibles.Contains(serialPort1.PortName))
            //{
            //    lbl_estado.Text = "❌ Balanza desconectada.";
            //    lbl_estado.ForeColor = System.Drawing.Color.Red;
            //}
        }

        //private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    //try
        //    //{
        //    //    // Acumular datos en el buffer
        //    //    bufferDatos += serialPort1.ReadExisting();
        //    //    ProcesarDatos(bufferDatos);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    MessageBox.Show("Error al recibir datos de la balanza: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    //}
        //    try
        //    {
        //        string datos = serialPort1.ReadExisting();
        //        bufferDatos += datos;
        //        ProcesarDatos(bufferDatos);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al recibir datos de la balanza: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        private void ProcesarDatos(string datos)
        {
            //// Filtrar pesos válidos como "0.435kg" y descartar "0/kg"
            //Regex regex = new Regex(@"\b\d+\.\d{3}\s*kg\b");

            //MatchCollection matches = regex.Matches(datos);

            //if (matches.Count > 0)
            //{
            //    // Mostrar solo el último peso válido recibido
            //    string pesoValido = matches[matches.Count - 1].Value.Replace("kg", "").Trim();
            //    MostrarPeso(pesoValido);

            //    // Limpiar el buffer después de procesar datos válidos
            //    bufferDatos = string.Empty;
            //}

            // Filtramos pesos válidos con formato "0.435kg"
            Regex regex = new Regex(@"\b\d+\.\d{3}\s*kg\b");
            MatchCollection matches = regex.Matches(datos);

            if (matches.Count > 0)
            {
                // Tomamos el último peso válido recibido y lo mostramos
                string pesoValido = matches[matches.Count - 1].Value.Replace("kg", "").Trim();
                MostrarPeso(pesoValido);

                // Limpiar el buffer después de procesar
                bufferDatos = string.Empty;
            }
        }

        private void MostrarPeso(string peso)
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(MostrarPeso), peso);
            }
            else
            {
                // Si el usuario está editando, no actualizar
                if (!usuarioEditando)
                {
                    txt_cant.Text = peso;
                }
            }
        }


        private void txt_cant_TextChanged(object sender, EventArgs e)
        {
            ////if (e.KeyCode == Keys.Enter)
            ////{
            //if (lbl_TipoProd.Text.Trim().ToString() == "Producto")
            //{
            //    if (Convert.ToDouble(txt_cant.Text) > Convert.ToDouble(Lbl_stockActual.Text))
            //    {


            //        MessageBox.Show("La cantidad a vender no puede ser Mayor al Stock Disponible", "Validar Stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        txt_cant.Text = "1";
            //        return;
            //    }
            //    else
            //    {
            //        this.Tag = "A";
            //        this.Close();
            //    }
            //}
            //else
            //{
            //    this.Tag = "A";
            //    this.Close();
            //}
            ////}
            ///

           

        }

        //private void FormatearCantidad()
        //{
        //    if(lbl_und.Text.Trim().ToString() == "Kg")
        //    {
        //        if(decimal.TryParse(txt_cant.Text, out decimal cantidad))
        //        {

        //        }
        //    }
        //}

        private void txt_cant_KeyDown(object sender, KeyEventArgs e)
        {
            usuarioEditando = true; 

            if (e.KeyCode == Keys.Enter)
            {
                if (double.TryParse(txt_cant.Text, out double cantidad) && cantidad > 0)
                {
                    // Validar stock si corresponde
                    if (lbl_TipoProd.Text.Trim() == "Producto" && cantidad > Convert.ToDouble(Lbl_stockActual.Text))
                    {
                        MessageBox.Show("La cantidad no puede ser mayor al stock disponible.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_cant.Text = "1";
                        return;
                    }

                    this.Tag = "A";  // Se marca como válido
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ingrese una cantidad válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }


        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            
            this.Tag = "";
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pnl_titu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_cant_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Utilitario ui = new Utilitario();
            //e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
            // Permitir solo números y un punto decimal
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Frm_Add_Cantidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            balanzaActiva = false;


            if (serialPort1 != null)
            {
                serialPort1.DataReceived -= sp_DataReceived;

                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }

                serialPort1.Dispose();
                serialPort1 = null;
            }

        }

        private void txt_cant_Enter(object sender, EventArgs e)
        {
            //usuarioEditando = true;
        }

        private void txt_cant_Leave(object sender, EventArgs e)
        {
            //usuarioEditando = false;
        }
    }
}
