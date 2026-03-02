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
using Microsell_Lite.Productos;
using Microsell_Lite.Compras;
using Microsell_Lite.Ventas;



namespace Microsell_Lite.Ventas
{
    public partial class Frm_Explor_Credito_Fiados : Form
    {
        public Frm_Explor_Credito_Fiados()
        {
            InitializeComponent();
           
        }

        private void Frm_Explor_Credito_Fiados_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            buscar_doc_creditos_pordia(dtp_hoy.Value); //para que solo cargue las ventas del dia.en el form
        }

        //private void Frm_Explor_Documento_Load(object sender, EventArgs e)
        //{
           
        //}



        //configurar nuestro listview

        private void Configurar_listView()
        {

            var lis = lsv_creditos;

            lsv_creditos.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("ID Credito.", 140, HorizontalAlignment.Left); //0
            lis.Columns.Add("Fecha Emi", 100, HorizontalAlignment.Left); //1
            lis.Columns.Add("Nombre del Cliente", 300, HorizontalAlignment.Left); //2
            lis.Columns.Add("Total Cred", 90, HorizontalAlignment.Left); //3
            lis.Columns.Add("Saldo Pdnte", 90, HorizontalAlignment.Left);//4
            lis.Columns.Add("Fecha Vencim.", 100, HorizontalAlignment.Left);//5
            lis.Columns.Add("Estado Credit.", 0, HorizontalAlignment.Left);//6
            lis.Columns.Add("Doc refe.", 120, HorizontalAlignment.Left);//7
            lis.Columns.Add("Fecha", 0, HorizontalAlignment.Left);//8




        }

        //llenar el listview:

