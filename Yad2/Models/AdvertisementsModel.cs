namespace Yad2.Models
{
    public class AdvertisementsModel
    {
        public int Id { get; set; }
         public AddressModel Address { get; set; }

         public string AssetType { get; set; }

         public string AssetState { get; set; }

         public int AirDirections { get; set; }

         public string View { get; set; }

         public bool RearProperty { get; set; }

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
        public bool TornadoAirConditioner { get; set; }  // מזגן טורנדו
        public bool StorageRoom { get; set; }            // מחסן

        public string Description { get; set; }

        public int NumberOfPayments { get; set; }           // מספר תשלומים*
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

        public List<string> Pictures { get; set; }

        public string Video { get; set; }

        public string ContactName { get; set; }

        public string ContactPhone { get; set; }

        public bool StandardizationAccepted { get; set; }


    }
}
