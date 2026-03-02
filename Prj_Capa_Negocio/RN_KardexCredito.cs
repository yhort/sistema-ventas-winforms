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
    public class RN_KardexCredito
    {

        public void RN_Registrar_KardexCredito(EN_Kardex_Credito kr)
        {
            BD_KardeCredito obj = new BD_KardeCredito();
            obj.BD_Registrar_KardexCredito(kr);

        }

        public void RN_Registrar_detalleKardexCredito(EN_Kardex_Credito kr)
        {
            BD_KardeCredito obj = new BD_KardeCredito();
            obj.BD_Registrar_detalleKardexCredito(kr);

        }

        public bool RN_Verificar_Documento_siTieneKardex(string idprod)
        {
            BD_KardeCredito obj = new BD_KardeCredito();
            return obj.BD_Verificar_Documento_siTieneKardex(idprod);
        }

        public DataTable RN_Buscar_KardexDetalle_por_Doc(string idprod)
        {
            BD_KardeCredito obj = new BD_KardeCredito();
            return obj.BD_Buscar_KardexDetalle_por_Doc(idprod);
        }

        public DataTable RN_Buscar_KardexDetalle_Abono_por_Doc(string idprodxxx)
        {
            BD_KardeCredito obj = new BD_KardeCredito();
            return obj.BD_Buscar_KardexDetalle_Abono_por_Doc(idprodxxx);
        }

        public DataTable RN_Cargar_DetalleKardexCredito_delDia(DateTime dia)
        {
            BD_KardeCredito obj = new BD_KardeCredito();
            return obj.BD_Cargar_DetalleKardexCredito_delDia(dia);
        }

    }
}
