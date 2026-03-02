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
    public class RN_Kardex
    {  
        public void RN_Registrar_Kardex(string idkardex, string idprodcto, string idprovee)
        {
            BD_Kardex obj = new BD_Kardex();
            obj.BD_Registrar_Kardex(idkardex, idprodcto, idprovee);

        }

        public void RN_Registrar_Detalle_Kardex(EN_Kardex kr)
        {

            BD_Kardex obj = new BD_Kardex();
            obj.BD_Registrar_Detalle_Kardex(kr);

        }

        public bool RN_Verificar_Producto_siTieneKardex(string idprod)
        {
            BD_Kardex obj = new BD_Kardex();
            return obj.BD_Verificar_Producto_siTieneKardex(idprod);
        }

        public DataTable RN_Buscar_KardexDetalle_porProducto(string idprod)
        {
            BD_Kardex obj = new BD_Kardex();
            return obj.BD_Buscar_KardexDetalle_porProducto(idprod);
        }


        public DataTable RN_Cargar_DetalleKardex_delDia(DateTime dia)
        {
            BD_Kardex obj = new BD_Kardex();
            return obj.BD_Cargar_DetalleKardex_delDia(dia);
        }

    }
}
