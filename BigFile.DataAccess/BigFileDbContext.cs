using Microsoft.EntityFrameworkCore;
using System;

namespace BigFile.DataAccess
{
    public class BigFileDbContext : DbContext
    {
        public DbSet<BigFile> BigFiles { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public BigFileDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=./BigFile.db");
        }
    }
}