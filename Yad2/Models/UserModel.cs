using Microsoft.AspNetCore.Identity;

namespace Yad2.Models
{
    public class UserModel : IdentityUser
    { 
        public string Name { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public AddressModel Address { get; set; }
        public int AddressId { get; set; }
        public string Picture { get; set; }
        public List<AdvertisementsModel> FavoriteAdvertisements { get; set; }
        public List<AdvertisementsModel> MyAdvertisements { get; set; }

        public List<AdvertisementModelStatistic> Statistics { get; set; }
    }
}
