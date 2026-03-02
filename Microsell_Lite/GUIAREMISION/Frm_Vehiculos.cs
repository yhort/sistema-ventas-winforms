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
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using Microsell_Lite.Utilitarios;

namespace Microsell_Lite.GUIAREMISION
{
    public partial class Frm_Vehiculos : Form
    {
        public Frm_Vehiculos()
        {
            InitializeComponent();
        }

        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_todas_lasMarcas();
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void Configurar_listView()
        {
            var lis = lsv_marca;

            lsv_marca.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las colummnas:
            lis.Columns.Add("ID", 40, HorizontalAlignment.Left); //0      
            lis.Columns.Add("Num Placa", 100, HorizontalAlignment.Left); //1
            lis.Columns.Add("Autorizacion placa Principal", 180, HorizontalAlignment.Left); //2
            lis.Columns.Add("T.U.C", 120, HorizontalAlignment.Left); //3
            lis.Columns.Add("Num Placa Secundaria", 170, HorizontalAlignment.Left); //4
            lis.Columns.Add("Autorizacion placa secundaria", 165, HorizontalAlignment.Left); //5
            lis.Columns.Add("T.U.C placa secundaria", 100, HorizontalAlignment.Left); //6
            lis.Columns.Add("Modelo", 100, HorizontalAlignment.Left); //7
            lis.Columns.Add("Marca", 100, HorizontalAlignment.Left); //8
            lis.Columns.Add("TUC", 200, HorizontalAlignment.Left); //9
           
        }

        private void Llenar_Listview(DataTable data)
        {

            lsv_marca.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_vehiculo"].ToString());                
                list.SubItems.Add(dr["veh_placa"].ToString());
                list.SubItems.Add(dr["veh_MtcPrincipal"].ToString());
                list.SubItems.Add(dr["veh_TUC"].ToString());
                list.SubItems.Add(dr["veh_placaSec"].ToString());
                list.SubItems.Add(dr["veh_MtcSecund"].ToString());
                list.SubItems.Add(dr["veh_TUC_Secun"].ToString());
                list.SubItems.Add(dr["veh_modelo"].ToString());
                list.SubItems.Add(dr["veh_marca"].ToString());
                list.SubItems.Add(dr["veh_TUC"].ToString());
                lsv_marca.Items.Add(list); //si no ponemos esto , el listview nunca se llenara               
            }
        }

