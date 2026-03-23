using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Yad2.Models;

namespace Yad2.Data
{
    public class Yad2Context : IdentityDbContext<UserModel>
    {
        public Yad2Context(DbContextOptions options) : base(options) 
        { 
            
        }

        public DbSet<AdvertisementsModel> Advertisements { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<LastSearchesModel> LastSearches { get; set; }


      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdvertisementsModel>()
                .HasMany(a => a.Pictures)
                .WithOne()
                .HasForeignKey(p => p.AdvertisementModelId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
