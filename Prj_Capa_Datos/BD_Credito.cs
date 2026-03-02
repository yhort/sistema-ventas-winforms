using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Prj_Capa_Entidad;
using System.Windows.Forms;

namespace Prj_Capa_Datos
{
    public class BD_Credito : BD_Conexion
    {

        public static bool credSaved = false;
        public static bool DetcredSaved = false;
       


        public void BD_Registrar_Credito(EN_Credito cre)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Credito", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //parametros del storede procedure:
                cmd.Parameters.AddWithValue("@idnotacredito", cre.Idcredito);
                cmd.Parameters.AddWithValue("@idDoc", cre.IdDoc);
                cmd.Parameters.AddWithValue("@Fecha_Credito", cre.Fecha_Credito);
                cmd.Parameters.AddWithValue("@nomcliente", cre.NomCliente);
                cmd.Parameters.AddWithValue("@total_ped", cre.TotalCredito);
                cmd.Parameters.AddWithValue("@Saldo_Pdnte", cre.Saldo_Pdnte);
                cmd.Parameters.AddWithValue("@Fecha_vncmnto", cre.Fecha_Vencimiento);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                credSaved = true;

            }
            catch (Exception ex)
            {
                credSaved = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }



        //detalle:
        public void BD_Registrar_Detalle_Credito(EN_DetCredito cre)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_ingresar_det_Credito", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //parametros del storede procedure:
                cmd.Parameters.AddWithValue("@idnotacredito", cre.IdCredito);
                cmd.Parameters.AddWithValue("@Acuenta", cre.Acuenta);
                cmd.Parameters.AddWithValue("@saldoactual", cre.SaldoActual);
                cmd.Parameters.AddWithValue("@Fecha_Pago", cre.FechaPago);
                cmd.Parameters.AddWithValue("@TipoPago", cre.TipoPago);
                cmd.Parameters.AddWithValue("@nroOpera", cre.NroOperacion);
                cmd.Parameters.AddWithValue("@idUsu", cre.IdUsu);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                DetcredSaved = true;

            }
            catch (Exception ex)
            {
                DetcredSaved = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }



        //consulta:
        public static double BD_Sumar_Total_Credito_porCliente(string idCliente)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar2();
                SqlCommand da = new SqlCommand("Sp_Ver_SumaTotal_credito_xcliente", cn);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@nomcliente", idCliente);

                double TotalCredito = 0;

                cn.Open();
                TotalCredito = Convert.ToDouble(da.ExecuteScalar());
                cn.Close();

                return TotalCredito;



            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
        }


        public DataTable BD_Listar_Todas_Creditos()
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Ver_Todo_Credito ", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@Fecha_Mes", mesx);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }


        //por valor
        public DataTable BD_Listar_creditos_porValor(string valor)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_creditos", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@nomcliente", valor);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }


        //por dia

        public DataTable BD_Buscador_Doc_Creditos_porDia(DateTime diax)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Filtrar_creditos_deldia", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Xmes", diax);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Creditos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        //Mes:
        public DataTable BD_Buscador_Doc_Creditos_porMes(DateTime mesx)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Filtrar_creditos_delMes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fechames", mesx);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Creditos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;

        }

        public static bool borrar = false;
        public void BD_Eliminar_Credito_Permanente(string idcred)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_eliminar_Credito_Permanente", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //
                cmd.Parameters.AddWithValue("@Idcredito", idcred);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                borrar = true;
            }
            catch (Exception ex)
            {
                borrar = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Creditos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        //cargar datos en vetnana de abono
        public DataTable BD_Buscador_CreditoDetalle_porID(string idcred)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Ver_SumaTotal_credito_xcliente", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Nro_Doc", idcred);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }



    }
}
