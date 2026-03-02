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
    public class RN_Usuario
    {
        public bool RN_Login(string usu, string clave)
        {
            BD_Usuario obj = new BD_Usuario();
            return obj.BD_Login(usu, clave);
        }

        public DataTable RN_Buscar_Usuario(string nomusu)
        {
            BD_Usuario obj = new BD_Usuario();
            return obj.BD_Buscar_Usuario(nomusu);
        }

        public void RN_insertar_Usuario(EN_Usuario us)
        {
            BD_Usuario obj = new BD_Usuario();
            obj.BD_insertar_Usuario(us);
        }

        public void RN_Editar_Usuario(EN_Usuario use)
        {
            BD_Usuario obj = new BD_Usuario();
            obj.BD_Editar_Usuario(use);
        }
        public DataTable RN_Buscar_UsuarioxEstado(string valor)
        {
            BD_Usuario obj = new BD_Usuario();
            return obj.BD_Buscar_UsuarioxEstado(valor);
        }

        public DataTable RN_buscar_usuarioNombre(string valor, string estado)
        {
            BD_Usuario obj = new BD_Usuario();
            return obj.BD_buscar_usuarioNombre(valor, estado);
        }

        public DataTable RN_Mostrar_Roles()
        {
            BD_Roles obj = new BD_Roles();
            return obj.BD_Mostrar_Roles();
        }

        public DataTable RN_Listar_Todos_Usuarios(int idEmpresa)
        {
            BD_Usuario obj = new BD_Usuario();
            return obj.BD_Listar_Todos_Usuarios(idEmpresa);
        }
        public DataTable RN_Buscar_Usuario_xIds(int idusu, int idempresa)
        {
            BD_Usuario obj = new BD_Usuario();
            return obj.BD_Buscar_Usuario_xIds(idusu,idempresa);
        }

        public void RN_Eliminar_Usuario(int idusu)
        {
            BD_Usuario obj = new BD_Usuario();
            obj.BD_Eliminar_Usuario(idusu);
        }
    }
}
