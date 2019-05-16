using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Hotel.Models;

namespace Hotel.Views.Shared.Components
{
    public class NavigationMenuSupplyViewComponent:ViewComponent
    {
        private ISupplyRepository repository;

        public NavigationMenuSupplyViewComponent(ISupplyRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            // ViewBag.SelectedCategory = RouteData?.Values[category];
            return View();
        }
    }
}
