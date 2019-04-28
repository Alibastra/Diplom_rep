using System.Collections.Generic;

namespace Hotel.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Customers { get; }
        void InsertCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
    }
}
