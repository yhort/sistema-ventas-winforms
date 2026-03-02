using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsell_Lite.Productos;
using Microsell_Lite.Ventas;
using Microsell_Lite.Cliente;
using Microsell_Lite.Compras;
using Microsell_Lite.Cotizacion;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Caja;
using Prj_Capa_Negocio;
using Microsell_Lite.Proveedor;
using Microsell_Lite.Informe;
using Microsell_Lite.Facturacion_Electronica;

namespace Microsell_Lite
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
            //inicializamos:
            customizeDesign();
        }

        //metodo: personalizar diseño:

        private void customizeDesign()
        {

            //colocamos como visibel false:
            panelVentasSubmenu.Visible = false;
            panelComprasSubmenu.Visible = false;
            panelAlmacenProdSubmenu.Visible = false;

         
        }

        //creamos otro metodo vacio para ocultar el submenu:

        private void hideSubMenu()
        {
            if (panelVentasSubmenu.Visible == true)
                panelVentasSubmenu.Visible = false;
            if (panelComprasSubmenu.Visible == true)
                panelComprasSubmenu.Visible = false;
            if (panelAlmacenProdSubmenu.Visible == true)
                panelAlmacenProdSubmenu.Visible = false;
        }

        //otro met.para mostrar el submenu:

        private void showSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            
                subMenu.Visible = false;
            
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            //invocamos el motodo de mostrar submenu, como parametro enviamos el 
            //panel submenu de ventas.
            showSubMenu(panelVentasSubmenu);

        }

        private void btnCrearVenta_Click(object sender, EventArgs e)
        {
            
            openChildForms(new Frm_Crear_Ventas());

            hideSubMenu();
            /*openChildForms(new FormularioPrueba());

            hideSubMenu();*/

        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            showSubMenu(panelComprasSubmenu);
           
        }

        private void btnRegistrarCompra_Click(object sender, EventArgs e)
        {
            openChildForms(new Frm_Compras());
            
            hideSubMenu();

        }

        //metodo para abrir los formularios hijos en el contenedor childforms:
        //unicos forms:



        //es necesario cerrar el formulario anterior , por lo tanto
        //almacenamos el form que se abre . en una var tipo privada.
        private Form activeForm = null; 
        private void openChildForms(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            //ahora guardamos el form que se abre en la variable activo,
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }


    }
}
