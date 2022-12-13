using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.Models
{
    [Table("Return")]
    public class Return
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ("Name of the client is required."))]
        public string Client { get; set; }

        [Required(ErrorMessage = ("Date is required."))]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = ("Description is required."))]
        public string Description { get; set; }

        public bool IsDisabled { get; set; }
    }
}