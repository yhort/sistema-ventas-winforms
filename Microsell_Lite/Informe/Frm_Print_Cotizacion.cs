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

namespace Microsell_Lite.Informe
{
    public partial class Frm_Print_Cotizacion : Form
    {
        public Frm_Print_Cotizacion()
        {
            InitializeComponent();
        }
        private void Frm_Print_Cotizacion_Load(object sender, EventArgs e)
        {
            Crear_Impresion_Cotizacion();
        }

        private void Crear_Impresion_Cotizacion()
        {
            RN_Cotizacion obj = new RN_Cotizacion();
            DataTable Datos = new DataTable();

            Datos = obj.RN_Buscar_Cotizacion_paraEditar(Convert.ToString(this.Tag));
            Rpte_Cotizacion ReportEjemplo = new Rpte_Cotizacion();

            this.Vsr_coti.ReportSource = ReportEjemplo;
            ReportEjemplo.SetDataSource(Datos);
            ReportEjemplo.Refresh();
            Vsr_coti.ReportSource = ReportEjemplo;

        }

      
    }
}
