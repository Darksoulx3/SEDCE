using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace SEDCE
{
    public partial class Configuraciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            #region Configuracion Visual
            btnAlta.BackColor = Color.AliceBlue;
            btnBaja.BackColor = Color.White;
            btnCambio.BackColor = Color.White;

            ddlUsuarios.Visible = false;
            tbxPassword.Visible = true;
            tbxUsuario.Visible = true;
            lblnContraseña.Visible = true;
            lblnUsuario.Visible = true;

            btnAceptarCambioUsuario.Text = "Crear usuario";
            #endregion

        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            #region Configuracion Visual
            btnAlta.BackColor = Color.White;
            btnBaja.BackColor = Color.AliceBlue;
            btnCambio.BackColor = Color.White;

            ddlUsuarios.Visible = true;
            tbxPassword.Visible = false;
            tbxUsuario.Visible = false;
            lblnContraseña.Visible = false;
            lblnUsuario.Visible = false;

            btnAceptarCambioUsuario.Text = "Dar de Baja";
            #endregion

        }

        protected void btnCambio_Click(object sender, EventArgs e)
        {
            #region Configuracion Visual
            btnAlta.BackColor = Color.White;
            btnBaja.BackColor = Color.White;
            btnCambio.BackColor = Color.AliceBlue;

            ddlUsuarios.Visible = true;
            tbxPassword.Visible = true;
            tbxUsuario.Visible = true;
            lblnContraseña.Visible = true;
            lblnUsuario.Visible = true;

            btnAceptarCambioUsuario.Text = "Cambiar datos";
            #endregion

        }
    }
}