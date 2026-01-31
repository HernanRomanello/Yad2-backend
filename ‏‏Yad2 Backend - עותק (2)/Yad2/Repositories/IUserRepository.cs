using Book_Store.Dto;
using Microsoft.AspNetCore.Identity;
using Yad2.Dto;
using Yad2.Models;

namespace Yad2.Repositories
{
    public interface IUserRepository
    {
        Task<AdvertisementsModel> AddAdvertisementToFavorite(int id, string email);
        Task<AdvertisementsModel> AddOrRemoveFavorite(int id, string email);
        Task<LastsearchesModel> AddSearchInput(string email, LastsearcheDto lastsearchesDto);
        Task<AdvertisementsModel> CreateAdvertisement(AdvertisementDto dto, string email);
        Task<UserNoteModel> CreateNoteForUser(string email, UserNoteDto userNote);
        Task<AdvertisementsModel> DeleteAdvertisement(int id, string email);
        Task<List<AdvertisementsModel>> GetFavoriteAdvertisements(string email);
        Task<List<LastsearchesModel>> GetSearchesList(string email);
        Task<List<AdvertisementsModel>> GetUserAdvertisementsByEmail(string email);
        Task<AdvertisementModelStatistic> GetUserAdvertisementsStatistic(string email);
        Task<UserModel> GetUserByEmail(string email);
        Task<List<UserNoteDto>> GetUserNotes(string email);
        Task<List<LastsearchesModel>> RemoveAllUserSearches(string email);
        Task<AdvertisementsModel> RemoveFavorite(int id, string email);
        Task<LastsearchesModel> RemoveSearchInput(Guid id);
        void SetJwtCookie(HttpResponse response, UserModel user);
        Task<IdentityResult> Singup(SignUpModel signupModel);
        Task<AdvertisementsModel> UpdateAdvertisement(int id, AdvertisementDto dto);
        Task<UserModel> UpdatUser(string email, UserUpdateDto userUpdate);
    }
}