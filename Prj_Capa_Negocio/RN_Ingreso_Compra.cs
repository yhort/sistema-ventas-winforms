using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;

namespace Prj_Capa_Negocio
{
    public class RN_Ingreso_Compra
    {
        public void RN_Ingresar_RegistroCompra(EN_IngresoCompra com)
        {
            BD_Ingreso_Compra obj = new BD_Ingreso_Compra();
            obj.BD_Ingresar_RegistroCompra(com);
        }

        public void RN_Ingresar_Detalle_RegistroCompra(EN_Det_IngresoCompra det)
        {
            BD_Ingreso_Compra obj = new BD_Ingreso_Compra();
            obj.BD_Ingresar_Detalle_RegistroCompra(det);
        }

        public bool RN_Verificar_NroDni_Fisico(string idfisico)
        {
            BD_Ingreso_Compra obj = new BD_Ingreso_Compra();
            return obj.BD_Verificar_NroDoc_Fisico(idfisico);

        }

        public DataTable RN_buscar_Compras_Explorador(string valor) // SE AGREGO DESDE BD_INGRESO_COMPRA PASO2. DEVUELVE VALOR SQL
        {
            BD_Ingreso_Compra obj = new BD_Ingreso_Compra();
            return obj.BD_buscar_Compras_Explorador(valor);
        }

        public DataTable RN_Cargar_Todas_Compras()
        {
            BD_Ingreso_Compra obj = new BD_Ingreso_Compra();
            return obj.BD_Cargar_Todas_Compras();
        }

        public DataTable RN_buscar_Compras_Explorador_Pormes_Dia(string tipo, DateTime fechames)
        {
            BD_Ingreso_Compra obj = new BD_Ingreso_Compra();
            return obj.BD_buscar_Compras_Explorador_Pormes_Dia(tipo, fechames);
        }

        public void RN_borrar_Compra(string idcompra)  //No hace falta poner return, ya que no devuelve valor.
        {
            BD_Ingreso_Compra obj = new BD_Ingreso_Compra();
            obj.BD_borrar_Compra(idcompra);
        }

        public DataTable RN_buscar_Compras_conDetalle(string idcompra)
        {
            BD_Ingreso_Compra obj = new BD_Ingreso_Compra();
            return obj.BD_buscar_Compras_conDetalle(idcompra);
        }

        public DataTable RN_Compras_RangoFechas(DateTime diax, DateTime diax2)
        {
            BD_Ingreso_Compra obj = new BD_Ingreso_Compra();
            return obj.BD_Compras_RangoFechas(diax, diax2);
        }
    }
}
