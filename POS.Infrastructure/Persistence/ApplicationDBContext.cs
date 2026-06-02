using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Products> Product { get; set; }
        public DbSet<Stocks> Stock { get; set; }
    }
}
