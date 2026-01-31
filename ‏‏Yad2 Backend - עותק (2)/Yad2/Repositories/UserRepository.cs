using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Book_Store.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Yad2.Data;
using Yad2.Dto;
using Yad2.Models;

namespace Yad2.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<UserModel> _userManager;

        private readonly SignInManager<UserModel> _singInManager;

        private readonly IConfiguration _configuration;

        private readonly Yad2Context _context;

        public UserRepository(UserManager<UserModel> userManager, SignInManager<UserModel> singInManager, IConfiguration configuration, Yad2Context context)
        {
            _userManager = userManager;
            _singInManager = singInManager;
            _configuration = configuration;
            _context = context;
        }

        public async Task<IdentityResult> Singup(SignUpModel signupModel)
        {




            UserModel User = new()
            {
                UserName = signupModel.Email,
                Email = signupModel.Email,
                Name = "",
                LastName = "",
                BirthDate = DateTime.Now,
                City = "",
                Street = "",
                HouseNumber = 0,
                Picture = "",
                FavoriteAdvertisements = new List<AdvertisementsModel>(),
                MyAdvertisements = new List<AdvertisementsModel>(),
                Statistics = new AdvertisementModelStatistic(),
                Lastsearches = new List<LastsearchesModel>(),
                UserNotes = new List<UserNoteModel>()

            };

            var statistics = new AdvertisementModelStatistic()
            {
                Id = Guid.Parse(User.Id.ToString()),
                ActiveAdvertisement = 0,
                InactiveAdvertisement = 0,
                InvalidAdvertisement = 0,
                AdvertismentPublishedUntilNow = 0
            };

            User.Statistics = statistics;


            var result = await _userManager.CreateAsync(User, signupModel.Password);

            if (result.Succeeded)
            {
                await _context.SaveChangesAsync();
            }

            return result;
        }
       
        public async Task<UserModel> GetUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;

            
        }

        public async Task<List<AdvertisementsModel>> GetUserAdvertisementsByEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException(nameof(email));

            var user = await _context.Users
                .Include(u => u.MyAdvertisements)
                .ThenInclude(a => a.Pictures)
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null) throw new InvalidOperationException("User not found");

            return user.MyAdvertisements?.ToList() ?? new List<AdvertisementsModel>();
        }



        public async Task<AdvertisementModelStatistic> GetUserAdvertisementsStatistic(string email)
        {
            var user = await _context.Users
               .Where(u => u.Email == email)
               .Include(u => u.Statistics)
               .FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception($"User with email {email} does not exist");
            }

            return user.Statistics ?? new AdvertisementModelStatistic();

        }



        public void SetJwtCookie(HttpResponse response, UserModel user)
        {
            var authClaims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));


            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: authClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            response.Cookies.Append("access_token", tokenString, new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(1),
                HttpOnly = true,
                IsEssential = true,
                Secure = true,
                SameSite = SameSiteMode.None

            });



        }

        public async Task<AdvertisementsModel> CreateAdvertisement(AdvertisementDto dto, string email)
        {
            var advertisement = new AdvertisementsModel()
            {
                CreationDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddMonths(3),
                City = dto.City,
                TradeType = dto.TradeType,
                Street = dto.Street,
                Number = dto.Number,
                Floor = dto.Floor,
                TotalFloors = dto.TotalFloors,
                OnPillars = dto.OnPillars,
                Neighborhood = dto.Neighborhood,
                Area = dto.Area,
                AssetType = dto.AssetType,
                AssetState = dto.AssetState,
                AirDirections = dto.AirDirections,
                View = dto.View,
                RearProperty = dto.RearProperty,
                Rooms = dto.Rooms,
                ShowerRooms = dto.ShowerRooms,
                PrivateParking = dto.PrivateParking,
                HasPrivateParking = dto.HasPrivateParking,

                HasBolcony = dto.HasBolcony,
                HasImage = dto.HasImage,
                HasPrice = dto.HasPrice,
                MoshavOrKibutz = dto.MoshavOrKibutz,
                needsRenovation = dto.needsRenovation,
                isWellMaintained = dto.isWellMaintained,
                isRenovated = dto.isRenovated,
                isNew = dto.isNew,
                isNewFromBuilder = dto.isNewFromBuilder,
                PirceDiscount = dto.PirceDiscount,
                PublisherIsMiddleMan = dto.PublisherIsMiddleMan,
                PublisherIsContractor = dto.PublisherIsContractor,
                BalconiesNumber = dto.BalconiesNumber,
                AccessibleForDisabled = dto.AccessibleForDisabled,
                AirConditioning = dto.AirConditioning,
                WindowBars = dto.WindowBars,
                SolarWaterHeater = dto.SolarWaterHeater,
                Elevator = dto.Elevator,
                ForRoommates = dto.ForRoommates,
                Furnished = dto.Furnished,
                Furnituredescription = dto.Furnituredescription,
                SeparateUnit = dto.SeparateUnit,
                KosherKitchen = dto.KosherKitchen,
                PetsAllowed = dto.PetsAllowed,
                Renovated = dto.Renovated,
                SafeRoom = dto.SafeRoom,
                MultiLockDoors = dto.MultiLockDoors,
                AirConditioner = dto.AirConditioner,
                TornadoAirConditioner = dto.TornadoAirConditioner,
                StorageRoom = dto.StorageRoom,
                Description = dto.Description,
                NumberOfPayments = dto.NumberOfPayments,
                HouseCommitteePayment = dto.HouseCommitteePayment,
                MunicipalityMonthlyPropertyTax = dto.MunicipalityMonthlyPropertyTax,
                BuiltSquareMeters = dto.BuiltSquareMeters,
                GardenSquareMeters = dto.GardenSquareMeters,
                TotalSquareMeters = dto.TotalSquareMeters,
                Price = dto.Price,
                MinimumAmount = dto.MinimumAmount,
                PricePerMeter = dto.PricePerMeter,
                EntryDate = (DateTimeOffset.FromUnixTimeMilliseconds(dto.EntryDate).DateTime).ToLocalTime(),
                Immediate = dto.Immediate,
                Flexible = dto.Flexible,
                LongTerm = dto.LongTerm,
                MainPicture = dto.MainPicture,
                Video = dto.Video,
                ContactName = dto.ContactName,
                SecondContactName = dto.SecondContactName,
                ContactPhone = dto.ContactPhone,
                SecondContactPhone = dto.SecondContactPhone,
                StandardizationAccepted = dto.StandardizationAccepted
            };
            this._context.Advertisements.Add(advertisement);
            var user = await GetUserByEmail(email);
            if (user.MyAdvertisements == null)
            {
                user.MyAdvertisements = new List<AdvertisementsModel>();
            }

            user.MyAdvertisements.Add(advertisement);

            var statistics = await this.GetUserAdvertisementsStatistic(email);

            if (user.Statistics == null)
            {
                user.Statistics = new AdvertisementModelStatistic();
            }
            if (statistics != null)
            {
                user.Statistics.AdvertismentPublishedUntilNow = statistics.AdvertismentPublishedUntilNow + 1;
                user.Statistics.ActiveAdvertisement = statistics.ActiveAdvertisement + 1;
            }


            await _context.SaveChangesAsync();

            var pictures = dto.Pictures.Select(p => new Picture()
            {
                Url = p,
                AdvertisementModelId = advertisement.Id
            }).ToList();


            _context.Pictures.AddRange(pictures);

            await _context.SaveChangesAsync();
            return advertisement;
        }
        public async Task<AdvertisementsModel> UpdateAdvertisement(int id, AdvertisementDto dto)
        {
            var advertisement = await _context.Advertisements
            .Include(a => a.Pictures)
            .FirstOrDefaultAsync(a => a.Id == id);

            var deletedPictures = advertisement?.Pictures.FindAll(p => !dto.Pictures.Contains(p.Url)).ToList();
            if (deletedPictures?.Count > 0)
            {
                _context.Pictures.RemoveRange(deletedPictures);
            }
            var addedPictures = dto.Pictures.FindAll(p => advertisement?.Pictures.Where(pIn => pIn.Url == p).Count() < 1).ToList();
            if (addedPictures.Count > 0)
            {
                _context.Pictures.AddRange(addedPictures.Select(p => new Picture() { Url = p, AdvertisementModelId = advertisement.Id }));
            }

            if (advertisement == null)
            {
                throw new Exception("Advertisement not found");
            }
            advertisement.Update(dto);
            await _context.SaveChangesAsync();
            return advertisement;
        }

        public async Task<AdvertisementsModel> DeleteAdvertisement(int id, string email)
        {
            var user = await GetUserByEmail(email);
            var advertisement = await _context.Advertisements
            .Include(a => a.Pictures)
            .FirstOrDefaultAsync(a => a.Id == id);
            if (advertisement == null)
            {
                throw new Exception("Advertisement not found");
            }

            var SearchAdvertising = user.MyAdvertisements?.FirstOrDefault(a => a.Id == id);
            if (SearchAdvertising == null)
            {
                throw new Exception("Advertisement not found");
            }

            var statistics = await this.GetUserAdvertisementsStatistic(email);

            if (user.Statistics == null)
            {
                user.Statistics = new AdvertisementModelStatistic();
            }
            if (statistics != null)
            {
                user.Statistics.ActiveAdvertisement = statistics.ActiveAdvertisement - 1;
            }

            user.MyAdvertisements?.Remove(advertisement);
            _context.Advertisements.Remove(advertisement);
            _context.Pictures.RemoveRange(advertisement.Pictures);
            await _context.SaveChangesAsync();
            return advertisement;
        }



        public async Task<AdvertisementsModel> AddAdvertisementToFavorite(int id, string email)
        {

            var user = await GetUserByEmail(email);
            var advertisement = await _context.Advertisements
                .Include(a => a.Pictures)
                .FirstOrDefaultAsync(a => a.Id == id)
          ?? throw new Exception("Advertisement not found");



            if (user.FavoriteAdvertisements == null)
            {
                user.FavoriteAdvertisements = new List<AdvertisementsModel>();
            }
            user.FavoriteAdvertisements.Add(advertisement);
            await _context.SaveChangesAsync();
            return advertisement;
        }

        public async Task<LastsearchesModel> AddSearchInput(string email, LastsearcheDto lastsearchesDto)
        {

            var user = await GetUserByEmail(email);

            var SearchInput = new LastsearchesModel()
            {
                Id = new Guid(),
                UserId = user.Id,

                CreationDate = DateTime.Now,
                MinuteOfCreation = DateTime.Now.Minute,
                HourOfCreation = DateTime.Now.Hour,
                DayOfCreation = DateTime.Now.Day,
                MonthOfCreation = DateTime.Now.Month,
                YearOfCreation = DateTime.Now.Year,
                City = lastsearchesDto.City,
                Neighborhood = lastsearchesDto.Neighborhood,
                ForSale = lastsearchesDto.ForSale,
                ForRent = lastsearchesDto.ForRent,
                MoshavOrKibuutz = lastsearchesDto.MoshavOrKibuutz,
                AssetType = lastsearchesDto.AssetType,
                MinRooms = lastsearchesDto.MinRooms,
                MaxRooms = lastsearchesDto.MaxRooms,
                MinPrice = lastsearchesDto.MinPrice,
                MaxPrice = lastsearchesDto.MaxPrice,
                HasImmediateEntry = lastsearchesDto.HasImmediateEntry,
                HasAccessibleForDisabled = lastsearchesDto.HasAccessibleForDisabled,
                HasAirConditioner = lastsearchesDto.HasAirConditioner,
                HasExclusivity = lastsearchesDto.HasExclusivity,
                HasBolcony = lastsearchesDto.HasBalcony,
                HaswindowBars = lastsearchesDto.HasWindowBars,
                HasElevator = lastsearchesDto.HasElevator,
                MinFloor = lastsearchesDto.MinFloor,

                MaxFloor = lastsearchesDto.MaxFloor,
                ForRoommates = lastsearchesDto.ForRoommates,
                HasFurnished = lastsearchesDto.HasFurnished,
                HasPrivateParking = lastsearchesDto.HasPrivateParking,
                PetsAllowed = lastsearchesDto.PetsAllowed,
                HasPrice = lastsearchesDto.HasPrice,
                HasImage = lastsearchesDto.HasImage,
                IsRenovated = lastsearchesDto.IsRenovated,
                HasSafeRoom = lastsearchesDto.HasSafeRoom,
                MinSquareSize = lastsearchesDto.MinSquareSize,
                MaxSquareSize = lastsearchesDto.MaxSquareSize,
                HasStorageRoom = lastsearchesDto.HasStorageRoom



            };


            if (SearchInput == null)
            {
                SearchInput = new LastsearchesModel();
            }

            _context.LastSearches.Add(SearchInput);

            await _context.SaveChangesAsync();

            return SearchInput;
        }

        public async Task<LastsearchesModel> RemoveSearchInput(Guid id)
        {

            var LastSearche = _context.LastSearches.FirstOrDefault(l => l.Id == id) ?? throw new Exception("Search not found");
          
            _context.LastSearches.Remove(LastSearche);
            await _context.SaveChangesAsync();

            return LastSearche;
        }

        public async Task<List<LastsearchesModel>> RemoveAllUserSearches(string email)
        {
            var user = await GetUserByEmail(email);

            var LastSearches = await _context.LastSearches
                .Where(u => u.UserId == user.Id)
                .ToListAsync();

            if (user == null) throw new InvalidOperationException("User not found");

            _context.LastSearches.RemoveRange(LastSearches);
            await _context.SaveChangesAsync();

            return LastSearches;
        }

        public async Task<List<LastsearchesModel>> GetSearchesList(string email)
        {

            // if (string.IsNullOrEmpty(email)) return null;

            var user = await GetUserByEmail(email);



            var LastSearches = await _context.LastSearches
                .Where(u => u.UserId == user.Id)
                .OrderByDescending(l => l.CreationDate)
                .ToListAsync();

            if (user == null) throw new InvalidOperationException("User not found");

            return LastSearches.ToList();

        }

        public async Task<List<AdvertisementsModel>> GetFavoriteAdvertisements(string email)
        {

            var user = await _context.Users
                .Include(u => u.FavoriteAdvertisements)
                .ThenInclude(a => a.Pictures)
                .FirstOrDefaultAsync(u => u.Email == email) ?? throw new InvalidOperationException("User not found");


            return user.FavoriteAdvertisements?.ToList() ?? new List<AdvertisementsModel>();
        }

        public async Task<AdvertisementsModel> RemoveFavorite(int id, string email)
        {
            var user = await GetUserByEmail(email);
            var advertisement = await _context.Advertisements
            .Include(a => a.Pictures)
            .FirstOrDefaultAsync(a => a.Id == id);
            if (advertisement == null)
            {
                throw new Exception("Advertisement not found");
            }

            var SearchAdvertising = user.FavoriteAdvertisements?.FirstOrDefault(a => a.Id == id) ?? throw new Exception("Advertisement not found"); ;
          

            user.FavoriteAdvertisements?.Remove(advertisement);
            await _context.SaveChangesAsync();
            return advertisement;
        }

        public async Task<AdvertisementsModel> AddOrRemoveFavorite(int id, string email)
        {
            var user = await GetUserByEmail(email);
            var advertisement = await _context.Advertisements
                .Include(a => a.Pictures)
                .FirstOrDefaultAsync(a => a.Id == id) ?? throw new Exception("Advertisement not found");

          

            var userFavorites = await this.GetFavoriteAdvertisements(email);
            if (userFavorites == null)
            {
                userFavorites = new List<AdvertisementsModel>();
            }

            var searchAdvertising = userFavorites.FirstOrDefault(a => a.Id == id);
            if (searchAdvertising == null)
            {
                return await AddAdvertisementToFavorite(id, email);
            }
            else
            {
                return await RemoveFavorite(id, email);
            }
        }

        public async Task<UserNoteModel> CreateNoteForUser(string email, UserNoteDto userNote)
        {
            var user = await _context.Users
                .Include(u => u.UserNotes)
                .FirstOrDefaultAsync(u => u.Email == email);

            var existingNote = user?.UserNotes?.FirstOrDefault(n => n.AdID == userNote.AdID);
            if (existingNote != null)
            {
                existingNote.Note = userNote.Note;
                await _context.SaveChangesAsync();
                return existingNote;
            }

            var note = new UserNoteModel()
            {
                Id = new Guid(),
                UserId = user?.Id,
                AdID = userNote.AdID,
                Note = userNote.Note
            };

            if (user?.UserNotes == null)
            {
                user.UserNotes = new List<UserNoteModel>();
            }
            user.UserNotes.Add(note);

            await _context.SaveChangesAsync();

            return note;
        }



        public async Task<List<UserNoteDto>> GetUserNotes(string email)
        {
            var user = await _context.Users
                .Include(u => u.UserNotes)
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null || user.UserNotes == null)
            {
                throw new Exception($"User with email {email} does not exist or has no notes.");
            }

            var userNotes = user.UserNotes.Select(n => new UserNoteDto
            {
                AdID = n.AdID,
                Note = n.Note
            }).ToList();

            return userNotes;
        }

        public async Task<UserModel> UpdatUser(string email, UserUpdateDto userUpdate)
        {

            var user = await _userManager.FindByEmailAsync(email);


            if (!string.IsNullOrEmpty(userUpdate.Name)) { user.Name = userUpdate.Name; }

            if (!string.IsNullOrEmpty(userUpdate.LastName)) { user.LastName = userUpdate.LastName; }

            if (!string.IsNullOrEmpty(userUpdate.phoneNumber)) { user.PhoneNumber = userUpdate.phoneNumber; }

            if (userUpdate?.BirthDate != null) { user.BirthDate = userUpdate.BirthDate; }

            if (!string.IsNullOrEmpty(userUpdate?.City)) { user.City = userUpdate.City; }

            if (!string.IsNullOrEmpty(userUpdate?.Street)) { user.Street = userUpdate.Street; }

            if (userUpdate?.HouseNumber != 0) { user.HouseNumber = userUpdate.HouseNumber; }

            if (userUpdate.Picture != null) { user.Picture = userUpdate.Picture; }



            await _context.SaveChangesAsync();

            return user;
        }

    }
    public class LastsearchesDto
    {
    }
}

        

