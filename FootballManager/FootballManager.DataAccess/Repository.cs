using FootballManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;


namespace FootballManager.DataAccess
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly FootballManagerContext context;
        private DbSet<T> entities;

        public Repository(FootballManagerContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public Task<List<T>> GetAll()
        {
            return entities.ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            return entities.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entities.Add(entity);
            return context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            T entity = await entities.SingleOrDefaultAsync(x => x.Id == id);
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
