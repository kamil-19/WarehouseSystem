using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.DTO;
using WarehouseSystem.Service;

namespace WarehouseSystem.ViewModels.Client
{
    public class ClientGridViewModel : Screen
    {
        public List<ClientDTO> Clients { get; set; } = new List<ClientDTO>();

        public ClientGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadAddClietntPage()
        {
            IWindowManager manager = new WindowManager();
            AddClientViewModel add = new AddClientViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadModifyClientPage(ClientDTO client)
        {
            IWindowManager manager = new WindowManager();
            AddClientViewModel modify = new AddClientViewModel(client);
            manager.ShowDialog(modify, null, null);
            Reload();
        }

        public void Delete(ClientDTO client)
        {
            IWindowManager manager = new WindowManager();
            // DeleteConfirmationViewModel modify = new DeleteConfirmationViewModel();
            // bool? showDialogResult = manager.ShowDialog(modify, null, null);
            // if (showDialogResult != null && showDialogResult == true)
            // {
            ClientService.Delete(client);
            // }
            Reload();
        }

        public void Reload()
        {
            Clients = ClientService.GetAll();
            NotifyOfPropertyChange(() => Clients);
        }
    }
}