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
using Microsell_Lite.Utilitarios;

namespace Microsell_Lite.Informe
{
    public partial class Frm_Rpte_Ventas : Form
    {
        public Frm_Rpte_Ventas()
        {
            InitializeComponent();
        }

        #region "Metodos"

        private void Listado_Ventas_Dia()
        {
            try
            {

                //Frm_Filtro fil = new Frm_Filtro();
                //Frm_SoloFecha solo = new Frm_SoloFecha();

                    BD_Documento doc = new BD_Documento();
                

                    DateTime valor =dtp_ini.Value;
                    DataTable mitabla = new DataTable();
                    mitabla = doc.BD_Buscador_Documentos_porDia(valor);
                    ReportDataSource fuente = new ReportDataSource("DataSet1", mitabla);
                    rep_view_docvent.LocalReport.DataSources.Clear();
                    rep_view_docvent.LocalReport.DataSources.Add(fuente);
                    rep_view_docvent.LocalReport.ReportEmbeddedResource = "Microsell_Lite.Informe.rpte_doc_ventas.rdlc";
                    rep_view_docvent.LocalReport.Refresh();
                    rep_view_docvent.RefreshReport();

                

                

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void Listado_Ventas_Mes()
        {
            //try
            //{
            //    BD_Documento doc = new BD_Documento();
            //    DateTime valor = dtp_hoy_var.Value;
            //    DataTable mitabla = new DataTable();
            //    mitabla = doc.BD_Buscador_Documentos_porMes(valor);
            //    ReportDataSource fuente = new ReportDataSource("DataSet1", mitabla);
            //    rep_view_docvent.LocalReport.DataSources.Clear();
            //    rep_view_docvent.LocalReport.DataSources.Add(fuente);
            //    rep_view_docvent.LocalReport.ReportEmbeddedResource = "Microsell_Lite.Informe.rpte_doc_ventas.rdlc";
            //    rep_view_docvent.LocalReport.Refresh();
            //    rep_view_docvent.RefreshReport();

            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
        }
        #endregion

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Rpte_Ventas_Load(object sender, EventArgs e)
        {
          
            this.rep_view_docvent.RefreshReport();
        }
    }
}
