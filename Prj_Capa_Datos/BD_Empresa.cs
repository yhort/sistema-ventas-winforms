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
    public class BD_Empresa : BD_Conexion
    {

        public static bool saved = false;

        public void BD_Editar_empresa(EN_Empresa con)
        {

            SqlConnection cn = new SqlConnection(Conectar());
            //cn.ConnectionString = Conectar();
            SqlCommand cmd = new SqlCommand("sp_editar_miempresa", cn);

            try
            {
               
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                //agregar los parametros
                cmd.Parameters.AddWithValue("@idempresa", con.Idempresa);
                cmd.Parameters.AddWithValue("@nombreEmpresa", con.Nombrempresa);
                cmd.Parameters.AddWithValue("@ruc", con.Nrouc);
                cmd.Parameters.AddWithValue("@direccion", con.Direccionempresa);
                cmd.Parameters.AddWithValue("@correo", con.Correo);
                cmd.Parameters.AddWithValue("@clave", con.Clavecorreo);
                cmd.Parameters.AddWithValue("@clavesol", con.Clavesol);
                cmd.Parameters.AddWithValue("@usuariosol", con.Usuariosol);
                cmd.Parameters.AddWithValue("@clavecertificado", con.Clavecertificado);
                cmd.Parameters.AddWithValue("@obs", con.Obs);


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
                MessageBox.Show("Algo malo pasó en Registro de Contrato: " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public DataTable BD_Buscar_Empresa_porId(int id)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_LeerMiempresa", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id", id);
                DataTable dato = new DataTable();

                da.Fill(dato);
                da = null;
                return dato;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                cn.Close();
                cn = null;
                MessageBox.Show("Algo malo pasó: " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw 
            }
            return null;
        }


        public void BD_Guardar_Token_Usuario(int usuarioID, string token, DateTime fechaObtencion, DateTime fechaExpiracion)
        {
            SqlConnection cn = new SqlConnection(Conectar());
            SqlCommand cmd = new SqlCommand("sp_guardar_token_usuario", cn);

            try
            {
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                // Agregar los parámetros
                cmd.Parameters.AddWithValue("@UsuarioID", usuarioID); // ID del usuario
                cmd.Parameters.AddWithValue("@Token", token); // Token
                cmd.Parameters.AddWithValue("@FechaObtencion", fechaObtencion); // Fecha de obtención
                cmd.Parameters.AddWithValue("@FechaExpiracion", fechaExpiracion); // Fecha de expiración

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
                MessageBox.Show("Error al guardar el token del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para obtener el token de un usuario específico desde la base de datos
        public EN_TokenInfo BD_Obtener_Token_Usuario(int usuarioID)
        {
            SqlConnection cn = new SqlConnection(Conectar());
            //SqlCommand cmd = new SqlCommand("SELECT TOP 1 token FROM Miempresa WHERE idempresa = @UsuarioID ORDER BY FechaObtencion DESC", cn);
            string query = "SELECT TOP 1 token, FechaObtencion FROM Miempresa WHERE idempresa = @idempresa ORDER BY FechaObtencion DESC";

            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.CommandTimeout = 20;
            cmd.CommandType = CommandType.Text; // Especificamos que es una consulta SQL, no un procedimiento almacenado

            // Agregar el parámetro necesario
            cmd.Parameters.AddWithValue("@idempresa", usuarioID);

            EN_TokenInfo tokenInfo = null;


            try
            {
                // Abrir la conexión
                cn.Open();

                // Ejecutar la consulta y obtener el lector de datos
                SqlDataReader reader = cmd.ExecuteReader();

                // Si hay resultados, procesarlos
                if (reader.HasRows)
                {
                    reader.Read(); // Leer la primera fila (solo seleccionamos TOP 1)
                    string token = reader["token"].ToString();
                    DateTime fechaObtencion = Convert.ToDateTime(reader["FechaObtencion"]);

                    // Crear un objeto EN_TokenInfo con los datos obtenidos
                    tokenInfo = new EN_TokenInfo
                    {
                        Token = token,
                        FechaObtencion = fechaObtencion
                    }; //almacenado para ese usuario
                }
                // Cerrar la conexión
                cn.Close();
            }
            catch (Exception ex)
            {
                // En caso de error, cerrar la conexión y mostrar el mensaje
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al obtener el token del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Retornar el objeto con el token y la fecha, o null si no se encontró
            return tokenInfo;
        }


        public int BD_Token_Es_Valido(int usuarioID)
        {
            SqlConnection cn = new SqlConnection(Conectar());
            SqlCommand cmd = new SqlCommand("sp_Validar_Token", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

            try
            {
                cn.Open();
                int resultado = (int)cmd.ExecuteScalar(); // Ejecuta el stored procedure y obtiene el resultado
                cn.Close();

                return resultado ; // Si el resultado es 1, el token es válido (en minutos)
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al verificar el token: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0; // Si ocurre un error, lo tratamos como inválido
            }
        }


        public void BD_Guardar_Cdr(int usuarioID, string nomArchivo, string cdrHash, DateTime fechaEnvio)
        {
            SqlConnection cn = new SqlConnection(Conectar());
            SqlCommand cmd = new SqlCommand("sp_guardar_cdr", cn);

            try
            {
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
                cmd.Parameters.AddWithValue("@NomArchivo", nomArchivo);
                cmd.Parameters.AddWithValue("@CdrHash", cdrHash);
                cmd.Parameters.AddWithValue("@FechaEnvio", fechaEnvio);

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
                MessageBox.Show("Error al guardar el CDR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }

}
