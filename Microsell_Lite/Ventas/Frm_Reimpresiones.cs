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
using Prj_Capa_Negocio;

namespace Microsell_Lite.Ventas
{
    public partial class Frm_Reimpresiones : Form
    {
        public Frm_Reimpresiones()
        {
            InitializeComponent();
        }

        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            
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

        

        private void btn_listo_Click(object sender, EventArgs e)
        {
           /*RN_Categoria obj = new RN_Categoria();
            
            if (txt_nomcateg.Text.Trim().Length < 0) { MessageBox.Show("Ingresa el nombre de la Categoria", "Registrar Categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (editar == false)
            {

                //Nuevo:
                obj.RN_Registrar_Categoria(txt_nomcateg.Text);
                pnl_add.Visible = false;
                Cargar_todas_lascategorias();
                txt_nomcateg.Text = "";

            }
            else
            {
                //Editar:
                obj.RN_Editar_Categoria(Convert.ToInt32(txt_idcateg.Text), txt_nomcateg.Text);
                pnl_add.Visible = false;
                Cargar_todas_lascategorias();
                txt_nomcateg.Text = "";
                editar = false;


            }*/




        }


       
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void lsv_categoria_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void txt_buscar_OnValueChanged(object sender, EventArgs e)
        {
            /*f (txt_buscar.Text.Trim().Length > 2)
            {
                buscar_Categoria(txt_buscar.Text);
            }*/
        }


        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.KeyCode == Keys.Enter)
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    buscar_Categoria(txt_buscar.Text);
                }
                else
                {
                    Cargar_todas_lascategorias();
                }
            }*/
        }//fin
    }
}
