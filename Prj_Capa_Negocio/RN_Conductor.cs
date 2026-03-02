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
    public class RN_Conductor
    {

        public void RN_Registrar_Conductor(EN_Choferes con)
        {
            BD_Conductor obj = new BD_Conductor();
            obj.BD_Registrar_Conductor(con);
        }

        public DataTable RN_Mostrar_Conductores()
        {
            BD_Conductor obj = new BD_Conductor();
            return obj.BD_Mostrar_Todos_Conductores();
        }

        public void RN_Editar_Conductor(EN_Choferes ediCon)
        {
            BD_Conductor obj = new BD_Conductor();
            obj.BD_Editar_Conductor(ediCon);
        }

        public void RN_Eliminar_Conductor(int idcond)
        {
            BD_Conductor obj = new BD_Conductor();
            obj.BD_Eliminar_Conductor(idcond);
        }
        public DataTable RN_BuscarConductor(string valor, string estado)
        {
            BD_Conductor obj = new BD_Conductor();
            return obj.BD_BuscarConductor(valor, estado);
        }

    }
}
