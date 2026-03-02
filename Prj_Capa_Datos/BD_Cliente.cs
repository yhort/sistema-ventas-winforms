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
    public class BD_Cliente : BD_Conexion
    {
        //validar:
        public bool BD_Verificar_NroDni(string NroDni)
        {
            bool respuesta = false;
            Int32 getvalue = 0;
            SqlConnection cn = new SqlConnection();

            try
            {

                SqlCommand cmd = new SqlCommand();

                cn.ConnectionString = Conectar();

                cmd.CommandText = "sp_Validar_NroDNI";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //parametros:
                cmd.Parameters.AddWithValue("@dni", NroDni);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;

            }

            return respuesta;

        }

        public static bool saved = false;

        //insertar;
        public void BD_insertar_Cliente(EN_Cliente cli)
        {


            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Cliente", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcliente", cli.Idcliente);
                cmd.Parameters.AddWithValue("@razonsocial ", cli.Razonsocial);
                cmd.Parameters.AddWithValue("@dni", cli.Dni);
                cmd.Parameters.AddWithValue("@direccion", cli.Direccion);
                cmd.Parameters.AddWithValue("@telefono", cli.Telefono);
                cmd.Parameters.AddWithValue("@email", cli.Email);
                cmd.Parameters.AddWithValue("@idDis", cli.IdDis);
                cmd.Parameters.AddWithValue("@fechaAniver", cli.FechaAniver);
                cmd.Parameters.AddWithValue("@contacto", cli.Contacto);
                cmd.Parameters.AddWithValue("@limiteCred", cli.LimiteCred);
                cmd.Parameters.AddWithValue("@IdTipo", cli.IdTipoDoc); //cod tip_docIdentidad 



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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }

        public static bool edited = false;

        //editar

        public void BD_Editar_Cliente(EN_Cliente cli)
        {


            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Modificar_Cliente", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcliente", cli.Idcliente);
                cmd.Parameters.AddWithValue("@razonsocial ", cli.Razonsocial);
                cmd.Parameters.AddWithValue("@dni", cli.Dni);
                cmd.Parameters.AddWithValue("@direccion", cli.Direccion);
                cmd.Parameters.AddWithValue("@telefono", cli.Telefono);
                cmd.Parameters.AddWithValue("@email", cli.Email);
                cmd.Parameters.AddWithValue("@idDis", cli.IdDis);
                cmd.Parameters.AddWithValue("@fechaAniver", cli.FechaAniver);
                cmd.Parameters.AddWithValue("@contacto", cli.Contacto);
                cmd.Parameters.AddWithValue("@limiteCred", cli.LimiteCred);
                cmd.Parameters.AddWithValue("@IdTipo", cli.IdTipoDoc);



                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                edited = true;



            }
            catch (Exception ex)
            {
                edited = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }

        public DataTable BD_Cargar_Todos_Cliente(string estado)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Todos_Clientes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@estado", estado);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        //para buscar por valor

        public DataTable BD_buscar_Cliente(string valor, string estado)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Cliente_porValor", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Valor", valor);
                da.SelectCommand.Parameters.AddWithValue("@estado", estado);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        //dar de baja 
        public static bool baja = false;

        public void BD_dardeBaja_Cliente(string idcliente)
        {


            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Modificar_Cliente", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcliente", idcliente);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                baja = true;



            }
            catch (Exception ex)
            {
                baja = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }

        //eliminar:

        public void BD_Eliminar_Cliente(string idcliente)
        {


            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Eliminar_Cliente", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcliente", idcliente);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                baja = true;



            }
            catch (Exception ex)
            {
                baja = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }

        //metodo para mostrar los cod_tipodocmuento Identidad
        public DataTable BD_Listar_CodTipoDocIdent()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_CodTipoDocIdent", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data = new DataTable();

                da.Fill(data);
                da = null;
                return data;
            }
            catch (Exception ex)
            {
                //para validar si hay algun error en las cadenas de conexion. consulta.
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null; //en caso no se cumpla la condicion.
        }

        public DataTable BD_Listar_Clientes()
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_cliente", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@id", id);
                //da.SelectCommand.Parameters.AddWithValue("@idEmpresa", idempresa);
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
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }


    }
}
