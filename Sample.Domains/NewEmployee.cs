using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sample.Domains
{

    public class Employee
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public char Gender { get; set; }

    }
}
