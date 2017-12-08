using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEDCE
{
    public partial class Graficas : System.Web.UI.Page
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
            Session["Carrera"] = ddlCarrera.SelectedValue;
            Session["Periodo"] = ddlPeriodo.SelectedValue;
            Session["Estilo"] = ddlEstiloGrafica.SelectedIndex;
            Session["Tipo"] = ddlTipoGrafica.SelectedValue;
            Session["Categoria"] = ddlCategoria.SelectedValue;

            Response.Redirect("Grafo.aspx");
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategoria.SelectedIndex == 0)
            {
                ddlTipoGrafica.Items.Remove("SEXO POR CARRERA");
                ddlTipoGrafica.Items.Remove("EDAD POR CARRERA");
                ddlTipoGrafica.Items.Remove("ALUMNOS POR SEMESTRE");
                ddlTipoGrafica.Items.Remove("EFICIENCIA DE EGRESO");
                ddlTipoGrafica.Items.Remove("INDICE DE REPROBACION");
                ddlTipoGrafica.Items.Add("SEXO POR CARRERA");
                ddlTipoGrafica.Items.Add("EDAD POR CARRERA");
                ddlTipoGrafica.DataBind();

                lblPeriodo.Visible = false;
                ddlPeriodo.Visible = false;
            }
            else
            {
                if (ddlCategoria.SelectedIndex == 1)
                {
                    ddlTipoGrafica.Items.Remove("SEXO POR CARRERA");
                    ddlTipoGrafica.Items.Remove("EDAD POR CARRERA");
                    ddlTipoGrafica.Items.Remove("EFICIENCIA DE EGRESO");
                    ddlTipoGrafica.Items.Remove("INDICE DE REPROBACION");
                    ddlTipoGrafica.Items.Add("SEXO POR CARRERA");
                    ddlTipoGrafica.Items.Add("EDAD POR CARRERA");
                    ddlTipoGrafica.Items.Add("ALUMNOS POR SEMESTRE");
                    ddlTipoGrafica.DataBind();

                    lblPeriodo.Visible = false;
                    ddlPeriodo.Visible = false;
                }
                else
                {
                    ddlTipoGrafica.Items.Remove("SEXO POR CARRERA");
                    ddlTipoGrafica.Items.Remove("EDAD POR CARRERA");
                    ddlTipoGrafica.Items.Remove("SEXO POR CARRERA");
                    ddlTipoGrafica.Items.Remove("EDAD POR CARRERA");
                    ddlTipoGrafica.Items.Remove("ALUMNOS POR SEMESTRE");
                    ddlTipoGrafica.Items.Add("EFICIENCIA DE EGRESO");
                    ddlTipoGrafica.Items.Add("INDICE DE REPROBACION");
                    ddlTipoGrafica.DataBind();

                    lblPeriodo.Visible = true;
                    ddlPeriodo.Visible = true;
                    ddlCarrera.Visible = false;
                    lblCarrera.Visible = false;

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

        protected void ddlTipoGrafica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategoria.SelectedIndex == 2)
            {
                if (ddlTipoGrafica.SelectedIndex == 0)
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
                    ddlCarrera.SelectedIndex = 0;
                }
                else
                {
                    if (ddlTipoGrafica.SelectedIndex == 1)
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
}