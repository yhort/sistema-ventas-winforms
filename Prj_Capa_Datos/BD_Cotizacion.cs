using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prj_Capa_Entidad;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Prj_Capa_Datos
{
    public class BD_Cotizacion  : BD_Conexion
    {
        public static bool seguardo = false;
        public void BD_Registrar_Cotizacion(EN_Cotizacion coti)
        {


            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Cotizacion", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Cotiza", coti.Id_Cotiza);
                cmd.Parameters.AddWithValue("@Id_Ped ", coti.Id_Ped);
                cmd.Parameters.AddWithValue("@Vigencia", coti.Vigencia);
                cmd.Parameters.AddWithValue("@TotalCotiza ", coti.TotalCotiza);
                cmd.Parameters.AddWithValue("@Condiciones", coti.Condiciones);
                cmd.Parameters.AddWithValue("@PrecioconIgv", coti.Preciocon_Igv);




                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                seguardo = true;



            }
            catch (Exception ex)
            {
                seguardo = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Cotizacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }



        //editar cotizaxion
        public void BD_Editar_Cotizacion(EN_Cotizacion coti)
        {


            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Editar_Cotizacion", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Cotiza", coti.Id_Cotiza);
                cmd.Parameters.AddWithValue("@Id_Ped ", coti.Id_Ped);
                cmd.Parameters.AddWithValue("@FechaCoti ", coti.FechaCoti);
                cmd.Parameters.AddWithValue("@Vigencia", coti.Vigencia);
                cmd.Parameters.AddWithValue("@TotalCotiza ", coti.TotalCotiza);
                cmd.Parameters.AddWithValue("@Condiciones", coti.Condiciones);
                cmd.Parameters.AddWithValue("@PrecioconIgv", coti.Preciocon_Igv);




                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                seguardo = true;



            }
            catch (Exception ex)
            {
                seguardo = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Cotizacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }


        //cambiar estado cotizacion.
        public void BD_Cambiar_Estado_Cotizacion(string idCoti, string estadoCoti)
        {


            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Cambiar_Estado_Cotizacion", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_coti", idCoti);
                cmd.Parameters.AddWithValue("@Estadocoti", estadoCoti);


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                seguardo = true;



            }
            catch (Exception ex)
            {
                seguardo = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Cotizacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }

        //consultas:
        public DataTable BD_Buscar_Cotizacion_paraEditar(string idCoti)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Cotizaciones_yDetalle", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Nro_coti", idCoti);


                DataTable dato = new DataTable();

                da.Fill(dato);
                return dato;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Cotizacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }
    }
}

