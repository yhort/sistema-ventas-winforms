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
    public class RN_Caja
    {

        public void RN_Registrar_Mov_Caja(En_Caja cja)
        {
            BD_Caja obj = new BD_Caja();
            obj.BD_Registrar_Mov_Caja(cja);
        }

        public void RN_Actualizar_Total_Caja(string nroDoc, double total, double totalUtili, string tipoPago)
        {
            BD_Caja obj = new BD_Caja();
            obj.BD_Actualizar_Total_Caja(nroDoc, total, totalUtili, tipoPago); 
        }

        public DataTable RN_Listar_Todas_Cajas()
        {
            BD_Caja obj = new BD_Caja();
            return obj.BD_Listar_Todas_Cajas();
        }

        public DataTable RN_Listar_Cajas_Del_Dia(DateTime xdia)
        {
            BD_Caja obj = new BD_Caja();
            return obj.BD_Listar_Cajas_Del_Dia(xdia);
        }

        //  se implemnto fecha 24/07/24 para mostrar del dia en explorador caja
        public DataTable RN_Listar_Cajas_Del_Dia_Rep(DateTime xdia)
        {
            BD_Caja obj = new BD_Caja();
            return obj.BD_Listar_Cajas_Del_Dia_Rep(xdia);
        }
    

        public DataTable RN_Listar_Cajas_Del_Mes(DateTime mesx)
        {
            BD_Caja obj = new BD_Caja();
            return obj.BD_Listar_Cajas_Del_Mes(mesx);
        }

        public DataTable RN_buscador_General_Cajas(string valor)
        {
            BD_Caja obj = new BD_Caja();
            return obj.BD_buscador_General_Cajas(valor);
        }

        public void RN_Anular_Mov_Caja(string nrodoc, string estadoCaja)
        {
            BD_Caja obj = new BD_Caja();
            obj.BD_Anular_Mov_Caja(nrodoc, estadoCaja);
        }

        public void RN_Anular_Mov_Caja2(string nrodoc)
        {
            BD_Caja obj = new BD_Caja();
            obj.BD_Anular_Mov_Caja2(nrodoc);
        }

        public DataTable RN_Leer_Caja_porId(string idrepcaja)
        {
            BD_Caja obj = new BD_Caja();
            return obj.BD_Leer_Caja_porId(idrepcaja);
        }

        public DataTable RN_buscador_VentasCajaTotalizado(int id, DateTime fechaIni, DateTime fechaFin)
        {
            BD_Caja obj = new BD_Caja();
            return obj.BD_buscador_VentasCajaTotalizado(id, fechaIni, fechaFin);
        }

        public void RN_CambiarModo_Caja(string idcaja)
        {
            BD_Caja obj = new BD_Caja();
            obj.BD_CambiarModo_Caja(idcaja);
        }

        public DataTable RN_Filtrar_MoviCaja_xrangoFech(DateTime desde, DateTime hasta)
        {
            BD_Caja obj = new BD_Caja();
            return obj.BD_Filtrar_MoviCaja_xrangoFech( desde, hasta);
        }
    }
}
