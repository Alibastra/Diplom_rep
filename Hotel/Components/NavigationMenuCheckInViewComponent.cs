using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Hotel.Models;
using Hotel.Models.ViewModels;

namespace Hotel.Views.Shared.Components
{
    public class NavigationMenuCheckInViewComponent : ViewComponent
    {
        private ICheckInRepository repository;

        public NavigationMenuCheckInViewComponent(ICheckInRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            return View();
            //return View(new CustomersListViewModel());
            // ViewBag.SelectedCategory = RouteData?.Values[category];
            //return View(repository.Customers
            //    .Select(x => x.LastName)
            //    .Distinct()
            //    .OrderBy(x => x));
        }
    }
}
