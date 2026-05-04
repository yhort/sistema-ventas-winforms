using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Det_IngresoCompra
    {
        private string _idingreso;
        private string _idproducto;
        private double _Precio;
        private double _Cantidad;
        private double _Importe;
        private int _idPresentacion;
        private decimal _cantidaPresentacion;
        private decimal _equivalencia;
        private string _nombrePresentacion;


        public double Importe { get => _Importe; set => _Importe = value; }
        public double Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public double Precio { get => _Precio; set => _Precio = value; }
        public string Idproducto { get => _idproducto; set => _idproducto = value; }
        public string Idingreso { get => _idingreso; set => _idingreso = value; }
        public int IdPresentacion { get => _idPresentacion; set => _idPresentacion = value; }
        public decimal CantidaPresentacion { get => _cantidaPresentacion; set => _cantidaPresentacion = value; }
        public decimal Equivalencia { get => _equivalencia; set => _equivalencia = value; }
        public string NombrePresentacion { get => _nombrePresentacion; set => _nombrePresentacion = value; }
    }
}
