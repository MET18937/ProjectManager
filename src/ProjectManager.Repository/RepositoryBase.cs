using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.DomainModel.Interfaces;
using ProjectManager.Infrastructure;
using ProjectManager.DomainModel.Exceptions;

namespace ProjectManager.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>, IReadOnlyRepositoryBase<TEntity>
        where TEntity : class
    {
        private readonly ProjectManagerContext _context;

        public RepositoryBase(ProjectManagerContext context)
        {
            _context = context;
        }

        public void Create(TEntity entity)
        {
            DbSet<TEntity> dbSet = _context.Set<TEntity>();
            dbSet.Add(entity);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new RepositoryCreateException("Save fehlgeschlagen", e);
            }

        }

        public IQueryable<TEntity> GetAll()
        {
            return null;
        }

        public TEntity? GetByPK<TKey>(TKey pk)
        {
            return _context.Find<TEntity>(pk);
        }
    }
}
