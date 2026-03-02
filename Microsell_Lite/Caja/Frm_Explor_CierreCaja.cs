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
using Microsell_Lite.Cotizacion;
using Microsell_Lite.Informe;
using System.IO;


namespace Microsell_Lite.Caja
{
    public partial class Frm_Explor_CierreCaja : Form
    {
        public Frm_Explor_CierreCaja()
        {
            InitializeComponent();
           
        }

        private void Frm_Explor_CierreCaja_Load(object sender, EventArgs e)
        {
            yacargo = true;

            Configurar_listView();
            Configurar_listView_Usuario();
            //Cargar_Todos_losUsuarios();
            Cargar_TodoCierre_Caja();
            //Llenar_Combo_Usuario();
        }

       
        //configurar nuestro listview

        private void Configurar_listView()
        {



            var lis = lsv_prodcto;

            lsv_prodcto.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("ID", 90, HorizontalAlignment.Left); //0
            lis.Columns.Add("Fecha.", 100, HorizontalAlignment.Left); //2
            lis.Columns.Add("Vendedor", 150, HorizontalAlignment.Left); //3
            lis.Columns.Add("Inicio", 0, HorizontalAlignment.Left); //4
            lis.Columns.Add("Total Gastos", 0, HorizontalAlignment.Left);//5
            lis.Columns.Add("Utilidad", 0, HorizontalAlignment.Left);//5
            lis.Columns.Add("Entregado", 0, HorizontalAlignment.Right);//5
            lis.Columns.Add("Saldo Sgte.", 0, HorizontalAlignment.Right);//5
            lis.Columns.Add("Vnta. Factura", 100, HorizontalAlignment.Left);//5
            lis.Columns.Add("Vnta. Boleta", 100, HorizontalAlignment.Left);//5
            lis.Columns.Add("Vnta. Notas", 100, HorizontalAlignment.Left);//5
            lis.Columns.Add("Vnta. Credito", 0, HorizontalAlignment.Left);//5
            lis.Columns.Add("Vnta. Tarjeta", 100, HorizontalAlignment.Left);//5
            lis.Columns.Add("Total Venta", 100, HorizontalAlignment.Left);//5
            lis.Columns.Add("Estado Cierre", 110, HorizontalAlignment.Left);//5




        }

        //llenar el listview:

        private void Llenar_Listview(DataTable data)
        {
            lsv_prodcto.Items.Clear();
            DateTime FechaCierre;
            double TotalCierre = 0;
            double saldocred = 0;
            double TotalCierre2 = 0;

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_cierre"].ToString());
                FechaCierre = Convert.ToDateTime(dr["Fecha_Cierre"]);
                list.SubItems.Add(FechaCierre.ToString("dd/MM/yyyy"));


                list.SubItems.Add(dr["Nombres"].ToString());
                list.SubItems.Add(dr["Apertura_Caja"].ToString());
                list.SubItems.Add(dr["TotalEgreso"].ToString());
                list.SubItems.Add(dr["Gananciadeldia"].ToString());

                //saldo

                saldocred = Convert.ToDouble(dr["TotalEntregado"].ToString());
                list.SubItems.Add(saldocred.ToString("###0.00"));


                list.SubItems.Add(dr["SaldoSiguiente"].ToString());
                list.SubItems.Add(dr["TotalFactura"].ToString());
                list.SubItems.Add(dr["TotalBoleta"].ToString());
                list.SubItems.Add(dr["TotalNotaVenta"].ToString());
                list.SubItems.Add(dr["TotalCreditoEmitido"].ToString());
                list.SubItems.Add(dr["TodoDeposito"].ToString());

                TotalCierre = Convert.ToDouble(dr["Total_Ingreso"]);
                list.SubItems.Add(TotalCierre.ToString("###0.00"));

                list.SubItems.Add(dr["Estado_cierre"].ToString());

                lsv_prodcto.Items.Add(list); //si ponemos esto,. el listview  nunca se llenara
                TotalCierre2 = TotalCierre2 + TotalCierre;
            }
            Pintar_Filas();
            pnl_msm.Visible = false;
            lbl_totalICierre.Text = lsv_prodcto.Items.Count.ToString();
            lbl_IngreTotalCierre.Text = TotalCierre2.ToString("###0.00");
        }


