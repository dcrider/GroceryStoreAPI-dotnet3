using System.Collections.Generic;

namespace GroceryStoreAPI.Interfaces
{
	public interface IRepository<T> where T : class
	{
		List<T> GetAll();
        T GetById(int id);
		T Add(T entity);
		bool Update(T entity);
		bool Delete(T entity);
		bool Delete(int id);
	}
}