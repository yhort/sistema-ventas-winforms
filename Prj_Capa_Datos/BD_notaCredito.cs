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
  public   class BD_notaCredito : BD_Conexion 
    {
        public static bool notacre_guardado = false;
        public static bool Deta_NotaCreguardado = false;
        

        public void BD_Agregar_NotaCredito(EN_notacredito ObjPed)
        {
            SqlConnection Cn = new SqlConnection(Conectar());
            SqlCommand Cmd = new SqlCommand("Sp_Insert_NotaCredito", Cn);
            try
            {
                Cmd.CommandTimeout = 20;
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@Id_cre", ObjPed.idcre);
                Cmd.Parameters.AddWithValue("@Id_Doc", ObjPed.nrodoc);
                // Cmd.Parameters.AddWithValue("@Ruc", ObjPed.Ruc)
                Cmd.Parameters.AddWithValue("@TipoComprabnte", ObjPed.TipoComprobnte);
                Cmd.Parameters.AddWithValue("@OtrosDatos", ObjPed.OtrosDatos);
                Cmd.Parameters.AddWithValue("@Fecha_Cred", ObjPed.Fechaemi);
                // Cmd.Parameters.AddWithValue("@Cliente", ObjPed.cliente)
                Cmd.Parameters.AddWithValue("@Total", ObjPed.total);
                Cmd.Parameters.AddWithValue("@IgvC", ObjPed.Igv);
                Cmd.Parameters.AddWithValue("@Subtotal", ObjPed.SubTotal);
                Cmd.Parameters.AddWithValue("@id_Usu", ObjPed.idusu);
                Cmd.Parameters.AddWithValue("@MotivoEmision", ObjPed.motivoEmisio);
                Cmd.Parameters.AddWithValue("@soncre", ObjPed.son);
                Cmd.Parameters.AddWithValue("@EstadoDinero", ObjPed.EstadoDinero);
                Cmd.Parameters.AddWithValue("@IdCliente", ObjPed.Id_Cliente);
                Cmd.Parameters.AddWithValue("@CdrSunat_NotaCre", ObjPed.CdrSunat);
                Cmd.Parameters.AddWithValue("@HashCpe_NotaCre", ObjPed.HasCpe);
                Cn.Open();
                Cmd.ExecuteNonQuery();
                Cn.Close();

                Cmd.Dispose();
                Cmd = null/* TODO Change to default(_) if this is not a reference type */;
                Cn = null/* TODO Change to default(_) if this is not a reference type */;
                notacre_guardado = true;
            }
            // MsgBox("La Nota de Credito" & "Nro: " & ObjPed.idcre & "se guardo con Exito", MsgBoxStyle.Information, "Aviso")
            catch (Exception ex)
            {
                notacre_guardado = false;
                if (Cn.State == ConnectionState.Open)
                    Cn.Close();
                Cmd.Dispose();
                Cmd = null/* TODO Change to default(_) if this is not a reference type */;
                MessageBox.Show("Error al Guardar: " + ex.Message, "Reg Nota de Credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Detalle:
        public void BD_Agregar_Items_Detalle_notacredito(EN_DetNotacredito  ObjDet)
        {
            SqlConnection Cn = new SqlConnection(Conectar());
            SqlCommand Cmd = new SqlCommand("Sp_Insert_Detalle_notacredito", Cn);
            try
            {
                Cmd.CommandTimeout = 20;
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@Id_cre", ObjDet.idcre);
                Cmd.Parameters.AddWithValue("@Id_Pro", ObjDet.idpro);
                Cmd.Parameters.AddWithValue("@Precio", ObjDet.PrecioUnit);
                Cmd.Parameters.AddWithValue("@Cantidad", ObjDet.Cantidadc);
                Cmd.Parameters.AddWithValue("@Importe", ObjDet.ImporteCre);
                Cmd.Parameters.AddWithValue("@TipoProdcto", ObjDet.TipoProdcto);
                Cmd.Parameters.AddWithValue("@DetalleNotaCredi", ObjDet.Detalle_Prodcto); //
                Cmd.Parameters.AddWithValue("@Tipo_Afectacion", ObjDet.tipoAfectacion);
                Cn.Open();
                Cmd.ExecuteNonQuery();
                Cn.Close();

                Cmd.Dispose();
                Cmd = null/* TODO Change to default(_) if this is not a reference type */;
                Cn = null/* TODO Change to default(_) if this is not a reference type */;
                Deta_NotaCreguardado = true;
            }
            catch (Exception ex)
            {
                Deta_NotaCreguardado = false;
                if (Cn.State == ConnectionState.Open)
                    Cn.Close();
                Cmd.Dispose();
                Cmd = null/* TODO Change to default(_) if this is not a reference type */;
                MessageBox.Show("Error al Guardar: " + ex.Message, "Reg Det Nota de Credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        public void BD_Actualizar_EstadoDinero_NC(string nroDoc_NC, string xstadodinero)
        {
            SqlConnection Cn = new SqlConnection(Conectar());
            SqlCommand Cmd = new SqlCommand("Sp_Actualizar_EstadoDinero_NC", Cn);
            try
            {
                Cmd.CommandTimeout = 20;
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@NroNotaCredi", nroDoc_NC);
                Cmd.Parameters.AddWithValue("@EstadoDinero", xstadodinero);

                Cn.Open();
                Cmd.ExecuteNonQuery();
                Cn.Close();

                Cmd.Dispose();
                Cmd = null/* TODO Change to default(_) if this is not a reference type */;
                Cn = null/* TODO Change to default(_) if this is not a reference type */;
                Deta_NotaCreguardado = true;
            }
            catch (Exception ex)
            {
                Deta_NotaCreguardado = false;
                if (Cn.State == ConnectionState.Open)
                    Cn.Close();
                Cmd.Dispose();
                Cmd = null/* TODO Change to default(_) if this is not a reference type */;
                MessageBox.Show("Error al Guardar: " + ex.Message, "Actualizar Estado Dinero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static bool CdrUpdated = false;

        public void BD_Actualizar_EstadoSunat_NC(string nroDoc_NC, string CdrSunat, string HashCpe)
        {
            SqlConnection Cn = new SqlConnection(Conectar());
            SqlCommand Cmd = new SqlCommand("Sp_ActualizarEstadoSunat_NotaCre", Cn);
            try
            {
                Cmd.CommandTimeout = 20;
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@IdNotaCre", nroDoc_NC);
                Cmd.Parameters.AddWithValue("@CdrSunat", CdrSunat);
                Cmd.Parameters.AddWithValue("@HashCpe", HashCpe);

                Cn.Open();
                Cmd.ExecuteNonQuery();
                Cn.Close();

                Cmd.Dispose();
                Cmd = null/* TODO Change to default(_) if this is not a reference type */;
                Cn = null/* TODO Change to default(_) if this is not a reference type */;
                CdrUpdated = true;
            }
            catch (Exception ex)
            {
                CdrUpdated = false;
                if (Cn.State == ConnectionState.Open)
                    Cn.Close();
                Cmd.Dispose();
                Cmd = null/* TODO Change to default(_) if this is not a reference type */;
                MessageBox.Show("Error al Guardar: " + ex.Message, "Actualizar estado N.C", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        public DataTable BD_Leer_Todas_notadecredito()
        {
            SqlConnection Cn = new SqlConnection();
            try
            {
                Cn.ConnectionString = Conectar();
                SqlDataAdapter Da = new SqlDataAdapter("SP_Cargar_Todas_Las_Notacredito", Cn);
                Da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable Datos = new DataTable();
                Da.Fill(Datos);
                Da = null/* TODO Change to default(_) if this is not a reference type */;
                return Datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Consultas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (Cn.State == ConnectionState.Open)
                    Cn.Close();
                Cn.Dispose();
                Cn = null/* TODO Change to default(_) if this is not a reference type */;
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }


        public DataTable BD_Leer_Todas_notadecredito_emitidosHOy()
        {
            SqlConnection Cn = new SqlConnection();
            try
            {
                Cn.ConnectionString = Conectar();
                SqlDataAdapter Da = new SqlDataAdapter("Sp_Listar_NotaCredito_EitidosHoy", Cn);
                Da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable Datos = new DataTable();
                Da.Fill(Datos);
                Da = null/* TODO Change to default(_) if this is not a reference type */;
                return Datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Consultas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (Cn.State == ConnectionState.Open)
                    Cn.Close();
                Cn.Dispose();
                Cn = null/* TODO Change to default(_) if this is not a reference type */;
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }


        public DataTable BD_Buscardor_Gneral_NotasCreditos(string xvalor)
        {
            SqlConnection Cn = new SqlConnection();
            try
            {
                Cn.ConnectionString = Conectar();  // ObtenerConexion();
                SqlDataAdapter Da = new SqlDataAdapter("SP_Buscador_Gneral_NotasCredito", Cn);
                Da.SelectCommand.CommandType = CommandType.StoredProcedure;
                Da.SelectCommand.Parameters.AddWithValue("@xValor", xvalor);

                DataTable Datos = new DataTable();
                Da.Fill(Datos);
                Da = null/* TODO Change to default(_) if this is not a reference type */;
                return Datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Consultas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (Cn.State == ConnectionState.Open)
                    Cn.Close();
                Cn.Dispose();
                Cn = null/* TODO Change to default(_) if this is not a reference type */;
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }



        public DataTable BD_Buscar_NotaCredito_Pormes(DateTime xvalor)
        {
            SqlConnection Cn = new SqlConnection();
            try
            {
                Cn.ConnectionString = Conectar(); // ObtenerConexion();
                SqlDataAdapter Da = new SqlDataAdapter("Sp_Listar_NotaCredito_delMes", Cn);
                Da.SelectCommand.CommandType = CommandType.StoredProcedure;
                Da.SelectCommand.Parameters.AddWithValue("@fecha", xvalor);

                DataTable Datos = new DataTable();
                Da.Fill(Datos);
                Da = null/* TODO Change to default(_) if this is not a reference type */;
                return Datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Consultas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (Cn.State == ConnectionState.Open)
                    Cn.Close();
                Cn.Dispose();
                Cn = null/* TODO Change to default(_) if this is not a reference type */;
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }

        //====================0
        // '4 cargar detalle de la nota de credito
        public DataTable BD_Cargar_NotaCredito_Detalle(string xvalor)
        {
            SqlConnection Cn = new SqlConnection();
            try
            {
                Cn.ConnectionString = Conectar(); // ObtenerConexion();
                SqlDataAdapter Da = new SqlDataAdapter("SP_Cargar_NotaCredito_Detalle", Cn);
                Da.SelectCommand.CommandType = CommandType.StoredProcedure;
                Da.SelectCommand.Parameters.AddWithValue("@nronotacred", xvalor);

                DataTable Datos = new DataTable();
                Da.Fill(Datos);
                Da = null/* TODO Change to default(_) if this is not a reference type */;
                return Datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Consultas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (Cn.State == ConnectionState.Open)
                    Cn.Close();
                Cn.Dispose();
                Cn = null/* TODO Change to default(_) if this is not a reference type */;
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }


        //verificar:        
        public bool BD_Verificar_SiFactura_Tiene_NotaCredito(string nroDoc)
        {
            bool respuesta = false;
            Int32 getvalue = 0;
            SqlConnection cn = new SqlConnection();

            try
            {

                SqlCommand cmd = new SqlCommand();

                cn.ConnectionString = Conectar();

                cmd.CommandText = "Sp_Validar_Factura_enNotaCredito";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //parametros:
                cmd.Parameters.AddWithValue("@nrFactu", nroDoc);

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
                respuesta = false;
            }

            return respuesta;

        }


        //nuevo:
        public bool BD_Verificar_SiNotaCredito_esParaPagos(string nroDoc)
        {
            bool respuesta = false;
            Int32 getvalue = 0;
            SqlConnection cn = new SqlConnection();

            try
            {

                SqlCommand cmd = new SqlCommand();

                cn.ConnectionString = Conectar();

                cmd.CommandText = "Sp_Verificar_NotaCredito_PendientePago";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //parametros:
                cmd.Parameters.AddWithValue("@Id_Cre", nroDoc);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos NotaCredito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                respuesta = false;
            }

            return respuesta;

        }

        public DataTable BD_Buscar_NotaCredito_PendientePago(string xvalor)
        {
            SqlConnection Cn = new SqlConnection();
            try
            {
                Cn.ConnectionString = Conectar(); // ObtenerConexion();
                SqlDataAdapter Da = new SqlDataAdapter("Sp_Buscar_NotaCredito_PendientePago", Cn);
                Da.SelectCommand.CommandType = CommandType.StoredProcedure;
                Da.SelectCommand.Parameters.AddWithValue("@Id_Cre", xvalor);

                DataTable Datos = new DataTable();
                Da.Fill(Datos);
                Da = null/* TODO Change to default(_) if this is not a reference type */;
                return Datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Consultas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (Cn.State == ConnectionState.Open)
                    Cn.Close();
                Cn.Dispose();
                Cn = null/* TODO Change to default(_) if this is not a reference type */;
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }

    }
}
