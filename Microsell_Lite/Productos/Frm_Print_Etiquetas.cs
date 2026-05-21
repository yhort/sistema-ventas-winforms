using CrystalDecisions.CrystalReports.Engine;
using Prj_Capa_Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;


namespace Microsell_Lite.Productos
{
    public partial class Frm_Print_Etiquetas : Form
    {
        public Frm_Print_Etiquetas()
        {
            InitializeComponent();
        }

        public DataTable dtEtiquetas = new DataTable();
        private void Frm_Print_Etiquetas_Load(object sender, EventArgs e)
        {
            Imprimir_Etiquetas();
        }
        private void Imprimir_Etiquetas()
        {
            try
            {
                if (dtEtiquetas == null || dtEtiquetas.Rows.Count == 0)
                {
                    MessageBox.Show("No hay etiquetas para imprimir.",
                        "Etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Rpt_Etiquetas reporte = new Rpt_Etiquetas();

                crystalReportViewer1.ReportSource = reporte;
                reporte.SetDataSource(dtEtiquetas);
                reporte.Refresh();
                crystalReportViewer1.ReportSource = reporte;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir etiquetas: " + ex.Message,
                    "Etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void CargarReporte(DataTable dtEtiquetas)
        {
            try
            {
                ReportDocument rpt = new ReportDocument();

                string ruta = Application.StartupPath + @"\Productos\Rpt_Etiquetas.rpt";

                rpt.Load(ruta);
                rpt.SetDataSource(dtEtiquetas);

                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reporte de etiquetas: " + ex.Message,
                    "Etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

       
    }
}
