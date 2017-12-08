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
        #region Nuevo_Ingreso
        public SEDCEdataset.NUEVO_INGRESO_POR_SEXODataTable NuevoIngresoPorSexo() 
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("NUEVO_INGRESO_POR_SEXO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SEDCEdataset.NUEVO_INGRESO_POR_SEXODataTable dt = new SEDCEdataset.NUEVO_INGRESO_POR_SEXODataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.NUEVO_INGRESO_POR_SEXO_CARRERA_ESPECIFICADataTable NuevoIngresoPorSexoCarreraEspeficica(string Carrera) 
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("NUEVO_INGRESO_POR_SEXO_CARRERA_ESPECIFICA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.Add(new SqlParameter("@CARRERA", Carrera));
            SEDCEdataset.NUEVO_INGRESO_POR_SEXO_CARRERA_ESPECIFICADataTable dt = new SEDCEdataset.NUEVO_INGRESO_POR_SEXO_CARRERA_ESPECIFICADataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.NUEVO_INGRESO_POR_EDADDataTable NuevoIngresoPorEdad()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("NUEVO_INGRESO_POR_EDAD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SEDCEdataset.NUEVO_INGRESO_POR_EDADDataTable dt = new SEDCEdataset.NUEVO_INGRESO_POR_EDADDataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.NUEVO_INGRESO_POR_EDAD_CARRERA_ESPECIFICADataTable NuevoIngresoPorEdadCarreraEspeficica(string Carrera)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("NUEVO_INGRESO_POR_EDAD_CARRERA_ESPECIFICA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.Add(new SqlParameter("@CARRERA", Carrera));
            SEDCEdataset.NUEVO_INGRESO_POR_EDAD_CARRERA_ESPECIFICADataTable dt = new SEDCEdataset.NUEVO_INGRESO_POR_EDAD_CARRERA_ESPECIFICADataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }
        #endregion

        #region Matricula_total
        public SEDCEdataset.MATRICULA_TOTAL_DISCAPACIDADDataTable MatriculaTotalDiscapacidad() 
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("MATRICULA_TOTAL_DISCAPACIDAD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SEDCEdataset.MATRICULA_TOTAL_DISCAPACIDADDataTable dt = new SEDCEdataset.MATRICULA_TOTAL_DISCAPACIDADDataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.MATRICULA_TOTAL_DISCAPACIDAD_CARRERA_ESPECIFICADataTable MatriculaTotalDiscapacidadCarreraEspecifica(string Carrera)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("MATRICULA_TOTAL_DISCAPACIDAD_CARRERA_ESPECIFICA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.Add(new SqlParameter("@CARRERA", Carrera));
            SEDCEdataset.MATRICULA_TOTAL_DISCAPACIDAD_CARRERA_ESPECIFICADataTable dt = new SEDCEdataset.MATRICULA_TOTAL_DISCAPACIDAD_CARRERA_ESPECIFICADataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.MATRICULA_TOTAL_POR_SEXODataTable MatriculaTotalSexo()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("MATRICULA_TOTAL_POR_SEXO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SEDCEdataset.MATRICULA_TOTAL_POR_SEXODataTable dt = new SEDCEdataset.MATRICULA_TOTAL_POR_SEXODataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.MATRICULA_TOTAL_POR_SEXO_CARRERA_ESPECIFICADataTable MatriculaTotalSexoCarreraEspecifica(string Carrera)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("MATRICULA_TOTAL_POR_SEXO_CARRERA_ESPECIFICA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.Add(new SqlParameter("@CARRERA", Carrera));
            SEDCEdataset.MATRICULA_TOTAL_POR_SEXO_CARRERA_ESPECIFICADataTable dt = new SEDCEdataset.MATRICULA_TOTAL_POR_SEXO_CARRERA_ESPECIFICADataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.MATRICULA_TOTAL_POR_EDADDataTable MatriculaTotalEdad()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("MATRICULA_TOTAL_POR_EDAD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SEDCEdataset.MATRICULA_TOTAL_POR_EDADDataTable dt = new SEDCEdataset.MATRICULA_TOTAL_POR_EDADDataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.MATRICULA_TOTAL_POR_EDAD_CARRERA_ESPECIFICADataTable MatriculaTotalEdadCarreraEspecifica(string Carrera)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("MATRICULA_TOTAL_POR_EDAD_CARRERA_ESPECIFICA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.Add(new SqlParameter("@CARRERA", Carrera));
            SEDCEdataset.MATRICULA_TOTAL_POR_EDAD_CARRERA_ESPECIFICADataTable dt = new SEDCEdataset.MATRICULA_TOTAL_POR_EDAD_CARRERA_ESPECIFICADataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.MATRICULA_TOTAL_SEMESTREDataTable MatriculaTotalSemestre()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("MATRICULA_TOTAL_SEMESTRE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SEDCEdataset.MATRICULA_TOTAL_SEMESTREDataTable dt = new SEDCEdataset.MATRICULA_TOTAL_SEMESTREDataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.MATRICULA_TOTAL_SEMESTRE_CARRERA_ESPECIFICADataTable MatriculaTotalSemestreCarreraEspecifica(string Carrera)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("MATRICULA_TOTAL_SEMESTRE_CARRERA_ESPECIFICA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.Add(new SqlParameter("@CARRERA", Carrera));
            SEDCEdataset.MATRICULA_TOTAL_SEMESTRE_CARRERA_ESPECIFICADataTable dt = new SEDCEdataset.MATRICULA_TOTAL_SEMESTRE_CARRERA_ESPECIFICADataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.MATRICULA_TOTAL_PROMEDIODataTable MatriculaTotalPromedio()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("MATRICULA_TOTAL_PROMEDIO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SEDCEdataset.MATRICULA_TOTAL_PROMEDIODataTable dt = new SEDCEdataset.MATRICULA_TOTAL_PROMEDIODataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.MATRICULA_TOTAL_PROMEDIO_CARRERA_ESPECIFICADataTable MatriculaTotalPromedioCarreraEspecifica(string Carrera)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("MATRICULA_TOTAL_PROMEDIO_CARRERA_ESPECIFICA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.Add(new SqlParameter("@CARRERA", Carrera));
            SEDCEdataset.MATRICULA_TOTAL_PROMEDIO_CARRERA_ESPECIFICADataTable dt = new SEDCEdataset.MATRICULA_TOTAL_PROMEDIO_CARRERA_ESPECIFICADataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.EGRESADOS_20102DataTable Egresados20102() 
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("EGRESADOS_20102", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SEDCEdataset.EGRESADOS_20102DataTable dt = new SEDCEdataset.EGRESADOS_20102DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.EGRESADOS_20111DataTable Egresados20111()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("EGRESADOS_20111", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SEDCEdataset.EGRESADOS_20111DataTable dt = new SEDCEdataset.EGRESADOS_20111DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.EGRESADOS_20112DataTable Egresados20112()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("EGRESADOS_20112", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SEDCEdataset.EGRESADOS_20112DataTable dt = new SEDCEdataset.EGRESADOS_20112DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.EGRESADOS_20121DataTable Egresados20121()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("EGRESADOS_20121", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SEDCEdataset.EGRESADOS_20121DataTable dt = new SEDCEdataset.EGRESADOS_20121DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.EGRESADOS_20122DataTable Egresados20122()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("EGRESADOS_20122", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SEDCEdataset.EGRESADOS_20122DataTable dt = new SEDCEdataset.EGRESADOS_20122DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.EGRESADOS_20131DataTable Egresados20131()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("EGRESADOS_20131", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SEDCEdataset.EGRESADOS_20131DataTable dt = new SEDCEdataset.EGRESADOS_20131DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.EGRESADOS_20132DataTable Egresados20132()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("EGRESADOS_20132", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SEDCEdataset.EGRESADOS_20132DataTable dt = new SEDCEdataset.EGRESADOS_20132DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.EGRESADOS_20141DataTable Egresados20141()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("EGRESADOS_20141", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SEDCEdataset.EGRESADOS_20141DataTable dt = new SEDCEdataset.EGRESADOS_20141DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.EGRESADOS_20142DataTable Egresados20142()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("EGRESADOS_20142", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SEDCEdataset.EGRESADOS_20142DataTable dt = new SEDCEdataset.EGRESADOS_20142DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.INDICE_DE_REPROBACION_20171DataTable IndiceReprobacion20171()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("INDICE_DE_REPROBACION_20171", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SEDCEdataset.INDICE_DE_REPROBACION_20171DataTable dt = new SEDCEdataset.INDICE_DE_REPROBACION_20171DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public SEDCEdataset.INDICE_DE_REPROBACION_20171_CARRERADataTable IndiceReprobacion20171Carrera(string Carrera)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("INDICE_DE_REPROBACION_20171_CARRERA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.Add(new SqlParameter("@CARRERA", Carrera));
            SEDCEdataset.INDICE_DE_REPROBACION_20171_CARRERADataTable dt = new SEDCEdataset.INDICE_DE_REPROBACION_20171_CARRERADataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }
        #endregion

        public bool ExisteUsuario(string usuario) 
        {
            bool Existe = false;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(@"select * from usuario where nombre_usuario = '" + usuario + "'",con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Existe = true;
            }
            con.Close();
            return Existe;
        
        
        }

        public void CambiarUsuario(string usuario,string pass) 
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(@"update usuario set contraseña_usuario = '"+pass+"' where nombre_usuario = '"+usuario+"'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void AgregraUsuario(string usuario, string contra, int nivel) 
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(@"insert into usuario values('"+ usuario + "','" + contra + "'," + nivel + ")", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void EliminarUsuario(string usuario) 
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(@"delete from usuario where nombre_usuario = '"+usuario+"'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
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
                case "ESPECIALIZACION EN INGENIERIA ELECTRONICA": resultado = "998"; break;
                case "MAESTRIA EN SISTEMAS INDUSTRIALES": resultado = "999"; break;
                case "INGENIERIA INDUSTRIAL 100% INGLES": resultado = "35"; break;
                case "LICENCIATURA EN INFORMATICA": resultado = "997"; break;
                case "MAESTRIA EN INGENIERIA ELECTRONICA": resultado = "996"; break;
            }
            return Convert.ToDouble(resultado);
        }

        public void BackUpBD(string backup)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(@"BACKUP DATABASE SEDSE TO DISK = '"+backup+"'", con);
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
            cmd.CommandText = @"TRUNCATE TABLE EGRESOS";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void ActualizarAlumnos(string FilePath)
        {
            string constr = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1;';");
            OleDbConnection Econ = new OleDbConnection(constr);
            string Query = string.Format("Select * FROM [{0}]", "ALUMNOS$");
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
            string Query = string.Format("Select * FROM [{0}]", "NUEVO_INGRESO$");
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
            string Query = string.Format("Select * FROM [{0}]", "APRO_Y_REPRO_POR_CARRERA$");
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

        public void InsertarEgresos(string FilePath) 
        {
            string constr = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1;';");
            OleDbConnection Econ = new OleDbConnection(constr);
            string Query = string.Format("Select * FROM [{0}]", "EGRESADOS$");
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
            objbulk.DestinationTableName = "egresos";
            //Mapping Table column    
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[0].ColumnName, "periodo_ingreso");
            objbulk.ColumnMappings.Add("Id_carrera", "id_carrera");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[2].ColumnName, "inscritos_generacion");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[12].ColumnName, "p20143");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[13].ColumnName, "p20151");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[14].ColumnName, "p20152");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[15].ColumnName, "p20153");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[16].ColumnName, "p20161");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[17].ColumnName, "p20162");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[18].ColumnName, "p20163");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[19].ColumnName, "p20171");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[20].ColumnName, "p20172");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[21].ColumnName, "p20173");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[22].ColumnName, "p20181");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[23].ColumnName, "p20182");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[24].ColumnName, "p20183");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[25].ColumnName, "p20191");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[26].ColumnName, "p20192");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[27].ColumnName, "p20193");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[28].ColumnName, "p20201");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[29].ColumnName, "p20202");
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[30].ColumnName, "p20203");
            //inserting Datatable Records to DataBase    
            con.Open();
            objbulk.WriteToServer(Exceldt);
            con.Close();
        }

        public void RestoreDB(string backup)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(@"USE MASTER "+
                                             "ALTER DATABASE SEDSE SET Single_User WITH Rollback Immediate "+
                                             "RESTORE DATABASE SEDSE FROM DISK = '" + backup + "' WITH REPLACE "+
                                             "ALTER DATABASE SEDSE SET Multi_User", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}