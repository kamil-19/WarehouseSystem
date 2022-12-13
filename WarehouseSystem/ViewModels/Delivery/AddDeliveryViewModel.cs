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
    //ViewModel do widoku AddDelivery
    public class AddDeliveryViewModel : Screen
    {
        private bool IsEdit { get; set; }

        private DeliveryDTO toEdit { get; set; }

        public string DeliveredItem { get; set; }
        public int ItemQuantity { get; set; }
        public string RecipientCompany { get; set; }
        public string CityTown { get; set; }
        public string PostalCode1 { get; set; }
        public string PostalCode2 { get; set; }
        public string StreetAddress { get; set; }
        public int Weight { get; set; }
        public string Description { get; set; }

        public string ButtonLabel { get; set; }

        public AddDeliveryViewModel(DeliveryDTO delivery)
        {
            IsEdit = true;
            ButtonLabel = "Edit";

            this.toEdit = delivery;
            DeliveredItem = delivery.DeliveredItem;
            ItemQuantity = delivery.ItemQuantity;
            RecipientCompany = delivery.RecipientCompany;
            CityTown = delivery.CityTown;
            PostalCode1 = delivery.PostalCode.Substring(0, 2);
            PostalCode2 = delivery.PostalCode.Substring(3, 3);
            StreetAddress = delivery.StreetAddress;
            Weight = delivery.Weight;
            Description = delivery.Description;
            NotifyOfPropertyChange(() => DeliveredItem);
            NotifyOfPropertyChange(() => ItemQuantity);
            NotifyOfPropertyChange(() => RecipientCompany);
            NotifyOfPropertyChange(() => CityTown);
            NotifyOfPropertyChange(() => PostalCode1);
            NotifyOfPropertyChange(() => PostalCode2);
            NotifyOfPropertyChange(() => StreetAddress);
            NotifyOfPropertyChange(() => Weight);
            NotifyOfPropertyChange(() => Description);
        }

        public AddDeliveryViewModel()
        {
            IsEdit = false;
            ButtonLabel = "Add";
        }

        public void Add()
        {
            if (IsEdit == true)
            {
                toEdit.DeliveredItem = DeliveredItem;
                toEdit.ItemQuantity = ItemQuantity;
                toEdit.RecipientCompany = RecipientCompany;
                toEdit.CityTown = CityTown;
                toEdit.PostalCode = string.Format("{0}-{1}", PostalCode1, PostalCode2);
                toEdit.StreetAddress = StreetAddress;
                toEdit.Weight = Weight;
                toEdit.Description = Description;
                DeliveryService.Edit(toEdit);
            }
            else
            {
                var newDelivery = new DeliveryDTO();
                newDelivery.DeliveredItem = DeliveredItem;
                newDelivery.ItemQuantity = ItemQuantity;
                newDelivery.RecipientCompany = RecipientCompany;
                newDelivery.CityTown = CityTown;
                newDelivery.PostalCode = string.Format("{0}-{1}", PostalCode1, PostalCode2);
                newDelivery.StreetAddress = StreetAddress;
                newDelivery.Weight = Weight;
                newDelivery.Description = Description;
                DeliveryService.Add(newDelivery);
            }
            TryClose();
        }

        public void Close()
        {
            TryClose();
        }
    }
}