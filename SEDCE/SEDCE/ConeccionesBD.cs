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
    }
}