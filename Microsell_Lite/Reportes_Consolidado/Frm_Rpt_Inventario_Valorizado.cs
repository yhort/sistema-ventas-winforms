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
    public partial class Frm_Rpt_Inventario_Valorizado : Form
    {
        public Frm_Rpt_Inventario_Valorizado()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Inventario_Valorizado_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet_Reportes_Consolidado.sp_Listar_Temporal_ReportKardex' Puede moverla o quitarla según sea necesario.
            this.sp_Listar_Temporal_ReportKardexTableAdapter.Fill(this.dataSet_Reportes_Consolidado.sp_Listar_Temporal_ReportKardex);

            this.reportViewer1.RefreshReport();
        }
    }
}
