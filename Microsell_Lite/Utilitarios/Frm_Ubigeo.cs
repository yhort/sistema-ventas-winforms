using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prj_Capa_Negocio;
using Prj_Capa_Datos;
using System.Data;

namespace Microsell_Lite.Utilitarios
{
    public partial class Frm_Ubigeo : Form
    {
        public Frm_Ubigeo()
        {
            InitializeComponent();
            //bdUbigeo = new BD_Ubigeo();
        }

        private void Frm_Ubigeo_Load(object sender, EventArgs e)
        {
            LoadDepartamentos();
        }


        private void LoadDepartamentos()
        {
            //RN_Ubigeo obj = new RN_Ubigeo();
            BD_Ubigeo obj = new BD_Ubigeo();
            DataTable dato = new DataTable();


            dato  = obj.BD_Listar_Ubigeos();

            var departamentos = dato.DefaultView.ToTable(true, "Departamento");
            cboDepartamento.DisplayMember = "Departamento";
            cboDepartamento.ValueMember = "Departamento";
            cboDepartamento.DataSource = departamentos;
        }

        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProvincias(cboDepartamento.SelectedValue.ToString());
        }


        private void LoadProvincias(string departamento)
        {
            //RN_Ubigeo obj = new RN_Ubigeo();
            BD_Ubigeo obj = new BD_Ubigeo();
            DataTable dato = new DataTable();
            dato = obj.BD_Listar_Ubigeos();
            var provincias = dato.Select($"Departamento = '{departamento}'").CopyToDataTable().DefaultView.ToTable(true, "Provincia");
            cboProvincia.DisplayMember = "Provincia";
            cboProvincia.ValueMember = "Provincia";
            cboProvincia.DataSource = provincias;
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDistritos(cboDepartamento.SelectedValue.ToString(), cboProvincia.SelectedValue.ToString());
        }

        private void LoadDistritos(string departamento, string provincia)
        {
            //RN_Ubigeo obj = new RN_Ubigeo();
            BD_Ubigeo obj = new BD_Ubigeo();
            DataTable dato = new DataTable();
            dato = obj.BD_Listar_Ubigeos();

            var distritos = dato.Select($"Departamento = '{departamento}' AND Provincia = '{provincia}'").CopyToDataTable();
            cboDistrito.DisplayMember = "Distrito";
            cboDistrito.ValueMember = "Ubigeo";
            cboDistrito.DataSource = distritos;
        }

        private void cboDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDistrito.SelectedValue != null)
            {
                txtUbigeo.Text = cboDistrito.SelectedValue.ToString();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            LoadDepartamentos();
        }
    }
}
