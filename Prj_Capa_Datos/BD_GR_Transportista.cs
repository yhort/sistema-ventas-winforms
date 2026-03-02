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
    public class BD_GR_Transportista : BD_Conexion
    {
        public static bool seguardo = false;
        public static bool detseguardo = false;

        public void BD_Ingresar_GuiaRemision_Transportista(EN_Gr_Transportista com)
        {


            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_GuiaR_Transportista", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_GrTransp", com.Idgr_Transp);
                cmd.Parameters.AddWithValue("@Id_GrRemitente ", com.Id_grRem);
                cmd.Parameters.AddWithValue("@Id_Cliente", com.IdCliente);
                cmd.Parameters.AddWithValue("@direccion_Id", com.IdDireccion);
                cmd.Parameters.AddWithValue("@Subtotal", com.Subtotal);
                cmd.Parameters.AddWithValue("@Fecha", com.Fecha);
                cmd.Parameters.AddWithValue("@Fecha_traslado", com.FechaTraslado);
                cmd.Parameters.AddWithValue("@UnidadMediad", com.UnidadMedida);
                cmd.Parameters.AddWithValue("@PesoTotal", com.PesoTotal);
                cmd.Parameters.AddWithValue("@NumPaquete", com.NumPaquete);
                cmd.Parameters.AddWithValue("@Orden_Compra", com.OrdenCompra);
                cmd.Parameters.AddWithValue("@Obs", com.Obs);
                cmd.Parameters.AddWithValue("@PagadorFlete", com.PagadorFlete);
                cmd.Parameters.AddWithValue("@Id_Cliente_2", com.IdCliente_sec);
                cmd.Parameters.AddWithValue("@direccion_Id_2", com.IdDirecsec);
                cmd.Parameters.AddWithValue("@Id_Cond", com.IdCond);
                cmd.Parameters.AddWithValue("@Id_Cond_2", com.IdCondsec);
                cmd.Parameters.AddWithValue("@Id_Vehiculo", com.Idvehic);              
                cmd.Parameters.AddWithValue("@Cdr_Sunat", com.CdrSunat);
                cmd.Parameters.AddWithValue("@NroTicket", com.NroTicket);
                cmd.Parameters.AddWithValue("@HashCPE", com.HashCpe);
                cmd.Parameters.AddWithValue("@Id_Usu", com.IdUsu);
                cmd.Parameters.AddWithValue("@Total", com.Total);
                cmd.Parameters.AddWithValue("@Estado", com.Estado);




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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos GuiaRemesion Transportista", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }


        // Guardar detalle
        public void BD_Ingresar_Detalle_GuiaRemIsion_Transportista(EN_Det_GR_Transportista det)
        {


            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Detalle_GR_Transportista", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_GrTransp", det.Idgr);
                cmd.Parameters.AddWithValue("@Id_Pro ", det.Idproducto);
                cmd.Parameters.AddWithValue("@PrecioUnit", det.Precio);
                cmd.Parameters.AddWithValue("@Cantidad", det.Cantidad);
                cmd.Parameters.AddWithValue("@Importe", det.Importe);


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                detseguardo = true;



            }
            catch (Exception ex)
            {
                detseguardo = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos GuiaRemision Transportista", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }

        //FE:
        public void BD_CambiarEstado_CdrSunat_GrTransport(string idDoc, string cdrSunat, string hascpe)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Cambiar_Estado_RespuestaSunat_GrTransport", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iddoc", idDoc);
                cmd.Parameters.AddWithValue("@estadoCdr", cdrSunat);
                cmd.Parameters.AddWithValue("@hash_cpe", hascpe);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos GrTransport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //buscar:
        public DataTable BD_Buscar_GrRemitente(string valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_buscarGrRemitente", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xvalor", valor);
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
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Gr_Transprt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }

        //buscador con detalle : 
        //buscador con detalle:

       


    }

}
