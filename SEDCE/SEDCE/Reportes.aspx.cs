using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEDCE
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USUARIO"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            ReportViewer Reporteador = new ReportViewer();
            if (ddlTipoReporte.SelectedIndex == 2)
            {
                Microsoft.Reporting.WebForms.Warning warnings;
                string fileName = "test";
                string streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                ReportViewer viewer = new ReportViewer();
                viewer.ProcessingMode = ProcessingMode.Local;
                //viewer.ServerReport.ReportServerUrl = new Uri("http://server/ReportServer_SQL2008R2");
                viewer.LocalReport.ReportPath = "/Reportes/MatriculaCompleta.rdlc";

                Byte[] bytes = viewer.LocalReport.Render("PDF");

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", ("attachment; filename=" + fileName + ".") + extension);
                Response.BinaryWrite(bytes);
                Response.Flush();
            }
        }

        protected void ddlCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlFormato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}