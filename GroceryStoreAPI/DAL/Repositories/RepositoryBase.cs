using System;
using System.Collections.Generic;
using System.Linq;
using GroceryStoreAPI.DAL.DB;
using GroceryStoreAPI.Models;

namespace GroceryStoreAPI.DAL.Repositories
{
	public abstract class RepositoryBase<T> where T : class
	{
		private dbData _dataContext;

		public abstract List<T> dbList { get; set; }

		protected RepositoryBase(IDatabaseFactory databaseFactory)
		{
			DatabaseFactory = databaseFactory;
			_dataContext = DatabaseFactory.Get();
		}

		protected IDatabaseFactory DatabaseFactory
		{
			get;
			private set;
		}

        public abstract T GetById(int id);

		public virtual List<T> GetAll()
		{
			return dbList.ToList();
		}

		public virtual T Add(T entity)
		{
			dbList.Add(entity);
			return entity;
		}

		public abstract bool Update(T entity);

		public virtual bool Delete(T entity)
		{
			return dbList.Remove(entity);
		}

		public abstract bool Delete(int id);
		
	}
}