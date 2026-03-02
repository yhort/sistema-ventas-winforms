using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using static Prj_Capa_Entidad.EN_Ubigeo;



namespace Prj_Capa_Negocio
{
    public class RN_Ubigeo
    {

        //public DataTable RN_Listar_Ubigeos()
        //{
        //    BD_Ubigeo obj = new BD_Ubigeo();
        //    return obj.BD_Listar_Ubigeos();
        //}

        //public List<UbigeoInfo> RN_Listar_Ubigeos()   // devuelve lista tipada
        //{
        //    var bd = new BD_Ubigeo();
        //    var dt = bd.BD_Listar_Ubigeos() ?? new DataTable();

        //    // Asegurar columnas esperadas
        //    if (!dt.Columns.Contains("Etiqueta"))
        //    {
        //        dt.Columns.Add("Etiqueta", typeof(string));
        //        foreach (DataRow r in dt.Rows)
        //        {
        //            var ub = r["Ubigeo"]?.ToString() ?? "";
        //            var dist = r["Distrito"]?.ToString() ?? "";
        //            var prov = r["Provincia"]?.ToString() ?? "";
        //            var dep = r["Departamento"]?.ToString() ?? "";
        //            r["Etiqueta"] = $"{ub} {dist} - {prov} - {dep}";
        //        }
        //    }

        //    var list = new List<UbigeoInfo>(dt.Rows.Count);
        //    foreach (DataRow r in dt.Rows)
        //    {
        //        list.Add(new UbigeoInfo
        //        {
        //            Ubigeo = r["Ubigeo"]?.ToString(),
        //            Distrito = r["Distrito"]?.ToString(),
        //            Provincia = r["Provincia"]?.ToString(),
        //            Departamento = r["Departamento"]?.ToString(),
        //            Etiqueta = r["Etiqueta"]?.ToString()
        //        });
        //    }
        //    return list;
        //}

        public List<UbigeoInfo> RN_Listar_Ubigeos()
        {
            var bd = new BD_Ubigeo();
            var dt = bd.BD_Listar_Ubigeos();              // nunca null por el cambio de arriba

            if (!dt.Columns.Contains("Etiqueta"))
                dt.Columns.Add("Etiqueta", typeof(string));

            foreach (DataRow r in dt.Rows)
            {
                // null-safe
                string ub = r["Ubigeo"]?.ToString() ?? "";
                string dist = r["Distrito"]?.ToString() ?? "";
                string prov = r["Provincia"]?.ToString() ?? "";
                string dep = r["Departamento"]?.ToString() ?? "";
                r["Etiqueta"] = $"{ub} {dist} - {prov} - {dep}";
            }

            var list = new List<UbigeoInfo>(dt.Rows.Count);
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new UbigeoInfo
                {
                    Ubigeo = r["Ubigeo"]?.ToString() ?? "",
                    Distrito = r["Distrito"]?.ToString() ?? "",
                    Provincia = r["Provincia"]?.ToString() ?? "",
                    Departamento = r["Departamento"]?.ToString() ?? "",
                    Etiqueta = r["Etiqueta"]?.ToString() ?? ""
                });
            }

            return list; // <- nunca null (si no hay filas, lista vacía)
        }
    }
}
