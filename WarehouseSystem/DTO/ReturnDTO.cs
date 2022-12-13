using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.DTO
{
    public class ReturnDTO
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool IsDisabled { get; set; }
    }
}