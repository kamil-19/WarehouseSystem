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
    //ViewModel do widoku AddShipment
    public class AddShipmentViewModel : Screen
    {
        private bool IsEdit { get; set; }
        private ShipmentDTO toEdit { get; set; }

        public string ShippedItem { get; set; }
        public int ItemQuantity { get; set; }
        public string RecipientCompany { get; set; }
        public string CityTown { get; set; }
        public string PostalCode1 { get; set; }
        public string PostalCode2 { get; set; }
        public string StreetAddress { get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; }
        public string ButtonLabel { get; set; }

        public AddShipmentViewModel(ShipmentDTO shipment)
        {
            IsEdit = true;
            ButtonLabel = "Edit";
            this.toEdit = shipment;
            ShippedItem = shipment.ShippedItem;
            ItemQuantity = shipment.ItemQuantity;
            RecipientCompany = shipment.RecipientCompany;
            CityTown = shipment.CityTown;
            PostalCode1 = shipment.PostalCode.Substring(0, 2);
            PostalCode2 = shipment.PostalCode.Substring(3, 3);
            StreetAddress = shipment.StreetAddress;
            Weight = shipment.Weight;
            Description = shipment.Description;
            NotifyOfPropertyChange(() => ShippedItem);
            NotifyOfPropertyChange(() => ItemQuantity);
            NotifyOfPropertyChange(() => RecipientCompany);
            NotifyOfPropertyChange(() => CityTown);
            NotifyOfPropertyChange(() => PostalCode1);
            NotifyOfPropertyChange(() => PostalCode2);
            NotifyOfPropertyChange(() => StreetAddress);
            NotifyOfPropertyChange(() => Weight);
            NotifyOfPropertyChange(() => Description);
        }

        public AddShipmentViewModel()
        {
            IsEdit = false;
            ButtonLabel = "Add";
        }

        public void Add()
        {
            if (IsEdit == true)
            {
                toEdit.ShippedItem = ShippedItem;
                toEdit.ItemQuantity = ItemQuantity;
                toEdit.RecipientCompany = RecipientCompany;
                toEdit.CityTown = CityTown;
                toEdit.PostalCode = string.Format("{0}-{1}", PostalCode1, PostalCode2);
                toEdit.StreetAddress = StreetAddress;
                toEdit.Weight = Weight;
                toEdit.Description = Description;
                ShipmentService.Edit(toEdit);
            }
            else
            {
                var newShipment = new ShipmentDTO();
                newShipment.ShippedItem = ShippedItem;
                newShipment.ItemQuantity = ItemQuantity;
                newShipment.RecipientCompany = RecipientCompany;
                newShipment.CityTown = CityTown;
                newShipment.PostalCode = string.Format("{0}-{1}", PostalCode1, PostalCode2);
                newShipment.StreetAddress = StreetAddress;
                newShipment.Weight = Weight;
                newShipment.Description = Description;
                ShipmentService.Add(newShipment);
            }
            TryClose();
        }

        public void Close()
        {
            TryClose();
        }
    }
}