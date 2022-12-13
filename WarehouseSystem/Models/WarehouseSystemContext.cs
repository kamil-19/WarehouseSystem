using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.Models.Initializer;

namespace WarehouseSystem.Models
{
    public class WarehouseSystemContext : DbContext
    {
        // Your context has been configured to use a 'Model2' connection string from your application's
        // configuration file (App.config or Web.config). By default, this connection string targets the
        // 'ArmyBase.Models.Model2' database on your LocalDb instance.
        //
        // If you wish to target a different database and/or database provider, modify the 'Model2'
        // connection string in the application configuration file.
        public WarehouseSystemContext()
            : base("name=WarehouseSystemContext")
        {
        }

        public static void Seed(WarehouseSystemContext context)
        {
            WarehouseSystemDBInitializer.Seed(context);
        }

        // Add a DbSet for each entity type that you want to include in your Models. For more information
        // on configuring and using a Code First Models, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventHistory> EventHistory { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<User> Users { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}