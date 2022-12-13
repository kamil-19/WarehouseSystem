using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.DTO;
using WarehouseSystem.Models;
using WarehouseSystem.Service;

namespace WarehouseSystem.ViewModels
{
    public class AddEmployeeViewModel : Screen
    {
        private bool IsEdit { get; set; }

        private EmployeeDTO ToEdit { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime EmploymentDate { get; set; } = DateTime.Now;

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Workplace { get; set; }

        public bool IsDisabled { get; set; }

        public string ButtonLabel { get; set; }

        public AddEmployeeViewModel(EmployeeDTO employee)
        {
            IsEdit = true;
            ButtonLabel = "Edit";

            this.ToEdit = employee;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            EmploymentDate = employee.EmploymentDate;
            Email = employee.Email;
            PhoneNumber = employee.PhoneNumber;
            Workplace = employee.Workplace;
            NotifyOfPropertyChange(() => FirstName);
            NotifyOfPropertyChange(() => LastName);
            NotifyOfPropertyChange(() => EmploymentDate);
            NotifyOfPropertyChange(() => Email);
            NotifyOfPropertyChange(() => PhoneNumber);
            NotifyOfPropertyChange(() => Workplace);
        }

        public AddEmployeeViewModel()
        {
            IsEdit = false;
            ButtonLabel = "Add";
        }

        public void Add()
        {
            if (IsEdit == true)
            {
                ToEdit.FirstName = FirstName;
                ToEdit.LastName = LastName;
                ToEdit.EmploymentDate = EmploymentDate;
                ToEdit.Email = Email;
                ToEdit.PhoneNumber = PhoneNumber;
                ToEdit.Workplace = Workplace;
                EmployeeService.Edit(ToEdit);
            }
            else
            {
                var newEmployee = new EmployeeDTO();
                newEmployee.FirstName = FirstName;
                newEmployee.LastName = LastName;
                newEmployee.EmploymentDate = EmploymentDate;
                newEmployee.Email = Email;
                newEmployee.PhoneNumber = PhoneNumber;
                newEmployee.Workplace = Workplace;
                EmployeeService.Add(newEmployee);
            }
            Close();
        }

        public void Close()
        {
            TryClose();
        }
    }
}