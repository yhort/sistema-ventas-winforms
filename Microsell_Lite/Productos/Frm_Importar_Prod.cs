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

        private const int ID_ALMACEN_DEFAULT = 1; 
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

        //string NombrProd = "";
        //double PrecioVenta = 0;
        //double Precompra = 0;
        //double Canti = 0;
        //string idpr ="";

        string NombrProd = "";
        string UnidadBase = "";
        double PrecioVenta = 0;
        double Precompra = 0;
        double Canti = 0;
        string idpr = "";

        private void Obtener_Registro()
        {
            int xitm = 0;

            if (dtg_datos.Rows.Count == 0)
                return;

            try
            {
                foreach (DataGridViewRow fila in dtg_datos.Rows)
                {
                    if (fila.IsNewRow)
                        continue;

                    if (fila.Cells[0].Value == null || Convert.IsDBNull(fila.Cells[0].Value))
                        break;

                    if (fila.Cells[1].Value == null || Convert.IsDBNull(fila.Cells[1].Value))
                        break;

                    if (fila.Cells[2].Value == null || Convert.IsDBNull(fila.Cells[2].Value))
                        break;

                    idpr = Convert.ToString(fila.Cells[0].Value).Trim();
                    NombrProd = Convert.ToString(fila.Cells[1].Value).Trim();
                    UnidadBase = Convert.ToString(fila.Cells[2].Value).Trim().ToUpper();

                    if (string.IsNullOrWhiteSpace(idpr))
                        break;

                    if (string.IsNullOrWhiteSpace(NombrProd))
                        break;

                    if (string.IsNullOrWhiteSpace(UnidadBase))
                        UnidadBase = "UND";

                    if (!double.TryParse(Convert.ToString(fila.Cells[3].Value), out Precompra))
                        Precompra = 0;

                    if (!double.TryParse(Convert.ToString(fila.Cells[4].Value), out PrecioVenta))
                        PrecioVenta = 0;

                    if (!double.TryParse(Convert.ToString(fila.Cells[5].Value), out Canti))
                        Canti = 0;

                    if (Precompra < 0 || PrecioVenta < 0 || Canti < 0)
                    {
                        MessageBox.Show("Hay valores negativos en el producto: " + NombrProd,
                            "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    registrar_Producto(idpr, NombrProd, UnidadBase, Precompra, PrecioVenta, Canti);

                    xitm += 1;
                    Lbl_registrado.Text = xitm.ToString();
                    Lbl_registrado.Refresh();
                }

                Frm_Filtro fil = new Frm_Filtro();
                Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

                fil.Show();
                ok.Lbl_msm1.Text = "La importación ha finalizado. Revisa el Explorador de Productos.";
                ok.ShowDialog();
                fil.Hide();

                this.Tag = "A";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Importar Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //private void Obtener_Registro()
        //{
        //    int xitm = 0;
        //    int totalfila = 0;
        //    totalfila = Convert.ToInt32(lbl_Nrofila.Text);
        //    int xtotal = totalfila;

        //    if (dtg_datos.Rows.Count == 0) return;

        //    try
        //    {
        //        foreach(DataGridViewRow fila in dtg_datos.Rows)
        //        {
        //            if(Convert.IsDBNull(fila.Cells[0].Value) == true) //codigo de barra
        //            {
        //                break;
        //                this.Tag = "A";
        //                this.Close();
        //            }
        //            else
        //            {
        //                idpr = Convert.ToString(fila.Cells[0].Value);
        //            }

        //            if(Convert.IsDBNull(fila.Cells[1].Value) == true) //Nombre de Producto 0
        //            {
        //                break;
        //                this.Tag = "A";
        //                this.Close();
        //            }
        //            else
        //            {
        //                NombrProd = Convert.ToString(fila.Cells[1].Value); 
        //            }

        //            if (Convert.IsDBNull(fila.Cells[1].Value)==true) // Precio COMPRA
        //            {

        //                break;
        //                this.Tag = "A";
        //                this.Close();
        //            }

        //            else
        //            {
        //                Precompra = Convert.ToDouble(fila.Cells[2].Value);
        //            }

        //            if (Convert.IsDBNull(fila.Cells[1].Value) == true) //PrecioVenta
        //            {
        //                break;
        //                this.Tag = "A";
        //                this.Close();
        //            }
        //            else
        //            {
        //                PrecioVenta = Convert.ToDouble(fila.Cells[3].Value);
        //            }
        //            if (Convert.IsDBNull(fila.Cells[1].Value) == true)//stock
        //            {
        //                break;
        //                this.Tag = "A";
        //                this.Close();
        //            }
        //            else
        //            {
        //                Canti = Convert.ToDouble(fila.Cells[4].Value);
        //            }

        //            registrar_Producto(idpr,NombrProd, Precompra, PrecioVenta, Canti);
        //            xitm += 1;
        //            Lbl_registrado.Text = xitm.ToString();
        //            Lbl_registrado.Refresh();

        //        }

        //        if(Convert.ToInt32(lbl_Nrofila.Text) == Convert.ToInt32(Lbl_registrado.Text))
        //        {
        //            Frm_Filtro fil = new Frm_Filtro();
        //            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

        //            fil.Show();
        //            ok.Lbl_msm1.Text = "La Importacion ha Finalizado Exitosamente, Revisa tu Explorador de Productos";
        //            ok.ShowDialog();
        //            fil.Hide();

        //            this.Tag = "A";
        //            this.Close();

        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }

        //}

        private void registrar_Producto(string idpr, string nom, string unidadBase, double precom, double preven, double stoc)
        {
            RN_Productos obj = new RN_Productos();
            EN_Producto pro = new EN_Producto();

            try
            {
                pro.Idproducto = idpr.Trim();
                pro.Idproveedor = "CGRR";
                pro.DescripcionGeneral = nom.Trim();

                pro.Frank = precom > 0 ? preven / precom : 0;
                pro.PreCompra_Sol = precom;
                pro.PreCompra_Dlr = 0;

                pro.Stock = stoc;

                pro.Idcategoria = 1;
                pro.Idmarca = 1;
                pro.Foto = "-";

                pro.PreVenta_Mnr = preven;
                pro.PreVenta_Myr = 0;
                pro.PreVenta_Dolr = 0;

                pro.UndMedida = unidadBase.Trim().ToUpper();
                pro.PesoUnit = 1;

                pro.UtilidadUnit = preven - precom;
                pro.TipoProducto = "Producto";
                pro.ValorGeneral = stoc * precom;

                pro.CodTipoAfectacion_Sunat = "10";
                pro.TipoAfectacion_Sunat = "Gravado";
                pro.ControlaStock = true;
                pro.PreventaLista = Convert.ToDecimal(preven);

                obj.RN_Registrar_Producto(pro);

                if (BD_Productos.seguardo == true)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(4);

                    Registrar_Kardex(idpr.Trim(), stoc, precom);

                    int idPresentacionBase = Crear_Presentacion_Base_Importacion(
                        idpr.Trim(),
                        unidadBase.Trim().ToUpper(),
                        precom,
                        preven
                    );

                    if (idPresentacionBase > 0)
                    {
                        Registrar_StockFisico_Base(
                            idpr.Trim(),
                            idPresentacionBase,
                            Convert.ToDecimal(stoc)
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas al guardar: " + ex.Message,
                    "Importar Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private int Crear_Presentacion_Base_Importacion(string idProducto, string unidadBase, double precioCompra, double precioVenta)
        {
            try
            {
                RN_ProductoPresentacion obj = new RN_ProductoPresentacion();
                EN_ProductoPresentacion pre = new EN_ProductoPresentacion();

                pre.IdProducto = idProducto.Trim();
                pre.NombrePresentacion = unidadBase.Trim().ToUpper();
                pre.Abreviatura = unidadBase.Trim().ToUpper();
                pre.Equivalencia = 1;

                pre.PrecioCompra = Convert.ToDecimal(precioCompra);
                pre.PrecioVentaMinorista = Convert.ToDecimal(precioVenta);
                pre.PrecioVentaMayorista = 0;
                pre.CantMinMayorista = 0;

                pre.EsBase = true;
                pre.PermiteCompra = true;
                pre.PermiteVenta = true;
                pre.Activo = true;

                obj.RN_Registrar_ProductoPresentacion(pre);

                DataTable dt = obj.RN_Listar_ProductoPresentacion_porProducto(idProducto.Trim());

                foreach (DataRow dr in dt.Rows)
                {
                    bool esBase = Convert.ToBoolean(dr["EsBase"]);

                    if (esBase)
                    {
                        return Convert.ToInt32(dr["IdPresentacion"]);
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear presentación base: " + ex.Message,
                    "Importar Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
        }

        private void Registrar_StockFisico_Base(string idProducto, int idPresentacion, decimal stockInicial)
        {
            try
            {
                RN_Productos obj = new RN_Productos();

                obj.RN_Sumar_StockPresentacion(
                    ID_ALMACEN_DEFAULT,
                    idProducto.Trim(),
                    idPresentacion,
                    stockInicial
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar stock físico: " + ex.Message,
                    "Importar Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Registrar_Kardex(string idprod, double stock, double precioCompra)
        {
            RN_Kardex obj = new RN_Kardex();
            EN_Kardex kr = new EN_Kardex();

            double precio_In = precioCompra;
            double total_In = precio_In * stock;

            try
            {
                if (obj.RN_Verificar_Producto_siTieneKardex(idprod) == true)
                {
                    return;
                }

                string idkardex = RN_TipoDoc.RN_NroID(6);
                obj.RN_Registrar_Kardex(idkardex, idprod, "CGRR");

                if (BD_Kardex.seguardo == true)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(6);

                    kr.Idkardex = idkardex;
                    kr.Item = 1;
                    kr.Doc_soporte = "IMPORT";
                    kr.Det_Operacion = "Inicio de Kardex por Importación";

                    kr.Cantidad_in = stock;
                    kr.Precio_In = precio_In;
                    kr.Total_In = total_In;

                    kr.Cantidad_Out = 0;
                    kr.Precio_out = 0;
                    kr.Total_out = 0;

                    kr.Cantidad_saldo = stock;
                    kr.Promedio = precio_In;
                    kr.Total_saldo = precio_In * kr.Cantidad_saldo;

                    kr.TipoOperacion = "InicioKardex";
                    kr.CantiDiferencial = "-";
                    kr.ImporteDiferencial = 0;
                    kr.Observacion = "Importación inicial";

                    obj.RN_Registrar_Detalle_Kardex(kr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salió mal: " + ex.Message,
                    "Kardex Importación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //private void registrar_Producto(string idpr,string nom, double precom, double preven, double stoc)
        //{

        //    RN_Productos obj = new RN_Productos();
        //    EN_Producto pro = new EN_Producto();
        //    //string idProd = RN_TipoDoc.RN_NroID(4);

        //    try
        //    {
        //        pro.Idproducto = idpr;
        //        pro.Idproveedor = "CGRR"; //deacuerdo a la base de datos 
        //        pro.DescripcionGeneral = nom;
        //        pro.Frank = preven / precom;
        //        pro.PreCompra_Sol = precom;
        //        pro.PreCompra_Dlr = 0;
        //        pro.Stock = stoc;
        //        pro.Idcategoria = 1;
        //        pro.Idmarca = 1;
        //        pro.Foto = Application.StartupPath + @"C:\Users\Yhort\Downloads\chrome\Libro-cliente.png"; //en carpeta

        //        pro.PreVenta_Mnr = preven;
        //        pro.PreVenta_Myr = 0;
        //        pro.PreVenta_Dolr = 0;
        //        pro.UndMedida = "Und";
        //        pro.PesoUnit = 1;
        //        pro.UtilidadUnit = preven - precom;//1;
        //        pro.TipoProducto = "Producto";
        //        pro.ValorGeneral = 0;
        //        pro.CodTipoAfectacion_Sunat = "10";
        //        pro.TipoAfectacion_Sunat = "Gravado";
        //        pro.ControlaStock = true;
        //        pro.PreventaLista =Convert.ToDecimal(preven);

        //        obj.RN_Registrar_Producto(pro);

        //        if (BD_Productos.seguardo == true)
        //        {
        //            RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(4);
        //            //para registrar el kardex:
        //            Registrar_Kardex(idpr, stoc);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Problemas al guardar" + ex.Message);
        //    }
        //}


        //private void Registrar_Kardex(string idprod, double stock)
        //{
        //    RN_Kardex obj = new RN_Kardex();
        //    EN_Kardex kr = new EN_Kardex();
        //    double precio_In = Precompra;
        //    double total_In = precio_In * stock;

        //    try
        //    {
        //        if (obj.RN_Verificar_Producto_siTieneKardex(idprod) == true)
        //        {
        //            return; //ya tiene kardex no hace falta crear otro 
        //        }
        //        else
        //        {
        //            string idkardex = RN_TipoDoc.RN_NroID(6);
        //            obj.RN_Registrar_Kardex(idkardex, idprod, "CGRR");

        //            if (BD_Kardex.seguardo == true)
        //            {
        //                //actualizar el sigueinte numero correlativo
        //                RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(6);

        //                //trabajamos con el detalle del kardex:
        //                kr.Idkardex = idkardex;
        //                kr.Item = 1;
        //                kr.Doc_soporte = "000";
        //                kr.Det_Operacion = "Inicio de Kardex";

        //                //entradas
        //                kr.Cantidad_in = stock;
        //                kr.Precio_In = precio_In;
        //                kr.Total_In = total_In;
        //                //salidas;
        //                kr.Cantidad_Out = 0;
        //                kr.Precio_out = 0;
        //                kr.Total_out = 0;

        //                //saldos:
        //                kr.Cantidad_saldo = stock;
        //                kr.Promedio = 0;
        //                kr.Total_saldo = Precompra * kr.Cantidad_saldo;
        //                kr.TipoOperacion = "InicioKardex";
        //                kr.CantiDiferencial = "-";
        //                kr.ImporteDiferencial = 0;
        //                kr.Observacion = "-";

        //                obj.RN_Registrar_Detalle_Kardex(kr);

        //                if (BD_Kardex.detsaved == true)
        //                {

        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Algo salio mal: " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //}
        private void btn_salir_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_Presentaciones_Click(object sender, EventArgs e)
        {
            Obtener_Registro_Presentaciones();
        }

        //para importar producto con presentaciones 
        private void Obtener_Registro_Presentaciones()
        {
            int registrados = 0;

            if (dtg_datos.Rows.Count == 0)
                return;

            try
            {
                foreach (DataGridViewRow fila in dtg_datos.Rows)
                {
                    if (fila.IsNewRow)
                        continue;

                    if (fila.Cells[0].Value == null || Convert.IsDBNull(fila.Cells[0].Value))
                        break;

                    string idProducto = Convert.ToString(fila.Cells[0].Value).Trim();
                    string nombrePresentacion = Convert.ToString(fila.Cells[1].Value).Trim();
                    string abrev = Convert.ToString(fila.Cells[2].Value).Trim().ToUpper();

                    if (string.IsNullOrWhiteSpace(idProducto))
                        break;

                    if (string.IsNullOrWhiteSpace(nombrePresentacion))
                        continue;

                    if (string.IsNullOrWhiteSpace(abrev))
                        continue;

                    decimal equivalencia = 1;
                    decimal precioCompra = 0;
                    decimal precioMinorista = 0;
                    decimal precioMayorista = 0;
                    decimal cantMinMayorista = 0;
                    decimal stockPresentacion = 0;

                    decimal.TryParse(Convert.ToString(fila.Cells[3].Value), out equivalencia);
                    decimal.TryParse(Convert.ToString(fila.Cells[4].Value), out precioCompra);
                    decimal.TryParse(Convert.ToString(fila.Cells[5].Value), out precioMinorista);
                    decimal.TryParse(Convert.ToString(fila.Cells[6].Value), out precioMayorista);
                    decimal.TryParse(Convert.ToString(fila.Cells[7].Value), out cantMinMayorista);
                    decimal.TryParse(Convert.ToString(fila.Cells[8].Value), out stockPresentacion);

                    if (equivalencia <= 0)
                    {
                        MessageBox.Show("Equivalencia inválida para: " + nombrePresentacion);
                        continue;
                    }

                    if (!ExisteProducto(idProducto))
                    {
                        MessageBox.Show("El producto no existe: " + idProducto + "\nPrimero importa o registra el producto base.");
                        continue;
                    }

                    int idPresentacion = Importar_Presentacion(
                        idProducto,
                        nombrePresentacion,
                        abrev,
                        equivalencia,
                        precioCompra,
                        precioMinorista,
                        precioMayorista,
                        cantMinMayorista
                    );

                    if (idPresentacion > 0 && stockPresentacion > 0)
                    {
                        Procesar_Stock_Inicial_Presentacion(
                            idProducto,
                            idPresentacion,
                            nombrePresentacion,
                            stockPresentacion,
                            equivalencia,
                            precioCompra
                        );
                    }

                    registrados++;
                    Lbl_registrado.Text = registrados.ToString();
                    Lbl_registrado.Refresh();
                }

                Frm_Filtro fil = new Frm_Filtro();
                Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

                fil.Show();
                ok.Lbl_msm1.Text = "Importación de presentaciones finalizada correctamente.";
                ok.ShowDialog();
                fil.Hide();

                this.Tag = "A";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al importar presentaciones: " + ex.Message);
            }
        }

        private bool ExisteProducto(string idProducto)
        {
            RN_Productos obj = new RN_Productos();
            DataTable dt = obj.RN_Buscar_Productos(idProducto.Trim());

            return dt.Rows.Count > 0;
        }

        private int Importar_Presentacion(
                                        string idProducto,
                                        string nombrePresentacion,
                                        string abrev,
                                        decimal equivalencia,
                                        decimal precioCompra,
                                        decimal precioMinorista,
                                        decimal precioMayorista,
                                        decimal cantMinMayorista)
        {
            RN_ProductoPresentacion obj = new RN_ProductoPresentacion();
            EN_ProductoPresentacion pre = new EN_ProductoPresentacion();

            pre.IdProducto = idProducto.Trim();
            pre.NombrePresentacion = nombrePresentacion.Trim();
            pre.Abreviatura = abrev.Trim().ToUpper();
            pre.Equivalencia = equivalencia;
            pre.PrecioCompra = precioCompra;
            pre.PrecioVentaMinorista = precioMinorista;
            pre.PrecioVentaMayorista = precioMayorista;
            pre.CantMinMayorista = cantMinMayorista;
            pre.EsBase = false;
            pre.PermiteCompra = true;
            pre.PermiteVenta = true;
            pre.Activo = true;

            return obj.RN_Importar_ProductoPresentacion(pre);
        }

        private void Procesar_Stock_Inicial_Presentacion(
                                                        string idProducto,
                                                        int idPresentacion,
                                                        string nombrePresentacion,
                                                        decimal stockPresentacion,
                                                        decimal equivalencia,
                                                        decimal precioCompraPresentacion)
        {
            RN_Productos objProd = new RN_Productos();

            DataTable dtProd = objProd.RN_Buscar_Productos(idProducto.Trim());

            if (dtProd.Rows.Count == 0)
                return;

            double stockActualBase = Convert.ToDouble(dtProd.Rows[0]["Stock_Actual"]);
            double costoActualBase = Convert.ToDouble(dtProd.Rows[0]["Pre_CompraS"]);

            double cantidadBase = Convert.ToDouble(stockPresentacion * equivalencia);

            double costoBase = 0;

            if (equivalencia > 0)
                costoBase = Convert.ToDouble(precioCompraPresentacion / equivalencia);

            double nuevoStockBase = stockActualBase + cantidadBase;

            double nuevoCostoPromedio = 0;

            if (nuevoStockBase > 0)
            {
                nuevoCostoPromedio =
                    ((stockActualBase * costoActualBase) + (cantidadBase * costoBase))
                    / nuevoStockBase;
            }

            // 1. Registrar Kardex entrada
            Registrar_Kardex_Entrada_Presentacion(
                idProducto,
                nombrePresentacion,
                cantidadBase,
                costoBase,
                nuevoStockBase,
                nuevoCostoPromedio
            );

            // 2. Actualizar stock base global y costo promedio
            objProd.RN_Actualizar_Stock_y_Precio(
                idProducto.Trim(),
                nuevoStockBase,
                nuevoCostoPromedio
            );

            // 3. Sumar stock físico por presentación
            objProd.RN_Sumar_StockPresentacion(
                ID_ALMACEN_DEFAULT,
                idProducto.Trim(),
                idPresentacion,
                stockPresentacion
            );
        }

        private void Registrar_Kardex_Entrada_Presentacion(
                                                            string idprod,
                                                            string nombrePresentacion,
                                                            double cantidadBase,
                                                            double costoBase,
                                                            double nuevoStockBase,
                                                            double nuevoCostoPromedio)
        {
            RN_Kardex obj = new RN_Kardex();
            EN_Kardex kr = new EN_Kardex();

            try
            {
                string idkardex = "";

                if (obj.RN_Verificar_Producto_siTieneKardex(idprod) == true)
                {
                    DataTable dt = obj.RN_Buscar_KardexDetalle_porProducto(idprod.Trim());

                    if (dt.Rows.Count == 0)
                        return;

                    idkardex = Convert.ToString(dt.Rows[0]["Id_krdx"]);

                    kr.Item = dt.Rows.Count + 1;
                }
                else
                {
                    idkardex = RN_TipoDoc.RN_NroID(6);
                    obj.RN_Registrar_Kardex(idkardex, idprod, "CGRR");

                    if (BD_Kardex.seguardo == true)
                    {
                        RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(6);
                    }

                    kr.Item = 1;
                }

                kr.Idkardex = idkardex;
                kr.Doc_soporte = "IMP-PRES";
                kr.Det_Operacion = "Importación de presentación: " + nombrePresentacion;
                kr.TipoOperacion = "ImportacionPresentacion";

                kr.Cantidad_in = cantidadBase;
                kr.Precio_In = costoBase;
                kr.Total_In = cantidadBase * costoBase;

                kr.Cantidad_Out = 0;
                kr.Precio_out = 0;
                kr.Total_out = 0;

                kr.Cantidad_saldo = nuevoStockBase;
                kr.Promedio = nuevoCostoPromedio;
                kr.Total_saldo = nuevoStockBase * nuevoCostoPromedio;

                kr.CantiDiferencial = "-";
                kr.ImporteDiferencial = 0;
                kr.Observacion = "Importación de stock físico por presentación";

                obj.RN_Registrar_Detalle_Kardex(kr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Kardex importación presentación: " + ex.Message);
            }
        }
    }
}
