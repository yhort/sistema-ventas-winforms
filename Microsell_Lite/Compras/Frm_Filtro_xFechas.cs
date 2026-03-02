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

namespace Microsell_Lite.Compras
{
    public partial class Frm_Filtro_xFechas : Form
    {
       
        public Frm_Filtro_xFechas()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {


        }

        private void Frm_ReporteVentasFecha_Load(object sender, EventArgs e)
        {
          
        }

        private void elButton1_Click(object sender, EventArgs e)
        {

            DateTime fechainic = Convert.ToDateTime(dtpfechaInicial.Text);

            Frm_Print_Compras print = new Frm_Print_Compras();

            print.fechainicial = fechainic;

            print.ShowDialog();
           
           
        }

        private void elButton2_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utilitario u = new Utilitario();
                u.Mover_formulario(this);
            }
        }
    }
}
