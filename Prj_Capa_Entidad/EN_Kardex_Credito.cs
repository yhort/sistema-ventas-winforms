using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Kardex_Credito
    {

        //@Id_KrdxCred char (13),
        //@item int,
        //@FechaAbono datetime,
        //@DocRef nchar(20),
        //@DetOperacion varchar(50),
        //@TotalCred real,
        //@A_Cuenta real,
        //@Saldo_Pendiente real

        private string _idkardex;
        private int _item;
        private DateTime _fechaAbono;
        private string _docreference;
        private string _detOperacion;
        private double _totalCredito;
        private double _Acuenta;
        private double _SaldoPendiente;

        public string Idkardex { get => _idkardex; set => _idkardex = value; }
        public int Item { get => _item; set => _item = value; }
        public DateTime FechaAbono { get => _fechaAbono; set => _fechaAbono = value; }
        public string Docreference { get => _docreference; set => _docreference = value; }
        public string DetOperacion { get => _detOperacion; set => _detOperacion = value; }
        public double TotalCredito { get => _totalCredito; set => _totalCredito = value; }
        public double Acuenta { get => _Acuenta; set => _Acuenta = value; }
        public double SaldoPendiente { get => _SaldoPendiente; set => _SaldoPendiente = value; }
    }
}
