using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsell_Lite.Productos;
using Microsell_Lite.Ventas;
using Microsell_Lite.Cliente;
using Microsell_Lite.Compras;
using Microsell_Lite.Cotizacion;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Caja;
using Prj_Capa_Negocio;
using Microsell_Lite.Proveedor;
using Microsell_Lite.Informe;
using Microsell_Lite.Facturacion_Electronica;
using Microsell_Lite.GUIAREMISION;
using Microsell_Lite.Reportes_Consolidado;
using Microsell_Lite.Usuarios;


namespace Microsell_Lite
{
    public partial class Frm_Principal : Form
    {
        public Frm_Principal()
        {
            InitializeComponent();
        }

        private void Frm_Principal_Load(object sender, EventArgs e)
        {
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void bt_almacen_Click(object sender, EventArgs e)
        {
          

        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Pnl_Menu_MouseMove(object sender, MouseEventArgs e)
         {
            Utilitario obj = new Utilitario();
           if (e.Button ==MouseButtons.Left )
            {
                obj.Mover_formulario(this);
            }
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_hide_Click(object sender, EventArgs e)
        {

          //if( PanelLateral.Width == 247)
          //  {
          //      PanelLateral.Width = 40;
          //      PicUser_2.Visible = true;
          //  }
          //else
          //  {
          //      PanelLateral.Width = 247;
          //      PicUser.Visible = true ;
          //      PicUser_2.Visible = false;
          //  }
        }

        private void Bt_ventas_Click(object sender, EventArgs e)
        {

          
            Frm_Crear_Ventas ven = new Frm_Crear_Ventas();

          
            
            ven.MdiParent = this;
            ven.Show();


        }

        private void bt_cliente_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Frm_Explor_Cliente"] != null)
            {
                // Application.OpenForms["Frm_Crear_Ventas"].Activate();
                MessageBox.Show("El Formulario ya está Abierto!", "Abrir Formulario", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); //para que no abra 2 ventanas
            }
            else
            {
                Frm_Explor_Cliente cli = new Frm_Explor_Cliente();
                cli.MdiParent = this;
                cli.Show();

                if (PanelLateral.Width == 247)
                {
                    PanelLateral.Width = 40;
                    PicUser_2.Visible = true;
                }

            }
        }

        public void Cargar_datos_Usuario() //por realizar en clase 19
        {

            Frm_Filtro fil = new Frm_Filtro();
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            Frm_InicioCaja ca = new Frm_InicioCaja();

            fil.Show();
            MessageBox.Show("Bienvenido (a) Sr: " + Cls_Libreria.Nombre, "Inicio de Sesion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fil.Hide();
            

            if (obj.RN_Validar_InicioDoble_Caja() == false)
            {
                //Inicio
                fil.Show();
                ca.ShowDialog();
                fil.Hide();

            }





            lbl_user.Text = Cls_Libreria.Nombre + Cls_Libreria.Apellidos;
            lbl_Rol.Text = Cls_Libreria.Rol;

            if (Cls_Libreria.Foto.Trim().Length == 0 | Cls_Libreria.Foto == null) return;
            if (File.Exists(Cls_Libreria.Foto) == true)
            {
                PicUser.Load(Cls_Libreria.Foto);
                PicUser_2.Load(Cls_Libreria.Foto);

            }
            else
            {
                //PicUser.Image = Properties.Resources.user114; //se agrega imagen
                //PicUser_2.Image = Properties.Resources.user114;
            }

        }

        private void bt_compras_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Frm_Compras"] != null)
            {
                // Application.OpenForms["Frm_Crear_Ventas"].Activate();
                MessageBox.Show("El Form ya está Abierto!", "Abrir Formulario", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); //para que no abra 2 ventanas
            }
            else
            {
                Frm_Compras com = new Frm_Compras();
                com.MdiParent = this;
                com.Show();

                if (PanelLateral.Width == 247)
                {
                    PanelLateral.Width = 40;
                    PicUser_2.Visible = true;
                }

            }

        }

        private void Bt_AbrirExploradorDeCompras_Click(object sender, EventArgs e)
        {
          
        }

        private void Bt_cotizar_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Frm_Cotizacion"] != null)
            {
                // Application.OpenForms["Frm_Crear_Ventas"].Activate();
                MessageBox.Show("El Form ya está Abierto!", "Abrir Formulario", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); //para que no abra 2 ventanas
            }
            else
            {

                Frm_Cotizacion coti = new Frm_Cotizacion();
                coti.MdiParent = this;
                coti.Show();

                if (PanelLateral.Width == 247)
                {
                    PanelLateral.Width = 40;
                    PicUser_2.Visible = true;
                }

            }

        }

        private void bt_DocEmitidos_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Frm_Explor_Documento"] != null)
            {
                // Application.OpenForms["Frm_Crear_Ventas"].Activate();
                MessageBox.Show("El Form ya está Abierto!", "Abrir Formulario", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); //para que no abra 2 ventanas
            }
            else
            {
                Frm_Explor_Documento doc = new Frm_Explor_Documento();
                doc.MdiParent = this;
                doc.Show();

                if (PanelLateral.Width == 247)
                {
                    PanelLateral.Width = 40;
                    PicUser_2.Visible = true;
                }

            }
        }

