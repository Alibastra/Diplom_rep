using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Hotel.Models;
using Hotel.Models.ViewModels;

namespace Hotel.Views.Shared.Components
{
    public class NavigationMenuRoomViewComponent:ViewComponent
    {
        private IRoomRepository repository;
        
        public NavigationMenuRoomViewComponent(IRoomRepository repo)
        {
            repository = repo;
        }

        //public IViewComponentResult Invoke()
        //{
        //    var model = new NavigationMenuRoomViewModel()
        //    {
        //        CurrentCategory = RouteData?.Values["category"],
        //        Categorys = repository.Rooms
        //        .Select(x => x.Category)
        //        .Distinct()
        //        .OrderBy(x => x)
        //    };
        //}

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["CurrentCategory"];
            return View(repository.Rooms
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
