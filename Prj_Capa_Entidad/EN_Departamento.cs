using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Departamento
    {

        private int _codigoDepartamento;
        private string _nombre;
        private bool _activo;

        public int CodigoDepartamento { get => _codigoDepartamento; set => _codigoDepartamento = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public bool Activo { get => _activo; set => _activo = value; }



    }
}
