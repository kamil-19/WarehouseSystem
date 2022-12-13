using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.DTO
{
    public class EventHistoryDTO
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public DateTime StartDate { get; set; }

        public bool IsDisabled { get; set; }
    }
}