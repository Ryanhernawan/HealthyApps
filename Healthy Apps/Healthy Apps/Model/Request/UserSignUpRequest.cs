using System.Globalization;

namespace Healthy_Apps.Model.Request
{
    public class UserSignUpRequest
    {
        public string CustomerID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
