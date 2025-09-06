using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SpendWise_backend.Models
{
    public class Transactions
    {
        [Key]
        public int id { get; set; }
        public required string userId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public required decimal amount { get; set; }
        public required string type { get; set; }
        public required string category { get; set; }
        public required string title { get; set; }
        public required DateTime date { get; set; }
        public required DateTime createdAt { get; set; }
    }
}