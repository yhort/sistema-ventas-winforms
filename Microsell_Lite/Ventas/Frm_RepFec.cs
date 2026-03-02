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

namespace Microsell_Lite.Ventas
{
    public partial class Frm_RepFec : Form
    {

        public DateTime fechainicial;
        public DateTime fechafinal;
        public Frm_RepFec()
        {
            InitializeComponent();
        }

        private void Frm_RepFechas_Load(object sender, EventArgs e)
        {           

        }

        private void Frm_RepFec_Load(object sender, EventArgs e)
        {



            //ReporteFechasVentas objreport = new ReporteFechasVentas();
            R objreport = new R();
            objreport.SetParameterValue("@fecha", fechainicial);
            objreport.SetParameterValue("@fecha2", fechafinal);

            CrystalReportViewer1.ReportSource = objreport;


        }

        

        public void Imprimir_ReporteVentas()
        {
      
            /*

             RN_Documento obj = new RN_Documento();
             DataTable dato = new DataTable();

               dato = obj.RN_Ventas_por_RagoFechas(fechainicial,fechafinal);


            //if (dato.Rows.Count > 0)
            //{
                Reporte_RangoFechas reporte = new Reporte_RangoFechas();
                CrystalReportViewer1.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                CrystalReportViewer1.ReportSource = reporte;
            //}*/
        }

        private void buscar_Documento_pordia(DateTime fechaxini, DateTime fechafin)
        {

            /*
            RN_Documento obj = new RN_Documento();
            DataTable dato = new DataTable();

            dato = obj.RN_Ventas_por_RagoFechas(fechaxini, fechafin);
            if (dato.Rows.Count > 0)
            {
                Reporte_RangoFechas reporte = new Reporte_RangoFechas();
                CrystalReportViewer1.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                CrystalReportViewer1.ReportSource = reporte;
            }
            else
            {
              
            }*/

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Tag = "A";
            this.Close();
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            CrystalReportViewer1.PrintReport();
        }
    }
}
