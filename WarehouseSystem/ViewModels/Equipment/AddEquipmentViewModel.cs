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
    public class AddEquipmentViewModel : Screen
    {
        private bool IsEdit { get; set; }

        private EquipmentDTO ToEdit { get; set; }

        public string Type { get; set; }

        public string Mark { get; set; }

        public string Model { get; set; }

        public DateTime AddDate { get; set; } = DateTime.Now;

        public string Status { get; set; }
        public string ButtonLabel { get; set; }

        public AddEquipmentViewModel(EquipmentDTO equipment)
        {
            IsEdit = true;
            ButtonLabel = "Edit";
            this.ToEdit = equipment;
            Type = equipment.Type;
            Mark = equipment.Mark;
            Model = equipment.Model;
            AddDate = equipment.AddDate;
            Status = equipment.Status;
            NotifyOfPropertyChange(() => Type);
            NotifyOfPropertyChange(() => Mark);
            NotifyOfPropertyChange(() => Model);
            NotifyOfPropertyChange(() => AddDate);
            NotifyOfPropertyChange(() => Status);
        }

        public AddEquipmentViewModel()
        {
            IsEdit = false;
            ButtonLabel = "Add";
        }

        public void Add()
        {
            if (IsEdit == true)
            {
                ToEdit.Type = Type;
                ToEdit.Mark = Mark;
                ToEdit.Model = Model;
                ToEdit.AddDate = AddDate;
                ToEdit.Status = Status;
                EquipmentService.Edit(ToEdit);
            }
            else
            {
                var newEquipment = new EquipmentDTO();
                newEquipment.Type = Type;
                newEquipment.Mark = Mark;
                newEquipment.Model = Model;
                newEquipment.AddDate = AddDate;
                newEquipment.Status = Status;
                EquipmentService.Add(newEquipment);
            }
            TryClose();
        }

        public void Close()
        {
            TryClose();
        }
    }
}