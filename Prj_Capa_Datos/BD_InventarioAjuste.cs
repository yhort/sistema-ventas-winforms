using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Prj_Capa_Entidad;

namespace Prj_Capa_Datos
{
    public class BD_InventarioAjuste : BD_Conexion
    {
        public static bool seGuardo = false;

        public int BD_Registrar_InventarioAjuste(EN_InventarioAjuste aj)
        {
            int idAjuste = 0;

            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("Sp_Registrar_InventarioAjuste", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdAlmacen", aj.IdAlmacen);
                        cmd.Parameters.AddWithValue("@Motivo", aj.Motivo);
                        cmd.Parameters.AddWithValue("@Observacion", aj.Observacion);
                        cmd.Parameters.AddWithValue("@IdUsuario", aj.IdUsuario);

                        SqlParameter pId = new SqlParameter("@IdAjuste", SqlDbType.Int);
                        pId.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(pId);

                        cmd.ExecuteNonQuery();

                        idAjuste = Convert.ToInt32(pId.Value);
                        seGuardo = true;
                    }
                }
                catch (Exception ex)
                {
                    seGuardo = false;
                    MessageBox.Show("Error al registrar ajuste: " + ex.Message,
                        "Capa Datos Inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            return idAjuste;
        }

        public void BD_Registrar_InventarioAjusteDetalle(EN_InventarioAjusteDetalle det)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("Sp_Registrar_InventarioAjusteDetalle", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdAjuste", det.IdAjuste);
                        cmd.Parameters.AddWithValue("@IdProducto", det.IdProducto);
                        cmd.Parameters.AddWithValue("@IdPresentacion", det.IdPresentacion);
                        cmd.Parameters.AddWithValue("@StockSistema", det.StockSistema);
                        cmd.Parameters.AddWithValue("@StockContado", det.StockContado);
                        cmd.Parameters.AddWithValue("@Diferencia", det.Diferencia);
                        cmd.Parameters.AddWithValue("@Equivalencia", det.Equivalencia);
                        cmd.Parameters.AddWithValue("@DiferenciaBase", det.DiferenciaBase);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar detalle de ajuste: " + ex.Message,
                        "Capa Datos Inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public DataTable BD_Listar_StockPresentacion_Inventario(string idProducto, int idAlmacen)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("Sp_Listar_StockPresentacion_Inventario", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                        cmd.Parameters.AddWithValue("@IdAlmacen", idAlmacen);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al listar stock de inventario: " + ex.Message,
                        "Capa Datos Inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            return dt;
        }

        public void BD_Ajustar_StockPresentacion_Exacto(int idAlmacen, string idProducto, int idPresentacion, decimal nuevoStock)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("Sp_Ajustar_StockPresentacion_Exacto", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdAlmacen", idAlmacen);
                        cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                        cmd.Parameters.AddWithValue("@IdPresentacion", idPresentacion);
                        cmd.Parameters.AddWithValue("@NuevoStock", nuevoStock);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al ajustar stock presentación: " + ex.Message,
                        "Capa Datos Inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public DataTable BD_Listar_InventarioAjustes(DateTime fechaDesde, DateTime fechaHasta, string estado)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("Sp_Listar_InventarioAjustes", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde.Date);
                        cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta.Date);
                        cmd.Parameters.AddWithValue("@Estado", estado);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al listar ajustes de inventario: " + ex.Message,
                                    "Capa Datos Inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
              
            }

            return dt;
        }

        public DataTable BD_Listar_InventarioAjusteDetalle(int idAjuste)
        {
            DataTable dt = new DataTable();

            using(SqlConnection cn = new SqlConnection(Conectar()))
            {

                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("Sp_Listar_InventarioAjusteDetalle", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdAjuste", idAjuste);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al listar detalle de ajuste: " + ex.Message,
                                    "Capa Datos Inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
               
            }

            return dt;
        }

        public DataTable BD_Buscar_Producto_Inventario(string valor, int idAlmacen)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("Sp_Buscar_Producto_Inventario", cn))
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
                    MessageBox.Show("Error al buscar producto para inventario: " + ex.Message,
                        "Capa Datos Inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            return dt;
        }

        public DataTable BD_Obtener_DetalleAjuste_ParaAnular(int idAjuste)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("Sp_Obtener_DetalleAjuste_ParaAnular", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdAjuste", idAjuste);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalle para anular: " + ex.Message,
                        "Capa Datos Inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            return dt;
        }

        public void BD_Anular_InventarioAjuste(int idAjuste, int idUsuarioAnula, string motivoAnulacion)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("Sp_Anular_InventarioAjuste", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdAjuste", idAjuste);
                        cmd.Parameters.AddWithValue("@IdUsuarioAnula", idUsuarioAnula);
                        cmd.Parameters.AddWithValue("@MotivoAnulacion", motivoAnulacion);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al anular ajuste: " + ex.Message,
                        "Capa Datos Inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    throw;
                }
            }
        }

        public void BD_Ajustar_StockPresentacion_PorDiferencia(int idAlmacen, string idProducto, int idPresentacion, decimal diferencia)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("Sp_Ajustar_StockPresentacion_PorDiferencia", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdAlmacen", idAlmacen);
                        cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                        cmd.Parameters.AddWithValue("@IdPresentacion", idPresentacion);
                        cmd.Parameters.AddWithValue("@Diferencia", diferencia);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al ajustar stock físico por diferencia: " + ex.Message,
                        "Capa Datos Inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    throw;
                }
            }
        }

        public DataTable BD_Validar_AnulacionAjuste_Stock(int idAjuste)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("Sp_Validar_AnulacionAjuste_Stock", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdAjuste", idAjuste);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al validar anulación: " + ex.Message,
                        "Capa Datos Inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            return dt;
        }



    }

}
