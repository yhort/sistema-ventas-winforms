using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Prj_Capa_Datos;

namespace Prj_Capa_Negocio
{
   public  class RN_Distrito
    {

        public void RN_Registrar_Distrito(string nomDist)
        {
            BD_Distrito obj = new BD_Distrito();
            obj.BD_Registrar_Distrito(nomDist);
            
        }

        public void RN_Editar_Distritos(int idDis, string nomDis)
        {
            BD_Distrito obj = new BD_Distrito();
            obj.BD_Editar_Distritos(idDis, nomDis);
        }

        public DataTable RN_Mostrar_Todos_Distritos()
        {
            BD_Distrito obj = new BD_Distrito();
            return obj.BD_Mostrar_Todos_Distritos();
        }

        public void RN_Eliminar_Distrito(int idDis)
        {
            BD_Distrito obj = new BD_Distrito();
            obj.BD_Eliminar_Distrito(idDis);
        }


        public DataTable RN_Buscar_Distrito(string valor)
        {
            BD_Distrito obj = new BD_Distrito();
            return obj.BD_Buscar_Distrito(valor);
        }

    }
}
