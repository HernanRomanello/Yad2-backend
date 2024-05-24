using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Yad2.Data;
using Yad2.Models;

namespace Yad2.Repositories
{
    public class UserRepository
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
        //         public string Name { get; set; }
        // public string LastName { get; set; }

        // public DateTime BirthDate { get; set; }

        // public AddressModel Address { get; set; }

        // public string Picture { get; set; }

        // public List<AdvertisementsModel> FavoriteAdvertisements { get; set; }
        // public List<AdvertisementsModel> MyAdvertisements { get; set; }

        // public List<AdvertisementModelStatistic> Statistics { get; set; }
                // UserName = signupModel.Email,
                // Email = signupModel.Email,
                // Address = new AddressModel()
                // {
                //     City = signupModel.City,
                //     Street = signupModel.Street,
                //     Number = signupModel.Number,
                //     Floor = signupModel.Floor,
                //     TotalFloors = signupModel.TotalFloors,
                //     OnPillars = signupModel.OnPillars,
                //     Neighborhood = signupModel.Neighborhood
                // }
             
            };


            var result = await _userManager.CreateAsync(User, signupModel.Password);

            return result;
        }
        public async Task<string> LogIn(LoginModel logInModel)
        {

            var result = await _singInManager.PasswordSignInAsync(logInModel.Email, logInModel.Password, false, false);

            if (!result.Succeeded) { return null; }

            string token = NewToken(logInModel.Email, false);

            return token;
        }
        public async Task<UserModel> GetUserByEmail(string email)
                {
                    var user = await _userManager.FindByEmailAsync(email);
                    return user;
                }
                    
      private string NewToken(string email, bool isAdmin)
     {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            if (isAdmin)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
