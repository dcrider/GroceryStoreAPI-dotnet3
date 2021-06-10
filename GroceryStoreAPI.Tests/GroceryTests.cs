using System;
using Xunit;
using Xunit.Abstractions;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Services;
using GroceryStoreAPI.Models;
using GroceryStoreAPI.DAL.Repositories;
using GroceryStoreAPI.DAL.DB;
using GroceryStoreAPI.Controllers;

namespace GroceryStoreAPI.Tests
{
    public class GroceryTests
    {
        ITestOutputHelper output;

        public GroceryTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        private readonly List<Customer> _testDb = new List<Customer>
		{
			new Customer
			{
				id = 1,
				name = "Me"
			},
			new Customer
			{
				id = 2,
				name = "Myself"
			},
			new Customer
			{
				id = 3,
				name = "I"
			}
		};

        [Fact]
        public void Get_ShouldReturn_All()
        {

            var testDbContext = new dbData { Customers = _testDb };
			var customersRepository = new CustomersRepository(new DatabaseFactory(testDbContext));
			var customersService = new CustomersService(customersRepository);
			var customersController = new CustomersController(customersService);

			// Act
			var response = customersController.GetAll();

            // Assert
			Assert.NotNull(response);
            var customerList = (List<Customer>) ((OkObjectResult) response).Value;
            Assert.NotEmpty(customerList);
            Assert.IsType<List<Customer>>(customerList);
			Assert.Equal(_testDb.Count, customerList.Count);

        }

        [Fact]
        public void Gets_ShouldReturnSingle_Customer()
        {
            var testDbContext = new dbData { Customers = _testDb };
			var customersRepository = new CustomersRepository(new DatabaseFactory(testDbContext));
			var customersService = new CustomersService(customersRepository);
			var customersController = new CustomersController(customersService);

			// Act
			var response = customersController.Get(1);
            var singleCustomer = (Customer) ((OkObjectResult) response).Value;
            // Assert
			Assert.NotNull(response);
            Assert.IsType<Customer>(singleCustomer);
            Assert.Equal(1, singleCustomer.id);
        }

        [Fact]
        public void Post_ShouldCreate_Customer()
        {
            var testDbContext = new dbData { Customers = _testDb };
			var customersRepository = new CustomersRepository(new DatabaseFactory(testDbContext));
			var customersService = new CustomersService(customersRepository);
			var customersController = new CustomersController(customersService);

            Customer testCustomer = new Customer() {
                id = 4, //this will get set dynamically on the backend regardless of what we see, mimics auto-incrementing of a DB and fights dupes
                name = "added test customer"
            };

			// Act
			var response = customersController.Create(testCustomer);
            var added = (Customer) ((OkObjectResult) response).Value;
          
            //output.WriteLine(objectResult);
            // Assert
            Assert.NotNull(response);
            Assert.IsType<Customer>(added);

        }

        [Fact]
        public void Put_ShouldUpdate_Customer()
        {
            var testDbContext = new dbData { Customers = _testDb };
			var customersRepository = new CustomersRepository(new DatabaseFactory(testDbContext));
			var customersService = new CustomersService(customersRepository);
			var customersController = new CustomersController(customersService);

            Customer testCustomer = new Customer() {
                id = 1,
                name = "updated customer"
            };

			// Act
			var response = customersController.Update(testCustomer);
            var updated = (bool) ((OkObjectResult) response).Value;
            //output.WriteLine(objectResult);
            // Assert
			Assert.True(updated);
        }

        [Fact]
        public void Delete_ShouldRemove_Customer()
        {
            var testDbContext = new dbData { Customers = _testDb };
			var customersRepository = new CustomersRepository(new DatabaseFactory(testDbContext));
			var customersService = new CustomersService(customersRepository);
			var customersController = new CustomersController(customersService);

			// Act
			var response = customersController.Delete(1);
            var deleted = (bool) ((OkObjectResult) response).Value;
            //output.WriteLine(objectResult);
            // Assert
			Assert.True(deleted);
        }
    }
}
