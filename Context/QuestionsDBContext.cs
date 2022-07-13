using Dissertation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dissertation.Context
{
    public class QuestionsDBContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }

        public QuestionsDBContext(DbContextOptions<QuestionsDBContext>options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().ToTable("Questions");
        }
    }
}
