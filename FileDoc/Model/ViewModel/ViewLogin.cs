using FileDoc.Model;

namespace FileDoc.Models.ViewModel
{
    public class ViewLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
    public class ViewWebLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
    public class ViewToken
    {
        public string Token { get; set; }
        public UserModel User { get; set; }
    }
}
