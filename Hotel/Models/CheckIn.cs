using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Hotel.Models
{
    public class CheckIn
    {
        [Key]
        public int CheckInID { get; set; }

        public int RoomID { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime Department { get; set; }

        public string LastName { get; set; }

        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Пожалуста, введите номер телефона гостя!")]
        public string PhoneNumber { get; set; }
    }
}
