using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Serie
    {

        private string _idPro;
        private string _serie;
        private int _item;

        public string IdPro { get => _idPro; set => _idPro = value; }
        public string Serie { get => _serie; set => _serie = value; }
        public int Item { get => _item; set => _item = value; }
    }
}
