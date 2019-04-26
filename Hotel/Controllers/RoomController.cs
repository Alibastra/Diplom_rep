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

        public ViewResult List(string category, int quantity, int page = 1)
            => View(new RoomsListViewModel
            {
                Rooms = repository.Rooms
                    .Where(p => ((category == null || p.Category == category) && (quantity == 0 || p.Quantity == quantity)))
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
                CurrentQuantity = quantity
            });

        public ViewResult AddRoom() => View(new Room());

        [HttpPost]
        public IActionResult InsertRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                if (repository.Rooms.FirstOrDefault(r => r.RoomID == room.RoomID) == null)
                {
                    repository.InsertRoom(room);
                    TempData["message"] = $"Room № {room.RoomID} has been added";
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    TempData["message"] = $"Комната с номером {room.RoomID} уже существует.";
                    return View("AddRoom", room);
                }
            }
            else { return View("AddRoom", room); }
        }

        [HttpPost]
        public IActionResult ConfirmDeleteRoom(int roomID) =>
            View(repository.Rooms.FirstOrDefault(r => r.RoomID == roomID));

        [HttpPost]
        public IActionResult DeleteRoom(int roomID)
        {
            repository.DeleteRoom(roomID);
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        public ViewResult EditRoom(int roomID, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(repository.Rooms.FirstOrDefault(r => r.RoomID == roomID));
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
                ViewBag.ReturnUrl = returnUrl;
                return View("EditRoom", room);
            }

        }
    }
}
