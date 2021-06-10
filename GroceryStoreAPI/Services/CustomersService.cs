using System.Collections.Generic;
using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Models;

namespace GroceryStoreAPI.Services 
{
    public class CustomersService : ICustomersService {
        private readonly ICustomersRepository _customersRepo;

        public CustomersService(ICustomersRepository customersRepo) {
            _customersRepo = customersRepo;
        }

        public List<Customer> GetAllCustomers() {
            return _customersRepo.GetAll();
        }

        public Customer GetCustomer(int id) {
            return _customersRepo.GetById(id);
        }

        public Customer AddCustomer(Customer customer) {
            return _customersRepo.Add(customer);
        }

        public bool UpdateCustomer(Customer customer) {
            return _customersRepo.Update(customer);
        }

        public bool DeleteCustomer(int id) {
            return _customersRepo.Delete(id);
        }     
    }
}

