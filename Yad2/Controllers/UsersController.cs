using System.Security.Claims;
using Book_Store.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yad2.Data;
using Yad2.Dto;
using Yad2.Models;
using Yad2.Repositories;

namespace Yad2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _usersRepository;
     
          private readonly Yad2Context _context;

       public UsersController(IUserRepository usersRepository , Yad2Context context)
         {
            _usersRepository = usersRepository;
              _context = context;
         }

            [HttpPost("signup")]
            public async Task<IActionResult> SignUp([FromBody] SignUpModel signUpModel)
            {
            var result = await _usersRepository.Singup(signUpModel);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized();
            }
            [HttpPost("login")]
            public async Task<IActionResult> LogIn([FromBody] LoginModel loginModel)
        {
           
            var User = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginModel.Email);
            if (User == null)
            {
                return Unauthorized("Invalid credentials");
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier , User.Id.ToString() ),
                new Claim(ClaimTypes.Email, User.Email),
                new Claim(ClaimTypes.Name, User.Email),
            };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddDays(1)
                }
            );

            _usersRepository.SetJwtCookie(Response, User);


                return Ok(new { message = "Login succesful " });


            }

            [HttpGet("User")]
            [Authorize]
            public async Task<IActionResult> GetUserByEmail()
        {
                string email = User.FindFirstValue(ClaimTypes.Name);

                var user = await _usersRepository.GetUserByEmail(email);
                
                if (user == null) {   return BadRequest();}
                if (user == null) {   return BadRequest();}
                
                return Ok(user);
                
              
            }

             [HttpPost("user/AddNote/{id}")]
            [Authorize]
           public async Task<IActionResult> AddNoteToAdvertisement(int id, [FromBody] UserNoteDto note)
            {
                string email = User.FindFirstValue(ClaimTypes.Name);
                var result = await _usersRepository.CreateNoteForUser(email,note);
                if (result == null) { return BadRequest(); }
                return Ok(result);
            }

            [HttpGet("user/GetNotes")]
            [Authorize]

            public async Task<IActionResult> GetNotes()
            {
                string email = User.FindFirstValue(ClaimTypes.Name);
                var notes = await _usersRepository.GetUserNotes(email);
                return Ok(notes);
            }


           [HttpPost("CreateAdvertisement")]
           [Authorize]
            public async Task<IActionResult> CreateAdvertisement([FromBody] AdvertisementDto dto) {
                 string email = User.FindFirstValue(ClaimTypes.Name);
                var advertisement = await _usersRepository.CreateAdvertisement(dto,email);
                return Ok(advertisement);
            }

            [HttpPut("UpdateAdvertisement/{id}")]
            [Authorize]

            public async Task<IActionResult> UpdateAdvertisement(int id, [FromBody] AdvertisementDto dto) {
                var advertisement = await _usersRepository.UpdateAdvertisement(id, dto);
                return Ok(advertisement);
            }
             [HttpDelete("DeleteAdvertisement/{id}")]
             
             [Authorize]

            public async Task<IActionResult> DeleteAdvertisement(int id) {
                string email = User.FindFirstValue(ClaimTypes.Name);
                await _usersRepository.DeleteAdvertisement(id,email);

                return Ok();
            }

            [HttpGet("GetAdvertisements")]
            [Authorize]
            public async Task<IActionResult> GetAdvertisements() {
                string email = User.FindFirstValue(ClaimTypes.Name);
                var advertisements = await _usersRepository.GetUserAdvertisementsByEmail(email);
                return Ok(advertisements);
            }
       

         [HttpPost("user/updateFavorite/{id}")]
         [Authorize]
             public async Task<IActionResult> UpdateFavorite(int id )
                {
                 string email = User.FindFirstValue(ClaimTypes.Name);
                 var result = await _usersRepository.AddOrRemoveFavorite(id,email);
                 if (result == null) { return BadRequest(); }
                 return Ok(result);
                }     

            [HttpGet("GetFavorites")]
            [Authorize]
            public async Task<IActionResult> GetFavorites() {
                string email = User.FindFirstValue(ClaimTypes.Name);
                var Favorites = await _usersRepository.GetFavoriteAdvertisements(email);
                return Ok(Favorites);
            }

           

        [HttpPut("user/update")]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDto updatedUser)
        {
            string email = User.FindFirstValue(ClaimTypes.Name);

            var user = await _usersRepository.UpdatUser(email,updatedUser);

            if (user == null) { return BadRequest(); }

            return Ok(user);
        }

        [HttpPost("user/AddLastSearch")]
        [Authorize]
        public async Task<IActionResult> AddLastsearch([FromBody] LastsearcheDto lastsearcheDto)
        {
            string email = User.FindFirstValue(ClaimTypes.Name);
            var lastsearch = await _usersRepository.AddSearchInput(email,lastsearcheDto);
            return Ok(lastsearch);
        }

        [HttpGet("user/GetLastSearches")]
        [Authorize]
        public async Task<IActionResult> GetLastSearches()
        {
            string email = User.FindFirstValue(ClaimTypes.Name);
            var lastSearches = await _usersRepository.GetSearchesList(email);
            return Ok(lastSearches);
        }

        [HttpDelete("user/DeleteLastSearch/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteLastSearch( Guid id)
        {
            var LastSearch = await _usersRepository.RemoveSearchInput(id);
            return Ok(LastSearch);
        }

        [HttpDelete("user/DeleteAllLastSearches")]
        [Authorize]

        public async Task<IActionResult> DeleteAllLastSearches()
        {
            string email = User.FindFirstValue(ClaimTypes.Name);
            var UserLastSearches =   await _usersRepository.RemoveAllUserSearches(email);
            return Ok(UserLastSearches);
        }

        [HttpGet("user/UserStatistics")]
        [Authorize]

        public async Task<IActionResult> GetUserStatistics()
        {
            string email = User.FindFirstValue(ClaimTypes.Name);
            var statistics = await _usersRepository.GetUserAdvertisementsStatistic(email);
            return Ok(statistics);
        }

        
    

         

    }
}
