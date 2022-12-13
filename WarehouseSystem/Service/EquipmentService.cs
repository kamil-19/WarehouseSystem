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
    public class EquipmentService
    {
        public static List<EquipmentDTO> GetAll()
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = db.Equipments.Where(x => x.IsDisabled == false).Select(
                                   x => new EquipmentDTO
                                   {
                                       Id = x.Id,
                                       Type = x.Type,
                                       Model = x.Model,
                                       Mark = x.Mark,
                                       AddDate = x.AddDate,
                                       Status = x.Status,
                                   }).ToList();
                return result;
            }
        }

        public static BindableCollection<EquipmentDTO> GetAllBindableCollection()
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = new BindableCollection<EquipmentDTO>(GetAll());
                return result;
            }
        }

        public static EquipmentDTO GetById(int id)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = db.Equipments.Where(x => x.Id == id).Select(
                                    x => new EquipmentDTO
                                    {
                                        Id = x.Id,
                                        Type = x.Type,
                                        Model = x.Model,
                                        Mark = x.Mark,
                                        AddDate = x.AddDate,
                                        Status = x.Status,
                                    }).FirstOrDefault();

                return result;
            }
        }

        public static string Add(EquipmentDTO equipment)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                string error = null;
                Equipment newEquipment = new Equipment();
                newEquipment.Id = equipment.Id;
                newEquipment.Type = equipment.Type;
                newEquipment.Model = equipment.Model;
                newEquipment.Mark = equipment.Mark;
                newEquipment.AddDate = equipment.AddDate;
                newEquipment.Status = equipment.Status;

                var context = new ValidationContext(newEquipment, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(newEquipment, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }

                if (error == null)
                {
                    db.Equipments.Add(newEquipment);
                    db.SaveChanges();
                }
                return error;
            }
        }

        public static string Edit(EquipmentDTO equipment)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                string error = null;

                var toModify = db.Equipments.Where(x => x.Id == equipment.Id).FirstOrDefault();

                toModify.Id = equipment.Id;
                toModify.Type = equipment.Type;
                toModify.Model = equipment.Model;
                toModify.Mark = equipment.Mark;
                toModify.AddDate = equipment.AddDate;
                toModify.Status = equipment.Status;

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

        public static void Delete(EquipmentDTO equipment)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var toDelete = db.Equipments.Where(x => x.Id == equipment.Id).FirstOrDefault();
                toDelete.IsDisabled = true;

                db.SaveChanges();
            }
        }
    }
}