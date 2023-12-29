namespace DataModel.Models
{
    public class User
    {
        public int Userid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SecretKey { get; set; }
        public string OrganizationId { get; set; }
    }
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginResult
    {
        public string Token { get; set; }
    }
}
