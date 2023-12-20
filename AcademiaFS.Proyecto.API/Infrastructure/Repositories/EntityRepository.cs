using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps;
using System.IdentityModel;
using System.Linq.Expressions;

namespace AcademiaFS.Proyecto.API.Infrastructure.Repositories
{
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly SistemaViajesDBContext _dbContext;
        public EntityRepository(SistemaViajesDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);

            _dbContext.SaveChanges();
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> query)
        {
            return _dbContext.Set<TEntity>().Where(query).FirstOrDefault();
        }

        public List<TEntity> Where(Expression<Func<TEntity, bool>> query)
        {
            return _dbContext.Set<TEntity>().Where(query).ToList();
        }
    }
}
