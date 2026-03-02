using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class En_Caja
    {

        //@Fecha_Caja datetime,
        //@Tipo_Caja varchar(50),
        //@Concepto varchar(190),
        //@De_Para varchar(180),
        //@Nro_Doc char (20),
        //@ImporteCaja real,
        //@Id_Usu int,
        //@TotalUti real,
        //@TipoPago varchar(13),
        //@GeneradoPor varchar(15)

        private DateTime _FechaCaja;
        private string _TipoCaja;
        private string _Concepto;
        private string _De_Para_Cliente;
        private string _Nro_Doc;
        private double _ImportaCaja;
        private int _IdUsu;
        private double _TotalUti;
        private string _TipoPago;
        private string _GeneradoPor;
        private string _tipoPago2;
        private string _idcaja; //se añade string para lois tipo pagos mx 13/05/24

        /*
        //nuevos campos para el metodo editar movicaja:
        private int _Idcaja;
        private string _Estado;
        */


        public DateTime FechaCaja { get => _FechaCaja; set => _FechaCaja = value; }
        public string TipoCaja { get => _TipoCaja; set => _TipoCaja = value; }
        public string Concepto { get => _Concepto; set => _Concepto = value; }
        public string De_Para_Cliente { get => _De_Para_Cliente; set => _De_Para_Cliente = value; }
        public string Nro_Doc { get => _Nro_Doc; set => _Nro_Doc = value; }
        public double ImportaCaja { get => _ImportaCaja; set => _ImportaCaja = value; }
        public int IdUsu { get => _IdUsu; set => _IdUsu = value; }
        public double TotalUti { get => _TotalUti; set => _TotalUti = value; }
        public string TipoPago { get => _TipoPago; set => _TipoPago = value; }
        public string GeneradoPor { get => _GeneradoPor; set => _GeneradoPor = value; }
        public string Idcaja { get => _idcaja; set => _idcaja = value; }
        //public string TipoPago2 { get => _tipoPago2; set => _tipoPago2 = value; }
        // public int Idcaja { get => _Idcaja; set => _Idcaja = value; }
        //public string Estado { get => _Estado; set => _Estado = value; }

    }
}
