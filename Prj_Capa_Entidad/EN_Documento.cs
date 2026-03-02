using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Documento
    {

        //       @id_Doc char (11),	
        //@id_Ped char (11),	
        //@Id_Tipo int,
        //@Fecha_Emi date,
        //   @Importe real,
        //@TipoPago varchar(50),
        //@NroOpera nchar(20),	
        //@id_Usu int,
        //@Igv real,
        //   @son varchar(180),
        //@TotalGanancia real

           


        private string _idDoc;
        private string _idPed;
        private int _IdTipo;
        private DateTime _Fecha_DocEmi;
        private double _Importe;
        //agregando campors efectivo-vuelto 12/01/23 //TABLA DOCUMENTO
        //SP_INSERTDOCUM. 
        private double _Efectivo;
        private double _Vuelto;

        //campos agregando pagos mixto
        private string _tipoPago2;
        private double _efec2;

        private string _TipoPago;
        private string _Nr_Operacion;
        private int _IdUsu;
        private double _Igv;
        private string _SonLetra;
        private Double _TotalGanancia;
        private string _CdrSunat;
        private string _Hash_CPE;
        private string _EstadoBaja;
        private string _NroTicket_baja;
        private string _Hash_cpeBaja;
        private int _idCanal;

        public string IdDoc { get => _idDoc; set => _idDoc = value; }
        public string IdPed { get => _idPed; set => _idPed = value; }
        public int IdTipo { get => _IdTipo; set => _IdTipo = value; }
        public DateTime Fecha_DocEmi { get => _Fecha_DocEmi; set => _Fecha_DocEmi = value; }
        public double Importe { get => _Importe; set => _Importe = value; }
        public string TipoPago { get => _TipoPago; set => _TipoPago = value; }
        public string Nr_Operacion { get => _Nr_Operacion; set => _Nr_Operacion = value; }
        public int IdUsu { get => _IdUsu; set => _IdUsu = value; }
        public double Igv { get => _Igv; set => _Igv = value; }
        public string SonLetra { get => _SonLetra; set => _SonLetra = value; }
        public double TotalGanancia { get => _TotalGanancia; set => _TotalGanancia = value; }
        public double Efectivo { get => _Efectivo; set => _Efectivo = value; }
        public double Vuelto { get => _Vuelto; set => _Vuelto = value; }
        public string CdrSunat { get => _CdrSunat; set => _CdrSunat = value; }
        public string Hash_CPE { get => _Hash_CPE; set => _Hash_CPE = value; }
        public string EstadoBaja { get => _EstadoBaja; set => _EstadoBaja = value; }
        public string NroTicket_baja { get => _NroTicket_baja; set => _NroTicket_baja = value; }
        public string Hash_cpeBaja { get => _Hash_cpeBaja; set => _Hash_cpeBaja = value; }
        public int IdCanal { get => _idCanal; set => _idCanal = value; }

        //public double Efec2 { get => _efec2; set => _efec2 = value; }
        //public string TipoPago2 { get => _tipoPago2; set => _tipoPago2 = value; }
    }
}
