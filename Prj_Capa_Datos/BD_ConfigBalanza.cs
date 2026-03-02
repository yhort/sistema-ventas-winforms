using Prj_Capa_Entidad;
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
    public class BD_ConfigBalanza : BD_Conexion
    {
        public static bool ConfigSaved = false;
        public void BD_GuardarConfiguracion(EN_ConfigBalanza config)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Guardar_ConfigBalanza", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 20;

                // Parámetros del Stored Procedure
                cmd.Parameters.AddWithValue("@NombreEquipo", config.NombreEquipo);
                cmd.Parameters.AddWithValue("@PuertoCOM", config.PuertoCOM);
                cmd.Parameters.AddWithValue("@BaudRate", config.BaudRate);
                cmd.Parameters.AddWithValue("@DataBits", config.DataBits);
                cmd.Parameters.AddWithValue("@Paridad", config.Paridad);
                cmd.Parameters.AddWithValue("@StopBits", config.StopBits);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                ConfigSaved = true;
            }
            catch (Exception ex)
            {
                ConfigSaved = false;

                if (cn.State == ConnectionState.Open)
                    cn.Close();

                MessageBox.Show("Error al guardar configuración: " + ex.Message, "Capa Datos Balanza", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public EN_ConfigBalanza BD_ObtenerConfiguracion(string nombreEquipo)
        {
            SqlConnection cn = new SqlConnection();
            EN_ConfigBalanza config = null;

            try
            {
                cn.ConnectionString = Conectar();
                cn.Open();

                SqlCommand cmd = new SqlCommand("Sp_Obtener_ConfigBalanza", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 20;
                cmd.Parameters.AddWithValue("@NombreEquipo", nombreEquipo);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read()) // Usamos Read directamente para simplificar
                {
                    config = new EN_ConfigBalanza
                    {
                        NombreEquipo = dr["NombreEquipo"].ToString(),
                        PuertoCOM = dr["PuertoCOM"].ToString(),
                        BaudRate = Convert.ToInt32(dr["BaudRate"]),
                        DataBits = Convert.ToInt32(dr["DataBits"]),
                        Paridad = dr["Paridad"].ToString(),
                        StopBits = dr["StopBits"].ToString()
                    };
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener configuración: " + ex.Message, "Capa Datos Balanza", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }

            return config;
        }


    }
}
