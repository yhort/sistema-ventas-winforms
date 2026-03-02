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

using System.Net.Mail;
using System.Diagnostics;
using System.Net;

namespace Microsell_Lite.Ventas
{
    public partial class Frm_EnviodocMail_Venta : Form
    {
        public Frm_EnviodocMail_Venta()
        {
            InitializeComponent();
        }

        bool enviado = false;

        MailMessage correos = new MailMessage();
        SmtpClient envios = new SmtpClient();

        ProcessStartInfo xpdf;
        Process procesopdf;


        private void Frm_EnviodocMail_Venta_Load(object sender, EventArgs e)
        {
            Leer_Dato_Empresa();
            lbl_msm.Text = "";
        }


        private void Leer_Dato_Empresa()
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
                    Lbl_CorreoEmi.Text = Convert.ToString(data.Rows[0]["correo"]);
                    Lbl_ClaveCorreo.Text = Convert.ToString(data.Rows[0]["clavecorreo"]);
                    Lbl_ClaveCertificado.Text = Convert.ToString(data.Rows[0]["clavecertificado"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer los Datos: " + ex.Message, "Form Add Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private int xseg = 0;

        private void btn_SendEmail_Click(object sender, EventArgs e)
        {

            try
            {

                if (txt_email.Text.Trim().Length < 8) return;

                lbl_msm.Text = "Espere, Estamos enviando el Correo";
                lbl_msm.Visible = true;
                lbl_msm.Refresh();

                if(lbl_rutxml.Text.Trim().Length < 4)
                {
                    //Cuando no tiene cargado el xml, se enviara solo PFD:
                    //metodo pars pdf:
                    Enviar_Pdf(Lbl_CorreoEmi.Text.Trim(), Lbl_ClaveCorreo.Text.Trim(), "CapSoft: " + "Estimado Cliente te Enviamos tu Comprobante Electronico",
                      "Tu FE Nro: " + lbl_nroDoc.Text, txt_email.Text.Trim(), lbl_rutDoc.Text.Trim());

                }

                if(enviado == true)
                {
                    MessageBox.Show("El Email se envio Correctamente", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbl_msm.Text = "";
                    lbl_msm.Visible = false;

                }
                else
                {
                    Enviar_Xml_and_Pdf(Lbl_CorreoEmi.Text.Trim(), Lbl_ClaveCorreo.Text.Trim(), "CapSoft: " + "Estimado Cliente te Enviamos tu Comprobante Electronico",
                      "Tu FE Nro: " + lbl_nroDoc.Text, txt_email.Text.Trim(), lbl_rutDoc.Text.Trim(), lbl_rutxml.Text.Trim());

                    if (enviado == true)
                    {
                        MessageBox.Show("El Email se Envio Correctamente", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lbl_msm.Text = "";
                        lbl_msm.Visible = false;

                    }

                }


            }
            catch (Exception)
            {

                throw;
            }

        }

        private void Enviar_Pdf(string emisor, string clave, string mensaje, string asunto, string destinatario, string rutapdf)
        {
            try
            {
                correos.To.Clear();
                correos.Body = "";
                correos.Subject = "";
                correos.Attachments.Clear();

                correos.Body = mensaje;
                correos.Subject = asunto;
                correos.IsBodyHtml = true;
                correos.To.Add  (destinatario.Trim());

                if(rutapdf.Trim() != "")
                {
                    Attachment archivo = new Attachment(rutapdf);
                    correos.Attachments.Add(archivo);
                }

                correos.From = new MailAddress(emisor);
                envios.Credentials = new NetworkCredential(emisor, clave);

                envios.Host = "smtp.gmail.com";
                envios.Port = 587;
                envios.EnableSsl = true;

                envios.Send(correos);
                enviado = true;

                

            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.Message, "Mensajeria 1.0 .net", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void Enviar_Xml_and_Pdf(string emisor, string clave, string mensaje, string asunto, string destinatario, string rutapdf, string rutaxml)
        {
            try
            {
                correos.To.Clear();
                correos.Body = "";
                correos.Subject = "";
                correos.Attachments.Clear();

                correos.Body = mensaje;
                correos.Subject = asunto;
                correos.IsBodyHtml = true;
                correos.To.Add(destinatario.Trim());

                if (rutapdf.Trim().Length > 3)
                {
                    Attachment archivo = new Attachment(rutapdf);
                    correos.Attachments.Add(archivo);
                }


                if (rutaxml.Trim().Length > 4)
                {
                    Attachment archivo2 = new Attachment(rutaxml);
                    correos.Attachments.Add(archivo2);
                }


                correos.From = new MailAddress(emisor);
                envios.Credentials = new NetworkCredential(emisor, clave);

                envios.Host = "smtp.gmail.com";
                envios.Port = 587;
                envios.EnableSsl = true;

                envios.Send(correos);
                enviado = true;



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensajeria 1.0 .net", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void Frm_EnviodocMail_Venta_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                this.Tag = "";
                this.Close();
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
    }
}
