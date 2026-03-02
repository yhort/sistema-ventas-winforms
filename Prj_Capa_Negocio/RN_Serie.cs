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
    public class RN_Serie
    {
        public void RN_Registrar_Serie(EN_Serie ser)
        {

            BD_Serie obj = new BD_Serie();
            obj.BD_Registrar_Serie(ser);

        }

    }
}
