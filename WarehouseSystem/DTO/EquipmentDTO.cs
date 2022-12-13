using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.DTO
{
    public class EquipmentDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public DateTime AddDate { get; set; }
        public string Status { get; set; }

        public bool IsDisabled { get; set; }
    }
}