using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise_backend.Models
{
    public class Transactions
    {
        [Key]
        public int Id { get; set; }
        public required string UserId { get; set; }
        public required decimal Amount { get; set; }
        public required string Type { get; set; }
        public required DateTime Date { get; set; }
    }
}