using System;
using System.Collections.Generic;
using System.Text;

namespace Tandem.DAL
{
	public class CosmosDBRepo<T> : IRepository<T> where T: class
	{




		public System.Threading.Tasks.Task<T> Add(T entity)
		{
			throw new NotImplementedException();
		}

		public System.Threading.Tasks.Task<T> GetAll(string id)
		{
			throw new NotImplementedException();
		}
	}
}
