using Identity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Identity.ViewModels
{
    public class JoiningDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime DateOfJoining { get; set; }
        public int UserCount { get; set; }
    }
}