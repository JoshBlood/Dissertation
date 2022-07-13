using Dissertation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dissertation.Context
{
    public class TestDBContext : DbContext      
    {
        private static DbContextOptions options;

        public DbSet<Test> Tests { get; set; }

        public TestDBContext(DbContextOptions<TestDBContext>options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>().ToTable("Tests");
        }
    }

}
