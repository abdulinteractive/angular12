using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /// base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<User>().ToTable("User");
            //modelBuilder.Entity<User>().HasIndex(u => u.UserId).IsUnique(true);

        }
    }
}
