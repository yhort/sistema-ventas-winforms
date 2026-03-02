using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsell_Lite.Productos;
using Prj_Capa_Negocio;
using Prj_Capa_Entidad;
using Prj_Capa_Datos;
using Microsell_Lite.Utilitarios;
namespace Microsell_Lite.Productos
{
    public partial class Frm_Importar_Prod : Form
    {
        public Frm_Importar_Prod()
        {
            InitializeComponent();
        }

        private void dtg_datos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int columIndex = e.ColumnIndex;
            string nomcolum = dtg_datos.Columns[columIndex].Name;
            dtg_datos.Columns.Remove(nomcolum);
        }

        private void btn_quitarfile_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(DataGridViewRow row in dtg_datos.SelectedRows)
                {
                    dtg_datos.Rows.Remove(row);
                   lbl_Nrofila.Text = Convert.ToString(dtg_datos.Rows.Count);
                }
            }
            catch (Exception ex)
            {

                txt_nombook.Focus();
            }
        }

        private void btn_cargarfile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                txt_ruta.Text = fileName.Trim();
                txt_nombook.Text = "Hoja1";
                if(txt_ruta.Text.Length == 0) { MessageBox.Show("Cargar la Ruta del Libro Excel por favor", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                if (txt_nombook.Text.Length == 0) { MessageBox.Show("Cargar el Nombre del Libro Excel por favor", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                Importar_Excel(txt_ruta.Text.Trim(), txt_nombook.Text.Trim());
            }
        }

        public void Importar_Excel(string Path, string LibroName)
        {
            try
            {
                System.Data.OleDb.OleDbConnection MyConnection;
                System.Data.DataSet dataSet;
                System.Data.OleDb.OleDbDataAdapter MyCommand;

                MyConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";Extended Properties=Excel 12.0;"); //versiones office / y descargar driver conector

                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [" + LibroName + "$]", MyConnection);

                dataSet = new System.Data.DataSet();
                MyCommand.Fill(dataSet);
                dtg_datos.DataSource = "";

                dtg_datos.DataSource = dataSet.Tables[0];

                int xnro = dtg_datos.RowCount;
                lbl_Nrofila.Text = Convert.ToString((xnro - 1));

                MyConnection.Close();
                btn_quitarfile.Enabled = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Obtener_Registro();
        }

        string NombrProd = "";
        double PrecioVenta = 0;
        double Precompra = 0;
        double Canti = 0;
        string idpr ="";
        private void Obtener_Registro()
        {
            int xitm = 0;
            int totalfila = 0;
            totalfila = Convert.ToInt32(lbl_Nrofila.Text);
            int xtotal = totalfila;

            if (dtg_datos.Rows.Count == 0) return;

            try
            {
                foreach(DataGridViewRow fila in dtg_datos.Rows)
                {
                    if(Convert.IsDBNull(fila.Cells[0].Value) == true) //codigo de barra
                    {
                        break;
                        this.Tag = "A";
                        this.Close();
                    }
                    else
                    {
                        idpr = Convert.ToString(fila.Cells[0].Value);
                    }

                    if(Convert.IsDBNull(fila.Cells[1].Value) == true) //Nombre de Producto 0
                    {
                        break;
                        this.Tag = "A";
                        this.Close();
                    }
                    else
                    {
                        NombrProd = Convert.ToString(fila.Cells[1].Value); 
                    }

                    if (Convert.IsDBNull(fila.Cells[1].Value)==true) // Precio COMPRA
                    {
                        
                        break;
                        this.Tag = "A";
                        this.Close();
                    }

                    else
                    {
                        Precompra = Convert.ToDouble(fila.Cells[2].Value);
                    }

                    if (Convert.IsDBNull(fila.Cells[1].Value) == true) //PrecioVenta
                    {
                        break;
                        this.Tag = "A";
                        this.Close();
                    }
                    else
                    {
                        PrecioVenta = Convert.ToDouble(fila.Cells[3].Value);
                    }
                    if (Convert.IsDBNull(fila.Cells[1].Value) == true)//stock
                    {
                        break;
                        this.Tag = "A";
                        this.Close();
                    }
                    else
                    {
                        Canti = Convert.ToDouble(fila.Cells[4].Value);
                    }

                    registrar_Producto(idpr,NombrProd, Precompra, PrecioVenta, Canti);
                    xitm += 1;
                    Lbl_registrado.Text = xitm.ToString();
                    Lbl_registrado.Refresh();

                }

                if(Convert.ToInt32(lbl_Nrofila.Text) == Convert.ToInt32(Lbl_registrado.Text))
                {
                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

                    fil.Show();
                    ok.Lbl_msm1.Text = "La Importacion ha Finalizado Exitosamente, Revisa tu Explorador de Productos";
                    ok.ShowDialog();
                    fil.Hide();

                    this.Tag = "A";
                    this.Close();
                    
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }



        private void registrar_Producto(string idpr,string nom, double precom, double preven, double stoc)
        {

            RN_Productos obj = new RN_Productos();
            EN_Producto pro = new EN_Producto();
            //string idProd = RN_TipoDoc.RN_NroID(4);

            try
            {
                pro.Idproducto = idpr;
                pro.Idproveedor = "CGRR"; //deacuerdo a la base de datos 
                pro.DescripcionGeneral = nom;
                pro.Frank = preven / precom;
                pro.PreCompra_Sol = precom;
                pro.PreCompra_Dlr = 0;
                pro.Stock = stoc;
                pro.Idcategoria = 1;
                pro.Idmarca = 1;
                pro.Foto = Application.StartupPath + @"C:\Users\Yhort\Downloads\chrome\Libro-cliente.png"; //en carpeta

                pro.PreVenta_Mnr = preven;
                pro.PreVenta_Myr = 0;
                pro.PreVenta_Dolr = 0;
                pro.UndMedida = "Und";
                pro.PesoUnit = 1;
                pro.UtilidadUnit = preven - precom;//1;
                pro.TipoProducto = "Producto";
                pro.ValorGeneral = 0;
                pro.CodTipoAfectacion_Sunat = "10";
                pro.TipoAfectacion_Sunat = "Gravado";
                pro.ControlaStock = true;
                pro.PreventaLista =Convert.ToDecimal(preven);

                obj.RN_Registrar_Producto(pro);

                if (BD_Productos.seguardo == true)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(4);
                    //para registrar el kardex:
                    Registrar_Kardex(idpr, stoc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas al guardar" + ex.Message);
            }
        }

        private void Registrar_Kardex(string idprod, double stock)
        {
            RN_Kardex obj = new RN_Kardex();
            EN_Kardex kr = new EN_Kardex();
            double precio_In = Precompra;
            double total_In = precio_In * stock;

            try
            {
                if (obj.RN_Verificar_Producto_siTieneKardex(idprod) == true)
                {
                    return; //ya tiene kardex no hace falta crear otro 
                }
                else
                {
                    string idkardex = RN_TipoDoc.RN_NroID(6);
                    obj.RN_Registrar_Kardex(idkardex, idprod, "CGRR");

                    if (BD_Kardex.seguardo == true)
                    {
                        //actualizar el sigueinte numero correlativo
                        RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(6);

                        //trabajamos con el detalle del kardex:
                        kr.Idkardex = idkardex;
                        kr.Item = 1;
                        kr.Doc_soporte = "000";
                        kr.Det_Operacion = "Inicio de Kardex";

                        //entradas
                        kr.Cantidad_in = stock;
                        kr.Precio_In = precio_In;
                        kr.Total_In = total_In;
                        //salidas;
                        kr.Cantidad_Out = 0;
                        kr.Precio_out = 0;
                        kr.Total_out = 0;

                        //saldos:
                        kr.Cantidad_saldo = stock;
                        kr.Promedio = 0;
                        kr.Total_saldo = Precompra * kr.Cantidad_saldo;
                        kr.TipoOperacion = "InicioKardex";
                        kr.CantiDiferencial = "-";
                        kr.ImporteDiferencial = 0;
                        kr.Observacion = "-";

                        obj.RN_Registrar_Detalle_Kardex(kr);

                        if (BD_Kardex.detsaved == true)
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salio mal: " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
    }
}
