using Healthy_Apps.Model.Request;
using Healthy_Apps.Model.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Healthy_Apps.Controllers
{
    [Route("api/HealthyApps/[action]")]
    [ApiController]
    public class HealthyAppsController : ControllerBase
    {
        

        #region Halaman Pertama
        [HttpPost]
        [ActionName("UserSignUp")]
        public UserSignUpResponse UserSignup(UserSignUpRequest request)
        {
            UserSignUpResponse response = new UserSignUpResponse();
            HealthyAppsProc proc = new HealthyAppsProc();
            string[] body =
            {
                "CustomerID: " + request.CustomerID
                //"Username: " + request.Username,
                //"Email: " + request.Email,
                //"Password: " + request.Password
            };
            try
            {
                response.data = proc.UserSignUp(request);
                response.Message = "Success Login";
                response.MessageCode = 200;

                //if(request.Username == null || request.Username == "")
                //{
                //    response.Message = "Username Tidak Boleh Kosong";
                //    response.MessageCode = 400;
                //}
                //else if(request.Email == null || request.Email == "")
                //{
                //    response.Message = "Email Tidak Boleh Kosong";
                //    response.MessageCode = 400;
                //}
                //else if(request.Password == null)
                //{
                //    response.Message = "Password Tidak Boleh Kosong";
                //    response.MessageCode = 400;
                //}
                //else if(request.Password.Length >= 16)
                //{
                //    response.Message = "Password anda terlalu panjang";
                //    response.MessageCode = 400;
                //}
                //else
                //{
                //    response.data = proc.UserSignUp(request);
                //    response.Message = "Success Login";
                //    response.MessageCode = 200;
                //}
            }
            catch
            {
                response.Message = "Gagal Login";
                response.MessageCode = 400;
            }
            return response;
        }



        #endregion

        #region HALAMAN WORKOUT

        [HttpGet]
        [ActionName("Workout")]
        public ResponseGlobal Workout()
        {
            ResponseGlobal response = new ResponseGlobal();
            HealthyAppsProc proc = new HealthyAppsProc();

           



            try
            {
                response.data = proc.Workout();
                response.Message = "Success";
                response.MessageCode = 200;
                Response.Headers.Add("Access-Control-Allow-Origin", "*");
            }
            catch
            {
                response.Message = "Faield";
                response.MessageCode = 400;
            }
            return response;
        }

        [HttpPost]
        [ActionName("SaveWorkout")]
        public ResponseGlobal SaveWorkout(SaveWorkoutRequest request)
        {
            ResponseGlobal response = new ResponseGlobal();
            HealthyAppsProc proc = new HealthyAppsProc();

            string[] body =
            {
                "titleSp: " + request.title,
                "levelSp: " + request.level,
                "timeSp: " + request.time,
                "imageURLSp: " + request.imageURL,
                "categorySp: " + request.category
            };

            try
            {
                response.data = proc.SaveWorkout(request);
                response.Message = "Success";
                response.MessageCode = 200;
            }
            catch
            {
                response.Message = "Failed";
                response.MessageCode = 400;
            }
            return response;
        }



        [HttpGet]
        [ActionName("WorkoutCategoryABS")]
        public ResponseGlobal WokroutCategoryABS()
        {
            ResponseGlobal response = new ResponseGlobal();
            HealthyAppsProc proc = new HealthyAppsProc();

           
            try
            {
                response.data = proc.WokroutCategoryABS();
                response.Message = "Success";
                response.MessageCode = 200;
            }
            catch
            {
                response.Message = "Failed";
                response.MessageCode = 400;
            }
            return response;
        }

        #endregion

    }
}
