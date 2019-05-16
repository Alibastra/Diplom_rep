using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Hotel.Models;
using System.Linq;
using Hotel.Models.ViewModels;
using Npgsql.EntityFrameworkCore;


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

        //public ViewResult AddSupply(string returnUrl) => View(new AddSupplyViewModel { Supply = new Supply(), ReturnUrl = returnUrl });

        [HttpPost]
        public IActionResult InsertSupply(Supply room, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (repositorySu.Supplys.FirstOrDefault(r => r.SupplyID == room.SupplyID) == null)
                {
                    repositorySu.InsertSupply(room);
                    TempData["message"] = $"Supply № {room.SupplyID} has been added";
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    TempData["message"] = $"Комната с номером {room.SupplyID} уже существует.";
                    return View(new SupplyViewModel { Supply = room, ReturnUrl = returnUrl });
                }
            }
            else { return View(new SupplyViewModel { Supply = room, ReturnUrl = returnUrl }); }
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
