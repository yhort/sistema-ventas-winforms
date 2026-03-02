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

namespace Microsell_Lite.Utilitarios
{
    public partial class Frm_edit_correlativo : Form
    {
        public Frm_edit_correlativo()
        {
            InitializeComponent();
        }

        private void btn_cancelPago_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();

        }

        private void btn_Generar_Click(object sender, EventArgs e)
        {

            RN_TipoDoc obj = new RN_TipoDoc();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

            if (txt_id.Text.Trim().Length == 0) { fil.Show(); ver.Lbl_msm1.Text = "Falta el ID del Documento"; ver.ShowDialog(); fil.Hide(); Cbo_Docs.Focus(); return; }
            if (txt_serie.Text.Trim().Length == 0) { fil.Show(); ver.Lbl_msm1.Text = "Falta la Serie del Documento"; ver.ShowDialog(); fil.Hide(); txt_serie.Focus(); return; }
            if (txt_num.Text.Trim().Length < 5) { fil.Show(); ver.Lbl_msm1.Text = "Falta el Nro del Documento"; ver.ShowDialog(); fil.Hide(); txt_num.Focus(); return; }

            obj.RN_editar_Nro_Correlativo(Convert.ToInt32(txt_id.Text), lbl_nom.Text, txt_serie.Text, txt_num.Text);

            if (BD_Tipo_Doc.saved == true)
            {
                fil.Show();
                ok.Lbl_msm1.Text = "Los Cambios se han Guardado correctamente";
                ok.ShowDialog();
                fil.Hide();

                txt_serie.Text = "";
                txt_num.Text = "";
                txt_id.Text  = "";

                pnl_edit.Enabled = false;
                btn_Generar.Enabled = false;

            }

        }

        private void pnl_titulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button ==MouseButtons.Left )
            {
                Utilitario u = new Utilitario();
                u.Mover_formulario(this);
            }

        }

        private void Frm_SoloFecha_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void Frm_SoloFecha_Load(object sender, EventArgs e)
        {
           
        }

        bool yacargo = false;
        private void Frm_edit_correlativo_Load(object sender, EventArgs e)
        {
            Cargar_TipoDoc();
            yacargo = true;
        }

        private void Cargar_TipoDoc()
        {

            RN_TipoDoc obj = new RN_TipoDoc();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Todos_TipoDoc();
            if (dato.Rows.Count >0)
            {

                Cbo_Docs.DataSource = dato;
                Cbo_Docs.DisplayMember = "Documento";
                Cbo_Docs.ValueMember = "Id_tipo";
                Cbo_Docs.SelectedIndex = -1;

            }
        }

        private void Frm_edit_correlativo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }

        private void Cbo_Docs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(yacargo == true)
            {
                if(Cbo_Docs.SelectedIndex > -1)
                {
                    int idtipo = Convert.ToInt32(Cbo_Docs.SelectedValue);
                    Buscar_tipoDoc(idtipo);

                }
            }
            
        }

        private void Buscar_tipoDoc(int idtipo)
        {
            RN_TipoDoc obj = new RN_TipoDoc();
            DataTable dato = new DataTable();


            dato = obj.RN_Listar_Todos_TipoDoc_porId(idtipo);
            if (dato.Rows.Count > 0)
            {

                txt_id.Text = Convert.ToString(dato.Rows[0]["Id_Tipo"]);
                lbl_nom.Text = Convert.ToString(dato.Rows[0]["Documento"]);
                txt_serie.Text = Convert.ToString(dato.Rows[0]["Serie"]);
                txt_num.Text = Convert.ToString(dato.Rows[0]["Numero"]);

                pnl_edit.Enabled = true;
                btn_Generar.Enabled = true;
                txt_serie.Focus();


            }


        }

    }
}
