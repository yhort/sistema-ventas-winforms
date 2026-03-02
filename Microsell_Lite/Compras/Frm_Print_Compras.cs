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

namespace Microsell_Lite.Compras
{
    public partial class Frm_Print_Compras : Form
    {
        public DateTime fechainicial;
        public Frm_Print_Compras()
        {
            InitializeComponent();
        }

        public void Imprimir_ReporteCaja()
        {
            // RN_Ingreso_Compra obj = new RN_Ingreso_Compra();
            // DataTable dato = new DataTable();

            //dato = obj.RN_Leer_Caja_porId(this.Tag.ToString());

            //if (dato.Rows.Count > 0)
            //{
            //    Crys_ReporteCierreCaja reporte = new Crys_ReporteCierreCaja();
            //    vsr_compras.ReportSource = reporte;
            //    reporte.SetDataSource(dato);
            //    reporte.Refresh();
            //    vsr_compras.ReportSource = reporte;

            //    //obj.RN_Eliminar_Temporal(this.Tag.ToString());
            //}
        }

     

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Tag = "A";  
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

        private void Frm_Print_Compras_Load(object sender, EventArgs e)
        {
            Rpte_Compras objreport = new Rpte_Compras();
            objreport.SetParameterValue("@Fecha_Mes", fechainicial);
            //objreport.SetParameterValue("@fecha2", fechafinal);

            vsr_compras.ReportSource = objreport;
            

        }

        public void Imprimir_reporte()
        {
           
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            vsr_compras.PrintReport();
        }
    }
}
