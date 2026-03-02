using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using System.Data;

namespace Prj_Capa_Negocio
{
    public class RN_Temporal
    {

        public void RN_Registrar_Temporal(EN_Temporal tem)
        {
            BD_Temporal obj = new BD_Temporal();
            obj.BD_Registrar_Temporal(tem);
        }

        public void RN_Registrar_Detalle_Temporal(EN_Det_Temporal tem)
        {
            BD_Temporal obj = new BD_Temporal();
            obj.BD_Registrar_Detalle_Temporal(tem);
        }

        public DataTable RN_Leer_Temporal_porId(string idtempo)
        {
            BD_Temporal obj = new BD_Temporal();
            return obj.BD_Leer_Temporal_porId(idtempo);
        }

        public void RN_Eliminar_Temporal(string idTempo)
        {
            BD_Temporal obj = new BD_Temporal();
            obj.BD_Eliminar_Temporal(idTempo);
        }

        public void RN_Eliminar_Temporal_V()
        {
            BD_Temporal obj = new BD_Temporal();
            obj.BD_Eliminar_Temporal_V();
        }

    }
}
