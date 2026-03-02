using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Vehiculo
    {
        //       @veh_codigo int,	
        //@veh_modelo varchar(10),
        //@veh_placa varchar(10),
        //@veh_fechacreac datetime,
        //   @veh_estado varchar(12)
        //       @veh_TUC char (20),
        //@veh_MtcPrincipal char (20),
        //@veh_placaSec char (10),
        //@veh_TUC_Secun char (20),
        //@veh_MtcSecund char (20)

        private int _idveh;
        private string _vehmodelo;
        private string _vehplaca;
        private DateTime _vehfechacre;
        private string _vehmarca;
        private string _vehTuc;
        private string _veh_mtc_principal;
        private string _veh_placa_secund;
        private string _veh_tuc_secund;
        private string _veh_mtc_secund;
        
       // public int Vehcodigo { get => _vehcodigo; set => _vehcodigo = value; }
        public string Vehmodelo { get => _vehmodelo; set => _vehmodelo = value; }
        public string Vehplaca { get => _vehplaca; set => _vehplaca = value; }
        public DateTime Vehfechacre { get => _vehfechacre; set => _vehfechacre = value; }
        public string Vehmarca { get => _vehmarca; set => _vehmarca = value; }
        public string VehTuc { get => _vehTuc; set => _vehTuc = value; }
        public string Veh_mtc_principal { get => _veh_mtc_principal; set => _veh_mtc_principal = value; }
        public string Veh_placa_secund { get => _veh_placa_secund; set => _veh_placa_secund = value; }
        public string Veh_tuc_secund { get => _veh_tuc_secund; set => _veh_tuc_secund = value; }
        public string Veh_mtc_secund { get => _veh_mtc_secund; set => _veh_mtc_secund = value; }
        public int Idveh { get => _idveh; set => _idveh = value; }
    }
}
