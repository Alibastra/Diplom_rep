using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Hotel.Models
{
    public class EFCustomerRepository: ICustomerRepository
    {
        private ApplicationDbContext context;
        public EFCustomerRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Customer> Customers => context.Customers;

        public void InsertCustomer (Customer customer)
        {
            context.AttachRange();
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
        }
        public void UpdateCustomer(Customer customer)
        {
            context.Customers.Update(customer);
            context.SaveChanges();
        }
    }
}
