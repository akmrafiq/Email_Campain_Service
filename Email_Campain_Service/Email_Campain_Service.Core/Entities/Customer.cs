using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Email_Campain_Service.Core.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Customer Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Provide a Valid Email"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage ="Provide a valid Phone Number"),DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
