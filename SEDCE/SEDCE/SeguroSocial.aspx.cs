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
                string query;
                SqlConnection con = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.ConnectionString = cnnstring;
                con.Open();
                cmd.Connection = con;
                query = "SELECT * FROM SEGURO_SOCIAL WHERE NOMBRE LIKE ('%@NOMBRE%')";
                cmd.Parameters.AddWithValue("@NOMBRE", txtBBuscar.Text);
                cmd.CommandText = query;
                da.Fill(dt);
                gvNSS.DataSource = dt;
                gvNSS.DataBind();
                con.Close();
            }
            else 
            {
                string cnnstring = ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString;
                string query;
                SqlConnection con = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.ConnectionString = cnnstring;
                con.Open();
                cmd.Connection = con;
                query = "SELECT * FROM SEGURO_SOCIAL WHERE NO_CONTROL LIKE ('%@NO_CONTROL%')";
                cmd.Parameters.AddWithValue("@NO_CONTROL", txtBBuscar.Text);
                cmd.CommandText = query;
                da.Fill(dt);
                gvNSS.DataSource = dt;
                gvNSS.DataBind();
                con.Close();
            }
            
        }

        protected void txtBBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarData(ddlBusqueda.SelectedIndex);
        }
    }
}