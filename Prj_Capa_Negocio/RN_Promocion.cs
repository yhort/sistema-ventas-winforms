using Prj_Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prj_Capa_Entidad;
using System.Security.Cryptography;
using System.Security.Policy;

namespace Prj_Capa_Negocio
{
    public class RN_Promocion
    {
        public int RN_RegistrarPromocion(string nombre, string tipo, DateTime inicio, DateTime fin)
        {
            BD_Promocion obj = new BD_Promocion();
            return obj.BD_RegistrarPromocion(nombre, tipo, inicio, fin);
        }

        public void RN_RegistrarDetallePromocion(int idPromo, string idProducto, int cantidad, decimal precio)
        {
            BD_Promocion obj = new BD_Promocion();
            obj.BD_RegistrarDetallePromocion(idPromo,idProducto, cantidad, precio);
        }

        public DataTable RN_BuscarDetallePromocion(int idPromocion)
        {
            BD_Promocion obj = new BD_Promocion();
            return obj.BD_BuscarDetallePromocion(idPromocion);
        }

        public DataTable RN_Buscar_Promociones_Activas(string idProducto)
        {
            BD_Promocion obj = new BD_Promocion();
            return obj.BD_Buscar_Promociones_Activas(idProducto);
        }

        public DataTable RN_Buscar_PromocionesVentas_Resumen(DateTime desde, DateTime hasta)
        {
            BD_Promocion obj = new BD_Promocion();
            return obj.BD_Buscar_PromocionesVentas_Resumen(desde, hasta);
        }

        public DataTable RN_Buscar_PromocionesVentas_Detalle(DateTime desde, DateTime hasta)
        {
            BD_Promocion obj = new BD_Promocion();
            return obj.BD_Buscar_PromocionesVentas_Detalle(desde, hasta);
        }

        public DataTable RN_Listar_Promociones()
        {
            BD_Promocion obj = new BD_Promocion();
            return obj.BD_Listar_Promociones();
        }

   

        public DataRow RN_ObtenerCabeceraPromo(int idPromo)
        {
            BD_Promocion objBD = new BD_Promocion();
            DataTable tabla = objBD.BD_ObtenerCabeceraPromo(idPromo);
            if (tabla != null && tabla.Rows.Count > 0)
            {
                return tabla.Rows[0];
            }
            return null;
        }

        public bool RN_PromocionYaUsada(int idPromocion)
        {
            BD_Promocion bd = new BD_Promocion();
            return bd.BD_PromocionYaUsada(idPromocion);
        }

        public void RN_Actualizar_Promocion(int idPromo, string nombre, string tipo, DateTime inicio, DateTime fin)
        {
            BD_Promocion obj = new BD_Promocion();
            obj.BD_Actualizar_Promocion(idPromo,nombre, tipo, inicio, fin);
        }

        public DataTable RN_BuscarDetallePromocion_paraActualizar(int idPromocion)
        {
            BD_Promocion obj = new BD_Promocion();
            return obj.BD_BuscarDetallePromocion_paraActualizar(idPromocion);
        }

        public void RN_EliminarDetallePromocion(int idPromo)
        {
            BD_Promocion bd = new BD_Promocion();
            bd.BD_EliminarDetallePromocion(idPromo);
        }

    }
}
