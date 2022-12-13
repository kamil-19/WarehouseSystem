using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.DTO;
using WarehouseSystem.Service;
using Caliburn.Micro;

namespace WarehouseSystem.ViewModels.Employee
{
    internal class EmployeeGridViewModel : Screen
    {
        public List<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();

        public EmployeeGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadAddEmployeePage()
        {
            IWindowManager manager = new WindowManager();
            AddEmployeeViewModel add = new AddEmployeeViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadModifyEmployeePage(EmployeeDTO employee)
        {
            IWindowManager manager = new WindowManager();
            AddEmployeeViewModel modify = new AddEmployeeViewModel(employee);
            manager.ShowDialog(modify, null, null);
            Reload();
        }

        public void Delete(EmployeeDTO employee)
        {
            IWindowManager manager = new WindowManager();
            EmployeeService.Delete(employee);
            Reload();
        }

        public void Reload()
        {
            Employees = EmployeeService.GetAll();
            NotifyOfPropertyChange(() => Employees);
        }
    }
}