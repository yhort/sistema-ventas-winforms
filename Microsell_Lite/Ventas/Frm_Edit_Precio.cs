using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;

namespace Microsell_Lite.Ventas
{
    public partial class Frm_Edit_Precio : Form
    {
        private SerialPort serialPort1;
        private string bufferDatos = string.Empty;
        private bool usuarioEditando = false;
        public Frm_Edit_Precio()
        {
            InitializeComponent();
        }


        public string idProducto = "";

        private void Frm_Edit_Precio_Load(object sender, EventArgs e)
        {

            Buscar_Producto(idProducto.Trim());
            //txt_precio.Focus();
            ConfigurarBalanza();

        }

        private bool balanzaActiva = false; // Nueva bandera de control

        private bool controlaStock;
        private void Buscar_Producto(string xvalor)
        {
            RN_Productos obj = new RN_Productos();
            DataTable data = new DataTable();
        

            try
            {

                data = obj.RN_Buscar_Productos(xvalor.Trim());
                if (data.Rows.Count > 0)
                {

                    lbl_idProd.Text = Convert.ToString(data.Rows[0]["Id_Pro"]);
                    Lbl_stockActual.Text = Convert.ToString(data.Rows[0]["Stock_Actual"]);
                    controlaStock = Convert.ToBoolean(data.Rows[0]["ControlaStock"]);
                    
                    Lbl_precompra.Text = Convert.ToString(data.Rows[0]["Pre_CompraS"]);
                    lbl_producto.Text = Convert.ToString(data.Rows[0]["Descripcion_Larga"]);
                    lbl_TipoProd.Text = Convert.ToString(data.Rows[0]["TipoProdcto"]);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Edit Precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (txt_precio.Text == "") { txt_precio.Focus();  return;  }  //se puede agregar un messabox como mensaje de alerta, q el valor sea mayor a cero
            if (Convert.ToDouble(txt_precio.Text) == 0) { MessageBox.Show("El Precio debe ser Mayor a Cero", "Precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txt_precio.Focus(); return; }


            if (txt_cant.Text == "") { txt_cant.Focus(); return; }
            if (Convert.ToDouble(txt_cant.Text) == 0) { MessageBox.Show("Ingrese la Cantidad", "Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txt_cant.Focus(); return; }

            try
            {
                Double PreCompra = Convert.ToDouble(Lbl_precompra.Text);
                double PreVenta = Convert.ToDouble(txt_precio.Text);
                double Utilidad_Unit = 0;

                Utilidad_Unit = PreVenta - PreCompra; //  5.50 :: 4.50 = 1.0 utiliunitaria
                Lbl_UtilidadUnit.Text = Utilidad_Unit.ToString("###0.00");

                if (controlaStock)
                {
                    //agregando if de validacion para ps.
                    if (double.TryParse(txt_cant.Text, out double cantidad) && cantidad > 0)
                    {
                        //VALIDAR STOCK DEL PRODUCTO 
                        if (lbl_TipoProd.Text.Trim() == "Producto" && cantidad > Convert.ToDouble(Lbl_stockActual.Text))
                        {
                            txt_cant.Text = "1";
                            MessageBox.Show("La cantidad a vender no puede superar al Stock disponible", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txt_cant.Focus();
                            return;

                        }
                        this.Tag = "A";
                        this.Close();

                    }
                    else
                    {
                        
                            MessageBox.Show("Ingrese una cantidad válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                    }
                }
                else
                {
                    this.Tag = "A";
                    this.Close();
                }

                ////agregando if de validacion para ps.
                //if (double.TryParse(txt_cant.Text, out double cantidad) && cantidad > 0)
                //{
                //    //VALIDAR STOCK DEL PRODUCTO 
                //    if (lbl_TipoProd.Text.Trim() == "Producto" && cantidad > Convert.ToDouble(Lbl_stockActual.Text))
                //    {
                //        txt_cant.Text = "1";
                //        MessageBox.Show("La cantidad a vender no puede superar al Stock disponible", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //        txt_cant.Focus();
                //        return;

                //    }
                //    this.Tag = "A";
                //    this.Close();

                //}

                //else
                //{
                //    MessageBox.Show("Ingrese una cantidad válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.Tag = "A";
            this.Close();
        }

        private void txt_precio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_cant_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario(); //evento keypress, con este codigo para ingresar solo numero, en los precios.
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_precio_TextChanged(object sender, EventArgs e)
        {
            //1.50 en decimales separador, confi, windows 
            txt_precio.Text = txt_precio.Text.Replace(",", ".");
            txt_precio.SelectionStart = txt_precio.Text.Length;

            try
            {
                Double PreCompra = Convert.ToDouble(Lbl_precompra.Text);
                double PreVenta = Convert.ToDouble(txt_precio.Text);
                double Utilidad_Unit = 0;

                Utilidad_Unit = PreVenta - PreCompra; //  5.50 :: 4.50 = 1.0 utiliunitaria
                Lbl_UtilidadUnit.Text = Utilidad_Unit.ToString("###0.00");
            }
            catch(Exception ex)
            {
                string sms = ex.Message;
            }

        }

        private void txt_cant_TextChanged(object sender, EventArgs e)
        {
            txt_cant.Text = txt_cant.Text.Replace(",", ".");
            txt_cant.SelectionStart = txt_cant.Text.Length;
        }

        private async Task ConfigurarBalanza()
        {
            try
            {
                RN_ConfigBalanza configNegocio = new RN_ConfigBalanza();
                EN_ConfigBalanza config = configNegocio.RN_ObtenerConfiguracion();

                if (config == null)
                {
                    MessageBox.Show("No se encontró configuración de la balanza. Configúrela primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
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

                // Abrir el puerto de forma asíncrona
                await Task.Run(() =>
                {
                    try
                    {
                        serialPort1.Open();
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("El puerto COM está en uso o no se puede acceder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al conectar con la balanza: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });

                // Verificar si responde
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
                    lbl_estado.Text = "✅ Balanza conectada correctamente.";
                    lbl_estado.ForeColor = Color.Green;
                }
                else
                {
                    balanzaActiva = false;
                    lbl_estado.Text = "❌ Balanza no responde. Verifique que esté encendida.";
                    lbl_estado.ForeColor = Color.Red;

                    serialPort1.Close();
                }
            }
            catch (Exception ex)
            {
                balanzaActiva = false;
                lbl_estado.Text = "❌ Error al conectar con la balanza: " + ex.Message;
                lbl_estado.ForeColor = Color.Red;
            }
        }

        private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (!balanzaActiva) return;

                string datos = serialPort1.ReadExisting();
                bufferDatos += datos;

                // Intentamos procesar los datos recibidos
                ProcesarDatos(bufferDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recibir datos de la balanza: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void Frm_Edit_Precio_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
