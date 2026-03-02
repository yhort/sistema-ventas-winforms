using Microsell_Lite.Utilitarios;
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
    public partial class Frm_Filtro_Fechas : Form
    {
        public Frm_Filtro_Fechas()
        {
            InitializeComponent();
        }
        private void Frm_ReporteVentasFecha_Load(object sender, EventArgs e)
        {
          
        }

        private void btnGenerar_Click_1(object sender, EventArgs e)
        {

            DateTime fechainic = Convert.ToDateTime(dtpfechaInicial.Text);
            DateTime fechafin = Convert.ToDateTime(dtpfechaFinal.Text);

            Frm_RepFec frmReportFecha = new Frm_RepFec();
            /*

            frmReportFecha.Tag = fechainic;
            frmReportFecha.Tag = fechafin;
            frmReportFecha.Imprimir_ReporteVentas();
            frmReportFecha.ShowDialog(); */
            frmReportFecha.fechainicial = fechainic;
            frmReportFecha.fechafinal = fechafin;
            frmReportFecha.ShowDialog();

            /*
            frmReportFecha.fechafinal = fechainic;
            frmReportFecha.fechafinal = fechafin;*/
        }

        private void btn_closed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnl_titulo_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }
    }
}
