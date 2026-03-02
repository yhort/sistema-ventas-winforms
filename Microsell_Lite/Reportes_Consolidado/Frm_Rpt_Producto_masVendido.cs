using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsell_Lite.Reportes_Consolidado
{
    public partial class Frm_Rpt_Producto_masVendido : Form
    {
        public Frm_Rpt_Producto_masVendido()
        {
            InitializeComponent();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            Frm_Rpt_TopProd oRpt_tprod = new Frm_Rpt_TopProd();
            oRpt_tprod.txt_v1.Text = Convert.ToString(dtp_start.Value);
            oRpt_tprod.txt_v2.Text = Convert.ToString(dtp_end.Value);
            oRpt_tprod.ShowDialog();
        }
    }
}
