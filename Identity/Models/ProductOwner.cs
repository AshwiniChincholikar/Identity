using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Identity.Models
{
    public class ProductOwner : User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FoundedIn { get; set; }

        public string WebsiteUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string FbUrl { get; set; }
    }
}