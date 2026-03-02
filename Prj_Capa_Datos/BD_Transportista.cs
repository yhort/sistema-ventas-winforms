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
    public class BD_Transportista : BD_Conexion
    {
        public static bool saved = false;
        public static bool seedito = false;
        public void BD_Insertar_Transportista(EN_Transportista tr)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Transportista", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Transportista", tr.IdTransportista);
                cmd.Parameters.AddWithValue("@Razon_Social ", tr.RazonSocialNombres);
                cmd.Parameters.AddWithValue("@RUC", tr.Ruc);
                cmd.Parameters.AddWithValue("@Direccion", tr.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", tr.Telefono);
                cmd.Parameters.AddWithValue("@E_Mail", tr.Email);
                cmd.Parameters.AddWithValue("@Nro_Licencia_Transporte", tr.NroLicTransporte);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Transportista", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void BD_Editar_Transportista(EN_Transportista tr)
        {
            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Editar_Transportista", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Transportista", tr.IdTransportista);
                cmd.Parameters.AddWithValue("@Razon_Social", tr.RazonSocialNombres);
                cmd.Parameters.AddWithValue("@RUC", tr.Ruc);
                cmd.Parameters.AddWithValue("@Direccion", tr.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", tr.Telefono);
                cmd.Parameters.AddWithValue("@E_Mail", tr.Email);
                cmd.Parameters.AddWithValue("@Nro_Licencia_Transporte", tr.NroLicTransporte);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seedito = true;

            }
            catch (Exception ex)
            {
                seedito = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Transportista", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        public DataTable BD_Mostrar_Transportista()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Transportistas", cn);
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
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Transportista", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null; //en caso no se cumpla la condicion.
        }
    }
}
