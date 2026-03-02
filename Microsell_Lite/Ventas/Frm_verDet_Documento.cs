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

namespace Microsell_Lite.Ventas
{
    public partial class Frm_verDet_Documento : Form
    {
        public Frm_verDet_Documento()
        {
            InitializeComponent();
        }

        private void Frm_verDet_Compra_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Buscar_Det_DocVtas(this.Tag.ToString());
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario ui = new Utilitario();

            if(e.Button == MouseButtons.Left)
            {
                ui.Mover_formulario(this);
            }
            
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Configurar_listView()
        {

            var lis = lsv_det;

            lis.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("ID", 0, HorizontalAlignment.Left); //0
            lis.Columns.Add("Id Prod", 150, HorizontalAlignment.Left); //1
            lis.Columns.Add("Descripcion del Producto", 250, HorizontalAlignment.Left); //2
            lis.Columns.Add("Precio", 90, HorizontalAlignment.Left); //3
            lis.Columns.Add("Cant", 70, HorizontalAlignment.Left);//4
            lis.Columns.Add("Total", 100, HorizontalAlignment.Left);//5

        }


        private void Buscar_Det_DocVtas(string id_Doc)
        {

            RN_Documento obj = new RN_Documento();
            DataTable dato = new DataTable();

            dato = obj.RN_buscar_DocumentosVtas_Detalle(id_Doc.Trim());

            if(dato.Rows.Count > 0)
            {

                lsv_det.Items.Clear();

                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];
                    ListViewItem list = new ListViewItem(dr["id_Doc"].ToString());
                    list.SubItems.Add(dr["Id_Pro"].ToString());
                    list.SubItems.Add(dr["Descripcion_Larga"].ToString());
                    list.SubItems.Add(dr["Precio_conIgv"].ToString());
                    list.SubItems.Add(dr["Cantidad"].ToString());
                    list.SubItems.Add(dr["ImporteconIgv"].ToString());
                    
                    lsv_det.Items.Add(list); //si no ponemos esto,. el listview  nunca se llenara
                }
                //Pintar_Filas();
                //pnl_msm.Visible = false;
                //lbl_totalItem.Text = lsv_com.Items.Count.ToString();

            }

        }



    }
}
