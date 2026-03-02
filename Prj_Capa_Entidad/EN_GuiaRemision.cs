using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_GuiaRemision
    {
            //        @id_gr char (13),
            //@nro_fac_ref char (11),
            //@id_cliente char (10),
            //@Id_Transportista char (10),
            //@Subtotal real,
            //@Fecha_sys datetime,
            //@Fecha_emision datetime,
            //@Fecha_traslado datetime,
            //@UnidadMediad char (3),
            //@PesoTotal real,
            //@NumPaquete int,
            //@Obs varchar(50),
            //@ubigeo_partida nvarchar(6),
            //@punto_partida nvarchar(6),
            //@ubigeo_llegada nvarchar(6),
            //@punto_llegada nvarchar(6),
            //@cdr_sunat varchar(15),
            //@nro_ticket varchar(50),
            //@hash_cpe varchar(15),
            //@motivo_traslado varchar(100),
            //@motivo_codigo char (2),
            //@motivo_desc nvarchar(80)

        private string _idGr;
        private string _nroRefFac;
        private string _idCliente;
        private int ?idvehiculo; //se pone ? para que acepte null
        private string idTransportista;
        private int idUsu;
        private double _subtotal;
        private DateTime _fechSyst;
        private DateTime _fechaEmision;
        private DateTime _fechaTraslado;
        private string _und;
        private double _pesoTotal;
        private double _numPaquete;
        private string _obs;
        private string _ubigeoPartida;
        private string _puntoPartida;
        private string _ubigeoLlegada;
        private string _puntoLlegada;
        private string _cdrSunat;
        private string _nroTicket;
        private string _hashCpe;
        private string _motivoTraslado;
        private string _motivoCodigo;
        private string _motivoDesc;
        private string _estadoDoc;

        //relacionando con campos de tablas intermedias.
        private List<string>_idsConductores;
        //private List<string> _idsVehiculos; en caso se requiera vehiculos independientes , empr.transp
       

        public List<string> IdsConductores { get => _idsConductores; set => _idsConductores = value; }
        //public List<string> IdsVehiculos { get => _idsVehiculos; set => _idsVehiculos = value; }
        public string IdGr { get => _idGr; set => _idGr = value; }
        public string NroRefFac { get => _nroRefFac; set => _nroRefFac = value; }
        public string IdCliente { get => _idCliente; set => _idCliente = value; }
        //public int? Idvehiculo { get => idvehiculo; set => idvehiculo = value; }
        public string IdTransportista { get => idTransportista; set => idTransportista = value; }
        public int IdUsu { get => idUsu; set => idUsu = value; }
        public double Subtotal { get => _subtotal; set => _subtotal = value; }
        public DateTime FechSyst { get => _fechSyst; set => _fechSyst = value; }
        public DateTime FechaEmision { get => _fechaEmision; set => _fechaEmision = value; }
        public DateTime FechaTraslado { get => _fechaTraslado; set => _fechaTraslado = value; }
        public string Und { get => _und; set => _und = value; }
        public double PesoTotal { get => _pesoTotal; set => _pesoTotal = value; }
        public double NumPaquete { get => _numPaquete; set => _numPaquete = value; }
        public string Obs { get => _obs; set => _obs = value; }
        public string UbigeoPartida { get => _ubigeoPartida; set => _ubigeoPartida = value; }
        public string PuntoPartida { get => _puntoPartida; set => _puntoPartida = value; }
        public string UbigeoLlegada { get => _ubigeoLlegada; set => _ubigeoLlegada = value; }
        public string PuntoLlegada { get => _puntoLlegada; set => _puntoLlegada = value; }
        public string CdrSunat { get => _cdrSunat; set => _cdrSunat = value; }
        public string NroTicket { get => _nroTicket; set => _nroTicket = value; }
        public string HashCpe { get => _hashCpe; set => _hashCpe = value; }
        public string MotivoTraslado { get => _motivoTraslado; set => _motivoTraslado = value; }
        public string MotivoCodigo { get => _motivoCodigo; set => _motivoCodigo = value; }
        public string MotivoDesc { get => _motivoDesc; set => _motivoDesc = value; }
        public string EstadoDoc { get => _estadoDoc; set => _estadoDoc = value; }
        public int? Idvehiculo { get => idvehiculo; set => idvehiculo = value; }
    }
}
