using Prj_Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Microsell_Lite.Ventas
{
    public partial class Frm_VentasxUsuario : Form
    {
        public Frm_VentasxUsuario()
        {
            InitializeComponent();
        }

        private void Frm_VentasxUsuario_Load(object sender, EventArgs e)
        {
            Llenar_Combo_Usuario();
           Convert.ToDateTime( dtpfechaInicial.Value = DateTime.Now);
           Convert.ToDateTime( dtpfechaFinal.Value = DateTime.Now);
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


        private void Configurar_datagrid_Ventas()
        {

            var per = dgv_ventas;

            per.ColumnCount = 11; //el nro de colummnas que tendra el datagried: el index es cero, por lo tanto , se pondra 10 columns.
            per.ColumnHeadersHeight = 32; //altrua del encabezado
            //per.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            per.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(234, 229, 243); //color whitesomke
            per.BackgroundColor = Color.White; //color de fonodo grid:
            per.BorderStyle = BorderStyle.None;
            per.CellBorderStyle = DataGridViewCellBorderStyle.None; //para que no tenga cuadricula.

            per.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            per.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            per.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(224, 100, 100); //color del encabezado , de esta manera se cambia. //blueviolet-115,85,175
            per.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; //color de texto.
            per.DefaultCellStyle.SelectionBackColor = Color.FromArgb(252, 143, 43); //color de la fila seleccionada.
            //per.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            per.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //textpo se alionea al centro encabezado

            per.ColumnHeadersDefaultCellStyle.Font = new Font(per.Font, FontStyle.Bold);
            per.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 12); //tamaño y tipo fuente
            per.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //permite selccionar toda la fila
            per.MultiSelect = false;
            per.AllowUserToAddRows = false; //evita que se genera la fila vacias adicional...tip grid.

            per.EnableHeadersVisualStyles = false;
            per.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            per.RowHeadersVisible = false; //sirve para ocultar las columnas de la izquierda que se genera por defecto en los grids

            //ponemos los nombres de las columnnas:      
            /*
            per.Columns[0].Name = "Id"; //nombre visual de la columna.
            per.Columns[0].Width = 90; //ancho de las columna.

            //se realizo lo mismo para las columnna q tendra el grid.
            per.Columns[1].Name = "Documento";
            per.Columns[1].Width = 90;
            per.Columns[2].Name = "Fecha Emision";
            per.Columns[2].Width = 100; //cuando es cero.. queremos que la columna este, pero oculta tambien podemos usar la propiedad visible para un mejor efecto.
            per.Columns[2].Visible = true;
            per.Columns[3].Name = "Nombres";
            per.Columns[3].Width = 150;
            per.Columns[3].Visible = false;
            per.Columns[4].Name = "Dni-Ruc";
            per.Columns[4].Width = 90;
            per.Columns[4].Visible = true;
            per.Columns[5].Name = "T.Pago";
            per.Columns[5].Width = 90;
            per.Columns[5].Visible = true;
            per.Columns[6].Name = "Subtotal";
            per.Columns[6].Width = 90;
            per.Columns[7].Name = "Igv";
            per.Columns[7].Width = 90;
            per.Columns[8].Name = "Importe";
            per.Columns[8].Width = 100;*/

            per.Columns[0].Name = "Id"; //nombre visual de la columna.
            per.Columns[0].Width = 90; //ancho de las columna.

            //se realizo lo mismo para las columnna q tendra el grid.
            per.Columns[1].Name = "Documento";
            per.Columns[1].Width = 90;

            per.Columns[2].Name = "Fecha Emision";
            per.Columns[2].Width = 100; //cuando es cero.. queremos que la columna este, pero oculta tambien podemos usar la propiedad visible para un mejor efecto.
            per.Columns[2].Visible = true;

            per.Columns[3].Name = "Nombres";
            per.Columns[3].Width = 150;
            per.Columns[3].Visible = false;
            per.Columns[4].Name = "T.Pago";
            per.Columns[4].Width = 90;
            per.Columns[4].Visible = true;

            per.Columns[5].Name = "Importe";
            per.Columns[5].Width = 100;

            //per.Columns[9].Name = "Importe";
            //per.Columns[9].Width = 100;
            //per.Columns[9].Visible = false;

            //per.Columns[10].Name = "Estado";
            //per.Columns[10].Width = 100;

        }

        //pasamos a llenar el datagriedview: cada vez que llamamos a este metodo.. le daremos la data que llenara:
        private void llenar_Grid_Ventas(DataTable data)
        {
            dgv_ventas.Rows.Clear();
            dgv_ventas.Columns.Clear();
            //como estamos limpiando las columnas y las filas..volveremos a llamar al metodo de configuracion
            //hacemos esto, para que cuando llamamos mas de una vez al metodo.. los datos no se dupliquen.

            Configurar_datagrid_Ventas(); //como arriba se limpia, se coloca el grid metodo.para qye se genere de nuevo.

            for (int i = 0; i < data.Rows.Count; i++)
            {


                DataRow dr = data.Rows[i];
                /*
                string[] row = new string[] { dr["Id_Doc"].ToString(), dr["Documento"].ToString(), dr["Fecha_Emi"].ToString(), dr["Razon_Social_Nombres"].ToString(),
                                                    dr["DNI"].ToString(), dr["TipoPago"].ToString(),dr["subtotal_gravado"].ToString(),
                                                    dr["IgvDoc"].ToString(), dr["ImporteDoc"].ToString()}; //aqui le pasamos todas las columnas*/
                string[] row = new string[] { dr["Idcaja"].ToString(), dr["GeneradoPor"].ToString(), dr["Fecha_Caja"].ToString(), dr["De_Para"].ToString(),
                                                    dr["TipoPago"].ToString(), dr["ImporteCaja"].ToString()}; //aqui le pasamos todas las columnas

                dgv_ventas.Rows.Add(row); //para llenar
                                       //con sus respectivos datos: y asi llenamos una fila, y con el for se llenara de forma automatica, todas las filas segun el contenido del database.
                                       //importante: que los nombres que iran en comillas..seran tal cual esta en la tabla de nuesta bd.
                                       //y en el mismo orden como hemos declarado nuestra columnas:
                                       //probemos, pero antes se hace un metodo mas P_cargar_todos_personal

                /*ahora se agreagra unos botones a las filas*/

            }
            /*
            //desde aqui se añadiran los botones:
            DataGridViewButtonColumn btnquit = new DataGridViewButtonColumn(); // un boton quitar o eliminar  
            dgv_per.Columns.Add(btnquit);
            btnquit.HeaderText = "..."; //si el boton tendra texto o no
            btnquit.Name = "btn_quit"; //el nombre del boton
            btnquit.ToolTipText = "Eliminar Personal";

            //boton editar:
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn(); // un boton quitar o eliminar  
            dgv_per.Columns.Add(btnEdit);
            btnEdit.HeaderText = "..."; //si el boton tendra texto o no
            btnEdit.Name = "btn_Edit"; //el nombre del boton
            btnEdit.ToolTipText = "Editar Personal";
            btnEdit.UseColumnTextForButtonValue = false;
            */

            

            //ahora para ponerlo un icono debemos trabajr en el evento cellpaiting del grid:

        }

        private void Calcular()
        {
            double total = 0;
            double efectivo = 0;
            double yape = 0;
            double plin = 0;
            double tarjeta = 0;
            double mixto = 0;
            

          //  y = Convert.ToString(row.Cells["TipoPago"].Value);

            foreach (DataGridViewRow row in dgv_ventas.Rows)
            {
                if (row.Cells["T.Pago"].Value.ToString() == "Efectivo")
                {
                    efectivo += Convert.ToDouble(row.Cells["Importe"].Value);
                }

                else if (row.Cells["T.Pago"].Value.ToString() == "Yape")
                {
                    yape += Convert.ToDouble(row.Cells["Importe"].Value);
                }
                else if (row.Cells["T.Pago"].Value.ToString() == "Plin")
                {

                    plin += Convert.ToDouble(row.Cells["Importe"].Value);
                }
                else if (row.Cells["T.Pago"].Value.ToString() == "Tarjeta")
                {

                    tarjeta += Convert.ToDouble(row.Cells["Importe"].Value);
                }
                else if (row.Cells["T.Pago"].Value.ToString() == "Mixto")
                {

                    mixto += Convert.ToDouble(row.Cells["Importe"].Value);
                }

                total += Convert.ToDouble(row.Cells["Importe"].Value);

            }

            lblEfectivo.Text = Convert.ToString(efectivo);
            lblYape.Text = Convert.ToString(yape);
            lblPlin.Text = Convert.ToString(plin);
            lblTarjeta.Text = Convert.ToString(tarjeta);
            lblMixto.Text = Convert.ToString(mixto);

             lblTotal.Text = Convert.ToString(total);

        }

        private void buscar_Ventas_porMes(DateTime fechax, DateTime fechax2, int user)
        {
            RN_Documento obj = new RN_Documento();
            DataTable dato = new DataTable();

            dato = obj.RN_Ventas_FecUsuario(fechax,fechax2,user);
            if (dato.Rows.Count > 0)
            {
                llenar_Grid_Ventas(dato);
                
            }
            else
            {
                //lsv_com.Items.Clear();
                //pnl_msm.Visible = true;
            }

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            buscar_Ventas_porMes(Convert.ToDateTime( dtpfechaInicial.Text), Convert.ToDateTime( dtpfechaFinal.Text), Convert.ToInt32( cbo_usu.SelectedValue));
            Calcular();
        }

       

        private void btn_cerrar_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Pnl_Titulo_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario ui = new Utilitario();
            if (e.Button == MouseButtons.Left)
            {
                ui.Mover_formulario(this);
            }
        }
    }
}
