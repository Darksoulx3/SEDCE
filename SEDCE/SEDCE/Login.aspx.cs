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
            string query = "SELECT nombre_usuario, contraseña_usuario, nivel_usuario FROM usuario WHERE nombre_usuario = @USUARIO AND contraseña_usuario = @PASSWORD";
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            string cnnstring = ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString;
            con.ConnectionString = cnnstring;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@USUARIO", txtBUsuario.Text);
            cmd.Parameters.AddWithValue("@PASSWORD", txtxBPassword.Text);
            sqldr = cmd.ExecuteReader();
            if (sqldr.Read())
            {
                if (txtxBPassword.Text.Equals(sqldr["contraseña_usuario"]))
                {
                    Session["usuario"] = sqldr["nombre_usuario"];
                    Session["nivel"] = sqldr["nivel_usuario"];
                    con.Close();
                    Response.Redirect("Inicio.aspx");
                }
                else 
                {
                    lblError.Text = "Usuario o contraseña incorrectos";
                }
            }
            else 
            {
                if (txtBUsuario.Text == "" | txtxBPassword.Text == "")
                {
                    lblError.Text = "Falto llenar alguno de los campos";
                }
                else
                {
                    lblError.Text = "Usuario o contraseña incorrectos";
                }
            }
        }
    }
}