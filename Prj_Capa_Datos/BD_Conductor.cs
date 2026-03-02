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
    public class BD_Conductor : BD_Conexion
    {

        public static bool saved = false;
        public void BD_Registrar_Conductor(EN_Choferes con)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Insert_choferes", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;    //Para trabajar con StoreProcedure  
                cmd.Parameters.AddWithValue("@co_nombres", con.Co_nombres);
                cmd.Parameters.AddWithValue("@co_dni", con.Dni);
                cmd.Parameters.AddWithValue("@co_licencia", con.Licencia);
                cmd.Parameters.AddWithValue("@Id_Dis", con.IdDis);
                cmd.Parameters.AddWithValue("@co_direccion", con.Direccion);
                cmd.Parameters.AddWithValue("@cho_telf", con.Telef);
                cmd.Parameters.AddWithValue("@cho_fechacreac", con.Fechacrea);
                cmd.Parameters.AddWithValue("@cho_fechamodif", con.Fechamod);
                cmd.Parameters.AddWithValue("@cho_estado", con.Estado);
                cmd.Parameters.AddWithValue("@co_apellidos", con.Apellido);

                cn.Open();
                cmd.ExecuteNonQuery(); //se coloca esta funcion para que se ejecuten las cadenas de conexion, lineas arriba.
                cn.Close();
                saved = true;
                //MessageBox.Show("El Conductor se ha Registrado Exitosamente!");

            }
            catch (Exception ex)
            {
                saved =false;
                //para validar si hay algun error en las cadenas de conexion. consulta.
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Conductor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static bool edited = false;
        public void BD_Editar_Conductor(EN_Choferes ediCon)
        {

            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Editar_choferes", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Cond", ediCon.IdCond);
                cmd.Parameters.AddWithValue("@cho_nombres ", ediCon.Co_nombres);
                cmd.Parameters.AddWithValue("@cho_dni", ediCon.Dni);
                cmd.Parameters.AddWithValue("@cho_licencia", ediCon.Licencia);
                cmd.Parameters.AddWithValue("@cho_telf", ediCon.Telef);
                cmd.Parameters.AddWithValue("@cho_fechamodif", ediCon.Fechamod);
                cmd.Parameters.AddWithValue("@co_apellidos", ediCon.Apellido);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Conductor ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        public void BD_Eliminar_Conductor(int idcond)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Eliminar_Conductor", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcond", idcond);
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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Conductor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }


        public DataTable BD_Mostrar_Todos_Conductores()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Conductores", cn);
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
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Conductor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null; //en caso no se cumpla la condicion.
        }

        public DataTable BD_BuscarConductor(string valor, string estado)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_buscarConductor", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@valor", valor);
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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Conductor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;

        }

    }
}
