using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.Models
{
    [Table("EventHistory")]
    public class EventHistory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ("Event ID is required."))]
        public int EventId { get; set; }

        [Required(ErrorMessage = ("Start date is required."))]
        public DateTime StartDate { get; set; }

        public bool IsDisabled { get; set; }
    }
}