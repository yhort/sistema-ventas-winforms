using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prj_Capa_Datos;

namespace Prj_Capa_Negocio
{
    public class RN_Reporte_Kardex_Temporal
    {

        public void RN_Registrar_Reporte_Kardex_Temporal(string idprod, string nombreprod, double stock, double precompra, double compra_xstock,
                                                         double preventa, double venta_xstock, double utilidad, double utilidad_xstock, string obs)
        {

            BD_Reporte_Kardex_Temporal obj = new BD_Reporte_Kardex_Temporal();
            obj.BD_Registrar_Reporte_Kardex_Temporal(idprod, nombreprod, stock, precompra, compra_xstock, preventa, venta_xstock, utilidad, utilidad_xstock, obs);

        }
        public void RN_Eliminar_Temporal_Kardex()
        {
            BD_Reporte_Kardex_Temporal obj = new BD_Reporte_Kardex_Temporal();
            obj.BD_Eliminar_Temporal_Kardex();
        }

        public DataTable RN_Listar_Temporal_Kardex()
        {
            BD_Reporte_Kardex_Temporal obj = new BD_Reporte_Kardex_Temporal();
            return obj.BD_Listar_Temporal_Kardex();
        }


    }
}
