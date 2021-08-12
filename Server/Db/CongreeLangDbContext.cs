using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Db
{
    public class CongreeLangDbContext : DbContext
    {
        #region DbSets

        public DbSet<Document> Documents { get; set; }
        public DbSet<Tag> Tags { get; set; }

        #region Analysis
        public DbSet<Analysis> Analyzes { get; set; }
        public DbSet<AnalysisItem> AnalysisItems { get; set; }

        #endregion Analysis

        #endregion DbSets

        public CongreeLangDbContext(DbContextOptions<CongreeLangDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>().ToTable(nameof(Document));
            modelBuilder.Entity<Tag>().ToTable(nameof(Tag));

            modelBuilder.Entity<Analysis>().ToTable(nameof(Analysis));
            modelBuilder.Entity<AnalysisItem>().ToTable(nameof(AnalysisItem));

            modelBuilder.Entity<AnalysisItem>()
            .HasOne(e => e.Tag)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction); // <-- Add this
        }
    }
}
