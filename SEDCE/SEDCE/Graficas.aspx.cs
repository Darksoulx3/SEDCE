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
            Session["Estilo"] = ddlEstiloGrafica.SelectedValue;
            Session["Tipo"] = ddlTipoReporte.SelectedValue;


            Response.Redirect("Grafo.aspx");
        }
    }
}