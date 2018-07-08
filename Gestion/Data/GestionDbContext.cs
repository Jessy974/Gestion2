using Gestion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gestion.Data
{
    public class GestionDbContext : DbContext
    {
        public GestionDbContext() : base("Gestion")
        {
        }
        public DbSet<Application> Applications { get; set; }
        public DbSet<User> Users { get; set; }
    }
}