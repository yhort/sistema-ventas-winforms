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

namespace Microsell_Lite.Utilitarios
{
    public partial class Frm_FechasFiltro : Form
    {
        public Frm_FechasFiltro()
        {
            InitializeComponent();
        }

        private void Frm_Filtro_Fechas_Load(object sender, EventArgs e)
        {
            
            DateTime hoy = DateTime.Now;
            dtpfechaInicial.Value = hoy;
            dtpfechaFinal.Value = hoy;
            //Validacion_Fechas();
           
        }
        
        private void Validacion_Fechas()
        {
            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Advertencia ad = new Frm_Advertencia(); 

            //if (dtpfechaInicial.Value > dtpfechaFinal.Value)
            //{
            //    fil.Show();
            //    ad.Lbl_msm1.Text = "La fecha Inicial no puede ser mayor a la fecha Final";
            //    ad.ShowDialog();
            //    fil.Hide();
            //}
        }
        private void btnGenerar_Click_1(object sender, EventArgs e)
        {
            this.Tag = "A";
            this.Close();
           
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

        private void Frm_Filtro_Fechas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
