using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
        private string categoria;
        private Categorias categorias;
        private string comandazo;


        private enum Categorias
        {
            Nuevo,
            Total,
            Estadisticas,
        }

        public string Carrera { get => carrera; set => carrera = value; }
        public string Periodo { get => periodo; set => periodo = value; }
        public string Estilo { get => estilo; set => estilo = value; }
        public string Tipo { get => tipo; set => tipo = value; }


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

            Chart1.Series.Add("0");
            Chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;
            Chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;

            AsignacionVariables();

            switch (categorias)
            {
                case Categorias.Nuevo:
                    switch (tipo)
                    {
                        case ("SEXO POR CARRERA"):
                            if (carrera == "TODAS")
                            {
                                comandazo = "NUEVO_INGRESO_POR_SEXO";
                            }
                            else
                            {
                                comandazo = "NUEVO_INGRESO_POR_SEXO_CARRERA_ESPECIFICA";
                            }                                      
                            break;

                        case ("EDAD POR CARRERA"):

                            if (carrera == "TODAS")
                            {
                                comandazo = "NUEVO_INGRESO_POR_EDAD";
                            }
                            else
                            {
                                comandazo = "NUEVO_INGRESO_POR_EDAD_CARRERA_ESPECIFICA";
                            }
                            break;
                    }              
                    break;

                case Categorias.Total:
                    switch (tipo)
                    {
                        case ("ALUMNOS CON DISCAPACIDAD"):
                            if (carrera == "TODAS")
                            {
                                comandazo = "MATRICULA_TOTAL_DISCAPACIDAD";
                            }
                            else
                            {
                                comandazo = "MATRICULA_TOTAL_DISCAPACIDAD_CARRERA_ESPECIFICA";
                            }
                            break;

                        case ("SEXO POR CARRERA"):
                            if (carrera == "TODAS")
                            {
                                comandazo = "MATRICULA_TOTAL_POR_SEXO";
                            }
                            else
                            {
                                comandazo = "MATRICULA_TOTAL_POR_SEXO_CARRERA_ESPECIFICA";
                            }
                            break;

                        case ("EDAD POR CARRERA"):
                            if (carrera == "TODAS")
                            {
                                comandazo = "MATRICULA_TOTAL_POR_EDAD";
                            }
                            else
                            {
                                comandazo = "NUEVO_INGRESO_POR_EDAD_CARRERA_ESPECIFICA";
                            }
                            break;

                        case ("ALUMNOS POR SEMESTRE"):
                            if (carrera == "TODAS")
                            {
                                comandazo = "MATRICULA_TOTAL_SEMESTRE";
                            }
                            else
                            {
                                comandazo = "MATRICULA_TOTAL_SEMESTRE_CARRERA_ESPECIFICA";
                            }
                            break;

                        case ("MAYOR PROMEDIO POR CARRERA"):
                            if (carrera == "TODAS")
                            {
                                comandazo = "MATRICULA_TOTAL_DISCAPACIDAD";
                            }
                            else
                            {
                                comandazo = "MATRICULA_TOTAL_DISCAPACIDAD_CARRERA_ESPECIFICA";
                            }
                            break;

                        default:
                            break;
                    }
                    break;

                case Categorias.Estadisticas:



                    break;

                default:
                    break;
            }



            SqlConnection Conection = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            Conection.Open();
            SqlCommand Comando;
            Comando = new SqlCommand(comandazo, Conection);

            //        Comando = new SqlCommand("select top 5 carrera.nombre_carrera as Carrera, materias.nombre_materia as Materia, apellido_empleado +' " +
            //"'+ nombre_empleado as Maestro, id_grupo as Grupo, periodo as Periodo, reprobados as Reprobados, total_inscritos as  'Total de inscritos'," +
            //" floor((reprobados * 100) / (total_inscritos)) as 'Indice de reprobacion' from relacion_materias inner join carrera on relacion_materias.id_carrera = " +
            //"carrera.id_carrera inner join materias on  relacion_materias.id_materia = materias.id_materia " + carrera + " order by reprobados desc", Conection);

            Comando.Parameters.Add("@CARRERA", carrera);
            SqlDataAdapter Adapter_P = new SqlDataAdapter(Comando);
            Adapter_P.Fill(DS_P, "materias");
            Conection.Close();


            Graficame(DS_P);

        }

        private void Graficame(DataSet DS_P)
        {
            List<double> indice = new List<double>();
            List<double> indiceaux = new List<double>();
            List<string> materias = new List<string>();

            switch (categorias)
            {
                case Categorias.Nuevo:
                    switch (tipo)
                    {
                        case ("SEXO POR CARRERA"):
                            for (int x = 0; x < DS_P.Tables[0].Rows.Count; x++)
                            {
                                materias.Add(DS_P.Tables[0].Rows[x][0].ToString());
                                indice.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][1]));
                                indiceaux.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][2]));
                            }
                            Chart1.Legends.Add(new Legend("Def"));
                            Chart1.Series.Add("1");

                            if (estilo == "0")
                            {
                                Chart1.Series["1"].ChartType = SeriesChartType.Column;
                            }
                            else if (estilo == "1")
                            {
                                Chart1.Series["1"].ChartType = SeriesChartType.Line;
                            }


                            Chart1.Series["0"].Points.DataBindXY(materias, indice);
                            Chart1.Series["1"].Points.DataBindY(indiceaux);
                            Chart1.Series["0"].IsValueShownAsLabel = true;
                            Chart1.Series["1"].IsValueShownAsLabel = true;

                            Chart1.Series["0"].Legend = "Def";

                            Chart1.Series["0"].LegendText = "Hombres";
                            Chart1.Series["1"].LegendText = "Mujeres";

                            Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
                            Chart1.ChartAreas[0].AxisX.Interval = 1;
                            break;

                        case ("EDAD POR CARRERA"):

                            break;
                    }
                    break;

                case Categorias.Total:
                    switch (tipo)
                    {
                        case ("ALUMNOS CON DISCAPACIDAD"):

                            break;

                        case ("SEXO POR CARRERA"):

                            break;

                        case ("EDAD POR CARRERA"):

                            break;

                        case ("ALUMNOS POR SEMESTRE"):

                            break;

                        case ("MAYOR PROMEDIO POR CARRERA"):

                            break;

                        default:
                            break;
                    }
                    break;

                case Categorias.Estadisticas:



                    break;

                default:
                    break;
            }
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

        private void AsignacionVariables()
        {
            switch (categoria)
            {
                case ("NUEVO INGRESONUEVO INGRESO"):
                    categorias = Categorias.Nuevo;
                    break;

                case ("MATRICULA TOTAL"):
                    categorias = Categorias.Total;
                    break;

                case ("ESTADISTICAS"):
                    categorias = Categorias.Estadisticas;
                    break;
            }



            if (estilo == "0")
            {
                Chart1.Series["0"].ChartType = SeriesChartType.Column;
            }
            else if (estilo == "1")
            {
                Chart1.Series["0"].ChartType = SeriesChartType.Line;
            }

        }

        /* Falta que eliga el tipo de grafica.
         * Falta arreglar el query con formats.
         * Falta arreglar las peticiones.
         * Falta arreglar  el exportar.
        */
    }
}