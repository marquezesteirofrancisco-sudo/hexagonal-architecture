using Application_RepositoryComponent.Models;
using ApplicationComponent;
using ApplicationComponent.DTOs;
using Domain_Component.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperComponent
{
    public class NoteModelMapper : IMapper<NoteDTO, NoteModel>
    {
        public NoteModel Map(NoteDTO dto)
            => new NoteModel()
            {
                Id= dto.Id,
                ItemId = dto.ItemId,
                Message = dto.Message,
                CreateDate = DateTime.Now,
                Color = dto.Color
            };
    }
}
