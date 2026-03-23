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
        Task<LastSearchesModel> AddSearchInput(string email, LastSearchDto lastsearchesDto);
        Task<AdvertisementsModel> CreateAdvertisement(AdvertisementDto dto, string email);
        Task<UserNoteModel> CreateNoteForUser(string email, UserNoteDto userNote);
        Task<AdvertisementsModel> DeleteAdvertisement(int id, string email);
        Task<List<AdvertisementsModel>> GetFavoriteAdvertisements(string email);
        Task<List<LastSearchesModel>> GetSearchesList(string email);
        Task<List<AdvertisementsModel>> GetUserAdvertisementsByEmail(string email);
        Task<AdvertisementModelStatistic> GetUserAdvertisementsStatistic(string email);
        Task<UserModel> GetUserByEmail(string email);
        Task<List<UserNoteDto>> GetUserNotes(string email);
        Task<List<LastSearchesModel>> RemoveAllUserSearches(string email);
        Task<AdvertisementsModel> RemoveFavorite(int id, string email);
        Task<LastSearchesModel> RemoveSearchInput(Guid id);
        void SetJwtCookie(HttpResponse response, UserModel user);
        Task<IdentityResult> SignUp(SignUpModel signupModel);
        Task<AdvertisementsModel> UpdateAdvertisement(int id, AdvertisementDto dto);
        Task<UserModel> UpdateUser(string email, UserUpdateDto userUpdate);
    }
}