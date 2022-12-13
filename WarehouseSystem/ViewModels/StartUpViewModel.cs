using Caliburn.Micro;
using WarehouseSystem.Models;
using WarehouseSystem.ViewModels.Client;
using WarehouseSystem.ViewModels.Delivery;
using WarehouseSystem.ViewModels.Employee;
using WarehouseSystem.ViewModels.Equipment;
using WarehouseSystem.ViewModels.Inventory;
using WarehouseSystem.ViewModels.Order;
using WarehouseSystem.ViewModels.Return;
using WarehouseSystem.ViewModels.Shipment;
using WarehouseSystem.ViewModels.User;
using WarehouseSystem.ViewModels.Event;
using WarehouseSystem.ViewModels.EventReadOnly;
using System.Windows;

namespace WarehouseSystem.ViewModels
{
    public class StartUpViewModel : Conductor<object>
    {
        private readonly WarehouseSystemContext context = new WarehouseSystemContext();

        public Authentication.Authentication LoggedUser { get; set; }

        public StartUpViewModel()
        {
            LogInOut = "Log in";
            LoggedUser = Authentication.Authentication.Instance;
            LoggedUserName = LoggedUser.Username;
        }

        protected override void OnViewLoaded(object view)
        {
            if (!context.Database.Exists())
            {
                IWindowManager manager = new WindowManager();
                DBInitializationViewModel dbInitializingView = new DBInitializationViewModel(context);
                bool? result2 = manager.ShowDialog(dbInitializingView, null, null);
            }

            IWindowManager manager2 = new WindowManager();
            LogInViewModel logInView = new LogInViewModel();
            bool? result = manager2.ShowDialog(logInView, null, null);
            if (result == true)
            {
                ChangeVisibilty();
                ChangeLogInButtonContent();
                ActiveItem = new EventReadOnlyGridViewModel();
            }
            else
            {
                ActiveItem = new BlankViewModel();
            }
        }

        public Visibility IsAdmin { get; set; } = Visibility.Collapsed;
        public Visibility EventScreenVisibility { get; set; } = Visibility.Collapsed;

        public string LogInOut { get; set; }
        public string LoggedUserName { get; set; }

        public void ChangeVisibilty()
        {
            if (LoggedUser.isLogged)
            {
                EventScreenVisibility = Visibility.Visible;
                if (LoggedUser.isAdmin)
                {
                    IsAdmin = Visibility.Visible;
                }
            }
            else
            {
                EventScreenVisibility = Visibility.Collapsed;
                IsAdmin = Visibility.Collapsed;
            }
            NotifyOfPropertyChange(() => IsAdmin);
            NotifyOfPropertyChange(() => EventScreenVisibility);
        }

        public void ChangeLogInButtonContent()
        {
            if (LoggedUser.isLogged)
            {
                LogInOut = "Log out";
            }
            else
                LogInOut = "Log in";

            LoggedUserName = LoggedUser.Username;
            NotifyOfPropertyChange(() => LogInOut);
            NotifyOfPropertyChange(() => LoggedUserName);
        }

        //Loading pages methods
        public void LoadClientPage()
        {
            if (LoggedUser.isAdmin) ActiveItem = new ClientGridViewModel();
        }

        public void LoadDeliveryPage()
        {
            if (LoggedUser.isAdmin) ActiveItem = new DeliveryGridViewModel();
        }

        public void LoadEmployeePage()
        {
            if (LoggedUser.isAdmin) ActiveItem = new EmployeeGridViewModel();
        }

        public void LoadEquipmentPage()
        {
            if (LoggedUser.isAdmin) ActiveItem = new EquipmentGridViewModel();
        }

        public void LoadInventoryPage()
        {
            if (LoggedUser.isAdmin) ActiveItem = new InventoryGridViewModel();
        }

        public void LoadOrderPage()
        {
            if (LoggedUser.isAdmin) ActiveItem = new OrderGridViewModel();
        }

        public void LoadReturnPage()
        {
            if (LoggedUser.isAdmin) ActiveItem = new ReturnGridViewModel();
        }

        public void LoadShipmentPage()
        {
            if (LoggedUser.isAdmin) ActiveItem = new ShipmentGridViewModel();
        }

        public void LoadUserPage()
        {
            if (LoggedUser.isAdmin) ActiveItem = new UserGridViewModel();
        }

        public void LoadEventPage()
        {
            if (LoggedUser.isAdmin) ActiveItem = new EventGridViewModel();
        }

        public void LoadEventReadOnlyPage()
        {
            ActiveItem = new EventReadOnlyGridViewModel();
        }

        public void LoadLogInPage()
        {
            if (!LoggedUser.isLogged)
            {
                IWindowManager manager = new WindowManager();
                LogInViewModel logInView = new LogInViewModel();
                bool? result = manager.ShowDialog(logInView, null, null);
                if (result == true)
                {
                    ChangeVisibilty();
                    ChangeLogInButtonContent();
                }
            }
            else
            {
                if (LogInViewModel.LogOut())
                {
                    ActiveItem = new BlankViewModel();
                    ChangeVisibilty();
                    ChangeLogInButtonContent();
                    IWindowManager manager = new WindowManager();
                    LogInViewModel logInView = new LogInViewModel();
                    bool? result = manager.ShowDialog(logInView, null, null);
                    if (result == true)
                    {
                        ChangeVisibilty();
                        ChangeLogInButtonContent();
                    }
                }
            }
        }
    }
}