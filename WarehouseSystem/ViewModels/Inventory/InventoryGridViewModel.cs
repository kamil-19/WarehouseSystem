using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.DTO;
using WarehouseSystem.Service;

namespace WarehouseSystem.ViewModels.Inventory
{
    public class InventoryGridViewModel : Screen
    {
        public List<InventoryDTO> Inventories { get; set; } = new List<InventoryDTO>();

        public InventoryGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadAddInventoryPage()
        {
            IWindowManager manager = new WindowManager();
            AddInventoryViewModel add = new AddInventoryViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadModifyInventoryPage(InventoryDTO ret)
        {
            IWindowManager manager = new WindowManager();
            AddInventoryViewModel modify = new AddInventoryViewModel(ret);
            manager.ShowDialog(modify, null, null);
            Reload();
        }

        public void Delete(InventoryDTO ret)
        {
            IWindowManager manager = new WindowManager();
            InventoryService.Delete(ret);
            Reload();
        }

        public void Reload()
        {
            Inventories = InventoryService.GetAll();
            NotifyOfPropertyChange(() => Inventories);
        }
    }
}