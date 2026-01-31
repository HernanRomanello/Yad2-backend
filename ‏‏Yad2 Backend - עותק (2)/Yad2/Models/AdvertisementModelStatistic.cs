namespace Yad2.Models
{
    public class AdvertisementModelStatistic
    {

        public Guid  Id { get; set; }

        public int ActiveAdvertisement { get; set; }

        public int InactiveAdvertisement { get; set; }

        public int InvalidAdvertisement { get; set; }

        public int AdvertismentPublishedUntilNow { get; set; }
    }
}
