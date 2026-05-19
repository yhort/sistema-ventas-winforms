using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Prj_Capa_Negocio
{
    public class RN_InventarioAjuste
    {
        public int RN_Registrar_InventarioAjuste(EN_InventarioAjuste aj)
        {
            BD_InventarioAjuste obj = new BD_InventarioAjuste();
            return obj.BD_Registrar_InventarioAjuste(aj);
        }

        public void RN_Registrar_InventarioAjusteDetalle(EN_InventarioAjusteDetalle det)
        {
            BD_InventarioAjuste obj = new BD_InventarioAjuste();
            obj.BD_Registrar_InventarioAjusteDetalle(det);
        }

        public DataTable RN_Listar_StockPresentacion_Inventario(string idProducto, int idAlmacen)
        {
            BD_InventarioAjuste obj = new BD_InventarioAjuste();
            return obj.BD_Listar_StockPresentacion_Inventario(idProducto, idAlmacen);
        }

        public void RN_Ajustar_StockPresentacion_Exacto(int idAlmacen, string idProducto, int idPresentacion, decimal nuevoStock)
        {
            BD_InventarioAjuste obj = new BD_InventarioAjuste();
            obj.BD_Ajustar_StockPresentacion_Exacto(idAlmacen, idProducto, idPresentacion, nuevoStock);
        }

        public DataTable RN_Listar_InventarioAjustes(DateTime fechaDesde, DateTime fechaHasta, string estado)
        {
            BD_InventarioAjuste obj = new BD_InventarioAjuste();
            return obj.BD_Listar_InventarioAjustes(fechaDesde, fechaHasta, estado);
        }

        public DataTable RN_Listar_InventarioAjusteDetalle(int idAjuste)
        {
            BD_InventarioAjuste obj = new BD_InventarioAjuste();
            return obj.BD_Listar_InventarioAjusteDetalle(idAjuste);
        }

        public DataTable RN_Buscar_Producto_Inventario(string valor, int idAlmacen)
        {
            BD_InventarioAjuste obj = new BD_InventarioAjuste();
            return obj.BD_Buscar_Producto_Inventario(valor, idAlmacen);
        }

        public DataTable RN_Obtener_DetalleAjuste_ParaAnular(int idAjuste)
        {
            BD_InventarioAjuste obj = new BD_InventarioAjuste();
            return obj.BD_Obtener_DetalleAjuste_ParaAnular(idAjuste);
        }

        public void RN_Anular_InventarioAjuste(int idAjuste, int idUsuarioAnula, string motivoAnulacion)
        {
            BD_InventarioAjuste obj = new BD_InventarioAjuste();
            obj.BD_Anular_InventarioAjuste(idAjuste, idUsuarioAnula, motivoAnulacion);
        }

        public void RN_Ajustar_StockPresentacion_PorDiferencia(int idAlmacen, string idProducto,int idPresentacion,decimal diferencia)
        {
            BD_InventarioAjuste obj = new BD_InventarioAjuste();

            obj.BD_Ajustar_StockPresentacion_PorDiferencia(
                idAlmacen,
                idProducto,
                idPresentacion,
                diferencia
            );
        }

        public DataTable RN_Validar_AnulacionAjuste_Stock(int idAjuste)
        {
            BD_InventarioAjuste obj = new BD_InventarioAjuste();
            return obj.BD_Validar_AnulacionAjuste_Stock(idAjuste);
        }
    }
}
