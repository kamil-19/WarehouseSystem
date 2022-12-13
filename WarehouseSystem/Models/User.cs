using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ("First name is required."))]
        public string FirstName { get; set; }

        [Required(ErrorMessage = ("Last name is required."))]
        public string LastName { get; set; }

        [Required(ErrorMessage = ("Birth date is required."))]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = ("Email is required."))]
        public string Email { get; set; }

        [Required(ErrorMessage = ("Phone number is required."))]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = ("User name is required."))]
        public string UserName { get; set; }

        [Required(ErrorMessage = ("Password is required."))]
        public string Password { get; set; }

        public bool IsDisabled { get; set; }
    }
}