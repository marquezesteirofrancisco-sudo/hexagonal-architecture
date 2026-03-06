using DomainComponent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationComponent
{
    public interface IService
    {
        Task<IEnumerable<Item>> GetAsync();

        Task AddAsync(string title);

    }
}
