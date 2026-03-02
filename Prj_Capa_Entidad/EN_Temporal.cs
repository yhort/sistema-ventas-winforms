using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Temporal
    {

        private string _idTemporal;
        private string _fechaEmi;
        private string _nomcliente;
        private string _Ruc;
        private string _direccion;
        private string _subtotal;
        private string _igv;
        private string _total;
        private string _Sonletra;
        private string _vendedor;
        private object _codigoQr;

        private string _Efectivo;
        private string _Vuelto;
        private string _TipoPago;
        private string _NroOperacion;

        //FE
        private string _tipocomprobante;
        private string _hash_cpe;
        private string _motivoEmision;
        private string _exonerada;
        


        public string Vendedor { get => _vendedor; set => _vendedor = value; }
        public string Sonletra { get => _Sonletra; set => _Sonletra = value; }
        public string Total { get => _total; set => _total = value; }
        public string Igv { get => _igv; set => _igv = value; }
        public string Subtotal { get => _subtotal; set => _subtotal = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Ruc { get => _Ruc; set => _Ruc = value; }
        public string Nomcliente { get => _nomcliente; set => _nomcliente = value; }
        public string FechaEmi { get => _fechaEmi; set => _fechaEmi = value; }
        public string IdTemporal { get => _idTemporal; set => _idTemporal = value; }
        public object CodigoQr { get => _codigoQr; set => _codigoQr = value; }
        public string Efectivo { get => _Efectivo; set => _Efectivo = value; }
        public string Vuelto { get => _Vuelto; set => _Vuelto = value; }
        public string TipoPago { get => _TipoPago; set => _TipoPago = value; }
        public string NroOperacion { get => _NroOperacion; set => _NroOperacion = value; }
        public string Tipocomprobante { get => _tipocomprobante; set => _tipocomprobante = value; }
        public string Hash_cpe { get => _hash_cpe; set => _hash_cpe = value; }
        public string MotivoEmision { get => _motivoEmision; set => _motivoEmision = value; }
        public string Exonerada { get => _exonerada; set => _exonerada = value; }
    }
}
