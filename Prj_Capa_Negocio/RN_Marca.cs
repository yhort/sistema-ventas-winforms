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
    public class RN_Marca
    {

        public void RN_Registrar_Marcas(string nomMarca)
        {
            BD_Marcas obj = new BD_Marcas();
            obj.BD_Registrar_Marcas(nomMarca);

        }


        public void RN_Editar_Marcas(int idmar, string nomMarca)
        {
            BD_Marcas obj = new BD_Marcas();
            obj.BD_Editar_Marcas(idmar, nomMarca);
        }

        public DataTable RN_Mostrar_Todas_Marcas()
        {
            BD_Marcas obj = new BD_Marcas();
            return obj.BD_Mostrar_Todas_Marcas();
        }

        public void RN_Eliminar_Marcas(int idmar)
        {
            BD_Marcas obj = new BD_Marcas();
            obj.BD_Eliminar_Marcas(idmar);
        }

        public DataTable BD_Buscar_Marca(string valor)
        {
            BD_Marcas obj = new BD_Marcas();
            return obj.BD_Buscar_Marca(valor);
        }

    }
}
