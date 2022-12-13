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
    public class ClientService
    {
        public static List<ClientDTO> GetAll()
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = db.Clients.Where(x => x.IsDisabled == false).Select(
                                   x => new ClientDTO
                                   {
                                       Id = x.Id,
                                       CompanyName = x.CompanyName,
                                       PostalCode = x.PostalCode,
                                       Email = x.Email,
                                       PhoneNumber = x.PhoneNumber,
                                       Address = x.Address,
                                   }).ToList();
                return result;
            }
        }

        public static BindableCollection<ClientDTO> GetAllBindableCollection()
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = new BindableCollection<ClientDTO>(GetAll());
                return result;
            }
        }

        public static ClientDTO GetById(int id)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = db.Clients.Where(x => x.Id == id).Select(
                                    x => new ClientDTO
                                    {
                                        Id = x.Id,
                                        CompanyName = x.CompanyName,
                                        PostalCode = x.PostalCode,
                                        Email = x.Email,
                                        PhoneNumber = x.PhoneNumber,
                                        Address = x.Address,
                                    }).FirstOrDefault();

                return result;
            }
        }

        public static string Add(ClientDTO client)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                string error = null;
                Client newClient = new Client();
                newClient.Id = client.Id;
                newClient.CompanyName = client.CompanyName;
                newClient.PostalCode = client.PostalCode;
                newClient.Email = client.Email;
                newClient.PhoneNumber = client.PhoneNumber;
                newClient.Address = client.Address;

                var context = new ValidationContext(newClient, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(newClient, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }

                if (error == null)
                {
                    db.Clients.Add(newClient);
                    db.SaveChanges();
                }
                return error;
            }
        }

        public static string Edit(ClientDTO client)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                string error = null;

                var toModify = db.Clients.Where(x => x.Id == client.Id).FirstOrDefault();

                toModify.Id = client.Id;
                toModify.CompanyName = client.CompanyName;
                toModify.PostalCode = client.PostalCode;
                toModify.Email = client.Email;
                toModify.PhoneNumber = client.PhoneNumber;
                toModify.Address = client.Address;

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

        public static void Delete(ClientDTO client)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var toDelete = db.Clients.Where(x => x.Id == client.Id).FirstOrDefault();
                toDelete.IsDisabled = true;

                db.SaveChanges();
            }
        }
    }
}