        private void Bt_RegistrarGastos_Click(object sender, EventArgs e)
        {
          
        }

        private void Bt_RegistrarOtrosIngresos_Click(object sender, EventArgs e)
        {
          
        }

        private void Bt_VerMovimientoDeCaja_Click(object sender, EventArgs e)
        {
            //Frm_Explor_Caja excaj = new Frm_Explor_Caja();
            //Frm_Filtro fil = new Frm_Filtro();

            //fil.Show();
            //excaj.ShowDialog();
            //fil.Hide();
        }

        private void Bt_VentanaDeFacturación_Click(object sender, EventArgs e)
        {
            Frm_Crear_Ventas ven = new Frm_Crear_Ventas();

            ven.MdiParent = this;
            ven.Show();
        }

        private void Bt_crearUnaCotización_Click(object sender, EventArgs e)
        {
            Frm_Cotizacion coti = new Frm_Cotizacion();

            coti.MdiParent = this;
            coti.Show();
        }

        private void Bt_VerDocumentosEmitidos_Click(object sender, EventArgs e)
        {
        }

        private void Bt_VerCotizacionesEmitidas_Click(object sender, EventArgs e)
        {
            Frm_Explor_cotizacion cot = new Frm_Explor_cotizacion();
            cot.MdiParent = this;
            cot.Show();
        }

        private void bt_VerListadoDeClientes_Click(object sender, EventArgs e)
        {
           
        }

        private void bt_VerExploradorDeProductos_Click(object sender, EventArgs e)
        {
            
        }

        private void Bt_RegistrarUnaCompra_Click(object sender, EventArgs e)
        {
           
        }

        private void Bt_AbrirExploradorDeProveedores_Click(object sender, EventArgs e)
        {
           
        }

        private void Bt_VerCierreDeCaja_Click(object sender, EventArgs e)
        {
            Frm_CerrarCaja caj = new Frm_CerrarCaja();

            caj.MdiParent = this;
            caj.Show();
        }

        private void bt_VerMovimientoDeProductos_Click(object sender, EventArgs e)
        {
          
        }

        private void mantenimientoDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Expl_Proveedor prved = new Frm_Expl_Proveedor();
            prved.MdiParent = this;
            prved.Show();
        }

