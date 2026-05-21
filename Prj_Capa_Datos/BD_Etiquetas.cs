using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prj_Capa_Datos
{
    public class BD_Etiquetas : BD_Conexion
    {
        public DataTable BD_Buscar_Presentaciones_ParaEtiquetas(string valor, int idAlmacen)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("Sp_Buscar_Presentaciones_ParaEtiquetas", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Valor", valor);
                        cmd.Parameters.AddWithValue("@IdAlmacen", idAlmacen);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar etiquetas: " + ex.Message,
                        "Capa Datos Etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            return dt;
        }
    }
}
