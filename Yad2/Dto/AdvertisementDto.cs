
public class AdvertisementDto
{
    // Location
    public string City { get; set; } = "";
    public string Area { get; set; } = "";
    public string Neighborhood { get; set; } = "";
    public string Street { get; set; } = "";
    public int Number { get; set; }

    // Property basics
    public string TradeType { get; set; } = "";
    public string AssetType { get; set; } = "";
    public string AssetState { get; set; } = "";
    public string View { get; set; } = "";

    public int Floor { get; set; }
    public int TotalFloors { get; set; }
    public bool OnPillars { get; set; }
    public bool RearProperty { get; set; }

    public string Rooms { get; set; } = "";
    public string ShowerRooms { get; set; } = "";

    public int BuiltSquareMeters { get; set; }
    public int GardenSquareMeters { get; set; }
    public int TotalSquareMeters { get; set; }

    public int AirDirections { get; set; }

    // Parking & balconies
    public bool HasPrivateParking { get; set; }
    public int PrivateParking { get; set; }

    public bool HasBolcony { get; set; }
    public int BalconiesNumber { get; set; }

    // Property condition flags
    public bool needsRenovation { get; set; }
    public bool isWellMaintained { get; set; }
    public bool isRenovated { get; set; }
    public bool isNew { get; set; }
    public bool isNewFromBuilder { get; set; }

    // Additional flags
    public bool HasImage { get; set; }
    public bool HasPrice { get; set; }
    public bool MoshavOrKibutz { get; set; }

    public bool PirceDiscount { get; set; }

    public bool PublisherIsMiddleMan { get; set; }
    public bool PublisherIsContractor { get; set; }

    // Amenities
    public bool AccessibleForDisabled { get; set; }
    public bool AirConditioning { get; set; }
    public bool AirConditioner { get; set; }
    public bool TornadoAirConditioner { get; set; }

    public bool Elevator { get; set; }
    public bool StorageRoom { get; set; }

    public bool SolarWaterHeater { get; set; }
    public bool WindowBars { get; set; }
    public bool MultiLockDoors { get; set; }

    public bool Furnished { get; set; }
    public bool SeparateUnit { get; set; }
    public bool ForRoommates { get; set; }

    public bool KosherKitchen { get; set; }
    public bool PetsAllowed { get; set; }

    public bool Renovated { get; set; }
    public bool SafeRoom { get; set; }

    // Description
    public string Description { get; set; } = "";
    public string Furnituredescription { get; set; } = "";

    // Payments
    public string NumberOfPayments { get; set; } = "";

    public double HouseCommitteePayment { get; set; }
    public double MunicipalityMonthlyPropertyTax { get; set; }

    public int Price { get; set; }
    public int MinimumAmount { get; set; }
    public double PricePerMeter { get; set; }

    // Entry
    public long EntryDate { get; set; }

    public bool Immediate { get; set; }
    public bool Flexible { get; set; }
    public bool LongTerm { get; set; }

    // Media
    public List<string> Pictures { get; set; } = new();
    public string MainPicture { get; set; } = "";
    public string Video { get; set; } = "";

    // Stats
    public int AdSavingRecordNumbers { get; set; }
    public int AdwatchedRecordNumbers { get; set; }

    public bool Active { get; set; } = true;

    // Contact
    public string ContactName { get; set; } = "";
    public string SecondContactName { get; set; } = "";

    public string ContactPhone { get; set; } = "";
    public string SecondContactPhone { get; set; } = "";

    public bool StandardizationAccepted { get; set; }
}