        private void mantenimientoDistritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Distrito distr = new Frm_Distrito();
            distr.MdiParent = this;
            distr.Show();
        }

        private void Bt_MantenimientoMarca_Click(object sender, EventArgs e)
        {
            Frm_Marca marc = new Frm_Marca();
            marc.MdiParent = this;
            marc.Show();
        }

        private void Bt_MantenimientoCategoria_Click(object sender, EventArgs e)
        {
            Frm_Categoria cate = new Frm_Categoria();
            cate.MdiParent = this;
            cate.Show();
        }

        private void Bt_EditarCorrelativos_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_edit_correlativo co = new Frm_edit_correlativo();

            fil.Show();
            co.ShowDialog();
            fil.Hide();

        }

        private void Bt_EditarTipoDeCambio_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_edit_tipocambio dlr = new Frm_edit_tipocambio();

            fil.Show();
            dlr.ShowDialog();
            fil.Hide();
        }

        private void regcompratoolStripMenuItem15_Click(object sender, EventArgs e)
        {
           
        }

        private void Bt_HacerCierreDeCaja_Click(object sender, EventArgs e)
        {
            Frm_CerrarCaja caj = new Frm_CerrarCaja();

            caj.MdiParent = this;
            caj.Show();
        }

        private void btn_maxim_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }else if(WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void VerComprasACreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reporteProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Frm_ReportProducto re = new Frm_ReportProducto();
            //re.MdiParent = this;
            //re.Show();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reporteComprasMESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Reporte_ComprasMes rex = new Frm_Reporte_ComprasMes();
            rex.MdiParent = this;
            rex.Show();
        }

        private void reimprimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void reimpresiónDeDocumentosDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void editarMiEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_EditEmpresa emp = new Frm_EditEmpresa();

            fil.Show();
            emp.ShowDialog();
            fil.Hide();
        }

        private void Bt_emitirNotaCredito_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_NotaCredito nc = new Frm_NotaCredito();
            
            fil.Show();
            nc.ShowDialog();
            fil.Hide();

        }

        private void Bt_verNotasDeCredito_Click(object sender, EventArgs e)
        {
            Frm_Explorador_notaCreditos nota = new Frm_Explorador_notaCreditos();
            nota.MdiParent = this;
            nota.Show();


        }

        private void bt_enviarNC_aSunat_Click(object sender, EventArgs e)
        {
            Frm_Send_NC_FC nota = new Frm_Send_NC_FC();
            nota.MdiParent = this;
            nota.Show();

        }

        private void bt_enviarResumenASunat_Click(object sender, EventArgs e)
        {
            Frm_ResumenBoleta boleta = new Frm_ResumenBoleta();

            boleta.MdiParent = this;
            boleta.Show();
        }

        private void bt_enviarBajaASunat_Click(object sender, EventArgs e)
        {
            Frm_DarBaja_FE baja = new Frm_DarBaja_FE();
            baja.MdiParent = this;
            baja.Show();
        }

        private void bt_anularDocumento_Click(object sender, EventArgs e)
        {
            frm_AnularDoc doc = new frm_AnularDoc();
            doc.MdiParent = this;
            doc.Show();
        }

        private void reporteVentas_Click(object sender, EventArgs e)
        {
         
        }

        private void registrarAbonos_Click(object sender, EventArgs e)
        {
           
        }

        private void registroDeAbonoDeCreditosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Explor_Credito_Fiados cred = new Frm_Explor_Credito_Fiados();
            cred.MdiParent = this;
            cred.Show();
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void exploradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void bt_mantVehiculos_Click(object sender, EventArgs e)
        {
            Frm_Vehiculos veh = new Frm_Vehiculos();
            veh.MdiParent = this;
            veh.Show();
        }

        private void bt_moduloUsuario_Click(object sender, EventArgs e)
        {
            Frm_Explo_Usuarios us = new Frm_Explo_Usuarios();
            us.MdiParent = this;
            us.Show();
        }

        private void enviarFEASunatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reporteDeVentasPorDíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Frm_Filtro_Fechas rex = new Frm_ReporteVentasFecha();
            //rex.MdiParent = this;
            //rex.Show();
        }

        private void bt_reporte_vusuario_Click(object sender, EventArgs e)
        {
            //Frm_ReporteVentasporDia v = new Frm_ReporteVentasporDia();
            Frm_fechaUser v = new Frm_fechaUser();
            v.MdiParent = this;
            v.Show();
        }

        private void bt_resumen_Click(object sender, EventArgs e)
        {
            //Frm_VentasxUsuario rep = new Frm_VentasxUsuario();
            //rep.MdiParent = this;
            //rep.Show();
        }

        private void limpiarTemporales_Click(object sender, EventArgs e)
        {
            Frm_Sino s = new Frm_Sino();

            s.Lbl_msm1.Text = "Desea eliminar los temporales";
            s.ShowDialog();

            if (s.Tag.ToString() == "Si")
            {
                RN_Temporal obj = new RN_Temporal();
                obj.RN_Eliminar_Temporal_V();
            }
        }

        private void bt_v_Click(object sender, EventArgs e)
        {
            Frm_Crear_Ventas ven = new Frm_Crear_Ventas();



            ven.MdiParent = this;
            ven.Show();
        }

        private void bt_kardexprod_Click(object sender, EventArgs e)
        {
            Frm_Explor_Movim_Prod movprod = new Frm_Explor_Movim_Prod();
         
            movprod.MdiParent = this;
            movprod.Show();
        }

        private void bt_cierreDeCaja_Click(object sender, EventArgs e)
        {
            Frm_CerrarCaja caj = new Frm_CerrarCaja();

            caj.MdiParent = this;
            caj.Show();
        }

        private void verMoviemientoDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Explor_Caja excaj = new Frm_Explor_Caja();
            Frm_Filtro fil = new Frm_Filtro();

            fil.Show();
            excaj.ShowDialog();
            fil.Hide();
        }

        private void bt_resumenCobranza_Click(object sender, EventArgs e)
        {
            Frm_VentasxUsuario rep = new Frm_VentasxUsuario();
            rep.MdiParent = this;
            rep.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Frm_Registrar_Gastos ga = new Frm_Registrar_Gastos();
            Frm_Filtro fil = new Frm_Filtro();

            fil.Show();
            ga.ShowDialog();
            fil.Hide();
        }

        private void bt_otrosingresos_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Reg_otroIngresos ing = new Frm_Reg_otroIngresos();

            fil.Show();
            ing.ShowDialog();
            fil.Hide();
        }

        private void bt_demitido_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Frm_Explor_Documento"] != null)
            {
                // Application.OpenForms["Frm_Crear_Ventas"].Activate();
                MessageBox.Show("El Form ya está Abierto!", "Abrir Formulario", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); //para que no abra 2 ventanas
            }
            else
            {
                Frm_Explor_Documento doc = new Frm_Explor_Documento();
                doc.MdiParent = this;
                doc.Show();

                //if (PanelLateral.Width == 247)
                //{
                //    PanelLateral.Width = 40;
                //    PicUser_2.Visible = true;
                //}

            }

        }

        private void bt_reimpresiones_Click(object sender, EventArgs e)
        {
            Frm_Reimprimir rex = new Frm_Reimprimir();
            rex.MdiParent = this;
            rex.Show();
        }

        private void bt_exploProd_Click(object sender, EventArgs e)
        {
            Frm_Explo_Prod pro = new Frm_Explo_Prod();
            pro.MdiParent = this;
            pro.Show();
        }

        private void bt_compras1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Frm_Compras"] != null)
            {
                // Application.OpenForms["Frm_Crear_Ventas"].Activate();
                MessageBox.Show("El Form ya está Abierto!", "Abrir Formulario", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); //para que no abra 2 ventanas
            }
            else
            {
                Frm_Compras com = new Frm_Compras();
                com.MdiParent = this;
                com.Show();

                //if (PanelLateral.Width == 247)
                //{
                //    PanelLateral.Width = 40;
                //    PicUser_2.Visible = true;
                //}

            }
        }

        private void bt_comprasReg_Click(object sender, EventArgs e)
        {
            Frm_Explor_Compras explo = new Frm_Explor_Compras();

            explo.MdiParent = this;
            explo.Show();
        }

        private void bt_verClientes_Click(object sender, EventArgs e)
        {
            Frm_Explor_Cliente cli = new Frm_Explor_Cliente();
            cli.MdiParent = this;
            cli.Show();
        }

        private void bt_crearprodExp_Click(object sender, EventArgs e)
        {
            Frm_Explo_Prod pro = new Frm_Explo_Prod();
            pro.MdiParent = this;
            pro.Show();
        }

        private void bt_exploProd_Click_1(object sender, EventArgs e)
        {
           

            if (Application.OpenForms["Frm_Explor_Producto"] != null)
            {
                // Application.OpenForms["Frm_Crear_Ventas"].Activate();
                MessageBox.Show("El Form ya está Abierto!", "Abrir Formulario", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); //para que no abra 2 ventanas
            }
            else
            {

                Frm_Explo_Prod pro = new Frm_Explo_Prod();
                pro.MdiParent = this;
                pro.Show();

                //if (PanelLateral.Width == 247)
                //{
                //    PanelLateral.Width = 40;
                //    PicUser_2.Visible = true;
                //}

            }


        }

        private void mantenimientoDeProveedoresToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Frm_Expl_Proveedor prove = new Frm_Expl_Proveedor();
            prove.MdiParent = this;
            prove.Show();
        }

        private void reporteMensualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reportes_Consolidado.Frm_SoloFecha_Vta vt = new Reportes_Consolidado.Frm_SoloFecha_Vta();
            Frm_SoloFecha_Vta v = new Frm_SoloFecha_Vta();
            v.MdiParent = this;
            v.Show();


        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Listado_Produc_IngresoCompras com = new Frm_Listado_Produc_IngresoCompras();
            fil.Show();
            com.ShowDialog();
            fil.Hide();
        }

        private void bt_productosMasVendidos_Click(object sender, EventArgs e)
        {
            Frm_Rpt_Producto_masVendido pr = new Frm_Rpt_Producto_masVendido();
            pr.MdiParent = this;
            pr.Show();
        }

        private void bt_guiaDeTrasladoToolStrip_Click(object sender, EventArgs e)
        {
            Frm_Filtro  fil = new Frm_Filtro();
            Frm_SalidaMercaderia salida = new Frm_SalidaMercaderia();

            fil.Show();
            salida.ShowDialog();
            fil.Hide();

        }

        private void bt_reporteInventarioValorizado_Click(object sender, EventArgs e)
        {
            RN_Productos obj = new RN_Productos();
            RN_Reporte_Kardex_Temporal objre = new RN_Reporte_Kardex_Temporal();
            DataTable data = new DataTable();
            Frm_Print_Informe_Almacen informe = new Frm_Print_Informe_Almacen();
            Frm_Filtro fil = new Frm_Filtro();


            double _stock = 0;
            double _precompra = 0;
            double _compra_xstock = 0;
            double _preventa = 0;
            double _venta_xstock = 0;
            double _utilidad = 0;
            double _utilidad_xstock = 0;
            string id_Prod = "";
            string nomProd = "";
            int count = 0;


            try
            {

                data = obj.RN_Mostrar_Todos_Productos();
                if (data.Rows.Count > 0)
                {
                    objre.RN_Eliminar_Temporal_Kardex(); 

                    for(int i=0; i < data.Rows.Count; i++)
                    {
                        DataRow dr = data.Rows[i];

                        _stock = Convert.ToDouble(dr["Stock_Actual"]);
                        if(_stock > 0)
                        {
                            //siempre que sea mayor a cero se registra
                            id_Prod = dr["Id_Pro"].ToString();
                            nomProd = dr["Descripcion_Larga"].ToString();
                            _precompra = Convert.ToDouble(dr["Pre_Compras"]);
                            _compra_xstock = _precompra * _stock;

                            //ventas:
                            _preventa = Convert.ToDouble(dr["Pre_vntaxMenor"]);
                            _venta_xstock = _preventa * _stock;

                            //utilidad;
                            _utilidad = Convert.ToDouble(dr["UtilidadUnit"]);
                            _utilidad_xstock = _utilidad * _stock;  
                            objre.RN_Registrar_Reporte_Kardex_Temporal(id_Prod,nomProd,_stock,_precompra,_compra_xstock,_preventa,_venta_xstock,_utilidad,_utilidad_xstock,"-");
                            count += 1;
                        }
                    }

                    if(count> 0)
                    {
                        fil.Show();
                        informe.tipoDoc = "kardx_valori";
                        informe.ShowDialog();
                        fil.Hide();
                    }
                }

            }
            catch (Exception ex )
            {

                MessageBox.Show("Error al Consultar: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void ajustesDeInventarioTool_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Ajuste_Inventario_Krdx inv = new Frm_Ajuste_Inventario_Krdx();

            fil.Show();
            inv.ShowDialog();
            fil.Hide();
        }

        private void productosSinRotacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RN_Productos obj = new RN_Productos();
            DataTable dataProd = new DataTable();
            RN_Pedido objPed = new RN_Pedido();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_SoloFecha solo = new Frm_SoloFecha();
            Frm_Print_Informe_Almacen inf = new Frm_Print_Informe_Almacen();



            string idProducto = "";
            DateTime fechaConsulta;

            int cont = 0;

            fil.Show();
            solo.ShowDialog();
            fil.Hide();

            if (solo.Tag.ToString() == "A")
            {
                fechaConsulta = solo.dtp_fecha.Value;

                try
                {
                    dataProd = obj.RN_Mostrar_Todos_Productos();
                    if (dataProd.Rows.Count == 0) return;

                    for(int i = 0; i < dataProd.Rows.Count; i++)
                    {
                        DataRow dr = dataProd.Rows[i];

                        idProducto = dr["Id_Pro"].ToString();

                        if(objPed.RN_Verificar_siProducto_tieneVenta(idProducto.Trim(), fechaConsulta) == false)
                        {
                            obj.RN_Cambiar_campo_estadoReporte(idProducto, "Sinrotacion");
                            cont += 1;
                        }

                    }

                    if(cont > 0)
                    {
                        //se llama imprimir reporte
                        fil.Show();
                        inf.tipoDoc = "sinrota";
                        inf.ShowDialog();
                        fil.Hide();

                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            
        }

        private void bt_actualizacion_Precio_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Editar_precios_compraVenta ed = new Frm_Editar_precios_compraVenta();

            fil.Show();
            ed.ShowDialog();
            fil.Hide();
        }

        private void reportePorMesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bt_reporteGeneral_ventas_xmes_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_SoloFecha solo = new Frm_SoloFecha();
            Frm_Print_Informe_Almacen prin = new Frm_Print_Informe_Almacen();

            fil.Show();
            solo.ShowDialog();
            fil.Hide();

            if(solo.Tag.ToString()== "A")
            {
                DateTime xfecha = solo.dtp_fecha.Value;

                fil.Show();
                prin.fechadia = xfecha;
                prin.tipoDoc = "venta_delmes";
                prin.ShowDialog();
                fil.Hide();
            }
        }

        private void bt_aperturarCaja_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_InicioCaja caja = new Frm_InicioCaja();

            fil.Show();
            caja.ShowDialog();
            fil.Hide();
        }

        private void bt_administradorDeUsuarios_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_RegUsuario us = new Frm_RegUsuario();

            fil.Show();
            us.ShowDialog();
            fil.Hide();
        }

        private void bt_verCierresDeCaja_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Explor_CierreCaja us = new Frm_Explor_CierreCaja();

            fil.Show();
            us.ShowDialog();
            fil.Hide();
        }

        private void ubigeoToolS_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Ubigeo us = new Frm_Ubigeo();

            fil.Show();
            us.ShowDialog();
            fil.Hide();
        }

        private void bt_mantenimientoDeConductores_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Conductores us = new Frm_Conductores();

            fil.Show();
            us.ShowDialog();
            fil.Hide();
        }

        private void bt_mantenimientoDeVehiculos_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Vehiculos us = new Frm_Vehiculos();

            fil.Show();
            us.ShowDialog();
            fil.Hide();
        }

        private void bt_mantenimientoDeTransportista_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_RegTransportista us = new Frm_RegTransportista();

            fil.Show();
            us.ShowDialog();
            fil.Hide();
        }

        private void direccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
          

        }

        private void guiaRemesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void bt_guiaRemisionTransportista_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_GuiaRemision dr = new Frm_GuiaRemision();

            fil.Show();
            dr.ShowDialog();
            fil.Hide();
        }

        private void bt_generarComprobantesMultiplesGuias_Click(object sender, EventArgs e)
        {
            
        }

        private void bt_venta2_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Crear_Ventas_conGR dr = new Frm_Crear_Ventas_conGR();

            fil.Show();
            dr.ShowDialog();
            fil.Hide();
        }

        private void creditosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        
        }

        private void credToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Detalle_TranspCarga_Fact dr = new Frm_Detalle_TranspCarga_Fact();

            //fil.Show();
            //dr.ShowDialog();
            //fil.Hide();
        }

        private void bt_guiaRemisionTrasnsportista_Click(object sender, EventArgs e)
        {
            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_GuiaRem_Transportista dr = new Frm_GuiaRem_Transportista();

            //fil.Show();
            //dr.ShowDialog();
            //fil.Hide();
        }

        private void bt_comprob_multiplesGuias_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Listado_GrTransprt lg = new Frm_Listado_GrTransprt();
            fil.Show();
            lg.ShowDialog();
            fil.Hide();

        }

        private void bt_canales_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Canal cn = new Frm_Canal();
            fil.Show();
            cn.ShowDialog();
            fil.Hide();
        }

        private void bt_direccionesEmpresas_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_DireccionesClientes dr = new Frm_DireccionesClientes();

            fil.Show();
            dr.ShowDialog();
            fil.Hide();
        }

        private void bt_configurarBalanza_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_ConfigBalanza dr = new Frm_ConfigBalanza();

            fil.Show();
            dr.ShowDialog();
            fil.Hide();
        }

        private void bt_promocionesTool_Click(object sender, EventArgs e)
        {
          
        }

        private void bt_consultaDePromocionVentas_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_PromocionVentas pro = new Frm_PromocionVentas();

            fil.Show();
            pro.ShowDialog();
            fil.Hide();
        }

        private void bt_creacionDePromociones_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Promociones pro = new Frm_Promociones();

            fil.Show();
            pro.ShowDialog();
            fil.Hide();
        }

        private void guiaRemisionRemitenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void bt_Emision_GuiaRemi_Rem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_GuiaRemision dr = new Frm_GuiaRemision();

            fil.Show();
            dr.ShowDialog();
            fil.Hide();
        }

        private void presentacionesDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            //Frm_AddEdit_Presentacion dr = new Frm_AddEdit_Presentacion();
            Frm_ProductoPresentaciones prodpr = new Frm_ProductoPresentaciones();

            // 👇 IMPORTANTE
            prodpr.AbrirEnRegistroDirecto = false; // o simplemente no lo pongas

            fil.Show();
            prodpr.ShowDialog();
            fil.Hide();
        }

        private void bt_tomaDeInventarioTool_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_TomaInventario inv = new Frm_TomaInventario();

            fil.Show();
            inv.ShowDialog();
            fil.Hide();
        }

        private void bt_historialDeAjustesinventario_Click(object sender, EventArgs e)
        {
           
        }

        private void bt_corteDeInventarioTool_Click(object sender, EventArgs e)
        {
           
        }

        private void bt_imprimirEtiquetasToolStrip_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_ImprimirEtiquetas eti = new Frm_ImprimirEtiquetas();

            fil.Show();
            eti.ShowDialog();
            fil.Hide();

        }

        private void reporteDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void historialAjusteInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_HistorialAjustesInventario frm = new Frm_HistorialAjustesInventario();
            frm.ShowDialog();
        }

        private void corteDeInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_CorteInventario cort = new Frm_CorteInventario();

            fil.Show();
            cort.ShowDialog();
            fil.Hide();
        }
    }
}
