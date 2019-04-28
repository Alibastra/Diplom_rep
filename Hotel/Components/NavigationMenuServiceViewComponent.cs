using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Hotel.Models;

namespace Hotel.Views.Shared.Components
{
    public class NavigationMenuServiceViewComponent:ViewComponent
    {
        private IServiceRepository repository;

        public NavigationMenuServiceViewComponent(IServiceRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
           // ViewBag.SelectedCategory = RouteData?.Values[category];
            return View(repository.Services
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
