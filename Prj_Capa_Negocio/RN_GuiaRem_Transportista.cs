using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;




namespace Prj_Capa_Negocio
{
    public class RN_GuiaRem_Transportista
    {

        public void RN_Ingresar_GuiaRemision_Transportista(EN_Gr_Transportista com)
        {
            BD_GR_Transportista obj = new BD_GR_Transportista();
            obj.BD_Ingresar_GuiaRemision_Transportista(com);
        }

        public void RN_Ingresar_Detalle_GuiaRemIsion_Transportista(EN_Det_GR_Transportista det)
        {
            BD_GR_Transportista obj = new BD_GR_Transportista();
            obj.BD_Ingresar_Detalle_GuiaRemIsion_Transportista(det);
        }

        public void RN_CambiarEstado_CdrSunat_GrTransport(string idDoc, string cdrSunat, string hascpe)
        {
            BD_GR_Transportista obj = new BD_GR_Transportista();
            obj.BD_CambiarEstado_CdrSunat_GrTransport(idDoc, cdrSunat, hascpe);
        }


        public DataTable RN_Buscar_GrRemitente(string valor)
        {
            BD_GR_Transportista obj = new BD_GR_Transportista();
            return obj.BD_Buscar_GrRemitente(valor);
        }

        //public DataTable RN_Buscador_DocumentoGR_Detalle_porID(string IdDoc)
        //{
        //    BD_GR_Transportista obj = new BD_GR_Transportista();
        //    return obj.BD_Buscador_DocumentoGR_Detalle_porID(IdDoc);
        //}



    }
}
