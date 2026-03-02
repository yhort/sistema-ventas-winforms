using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prj_Capa_Entidad;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Prj_Capa_Datos
{
    public class BD_Cierre_Caja : BD_Conexion
    {

        public static bool saved = false;

        public void BD_Registrar_Inicio_Caja(EN_Cierre_Caja cli)
        {


            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Reg_Cierre_Caja", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCierre", cli.Idcierre);
                cmd.Parameters.AddWithValue("@Apertura_Caja", cli.AperturaCaja);
                cmd.Parameters.AddWithValue("@Total_Ingreso", cli.TotalIngreso);
                cmd.Parameters.AddWithValue("@TotalEgreso", cli.TotalEgreso);
                cmd.Parameters.AddWithValue("@Id_usu", cli.IdUsu);
                cmd.Parameters.AddWithValue("@TodoDeposito", cli.TodoDeposito);
                cmd.Parameters.AddWithValue("@TotalGanancia", cli.TotalGanancia);
                cmd.Parameters.AddWithValue("@TotalEntregado", cli.TotalEntregado);
                cmd.Parameters.AddWithValue("@SaldoSiguiente", cli.SaldoSiguiente);
                cmd.Parameters.AddWithValue("@TotalFactura", cli.TotalFactura);
                cmd.Parameters.AddWithValue("@TotalBoleta", cli.TotalBoleta);
                cmd.Parameters.AddWithValue("@Totalnota", cli.TotalNota);
                cmd.Parameters.AddWithValue("@TotalCreditoCobrado", cli.TotalCreditoCobrado);
                cmd.Parameters.AddWithValue("@TotalCreditoEmitido", cli.TotalCreditoEmitido);
                cmd.Parameters.AddWithValue("@Total_Efectivo", cli.TotalEfectivo);
                cmd.Parameters.AddWithValue("@Total_Yape", cli.TotalYape);
                cmd.Parameters.AddWithValue("@Total_Plin", cli.TotalPlin);
                cmd.Parameters.AddWithValue("@Total_TarjetasCred", cli.TotalTarjetasCred);
                cmd.Parameters.AddWithValue("@Total_OtrosIngresos", cli.TotalOtrosIngresos);

                //cmd.Parameters.AddWithValue("@NombreDesktop", cli.NomnbreDesktop);



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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Cierre Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }


        public void BD_Registrar_Cierrede_Caja(EN_Cierre_Caja cli)
        {


            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_registrar_Cierre_Caja", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDCIERRE", cli.Idcierre);
                cmd.Parameters.AddWithValue("@Apertura_Caja", cli.AperturaCaja);
                cmd.Parameters.AddWithValue("@Total_Ingreso", cli.TotalIngreso);
                cmd.Parameters.AddWithValue("@TotalEgreso", cli.TotalEgreso);
                cmd.Parameters.AddWithValue("@Id_usu", cli.IdUsu);
                cmd.Parameters.AddWithValue("@TodoDeposito", cli.TodoDeposito);
                cmd.Parameters.AddWithValue("@TotalGanancia", cli.TotalGanancia);
                cmd.Parameters.AddWithValue("@TotalEntregado", cli.TotalEntregado);
                cmd.Parameters.AddWithValue("@SaldoSiguiente", cli.SaldoSiguiente);
                cmd.Parameters.AddWithValue("@TotalFactura", cli.TotalFactura);
                cmd.Parameters.AddWithValue("@TotalBoleta", cli.TotalBoleta);
                cmd.Parameters.AddWithValue("@Totalnota", cli.TotalNota);
                cmd.Parameters.AddWithValue("@TotalCreditoCobrado", cli.TotalCreditoCobrado);
                cmd.Parameters.AddWithValue("@TotalCreditoEmitido", cli.TotalCreditoEmitido);
                cmd.Parameters.AddWithValue("@Total_Efectivo", cli.TotalEfectivo);
                cmd.Parameters.AddWithValue("@Total_Yape", cli.TotalYape);
                cmd.Parameters.AddWithValue("@Total_Plin", cli.TotalPlin);
                cmd.Parameters.AddWithValue("@Total_TarjetasCred", cli.TotalTarjetasCred);
                cmd.Parameters.AddWithValue("@Total_OtrosIngresos", cli.TotalOtrosIngresos); 
                //cmd.Parameters.AddWithValue("@NombreDesktop", cli.NomnbreDesktop);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        public DataTable BD_Listar_Todas_CierresCaja()
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_todos_cierresCaja", cn);
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


        public DataTable BD_Listar_Cierre_Caja_delDia(DateTime fecha, string valor)
        {
            //se añadio 2 parametros fecha,valor 6/11/24
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_CierreCaja_delDia", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xdia", fecha);
                da.SelectCommand.Parameters.AddWithValue("@estadocierre", valor);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos CierreCaja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        public DataTable BD_Listar_Cierre_Caja_delMes(DateTime fecha)
        {
            //se añadio 2 parametros fecha,valor 6/11/24
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_CierreCaja_delMes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xmes", fecha);
 

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos CierreCaja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }
        public DataTable BD_Listar_Cierre_Caja_xUsuario(int usu)
        {
            //se añadio 2 parametros fecha,valor 6/11/24
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_CierreCaja_porUsuario", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_Usu", usu);


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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos CierreCaja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        public DataTable BD_Listar_Cierre_Caja_xUsuarioMes(int idusu, DateTime xfecha)
        {
            //se añadio 2 parametros fecha,valor 6/11/24
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_CierreCaja_porUsu_Mes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_Usu", idusu);
                da.SelectCommand.Parameters.AddWithValue("@fechames", xfecha);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos CierreCaja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }
        //Validar:

        public bool BD_Validar_InicioDoble_Caja()
        {
            bool respuesta = false;
            Int32 getvalue = 0;
            SqlConnection cn = new SqlConnection();

            try
            {


                SqlCommand cmd = new SqlCommand();

                cn.ConnectionString = Conectar();

                cmd.CommandText = "SP_VALIDAR_REGISTRO_CAJA";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //parametros:
                //cmd.Parameters.AddWithValue("@Usuario", usu);
                //cmd.Parameters.AddWithValue("@Contraseña", clave);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;

            }

            return respuesta;

        }


        public DataTable BD_Listar_Cierre_Caja_porID(string idcierre)
        {
            //nuevo 
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_CierreCaja_porId", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idcierre", idcierre);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Cierre Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }


        //public bool BD_Validar_InicioDoble_Caja_2(string nompc)
        //{
        //    bool respuesta = false;
        //    Int32 getvalue = 0;
        //    SqlConnection cn = new SqlConnection();

        //    try
        //    {


        //        SqlCommand cmd = new SqlCommand();

        //        cn.ConnectionString = Conectar();

        //        cmd.CommandText = "SP_VALIDAR_REGISTRO_CAJA_un";
        //        cmd.Connection = cn;
        //        cmd.CommandTimeout = 20;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        //parametros:
        //        cmd.Parameters.AddWithValue("@valor", nompc);
        //        //cmd.Parameters.AddWithValue("@Contraseña", clave);

        //        cn.Open();
        //        getvalue = Convert.ToInt32(cmd.ExecuteScalar());

        //        if (getvalue > 0)
        //        {
        //            respuesta = true;
        //        }
        //        else
        //        {
        //            respuesta = false;
        //        }
        //        cmd.Parameters.Clear();
        //        cmd.Dispose();
        //        cmd = null;
        //        cn.Close();

        //    }
        //    catch (Exception ex)
        //    {


        //        if (cn.State == ConnectionState.Open)
        //        {

        //            cn.Close();
        //        }
        //        MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return false;

        //    }

        //    return respuesta;

        //}





        //======================= Metodos para calcular las ventas del Dia ================================//

        public DataTable BD_Calcular_Ventas_PorTipo_Doc(string nomTipoDoc)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Ventas_PorTipoDoc", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@tipodoc", nomTipoDoc);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        //public DataTable BD_Calcular_Ventas_PorTipo_Pagox(string tipopagox, string tipopagox_n = null)
        //{
        //    SqlConnection cn = new SqlConnection();
        //    try
        //    {
        //        cn.ConnectionString = Conectar();
        //        SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Ventas_PorTipoPago", cn);
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;

        //        // Primer parámetro obligatorio: tipo de pago
        //        da.SelectCommand.Parameters.AddWithValue("@tipopagox", tipopagox);

        //        // Si se pasa un tipo de pago adicional, lo agregamos, si no se pasa, lo dejamos como NULL
        //        if (string.IsNullOrEmpty(tipopagox_n))
        //        {
        //            da.SelectCommand.Parameters.AddWithValue("@tipopagox_n", DBNull.Value);  // Usamos DBNull.Value si no se pasa el segundo parámetro
        //        }
        //        else
        //        {
        //            da.SelectCommand.Parameters.AddWithValue("@tipopagox_n", tipopagox_n);
        //        }

        //        DataTable dato = new DataTable();
        //        da.Fill(dato);
        //        return dato;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (cn.State == ConnectionState.Open)
        //        {
        //            cn.Close();
        //        }
        //        MessageBox.Show("Error al obtener datos: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //    return null;
        //}


        public DataTable BD_Calcular_Ventas_PorTipo_Pagox(string tipopagox)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Ventas_PorTipoPago", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@tipopagox", tipopagox);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }



        public DataTable BD_Calcular_Gastos_PorTipo_Pago(string tipopago)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Gastos_porTipoPago", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@tipopago", tipopago);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }




        public DataTable BD_Calcular_Ventas_Acredito()
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Ventas_aCredito", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@tipopago", tipopago);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }



        public DataTable BD_Calcular_Ventas_Adeposito()
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Ventas_aDeposito", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@tipopago", tipopago);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }


        public DataTable BD_Calcular_Ganancias_Deldia()
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Ventas_GananciadelDia", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@tipopago", tipopago);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }


    }
}
