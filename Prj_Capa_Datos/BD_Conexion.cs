using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Prj_Capa_Datos
{
    public class BD_Conexion
    {
        //CADENA DE CONEXION EN DESARROLLO:

        //public string Conectar()
        //{
        //    return "data source = ING-HPX360\\SQLDEV;Initial Catalog=SISTEMA_VENTASFACT; uid=sa;pwd=sa123";
        //}

        //public static string Conectar2()
        //{
        //    return "data source = ING-HPX360\\SQLDEV;Initial Catalog=SISTEMA_VENTASFACT; uid=sa;pwd=sa123";
        //}


        //CADENA DE CONEXION PARA INSTALAR AL CLIENTE.
        public string Conectar()
        {

            StreamReader leer;
            string ruta = Application.StartupPath;
            leer = new StreamReader(ruta + @"\DllConectar.txt");
            string linea;
            linea = leer.ReadLine();
            return linea;
        }



        public static string Conectar2()
        {
            //return "data source = ING-HPX360\\SQLDEV; Initial Catalog=POS_Microsell_Lite;uid=sa;pwd=sa123";


            StreamReader leer;
            string ruta = Application.StartupPath;
            leer = new StreamReader(ruta + @"\DllConectar.txt");
            string linea;
            linea = leer.ReadLine();
            return linea;

        }


    }
}
