using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Prj_Capa_Entidad;

namespace Prj_Capa_Datos
{
    public class BD_Documento : BD_Conexion
    {
        public static bool seedito = false;

        public bool BD_Verificar_NroDocumento(string nroDoc)
        {
            bool respuesta = false;

            Int32 getvalue = 0;
            SqlConnection cn = new SqlConnection();

            try
            {


                SqlCommand cmd = new SqlCommand();

                cn.ConnectionString = Conectar();

                cmd.CommandText = "Sp_Validar_Id_Doc";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //parametros:
                cmd.Parameters.AddWithValue("@Id_Doc", nroDoc);

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

                respuesta = false; // se puede cambiar deacuerdo al video.
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //return false; //respuesta =false; se hizo cambio linea abajo
                respuesta = false;

            }

            return respuesta;

        }


        public static bool seguardo = false;


        //GUARDAR:

        public void BD_Registrar_Nuevo_Documento(EN_Documento doc)

        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Insert_Documento", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Parameters.AddWithValue("@id_Doc", doc.IdDoc);
                cmd.Parameters.AddWithValue("@id_Ped", doc.IdPed);
                cmd.Parameters.AddWithValue("@Id_Tipo", doc.IdTipo);
                cmd.Parameters.AddWithValue("@Fecha_Emi", doc.Fecha_DocEmi);
                cmd.Parameters.AddWithValue("@Importe", doc.Importe);
                cmd.Parameters.AddWithValue("@Efectivo", doc.Efectivo);
                //cmd.Parameters.AddWithValue("@Efec2", doc.Efec2);
                cmd.Parameters.AddWithValue("@Vuelto", doc.Vuelto);
                cmd.Parameters.AddWithValue("@TipoPago", doc.TipoPago);
                //cmd.Parameters.AddWithValue("@TipoPago2", doc.TipoPago2);
                cmd.Parameters.AddWithValue("@NroOpera", doc.Nr_Operacion);
                cmd.Parameters.AddWithValue("@id_Usu", doc.IdUsu);
                cmd.Parameters.AddWithValue("@Igv", doc.Igv);
                cmd.Parameters.AddWithValue("@son", doc.SonLetra);
                cmd.Parameters.AddWithValue("@TotalGanancia", doc.TotalGanancia);
                cmd.Parameters.AddWithValue("@CdrSunat", doc.CdrSunat);
                cmd.Parameters.AddWithValue("@Hash_CPE", doc.Hash_CPE);
                cmd.Parameters.AddWithValue("@EstadoBaja", doc.EstadoBaja);
                cmd.Parameters.AddWithValue("@NroTicket_baja", doc.NroTicket_baja);
                cmd.Parameters.AddWithValue("@Hash_cpeBaja", doc.Hash_cpeBaja);
                //cmd.Parameters.AddWithValue("@Id_Canal", doc.IdCanal);



                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seguardo = true;


            }
            catch (Exception ex)
            {
                seguardo = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }


