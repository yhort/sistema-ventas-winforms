using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.Data.SqlClient;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
//using Microsoft.Office.Interop.Excel;

namespace Prj_Capa_Negocio
{
    public class RN_GuiaRemision
    {
        public void RN_Ingresar_GuiaRemision(EN_GuiaRemision com)
        {
            BD_GuiaRemision obj = new BD_GuiaRemision();
            obj.BD_Ingresar_GuiaRemision(com);

        }

        public void RN_Ingresar_Detalle_GuiaRemesion(EN_Det_GuiaRemision det)
        {
            BD_GuiaRemision obj = new BD_GuiaRemision();
            obj.BD_Ingresar_Detalle_GuiaRemesion(det);
        }

        public void RN_Ingresar_GuiaConductor(string idGr, int idCond)
        {
            BD_GuiaRemision obj = new BD_GuiaRemision();
            obj.BD_Ingresar_GuiaConductor(idGr, idCond);
        }

        public void RN_Ingresar_GuiaVehiculo(string idGr, int idVehiculo)
        {
            BD_GuiaRemision obj = new BD_GuiaRemision();
            obj.BD_Ingresar_GuiaVehiculo(idGr, idVehiculo);
        }

        public void RN_CambiarEstado_CdrSunat_GuiaRem(string idDoc, string cdrSunat, string hascpe)
        {
            BD_GuiaRemision obj = new BD_GuiaRemision();
            obj.BD_CambiarEstado_CdrSunat_GuiaRem(idDoc, cdrSunat, hascpe);
        }

        public void RN_ActualizarRespuestas_GuiaRem(string idDoc, string nroTicket, string hashcpe)
        {
            BD_GuiaRemision obj = new BD_GuiaRemision();
            obj.BD_ActualizarRespuestas_GuiaRem(idDoc, nroTicket, hashcpe);
        }
        public DataTable RN_Buscador_DocumentoGR_Detalle_porID(string IdDoc)
        {
            BD_GuiaRemision obj = new BD_GuiaRemision();
            return obj.BD_Buscador_DocumentoGR_Detalle_porID(IdDoc);
        }

        public DataTable RN_Buscar_GuiaRemisionRem(string valor)
        {
            BD_GuiaRemision obj = new BD_GuiaRemision();
            return obj.BD_Buscar_GuiaRemisionRem(valor);
        }

        public DataTable RN_Buscar_GuiasRem_Remitente_aExcel(DateTime desde, DateTime hasta)
        {
            BD_GuiaRemision obj = new BD_GuiaRemision();
            return obj.BD_Buscar_GuiasRem_Remitente_aExcel(desde,hasta);
        }

        public DataTable RN_Filtrar_DocsGr_RangoFechas(DateTime desde, DateTime hasta)
        {
            BD_GuiaRemision obj = new BD_GuiaRemision();
            return obj.BD_Filtrar_DocsGr_RangoFechas(desde, hasta);
        }

    }
}
