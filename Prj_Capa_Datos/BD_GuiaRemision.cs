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
    public class BD_GuiaRemision : BD_Conexion
    {
        public static bool seguardo = false;
        public static bool detseguardo = false;
        public void BD_Ingresar_GuiaRemision(EN_GuiaRemision com)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_GuiaRemision", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_gr", com.IdGr);
                cmd.Parameters.AddWithValue("@nro_fac_ref", com.NroRefFac);
                cmd.Parameters.AddWithValue("@id_cliente", com.IdCliente);
                if (com.Idvehiculo.HasValue)
                {
                    cmd.Parameters.AddWithValue("@id_vehiculo", com.Idvehiculo.Value);  // Se pasa el int
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_vehiculo", DBNull.Value);          // Se guarda NULL
                }

                if (string.IsNullOrEmpty(com.IdTransportista))
                {
                    cmd.Parameters.AddWithValue("@Id_Transportista", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Id_Transportista", com.IdTransportista);
                }              
                cmd.Parameters.AddWithValue("@Id_Usu", com.IdUsu);
                cmd.Parameters.AddWithValue("@Subtotal", com.Subtotal);
                cmd.Parameters.AddWithValue("@Fecha_sys", com.FechSyst);
                cmd.Parameters.AddWithValue("@Fecha_emision", com.FechaEmision);
                cmd.Parameters.AddWithValue("@Fecha_traslado", com.FechaTraslado);
                cmd.Parameters.AddWithValue("@UnidadMediad", com.Und);
                cmd.Parameters.AddWithValue("@PesoTotal", com.PesoTotal);
                cmd.Parameters.AddWithValue("@NumPaquete", com.NumPaquete);
                cmd.Parameters.AddWithValue("@Obs", com.Obs);
                cmd.Parameters.AddWithValue("@ubigeo_partida", com.UbigeoPartida);
                cmd.Parameters.AddWithValue("@punto_partida", com.PuntoPartida);
                cmd.Parameters.AddWithValue("@ubigeo_llegada", com.UbigeoLlegada);
                cmd.Parameters.AddWithValue("@punto_llegada", com.PuntoLlegada);
                cmd.Parameters.AddWithValue("@cdr_sunat", com.CdrSunat);
                cmd.Parameters.AddWithValue("@nro_ticket", com.NroTicket);
                cmd.Parameters.AddWithValue("@hash_cpe", com.HashCpe);
                cmd.Parameters.AddWithValue("@motivo_traslado", com.MotivoTraslado);
                cmd.Parameters.AddWithValue("@motivo_codigo", com.MotivoCodigo);
                cmd.Parameters.AddWithValue("@motivo_desc", com.MotivoDesc);
                cmd.Parameters.AddWithValue("@estado_Doc", com.EstadoDoc);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos GuiaRemesion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // Guardar detalle
        public void BD_Ingresar_Detalle_GuiaRemesion(EN_Det_GuiaRemision det)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Detalle_GuiaRemision", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_gr", det.Idgr);
                cmd.Parameters.AddWithValue("@Id_Pro ", det.Idproducto);
                cmd.Parameters.AddWithValue("@Precio", det.Precio);
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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos GuiaRemision", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // Método para insertar una relación entre una Guía de Remisión y un Conductor
        public void BD_Ingresar_GuiaConductor(string idGr, int idCond)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Gr_Conductor", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_GrTransp", idGr);
                cmd.Parameters.AddWithValue("@Id_Cond", idCond);

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
                MessageBox.Show("Error al registrar conductor en la guía: " + ex.Message, "Capa Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // Método para insertar una relación entre una Guía de Remisión y un Vehículo
        public void BD_Ingresar_GuiaVehiculo(string idGr, int idVehiculo)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Gr_Vehiculo", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_GrTransp", idGr);
                cmd.Parameters.AddWithValue("@Id_vehiculo", idVehiculo);

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
                MessageBox.Show("Error al registrar vehículo en la guía: " + ex.Message, "Capa Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //FE:
        public void BD_CambiarEstado_CdrSunat_GuiaRem(string idDoc, string cdrSunat, string hascpe)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Cambiar_Estado_RespuestaSunat_GuiaRem", cn);
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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Gr", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void BD_ActualizarRespuestas_GuiaRem(string idDoc, string nroTicket, string hashcpe)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_ActualizarResp_GuiaRem", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iddoc", idDoc);
                cmd.Parameters.AddWithValue("@nroticket", nroTicket);
                cmd.Parameters.AddWithValue("@hashcpe", hashcpe);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Gr", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public DataTable BD_Buscador_DocumentoGR_Detalle_porID(string IdDoc)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_DocumentoGR_yDetalle", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Nro_Doc", IdDoc);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos gr_transportista", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;
        }

        //buscar:
        public DataTable BD_Buscar_GuiaRemisionRem(string valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_buscarGrRemitente", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xvalor_cliente", valor);
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
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Gr_Rem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }

        public DataTable BD_Buscar_GuiasRem_Remitente_aExcel(DateTime desde, DateTime hasta)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                SqlCommand cmd = new SqlCommand("sp_Reporte_General_GuiR_Rem", cn)
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

        public DataTable BD_Filtrar_DocsGr_RangoFechas(DateTime desde, DateTime hasta)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                SqlCommand cmd = new SqlCommand("sp_filtrar_Gr_xrangoFech", cn)
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
    }

}
