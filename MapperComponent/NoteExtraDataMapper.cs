using ApplicationComponent;
using ApplicationComponent.DTOs;
using InfrastructureRepositoryComponent.ExtraData;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperComponent
{
    public class NoteExtraDataMapper : IMapper<NoteDTO, NoteExtraData>
    {
        public NoteExtraData Map(NoteDTO dto)
            => new NoteExtraData()
            {
                Color = dto.Color,
            };
    }
}
