using Microsell_Lite.Informe;
using Microsell_Lite.Reportes_Consolidado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsell_Lite.Ventas
{
    public partial class Frm_InformesPromociones : Form
    {
        //private DateTime fechaDesde;
        //private DateTime fechaHasta;
        public Frm_InformesPromociones()
        {
            InitializeComponent();
            //this.fechaDesde = desde;
            //this.fechaDesde = hasta;
        }
       
        private void Frm_InformesPromociones_Load(object sender, EventArgs e)
        {
            //rpte_promocionVentas_Detalle reporte = new rpte_promocionVentas_Detalle();

            //reporte.SetParameterValue("@Desde", fechaDesde);
            //reporte.SetParameterValue("@Hasta", fechaHasta);

            //crys_printPromociones.ReportSource = reporte;
            ////reporte.SetDataSource(dato);
            //reporte.Refresh();
            ////vsr_impre.ReportSource = reporte;
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            crys_printPromociones.ExportReport();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            crys_printPromociones.PrintReport();
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            crys_printPromociones.RefreshReport();
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }
    }
}
