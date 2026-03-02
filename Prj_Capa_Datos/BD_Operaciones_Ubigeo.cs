using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Prj_Capa_Entidad;
using System.Data.SqlClient;

namespace Prj_Capa_Datos
{
    public class BD_Operaciones_Ubigeo : BD_Conexion
    {

 
        public DataTable BD_ListarDepartamentos()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("usp_ObtenerDepartamento", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dato = new DataTable();
                da.Fill(dato);
                return dato;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DataTable BD_ListarProvinciaporDepartamentoId( int CodigoDepartamento)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("usp_ObtenerProvincia", cn);
                da.SelectCommand.Parameters.AddWithValue("@CodigoDepartamento", CodigoDepartamento);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dato = new DataTable();
                da.Fill(dato);
                return dato;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DataTable BD_ListarDistrito_ProvinciaId(int CodigoProvincia)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("usp_ObtenerDistrito", cn);
                da.SelectCommand.Parameters.AddWithValue("@CodigoProvincia", CodigoProvincia);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dato = new DataTable();
                da.Fill(dato);
                return dato;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
