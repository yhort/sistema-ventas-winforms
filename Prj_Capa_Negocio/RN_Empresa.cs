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
    public class RN_Empresa
    {

        public void RN_Editar_Empresa(EN_Empresa con)
        {
            BD_Empresa obj = new BD_Empresa();
            obj.BD_Editar_empresa(con);
        }

        public DataTable RN_Buscar_Empresa_porId(int id)
        {
            BD_Empresa obj = new BD_Empresa();
            return obj.BD_Buscar_Empresa_porId(id);
        }

        // Método para guardar el token asociado a un usuario
        public void RN_Guardar_Token_Usuario(int usuarioID, string token, DateTime fechaObtencion, DateTime fechaExpiracion)
        {
            BD_Empresa obj = new BD_Empresa();
            obj.BD_Guardar_Token_Usuario(usuarioID, token, fechaObtencion, fechaExpiracion);
        }

        // Método para obtener el token asociado a un usuario
        //public string RN_Obtener_Token_Usuario(int usuarioID)
        //{
        //    //BD_Empresa obj = new BD_Empresa();
        //    //return obj.BD_Obtener_Token_Usuario(usuarioID);
        //}

        // Método para verificar si el token es válido
        public bool RN_Token_Es_Valido(int usuarioID)
        {
            BD_Empresa obj = new BD_Empresa();
            EN_TokenInfo tokenData = obj.BD_Obtener_Token_Usuario(usuarioID);

            if( tokenData != null)
            {
                //
                DateTime fechaExpiracion = tokenData.FechaObtencion.AddHours(1);// Token válido por 1 hora
                if(fechaExpiracion > DateTime.Now)
                {
                    return true; //token aun valido
                }
            }

            //si el token no existe o esta expirado
            return false; //token expirado o no encontrado
        }

    }
}
