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

namespace Microsell_Lite.Productos
{
    public partial class Frm_Edit_Precio : Form
    {
        public Frm_Edit_Precio()
        {
            InitializeComponent();
        }


        public string idProducto = "";

        private void Frm_Edit_Precio_Load(object sender, EventArgs e)
        {

            //Buscar_Producto(idProducto.Trim());
            txt_precioCompra.Focus();

        }


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
                    Lbl_precompra.Text = Convert.ToString(data.Rows[0]["Pre_CompraS"]);
                    lbl_producto.Text = Convert.ToString(data.Rows[0]["Descripcion_Larga"]);
                    lbl_TipoProd.Text = Convert.ToString(data.Rows[0]["TipoProdcto"]);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (txt_precioCompra.Text == "") { txt_precioCompra.Focus();  return;  }  //se puede agregar un messabox como mensaje de alerta, q el valor sea mayor a cero
            if (Convert.ToDouble(txt_precioCompra.Text) == 0) { MessageBox.Show("El Precio debe ser Mayor a Cero", "Precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txt_precioCompra.Focus(); return; }


            if (txt_preVenta.Text == "") { txt_preVenta.Focus(); return; }
            if (Convert.ToDouble(txt_preVenta.Text) == 0) { MessageBox.Show("Ingrese la Cantidad", "Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txt_preVenta.Focus(); return; }

           
            
            this.Tag = "A";
            this.Close();
   
        }

        private void txt_precio_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_preVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario(); //evento keypress, con este codigo para ingresar solo numero, en los precios.
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

       

        private void txt_preVenta_TextChanged(object sender, EventArgs e)
        {
            txt_preVenta.Text = txt_preVenta.Text.Replace(",", ".");
            txt_preVenta.SelectionStart = txt_preVenta.Text.Length;
        }

        private void txt_precioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_precioCompra_TextChanged(object sender, EventArgs e)
        {
     
            txt_precioCompra.Text = txt_precioCompra.Text.Replace(",", ".");
            txt_precioCompra.SelectionStart = txt_precioCompra.Text.Length;


        }
    }
}
