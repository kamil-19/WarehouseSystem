using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.DTO;
using WarehouseSystem.Service;

namespace WarehouseSystem.ViewModels.User
{
    public class UserGridViewModel : Screen
    {
        public List<UserDTO> Users { get; set; } = new List<UserDTO>();

        public UserGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadAddUserPage()
        {
            IWindowManager manager = new WindowManager();
            AddUserViewModel add = new AddUserViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadModifyUserPage(UserDTO user)
        {
            IWindowManager manager = new WindowManager();
            AddUserViewModel modify = new AddUserViewModel(user);
            manager.ShowDialog(modify, null, null);
            Reload();
        }

        public void Delete(UserDTO user)
        {
            IWindowManager manager = new WindowManager();
            // DeleteConfirmationViewModel modify = new DeleteConfirmationViewModel();
            // bool? showDialogResult = manager.ShowDialog(modify, null, null);
            // if (showDialogResult != null && showDialogResult == true)
            // {
            UserService.Delete(user);
            // }
            Reload();
        }

        public void Reload()
        {
            Users = UserService.GetAll();
            NotifyOfPropertyChange(() => Users);
        }
    }
}