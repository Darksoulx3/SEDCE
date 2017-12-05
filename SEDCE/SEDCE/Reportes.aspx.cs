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
            ImprimirReporte();
        }

        private void ImprimirReporte()
        {
            string Carrera = ddlCarrera.SelectedItem.ToString();
            string Formato = ddlFormato.SelectedItem.ToString();
            string nombre = "~/ArchivosTemporales/"+ddlCategoria.SelectedItem.ToString();

            nombre += " "+ddlReporte.SelectedItem.ToString();

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

            if (ddlCategoria.SelectedIndex == 0) 
            {
                if (ddlReporte.SelectedIndex == 0)
                {
                    if (ddlCarrera.SelectedItem.ToString().Equals("TODAS"))
                    {
                        report.ReportPath = "Reportes/NuevoIngresoPorSexo.rdlc";
                        SEDCEdatasetTableAdapters.NUEVO_INGRESO_POR_SEXOTableAdapter MC = new SEDCEdatasetTableAdapters.NUEVO_INGRESO_POR_SEXOTableAdapter();
                        MC.Fill(Consulta.NuevoIngresoPorSexo());
                        RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                        RDS.Value = Consulta.NuevoIngresoPorSexo();
                    }
                    else 
                    {
                        report.ReportPath = "Reportes/NuevoIngresoPorSexo.rdlc";
                        SEDCEdatasetTableAdapters.NUEVO_INGRESO_POR_SEXO_CARRERA_ESPECIFICATableAdapter MC = new SEDCEdatasetTableAdapters.NUEVO_INGRESO_POR_SEXO_CARRERA_ESPECIFICATableAdapter();
                        MC.Fill(Consulta.NuevoIngresoPorSexoCarreraEspeficica(Carrera),Carrera);
                        RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                        RDS.Value = Consulta.NuevoIngresoPorSexoCarreraEspeficica(Carrera);
                    }
                }
                else 
                {
                    if (ddlReporte.SelectedIndex == 1)
                    {
                        if (ddlCarrera.SelectedItem.ToString().Equals("TODAS"))
                        {
                            report.ReportPath = "Reportes/NuevoIngresoPorEdad.rdlc";
                            SEDCEdatasetTableAdapters.NUEVO_INGRESO_POR_EDADTableAdapter MC = new SEDCEdatasetTableAdapters.NUEVO_INGRESO_POR_EDADTableAdapter();
                            MC.Fill(Consulta.NuevoIngresoPorEdad());
                            RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                            RDS.Value = Consulta.NuevoIngresoPorEdad();
                        }
                        else
                        {
                            report.ReportPath = "Reportes/NuevoIngresoPorEdad.rdlc";
                            SEDCEdatasetTableAdapters.NUEVO_INGRESO_POR_EDAD_CARRERA_ESPECIFICATableAdapter MC = new SEDCEdatasetTableAdapters.NUEVO_INGRESO_POR_EDAD_CARRERA_ESPECIFICATableAdapter();
                            MC.Fill(Consulta.NuevoIngresoPorEdadCarreraEspeficica(Carrera), Carrera);
                            RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                            RDS.Value = Consulta.NuevoIngresoPorEdadCarreraEspeficica(Carrera);
                        }
                    }
                    else
                    {
                        if (ddlCarrera.SelectedItem.ToString().Equals("TODAS"))
                        {
                            //PROCEDENCIA POR CARRERA TODAS
                        }
                        else
                        {
                                //PROCEDENCIA POR CARRERA ESPECIFICA
                        }
                    }
                }
            }
            else
            {
                if (ddlReporte.SelectedIndex == 0)
                {
                    if (ddlCarrera.SelectedItem.ToString().Equals("TODAS"))
                    {
                        report.ReportPath = "Reportes/MatriculaTotalDiscapacidad.rdlc";
                        SEDCEdatasetTableAdapters.MATRICULA_TOTAL_DISCAPACIDADTableAdapter MC = new SEDCEdatasetTableAdapters.MATRICULA_TOTAL_DISCAPACIDADTableAdapter();
                        MC.Fill(Consulta.MatriculaTotalDiscapacidad());
                        RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                        RDS.Value = Consulta.MatriculaTotalDiscapacidad();
                    }
                    else 
                    {
                        report.ReportPath = "Reportes/MatriculaTotalDiscapacidad.rdlc";
                        SEDCEdatasetTableAdapters.MATRICULA_TOTAL_DISCAPACIDAD_CARRERA_ESPECIFICATableAdapter MC = new SEDCEdatasetTableAdapters.MATRICULA_TOTAL_DISCAPACIDAD_CARRERA_ESPECIFICATableAdapter();
                        MC.Fill(Consulta.MatriculaTotalDiscapacidadCarreraEspecifica(Carrera), Carrera);
                        RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                        RDS.Value = Consulta.MatriculaTotalDiscapacidadCarreraEspecifica(Carrera);
                    }
                }
                else
                {
                    if (ddlReporte.SelectedIndex == 1)
                    {
                        if (ddlCarrera.SelectedItem.ToString().Equals("TODAS"))
                        {
                            report.ReportPath = "Reportes/MatriculaTotalPorSexo.rdlc";
                            SEDCEdatasetTableAdapters.MATRICULA_TOTAL_POR_SEXOTableAdapter MC = new SEDCEdatasetTableAdapters.MATRICULA_TOTAL_POR_SEXOTableAdapter();
                            MC.Fill(Consulta.MatriculaTotalSexo());
                            RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                            RDS.Value = Consulta.MatriculaTotalSexo();
                        }
                        else
                        {
                            report.ReportPath = "Reportes/MatriculaTotalPorSexo.rdlc";
                            SEDCEdatasetTableAdapters.MATRICULA_TOTAL_POR_SEXO_CARRERA_ESPECIFICATableAdapter MC = new SEDCEdatasetTableAdapters.MATRICULA_TOTAL_POR_SEXO_CARRERA_ESPECIFICATableAdapter();
                            MC.Fill(Consulta.MatriculaTotalSexoCarreraEspecifica(Carrera), Carrera);
                            RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                            RDS.Value = Consulta.MatriculaTotalSexoCarreraEspecifica(Carrera);
                        }
                    }
                    else
                    {
                        if (ddlReporte.SelectedIndex == 2)
                        {
                            if (ddlCarrera.SelectedItem.ToString().Equals("TODAS"))
                            {
                                report.ReportPath = "Reportes/MatriculaTotalPorEdad.rdlc";
                                SEDCEdatasetTableAdapters.MATRICULA_TOTAL_POR_EDADTableAdapter MC = new SEDCEdatasetTableAdapters.MATRICULA_TOTAL_POR_EDADTableAdapter();
                                MC.Fill(Consulta.MatriculaTotalEdad());
                                RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                                RDS.Value = Consulta.MatriculaTotalEdad();
                            }
                            else
                            {
                                report.ReportPath = "Reportes/MatriculaTotalPorEdad.rdlc";
                                SEDCEdatasetTableAdapters.MATRICULA_TOTAL_POR_EDAD_CARRERA_ESPECIFICATableAdapter MC = new SEDCEdatasetTableAdapters.MATRICULA_TOTAL_POR_EDAD_CARRERA_ESPECIFICATableAdapter();
                                MC.Fill(Consulta.MatriculaTotalEdadCarreraEspecifica(Carrera), Carrera);
                                RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                                RDS.Value = Consulta.MatriculaTotalEdadCarreraEspecifica(Carrera);
                            }
                        }
                        else
                        {
                            if (ddlReporte.SelectedIndex == 3)
                            {
                                if (ddlCarrera.SelectedItem.ToString().Equals("TODAS"))
                                {
                                    report.ReportPath = "Reportes/MatriculaTotalSemestre.rdlc";
                                    SEDCEdatasetTableAdapters.MATRICULA_TOTAL_SEMESTRETableAdapter MC = new SEDCEdatasetTableAdapters.MATRICULA_TOTAL_SEMESTRETableAdapter();
                                    MC.Fill(Consulta.MatriculaTotalSemestre());
                                    RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                                    RDS.Value = Consulta.MatriculaTotalSemestre();
                                }
                                else
                                {
                                    report.ReportPath = "Reportes/MatriculaTotalSemestre.rdlc";
                                    SEDCEdatasetTableAdapters.MATRICULA_TOTAL_SEMESTRE_CARRERA_ESPECIFICATableAdapter MC = new SEDCEdatasetTableAdapters.MATRICULA_TOTAL_SEMESTRE_CARRERA_ESPECIFICATableAdapter();
                                    MC.Fill(Consulta.MatriculaTotalSemestreCarreraEspecifica(Carrera), Carrera);
                                    RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                                    RDS.Value = Consulta.MatriculaTotalSemestreCarreraEspecifica(Carrera);
                                }
                            }
                            else
                            {
                                if (ddlReporte.SelectedIndex == 4)
                                {
                                    if (ddlCarrera.SelectedItem.ToString().Equals("TODAS"))
                                    {
                                        report.ReportPath = "Reportes/MatriculaTotalPromedio.rdlc";
                                        SEDCEdatasetTableAdapters.MATRICULA_TOTAL_PROMEDIOTableAdapter MC = new SEDCEdatasetTableAdapters.MATRICULA_TOTAL_PROMEDIOTableAdapter();
                                        MC.Fill(Consulta.MatriculaTotalPromedio());
                                        RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                                        RDS.Value = Consulta.MatriculaTotalPromedio();
                                    }
                                    else
                                    {
                                        report.ReportPath = "Reportes/MatriculaTotalPromedio.rdlc";
                                        SEDCEdatasetTableAdapters.MATRICULA_TOTAL_PROMEDIO_CARRERA_ESPECIFICATableAdapter MC = new SEDCEdatasetTableAdapters.MATRICULA_TOTAL_PROMEDIO_CARRERA_ESPECIFICATableAdapter();
                                        MC.Fill(Consulta.MatriculaTotalPromedioCarreraEspecifica(Carrera), Carrera);
                                        RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                                        RDS.Value = Consulta.MatriculaTotalPromedioCarreraEspecifica(Carrera);
                                    }
                                }
                                else
                                {
                                    if (ddlCarrera.SelectedItem.ToString().Equals("TODAS"))
                                    {

                                    }
                                    else
                                    {

                                    }
                                }
                            }
                        }
                    }
                }
            }
            report.DataSources.Add(RDS);
            Byte[] mybytes2 = report.Render(Formato);

            using (FileStream fs = new FileStream(Server.MapPath(nombre), FileMode.Append, FileAccess.Write))
            {
                fs.Write(mybytes2, 0, mybytes2.Length);
            }

            try
            {
                Response.AppendHeader("content-disposition", "attachment; filename=" + nombre);
                Response.TransmitFile(nombre);
                Response.Flush();
            }
            finally 
            {
                File.Delete(Server.MapPath(nombre));
            }
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategoria.SelectedIndex == 0)
            {
                ddlReporte.Items.Remove("ALUMNOS CON DISCAPACIDAD");
                ddlReporte.Items.Remove("SEXO POR CARRERA");
                ddlReporte.Items.Remove("EDAD POR CARRERA");
                ddlReporte.Items.Remove("ALUMNOS POR SEMESTRE");
                ddlReporte.Items.Remove("MAYOR PROMEDIO POR CARRERA");
                ddlReporte.Items.Add("SEXO POR CARRERA");
                ddlReporte.Items.Add("EDAD POR CARRERA");
                //ddlReporte.Items.Add("PROCEDENCIA POR CARRERA");
                ddlReporte.DataBind();
            }
            else 
            {
                ddlReporte.Items.Remove("SEXO POR CARRERA");
                ddlReporte.Items.Remove("EDAD POR CARRERA");
                //ddlReporte.Items.Remove("PROCEDENCIA POR CARRERA");
                ddlReporte.Items.Add("ALUMNOS CON DISCAPACIDAD");
                ddlReporte.Items.Add("SEXO POR CARRERA");
                ddlReporte.Items.Add("EDAD POR CARRERA");
                ddlReporte.Items.Add("ALUMNOS POR SEMESTRE");
                ddlReporte.Items.Add("MAYOR PROMEDIO POR CARRERA");
                ddlReporte.DataBind();
            }
        }
    }
}