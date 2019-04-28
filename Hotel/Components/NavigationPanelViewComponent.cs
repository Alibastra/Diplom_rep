using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Hotel.Models;

namespace Hotel.Views.Shared.Components
{
    public class NavigationPanelViewComponent:ViewComponent
    {
        private IRoomRepository repository;

        public NavigationPanelViewComponent(IRoomRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            // ViewBag.SelectedCategory = RouteData?.Values[category];
            return View(repository.Rooms
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
