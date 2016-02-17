using DataLayer.Models;

namespace DataLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SimpleApp : DbContext
    {
        public SimpleApp()
            : base("name=SimpleApp")
        {
        }

        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
