using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Provincia
    {
        private int _codigoProvincia;
        private string _nombre;
        private int _CodigoDepartamento;
        private bool _activo;

        public int CodigoProvincia { get => _codigoProvincia; set => _codigoProvincia = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public int CodigoDepartamento { get => _CodigoDepartamento; set => _CodigoDepartamento = value; }
        public bool Activo { get => _activo; set => _activo = value; }
    }
}
