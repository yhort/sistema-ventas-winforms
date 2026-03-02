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
    public class BD_KardeCredito : BD_Conexion
    {
        public static bool seguardo = false;
        public static bool detsaved = false;
    

        public void BD_Registrar_KardexCredito(EN_Kardex_Credito kr)

        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_KardexCredito", cn);
                cmd.CommandTimeout = 20;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdNotaCred", kr.Idkardex);
                cmd.Parameters.AddWithValue("@Item", kr.Item);
                cmd.Parameters.AddWithValue("@FechaAbono", kr.FechaAbono);
                cmd.Parameters.AddWithValue("@DocRef", kr.Docreference);
                cmd.Parameters.AddWithValue("@DetOperacion", kr.DetOperacion);
                cmd.Parameters.AddWithValue("@TotalCred", kr.TotalCredito);
                cmd.Parameters.AddWithValue("@A_Cuenta", kr.Acuenta);

                cmd.Parameters.AddWithValue("@Saldo_Pendiente", kr.SaldoPendiente);



                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                detsaved = true;



            }
            catch (Exception ex)
            {
                detsaved = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Kardex_Credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }


        public void BD_Registrar_detalleKardexCredito(EN_Kardex_Credito kr)

        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_registrar_DetalleKardex_Credito", cn);
                cmd.CommandTimeout = 20;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdNotaCred", kr.Idkardex);
                cmd.Parameters.AddWithValue("@Item", kr.Item);
                cmd.Parameters.AddWithValue("@FechaAbono", kr.FechaAbono);
                cmd.Parameters.AddWithValue("@DocRef", kr.Docreference);
                cmd.Parameters.AddWithValue("@DetOperacion", kr.DetOperacion);
                cmd.Parameters.AddWithValue("@TotalCred", kr.TotalCredito);
                cmd.Parameters.AddWithValue("@A_Cuenta", kr.Acuenta);

                cmd.Parameters.AddWithValue("@Saldo_Pendiente", kr.SaldoPendiente);



                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                detsaved = true;



            }
            catch (Exception ex)
            {
                detsaved = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Kardex_Credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }





        //VALIDAR:

        public bool BD_Verificar_Documento_siTieneKardex(string idprod)
        {
            bool respuesta = false;
            Int32 getvalue = 0;
            SqlConnection cn = new SqlConnection();

            try
            {


                SqlCommand cmd = new SqlCommand();

                cn.ConnectionString = Conectar();

                cmd.CommandText = "Sp_Ver_sihay_Kardex_Credito";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //parametros:
                cmd.Parameters.AddWithValue("@IdNotaCred", idprod);

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

                detsaved = false; // se puede cambiar deacuerdo al video.
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Kardex_Credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //return false; //respuesta =false; se hizo cambio linea abajo
                respuesta = false;

            }

            return respuesta;

        }

        public DataTable BD_Buscar_KardexDetalle_por_Doc(string idprod)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_DeKardex_Principal_yDetalle_Credito", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xvalor", idprod);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Kardex", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }


        //PARA CONSULTAR MOVIMIENTO DE ABONOS DE CREDITO DETALLE - 21-01-24

        public DataTable BD_Buscar_KardexDetalle_Abono_por_Doc(string idprodxxx)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_DetalleKardex_Credito", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@valordet", idprodxxx);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Kardex", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }




        //buscar por dia
        public DataTable BD_Cargar_DetalleKardexCredito_delDia(DateTime dia)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Ver_KardexCreditoExplor_delDia", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Fecha", dia);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Kardex", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }



    }
}
