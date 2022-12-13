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
    public class OrderService
    {
        public static List<OrderDTO> GetAll()
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = db.Orders.Where(x => x.IsDisabled == false).Select(
                                   x => new OrderDTO
                                   {
                                       Id = x.Id,
                                       OrderItem = x.OrderItem,
                                       ItemQuantity = x.ItemQuantity,
                                       RecipientCompany = x.RecipientCompany,
                                       PostalCode = x.PostalCode,
                                       CityTown = x.CityTown,
                                       StreetAddress = x.StreetAddress,
                                       Description = x.Description,
                                   }).ToList();
                return result;
            }
        }

        public static BindableCollection<OrderDTO> GetAllBindableCollection()
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = new BindableCollection<OrderDTO>(GetAll());
                return result;
            }
        }

        public static OrderDTO GetById(int id)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = db.Orders.Where(x => x.Id == id).Select(
                                    x => new OrderDTO
                                    {
                                        Id = x.Id,
                                        OrderItem = x.OrderItem,
                                        ItemQuantity = x.ItemQuantity,
                                        RecipientCompany = x.RecipientCompany,
                                        PostalCode = x.PostalCode,
                                        CityTown = x.CityTown,
                                        StreetAddress = x.StreetAddress,
                                        Description = x.Description,
                                    }).FirstOrDefault();

                return result;
            }
        }

        public static string Add(OrderDTO order)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                string error = null;
                Order newOrder = new Order();
                newOrder.Id = order.Id;
                newOrder.OrderItem = order.OrderItem;
                newOrder.ItemQuantity = order.ItemQuantity;
                newOrder.RecipientCompany = order.RecipientCompany;
                newOrder.PostalCode = order.PostalCode;
                newOrder.CityTown = order.CityTown;
                newOrder.StreetAddress = order.StreetAddress;
                newOrder.Description = order.Description;

                var context = new ValidationContext(newOrder, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(newOrder, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }

                if (error == null)
                {
                    db.Orders.Add(newOrder);
                    db.SaveChanges();
                }
                return error;
            }
        }

        public static string Edit(OrderDTO order)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                string error = null;

                var toModify = db.Orders.Where(x => x.Id == order.Id).FirstOrDefault();

                toModify.Id = order.Id;
                toModify.OrderItem = order.OrderItem;
                toModify.RecipientCompany = order.RecipientCompany;
                toModify.ItemQuantity = order.ItemQuantity;
                toModify.PostalCode = order.PostalCode;
                toModify.CityTown = order.CityTown;
                toModify.StreetAddress = order.StreetAddress;
                toModify.Description = order.Description;

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

        public static void Delete(OrderDTO order)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var toDelete = db.Orders.Where(x => x.Id == order.Id).FirstOrDefault();
                toDelete.IsDisabled = true;

                db.SaveChanges();
            }
        }
    }
}