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
    public class RN_TipoDoc
    {
        public static string RN_NroID(int idtipo)
        {
            return BD_Tipo_Doc.BD_NroID(idtipo);

        }

        public static void RN_Actualizar_SiguienteNro_Correlativo(int idtipo)
        {

            BD_Tipo_Doc.BD_Actualizar_SiguienteNro_Correlativo(idtipo);

        }

        public void RN_Actualizar_tipoCambio(int idtipo, double TipoCambio)
        {

            BD_Tipo_Doc obj = new BD_Tipo_Doc();
            obj.BD_Actualizar_tipoCambio(idtipo, TipoCambio);

        }

        public static double RN_Leer_TipoCambio(int idtipo)
        {
            return BD_Tipo_Doc.BD_Leer_TipoCambio(idtipo);
        }

        public static void RN_Actualizar_SiguienteNro_Correlativo_Producto(int idtipo) //para correlativos
        {
            BD_Tipo_Doc.BD_Actualizar_SiguienteNro_Correlativo(idtipo);
            
        }

        public DataTable RN_Listar_Doc_Especial()
        {
            BD_Tipo_Doc obj = new BD_Tipo_Doc();
            return obj.BD_Listar_Doc_Especial();
        }

        public void RN_editar_Nro_Correlativo(int idtipo, string docu, string sere, string numero)
        {
            BD_Tipo_Doc obj = new BD_Tipo_Doc();
            obj.BD_editar_Nro_Correlativo(idtipo, docu, sere, numero);
        }


        public DataTable RN_Listar_Todos_TipoDoc_porId(int idtipo)
        {
            BD_Tipo_Doc obj = new BD_Tipo_Doc();
            return obj.BD_Listar_Todos_TipoDoc_porId(idtipo);
        }


        public DataTable RN_Listar_Todos_TipoDoc()
        {
            BD_Tipo_Doc obj = new BD_Tipo_Doc();
            return obj.BD_Listar_Todos_TipoDoc();
        }

    }
}
