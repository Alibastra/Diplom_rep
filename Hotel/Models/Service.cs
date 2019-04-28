using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Service
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Пожалуста, введите корректный номер услуги!")]
        public int ServiceID { get; set; }

        [Required(ErrorMessage = "Пожалуста, выберите категорию!")]
        public string Category { get; set; }

        [Required( ErrorMessage = "Пожалуста, введите название услуги!")]
        public string ServiceName { get; set; }

        [Required]
        [Range(0.00, double.MaxValue, ErrorMessage = "Пожалуйста, введите цену услуги!")]
        public decimal Price { get; set; }

        public string Comments { get; set; }

        public bool State { get; set; }
    }
}
