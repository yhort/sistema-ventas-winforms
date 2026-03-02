using Prj_Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prj_Capa_Entidad;

namespace Prj_Capa_Negocio
{
    public class RN_Canal
    {
        public void RN_Registrar_Canal(EN_Canal cl)
        {
            BD_Canal obj = new BD_Canal();
            obj.BD_Registrar_Canal(cl);
        }

        public DataTable RN_Mostrar_Canales()
        {
            BD_Canal obj = new BD_Canal();
            return obj.BD_Mostrar_Canales();
        }

        public DataTable RN_Buscar_Canal(string valor)
        {
            BD_Canal obj = new BD_Canal();
            return obj.BD_Buscar_Canal(valor);
        }

        public void RN_Editar_Canal(EN_Canal cln)
        {
            BD_Canal obj = new BD_Canal();
            obj.BD_Editar_Canal(cln);

        }

    }
}
