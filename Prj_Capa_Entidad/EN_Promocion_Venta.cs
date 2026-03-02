using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Promocion_Venta
    {
        private string _idDoc;
        private int _idPromocion;
        private double _descuento;

        public string IdDoc { get => _idDoc; set => _idDoc = value; }
        public int IdPromocion { get => _idPromocion; set => _idPromocion = value; }
        public double Descuento { get => _descuento; set => _descuento = value; }
    }
}
