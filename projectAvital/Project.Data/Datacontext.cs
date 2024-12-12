using Microsoft.EntityFrameworkCore;
using Project.core.model;
using Project.Data;
using System;

namespace Project.Data
{
    public class Datacontext:DbContext
    {
        public DbSet<Guide> guides { get; set; }
        public DbSet<Registeres> registeres { get; set; }
        public DbSet<Trip> trips { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Trips");
        }

    }
}
