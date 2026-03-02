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
    public class BD_Vehiculo : BD_Conexion
    {

        public void BD_Registrar_Vehiculo(EN_Vehiculo veh)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Insert_vehiculos", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;    //Para trabajar con StoreProcedure  
                cmd.Parameters.AddWithValue("@veh_modelo", veh.Vehmodelo);
                cmd.Parameters.AddWithValue("@veh_placa", veh.Vehplaca);
                cmd.Parameters.AddWithValue("@veh_fechacreac", veh.Vehfechacre);
                cmd.Parameters.AddWithValue("@veh_marca", veh.Vehmarca);

                cmd.Parameters.AddWithValue("@veh_TUC", veh.VehTuc);
                cmd.Parameters.AddWithValue("@veh_MtcPrincipal", veh.Veh_mtc_principal);
                cmd.Parameters.AddWithValue("@veh_placaSec", veh.Veh_placa_secund); //
                cmd.Parameters.AddWithValue("@veh_TUC_Secun", veh.Veh_tuc_secund);
                cmd.Parameters.AddWithValue("@veh_MtcSecund", veh.Veh_mtc_principal);

                cn.Open();
                cmd.ExecuteNonQuery(); //se coloca esta funcion para que se ejecuten las cadenas de conexion, lineas arriba.
                cn.Close();
                //MessageBox.Show("El vehiculo se ha Registrado Exitosamente!");

            }
            catch (Exception ex)
            {
                //para validar si hay algun error en las cadenas de conexion. consulta.
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Vehiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        public DataTable BD_Mostrar_Todos_Vehiculo()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Todos_vehiculos", cn);
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
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Vehiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null; //en caso no se cumpla la condicion.
        }



        public DataTable BD_Cargar_Vehiculo_xEstado(string valor, string estado)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Vehiculos_porEstado", cn);
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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Vehiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;

        }

        public static bool edited = false;
        public void BD_Editar_Vehiculo(EN_Vehiculo vehed)
        {

            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Editar_vehiculo", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_veh", vehed.Idveh);
                cmd.Parameters.AddWithValue("@veh_modelo", vehed.Vehmodelo);
                cmd.Parameters.AddWithValue("@veh_placa", vehed.Vehplaca);                
                cmd.Parameters.AddWithValue("@veh_marca", vehed.Vehmarca);
                cmd.Parameters.AddWithValue("@veh_tuc", vehed.VehTuc);
                cmd.Parameters.AddWithValue("@veh_mtcpr", vehed.Veh_mtc_principal);
                cmd.Parameters.AddWithValue("@veh_placasec", vehed.Veh_placa_secund);
                cmd.Parameters.AddWithValue("@veh_tucSec", vehed.Veh_tuc_secund);
                cmd.Parameters.AddWithValue("@veh_mtcSec", vehed.Veh_mtc_secund);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos vehiculo ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }
        public static bool saved = false;
        public void BD_Eliminar_Vehiculo(int idve)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Eliminar_vehiculo", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idve", idve);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Vehiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

    }
}
