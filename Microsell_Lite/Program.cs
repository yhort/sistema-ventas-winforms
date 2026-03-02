using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsell_Lite.Productos;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Proveedor;
using Microsell_Lite.Ventas;
using Microsell_Lite.Informe;
using Microsell_Lite.GUIAREMISION;

namespace Microsell_Lite
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_Login());
        }
    }
}
