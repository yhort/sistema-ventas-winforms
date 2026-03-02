using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Producto
    {

        //@idpro char (20),
        //@idprove char (6),
        //@descripcion varchar(150),
        //@frank real,
        //@Pre_compraSol real,
        //@pre_CompraDolar real,
        //@StockActual real,
        //@idCat int,
        //@idMar int,
        ////@Foto varchar(180),
        //@Pre_Venta_Menor real,
        //@Pre_Venta_Mayor real,
        //@Pre_Venta_Dolar real,
        //@UndMdida char (6),
        //@PesoUnit real,
        //@Utilidad real,
        //@TipoProd varchar(12),
        //@ValorporProd real

        private string _idproducto;
        private string _idproveedor;
        private string _descripcionGeneral;
        private double _frank;
        private double _PreCompra_Sol;
        private double _PreCompra_Dlr;
        private double _stock;
        private int _idcategoria;
        private int _idmarca;
        private string _foto;
        private double _PreVenta_Mnr;
        private double _PreVenta_Myr;
        private double _PreVenta_Dolr;
        private string _UndMedida;
        private double _PesoUnit;
        private double _UtilidadUnit;
        private string _TipoProducto;
        private double _valorGeneral;

        //private string _tipoProd_Sunat;
        private string _codTipoAfectacion_Sunat;//para 10 gravado, 20 exonerado
        private string _tipoAfectacion_Sunat; //

        //para prodc (stok - o no)
        private bool _controlaStock;
        private decimal _preventaLista; 



        public string Idproducto { get => _idproducto; set => _idproducto = value; }
        public string Idproveedor { get => _idproveedor; set => _idproveedor = value; }
        public string DescripcionGeneral { get => _descripcionGeneral; set => _descripcionGeneral = value; }
        public double Frank { get => _frank; set => _frank = value; }
        public double PreCompra_Sol { get => _PreCompra_Sol; set => _PreCompra_Sol = value; }
        public double PreCompra_Dlr { get => _PreCompra_Dlr; set => _PreCompra_Dlr = value; }
        public double Stock { get => _stock; set => _stock = value; }
        public int Idcategoria { get => _idcategoria; set => _idcategoria = value; }
        public int Idmarca { get => _idmarca; set => _idmarca = value; }
        public string Foto { get => _foto; set => _foto = value; }
        public double PreVenta_Mnr { get => _PreVenta_Mnr; set => _PreVenta_Mnr = value; }
        public double PreVenta_Myr { get => _PreVenta_Myr; set => _PreVenta_Myr = value; }
        public double PreVenta_Dolr { get => _PreVenta_Dolr; set => _PreVenta_Dolr = value; }
        public string UndMedida { get => _UndMedida; set => _UndMedida = value; }
        public double PesoUnit { get => _PesoUnit; set => _PesoUnit = value; }
        public double UtilidadUnit { get => _UtilidadUnit; set => _UtilidadUnit = value; }
        public string TipoProducto { get => _TipoProducto; set => _TipoProducto = value; }
        public double ValorGeneral { get => _valorGeneral; set => _valorGeneral = value; }
       //public string TipoProd_Sunat { get => _tipoProd_Sunat; set => _tipoProd_Sunat = value; }
        public string TipoAfectacion_Sunat { get => _tipoAfectacion_Sunat; set => _tipoAfectacion_Sunat = value; }
        public string CodTipoAfectacion_Sunat { get => _codTipoAfectacion_Sunat; set => _codTipoAfectacion_Sunat = value; }
        public bool ControlaStock { get => _controlaStock; set => _controlaStock = value; }
        public decimal PreventaLista { get => _preventaLista; set => _preventaLista = value; }
    }
}
