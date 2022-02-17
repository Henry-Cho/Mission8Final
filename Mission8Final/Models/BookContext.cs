using System;
using Microsoft.EntityFrameworkCore;

namespace Mission8Final.Models
{
    public class BookContext : DbContext
    {
        public BookContext()
        {

        }

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
