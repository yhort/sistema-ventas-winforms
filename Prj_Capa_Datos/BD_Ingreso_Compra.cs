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
    public class BD_Ingreso_Compra : BD_Conexion
    {
        public static bool seguardo = false;
        public static bool detseguardo = false;
        //insertar;
        public void BD_Ingresar_RegistroCompra(EN_IngresoCompra com)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Compra", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCom", com.IdCom);
                cmd.Parameters.AddWithValue("@Nro_Fac_Fisico ", com.NroDoc_Fisico);
                cmd.Parameters.AddWithValue("@IdProvee", com.IdProvee);
                cmd.Parameters.AddWithValue("@SubTotal_Com", com.SubTotal_Com);
                cmd.Parameters.AddWithValue("@FechaIngre", com.FechaIngre);
                cmd.Parameters.AddWithValue("@TotalCompra", com.TotalCompra);
                cmd.Parameters.AddWithValue("@IdUsu", com.IdUsu);
                cmd.Parameters.AddWithValue("@ModalidadPago", com.ModalidadPago);
                cmd.Parameters.AddWithValue("@TiempoEspera", com.TiempoEspera);
                cmd.Parameters.AddWithValue("@FechaVence", com.FechaVence);
                cmd.Parameters.AddWithValue("@EstadoIngre", com.EstadoIngre);
                cmd.Parameters.AddWithValue("@RecibiConforme", com.RecibiConforme);
                cmd.Parameters.AddWithValue("@Datos_Adicional", com.Datos_Adicional);
                cmd.Parameters.AddWithValue("@Tipo_Doc_Compra", com.Tipo_Doc_Compra);
                cmd.Parameters.AddWithValue("@TipoRegistro", com.TipoRegistro);
                cmd.Parameters.AddWithValue("@LugarSalida", com.LugarSalida);
                cmd.Parameters.AddWithValue("@TipoProceso", com.TipoProceso);
                cmd.Parameters.AddWithValue("@trn_codigo", com.TrnCodigo);
                cmd.Parameters.AddWithValue("@IGV", com.Igv);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Compras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // Guardar detalle
        public void BD_Ingresar_Detalle_RegistroCompra(EN_Det_IngresoCompra det)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Insert_Detalle_ingreso", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_ingreso", det.Idingreso);
                cmd.Parameters.AddWithValue("@Id_Pro", det.Idproducto);
                cmd.Parameters.AddWithValue("@Precio", det.Precio);
                cmd.Parameters.AddWithValue("@Cantidad", det.Cantidad);
                cmd.Parameters.AddWithValue("@Importe", det.Importe);
                cmd.Parameters.AddWithValue("@IdPresentacion", det.IdPresentacion);
                cmd.Parameters.AddWithValue("@CantidadPresentacion", det.CantidaPresentacion);
                cmd.Parameters.AddWithValue("@Equivalencia", det.Equivalencia);
                cmd.Parameters.AddWithValue("@NombrePresentacion", det.NombrePresentacion);



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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Compras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //validar:
        public bool BD_Verificar_NroDoc_Fisico(string idfisico)
        {
            bool respuesta = false;
            Int32 getvalue = 0;
            SqlConnection cn = new SqlConnection();

            try
            {


                SqlCommand cmd = new SqlCommand();

                cn.ConnectionString = Conectar();

                cmd.CommandText = "sp_validar_NroFisico_Compra";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //parametros:
                cmd.Parameters.AddWithValue("@Nro_Doc_fisico", idfisico);

                cn.Open();
                getvalue = Convert.ToInt32(cmd.ExecuteScalar());

                if (getvalue > 0)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
                cmd.Parameters.Clear();
                cmd.Dispose();
                cmd = null;
                cn.Close();

            }
            catch (Exception ex)
            {


                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Compras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;

            }

            return respuesta;

        }


        //consultas:  haces consultas desde sql -pas2-inserta capanegocio-insrcompras.cs

        public DataTable BD_buscar_Compras_Explorador(string valor)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_Gnral_deCompras", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xvalor", valor);


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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Compras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        //todos:

        public DataTable BD_Cargar_Todas_Compras()
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Leer_Todas_Facturas_Compras", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@Valor", valor);
                //da.SelectCommand.Parameters.AddWithValue("@estado", estado);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Compras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        //por mes: // haces consultas desde sql 
        public DataTable BD_buscar_Compras_Explorador_Pormes_Dia(string tipo, DateTime fechames)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Facturas_Ingresadas_alDia", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@tipo", tipo);
                da.SelectCommand.Parameters.AddWithValue("@fecha", fechames);


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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Compras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        //borrar :

        public void BD_borrar_Compra(string idcompra)
        {


            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("SP_Borrar_Factura_Ingresada", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Fac", idcompra);


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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Compras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }

        public DataTable BD_buscar_Compras_conDetalle(string idcompra)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_FacturasCompras_Detalle", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xvalor", idcompra);
                //da.SelectCommand.Parameters.AddWithValue("@fecha", fechames);


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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Compras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        public DataTable BD_Compras_RangoFechas(DateTime diax, DateTime diax2)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Compras_RangoFechas", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fechaIn", diax);
                da.SelectCommand.Parameters.AddWithValue("@fechaFin", diax2);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;

        }
    }
}
