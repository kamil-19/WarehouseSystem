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
    internal class DeliveryService
    {
        public static List<DeliveryDTO> GetAll()
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = db.Deliveries.Where(x => x.IsDisabled == false).Select(
                                   x => new DeliveryDTO
                                   {
                                       Id = x.Id,
                                       DeliveredItem = x.DeliveredItem,
                                       ItemQuantity = x.ItemQuantity,
                                       RecipientCompany = x.RecipientCompany,
                                       PostalCode = x.PostalCode,
                                       CityTown = x.CityTown,
                                       StreetAddress = x.StreetAddress,
                                       Weight = x.Weight,
                                       Description = x.Description,
                                   }).ToList();
                return result;
            }
        }

        public static BindableCollection<DeliveryDTO> GetAllBindableCollection()
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = new BindableCollection<DeliveryDTO>(GetAll());
                return result;
            }
        }

        public static DeliveryDTO GetById(int id)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = db.Deliveries.Where(x => x.Id == id).Select(
                                    x => new DeliveryDTO
                                    {
                                        Id = x.Id,
                                        DeliveredItem = x.DeliveredItem,
                                        ItemQuantity = x.ItemQuantity,
                                        RecipientCompany = x.RecipientCompany,
                                        PostalCode = x.PostalCode,
                                        CityTown = x.CityTown,
                                        StreetAddress = x.StreetAddress,
                                        Weight = x.Weight,
                                        Description = x.Description,
                                    }).FirstOrDefault();

                return result;
            }
        }

        public static string Add(DeliveryDTO delivery)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                string error = null;
                Delivery newDelivery = new Delivery();
                newDelivery.Id = delivery.Id;
                newDelivery.DeliveredItem = delivery.DeliveredItem;
                newDelivery.ItemQuantity = delivery.ItemQuantity;
                newDelivery.RecipientCompany = delivery.RecipientCompany;
                newDelivery.PostalCode = delivery.PostalCode;
                newDelivery.CityTown = delivery.CityTown;
                newDelivery.StreetAddress = delivery.StreetAddress;
                newDelivery.Weight = delivery.Weight;
                newDelivery.Description = delivery.Description;

                var context = new ValidationContext(newDelivery, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(newDelivery, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }

                if (error == null)
                {
                    db.Deliveries.Add(newDelivery);
                    db.SaveChanges();
                }
                return error;
            }
        }

        public static string Edit(DeliveryDTO delivery)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                string error = null;

                var toModify = db.Deliveries.Where(x => x.Id == delivery.Id).FirstOrDefault();

                toModify.Id = delivery.Id;
                toModify.DeliveredItem = delivery.DeliveredItem;
                toModify.RecipientCompany = delivery.RecipientCompany;
                toModify.ItemQuantity = delivery.ItemQuantity;
                toModify.PostalCode = delivery.PostalCode;
                toModify.CityTown = delivery.CityTown;
                toModify.StreetAddress = delivery.StreetAddress;
                toModify.Weight = delivery.Weight;
                toModify.Description = delivery.Description;

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

        public static void Delete(DeliveryDTO delivery)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var toDelete = db.Deliveries.Where(x => x.Id == delivery.Id).FirstOrDefault();
                toDelete.IsDisabled = true;

                db.SaveChanges();
            }
        }
    }
}