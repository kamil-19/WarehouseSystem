using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.DTO;
using WarehouseSystem.Service;

namespace WarehouseSystem.ViewModels.Delivery
{
    public class DeliveryGridViewModel : Screen
    {
        public List<DeliveryDTO> Deliveries { get; set; } = new List<DeliveryDTO>();

        public DeliveryGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadAddDeliveryPage()
        {
            IWindowManager manager = new WindowManager();
            AddDeliveryViewModel add = new AddDeliveryViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadModifyDeliveryPage(DeliveryDTO client)
        {
            IWindowManager manager = new WindowManager();
            AddDeliveryViewModel modify = new AddDeliveryViewModel(client);
            manager.ShowDialog(modify, null, null);
            Reload();
        }

        public void Delete(DeliveryDTO client)
        {
            IWindowManager manager = new WindowManager();
            // DeleteConfirmationViewModel modify = new DeleteConfirmationViewModel();
            // bool? showDialogResult = manager.ShowDialog(modify, null, null);
            // if (showDialogResult != null && showDialogResult == true)
            // {
            DeliveryService.Delete(client);
            // }
            Reload();
        }

        public void Reload()
        {
            Deliveries = DeliveryService.GetAll();
            NotifyOfPropertyChange(() => Deliveries);
        }
    }
}