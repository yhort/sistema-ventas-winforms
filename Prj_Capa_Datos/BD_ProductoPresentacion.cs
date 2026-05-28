using Prj_Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Datos
{
    public class BD_ProductoPresentacion : BD_Conexion
    {
        public void BD_Registrar_ProductoPresentacion(EN_ProductoPresentacion pre)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("Sp_Registrar_ProductoPresentacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdProducto", pre.IdProducto);
                cmd.Parameters.AddWithValue("@NombrePresentacion", pre.NombrePresentacion);
                cmd.Parameters.AddWithValue("@Abreviatura", pre.Abreviatura);
                cmd.Parameters.AddWithValue("@Equivalencia", pre.Equivalencia);
                cmd.Parameters.AddWithValue("@PrecioCompra", pre.PrecioCompra);
                cmd.Parameters.AddWithValue("@PrecioVentaMinorista", pre.PrecioVentaMinorista);
                cmd.Parameters.AddWithValue("@PrecioVentaMayorista", pre.PrecioVentaMayorista);
                cmd.Parameters.AddWithValue("@CantMinMayorista", pre.CantMinMayorista);
                cmd.Parameters.AddWithValue("@EsBase", pre.EsBase);
                cmd.Parameters.AddWithValue("@PermiteCompra", pre.PermiteCompra);
                cmd.Parameters.AddWithValue("@PermiteVenta", pre.PermiteVenta);
                cmd.Parameters.AddWithValue("@Activo", pre.Activo);
                cmd.Parameters.AddWithValue("@CodigoBarra", string.IsNullOrWhiteSpace(pre.CodigoBarra) ? (object)DBNull.Value : pre.CodigoBarra);
                cmd.Parameters.AddWithValue("@SKU", string.IsNullOrWhiteSpace(pre.SKU) ? (object)DBNull.Value : pre.SKU);


                cmd.ExecuteNonQuery();
            }
        }

        public void BD_Editar_ProductoPresentacion(EN_ProductoPresentacion pre)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("Sp_Editar_ProductoPresentacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdPresentacion", pre.IdPresentacion);
                cmd.Parameters.AddWithValue("@NombrePresentacion", pre.NombrePresentacion);
                cmd.Parameters.AddWithValue("@Abreviatura", pre.Abreviatura);
                cmd.Parameters.AddWithValue("@Equivalencia", pre.Equivalencia);
                cmd.Parameters.AddWithValue("@PrecioCompra", pre.PrecioCompra);
                cmd.Parameters.AddWithValue("@PrecioVentaMinorista", pre.PrecioVentaMinorista);
                cmd.Parameters.AddWithValue("@PrecioVentaMayorista", pre.PrecioVentaMayorista);
                cmd.Parameters.AddWithValue("@CantMinMayorista", pre.CantMinMayorista);
                cmd.Parameters.AddWithValue("@EsBase", pre.EsBase);
                cmd.Parameters.AddWithValue("@PermiteCompra", pre.PermiteCompra);
                cmd.Parameters.AddWithValue("@PermiteVenta", pre.PermiteVenta);
                cmd.Parameters.AddWithValue("@Activo", pre.Activo);
                cmd.Parameters.AddWithValue("@CodigoBarra", string.IsNullOrWhiteSpace(pre.CodigoBarra) ? (object)DBNull.Value : pre.CodigoBarra);
                cmd.Parameters.AddWithValue("@SKU", string.IsNullOrWhiteSpace(pre.SKU) ? (object)DBNull.Value : pre.SKU);

                cmd.ExecuteNonQuery();
            }
        }

        public void BD_Desactivar_ProductoPresentacion(int idPresentacion)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("Sp_Desactivar_ProductoPresentacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdPresentacion", idPresentacion);

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable BD_Listar_ProductoPresentacion_PorProducto(string idProducto , int idAlmacen)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("Sp_Listar_ProductoPresentacion_PorProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                cmd.Parameters.AddWithValue("@IdAlmacen", idAlmacen);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public DataTable BD_Buscar_ProductoPresentacion_PorId(int idPresentacion)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("Sp_Buscar_ProductoPresentacion_PorId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPresentacion", idPresentacion);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public DataTable BD_Buscar_Producto_ConPresentaciones(string valor)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("Sp_Buscar_Producto_ConPresentaciones", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@valor", valor);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public DataTable BD_Buscar_Producto_ConPresentaciones_Venta(string valor)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("Sp_Buscar_Producto_ConPresentaciones_Venta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@valor", valor);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public int BD_Importar_ProductoPresentacion(EN_ProductoPresentacion pre)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("Sp_Importar_ProductoPresentacion", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdProducto", pre.IdProducto);
                    cmd.Parameters.AddWithValue("@NombrePresentacion", pre.NombrePresentacion);
                    cmd.Parameters.AddWithValue("@Abreviatura", pre.Abreviatura);
                    cmd.Parameters.AddWithValue("@Equivalencia", pre.Equivalencia);
                    cmd.Parameters.AddWithValue("@CodigoBarra",
                    string.IsNullOrWhiteSpace(pre.CodigoBarra) ? "" : pre.CodigoBarra.Trim());
                    cmd.Parameters.AddWithValue("@SKU",
                    string.IsNullOrWhiteSpace(pre.SKU) ? "" : pre.SKU.Trim().ToUpper());
                    cmd.Parameters.AddWithValue("@PrecioCompra", pre.PrecioCompra);
                    cmd.Parameters.AddWithValue("@PrecioVentaMinorista", pre.PrecioVentaMinorista);
                    cmd.Parameters.AddWithValue("@PrecioVentaMayorista", pre.PrecioVentaMayorista);
                    cmd.Parameters.AddWithValue("@CantMinMayorista", pre.CantMinMayorista);

                    SqlParameter idPres = new SqlParameter("@IdPresentacion", SqlDbType.Int);
                    idPres.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(idPres);

                    cmd.ExecuteNonQuery();

                    return Convert.ToInt32(idPres.Value);
                }
            }
        }

        public DataTable BD_Validar_CodigoSKU_Presentacion(int idPresentacion, string codigoBarra, string sku)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("Sp_Validar_CodigoSKU_Presentacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPresentacion", idPresentacion);
                cmd.Parameters.AddWithValue("@CodigoBarra", codigoBarra);
                cmd.Parameters.AddWithValue("@SKU", sku);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

    }
}
