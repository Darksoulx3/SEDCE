using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace SEDCE
{
    public partial class Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USUARIO"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        private void InsertExcelRecords(string FilePath)
        {

            ConeccionesBD Consultas = new ConeccionesBD();
            try
            {
                string backup = Server.MapPath("~/DataBaseBackUp/SEDSE.BAK");
                if (File.Exists(backup)) 
                {
                    File.Delete(backup);
                }
                Consultas.BackUpBD(backup);
                Consultas.PrepararTablas();
                Consultas.ActualizarAlumnos(FilePath);
                Consultas.CrearNuevoIngreso();
                Consultas.InsertarNuevoIngreso(FilePath);
                Consultas.InsertarMaterias(FilePath);
                Consultas.InsertarEgresos(FilePath);
                lblResultado.Text = "Base de datos actualizada correctamente";
            }
            catch (Exception)
            {
                string backup = Server.MapPath("~/DataBaseBackUp/SEDSE.BAK");
                Consultas.RestoreDB(backup);
                lblResultado.Text = "Error al actualizar base de datos revise el archivo porfavor";
            }
        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            if (fuBD.HasFile)
            {
                string NombreArchivo = Server.MapPath("~/ImportarDocumento/import.xls");
                fuBD.PostedFile.SaveAs(NombreArchivo);
                InsertExcelRecords(NombreArchivo);
                File.Delete(NombreArchivo);
            }
            else
            {
                lblResultado.Text = "Favor de seleccionar un archivo";
            }
        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            string NombreArchivo = Server.MapPath("~/ArchivosTemporales/SEDSE.BAK");
            ConeccionesBD Consultas = new ConeccionesBD();
            Consultas.BackUpBD(NombreArchivo);
            try
            {
                Response.AppendHeader("content-disposition", "attachment; filename=SEDSE.BAK");
                Response.TransmitFile("~/ArchivosTemporales/SEDSE.BAK");
                Response.Flush();
            }
            finally 
            {
                File.Delete(Server.MapPath("~/ArchivosTemporales/SEDSE.BAK"));
            }
        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            if (fuRestore.HasFile)
            {
                string NombreArchivo = Server.MapPath("~/ArchivosTemporales/SEDSE.BAK");
                fuRestore.PostedFile.SaveAs(NombreArchivo);
                ConeccionesBD consultas = new ConeccionesBD();
                consultas.RestoreDB(NombreArchivo);
                lblRestoreError.Text = "Restore completado exitosamente";
                File.Delete(NombreArchivo);
            }
            else
            {
                lblRestoreError.Text = "Favor de seleccionar un archivo";
            }
        }
    }
}