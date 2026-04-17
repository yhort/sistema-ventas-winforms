using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Prj_Capa_Entidad;
using System.Data.SqlClient;

namespace Prj_Capa_Datos
{
    public class BD_Caja : BD_Conexion
    {
        public static bool cajaSaved = false;

        public void BD_Registrar_Mov_Caja(En_Caja cja)

        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_registrar_Caja", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcaja", cja.Idcaja); //se añadio ára tipos.pagos mx bot
                cmd.Parameters.AddWithValue("@Fecha_Caja", cja.FechaCaja);
                cmd.Parameters.AddWithValue("@Tipo_Caja", cja.TipoCaja);
                cmd.Parameters.AddWithValue("@Concepto", cja.Concepto);
                cmd.Parameters.AddWithValue("@De_Para", cja.De_Para_Cliente);
                cmd.Parameters.AddWithValue("@Nro_Doc", cja.Nro_Doc);
                cmd.Parameters.AddWithValue("@ImporteCaja", cja.ImportaCaja);

                cmd.Parameters.AddWithValue("@Id_Usu", cja.IdUsu);
                cmd.Parameters.AddWithValue("@TotalUti", cja.TotalUti);
                cmd.Parameters.AddWithValue("@TipoPago", cja.TipoPago);
                //cmd.Parameters.AddWithValue("@TipoPago2", cja.TipoPago2);
                cmd.Parameters.AddWithValue("@GeneradoPor", cja.GeneradoPor);
          
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                cajaSaved = true;

            }
            catch (Exception ex)
            {
                cajaSaved = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        //
        public void BD_Actualizar_Total_Caja(string nroDoc, double total, double totalUtili, string tipoPago)

        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Actualizar_Total_Caja", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nro_doc", nroDoc);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@TotalUtilidad", totalUtili);
                cmd.Parameters.AddWithValue("@TipoPago", tipoPago);
               



                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                cajaSaved = true;


            }
            catch (Exception ex)
            {
                cajaSaved = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }

        public DataTable BD_Listar_Todas_Cajas()
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Todas_Cajas", cn);
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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }


        public DataTable BD_Listar_Cajas_Del_Dia(DateTime xdia)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Cajas_delDia", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xdia", xdia);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }


        //se implemnto fecha 24/07/24 para mostrar del dia en explorador caja
        public DataTable BD_Listar_Cajas_Del_Dia_Rep(DateTime xdia)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Cajas_delDia_Rep", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xdia", xdia);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }
        public DataTable BD_Listar_Cajas_Del_Mes(DateTime mesx)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Cajas_del_Mes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fechas", mesx);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        public DataTable BD_buscador_General_Cajas(string valor)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_MoviCaja_xValor", cn);
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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;
        }

        //metodo para implementar editar caja:

        public void BD_editar_Mov_Caja(En_Caja cja)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                //crear el sp editarcaja sql
                SqlCommand cmd = new SqlCommand("Sp_Actualizar_Total_Caja", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@idcaja", cja.Idcaja );
                cmd.Parameters.AddWithValue("@Fecha_Caja", cja.FechaCaja);
                cmd.Parameters.AddWithValue("@Tipo_Caja", cja.TipoCaja);
                cmd.Parameters.AddWithValue("@Concepto", cja.Concepto);
                cmd.Parameters.AddWithValue("@De_Para", cja.De_Para_Cliente);
                cmd.Parameters.AddWithValue("@Nro_Doc", cja.Nro_Doc);
                cmd.Parameters.AddWithValue("@ImporteCaja", cja.ImportaCaja);
                cmd.Parameters.AddWithValue("@TotalUti", cja.TotalUti);
                cmd.Parameters.AddWithValue("@TipoPago", cja.TipoPago);
                //cmd.Parameters.AddWithValue("EstadoCaja", cja.Estado);




                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                cajaSaved = true;


            }
            catch (Exception ex)
            {
                cajaSaved = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        //Sp_Anular_moviCaja 

        public void BD_Anular_Mov_Caja(string nrodoc, string estadoCaja)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                //crear el sp editarcaja sql
                SqlCommand cmd = new SqlCommand("Sp_Anular_moviCaja", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nroDoc", nrodoc);
                cmd.Parameters.AddWithValue("@estadocaja", estadoCaja);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                cajaSaved = true;


            }
            catch (Exception ex)
            {
                cajaSaved = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }



        //Sp_Anular_moviCaja 2 pagos
        public void BD_Anular_Mov_Caja2(string nrodoc)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                //crear el sp editarcaja sql
                SqlCommand cmd = new SqlCommand("Sp_Anular_moviCaja2", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nro_Doc", nrodoc);
              

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                cajaSaved = true;


            }
            catch (Exception ex)
            {
                cajaSaved = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }


        //se añadio del proy.boti:


        //IMPRIMIR REPORTE DE CAJA 
        public DataTable BD_Leer_Caja_porId(string idrepcaja)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_ReporteCierrecaja", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_cierre", idrepcaja);


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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }


        //nuevo metodo para implemntar: Cambiar_modoCaja

        public DataTable BD_buscador_VentasCajaTotalizado( int id, DateTime fechaIni, DateTime fechaFin)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_report_ventasCajaTotalizado", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_Usu", id);
                da.SelectCommand.Parameters.AddWithValue("@fechaIni", fechaIni);
                da.SelectCommand.Parameters.AddWithValue("@fechaFin", fechaFin);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;
        }


        public void BD_CambiarModo_Caja(string idcaja)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                //crear el sp editarcaja sql
                SqlCommand cmd = new SqlCommand("sp_cambiarModo_cierreCaja", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcaja", idcaja);


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                cajaSaved = true;


            }
            catch (Exception ex)
            {
                cajaSaved = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        public DataTable BD_Filtrar_MoviCaja_xrangoFech(DateTime desde, DateTime hasta)
        {
            using (SqlConnection cn = new SqlConnection(Conectar()))
            {
                SqlCommand cmd = new SqlCommand("Sp_Buscador_MoviCaja_xrangoFech", cn)
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
