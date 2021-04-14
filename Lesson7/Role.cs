using System;

namespace Lesson7
{
    public enum Role
    {
        Buy = 1,
        Admin = 1,
        System = 2,
        User = 3
    }

    public class UserServices
    {
        public void Create(User user)
        {
            UserMapper.FillRequiredFields(user);
            var login = user.Login; // temp31032021441212123123
            var pass = user.Password; //123qwe
            
            //api requs
        }
    }

    public static class UserMapper
    {
        public static void FillRequiredFields(User user)
        {
            user.Login ??= "temp" + DateTime.Now.ToString("ddMMyyyymmHHssff");
            user.Password ??= "123qwe";
        }
    }
}