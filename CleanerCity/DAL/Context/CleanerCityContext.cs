using CleanerCity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace CleanerCity.DAL.Context
{
    public class CleanerCityContext : DbContext
    {
        public CleanerCityContext() : base("name=ConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<RequestType> RequestTypes { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}
