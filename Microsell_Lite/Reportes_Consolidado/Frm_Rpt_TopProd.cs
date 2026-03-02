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
namespace Microsell_Lite.Reportes_Consolidado
{
    public partial class Frm_Rpt_TopProd : Form
    {
        public Frm_Rpt_TopProd()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_TopProd_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet_Reportes_Consolidado.Sp_Productos_masVendidos' Puede moverla o quitarla según sea necesario.
            this.Sp_Productos_masVendidosTableAdapter.Fill(this.DataSet_Reportes_Consolidado.Sp_Productos_masVendidos, startDate:Convert.ToDateTime( txt_v1.Text), endDate:Convert.ToDateTime( txt_v2.Text));

            this.reportViewer1.RefreshReport();

           
        }



        private void CargarTop_Productos(DateTime start, DateTime end)
        {
            //RN_Productos pr = new RN_Productos();
            //pr.RN_Productos_masVendidos(start, end);

            //this.Sp_Productos_masVendidosTableAdapter.Fill(this.DataSet_Reportes_Consolidado.Sp_Productos_masVendidos);

        }

        private void btn_hoy_Click(object sender, EventArgs e)
        {
            //DateTime fromDate = DateTime.Today;
            //DateTime toDate = DateTime.Now;

        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            ////Frm_Rpt_Ventas oRpt_Ventas = new Frm_Rpt_Ventas();
            //txt_v1.Text = Convert.ToString(dtp_start.Value);
            //txt_v2.Text = Convert.ToString(dtp_end.Value);
            //ShowDialog();
        }
    }
}
