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
    public class RN_Operaciones_Ubigeo
    {

        public DataTable RN_ListarDepartamentos()
        {
            BD_Operaciones_Ubigeo obj = new BD_Operaciones_Ubigeo();
            return obj.BD_ListarDepartamentos();

        

        }
        public DataTable RN_ListarProvinciaporDepartamentoId(int CodigoDepartamento)
        {
            BD_Operaciones_Ubigeo obj = new BD_Operaciones_Ubigeo();
            return obj.BD_ListarProvinciaporDepartamentoId(CodigoDepartamento);
        }

        public DataTable RN_ListarDistrito_ProvinciaId(int CodigoProvincia)
        {
            BD_Operaciones_Ubigeo obj = new BD_Operaciones_Ubigeo();
            return obj.BD_ListarDistrito_ProvinciaId(CodigoProvincia);
        }
    }
}
