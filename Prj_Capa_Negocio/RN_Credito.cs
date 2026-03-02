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
   public  class RN_Credito
    {

        public void RN_Registrar_Credito(EN_Credito cre)
        {
            BD_Credito obj = new BD_Credito();
            obj.BD_Registrar_Credito(cre);
        }

        public void RN_Registrar_Detalle_Credito(EN_DetCredito cre)
        {
            BD_Credito obj = new BD_Credito();
            obj.BD_Registrar_Detalle_Credito(cre);
        }

        public static double RN_Sumar_Total_Credito_porCliente(string idCliente)
        {
            return BD_Credito.BD_Sumar_Total_Credito_porCliente(idCliente);
        }

        public DataTable RN_Listar_Todas_Creditos()
        {
            BD_Credito obj = new BD_Credito();
            return obj.BD_Listar_Todas_Creditos();
        }

        public DataTable RN_Listar_creditos_porValor(string valor)
        {
            BD_Credito obj = new BD_Credito();
            return obj.BD_Listar_creditos_porValor(valor);
        }


        public DataTable RN_Buscador_Doc_Creditos_porDia(DateTime diax)
        {
            BD_Credito obj = new BD_Credito();
            return obj.BD_Buscador_Doc_Creditos_porDia(diax);
        }

        public DataTable RN_Buscador_Doc_Creditos_porMes(DateTime mesx)
        {
            BD_Credito obj = new BD_Credito();
            return obj.BD_Buscador_Doc_Creditos_porDia(mesx);
        }

        public void RN_Eliminar_Credito_Permanente(string idcred)
        {
            BD_Credito obj = new BD_Credito();
            obj.BD_Eliminar_Credito_Permanente(idcred);
        }

      
    }
}
