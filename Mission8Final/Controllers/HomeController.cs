using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission8Final.Models;
using Mission8Final.Models.ViewModels;

namespace Mission7Final.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository repo;

        public HomeController(IBookRepository context)
        {
            repo = context;
        }

        // Get the data from the Book databse and display its data in the index.cshtml
        // default page number is 1
        public IActionResult Index(string categoryType, int pageNum = 1)
        {
            // display 10 items per page
            // A page should have a list of 10 books
            int pageSize = 10;

            // define x with assigning a BooksViewModel instance
            // the instance has Books model and PageInfo model
            var x = new BooksViewModel
            {
                // Have a Books model with 10 items without the 10 previous items.
                Books = repo.Books
                .Where(x => x.Category == categoryType || categoryType == null)
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                // Define total number of projects, projects per page, and current page.
                PageInfo = new PageInfo
                {
                    TotalNumProjects = (categoryType == null ? repo.Books.Count() : repo.Books.Where(x => x.Category == categoryType).Count()),
                    ProjectsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            // return a view that contains BooksViewModel information
            return View(x);
        }

    }
}
