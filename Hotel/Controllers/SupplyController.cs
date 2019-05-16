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
        private ISupplyRepository repository;
        public SupplyController(ISupplyRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int checkInID, int page = 1)
            => View(new SupplysListViewModel
            {
                Supplys = repository.Supplys
                    .Where(p => (checkInID == 0 || p.CheckInID == checkInID))
                    .OrderBy(p => p.SupplyID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = checkInID == 0 ? repository.Supplys.Count() : repository.Supplys.Where(e => e.CheckInID == checkInID).Count()
                },
                CheckInID = checkInID
            });

        //public ViewResult AddRoom(string returnUrl) => View(new AddRoomViewModel { Room = new Room(), ReturnUrl = returnUrl });

        //[HttpPost]
        //public IActionResult InsertRoom(Room room, string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (repository.Rooms.FirstOrDefault(r => r.RoomID == room.RoomID) == null)
        //        {
        //            repository.InsertRoom(room);
        //            TempData["message"] = $"Room № {room.RoomID} has been added";
        //            return RedirectToAction(nameof(List));
        //        }
        //        else
        //        {
        //            TempData["message"] = $"Комната с номером {room.RoomID} уже существует.";
        //            return View(new AddRoomViewModel { Room = room, ReturnUrl = returnUrl });
        //        }
        //    }
        //    else { return View(new AddRoomViewModel { Room = room, ReturnUrl = returnUrl }); }
        //}

        //[HttpPost]
        //public IActionResult ConfirmDeleteRoom(int roomID, string returnUrl) =>
        //   View(new DeleteRoomViewModel { Room = repository.Rooms.FirstOrDefault(r => r.RoomID == roomID), ReturnUrl = returnUrl });

        //[HttpPost]
        //public IActionResult DeleteRoom(Room room, string returnUrl)
        //{
        //    repository.DeleteRoom(room);
        //    return RedirectToAction(nameof(List));
        //}

        //[HttpPost]
        //public ViewResult EditRoom(int roomID, string returnUrl) =>
        //    View(new EditRoomViewModel { Room = repository.Rooms.FirstOrDefault(r => r.RoomID == roomID), ReturnUrl = returnUrl });


        //[HttpPost]
        //public IActionResult UpdateRoom(Room room, string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        repository.UpdateRoom(room);
        //        TempData["message"] = $"Изменения по комнате № {room.RoomID} сохранены";
        //        return RedirectToAction(nameof(List));
        //    }
        //    else
        //    {
        //        return View(new EditRoomViewModel { Room = room, ReturnUrl = returnUrl });
        //    }
        //}
    }
}
