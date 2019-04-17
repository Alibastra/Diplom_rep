//using System.Linq;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http;
//using Hotel.Infrastructure;
//using Hotel.Models;

//namespace Hotel.Controllers
//{
//    public class EditController : Controller
//    {
//        private IRoomRepository repository;
//        public EditController(IRoomRepository repo)
//        {
//            repository = repo;
//        }
//        public RedirectToActionResult Edit(int roomID, string returnUrl)
//        {
//            Room room = repository.Rooms
//                .FirstOrDefault(p => p.RoomID == roomID);
//            if (room != null)
//            {
//                Edit edit
//            }
//        }
//    }
//}