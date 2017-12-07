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
            string nombre = ddlCategoria.SelectedItem.ToString();

            nombre += " "+ddlReporte.SelectedItem.ToString();

            if (Carrera.Equals("TODAS"))
            {
                if (ddlCategoria.SelectedIndex != 2)
                {
                    nombre += " DE TODAS LAS CARRERAS";
                }
            }
            else
            {
                if (ddlCategoria.SelectedIndex != 2)
                {
                    nombre += " DE " + Carrera;
                }
            }

            if (ddlCategoria.SelectedIndex == 2)
            {
                nombre += ddlPeriodo.SelectedItem.Text;
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
                if (ddlCategoria.SelectedIndex == 1)
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
                                            //Alumnos extranjeros TT.TT
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
                else
                {
                    if (ddlReporte.SelectedIndex == 0)
                    {
                        if (ddlPeriodo.SelectedIndex == 0)
                        {
                            report.ReportPath = "Reportes/EGRESADOS20102.rdlc";
                            SEDCEdatasetTableAdapters.EGRESADOS_20102TableAdapter MC = new SEDCEdatasetTableAdapters.EGRESADOS_20102TableAdapter();
                            MC.Fill(Consulta.Egresados20102());
                            RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                            RDS.Value = Consulta.Egresados20102();
                        }
                        else
                        {
                            if (ddlPeriodo.SelectedIndex == 1)
                            {
                                report.ReportPath = "Reportes/EGRESADOS20111.rdlc";
                                SEDCEdatasetTableAdapters.EGRESADOS_20111TableAdapter MC = new SEDCEdatasetTableAdapters.EGRESADOS_20111TableAdapter();
                                MC.Fill(Consulta.Egresados20111());
                                RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                                RDS.Value = Consulta.Egresados20111();
                            }
                            else
                            {
                                if (ddlPeriodo.SelectedIndex == 2)
                                {
                                    report.ReportPath = "Reportes/EGRESADOS20112.rdlc";
                                    SEDCEdatasetTableAdapters.EGRESADOS_20112TableAdapter MC = new SEDCEdatasetTableAdapters.EGRESADOS_20112TableAdapter();
                                    MC.Fill(Consulta.Egresados20112());
                                    RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                                    RDS.Value = Consulta.Egresados20112();
                                }
                                else
                                {
                                    if (ddlPeriodo.SelectedIndex == 3)
                                    {
                                        report.ReportPath = "Reportes/EGRESADOS20121.rdlc";
                                        SEDCEdatasetTableAdapters.EGRESADOS_20121TableAdapter MC = new SEDCEdatasetTableAdapters.EGRESADOS_20121TableAdapter();
                                        MC.Fill(Consulta.Egresados20121());
                                        RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                                        RDS.Value = Consulta.Egresados20121();
                                    }
                                    else
                                    {
                                        if (ddlPeriodo.SelectedIndex == 4)
                                        {
                                            report.ReportPath = "Reportes/EGRESADOS20122.rdlc";
                                            SEDCEdatasetTableAdapters.EGRESADOS_20122TableAdapter MC = new SEDCEdatasetTableAdapters.EGRESADOS_20122TableAdapter();
                                            MC.Fill(Consulta.Egresados20122());
                                            RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                                            RDS.Value = Consulta.Egresados20122();
                                        }
                                        else
                                        {
                                            if (ddlPeriodo.SelectedIndex == 5)
                                            {
                                                report.ReportPath = "Reportes/EGRESADOS20131.rdlc";
                                                SEDCEdatasetTableAdapters.EGRESADOS_20131TableAdapter MC = new SEDCEdatasetTableAdapters.EGRESADOS_20131TableAdapter();
                                                MC.Fill(Consulta.Egresados20131());
                                                RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                                                RDS.Value = Consulta.Egresados20131();
                                            }
                                            else
                                            {
                                                if (ddlPeriodo.SelectedIndex == 6)
                                                {
                                                    report.ReportPath = "Reportes/EGRESADOS20132.rdlc";
                                                    SEDCEdatasetTableAdapters.EGRESADOS_20132TableAdapter MC = new SEDCEdatasetTableAdapters.EGRESADOS_20132TableAdapter();
                                                    MC.Fill(Consulta.Egresados20132());
                                                    RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                                                    RDS.Value = Consulta.Egresados20132();
                                                }
                                                else
                                                {
                                                    if (ddlPeriodo.SelectedIndex == 7)
                                                    {
                                                        report.ReportPath = "Reportes/EGRESADOS20141.rdlc";
                                                        SEDCEdatasetTableAdapters.EGRESADOS_20141TableAdapter MC = new SEDCEdatasetTableAdapters.EGRESADOS_20141TableAdapter();
                                                        MC.Fill(Consulta.Egresados20141());
                                                        RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                                                        RDS.Value = Consulta.Egresados20141();
                                                    }
                                                    else
                                                    {
                                                        report.ReportPath = "Reportes/EGRESADOS20142.rdlc";
                                                        SEDCEdatasetTableAdapters.EGRESADOS_20142TableAdapter MC = new SEDCEdatasetTableAdapters.EGRESADOS_20142TableAdapter();
                                                        MC.Fill(Consulta.Egresados20142());
                                                        RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                                                        RDS.Value = Consulta.Egresados20142();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (ddlPeriodo.SelectedIndex == 0)
                        {
                            if (ddlCarrera.SelectedItem.Text == "TODAS")
                            {
                                report.ReportPath = "Reportes/INDICEDEREPROBACION20171.rdlc";
                                SEDCEdatasetTableAdapters.INDICE_DE_REPROBACION_20171TableAdapter MC = new SEDCEdatasetTableAdapters.INDICE_DE_REPROBACION_20171TableAdapter();
                                MC.Fill(Consulta.IndiceReprobacion20171());
                                RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                                RDS.Value = Consulta.IndiceReprobacion20171();
                            }
                            else 
                            {
                                report.ReportPath = "Reportes/INDICEDEREPROBACION20171.rdlc";
                                SEDCEdatasetTableAdapters.INDICE_DE_REPROBACION_20171_CARRERATableAdapter MC = new SEDCEdatasetTableAdapters.INDICE_DE_REPROBACION_20171_CARRERATableAdapter();
                                MC.Fill(Consulta.IndiceReprobacion20171Carrera(Carrera),Carrera);
                                RDS.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                                RDS.Value = Consulta.IndiceReprobacion20171Carrera(Carrera);
                            }
                        }
                    }
                }
            }
            report.DataSources.Add(RDS);
            Byte[] mybytes2 = report.Render(Formato);

            using (FileStream fs = new FileStream(Server.MapPath("~/ArchivosTemporales/" + nombre), FileMode.Append, FileAccess.Write))
            {
                fs.Write(mybytes2, 0, mybytes2.Length);
            }

            try
            {
                Response.AppendHeader("content-disposition", "attachment; filename=" + nombre);
                Response.TransmitFile("~/ArchivosTemporales/" + nombre);
                Response.Flush();
            }
            finally 
            {
                File.Delete(Server.MapPath("~/ArchivosTemporales/" + nombre));
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
                ddlReporte.Items.Remove("EFICIENCIA DE EGRESO");
                ddlReporte.Items.Remove("INDICE DE REPROBACION");
                ddlReporte.Items.Add("SEXO POR CARRERA");
                ddlReporte.Items.Add("EDAD POR CARRERA");
                //ddlReporte.Items.Add("PROCEDENCIA POR CARRERA");
                ddlReporte.DataBind();
                ddlCarrera.Visible = true;
                lblCarrera.Visible = true;
                ddlPeriodo.Visible = false;
                lblPeriodo.Visible = false;
            }
            else 
            {
                if (ddlCategoria.SelectedIndex == 1)
                {
                    ddlReporte.Items.Remove("SEXO POR CARRERA");
                    ddlReporte.Items.Remove("EDAD POR CARRERA");
                    ddlReporte.Items.Remove("EFICIENCIA DE EGRESO");
                    ddlReporte.Items.Remove("INDICE DE REPROBACION");
                    //ddlReporte.Items.Remove("PROCEDENCIA POR CARRERA");
                    ddlReporte.Items.Add("ALUMNOS CON DISCAPACIDAD");
                    ddlReporte.Items.Add("SEXO POR CARRERA");
                    ddlReporte.Items.Add("EDAD POR CARRERA");
                    ddlReporte.Items.Add("ALUMNOS POR SEMESTRE");
                    ddlReporte.Items.Add("MAYOR PROMEDIO POR CARRERA");
                    ddlReporte.DataBind();
                    ddlCarrera.Visible = true;
                    lblCarrera.Visible = true;
                    ddlPeriodo.Visible = false;
                    lblPeriodo.Visible = false;
                }
                else
                {
                    ddlReporte.Items.Remove("SEXO POR CARRERA");
                    ddlReporte.Items.Remove("EDAD POR CARRERA");
                    //ddlReporte.Items.Remove("PROCEDENCIA POR CARRERA");
                    ddlReporte.Items.Remove("ALUMNOS CON DISCAPACIDAD");
                    ddlReporte.Items.Remove("SEXO POR CARRERA");
                    ddlReporte.Items.Remove("EDAD POR CARRERA");
                    ddlReporte.Items.Remove("ALUMNOS POR SEMESTRE");
                    ddlReporte.Items.Remove("MAYOR PROMEDIO POR CARRERA");
                    ddlReporte.Items.Add("EFICIENCIA DE EGRESO");
                    ddlReporte.Items.Add("INDICE DE REPROBACION");
                    ddlReporte.DataBind();
                    ddlCarrera.Visible = false;
                    lblCarrera.Visible = false;
                    ddlPeriodo.Visible = true;
                    lblPeriodo.Visible = true;

                    ddlPeriodo.Items.Remove("20102");
                    ddlPeriodo.Items.Remove("20111");
                    ddlPeriodo.Items.Remove("20112");
                    ddlPeriodo.Items.Remove("20121");
                    ddlPeriodo.Items.Remove("20122");
                    ddlPeriodo.Items.Remove("20131");
                    ddlPeriodo.Items.Remove("20132");
                    ddlPeriodo.Items.Remove("20141");
                    ddlPeriodo.Items.Remove("20142");
                    ddlPeriodo.Items.Add("20102");
                    ddlPeriodo.Items.Add("20111");
                    ddlPeriodo.Items.Add("20112");
                    ddlPeriodo.Items.Add("20121");
                    ddlPeriodo.Items.Add("20122");
                    ddlPeriodo.Items.Add("20131");
                    ddlPeriodo.Items.Add("20132");
                    ddlPeriodo.Items.Add("20141");
                    ddlPeriodo.Items.Add("20142");
                    ddlPeriodo.Items.Remove("20171");
                    ddlPeriodo.DataBind();
                }
            }
        }

        protected void ddlReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategoria.SelectedIndex == 2)
            {
                if (ddlReporte.SelectedIndex == 0)
                {
                    ddlPeriodo.Items.Add("20102");
                    ddlPeriodo.Items.Add("20111");
                    ddlPeriodo.Items.Add("20112");
                    ddlPeriodo.Items.Add("20121");
                    ddlPeriodo.Items.Add("20122");
                    ddlPeriodo.Items.Add("20131");
                    ddlPeriodo.Items.Add("20132");
                    ddlPeriodo.Items.Add("20141");
                    ddlPeriodo.Items.Add("20142");
                    ddlPeriodo.Items.Remove("20171");
                    ddlPeriodo.DataBind();
                    lblCarrera.Visible = false;
                    ddlCarrera.Visible = false;
                }
                else
                {
                    ddlPeriodo.Items.Remove("20102");
                    ddlPeriodo.Items.Remove("20111");
                    ddlPeriodo.Items.Remove("20112");
                    ddlPeriodo.Items.Remove("20121");
                    ddlPeriodo.Items.Remove("20122");
                    ddlPeriodo.Items.Remove("20131");
                    ddlPeriodo.Items.Remove("20132");
                    ddlPeriodo.Items.Remove("20141");
                    ddlPeriodo.Items.Remove("20142");
                    ddlPeriodo.Items.Add("20171");
                    ddlPeriodo.DataBind();
                    lblCarrera.Visible = true;
                    ddlCarrera.Visible = true;
                }
            }
        }
    }
}