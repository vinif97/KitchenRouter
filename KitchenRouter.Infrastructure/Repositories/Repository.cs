using KitchenRouter.Domain.Models;
using KitchenRouter.Domain.Repositories.Interfaces;
using KitchenRouter.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace KitchenRouter.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly KitchenRouterContext _context;
        public Repository(KitchenRouterContext context) 
        {
            _context = context;
        }

        public async Task Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public async Task<TEntity?> GetById(int id)
        {
            return await _context.Set<TEntity>()
                 .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
