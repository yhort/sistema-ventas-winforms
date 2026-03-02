using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Gr_Transportista
    {

        /*
         
                     @Id_GrTransp char(13),
            @Id_GrRemitente char(13),
            @Id_Cliente char(10),
            @direccion_Id int,
            @Subtotal real,
            @Fecha datetime,
            @Fecha_traslado datetime,
            @UnidadMediad char(3),
            @PesoTotal real,
            @NumPaquete real,
            @Orden_Compra char(13),
            @Obs varchar(50),
            @PagadorFlete varchar(50),
            @Id_Cliente_2 char(10),
            @direccion_Id_2 int,
            @Id_Cond int,
            @Id_Cond_2 int,
            @Id_Vehiculo int,
            @Id_Veh_2 int,
            @Cdr_Sunat varchar(50),
            @NroTicket varchar(50),
            @HashCPE varchar(50),
            @Estado varchar(50)
         
         
         */

        private string _idgr_Transp;
        private string _id_grRem;
        private string _idCliente;
        private int _idDireccion;
        private double _subtotal;
        private DateTime _fecha;
        private DateTime _fechaTraslado;
        private string _unidadMedida;
        private double _pesoTotal;
        private int _numPaquete;
        private string _ordenCompra;
        private string _obs;
        private string _pagadorFlete;
        private string _idCliente_sec;
        private int _idDirecsec;
        private int _idCond;
        private int? _idCondsec;
        private int _idvehic;
        private int? _idVehicSec;
        private string _cdrSunat;
        private string _nroTicket;
        private string _hashCpe;
        private string _estado;
        private int _idUsu;
        private double _total;

        public string Idgr_Transp { get => _idgr_Transp; set => _idgr_Transp = value; }
        public string Id_grRem { get => _id_grRem; set => _id_grRem = value; }
        public string IdCliente { get => _idCliente; set => _idCliente = value; }
        public int IdDireccion { get => _idDireccion; set => _idDireccion = value; }
        public double Subtotal { get => _subtotal; set => _subtotal = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public DateTime FechaTraslado { get => _fechaTraslado; set => _fechaTraslado = value; }
        public string UnidadMedida { get => _unidadMedida; set => _unidadMedida = value; }
        public double PesoTotal { get => _pesoTotal; set => _pesoTotal = value; }
        public int NumPaquete { get => _numPaquete; set => _numPaquete = value; }
        public string OrdenCompra { get => _ordenCompra; set => _ordenCompra = value; }
        public string Obs { get => _obs; set => _obs = value; }
        public string PagadorFlete { get => _pagadorFlete; set => _pagadorFlete = value; }
        public string IdCliente_sec { get => _idCliente_sec; set => _idCliente_sec = value; }
        public int IdDirecsec { get => _idDirecsec; set => _idDirecsec = value; }
        public int IdCond { get => _idCond; set => _idCond = value; }
        //public int? IdCondsec { get => _idCondsec; set => _idCondsec = value; }
        
        //public int? IdVehicSec { get => _idVehicSec; set => _idVehicSec = value; }
        public string CdrSunat { get => _cdrSunat; set => _cdrSunat = value; }
        public string NroTicket { get => _nroTicket; set => _nroTicket = value; }
        public string HashCpe { get => _hashCpe; set => _hashCpe = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public int IdUsu { get => _idUsu; set => _idUsu = value; }
        public double Total { get => _total; set => _total = value; }
        public int Idvehic { get => _idvehic; set => _idvehic = value; }
        public int? IdCondsec { get => _idCondsec; set => _idCondsec = value; }
        public int? IdVehicSec { get => _idVehicSec; set => _idVehicSec = value; }
    }
}
