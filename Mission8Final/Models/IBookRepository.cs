using System;
using System.Linq;

namespace Mission8Final.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
