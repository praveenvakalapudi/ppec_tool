using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PPECTool.Models;
using PPECTool.Models.Settings;
using PPECTool.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PPECTool.Repository.Implementations
{
    public class SampleRepository : ISampleRepository
    {
        //IConfiguration configuration;
        private readonly IOptions<DatabaseConnections> _appSettings;
        public SampleRepository(IOptions<DatabaseConnections> appSettings)
        {
            _appSettings = appSettings;
        }
        public string GetConnectionString()
        {
            string connectionString = "";
            try
            {
                //Server=tcp:hsvssouthindia.database.windows.net,1433;Initial Catalog=PPEDevelop;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;


                string server = _appSettings.Value.ServerName;
                string db = _appSettings.Value.DBName;
                string uid = _appSettings.Value.UserName;
                string pwd = _appSettings.Value.Password;
                connectionString = "Server=" + server + ";Database=" + db + ";User id=" + uid + ";Password=" + pwd + " ";
            }
            catch (Exception ex)
            {

                throw;
            }

            return connectionString;
        }
        public List<SampleModel> GetSampleRecords()
        {
            List<SampleModel> lstSampleModel = new List<SampleModel>();
            DataTable dt = new DataTable();
            try
            {
                string connectionString = GetConnectionString();
                SqlConnection conn = new SqlConnection(connectionString);
                if (conn.State != ConnectionState.Closed)
                    conn.Open();
                //INSERT
                SqlCommand command = conn.CreateCommand();
                command.CommandTimeout = 0;
                string sql = "select * from sample";
                command.CommandText = sql;
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (var i = 0; i < dt.Rows.Count; i++)
                    {
                        SampleModel objSampleModel = new SampleModel();
                        objSampleModel.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                        objSampleModel.Name = Convert.ToString(dt.Rows[i]["Name"]);
                        objSampleModel.Email = Convert.ToString(dt.Rows[i]["Email"]);
                        objSampleModel.Mobile = Convert.ToString(dt.Rows[i]["Mobile"]);
                        lstSampleModel.Add(objSampleModel);
                    }
                }

                conn.Close();
            }
            catch (Exception ex)
            {

            }
            return lstSampleModel;
        }
        public SampleModel AddSampleRecords(SampleModel obj)
        {
            List<SampleModel> lstSampleModel = new List<SampleModel>();
            DataTable dt = new DataTable();
            try
            {
                string connectionString = GetConnectionString();
                SqlConnection conn = new SqlConnection(connectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                //INSERT
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandTimeout = 0;
                string sql = "INSERT INTO Sample(Name, Email, Mobile) values(@Name, @Email, @Mobile);";
                command.CommandText = sql;
                command.Parameters.AddWithValue("@Name", obj.Name);
                command.Parameters.AddWithValue("@Email", obj.Email);
                command.Parameters.AddWithValue("@Mobile", obj.Mobile);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
            return obj;
        }
    }
}
