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
    public class BD_Usuario : BD_Conexion
    {
        public bool BD_Login(string usu, string clave)
        {
            bool respuesta = false;
            Int32 getvalue = 0;
            SqlConnection cn = new SqlConnection();

            try
            {
                SqlCommand cmd = new SqlCommand();

                cn.ConnectionString = Conectar();

                cmd.CommandText = "Sp_Login";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //parametros:
                cmd.Parameters.AddWithValue("@Usuario", usu);
                cmd.Parameters.AddWithValue("@Contraseña", clave);

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


        public DataTable BD_Buscar_Usuario(string nomusu)
        {
            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Usuario_Login", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Usuario", nomusu);
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
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }


        }

        public static bool saved = false;

        //insertar;
        public void BD_insertar_Usuario(EN_Usuario us)
        {


            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Insert_Usuarios", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombres", us.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", us.Apellidos);
                cmd.Parameters.AddWithValue("@Id_Dis", us.IdDis);
                cmd.Parameters.AddWithValue("@Usuario", us.Usuario);
                cmd.Parameters.AddWithValue("@Contraseña", us.Password);
                cmd.Parameters.AddWithValue("@Ubicacion_Foto", us.Foto);
                cmd.Parameters.AddWithValue("@Fecha_Ncmiento", us.FechaNac);
                cmd.Parameters.AddWithValue("@Id_Rol", us.IdRol);
                cmd.Parameters.AddWithValue("@Correo", us.Correo);
                cmd.Parameters.AddWithValue("@Estado_Usu", us.Estado);
                cmd.Parameters.AddWithValue("@idempresa", us.IdEmpresa);



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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }

        public static bool edited = false;

        //editar

        public void BD_Editar_Usuario(EN_Usuario use)
        {

            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Editar_Usuario", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Usu",use.IdUser);
                cmd.Parameters.AddWithValue("Nombres ", use.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", use.Apellidos);
                cmd.Parameters.AddWithValue("@Id_Dis", use.IdDis);
                cmd.Parameters.AddWithValue("@Usuario", use.Usuario);
                cmd.Parameters.AddWithValue("@Contraseña", use.Password);
                cmd.Parameters.AddWithValue("@Ubicacion_Foto", use.Foto);
                cmd.Parameters.AddWithValue("@Fecha_Ncmiento", use.FechaNac);
                cmd.Parameters.AddWithValue("@Id_Rol", use.IdRol);
                cmd.Parameters.AddWithValue("@Correo", use.Correo);
                cmd.Parameters.AddWithValue("@Estado_Usu", use.Estado);
                cmd.Parameters.AddWithValue("@idempresa", use.IdEmpresa);



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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Usuario ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }

        public DataTable BD_Buscar_UsuarioxEstado(string valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Usuario", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@estado", valor);
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
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null; //en caso no se cumpla la condicion.
        }

        public DataTable BD_buscar_usuarioNombre(string valor, string estado)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Usuario_porValor", cn);
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

        public DataTable BD_Listar_Todos_Usuarios(int idEmpresa)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Todos_Usuario", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idEmpresa", idEmpresa);
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
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        //public DataTable BD_Listar_Todos_Usuarios_porEmpresa(int idEmpresa)
        //{

        //    SqlConnection cn = new SqlConnection();
        //    try
        //    {
        //        cn.ConnectionString = Conectar();
        //        SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Todos_Usuarios_xEmpresa", cn);
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        da.SelectCommand.Parameters.AddWithValue("@idempresa", idEmpresa);
        //        //da.SelectCommand.Parameters.AddWithValue("@idEmpresa", idempresa);
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
        //        MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //    return null;


        //}


        public DataTable BD_Buscar_Usuario_xIds(int idusu, int idempresa)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Buscar_Usuario", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idusu", idusu);
                da.SelectCommand.Parameters.AddWithValue("@idEmpresa", idempresa);
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
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        public void BD_Eliminar_Usuario(int  idusu)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Eliminar_Usuario", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusu", idusu);
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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }



        //public static List<Menu>ObtenerPermisos(int P_idusuario)
        //{
        //    List<Menu> Permisos = new List<Menu>();
        //    SqlConnection cn = new SqlConnection();
        //    try
        //    {
        //        cn.ConnectionString = Conectar2();
        //        SqlCommand cmd = new SqlCommand("usp_ObtenerPermisos", cn);

        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@IdUsuario", P_idusuario);


        //        cn.Open();

        //        cn.Close();


        //    }
        //    catch (Exception ex)
        //    {

        //        Permisos = new List<Menu>();
        //    }

        //    return Permisos;
        //}
    }
}
