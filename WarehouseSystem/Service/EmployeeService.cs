using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.DTO;
using WarehouseSystem.Models;

namespace WarehouseSystem.Service
{
    public class EmployeeService
    {
        public static List<EmployeeDTO> GetAll()
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = db.Employees.Where(x => x.IsDisabled == false).Select(
                                   x => new EmployeeDTO
                                   {
                                       Id = x.Id,
                                       FirstName = x.FirstName,
                                       LastName = x.LastName,
                                       Email = x.Email,
                                       PhoneNumber = x.PhoneNumber,
                                       EmploymentDate = x.EmploymentDate,
                                       Workplace = x.Workplace
                                   }).ToList();
                return result;
            }
        }

        public static BindableCollection<EmployeeDTO> GetAllBindableCollection()
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = new BindableCollection<EmployeeDTO>(GetAll());
                return result;
            }
        }

        public static EmployeeDTO GetById(int id)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = db.Employees.Where(x => x.Id == id).Select(
                                    x => new EmployeeDTO
                                    {
                                        Id = x.Id,
                                        FirstName = x.FirstName,
                                        LastName = x.LastName,
                                        Email = x.Email,
                                        PhoneNumber = x.PhoneNumber,
                                        EmploymentDate = x.EmploymentDate,
                                        Workplace = x.Workplace,
                                    }).FirstOrDefault();

                return result;
            }
        }

        public static string Add(EmployeeDTO employee)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                string error = null;
                Employee newEmployee = new Employee();
                newEmployee.Id = employee.Id;
                newEmployee.FirstName = employee.FirstName;
                newEmployee.LastName = employee.LastName;
                newEmployee.Email = employee.Email;
                newEmployee.PhoneNumber = employee.PhoneNumber;
                newEmployee.EmploymentDate = employee.EmploymentDate;
                newEmployee.Workplace = employee.Workplace;

                var context = new ValidationContext(newEmployee, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(newEmployee, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }

                if (error == null)
                {
                    db.Employees.Add(newEmployee);
                    db.SaveChanges();
                }
                return error;
            }
        }

        public static string Edit(EmployeeDTO employee)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                string error = null;

                var toModify = db.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();

                toModify.Id = employee.Id;
                toModify.FirstName = employee.FirstName;
                toModify.LastName = employee.LastName;
                toModify.Email = employee.Email;
                toModify.PhoneNumber = employee.PhoneNumber;
                toModify.EmploymentDate = employee.EmploymentDate;
                toModify.Workplace = employee.Workplace;

                var context = new ValidationContext(toModify, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(toModify, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }

                if (error == null)
                {
                    db.SaveChanges();
                }
                return error;
            }
        }

        public static void Delete(EmployeeDTO employee)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var toDelete = db.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();
                toDelete.IsDisabled = true;

                db.SaveChanges();
            }
        }
    }
}