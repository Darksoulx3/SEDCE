using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;

namespace SEDCE
{
    public partial class Configuraciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USUARIO"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
        bool Alta = true;
        bool Baja = false;
        bool Cambio = false;
        bool usuario = false;
        bool pass = false;

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            #region Configuracion Visual
            btnAlta.BackColor = Color.LightSkyBlue;
            btnBaja.BackColor = Color.White;
            btnCambio.BackColor = Color.White;
            btnAceptarCambioUsuario.Visible = true;
            Button1.Visible = false;
            Button2.Visible = false;

            ddlUsuarios.Visible = false;
            tbxPassword.Visible = true;
            tbxUsuario.Visible = true;
            lblnContraseña.Visible = true;
            lblnUsuario.Visible = true;

            lblMensaje.Visible = false;
            lblLong.Visible = false;
            lblMay.Visible = false;
            lblUsuarioError.Visible = false;
            lblNum.Visible = false;
            lblNivel.Visible = true;

            lblResultado.Visible = false;
            ddlNivel.Visible = true;

            Alta = true;
            Baja = false;
            Cambio = false;

            usuario = false;
            pass = false;

            tbxUsuario.Text = "";
            tbxPassword.Text = "";

            btnAceptarCambioUsuario.Text = "Crear usuario";
            mantenerpass(false);
            #endregion
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            llenarUsuarios();
            #region Configuracion Visual
            btnAlta.BackColor = Color.White;
            btnBaja.BackColor = Color.LightSkyBlue;
            btnCambio.BackColor = Color.White;

            lblNivel.Visible = false;
            ddlUsuarios.Visible = true;
            tbxPassword.Visible = false;
            tbxUsuario.Visible = false;
            lblnContraseña.Visible = false;
            lblnUsuario.Visible = false;

            lblMensaje.Visible = false;
            lblLong.Visible = false;
            lblMay.Visible = false;
            lblUsuarioError.Visible = false;
            lblNum.Visible = false;

            lblResultado.Visible = false;
            ddlNivel.Visible = false;

            Alta = false;
            Baja = true;
            Cambio = false;

            btnAceptarCambioUsuario.Visible = false;
            Button1.Visible = true;
            Button2.Visible = false;

            usuario = false;
            pass = false;

            tbxUsuario.Text = "";
            tbxPassword.Text = "";

