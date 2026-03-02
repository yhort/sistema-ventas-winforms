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
    public class BD_Serie : BD_Conexion
    {

        public static bool seguardo = false;
        public static bool detsaved = false;

        //Detalles del kardex:
        public void BD_Registrar_Serie(EN_Serie Ser)

        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_registrar_Serie", cn);
                cmd.CommandTimeout = 20;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Pro", Ser.IdPro);
                cmd.Parameters.AddWithValue("@Serie", Ser.Serie);
                cmd.Parameters.AddWithValue("@item", Ser.Item);
               



                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                detsaved = true;



            }
            catch (Exception ex)
            {
                detsaved = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Serie", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }
    }
}
