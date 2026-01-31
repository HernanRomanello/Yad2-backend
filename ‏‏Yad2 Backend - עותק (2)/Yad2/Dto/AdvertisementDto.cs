

using Yad2.Models;

public class AdvertisementDto {
         public string City { get; set; }
        public string TradeType { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public int TotalFloors { get; set; }
        public bool OnPillars { get; set; }
        
        public string Neighborhood { get; set; }

        public string Area { get; set; }

         public string AssetType { get; set; }

         public string AssetState { get; set; }

         public int AirDirections { get; set; }

         public string View { get; set; }

         public bool RearProperty { get; set; }

          public string Rooms { get; set; }

         public string ShowerRooms { get; set; } 

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
        public string Description { get; set; }

        public string Furnituredescription { get; set; }


        public string NumberOfPayments { get; set; }           // מספר תשלומים*
        public double HouseCommitteePayment { get; set; }   // תשלום לועד בית
        public double MunicipalityMonthlyPropertyTax { get; set; }    // ארנונה לחודשיים
        public int BuiltSquareMeters { get; set; }       // מ"ר בנוי
        public int GardenSquareMeters { get; set; }      // מ"ר גינה
        public int TotalSquareMeters { get; set; }       // גודל במ"ר סך הכל*
        public int Price { get; set; }                   // מחיר
        public int MinimumAmount { get; set; }        // סכום מינימלי 100
        public double PricePerMeter { get; set; }           // מחיר למטר
        public long EntryDate { get; set; }               // תאריך כניסה*
        public bool Immediate { get; set; }                 // מיידי
        public bool Flexible { get; set; }                  // גמיש
        public bool LongTerm { get; set; }                  // לטווח ארוך

        public List<string> Pictures { get; set; }
        public string MainPicture { get; set; }

        public string Video { get; set; }
        public int AdSavingRecordNumbers { get; set; }
        public int AdwatchedRecordNumbers { get; set; }
        public bool Active { get; set; }=true;

        public string ContactName { get; set; }
        public string SecondContactName { get; set; }

        public string ContactPhone { get; set; }
        public string SecondContactPhone { get; set; }

        public bool StandardizationAccepted { get; set; }

        
}