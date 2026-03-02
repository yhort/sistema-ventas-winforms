using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BE = businessEntities;
using EV = CPEEnvio;
using XM = CrearXML;
using SG = Signature;
using System.IO;

namespace Microsell_Lite
{
    public class CPEConfig
    {


        XM.CrearXML objXML = new XM.CrearXML();
        SG.FirmadoRequest objPregunta = new SG.FirmadoRequest();
        SG.FirmadoResponse objRespuesta = new SG.FirmadoResponse();
        SG.Signature objSignature = new SG.Signature();
        EV.ServiceSunat objENV = new EV.ServiceSunat();



        //Public NoAbrirPdf As Boolean

        public string RutaCompletaxml = "";


        public Dictionary<string, string> Enviar_FacturaBoleta_aSunat(BE.CPE CPE)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string nomARCHIVO = "";
            string ruta = "";
            string rutaFirma = "";
            string url = "";

            //============================================


            nomARCHIVO = CPE.NRO_DOCUMENTO_EMPRESA + "-" + CPE.COD_TIPO_DOCUMENTO + "-" + CPE.NRO_COMPROBANTE;

            if ((CPE.TIPO_PROCESO == 3))
            { //'Pruebas
                ruta = @"D:\\CPE_2\\BETA\\";
                url = "https://e-beta.sunat.gob.pe:443/ol-ti-itcpfegem-beta/billService";
            }
            else if ((CPE.TIPO_PROCESO == 1))
            { //Produccion
                ruta = @"D:\\CPE_2\\PRODUCCION\\";
                url = "https://e-factura.sunat.gob.pe/ol-ti-itcpfegem/billService"; //'Produccion
            }


            //rutaFirma = "D:\\CPE\\FIRMA\\" & CPE.NRO_DOCUMENTO_EMPRESA & ".pfx"
            rutaFirma = @"D:\\CPE_2\\FIRMABETA\\FIRMABETA.pfx";

            //===================creamos xml(comprobante)===================
            if (CPE.COD_TIPO_DOCUMENTO == "01" | CPE.COD_TIPO_DOCUMENTO == "03")
            {
                dictionary = objXML.CPE(CPE, nomARCHIVO, ruta);
            }

            if (dictionary["flg_rta"] == "0")
            {
                return dictionary;
            }
            //=================datos para la firma====================
            objPregunta.ruta_Firma = rutaFirma;
            objPregunta.contra_Firma = CPE.CONTRA_FIRMA;
            objPregunta.ruta_xml = ruta + nomARCHIVO + ".XML";
            RutaCompletaxml = ruta + nomARCHIVO + ".XML";
            objPregunta.flg_firma = 0;
            objRespuesta = objSignature.FirmaXMl(objPregunta);
            //'====================creamos pdf====================
            //Dim RptPDF As New Frm_Print_Pdf_Factura_Vic
            //'Dim RptPDF As New Metodos
            //CPE.HASH_CPE = objRespuesta.DigestValue
            //CPE.RUTA_CODIGO_BARRA = "D:\\CPE\\CODIGOBARRA\\" & nomARCHIVO & ".BMP"
            //CPE.RUTA_PDF = "D:\\CPE\\BETA\\" & nomARCHIVO & ".PDF"
            //RptPDF.TraerReporteComprobante_dePrueba(CPE)  ''USAN EL MISMO metodo al de la Prueba ''Prueba en version de conocer el sistema
            //'Abrimos el Aviso de Enviando a la Sunat:



            //====================enviamos documento a la sunat=========================
            dictionary = objENV.Envio(CPE.NRO_DOCUMENTO_EMPRESA, CPE.USUARIO_SOL_EMPRESA, CPE.PASS_SOL_EMPRESA, nomARCHIVO, ruta, url, objRespuesta.DigestValue);
            CPE.HASH_CPE = dictionary["hash_cpe"];
            return dictionary;

        }





        public Dictionary<string, string> Enviar_Baja_de_FE(BE.CPE_BAJA CPEBaja)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            string nomARCHIVO = "";
            string ruta = "";
            string rutaFirma = "";
            string url = "";


