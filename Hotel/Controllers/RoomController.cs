using Microsoft.AspNetCore.Mvc;
using Hotel.Models;
using System.Linq;

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
        public ViewResult List(int page=1) 
            => View(repository.Rooms
                .OrderBy(p=>p.RoomID)
                .Skip((page-1)*PageSize)
                .Take(PageSize));
    }
}
