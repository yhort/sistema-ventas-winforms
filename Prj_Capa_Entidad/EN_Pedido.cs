using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Pedido
    {

        private string _IdPedido;
        private string _IdCliente;
        private Double _SubTotal;
        private DateTime _FechaPed;
        private double _Igv;
        private double _TotalPed;
        private int _IdUsu;
        private double _TotalGancia;

        private double _subtotal_gravado;
        private double _IgvGravado;
        private double _TotalGravado;

        private double _exonerada;

        public double TotalGancia { get => _TotalGancia; set => _TotalGancia = value; }
        public int IdUsu { get => _IdUsu; set => _IdUsu = value; }
        public double TotalPed { get => _TotalPed; set => _TotalPed = value; }
        public double Igv { get => _Igv; set => _Igv = value; }
        public DateTime FechaPed { get => _FechaPed; set => _FechaPed = value; }
        public double SubTotal { get => _SubTotal; set => _SubTotal = value; }
        public string IdCliente { get => _IdCliente; set => _IdCliente = value; }
        public string IdPedido { get => _IdPedido; set => _IdPedido = value; }
        public double Subtotal_gravado { get => _subtotal_gravado; set => _subtotal_gravado = value; }
        public double IgvGravado { get => _IgvGravado; set => _IgvGravado = value; }
        public double TotalGravado { get => _TotalGravado; set => _TotalGravado = value; }
        public double Exonerada { get => _exonerada; set => _exonerada = value; }
    }
}