            nomARCHIVO = CPEBaja.NRO_DOCUMENTO_EMPRESA + "-" + CPEBaja.CODIGO + "-" + CPEBaja.SERIE + "-" + CPEBaja.SECUENCIA;

            if ((CPEBaja.TIPO_PROCESO == 3))
            { //'Pruebas
                ruta = @"D:\\CPE_2\\BETA\\";
                url = "https://e-beta.sunat.gob.pe:443/ol-ti-itcpfegem-beta/billService";
            }
            else if ((CPEBaja.TIPO_PROCESO == 1))
            { //Produccion
                ruta = @"D:\\CPE_2\\PRODUCCION\\";
                url = "https://e-factura.sunat.gob.pe/ol-ti-itcpfegem/billService"; //'Produccion
            }


            //valores:            
            rutaFirma = @"D:\\CPE_2\\FIRMABETA\\FIRMABETA.pfx";
            //===================creamos xml(comprobante)===================                
            dictionary = objXML.ResumenBaja(CPEBaja, nomARCHIVO, ruta);

            if (dictionary["flg_rta"] == "0")
            {
                return dictionary;
            }

            //=================datos para la firma====================
            objPregunta.ruta_Firma = rutaFirma;
            objPregunta.contra_Firma = CPEBaja.CONTRA_FIRMA;
            objPregunta.ruta_xml = ruta + nomARCHIVO + ".XML";
            RutaCompletaxml = ruta + nomARCHIVO + ".XML";
            objPregunta.flg_firma = 0;
            objRespuesta = objSignature.FirmaXMl(objPregunta);
            //====================0 llamamos la metodo apra enviar :
            dictionary = objENV.EnvioResumen(CPEBaja.NRO_DOCUMENTO_EMPRESA, CPEBaja.USUARIO_SOL_EMPRESA, CPEBaja.PASS_SOL_EMPRESA, nomARCHIVO, ruta, url, objRespuesta.DigestValue);
            CPEBaja.HASH_CPE = dictionary["hash_cpe"];
            return dictionary;



        }




        //consultas de Bajas:
        public Dictionary<string, string> Consulta_Ticket_de_Baja(BE.CONSULTA_TICKET CPETicket)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            string nomARCHIVO = "";
            string ruta = "";          
            string url = "";


            nomARCHIVO = CPETicket.NRO_DOCUMENTO_EMPRESA + "-" + CPETicket.TIPO_DOCUMENTO + "-" + CPETicket.NRO_DOCUMENTO;

            if (CPETicket.TIPO_PROCESO == 3)
            { //'Pruebas
                ruta = @"D:\\CPE_2\\BETA\\";
                url = "https://e-beta.sunat.gob.pe:443/ol-ti-itcpfegem-beta/billService";
            }
            else if ((CPETicket.TIPO_PROCESO == 1))
            { //Produccion
                ruta = @"D:\\CPE_2\\PRODUCCION\\";
                url = "https://e-factura.sunat.gob.pe/ol-ti-itcpfegem/billService"; //'Produccion
            }          
                     
            //====================0 llamamos la metodo apra enviar :
            dictionary = objENV.ConsultaTicket(CPETicket.NRO_DOCUMENTO_EMPRESA, CPETicket.USUARIO_SOL_EMPRESA, CPETicket.PASS_SOL_EMPRESA, nomARCHIVO, ruta, url, objRespuesta.DigestValue, CPETicket.TICKET);
           
            return dictionary;

        }


        //pegar: para Crear el Resumen de Boletas:
        public Dictionary<string, string> Enviar_ResumenBoletas(BE.CPE_RESUMEN_BOLETA CPEResumen)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            string nomARCHIVO = "";
            string ruta = "";
            string rutaFirma = "";
            string url = "";


            nomARCHIVO = CPEResumen.NRO_DOCUMENTO_EMPRESA + "-" + CPEResumen.CODIGO + "-" + CPEResumen.SERIE + "-" + CPEResumen.SECUENCIA;

            if ((CPEResumen.TIPO_PROCESO == 3))
            { //'Pruebas
                ruta = @"D:\\CPE_2\\BETA\\";
                url = "https://e-beta.sunat.gob.pe:443/ol-ti-itcpfegem-beta/billService";
            }
            else if ((CPEResumen.TIPO_PROCESO == 1))
            { //Produccion
                ruta = @"D:\\CPE_2\\PRODUCCION\\";
                url = "https://e-factura.sunat.gob.pe/ol-ti-itcpfegem/billService"; //'Produccion
            }


            //valores:            
            rutaFirma = @"D:\\CPE_2\\FIRMABETA\\FIRMABETA.pfx";
            //===================creamos xml(comprobante)===================                
            dictionary = objXML.ResumenBoleta(CPEResumen, nomARCHIVO, ruta);

            if (dictionary["flg_rta"] == "0")
            {
                return dictionary;
            }

            //=================datos para la firma====================
            objPregunta.ruta_Firma = rutaFirma;
            objPregunta.contra_Firma = CPEResumen.CONTRA_FIRMA;
            objPregunta.ruta_xml = ruta + nomARCHIVO + ".XML";
            RutaCompletaxml = ruta + nomARCHIVO + ".XML";
            objPregunta.flg_firma = 0;
            objRespuesta = objSignature.FirmaXMl(objPregunta);
            //====================0 llamamos la metodo apra enviar :
            dictionary = objENV.EnvioResumen(CPEResumen.NRO_DOCUMENTO_EMPRESA, CPEResumen.USUARIO_SOL_EMPRESA, CPEResumen.PASS_SOL_EMPRESA, nomARCHIVO, ruta, url, objRespuesta.DigestValue);
            
            return dictionary;



        }



        //metodo para enviar NC

        public Dictionary<string, string> Enviar_NotaCredito_aSunat(BE.CPE CPE)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string nomARCHIVO = "";
            string ruta = "";
            string rutaFirma = "";
            string url = "";

            //============================================


            nomARCHIVO = CPE.NRO_DOCUMENTO_EMPRESA + "-" + CPE.COD_TIPO_DOCUMENTO + "-" + CPE.NRO_COMPROBANTE;

            if ((CPE.TIPO_PROCESO == 3))
            { //'Pruebas
                ruta = @"D:\\CPE_2\\BETA\\";
                url = "https://e-beta.sunat.gob.pe:443/ol-ti-itcpfegem-beta/billService";
            }
            else if ((CPE.TIPO_PROCESO == 1))
            { //Produccion
                ruta = @"D:\\CPE_2\\PRODUCCION\\";
                url = "https://e-factura.sunat.gob.pe/ol-ti-itcpfegem/billService"; //'Produccion
            }


            //rutaFirma = "D:\\CPE\\FIRMA\\" & CPE.NRO_DOCUMENTO_EMPRESA & ".pfx"
            rutaFirma = @"D:\\CPE_2\\FIRMABETA\\FIRMABETA.pfx";

            //===================creamos xml(comprobante)===================
            if (CPE.COD_TIPO_DOCUMENTO == "07")
            {
                dictionary = objXML.CPE_NC(CPE, nomARCHIVO, ruta);
            }

            if (dictionary["flg_rta"] == "0")
            {
                return dictionary;
            }
            //=================datos para la firma====================
            objPregunta.ruta_Firma = rutaFirma;
            objPregunta.contra_Firma = CPE.CONTRA_FIRMA;
            objPregunta.ruta_xml = ruta + nomARCHIVO + ".XML";
            RutaCompletaxml = ruta + nomARCHIVO + ".XML";
            objPregunta.flg_firma = 0;
            objRespuesta = objSignature.FirmaXMl(objPregunta);
              

            //====================enviamos documento a la sunat=========================
            dictionary = objENV.Envio(CPE.NRO_DOCUMENTO_EMPRESA, CPE.USUARIO_SOL_EMPRESA, CPE.PASS_SOL_EMPRESA, nomARCHIVO, ruta, url, objRespuesta.DigestValue);
            CPE.HASH_CPE = dictionary["hash_cpe"];
            return dictionary;

        }


















    }
}
