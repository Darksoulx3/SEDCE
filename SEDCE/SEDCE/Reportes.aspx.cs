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
            ConeccionesBD Consulta = new ConeccionesBD();
            ReportDataSource RDS = new ReportDataSource();
            switch (ddlTipoReporte.SelectedIndex)
            {
                case 0:
                    break;
                case 1: 
                    break;
                case 2: 
                    if (ddlCarrera.SelectedItem.ToString().Equals("TODAS"))
                    {
                        report.ReportPath = "Reportes/MatriculaCompleta.rdlc";
                        SEDCEdatasetTableAdapters.MATRICULA_COMPLETATableAdapter MC = new SEDCEdatasetTableAdapters.MATRICULA_COMPLETATableAdapter();
                        MC.Fill(Consulta.MatriculaCompleta());
                        RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                        RDS.Value = Consulta.MatriculaCompleta();
                    }
                    else 
                    {
                        report.ReportPath = "Reportes/MatriculaCompleta.rdlc";
                        SEDCEdatasetTableAdapters.MATRICULA_COMPLETA_CARRERA_ESPECIFICATableAdapter MC = new SEDCEdatasetTableAdapters.MATRICULA_COMPLETA_CARRERA_ESPECIFICATableAdapter();
                        MC.Fill(Consulta.MatriculaCompletaCarreraEspecifica(ddlCarrera.SelectedItem.ToString()),ddlCarrera.SelectedItem.ToString());
                        RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                        RDS.Value = Consulta.MatriculaCompletaCarreraEspecifica(ddlCarrera.SelectedItem.ToString());
                    }
                    break;
            }
            report.DataSources.Add(RDS);
            Byte[] mybytes2 = report.Render(Formato);

            using (FileStream fs = new FileStream(Server.MapPath(nombre), FileMode.Append, FileAccess.Write))
            {
                fs.Write(mybytes2, 0, mybytes2.Length);
            }
            Response.AppendHeader("content-disposition", "attachment; filename=" + nombre);
            Response.TransmitFile(nombre);
            Response.End();
        }
    }
}