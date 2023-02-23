using BCrypt.Net;
using Healthy_Apps.Model;
using Healthy_Apps.Model.Request;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Healthy_Apps
{
    public class HealthyAppsProc
    {
        public string HealhtyApps = Startup.connectionString["connectionString:Connect"];

        #region HALAMAN LOGIN SIGN UP
        public DataTable UserSignUp(UserSignUpRequest input)
        {
            DataTable dt = new DataTable();
            string query = "sp_SignUp";
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = HealhtyApps; 
                SqlCommand command = new SqlCommand(query, connection); 
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.Add(new SqlParameter("Username", input.Username));
                command.Parameters.Add(new SqlParameter("Email", input.Email));
                command.Parameters.Add(new SqlParameter("Password", input.Password));

                connection.Open();
                var dataReader = command.ExecuteReader();
                dt.Load(dataReader);
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        public DataTable UserLogin(UserLoginRequest input)
        {
            DataTable dt = new DataTable();
            string query = "sp_Login";
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = HealhtyApps;
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("Email", input.Email));
                command.Parameters.Add(new SqlParameter("Password", input.Password));

                connection.Open();
                var dataReader = command.ExecuteReader();
                dt.Load(dataReader);
                return dt;




            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
