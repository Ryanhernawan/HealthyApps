using BCrypt.Net;
using Healthy_Apps.Model;
using Healthy_Apps.Model.Request;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Healthy_Apps
{
    public class HealthyAppsProc
    {
        public string HealhtyApps = Startup.connectionString["connectionString:Connect"];
        MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=root;database=healthyapps;");

        #region HALAMAN LOGIN SIGN UP
        public DataTable UserSignUp(UserSignUpRequest input)
        {
            DataTable dt = new DataTable();
            string query = "spGetDataUser";
            MySqlConnection connection = new MySqlConnection();
            try
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CustomerID", input.CustomerID);

                conn.Open();
                var dataReader = command.ExecuteReader();
                dt.Load(dataReader);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion


        #region HALAMAN WORKOUT

        public DataTable Workout()
        {
            DataTable dt = new DataTable();
            string query = "spGetWorkout";
            try
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                command.CommandType = CommandType.StoredProcedure;

                conn.Open();
                var dataReader = command.ExecuteReader();
                dt.Load(dataReader);
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable SaveWorkout(SaveWorkoutRequest input)
        {
            DataTable dt = new DataTable();
            string query = "SpSaveWorkout";
            try
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@titleSp", input.title);
                command.Parameters.AddWithValue("@levelSp", input.level);
                command.Parameters.AddWithValue("@timeSp", input.time);
                command.Parameters.AddWithValue("@imageURlSp", input.imageURL);
                command.Parameters.AddWithValue("@categorySp", input.category);

                conn.Open();
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


        public DataTable WokroutCategoryABS()
        {
            DataTable dt = new DataTable();
            string query = "spGetWorkoutABS";
            try
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                command.CommandType = CommandType.StoredProcedure;
                
                //command.Parameters.AddWithValue("@categorySp", input.Category);

                conn.Open();
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
