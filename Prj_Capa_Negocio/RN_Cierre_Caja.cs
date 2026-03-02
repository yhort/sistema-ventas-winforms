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
    public class RN_Cierre_Caja
    {

        public void RN_Registrar_Inicio_Caja(EN_Cierre_Caja cli)
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            obj.BD_Registrar_Inicio_Caja(cli);
        }

        public void RN_Registrar_Cierrede_Caja(EN_Cierre_Caja cli)
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            obj.BD_Registrar_Cierrede_Caja(cli);
        }

        public DataTable RN_Listar_Todas_CierresCaja()
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            return obj.BD_Listar_Todas_CierresCaja();
        }
        public DataTable RN_Listar_Cierre_Caja_delDia(DateTime fecha, string valor)
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            return obj.BD_Listar_Cierre_Caja_delDia(fecha,valor);
        }

        public DataTable RN_Listar_Cierre_Caja_delMes(DateTime fecha)
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            return obj.BD_Listar_Cierre_Caja_delMes(fecha);
        }

        public DataTable RN_Listar_Cierre_Caja_xUsuario(int usu)
        {

            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            return obj.BD_Listar_Cierre_Caja_xUsuario(usu);
        }

        public DataTable RN_Listar_Cierre_Caja_xUsuarioMes(int idusu, DateTime xfecha)
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            return obj.BD_Listar_Cierre_Caja_xUsuarioMes(idusu,xfecha);
        }
        public bool RN_Validar_InicioDoble_Caja()
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            return obj.BD_Validar_InicioDoble_Caja();
        }

        public DataTable RN_Listar_Cierre_Caja_porID(string idcierre)
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            return obj.BD_Listar_Cierre_Caja_porID(idcierre);
        }

        public DataTable RN_Calcular_Ventas_PorTipo_Doc(string nomTipoDoc)
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            return obj.BD_Calcular_Ventas_PorTipo_Doc(nomTipoDoc);
        }

        public DataTable RN_Calcular_Ventas_PorTipo_Pagox(string tipopagox)
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            return obj.BD_Calcular_Ventas_PorTipo_Pagox(tipopagox);
        }


        public DataTable RN_Calcular_Gastos_PorTipo_Pago(string tipopago)
        {

            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            return obj.BD_Calcular_Gastos_PorTipo_Pago(tipopago);
        }

        public DataTable RN_Calcular_Ventas_Acredito()
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            return obj.BD_Calcular_Ventas_Acredito();
        }


        public DataTable RN_Calcular_Ventas_Adeposito()
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            return obj.BD_Calcular_Ventas_Adeposito();
        }

        public DataTable RN_Calcular_Ganancias_Deldia()
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            return obj.BD_Calcular_Ganancias_Deldia();
        }

        //public bool RN_Validar_InicioDoble_Caja_2(string nompc)
        //{
        //    BD_Cierre_Caja obj = new BD_Cierre_Caja();
        //    return obj.BD_Validar_InicioDoble_Caja_2(nompc);

        //}


    }
}
