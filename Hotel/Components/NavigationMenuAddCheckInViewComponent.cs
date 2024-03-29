﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Hotel.Models;
using Hotel.Models.ViewModels;

namespace Hotel.Views.Shared.Components
{
    public class NavigationMenuAddCustomerViewComponent : ViewComponent
    {
        private ICheckInRepository repositoryC;
        private ICustomerRepository repositoryCu;


        public NavigationMenuAddCustomerViewComponent(ICheckInRepository repoC, ICustomerRepository repoCu)
        {
            repositoryC = repoC;
            repositoryCu = repoCu;
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