        public void BD_Actualizar_Totales_Documento(string idDoc, double importe, double igv, string sonletra)

        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Actualizar_documento", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Doc", idDoc);
                cmd.Parameters.AddWithValue("@importe", importe);
                cmd.Parameters.AddWithValue("@Igv", igv);
                cmd.Parameters.AddWithValue("@son", sonletra);
               

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seguardo = true;


            }
            catch (Exception ex)
            {
                seguardo = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }

        //consulta:

        public DataTable BD_Buscador_Documentos_porValor(string valor)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_Documentos_xValor", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Xvalor", valor);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        //por fechas 

        public DataTable BD_Buscador_Documentos_porDia(DateTime diax)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Doc_emitoshoy", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@FechaActual", diax);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        //por mes

        public DataTable BD_Buscador_Documentos_porMes(DateTime mesx)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Leer_Fcturas_Emtidas_EnunMes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Fecha_Mes", mesx);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        //por mes y tipo de documento:  //para reportes
        public DataTable BD_Buscador_Documentos_porMes_TipoDocumento(DateTime mesx, int idTipoDoc)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Leer_Comprobantes_Emtidas_EnunMes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Fecha_Mes", mesx);
                da.SelectCommand.Parameters.AddWithValue("@Docu", idTipoDoc);
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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        //buscador con detalle:

        public DataTable BD_Buscador_DocumentoDetalle_porID(string IdDoc)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Documento_yDetalle", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Nro_Doc", IdDoc);
                
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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

      

        //anular:
        public void BD_Anular_Documento(string idDoc, string estadoDoc)

        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Anular_Documento", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Doc", idDoc);
                cmd.Parameters.AddWithValue("@estado", estadoDoc);
             


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seguardo = true;


            }
            catch (Exception ex)
            {
                seguardo = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }

        //Cambiar tipo de Doc:

        public void BD_Cambiar_TipoPago(string idDoc, string tipoPago)

        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Cambiar_TipoPago_Documento", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Doc", idDoc);
                cmd.Parameters.AddWithValue("@tipoPago", tipoPago);



                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seguardo = true;


            }
            catch (Exception ex)
            {
                seguardo = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }



        //Listar documentos 
        //nuevo store, para crear por fechas y ordenarlos
        public DataTable BD_Listar_Todos_Documentos()
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_listar_todos_Docs", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@Nro_Doc", IdDoc);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        //se agrego buscar detalle de venta explorador : 02/08/2022

        public DataTable BD_buscar_DocumentosVtas_Detalle(string id_Doc)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Documento_yDetalle", cn);
               
                
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Nro_Doc", id_Doc);
                //da.SelectCommand.Parameters.AddWithValue("@fecha", fechames);


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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }


        //nuevo para buscar doc por fechas inicio - fin  

        public DataTable BD_Buscador_Fechas(DateTime mesx, DateTime mesxx)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("SP_Demo_Fechas_DocumxMes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Inicial", mesx);
                da.SelectCommand.Parameters.AddWithValue("@Final", mesxx);
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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }


        //FE:
        public void BD_CambiarEstado_CdrSunat(string idDoc, string cdrSunat, string hascpe)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Cambiar_Estado_RespuestaSunat", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iddoc", idDoc);
                cmd.Parameters.AddWithValue("@estadoCdr", cdrSunat);
                cmd.Parameters.AddWithValue("@hash_cpe", hascpe);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                seguardo = true;

            }
            catch (Exception ex)
            {

                seguardo = false;
                if(cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //RESUMEN DE BOLETAS:


        public DataTable BD_Leer_Docs_delDia_PorTipoDoc(DateTime xdia, int idtipo)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Leer_Docs_delDia_PorTipoDoc", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Fecha_Mes", xdia);
                da.SelectCommand.Parameters.AddWithValue("@Docu", idtipo);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        //
        //METODO BOOLEANO:

        public bool BD_Verificar_FechaFE_enResumen(DateTime fechaElegida, DateTime fechaDoc)
        {
            bool respuesta = false;
            Int32 getvalue = 0;
            SqlConnection cn = new SqlConnection();

            try
            {


                SqlCommand cmd = new SqlCommand();

                cn.ConnectionString = Conectar();

                cmd.CommandText = "Sp_validar_fechaDoc_enResumenBoleta";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //parametros:
                cmd.Parameters.AddWithValue("@FechaElegida", fechaElegida);
                cmd.Parameters.AddWithValue("@Fecha_Doc", fechaDoc);

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

                respuesta = false; // se puede cambiar deacuerdo al video.
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //return false; //respuesta =false; se hizo cambio linea abajo
                respuesta = false;

            }

            return respuesta;

        }

        public void BD_Actualizar_Documento_CDR_SunatBajas(string idDoc, string estadobaja, string nroticket, string hash_cpebaja )

        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Actualizar_BajasdeSunat ", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NroDoc", idDoc);
                cmd.Parameters.AddWithValue("@EstadoBaja", estadobaja);
                cmd.Parameters.AddWithValue("@NroticketSunat", nroticket);
                cmd.Parameters.AddWithValue("@Hash_CpeBaja", hash_cpebaja);


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seguardo = true;


            }
            catch (Exception ex)
            {
                seguardo = false;
                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }


        public DataTable BD_Ventas_por_RagoFechas(DateTime diax, DateTime diax2)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_report_ventas1", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fecha", diax);
                da.SelectCommand.Parameters.AddWithValue("@fecha2", diax2);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        //FECHA POR  USUARIO - PARA REPORTE CAJA SEC
        public DataTable BD_Ventas_FecUsuario(DateTime diax, DateTime diax2, int user)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_reporteVentas_xUsuario", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fecha", diax);
                da.SelectCommand.Parameters.AddWithValue("@fecha2", diax2);
                da.SelectCommand.Parameters.AddWithValue("@user", user);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;


        }

        //buscar:
        public DataTable BD_Buscar_Creditos(string valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_creditos", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@nomcliente", valor);
                DataTable data = new DataTable();

                da.Fill(data);
                da = null;
                return data;
            }
            catch (Exception ex)
            {

                if (cn.State == ConnectionState.Open)
                {

                    cn.Close();
                }
                MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }


        }

        public void BD_Restar_Credito(string idprod, double stock)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Restar_Credito", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idprod);
                cmd.Parameters.AddWithValue("@stock", stock);


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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }




    }


}
