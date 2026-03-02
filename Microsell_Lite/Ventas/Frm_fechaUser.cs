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
using Prj_Capa_Datos;
using Prj_Capa_Negocio;

namespace Microsell_Lite.Ventas
{
    public partial class Frm_fechaUser : Form
    {
        public Frm_fechaUser()
        {
            InitializeComponent();
        }

        private void Llenar_Combo_Usuario()
        {
            RN_Usuario obj = new RN_Usuario();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Todos_Usuarios(Convert.ToInt32(Cls_Libreria.Idempresa));
            if (dato.Rows.Count > 0)
            {
                var cbo = cbo_usu;

                cbo.DataSource = dato;
                cbo.DisplayMember = "Usuario";
                cbo.ValueMember = "Id_Usu";
                cbo.SelectedIndex = -1;
            }
        }

     



        private void Frm_ReporteVentasFecha_Load(object sender, EventArgs e)
        {
            Llenar_Combo_Usuario();
        }

      

        private void btnGenerar_Click(object sender, EventArgs e)
        {

            DateTime fechainic = Convert.ToDateTime(dtpfechaInicial.Text);
            DateTime fechafin = Convert.ToDateTime(dtpfechaFinal.Text);
            int user = Convert.ToInt32(cbo_usu.SelectedValue);


            Frm_ReporteFecha_xUsuario frmReportFecha = new Frm_ReporteFecha_xUsuario();
            /*
            

           

            frmReportFecha.Tag = fechainic;
            frmReportFecha.Tag = fechafin;
            frmReportFecha.Imprimir_ReporteVentas();
            frmReportFecha.ShowDialog(); */


            frmReportFecha.user = user;
            frmReportFecha.fechainicial = fechainic;
            frmReportFecha.fechafinal = fechafin;
           

            frmReportFecha.ShowDialog();

            /*
            frmReportFecha.fechafinal = fechainic;
            frmReportFecha.fechafinal = fechafin;*/
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

       
    }
}
