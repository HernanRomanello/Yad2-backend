namespace Yad2.Models
{
    public class AddressDto
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public int TotalFloors { get; set; }
        public bool OnPillars { get; set; }
        public string Neighborhood { get; set; }

        public AddressModel ToModel() {
            return new AddressModel {
                City = City,
                Street = Street,
                Number = Number,
                Floor = Floor,
                TotalFloors = TotalFloors,
                OnPillars = OnPillars,
                Neighborhood = Neighborhood
            };
        }
    }
}