        private void Llenar_Listview(DataTable data)
        {
            lsv_creditos.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["IdNotaCred"].ToString());
                list.SubItems.Add(dr["Fecha_Credito"].ToString());
                list.SubItems.Add(dr["Nom_Cliente"].ToString());
                list.SubItems.Add(dr["Total_Cre"].ToString());
                list.SubItems.Add(dr["Saldo_Pdnte"].ToString());
                list.SubItems.Add(dr["Fecha_Vncimnto"].ToString());
                list.SubItems.Add(dr["Estado_Cred"].ToString());
                list.SubItems.Add(dr["id_Doc"].ToString());
                list.SubItems.Add(dr["Fecha_Emi"].ToString());  
                lsv_creditos.Items.Add(list); //si no ponemos esto,. el listview  nunca se llenara
            }
            //Pintar_Filas();
            pnl_msm.Visible = false;
            lbl_totalItem.Text = lsv_creditos.Items.Count.ToString();
        }

        //private void Pintar_Filas()
        //{
        //    int cont = 1;

        //    for (int i=0; i < lsv_com.Items.Count; i++)
        //    {
        //        if (cont % 2 == 0)
        //        {

        //        }
        //        else
        //        {
        //            lsv_com.Items[i].BackColor = Color.WhiteSmoke;
        //        }
        //        cont += 1;
        //    }
        //}

        private void Cargar_Todos_Creditos()
        {
            RN_Credito obj = new RN_Credito();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Todas_Creditos();
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);

            }
            else
            {
                lsv_creditos.Items.Clear();
                pnl_msm.Visible = true;
            }

        }

        private void buscar_Docu_Creditos(string valor)
        {
            RN_Credito obj = new RN_Credito();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_creditos_porValor(valor);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_creditos.Items.Clear();
                pnl_msm.Visible = true;
            }

        }

        //por fecha
        private void buscar_doc_creditos_pordia(DateTime fechax)
        {
            RN_Credito obj = new RN_Credito();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscador_Doc_Creditos_porDia(fechax);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_creditos.Items.Clear();
                pnl_msm.Visible = true;
            }

        }

        //por mes:


        private void buscar_doc_creditos_porMes(DateTime fechax)
        {
            RN_Credito obj = new RN_Credito();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscador_Doc_Creditos_porMes(fechax);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_creditos.Items.Clear();
                pnl_msm.Visible = true;
            }

        }


        private void txt_buscar_OnValueChanged(object sender, EventArgs e)//se agrego como el frm_explor_cliente cambio actualizado. vid.#15
        {
           //if(txt_buscar.Text.Trim().Length > 2) ACTIVADO KEYDOWN 1
           // {
           //     buscar_Docu_Ventas(txt_buscar.Text);
           // }
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e) //se agrego como el frm_explor_cliente cambio actualizado.
        {

            if(e.KeyCode == Keys.Enter)   //se agrego if e.keycode.. se puede quitar tbm clas 36 min 15:44
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    buscar_Docu_Creditos(txt_buscar.Text);
                }
                else
                {
                    Cargar_Todos_Creditos();
                }
            }
        

            

        }

        private void txt_buscar_OnValueChanged_1(object sender, EventArgs e) //hay 2 onvaluechaged validar funcion en propiedades
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                buscar_Docu_Creditos(txt_buscar.Text);

            } 

        }

        private void elLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bt_copiarIDProveedorTool_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();

            if (lsv_creditos.SelectedIndices .Count == 0)
            {
                fil.Show();
                ver.Lbl_Msm1.Text = "Selecciona el Item que desees copiar";
                ver.ShowDialog();
                fil.Hide();

            }
            else
            {

                var lis = lsv_creditos.SelectedItems[0];
                string idprovee = lis.SubItems[0].Text;

                Clipboard.Clear();
                Clipboard.SetText(idprovee.Trim());


            }
        }

    

      

        private void toolStripSeparator2_Click(object sender, EventArgs e)
        {

        }

        

       
        
        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Todos_Creditos();
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if(e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);
            }
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btn_cerrar_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_cerrar_Click_2(object sender, EventArgs e)
        {

        }

        private void bt_cerrar_Click(object sender, EventArgs e)
        {
            //this.Tag = "";
            this.Close();
        }

        private void elLabel14_Click(object sender, EventArgs e)
        {

        }

        private void cargarComprasDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_SoloFecha solo = new Frm_SoloFecha();

            fil.Show();
            solo.ShowDialog();
            fil.Hide();

            if (solo.Tag.ToString() == "A")
            {
                DateTime xfecha = solo.dtp_fecha.Value;

                buscar_doc_creditos_pordia(xfecha);
            }
        }

        private void buscarComprasDelMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_SoloFecha solo = new Frm_SoloFecha();

            fil.Show();
            solo.ShowDialog();
            fil.Hide();

            if (solo.Tag.ToString() == "A")
            {
                DateTime xfecha = solo.dtp_fecha.Value;

                buscar_doc_creditos_porMes(xfecha);
            }
        }

        private void lsv_com_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void bt_reimprimirDocumentoTool_Click(object sender, EventArgs e)
        {

            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Addver ver = new Frm_Addver();
            //Frm_Crear_Ventas ven = new Frm_Crear_Ventas();

            //if (lsv_creditos.SelectedIndices.Count == 0)
            //{
            //    fil.Show();
            //    ver.Lbl_Msm1.Text = "Selecciona el Item que deseas Reimprimir";
            //    ver.ShowDialog();
            //    fil.Hide();

            //}
            //else
            //{

            //    var lis = lsv_creditos.SelectedItems[0];
            //    string iddoc = lis.SubItems[0].Text;

            //    fil.Show();
            //    ven.txt_buscar.Text = iddoc;
            //    ven.ShowDialog();
            //    fil.Hide();

            //}

        }

        private void agregarAbono_Click(object sender, EventArgs e)
        {

        }

        private void bt_addAbono_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();
            Frm_Reg_AbonosdeCredito edi = new Frm_Reg_AbonosdeCredito();

            if (lsv_creditos.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.Lbl_Msm1.Text = "Selecciona el Item que desees agregar";
                ver.ShowDialog();
                fil.Hide();

            }
            else
            {

                var lis = lsv_creditos.SelectedItems[0];
                string idclie = lis.SubItems[0].Text;

                fil.Show();
                edi.Tag = idclie;
                edi.ShowDialog();
                fil.Hide();

                if (edi.Tag.ToString() == "A")
                {
                    Cargar_Todos_Creditos();
                }


            }
        }

        private void Frm_Explor_Credito_Fiados_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            
        }

        private void lsv_creditos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();
            Frm_verDet_Compra edi = new Frm_verDet_Compra();

            if (lsv_creditos.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.Lbl_Msm1.Text = "Selecciona el Item";
                ver.ShowDialog();
                fil.Hide();

            }
            else
            {

                var lis = lsv_creditos.SelectedItems[0];
                string idcompra = lis.SubItems[0].Text;

                fil.Show();
                edi.Tag = idcompra;
                edi.ShowDialog();
                fil.Hide();

            }

        }
    }
}
