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
    public class BD_Pedido  : BD_Conexion
    {

        public static bool seguardo = false;

        public static bool detseguardo = false;

        public void BD_Registrar_Pedido(EN_Pedido ped)
        {


            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Pedido", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Ped", ped.IdPedido);
                cmd.Parameters.AddWithValue("@Id_Cliente", ped.IdCliente);
                cmd.Parameters.AddWithValue("@SubTotal", ped.SubTotal);
                cmd.Parameters.AddWithValue("@IgvPed", ped.Igv);
                cmd.Parameters.AddWithValue("@TotalPed", ped.TotalPed);
                cmd.Parameters.AddWithValue("@id_Usu", ped.IdUsu);
                cmd.Parameters.AddWithValue("@TotalGancia", ped.TotalGancia);
                cmd.Parameters.AddWithValue("@subtotal_gravado ", ped.Subtotal_gravado);
                cmd.Parameters.AddWithValue("@IgvGravado", ped.IgvGravado);
                cmd.Parameters.AddWithValue("@TotalGravado", ped.TotalGravado);
                cmd.Parameters.AddWithValue("@Exonerada", ped.Exonerada);


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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }



        //detalle

        public void BD_Registrar_Detalle_Pedido(EN_Det_Pedido det)
        {



            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Registrar_detalle_Pedido", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Ped", det.IdPed);
                cmd.Parameters.AddWithValue("@Id_Pro", det.IdPro);
                cmd.Parameters.AddWithValue("@Precio", det.Precio);
                cmd.Parameters.AddWithValue("@Cantidad", det.Cantidad);
                cmd.Parameters.AddWithValue("@Importe", det.Importe);
                cmd.Parameters.AddWithValue("@Tipo_Prod", det.Tipo_Prod);
                cmd.Parameters.AddWithValue("@Und_Medida", det.Und);
                cmd.Parameters.AddWithValue("@Utilidad_Unit", det.Utilidad_Unit);
                cmd.Parameters.AddWithValue("@TotalUtilidad", det.Totalutilidad);
                cmd.Parameters.AddWithValue("@AfectoIgv ", det.AfectoIgv);
                cmd.Parameters.AddWithValue("@Precio_sinIgv", det.Precio_sinIgv);
                cmd.Parameters.AddWithValue("@subtotal_SinIgv", det.Subtotal_SinIgv);
                cmd.Parameters.AddWithValue("@Igv_subtotal", det.Igv_subtotal);

                cmd.Parameters.AddWithValue("@IdPresentacion", det.IdPresentacion);
                cmd.Parameters.AddWithValue("@CantidadPresentacion", det.CantidadPresentacion);
                cmd.Parameters.AddWithValue("@Equivalencia", det.Equivalencia);
                cmd.Parameters.AddWithValue("@NombrePresentacion", det.NombrePresentacion);
                cmd.Parameters.AddWithValue("@CantidadBase", det.CantidadBase);


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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }


        //borrar detalle de pedido

        public void BD_Eliminar_Detalle_Pedido(string idpedido) //no se necesita clase EN_ solo variable
        {



            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_eliminar_detalle_Pedido", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Ped", idpedido);



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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }



        //editar pedido:
        public void BD_Editar_Pedido(EN_Pedido ped)
        {


            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Editar_Pedido", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Ped", ped.IdPedido);
                cmd.Parameters.AddWithValue("@Id_Cliente", ped.IdCliente);
                cmd.Parameters.AddWithValue("@SubTotal", ped.SubTotal);
                cmd.Parameters.AddWithValue("@IgvPed", ped.Igv);
                cmd.Parameters.AddWithValue("@TotalPed", ped.TotalPed);
                cmd.Parameters.AddWithValue("@id_Usu", ped.IdUsu);
                cmd.Parameters.AddWithValue("@TotalGancia", ped.TotalGancia);
                cmd.Parameters.AddWithValue("@subtotal_gravado ", ped.Subtotal_gravado);
                cmd.Parameters.AddWithValue("@IgvGravado", ped.IgvGravado);
                cmd.Parameters.AddWithValue("@TotalGravado", ped.TotalGravado);




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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }


        //verificar:
        public bool BD_Verificar_Nro_Pedido(string NroPedido)
        {
            bool respuesta = false;
            Int32 getvalue = 0;
            SqlConnection cn = new SqlConnection();

            try
            {


                SqlCommand cmd = new SqlCommand();

                cn.ConnectionString = Conectar();

                cmd.CommandText = "Sp_Verificar_Id_Pedido";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //parametros:
                cmd.Parameters.AddWithValue("id_Ped", NroPedido);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;

            }

            return respuesta;

        }


        //poner pedido como atendido:
        public void BD_Poner_Pedido_Como_Atendido(string idpedido)
        {



            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Pedido_Atendido", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Ped", idpedido);



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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }


        //cambiar el Nombre del cliente del pedido:
        public void BD_Cambiar_Cliente_dePedido_Pedido(string idpedido, string idcliente)
        {



            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Actu_clien_Ped", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Ped", idpedido);
                cmd.Parameters.AddWithValue("@Id_cli", idcliente);



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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }


        //eliminar pedido permanente:
        public void BD_Eliminar_Pedido_Permanente(string idpedido)
        {



            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Eliminar_Pedido_Completo", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Ped", idpedido);




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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }



        //consultas:
        public DataTable BD_Buscar_Pedido_Para_Editar(string idpedido)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Pedido_Para_Editar", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_Ped", idpedido);

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


        //1:cargar pedidos todos:
        public DataTable BD_Buscar_Pedidos_porValor(string IdPedido)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_buscar_Pedidos_porValor", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@valor", IdPedido);

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


        //2:
        public DataTable BD_Buscar_Pedidos_porFecha(string tipo, DateTime xfecha)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Pedidos_porFecha", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@tipo", tipo);
                da.SelectCommand.Parameters.AddWithValue("@fecha", xfecha);

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


        //3:
        public DataTable BD_Buscar_Pedidos_porAtender()
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Leer_Pedidos_PorAtender", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@tipo", tipo);
                //da.SelectCommand.Parameters.AddWithValue("@fecha", xfecha);

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

        public bool BD_Verificar_siProducto_tieneVenta(string idprod, DateTime fecha)
        {
            bool respuesta = false;
            Int32 cant_registros = 0;

            SqlConnection cn = new SqlConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cn.ConnectionString = Conectar();
                cmd.CommandText = "Sp_Verificar_siProducto_TieneVenta";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idprod", idprod);
                cmd.Parameters.AddWithValue("@fecha", fecha);

                cn.Open();
                cant_registros = Convert.ToInt32(cmd.ExecuteScalar());

                if (cant_registros > 0)
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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                respuesta = false;
            }

            return respuesta;
        }

    }
}
