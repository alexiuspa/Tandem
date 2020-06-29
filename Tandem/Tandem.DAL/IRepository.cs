using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tandem.DAL
{
	public interface IRepository<T> where T : class
	{

		Task<T> GetAll(string id);

		Task<T> Add(T entity);


	 

	}
}
