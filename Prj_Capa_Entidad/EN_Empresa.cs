using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Empresa
    {
        /*
          idempresa int not null,
            nombreEmpresa varchar (250),
            nroRuc char (20),
            DireccionEmpresa varchar(250),
            correo varchar(180),
            clavecorreo varchar (20),
            clavesol varchar(20),
            usuariosol varchar(20),
            clavecertificado varchar(20),
            obs varchar(240),
         */
        private int _idempresa;
        private string _nombrempresa;
        private string _nrouc;
        private string _direccionempresa;
        private string _correo;
        private string clavecorreo;
        private string clavesol;
        private string usuariosol;
        private string clavecertificado;
        private string obs;

        public int Idempresa { get => _idempresa; set => _idempresa = value; }
        public string Nombrempresa { get => _nombrempresa; set => _nombrempresa = value; }
        public string Nrouc { get => _nrouc; set => _nrouc = value; }
        public string Direccionempresa { get => _direccionempresa; set => _direccionempresa = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public string Clavecorreo { get => clavecorreo; set => clavecorreo = value; }
        public string Clavesol { get => clavesol; set => clavesol = value; }
        public string Usuariosol { get => usuariosol; set => usuariosol = value; }
        public string Clavecertificado { get => clavecertificado; set => clavecertificado = value; }
        public string Obs { get => obs; set => obs = value; }
    }
}
