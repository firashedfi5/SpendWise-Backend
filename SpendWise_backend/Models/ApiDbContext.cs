using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SpendWise_backend.Models
{
    public class ApiDbContext(DbContextOptions option) : DbContext(option)
    {
        public DbSet<Transactions> Transactions { get; set; }


    }
}