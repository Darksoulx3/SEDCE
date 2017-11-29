using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
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
            //Response.Redirect("Reporteador.aspx");

            LocalReport report = new LocalReport();
            report.ReportPath = "Reportes/MatriculaCompleta.rdlc";
            SEDSEDataSetTableAdapters.MATRICULA_COMPLETATableAdapter ta = new SEDSEDataSetTableAdapters.MATRICULA_COMPLETATableAdapter();
            SEDSEDataSet.MATRICULA_COMPLETADataTable dt = new SEDSEDataSet.MATRICULA_COMPLETADataTable();
            ta.Fill(dt);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";//This refers to the dataset name in the RDLC file
            rds.Value = dt;
            report.DataSources.Add(rds);
            Byte[] mybytes = report.Render("WORD");
            //Byte[] mybytes = report.Render("PDF"); for exporting to PDF
            using (FileStream fs = File.Create(@"C:\Users\Jonathan Rodriguez\Desktop\SalSlip.doc"))
            {
                fs.Write(mybytes, 0, mybytes.Length);
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