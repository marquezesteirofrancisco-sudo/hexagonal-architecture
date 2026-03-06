using Application_RepositoryComponent.Models;
using ApplicationComponent.DTOs;
using Domain_Component.Interfaces;
using Microsoft.EntityFrameworkCore;
using RepositoryComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRepositoryComponent
{
    public class NoteDTORepository : ICommonRepository<NoteDTO>
    {
        private readonly ItemsDBContext _context;

        public NoteDTORepository(ItemsDBContext context)
            => _context = context;
        

        public async Task AddAsync(NoteDTO item)
        {
            var noteModel = new NoteModel()
            {
                Message = item.Message,
                ItemId = item.ItemId,
                Color = item.Color,
                CreateDate = DateTime.Now
            };

            await _context.AddAsync(noteModel);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<NoteDTO>> GetAllAsync()
            => await _context.NotesModel
                .Select(n => new NoteDTO
                {
                    Id = n.Id,
                    Message = n.Message,
                    ItemId = n.ItemId,
                    Color = n.Color
                }).ToListAsync();
    }
}
