using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.Models
{
    [Table("Shipment")]
    public class Shipment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ("Name of the shipped item is required."))]
        public string ShippedItem { get; set; }

        [Required(ErrorMessage = ("Item quantity is required."))]
        public int ItemQuantity { get; set; }

        [Required(ErrorMessage = ("Name of the recipient company is required."))]
        public string RecipientCompany { get; set; }

        [Required(ErrorMessage = ("City/Town name is required."))]
        public string CityTown { get; set; }

        [Required(ErrorMessage = ("Postal code is required."))]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = ("Street address is required."))]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = ("Weight is required."))]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = ("Description is required."))]
        public string Description { get; set; }

        public bool IsDisabled { get; set; }
    }
}