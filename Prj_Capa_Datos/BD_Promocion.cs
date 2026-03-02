using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prj_Capa_Entidad;
using System.Windows.Forms;

namespace Prj_Capa_Datos
{
    public class BD_Promocion : BD_Conexion
    {
        public static bool promoSaved = false;
        public int BD_RegistrarPromocion(string nombre, string tipo, DateTime inicio, DateTime fin)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                SqlCommand cmd = new SqlCommand("sp_Registrar_Promocion", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@FechaInicio", inicio);
                cmd.Parameters.AddWithValue("@FechaFin", fin);
                cmd.Parameters.Add("@IdPromocion", SqlDbType.Int).Direction = ParameterDirection.Output;

                cn.Open();
                cmd.ExecuteNonQuery();
                int idPromo = Convert.ToInt32(cmd.Parameters["@IdPromocion"].Value);
                cn.Close();

                return idPromo;
            }
        }

        public void BD_Actualizar_Promocion(int idPromo,string nombre, string tipo, DateTime inicio, DateTime fin)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Actualizar_Promocion", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPromocion", idPromo);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@FechaInicio", inicio);
                cmd.Parameters.AddWithValue("@FechaFin", fin);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("La Promoción se ha Actualizado Exitosamente");

            }
            catch (Exception ex)
            {

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Promoción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        public void BD_RegistrarDetallePromocion(int idPromo, string idProducto, int cantidad, decimal precio)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                SqlCommand cmd = new SqlCommand("sp_Registrar_DetallePromocion", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdPromocion", idPromo);
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                cmd.Parameters.AddWithValue("@PrecioUnitario", precio);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public DataTable BD_BuscarDetallePromocion(int idPromocion)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                SqlCommand cmd = new SqlCommand("sp_Buscar_DetallePromocion", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdPromocion", idPromocion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public DataTable BD_Buscar_Promociones_Activas(string idProducto)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                SqlCommand cmd = new SqlCommand("sp_Buscar_Promociones_Activas", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@IdProducto", string.IsNullOrEmpty(idProducto) ? DBNull.Value : (object)idProducto);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al consultar promociones activas: " + ex.Message);
                }
            }
        }

        public DataTable BD_Buscar_PromocionesVentas_Resumen(DateTime desde, DateTime hasta)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                SqlCommand cmd = new SqlCommand("sp_Reporte_Promociones_Venta", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@desde", desde); 
                cmd.Parameters.AddWithValue("@hasta", hasta);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable BD_Buscar_PromocionesVentas_Detalle(DateTime desde, DateTime hasta)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                SqlCommand cmd = new SqlCommand("sp_Reporte_Promociones_Detallado", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@desde", desde);
                cmd.Parameters.AddWithValue("@hasta", hasta);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public DataTable BD_Listar_Promociones()
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                SqlCommand cmd = new SqlCommand("sp_Listar_Promociones", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable BD_ObtenerCabeceraPromo(int idPromo)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerCabecera_Promo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idPromo", idPromo);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);
                    return tabla;
                }
            }
        }

        public bool BD_PromocionYaUsada(int idPromocion)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                SqlCommand cmd = new SqlCommand("sp_verificar_promocionYaUsada", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPromocion", idPromocion);

                cn.Open();
                int cantidad = (int)cmd.ExecuteScalar();
                cn.Close();

                return cantidad > 0;
            }
        }

        public DataTable BD_BuscarDetallePromocion_paraActualizar(int idPromocion)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                SqlCommand cmd = new SqlCommand("sp_Buscar_DetallePromocion_paraActualizar", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdPromocion", idPromocion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void BD_EliminarDetallePromocion(int idPromo)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                SqlCommand cmd = new SqlCommand("sp_Eliminar_DetallePromocion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPromocion", idPromo);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }


    }
}
