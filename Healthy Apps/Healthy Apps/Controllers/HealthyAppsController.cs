using Healthy_Apps.Model.Request;
using Healthy_Apps.Model.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                "Username: " + request.Username,
                "Email: " + request.Email,
                "Password: " + request.Password
            };
            try
            {
                if(request.Username == null || request.Username == "")
                {
                    response.Message = "Username Tidak Boleh Kosong";
                    response.MessageCode = 400;
                }
                else if(request.Email == null || request.Email == "")
                {
                    response.Message = "Email Tidak Boleh Kosong";
                    response.MessageCode = 400;
                }
                else if(request.Password == null)
                {
                    response.Message = "Password Tidak Boleh Kosong";
                    response.MessageCode = 400;
                }
                else if(request.Password.Length >= 16)
                {
                    response.Message = "Password anda terlalu panjang";
                    response.MessageCode = 400;
                }
                else
                {
                    response.data = proc.UserSignUp(request);
                    response.Message = "Success Login";
                    response.MessageCode = 200;
                }
            }
            catch
            {
                response.Message = "Gagal Login";
                response.MessageCode = 400;
            }
            return response;
        }

        [HttpPost]
        [ActionName("UserLogin")]
        public UserLoginResponse UserLogin(UserLoginRequest request)
        {
            UserLoginResponse response = new UserLoginResponse();
            HealthyAppsProc proc = new HealthyAppsProc();

            string[] body =
            {
                "Email: " + request.Email,
                "Password: " + request.Password
            };

            try
            {
                response.data = proc.UserLogin(request);
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
        //[HttpPost]
        //[ActionName("CheckUsedEmail")]


        
        //[HttpPost]
        //[ActionName("CheckUsedUsername")]

        #endregion

    }
}
