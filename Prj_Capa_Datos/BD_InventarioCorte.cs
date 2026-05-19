using Prj_Capa_Entidad;
using Prj_Capa_Datos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaDatos
{
    public class BD_InventarioCorte : BD_Conexion
    {
        public int BD_Registrar_InventarioCorte(EN_InventarioCorte corte)
        {
            int idCorte = 0;

            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("Sp_Registrar_InventarioCorte", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdAlmacen", corte.IdAlmacen);
                        cmd.Parameters.AddWithValue("@Descripcion", corte.Descripcion);
                        cmd.Parameters.AddWithValue("@Observacion", corte.Observacion);
                        cmd.Parameters.AddWithValue("@IdUsuario", corte.IdUsuario);

                        SqlParameter pId = new SqlParameter("@IdCorte", SqlDbType.Int);
                        pId.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(pId);

                        cmd.ExecuteNonQuery();

                        idCorte = Convert.ToInt32(pId.Value);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar corte: " + ex.Message,
                        "Capa Datos Corte", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            return idCorte;
        }

        public void BD_Generar_Detalle_InventarioCorte(int idCorte, int idAlmacen)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("Sp_Generar_Detalle_InventarioCorte", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdCorte", idCorte);
                        cmd.Parameters.AddWithValue("@IdAlmacen", idAlmacen);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar detalle del corte: " + ex.Message,
                        "Capa Datos Corte", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public DataTable BD_Listar_InventarioCortes()
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("Sp_Listar_InventarioCortes", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al listar cortes: " + ex.Message,
                        "Capa Datos Corte", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            return dt;
        }

        public DataTable BD_Listar_InventarioCorteDetalle(int idCorte)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("Sp_Listar_InventarioCorteDetalle", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdCorte", idCorte);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al listar detalle del corte: " + ex.Message,
                        "Capa Datos Corte", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            return dt;
        }
    }
}