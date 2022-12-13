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
    public class EventService
    {
        public static List<EventDTO> GetAll()
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = db.Events.Where(x => x.IsDisabled == false).Select(
                                   x => new EventDTO
                                   {
                                       Id = x.Id,
                                       Name = x.Name,
                                       Description = x.Description,
                                       Executed = x.Executed,
                                       UserId = x.UserId,
                                       OrderId = x.OrderId,
                                   }).ToList();
                return result;
            }
        }

        public static List<EventDTO> GetNotExecuted()
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = db.Events.Where(x => x.IsDisabled == false && x.Executed==false).Select(
                                   x => new EventDTO
                                   {
                                       Id = x.Id,
                                       Name = x.Name,
                                       Description = x.Description,
                                       Executed = x.Executed,
                                       UserId = x.UserId,
                                       OrderId = x.OrderId,
                                   }).ToList();
                return result;
            }
        }

        public static BindableCollection<EventDTO> GetAllBindableCollection()
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = new BindableCollection<EventDTO>(GetAll());
                return result;
            }
        }

        public static EventDTO GetById(int id)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var result = db.Events.Where(x => x.Id == id).Select(
                                    x => new EventDTO
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Description = x.Description,
                                        Executed = x.Executed,
                                        UserId = x.UserId,
                                        OrderId = x.OrderId,
                                    }).FirstOrDefault();

                return result;
            }
        }

        public static string Add(EventDTO eventDTO)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                string error = null;
                Event newEvent = new Event();

                newEvent.Id = eventDTO.Id;

                newEvent.Name = eventDTO.Name;

                newEvent.Description = eventDTO.Description;

                newEvent.Executed = eventDTO.Executed;

                newEvent.UserId = eventDTO.UserId;

                newEvent.OrderId = eventDTO.OrderId;

                var context = new ValidationContext(newEvent, null, null);

                var result = new List<ValidationResult>();
                Validator.TryValidateObject(newEvent, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }

                if (error == null)
                {
                    db.Events.Add(newEvent);
                    db.SaveChanges();
                }

                return error;
            }
        }

        public static string Edit(EventDTO eventDTO)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                string error = null;

                var toModify = db.Events.Where(x => x.Id == eventDTO.Id).FirstOrDefault();

                toModify.Id = eventDTO.Id;
                toModify.Name = eventDTO.Name;
                toModify.Description = eventDTO.Description;
                toModify.Executed = eventDTO.Executed;
                toModify.UserId = eventDTO.UserId;
                toModify.OrderId = eventDTO.OrderId;

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

        public static void Delete(EventDTO eventDTO)
        {
            using (WarehouseSystemContext db = new WarehouseSystemContext())
            {
                var toDelete = db.Events.Where(x => x.Id == eventDTO.Id).FirstOrDefault();
                toDelete.IsDisabled = true;

                db.SaveChanges();
            }
        }
    }
}