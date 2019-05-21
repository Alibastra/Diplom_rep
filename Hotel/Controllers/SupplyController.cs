using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Hotel.Models;
using System.Linq;
using Hotel.Models.ViewModels;
using Npgsql.EntityFrameworkCore;
using System;

namespace Hotel.Controllers
{
    public class SupplyController : Controller
    {
        public int PageSize = 4;
        private ISupplyRepository repositorySu;
        private IServiceRepository repositorySe;
        public SupplyController(ISupplyRepository repoSu, IServiceRepository repoSe)
        {
            repositorySe = repoSe;
            repositorySu = repoSu;
        }

        public ViewResult List(int checkInID, int page = 1)
            => View(new SupplysListViewModel
            {
                Supplys = repositorySu.Supplys
                    .Where(p => (checkInID == 0 || p.CheckInID == checkInID))
                    .OrderBy(p => p.SupplyID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = checkInID == 0 ? repositorySu.Supplys.Count() : repositorySu.Supplys.Where(e => e.CheckInID == checkInID).Count()
                },
            });

        public ViewResult AddSupplyFilt(int checkInID,int serviceID, string category, string returnUrl, int page = 1, int pagesize = 6)
        {
            if (string.IsNullOrEmpty(category)) category = "";

            var model = new SupplysListViewModel()
            {
                ServiceID=(int)serviceID,
                Category = category
            };

            model.Services = repositorySe.Services
                    .Where(p =>(category == "" || p.Category == category)
                        && (p.ServiceID == serviceID|| serviceID==0))
                    .OrderBy(p => p.ServiceID)
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize);

            model.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pagesize,
                TotalItems = repositorySe.Services
                    .Where(p => (category == "" || p.Category == category)&& (p.ServiceID == serviceID || serviceID == 0)).Count()
            };
            model.ReturnUrl = returnUrl;
            model.CheckInID = checkInID;
            return View(model);
        }
      
        public ViewResult AddSupply(int checkInID, string returnUrl, int serviceID)
        {
            return View(new SupplyViewModel
            {
                Service = repositorySe.Services.FirstOrDefault(s => s.ServiceID ==serviceID),
                Supply = new Supply() { ServiceID = serviceID,
                    SupplyDate = DateTime.Now.Date,
                    CheckInID = checkInID,
                    Quantity = 1,
                    Price = (int) repositorySe.Services.FirstOrDefault(s => s.ServiceID == serviceID).Price,
                    ServiceName = repositorySe.Services.FirstOrDefault(s => s.ServiceID == serviceID).ServiceName
                },
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public IActionResult InsertSupply(Supply supply, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                repositorySu.InsertSupply(supply);
                TempData["message"] = $"Услуга с кодом {supply.ServiceID} была оказана для брони {supply.CheckInID}";
                return RedirectToAction(nameof(List));
            }
            else
            {
                return View("AddSupply",
                              new SupplyViewModel
                              {
                                  CheckInID = supply.CheckInID,
                                  ReturnUrl = returnUrl,
                                  ServiceID = supply.ServiceID,
                              });
            }
        }

        [HttpPost]
        public IActionResult ConfirmDeleteSupply(int supplyID, string returnUrl) =>
           View(new SupplyViewModel { Supply = repositorySu.Supplys.FirstOrDefault(r => r.SupplyID == supplyID),
               Service = repositorySe.Services.FirstOrDefault(s=>s.ServiceID ==(repositorySu.Supplys.FirstOrDefault(r => r.SupplyID == supplyID)).ServiceID),
               ReturnUrl = returnUrl });

        [HttpPost]
        public IActionResult DeleteSupply(Supply supply, string returnUrl)
        {
            repositorySu.DeleteSupply(supply);
            TempData["message"] = $"Предоставление услуги с кодом {supply.SupplyID} было удалено";
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        public ViewResult EditSupply(int supplyID, string returnUrl) =>
            View(new SupplyViewModel { Supply = repositorySu.Supplys.FirstOrDefault(r => r.SupplyID == supplyID),
               Service = repositorySe.Services.FirstOrDefault(s=>s.ServiceID ==repositorySu.Supplys.FirstOrDefault(r => r.SupplyID == supplyID).ServiceID),
               ReturnUrl = returnUrl });


        [HttpPost]
        public IActionResult UpdateSupply(Supply supply, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                repositorySu.UpdateSupply(supply);
                TempData["message"] = $"Изменения по оказанию услуги с кодом{supply.SupplyID} сохранены";
                return RedirectToAction(nameof(List));
            }
            else
            {
                return View(new SupplyViewModel { Supply = supply, ReturnUrl = returnUrl });
            }
        }
    }
}
