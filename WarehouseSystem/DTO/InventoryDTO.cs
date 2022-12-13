using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.DTO
{
    public class InventoryDTO
    {
        public int Id { get; set; }
        public string ItemFrom { get; set; }
        public string ItemTo { get; set; }
        public DateTime DateOfArrival { get; set; }
        public DateTime DateToSend { get; set; }
        public int Weight { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public bool IsDisabled { get; set; }
    }
}