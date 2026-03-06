using DomainComponent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Component
{
    public interface ICommonService<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAsync();

        Task AddAsync(TEntity entity);
    }
}
