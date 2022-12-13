using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.DTO;
using WarehouseSystem.Service;

namespace WarehouseSystem.ViewModels.Shipment
{
    public class ShipmentGridViewModel : Screen
    {
        public List<ShipmentDTO> Shipments { get; set; } = new List<ShipmentDTO>();

        public ShipmentGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadAddShipmentPage()
        {
            IWindowManager manager = new WindowManager();
            AddShipmentViewModel add = new AddShipmentViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadModifyShipmentPage(ShipmentDTO client)
        {
            IWindowManager manager = new WindowManager();
            AddShipmentViewModel modify = new AddShipmentViewModel(client);
            manager.ShowDialog(modify, null, null);
            Reload();
        }

        public void Delete(ShipmentDTO client)
        {
            IWindowManager manager = new WindowManager();
            ShipmentService.Delete(client);
            Reload();
        }

        public void Reload()
        {
            Shipments = ShipmentService.GetAll();
            NotifyOfPropertyChange(() => Shipments);
        }
    }
}