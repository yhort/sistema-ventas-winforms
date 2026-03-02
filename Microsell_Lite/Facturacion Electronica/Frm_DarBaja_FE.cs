using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE = businessEntities;
using Prj_Capa_Negocio;
using Prj_Capa_Datos;
using System.IO;
using Microsell_Lite.Utilitarios;


namespace Microsell_Lite.Facturacion_Electronica
{
    public partial class Frm_DarBaja_FE : Form
    {
        public Frm_DarBaja_FE()
        {
            InitializeComponent();
        }

        private void Frm_DarBaja_FE_Load(object sender, EventArgs e)
        {
            Leer_Dato_empresa();
        }

        private void Leer_Dato_empresa()
        {
            RN_Empresa obj = new RN_Empresa();
            DataTable data = new DataTable();


            try
            {
                data = obj.RN_Buscar_Empresa_porId(1);
                if (data.Rows.Count > 0)
                {

                    Lbl_EmpresaEmisor.Text = Convert.ToString(data.Rows[0]["nombreEmpresa"]);
                    Lbl_RucEmisor.Text = Convert.ToString(data.Rows[0]["nroRuc"]);
                    Lbl_DireccionEmpresa.Text = Convert.ToString(data.Rows[0]["DireccionEmpresa"]);
                    Lbl_UsuarioSol.Text = Convert.ToString(data.Rows[0]["usuariosol"]);
                    Lbl_ClaveSol.Text = Convert.ToString(data.Rows[0]["clavesol"]);
                    Lbl_CertificadoClave.Text = Convert.ToString(data.Rows[0]["clavecertificado"]);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Leer los Datos: " + ex.Message, "Form Add Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }


        string iEstadoInterno = "";
        string iCdrSunat = "";
        string iBajaSunat = "";
        string xTipoDoc = "";


        private bool Validar_Doc()
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Addver ver = new Frm_Addver();

            if (iEstadoInterno.Trim() == "Activo")
            {
                fil.Show(); ver.Lbl_Msm1.Text = "El Documento Ingresado Aun no está Anulado Internamente"; ver.ShowDialog(); fil.Hide(); return false;
            }
            if (iCdrSunat.Trim() != "Aprobado")
            {
                fil.Show(); ver.Lbl_Msm1.Text = "La Factura aun no fue enviada a Sunat, Verifique"; ver.ShowDialog(); fil.Hide(); return false;
            }
            if (iBajaSunat.Trim() != "Activo")
            {
                fil.Show(); ver.Lbl_Msm1.Text = "La Factura Tiene una Baja Pendiente de aprobacion o está con Errores"; ver.ShowDialog(); fil.Hide(); return false;
            }
            if (xTipoDoc.Trim() != "Factura")
            {
                fil.Show(); ver.Lbl_Msm1.Text = "El Documento ingresado no Puede ser anulado desde aqui, Asegurate de Ingresar sólo Facturas"; ver.ShowDialog(); fil.Hide(); return false;
            }
            return true;
        }

        private void Lbl_lupa_Click(object sender, EventArgs e)
        {

            DataTable data = new DataTable();
            RN_Documento obj = new RN_Documento();
            Frm_Addver ver = new Frm_Addver();
            Frm_Filtro fil = new Frm_Filtro();
            string soloNorDoc = "";
            string soloSerieDoc = "";
            string nroEntero = "";  //FE01-00012

            string[] NroDoc_matriz;

            //Pasamos Variables la a Fecha:
            string xaño = "";
            string xmes = "";
            string xdia = "";
            string FechaPura = "";

            try
            {
                data = obj.RN_Buscador_Documentos_porValor(txt_buscar.Text);
                if (data.Rows.Count > 0)
                {
                    var ve = data.Rows[0];
                    iEstadoInterno = Convert.ToString(ve["Estado_Doc"]);
                    iCdrSunat = Convert.ToString(ve["CdrSunat"]);
                    iBajaSunat = Convert.ToString(ve["EstadoBaja"]);
                    xTipoDoc = Convert.ToString(ve["Documento"]);

                    if (Validar_Doc() == false) return;

                    var withBlock = data.Rows[0];
                    nroEntero = withBlock["id_Doc"].ToString();
                    xTipoDoc = withBlock["Documento"].ToString();
                    lbl_estadoDoc.Text = withBlock["Estado_Doc"].ToString();
                    lbl_estadoDoc_sunat.Text = withBlock["CdrSunat"].ToString();
                    lbl_estadoBaja.Text = withBlock["EstadoBaja"].ToString();
                    Dtp_FechaDoc.Value = Convert.ToDateTime(withBlock["Fecha_Emi"]);

                    // 'Tipo de Documento:
                    if (xTipoDoc.Trim() == "Factura")
                    {
                        lbl_TipoComprobante.Text = "01-Factura";
                        lbl_CodTipoDoc_Sunat.Text = "01";
                    }
                    else if (xTipoDoc.Trim() == "Boleta")
                    {
                        lbl_TipoComprobante.Text = "03-Boleta";
                        lbl_CodTipoDoc_Sunat.Text = "03";
                    }

                    // 'Nro de Secuencia:
                    xaño = dtp_FechaBaja.Value.Year.ToString();
                    xmes = dtp_FechaBaja.Value.Month.ToString();
                    xdia = dtp_FechaBaja.Value.Day.ToString();
                    if (xmes.Trim().Length == 1)
                    {
                        xmes = "0" + xmes;
                    }
                    else
                    {
                        xmes = xmes;
                    }


                    if (xdia.Trim().Length == 1)
                    {
                        xdia = "0" + xdia;
                    }
                    else
                    {
                        xdia = xdia;
                    }


                    FechaPura = xaño + xmes + xdia; // 14102020
                    Lbl_serieSunat.Text = FechaPura;
                    // 'Disgregamos el Nro de Doc:
                    char delimi = '-';
                    NroDoc_matriz = nroEntero.Split(delimi);  //FE01-00012
                    soloSerieDoc = NroDoc_matriz[0];
                    soloNorDoc = NroDoc_matriz[1];
                    Lbl_SerieDoc.Text = soloSerieDoc;
                    Lbl_nroDoc.Text = soloNorDoc;
                    Txt_NroItem.Text = "1";
                    Lbl_NroDoc_Completo.Text = txt_buscar.Text.Trim();

                    // 'Habilitamos Controles:
                    Btn_Enviar.Enabled = true;
                    Gru_Principal.Enabled = true;

                }
                else
                {
                    //no hay datos:
                    fil.Show();
                    ver.Lbl_Msm1.Text = "El Documento Ingresado NO Existe";
                    ver.ShowDialog();
                    fil.Hide();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EEror al Cargar el Doc: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }



        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                Lbl_lupa_Click(sender, e);
            }
        }


        BE.CPE_BAJA objCPE_BAJA = new BE.CPE_BAJA();
        BE.CPE_BAJA_DETALLE objCPE_BAJA_DETALLE = new BE.CPE_BAJA_DETALLE();

        BE.CONSULTA_TICKET objCPETICKET = new BE.CONSULTA_TICKET();
        CPEConfig obj = new CPEConfig();





        private void Btn_Enviar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_Addver ver = new Frm_Addver();

            try
            {
                objCPE_BAJA.NRO_DOCUMENTO_EMPRESA = Lbl_RucEmisor.Text.Trim();
                objCPE_BAJA.RAZON_SOCIAL = Lbl_EmpresaEmisor.Text.Trim();
                objCPE_BAJA.TIPO_DOCUMENTO = "6";  // 'Corresponde al tipo de doc de la empresa emisora.. 06=Ruc
                                                   // '======
                objCPE_BAJA.CODIGO = "RA";
                objCPE_BAJA.SERIE = Lbl_serieSunat.Text.Trim();   // '  "20161029"
                objCPE_BAJA.SECUENCIA = "1"; // 'Es el Correlativo de las Bajas
                objCPE_BAJA.FECHA_REFERENCIA = Dtp_FechaDoc.Value.ToString("yyyy-MM-dd");
                objCPE_BAJA.FECHA_BAJA = dtp_FechaBaja.Value.ToString("yyyy-MM-dd");

                int xtipoServer = Convert.ToInt32(Cbo_TipoServidor.Text);

                objCPE_BAJA.TIPO_PROCESO = System.Convert.ToInt32(xtipoServer); // '  3  ''1= produccion -- 3= Beta/prueba
                objCPE_BAJA.USUARIO_SOL_EMPRESA = Lbl_UsuarioSol.Text.Trim();
                objCPE_BAJA.PASS_SOL_EMPRESA = Lbl_ClaveSol.Text.Trim();
                objCPE_BAJA.CONTRA_FIRMA = Lbl_CertificadoClave.Text.Trim(); // ' "123456"         


                List<BE.CPE_BAJA_DETALLE> OBJCPE_DETALLE_LIST = new List<BE.CPE_BAJA_DETALLE>();

                objCPE_BAJA_DETALLE.ITEM = 1;  // 'Indica la cantidad de documentos que se van a anular o Dar de Baja
                objCPE_BAJA_DETALLE.TIPO_COMPROBANTE = lbl_CodTipoDoc_Sunat.Text; // '01=factura , 07=nota de credito , 08=nota de debito
                objCPE_BAJA_DETALLE.SERIE = Lbl_SerieDoc.Text.Trim();
                objCPE_BAJA_DETALLE.NUMERO = Lbl_nroDoc.Text.Trim();
                objCPE_BAJA_DETALLE.DESCRIPCION = Txt_MotivoBaja.Text.Trim();

                OBJCPE_DETALLE_LIST.Add(objCPE_BAJA_DETALLE);

                objCPE_BAJA.detalle = OBJCPE_DETALLE_LIST;

                //================Leer la Respuesta del CDR =======0
                Dictionary<string, string> dictionaryEnv = new Dictionary<string, string>();
                dictionaryEnv = obj.Enviar_Baja_de_FE(objCPE_BAJA);

                txt_codSunat.Text = dictionaryEnv["cod_sunat"];
                Txt_MsmSunat.Text = dictionaryEnv["msj_sunat"];
                TXTHASHCPE.Text = dictionaryEnv["hash_cpe"];
                Lbl_HashCpe2.Text = dictionaryEnv["hash_cpe"];
                TXTHASHCDR.Text = dictionaryEnv["hash_cdr"];
                // ==============================
                Txt_NroTicket.Text = dictionaryEnv["msj_sunat"];
                Lbl_NroTicket2.Text = Txt_NroTicket.Text;

                if (txt_codSunat.Text.Trim().Length == 0)
                {
                    ok.Lbl_msm1.Text = "El Documento fue Enviado para la Baja, Nro Ticket: " + Txt_NroTicket.Text;
                    ok.ShowDialog();
                }
                else
                {
                    fil.Show();
                    ver.Lbl_Msm1.Text = "El Documento NO fue Aceptada por la Sunat: " + txt_codSunat.Text.Trim() + " -- " + Txt_MsmSunat.Text;
                    ver.ShowDialog();
                    fil.Hide();
                }

                //consultar el stado de la Baja:
                if (Txt_NroTicket.Text.Trim().Length > 2)
                {
                   Consultar_EstadoBaja();
                }                    
                else
                {
                    Gru_MsmSunat.Enabled = true;
                    btn_consulTicket.Enabled = true;
                }



            }
            catch (Exception ex)
            {

               
            }



        }


