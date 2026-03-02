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

namespace Microsell_Lite.Informe
{
    public partial class Frm_Print_Informe : Form
    {
        public Frm_Print_Informe()
        {
            InitializeComponent();
        }

        public string tipoDoc = "";

        private void Frm_Print_Informe_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }

        //private void Imprimir_Kardex_Valorizado()
        //{
        //    RN_Reporte_Kardex_Temporal obj = new RN_Reporte_Kardex_Temporal();
        //    DataTable data = new DataTable();

        //    data = obj.RN_Listar_Temporal_Kardex();

        //    if(data.Rows.Count > 0)
        //    {
        //        //Crys_Inventario_Valorizado;
        //    }
        //}
    }
}
