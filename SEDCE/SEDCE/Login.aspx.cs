using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEDCE
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void btnInicioSesion_Click(object sender, EventArgs e)
        {
            SqlDataReader sqldr;
            string query = "SELECT nombre_usuario, contraseña_usuario, nivel_usuario FROM USUARIO WHERE nombre_usuario = @USUARIO AND contraseña_usuario = @PASSWORD";
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            string cnnstring = ConfigurationManager.ConnectionStrings["ConociendoControlesConnectionString"].ConnectionString;
            con.ConnectionString = cnnstring;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@USUARIO", txtBUsuario.Text);
            cmd.Parameters.AddWithValue("@PASSWORD", txtxBPassword.Text);
            sqldr = cmd.ExecuteReader();
            if (sqldr.Read())
            {
                Session["usuario"] = sqldr["USUARIO"];
                Session["nivel"] = sqldr["NIVEL"];
                con.Close();
                Response.Redirect("Inicio.aspx");
            }
        }
    }
}