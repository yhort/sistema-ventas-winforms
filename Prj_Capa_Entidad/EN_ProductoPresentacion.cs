using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_ProductoPresentacion
    {
        private int _idPresentacion;
        private string _idProducto;
        private string _nombrePresentacion;
        private string _abreviatura;
        private decimal _equivalencia;
        private decimal _precioCompra;
        private decimal _precioVentaMinorista;
        private decimal _precioVentaMayorista;
        private decimal _cantMinMayorista;
        private bool _esBase;
        private bool _permiteCompra;
        private bool _permiteVenta;
        private bool _activo;
        private string _codigoBarra;
        private string _SKU;

        public int IdPresentacion { get => _idPresentacion; set => _idPresentacion = value; }
        public string IdProducto { get => _idProducto; set => _idProducto = value; }
        public string NombrePresentacion { get => _nombrePresentacion; set => _nombrePresentacion = value; }
        public string Abreviatura { get => _abreviatura; set => _abreviatura = value; }
        public decimal Equivalencia { get => _equivalencia; set => _equivalencia = value; }
        public decimal PrecioCompra { get => _precioCompra; set => _precioCompra = value; }
        public decimal PrecioVentaMinorista { get => _precioVentaMinorista; set => _precioVentaMinorista = value; }
        public decimal PrecioVentaMayorista { get => _precioVentaMayorista; set => _precioVentaMayorista = value; }
        public decimal CantMinMayorista { get => _cantMinMayorista; set => _cantMinMayorista = value; }
        public bool EsBase { get => _esBase; set => _esBase = value; }
        public bool PermiteCompra { get => _permiteCompra; set => _permiteCompra = value; }
        public bool PermiteVenta { get => _permiteVenta; set => _permiteVenta = value; }
        public bool Activo { get => _activo; set => _activo = value; }
        public string CodigoBarra { get => _codigoBarra; set => _codigoBarra = value; }
        public string SKU { get => _SKU; set => _SKU = value; }
    }
}
