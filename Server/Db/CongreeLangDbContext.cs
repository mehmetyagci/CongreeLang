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
        public DbSet<TagDetail> TagDetails { get; set; }
        #endregion DbSets

        public CongreeLangDbContext(DbContextOptions<CongreeLangDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>().ToTable(nameof(Document));
            modelBuilder.Entity<Tag>().ToTable(nameof(Tag));
            modelBuilder.Entity<TagDetail>().ToTable(nameof(TagDetail));
        }
    }
}
