using System;
using System.Linq;
using System.Threading.Tasks;

namespace LearnCore.Web.Data
{
    public class EfRespository<T> : IRespository<T> where T : class
    {
        private LearnCoreDbContext _dbContext;
        public EfRespository(LearnCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get all table record
        public IQueryable<T> Table
        {
            get
            {
                return _dbContext.Set<T>();
            }
        }

        //Get record from table by id
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }


        //Insert record in table and return table 
        public async Task<T> InsertAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        //update record in table
        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dbContext.Update(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        //delete record from table
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
