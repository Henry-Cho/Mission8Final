using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission8Final.Infrastructure;
using Mission8Final.Models;

namespace Mission8Final.Pages
{
    public class ShoppingModel : PageModel
    {
        private IBookRepository repo { get; set; }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public ShoppingModel(IBookRepository temp)
        {
            repo = temp;
        }

        // Get
        public void OnGet(string returnUrl)
        {
            // set the ReturnUrl which is going to be where a user can go back
            ReturnUrl = returnUrl ?? "/";
            // If there is an object whose key is basket, get the json of the object or create a instance of Basket model
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        // Post
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            // Get the specific book info that matches the given bookId
            Book p = repo.Books.FirstOrDefault(x => x.BookID == bookId);

            // If there is an object whose key is basket, get the json of the object or create a instance of Basket model
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            // Add item to the basket
            basket.AddItem(p, 1);

            // Set the json with the newly added item
            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
