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

        [Required]
        public int RoomID { get; set; }

        [Required]
        public DateTime Arrival { get; set; }

        [Required]
        public DateTime Department { get; set; }

        [Required(ErrorMessage = "Пожалуста, введите фамилию гостя!")]
        public string LastName { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Пожалуста, введите корректный номер телефона гостя!")]
        public string PhoneNumber { get; set; }
    }
}
