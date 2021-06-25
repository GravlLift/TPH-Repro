using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBHRepro.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Person> People { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>(
                eb =>
                {
                    eb.HasMany(c => c.Entities)
                        .WithOne(p => p.Contact)
                        .HasForeignKey(p => p.ContactId)
                        .IsRequired();
                    eb.HasOne(c => c.Person)
                        .WithOne(p => p.Contact)
                        .HasForeignKey<Person>(p => p.ContactId)
                        .IsRequired();
                }
            );

            modelBuilder.Entity<Entity>(
                eb =>
                {
                    eb.HasDiscriminator<string>("EntityType");
                }
            );

            modelBuilder.Entity<Business>(
                eb =>
                {
                    eb.HasBaseType<Entity>();
                }
            );

            modelBuilder.Entity<Person>(
                eb =>
                {
                    eb.HasBaseType<Entity>();
                }
            );
        }
    }
}
