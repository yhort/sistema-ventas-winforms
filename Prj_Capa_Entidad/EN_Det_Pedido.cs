using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
   public class EN_Det_Pedido
    {


        private string _IdPed;

        private string _IdPro;

        private double _Precio;

        private double _Cantidad;

        private double _Importe;

        private string _Tipo_Prod;

        private string _Und;

        private double _Utilidad_Unit;

        private double _Totalutilidad;

        private string _AfectoIgv;
        private double _Precio_sinIgv;
        private double _subtotal_SinIgv;
        private double _Igv_subtotal;


        private int _idPresentacion;
        private decimal _cantidadPresentacion;
        private decimal _equivalencia;
        private string _nombrePresentacion;
        private decimal _cantidadBase;
        public double Totalutilidad { get => _Totalutilidad; set => _Totalutilidad = value; }
        public double Utilidad_Unit { get => _Utilidad_Unit; set => _Utilidad_Unit = value; }
        public string Und { get => _Und; set => _Und = value; }
        public string Tipo_Prod { get => _Tipo_Prod; set => _Tipo_Prod = value; }
        public double Importe { get => _Importe; set => _Importe = value; }
        public double Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public double Precio { get => _Precio; set => _Precio = value; }
        public string IdPro { get => _IdPro; set => _IdPro = value; }
        public string IdPed { get => _IdPed; set => _IdPed = value; }
        public string AfectoIgv { get => _AfectoIgv; set => _AfectoIgv = value; }
        public double Precio_sinIgv { get => _Precio_sinIgv; set => _Precio_sinIgv = value; }
        public double Subtotal_SinIgv { get => _subtotal_SinIgv; set => _subtotal_SinIgv = value; }
        public double Igv_subtotal { get => _Igv_subtotal; set => _Igv_subtotal = value; }
        public int IdPresentacion { get => _idPresentacion; set => _idPresentacion = value; }
        public decimal CantidadPresentacion { get => _cantidadPresentacion; set => _cantidadPresentacion = value; }
        public decimal Equivalencia { get => _equivalencia; set => _equivalencia = value; }
        public string NombrePresentacion { get => _nombrePresentacion; set => _nombrePresentacion = value; }
        public decimal CantidadBase { get => _cantidadBase; set => _cantidadBase = value; }
    }
}
