using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Hotel.Models;
using System.Linq;
using Hotel.Models.ViewModels;
using Npgsql.EntityFrameworkCore;


namespace Hotel.Controllers
{
    public class CustomerController : Controller
    {
        public int PageSize = 4;
        private ICustomerRepository repository;
        public CustomerController(ICustomerRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string lastname, int page = 1)
            => View(new CustomersListViewModel
            {
                Customers = repository.Customers
                    .Where(p => (lastname == null || p.LastName.ToLower().IndexOf(lastname.ToLower())>=0))
                    .OrderBy(p => p.CustomerID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = lastname == null ? repository.Customers.Count() : repository.Customers.Where(e => e.LastName == lastname).Count()
                },
                LastName = lastname
            });

        public ViewResult AddCustomer(string returnUrl) => View(new CustomerViewModel { Customer = new Customer(), ReturnUrl=returnUrl});

        [HttpPost]
        public IActionResult InsertCustomer(Customer customer, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (repository.Customers.FirstOrDefault(r => r.CustomerID == customer.CustomerID) == null)
                {
                    repository.InsertCustomer(customer);
                    TempData["message"] = $"Клиент с номером {customer.FirstName} {customer.LastName} был добавлен";
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    TempData["message"] = $"Клиент с номером {customer.CustomerID} уже существует.";
                    return View("AddCustomer", new CustomerViewModel { Customer = customer, ReturnUrl = returnUrl });
                }
            }
            else { return View("AddCustomer", new CustomerViewModel { Customer = customer, ReturnUrl = returnUrl }); }
        }

        [HttpPost]
        public IActionResult ConfirmDeleteCustomer(int customerID, string returnUrl) =>
            View(new CustomerViewModel { Customer = repository.Customers.FirstOrDefault(r => r.CustomerID == customerID), ReturnUrl = returnUrl });

        [HttpPost]
        public IActionResult DeleteCustomer(Customer customer)
        {
            repository.DeleteCustomer(customer);
            TempData["message"] = $"Клиент {customer.FirstName} {customer.LastName} был удален";
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        public ViewResult EditCustomer(int customerID, string returnUrl)
        {
            return View(new CustomerViewModel { Customer = repository.Customers.FirstOrDefault(r => r.CustomerID == customerID), ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateCustomer(customer);
                TempData["message"] = $"Изменения информации для клиента {customer.FirstName} {customer.LastName} сохранены";
                return RedirectToAction(nameof(List), new { returnUrl});
            }
            else
            {
                return View("EditCustomer", new CustomerViewModel { Customer = customer, ReturnUrl = returnUrl });
            }
        }
    }
}
