using System;
using Microsoft.EntityFrameworkCore;

namespace Texter.Models
{
    public class TexterDbContext : DbContext
    {
        public TexterDbContext()
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=Texter;uid=root;pwd=root;");
        }

        public TexterDbContext(DbContextOptions<TexterDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}