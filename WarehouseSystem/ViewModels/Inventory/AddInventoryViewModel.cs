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
    public class AddInventoryViewModel : Screen
    {
        private bool IsEdit { get; set; }
        private InventoryDTO toEdit { get; set; }

        public string ItemFrom { get; set; }
        public string ItemTo { get; set; }
        public DateTime DateOfArrival { get; set; } = DateTime.Now;
        public DateTime DateToSend { get; set; } = DateTime.Now;
        public int Weight { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string ButtonLabel { get; set; }

        public AddInventoryViewModel(InventoryDTO inventory)
        {
            IsEdit = true;
            ButtonLabel = "Edit";
            this.toEdit = inventory;

            ItemFrom = inventory.ItemFrom;
            ItemTo = inventory.ItemTo;
            DateOfArrival = inventory.DateOfArrival;
            DateToSend = inventory.DateToSend;
            Weight = inventory.Weight;
            Status = inventory.Status;
            Description = inventory.Description;

            NotifyOfPropertyChange(() => ItemFrom);
            NotifyOfPropertyChange(() => ItemTo);
            NotifyOfPropertyChange(() => DateOfArrival);
            NotifyOfPropertyChange(() => DateToSend);
            NotifyOfPropertyChange(() => Weight);
            NotifyOfPropertyChange(() => Status);
            NotifyOfPropertyChange(() => Description);
        }

        public AddInventoryViewModel()
        {
            IsEdit = false;
            ButtonLabel = "Add";
        }

        public void Add()
        {
            if (IsEdit == true)
            {
                toEdit.ItemFrom = ItemFrom;
                toEdit.ItemTo = ItemTo;
                toEdit.DateOfArrival = DateOfArrival;
                toEdit.DateToSend = DateToSend;
                toEdit.Weight = Weight;
                toEdit.Status = Status;
                toEdit.Description = Description;
                InventoryService.Edit(toEdit);
            }
            else
            {
                var newInventory = new InventoryDTO();
                newInventory.ItemFrom = ItemFrom;
                newInventory.ItemTo = ItemTo;
                newInventory.DateOfArrival = DateOfArrival;
                newInventory.DateToSend = DateToSend;
                newInventory.Weight = Weight;
                newInventory.Status = Status;
                newInventory.Description = Description;
                InventoryService.Add(newInventory);
            }
            Close();
        }

        public void Close()
        {
            TryClose();
        }
    }
}