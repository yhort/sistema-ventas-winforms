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
    public class RN_Cliente
    {
        public bool RN_Verificar_NroDni(string NroDni)
        {
            BD_Cliente obj = new BD_Cliente();
            return obj.BD_Verificar_NroDni(NroDni);
        }

        public void RN_insertar_Cliente(EN_Cliente cli)
        {
            BD_Cliente obj = new BD_Cliente();
            obj.BD_insertar_Cliente(cli);
        }

        public void RN_Editar_Cliente(EN_Cliente cli)
        {
            BD_Cliente obj = new BD_Cliente();
            obj.BD_Editar_Cliente(cli);
        }

        public DataTable RN_Cargar_Todos_Cliente(string estado)
        {
            BD_Cliente obj = new BD_Cliente();
            return obj.BD_Cargar_Todos_Cliente(estado);
        }

        public DataTable RN_buscar_Cliente(string valor, string estado)
        {
            BD_Cliente obj = new BD_Cliente();
            return obj.BD_buscar_Cliente(valor, estado);
        }

        public void RN_dardeBaja_Cliente(string idcliente)
        {
            BD_Cliente obj = new BD_Cliente();
            obj.BD_dardeBaja_Cliente(idcliente);
        }

        public void RN_Eliminar_Cliente(string idcliente)
        {
            BD_Cliente obj = new BD_Cliente();
            obj.BD_Eliminar_Cliente(idcliente);
        }

        public DataTable RN_Listar_CodTipoDocIdent()
        {
            BD_Cliente obj = new BD_Cliente();
            return obj.BD_Listar_CodTipoDocIdent();
        }

        public DataTable RN_Listar_Clientes()
        {
            BD_Cliente obj = new BD_Cliente();
            return obj.BD_Listar_Clientes();
        }

    }
}
