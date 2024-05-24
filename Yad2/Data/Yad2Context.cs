using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Yad2.Models;

namespace Yad2.Data
{
    public class Yad2Context : IdentityDbContext<UserModel>
    {
        public Yad2Context(DbContextOptions options) : base(options) { }

        public DbSet<AdvertisementsModel> Advertisements { get; set; }
        public DbSet<AdvertisementModelStatistic> AdvertisementStatistics { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<AdvertisementsModel> AdvertisementsModels { get; set; }
        public DbSet<Picture> Pictures { get; set; }

    }
}
