namespace Lesson7
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public bool IsLogin { get; set; }

        private bool _isLogin;

        public bool GetIsLogin()
        {
            return _isLogin;
        }

        public void SetIsLogin(bool isLogin)
        {
            _isLogin = isLogin;
        }

        public User(string login, string password, Role role = Role.User)
        {
            if(login.IsNull())
            {

            }
            Login = login;
            Password = password;
            Role = role;
        }

        public User()
        {
            IsLogin = false;
        }
    }
}