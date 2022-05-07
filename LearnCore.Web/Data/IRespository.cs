using System.Linq;
using System.Threading.Tasks;

namespace LearnCore.Web.Data
{
    public interface IRespository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        IQueryable<T> Table { get; }
    }
}
