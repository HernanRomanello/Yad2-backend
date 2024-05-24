using System.Net;
using System.Net.Mime;
using System.Xml;
using Microsoft.EntityFrameworkCore;
using Yad2.Data;
using Yad2.Models;

namespace Yad2.Repositories;


public class AdvertisementRepository {


    private Yad2Context context;

    public AdvertisementRepository(Yad2Context _context) {
        context = _context;
    }

    public async Task<AdvertisementsModel> CreateAdvertisement(AdvertisementDto dto) {
       
        var advertisement = dto.ToModel();
        context.Advertisements.Add(advertisement);
        await context.SaveChangesAsync();

        // save pictures & address
        var Pictures = dto.Pictures.Select(p => new Picture() { 
            Url = p,
            AdvertisementId = advertisement.Id 
        }).ToList();
        context.Pictures.AddRange(Pictures);
        var addressModel = dto.Address.ToModel();
        addressModel.AdvertisementId = advertisement.Id;   
        context.Addresses.Add(addressModel);
        await context.SaveChangesAsync();
        return advertisement;
    }

    public async Task<AdvertisementsModel> GetAdvertisement(int id) {
        var advertisement =  await context.Advertisements
        .Include(a => a.Pictures)
        .Include(a => a.Address)
        .FirstOrDefaultAsync(a => a.Id == id);
        if(advertisement == null) {
            throw new Exception("Advertisement not found");
        }
        return advertisement;
    }

    public async Task<List<AdvertisementsModel>> GetAdvertisements() {
        return await context.Advertisements
        .Include(a => a.Pictures)
        .Include(a => a.Address)
        .ToListAsync();
    }

    public async Task<AdvertisementsModel> UpdateAdvertisement(int id, AdvertisementDto dto) {
        var advertisement = await context.Advertisements
        .Include(a => a.Pictures)
        .Include(a => a.Address)
        .FirstOrDefaultAsync(a => a.Id == id);

        // pictures that were deleted
        var deletedPictures = advertisement.Pictures.FindAll(p => !dto.Pictures.Contains(p.Url)).ToList();
        if (deletedPictures.Count > 0)
        {
            // delete the pictures
            context.Pictures.RemoveRange(deletedPictures);
        }
        // pictures that were added
        var addedPictures = dto.Pictures.FindAll(p => advertisement.Pictures.Where(pIn => pIn.Url == p).Count() < 1).ToList();
        if(addedPictures.Count > 0)
        { 
            context.Pictures.AddRange(addedPictures.Select(p => new Picture() { Url = p, AdvertisementId = advertisement.Id}));
        }

        if (advertisement == null) {
            throw new Exception("Advertisement not found");
        }
        advertisement.Update(dto);
        await context.SaveChangesAsync();
        return advertisement;
    }

    public async Task<AdvertisementsModel> DeleteAdvertisement(int id) {
        var advertisement = await context.Advertisements
        .Include(a => a.Pictures)
        .Include(a => a.Address)
        .FirstOrDefaultAsync(a => a.Id == id);
        if(advertisement == null) {
            throw new Exception("Advertisement not found");
        }
        context.Advertisements.Remove(advertisement);
        context.Pictures.RemoveRange(advertisement.Pictures);
        context.Addresses.Remove(advertisement.Address);
        await context.SaveChangesAsync();
        return advertisement;
    }
}