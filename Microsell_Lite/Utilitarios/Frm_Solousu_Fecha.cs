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

namespace Microsell_Lite.Utilitarios
{
    public partial class Frm_Solousu_Fecha : Form
    {
        public Frm_Solousu_Fecha()
        {
            InitializeComponent();
        }

        private void Frm_Solousu_Fecha_Load(object sender, EventArgs e)
        {
            Llenar_Combo_Usuario();
        }

        private void btn_cancelPago_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();

        }

        private void btn_Generar_Click(object sender, EventArgs e)
        {
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

       
    }
}
