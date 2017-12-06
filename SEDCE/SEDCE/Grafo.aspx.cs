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

        public string Carrera 
        { 
            get 
            {
                return carrera; 
            }
            set 
            { 
                carrera = value; 
            }
        }
        public string Periodo 
        { 
            get 
            { 
                return periodo;
            }
            set 
            {
                periodo = value; 
            }
        }
        public string Estilo 
        { 
            get 
            {
                return estilo; 
            }
            set 
            { 
                estilo = value; 
            }
        }
        public string Tipo
        {
            get
            {
                return tipo;
            }
            set
            {
                tipo = value;
            }
        }


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
            categoria = Session["Categoria"].ToString();
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
            SqlCommand Comando;
            Comando = new SqlCommand(comandazo, Conection);
            Comando.CommandType = CommandType.StoredProcedure;
            Conection.Open();

            //        Comando = new SqlCommand("select top 5 carrera.nombre_carrera as Carrera, materias.nombre_materia as Materia, apellido_empleado +' " +
            //"'+ nombre_empleado as Maestro, id_grupo as Grupo, periodo as Periodo, reprobados as Reprobados, total_inscritos as  'Total de inscritos'," +
            //" floor((reprobados * 100) / (total_inscritos)) as 'Indice de reprobacion' from relacion_materias inner join carrera on relacion_materias.id_carrera = " +
            //"carrera.id_carrera inner join materias on  relacion_materias.id_materia = materias.id_materia " + carrera + " order by reprobados desc", Conection);

            if (carrera != "TODAS")
            {
                Comando.Parameters.Add("@CARRERA", carrera);
            }


            SqlDataAdapter Adapter_P = new SqlDataAdapter(Comando);
            Adapter_P.Fill(DS_P, "materias");
            Conection.Close();


            Graficame(DS_P);

        }

        private void Graficame(DataSet DS_P)
        {
            List<double> indice = new List<double>();
            List<string> materias = new List<string>();

            switch (categorias)
            {
                case Categorias.Nuevo:
                    switch (tipo)
                    {
                        case ("SEXO POR CARRERA"):
                            List<double> indiceaux = new List<double>();

                            for (int x = 0; x < DS_P.Tables[0].Rows.Count; x++)
                            {
                                materias.Add(DS_P.Tables[0].Rows[x][0].ToString());
                                indice.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][1]));
                                indiceaux.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][2]));
                            }
                            Chart1.Legends.Add(new Legend("Def"));


                            if (estilo == "0")
                            {
                                foreach (var item in Chart1.Series)
                                {
                                    item.ChartType = SeriesChartType.Column;
                                }
                            }
                            else if (estilo == "1")
                            {
                                foreach (var item in Chart1.Series)
                                {
                                    item.ChartType = SeriesChartType.Line;
                                }
                            }

                            if (carrera == "TODAS")
                            {
                                Chart1.Series.Add("1");

                                Chart1.Series["0"].Points.DataBindXY(materias, indice);
                                Chart1.Series["1"].Points.DataBindY(indiceaux);

                                Chart1.Series["0"].Legend = "Def";

                                Chart1.Series[0].IsValueShownAsLabel = true;
                                Chart1.Series[1].IsValueShownAsLabel = true;

                                Chart1.Series["0"].LegendText = "Hombres";
                                Chart1.Series["1"].LegendText = "Mujeres";

                                Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
                                Chart1.ChartAreas[0].AxisX.Interval = 1;
                            }
                            else
                            {
                                Chart1.Series[0].IsValueShownAsLabel = true;
                                Chart1.Series[0].LegendText = carrera;
                                Chart1.Series[0].Points.AddXY("Hombres", indice[0]);
                                Chart1.Series[0].Points.AddXY("Mujeres", indiceaux[0]);
                            }

                            if (estilo == "0")
                            {
                                foreach (var item in Chart1.Series)
                                {
                                    item.ChartType = SeriesChartType.Column;
                                }
                            }
                            else if (estilo == "1")
                            {
                                foreach (var item in Chart1.Series)
                                {
                                    item.ChartType = SeriesChartType.Line;
                                }
                            }

                            break;

                        case ("EDAD POR CARRERA"):
                            List<double> indiceaux1 = new List<double>();
                            List<double> indiceaux2 = new List<double>();
                            List<double> indiceaux3 = new List<double>();
                            List<double> indiceaux4 = new List<double>();
                            List<double> indiceaux5 = new List<double>();
                            List<double> indiceaux6 = new List<double>();
                            List<double> indiceaux7 = new List<double>();
                            List<double> indiceaux8 = new List<double>();
                            List<double> indiceaux9 = new List<double>();
                            List<double> indiceaux10 = new List<double>();
                            List<double> indiceaux11 = new List<double>();
                            List<double> indiceaux12 = new List<double>();
                            List<double> indiceaux13 = new List<double>();
                            for (int x = 0; x < DS_P.Tables[0].Rows.Count; x++)
                            {
                                materias.Add(DS_P.Tables[0].Rows[x][0].ToString());
                                indice.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][1]));
                                indiceaux1.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][2]));
                                indiceaux2.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][3]));
                                indiceaux3.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][4]));
                                indiceaux4.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][5]));
                                indiceaux5.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][6]));
                                indiceaux6.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][7]));
                                indiceaux7.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][8]));
                                indiceaux8.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][9]));
                                indiceaux9.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][10]));
                                indiceaux10.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][11]));
                            }
                            Chart1.Legends.Add(new Legend("Def"));




                            if (carrera != "TODAS")
                            {
                                foreach (var item in Chart1.Series)
                                {
                                    item.IsValueShownAsLabel = true;
                                }
                                Chart1.Series[0].LegendText = carrera;
                                Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
                                Chart1.ChartAreas[0].AxisX.Interval = 1;

                                Chart1.Series[0].Points.AddXY("16 años", indice[0]);
                                Chart1.Series[0].Points.AddXY("17 años", indiceaux1[0]);
                                Chart1.Series[0].Points.AddXY("18 años", indiceaux2[0]);
                                Chart1.Series[0].Points.AddXY("19 años", indiceaux3[0]);
                                Chart1.Series[0].Points.AddXY("20 años", indiceaux4[0]);
                                Chart1.Series[0].Points.AddXY("21 años", indiceaux5[0]);
                                Chart1.Series[0].Points.AddXY("22 años", indiceaux6[0]);
                                Chart1.Series[0].Points.AddXY("23 años", indiceaux7[0]);
                                Chart1.Series[0].Points.AddXY("24 años", indiceaux8[0]);
                                Chart1.Series[0].Points.AddXY("25+ años", indiceaux9[0]);

                            }
                            else
                            {
                                Chart1.Series.Add("1");
                                Chart1.Series.Add("2");
                                Chart1.Series.Add("3");
                                Chart1.Series.Add("4");
                                Chart1.Series.Add("5");
                                Chart1.Series.Add("6");
                                Chart1.Series.Add("7");
                                Chart1.Series.Add("8");
                                Chart1.Series.Add("9");

                                Chart1.Series[0].Points.DataBindXY(materias, indice);
                                Chart1.Series[1].Points.DataBindXY(materias, indiceaux1);
                                Chart1.Series[2].Points.DataBindXY(materias, indiceaux2);
                                Chart1.Series[4].Points.DataBindXY(materias, indiceaux3);
                                Chart1.Series[5].Points.DataBindXY(materias, indiceaux4);
                                Chart1.Series[6].Points.DataBindXY(materias, indiceaux5);
                                Chart1.Series[7].Points.DataBindXY(materias, indiceaux6);
                                Chart1.Series[8].Points.DataBindXY(materias, indiceaux7);
                                Chart1.Series[9].Points.DataBindXY(materias, indiceaux8);


                                Chart1.Series[0].Legend = "Def";

                                Chart1.Series[0].LegendText = "16 Años";
                                Chart1.Series[1].LegendText = "17 Años";
                                Chart1.Series[2].LegendText = "18 Años";
                                Chart1.Series[3].LegendText = "19 Años";
                                Chart1.Series[4].LegendText = "20 Años";
                                Chart1.Series[5].LegendText = "21 Años";
                                Chart1.Series[6].LegendText = "22 Años";
                                Chart1.Series[7].LegendText = "23 Años";
                                Chart1.Series[8].LegendText = "24 Años";
                                Chart1.Series[9].LegendText = "25+ Años";

                                Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
                                Chart1.ChartAreas[0].AxisX.Interval = 1;
                            }

                            if (estilo == "0")
                            {
                                foreach (var item in Chart1.Series)
                                {
                                    item.ChartType = SeriesChartType.Column;
                                }
                            }
                            else if (estilo == "1")
                            {
                                foreach (var item in Chart1.Series)
                                {
                                    item.ChartType = SeriesChartType.Line;
                                }
                            }

                            break;
                    }
                    break;

                case Categorias.Total:
                    switch (tipo)
                    {
                        case ("SEXO POR CARRERA"):
                            List<double> indiceaux = new List<double>();

                            for (int x = 0; x < DS_P.Tables[0].Rows.Count; x++)
                            {
                                materias.Add(DS_P.Tables[0].Rows[x][0].ToString());
                                indice.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][1]));
                                indiceaux.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][2]));
                            }
                            Chart1.Legends.Add(new Legend("Def"));


                            if (estilo == "0")
                            {
                                foreach (var item in Chart1.Series)
                                {
                                    item.ChartType = SeriesChartType.Column;
                                }
                            }
                            else if (estilo == "1")
                            {
                                foreach (var item in Chart1.Series)
                                {
                                    item.ChartType = SeriesChartType.Line;
                                }
                            }

                            if (carrera == "TODAS")
                            {
                                Chart1.Series.Add("1");

                                Chart1.Series["0"].Points.DataBindXY(materias, indice);
                                Chart1.Series["1"].Points.DataBindY(indiceaux);

                                Chart1.Series["0"].Legend = "Def";

                                Chart1.Series[0].IsValueShownAsLabel = true;
                                Chart1.Series[1].IsValueShownAsLabel = true;

                                Chart1.Series["0"].LegendText = "Hombres";
                                Chart1.Series["1"].LegendText = "Mujeres";

                                Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
                                Chart1.ChartAreas[0].AxisX.Interval = 1;
                            }
                            else
                            {
                                Chart1.Series[0].IsValueShownAsLabel = true;
                                Chart1.Series[0].LegendText = carrera;
                                Chart1.Series[0].Points.AddXY("Hombres", indice[0]);
                                Chart1.Series[0].Points.AddXY("Mujeres", indiceaux[0]);
                            }

                            if (estilo == "0")
                            {
                                foreach (var item in Chart1.Series)
                                {
                                    item.ChartType = SeriesChartType.Column;
                                }
                            }
                            else if (estilo == "1")
                            {
                                foreach (var item in Chart1.Series)
                                {
                                    item.ChartType = SeriesChartType.Line;
                                }
                            }
                            break;

                        case ("EDAD POR CARRERA"):
                            List<double> indiceaux1 = new List<double>();
                            List<double> indiceaux2 = new List<double>();
                            List<double> indiceaux3 = new List<double>();
                            List<double> indiceaux4 = new List<double>();
                            List<double> indiceaux5 = new List<double>();
                            List<double> indiceaux6 = new List<double>();
                            List<double> indiceaux7 = new List<double>();
                            List<double> indiceaux8 = new List<double>();
                            List<double> indiceaux9 = new List<double>();
                            List<double> indiceaux10 = new List<double>();
                            List<double> indiceaux11 = new List<double>();
                            List<double> indiceaux12 = new List<double>();
                            List<double> indiceaux13 = new List<double>();
                            for (int x = 0; x < DS_P.Tables[0].Rows.Count; x++)
                            {
                                materias.Add(DS_P.Tables[0].Rows[x][0].ToString());
                                indice.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][1]));
                                indiceaux1.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][2]));
                                indiceaux2.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][3]));
                                indiceaux3.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][4]));
                                indiceaux4.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][5]));
                                indiceaux5.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][6]));
                                indiceaux6.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][7]));
                                indiceaux7.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][8]));
                                indiceaux8.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][9]));
                                indiceaux9.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][10]));
                                indiceaux10.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][11]));
                            }
                            Chart1.Legends.Add(new Legend("Def"));




                            if (carrera != "TODAS")
                            {
                                foreach (var item in Chart1.Series)
                                {
                                    item.IsValueShownAsLabel = true;
                                }
                                Chart1.Series[0].LegendText = carrera;
                                Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
                                Chart1.ChartAreas[0].AxisX.Interval = 1;

                                Chart1.Series[0].Points.AddXY("16 años", indice[0]);
                                Chart1.Series[0].Points.AddXY("17 años", indiceaux1[0]);
                                Chart1.Series[0].Points.AddXY("18 años", indiceaux2[0]);
                                Chart1.Series[0].Points.AddXY("19 años", indiceaux3[0]);
                                Chart1.Series[0].Points.AddXY("20 años", indiceaux4[0]);
                                Chart1.Series[0].Points.AddXY("21 años", indiceaux5[0]);
                                Chart1.Series[0].Points.AddXY("22 años", indiceaux6[0]);
                                Chart1.Series[0].Points.AddXY("23 años", indiceaux7[0]);
                                Chart1.Series[0].Points.AddXY("24 años", indiceaux8[0]);
                                Chart1.Series[0].Points.AddXY("25+ años", indiceaux9[0]);

                            }
                            else
                            {
                                Chart1.Series.Add("1");
                                Chart1.Series.Add("2");
                                Chart1.Series.Add("3");
                                Chart1.Series.Add("4");
                                Chart1.Series.Add("5");
                                Chart1.Series.Add("6");
                                Chart1.Series.Add("7");
                                Chart1.Series.Add("8");
                                Chart1.Series.Add("9");

                                Chart1.Series[0].Points.DataBindXY(materias, indice);
                                Chart1.Series[1].Points.DataBindXY(materias, indiceaux1);
                                Chart1.Series[2].Points.DataBindXY(materias, indiceaux2);
                                Chart1.Series[4].Points.DataBindXY(materias, indiceaux3);
                                Chart1.Series[5].Points.DataBindXY(materias, indiceaux4);
                                Chart1.Series[6].Points.DataBindXY(materias, indiceaux5);
                                Chart1.Series[7].Points.DataBindXY(materias, indiceaux6);
                                Chart1.Series[8].Points.DataBindXY(materias, indiceaux7);
                                Chart1.Series[9].Points.DataBindXY(materias, indiceaux8);


                                Chart1.Series[0].Legend = "Def";

                                Chart1.Series[0].LegendText = "16 Años";
                                Chart1.Series[1].LegendText = "17 Años";
                                Chart1.Series[2].LegendText = "18 Años";
                                Chart1.Series[3].LegendText = "19 Años";
                                Chart1.Series[4].LegendText = "20 Años";
                                Chart1.Series[5].LegendText = "21 Años";
                                Chart1.Series[6].LegendText = "22 Años";
                                Chart1.Series[7].LegendText = "23 Años";
                                Chart1.Series[8].LegendText = "24 Años";
                                Chart1.Series[9].LegendText = "25+ Años";

                                Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
                                Chart1.ChartAreas[0].AxisX.Interval = 1;
                            }

                            if (estilo == "0")
                            {
                                foreach (var item in Chart1.Series)
                                {
                                    item.ChartType = SeriesChartType.Column;
                                }
                            }
                            else if (estilo == "1")
                            {
                                foreach (var item in Chart1.Series)
                                {
                                    item.ChartType = SeriesChartType.Line;
                                }
                            }
                            break;

                        case ("ALUMNOS POR SEMESTRE"):
                            indiceaux1 = new List<double>();
                            indiceaux2 = new List<double>();
                            indiceaux3 = new List<double>();
                            indiceaux4 = new List<double>();
                            indiceaux5 = new List<double>();
                            indiceaux6 = new List<double>();
                            indiceaux7 = new List<double>();
                            indiceaux8 = new List<double>();
                            indiceaux9 = new List<double>();
                            indiceaux10 = new List<double>();
                            indiceaux11 = new List<double>();
                            indiceaux12 = new List<double>();
                            indiceaux13 = new List<double>();
                            for (int x = 0; x < DS_P.Tables[0].Rows.Count; x++)
                            {
                                materias.Add(DS_P.Tables[0].Rows[x][0].ToString());
                                indice.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][1]));
                                indiceaux1.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][2]));
                                indiceaux2.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][3]));
                                indiceaux3.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][4]));
                                indiceaux4.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][5]));
                                indiceaux5.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][6]));
                                indiceaux6.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][7]));
                                indiceaux7.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][8]));
                                indiceaux8.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][9]));
                                indiceaux9.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][10]));
                                indiceaux10.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][11]));
                                indiceaux11.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][12]));
                                indiceaux12.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][13]));
                                indiceaux13.Add(Convert.ToDouble(DS_P.Tables[0].Rows[x][14]));
                            }
                            Chart1.Legends.Add(new Legend("Def"));

                            if (carrera == "TODAS")
                            {
                                Chart1.Series.Add("1");
                                Chart1.Series.Add("2");
                                Chart1.Series.Add("3");
                                Chart1.Series.Add("4");
                                Chart1.Series.Add("5");
                                Chart1.Series.Add("6");
                                Chart1.Series.Add("7");
                                Chart1.Series.Add("8");
                                Chart1.Series.Add("9");
                                Chart1.Series.Add("10");
                                Chart1.Series.Add("11");
                                Chart1.Series.Add("12");

                                Chart1.Series[0].Points.DataBindXY(materias, indice);
                                Chart1.Series[1].Points.DataBindY(indiceaux1);
                                Chart1.Series[2].Points.DataBindY(indiceaux2);
                                Chart1.Series[4].Points.DataBindY(indiceaux3);
                                Chart1.Series[5].Points.DataBindY(indiceaux4);
                                Chart1.Series[6].Points.DataBindY(indiceaux5);
                                Chart1.Series[7].Points.DataBindY(indiceaux6);
                                Chart1.Series[8].Points.DataBindY(indiceaux7);
                                Chart1.Series[9].Points.DataBindY(indiceaux8);
                                Chart1.Series[10].Points.DataBindY(indiceaux9);
                                Chart1.Series[11].Points.DataBindY(indiceaux10);
                                Chart1.Series[12].Points.DataBindY(indiceaux11);

                                Chart1.Series[0].Legend = "Def";

                                Chart1.Series[0].LegendText = "Semestre 1";
                                Chart1.Series[1].LegendText = "Semestre 2";
                                Chart1.Series[2].LegendText = "Semestre 3";
                                Chart1.Series[3].LegendText = "Semestre 4";
                                Chart1.Series[4].LegendText = "Semestre 5";
                                Chart1.Series[5].LegendText = "Semestre 6";
                                Chart1.Series[6].LegendText = "Semestre 7";
                                Chart1.Series[7].LegendText = "Semestre 8";
                                Chart1.Series[8].LegendText = "Semestre 9";
                                Chart1.Series[9].LegendText = "Semestre 10";
                                Chart1.Series[10].LegendText = "Semestre 11";
                                Chart1.Series[11].LegendText = "Semestre 12";
                                Chart1.Series[12].LegendText = "Semestre 13";
                            }
                            else
                            {
                                foreach (var item in Chart1.Series)
                                {
                                    item.IsValueShownAsLabel = true;
                                }
                                Chart1.Series[0].LegendText = carrera;
                                Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
                                Chart1.ChartAreas[0].AxisX.Interval = 1;

                                Chart1.Series[0].Points.AddXY("Semestre 1", indice[0]);
                                Chart1.Series[0].Points.AddXY("Semestre 2", indiceaux1[0]);
                                Chart1.Series[0].Points.AddXY("Semestre 3", indiceaux2[0]);
                                Chart1.Series[0].Points.AddXY("Semestre 4", indiceaux3[0]);
                                Chart1.Series[0].Points.AddXY("Semestre 5", indiceaux4[0]);
                                Chart1.Series[0].Points.AddXY("Semestre 6", indiceaux5[0]);
                                Chart1.Series[0].Points.AddXY("Semestre 7", indiceaux6[0]);
                                Chart1.Series[0].Points.AddXY("Semestre 8", indiceaux7[0]);
                                Chart1.Series[0].Points.AddXY("Semestre 9", indiceaux8[0]);
                                Chart1.Series[0].Points.AddXY("Semestre 10", indiceaux9[0]);
                                Chart1.Series[0].Points.AddXY("Semestre 11", indiceaux10[0]);
                                Chart1.Series[0].Points.AddXY("Semestre 12", indiceaux11[0]);
                                Chart1.Series[0].Points.AddXY("Semestre 13", indiceaux12[0]);
                            }



                            if (estilo == "0")
                            {
                                foreach (var item in Chart1.Series)
                                {
                                    item.ChartType = SeriesChartType.Column;
                                }
                            }
                            else if (estilo == "1")
                            {
                                foreach (var item in Chart1.Series)
                                {
                                    item.ChartType = SeriesChartType.Line;
                                }
                            }




                            Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
                            Chart1.ChartAreas[0].AxisX.Interval = 1;
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
            Chart1.Titles.Add(tipo);
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                Chart1.SaveImage(Server.MapPath("/" + Chart1.Titles[0].Text.Replace(":", "") + ".jpg"));
                Response.AppendHeader("content-disposition", "attachment; filename= " + Chart1.Titles[0].Text.Replace(":", "") + ".jpg");
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
                case ("NUEVO INGRESO"):
                    categorias = Categorias.Nuevo;
                    break;

                case ("MATRICULA TOTAL"):
                    categorias = Categorias.Total;
                    break;

                case ("ESTADISTICAS"):
                    categorias = Categorias.Estadisticas;
                    break;
            }

        }

        /* Falta que eliga el tipo de grafica.
         * Falta arreglar el query con formats.
         * Falta arreglar las peticiones.
         * Falta arreglar  el exportar.
        */
    }
}