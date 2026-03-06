using Domain_Component.Entities;
using DomainComponent.Interfaces;
using InfrastructureRepositoryComponent.ExtraData;
using RepositoryComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureRepositoryComponent.Factories
{
    public class NoteRepositoryFactory : IRepositoryFactory<IAddRepository<Note>, NoteExtraData>
    {
        private readonly ItemsDBContext _context;

        public NoteRepositoryFactory(ItemsDBContext context)
        {
            _context = context;
        }

        public IAddRepository<Note> Create(NoteExtraData extraData)
            => new NoteFactoriedRepository(extraData, _context);
    }
}   
