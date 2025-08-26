using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise_backend.Models
{
    public class Users
    {
        [Key]
        public required string userId { get; set; }
        public required string username { get; set; }
        public required string email { get; set; }
    }
}