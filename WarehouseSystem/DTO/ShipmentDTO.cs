using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.DTO
{
    public class ShipmentDTO
    {
        public int Id { get; set; }
        public string ShippedItem { get; set; }
        public int ItemQuantity { get; set; }
        public string RecipientCompany { get; set; }
        public string CityTown { get; set; }
        public string PostalCode { get; set; }
        public string StreetAddress { get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; }

        public bool IsDisabled { get; set; }
    }
}