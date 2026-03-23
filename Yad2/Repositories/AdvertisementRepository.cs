using System.Net;
using System.Net.Mime;
using System.Xml;
using Microsoft.EntityFrameworkCore;
using Yad2.Data;
using Yad2.Models;

namespace Yad2.Repositories;


public class AdvertisementRepository : IAdvertisementRepository
{


    private Yad2Context context;

    public AdvertisementRepository(Yad2Context _context)
    {
        context = _context;
    }



    public async Task<AdvertisementsModel> GetAdvertisement(int id)
    {
        var advertisement = await context.Advertisements
        .Include(a => a.Pictures)
        .FirstOrDefaultAsync(a => a.Id == id)
        ?? throw new Exception("Advertisement not found");
        return advertisement;
    }

    public async Task<List<AdvertisementsModel>> GetAdvertisements()
    {
        return await context.Advertisements
        .Include(a => a.Pictures)
        .ToListAsync();
    }


}