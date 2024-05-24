using Yad2.Models;

namespace Yad2.Repositories
{
    public interface IAdvertisementRepository
    {
        Task<AdvertisementsModel> CreateAdvertisement(AdvertisementDto dto);
        Task<AdvertisementsModel> DeleteAdvertisement(int id);
        Task<AdvertisementsModel> GetAdvertisement(int id);
        Task<List<AdvertisementsModel>> GetAdvertisements();
        Task<AdvertisementsModel> UpdateAdvertisement(int id, AdvertisementDto dto);
    }
}