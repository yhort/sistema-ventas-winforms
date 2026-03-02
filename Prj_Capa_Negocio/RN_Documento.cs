using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;

namespace Prj_Capa_Negocio
{
    public class RN_Documento
    {

        public bool RN_Verificar_NroDocumento(string nroDoc)
        {
            BD_Documento obj = new BD_Documento();
             return obj.BD_Verificar_NroDocumento(nroDoc);
        }

        public void RN_Registrar_Nuevo_Documento(EN_Documento doc)
        {
            BD_Documento obj = new BD_Documento();
            obj.BD_Registrar_Nuevo_Documento(doc);
        }

        public void RN_Actualizar_Totales_Documento(string idDoc, double importe, double igv, string sonletra)
        {
            BD_Documento obj = new BD_Documento();
            obj.BD_Actualizar_Totales_Documento(idDoc, importe, igv, sonletra);
        }

        public DataTable RN_Buscador_Documentos_porValor(string valor)
        {
            BD_Documento obj = new BD_Documento();
            return obj.BD_Buscador_Documentos_porValor(valor);
        }

        public DataTable RN_Buscador_Documentos_porDia(DateTime diax)
        {
            BD_Documento obj = new BD_Documento();
            return obj.BD_Buscador_Documentos_porDia(diax);
        }

        public DataTable RN_Buscador_Documentos_porMes(DateTime mesx)
        {
            BD_Documento obj = new BD_Documento();
            return obj.BD_Buscador_Documentos_porMes(mesx);
        }

        public DataTable RN_Buscador_Documentos_porMes_TipoDocumento(DateTime mesx, int idTipoDoc)
        {
            BD_Documento obj = new BD_Documento();
            return obj.BD_Buscador_Documentos_porMes_TipoDocumento(mesx, idTipoDoc);
        }

        public DataTable RN_Buscador_DocumentoDetalle_porID(string IdDoc)
        {
            BD_Documento obj = new BD_Documento();
            return obj.BD_Buscador_DocumentoDetalle_porID(IdDoc);
        }

        public void RN_Anular_Documento(string idDoc, string estadoDoc)
        {
            BD_Documento obj = new BD_Documento();
            obj.BD_Anular_Documento(idDoc, estadoDoc);
        }

        public void RN_Cambiar_TipoPago(string idDoc, string tipoPago)
        {
            BD_Documento obj = new BD_Documento();
            obj.BD_Cambiar_TipoPago(idDoc, tipoPago);
        }

        public DataTable RN_Listar_Todos_Documentos()
        {
            BD_Documento obj = new BD_Documento();
            return obj.BD_Listar_Todos_Documentos();
        }


        public DataTable RN_buscar_DocumentosVtas_Detalle(string id_Doc)
        {
            BD_Documento obj = new BD_Documento();
            return obj.BD_buscar_DocumentosVtas_Detalle(id_Doc);
        }

        public DataTable RN_Buscador_Fechas(DateTime mesx, DateTime mesxx)
        {
            BD_Documento obj = new BD_Documento();
            return obj.BD_Buscador_Fechas(mesx, mesxx);
        }

        public void RN_CambiarEstado_CdrSunat(string idDoc, string cdrSunat, string hascpe)
        {
            BD_Documento obj = new BD_Documento();
            obj.BD_CambiarEstado_CdrSunat(idDoc, cdrSunat, hascpe);
        }

        public DataTable RN_Leer_Docs_delDia_PorTipoDoc(DateTime xdia, int idtipo)
        {
            BD_Documento obj = new BD_Documento();
            return obj.BD_Leer_Docs_delDia_PorTipoDoc(xdia, idtipo);
        }

        public bool RN_Verificar_FechaFE_enResumen(DateTime fechaElegida, DateTime fechaDoc)
        {
            BD_Documento obj = new BD_Documento();
            return obj.BD_Verificar_FechaFE_enResumen(fechaElegida, fechaDoc);
        }

        public void RN_Actualizar_Documento_CDR_SunatBajas(string idDoc, string estadobaja, string nroticket, string hash_cpebaja)
        {
            BD_Documento obj = new BD_Documento();
            obj.BD_Actualizar_Documento_CDR_SunatBajas(idDoc, estadobaja, nroticket, hash_cpebaja);
        }


        public DataTable RN_Ventas_por_RagoFechas(DateTime diax, DateTime diax2)
        {
            BD_Documento obj = new BD_Documento();
            return obj.BD_Ventas_por_RagoFechas(diax, diax2);
        }

        public DataTable RN_Ventas_FecUsuario(DateTime diax, DateTime diax2, int user)
        {
            BD_Documento obj = new BD_Documento();
            return obj.BD_Ventas_FecUsuario(diax, diax2, user);
        }

        public DataTable RN_Buscar_Creditos(string valor)
        {
            BD_Documento obj = new BD_Documento();
            return obj.BD_Buscar_Creditos(valor);

        }

        public void RN_Restar_Credito(string idprod, double stock)
        {
            BD_Documento obj = new BD_Documento();
            obj.BD_Restar_Credito(idprod, stock);
        }

        // En la clase RN_Documento
        //public DataTable RN_Buscador_DocumentoCabecera_porID(string IdDoc)
        //{
        //    // Llama al método de detalle de la Capa de Datos (BD), 
        //    // que ya ejecuta el SP 'Sp_Buscar_Documento_yDetalle' y trae los datos del cliente.
        //    BD_Documento obj = new BD_Documento();
        //    DataTable dtCompleto = obj.BD_Buscador_DocumentoDetalle_porID(IdDoc);

        //    // Procesamos el DataTable para aislar solo la cabecera.
        //    if (dtCompleto != null && dtCompleto.Rows.Count > 0)
        //    {
        //        // Creamos un DataTable ligero para el RUC/DNI y Nombre.
        //        DataTable dtCabecera = new DataTable();

        //        // Las columnas de retorno para el formulario:
        //        dtCabecera.Columns.Add("RUC");
        //        dtCabecera.Columns.Add("Nombre_Cliente");

        //        // Tomamos la primera fila, donde están los datos de cabecera (repetidos).
        //        DataRow primeraFila = dtCompleto.Rows[0];

        //        // Mapeo y llenado de la nueva fila.
        //        DataRow newRow = dtCabecera.NewRow();

        //        // Mapeo: 
        //        // Columna 'DNI' de la vista (que usas como identificador) -> Columna 'RUC' para el formulario
        //        // Columna 'Razon_Social_Nombres' de la vista -> Columna 'Nombre_Cliente'
        //        newRow["RUC"] = primeraFila["DNI"].ToString();
        //        newRow["Nombre_Cliente"] = primeraFila["Razon_Social_Nombres"].ToString();

        //        dtCabecera.Rows.Add(newRow);
        //        return dtCabecera;
        //    }

        //    // Si no se encontró el documento, devolvemos null o un DataTable vacío.
        //    return null;
        //}
    }
}
