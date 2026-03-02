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
    public class RN_Productos
    {

        public void RN_Registrar_Producto(EN_Producto pro)
        {
            BD_Productos obj = new BD_Productos();
            obj.BD_Registrar_Producto(pro);
        }

        public void RN_Editar_Producto(EN_Producto pro)
        {
            BD_Productos obj = new BD_Productos();
            obj.BD_Editar_Producto(pro);

        }

        public DataTable RN_Mostrar_Todos_Productos()
        {
            BD_Productos obj = new BD_Productos();
            return obj.BD_Mostrar_Todos_Productos();

        }

        public DataTable RN_Buscar_Productos(string valor)
        {
            BD_Productos obj = new BD_Productos();
            return obj.BD_Buscar_Productos(valor);

        }

        public void RN_darBaja_Producto(string idprod)
        {
            BD_Productos obj = new BD_Productos();
            obj.BD_darBaja_Producto(idprod);

        }

        public void RN_Eliminar_Producto(string idprod)
        {

            BD_Productos obj = new BD_Productos();
            obj.BD_Eliminar_Producto(idprod);

        }

        public void RN_Sumar_Stock_Producto(string idprod, double stock)
        {
            BD_Productos obj = new BD_Productos();
            obj.BD_Sumar_Stock_Producto(idprod, stock);

        }

        public void RN_Restar_Stock_Producto(string idprod, double stock)
        {
            BD_Productos obj = new BD_Productos();
            obj.BD_Restar_Stock_Producto(idprod, stock);

        }

        public void RN_Actualizar_PrecioCompra_Producto(string idprod, double precompraSol, double preVenta_mnor, double utilidad, double valoralmacen)
        {

            BD_Productos obj = new BD_Productos();
            obj.BD_Actualizar_PrecioCompra_Producto(idprod, precompraSol, preVenta_mnor, utilidad, valoralmacen);

        }

        public void RN_calcular_Valor_almacen(string idprod)
        {
            BD_Productos obj = new BD_Productos();
            obj.BD_calcular_Valor_almacen(idprod);
        }
        public void RN_calcular_utilidad_almacen(string idprod)
        {
            BD_Productos obj = new BD_Productos();
            obj.BD_calcular_utilidad_almacen(idprod);
        }


        public DataTable RN_Productos_masVendidos(DateTime startDate, DateTime endDate)
        {
            BD_Productos obj = new BD_Productos();
            return obj.BD_Productos_masVendidos(startDate, endDate);
        }


        public void RN_Igualar_Stock_Producto(string idprod, double stock)
        {
            BD_Productos obj = new BD_Productos();
            obj.BD_Igualar_Stock_Producto(idprod, stock);

        }

        public void RN_Cambiar_campo_estadoReporte(string idprod, string palabra)
        {
            BD_Productos obj = new BD_Productos();
            obj.BD_Cambiar_campo_estadoReporte(idprod, palabra);
            
        }

        public DataTable RN_Listar_todos_los_Productos_sinRotacion(string palabra)
        {
            BD_Productos obj = new BD_Productos();
            return obj.BD_Listar_todos_los_Productos_sinRotacion(palabra);
        }

        public DataTable RN_Buscar_Productos_Promociones(string valor)
        {
            BD_Productos obj = new BD_Productos();
            return obj.BD_Buscar_Productos_Promociones(valor);
        }

    }
}
