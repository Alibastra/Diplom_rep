using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Hotel.Models;
using System.Linq;
using Hotel.Models.ViewModels;
using Npgsql.EntityFrameworkCore;


namespace Hotel.Controllers
{
    public class RoomController : Controller
    {
        public int PageSize = 4;
        private IRoomRepository repository;
        public RoomController(IRoomRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int page = 1)
            => View(new RoomsListViewModel
            {
                Rooms = repository.Rooms
                    .Where(p => (category == null || p.Category == category))
                    .OrderBy(p => p.RoomID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? repository.Rooms.Count() : repository.Rooms.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category,
            });

        public ViewResult AddRoom(string returnUrl) => View(new RoomViewModel { Room = new Room(), ReturnUrl=returnUrl});

        [HttpPost]
        public IActionResult InsertRoom(Room room, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (repository.Rooms.FirstOrDefault(r => r.RoomID == room.RoomID) == null)
                {
                    repository.InsertRoom(room);
                    TempData["message"] = $"Комната с номером {room.RoomID} была создана";
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    TempData["message"] = $"Комната с номером {room.RoomID} уже существует.";
                    return View("AddRoom", new RoomViewModel { Room = room, ReturnUrl = returnUrl });
                }
            }
            else { return View("AddRoom", new RoomViewModel { Room = room, ReturnUrl = returnUrl }); }
        }

        [HttpPost]
        public IActionResult ConfirmDeleteRoom(int roomID, string returnUrl) =>
            View(new RoomViewModel { Room = repository.Rooms.FirstOrDefault(r => r.RoomID == roomID), ReturnUrl = returnUrl });

        [HttpPost]
        public IActionResult DeleteRoom(Room room)
        {
            repository.DeleteRoom(room);
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        public ViewResult EditRoom(int roomID, string returnUrl)
        {
            return View(new RoomViewModel { Room = repository.Rooms.FirstOrDefault(r => r.RoomID == roomID), ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult UpdateRoom(Room room, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateRoom(room);
                TempData["message"] = $"Изменения по комнате № {room.RoomID} сохранены";
                return RedirectToAction(nameof(List), new { returnUrl});
            }
            else
            {
                return View("EditRoom", new RoomViewModel { Room = room, ReturnUrl = returnUrl });
            }
        }
    }
}
