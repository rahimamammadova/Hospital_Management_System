using HMS_DAL.Data;
using HMS_DAL.Models;
using HMS_DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace HMS_DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        public readonly AppDbContext _context;
        public readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }


        public async Task<T> Create(T Entity)
        {
            await _dbSet.AddAsync(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }

        public async Task<T> Delete(int id)
        {
            var existingEntity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (existingEntity != null)
            {
                _dbSet.Remove(existingEntity);
                await _context.SaveChangesAsync();
            }
            return existingEntity;
        }


        public async Task<T> GetById(int id)
        {
            var existingEntity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return existingEntity;
        }

        public async Task<List<T>> GetList()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> Update(T Entity)
        {
            _dbSet.Update(Entity);
           await _context.SaveChangesAsync();
            return Entity;
        }
    }
}
