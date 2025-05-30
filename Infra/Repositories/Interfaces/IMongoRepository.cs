using MongoDB.Bson;
using System.Linq.Expressions;

namespace Infra.Repositories.Interfaces
{
    public interface IMongoRepository<T>
    {
        Task<bool> InsertAsync(T item);
        Task<T> GetByIdAsync(ObjectId id);
        Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByFieldAsync(string fieldName, string name);
        Task UpdateAsync(ObjectId id, T item);
        Task<bool> DeleteAsync(ObjectId id);
    }
}
