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
    public class BD_DireccionesCl  : BD_Conexion
    {


        public static bool saved = false;

        //insertar;
        public void BD_insertar_DireccionesCli(EN_DireccionesCl di)
        {


            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_InsertarDireccionCliente", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClienteId", di.ClienteId);
                cmd.Parameters.AddWithValue("@Direccion", di.Direccion);
                cmd.Parameters.AddWithValue("@Distrito", di.Distrito);
                cmd.Parameters.AddWithValue("@Cod_ubigeo", di.CodUbigeo);
                cmd.Parameters.AddWithValue("@Departamento", di.Departamento);
                cmd.Parameters.AddWithValue("@Provincia", di.Provincia);
                cmd.Parameters.AddWithValue("@Pais", di.Pais);


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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos DireccionesCl", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }

        public DataTable BD_ObtenerDireccionesPorCliente(string clienteId)
        {



            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_ObtenerDireccionesPorCliente", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@ClienteId", clienteId);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos direccionescl", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        //public DataTable BD_ObtenerDireccionesPorCliente(string clienteId)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(Conectar()))
        //        {
        //            using (SqlDataAdapter da = new SqlDataAdapter("sp_ObtenerDireccionesPorCliente", cn))
        //            {
        //                da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //                da.SelectCommand.Parameters.AddWithValue("@ClienteId", clienteId);

        //                DataTable dato = new DataTable();
        //                da.Fill(dato);
        //                return dato;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al Obtener Direcciones: " + ex.Message, "Capa Datos Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return null; // Retorna null si ocurrió un error
        //    }
        //}


        public DataTable BD_Cargar_DireccionesCl()
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_CargarDireccionClientes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure; 

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos DireccionesCl", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }


    }
}
