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

namespace Microsell_Lite.Caja
{
    public partial class Frm_Print_ReporteCaja : Form
    {
        public Frm_Print_ReporteCaja()
        {
            InitializeComponent();
        }

        public void Imprimir_ReporteCaja()
        {
             RN_Caja obj = new RN_Caja();
             DataTable dato = new DataTable();

            dato = obj.RN_Leer_Caja_porId(this.Tag.ToString());

            if (dato.Rows.Count > 0)
            {
                Crys_ReporteCierreCaja reporte = new Crys_ReporteCierreCaja();
                vsr_imprecaja.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_imprecaja.ReportSource = reporte;

                //obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }

        public void Imprimir_ReporteCaja_Hoja()
        {

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        private void pnl_titu_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void pnl_titu_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            vsr_imprecaja.PrintReport();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            vsr_imprecaja.ExportReport();
        }
    }
}
