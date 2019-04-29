using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(ApplicationDbContext context)
        {
            if (!context.Rooms.Any())
            {
                context.Rooms.AddRange(
                    new Room
                    {
                        RoomID = 1,
                        Price = 1200,
                        Category = "Luxe",
                        Quantity = 2,
                        State = true,
                        Comments = "It's room №1"
                    },
                    new Room
                    {
                        RoomID = 2,
                        Price = 300,
                        Category = "Econom",
                        Quantity = 2,
                        State = true,
                        Comments = "It's room №2"
                    },
                    new Room
                    {
                        RoomID = 3,
                        Price = 1200,
                        Category = "Luxe",
                        Quantity = 2,
                        State = false,
                        Comments = "It's room №2"
                    },
                    new Room
                    {
                        RoomID = 4,
                        Price = 1200,
                        Category = "Luxe",
                        Quantity = 2,
                        State = true,
                        Comments = "It's room №4"
                    },
                    new Room
                    {
                        RoomID = 5,
                        Price = 1200,
                        Category = "Standart",
                        Quantity = 3,
                        State = true,
                        Comments = "It's room №5"
                    },
                    new Room
                    {
                        RoomID = 6,
                        Price = 1200,
                        Category = "Standart",
                        Quantity = 3,
                        State = true,
                        Comments = "It's room №6"
                    },
                    new Room
                    {
                        RoomID = 7,
                        Price = 1200,
                        Category = "Econom",
                        Quantity = 3,
                        State = true,
                        Comments = "It's room №7"
                    },
                    new Room
                    {
                        RoomID = 8,
                        Price = 1200,
                        Category = "Standart",
                        Quantity = 3,
                        State = true,
                        Comments = "It's room №8"
                    }
                    );
                context.SaveChanges();

            }
            if (!context.Services.Any())
            {
                context.Services.AddRange(
                    new Service
                    {
                        ServiceID = 1,
                        Price = 1200,
                        ServiceName = "Услуга № 1",
                        Category = "Основные",
                        State = true,
                        Comments = "Ля-ля-ля"
                    },
                    new Service
                    {
                        ServiceID = 2,
                        Price = 1200,
                        ServiceName = "Услуга № 1",
                        Category = "Дополнительные",
                        State = true,
                        Comments = "Ля-ля-ля"
                    },
                    new Service
                    {
                        ServiceID = 3,
                        Price = 1200,
                        ServiceName = "Услуга № 1",
                        Category = "Индивидуальные",
                        State = true,
                        Comments = "Ля-ля-ля"
                    },
                    new Service
                    {
                        ServiceID = 4,
                        Price = 1200,
                        ServiceName = "Услуга № 1",
                        Category = "Основные",
                        State = true,
                        Comments = "Ля-ля-ля"
                    },
                    new Service
                    {
                        ServiceID = 5,
                        Price = 1200,
                        ServiceName = "Услуга № 1",
                        Category = "Дополнительные",
                        State = true,
                        Comments = "Ля-ля-ля"
                    });
                context.SaveChanges();
            }
            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                   new Customer
                   {
                       CustomerID = 1,
                       FirstName = "Анастасия",
                       LastName = "Уварова",
                       BithDate =new DateTime(1997,09,26),
                       Email = "kotenok26_97@mail.ru",
                       PhoneNumber = "89253136326"
                   },
                   new Customer
                   {
                       CustomerID = 2,
                       FirstName = "Анастасия",
                       LastName = "Сомова",
                       BithDate = new DateTime(1997, 09, 26),
                       Email = "kotenok26_97@mail.ru",
                       PhoneNumber = "89253136326"
                   },
                   new Customer
                   {
                       CustomerID = 3,
                       FirstName = "Анастасия",
                       LastName = "Карелина",
                       BithDate = new DateTime(1997, 09, 26),
                       Email = "kotenok26_97@mail.ru",
                       PhoneNumber = "89253136326"
                   });
                context.SaveChanges();
            }
        }

    }
}