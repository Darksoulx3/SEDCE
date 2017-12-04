using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SEDCE
{
    public class ConeccionesBD
    {
        public SEDCEdataset.MATRICULA_COMPLETA_CARRERA_ESPECIFICADataTable MatriculaCompletaCarreraEspecifica(string Carrera, string Periodo) 
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("MATRICULA_COMPLETA_CARRERA_ESPECIFICA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.Add(new SqlParameter("@CARRERA", Carrera));
            cmd.Parameters.Add(new SqlParameter("@PERIODO", Periodo));
            SEDCEdataset.MATRICULA_COMPLETA_CARRERA_ESPECIFICADataTable dt = new SEDCEdataset.MATRICULA_COMPLETA_CARRERA_ESPECIFICADataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public SEDCEdataset.MATRICULA_COMPLETADataTable MatriculaCompleta(string Periodo) 
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("MATRICULA_COMPLETA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.Add(new SqlParameter("@PERIODO", Periodo));
            SEDCEdataset.MATRICULA_COMPLETADataTable dt = new SEDCEdataset.MATRICULA_COMPLETADataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public SEDCEdataset.NUEVO_INGRESO_CARRERA_ESPECIFICADataTable NuevoIngresoCarreraEspecifica(string Carrera, string Periodo)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("NUEVO_INGRESO_CARRERA_ESPECIFICA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.Add(new SqlParameter("@CARRERA", Carrera));
            cmd.Parameters.Add(new SqlParameter("@PERIODO", Periodo));
            SEDCEdataset.NUEVO_INGRESO_CARRERA_ESPECIFICADataTable dt = new SEDCEdataset.NUEVO_INGRESO_CARRERA_ESPECIFICADataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public SEDCEdataset.NUEVO_INGRESODataTable NuevoIngreso(string Periodo)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("NUEVO_INGRESO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.Add(new SqlParameter("@PERIODO", Periodo));
            SEDCEdataset.NUEVO_INGRESODataTable dt = new SEDCEdataset.NUEVO_INGRESODataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public double IDCarrera(string carrera) 
        {
            string resultado = "";
            switch (carrera)
            {
                case "INGENIERIA MECANICA": resultado = "5"; break;
                case "INGENIERIA ELECTRICA": resultado = "6"; break;
                case "INGENIERIA INDUSTRIAL": resultado = "8"; break;
                case "INGENIERIA EN SISTEMAS COMPUTACIONALES": resultado = "10"; break;
                case "INGENIERIA ELECTRONICA": resultado = "11"; break;
                case "LICENCIATURA EN ADMINISTRACION": resultado = "16"; break;
                case "MAESTRIA EN ADMINISTRACION": resultado = "24"; break;
                case "MAESTRIA EN ELECTRONICA": resultado = "27"; break;
                case "MAESTRIA EN CIENCIAS DE LA COMPUTACION": resultado = "28"; break;
                case "MAESTRIA EN INGENIERIA INDUSTRIAL": resultado = "29"; break;
                case "INGENIERIA MECATRONICA": resultado = "31"; break;
                case "INGENIERIA EN GESTION EMPRESARIAL": resultado = "32"; break;
                case "INGENIERIA EN INFORMATICA": resultado = "33"; break;
                case "INGENIERIA BIOMEDICA": resultado = "34"; break;
                case "ING. IND. 100 INGLES": resultado = "35"; break;
            }
            return Convert.ToDouble(resultado);
        }
    }
}