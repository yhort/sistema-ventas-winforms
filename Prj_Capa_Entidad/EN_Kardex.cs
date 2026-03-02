using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Kardex
    {
        //@Id_Krdx char (11),
        //@Item int,
        //@Fecha_Krdx Date,
        //@Doc_Soport nchar(29),
        //@Det_Operacion varchar(50),
        //--entrada
        //@Cantidad_In Real,
        //@Precio_Unt_In Real,
        //@Costo_Total_In Real,
        //--salida
        //@Cantidad_Out Real,
        //@Precio_Unt_Out Real,
        //@Importe_Total_Out Real,
        //--saldo
        //@Cantidad_Saldo Real,
        //@Promedio Real,
        //@Costo_Total_Saldo Real

        private string _idkardex;
        private int _item;
        private string _doc_soporte;
        private string _Det_Operacion;
        private double _cantidad_in;
        private double _precio_In;
        private double _total_In;

        private double _cantidad_Out;
        private double _Precio_out;
        private double _Total_out;

        private double _cantidad_saldo;
        private double _Promedio;
        private double _Total_saldo;

        private string _tipoOperacion;
        private string _cantiDiferencial;
        private double _importeDiferencial;

        private string _observacion;

        public double Total_saldo { get => _Total_saldo; set => _Total_saldo = value; }
        public double Promedio { get => _Promedio; set => _Promedio = value; }
        public double Cantidad_saldo { get => _cantidad_saldo; set => _cantidad_saldo = value; }
        public double Total_out { get => _Total_out; set => _Total_out = value; }
        public double Precio_out { get => _Precio_out; set => _Precio_out = value; }
        public double Cantidad_Out { get => _cantidad_Out; set => _cantidad_Out = value; }
        public double Total_In { get => _total_In; set => _total_In = value; }
        public double Precio_In { get => _precio_In; set => _precio_In = value; }
        public double Cantidad_in { get => _cantidad_in; set => _cantidad_in = value; }
        public string Det_Operacion { get => _Det_Operacion; set => _Det_Operacion = value; }
        public string Doc_soporte { get => _doc_soporte; set => _doc_soporte = value; }
        public int Item { get => _item; set => _item = value; }
        public string Idkardex { get => _idkardex; set => _idkardex = value; }
        public string CantiDiferencial { get => _cantiDiferencial; set => _cantiDiferencial = value; }
        public double ImporteDiferencial { get => _importeDiferencial; set => _importeDiferencial = value; }
        public string TipoOperacion { get => _tipoOperacion; set => _tipoOperacion = value; }
        public string Observacion { get => _observacion; set => _observacion = value; }
    }
}