        private void Consultar_EstadoBaja()
        {
            // ===================CONSULTA RESUMEN DE BAJA=======================
            int xtiposer =Convert.ToInt32 (Cbo_TipoServidor.Text);
            objCPETICKET.TIPO_PROCESO = System.Convert.ToInt32(xtiposer);  // ' 3
            objCPETICKET.NRO_DOCUMENTO_EMPRESA = Lbl_RucEmisor.Text.Trim();
            objCPETICKET.USUARIO_SOL_EMPRESA = Lbl_UsuarioSol.Text.Trim();
            objCPETICKET.PASS_SOL_EMPRESA = Lbl_ClaveSol.Text.Trim();
            objCPETICKET.TICKET = Txt_NroTicket.Text.Trim();
            objCPETICKET.TIPO_DOCUMENTO = "RA";
            objCPETICKET.NRO_DOCUMENTO = Lbl_serieSunat.Text + "-1"; // ' "20161029-1"

            // ======================================RESPUESTA====================================
            Dictionary<string, string> dictionaryEnv = new Dictionary<string, string>();
            dictionaryEnv = obj.Consulta_Ticket_de_Baja(objCPETICKET);
            txt_codSunat.Text = dictionaryEnv["cod_sunat"];
            Txt_MsmSunat.Text = dictionaryEnv["msj_sunat"];
            TXTHASHCPE.Text = dictionaryEnv["hash_cpe"];
            TXTHASHCDR.Text = dictionaryEnv["hash_cdr"];
            Txt_NroTicket.Text = "";

            Frm_Filtro fil = new Frm_Filtro ();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_Addver ver = new Frm_Addver();
            string xStadoBaja = "";
            if (txt_codSunat.Text.Trim() == "0" | txt_codSunat.Text.Trim() == "1")
            {
                ok.Lbl_msm1.Text = "La Sunat Aceptó la Baja/Anulacion de la Factura Nro: " + Lbl_NroDoc_Completo.Text;
                ok.ShowDialog();
                xStadoBaja = "Anulado";
            }
            else if (txt_codSunat.Text.Trim() == "98")
            {
                ok.Lbl_msm1.Text = "La baja del Documento está en Proceso. Nro Doc: " + Lbl_NroDoc_Completo.Text;
                ok.ShowDialog();
                xStadoBaja = "En Proceso";
            }
            else if (txt_codSunat.Text.Trim() == "99")
            {
                fil.Show();
                ver.Lbl_Msm1.Text = "Algo salió mal al dar la Baja. Nro Doc: " + Lbl_NroDoc_Completo.Text;
                ver.ShowDialog();
                fil.Hide();
                xStadoBaja = "Activo";
            }
            else
            {
                fil.Show();
                ver.Lbl_Msm1.Text = "Algo salió mal al dar la Baja. Nro Doc: " + Lbl_NroDoc_Completo.Text;
                ver.ShowDialog();
                fil.Hide();
            }
            

            RN_Documento objDoc = new RN_Documento();
            objDoc.RN_Actualizar_Documento_CDR_SunatBajas(Lbl_NroDoc_Completo.Text, xStadoBaja, Lbl_NroTicket2.Text.Trim(), Lbl_HashCpe2.Text.Trim());
            // 'Limpiaamos
            Limpiar_Ventana();
            Gru_Principal.Enabled = false;
        }




        private void Limpiar_Ventana()
        {
            lbl_estadoDoc.Text = "";
            lbl_estadoDoc_sunat.Text = "";
            Lbl_SerieDoc.Text = "";
            Lbl_nroDoc.Text = "";
            lbl_CodTipoDoc_Sunat.Text = "";
            Lbl_NroDoc_Completo.Text = "";
            lbl_TipoComprobante.Text = "";
            Lbl_serieSunat.Text = "";

            txt_codSunat.Text = "";
            Txt_MotivoBaja.Text = "";
            Txt_MsmSunat.Text = "";
            Txt_NroItem.Text = "";
            Txt_NroTicket.Text = "";
            txt_buscar.Text = "";
            txt_codSunat.Text = "";
        }

        private void btn_consulTicket_Click(object sender, EventArgs e)
        {
            if (Txt_NroTicket.Text.Trim().Length > 2)
            {
                Consultar_EstadoBaja();
            }
        }
    }
}
