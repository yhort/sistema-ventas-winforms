using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsell_Lite.Compras;

using Gma.QrCodeNet.Encoding;
using QRCoder;
using ThoughtWorks.QRCode;
using ThoughtWorks.QRCode.Codec;

//importar:
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using System.IO;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Productos;
using Microsell_Lite.Cliente;
using Microsell_Lite.Informe;
using Microsell_Lite.Ventas;

using BE = businessEntities;
using CPEEnvio;
using CrearXML;
using Signature;



namespace Microsell_Lite.Ventas
{
    public partial class frm_AnularDoc : Form
    {
        public frm_AnularDoc()
        {
            InitializeComponent();
        }

        private void Frm_Ventana_Ventas_Load(object sender, EventArgs e)
        {

            Configurar_listView();
            Llenar_Combo_docs();
            cbo_tipoPago.SelectedIndex = 0;
            rdb_devolverstock.Checked = false;
            rdb_nodevolver.Checked = false;
            lbl_op.Text = "-";

        }



        private void Llenar_Combo_docs()
        {

            RN_TipoDoc obj = new RN_TipoDoc();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Doc_Especial();
            if (dato.Rows.Count > 0)
            {

                var cbo = Cbo_TipoDoc;

                cbo.DataSource = dato;
                cbo.DisplayMember = "Documento";
                cbo.ValueMember = "Id_Tipo";

            }

        }

        private void Configurar_listView()
        {
            var lis = lsv_Det;

            lis.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;

            //configurar las columnas:
            lis.Columns.Add("ID producto", 80, HorizontalAlignment.Left); //0
            lis.Columns.Add("Descripcion producto", 400, HorizontalAlignment.Left);  //1
            lis.Columns.Add("cantidad", 80, HorizontalAlignment.Left);  //2
            lis.Columns.Add("precio Unit", 90, HorizontalAlignment.Right);  //3
            lis.Columns.Add("Importe", 90, HorizontalAlignment.Right);  //4
            lis.Columns.Add("Tipo Producto", 100, HorizontalAlignment.Right);  //5
            lis.Columns.Add("Und", 0, HorizontalAlignment.Right);  //6
            lis.Columns.Add("Utilidad Unit", 0, HorizontalAlignment.Right);  //7
            lis.Columns.Add("Total Utilidad", 0, HorizontalAlignment.Right);  //8
            //campos que se requiere para la FE:
            lis.Columns.Add("Afec. Igv", 90, HorizontalAlignment.Left);  //8

            lis.Columns.Add("PreUni sinIgv", 0, HorizontalAlignment.Left);  //3.0
            lis.Columns.Add("SubTotal SinIgv", 0, HorizontalAlignment.Left);  // 0.40
            lis.Columns.Add("Igv", 0, HorizontalAlignment.Left);  //3.40
            lis.Columns.Add("Tipo", 110, HorizontalAlignment.Left);

        }


        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {

            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }

        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        private void Calcular()
        {

            double xtotal = 0;
            double xcant = 0;
            double xprecio = 0;
            double ximporte = 0;
            double xsubtotal = 0;
            double xigv = 0;
            double xuti_unit = 0;
            double ximport_Uti = 0;
            double xTotalGanancia = 0;

            //================ para la FE ================
            double igvProd = 0;
            double subtotal_sinIgv = 0;
            double preUnit_sinIgv = 0;

            double xsubtotal_sinIgv = 0;
            double xigv_total = 0;



            for (int i = 0; i < lsv_Det.Items.Count; i++)
            {
                xcant = Convert.ToDouble(lsv_Det.Items[i].SubItems[2].Text);
                xprecio = Convert.ToDouble(lsv_Det.Items[i].SubItems[3].Text);  //precio que incluye el IGV

                //calculo:
                ximporte = xprecio * xcant;
                lsv_Det.Items[i].SubItems[4].Text = ximporte.ToString("###0.00");

                //utilidad:
                xuti_unit = Convert.ToDouble(lsv_Det.Items[i].SubItems[7].Text);
                ximport_Uti = xuti_unit * xcant;
                lsv_Det.Items[i].SubItems[8].Text = ximport_Uti.ToString("###0.00");



                //caluclo del total:
                xtotal = xtotal + Convert.ToDouble(lsv_Det.Items[i].SubItems[4].Text);
                xTotalGanancia = xTotalGanancia + Convert.ToDouble(lsv_Det.Items[i].SubItems[8].Text);

                //Calculo para Sunat: ========================
                preUnit_sinIgv = xprecio / 1.18;
                lsv_Det.Items[i].SubItems[10].Text = preUnit_sinIgv.ToString("###0.00");
                //subtotal sin igv:
                subtotal_sinIgv = preUnit_sinIgv * xcant;
                lsv_Det.Items[i].SubItems[11].Text = subtotal_sinIgv.ToString("###0.00");

                //calculamos el Igv:
                igvProd = subtotal_sinIgv * 0.18;
                lsv_Det.Items[i].SubItems[12].Text = igvProd.ToString("###0.00");


                //=================== Pie de la FE para la Sunat ====================== //
                xsubtotal_sinIgv = xsubtotal_sinIgv + Convert.ToDouble(lsv_Det.Items[i].SubItems[11].Text);
                xigv_total = xigv_total + Convert.ToDouble(lsv_Det.Items[i].SubItems[12].Text);

            }
            //calcular el IGV: IVA
            xsubtotal = xtotal / 1.18;
            xigv = xsubtotal * 0.18;

            lbl_subtotal.Text = xsubtotal.ToString("###0.00");
            lbl_igv.Text = xigv.ToString("###0.00");
            lbl_TotalPagar.Text = xtotal.ToString("###0.00");
            

            //=============== Totales del Pie de la FE ===================//
            lbl_subtotalGravado.Text = xsubtotal_sinIgv.ToString("###0.00");
            lbl_igvgravado.Text = xigv_total.ToString("###0.00");
            double totalGravado = xsubtotal_sinIgv + xigv_total;
            Lbl_totalGravado.Text = totalGravado.ToString("###0.00");


            lbl_son.Text = Numalet.ToString(lbl_TotalPagar.Text);
            let.LetraCapital = chkCapital.Checked;
            if (!actualizado) ActualizarCong();




        }


