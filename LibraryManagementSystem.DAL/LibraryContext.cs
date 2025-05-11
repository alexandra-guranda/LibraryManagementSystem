using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Models;
using System;
using System.IO;

namespace LibraryManagementSystem.DAL
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<WaitlistEntry> WaitlistEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "library.db");
            optionsBuilder.UseSqlite($"Data Source={path}");
        }
    }
}
