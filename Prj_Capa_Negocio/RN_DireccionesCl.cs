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
    public class RN_DireccionesCl
    {

        public void RN_insertar_DireccionesCli(EN_DireccionesCl di)
        {
            BD_DireccionesCl obj = new BD_DireccionesCl();
            obj.BD_insertar_DireccionesCli(di);
        }

        public DataTable RN_Cargar_DireccionesCl()
        {
            BD_DireccionesCl obj = new BD_DireccionesCl();
            return obj.BD_Cargar_DireccionesCl();
        }

        public DataTable RN_ObtenerDireccionesPorCliente(string clienteId)
        {
            BD_DireccionesCl obj = new BD_DireccionesCl();
            return obj.BD_ObtenerDireccionesPorCliente(clienteId);
        }
    }
}
