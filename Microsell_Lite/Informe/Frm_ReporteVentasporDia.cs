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

namespace Microsell_Lite.Informe
{
    public partial class Frm_ReporteVentasporDia : Form
    {
        public Frm_ReporteVentasporDia()
        {
            InitializeComponent();
        }

        private void Frm_ReporteVentasporDia_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Llenar_Combo_Usuario();
           
        }

        //configurar nuestro listview

        private void Configurar_listView()
        {

            var lis = lsv_Caja;

            lsv_Caja.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            //lis.Columns.Add("ID", 0, HorizontalAlignment.Left); //0
            lis.Columns.Add("Fecha", 150, HorizontalAlignment.Left); //2
            lis.Columns.Add("Total Venta", 150, HorizontalAlignment.Left); //3
            lis.Columns.Add("Total Gncia", 189, HorizontalAlignment.Left); //4
       



        }

        //llenar el listview:

        private void Llenar_Listview(DataTable data)
        {
            lsv_Caja.Items.Clear();
            DateTime FechaCoti;
            double TotalCoti = 0;
            double saldocred = 0;

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                //ListViewItem list = new ListViewItem(dr["Id_Cierre"].ToString());
                ListViewItem list = new ListViewItem(dr["Fecha_Cierre"].ToString());
                list.SubItems.Add(dr["Total_Ingreso"].ToString());
                list.SubItems.Add(dr["TotalEgreso"].ToString());
                list.SubItems.Add(dr["Gananciadelia"].ToString());
                //list.SubItems.Add(dr["Concepto"].ToString());
                //TotalCoti = Convert.ToDouble(dr["ImporteCaja"].ToString());
                //list.SubItems.Add(TotalCoti.ToString("###0.00"));
                ////saldo
                //saldocred = Convert.ToDouble(dr["TotalUti"]);
                //list.SubItems.Add(saldocred.ToString("###0.00"));

                //list.SubItems.Add(dr["TipoPago"].ToString());
                //list.SubItems.Add(dr["GeneradoPor"].ToString());
                //list.SubItems.Add(dr["EstadoCaja"].ToString());

                lsv_Caja.Items.Add(list); //si ponemos esto,. el listview  nunca se llenara
            }
            //Pintar_Filas();
            //pnl_msm.Visible = false;
            //lbl_totalItem.Text = lsv_prodcto.Items.Count.ToString();
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

        
        private void Buscar_Venta(int id, DateTime fechaIni, DateTime fechaFin )
        {
            
            RN_Caja obj = new RN_Caja();
            DataTable dato = new DataTable();

            

            dato = obj.RN_buscador_VentasCajaTotalizado(id,fechaIni,fechaFin);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_Caja.Items.Clear();
                //pnl_msm.Visible = true;
            }

        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime fechainic = dtp_fechIni.Value;
                DateTime fechafin = dtp_fechaFin.Value;


                Buscar_Venta(Convert.ToInt32(cbo_usu.SelectedValue), fechainic, fechafin);
            }
            catch (Exception)
            {

                throw;
            }
            //DateTime fechainic = Convert.ToDateTime(dtp_fechIni.Text);
            //DateTime fechafin = Convert.ToDateTime(dtp_fechaFin.Text);

           


        }

        private void btn_consul2_Click(object sender, EventArgs e)
        {
            try
            {
                //DateTime fechainic = dtp_fechIni.Value;
                //DateTime fechafin = dtp_fechaFin.Value;


                Buscar_Venta(Convert.ToInt32( cbo_usu.SelectedValue), dtp_fechIni.Value, dtp_fechaFin.Value);
            }
            catch (Exception)
            {

                throw;
            }
            //DateTime fechainic = Convert.ToDateTime(dtp_fechIni.Text);
            //DateTime fechafin = Convert.ToDateTime(dtp_fechaFin.Text);
        }
    }
}
