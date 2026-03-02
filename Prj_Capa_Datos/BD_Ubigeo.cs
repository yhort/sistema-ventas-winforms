using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
//using static Prj_Capa_Entidad.EN_Ubigeo;

namespace Prj_Capa_Datos
{
    public class BD_Ubigeo : BD_Conexion
    {

        ////metodo para mostrar los distritos: metodo de tipo consulta
        //public DataTable BD_Listar_Ubigeos()
        //{
        //    SqlConnection cn = new SqlConnection();
        //    try
        //    {
        //        cn.ConnectionString = Conectar();
        //        SqlDataAdapter da = new SqlDataAdapter("Sp_UbigeoList", cn);
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        DataTable data = new DataTable();

        //        da.Fill(data);
        //        da = null;
        //        return data;
        //    }
        //    catch (Exception ex)
        //    {
        //        //para validar si hay algun error en las cadenas de conexion. consulta.
        //        if (cn.State == ConnectionState.Open)
        //        {
        //            cn.Close();
        //        }
        //        MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Ubigeo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //    return null; //en caso no se cumpla la condicion.
        //}

        public DataTable BD_Listar_Ubigeos()
        {
            var dt = new DataTable();
            try
            {
                using (var cn = new SqlConnection(Conectar()))
                using (var da = new SqlDataAdapter("Sp_UbigeoList", cn))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);                      // si no hay filas, dt quedará vacío
                }
            }
            catch (Exception ex)
            {
                // Log si quieres, pero NO MessageBox en capa de datos
                // Logger.LogError(ex); 
                // Dejamos dt vacío.
            }
            return dt; // <- nunca null
        }


    }

}
