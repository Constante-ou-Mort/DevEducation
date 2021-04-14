using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Lesson7
{
    public class SocialNetwork 
    {
        private readonly List<User> _users = new List<User>();
        private User _currentUser;

        public SocialNetwork(User currentUser)
        {
            _currentUser = currentUser;
            _currentUser.IsLogin = true;
            AddDefaultUsers();
        }

        internal void AskMenuOptions()
        {
            WriteLine("The company welcomes you!Please choose the action:\n(R) Registration, (L) Login, (LG) Logout.");
            var userOperation = ReadLine();

            switch (userOperation?.ToLower())
            {
                case "r": Registration(); break;
                case "l": Login(); break;
                case "lg": Logout(); break;
                default: throw new ArgumentException($"Invalid operation {userOperation}.");
            }
        }

        private void Login()
        {
            if (!_currentUser.IsLogin)
            {
                WriteLine("Please, enter your login:");
                var login = ReadLine();
                if (!ValidateLogin(ref login))
                    return;

                WriteLine("Please, enter the password.");
                var password = ReadLine();
                if (!ValidatePassword(login, ref password))
                    return;

                var user = FindUser(login, password);
                user.IsLogin = true;

                _currentUser = user;

                WriteLine($"You have been successfully logged in the system as user with login {login}.");
            }
            else
                WriteLine("You are logged in the system.");
        }

        private User FindUser(string login, string password)
        {
            return _users.First(u => u.Login.Equals(login) && u.Password.Equals(password));
        }

        private bool ValidateLogin(ref string login)
        {
            while (!IsLoginExist(login))
            {
                WriteLine("Do you want try again? Y/N");
                if (ReadLine().ToLower() == "y")
                {
                    WriteLine("Please, enter your login again:");
                    login = ReadLine();
                }
                else
                    return false;
            }

            return true;
        }

        private bool IsLoginExist(string login)
        {
            var result = _users.Any(user => user.Login.Equals(login));

            if (!result)
                WriteLine($"User with login {login} does not exist in the system.");

            return result;
        }

        private bool ValidatePassword(string login, ref string password)
        {
            while (!IsPasswordCorrect(login, password))
            {
                WriteLine("Do you want try again? Y/N");
                if (ReadLine().ToLower() == "y")
                {
                    WriteLine("Please, enter your password again:");
                    password = ReadLine();
                }
                else
                    return false;
            }

            return true;
        }

        private bool IsPasswordCorrect(string login, string password)
        {
            var result = _users.First(user => user.Login.Equals(login)).Password.Equals(password);

            if (!result)
                WriteLine("Password is incorrect.");

            return result;
        }

        private void Registration()
        {
            if (!_currentUser.IsLogin)
            {
                WriteLine("Please, enter the login:");
                var login = ReadLine();

                WriteLine("Please, enter the password:");
                var password = ReadLine();

                AddUser(login, password);
            }
            else
                WriteLine("You are already logged in the system.");
        }

        private void AddUser(string login, string password)
        {
            var doesUserExist = _users.Any(u => u.Login.Equals(login));

            if (doesUserExist)
                WriteLine($"User with login {login} already exists.");
            else
            {
                var user = new User(login, password);

                _users.Add(user);

                WriteLine($"You have been successfully registered in the system as user with login {login}.");

                Login();
            }
        }

        private void Logout()
        {
            if (_currentUser.IsLogin)
            {
                WriteLine("You are successfully logout from the system.");
                _currentUser.IsLogin = false;
            }
            else
                WriteLine("You are not logged in the system.");
        }


        private void AddDefaultUsers()
        {
            _users.Add(new User("admin", "admin", Role.Admin));
            _users.Add(new User("system", "system", Role.System));
        }
    }
}