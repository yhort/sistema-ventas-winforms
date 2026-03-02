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
    public partial class Frm_edit_tipocambio : Form
    {
        public Frm_edit_tipocambio()
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

            

            if(txt_nuevocam.Text.Trim().Length == 0) { txt_nuevocam.Focus(); return; }
            if(Convert.ToDouble(txt_nuevocam.Text)==0) { txt_nuevocam.Focus(); return; }

            obj.RN_Actualizar_tipoCambio(7, Convert.ToDouble(txt_nuevocam.Text));

            this.Tag = "A";
            this.Close();

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
            if (e.KeyCode ==Keys.Escape )
            {
                this.Tag = "";
                this.Close();
            }
        }

        private void Frm_SoloFecha_Load(object sender, EventArgs e)
        {
            double tipocambio = 0;
            tipocambio = RN_TipoDoc.RN_Leer_TipoCambio(7);
            txt_actual.Text = tipocambio.ToString("###0.00");
            txt_nuevocam.Focus();
        }
    }
}
