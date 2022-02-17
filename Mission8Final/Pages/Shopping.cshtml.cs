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

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book p = repo.Books.FirstOrDefault(x => x.BookID == bookId);

            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(p, 1);

            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
