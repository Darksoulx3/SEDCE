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
        public SEDCEdataset.MATRICULA_COMPLETA_CARRERA_ESPECIFICADataTable MatriculaCompletaCarreraEspecifica(string Carrera) 
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("MATRICULA_COMPLETA_CARRERA_ESPECIFICA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.Add(new SqlParameter("@CARRERA", Carrera));
            SEDCEdataset.MATRICULA_COMPLETA_CARRERA_ESPECIFICADataTable dt = new SEDCEdataset.MATRICULA_COMPLETA_CARRERA_ESPECIFICADataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public SEDCEdataset.MATRICULA_COMPLETADataTable MatriculaCompleta() 
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("MATRICULA_COMPLETA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SEDCEdataset.MATRICULA_COMPLETADataTable dt = new SEDCEdataset.MATRICULA_COMPLETADataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
    }
}