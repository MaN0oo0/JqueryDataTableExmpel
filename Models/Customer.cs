using System;
using System.ComponentModel.DataAnnotations;

namespace jQueryDataTable.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required,MaxLength(20)]
         public string FirstName { get; set; }
        [Required, MaxLength(20)]
        public string LastName { get; set; }
        [Required, MaxLength(20)]
        public string Contact { get; set; }
        [Required, MaxLength(120)]
        public string Email { get; set; }
        public DateTime DateOfBith { get; set; }
    }
}
