using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
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
            con.Close();
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
            con.Close();
            return dt;
        }

        public SEDCEdataset.NUEVO_INGRESO_CARRERA_ESPECIFICADataTable NuevoIngresoCarreraEspecifica(string Carrera)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("NUEVO_INGRESO_CARRERA_ESPECIFICA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.Add(new SqlParameter("@CARRERA", Carrera));
            SEDCEdataset.NUEVO_INGRESO_CARRERA_ESPECIFICADataTable dt = new SEDCEdataset.NUEVO_INGRESO_CARRERA_ESPECIFICADataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.NUEVO_INGRESODataTable NuevoIngreso()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("NUEVO_INGRESO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SEDCEdataset.NUEVO_INGRESODataTable dt = new SEDCEdataset.NUEVO_INGRESODataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
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
                case "ING. MECANICA": resultado = "5"; break;
                case "ING. ELECTRICA": resultado = "6"; break;
                case "ING. INDUSTRIAL": resultado = "8"; break;
                case "ING. SIS. COMP.": resultado = "10"; break;
                case "ING. ELECTRONICA": resultado = "11"; break;
                case "LIC. ADMINISTRACION": resultado = "16"; break;
                case "MAESTRIA ADMON.": resultado = "24"; break;
                case "MAEST.  ELECTRONIC": resultado = "27"; break;
                case "M.EN CIENC.DE LA COM": resultado = "28"; break;
                case "M.ING.INDUSTRIAL": resultado = "29"; break;
                case "ING. MECATRONICA": resultado = "31"; break;
                case "ING. GESTION EMPRESARIAL": resultado = "32"; break;
                case "ING. EN INFORMATICA": resultado = "33"; break;
                case "ING. BIOMEDICA": resultado = "34"; break;
            }
            return Convert.ToDouble(resultado);
        }

        public void BackUpBD()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(@"BACKUP DATABASE SEDSE TO DISK = 'C:\Users\Jonathan Rodriguez\Documents\Backups\SEDSE" +
                             DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year + ".BAK'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void PrepararTablas()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(@"DROP TABLE INFO_NUEVO_INGRESO", con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"TRUNCATE TABLE ALUMNOS";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void ActualizarAlumnos(string FilePath)
        {
            string constr = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1;';");
            OleDbConnection Econ = new OleDbConnection(constr);
            string Query = string.Format("Select * FROM [{0}]", "7_enviar$");
            OleDbCommand Ecom = new OleDbCommand(Query, Econ);
            Econ.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
            Econ.Close();
            oda.Fill(ds);
            ds.Tables[0].Columns.Add(new DataColumn("Id_carrera"));
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                ds.Tables[0].Rows[i]["Id_carrera"] = IDCarrera(ds.Tables[0].Rows[i][0].ToString());
            }
            DataTable Exceldt = ds.Tables[0];

            string sqlconn = ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString;
            SqlConnection con = new SqlConnection(sqlconn);

            //creating object of SqlBulkCopy    
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name    
            objbulk.DestinationTableName = "alumnos";
            //Mapping Table column    
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[3].ColumnName, "no_control");
            objbulk.ColumnMappings.Add("Id_carrera", "id_carrera");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[2].ColumnName, "semestre");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[4].ColumnName, "apellido_paterno");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[5].ColumnName, "apellido_materno");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[6].ColumnName, "nombre_alumno");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[10].ColumnName, "promedio");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[1].ColumnName, "competencia");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[7].ColumnName, "sexo");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[8].ColumnName, "años");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[9].ColumnName, "discapacidad");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[11].ColumnName, "comunidad_indigena");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[12].ColumnName, "lengua_indigena");
            //inserting Datatable Records to DataBase    
            con.Open();
            objbulk.WriteToServer(Exceldt);
            con.Close();
        }

        public void CrearNuevoIngreso()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(@"Create Table info_nuevo_ingreso
                            (
	                            no_control varchar (255),			 /*foreign*/
	                            id_escuela_procedencia varchar(255), /*foreign*/
	                            lugar_nacimiento varchar (255)
	                            constraint fk_no_control foreign key (no_control) references alumnos (no_control),
	                            constraint fk_id_escuela_procedencia_escuela_procedencia foreign key (id_escuela_procedencia) references escuela_procedencia (clave_escuela)
                            )", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void InsertarNuevoIngreso(string FilePath)
        {
            string constr = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1;';");
            OleDbConnection Econ = new OleDbConnection(constr);
            string Query = string.Format("Select * FROM [{0}]", "NUEVO_INGRESO_20113_DETALLE$");
            OleDbCommand Ecom = new OleDbCommand(Query, Econ);
            Econ.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
            Econ.Close();
            oda.Fill(ds);
            DataTable Exceldt = ds.Tables[0];

            string sqlconn = ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString;
            SqlConnection con = new SqlConnection(sqlconn);

            //creating object of SqlBulkCopy    
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name    
            objbulk.DestinationTableName = "info_nuevo_ingreso";
            //Mapping Table column    
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[2].ColumnName, "no_control");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[8].ColumnName, "id_escuela_procedencia");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[9].ColumnName, "lugar_nacimiento");
            //inserting Datatable Records to DataBase    
            con.Open();
            objbulk.WriteToServer(Exceldt);
            con.Close();
        }

        public void InsertarMaterias(string FilePath)
        {
            string constr = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1;';");
            OleDbConnection Econ = new OleDbConnection(constr);
            string Query = string.Format("Select * FROM [{0}]", "APRO_Y_REPRO_POR_CARRERA_3$");
            OleDbCommand Ecom = new OleDbCommand(Query, Econ);
            Econ.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
            Econ.Close();
            oda.Fill(ds);
            ds.Tables[0].Columns.Add(new DataColumn("Id_carrera"));
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                ds.Tables[0].Rows[i]["Id_carrera"] = IDCarrera(ds.Tables[0].Rows[i][1].ToString());
            }
            DataTable Exceldt = ds.Tables[0];

            string sqlconn = ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString;
            SqlConnection con = new SqlConnection(sqlconn);

            //creating object of SqlBulkCopy    
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name    
            objbulk.DestinationTableName = "relacion_materias";
            //Mapping Table column    
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[9].ColumnName, "clave_area");
            objbulk.ColumnMappings.Add("Id_carrera", "id_carrera");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[2].ColumnName, "id_materia");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[3].ColumnName, "id_grupo");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[5].ColumnName, "apellido_empleado");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[6].ColumnName, "nombre_empleado");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[0].ColumnName, "periodo");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[7].ColumnName, "reprobados");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[8].ColumnName, "aprobados");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[10].ColumnName, "total_inscritos");
            //inserting Datatable Records to DataBase    
            con.Open();
            objbulk.WriteToServer(Exceldt);
            con.Close();
        }

        public void RestoreDB()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(@"USE MASTER RESTORE DATABASE SEDSE FROM DISK = 'C:\Users\Jonathan Rodriguez\Documents\Backups\SEDSE" +
                             DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year + ".BAK'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}