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
using CrystalDecisions.Shared;
using Microsell_Lite.Informe;
using Prj_Capa_Datos;

namespace Microsell_Lite.Ventas
{
    public partial class Frm_Print_NotaVenta : Form
    {
        public Frm_Print_NotaVenta()
        {
            InitializeComponent();
        }

        public string tipoprin = "";
        public string RucEmisor = "";
        public string tipoCompro = "";
        private void Frm_Print_NotaVenta_Load(object sender, EventArgs e)
        {
            //if(tipoprin == "fe")
            //{
            //    Imprimir_BoletaFactura_Ticket(this.Tag.ToString());
            //}
            //else
            //{
            //    Imprimir_NotaVenta_Ticket(this.Tag.ToString());
            //}
            /*
            //probar con ste codigo en caso no salga:

            if (tipoprin == "nv")
            {
                Imprimir_NotaVenta_Ticket(this.Tag.ToString());
            }
            else if(tipoprin =="fe")
            {                
                Imprimir_BoletaFactura_Ticket(this.Tag.ToString());
            }
            */
        }
        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //private void Imprimir_NotaVenta(string idDoc)
        //{
        //    RN_Temporal obj = new RN_Temporal();
        //    DataTable dato = new DataTable();

        //    dato = obj.RN_Leer_Temporal_porId(idDoc.Trim());

        //    if(dato.Rows.Count > 0)
        //    {
        //        Rpte_Print_NotaVenta reporte = new Rpte_Print_NotaVenta();
        //        vsr_impre.ReportSource = reporte;
        //        reporte.SetDataSource(dato);
        //        reporte.Refresh();
        //        vsr_impre.ReportSource = reporte;

        //        obj.RN_Eliminar_Temporal(this.Tag.ToString());
        //    }
        //}
        public string Rutdapdf;
        public void Imprimir_BoletaFactura_Ticket(string nrodoc)
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();

            //dato = obj.RN_Leer_Temporal_porId(this.Tag.ToString());
            dato = obj.RN_Leer_Temporal_porId(nrodoc);

