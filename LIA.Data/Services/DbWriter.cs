using LIA.Data.Data;
using System.Threading.Tasks;

namespace LIA.Data.Services
{
    public class DbWriter : IDbWriter
    {
        private CourseContext _db;
        public DbWriter(CourseContext db)
        {
            _db = db;
        }
        public async Task<bool> AddAsync<TEntity>(TEntity item) where TEntity : class
        {
            await _db.AddAsync<TEntity>(item);
            return await _db.SaveChangesAsync() >= 0;
        }

        public async Task<bool> Remove<TEntity>(TEntity item) where TEntity : class
        {
            _db.Remove<TEntity>(item);
            return await _db.SaveChangesAsync() >= 0;
        }

        public async Task<bool> UpdateAsync<TEntity>(TEntity item) where TEntity : class
        {
            _db.Set<TEntity>().Update(item);
            return await _db.SaveChangesAsync() >= 0;
        }
    }
}
