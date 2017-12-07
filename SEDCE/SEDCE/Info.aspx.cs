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
            string NombreArchivo = Path.Combine(Server.MapPath("~/ImportarDocumento"), Guid.NewGuid().ToString() + Path.GetExtension(fuBD.PostedFile.FileName));
            fuBD.PostedFile.SaveAs(NombreArchivo);
            InsertExcelRecords(NombreArchivo);
            File.Delete(NombreArchivo);
        }
    }
}