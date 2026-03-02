using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Microsell_Lite.Reportes_Consolidado
{
    public partial class Frm_Rpt_Ventas : Form
    {
        public Frm_Rpt_Ventas()
        {
            InitializeComponent();
        }

        #region

            

            

        #endregion

        private void Frm_Rpt_Ventas_Load(object sender, EventArgs e)
        {
            
            // TODO: esta línea de código carga datos en la tabla 'DataSet_Reportes_Consolidado.Sp_Listar_Doc_emitoshoy' Puede moverla o quitarla según sea necesario.
            this.Sp_Listar_Doc_emitoshoyTableAdapter.Fill(this.DataSet_Reportes_Consolidado.Sp_Listar_Doc_emitoshoy, FechaActual:Convert.ToDateTime( txt_p1.Text));

            this.reportViewer1.RefreshReport();
        

        }



    }
}
