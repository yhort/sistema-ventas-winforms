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
    public class BD_Temporal : BD_Conexion
    {

        public static bool saved = false;
        public void BD_Registrar_Temporal(EN_Temporal tem)
        {
            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Insertar_Temporal", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codTem", tem.IdTemporal);
                cmd.Parameters.AddWithValue("@FechaEmi", tem.FechaEmi);
                cmd.Parameters.AddWithValue("@cliente", tem.Nomcliente);
                cmd.Parameters.AddWithValue("@Ruc", tem.Ruc);
                cmd.Parameters.AddWithValue("@Direccion", tem.Direccion);
                cmd.Parameters.AddWithValue("@SubTtal", tem.Subtotal);
                cmd.Parameters.AddWithValue("@IgvT", tem.Igv);
                cmd.Parameters.AddWithValue("@TotalT", tem.Total);
                cmd.Parameters.AddWithValue("@TipoPago", tem.TipoPago);
                cmd.Parameters.AddWithValue("@NroOperacion", tem.NroOperacion);
                cmd.Parameters.AddWithValue("@Efectivo", tem.Efectivo);
                cmd.Parameters.AddWithValue("@Vuelto", tem.Vuelto);
                cmd.Parameters.AddWithValue("@SonT", tem.Sonletra);
                cmd.Parameters.AddWithValue("@vendedor", tem.Vendedor);
                cmd.Parameters.AddWithValue("@CodigoQr", tem.CodigoQr);

                //FE:
                cmd.Parameters.AddWithValue("@Tipocomprobante", tem.Tipocomprobante);
                cmd.Parameters.AddWithValue("@hash_cpe", tem.Hash_cpe);
                cmd.Parameters.AddWithValue("@MotivoEmision", tem.MotivoEmision);
                cmd.Parameters.AddWithValue("@Exonerada", tem.Exonerada);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                saved = true;

            }
            catch (Exception ex)
            {
                saved = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Temporal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }

        public void BD_Registrar_Detalle_Temporal(EN_Det_Temporal tem)
        {


            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_registrar_Det_Temporal", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codtem", tem.IdTempo);
                cmd.Parameters.AddWithValue("@CodProd", tem.CodProd);
                cmd.Parameters.AddWithValue("@Cantidad", tem.Canti);
                cmd.Parameters.AddWithValue("@Producto", tem.Producto);
                cmd.Parameters.AddWithValue("@PreUnt", tem.Precio);
                cmd.Parameters.AddWithValue("@Importe", tem.Importe);




                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                saved = true;



            }
            catch (Exception ex)
            {
                saved = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Temporal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }


        public DataTable BD_Leer_Temporal_porId(string idtempo)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Temporales", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id", idtempo);


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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Temporal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }


        //Eliminar:
        public void BD_Eliminar_Temporal(string idTempo)
        {


            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Delete_Det_Temporal", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", idTempo);


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                saved = true;


            }
            catch (Exception ex)
            {
                saved = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Temporal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }

        //Eliminar todo tmventa:
        public void BD_Eliminar_Temporal_V()
        {


            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Limpiar_Temporales_Venta", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;



                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                saved = true;


            }
            catch (Exception ex)
            {
                saved = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Temporal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }

    }
}
