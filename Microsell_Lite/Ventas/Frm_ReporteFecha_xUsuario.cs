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
    public partial class Frm_ReporteFecha_xUsuario : Form
    {

        public DateTime fechainicial;
        public DateTime fechafinal;
        public int user;
        public Frm_ReporteFecha_xUsuario()
        {
            InitializeComponent();
        }

        private void Frm_ReporteFecha_xUsuario_Load(object sender, EventArgs e)
        {

            //ReporteVentas_xUsuario objreport = new ReporteVentas_xUsuario();
          
            rpte_ventasxUsuario objreport = new rpte_ventasxUsuario();

            objreport.SetParameterValue("@user", user);
            objreport.SetParameterValue("@fecha", fechainicial);
            objreport.SetParameterValue("@fecha2", fechafinal);
           
            //opcional cuando solicite login rpte
            objreport.SetDatabaseLogon("srvcaps", "srvcaps");
            crpw_reportfecha_usu.ReportSource = objreport;
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
            crpw_reportfecha_usu.PrintReport();
        }

        private void pnl_titu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            crpw_reportfecha_usu.ExportReport();
        }
    }
}
