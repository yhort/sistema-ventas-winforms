using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Transportista
    {
		/*
         @Id_Transportista char(10),	
		@Razon_Social nvarchar(250),
		@RUC int,
		@Direccion nvarchar(150),	
		@Telefono char(10),
		@E_Mail varchar(15),
		@Nro_Licencia_Transporte varchar(20)
		*/

		private string _idTransportista;
		private string _razonSocialNombres;
		private string _ruc;
		private string _direccion;
		private string _telefono;
		private string _email;
		private string _nroLicTransporte;

        public string IdTransportista { get => _idTransportista; set => _idTransportista = value; }
        public string RazonSocialNombres { get => _razonSocialNombres; set => _razonSocialNombres = value; }
        public string Ruc { get => _ruc; set => _ruc = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Email { get => _email; set => _email = value; }
        public string NroLicTransporte { get => _nroLicTransporte; set => _nroLicTransporte = value; }
       
    }
}
