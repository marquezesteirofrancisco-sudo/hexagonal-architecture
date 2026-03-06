using DomainComponent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Component.Interfaces
{
    public interface ICommonRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task AddAsync(TEntity item);
    }
}
