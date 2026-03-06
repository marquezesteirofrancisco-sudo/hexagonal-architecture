using Application_Component;
using ApplicationComponent.DTOs;
using Domain_Component.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationComponent
{
    public class NoteDTOService: ICommonService<NoteDTO>
    {
        private readonly ICommonRepository<NoteDTO> _repository;

        public NoteDTOService(ICommonRepository<NoteDTO> repository)
            => _repository = repository;

        public async Task AddAsync(NoteDTO dto)
            => await _repository.AddAsync(dto);

        public async Task<IEnumerable<NoteDTO>> GetAsync()
            => await _repository.GetAllAsync();
    }
}
