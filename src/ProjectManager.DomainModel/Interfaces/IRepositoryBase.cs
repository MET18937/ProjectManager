using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DomainModel.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {
        void Create(TEntity entity);
    }
}
