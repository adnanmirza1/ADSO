using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adso.Models
{
    public class AdsoDbContext : DbContext
    {
        public AdsoDbContext(DbContextOptions<AdsoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Country { get; set; }

        public DbSet<City> City { get; set; }
    }
}