        Numalet let = new Numalet();
        Boolean actualizado = false;

        private void ActualizarCong()
        {
            actualizado = true;
            chkCapital.Checked = let.LetraCapital;
            if (lbl_son.Text.Length > 0)
            {
                lbl_son.Text = let.ToCustomString(lbl_TotalPagar.Text);
                actualizado = false;
            }
        }


        private bool Validar_Antes_Vender()
        {

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (lsv_Det.Items.Count == 0) { fil.Show(); ver.Lbl_msm1.Text = "Debes Agregra como Minimo un Producto al Carrito"; ver.ShowDialog(); fil.Hide(); return false; }
            if (Convert.ToInt32(lbl_idcliente.Text.Length) < 2) { fil.Show(); ver.Lbl_msm1.Text = "Te falta agregar un Cliente"; ver.ShowDialog(); fil.Hide(); return false; }
            if (txt_NroDoc.Text.Trim().Length <2) { fil.Show(); ver.Lbl_msm1.Text = "No se cargo el Nro de Documento "; ver.ShowDialog(); fil.Hide(); return false; }
            if (lbl_op.Text.Trim().Length <=1) { fil.Show(); ver.Lbl_msm1.Text = "Selecciona el tipo de Operación a realizar  "; ver.ShowDialog(); fil.Hide(); return false; }

            return true;

        }

