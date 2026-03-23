using Microsoft.AspNetCore.Mvc;
using Yad2.Data;
using Yad2.Repositories;

namespace Yad2.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AdvertisementController : ControllerBase {

    private readonly IAdvertisementRepository _repository;

    private Yad2Context _context;

    public AdvertisementController(IAdvertisementRepository repository, Yad2Context context) {
        _repository = repository;
        _context = context;
    }


    

    [HttpGet("GetAdvertisement/{id}")]
    public async Task<IActionResult> GetAdvertisement(int id) {
        var advertisement = await _repository.GetAdvertisement(id);
        return Ok(advertisement);
    }

    [HttpGet("GetAdvertisements")]
    public async Task<IActionResult> GetAdvertisements() {
        var advertisements = await _repository.GetAdvertisements();
        return Ok(advertisements);
    }

   


}