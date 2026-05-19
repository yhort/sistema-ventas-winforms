using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_InventarioCorteDetalle
    {
        /*
         namespace CapaEntidad
{
    public class EN_InventarioCorteDetalle
    {
        public int IdDetalle { get; set; }
        public int IdCorte { get; set; }
        public string IdProducto { get; set; }
        public int IdPresentacion { get; set; }
        public decimal StockPresentacion { get; set; }
        public decimal Equivalencia { get; set; }
        public decimal StockBaseEquivalente { get; set; }
        public decimal CostoPromedioBase { get; set; }
        public decimal ValorInventario { get; set; }
    }
}
         */

        private int _idDetalle;
        private int _idCorte;
        private string _idProducto;
        private int _idPresentacion;
        private decimal _stockPresentacion;
        private decimal _equivalencia;
        private decimal _stockBaseEquivalente;
        private decimal _costoPromedioBase;
        private decimal _valorInventario;

        public int IdDetalle { get => _idDetalle; set => _idDetalle = value; }
        public int IdCorte { get => _idCorte; set => _idCorte = value; }
        public string IdProducto { get => _idProducto; set => _idProducto = value; }
        public int IdPresentacion { get => _idPresentacion; set => _idPresentacion = value; }
        public decimal StockPresentacion { get => _stockPresentacion; set => _stockPresentacion = value; }
        public decimal Equivalencia { get => _equivalencia; set => _equivalencia = value; }
        public decimal StockBaseEquivalente { get => _stockBaseEquivalente; set => _stockBaseEquivalente = value; }
        public decimal CostoPromedioBase { get => _costoPromedioBase; set => _costoPromedioBase = value; }
        public decimal ValorInventario { get => _valorInventario; set => _valorInventario = value; }
    }
}
