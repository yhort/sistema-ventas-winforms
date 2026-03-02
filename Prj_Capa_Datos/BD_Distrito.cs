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
    public class BD_Distrito : BD_Conexion
    {

        public void BD_Registrar_Distrito(string nomDist)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_addDistrito", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;    //Para trabajar con StoreProcedure  
                cmd.Parameters.AddWithValue("@distrito", nomDist);

                cn.Open();
                cmd.ExecuteNonQuery(); //se coloca esta funcion para que se ejecuten las cadenas de conexion, lineas arriba.
                cn.Close();
                MessageBox.Show("El distrito se ha Registrado Exitosamente");

            }
            catch (Exception ex)
            {
                //para validar si hay algun error en las cadenas de conexion. consulta.
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //metodo para editar los Distritos:
        public void BD_Editar_Distritos(int idDis, string nomDis)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Editar_Distrito", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDis", idDis);
                cmd.Parameters.AddWithValue("@nomdis", nomDis);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("El distrito se ha Editado Exitosamente");

            }
            catch (Exception ex)
            {

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        //metodo para mostrar los distritos: metodo de tipo consulta
        public DataTable BD_Mostrar_Todos_Distritos()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Todos_Distritos", cn);
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
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null; //en caso no se cumpla la condicion.
        }



        //metodo para Eliminar los Distritos:
        public void BD_Eliminar_Distrito(int idDis)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_eliminar_distrito", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDis", idDis);


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("El distrito se ha Eliminado Exitosamente");

            }
            catch (Exception ex)
            {

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        public DataTable BD_Buscar_Distrito(string valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_buscar_distrito_porvalor", cn);
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
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null; //en caso no se cumpla la condicion.
        }

    }
}
