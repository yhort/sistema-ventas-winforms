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
    public partial class Frm_InicioCaja : Form
    {
        public Frm_InicioCaja()
        {
            InitializeComponent();
        }

        private void Frm_InicioCaja_Load(object sender, EventArgs e)
        {
            txt_importe.Focus();
        }

        private void Frm_InicioCaja_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario ui = new Utilitario();
            if (e.Button ==MouseButtons.Left )
            {
                ui.Mover_formulario(this);
            }
        }

        private void Frm_InicioCaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Escape )
            {
               // this.Tag = "";
                this.Close();
            }
        }

        //agregando para que el inicio de caja se por usuario pc

        //private void Leer_Dato_Empresa()
        //{
        //    RN_Empresa obj = new RN_Empresa();
        //    DataTable data = new DataTable();

        //    try
        //    {
        //        data = obj.RN_Buscar_Empresa_porId(Convert.ToInt32(Cls_Libreria.Idempresa)); //CONVERT.TOIN32(CLS.IDEMPRESA) Y DEMAS METODOS
        //        if (data.Rows.Count > 0)
        //        {
        //            Lbl_EmpresaEmisor.Text = Convert.ToString(data.Rows[0]["nombreEmpresa"]);
        //            Lbl_RucEmisor.Text = Convert.ToString(data.Rows[0]["nroRuc"]);
        //            Lbl_DireccionEmpresa.Text = Convert.ToString(data.Rows[0]["DireccionEmpresa"]);
        //            Lbl_UsuarioSol.Text = Convert.ToString(data.Rows[0]["usuariosol"]);
        //            Lbl_ClaveSol.Text = Convert.ToString(data.Rows[0]["clavesol"]);
        //            Lbl_CorreoEmi.Text = Convert.ToString(data.Rows[0]["correo"]);
        //            Lbl_ClaveCorreo.Text = Convert.ToString(data.Rows[0]["clavecorreo"]);
        //            Lbl_ClaveCertificado.Text = Convert.ToString(data.Rows[0]["clavecertificado"]);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al leer los Datos: " + ex.Message, "Form Add Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //}

         public  string nombrepc = Environment.MachineName;
        private void Registrar_Inicio_Caja()
        {
            EN_Cierre_Caja ca = new EN_Cierre_Caja();
            RN_Cierre_Caja obj = new RN_Cierre_Caja();

            //int iduser = Cls_Libreria.IdUsu;
            
           

           
            try
            {
                string idcierre = RN_TipoDoc.RN_NroID(13);

                ca.Idcierre = idcierre;
                ca.AperturaCaja = Convert.ToDouble(txt_importe.Text);
                ca.TotalIngreso = 0;
                ca.TotalEgreso = 0;
                ca.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                ca.TodoDeposito = 0;
                ca.TotalGanancia = 0;
                ca.TotalEntregado = 0;
                ca.SaldoSiguiente = 0;
                ca.TotalFactura = 0;
                ca.TotalBoleta = 0;
                ca.TotalNota = 0;
                ca.TotalCreditoCobrado = 0;
                ca.TotalCreditoEmitido = 0;
                //agregado para inicio y cierra indivual por pc
                //ca.NomnbreDesktop = nombrepc;

                obj.RN_Registrar_Inicio_Caja(ca);

                if(BD_Cierre_Caja.saved == true)
                {

                    RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(13);

                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

                    fil.Show();
                    ok.Lbl_msm1.Text = "El inicio de Caja se ha Aperturado Exitosamente";
                    ok.ShowDialog();
                    fil.Hide();

                    txt_importe.Text = "";

                    //txt_importe.Text = "A";
                    this.Tag = "A";
                    this.Close();


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // se puede personalizar
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {

            txt_importe.Text = "";
            this.Close();
        }

        private void btn_cancel_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void btn_procesar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
           
            Frm_Advertencia ver = new Frm_Advertencia();
            RN_Cierre_Caja obj = new RN_Cierre_Caja();

            if(txt_importe.Text.Trim().Length == 0)
            {

                fil.Show();
                ver.Lbl_msm1.Text = "Por favor, ingresa el importe para aperturar la caja del día ";
                ver.ShowDialog();

                fil.Hide();

                txt_importe.Focus();
                return;

            }

            if (obj.RN_Validar_InicioDoble_Caja() == true) //condificonal de verdadero
            {

                fil.Show();
                ver.Lbl_msm1.Text = "El sistema verificó que ya existe una apertura de Caja en este mismo día";
                ver.ShowDialog();

                fil.Hide();

                txt_importe.Focus();
                return;

            }

            //if (obj.RN_Validar_InicioDoble_Caja_2(nombrepc) == true) //condificonal de verdadero
            //{

            //    fil.Show();
            //    ver.Lbl_Msm1.Text = "El sistema verificó que ya existe una apertura de Caja en este mismo día";
            //    ver.ShowDialog();

            //    fil.Hide();

            //    txt_importe.Focus();
            //    return;

            //}
            else
            {
                Registrar_Inicio_Caja();
            }


        }
    }
}
