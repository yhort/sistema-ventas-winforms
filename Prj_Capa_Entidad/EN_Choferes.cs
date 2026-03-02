using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{ 
   
    public class EN_Choferes
    {

        //       @co_nombres varchar(50),
        //@co_dni varchar(10),
        //@co_licencia varchar(15),
        //@Id_Dis int,
        //@co_direccion varchar(60),
        //@cho_telf varchar(15),
        //@cho_fechacreac datetime,
        //   @cho_fechamodif datetime,
        //@cho_estado varchar(12)

        private int idCond;
        private string _co_nombres;
        private string _dni;
        private string _licencia;
        private int _idDis;
        private string _direccion;
        private string _telef;
        private DateTime _fechacrea;
        private DateTime _fechamod;
        private string _estado;
        private string _apellido;


        public string Co_nombres { get => _co_nombres; set => _co_nombres = value; }
        public string Dni { get => _dni; set => _dni = value; }
        public string Licencia { get => _licencia; set => _licencia = value; }
        public int IdDis { get => _idDis; set => _idDis = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Telef { get => _telef; set => _telef = value; }
        public DateTime Fechacrea { get => _fechacrea; set => _fechacrea = value; }
        public DateTime Fechamod { get => _fechamod; set => _fechamod = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public int IdCond { get => idCond; set => idCond = value; }
    }


}
