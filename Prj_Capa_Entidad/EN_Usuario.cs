using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Usuario
    {
        //       @Nombres nvarchar(50),
        //@Apellidos nvarchar(50),
        //@Id_Dis int,
        //@Usuario nvarchar(8),
        //@Contraseña nvarchar(10),
        //@Ubicacion_Foto nvarchar(200),
        //@Fecha_Ncmiento datetime,
        //   @Id_Rol int,
        //@Correo varchar(150),
        //@Estado_Usu varchar(12),
        //@idempresa int

        private int _idUser;
        private string _nombres;
        private string _apellidos;
        private int _idDis;
        private string _usuario;
        private string _password;
        private string _foto;
        private DateTime _fechaNac;
        private int _idRol;
        private string _correo;
        private string _estado;
        private int _idEmpresa;

        public string Nombres { get => _nombres; set => _nombres = value; }
        public string Apellidos { get => _apellidos; set => _apellidos = value; }
        public int IdDis { get => _idDis; set => _idDis = value; }
        public string Usuario { get => _usuario; set => _usuario = value; }
        public string Password { get => _password; set => _password = value; }
        public string Foto { get => _foto; set => _foto = value; }
        public DateTime FechaNac { get => _fechaNac; set => _fechaNac = value; }
        public int IdRol { get => _idRol; set => _idRol = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public int IdEmpresa { get => _idEmpresa; set => _idEmpresa = value; }
        public int IdUser { get => _idUser; set => _idUser = value; }
    }
}
