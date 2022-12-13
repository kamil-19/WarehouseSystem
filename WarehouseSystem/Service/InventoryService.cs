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
    public class InventoryService
    {
        public static List<InventoryDTO> GetAll()
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = db.Inventory.Where(x => x.IsDisabled == false).Select(
                                   x => new InventoryDTO
                                   {
                                       Id = x.Id,
                                       ItemFrom = x.ItemFrom,
                                       ItemTo = x.ItemTo,
                                       DateOfArrival = x.DateOfArrival,
                                       DateToSend = x.DateToSend,
                                       Weight = x.Weight,
                                       Status = x.Status,
                                       Description = x.Description,
                                   }).ToList();
                return result;
            }
        }

        public static BindableCollection<InventoryDTO> GetAllBindableCollection()
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = new BindableCollection<InventoryDTO>(GetAll());
                return result;
            }
        }

        public static InventoryDTO GetById(int id)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = db.Inventory.Where(x => x.Id == id).Select(
                                    x => new InventoryDTO
                                    {
                                        Id = x.Id,
                                        ItemFrom = x.ItemFrom,
                                        ItemTo = x.ItemTo,
                                        DateOfArrival = x.DateOfArrival,
                                        DateToSend = x.DateToSend,
                                        Weight = x.Weight,
                                        Status = x.Status,
                                        Description = x.Description,
                                    }).FirstOrDefault();

                return result;
            }
        }

        public static string Add(InventoryDTO inventory)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                string error = null;
                Inventory newInventory = new Inventory();
                newInventory.Id = inventory.Id;
                newInventory.ItemFrom = inventory.ItemFrom;
                newInventory.ItemTo = inventory.ItemTo;
                newInventory.DateOfArrival = inventory.DateOfArrival;
                newInventory.DateToSend = inventory.DateToSend;
                newInventory.Weight = inventory.Weight;
                newInventory.Status = inventory.Status;
                newInventory.Description = inventory.Description;

                var context = new ValidationContext(newInventory, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(newInventory, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }

                if (error == null)
                {
                    db.Inventory.Add(newInventory);
                    db.SaveChanges();
                }
                return error;
            }
        }

        public static string Edit(InventoryDTO inventory)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                string error = null;

                var toModify = db.Inventory.Where(x => x.Id == inventory.Id).FirstOrDefault();

                toModify.Id = inventory.Id;
                toModify.ItemFrom = inventory.ItemFrom;
                toModify.ItemTo = inventory.ItemTo;
                toModify.DateOfArrival = inventory.DateOfArrival;
                toModify.DateToSend = inventory.DateToSend;
                toModify.Weight = inventory.Weight;
                toModify.Status = inventory.Status;
                toModify.Description = inventory.Description;

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

        public static void Delete(InventoryDTO inventory)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var toDelete = db.Inventory.Where(x => x.Id == inventory.Id).FirstOrDefault();
                toDelete.IsDisabled = true;

                db.SaveChanges();
            }
        }
    }
}