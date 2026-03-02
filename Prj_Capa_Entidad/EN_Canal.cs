using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public  class EN_Canal
    {
        //@ClienteId char (10),
        // @Nombre_Canal NVARCHAR(150),
        // @Estado_Canal VARCHAR(12)

        private int _idCanal;
        private string _clienteId;
        private string _nombreCanal;
        private string _estado;

        public int IdCanal { get => _idCanal; set => _idCanal = value; }
        public string ClienteId { get => _clienteId; set => _clienteId = value; }
        public string NombreCanal { get => _nombreCanal; set => _nombreCanal = value; }
        public string Estado { get => _estado; set => _estado = value; }
    }
}
