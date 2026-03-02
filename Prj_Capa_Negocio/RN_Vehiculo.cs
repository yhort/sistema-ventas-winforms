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
    public class RN_Vehiculo
    {
        public void RN_Registrar_Vehiculo(EN_Vehiculo veh)
        {
            BD_Vehiculo obj = new BD_Vehiculo();
            obj.BD_Registrar_Vehiculo(veh);
        }

        public DataTable RN_Cargar_Vehiculo_xEstado(string valor, string estado)
        {
            BD_Vehiculo obj = new BD_Vehiculo();
            return obj.BD_Cargar_Vehiculo_xEstado(valor ,estado);
        }

        public DataTable RN_Mostrar_Todos_Vehiculo()
        {
            BD_Vehiculo obj = new BD_Vehiculo();
            return obj.BD_Mostrar_Todos_Vehiculo();
        }

        public void RN_Editar_Vehiculo(EN_Vehiculo vehed)
        {
            BD_Vehiculo obj = new BD_Vehiculo();
            obj.BD_Editar_Vehiculo(vehed);
        }

        public void RN_Eliminar_Vehiculo(int idve)
        {
            BD_Vehiculo obj = new BD_Vehiculo();
            obj.BD_Eliminar_Vehiculo(idve);
        }

    }
}