        private void Cargar_todas_lasMarcas()
        {

            RN_Vehiculo obj = new RN_Vehiculo();
            DataTable dato = new DataTable();

            dato = obj.RN_Mostrar_Todos_Vehiculo();
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_marca.Items.Clear();
            }
        }

        private void buscar_Marca(string valor ,string estado)
        {
            RN_Vehiculo obj = new RN_Vehiculo();
            DataTable dato = new DataTable();

            dato = obj.RN_Cargar_Vehiculo_xEstado(valor,estado);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_marca.Items.Clear();
            }
        }

        public bool editar = false;
        private void btn_add_Click(object sender, EventArgs e)
        {
            pnl_add.Visible = true;
            txt_placa.Focus();
            editar = false;
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno(); 

            RN_Vehiculo obj = new RN_Vehiculo();
            EN_Vehiculo veh = new EN_Vehiculo();

            //if (Validar_cajasText() == true)
            //{
            //    if (editar == false)
            //    {
            //        if (editar == true)
            //        {
            //            Editar_Vehiculo();
            //        }
            //        else
            //        {
            //            Registrar_Vehiculo();
            //        }
            //    }
            //}

            //if (txt_modelo.Text.Trim().Length < 0) { MessageBox.Show("Ingresa el modelo ", "Registrar Vehiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            //este algoritmo sirve para guardar incluido los nulls;
            if(Validar_cajasText() == true)
            {
                if (editar == false)
                {
                    //Nuevo:
                    //obj.RN_Registrar_Marcas(txt_modelo.Text);
                    veh.Vehmodelo = txt_modelo.Text;
                    veh.Vehplaca = txt_placa.Text;
                    veh.Vehfechacre = dtp_fecha.Value;
                    veh.Vehmarca = txt_marcaVehiculo.Text;
                    veh.VehTuc = txt_TUC.Text;
                    veh.Veh_mtc_principal = txt_mtc_placaPrincipal.Text;
                    veh.Veh_placa_secund = txt_placaSecund.Text;
                    veh.Veh_mtc_secund = txt_mtc_secund.Text;
                    veh.Veh_tuc_secund = txt_TUC_Secun.Text;

                    obj.RN_Registrar_Vehiculo(veh);
                    fil.Show();
                    ok.Lbl_msm1.Text = "Vehiculo registrado exitosamente";
                    ok.ShowDialog();
                    fil.Hide();                
                    pnl_add.Visible = false;
                    Cargar_todas_lasMarcas();
                    limpiarForm();
                }
                else
                {
                    //Editar:
                    veh.Idveh = Convert.ToInt32(txt_idvehiculo.Text); // ID del vehículo para edición
                    veh.Vehmodelo = txt_modelo.Text;
                    veh.Vehplaca = txt_placa.Text;
                    veh.Vehmarca = txt_marcaVehiculo.Text;
                    veh.VehTuc = txt_TUC.Text;
                    veh.Veh_mtc_principal = txt_mtc_placaPrincipal.Text;
                    veh.Veh_placa_secund = txt_placaSecund.Text;
                    veh.Veh_mtc_secund = txt_mtc_secund.Text;
                    veh.Veh_tuc_secund = txt_TUC_Secun.Text;

                    try
                    {
                        obj.RN_Editar_Vehiculo(veh);
                        fil.Show();
                        ok.Lbl_msm1.Text = "Vehiculo editado exitosamente";
                        ok.ShowDialog();
                        fil.Hide();
                        //MessageBox.Show("Vehículo editado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pnl_add.Visible = false;
                        Cargar_todas_lasMarcas();
                        limpiarForm();
                        editar = false;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error al editar el vehículo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
           
        }
        private void limpiarForm()
        {
            //txt_idproducto.Text = "";
            txt_modelo.Text = "";
            txt_placa.Text = "";
            txt_TUC.Text = "";
            txt_mtc_placaPrincipal.Text = "";
            txt_placaSecund.Text = "";
            txt_TUC_Secun.Text = "";
            txt_mtc_secund.Text = "";
            txt_marcaVehiculo.Text = "";
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (lsv_marca.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Selecciona el Item para Editar", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {

                var lsv = lsv_marca.SelectedItems[0];
                txt_idvehiculo.Text = lsv.SubItems[0].Text;
                txt_modelo.Text = lsv.SubItems[7].Text;
                txt_placa.Text = lsv.SubItems[1].Text;
                txt_mtc_placaPrincipal.Text = lsv.SubItems[2].Text;
                txt_TUC.Text = lsv.SubItems[3].Text;
                txt_placaSecund.Text = lsv.SubItems[4].Text;
                txt_mtc_secund.Text = lsv.SubItems[5].Text;
                txt_TUC_Secun.Text = lsv.SubItems[6].Text;
                txt_marcaVehiculo.Text = lsv.SubItems[8].Text;

                pnl_add.Visible = true;
                txt_modelo.Focus();
                editar = true;

            }
        }

        private void Registrar_Vehiculo()
        { /*
            RN_Vehiculo obj = new RN_Vehiculo();
            EN_Vehiculo vehed = new EN_Vehiculo();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

            try
            {
                //vehed.Idveh = Convert.ToInt32(txt_idvehiculo.Text);
                vehed.Vehmodelo = txt_modelo.Text;
                vehed.Veh_placa_secund = txt_placa.Text;
                vehed.Vehfechacre = dtp_fecha.Value;
                vehed.Vehmarca = txt_marcaVehiculo.Text;
                vehed.VehTuc = txt_TUC.Text;
                vehed.Veh_mtc_principal = txt_mtc_placaPrincipal.Text;
                vehed.Veh_placa_secund = txt_placaSecund.Text;
                vehed.Veh_tuc_secund = txt_TUC_Secun.Text;
                vehed.Veh_mtc_secund = txt_mtc_secund.Text;

                obj.RN_Registrar_Vehiculo(vehed);

                if (BD_Vehiculo.saved == true)
                {
                    fil.Show();
                    ok.Lbl_msm1.Text = "El Vehiculo se ha Registrado Exitosamente";
                    ok.ShowDialog();
                    fil.Hide();

                    limpiarForm();
                    pnl_add.Visible = false;
                    Cargar_todas_lasMarcas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Leer los Datos: " + ex.Message, "Form Add veh", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }*/
        }
        
        private void Editar_Vehiculo()
        {

            RN_Vehiculo obj = new RN_Vehiculo();
            EN_Vehiculo vehed = new EN_Vehiculo();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

            try
            {
                vehed.Idveh = Convert.ToInt32(txt_idvehiculo.Text);
                vehed.Vehmodelo = txt_modelo.Text;
                vehed.Veh_placa_secund = txt_placa.Text;
                vehed.Vehmarca = txt_marcaVehiculo.Text;
                vehed.VehTuc = txt_TUC.Text;
                vehed.Veh_mtc_principal = txt_mtc_placaPrincipal.Text;
                vehed.Veh_placa_secund = txt_placaSecund.Text;
                vehed.Veh_tuc_secund = txt_TUC_Secun.Text;
                vehed.Veh_mtc_secund = txt_mtc_secund.Text;
                

                obj.RN_Editar_Vehiculo(vehed);

                if (BD_Vehiculo.edited == true)
                {
                    fil.Show();
                    ok.Lbl_msm1.Text = "El Vehiculo se ha Actualizado Exitosamente";
                    ok.ShowDialog();
                    fil.Hide();

                    limpiarForm();
                    pnl_add.Visible = false;
                    Cargar_todas_lasMarcas();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Leer los Datos: " + ex.Message, "Form Add veh", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool Validar_cajasText()
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            //if (txt_id.Text.Trim().Length == 0) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa id"; ver.ShowDialog(); fil.Hide(); return false; }
            if (txt_placa.Text == "") { fil.Show(); ver.Lbl_msm1.Text = "Ingresa el número de placa"; ver.ShowDialog(); fil.Hide(); txt_placa.Focus(); return false; }
            if (txt_modelo.Text == "") { fil.Show(); ver.Lbl_msm1.Text = "Ingresa el modelo"; ver.ShowDialog(); fil.Hide(); txt_modelo.Focus(); return false; }
            if (txt_marcaVehiculo.Text == "") { fil.Show(); ver.Lbl_msm1.Text = "Ingresa la marca del vehiculo"; ver.ShowDialog(); fil.Hide(); txt_marcaVehiculo.Focus(); return false; }
            //if (txtLicencia.Text == "") { fil.Show(); ver.Lbl_msm1.Text = "Ingresa la licencia del Conductor"; ver.ShowDialog(); fil.Hide(); txtLicencia.Focus(); return false; }

            return true;

        }

        //metodo para eliminar las marcas, cuando no esta asiganado a un producto

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (lsv_marca.SelectedIndices.Count == 0)
            {

                MessageBox.Show("Selecciona el Item para Eliminar", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {

                var lsv = lsv_marca.SelectedItems[0];
                txt_idvehiculo.Text = lsv.SubItems[0].Text;

                Frm_Filtro fil = new Frm_Filtro();  
                Frm_Sino sino = new Frm_Sino();

                fil.Show();
                sino.Lbl_msm1.Text = "¿Estas Seguro de eliminar el vehiculo?";
                sino.ShowDialog();
                fil.Hide();

                if (sino.Tag.ToString() == "Si")
                {
                    RN_Vehiculo obj = new RN_Vehiculo();
                    obj.RN_Eliminar_Vehiculo(Convert.ToInt32(txt_idvehiculo.Text));
                    Cargar_todas_lasMarcas();
                }
            }
        }
        private void btn_Selecc_Click(object sender, EventArgs e)
        {
            if (lsv_marca.SelectedIndices.Count == 0)
            {

                MessageBox.Show("Selecciona un vehiculo", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                var lsv = lsv_marca.SelectedItems[0];
                txt_idvehiculo.Text = lsv.SubItems[0].Text;
                this.Tag = "A";
                //this.Close();
            }
        }
        private void lsv_marca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Selecc_Click(sender, e);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            pnl_add.Visible = false;
            limpiarForm();
        }

        private void bt_delete_Click_1(object sender, EventArgs e)
        {

        }
        private void lsv_marca_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsv_marca.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar un Vehiculo", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                txt_idvehiculo.Text = lsv_marca.SelectedItems[0].SubItems[0].Text;
                txt_modelo.Text = lsv_marca.SelectedItems[0].SubItems[7].Text;
                txt_placa.Text = lsv_marca.SelectedItems[0].SubItems[1].Text;
                txt_placaSecund.Text = lsv_marca.SelectedItems[0].SubItems[4].Text;
                txt_marcaVehiculo.Text = lsv_marca.SelectedItems[0].SubItems[8].Text;

                this.Tag = "A";
                this.Close();

            }
        }

        private void txt_buscar_OnValueChanged(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                buscar_Marca(txt_buscar.Text, "Activo");
            }
        }

        //funcion tecla enter
        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {

                if (txt_buscar.Text.Trim().Length > 2)
                {
                    buscar_Marca(txt_buscar.Text, "Activo");
                }
                else
                {
                    Cargar_todas_lasMarcas();
                }
        }//fin

        private void pnl_add_Click(object sender, EventArgs e)
        {

        }

        private void txt_placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite letras y números, y la tecla de retroceso para borrar
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si el carácter no es una letra, ni un número, ni una tecla de control,
                // cancela el evento para que el carácter no aparezca en el TextBox.
                e.Handled = true;
            }
            // Verifica que la longitud no supere los 8 caracteres
            if (txt_placa.Text.Length >= 6 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;  // Evita que se agregue más de 8 caracteres
            }
        }

        private void txt_mtc_secund_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite letras y números, y la tecla de retroceso para borrar
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si el carácter no es una letra, ni un número, ni una tecla de control,
                // cancela el evento para que el carácter no aparezca en el TextBox.
                e.Handled = true;
            }

        }

        private void txt_TUC_Secun_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite letras y números, y la tecla de retroceso para borrar
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si el carácter no es una letra, ni un número, ni una tecla de control,
                // cancela el evento para que el carácter no aparezca en el TextBox.
                e.Handled = true;
            }
        }

        private void txt_placaSecund_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite letras y números, y la tecla de retroceso para borrar
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si el carácter no es una letra, ni un número, ni una tecla de control,
                // cancela el evento para que el carácter no aparezca en el TextBox.
                e.Handled = true;
            }
            if (txt_placaSecund.Text.Length >= 6 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;  // Evita que se agregue más de 8 caracteres
            }
        }
    }
}
