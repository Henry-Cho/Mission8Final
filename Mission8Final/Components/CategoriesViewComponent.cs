using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mission8Final.Models;

namespace Mission8Final.Components
{
    // this is linked to the components folder in the Shared folder
    public class TypesViewComponent : ViewComponent
    {
        private IBookRepository repo { get; set; }

        public TypesViewComponent(IBookRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            // This indicates what the current selected categoryType is
            ViewBag.SelectedType = RouteData?.Values["categoryType"];

            // Only show the unique categories
            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
