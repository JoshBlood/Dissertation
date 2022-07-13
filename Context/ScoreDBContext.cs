using Dissertation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dissertation.Context
{
    public class ScoreDBContext : DbContext
    {
        public DbSet<Score> Scores { get; set; }

        public ScoreDBContext(DbContextOptions<ScoreDBContext>options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Score>().ToTable("Scores");
        }
    }
}
