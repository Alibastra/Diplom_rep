using Microsoft.AspNetCore.Mvc;
using Hotel.Models;
using System.Linq;
using Hotel.Models.ViewModels;

namespace Hotel.Controllers
{
    public class RoomController:Controller
    {
        public int PageSize = 4; 
        private IRoomRepository repository;
        public RoomController (IRoomRepository repo)
        {
            repository = repo;
        }
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
                    TotalItems = repository.Rooms.Count()
                },
                CurrentCategory=category,
                CurrentQuantity=quantity
            });
    }
}
