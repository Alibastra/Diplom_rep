using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required (ErrorMessage = "Пожалуста, введите имя гостя!")]
        public string FirstName { get; set;}

        [Required (ErrorMessage = "Пожалуста, введите фамилию готя!")]
        public string LastName { get; set; }

        [Required (ErrorMessage = "Пожалуста, введите дату рождения гостя!")]
        public DateTime BithDate { get; set; }

        [Required (ErrorMessage = "Пожалуста, введите адрес почты!")]
        public string Email{ get; set; }

        [Required (ErrorMessage = "Пожалуста, введите номер телефона гостя!")]
        public string PhoneNumber { get; set; }
    }
}
