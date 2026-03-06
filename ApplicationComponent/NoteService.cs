using Domain_Component.Entities;
using Domain_Component.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Component
{
    public class NoteService : ICommonService<Note>
    {
        private readonly ICommonRepository<Note> _repository;

        public NoteService(ICommonRepository<Note> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Note entity)
            => await _repository.AddAsync( entity);
         

        public async Task<IEnumerable<Note>> GetAsync()
            => await _repository.GetAllAsync();
    }
}
