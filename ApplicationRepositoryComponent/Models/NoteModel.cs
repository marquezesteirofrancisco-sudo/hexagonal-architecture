using RepositoryComponent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_RepositoryComponent.Models
{
    public class NoteModel
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public string Message { get; set; }

        public DateTime CreateDate { get; set; }

        public string Color { get; set; }

        public ItemModel Item { get; set; }

        
    }
}
