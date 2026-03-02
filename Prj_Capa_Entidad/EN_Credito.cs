using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Credito
    {
        private string _idcredito;
        private string _idDoc;
        private DateTime _Fecha_Credito;
        private string _nomCliente;
        private double _TotalCredito;
        private double _Saldo_Pdnte;
        private DateTime _Fecha_Vencimiento;

        public DateTime Fecha_Vencimiento { get => _Fecha_Vencimiento; set => _Fecha_Vencimiento = value; }
        public double Saldo_Pdnte { get => _Saldo_Pdnte; set => _Saldo_Pdnte = value; }
        public double TotalCredito { get => _TotalCredito; set => _TotalCredito = value; }
        public string NomCliente { get => _nomCliente; set => _nomCliente = value; }
        public DateTime Fecha_Credito { get => _Fecha_Credito; set => _Fecha_Credito = value; }
        public string IdDoc { get => _idDoc; set => _idDoc = value; }
        public string Idcredito { get => _idcredito; set => _idcredito = value; }
    }
}
