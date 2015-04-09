using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Identity.Models
{
    public class User
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat (DataFormatString = "{0:yyyy-MM-dd}" ,  ApplyFormatInEditMode = true)]
        public DateTime DateOfJoining { get; set; }

        [Required]
        [StringLength (15, MinimumLength =6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int ContactNo { get; set; }

        public virtual Address AddressObject { get; set; }
    
    
    }
}