using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Threading.Tasks;
using WarehouseSystem.DTO;
using WarehouseSystem.Service;
using WarehouseSystem.Authentication;

namespace WarehouseSystem.ViewModels
{
    public class LogInViewModel : Screen
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LogInViewModel()
        {
        }

        public void LogIn(string username, string password)
        {
            var loggedUser = UserService.GetByUserName(username, password);
            if (loggedUser != null)
            {
                if (loggedUser.UserName == "admin")
                {
                    Authentication.Authentication.Instance.Username = loggedUser.FirstName;
                    Authentication.Authentication.Instance.isLogged = true;
                    Authentication.Authentication.Instance.isAdmin = true;
                    TryClose(true);
                }
                else if (!string.IsNullOrEmpty(Username))
                {
                    Authentication.Authentication.Instance.Username = loggedUser.FirstName + " " + loggedUser.LastName;
                    Authentication.Authentication.Instance.isLogged = true;
                    Authentication.Authentication.Instance.isAdmin = false;
                    TryClose(true);
                }
                Authentication.Authentication.Instance.User = loggedUser;
            }
            else
            {
            }
        }

        public static bool LogOut()
        {
            if (Authentication.Authentication.Instance.isLogged)
            {
                Authentication.Authentication.Instance.Username = string.Empty;
                Authentication.Authentication.Instance.isLogged = false;
                Authentication.Authentication.Instance.isAdmin = false;
                Authentication.Authentication.Instance.User = null;
                return true;
            }
            return false;
        }

        public void Close()
        {
            TryClose();
        }
    }
}