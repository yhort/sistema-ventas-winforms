using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prj_Capa_Datos;
using Prj_Capa_Negocio;
using Microsoft.Reporting.WinForms;

namespace Microsell_Lite.Informe
{
    public partial class Frm_rpt_Productos : Form
    {
        public Frm_rpt_Productos()
        {
            InitializeComponent();
        }

        #region "Metodos"

        private void Listado()
        {
            try
            {
                BD_Productos pro = new BD_Productos();
                string valor = txt_valor.Text;
                DataTable mitabla = new DataTable();
                mitabla = pro.BD_Buscar_Productos(valor);
                ReportDataSource fuente = new ReportDataSource("DataSet1", mitabla);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add( fuente);
                reportViewer1.LocalReport.ReportEmbeddedResource = "Microsell_Lite.Informe.rpt_tod_prod.rdlc";
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();
                
            }
            catch (Exception ex )
            {

                throw;
            }
        }

        #endregion

        private void Frm_rpt_Productos_Load(object sender, EventArgs e)
        {
            this.Listado();
            //this.reportViewer1.RefreshReport();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
           // reportViewer1.ReportExport();
        }
    }
}
