using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SEDCE
{
    public partial class Grafo : System.Web.UI.Page
    {
        string[] materias = new string[5];
        double[] indice = new double[5];

        private string carrera;
        private string periodo;
        private string estilo;
        private string tipo;

        //public string Carrera { get => carrera; set => carrera = value; }
        //public string Periodo { get => periodo; set => periodo = value; }
        //public string Estilo { get => estilo; set => estilo = value; }
        //public string Tipo { get => tipo; set => tipo = value; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USUARIO"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            carrera = Session["Carrera"].ToString();
            periodo = Session["Periodo"].ToString();
            estilo = Session["Estilo"].ToString();
            tipo = Session["Tipo"].ToString();
        }

        protected void Chart1_Load(object sender, EventArgs e)
        {
            DataSet DS_P = new DataSet();

            if (carrera != "TODAS")
            {
                carrera = "where carrera.nombre_carrera = " + "'" + carrera + "'";
            }
            else
            {
                carrera = "";
            }

            try
            {
                //SqlConnection Conection = new SqlConnection(@"Data Source=HORO\SQLEXPRESS;Initial Catalog=SEDSE; Integrated Security = true");
                SqlConnection Conection = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
                Conection.Open();
                SqlCommand Comando;
                Comando = new SqlCommand("select top 5 carrera.nombre_carrera as Carrera, materias.nombre_materia as Materia, apellido_empleado +' " +
                    "'+ nombre_empleado as Maestro, id_grupo as Grupo, periodo as Periodo, reprobados as Reprobados, total_inscritos as  'Total de inscritos'," +
                    " floor((reprobados * 100) / (total_inscritos)) as 'Indice de reprobacion' from relacion_materias inner join carrera on relacion_materias.id_carrera = " +
                    "carrera.id_carrera inner join materias on  relacion_materias.id_materia = materias.id_materia " + carrera + " order by reprobados desc", Conection);
                SqlDataAdapter Adapter_P = new SqlDataAdapter(Comando);
                Adapter_P.Fill(DS_P, "materias");
                Conection.Close();
            }
            catch (Exception)
            {
            }

            for (int x = 0; x < DS_P.Tables[0].Rows.Count; x++)
            {
                materias[x] = DS_P.Tables[0].Rows[x][1].ToString();
                indice[x] = Convert.ToDouble(DS_P.Tables[0].Rows[x][7]);
            }

            Chart1.Series[0].ChartType = SeriesChartType.Line;

            Chart1.Titles.Add("Mayor indice de reprobacion del periodo: " + periodo);

            Chart1.Series[0].Points.DataBindXY(materias, indice);
            Chart1.Series[0].IsValueShownAsLabel = true;
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                Chart1.SaveImage(Server.MapPath("/"+Chart1.Titles[0].Text.Replace(":","")+".jpg"));
                Response.AppendHeader("content-disposition", "attachment; filename= " + Server.MapPath("/" + Chart1.Titles[0].Text.Replace(":", "") + ".jpg"));
                Response.TransmitFile(Server.MapPath("/" + Chart1.Titles[0].Text.Replace(":", "") + ".jpg"));
                Response.Flush();
            }
            finally
            {
                File.Delete(Server.MapPath("/" + Chart1.Titles[0].Text.Replace(":", "") + ".jpg"));
            }
        }

        /* Falta que eliga el tipo de grafica.
         * Falta arreglar el query con formats.
         * Falta arreglar las peticiones.
         * Falta arreglar  el exportar.
        */
    }
}