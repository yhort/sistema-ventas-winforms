using Prj_Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prj_Capa_Datos
{
    public  class BD_PromocionVenta : BD_Conexion
    {

        public static bool promoSaved = false;

        public void BD_Registrar_PromocionVenta(EN_Promocion_Venta promoVenta)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Registrar_PromocionVenta", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_Doc", promoVenta.IdDoc);
                cmd.Parameters.AddWithValue("@IdPromocion", promoVenta.IdPromocion);
                cmd.Parameters.AddWithValue("@Descuento", promoVenta.Descuento);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                promoSaved = true;
            }
            catch (Exception ex)
            {
                promoSaved = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar promoción: " + ex.Message, "Capa Datos PromociónVenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        //public DataTable BD_Buscar_Promociones_Activas(string idProducto)
        //{
        //    SqlConnection cn = new SqlConnection();
        //    try
        //    {
        //        cn.ConnectionString = Conectar();
        //        SqlCommand cmd = new SqlCommand(@"
        //            SELECT p.IdPromocion, p.Nombre, p.Tipo, pd.IdProducto, pd.Cantidad, pd.PrecioUnitario 
        //            FROM Promocion p
        //            INNER JOIN PromocionDetalle pd ON p.IdPromocion = pd.IdPromocion
        //            WHERE p.Activo = 1 
        //            AND GETDATE() BETWEEN p.FechaInicio AND p.FechaFin 
        //            AND pd.IdProducto = @IdProducto", cn);
        //        cmd.CommandType = CommandType.Text;
        //        cmd.Parameters.AddWithValue("@IdProducto", idProducto);

        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al consultar promociones: " + ex.Message, "Capa Datos PromociónVenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return null;
        //    }
        //}

    }
}
