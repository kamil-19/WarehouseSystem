using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.DTO;
using WarehouseSystem.Service;

namespace WarehouseSystem.ViewModels
{
    public class AddUserViewModel : Screen
    {
        private bool IsEdit { get; set; }

        private UserDTO toEdit { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;

        public string ButtonLabel { get; set; }

        public AddUserViewModel(UserDTO user)
        {
            IsEdit = true;
            ButtonLabel = "Edit";

            this.toEdit = user;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            BirthDate = user.BirthDate;
            UserName = user.UserName;
            Password = user.Password;

            NotifyOfPropertyChange(() => FirstName);
            NotifyOfPropertyChange(() => LastName);
            NotifyOfPropertyChange(() => Email);
            NotifyOfPropertyChange(() => PhoneNumber);
            NotifyOfPropertyChange(() => BirthDate);
            NotifyOfPropertyChange(() => UserName);
            NotifyOfPropertyChange(() => Password);
        }

        public AddUserViewModel()
        {
            IsEdit = false;
            ButtonLabel = "Add";
        }

        public void Add()
        {
            if (IsEdit == true)
            {
                toEdit.FirstName = FirstName;
                toEdit.LastName = LastName;
                toEdit.PhoneNumber = PhoneNumber;
                toEdit.Email = Email;
                toEdit.BirthDate = BirthDate;
                toEdit.UserName = UserName;
                toEdit.Password = Password;
                UserService.Edit(toEdit);
            }
            else
            {
                var newUser = new UserDTO();
                newUser.FirstName = FirstName;
                newUser.LastName = LastName;
                newUser.PhoneNumber = PhoneNumber;
                newUser.Email = Email;
                newUser.BirthDate = BirthDate;
                newUser.UserName = UserName;
                newUser.Password = Password;
                UserService.Add(newUser);
            }
            TryClose();
        }

        public void Close()
        {
            TryClose();
        }
    }
}