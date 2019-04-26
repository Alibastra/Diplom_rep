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


        public IActionResult Save(Room room)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRoom(room);
                TempData["message"] = $"Room № {room.RoomID} has been added";
                return RedirectToAction(nameof(AddRoom));
            }
            else { return View(room); }
        }

        [HttpPost]
        public IActionResult DeleteRoom(int roomID)
        {
            repository.DeleteRoom(roomID);
            return RedirectToAction(nameof(List));
        }

        public ViewResult EditRoom(int roomID) =>
            View(repository.Rooms.FirstOrDefault(r => r.RoomID == roomID));

        [HttpPost]
        public IActionResult EditRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                repository.EditRoom(room);
                TempData["message"] = $"Room № {room.RoomID} has been edited";
                return RedirectToAction(nameof(List));
            }
            else
            {
                return View(room);
            }

        }
    }
}
