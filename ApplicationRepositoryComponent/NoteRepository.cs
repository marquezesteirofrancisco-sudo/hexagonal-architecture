using Application_RepositoryComponent.Models;
using Domain_Component.Entities;
using Domain_Component.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryComponent
{
    public class NoteRepository : ICommonRepository<Note>
    {

        private readonly ItemsDBContext _context;

        public NoteRepository(ItemsDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Note note)
        {
            var noteModel = new NoteModel
            {
                Id = note.Id,
                ItemId = note.ItemId,
                Message = note.Message,
                CreateDate = DateTime.UtcNow
            };

            await _context.NotesModel.AddAsync(noteModel);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            return await _context.NotesModel
                    .Select(n => new Note(n.Id, n.ItemId, n.Message))
                    .ToListAsync();
        }
    }
}
