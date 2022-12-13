using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.Models
{
    [Table("Event")]
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ("Event name is required."))]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = ("Executed state is required."))]
        public bool Executed { get; set; }

        public int? UserId { get; set; }

        [Required(ErrorMessage = ("User ID is required."))]
        public int OrderId { get; set; }

        public bool IsDisabled { get; set; }
    }
}