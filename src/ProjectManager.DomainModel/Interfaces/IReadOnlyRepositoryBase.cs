using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DomainModel.Interfaces
{
    public interface IReadOnlyRepositoryBase<TEntity>
    {
        TEntity? GetByPK<TKey>(TKey pk);
        IQueryable<TEntity> GetAll();
    }
}
