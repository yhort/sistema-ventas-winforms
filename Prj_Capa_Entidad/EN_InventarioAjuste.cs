using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_InventarioAjuste
    {
        /*
         
        public int IdAjuste { get; set; }
        public DateTime Fecha { get; set; }
        public int IdAlmacen { get; set; }
        public string Motivo { get; set; }
        public string Observacion { get; set; }
        public int IdUsuario { get; set; }
        public string Estado { get; set; }
         */

        private int _idAjuste;
        private DateTime _fecha;
        private int _idAlmacen;
        private string _motivo;
        private string _observacion;
        private int _idUsuario;
        private string _estado;

        public int IdAjuste { get => _idAjuste; set => _idAjuste = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public int IdAlmacen { get => _idAlmacen; set => _idAlmacen = value; }
        public string Motivo { get => _motivo; set => _motivo = value; }
        public string Observacion { get => _observacion; set => _observacion = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string Estado { get => _estado; set => _estado = value; }
    }
}
