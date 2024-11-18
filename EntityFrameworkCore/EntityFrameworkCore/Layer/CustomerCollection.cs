using EFModellayer.Models;
using System.Collections;

namespace EntityFrameworkCore.Layer
{
    public class CustomerCollection : IEnumerable<Customer>
    {
        private List<Customer> _customers = new List<Customer>();

        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }
        // Method to retrieve a customer by ID (simulating a database lookup)
        public Customer GetCustomerById(int customerId)
        {
            return _customers.Find(c => c.Id == customerId);
        }

        // Custom iterator to return customers one by one
        public IEnumerator<Customer> GetEnumerator()
        {
            foreach (var customer in _customers)
            {
                yield return customer;
            }
        }

        // Required for non-generic IEnumerable interface
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
