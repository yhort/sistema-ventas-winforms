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
    public class RN_ProductoPresentacion
    {

        BD_ProductoPresentacion obj = new BD_ProductoPresentacion();

        public void RN_Registrar_ProductoPresentacion(EN_ProductoPresentacion pre)
        {
            obj.BD_Registrar_ProductoPresentacion(pre);
        }

        public void RN_Editar_ProductoPresentacion(EN_ProductoPresentacion pre)
        {
            obj.BD_Editar_ProductoPresentacion (pre);
        }

        public void RN_Desactivar_ProductoPresentacion(int idPresentacion)
        {
            obj.BD_Desactivar_ProductoPresentacion(idPresentacion);
        }

        public DataTable RN_Listar_ProductoPresentacion_porProducto(string idProducto)
        {
            return obj.BD_Listar_ProductoPresentacion_PorProducto(idProducto);
        }

        public DataTable RN_Buscar_ProductoPresentacion_porId(int idPresentacion)
        {
            return obj.BD_Buscar_ProductoPresentacion_PorId(idPresentacion);
        }

    }
}
