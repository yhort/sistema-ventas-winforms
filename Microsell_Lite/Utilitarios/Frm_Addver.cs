using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsell_Lite.Utilitarios
{
    public partial class Frm_Addver : Form
    {
        public Frm_Addver()
        {
            InitializeComponent();
        }


        private void Frm_Addver_Load(object sender, EventArgs e)
        {

        }

        private void Frm_Addver_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                Utilitario obj = new Utilitario();
                obj.Mover_formulario(this);

            }

        }

        private void elPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_acept_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Addver_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {

                btn_acept_Click(sender, e);

            }

        }

        
    }
}
