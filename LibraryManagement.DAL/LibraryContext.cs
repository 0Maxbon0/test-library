using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace LibraryManagement.DAL
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<Penalty> Penalties { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Checkout>()
                .HasOne(c => c.Book)
                .WithMany(b => b.Checkouts)
                .HasForeignKey(c => c.BookID);

            modelBuilder.Entity<Checkout>()
                .HasOne(c => c.Member)
                .WithMany(m => m.Checkouts)
                .HasForeignKey(c => c.MemberID);

            modelBuilder.Entity<Return>()
                .HasOne(r => r.Checkout)
                .WithOne(c => c.Return)
                .HasForeignKey<Return>(r => r.CheckoutID);

            modelBuilder.Entity<Penalty>()
                .HasOne(p => p.Checkout)
                .WithOne(c => c.Penalty)
                .HasForeignKey<Penalty>(p => p.CheckoutID);
        }
    }
}
