using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yad2.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvertisementModelStatistic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActiveAdvertisement = table.Column<int>(type: "int", nullable: false),
                    InactiveAdvertisement = table.Column<int>(type: "int", nullable: false),
                    InvalidAdvertisement = table.Column<int>(type: "int", nullable: false),
                    AdvertismentPublishedUntilNow = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementModelStatistic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatisticsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AdvertisementModelStatistic_StatisticsId",
                        column: x => x.StatisticsId,
                        principalTable: "AdvertisementModelStatistic",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TradeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    TotalFloors = table.Column<int>(type: "int", nullable: false),
                    OnPillars = table.Column<bool>(type: "bit", nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirDirections = table.Column<int>(type: "int", nullable: false),
                    View = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RearProperty = table.Column<bool>(type: "bit", nullable: false),
                    Rooms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShowerRooms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrivateParking = table.Column<int>(type: "int", nullable: false),
                    HasPrivateParking = table.Column<bool>(type: "bit", nullable: false),
                    HasBolcony = table.Column<bool>(type: "bit", nullable: false),
                    HasImage = table.Column<bool>(type: "bit", nullable: false),
                    HasPrice = table.Column<bool>(type: "bit", nullable: false),
                    MoshavOrKibutz = table.Column<bool>(type: "bit", nullable: false),
                    needsRenovation = table.Column<bool>(type: "bit", nullable: false),
                    isWellMaintained = table.Column<bool>(type: "bit", nullable: false),
                    isRenovated = table.Column<bool>(type: "bit", nullable: false),
                    isNew = table.Column<bool>(type: "bit", nullable: false),
                    isNewFromBuilder = table.Column<bool>(type: "bit", nullable: false),
                    PirceDiscount = table.Column<bool>(type: "bit", nullable: false),
                    PublisherIsMiddleMan = table.Column<bool>(type: "bit", nullable: false),
                    PublisherIsContractor = table.Column<bool>(type: "bit", nullable: false),
                    BalconiesNumber = table.Column<int>(type: "int", nullable: false),
                    AccessibleForDisabled = table.Column<bool>(type: "bit", nullable: false),
                    AirConditioning = table.Column<bool>(type: "bit", nullable: false),
                    WindowBars = table.Column<bool>(type: "bit", nullable: false),
                    SolarWaterHeater = table.Column<bool>(type: "bit", nullable: false),
                    Elevator = table.Column<bool>(type: "bit", nullable: false),
                    ForRoommates = table.Column<bool>(type: "bit", nullable: false),
                    Furnished = table.Column<bool>(type: "bit", nullable: false),
                    SeparateUnit = table.Column<bool>(type: "bit", nullable: false),
                    KosherKitchen = table.Column<bool>(type: "bit", nullable: false),
                    PetsAllowed = table.Column<bool>(type: "bit", nullable: false),
                    Renovated = table.Column<bool>(type: "bit", nullable: false),
                    SafeRoom = table.Column<bool>(type: "bit", nullable: false),
                    MultiLockDoors = table.Column<bool>(type: "bit", nullable: false),
                    AirConditioner = table.Column<bool>(type: "bit", nullable: false),
                    TornadoAirConditioner = table.Column<bool>(type: "bit", nullable: false),
                    StorageRoom = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Furnituredescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfPayments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseCommitteePayment = table.Column<double>(type: "float", nullable: false),
                    MunicipalityMonthlyPropertyTax = table.Column<double>(type: "float", nullable: false),
                    BuiltSquareMeters = table.Column<int>(type: "int", nullable: false),
                    GardenSquareMeters = table.Column<double>(type: "float", nullable: false),
                    TotalSquareMeters = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    MinimumAmount = table.Column<int>(type: "int", nullable: false),
                    PricePerMeter = table.Column<double>(type: "float", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Immediate = table.Column<bool>(type: "bit", nullable: false),
                    Flexible = table.Column<bool>(type: "bit", nullable: false),
                    LongTerm = table.Column<bool>(type: "bit", nullable: false),
                    MainPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdSavingRecordNumbers = table.Column<int>(type: "int", nullable: false),
                    AdwatchedRecordNumbers = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StandardizationAccepted = table.Column<bool>(type: "bit", nullable: false),
                    UserModelId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserModelId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertisements_AspNetUsers_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Advertisements_AspNetUsers_UserModelId1",
                        column: x => x.UserModelId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LastSearches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinuteOfCreation = table.Column<int>(type: "int", nullable: false),
                    HourOfCreation = table.Column<int>(type: "int", nullable: false),
                    DayOfCreation = table.Column<int>(type: "int", nullable: false),
                    MonthOfCreation = table.Column<int>(type: "int", nullable: false),
                    YearOfCreation = table.Column<int>(type: "int", nullable: false),
                    ForSale = table.Column<bool>(type: "bit", nullable: false),
                    ForRent = table.Column<bool>(type: "bit", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoshavOrKibuutz = table.Column<bool>(type: "bit", nullable: false),
                    AssetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinRooms = table.Column<float>(type: "real", nullable: false),
                    MaxRooms = table.Column<float>(type: "real", nullable: false),
                    MinPrice = table.Column<int>(type: "int", nullable: false),
                    MaxPrice = table.Column<int>(type: "int", nullable: false),
                    HasImmediateEntry = table.Column<bool>(type: "bit", nullable: false),
                    HasAccessibleForDisabled = table.Column<bool>(type: "bit", nullable: false),
                    HasAirConditioner = table.Column<bool>(type: "bit", nullable: false),
                    HasExclusivity = table.Column<bool>(type: "bit", nullable: false),
                    HasBolcony = table.Column<bool>(type: "bit", nullable: false),
                    HaswindowBars = table.Column<bool>(type: "bit", nullable: false),
                    HasElevator = table.Column<bool>(type: "bit", nullable: false),
                    MinFloor = table.Column<int>(type: "int", nullable: false),
                    MaxFloor = table.Column<int>(type: "int", nullable: false),
                    ForRoommates = table.Column<bool>(type: "bit", nullable: false),
                    HasFurnished = table.Column<bool>(type: "bit", nullable: false),
                    HasPrivateParking = table.Column<bool>(type: "bit", nullable: false),
                    PetsAllowed = table.Column<bool>(type: "bit", nullable: false),
                    HasPrice = table.Column<bool>(type: "bit", nullable: false),
                    HasImage = table.Column<bool>(type: "bit", nullable: false),
                    IsRenovated = table.Column<bool>(type: "bit", nullable: false),
                    HasSafeRoom = table.Column<bool>(type: "bit", nullable: false),
                    MinSquareSize = table.Column<int>(type: "int", nullable: false),
                    MaxSquareSize = table.Column<int>(type: "int", nullable: false),
                    HasStorageRoom = table.Column<bool>(type: "bit", nullable: false),
                    UserModelId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastSearches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LastSearches_AspNetUsers_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserNoteModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdID = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModelId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNoteModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNoteModel_AspNetUsers_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvertisementModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_Advertisements_AdvertisementModelId",
                        column: x => x.AdvertisementModelId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_UserModelId",
                table: "Advertisements",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_UserModelId1",
                table: "Advertisements",
                column: "UserModelId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StatisticsId",
                table: "AspNetUsers",
                column: "StatisticsId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LastSearches_UserModelId",
                table: "LastSearches",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_AdvertisementModelId",
                table: "Pictures",
                column: "AdvertisementModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNoteModel_UserModelId",
                table: "UserNoteModel",
                column: "UserModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "LastSearches");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "UserNoteModel");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AdvertisementModelStatistic");
        }
    }
}
