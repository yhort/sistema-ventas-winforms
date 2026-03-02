using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_DireccionesCl
    {
        //        @ClienteId INT,
        //@Direccion NVARCHAR(255),
        //    @Distrito NVARCHAR(100),
        //	@Cod_ubigeo NVARCHAR(6),
        //	@Departamento NVARCHAR(100),
        //    @Provincia NVARCHAR(100),
        //    @Pais NVARCHAR(100)
        private string _clienteId;
        private string _direccion;
        private string _distrito;
        private string _codUbigeo;
        private string _departamento;
        private string _provincia;
        private string _pais;

        public string ClienteId { get => _clienteId; set => _clienteId = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Distrito { get => _distrito; set => _distrito = value; }
        public string CodUbigeo { get => _codUbigeo; set => _codUbigeo = value; }
        public string Departamento { get => _departamento; set => _departamento = value; }
        public string Provincia { get => _provincia; set => _provincia = value; }
        public string Pais { get => _pais; set => _pais = value; }
    }
}
