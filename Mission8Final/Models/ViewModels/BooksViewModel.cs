using System;
using System.Linq;

namespace Mission8Final.Models.ViewModels
{
    public class BooksViewModel
    {
        // in order to pass two model into one view
        public IQueryable<Book> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
