using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.DTO
{
    public class DeliveryDTO
    {
        public int Id { get; set; }
        public string DeliveredItem { get; set; }
        public int ItemQuantity { get; set; }
        public string RecipientCompany { get; set; }
        public string CityTown { get; set; }
        public string PostalCode { get; set; }
        public string StreetAddress { get; set; }
        public int Weight { get; set; }
        public string Description { get; set; }

        public bool IsDisabled { get; set; }
    }
}