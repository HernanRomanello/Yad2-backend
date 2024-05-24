namespace Yad2.Models
{
    public class AddressModel
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }

        public int Floor { get; set; }

        public int TotalFloors { get; set; }

        public bool OnPillars { get; set; }

        public string Neighborhood { get; set; }
    }
}