            btnAceptarCambioUsuario.Text = "Dar de Baja";
            mantenerpass(false);
            #endregion

        }

        protected void btnCambio_Click(object sender, EventArgs e)
        {
            llenarUsuarios();
            #region Configuracion Visual
            btnAlta.BackColor = Color.White;
            btnBaja.BackColor = Color.White;
            btnCambio.BackColor = Color.LightSkyBlue;

            ddlUsuarios.Visible = true;
            tbxPassword.Visible = true;
            tbxUsuario.Visible = false;
            lblnContraseña.Visible = true;
            lblnUsuario.Visible = false;
            lblNivel.Visible = false;

            btnAceptarCambioUsuario.Visible = false;
            Button1.Visible = false;
            Button2.Visible = true;

            lblMensaje.Visible = false;
            lblLong.Visible = false;
            lblMay.Visible = false;
            lblUsuarioError.Visible = false;
            lblNum.Visible = false;

            lblResultado.Visible = false;
            ddlNivel.Visible = false;

            Alta = false;
            Baja = false;
            Cambio = true;

            usuario = false;
            pass = false;

            tbxUsuario.Text = "";
            tbxPassword.Text = "";

            btnAceptarCambioUsuario.Text = "Cambiar datos";
            mantenerpass(false);
            #endregion

        }

        protected void tbxUsuario_TextChanged(object sender, EventArgs e)
        {
            if (Alta)
            {
                usuario = true;
                for (int i = 0; i < tbxUsuario.Text.Length; i++)
                {
                    if (tbxUsuario.Text.Substring(i,1).Equals(" "))
                    {
                        lblUsuarioError.Text = "No se permiten espacios";
                        lblUsuarioError.Visible = true;
                        usuario = false;
                        break;
                    }
                }
                if (usuario)
                {
                    ConeccionesBD Consulta = new ConeccionesBD();
                    if (Consulta.ExisteUsuario(tbxUsuario.Text))
                    {
                        lblUsuarioError.Text = "El usuario ya existe";
                        lblUsuarioError.Visible = true;
                        usuario = false;
                    }
                    else
                    {
                        if (tbxUsuario.Text.Length >=8)
                        {
                            lblUsuarioError.Text = "";
                        }
                        else
                        {
                            lblUsuarioError.Text = "Minimo 8 caracteres";
                            lblUsuarioError.Visible = true;
                            usuario = false;
                        }
                        
                    }  
                }
            }

            mantenerpass(true);
        }

        protected void tbxPassword_TextChanged(object sender, EventArgs e)
        {
            if (Alta)
            {
                pass = false;
                lblLong.Visible = true;
                lblMay.Visible = true;
                lblNum.Visible = true;
                lblMensaje.Visible = true;
                lblMay.ForeColor = Color.Red;
                lblNum.ForeColor = Color.Red;
                lblLong.ForeColor = Color.Red;
                for (int i = 0; i < tbxPassword.Text.Length; i++)
                {
                    if (Char.IsUpper(Convert.ToChar(tbxPassword.Text.Substring(i,1))))
                    {
                        lblMay.ForeColor = Color.Green;
                    }
                    if (Char.IsNumber(Convert.ToChar(tbxPassword.Text.Substring(i, 1))))
                    {
                        lblNum.ForeColor = Color.Green;
                    }
                }
                if (tbxPassword.Text.Length >= 8)
                {
                    lblLong.ForeColor = Color.Green;
                }
                if (lblLong.ForeColor == Color.Green && lblNum.ForeColor == Color.Green && lblMay.ForeColor == Color.Green)
                {
                    pass = true;
                    lblMensaje.Visible = false;
                    lblLong.Visible = false;
                    lblMay.Visible = false;
                    lblNum.Visible = false;
                }
            }
            mantenerpass(true);
        }

        protected void btnAceptarCambioUsuario_Click(object sender, EventArgs e)
        {
                tbxPassword_TextChanged(null, null);
                tbxUsuario_TextChanged(null, null);
                if (usuario && pass)
                {
                    ConeccionesBD Consultas = new ConeccionesBD();
                    Consultas.AgregraUsuario(tbxUsuario.Text, tbxPassword.Text, ddlNivel.SelectedIndex);
                    tbxUsuario.Text = "";
                    mantenerpass(false);
                    lblResultado.Text = "Usuario creado Correctamente";
                }
        }

        private void mantenerpass(bool opcion) 
        {
            if (opcion)
            {
                string Password = tbxPassword.Text;
                tbxPassword.Attributes.Add("value", Password);
            }
            else 
            {
                tbxPassword.Attributes.Add("value", "");
            }

        }

        private void llenarUsuarios() 
        {
            string cnnstring = ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString;

            string query = "select nombre_usuario From usuario";
            using (SqlConnection con = new SqlConnection(cnnstring))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    ddlUsuarios.DataSource = cmd.ExecuteReader();
                    ddlUsuarios.DataTextField = "nombre_usuario";
                    string hola = (string)Session["USUARIO"];
                    ddlUsuarios.DataBind();
                    ddlUsuarios.Items.Remove(hola);
                    con.Close();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ConeccionesBD Consultas = new ConeccionesBD();
            Consultas.EliminarUsuario(ddlUsuarios.SelectedItem.Text);
            lblResultado.Visible = true;
            lblResultado.Text = "Usuario Eliminado correctamente";
            llenarUsuarios();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            tbxPassword_TextChanged(null, null);
            if (pass)
            {
                ConeccionesBD Consultas = new ConeccionesBD();
                Consultas.CambiarUsuario(ddlUsuarios.Text, tbxPassword.Text);
                mantenerpass(false);
                lblResultado.Visible = true;
                lblResultado.Text = "Usuario modificado Correctamente";
            }
        }
    }
}