            if (dato.Rows.Count > 0)
            {
                //crys_factur_BoletaFE reporte = new crys_factur_BoletaFE();
                //crys_factur_BoletaFE_CrocePlants reporte = new crys_factur_BoletaFE_CrocePlants();
                crys_fact_bole_mcbTransport reporte  = new crys_fact_bole_mcbTransport();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;
                reporte.PrintToPrinter(1, false, 1, 1); //para impresion directa

                try
                {
                    //Guardamos el PDF Automaticamente:
                    ExportOptions exportOption;
                    DiskFileDestinationOptions destinoPdf = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions typeformatoOption = new PdfRtfWordFormatOptions();

                    destinoPdf.DiskFileName = Rutdapdf;
                    exportOption = reporte.ExportOptions;

                    exportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                    exportOption.ExportFormatType = ExportFormatType.PortableDocFormat;
                    exportOption.ExportDestinationOptions = destinoPdf;
                    exportOption.ExportFormatOptions = typeformatoOption;

                    reporte.Export();


                }
                catch (Exception ex )
                {
                    MessageBox.Show("Error al Exportar PDF: " + ex.Message, "Advertencia de Exportacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                //obj.RN_Eliminar_Temporal(this.Tag.ToString());


            }
        }
        public void Imprimir_BoletaFactura_Ticket_GermanEIRL()
        {

            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();
            dato = obj.RN_Leer_Temporal_porId(this.Tag.ToString());
            if (dato.Rows.Count > 0)
            {
                crys_factur_BoletaFE_GermanEIRL reporte = new crys_factur_BoletaFE_GermanEIRL();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;
                //obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        public void Imprimir_BoletaFactura_Ticket_Airlee()
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();
            dato = obj.RN_Leer_Temporal_porId(this.Tag.ToString());
            if (dato.Rows.Count > 0)
            {
                crys_factur_BoletaFE_tx3 reporte = new crys_factur_BoletaFE_tx3();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;
                //obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        public void Imprimir_BoletaFactura_Ticket_TurbInject()
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();

            dato = obj.RN_Leer_Temporal_porId(this.Tag.ToString());

            if (dato.Rows.Count > 0)
            {
                crys_factur_BoletaFE_Turbinject4 reporte = new crys_factur_BoletaFE_Turbinject4();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;

                //obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        public void Imprimir_BoletaFactura_Ticket_Mavaqui()
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();

            dato = obj.RN_Leer_Temporal_porId(this.Tag.ToString());

            if (dato.Rows.Count > 0)
            {
                crys_factur_BoletaFE_Mavaqui reporte = new crys_factur_BoletaFE_Mavaqui();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;

                //obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        public void Imprimir_BoletaFactura_Ticket_Niko()
        {
            //RN_Temporal obj = new RN_Temporal();
            //DataTable dato = new DataTable();

            //dato = obj.RN_Leer_Temporal_porId(this.Tag.ToString());

            //if (dato.Rows.Count > 0)
            //{
            //    //crys_factur_BoletaFE_Niko1 reporte = new crys_factur_BoletaFE_Niko1();
            //    vsr_impre.ReportSource = reporte;
            //    reporte.SetDataSource(dato);
            //    reporte.Refresh();
            //    vsr_impre.ReportSource = reporte;

            //    //obj.RN_Eliminar_Temporal(this.Tag.ToString());
            //}
        }
        public void Imprimir_BoletaFactura_Ticket_JassiStore_SJL(string nrodoc)
        {
           // RN_Temporal obj = new RN_Temporal();
           // DataTable dato = new DataTable();

           // //dato = obj.RN_Leer_Temporal_porId(this.Tag.ToString());
           //// dato = obj.RN_Leer_Temporal_porId(nrodoc); v

           // //if (dato.Rows.Count > 0)
           // //{
           // /*
           //     crys_factur_BoletaFE_JassiStore_SJL reporte = new crys_factur_BoletaFE_JassiStore_SJL();
           //     vsr_impre.ReportSource = reporte;
           //     reporte.SetDataSource(dato);
           //     reporte.Refresh();
           //     vsr_impre.ReportSource = reporte;
           //     reporte.PrintToPrinter(1, false, 1, 1); //para impresion directa
           //     */
           //     //obj.RN_Eliminar_Temporal(this.Tag.ToString());

           //     try
           //     {

           //         dato = obj.RN_Leer_Temporal_porId(nrodoc);
           //         crys_factur_BoletaFE_JassiStore_SJL reporte = new crys_factur_BoletaFE_JassiStore_SJL();
           //         this.vsr_impre.ReportSource = reporte;
           //         reporte.SetDataSource(dato);
           //         reporte.Refresh();
           //         vsr_impre.ReportSource = reporte;
           //         reporte.PrintToPrinter(1, false, 1, 1); //para impresion directa


           //     //probando copia administrativa

           //         crys_factur_BoletaFE_CopiaAdmin repCop = new crys_factur_BoletaFE_CopiaAdmin();
           //         this.vsr_impre.ReportSource = repCop;
           //         repCop.SetDataSource(dato);
           //         repCop.Refresh();
           //         vsr_impre.ReportSource = repCop;
           //         repCop.PrintToPrinter(1, false, 1, 1);
           //     //fin 

           //     //Guardamos el PDF Automaticamente:
           //     //ExportOptions exportOption;
           //     //DiskFileDestinationOptions destinoPdf = new DiskFileDestinationOptions();
           //     //PdfRtfWordFormatOptions typeformatoOption = new PdfRtfWordFormatOptions();

           //     //destinoPdf.DiskFileName = Rutdapdf;
           //     //exportOption = reporte.ExportOptions;

           //     //exportOption.ExportDestinationType = ExportDestinationType.DiskFile;
           //     //exportOption.ExportFormatType = ExportFormatType.PortableDocFormat;
           //     //exportOption.ExportDestinationOptions = destinoPdf;
           //     //exportOption.ExportFormatOptions = typeformatoOption;

           //     //reporte.Export();

           // }
           //     catch (Exception ex)
           //     {

           //         MessageBox.Show("Error al crear la impresion: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
           //     }
            //}
        }
        
        //impresion de copia administrativa 
        public void Imprimir_CopAdminTicket_JassiStore_SJL(string nrodoc)
        {
            //RN_Temporal obj = new RN_Temporal();
            //DataTable dato = new DataTable();

            //try
            //{

            //    dato = obj.RN_Leer_Temporal_porId(nrodoc);
            //    crys_factur_BoletaFE_CopiaAdmin reporte = new crys_factur_BoletaFE_CopiaAdmin();
            //    this.vsr_impre.ReportSource = reporte;
            //    reporte.SetDataSource(dato);
            //    reporte.Refresh();
            //    vsr_impre.ReportSource = reporte;
            //    reporte.PrintToPrinter(1, false, 1, 1); //para impresion directa

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("Error al crear la impresion: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
            

        }
        public void Imprimir_BoletaFactura_Ticket_SoniaValero()
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();

            dato = obj.RN_Leer_Temporal_porId(this.Tag.ToString());

            if (dato.Rows.Count > 0)
            {
                crys_factur_BoletaFE_SoniaValero reporte = new crys_factur_BoletaFE_SoniaValero();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;
                //reporte.PrintToPrinter(1, false, 1, 1); //para impresion directa
                //obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        public void Imprimir_BoletaFactura_Ticket_InvAnelay(string nrodoc)
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();
            
            try
            {
                dato = obj.RN_Leer_Temporal_porId(nrodoc);
                crys_factur_BoletaFE_InvAnelay reporte = new crys_factur_BoletaFE_InvAnelay();
                this.vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;
                reporte.PrintToPrinter(1, false, 1, 1); //para impresion directa

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la impresion: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void Imprimir_BoletaFactura_Ticket_ColeccionistaPeru(string nrodoc)
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();

            try
            {
                dato = obj.RN_Leer_Temporal_porId(nrodoc);
                crys_factur_BoletaFE_ColeccionistaPeru reporte = new crys_factur_BoletaFE_ColeccionistaPeru();
                this.vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;
                reporte.PrintToPrinter(1, false, 1, 1); //para impresion directa
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la impresion: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void Imprimir_BoletaFactura_Ticket_McbTransport(string nrodoc)
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();

            try
            {
                dato = obj.RN_Leer_Temporal_porId(nrodoc);
                crys_fact_bole_mcbTransport reporte = new crys_fact_bole_mcbTransport();
                this.vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;
                //reporte.PrintToPrinter(1, false, 1, 1); //para impresion directa
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la impresion: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void Imprimir_BoletaFactura_Ticket_INV_NJT(string nrodoc)
        {
            //RN_Temporal obj = new RN_Temporal();
            //DataTable dato = new DataTable();

            //try
            //{

            //    dato = obj.RN_Leer_Temporal_porId(nrodoc);

            //    crys_factur_BoletaFE_INV_NJT reporte = new crys_factur_BoletaFE_INV_NJT();
            //    this.vsr_impre.ReportSource = reporte;
            //    reporte.SetDataSource(dato);
            //    reporte.Refresh();
            //    vsr_impre.ReportSource = reporte;
            //    reporte.PrintToPrinter(1, false, 1, 1); //para impresion directa

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("Error al crear la impresion: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}

        }
        public void Imprimir_BoletaFactura_Ticket_TextCharlote()
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();
            dato = obj.RN_Leer_Temporal_porId(this.Tag.ToString());
            if (dato.Rows.Count > 0)
            {
                crys_factur_BoletaFE_TextilCharlotte reporte = new crys_factur_BoletaFE_TextilCharlotte();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;
                //obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        public void Imprimir_BoletaFactura_Ticket_ImportacionTextilLucero()
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();

            dato = obj.RN_Leer_Temporal_porId(this.Tag.ToString());

            if (dato.Rows.Count > 0)
            {
                crys_factur_BoletaFE_ImportTextil_Lucero reporte = new crys_factur_BoletaFE_ImportTextil_Lucero();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;
                //obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        public void Imprimir_BoletaFactura_Ticket_LucianoEIRL(string nrodoc)
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();

            try
            {
                dato = obj.RN_Leer_Temporal_porId(nrodoc);
                crys_factur_BoletaFE_LucianoEIRL reporte = new crys_factur_BoletaFE_LucianoEIRL();
                this.vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;
                reporte.PrintToPrinter(1, false, 1, 1); //para impresion directa

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la impresion: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #region  Metodos para ImpresionNotasVenta

        public void Imprimir_NotaVenta_Ticket()
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();

            dato = obj.RN_Leer_Temporal_porId(this.Tag.ToString());

            if (dato.Rows.Count > 0)
            {
                crys_Notaventa_CrocePlants reporte = new crys_Notaventa_CrocePlants();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;

                //obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        public void Imprimir_NotaVenta_Ticket_GermanEIRL()
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();

            dato = obj.RN_Leer_Temporal_porId(this.Tag.ToString());

            if (dato.Rows.Count > 0)
            {
                rpte_print_TicketNota_GermanEIRL reporte = new rpte_print_TicketNota_GermanEIRL();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;

               // obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        public void Imprimir_NotaVenta_Ticket_Airlee()
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();

            dato = obj.RN_Leer_Temporal_porId(this.Tag.ToString());

            if (dato.Rows.Count > 0)
            {
                rpte_print_TicketNota_Airlee reporte = new rpte_print_TicketNota_Airlee();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;

                // obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        public void Imprimir_NotaVenta_Ticket_TurbInject()
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();

            dato = obj.RN_Leer_Temporal_porId(this.Tag.ToString());

            if (dato.Rows.Count > 0)
            {
                rpte_print_TicketNota_Turbinject reporte = new rpte_print_TicketNota_Turbinject();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;

                // obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        public void Imprimir_NotaVenta_Ticket_Mavaqui()
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();

            dato = obj.RN_Leer_Temporal_porId(this.Tag.ToString());

            if (dato.Rows.Count > 0)
            {
                rpte_print_TicketNota_Mavaqui reporte = new rpte_print_TicketNota_Mavaqui();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;

                // obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        public void Imprimir_NotaVenta_Ticket_Niko()
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();

            dato = obj.RN_Leer_Temporal_porId(this.Tag.ToString());

            if (dato.Rows.Count > 0)
            {
                rpte_print_TicketNota_Niko1 reporte = new rpte_print_TicketNota_Niko1();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;

                // obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        public void Imprimir_NotaVenta_Ticket_JassiStore_SJL(string nrodoc)
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();

            dato = obj.RN_Leer_Temporal_porId(nrodoc);

            if (dato.Rows.Count > 0)
            {
                rpte_print_TicketNota_JassiStore_SJL reporte = new rpte_print_TicketNota_JassiStore_SJL();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;
                reporte.PrintToPrinter(1, false, 1, 1); //para impresion directa
                // obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        public void Imprimir_NotaVenta_Ticket_SoniaValero()
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();

            dato = obj.RN_Leer_Temporal_porId(this.Tag.ToString());

            if (dato.Rows.Count > 0)
            {
                rpte_print_TicketNota_SoniaValero reporte = new rpte_print_TicketNota_SoniaValero();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;

                // obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        public void Imprimir_NotaVenta_Ticket_InvAnelay(string nrodoc)
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();

            dato = obj.RN_Leer_Temporal_porId(nrodoc);

            if (dato.Rows.Count > 0)
            {
                rpte_print_TicketNota_InvAnelay reporte = new rpte_print_TicketNota_InvAnelay();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;
                reporte.PrintToPrinter(1, false, 1, 1); //para impresion directa
                // obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        public void Imprimir_NotaVenta_Ticket_ColeccionistaPeru(string nrodoc)
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();

            dato = obj.RN_Leer_Temporal_porId(nrodoc);

            if (dato.Rows.Count > 0)
            {
                rpte_print_TicketNota_ColeccionistaPeru reporte = new rpte_print_TicketNota_ColeccionistaPeru();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;
                reporte.PrintToPrinter(1, false, 1, 1); //para impresion directa
                // obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        public void Imprimir_NotaVenta_Ticket_INV_NJT(string nrodoc)
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();

            dato = obj.RN_Leer_Temporal_porId(nrodoc);

            if (dato.Rows.Count > 0)
            {
                rpte_print_TicketNota_INV_NJT reporte = new rpte_print_TicketNota_INV_NJT();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;
                reporte.PrintToPrinter(1, false, 1, 1); //para impresion directa
                // obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        public void Imprimir_NotaVenta_Ticket_TextCharlote(string nrodoc)
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();
            dato = obj.RN_Leer_Temporal_porId(nrodoc);
            if (dato.Rows.Count > 0)
            {
                rpte_print_TicketNota_Textil_Charlotte reporte = new rpte_print_TicketNota_Textil_Charlotte();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;
                reporte.PrintToPrinter(1, false, 1, 1); //para impresion directa
                // obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        public void Imprimir_NotaVenta_Ticket_TextilLucero(string nrodoc)
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();
            dato = obj.RN_Leer_Temporal_porId(nrodoc);
            if (dato.Rows.Count > 0)
            {
                rpte_print_TicketNota_Import_Text_Lucero reporte = new rpte_print_TicketNota_Import_Text_Lucero();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;
                reporte.PrintToPrinter(1, false, 1, 1); //para impresion directa
                // obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }
        public void Imprimir_NotaVenta_Ticket_LucianoEIRL(string nrodoc)
        {
            RN_Temporal obj = new RN_Temporal();
            DataTable dato = new DataTable();
            dato = obj.RN_Leer_Temporal_porId(nrodoc);
            if (dato.Rows.Count > 0)
            {
                rpte_print_TicketNota_LucianoEIRL reporte = new rpte_print_TicketNota_LucianoEIRL();
                vsr_impre.ReportSource = reporte;
                reporte.SetDataSource(dato);
                reporte.Refresh();
                vsr_impre.ReportSource = reporte;
                reporte.PrintToPrinter(1, false, 1, 1); //para impresion directa
                // obj.RN_Eliminar_Temporal(this.Tag.ToString());
            }
        }

        #endregion
        private void btn_Print_Click(object sender, EventArgs e)
        {
            vsr_impre.PrintReport();
        }
        private void btn_export_Click(object sender, EventArgs e)
        {
            vsr_impre.ExportReport();
        }
        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            vsr_impre.RefreshReport();
            
        }
    }
}
