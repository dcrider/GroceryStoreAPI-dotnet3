using GroceryStoreAPI.Models;

namespace GroceryStoreAPI.DAL.DB
{
	public interface IDatabaseFactory
	{
		dbData Get();
	}
}