using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Hotel.Models;
using System.Linq;
using Hotel.Models.ViewModels;
using Npgsql.EntityFrameworkCore;
using System;

namespace Hotel.Controllers
{
    public class CustomerController : Controller
    {
        public int PageSize = 4;
        private ICustomerRepository repositoryCu;
        private ICheckInRepository repositoryCh;
        public CustomerController(ICustomerRepository repoCu, ICheckInRepository repoCh)
        {
            repositoryCu = repoCu;
            repositoryCh = repoCh;
        }

        public ViewResult List(string lastname, int page = 1)
            => View(new CustomersListViewModel
            {
                Customers = repositoryCu.Customers
                    .Where(p => (lastname == null || p.LastName.ToLower().IndexOf(lastname.ToLower())>=0))
                    .OrderBy(p => p.CustomerID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = lastname == null ? repositoryCu.Customers.Count() : repositoryCu.Customers.Where(e => e.LastName == lastname).Count()
                },
                LastName = lastname
            });

        public ViewResult AddCustomer(string returnUrl, int checkInID, string lastname, string phone_number) => View(new CustomerViewModel { Customer = new Customer() { LastName = lastname, PhoneNumber = phone_number, BithDate = new DateTime(1990, 1, 1)}, ReturnUrl=returnUrl, CheckInID = checkInID });

        [HttpPost]
        public IActionResult InsertCustomer(Customer customer, string returnUrl, int checkInID)
        {
            if (ModelState.IsValid)
            {
                if (checkInID == 0)
                {
                    TempData["message"] = $"Клиент с номером {customer.FirstName} {customer.LastName} был добавлен";
                    repositoryCu.InsertCustomer(customer);
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    CheckIn checkIn = repositoryCh.CheckIns.FirstOrDefault(r => r.CheckInID == checkInID);
                    TempData["message"] = $" Клиент {customer.FirstName} {customer.LastName} был зарегистрирован";
                    checkIn.CustomerID = customer.CustomerID;
                    repositoryCh.UpdateCheckIn(checkIn);
                    repositoryCu.InsertCustomer(customer);
                    return View("/CheckIn/List");
                }
            }
            else { return View("AddCustomer", new CustomerViewModel { Customer = customer, ReturnUrl = returnUrl, CheckInID = checkInID }); }
        }

        [HttpPost]
        public IActionResult ConfirmDeleteCustomer(int customerID, string returnUrl) =>
            View(new CustomerViewModel { Customer = repositoryCu.Customers.FirstOrDefault(r => r.CustomerID == customerID), ReturnUrl = returnUrl });

        [HttpPost]
        public IActionResult DeleteCustomer(Customer customer)
        {
            repositoryCu.DeleteCustomer(customer);
            TempData["message"] = $"Клиент {customer.FirstName} {customer.LastName} был удален";
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        public ViewResult EditCustomer(int customerID, string returnUrl,int checkInID)
        {
            return View(new CustomerViewModel { Customer = repositoryCu.Customers.FirstOrDefault(r => r.CustomerID == customerID), ReturnUrl = returnUrl, CheckInID=checkInID });
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer, string returnUrl,int checkInID)
        {
            if (ModelState.IsValid)
            {
                if (checkInID == 0)
                {
                    TempData["message"] = $"Изменения информации для клиента {customer.FirstName} {customer.LastName} сохранены";
                    repositoryCu.UpdateCustomer(customer);
                    return RedirectToAction(nameof(List), new { returnUrl });
                }
                else {
                    CheckIn checkIn = repositoryCh.CheckIns.FirstOrDefault(r => r.CheckInID == checkInID);
                    TempData["message"] = $" Клиент {customer.FirstName} {customer.LastName} был зарегистрирован";
                    checkIn.CustomerID = customer.CustomerID;
                    repositoryCh.UpdateCheckIn(checkIn);
                    repositoryCu.UpdateCustomer(customer);
                    return View("/CheckIn/List");
                }
            }
            else
            {
                return View("EditCustomer", new CustomerViewModel { Customer = customer, ReturnUrl = returnUrl, CheckInID = checkInID });
            }
        }

        public ViewResult AddCustomerFilt(int checkInID, string lastname, string phone_number, string returnUrl, int page = 1)
        {
            return View(new CustomersListViewModel
            {
                Customers = repositoryCu.Customers
                  .Where(p => (lastname == null || p.LastName.ToLower().IndexOf(lastname.ToLower()) >= 0))
                  .OrderBy(p => p.LastName)
                  .Skip((page - 1) * PageSize)
                  .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = lastname == null ? repositoryCu.Customers.Count() : repositoryCu.Customers.Where(e => e.LastName == lastname).Count()
                },
                ReturnUrl = returnUrl,
                PhoneNumber = phone_number,
                LastName=lastname,
                CheckInID=checkInID
            });
        }
    }
}
