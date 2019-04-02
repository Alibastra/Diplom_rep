using Microsoft.AspNetCore.Mvc;
using Hotel.Models;


namespace Hotel.Controllers
{
    public class RoomController:Controller
    {
        private IRoomRepository repository;
        public RoomController (IRoomRepository repo)
        {
            repository = repo;
        }
        public ViewResult List() => View(repository.Rooms);
    }
}