        private void Configurar_listView_Usuario()
        {

            var lis = lsv_usu;

            lsv_usu.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;

            //configuracion de colummnas
            lis.Columns.Add("ID", 40, HorizontalAlignment.Left);
            lis.Columns.Add("Nombres ", 250, HorizontalAlignment.Left);
            lis.Columns.Add("Apellido ", 250, HorizontalAlignment.Left);
            lis.Columns.Add("Distrito ", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Usu Login", 120, HorizontalAlignment.Left);
            lis.Columns.Add("Clave", 100, HorizontalAlignment.Left);
            lis.Columns.Add("Rol", 120, HorizontalAlignment.Left);
            lis.Columns.Add("Empresa", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Estado", 100, HorizontalAlignment.Left);



        }

        private void Llenar_ListView_Usuario(DataTable data)
        {
            lsv_usu.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Usu"].ToString());
                list.SubItems.Add(dr["Nombres"].ToString());
                list.SubItems.Add(dr["Apellidos"].ToString());
                list.SubItems.Add(dr["Id_Dis"].ToString());
                list.SubItems.Add(dr["Usuario"].ToString());
                list.SubItems.Add(dr["Contraseña"].ToString());
                list.SubItems.Add(dr["Id_Rol"].ToString());
                list.SubItems.Add(dr["idempresa"].ToString());
                list.SubItems.Add(dr["Estado_Usu"].ToString());

                lsv_usu.Items.Add(list);

            }

        }

        private void Pintar_Filas()
        {
            int cont = 1;

            for (int i=0; i < lsv_prodcto.Items.Count; i++)
            {
                if (cont % 2 == 0)
                {

                }
                else
                {
                    lsv_prodcto.Items[i].BackColor = Color.WhiteSmoke;
                }
                cont += 1;
            }
        }

        private void Llenar_Combo_Usuario(int idusu4)
        {
            RN_Usuario obj = new RN_Usuario();
            DataTable dato = new DataTable();

            

            dato = obj.RN_Buscar_Usuario_xIds(idusu4, idempresa);
            if (dato.Rows.Count > 0)
            {
                var cbo = cbo_usu_ci;

                cbo.DataSource = dato;
                cbo.DisplayMember = "Nombres";
                cbo.ValueMember = "Id_Usu";
                cbo.SelectedIndex = -1;
            }
        }

        public int idempresa = Cls_Libreria.Idempresa;
        private void Cargar_Todos_losUsuarios()
        {
            RN_Usuario obj = new RN_Usuario();
            DataTable data = new DataTable();

            data = obj.RN_Listar_Todos_Usuarios(idempresa);
            if (data.Rows.Count > 0)
            {
                Llenar_ListView_Usuario(data);
            }
            else
            {
                lsv_usu.Items.Clear();
            }

        }


        private void Cargar_TodoCierre_Caja()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();


            dato = obj.RN_Listar_Todas_CierresCaja();
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_prodcto.Items.Clear();
                pnl_msm.Visible = true;
            }

        }

        private void buscar_cierre_pordia(DateTime fechax, string estado)
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Cierre_Caja_delDia(fechax, estado);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_prodcto.Items.Clear();
                pnl_msm.Visible = true;
            }

        }

        private void buscar_cierrexMes(DateTime fechax)
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Cierre_Caja_delMes(fechax);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_prodcto.Items.Clear();
                pnl_msm.Visible = true;
            }

        }


        private void buscar_Cierre_Caja_xUsuario(int usu)
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Cierre_Caja_xUsuario(usu);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_prodcto.Items.Clear();
                pnl_msm.Visible = true;
            }

        }


        private void buscar_Cierre_Caja_xUsuarioMes(int idusu, DateTime xfecha)
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Cierre_Caja_xUsuarioMes(idusu, xfecha);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_prodcto.Items.Clear();
                pnl_msm.Visible = true;
            }

        }
        private void txt_buscar_OnValueChanged(object sender, EventArgs e)//se agrego como el frm_explor_cliente cambio actualizado. vid.#15
        {
           //if(txt_buscar.Text.Trim().Length > 2)
           // {
           //     buscar_Caja_porvalor(txt_buscar.Text);
           // }
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e) //se agrego como el frm_explor_cliente cambio actualizado.
        {

        }

        private void txt_buscar_OnValueChanged_1(object sender, EventArgs e)
        {
         

        }

        private void elLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bt_copiarIDProveedorTool_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (lsv_prodcto.SelectedIndices .Count == 0)
            {
                fil.Show();
                ver.Lbl_msm1.Text = "Selecciona el Item que desees copiar";
                ver.ShowDialog();
                fil.Hide();

            }
            else
            {

                var lis = lsv_prodcto.SelectedItems[0];
                string idprovee = lis.SubItems[0].Text;

                Clipboard.Clear();
                Clipboard.SetText(idprovee.Trim());


            }
        }

    

        private void bt_add_Click(object sender, EventArgs e)
        {
            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Add_Producto ad = new Frm_Add_Producto();
            

            //fil.Show();
            //ad.ShowDialog();
            //fil.Hide();

            //if (ad.Tag.ToString() =="A")
            //{
            //    Cargar_Todos_Cajas();

            //}
        }

        private void toolStripSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void bt_nuevoProveedorTool_Click(object sender, EventArgs e)
        {
            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_AddProductos ad = new Frm_AddProductos();

            //fil.Show();
            //ad.ShowDialog();
            //fil.Hide();

            //if (ad.Tag.ToString() == "A")
            //{
            //    Cargar_Todos_Cajas();

            //}

        }

        private void bt_edit_Click(object sender, EventArgs e)
        {

        }

        private void editarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bt_edit_Click(sender, e);
        }

        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cargar_Todos_Cajas();
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
            //this.WindowState = FormWindowState.Maximized;
        }

        private void btn_cerrar_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_cerrar_Click_2(object sender, EventArgs e)
        {

        }

        private void bt_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_minimi_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bt_edit1_Click(object sender, EventArgs e)
        {

            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Addver ver = new Frm_Addver();
            //Frm_Edit_Producto edi = new Frm_Edit_Producto();

            //if (lsv_prodcto.SelectedIndices.Count == 0)
            //{
            //    fil.Show();
            //    ver.Lbl_Msm1.Text = "Selecciona el Item que desees Editar";
            //    ver.ShowDialog();
            //    fil.Hide();

            //}
            //else
            //{

            //    var lis = lsv_prodcto.SelectedItems[0];
            //    string idprod = lis.SubItems[0].Text;

            //    fil.Show();
            //    edi.Tag = idprod;
            //    edi.ShowDialog();
            //    fil.Hide();

            //    if (edi.Tag.ToString() == "A")
            //    {
            //        Cargar_Todos_Cajas();
            //    }


            //}
        }

        private void txt_buscar1_KeyDown(object sender, KeyEventArgs e)
        {
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (txt_buscar1.Text.Trim().Length > 2)
        //        {
        //            buscar_Caja_porvalor(txt_buscar1.Text);
        //        }
        //        else
        //        {
        //            Cargar_Todos_Cajas();
        //        }
        //    }
        }

        private void txt_buscar1_OnValueChanged(object sender, EventArgs e)
        {
            //if (txt_buscar1.Text.Trim().Length > 2)
            //{
            //    buscar_Caja_porvalor(txt_buscar1.Text);

            //}
        }

        private void lsv_prodcto_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void btn_ExpExcel_Click(object sender, EventArgs e)
        {

            //Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            //app.Visible = true;
            //Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);

            //Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];


            //int linea = 2, columna = 1;

            //ws.Cells[1, 1] = lsv_prodcto.Columns[0].Text;
            //ws.Cells[1, 2] = lsv_prodcto.Columns[1].Text;
            //ws.Cells[1, 3] = lsv_prodcto.Columns[2].Text;
            //ws.Cells[1, 4] = lsv_prodcto.Columns[3].Text;
            //ws.Cells[1, 5] = lsv_prodcto.Columns[4].Text;
            //ws.Cells[1, 6] = lsv_prodcto.Columns[5].Text;
            //ws.Cells[1, 7] = lsv_prodcto.Columns[6].Text;
            //ws.Cells[1, 8] = lsv_prodcto.Columns[7].Text;
            //ws.Cells[1, 9] = lsv_prodcto.Columns[8].Text;
            //ws.Cells[1, 10] = lsv_prodcto.Columns[9].Text;
            //ws.Cells[1, 11] = lsv_prodcto.Columns[10].Text;




            //foreach (ListViewItem list in lsv_prodcto.Items)
            //{
            //    columna = 1;
            //    foreach (ListViewItem.ListViewSubItem lvs in list.SubItems)
            //    {
            //        ws.Cells[linea, columna] = lvs.Text;
            //        columna++;
            //    }
            //    linea++;
            //}

        }

        private void btn_print_Click(object sender, EventArgs e)
        {
           // Frm_movCaja cja = new Frm_movCaja();
           // Frm_Filtro fil = new Frm_Filtro();

           //// Frm_SoloFecha fec = new Frm_SoloFecha();

           // fil.Show();
           // cja.Tag = dtp_hoy.Value;
           // cja.Imprimir_MoviCaja(dtp_hoy.Value);
           // fil.Hide();

           
          

        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            //Frm_SoloFecha solo = new Frm_SoloFecha();

            //fil.Show();

            //DateTime xfecha = dtp_hoy.Value;
            //buscar_movCaja_pordia(dtp_hoy.Value);

            //fil.Hide();

           

               

            
        }

        private void btn_verCierre_delDia_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_SoloFecha solo = new Frm_SoloFecha();

            fil.Show();
            solo.ShowDialog();
            fil.Hide();

            if (solo.Tag.ToString() == "A")
            {
                DateTime fecha2 = solo.dtp_fecha.Value;
                buscar_cierre_pordia(fecha2, "Cerrado");
            }
        }

        private void btnCierrexMes_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Solousu_Fecha solo = new Frm_Solousu_Fecha();

            fil.Show();
            solo.ShowDialog();
            fil.Hide();

            if (solo.Tag.ToString() == "A")
            {
                DateTime fecha1 = solo.dtp_fecha.Value;
                int idusu1 = Convert.ToInt32(solo.cbo_usu.SelectedValue);
                buscar_Cierre_Caja_xUsuarioMes(idusu1,fecha1);
            }
        }

        bool yacargo = false;
        private void cbo_usu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////metodo para no lag:
            //if (yacargo == false) return;
            //if (cbo_usu_ci.SelectedIndex == -1)
            //{

            //}
            //else
            //{
            //    int idusu3 = Convert.ToInt32(cbo_usu_ci.SelectedValue);
            //    buscar_Cierre_Caja_xUsuario(idusu3);
            //}



        }

        private void cbo_user2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (yacargo == false) return;
            if (cbo_user2.SelectedIndex == -1)
            {

            }
            else
            {
                int idusu3 = Convert.ToInt32(cbo_user2.SelectedValue);
                buscar_Cierre_Caja_xUsuario(idusu3);
            }



        }
    }
}
