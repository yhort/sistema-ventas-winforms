using CapaDatos;
using Prj_Capa_Entidad;
using System.Data;

namespace CapaNegocio
{
    public class RN_InventarioCorte
    {
        public int RN_Registrar_InventarioCorte(EN_InventarioCorte corte)
        {
            BD_InventarioCorte obj = new BD_InventarioCorte();
            return obj.BD_Registrar_InventarioCorte(corte);
        }

        public void RN_Generar_Detalle_InventarioCorte(int idCorte, int idAlmacen)
        {
            BD_InventarioCorte obj = new BD_InventarioCorte();
            obj.BD_Generar_Detalle_InventarioCorte(idCorte, idAlmacen);
        }

        public DataTable RN_Listar_InventarioCortes()
        {
            BD_InventarioCorte obj = new BD_InventarioCorte();
            return obj.BD_Listar_InventarioCortes();
        }

        public DataTable RN_Listar_InventarioCorteDetalle(int idCorte)
        {
            BD_InventarioCorte obj = new BD_InventarioCorte();
            return obj.BD_Listar_InventarioCorteDetalle(idCorte);
        }
    }
}