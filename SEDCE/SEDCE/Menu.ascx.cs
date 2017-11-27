using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEDCE
{
    public partial class Menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USUARIO"] == null)
            {
                Menu1.Visible = false;
            }
            if (Session["USUARIO"] != null)
            {
                Menu1.Items.Remove(Menu1.FindItem("Inicio de Sesion"));
                MenuItem CERRAR = new MenuItem("Cerrar Sesion", "", "", "~/Login.aspx");
                Menu1.Items.Add(CERRAR);
                //                    Tipos de usuarios
                //        0                   1                     2
                //  Administrador           Jefe             Chico del servicio
                string Nivel = Session["NIVEL"].ToString();
                if (Nivel == "1")
                {
                    Menu1.Items.Remove(Menu1.FindItem("Configuraciones"));
                }
                else 
                {
                    if (Nivel == "2")
                    {
                        Menu1.Items.Remove(Menu1.FindItem("Configuraciones"));
                        Menu1.Items.Remove(Menu1.FindItem("Graficador"));
                        Menu1.Items.Remove(Menu1.FindItem("Reporteador"));
                        Menu1.Items.Remove(Menu1.FindItem("Carga de Archivos"));
                    }
                }
            }
        }
    }
}