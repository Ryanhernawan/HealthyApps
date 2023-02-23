using System.Data;

namespace Healthy_Apps.Model.Response
{
    public class UserLoginResponse
    {
        public string Message { get; set; }
        public int MessageCode { get; set; }
        public DataTable data { get; set; }
    }
}
