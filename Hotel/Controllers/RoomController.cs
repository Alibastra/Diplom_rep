using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Hotel.Models;
using System.Linq;
using Hotel.Models.ViewModels;

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
        //[HttpGet]
        public ViewResult AddRoom(Room room)=>View();

        //[HttpPost]
        //public ViewResult AddRoom(Rooms) {
        //    .AddRange(repository);
        //    return View("List");
        //}


        public ViewResult List(string category, int quantity, int page = 1)
            => View(new RoomsListViewModel
            {
                Rooms = repository.Rooms
                    .Where(p => ((category==null||p.Category==category)&&(quantity == 0||p.Quantity==quantity)))
                    .OrderBy(p => p.RoomID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? repository.Rooms.Count(): repository.Rooms.Where(e=>e.Category==category).Count()
                },
                CurrentCategory=category,
                CurrentQuantity=quantity
            });
    }
} 
