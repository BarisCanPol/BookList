using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<BookGenre> BookGenre { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Author> Author { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookGenre>()
                .HasKey(bc => new { bc.BookId, bc.GenreId });
            modelBuilder.Entity<BookGenre>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(bc => bc.BookId);
            modelBuilder.Entity<BookGenre>()
                .HasOne(bc => bc.Genre)
                .WithMany(c => c.BookGenres)
                .HasForeignKey(bc => bc.GenreId);
        }

    }
}
