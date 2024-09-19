using DataBase.Entities;
using System.Runtime.CompilerServices;

namespace DataBase.Operations
{
	public interface IDefaultOperationDbEntity<T>
	{
		Task<int> AddAsync(T Entity);
		Task UpdateAsync(T Entity);
		Task DeleteAsync(T Entity);
		Task DeleteAsync(int id);

		Task<T> Get(int id);
		Task<List<T>> GetAll();

	}
}
