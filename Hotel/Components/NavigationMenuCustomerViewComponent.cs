﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Hotel.Models;
using Hotel.Models.ViewModels;

namespace Hotel.Views.Shared.Components
{
    public class NavigationMenuCustomerViewComponent : ViewComponent
    {
        private ICustomerRepository repository;

        public NavigationMenuCustomerViewComponent(ICustomerRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
