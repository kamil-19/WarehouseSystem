using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.Models
{
    [Table("Inventory")]
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ("Name of the sender is required."))]
        public string ItemFrom { get; set; }

        [Required(ErrorMessage = ("Name of the receiver is required."))]
        public string ItemTo { get; set; }

        [Required(ErrorMessage = ("Date of arrival is required."))]
        public DateTime DateOfArrival { get; set; }

        [Required(ErrorMessage = ("Date of sending is required."))]
        public DateTime DateToSend { get; set; }

        [Required(ErrorMessage = ("Weight of item is required."))]
        public int Weight { get; set; }

        [Required(ErrorMessage = ("Status of item is required."))]
        public string Status { get; set; }

        [Required(ErrorMessage = ("Description of item is required."))]
        public string Description { get; set; }

        public bool IsDisabled { get; set; }
    }
}