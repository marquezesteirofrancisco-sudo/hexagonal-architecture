using Application_RepositoryComponent.Models;
using DomainComponent.Interfaces;
using RepositoryComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRepositoryComponent
{
    public class NoteMapperRepository: IAddRepository<NoteModel>
    {
        private readonly ItemsDBContext _context;

        public NoteMapperRepository(ItemsDBContext context)
            => _context = context;

        public async Task AddAsync(NoteModel model)
        {
            _context.NotesModel.Add(model);
            await _context.SaveChangesAsync();
        }
    }
}
