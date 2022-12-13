using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using WarehouseSystem.DTO;
using WarehouseSystem.Service;

namespace WarehouseSystem.ViewModels
{
    public class EventReadOnlyWindowViewModel : Screen
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public bool Executed { get; set; }
        public OrderDTO customOrder { get; set; }

        public EventReadOnlyWindowViewModel(EventDTO customEvent)
        {
            Name = customEvent.Name;
            Description = customEvent.Description;
            Executed = customEvent.Executed;
            if (customEvent.UserId != null)
            {
                UserDTO user = UserService.GetById(customEvent.UserId);
                UserName = user.FirstName + " " + user.LastName;
            }
            customOrder = OrderService.GetById(customEvent.OrderId);
            NotifyOfPropertyChange(() => Name);
            NotifyOfPropertyChange(() => Description);
            NotifyOfPropertyChange(() => UserName);
            NotifyOfPropertyChange(() => Executed);
        }

        public EventReadOnlyWindowViewModel()
        {
        }

        public void OpenAttachment()
        {
            IWindowManager manager = new WindowManager();
            OrderReadOnlyWindowViewModel attachment = new OrderReadOnlyWindowViewModel(customOrder);
            manager.ShowDialog(attachment, null, null);
        }

        public void Close()
        {
            TryClose();
        }
    }
}