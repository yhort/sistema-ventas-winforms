using Microsell_Lite.Informe;
using Microsell_Lite.Reportes_Consolidado;
using Prj_Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsell_Lite.Ventas
{
    public partial class Frm_PromocionVentas : Form
    {
        public Frm_PromocionVentas()
        {
            InitializeComponent();
        }

        private void CargarPromocionesResumenDesdeNegocio()
        {
            RN_Promocion promoNegocio = new RN_Promocion();
            DataTable tabla = promoNegocio.RN_Buscar_PromocionesVentas_Resumen(dtpDesde_Resumen.Value.Date, dtpHasta_Resumen.Value.Date);

            lsv_resumen.Items.Clear();
            lsv_resumen.Columns.Clear();
            lsv_resumen.View = View.Details;
            lsv_resumen.FullRowSelect = true;
            lsv_resumen.GridLines = true;

            lsv_resumen.Columns.Add("N° Documento", 100);
            lsv_resumen.Columns.Add("Fecha Emisión", 100);
            lsv_resumen.Columns.Add("Nombre de la Promoción", 200);
            lsv_resumen.Columns.Add("Descuento Aplicado", 100);
            lsv_resumen.Columns.Add("Importe Total", 100);
            lsv_resumen.Columns.Add("Total Antes de Descuento", 130);

            foreach (DataRow row in tabla.Rows)
            {
                ListViewItem item = new ListViewItem(row["N° Documento"].ToString());
                item.SubItems.Add(Convert.ToDateTime(row["Fecha Emisión"]).ToShortDateString());
                item.SubItems.Add(row["Nombre de la Promoción"].ToString());
                item.SubItems.Add(Convert.ToDouble(row["Descuento Aplicado"]).ToString("C2"));
                item.SubItems.Add(Convert.ToDouble(row["Importe Total"]).ToString("C2"));
                item.SubItems.Add(Convert.ToDouble(row["Total Antes de Descuento"]).ToString("C2"));

                lsv_resumen.Items.Add(item);
            }
        }

        private void CargarPromos_Detalle()
        {

            RN_Promocion promoNegocio = new RN_Promocion();
            DataTable tabla = promoNegocio.RN_Buscar_PromocionesVentas_Detalle(dtpDesde_Det.Value.Date, dtpHasta_det.Value.Date);

            lsv_Detalle.Items.Clear();
            lsv_Detalle.Columns.Clear();
            lsv_Detalle.View = View.Details;
            lsv_Detalle.FullRowSelect = true;
            lsv_Detalle.GridLines = true;

            lsv_Detalle.Columns.Add("N° Documento", 100);
            lsv_Detalle.Columns.Add("Fecha", 90);
            lsv_Detalle.Columns.Add("Promoción", 200);
            lsv_Detalle.Columns.Add("Producto ID", 100);
            lsv_Detalle.Columns.Add("Producto", 200);
            lsv_Detalle.Columns.Add("Cantidad Promocionada", 80);
            lsv_Detalle.Columns.Add("Precio Especial", 110);
            lsv_Detalle.Columns.Add("Tipo Promo", 120);



            foreach (DataRow row in tabla.Rows)
            {
                ListViewItem item = new ListViewItem(row["N° Documento"].ToString());
                item.SubItems.Add(Convert.ToDateTime(row["Fecha"]).ToShortDateString());
                item.SubItems.Add(row["Promoción"].ToString());
                item.SubItems.Add(row["Producto ID"].ToString());
                item.SubItems.Add(row["Producto"].ToString());
                item.SubItems.Add(Convert.ToDouble(row["Cantidad Promocionada"]).ToString());
                item.SubItems.Add(Convert.ToDouble(row["Precio Especial"]).ToString("C2"));
                item.SubItems.Add(row["Tipo Promo"].ToString());

                lsv_Detalle.Items.Add(item);
            }
          
        }

        private void Imprimir_Reporte_Promociones()
        {
            RN_Promocion promo = new RN_Promocion();
            DataTable datos = promo.RN_Buscar_PromocionesVentas_Detalle(dtpDesde_Det.Value.Date, dtpHasta_det.Value.Date);

            if (datos.Rows.Count > 0)
            {
                rpte_promocionVentas_Detalle rpt = new rpte_promocionVentas_Detalle(); // tu clase Crystal Report
                rpt.SetDataSource(datos);

                Frm_InformesPromociones visor = new Frm_InformesPromociones();
                visor.crys_printPromociones.ReportSource = rpt;
                visor.crys_printPromociones.Refresh();
                visor.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay datos para mostrar.", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void Imprimir_Reporte_Promociones_Resumen()
        {
            RN_Promocion promo = new RN_Promocion();
            DataTable datos = promo.RN_Buscar_PromocionesVentas_Resumen(dtpDesde_Resumen.Value.Date, dtpHasta_Resumen.Value.Date);

            if (datos.Rows.Count > 0)
            {
                rpte_promocionVentas_Resumen rpt = new rpte_promocionVentas_Resumen(); // tu clase Crystal Report
                rpt.SetDataSource(datos);

                Frm_InformesPromociones visor = new Frm_InformesPromociones();
                visor.crys_printPromociones.ReportSource = rpt;
                visor.crys_printPromociones.Refresh();
                visor.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay datos para mostrar.", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExportarListViewAExcel(ListView lvw, string rutaArchivo)
        {
            using (StreamWriter sw = new StreamWriter(rutaArchivo, false, Encoding.UTF8))
            {
                // Escribir encabezados
                string headers = string.Join(",", lvw.Columns.Cast<ColumnHeader>().Select(col => col.Text));
                sw.WriteLine(headers);

                // Escribir filas
                foreach (ListViewItem item in lvw.Items)
                {
                    string row = item.Text;
                    for (int i = 1; i < item.SubItems.Count; i++)
                    {
                        row += "," + item.SubItems[i].Text;
                    }
                    sw.WriteLine(row);
                }
            }

            MessageBox.Show("Exportado a Excel correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnResumen_Click(object sender, EventArgs e)
        {
            CargarPromocionesResumenDesdeNegocio();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            CargarPromos_Detalle();
        }

        private void Frm_PromocionVentas_Load(object sender, EventArgs e)
        {

        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReporteDet_Click(object sender, EventArgs e)
        {
            Imprimir_Reporte_Promociones();
        }

        private void btn_report_resum_Click(object sender, EventArgs e)
        {
            Imprimir_Reporte_Promociones_Resumen();
        }
    }
}
