using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prj_Capa_Entidad;

namespace Prj_Capa_Datos
{
    public class BD_Canal : BD_Conexion
    {
        public static bool saved = false;
        public static bool edited = false;

        public void BD_Registrar_Canal(EN_Canal cl)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_InsertarCanal", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;    //Para trabajar con StoreProcedure  
             
                cmd.Parameters.AddWithValue("@ClienteId", cl.ClienteId);
                cmd.Parameters.AddWithValue("@Nombre_Canal", cl.NombreCanal);
                cmd.Parameters.AddWithValue("@Estado_Canal", cl.Estado);

                cn.Open();
                cmd.ExecuteNonQuery(); //se coloca esta funcion para que se ejecuten las cadenas de conexion, lineas arriba.
                cn.Close();
                saved = true;
                //MessageBox.Show("El canal se ha Registrado Exitosamente");

            }
            catch (Exception ex)
            {
                saved = false;
                //para validar si hay algun error en las cadenas de conexion. consulta.
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Canal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //metodo para editar las Marcas:
        public void BD_Editar_Canal(EN_Canal cln)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Editar_Canal", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcanal", cln.IdCanal);
                cmd.Parameters.AddWithValue("@id_cliente", cln.ClienteId);
                cmd.Parameters.AddWithValue("@nombre_canal", cln.NombreCanal);
                cmd.Parameters.AddWithValue("@Estado_Canal", cln.Estado);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                edited = true;
                //MessageBox.Show("El canal se ha Editado Exitosamente");

            }
            catch (Exception ex)
            {
                edited = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Canal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //metodo para mostrar las categorias: metodo de tipo consulta
        public DataTable BD_Mostrar_Canales()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Canales", cn);
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
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Canales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null; //en caso no se cumpla la condicion.
        }


        public DataTable BD_Buscar_Canal(string valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_buscar_canal_porvalor", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@valor", valor);
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
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Canal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null; //en caso no se cumpla la condicion.
        }
    }
}
