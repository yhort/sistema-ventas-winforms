using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Cierre_Caja
    {

        //@idCierre char (10),
        //@Apertura_Caja real,
        //@Total_Ingreso real,
        //@TotalEgreso real,
        //@Id_usu int,
        //@TodoDeposito real,
        //@TotalGanancia Real,
        //@TotalEntregado Real,
        //@SaldoSiguiente Real,
        //@TotalFactura Real,
        //@TotalBoleta Real,
        //@Totalnota Real,
        //@TotalCreditoCobrado real,
        //@TotalCreditoEmitido real



        private string _idcierre;
        private double _aperturaCaja;
        private double _totalIngreso;
        private double _totalEgreso;
        private int _idUsu;
        private double _todoDeposito;
        private double _totalGanancia;
        private double _totalEntregado;
        private double _SaldoSiguiente;
        private double _totalFactura;
        private double _totalBoleta;
        private double _totalNota;
        private double _totalCreditoCobrado;
        private double _totalCreditoEmitido;

        //se añaden campos nuevos pagos
        private double _totalEfectivo;
        private double _totalYape;
        private double _totalPlin;
        private double _totalTarjetasCred;

        //campo nuevo 8-7-24
        private string _nomnbreDesktop;

        //campo nuevo 230525
        private double _totalOtrosIngresos;


        public string Idcierre { get => _idcierre; set => _idcierre = value; }
        public double AperturaCaja { get => _aperturaCaja; set => _aperturaCaja = value; }
        public double TotalIngreso { get => _totalIngreso; set => _totalIngreso = value; }
        public double TotalEgreso { get => _totalEgreso; set => _totalEgreso = value; }
        public int IdUsu { get => _idUsu; set => _idUsu = value; }
        public double TodoDeposito { get => _todoDeposito; set => _todoDeposito = value; }
        public double TotalGanancia { get => _totalGanancia; set => _totalGanancia = value; }
        public double TotalEntregado { get => _totalEntregado; set => _totalEntregado = value; }
        public double SaldoSiguiente { get => _SaldoSiguiente; set => _SaldoSiguiente = value; }
        public double TotalFactura { get => _totalFactura; set => _totalFactura = value; }
        public double TotalBoleta { get => _totalBoleta; set => _totalBoleta = value; }
        public double TotalNota { get => _totalNota; set => _totalNota = value; }
        public double TotalCreditoCobrado { get => _totalCreditoCobrado; set => _totalCreditoCobrado = value; }
        public double TotalCreditoEmitido { get => _totalCreditoEmitido; set => _totalCreditoEmitido = value; }
        public double TotalEfectivo { get => _totalEfectivo; set => _totalEfectivo = value; }
        public double TotalYape { get => _totalYape; set => _totalYape = value; }
        public double TotalPlin { get => _totalPlin; set => _totalPlin = value; }
        public double TotalTarjetasCred { get => _totalTarjetasCred; set => _totalTarjetasCred = value; }
        public double TotalOtrosIngresos { get => _totalOtrosIngresos; set => _totalOtrosIngresos = value; }
        //public string NomnbreDesktop { get => _nomnbreDesktop; set => _nomnbreDesktop = value; }
    }
}
