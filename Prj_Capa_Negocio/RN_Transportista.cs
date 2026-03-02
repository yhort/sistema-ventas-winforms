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
    public class RN_Transportista
    {
        public void RN_Insertar_Transportista(EN_Transportista tr)
        {
            BD_Transportista obj = new BD_Transportista();
            obj.BD_Insertar_Transportista(tr);
        }

        public void RN_Editar_Transportista(EN_Transportista tr)
        {
            BD_Transportista obj = new BD_Transportista();
            obj.BD_Editar_Transportista(tr);

        }

        public DataTable RN_Mostrar_Transportista()
        {
            BD_Transportista obj = new BD_Transportista();
            return obj.BD_Mostrar_Transportista();
        }

       

    }
}
