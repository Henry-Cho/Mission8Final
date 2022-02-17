using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mission8Final.Models;

namespace Mission8Final.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookRepository repo { get; set; }

        public TypesViewComponent(IBookRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["categoryType"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
