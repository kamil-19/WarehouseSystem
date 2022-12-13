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
    public class ShipmentService
    {
        public static List<ShipmentDTO> GetAll()
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = db.Shipments.Where(x => x.IsDisabled == false).Select(
                                   x => new ShipmentDTO
                                   {
                                       Id = x.Id,
                                       ShippedItem = x.ShippedItem,
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

        public static BindableCollection<ShipmentDTO> GetAllBindableCollection()
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = new BindableCollection<ShipmentDTO>(GetAll());
                return result;
            }
        }

        public static ShipmentDTO GetById(int id)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = db.Shipments.Where(x => x.Id == id).Select(
                                    x => new ShipmentDTO
                                    {
                                        Id = x.Id,
                                        ShippedItem = x.ShippedItem,
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

        public static string Add(ShipmentDTO shipment)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                string error = null;
                Shipment newShipment = new Shipment();
                newShipment.Id = shipment.Id;
                newShipment.ShippedItem = shipment.ShippedItem;
                newShipment.ItemQuantity = shipment.ItemQuantity;
                newShipment.RecipientCompany = shipment.RecipientCompany;
                newShipment.PostalCode = shipment.PostalCode;
                newShipment.CityTown = shipment.CityTown;
                newShipment.StreetAddress = shipment.StreetAddress;
                newShipment.Weight = shipment.Weight;
                newShipment.Description = shipment.Description;

                var context = new ValidationContext(newShipment, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(newShipment, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }

                if (error == null)
                {
                    db.Shipments.Add(newShipment);
                    db.SaveChanges();
                }
                return error;
            }
        }

        public static string Edit(ShipmentDTO shipment)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                string error = null;

                var toModify = db.Shipments.Where(x => x.Id == shipment.Id).FirstOrDefault();

                toModify.Id = shipment.Id;
                toModify.ShippedItem = shipment.ShippedItem;
                toModify.RecipientCompany = shipment.RecipientCompany;
                toModify.ItemQuantity = shipment.ItemQuantity;
                toModify.PostalCode = shipment.PostalCode;
                toModify.CityTown = shipment.CityTown;
                toModify.StreetAddress = shipment.StreetAddress;
                toModify.Weight = shipment.Weight;
                toModify.Description = shipment.Description;

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

        public static void Delete(ShipmentDTO shipment)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var toDelete = db.Shipments.Where(x => x.Id == shipment.Id).FirstOrDefault();
                toDelete.IsDisabled = true;

                db.SaveChanges();
            }
        }
    }
}