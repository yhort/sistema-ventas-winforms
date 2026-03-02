using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_TokenInfo
    {
        private string _token;
        private DateTime _fechaObtencion;

        public string Token { get => _token; set => _token = value; }
        public DateTime FechaObtencion { get => _fechaObtencion; set => _fechaObtencion = value; }
    }
}
