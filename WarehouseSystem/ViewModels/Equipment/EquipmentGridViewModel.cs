﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.DTO;
using WarehouseSystem.Service;
using Caliburn.Micro;

namespace WarehouseSystem.ViewModels.Equipment
{
    internal class EquipmentGridViewModel : Screen
    {
        public List<EquipmentDTO> Equipments { get; set; } = new List<EquipmentDTO>();

        public EquipmentGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadAddEquipmentPage()
        {
            IWindowManager manager = new WindowManager();
            AddEquipmentViewModel add = new AddEquipmentViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadModifyEquipmentPage(EquipmentDTO equipment)
        {
            IWindowManager manager = new WindowManager();
            AddEquipmentViewModel modify = new AddEquipmentViewModel(equipment);
            manager.ShowDialog(modify, null, null);
            Reload();
        }

        public void Delete(EquipmentDTO equipment)
        {
            IWindowManager manager = new WindowManager();
            EquipmentService.Delete(equipment);
            Reload();
        }

        public void Reload()
        {
            Equipments = EquipmentService.GetAll();
            NotifyOfPropertyChange(() => Equipments);
        }
    }
}