using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.Models.Initializer
{
    internal class WarehouseSystemDBInitializer
    {
        public static void Seed(WarehouseSystemContext db)
        {
            IList<Client> Clients = new List<Client>();
            Clients.Add(new Client() { Id = 1, CompanyName = "Tomex", PostalCode = "16-010", Address = "Warszawska 54", Email = "Tomex@test.com", PhoneNumber = "123456789" });
            Clients.Add(new Client() { Id = 2, CompanyName = "Adamex", PostalCode = "16-011", Address = "Krucza 32", Email = "Adamex@test.com", PhoneNumber = "67895432" });
            Clients.Add(new Client() { Id = 3, CompanyName = "RazDwaTrzy", PostalCode = "16-012", Address = "Wąska 1", Email = "razdwatrzy@test.com", PhoneNumber = "12345632" });
            Clients.Add(new Client() { Id = 4, CompanyName = "Delta", PostalCode = "16-013", Address = "Waszyngtonaa 2", Email = "delta@test.com", PhoneNumber = "123458932" });

            foreach (var item in Clients)
                db.Clients.Add(item);

            IList<Delivery> Deliveries = new List<Delivery>();
            Deliveries.Add(new Delivery() { Id = 1, RecipientCompany = "Alfa", PostalCode = "16-010", CityTown = "Warszawa", DeliveredItem = "Czajnik", ItemQuantity = 1, Description = "brak", StreetAddress = "Długa 21", Weight = 15 });
            Deliveries.Add(new Delivery() { Id = 2, RecipientCompany = "Beteta", PostalCode = "16-210", CityTown = "Gdańsk", DeliveredItem = "Kubek", ItemQuantity = 3, Description = "brak", StreetAddress = "Wiejska 42", Weight = 15 });
            Deliveries.Add(new Delivery() { Id = 3, RecipientCompany = "Karolex", PostalCode = "13-010", CityTown = "Legionowo", DeliveredItem = "Szklanka", ItemQuantity = 3, Description = "brak", StreetAddress = "Warszawska 2", Weight = 15 });
            Deliveries.Add(new Delivery() { Id = 4, RecipientCompany = "OneAndTwo", PostalCode = "11-010", CityTown = "Olsztyn", DeliveredItem = "Maskotka", ItemQuantity = 6, Description = "brak", StreetAddress = "Mickiewicza 21", Weight = 15 });

            foreach (var item in Deliveries)
                db.Deliveries.Add(item);

            IList<Employee> Employees = new List<Employee>();
            Employees.Add(new Employee() { Id = 1, FirstName = "Andrzej", LastName = "Grabara", Email = "a.grabare@test.com", PhoneNumber = "871313123", EmploymentDate = new DateTime(2017, 2, 14), Workplace = "Magazyn" });
            Employees.Add(new Employee() { Id = 2, FirstName = "Beata", LastName = "Kościelniak", Email = "b.koscielniak@test.com", PhoneNumber = "691323123", EmploymentDate = new DateTime(2017, 2, 11), Workplace = "Rampa" });
            Employees.Add(new Employee() { Id = 3, FirstName = "Tomasz", LastName = "Lis", Email = "t.lis@test.com", PhoneNumber = "696133123", EmploymentDate = new DateTime(2017, 2, 13), Workplace = "Sortownia" });
            Employees.Add(new Employee() { Id = 4, FirstName = "Przemysław", LastName = "Bak", Email = "p.bak@test.com", PhoneNumber = "696513223", EmploymentDate = new DateTime(2017, 2, 12), Workplace = "Sortownia" });

            foreach (var item in Employees)
                db.Employees.Add(item);

            IList<Equipment> Equipments = new List<Equipment>();
            Equipments.Add(new Equipment() { Id = 1, Type = "Wózek widłowy", Mark = "Workp", Model = "TR34", AddDate = new DateTime(2017, 3, 3), Status = "Aktywny" });
            Equipments.Add(new Equipment() { Id = 2, Type = "Wózek widłowy", Mark = "WorkP", Model = "TR35", AddDate = new DateTime(2017, 4, 9), Status = "Niedostępny" });
            Equipments.Add(new Equipment() { Id = 3, Type = "Rękawice", Mark = "Teslo", Model = "AN321", AddDate = new DateTime(2017, 1, 11), Status = "Aktywny" });
            Equipments.Add(new Equipment() { Id = 4, Type = "Kask", Mark = "Dark", Model = "Db47", AddDate = new DateTime(2017, 7, 12), Status = "Aktywny" });

            foreach (var item in Equipments)
                db.Equipments.Add(item);

            IList<Event> Events = new List<Event>();
            Events.Add(new Event() { Id = 1, Name = "Test", Description = "Test", Executed = false, UserId = 1, OrderId = 1 });
            Events.Add(new Event() { Id = 2, Name = "Test2", Description = "Test2", Executed = false, UserId = 2, OrderId = 2 });
            Events.Add(new Event() { Id = 3, Name = "Test3", Description = "Test3", Executed = false, UserId = 3, OrderId = 3 });
            Events.Add(new Event() { Id = 4, Name = "Test4", Description = "Test4", Executed = false, UserId = 4, OrderId = 4 });

            foreach (var item in Events)
                db.Events.Add(item);

            IList<EventHistory> EventHistory = new List<EventHistory>();
            EventHistory.Add(new EventHistory() { Id = 1, EventId = 1, StartDate = new DateTime(2017, 2, 14) });
            EventHistory.Add(new EventHistory() { Id = 2, EventId = 2, StartDate = new DateTime(2017, 6, 14) });
            EventHistory.Add(new EventHistory() { Id = 3, EventId = 3, StartDate = new DateTime(2017, 3, 14) });
            EventHistory.Add(new EventHistory() { Id = 4, EventId = 4, StartDate = new DateTime(2017, 2, 16) });

            foreach (var item in EventHistory)
                db.EventHistory.Add(item);

            IList<Inventory> Inventory = new List<Inventory>();
            Inventory.Add(new Inventory() { Id = 1, ItemFrom = "Adam Korol", ItemTo = "Słowik", DateOfArrival = new DateTime(2017, 1, 3), DateToSend = new DateTime(2017, 2, 3), Weight = 3, Status = "Dostarczono", Description = "Brak" });
            Inventory.Add(new Inventory() { Id = 2, ItemFrom = "Tomex", ItemTo = "OneAndTwo", DateOfArrival = new DateTime(2017, 1, 4), DateToSend = new DateTime(2017, 2, 4), Weight = 1, Status = "W magazynie", Description = "Nie rzucać!" });
            Inventory.Add(new Inventory() { Id = 3, ItemFrom = "Kamil Olczyk", ItemTo = "Grzegorz Tarasiewicz", DateOfArrival = new DateTime(2017, 1, 5), DateToSend = new DateTime(2017, 2, 5), Weight = 7, Status = "W magazynie", Description = "Nie rzucać!" });
            Inventory.Add(new Inventory() { Id = 4, ItemFrom = "RazDwaTrzy", ItemTo = "Michał Adamek", DateOfArrival = new DateTime(2017, 1, 6), DateToSend = new DateTime(2017, 2, 6), Weight = 5, Status = "Dostarczono", Description = "Brak" });

            foreach (var item in Inventory)
                db.Inventory.Add(item);

            IList<Order> Orders = new List<Order>();
            Orders.Add(new Order() { Id = 1, OrderItem = "Telefon Iphone 6s", ItemQuantity = 1, RecipientCompany = "Tomex", CityTown = "Kraków", PostalCode = "13-011", StreetAddress = "Warszawska 6", Description = "Nie rzucać!" });
            Orders.Add(new Order() { Id = 2, OrderItem = "Czajnik elektryczny", ItemQuantity = 23, RecipientCompany = "RazDwaTrzy", CityTown = "Białystok", PostalCode = "13-101", StreetAddress = "Krótka 4", Description = "Brak" });
            Orders.Add(new Order() { Id = 3, OrderItem = "Flet", ItemQuantity = 2, RecipientCompany = "Słowik", CityTown = "Warszawa", PostalCode = "13-031", StreetAddress = "Mickiewicza 3", Description = "Brak" });
            Orders.Add(new Order() { Id = 4, OrderItem = "Bateria", ItemQuantity = 15, RecipientCompany = "Telekom", CityTown = "Olsztyn", PostalCode = "13-001", StreetAddress = "Okopowa 54", Description = "Brak" });

            foreach (var item in Orders)
                db.Orders.Add(item);

            IList<Return> Returns = new List<Return>();
            Returns.Add(new Return() { Id = 1, Client = "Adam Wakulak", Date = new DateTime(2017, 4, 6), Description = "Brak" });
            Returns.Add(new Return() { Id = 2, Client = "Kamil Stoch", Date = new DateTime(2017, 4, 7), Description = "Brak" });
            Returns.Add(new Return() { Id = 3, Client = "Andrzej Duda", Date = new DateTime(2017, 4, 8), Description = "Uszkodzenie szybki" });
            Returns.Add(new Return() { Id = 4, Client = "Andreas Kooler", Date = new DateTime(2017, 4, 9), Description = "Zgniecenie" });

            foreach (var item in Returns)
                db.Returns.Add(item);

            IList<Shipment> Shipments = new List<Shipment>();
            Shipments.Add(new Shipment() { Id = 1, ShippedItem = "Szafa", ItemQuantity = 1, RecipientCompany = "Januszex", CityTown = "Warszawa", PostalCode = "13-097", StreetAddress = "Waszyngtona 5", Weight = 4, Description = "Brak" });
            Shipments.Add(new Shipment() { Id = 2, ShippedItem = "Ubudowa telefonu mi6", ItemQuantity = 12, RecipientCompany = "OneAndTwo", CityTown = "Ełk", PostalCode = "12-197", StreetAddress = "Krucza 2", Weight = 44, Description = "Brak" });
            Shipments.Add(new Shipment() { Id = 3, ShippedItem = "Kubek z imieniem", ItemQuantity = 6, RecipientCompany = "Testrix", CityTown = "Białystok", PostalCode = "15-297", StreetAddress = "Towarowa 21", Weight = 2, Description = "Uwaga produkt delikatny!" });
            Shipments.Add(new Shipment() { Id = 4, ShippedItem = "Szklanki Zestaw", ItemQuantity = 8, RecipientCompany = "Phil", CityTown = "Białystok", PostalCode = "13-297", StreetAddress = "Długa 121", Weight = 12, Description = "Nie rzucać!" });

            foreach (var item in Shipments)
                db.Shipments.Add(item);

            IList<User> Users = new List<User>();
            Users.Add(new User() { Id = 1, FirstName = "Administrator", LastName = "Adminsitrator", BirthDate = new DateTime(1999, 1, 13), Email = "admin@gmail.com", PhoneNumber = "654321123", UserName = "admin", Password = "admin" });
            Users.Add(new User() { Id = 2, FirstName = "Adam", LastName = "Lewandowski", BirthDate = new DateTime(1999, 2, 13), Email = "a.lewandowski@gmail.com", PhoneNumber = "654311123", UserName = "lewa", Password = "lewa" });
            Users.Add(new User() { Id = 3, FirstName = "Jan", LastName = "Nowak", BirthDate = new DateTime(1999, 6, 13), Email = "j.nowak@gmail.com", PhoneNumber = "654331123", UserName = "nowj", Password = "nowj" });
            Users.Add(new User() { Id = 4, FirstName = "Andrzej", LastName = "Kowalski", BirthDate = new DateTime(1999, 5, 13), Email = "a.kowalski@gmail.com", PhoneNumber = "654341123", UserName = "kowa", Password = "kowa" });
            Users.Add(new User() { Id = 5, FirstName = "Karol", LastName = "Koc", BirthDate = new DateTime(1999, 1, 13), Email = "k.koc@gmail.com", PhoneNumber = "654321123", UserName = "kock", Password = "kock" });

            foreach (var item in Users)
                db.Users.Add(item);

            db.SaveChanges();
        }
    }
}