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
using Microsell_Lite.Utilitarios;

namespace Microsell_Lite.Informe
{
    public partial class Frm_Reporte_ComprasMes : Form
    {
        public Frm_Reporte_ComprasMes()
        {
            InitializeComponent();


        }

        private void Frm_Reporte_ComprasMes_Load(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_SoloFecha solo = new Frm_SoloFecha();

            fil.Show();
            solo.ShowDialog();
            fil.Hide();

            if (solo.Tag.ToString() == "A")
            {
                DateTime xfecha = solo.dtp_fecha.Value;

                Imprimir_Reporte_ComprasMes(xfecha);
            }
        }

        private void Imprimir_Reporte_ComprasMes(DateTime fechax)
        {
            /* RN_Ingreso_Compra obj = new RN_Ingreso_Compra();
             DataTable dato = new DataTable();

             dato = obj.RN_buscar_Compras_Explorador_Pormes_Dia("mes" , fechax);

            Frm_Filtro filx = new Frm_Filtro();
            Frm_SoloFecha f = new Frm_SoloFecha();
            Rpte_ComprasMes repCom = new  Rpte_ComprasMes();

            filx.Show();
            f.ShowDialog();
            filx.Hide();*/
            Frm_SoloFecha solo = new Frm_SoloFecha();

            RN_Documento obj = new RN_Documento();
            DataTable dato = new DataTable();


            dato = obj.RN_Buscador_Documentos_porMes(Convert.ToDateTime(this.Tag));
            Rpte_ComprasMes ReportEjemplo = new Rpte_ComprasMes();

            this.vsr_CompMes.ReportSource = ReportEjemplo;
            ReportEjemplo.SetParameterValue(0, solo.dtp_fecha );
            ReportEjemplo.Refresh();
            vsr_CompMes.ReportSource = ReportEjemplo;
            




            //if (dato.Rows.Count > 0)
            //{
            //    rpte_print_TicketNota reporte = new rpte_print_TicketNota();
            //    vsr_impre.ReportSource = reporte;
            //    reporte.SetDataSource(dato);
            //    reporte.Refresh();
            //    vsr_impre.ReportSource = reporte;

            //    obj.RN_Eliminar_Temporal(this.Tag.ToString());
            //}
        }

       
    }
}
