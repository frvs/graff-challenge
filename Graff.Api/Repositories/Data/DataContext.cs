using Graff.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Graff.Api.Repositories.Data
{
    public class DataContext : DbContext
    {
        private Func<Func<DbContextOptionsBuilder, DbContextOptions>> p;

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DataContext(Func<Func<DbContextOptionsBuilder, DbContextOptions>> p)
        {
            this.p = p;
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Bid> Bid { get; set; }
        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
