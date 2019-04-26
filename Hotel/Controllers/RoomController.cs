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
        public IActionResult Save(Room room)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRoom(room);
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

        [HttpGet]
        public IActionResult EditRoom(int? roomID)
        {
            if (roomID != null)
            {
                Room room = repository.Rooms.FirstOrDefault(r => r.RoomID == roomID);
                return View(room);
                //repository.EditRoom(room);
                //return RedirectToAction(nameof(EditRoom));
            }
            return NotFound(); 
        }
        [HttpPost]
        public IActionResult EditRoom(Room room)
        {
            //if (roomID != null)
            repository.EditRoom(room);
            return RedirectToAction("List");
        }
        public IActionResult Cancel() => RedirectToAction(nameof(List));
    }
} 
