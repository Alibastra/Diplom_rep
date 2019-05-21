using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Hotel.Models;
using Hotel.Models.ViewModels;

namespace Hotel.Views.Shared.Components
{
    public class NavigationMenuAddSupplyViewComponent : ViewComponent
    {
        private ICheckInRepository repositorySu;
        private ISupplyRepository repositorySe;


        public NavigationMenuAddSupplyViewComponent(ICheckInRepository repoSu, ISupplyRepository repoSe)
        {
            repositorySu = repoSu;
            repositorySe = repoSe;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
