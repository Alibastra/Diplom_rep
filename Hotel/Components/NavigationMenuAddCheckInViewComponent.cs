using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Hotel.Models;
using Hotel.Models.ViewModels;

namespace Hotel.Views.Shared.Components
{
    public class NavigationMenuAddCheckInViewComponent : ViewComponent
    {
        private ICheckInRepository repositoryC;
        private IRoomRepository repositoryR;


        public NavigationMenuAddCheckInViewComponent(ICheckInRepository repoC, IRoomRepository repoR)
        {
            repositoryC = repoC;
            repositoryR = repoR;
        }
        public IViewComponentResult Invoke()
        {
            return View();
            //return View(new CustomersListViewModel());
            // ViewBag.SelectedCategory = RouteData?.Values[category];
            //return View(repositoryR.Rooms
            //    .Select(x => x.Category)
            //    .Distinct()
            //    .OrderBy(x => x));
        }
    }
}
