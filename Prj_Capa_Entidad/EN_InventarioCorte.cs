using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_InventarioCorte
    {
        private int _idCorte;
        private DateTime _fechaCorte;
        private int _idAlmacen;
        private string _descripcion;
        private string _observacion;
        private int _idUsuario;
        private string _estado;

        public int IdCorte { get => _idCorte; set => _idCorte = value; }
        public DateTime FechaCorte { get => _fechaCorte; set => _fechaCorte = value; }
        public int IdAlmacen { get => _idAlmacen; set => _idAlmacen = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Observacion { get => _observacion; set => _observacion = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string Estado { get => _estado; set => _estado = value; }
    }
}
