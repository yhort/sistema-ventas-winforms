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


namespace Microsell_Lite.Caja
{
    public partial class Frm_Reg_otroIngresos : Form
    {
        public Frm_Reg_otroIngresos()
        {
            InitializeComponent();
        }

        private void Pnl_titulo_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario ui = new Utilitario();
            if (e.Button == MouseButtons.Left)
            {
                ui.Mover_formulario(this);
            }
        }

        private void Frm_Reg_otroIngresos_Load(object sender, EventArgs e)
        {
            lbl_idcaja.Text = RN_TipoDoc.RN_NroID(15);
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();

        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            Guardar_IngresoCaja();
        }

        bool siguardo = false;
        private void Guardar_IngresoCaja()
        {
            RN_Caja obj = new RN_Caja();
            En_Caja cja = new En_Caja();

            try
            {
                cja.Idcaja = lbl_idcaja.Text;
                cja.FechaCaja = dtp_fecha.Value;
                cja.TipoCaja = "Entrada";
                cja.Concepto = txt_concepto.Text;
                cja.De_Para_Cliente = txt_cliente.Text;
                cja.Nro_Doc = txt_nroDoc.Text;
                cja.ImportaCaja = Convert.ToDouble(txt_importe.Text);
                cja.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                cja.TotalUti = 0;
                cja.TipoPago = cbo_tipoPago.Text;
                cja.GeneradoPor = "Otros";

                obj.RN_Registrar_Mov_Caja(cja);
                if(BD_Caja.cajaSaved == true)
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo_Producto(15);
                    siguardo = true;

                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

                    fil.Show();
                    ok.Lbl_msm1.Text = "El ingreso se guardo Correctamente";
                    ok.ShowDialog();
                    fil.Hide();

                    this.Tag = "A";
                    this.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

    }
}
