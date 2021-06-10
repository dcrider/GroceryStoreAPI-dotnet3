using System.Collections.Generic;
using GroceryStoreAPI.Models;

namespace GroceryStoreAPI.Interfaces
{
    public interface ICustomersService
    {
        Customer GetCustomer(int id);
        List<Customer> GetAllCustomers();
        Customer AddCustomer (Customer customer);
        bool UpdateCustomer (Customer customer);
        bool DeleteCustomer (int id);
    }

}