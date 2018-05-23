using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineSpecs.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Computer> Computers { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<GraphicsCard> GraphicsCards { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<Processor> Processors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Computer>().ToTable("Computer", "DEVTASK");
            modelBuilder.Entity<Connection>().ToTable("Connection", "DEVTASK");
            modelBuilder.Entity<GraphicsCard>().ToTable("GraphicsCard", "DEVTASK");
            modelBuilder.Entity<Port>().ToTable("Port", "DEVTASK");
            modelBuilder.Entity<Processor>().ToTable("Processor", "DEVTASK");
        }
    }
}