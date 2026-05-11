using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_IngresoCompra
    {
        private string _idCom;
        private string _NroDoc_Fisico;
        private string _IdProvee;
        private Double _SubTotal_Com;
        private DateTime _FechaIngre;
        private double _TotalCompra;
        private int _IdUsu;
        private string _ModalidadPago;
        private int _TiempoEspera;
        private DateTime _FechaVence;
        private string _EstadoIngre;
        private bool _RecibiConforme;
        private string _Datos_Adicional;
        private string _Tipo_Doc_Compra;

        //para salida:
        private string _tipoRegistro;
        private string _lugarSalida;
        private string _tipoProceso;
        private string _trnCodigo;

        private decimal _igv;

        public string Tipo_Doc_Compra { get => _Tipo_Doc_Compra; set => _Tipo_Doc_Compra = value; }
        public string Datos_Adicional { get => _Datos_Adicional; set => _Datos_Adicional = value; }
        public bool RecibiConforme { get => _RecibiConforme; set => _RecibiConforme = value; }
        public string EstadoIngre { get => _EstadoIngre; set => _EstadoIngre = value; }
        public DateTime FechaVence { get => _FechaVence; set => _FechaVence = value; }
        public int TiempoEspera { get => _TiempoEspera; set => _TiempoEspera = value; }
        public string ModalidadPago { get => _ModalidadPago; set => _ModalidadPago = value; }
        public int IdUsu { get => _IdUsu; set => _IdUsu = value; }
        public double TotalCompra { get => _TotalCompra; set => _TotalCompra = value; }
        public DateTime FechaIngre { get => _FechaIngre; set => _FechaIngre = value; }
        public double SubTotal_Com { get => _SubTotal_Com; set => _SubTotal_Com = value; }
        public string IdProvee { get => _IdProvee; set => _IdProvee = value; }
        public string NroDoc_Fisico { get => _NroDoc_Fisico; set => _NroDoc_Fisico = value; }
        public string IdCom { get => _idCom; set => _idCom = value; }
        public string TipoRegistro { get => _tipoRegistro; set => _tipoRegistro = value; }
        public string LugarSalida { get => _lugarSalida; set => _lugarSalida = value; }
        public string TipoProceso { get => _tipoProceso; set => _tipoProceso = value; }
        public string TrnCodigo { get => _trnCodigo; set => _trnCodigo = value; }
        public decimal Igv { get => _igv; set => _igv = value; }
    }
}
