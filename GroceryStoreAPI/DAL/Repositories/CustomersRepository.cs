using System.Collections.Generic;
using GroceryStoreAPI.DAL.DB;
using GroceryStoreAPI.Models;
using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Services;
using System.Linq;


namespace GroceryStoreAPI.DAL.Repositories
{
	public class CustomersRepository : RepositoryBase<Customer>, ICustomersRepository
	{
		private readonly dbData _dbContext;

		public CustomersRepository(IDatabaseFactory dbFactory) : base(dbFactory)
		{
			_dbContext = dbFactory.Get();
		}

		public override List<Customer> dbList
		{
			get => _dbContext.Customers;
			set => _dbContext.Customers = value;
		}

		public override Customer GetById(int id)
		{
			var customer = dbList.Find(x => x.id == id);
			return customer;
		}

		//use this if ID needs to be dynamic
		public override Customer Add(Customer customer)
		{
			//calculate dynamic ID to mimic auto-incrementing of a database and fight duplicate ID's 
			int dynamicId = dbList.Count(); 
			do {
				dynamicId += 1;
			} while (dbList.Any(c => c.id == dynamicId));

			customer.id = dynamicId;
			dbList.Add(customer);
			//persist data changes out to file
			JsonDataService.WriteDataToFile(dbList);
			return customer;
		}

        public override bool Update(Customer customer) {
            var updated = dbList.Where(x => x.id == customer.id).FirstOrDefault();
			if (updated != null)
            {
                updated.name = customer.name;
				//persist data changes out to file
				if(JsonDataService.WriteDataToFile(dbList)) { 
					return true;
				}
            }

            return false;
        }

        public override bool Delete(int id) {
            if(dbList.RemoveAll(x => x.id == id) > 0) {
				//persist data changes out to file
				if(JsonDataService.WriteDataToFile(dbList)) {
					return true;
				}
			}
			
            return false;
        }
	}
}