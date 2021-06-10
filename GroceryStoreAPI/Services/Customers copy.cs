using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Models;

namespace GroceryStoreAPI.Services 
{
     /*public class Customers : ICustomerService {
       public Dictionary<int, Customer> db;

        public Customers() {
            db = LoadDatabase();
        }

        public Customers(Dictionary<int, Customer> MockedDB) {
            db = MockedDB;
        }

        public Customer GetCustomer(int id) {
            bool wasFound = db.TryGetValue(id, out var customer);
            if(wasFound) return customer;
            else return null;
        }

        public List<Customer> GetAllCustomers() {
            List<Customer> returnList = db.Values.ToList();
            return returnList;
        }

        public bool AddCustomer(Customer customer) {
            //going to assume a default ID = 0 and auto-increment the ID to mimic a relational DB
            int dynamicId = db.Keys.Max() + 1; 
            customer.id = dynamicId;
            db.Add(dynamicId, customer);
            if(SaveDatabase(db)) {
                return true;
            }
            return true;
        }

        public bool UpdateCustomer(Customer customer) {
            if(db.ContainsKey(customer.id)) {
                db[customer.id] = customer;
                if(SaveDatabase(db)) {
                    return true;
                }
            }
            
            return false;
        }

        public bool DeleteCustomer(int id) {
            bool wasDeleted = db.Remove(id);

            if(!wasDeleted) {
                return false;
            }
            
            if(SaveDatabase(db)) {
                return true;
            }

            return false;
        }


        public Dictionary<int, Customer> LoadDatabase() {
            using (StreamReader r = new StreamReader("database.json"))
            {
                string json = r.ReadToEnd();
                CustomerList items = JsonConvert.DeserializeObject<CustomerList>(json);
                //converting to dictionary instead of List for faster hash-based searching/updating
                return items.Customers.ToDictionary(x => x.id, x => x);
            }
        }

        private bool SaveDatabase(Dictionary<int, Customer> updatedDBDict) {
            CustomerList updatedDb = new CustomerList();
            //convert back to list for easier serialization...
            updatedDb.Customers = updatedDBDict.Values.ToList();

            try {
                var json = JsonConvert.SerializeObject(updatedDb, Formatting.Indented);
                //save contents to file
                File.WriteAllText("database.json", json);
                return true;
            } catch {
                return false;
            }
        }
    } */
}

