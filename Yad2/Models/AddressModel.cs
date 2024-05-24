using System.Text.Json.Serialization;

namespace Yad2.Models
{
    public class AddressModel
    {

        public int Id { get; set; }
        public int AdvertisementId { get; set; }

        [JsonIgnore]
        public AdvertisementsModel Advertisement { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public int TotalFloors { get; set; }
        public bool OnPillars { get; set; }
        public string Neighborhood { get; set; }

        internal void Update(AddressDto dto) {
            City = dto.City;
            Street = dto.Street;
            Number = dto.Number;
            Floor = dto.Floor;
            TotalFloors = dto.TotalFloors;
            OnPillars = dto.OnPillars;
            Neighborhood = dto.Neighborhood;
        }
    }
}
