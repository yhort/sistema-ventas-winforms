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
   public class BD_Proveedor : BD_Conexion 
    {
        public static bool seguardoprov = false;
        public static bool seeditoprov = false;
        public void BD_Registrar_Proveedor(EN_Proveedor pro)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_registrar_Proveedor", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;    //Para trabajar con StoreProcedure  
                cmd.Parameters.AddWithValue("@idproveedor", pro.Idproveedor);
                cmd.Parameters.AddWithValue("@nombre", pro.Nombreproveedor);
                cmd.Parameters.AddWithValue("@direccion", pro.Direccion);
                cmd.Parameters.AddWithValue("@telefono", pro.Telefono);
                cmd.Parameters.AddWithValue("@rubro", pro.Rubro);
                cmd.Parameters.AddWithValue("@ruc", pro.Ruc);
                cmd.Parameters.AddWithValue("@correo", pro.Correo);
                cmd.Parameters.AddWithValue("@contacto", pro.Contacto);

                cmd.Parameters.AddWithValue("@fotologo", pro.Fotologo);

                cn.Open();
                cmd.ExecuteNonQuery(); //se coloca esta funcion para que se ejecuten las cadenas de conexion, lineas arriba.
                cn.Close();
                seguardoprov = true;
                //MessageBox.Show("El Proveedor se ha Registrado Exitosamente");

            }
            catch (Exception ex)
            {
                //para validar si hay algun error en las cadenas de conexion. consulta.
                seguardoprov=false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        public void BD_Editar_Proveedor(EN_Proveedor pro)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Modificar_Proveedor", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;    //Para trabajar con StoreProcedure  
                cmd.Parameters.AddWithValue("@idproveedor", pro.Idproveedor);
                cmd.Parameters.AddWithValue("@nombre", pro.Nombreproveedor);
                cmd.Parameters.AddWithValue("@direccion", pro.Direccion);
                cmd.Parameters.AddWithValue("@telefono", pro.Telefono);
                cmd.Parameters.AddWithValue("@rubro", pro.Rubro);
                cmd.Parameters.AddWithValue("@ruc", pro.Ruc);
                cmd.Parameters.AddWithValue("@correo", pro.Correo);
                cmd.Parameters.AddWithValue("@contacto", pro.Contacto);
                cmd.Parameters.AddWithValue("@fotologo", pro.Fotologo);

                cn.Open();
                cmd.ExecuteNonQuery(); //se coloca esta funcion para que se ejecuten las cadenas de conexion, lineas arriba.
                cn.Close();
                seeditoprov = true;
                //MessageBox.Show("El Proveedor se ha Editado Exitosamente");

            }
            catch (Exception ex)
            {
                //para validar si hay algun error en las cadenas de conexion. consulta.
                seeditoprov =false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        public DataTable BD_Mostrar_Todos_Proveedores()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Todos_Proveedores", cn);
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
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null; //en caso no se cumpla la condicion.
        }


        //Buscar por Valor:
        public DataTable BD_Buscar_Proveedores(string valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_buscar_proveedor_porvalor", cn);
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
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null; //en caso no se cumpla la condicion.
        }

        //validar ruc prove

        //validar:
        public bool BD_Verificar_NroRucProveedor(string NroRuc)
        {
            bool respuesta = false;
            Int32 getvalue = 0;
            SqlConnection cn = new SqlConnection();

            try
            {

                SqlCommand cmd = new SqlCommand();

                cn.ConnectionString = Conectar();

                cmd.CommandText = "sp_Validar_NroRucProve";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //parametros:
                cmd.Parameters.AddWithValue("@ruc", NroRuc);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;

            }

            return respuesta;

        }

    }
}