        private void Guardar_Documento()
        {

            RN_Documento obj = new RN_Documento();
            EN_Documento doc = new EN_Documento();

            try
            {

                txt_NroDoc.Text = RN_TipoDoc.RN_NroID(Convert.ToInt32(Cbo_TipoDoc.SelectedValue));
                //los parametros:
                doc.IdDoc = txt_NroDoc.Text;
                doc.IdPed = txt_nroPed.Text;
                doc.IdTipo = Convert.ToInt32(Cbo_TipoDoc.SelectedValue);
                doc.Fecha_DocEmi = dtp_FechaEmi.Value;
                doc.Importe = Convert.ToDouble(lbl_TotalPagar.Text);
                doc.TipoPago = cbo_tipoPago.Text;
                
                doc.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                doc.Igv = Convert.ToDouble(lbl_igv.Text);
                doc.SonLetra = lbl_son.Text;
               
                doc.CdrSunat = "Pendiente";

                obj.RN_Registrar_Nuevo_Documento(doc);

                if (BD_Documento.seguardo == true)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(Convert.ToInt32(Cbo_TipoDoc.SelectedValue));
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }




        private void btn_procesar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            RN_Documento obj = new RN_Documento();
            RN_Caja objca = new RN_Caja();
            RN_Credito objcre = new RN_Credito();

            DataTable datacred = new DataTable();
            DataTable datacaja = new DataTable();
            Frm_TerminarAnulacion fin = new Frm_TerminarAnulacion();

            string idcredito = "";

            try
            {
                if (Validar_Antes_Vender() == true)
                {
                    obj.RN_Anular_Documento(txt_NroDoc.Text, "Anulado"); //documento anulado:
                    if(BD_Documento.seguardo == true)
                    {
                        objca.RN_Anular_Mov_Caja(txt_NroDoc.Text, "Anulado");

                        if(BD_Caja.cajaSaved == true)
                        {
                            datacred = objcre.RN_Listar_creditos_porValor(txt_NroDoc.Text);
                            if(datacred.Rows.Count > 0) //para validar si existe valores
                            {
                                idcredito = datacred.Rows[0]["IdNotaCred"].ToString();
                                objcre.RN_Eliminar_Credito_Permanente(idcredito);
                            }

                            //si eligio devolver stock o no:
                            if(rdb_devolverstock.Checked == true)
                            {
                                //vamos a devolver stock:
                                Registrar_MovimientoKardex();
                            }

                            //QUE HACEMOS CON EL DINERO:
                            fil.Show();
                            fin.lbl_totalDoc.Text = lbl_TotalPagar.Text;
                            fil.ShowDialog();
                            fil.Hide();

                            if (fin.Tag.ToString() == "A")
                            {
                                string opcion = fin.lbl_op.Text;

                                if (opcion.Trim()=="Nada")
                                {
                                    fil.Show();
                                    ok.Lbl_msm1.Text = "El Documento Fue Anulado Exitosamente";
                                    ok.ShowDialog();
                                    fil.Hide();

                                    this.Close();
                                }
                                else if (opcion.Trim()=="Salida")
                                {
                                    //egreso de caja
                                    Guardar_EgresoCaja();
                                    fil.Show();
                                    ok.Lbl_msm1.Text = "El Documento Fue Anulado Exitosamente";
                                    ok.ShowDialog();
                                    fil.Hide();

                                    this.Close();
                                }

                                else if( opcion.Trim() == "Vale")
                                {

                                }

                            }
                            

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }


        private void Registrar_MovimientoKardex()
        {
            RN_Kardex obj = new RN_Kardex();
            EN_Kardex kar = new EN_Kardex();
            RN_Productos objpro = new RN_Productos();
            DataTable dato = new DataTable();
            DataTable datoprod = new DataTable();

            string xidkardex = "";
            int xitem = 0;
            double stockProd = 0;
            double precioCompraProd = 0;

            string xidProd = "";
            double xcant = 0;
            string xTipoProd = "";


            try
            {

                for (int i = 0; i < lsv_Det.Items.Count; i++)
                {
                    var lis = lsv_Det.Items[i];

                    xidProd = lis.SubItems[0].Text;
                    xcant = Convert.ToDouble(lis.SubItems[2].Text);
                    xTipoProd = lis.SubItems[5].Text;

                    if (obj.RN_Verificar_Producto_siTieneKardex(xidProd) == true)
                    {
                        dato = obj.RN_Buscar_KardexDetalle_porProducto(xidProd.Trim());
                        if (dato.Rows.Count > 0)
                        {
                            xidkardex = Convert.ToString(dato.Rows[0]["Id_krdx"]);
                            xitem = dato.Rows.Count;
                            //leemos los datos del producto 
                            datoprod = objpro.RN_Buscar_Productos(xidProd.Trim());
                            stockProd = Convert.ToDouble(datoprod.Rows[0]["Stock_Actual"]);
                            precioCompraProd = Convert.ToDouble(datoprod.Rows[0]["Pre_CompraS"]);


                            //registramos el Detalle del Kardex:

                            kar.Idkardex = xidkardex;
                            kar.Item = xitem + 1;
                            kar.Doc_soporte = txt_NroDoc.Text;
                            kar.Det_Operacion = "Por anulacion de Venta";
                            //Entrada
                            kar.Cantidad_in = xcant; //producto ingresando al almacen:
                            kar.Precio_In = precioCompraProd;
                            kar.Total_In = xcant * precioCompraProd;
                            //salida:
                            kar.Cantidad_Out = 0;
                            kar.Precio_out =0;
                            kar.Total_out = 0;
                            //saldos:   //CALCULOS DE LOS KARDEX VALORIZADOS
                            kar.Cantidad_saldo = stockProd + xcant;
                            kar.Promedio = precioCompraProd;
                            kar.Total_saldo = precioCompraProd * kar.Cantidad_saldo;

                            obj.RN_Registrar_Detalle_Kardex(kar);

                            //ahora actualizamos nuestro stock de la tabla de productos:
                            objpro.RN_Sumar_Stock_Producto(xidProd.Trim(), xcant);

                           // Prod_Krd += 1;

                        }

                    }

                }//fin del for:

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reg Kardex Capa Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void Guardar_EgresoCaja()
        {
            RN_Caja obj = new RN_Caja();
            En_Caja cja = new En_Caja();

            try
            {

                cja.FechaCaja = dtp_FechaEmi.Value;
                cja.TipoCaja = "Salida";
                cja.Concepto = "Por Anulacion de Comprobante";
                cja.De_Para_Cliente = txt_cliente.Text;
                cja.Nro_Doc = txt_NroDoc.Text;
                cja.ImportaCaja = Convert.ToDouble(lbl_TotalPagar.Text);
                cja.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                cja.TotalUti = 0;
                cja.TipoPago = cbo_tipoPago.Text;
                cja.GeneradoPor = Cbo_TipoDoc.Text;

                obj.RN_Registrar_Mov_Caja(cja);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }



        private void tocar_timbreCaja()
        {
            string ruta;
            ruta = Application.StartupPath;
            System.Media.SoundPlayer son;
            son = new System.Media.SoundPlayer(ruta + @"\Efectocaja.wav");
            son.Play();

        }

        private void tocar_timbre_Aparecer()
        {
            string ruta;
            ruta = Application.StartupPath;
            System.Media.SoundPlayer son;
            son = new System.Media.SoundPlayer(ruta + @"\EspadaEfect.wav");
            son.Play();

        }



        public void GenerarQR(string tipodoc, string totalDoc, string Cliente, string nroDoc, string rutaqr)
        {
            QRCodeEncoder generarCodigoQR = new QRCodeEncoder();
            generarCodigoQR.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            generarCodigoQR.QRCodeScale = Int32.Parse("4");

            try
            {
                generarCodigoQR.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                //La versión "0" calcula automáticamente el tamaño
                generarCodigoQR.QRCodeVersion = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Generar QR 1: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //' -----------------------------------------------------
            string contenido;
            contenido = "Nro: " + nroDoc + "\r\n" + "Documento: " + tipodoc + "\r\n" + "Total: " + totalDoc + "\r\n" + "Cliente: " + Cliente;

            System.Drawing.Bitmap imgQR;

            try
            {

                imgQR = new System.Drawing.Bitmap(generarCodigoQR.Encode(contenido, System.Text.Encoding.UTF8));
                pic_qr.Image = imgQR;
                // imgQR.Save(rutaqr); //'Aqui Guarda la Primera Imagen QR en .BMP
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Generar QR 2: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        public static byte[] Convertir_Imagen_Bytes(Image img)
        {
            string sTemp = Path.GetTempFileName();
            FileStream fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            fs.Position = 0;

            int imgLength = Convert.ToInt32(fs.Length);
            byte[] bytes = new byte[imgLength];
            fs.Read(bytes, 0, imgLength);
            fs.Close();
            return bytes;
        }



        private void Limpiar_todo()
        {
            lsv_Det.Items.Clear();
            txt_cliente.Text = "";
            lbl_idcliente.Text = "-";          
            lbl_subtotal.Text = "0";
            lbl_igv.Text = "0";
            cbo_tipoPago.SelectedIndex = -1;
            Cbo_TipoDoc.SelectedIndex = -1;

        }


        private void Buscar_Producto_DeCotizacion(string idprdcto)
        {
            RN_Productos obj = new RN_Productos();
            DataTable data = new DataTable();

            try
            {
                data = obj.RN_Buscar_Productos(idprdcto);
                if (data.Rows.Count > 0)
                {
                    lbl_StockProdx.Text = Convert.ToString(data.Rows[0]["Stock_Actual"]);
                    lbl_tipoProdx.Text = Convert.ToString(data.Rows[0]["TipoProdcto"]);

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void Buscar_Documento_paraReimprimir(string nroDoc)
        {
            RN_Documento obj = new RN_Documento();
            DataTable dato = new DataTable();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Filtro fil = new Frm_Filtro();

            string descripProd = "";
            //string nroSerie = "";
            string estadoDoc = "";
            int tipoDoc = 0;
            string xtipoProd = "";
            string xidprod;

            try
            {
                dato = obj.RN_Buscador_DocumentoDetalle_porID(nroDoc.Trim());
                if (dato.Rows.Count > 0)
                {
                    var dt = dato.Rows[0];
                    //Validamos el Documento:

                    estadoDoc = Convert.ToString(dt["Estado_Doc"]);


                    if (estadoDoc.Trim() == "Anulado") { fil.Show(); ver.Lbl_msm1.Text = "El Documento ingresado ya ha sido Anulado"; ver.ShowDialog(); fil.Hide(); return; }
                    if (estadoDoc.Trim() == "Canjeado") { fil.Show(); ver.Lbl_msm1.Text = "El Documento ingresado ya ha sido Canjeado"; ver.ShowDialog(); fil.Hide(); return; }


                    txt_NroDoc.Text = Convert.ToString(dt["id_Doc"]);
                    txt_nroPed.Text = Convert.ToString(dt["id_Ped"]);
                    Cbo_TipoDoc.SelectedValue = Convert.ToInt32(dt["Id_Tipo"]);
                    dtp_FechaEmi.Value = Convert.ToDateTime(dt["Fecha_Emi"]);

                    cbo_tipoPago.Text = Convert.ToString(dt["TipoPago"]);
                    lbl_idcliente.Text = Convert.ToString(dt["Id_Cliente"]);
                    txt_cliente.Text = Convert.ToString(dt["Razon_Social_Nombres"]);




                    //detalle del documento:
                    foreach (DataRow xitem in dato.Rows)
                    {
                        ListViewItem xlist;
                        xlist = lsv_Det.Items.Add(xitem["Id_Pro"].ToString());
                        xidprod = xitem["Id_Pro"].ToString();
                        descripProd = xitem["Descripcion_Larga"].ToString();
                        //nroSerie = xitem["NroSerie_prod"].ToString();

                        xlist.SubItems.Add(descripProd.Trim());
                        xlist.SubItems.Add(xitem["Cantidad"].ToString());
                        xlist.SubItems.Add(xitem["Precio_conIgv"].ToString());
                        xlist.SubItems.Add(xitem["ImporteconIgv"].ToString());
                        xlist.SubItems.Add("Producto".ToString());
                        xlist.SubItems.Add(xitem["Und_Medida"].ToString());  //und, bls, kg, cja
                        xlist.SubItems.Add(xitem["Utilidad_Unit"].ToString());
                        xlist.SubItems.Add(xitem["TotalUtilidad"].ToString());

                        xlist.SubItems.Add(xitem["AfectoIgv"].ToString());
                        xlist.SubItems.Add(xitem["Precio_sinIgv"].ToString());
                        xlist.SubItems.Add(xitem["subtotal_SinIgv"].ToString());
                        xlist.SubItems.Add(xitem["Igv_subtotal"].ToString());
                        xlist.SubItems.Add("NIU");  //NIU -- ZZ
                                                    //if (xtipoProd.Trim()=="Producto")
                                                    //{
                                                    //    xlist.SubItems.Add("NIU");  //NIU -- ZZ
                                                    //}
                                                    //else
                                                    //{
                                                    //    xlist.SubItems.Add("ZZ");  //NIU -- ZZ
                                                    //}

                    }
                    Calcular();
                    pnl_sinProd.Visible = false;
                }
                else
                {

                    fil.Show();
                    ver.Lbl_msm1.Text = "el Documento que buscas no Existe";
                    ver.ShowDialog();
                    fil.Hide();
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al leer: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            lsv_Det.Items.Clear();
            Limpiar_todo();
            pnl_sinProd.Visible = true;

        }

        private void Frm_Crear_Ventas_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.F1)
            {
                if (pnl_sinProd.Visible == true)
                {
                    btn_Nuevo_buscarProd_Click(sender, e);
                }

            }

            if (e.KeyCode == Keys.F5)
            {
                if (pnl_sinProd.Visible == false)
                {
                    btn_procesar_Click(sender, e);
                }

            }
        }


        private void rdb_prueba_CheckedChanged(object sender, EventArgs e)
        { /*
            if (rdb_prueba.Checked == true)
            {
                lbl_idServer.Text = "3";
                rdb_prueba.BackColor = Color.SkyBlue;
            }
            else
            {
                rdb_prueba.BackColor = Color.WhiteSmoke;
            }
            */
        }


        private void btn_Nuevo_buscarProd_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Solo_letNum num = new Frm_Solo_letNum(); //solo numeros implementar

            fil.Show();
            num.ShowDialog();
            fil.Hide();

            if (num.Tag.ToString() == "A")
            {
                string nroDoc = num.txt_nro.Text;
                Buscar_Documento_paraReimprimir(nroDoc);
            }

        }

        private void rdb_devolverstock_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdb_nodevolver_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
