using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Hotel.Models;
using System.Linq;
using Hotel.Models.ViewModels;
using Npgsql.EntityFrameworkCore;


namespace Hotel.Controllers
{
    public class ServiceController : Controller
    {
        public int PageSize = 8;
        private IServiceRepository repository;
        public ServiceController(IServiceRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(string category, int page = 1)
            => View(new ServicesListViewModel
            {
                Services = repository.Services
                    .Where(p => (category == null || p.Category == category))
                    .OrderBy(p => p.ServiceID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? repository.Services.Count() : repository.Services.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category,
            });

        public ViewResult AddService(string returnUrl) => View(new ServiceViewModel { Service = new Service(), ReturnUrl = returnUrl });

        [HttpPost]
        public IActionResult InsertService(Service service, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (repository.Services.FirstOrDefault(r => r.ServiceID == service.ServiceID) == null)
                {
                    repository.InsertService(service);
                    TempData["message"] = $"Комната с номером {service.ServiceID} была создана";
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    TempData["message"] = $"Комната с номером {service.ServiceID} уже существует.";
                    return View("AddService", new ServiceViewModel { Service = service, ReturnUrl = returnUrl });
                }
            }
            else { return View("AddService", new ServiceViewModel { Service = service, ReturnUrl = returnUrl }); }
        }

        [HttpPost]
        public IActionResult ConfirmDeleteService(int serviceID, string returnUrl) =>
            View(new ServiceViewModel { Service = repository.Services.FirstOrDefault(r => r.ServiceID == serviceID), ReturnUrl = returnUrl });

        [HttpPost]
        public IActionResult DeleteService(Service service)
        {
            repository.DeleteService(service);
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        public ViewResult EditService(int serviceID, string returnUrl)
        {
            return View(new ServiceViewModel { Service = repository.Services.FirstOrDefault(r => r.ServiceID == serviceID), ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult UpdateService(Service service, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateService(service);
                TempData["message"] = $"Изменения по комнате № {service.ServiceID} сохранены";
                return RedirectToAction(nameof(List), new { returnUrl });
            }
            else
            {
                return View("EditService", new ServiceViewModel { Service = service, ReturnUrl = returnUrl });
            }
        }
    }
}
