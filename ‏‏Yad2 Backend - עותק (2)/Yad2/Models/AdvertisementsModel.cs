using System.ComponentModel.DataAnnotations;

namespace Yad2.Models
{
    public class AdvertisementsModel
    {

        [Key]
         public int Id { get; set; }

         public DateTime CreationDate { get; set; }
         public DateTime ExpirationDate { get; set; }

        public string City { get; set; } = "";

         public string TradeType { get; set; }  = "";
        public string Street { get; set; } = "";
        public int Number { get; set; }
        public int Floor { get; set; }
        public int TotalFloors { get; set; }
        public bool OnPillars { get; set; }
        public string Neighborhood { get; set; } = "";

        public string Area { get; set; }  = "";  
         public string AssetType { get; set; } = "";

         public string AssetState { get; set; } = "";

         public int AirDirections { get; set; }

         public string View { get; set; } = "";

         public bool RearProperty { get; set; }

         public string Rooms { get; set; } = "";

         public string ShowerRooms { get; set; }  = "";

        public int PrivateParking { get; set; } 

        public bool HasPrivateParking { get; set; } 
         
        public bool HasBolcony { get; set; }
        public bool HasImage { get; set; }    
        public bool HasPrice { get; set; }    
        public bool MoshavOrKibutz { get; set; }    
         public bool needsRenovation { get; set; }    
        public bool isWellMaintained { get; set; }    
        public bool isRenovated { get; set; }    
        public bool isNew { get; set; }    
        public bool isNewFromBuilder  { get; set; }   
        public bool PirceDiscount { get; set; }    
        public bool PublisherIsMiddleMan { get; set; }    
        public bool PublisherIsContractor { get; set; }    

        public int BalconiesNumber { get; set; }

         public bool AccessibleForDisabled { get; set; }  // גישה לנכים
        public bool AirConditioning { get; set; }        // מיזוג
        public bool WindowBars { get; set; }             // סורגים
        public bool SolarWaterHeater { get; set; }       // דוד שמש
        public bool Elevator { get; set; }               // מעלית
        public bool ForRoommates { get; set; }           // לשותפים
        public bool Furnished { get; set; }              // ריהוט
        public bool SeparateUnit { get; set; }           // יחידת דיור
        public bool KosherKitchen { get; set; }          // מטבח כשר
        public bool PetsAllowed { get; set; }            // חיות מחמד
        public bool Renovated { get; set; }              // משופצת
        public bool SafeRoom { get; set; }               // ממ"ד (מרחב מוגן דירתי)
        public bool MultiLockDoors { get; set; }         // דלתות רב-בריח

        public bool AirConditioner { get; set; }  // מזגן טורנדו
        public bool TornadoAirConditioner { get; set; }  // מזגן טורנדו
        public bool StorageRoom { get; set; }            // מחסן

        public string Description { get; set; } = "";



        public string Furnituredescription { get; set; } = "";

        public string NumberOfPayments { get; set; }    = "";        // מספר תשלומים*
        public double HouseCommitteePayment { get; set; }   // תשלום לועד בית
        public double MunicipalityMonthlyPropertyTax { get; set; }    // ארנונה לחודשיים
        public int BuiltSquareMeters { get; set; }       // מ"ר בנוי
        public double GardenSquareMeters { get; set; }      // מ"ר גינה
        public double TotalSquareMeters { get; set; }       // גודל במ"ר סך הכל*
        public int Price { get; set; }                   // מחיר
        public int MinimumAmount { get; set; }        // סכום מינימלי 100
        public double PricePerMeter { get; set; }           // מחיר למטר
        public DateTime EntryDate { get; set; }               // תאריך כניסה*
        public bool Immediate { get; set; }                 // מיידי
        public bool Flexible { get; set; }                  // גמיש
        public bool LongTerm { get; set; }                  // לטווח ארוך

        public List<Picture> Pictures { get; set; } = new List<Picture>();

        public string MainPicture { get; set; } = "";

        public string Video { get; set; } = "";

         public int AdSavingRecordNumbers { get; set; }
        public int AdwatchedRecordNumbers { get; set; }
        public bool Active { get; set; } = true;

        public string ContactName { get; set; } = "";
        public string SecondContactName { get; set; } = "";

        public string ContactPhone { get; set; } = "";
        public string SecondContactPhone { get; set; } = "";

        public bool StandardizationAccepted { get; set; }

        internal void Update(AdvertisementDto dto)
        {
       

            City = dto.City;
            TradeType = dto.TradeType;
            Street = dto.Street;
            Number = dto.Number;
            Floor = dto.Floor;
            TotalFloors = dto.TotalFloors;
            OnPillars = dto.OnPillars;
            Neighborhood = dto.Neighborhood;
            Area = dto.Area;

            Description = dto.Description;
            Furnituredescription = dto.Furnituredescription;
            Price = dto.Price;
            EntryDate =  (DateTimeOffset.FromUnixTimeMilliseconds(dto.EntryDate).DateTime).ToLocalTime();
            Elevator = dto.Elevator;
            TotalSquareMeters = dto.TotalSquareMeters;
            ForRoommates = dto.ForRoommates;
            Furnished = dto.Furnished;
            AirConditioning = dto.AirConditioning;
            
            AirDirections = dto.AirDirections;
            AssetState = dto.AssetState;
            AssetType = dto.AssetType;
            AccessibleForDisabled = dto.AccessibleForDisabled;
            Immediate = dto.Immediate;
            Flexible = dto.Flexible;
            LongTerm = dto.LongTerm;
            MinimumAmount = dto.MinimumAmount;
            NumberOfPayments = dto.NumberOfPayments;
            HouseCommitteePayment = dto.HouseCommitteePayment;
            MunicipalityMonthlyPropertyTax = dto.MunicipalityMonthlyPropertyTax;
            BuiltSquareMeters = dto.BuiltSquareMeters;

            
            PricePerMeter = dto.PricePerMeter;
            RearProperty = dto.RearProperty;
            Rooms = dto.Rooms;
            ShowerRooms = dto.ShowerRooms;
            PrivateParking = dto.PrivateParking;
            HasPrivateParking = dto.HasPrivateParking;
            
            HasBolcony = dto.HasBolcony;
            HasImage = dto.HasImage;
            HasPrice = dto.HasPrice;
            MoshavOrKibutz = dto.MoshavOrKibutz;
       
            needsRenovation = dto.needsRenovation;
            isWellMaintained = dto.isWellMaintained;
            isRenovated = dto.isRenovated;
            isNew = dto.isNew;
            isNewFromBuilder = dto.isNewFromBuilder;

            PirceDiscount = dto.PirceDiscount;
            PublisherIsMiddleMan = dto.PublisherIsMiddleMan;
            PublisherIsContractor = dto.PublisherIsContractor;
            BalconiesNumber = dto.BalconiesNumber;
            Renovated = dto.Renovated;
            SafeRoom = dto.SafeRoom;
            SolarWaterHeater = dto.SolarWaterHeater;
            StorageRoom = dto.StorageRoom;
            AirConditioner = dto.AirConditioner;
            TornadoAirConditioner = dto.TornadoAirConditioner;
            View = dto.View;
            MainPicture = dto.MainPicture;
            Video = dto.Video;
            
            WindowBars = dto.WindowBars;
            ContactName = dto.ContactName;
            SecondContactName = dto.SecondContactName;
            ContactPhone = dto.ContactPhone;
            SecondContactPhone = dto.SecondContactPhone;
            StandardizationAccepted = dto.StandardizationAccepted;
        }
    }
}
