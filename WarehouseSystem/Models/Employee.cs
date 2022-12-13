using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ("First name is required."))]
        public string FirstName { get; set; }

        [Required(ErrorMessage = ("Last name is required."))]
        public string LastName { get; set; }

        [Required(ErrorMessage = ("Employment date is required."))]
        public DateTime EmploymentDate { get; set; }

        [Required(ErrorMessage = ("Email is required."))]
        public string Email { get; set; }

        [Required(ErrorMessage = ("PhoneNumber number is required."))]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = ("Workaplace is required."))]
        public string Workplace { get; set; }

        public bool IsDisabled { get; set; }
    }
}