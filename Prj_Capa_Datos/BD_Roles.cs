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
    public class BD_Roles : BD_Conexion
    {

        public void BD_Registrar_Roles(string nomRol)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Insert_Rol", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;    //Para trabajar con StoreProcedure  
               // cmd.Parameters.AddWithValue("@Id_rol", idRol);
                cmd.Parameters.AddWithValue("@NomRol", nomRol);

                cn.Open();
                cmd.ExecuteNonQuery(); //se coloca esta funcion para que se ejecuten las cadenas de conexion, lineas arriba.
                cn.Close();
                MessageBox.Show("Registro Exitoso!");

            }
            catch (Exception ex)
            {
                //para validar si hay algun error en las cadenas de conexion. consulta.
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Rol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void BD_Editar_Roles(int idRol, string nomRol)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Editar_Distrito", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_rol", idRol);
                cmd.Parameters.AddWithValue("@NomRol", nomRol);

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


        public DataTable BD_Mostrar_Roles()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("SP_Listar_Roles", cn);
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
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Roles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null; //en caso no se cumpla la condicion.
        }



    }

}
