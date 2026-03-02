using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Cliente
    {
        private string _idcliente;
        private string _razonsocial;
        private string _dni;
        private string _direccion;
        private string _telefono;
        private string _email;
        private int _idDis;
        private DateTime _fechaAniver;
        private string _contacto;
        private double _limiteCred;
        private string _idTipoDoc; //cod tipo doc Identidad

        public double LimiteCred { get => _limiteCred; set => _limiteCred = value; }
        public string Contacto { get => _contacto; set => _contacto = value; }
        public DateTime FechaAniver { get => _fechaAniver; set => _fechaAniver = value; }
        public int IdDis { get => _idDis; set => _idDis = value; }
        public string Email { get => _email; set => _email = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Dni { get => _dni; set => _dni = value; }
        public string Razonsocial { get => _razonsocial; set => _razonsocial = value; }
        public string Idcliente { get => _idcliente; set => _idcliente = value; }
        public string IdTipoDoc { get => _idTipoDoc; set => _idTipoDoc = value; }
    }
}
