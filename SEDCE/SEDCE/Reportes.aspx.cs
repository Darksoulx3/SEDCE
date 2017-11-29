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
            string Carrera = ddlCarrera.SelectedItem.ToString();
            string Formato = ddlFormato.SelectedItem.ToString();
            string Periodo = ddlPeriodo.SelectedItem.ToString();
            string nombre = ddlTipoReporte.SelectedItem.ToString() + Periodo;

            if (Carrera.Equals("TODAS"))
            {
                nombre += " DE TODAS LAS CARRERAS";
            }
            else 
            {
                nombre += " DE " + Carrera;
            }

            switch (Formato)
            {
                case "PDF": nombre += ".pdf"; break;
                case "WORD": nombre += ".doc"; break;
                case "EXCEL": nombre += ".xls"; break;
            }

            LocalReport report = new LocalReport();

            switch (ddlTipoReporte.SelectedIndex)
            {
                case 0: report.ReportPath = "Reportes/MatriculaCompleta.rdlc";
                    SEDSEDataSetTableAdapters.MATRICULA_COMPLETATableAdapter ta = new SEDSEDataSetTableAdapters.MATRICULA_COMPLETATableAdapter();
                    SEDSEDataSet.MATRICULA_COMPLETADataTable dt = new SEDSEDataSet.MATRICULA_COMPLETADataTable();
                    ta.Fill(dt);
                    ReportDataSource rds = new ReportDataSource();
                    rds.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                    rds.Value = dt;
                    report.DataSources.Add(rds);
                    Byte[] mybytes = report.Render(Formato);

                    using (FileStream fs = new FileStream(Server.MapPath(nombre), FileMode.Append, FileAccess.Write))
                    {
                        fs.Write(mybytes, 0, mybytes.Length);
                    }
                    Response.AppendHeader("content-disposition", "attachment; filename=" + nombre);
                    Response.TransmitFile(nombre);
                    Response.End();
                    break;
                case 1: report.ReportPath = "Reportes/MatriculaCompleta.rdlc";
                    SEDSEDataSetTableAdapters.MATRICULA_COMPLETATableAdapter ta1 = new SEDSEDataSetTableAdapters.MATRICULA_COMPLETATableAdapter();
                    SEDSEDataSet.MATRICULA_COMPLETADataTable dt1 = new SEDSEDataSet.MATRICULA_COMPLETADataTable();
                    ta1.Fill(dt1);
                    ReportDataSource rds1 = new ReportDataSource();
                    rds1.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                    rds1.Value = dt1;
                    report.DataSources.Add(rds1);
                    Byte[] mybytes1 = report.Render(Formato);

                    using (FileStream fs = new FileStream(Server.MapPath(nombre), FileMode.Append, FileAccess.Write))
                    {
                        fs.Write(mybytes1, 0, mybytes1.Length);
                    }
                    Response.AppendHeader("content-disposition", "attachment; filename=" + nombre);
                    Response.TransmitFile(nombre);
                    Response.End();
                    break;
                case 2: report.ReportPath = "Reportes/MatriculaCompleta.rdlc";
                    SEDSEDataSetTableAdapters.MATRICULA_COMPLETATableAdapter ta2 = new SEDSEDataSetTableAdapters.MATRICULA_COMPLETATableAdapter();
                    SEDSEDataSet.MATRICULA_COMPLETADataTable dt2 = new SEDSEDataSet.MATRICULA_COMPLETADataTable();
                    ta2.Fill(dt2);
                    ReportDataSource rds2 = new ReportDataSource();
                    rds2.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                    rds2.Value = dt2;
                    report.DataSources.Add(rds2);
                    Byte[] mybytes2 = report.Render(Formato);

                    using (FileStream fs = new FileStream(Server.MapPath(nombre), FileMode.Append, FileAccess.Write))
                    {
                        fs.Write(mybytes2, 0, mybytes2.Length);
                    }
                    Response.AppendHeader("content-disposition", "attachment; filename=" + nombre);
                    Response.TransmitFile(nombre);
                    Response.End();
                    break;
            }
        }
    }
}