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
using CrystalDecisions.Shared;
using Microsell_Lite.Caja;
using Prj_Capa_Datos;

namespace Microsell_Lite.Informe
{
    public partial class Frm_Print_Informe_GuiaRemision : Form
    {
        public Frm_Print_Informe_GuiaRemision()
        {
            InitializeComponent();
        }

        public string NroDoc = "";
        public string tipoDoc= "";
        public string modalidad_traslado = "";
        public DateTime fechadia;
        private void Frm_Print_NotaVenta_Load(object sender, EventArgs e)
        {
            if (tipoDoc.Trim() == "Guia Remision-Charlote")
            {
                Imprimir_Informe_GuiaR_Rem_TextilCharlotte(NroDoc);
            }
            if (tipoDoc.Trim() == "Guia Remision-Lucero")
            {
                Imprimir_Informe_GuiaR_Rem_Impor_TextilLucero(NroDoc);
            }
            if (tipoDoc.Trim() == "Guia Remision-Rcp")
            {
                Imprimir_Informe_GuiaR_Rem_Rcp(NroDoc);
            }
        }
        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Imprimir_Informe_SalidaAlmacen(string idDoc)
        {
            RN_Ingreso_Compra obj = new RN_Ingreso_Compra();
            DataTable dato = new DataTable();

            dato = obj.RN_buscar_Compras_conDetalle(idDoc.Trim());

            if (dato.Rows.Count > 0)
            {
                Rpte_Salida_Almacen reporte = new Rpte_Salida_Almacen();
                vsr_impre_gr.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre_gr.ReportSource = reporte;

              
            }
        }
        private void Imprimir_productos_sinRotacion()
        {
            RN_Productos obj = new RN_Productos();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_todos_los_Productos_sinRotacion("Sinrotacion");

            if (dato.Rows.Count > 0)
            {
                Rpte_Productos_SinRotacion reporte = new Rpte_Productos_SinRotacion();
                vsr_impre_gr.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre_gr.ReportSource = reporte;


            }
        }
        private void Imprimir_ReporteCaja(string NroDoc)
        {
            RN_Caja obj = new RN_Caja();
            DataTable dato = new DataTable();

            dato = obj.RN_Leer_Caja_porId(NroDoc);

            if (dato.Rows.Count > 0)
            {
                Crys_ReporteCierreCaja ticket = new Crys_ReporteCierreCaja();
                vsr_impre_gr.ReportSource = ticket;
                ticket.SetDataSource(dato);
                ticket.Refresh();
                vsr_impre_gr.ReportSource = ticket;

                //obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        private void Imprimir_ReporteGeneral_Ventas_xMes()
        {
            RN_Documento obj = new RN_Documento();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscador_Documentos_porMes(fechadia);

            if (dato.Rows.Count > 0)
            {
                Rpte_Ventas_delMes ticket = new Rpte_Ventas_delMes();
                vsr_impre_gr.ReportSource = ticket;
                ticket.SetDataSource(dato);
                ticket.Refresh();
                vsr_impre_gr.ReportSource = ticket;

                //obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        private void Imprimir_Kardex_Valorizado()
        {
            RN_Reporte_Kardex_Temporal obj = new RN_Reporte_Kardex_Temporal();
            DataTable data = new DataTable();
            data = obj.RN_Listar_Temporal_Kardex();
            if (data.Rows.Count > 0)
            {
                Crys_Inventario_Valorizado kr = new Crys_Inventario_Valorizado();
                vsr_impre_gr.ReportSource = kr;
                kr.SetDataSource(data);
                kr.Refresh();
                vsr_impre_gr.ReportSource = kr;
            }
        }

        public string Rutdapdf;
        public void Imprimir_Informe_GuiaR_Rem_TextilCharlotte(string idDoc)
        {
            BD_GuiaRemision obj = new BD_GuiaRemision();
            DataTable dato = new DataTable();
            dato = obj.BD_Buscador_DocumentoGR_Detalle_porID(idDoc.Trim());

            if (dato.Rows.Count > 0)
            {
                if (modalidad_traslado == "02")
                {
                    Cry_Gr_Rem_TextChar_Privado reporte = new Cry_Gr_Rem_TextChar_Privado();
                    vsr_impre_gr.ReportSource = reporte;
                    reporte.SetDataSource(dato);
                    reporte.Refresh();
                    vsr_impre_gr.ReportSource = reporte;
                }
                else
                {
                    Cry_Gr_Rem_ticket reporte = new Cry_Gr_Rem_ticket();
                    vsr_impre_gr.ReportSource = reporte;
                    reporte.SetDataSource(dato);
                    reporte.Refresh();
                    vsr_impre_gr.ReportSource = reporte;
                }
            }
        }
        public void Imprimir_Informe_GuiaR_Rem_Impor_TextilLucero(string idDoc)
        {
            BD_GuiaRemision obj = new BD_GuiaRemision();
            DataTable dato = new DataTable();
            dato = obj.BD_Buscador_DocumentoGR_Detalle_porID(idDoc.Trim());

            if (dato.Rows.Count > 0)
            {
                if (modalidad_traslado == "02")
                {
                    Cry_Gr_Rem_TextLucero_Privado reporte = new Cry_Gr_Rem_TextLucero_Privado();
                    vsr_impre_gr.ReportSource = reporte;
                    reporte.SetDataSource(dato);
                    reporte.Refresh();
                    vsr_impre_gr.ReportSource = reporte;
                }
                else
                {
                    Cry_Gr_Rem_Import_TextilLucero_ticket reporte = new Cry_Gr_Rem_Import_TextilLucero_ticket();
                    vsr_impre_gr.ReportSource = reporte;
                    reporte.SetDataSource(dato);
                    reporte.Refresh();
                    vsr_impre_gr.ReportSource = reporte;
                }
            }
        }

        public void Imprimir_Informe_GuiaR_Rem_Rcp(string idDoc)
        {
            BD_GuiaRemision obj = new BD_GuiaRemision();
            DataTable dato = new DataTable();
            dato = obj.BD_Buscador_DocumentoGR_Detalle_porID(idDoc.Trim());

            if (dato.Rows.Count > 0)
            {
                if (modalidad_traslado == "02")
                {
                    Cry_Gr_Rem_Rcp_priv reporte = new Cry_Gr_Rem_Rcp_priv();
                    vsr_impre_gr.ReportSource = reporte;
                    reporte.SetDataSource(dato);
                    reporte.Refresh();
                    vsr_impre_gr.ReportSource = reporte;
                }
                else
                {
                    Cry_Gr_Rem_Rcp reporte = new Cry_Gr_Rem_Rcp();
                    vsr_impre_gr.ReportSource = reporte;
                    reporte.SetDataSource(dato);
                    reporte.Refresh();
                    vsr_impre_gr.ReportSource = reporte;
                }
            }
        }
        private void btn_Print_Click(object sender, EventArgs e)
        {
            vsr_impre_gr.PrintReport();
        }
        private void btn_export_Click(object sender, EventArgs e)
        {
            vsr_impre_gr.ExportReport();
        }
        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            vsr_impre_gr.RefreshReport();
            
        }
    }
}
