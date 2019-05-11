using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Hotel.Models;
using System.Linq;
using Hotel.Models.ViewModels;
using Npgsql.EntityFrameworkCore;


namespace Hotel.Controllers
{
    public class CheckInController : Controller
    {
        public int PageSize = 8;
        private ICheckInRepository repositoryC;
        private IRoomRepository repositoryR;

        public CheckInController(ICheckInRepository repoC, IRoomRepository repoR)
        {
            repositoryC = repoC;
            repositoryR = repoR;
        }

        public ViewResult List(int customerId, int page = 1)
            => View(new CheckInsListViewModel
            {
                CheckIns = repositoryC.CheckIns
                    .OrderBy(p => p.CheckInID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems =repositoryC.CheckIns.Count()
                },
                CustomerID=customerId
            });

        public ViewResult AddCheckIn(int roomID, string returnUrl) => View(new CheckInViewModel { CheckIn = new CheckIn() {RoomID=roomID},Room = repositoryR.Rooms.FirstOrDefault(r => r.RoomID == roomID), ReturnUrl = returnUrl });

        [HttpPost]
        public IActionResult InsertCheckIn(CheckIn checkIn, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (repositoryC.CheckIns.FirstOrDefault(r => r.CheckInID == checkIn.CheckInID) == null)
                {
                    repositoryC.InsertCheckIn(checkIn);
                    TempData["message"] = $"CheckIn № {checkIn.CheckInID} has been added";
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    TempData["message"] = $"Комната с номером {checkIn.CheckInID} уже существует.";
                    return View(new CheckInViewModel { CheckIn = checkIn, ReturnUrl = returnUrl });
                }
            }
            else { return View(new CheckInViewModel { CheckIn = checkIn, ReturnUrl = returnUrl }); }
        }

        [HttpPost]
        public IActionResult ConfirmDeleteCheckIn(int checkInID, string returnUrl) =>
           View(new CheckInViewModel { CheckIn = repositoryC.CheckIns.FirstOrDefault(r => r.CheckInID == checkInID), ReturnUrl = returnUrl });

        [HttpPost]
        public IActionResult DeleteCheckIn(CheckIn checkIn, string returnUrl)
        {
            repositoryC.DeleteCheckIn(checkIn);
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        public ViewResult EditCheckIn(int checkInID, string returnUrl) =>
            View(new CheckInViewModel { CheckIn = repositoryC.CheckIns.FirstOrDefault(r => r.CheckInID == checkInID), ReturnUrl = returnUrl });


        [HttpPost]
        public IActionResult UpdateCheckIn(CheckIn checkIn, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                repositoryC.UpdateCheckIn(checkIn);
                TempData["message"] = $"Изменения по комнате № {checkIn.CheckInID} сохранены";
                return RedirectToAction(nameof(List));
            }
            else
            {
                return View(new CheckInViewModel { CheckIn = checkIn, ReturnUrl = returnUrl });
            }
        }
    }
}
