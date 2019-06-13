using ContactApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContactApp.Repository
{
    public partial class ContactDBContext : DbContext
    {
        public ContactDBContext()
        {
        }

        public ContactDBContext(DbContextOptions<ContactDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Contacts> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\v11.0;Initial Catalog=ContactDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                //
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("PK_Contact");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });
        }

    }
}
