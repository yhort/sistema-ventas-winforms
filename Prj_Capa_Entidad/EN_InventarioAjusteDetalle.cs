using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_InventarioAjusteDetalle
    {

        private int _idDetalle;
        private int idAjuste;
        private string _idProducto;
        private int _idPresentacion;
        private decimal _stockSistema;
        private decimal _stockContado;
        private decimal _diferencia;
        private decimal _equivalencia;
        private decimal _diferenciaBase;

        public int IdDetalle { get => _idDetalle; set => _idDetalle = value; }
        public int IdAjuste { get => idAjuste; set => idAjuste = value; }
        public string IdProducto { get => _idProducto; set => _idProducto = value; }
        public int IdPresentacion { get => _idPresentacion; set => _idPresentacion = value; }
        public decimal StockSistema { get => _stockSistema; set => _stockSistema = value; }
        public decimal StockContado { get => _stockContado; set => _stockContado = value; }
        public decimal Diferencia { get => _diferencia; set => _diferencia = value; }
        public decimal Equivalencia { get => _equivalencia; set => _equivalencia = value; }
        public decimal DiferenciaBase { get => _diferenciaBase; set => _diferenciaBase = value; }
    }
}
