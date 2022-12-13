using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Workplace { get; set; }

        public bool IsDisabled { get; set; }
    }
}