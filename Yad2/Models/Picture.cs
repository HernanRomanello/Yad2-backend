using System.Text.Json.Serialization;

namespace Yad2.Models;

public class Picture
{
    public int Id { get; set; }
    public string ?Url { get; set; }
    public int AdvertisementModelId { get; set; }
    public AdvertisementsModel ?AdvertisementModel { get; set; }
  
}