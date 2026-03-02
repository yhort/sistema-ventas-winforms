using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Prj_Capa_Datos
{
    public class BD_Marcas : BD_Conexion
    {

        public void BD_Registrar_Marcas(string nomMarca)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_addMarca", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;    //Para trabajar con StoreProcedure  
                cmd.Parameters.AddWithValue("@marca", nomMarca);

                cn.Open();
                cmd.ExecuteNonQuery(); //se coloca esta funcion para que se ejecuten las cadenas de conexion, lineas arriba.
                cn.Close();
                MessageBox.Show("La Marca se ha Registrado Exitosamente");

            }
            catch (Exception ex)
            {
                //para validar si hay algun error en las cadenas de conexion. consulta.
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Marcas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //metodo para editar las Marcas:
        public void BD_Editar_Marcas(int idmar, string nomMarca)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Editar_Marca", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;    
                cmd.Parameters.AddWithValue("@idmar", idmar);
                cmd.Parameters.AddWithValue("@nom_marca", nomMarca);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("La Marca se ha Editado Exitosamente");

            }
            catch (Exception ex)
            {
               
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Marcas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //metodo para mostrar las categorias: metodo de tipo consulta
        public DataTable BD_Mostrar_Todas_Marcas()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Todos_Marcas", cn);
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
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Marcas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null; //en caso no se cumpla la condicion.
        }



        //metodo para Eliminar las Marcas:
        public void BD_Eliminar_Marcas(int idmar)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_eliminar_Marca", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;   
                cmd.Parameters.AddWithValue("@idmar", idmar);
                

                cn.Open();
                cmd.ExecuteNonQuery(); 
                cn.Close();
                MessageBox.Show("La Marca se ha Eliminado Exitosamente");

            }
            catch (Exception ex)
            {
               
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Marcas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        public DataTable BD_Buscar_Marca(string valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_buscar_marca_porvalor", cn);
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
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Marca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null; //en caso no se cumpla la condicion.
        }


    }
}
