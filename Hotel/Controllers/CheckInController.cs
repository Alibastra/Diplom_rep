using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Hotel.Models;
using System.Linq;
using Hotel.Models.ViewModels;
using Npgsql.EntityFrameworkCore;
using System;


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

        public ViewResult List(string lastname, int page = 1)
            => View(new CheckInsListViewModel
            {
                CheckIns = repositoryC.CheckIns
                    .Where(p => (lastname == null || p.LastName.ToLower().IndexOf(lastname.ToLower()) >= 0))
                    .OrderBy(p => p.CheckInID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems =repositoryC.CheckIns.Count()
                },
                LastName = lastname
            });

        public ViewResult AddCheckInFilt(CheckInNewViewModel checkInNew, string returnUrl, int page = 1, int pagesize = 6)
        {
            if (checkInNew == null)
            {
                checkInNew = new CheckInNewViewModel()
                {
                    Quantity = 0,
                    CheckIn = new CheckIn() { Arrival = DateTime.Now, Department = DateTime.Now.AddDays(1) }
                };
            }
            checkInNew.Rooms = repositoryR.Rooms
                    .Where(p =>
                           (checkInNew.Category == null || p.Category == checkInNew.Category)
                        && (checkInNew.Quantity == 0 || p.Quantity >= checkInNew.Quantity)
                        && repositoryC.CheckIns.FirstOrDefault(c => c.RoomID == p.RoomID && checkInNew?.CheckIn!= null &&
                           (c.Arrival >= checkInNew.CheckIn.Arrival && c.Arrival < checkInNew.CheckIn.Department || c.Department <= checkInNew.CheckIn.Department && c.Department > checkInNew.CheckIn.Arrival)) == null
                    )
                    .OrderBy(p => p.RoomID)
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize);

            checkInNew.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pagesize,
                TotalItems = checkInNew.Category == null ? repositoryR.Rooms.Count() : repositoryR.Rooms.Where(e => e.Category == checkInNew.Category).Count()
            };
            checkInNew.ReturnUrl = returnUrl;
            return View(checkInNew);

            return View(new CheckInNewViewModel
            {
                Rooms = repositoryR.Rooms
                    .Where(p =>
                           (checkInNew.Category == null || p.Category == checkInNew.Category)
                        && (checkInNew.Quantity == 0 || p.Quantity >= checkInNew.Quantity)
                        && repositoryC.CheckIns.FirstOrDefault(c => c.RoomID == p.RoomID && (c.Arrival >= checkInNew.CheckIn.Arrival && c.Arrival < checkInNew.CheckIn.Department || c.Department <= checkInNew.CheckIn.Department && c.Department > checkInNew.CheckIn.Arrival)) == null
                    )
                    .OrderBy(p => p.RoomID)
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pagesize,
                    TotalItems = checkInNew.Category == null ? repositoryR.Rooms.Count() : repositoryR.Rooms.Where(e => e.Category == checkInNew.Category).Count()
                },
                CheckIn = checkInNew.CheckIn,
                Category = checkInNew.Category,
                Quantity = checkInNew.Quantity,
                ReturnUrl = returnUrl
            });
        }

        public ViewResult AddCheckIn(int roomID, string returnUrl, DateTime arrival, DateTime depart ) =>
            View(new CheckInViewModel {
                CheckIn = new CheckIn() {RoomID=roomID, Arrival=arrival, Department= depart},
                Room = repositoryR.Rooms.FirstOrDefault(r => r.RoomID == roomID),
                ReturnUrl = returnUrl
            });

        [HttpPost]
        public IActionResult InsertCheckIn(CheckIn checkIn, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if ((checkIn.LastName==null&&checkIn.CheckInID>0)|| (checkIn.LastName != null && checkIn.CheckInID <= 0))
                {
                    repositoryC.InsertCheckIn(checkIn);
                    TempData["message"] = $"Комната с номером {checkIn.RoomID} была забранированна для клиента {checkIn.LastName}";
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    TempData["message"] = $"Выберите только один идентификатор для клиента!";
                    return View(" AddCheckIn", 
                                new CheckInViewModel
                                {
                                    CheckIn = checkIn,
                                    Room = repositoryR.Rooms.FirstOrDefault(r => r.RoomID == checkIn.RoomID),
                                    ReturnUrl = returnUrl
                                });
                }
            }
            else { return View(" AddCheckIn",
                                 new CheckInViewModel
                                 {
                                     CheckIn = checkIn,
                                     Room = repositoryR.Rooms.FirstOrDefault(r => r.RoomID == checkIn.RoomID),
                                     ReturnUrl = returnUrl
                                 });
            }
        }

        [HttpPost]
        public IActionResult ConfirmDeleteCheckIn(int checkInID, string returnUrl) =>
           View(new CheckInViewModel { CheckIn = repositoryC.CheckIns.FirstOrDefault(c => c.CheckInID == checkInID),
               Room = repositoryR.Rooms.FirstOrDefault(r => r.RoomID == repositoryC.CheckIns.FirstOrDefault(c => c.CheckInID == checkInID).RoomID),
               ReturnUrl = returnUrl });

        [HttpPost]
        public IActionResult DeleteCheckIn(CheckIn checkIn, string returnUrl)
        {
            repositoryC.DeleteCheckIn(checkIn);
            TempData["message"] = $"Бронирование с кодом {checkIn.CheckInID} было удалено";
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        public ViewResult EditCheckIn(int checkInID, string returnUrl) =>
            View(new CheckInViewModel { CheckIn = repositoryC.CheckIns.FirstOrDefault(r => r.CheckInID == checkInID),
                Room = repositoryR.Rooms.FirstOrDefault(r => r.RoomID == repositoryC.CheckIns.FirstOrDefault(c => c.CheckInID == checkInID).RoomID),
                ReturnUrl = returnUrl });


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
