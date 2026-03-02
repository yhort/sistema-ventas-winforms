using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Submenu
    {
        private string _nombre;
        private string _nomnbreFormulario;

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string NomnbreFormulario { get => _nomnbreFormulario; set => _nomnbreFormulario = value; }
    }
}
