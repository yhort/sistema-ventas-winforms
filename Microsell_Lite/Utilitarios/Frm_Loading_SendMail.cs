using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Microsell_Lite.Utilitarios 
{
    public partial class Frm_Loading_SendMail : Form
    {
        public Frm_Loading_SendMail()
        {
            InitializeComponent();
        }

        private void Frm_Msm_Bueno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                btn_acept_Click(sender, e);
            }
        }

        private void btn_acept_Click(object sender, EventArgs e)
        {
           
        }

        private void tocar_timbre ()
        {
            string ruta;
            ruta = Application.StartupPath;
            System.Media.SoundPlayer son;
            son = new System.Media.SoundPlayer(ruta + @"\Gotaagua.wav");
            son.Play();
                       
        }

        // Este método puede usarse para cerrar el formulario automáticamente
        // después de que el proceso se haya completado
        public void CerrarFormulario()
        {
            this.Close();  // Cierra el formulario de carga
        }

        private void Frm_Msm_Bueno_Load(object sender, EventArgs e)
        {
            //   sonido al iniciar el formulario
            //tocar_timbre();

            // Puedes poner un texto o animación aquí si es necesario
            Lbl_TituPrinci.Text = "Por favor espere, exportando datos..."; // Un Label con un mensaje
        }

        private void Frm_Loading_SendMail_Load(object sender, EventArgs e)
        {
            tocar_timbre();
        }
    }
}
