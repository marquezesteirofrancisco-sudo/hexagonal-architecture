using DomainComponent.Entities;
using DomainComponent.Interfaces;
using Microsoft.EntityFrameworkCore;
using RepositoryComponent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryComponent
{
    public class ItemRepository : IRepository, ICompleteRepository, IGetRepository<Item>
    {
        private readonly ItemsDBContext _context;

        public ItemRepository(ItemsDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Item item)
        {
            var itemModel = new ItemModel
            {
                Id = item.Id,
                Title = item.Title,
                IsCompleted = item.IsCompleted,
                CreateDate = DateTime.UtcNow
            };

            _context.ItemsModel.Add(itemModel);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.ItemsModel
                .Select(e => new Item(e.Id, e.Title, e.IsCompleted))
                .ToListAsync();
        }

        public async Task Complete(int id)
        {
            var model = await _context.ItemsModel.FindAsync(id);

            if (model == null)
                throw new InvalidOperationException($"No se ha encontrado el item {id}");

            model.IsCompleted = true;

            await  _context.SaveChangesAsync(); 
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            var model = await _context.ItemsModel.FindAsync(id);

            if (model != null)
            {
                var item = new Item(model.Id, model.Title, model.IsCompleted);
                return item;
            }

            return null;    

        }
    }
}
