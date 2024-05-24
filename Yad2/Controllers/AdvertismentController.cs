using Microsoft.AspNetCore.Mvc;
using Yad2.Data;
using Yad2.Repositories;

namespace Yad2.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AdvertisementController : ControllerBase {

    private AdvertisementRepository _repository;

    public AdvertisementController(AdvertisementRepository repository) {
        _repository = repository;
    }


    [HttpPost("CreateAdvertisement")]
    public async Task<IActionResult> CreateAdvertisement([FromBody] AdvertisementDto dto) {
        var advertisement = await _repository.CreateAdvertisement(dto);
        return Ok(advertisement);
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

    [HttpPut("UpdateAdvertisement/{id}")]
    public async Task<IActionResult> UpdateAdvertisement(int id, [FromBody] AdvertisementDto dto) {
        var advertisement = await _repository.UpdateAdvertisement(id, dto);
        return Ok(advertisement);
    }

    [HttpDelete("DeleteAdvertisement/{id}")]
    public async Task<IActionResult> DeleteAdvertisement(int id) {
        await _repository.DeleteAdvertisement(id);
        return Ok();
    }

}