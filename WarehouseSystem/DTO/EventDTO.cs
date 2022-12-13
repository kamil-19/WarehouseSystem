using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Executed { get; set; }
        public int? UserId { get; set; }
        public int OrderId { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsActive { get; set; }
    }
}