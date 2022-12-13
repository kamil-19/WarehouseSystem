using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using WarehouseSystem.DTO;
using WarehouseSystem.Service;

namespace WarehouseSystem.ViewModels
{
    public class AddEventViewModel : Screen
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Executed { get; set; }
        private bool IsEdit { get; set; }
        public string ButtonLabel { get; set; }
        private EventDTO toEdit { get; set; }

        public ObservableCollection<UserDTO> Users
        {
            get
            {
                return new BindableCollection<UserDTO>(UserService.GetAll());
            }
        }

        public BindableCollection<OrderDTO> Orders
        {
            get
            {
                return new BindableCollection<OrderDTO>(OrderService.GetAll());
            }
        }

        private OrderDTO _selectedOrder;
        private UserDTO _selectedUser;

        public UserDTO SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (value != null)
                {
                    _selectedUser = value;
                    NotifyOfPropertyChange(() => SelectedUser);
                }
            }
        }

        public OrderDTO SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                NotifyOfPropertyChange(() => SelectedOrder);
            }
        }

        public AddEventViewModel(EventDTO customEvent)
        {
            IsEdit = true;
            ButtonLabel = "Edit";
            this.toEdit = customEvent;
            Name = customEvent.Name;
            Description = customEvent.Description;
            Executed = customEvent.Executed;
            if (customEvent.UserId != null)
            {
                SelectedUser = UserService.GetById(customEvent.UserId);
            }

            SelectedOrder = OrderService.GetById(customEvent.OrderId);
            SelectedOrder.Id = customEvent.OrderId;

            NotifyOfPropertyChange(() => Name);
            NotifyOfPropertyChange(() => Description);
            NotifyOfPropertyChange(() => Executed);
            NotifyOfPropertyChange(() => SelectedUser);
            NotifyOfPropertyChange(() => Description);
            NotifyOfPropertyChange(() => SelectedOrder);
        }

        public AddEventViewModel()
        {
            IsEdit = false;
            ButtonLabel = "Add";
        }

        public void Add()
        {
            if (IsEdit == true)
            {
                toEdit.Name = Name;
                toEdit.Description = Description;
                if (SelectedUser != null)
                {
                    toEdit.UserId = SelectedUser.Id;
                }
                toEdit.OrderId = SelectedOrder.Id;
                toEdit.Executed = Executed;
                EventService.Edit(toEdit);
            }
            else
            {
                var newEvent = new EventDTO();
                newEvent.Name = Name;
                newEvent.Description = Description;
                if (SelectedUser != null)
                {
                    newEvent.UserId = SelectedUser.Id;
                }
                newEvent.OrderId = SelectedOrder.Id;
                newEvent.Executed = Executed;
                EventService.Add(newEvent);
            }
            TryClose();
        }

        public void Close()
        {
            TryClose();
        }
    }
}