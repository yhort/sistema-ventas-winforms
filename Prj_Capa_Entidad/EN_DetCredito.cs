using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_DetCredito
    {

        private string _idCredito;
        private double _acuenta;
        private double _saldoActual;
        private DateTime _fechaPago;
        private string _TipoPago;
        private string _NroOperacion;
        private int _idUsu;

        public int IdUsu { get => _idUsu; set => _idUsu = value; }
        public string NroOperacion { get => _NroOperacion; set => _NroOperacion = value; }
        public string TipoPago { get => _TipoPago; set => _TipoPago = value; }
        public DateTime FechaPago { get => _fechaPago; set => _fechaPago = value; }
        public double SaldoActual { get => _saldoActual; set => _saldoActual = value; }
        public double Acuenta { get => _acuenta; set => _acuenta = value; }
        public string IdCredito { get => _idCredito; set => _idCredito = value; }
    }
}
