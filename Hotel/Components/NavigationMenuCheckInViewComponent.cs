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
        public IViewComponentResult Invoke()=> View();
    }
}
