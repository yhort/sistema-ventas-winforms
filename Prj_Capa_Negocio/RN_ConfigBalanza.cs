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
    public class RN_ConfigBalanza
    {
        private BD_ConfigBalanza datos = new BD_ConfigBalanza();

        public void RN_GuardarConfiguracion(EN_ConfigBalanza config)
        {
            datos.BD_GuardarConfiguracion(config);
        }

        public EN_ConfigBalanza RN_ObtenerConfiguracion()
        {
            return datos.BD_ObtenerConfiguracion(Environment.MachineName);
        }
    }
}
