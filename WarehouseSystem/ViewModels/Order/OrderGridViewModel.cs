using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.DTO;
using WarehouseSystem.Service;

namespace WarehouseSystem.ViewModels.Order
{
    public class OrderGridViewModel : Screen
    {
        public List<OrderDTO> Orders { get; set; } = new List<OrderDTO>();

        public OrderGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadAddOrderPage()
        {
            IWindowManager manager = new WindowManager();
            AddOrderViewModel add = new AddOrderViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadModifyOrderPage(OrderDTO order)
        {
            IWindowManager manager = new WindowManager();
            AddOrderViewModel modify = new AddOrderViewModel(order);
            manager.ShowDialog(modify, null, null);
            Reload();
        }

        public void Delete(OrderDTO order)
        {
            IWindowManager manager = new WindowManager();
            OrderService.Delete(order);
            Reload();
        }

        public void Reload()
        {
            Orders = OrderService.GetAll();
            NotifyOfPropertyChange(() => Orders);
        }
    }
}