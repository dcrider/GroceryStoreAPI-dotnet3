using GroceryStoreAPI.Models;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;


namespace GroceryStoreAPI.Services
{
	public static class JsonDataService
	{
		public static dbData LoadDataFromFile(string dataFileSpec)
		{
            var json = File.ReadAllText(dataFileSpec);
            dbData items = JsonConvert.DeserializeObject<dbData>(json);
			return items;
		}
        public static bool WriteDataToFile(List<Customer> updatedDbList)
		{
            dbData updatedDb = new dbData();
            updatedDb.Customers = updatedDbList;

            try {
                var json = JsonConvert.SerializeObject(updatedDb, Formatting.Indented);
                //persist contents to file
                File.WriteAllText("database.json", json);
                return true;
            } catch {
                return false;
            }
		}
	}
}