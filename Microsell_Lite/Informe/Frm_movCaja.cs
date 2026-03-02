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
    public partial class Frm_movCaja : Form
    {
        public Frm_movCaja()
        {
            InitializeComponent();
        }

        private void Cargar()
        {
            //RN_Caja caj = new RN_Caja();
            //DataTable dt = new DataTable();

            ////dt = caj.RN_Listar_Cajas_Del_Dia();

            ////caj.RN_Listar_Cajas_Del_Dia();

            //rpte_movCaja cj = new rpte_movCaja();

            //cj.SetDataSource(caj.RN_Listar_Cajas_Del_Dia(dtp_fechaIn.Value));
            //this.crvData.ReportSource = cj;
        }

        public void Imprimir_MoviCaja(DateTime nrodoc)
        {
            RN_Caja obj = new RN_Caja();
            RN_Temporal tm = new RN_Temporal();
            DataTable dato = new DataTable();

            //dato = obj.RN_Leer_Temporal_porId(this.Tag.ToString());
            dato = tm.RN_Leer_Temporal_porId(Convert.ToString(nrodoc));

            if (dato.Rows.Count > 0)
            {
                try
                {


                    rpte_movCaja reporte = new rpte_movCaja();
                    this.crvData.ReportSource = reporte;
                    reporte.SetParameterValue("xdia", nrodoc);
                    //reporte.SetDataSource(obj.RN_Listar_Cajas_Del_Dia(nrodoc));
                    reporte.SetDataSource(dato);
                    reporte.Refresh();
                    crvData.ReportSource = reporte;
                    //reporte.PrintToPrinter(1, false, 1, 1); //para impresion directa

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al Exportar PDF: " + ex.Message, "Advertencia de Exportacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                //obj.RN_Eliminar_Temporal(this.Tag.ToString());


            }



        }

        private void btn_cargar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
