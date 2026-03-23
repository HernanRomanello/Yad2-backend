using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Yad2.Models
{
    public class LastSearchesModel
    {
        [Key]
         public Guid Id { get; set; }

        public string ?UserId { get; set; }

        public DateTime CreationDate { get; set; }

        public int  MinuteOfCreation { get; set; }
        public int HourOfCreation { get; set; }
        public int DayOfCreation { get; set; }
        public int MonthOfCreation { get; set; }
        public int YearOfCreation { get; set; }


        public bool ForSale { get; set; }

        public bool ForRent { get; set; }

        public string ?City { get; set; }

        public string ?Neighborhood { get; set; }

        public bool MoshavOrKibuutz { get; set; }
       public string? AssetType { get; set; }

        public float MinRooms { get; set; }     

        public float MaxRooms { get; set; }
        public int MinPrice { get; set; }

        public int MaxPrice { get; set; }

        public bool HasImmediateEntry { get; set; }
        public bool HasAccessibleForDisabled { get; set; }
        public bool HasAirConditioner { get; set; }
        public bool HasExclusivity { get; set; }
        public bool HasBalcony { get; set; }
        public bool HasWindowBars { get; set; }
        public bool HasElevator { get; set; }

        public int MinFloor { get; set; }

        public int MaxFloor { get; set; }

        public bool ForRoommates { get; set; }
        public bool HasFurnished { get; set; }
        public bool HasPrivateParking { get; set; }
        public bool PetsAllowed { get; set; }
        public bool HasPrice { get; set; }
        public bool HasImage { get; set; }
        public bool IsRenovated { get; set; }
        public bool HasSafeRoom { get; set; }
        public int MinSquareSize { get; set; }
        public int MaxSquareSize { get; set; }

        public bool HasStorageRoom { get; set; }

    }
}
