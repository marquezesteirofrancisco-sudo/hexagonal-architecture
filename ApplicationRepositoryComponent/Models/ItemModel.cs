using Application_RepositoryComponent.Models;
using Domain_Component.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryComponent.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public DateTime CreateDate { get; set; }
        public ICollection<NoteModel> Notes { get; set; }
    }
}
