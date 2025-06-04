using Microsoft.EntityFrameworkCore;
using MusicRadio.Infrastructure.DbContexts;
using System.Linq.Expressions;

namespace MusicRadio.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly MusicRadioDbContext _context;
        public RepositoryBase(MusicRadioDbContext context) => _context = context;

        public DbSet<TEntity> EntitySet => _context.Set<TEntity>();

        public async Task<TEntity?> Delete(int id, CancellationToken cancellationToken)
        {
            TEntity? entity = await EntitySet.FindAsync(id, cancellationToken);
            if (entity != null)
            {
                EntitySet.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return entity;
        }

        public async Task<TEntity?> Find(Expression<Func<TEntity, bool>> expr, CancellationToken cancellationToken)
        {
            return await EntitySet.AsNoTracking().FirstOrDefaultAsync(expr, cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> GetByID(int id, CancellationToken cancellationToken)
        {
            return await EntitySet.FindAsync(id, cancellationToken);
        }

        public async Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken)
        {
            var result = await EntitySet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return result.Entity;
        }

        public async Task Update(TEntity entity, CancellationToken cancellationToken)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
