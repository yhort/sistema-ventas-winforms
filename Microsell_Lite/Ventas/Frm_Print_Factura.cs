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
    public partial class Frm_Print_Factura : Form
    {
        public Frm_Print_Factura()
        {
            InitializeComponent();
        }

        private void Frm_Print_NotaVenta_Load(object sender, EventArgs e)
        {
           Imprimir_Factura_Ticket(this.Tag.ToString());
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


        //private void Imprimir_NotaVenta(string idDoc)
        //{
        //    RN_Temporal obj = new RN_Temporal();
        //    DataTable dato = new DataTable();

        //    dato = obj.RN_Leer_Temporal_porId(idDoc.Trim());

        //    if(dato.Rows.Count > 0)
        //    {
        //        Rpte_Print_NotaVenta reporte = new Rpte_Print_NotaVenta();
        //        vsr_impre.ReportSource = reporte;
        //        reporte.SetDataSource(dato);
        //        reporte.Refresh();
        //        vsr_impre.ReportSource = reporte;

        //        obj.RN_Eliminar_Temporal(this.Tag.ToString());
        //    }
        //}



        private void Imprimir_Factura_Ticket(string idDoc)
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();

            dato = obj.RN_Leer_Temporal_porId(idDoc.Trim());

            if (dato.Rows.Count > 0)
            {
                rpte_print_TicketFactura reporte = new rpte_print_TicketFactura();
                vsr_impre_fac.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre_fac.ReportSource = reporte;

                obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }


        private void btn_Print_Click(object sender, EventArgs e)
        {
            vsr_impre_fac.PrintReport();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            vsr_impre_fac.ExportReport();
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            vsr_impre_fac.RefreshReport();
        }
    }
}
