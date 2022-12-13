using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.Models
{
    [Table("Equipment")]
    public class Equipment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ("Type is required."))]
        public string Type { get; set; }

        [Required(ErrorMessage = ("Mark is required."))]
        public string Mark { get; set; }

        [Required(ErrorMessage = ("Model is required."))]
        public string Model { get; set; }

        [Required(ErrorMessage = ("Date of addition is required."))]
        public DateTime AddDate { get; set; }

        [Required(ErrorMessage = ("Status is required."))]
        public string Status { get; set; }

        public bool IsDisabled { get; set; }
    }
}