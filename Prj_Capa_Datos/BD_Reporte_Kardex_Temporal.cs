using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Prj_Capa_Entidad;
using System.Data.SqlClient;
using System.Collections;

namespace Prj_Capa_Datos
{
    public class BD_Reporte_Kardex_Temporal : BD_Conexion
    {
        public static bool seguardo = false;
        public static bool seedito = false;
        public void BD_Registrar_Reporte_Kardex_Temporal(string idprod, string nombreprod, double stock, double precompra,double compra_xstock,
            double preventa,double venta_xstock, double utilidad, double utilidad_xstock, string obs)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                //                @idprod,
                //@NombreProducto,
                //@stock,
                //@preCompra,
                //@Comp_x_Stock,
                //@PreVenta,
                //@Venta_x_Stock,
                //@Utilidad ,
                //@Utili_x_Stock ,
                //@obs

                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Temporal_Reportkardex", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idprod", idprod);
                cmd.Parameters.AddWithValue("@NombreProducto", nombreprod);
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@preCompra", precompra);
                cmd.Parameters.AddWithValue("@Comp_x_Stock", compra_xstock);
                cmd.Parameters.AddWithValue("@PreVenta", preventa);
                cmd.Parameters.AddWithValue("@Venta_x_Stock ", venta_xstock);
                cmd.Parameters.AddWithValue("@Utilidad", utilidad);
                cmd.Parameters.AddWithValue("@Utili_x_Stock", utilidad_xstock);
                cmd.Parameters.AddWithValue("@obs", obs);
              

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seguardo = true;  //se coloca esta variable tipo bool, para verificar que se haya guardado todos los campos.
            }
            catch (Exception ex)
            {
                seguardo = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Reporte_Kardex_Temporal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void BD_Eliminar_Temporal_Kardex()
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Eliminar_Temporal_Kardex", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
              

            }
            catch (Exception ex)
            {
                
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Reporte_Kardex_Temporal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public DataTable BD_Listar_Temporal_Kardex()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Temporal_Kardex", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data = new DataTable();

                da.Fill(data);
                da = null;
                return data;
            }
            catch (Exception ex)
            {

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }


        }

    }
}
