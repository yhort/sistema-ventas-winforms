using Prj_Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Prj_Capa_Datos;

namespace Prj_Capa_Negocio
{
    public class RN_PromocionVenta
    {
        public void RN_Registrar_PromocionVenta(EN_Promocion_Venta promoVenta)
        {
            BD_PromocionVenta obj = new BD_PromocionVenta();
            obj.BD_Registrar_PromocionVenta(promoVenta);
        }


        //public DataTable RN_Buscar_Promociones_Activas(string idProducto)
        //{
        //    BD_PromocionVenta obj = new BD_PromocionVenta();
        //    return obj.BD_Buscar_Promociones_Activas(idProducto);
        //}

    }
}
