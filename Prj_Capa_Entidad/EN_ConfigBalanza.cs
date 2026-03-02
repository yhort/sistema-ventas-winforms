using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_ConfigBalanza
    {


        private string _nombreEquipo;
        private string _puertoCOM;
        private int _baudRate;
        private int _dataBits;
        private string _paridad;
        private string _stopBits;

        public string NombreEquipo { get => _nombreEquipo; set => _nombreEquipo = value; }
        public string PuertoCOM { get => _puertoCOM; set => _puertoCOM = value; }
        public int BaudRate { get => _baudRate; set => _baudRate = value; }
        public int DataBits { get => _dataBits; set => _dataBits = value; }
        public string Paridad { get => _paridad; set => _paridad = value; }
        public string StopBits { get => _stopBits; set => _stopBits = value; }
    }
}
