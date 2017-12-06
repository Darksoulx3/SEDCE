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
                ddlTipoGrafica.Items.Remove("ALUMNOS CON DISCAPACIDAD");
                ddlTipoGrafica.Items.Remove("SEXO POR CARRERA");
                ddlTipoGrafica.Items.Remove("EDAD POR CARRERA");
                ddlTipoGrafica.Items.Remove("ALUMNOS POR SEMESTRE");
                ddlTipoGrafica.Items.Remove("MAYOR PROMEDIO POR CARRERA");

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
                    ddlTipoGrafica.Items.Add("ALUMNOS CON DISCAPACIDAD");
                    ddlTipoGrafica.Items.Add("SEXO POR CARRERA");
                    ddlTipoGrafica.Items.Add("EDAD POR CARRERA");
                    ddlTipoGrafica.Items.Add("ALUMNOS POR SEMESTRE");
                    ddlTipoGrafica.Items.Add("MAYOR PROMEDIO POR CARRERA");

                    ddlTipoGrafica.Items.Remove("EFICIENCIA DE EGRESO");
                    ddlTipoGrafica.Items.Remove("INDICE DE REPROBACION");

                    ddlTipoGrafica.Items.Remove("SEXO POR CARRERA");
                    ddlTipoGrafica.Items.Remove("EDAD POR CARRERA");
                    ddlTipoGrafica.DataBind();

                    lblPeriodo.Visible = false;
                    ddlPeriodo.Visible = false;
                }
                else 
                {
                    ddlTipoGrafica.Items.Remove("ALUMNOS CON DISCAPACIDAD");
                    ddlTipoGrafica.Items.Remove("SEXO POR CARRERA");
                    ddlTipoGrafica.Items.Remove("EDAD POR CARRERA");
                    ddlTipoGrafica.Items.Remove("ALUMNOS POR SEMESTRE");
                    ddlTipoGrafica.Items.Remove("MAYOR PROMEDIO POR CARRERA");

                    ddlTipoGrafica.Items.Add("EFICIENCIA DE EGRESO");
                    ddlTipoGrafica.Items.Add("INDICE DE REPROBACION");

                    ddlTipoGrafica.Items.Remove("SEXO POR CARRERA");
                    ddlTipoGrafica.Items.Remove("EDAD POR CARRERA");
                    ddlTipoGrafica.DataBind();

                    lblPeriodo.Visible = true;
                    ddlPeriodo.Visible = true;
                }
            }
        }
    }
}