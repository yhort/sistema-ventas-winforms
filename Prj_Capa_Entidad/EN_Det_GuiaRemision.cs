using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Det_GuiaRemision
    {
        private string _idgr;
        private string _idproducto;
        private double _Precio;
        private double _Cantidad;
        private double _Importe;

        public double Importe { get => _Importe; set => _Importe = value; }
        public double Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public double Precio { get => _Precio; set => _Precio = value; }
        public string Idproducto { get => _idproducto; set => _idproducto = value; }
        public string Idgr { get => _idgr; set => _idgr = value; }
    }
}
