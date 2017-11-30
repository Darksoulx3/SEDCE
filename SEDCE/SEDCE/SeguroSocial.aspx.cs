using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEDCE
{
    public partial class SeguroSocial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USUARIO"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        private void CargarData(int TipodeBusqueda)
        {
            if (TipodeBusqueda == 0)
            {
                string cnnstring = ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString;
                string query = "SELECT * FROM SEGURO_SOCIAL WHERE NOMBRE LIKE '%"+txtBBuscar.Text+"%'";
                SqlConnection con = new SqlConnection(cnnstring);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                gvNSS.DataSource = ds;
                gvNSS.DataBind();
            }
            else 
            {
                string cnnstring = ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString;
                string query = "SELECT * FROM SEGURO_SOCIAL WHERE NO_CONTROL LIKE '%"+txtBBuscar.Text+"%'";
                SqlConnection con = new SqlConnection(cnnstring);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                gvNSS.DataSource = ds;
                gvNSS.DataBind();  
            }
        }

        protected void txtBBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarData(ddlBusqueda.SelectedIndex);
            if (((gvNSS.Rows.Count + 1) * 10 )< 50)
            {
                gvNSS.Height = (gvNSS.Rows.Count + 1) * 10;
            }
            else 
            {
                gvNSS.Height = 50;
            }
            
        }
    }
}