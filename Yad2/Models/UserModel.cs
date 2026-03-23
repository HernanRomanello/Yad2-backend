using Microsoft.AspNetCore.Identity;

namespace Yad2.Models
{
    public class UserModel : IdentityUser
    { 
        public string ?Name { get; set; }
        public string ?LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string ?City { get; set; }

        public string ?Street { get; set; }

        public int HouseNumber { get; set; }

        public string ?Picture { get; set; }
        public List<AdvertisementsModel> ?FavoriteAdvertisements { get; set; }
        public List<AdvertisementsModel> ?MyAdvertisements { get; set; }

        public AdvertisementModelStatistic ?Statistics { get; set; }
        public List<LastsearchesModel> Lastsearches { get; set; } = new List<LastsearchesModel>();

        public List<UserNoteModel> ?UserNotes { get; set; }

        
    }
}
