using Yad2.Models;

namespace Yad2.Repositories
{
    public interface IAdvertisementRepository
    {
        Task<AdvertisementsModel> GetAdvertisement(int id);
        Task<List<AdvertisementsModel>> GetAdvertisements();
    }
}