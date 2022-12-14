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
    public class AddOrderViewModel : Screen
    {
        public string OrderItem { get; set; }
        public int ItemQuantity { get; set; }
        public string RecipientCompany { get; set; }
        public string CityTown { get; set; }
        public string PostalCode1 { get; set; }
        public string PostalCode2 { get; set; }
        public string StreetAddress { get; set; }
        public float Weight { get; set; }
        public string Description { get; set; }
        private bool IsEdit { get; set; }
        public string ButtonLabel { get; set; }
        private OrderDTO toEdit { get; set; }

        public AddOrderViewModel(OrderDTO order)
        {
            IsEdit = true;
            ButtonLabel = "Edit";
            this.toEdit = order;
            ItemQuantity = order.ItemQuantity;
            OrderItem = order.OrderItem;
            RecipientCompany = order.RecipientCompany;
            CityTown = order.CityTown;
            PostalCode1 = order.PostalCode.Substring(0, 2);
            PostalCode2 = order.PostalCode.Substring(3, 3);
            StreetAddress = order.StreetAddress;
            Weight = order.Weight;
            Description = order.Description;

            NotifyOfPropertyChange(() => ItemQuantity);
            NotifyOfPropertyChange(() => OrderItem);
            NotifyOfPropertyChange(() => RecipientCompany);
            NotifyOfPropertyChange(() => CityTown);
            NotifyOfPropertyChange(() => PostalCode1);
            NotifyOfPropertyChange(() => PostalCode2);
            NotifyOfPropertyChange(() => Weight);
            NotifyOfPropertyChange(() => CityTown);
            NotifyOfPropertyChange(() => Description);
        }

        public AddOrderViewModel()
        {
            IsEdit = false;
            ButtonLabel = "Add";
        }

        public void Add()
        {
            if (IsEdit == true)
            {
                toEdit.OrderItem = OrderItem;
                toEdit.ItemQuantity = ItemQuantity;
                toEdit.RecipientCompany = RecipientCompany;
                toEdit.CityTown = CityTown;
                toEdit.PostalCode = string.Format("{0}-{1}", PostalCode1, PostalCode2);
                toEdit.StreetAddress = StreetAddress;
                toEdit.Weight = Weight;
                toEdit.Description = Description;
                OrderService.Edit(toEdit);
            }
            else
            {
                var newOrder = new OrderDTO();
                newOrder.OrderItem = OrderItem;
                newOrder.ItemQuantity = ItemQuantity;
                newOrder.RecipientCompany = RecipientCompany;
                newOrder.CityTown = CityTown;
                newOrder.PostalCode = string.Format("{0}-{1}", PostalCode1, PostalCode2);
                newOrder.StreetAddress = StreetAddress;
                newOrder.Weight = Weight;
                newOrder.Description = Description;
                OrderService.Add(newOrder);
            }
            TryClose();
        }

        public void Close()
        {
            TryClose();
        }
    }
}