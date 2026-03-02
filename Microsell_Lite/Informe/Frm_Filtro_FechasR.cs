using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Prj_Capa_Negocio;

namespace Microsell_Lite.Informe
{
    public partial class Frm_Filtro_FechasR : Form
    {
        public Frm_Filtro_FechasR()
        {
            InitializeComponent();
        }


        private void Cargar()
        {
            //Fechas objReporte = new Fechas();

            RN_Documento objReporte = new RN_Documento();
            DataTable dato = new DataTable();

            dato = objReporte.RN_Buscador_Fechas(dtp_Inicio.Value.Date, dtp_Final.Value.Date);

            //objReporte.SetParameterValue("@Inicial", dtp_Inicio.Value.Date);
            //objReporte.SetParameterValue("@Final", dtp_Final.Value.Date);


            //objReporte.se(dato);
            //objReporte.Refresh();
            //crv_informe.ReportSource = objReporte;
            /*Fechas reporte = new Fechas();
            crv_informe.ReportSource = reporte;
            reporte.SetDataSource(dato);
            reporte.Refresh();
            crv_informe.ReportSource = reporte;*/

            //if (dato.Rows.Count > 0)
            //{
               

            //   // objReporte.RN_Buscador_Fechas(this.Tag.ToString());
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}
