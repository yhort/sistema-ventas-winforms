using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;


namespace Prj_Capa_Negocio
{
  public   class RN_Notacredito
    {

        public void RN_Agregar_NotaCredito(EN_notacredito ObjPed)
        {
            BD_notaCredito obj = new BD_notaCredito();
            obj.BD_Agregar_NotaCredito(ObjPed);
        }


        public DataTable RN_Cargar_NotaCredito_Detalle(string xvalor)
        {
            BD_notaCredito obj = new BD_notaCredito();
            return obj.BD_Cargar_NotaCredito_Detalle(xvalor);
        }

        public void RN_Agregar_Items_Detalle_notacredito(EN_DetNotacredito  ObjDet)
        {
            BD_notaCredito  obj = new BD_notaCredito();
            obj.BD_Agregar_Items_Detalle_notacredito(ObjDet);
        }

        public DataTable RN_Buscardor_Gneral_NotasCreditos(string xvalor)
        {
            BD_notaCredito  obj = new BD_notaCredito ();
            return obj.BD_Buscardor_Gneral_NotasCreditos(xvalor);
        }

        public DataTable RN_Buscar_NotaCredito_Pormes(DateTime xvalor)
        {
            BD_notaCredito obj = new BD_notaCredito();
            return obj.BD_Buscar_NotaCredito_Pormes(xvalor);
        }

        public void RN_Actualizar_EstadoDinero_NC(string nroDoc_NC, string xstadodinero)
        {
            BD_notaCredito obj = new BD_notaCredito();
            obj.BD_Actualizar_EstadoDinero_NC(nroDoc_NC, xstadodinero);
        }        

        // 'todas las notas de credito
        public DataTable RN_Leer_Todas_notadecredito()
        {
            BD_notaCredito obj = new BD_notaCredito();
            return obj.BD_Leer_Todas_notadecredito();
        }

        // 'solo los emitidos hoy
        public DataTable RN_Leer_Todas_notadecredito_emitidosHOy()
        {
            BD_notaCredito  obj = new BD_notaCredito();
            return obj.BD_Leer_Todas_notadecredito_emitidosHOy();
        }


        public void RN_Actualizar_EstadoSunat_NC(string nroDoc_NC, string CdrSunat, string HashCpe)
        {
            BD_notaCredito obj = new BD_notaCredito();
            obj.BD_Actualizar_EstadoSunat_NC(nroDoc_NC, CdrSunat, HashCpe);
        }

        public bool RN_Verificar_SiFactura_Tiene_NotaCredito(string numFactu)
        {
            BD_notaCredito obj = new BD_notaCredito();
            return obj.BD_Verificar_SiFactura_Tiene_NotaCredito(numFactu);
        }


        public bool RN_Verificar_SiNotaCredito_esParaPagos(string nroDoc)
        {
            BD_notaCredito obj = new BD_notaCredito();
            return obj.BD_Verificar_SiNotaCredito_esParaPagos(nroDoc);
        }

        public DataTable RN_Buscar_NotaCredito_PendientePago(string xvalor)
        {
            BD_notaCredito obj = new BD_notaCredito();
            return obj.BD_Buscar_NotaCredito_PendientePago(xvalor);
        }
    }
}
