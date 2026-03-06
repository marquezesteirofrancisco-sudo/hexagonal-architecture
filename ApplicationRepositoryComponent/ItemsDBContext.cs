using Application_RepositoryComponent.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryComponent.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryComponent
{
    public class ItemsDBContext : DbContext
    {

        public ItemsDBContext(DbContextOptions<ItemsDBContext> options)
            : base(options)
        {


        }


        public DbSet<ItemModel> ItemsModel { get; set; }

        public DbSet<NoteModel> NotesModel { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemModel>()
                .ToTable("ITems");


            modelBuilder.Entity<NoteModel>()
                .ToTable("Notes")
                .HasOne(n => n.Item)
                .WithMany(i => i.Notes)
                .HasForeignKey(n => n.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
                

        }

    }
}
