using Prj_Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Prj_Capa_Negocio
{
    public class RN_Etiquetas
    {
        public DataTable RN_Buscar_Presentaciones_ParaEtiquetas(string valor, int idAlmacen)
        {
            BD_Etiquetas obj = new BD_Etiquetas();
            return obj.BD_Buscar_Presentaciones_ParaEtiquetas(valor, idAlmacen);
        }
    }
}
