using Application_RepositoryComponent.Models;
using Domain_Component.Entities;
using DomainComponent.Interfaces;
using InfrastructureRepositoryComponent.ExtraData;
using RepositoryComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureRepositoryComponent
{
    public class NoteFactoriedRepository: IAddRepository<Note>
    {
        private NoteExtraData _extraData;
        private readonly ItemsDBContext _context;

        public NoteFactoriedRepository(NoteExtraData extraData, ItemsDBContext context)
        {
            _extraData = extraData;
            _context = context;
        }

        public async Task AddAsync(Note note)
        {
            var model = new NoteModel()
            {
                Message = note.Message,
                ItemId = note.ItemId,
                CreateDate = DateTime.Now,
                Color = _extraData.Color,
            };

            await _context.NotesModel.AddAsync(model);

            await _context.SaveChangesAsync();

        }
    }
}
