using GroceryStoreAPI.Models;

namespace GroceryStoreAPI.DAL.DB
{
	public class DatabaseFactory : IDatabaseFactory
	{
		private readonly dbData _theData;

		public DatabaseFactory(dbData theData)
		{
			_theData = theData;
		}

		public dbData Get()
		{
			return _theData;
		}
	}
}