using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Det_Temporal
    {

        private string _idTempo;
        private string _codProd;
        private string _canti;
        private string _producto;
        private string _Precio;
        private string _Importe;
       

        public string Importe { get => _Importe; set => _Importe = value; }
        public string Precio { get => _Precio; set => _Precio = value; }
        public string Producto { get => _producto; set => _producto = value; }
        public string Canti { get => _canti; set => _canti = value; }
        public string CodProd { get => _codProd; set => _codProd = value; }
        public string IdTempo { get => _idTempo; set => _idTempo = value; }
      
    }
}
