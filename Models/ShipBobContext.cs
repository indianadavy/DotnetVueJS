using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;


namespace shipbob.Models
{
    public class ShipBobContext : DbContext
    {
        public ShipBobContext(DbContextOptions<ShipBobContext> options) : base(options)
        {
        }

        public DbSet<OrderItem> Orders { get; set; }
        public DbSet<UserItem> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the model and override the defaults if needed.
            // for example you can rename the table names and more.
            // Add your customizations after calling base.OnModelCreateing(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ShipBob.db");
        }
    }
}
