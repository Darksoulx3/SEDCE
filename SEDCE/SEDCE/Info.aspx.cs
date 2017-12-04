using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace SEDCE
{
    public partial class Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USUARIO"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnSubirArchivo_Click(object sender, EventArgs e)
        {
            
        }

        private void InsertExcelRecords(string FilePath)
        {
            ConeccionesBD Consultas = new ConeccionesBD();
            float Periodo = (float)Convert.ToDouble(ddlPeriodo1.SelectedItem.ToString() + ddlPeriodo2.SelectedItem.ToString());
            string constr = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1;';");
            OleDbConnection Econ = new OleDbConnection(constr);  
            string Query = string.Format("Select * FROM 7_enviar");
            OleDbCommand Ecom = new OleDbCommand(Query, Econ);
            Econ.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
            Econ.Close();
            oda.Fill(ds);
            ds.Tables[0].Columns.Add(new DataColumn("Periodo"));
            ds.Tables[0].Columns.Add(new DataColumn("Id_carrera"));
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                ds.Tables[0].Rows[i]["Periodo"] = Periodo;
                ds.Tables[0].Rows[i]["Id_carrera"] = Consultas.IDCarrera(ds.Tables[0].Rows[i][0].ToString());
            }
            DataTable Exceldt = ds.Tables[0];

            string sqlconn = ConfigurationManager.ConnectionStrings["SEDCEConString"].ConnectionString;
            SqlConnection con = new SqlConnection(sqlconn);

            //creating object of SqlBulkCopy    
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name    
            objbulk.DestinationTableName = "alumnos";
            //Mapping Table column    
            objbulk.ColumnMappings.Add(ds.Tables[0].Columns[3].ColumnName,"no_control");
            objbulk.ColumnMappings.Add("Id_carrera", "id_carrera");
            objbulk.ColumnMappings.Add("Periodo", "periodo");
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

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            string NombreArchivo = Path.Combine(Server.MapPath("~/ImportarDocumento"), Guid.NewGuid().ToString() + Path.GetExtension(fuBD.PostedFile.FileName));
            fuBD.PostedFile.SaveAs(NombreArchivo);
            InsertExcelRecords(NombreArchivo);
        }
    }
}