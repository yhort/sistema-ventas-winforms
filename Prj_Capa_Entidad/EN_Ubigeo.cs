using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Ubigeo
    {
        public class UbigeoInfo
        {
            public string Ubigeo { get; set; } //"150115"

            public string Distrito { get; set; } //"LA VICTORIA"

            public string Provincia { get; set; } //Provincia

            public string Departamento { get; set; } //Departamento

            public string Etiqueta { get; set; } //"150115 LA VICTORIA - LIMA- LIMA"

            public override string ToString() => Etiqueta;
            //public string Ciudad { get; set; }  // 


        }
    }
}
