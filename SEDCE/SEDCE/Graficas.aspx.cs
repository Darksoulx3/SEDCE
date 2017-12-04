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
            DataSet DS_P = new DataSet();

            try
            {
                SqlConnection Conection = new SqlConnection(@"Data Source=HORO\SQLEXPRESS;Initial Catalog=SEDSE; Integrated Security = true");
                Conection.Open();
                SqlCommand Comando;
                Comando = new SqlCommand ("select top 5 carrera.nombre_carrera as Carrera, materias.nombre_materia as Materia, apellido_empleado +' " +
                    "'+ nombre_empleado as Maestro, id_grupo as Grupo, periodo as Periodo, reprobados as Reprobados, total_inscritos as  'Total de inscritos'," +
                    " (reprobados * 100) / (total_inscritos) as 'Indice de reprobacion' from relacion_materias inner join carrera on relacion_materias.id_carrera = " +
                    "carrera.id_carrera inner join materias on  relacion_materias.id_materia = materias.id_materia order by 'Indice de reprobacion' desc", Conection);
                SqlDataAdapter Adapter_P = new SqlDataAdapter(Comando);
                Adapter_P.Fill(DS_P, "materias");
                Conection.Close();
            }
            catch (Exception)
            {
            }

        }
    }
}