using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Distrito
    {

        private int _CodigoDistrito;
        private string _nombre;
        private int _CodigoProvincia;
        private bool _activo;

        public int CodigoDistrito { get => _CodigoDistrito; set => _CodigoDistrito = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public int CodigoProvincia { get => _CodigoProvincia; set => _CodigoProvincia = value; }
        public bool Activo { get => _activo; set => _activo = value; }
    }
}
