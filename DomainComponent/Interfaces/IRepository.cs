using DomainComponent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainComponent.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();

        Task AddAsync(Item item);

    }
}
