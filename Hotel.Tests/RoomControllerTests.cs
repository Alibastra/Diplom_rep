using System.Collections.Generic;
using System.Linq;
using Hotel.Controllers;
using Hotel.Models;
using Moq;
using Xunit;



namespace Hotel.Tests
{
    public class RoomControllerTests
    {
        [Fact]
        public void Can_Paginate()
        {
            //Организация
            Mock<IRoomRepository> mock = new Mock<IRoomRepository>();
            mock.Setup(m => m.Rooms).Returns(new RoomControllerTests[] {
                new Room {RoomID = 1, RoomNumber = 1 },
                new Room {RoomID = 2, RoomNumber = 2 },
                new Room {RoomID = 3, RoomNumber = 3 },
                new Room {RoomID = 4, RoomNumber = 4 },
                new Room {RoomID = 5, RoomNumber = 5 }
            });
            RoomController;
        }
    }

}
