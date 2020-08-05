using HobbyListForHobbyist.Data;
using HobbyListForHobbyist.Models.DTOs;
using HobbyListForHobbyist.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyListForHobbyist.Models.Services
{
    public class MiniWishListService : IMiniWishList
    {
        private HobbyListDbContext _context;
       

        public MiniWishListService(HobbyListDbContext context)
        {
            _context = context;
           
        }
        public async Task<MiniWishListDTO> Create(MiniWishListDTO wishListDto, string userId)
        {
            MiniWishList wishList = new MiniWishList()
            {
                Name = wishListDto.Name,
                Manufacturer = wishListDto.Manufacturer,
                PartNumber = wishListDto.PartNumber,
                Faction = wishListDto.Faction,
                PointCost = wishListDto.PointCost,
                Price = wishListDto.Price,
                UserId = userId
            };

            _context.Entry(wishList).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return wishListDto;
        }



        public async Task<MiniWishListDTO> GetMiniModelInWishList(int id, string userId)
        {
            MiniWishList wishList = await _context.MiniWishLists.Where(x => x.UserId == userId)
                                                   .FirstOrDefaultAsync(x => x.Id == id);


            // ============ TODO: Needs Testing =============

            MiniWishListDTO wishListDto = new MiniWishListDTO()
            {
                Id = wishList.Id,
                Name = wishList.Name,
                Manufacturer = wishList.Manufacturer,
                Faction = wishList.Faction,
                PointCost = wishList.PointCost,
                Price = wishList.Price,

            };

            return wishListDto;

        }

        public async Task<List<MiniWishListDTO>> GetAllMiniModelsInWishList(string userId)
        {
            List<MiniWishList> wishList = await _context.MiniWishLists.Where(x => x.UserId == userId)
                                                                .ToListAsync();

            List<MiniWishListDTO> wishListDto = new List<MiniWishListDTO>();

            foreach (var item in wishList)
            {
                //wishListDto.Add(await GetMiniModelInWishList(item.Id, item.UserId));
                wishListDto.Add(new MiniWishListDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Manufacturer = item.Manufacturer,
                    PartNumber = item.PartNumber,
                    Faction = item.Faction,
                    PointCost = item.PointCost,
                    Price = item.Price
                     
                });
            }
            return wishListDto;
        }


        public async Task<MiniWishListDTO> Update(MiniWishListDTO wishListDto, int id)
        {
            MiniWishList wishList = new MiniWishList()
            {
                Id = id,
                Name = wishListDto.Name,
                Manufacturer = wishListDto.Manufacturer,
                Faction = wishListDto.Faction,
                PointCost = wishListDto.PointCost,
                Price = wishListDto.Price
            };

            _context.Entry(wishList).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return wishListDto;
        }

        public async Task Delete(int id)
        {
            MiniWishList wishList = await _context.MiniWishLists.FindAsync(id);
            _context.Entry(wishList).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task AddMiniWishListToMiniModel(string userId,int id)
        {
          var wishList = await  _context.MiniWishLists.Where(x => x.UserId == userId)
                                        .FirstOrDefaultAsync(x => x.Id == id);
            MiniModel miniModel = new MiniModel()
            {
                Name = wishList.Name,
                Manufacturer = wishList.Manufacturer,
                PartNumber = wishList.PartNumber,
                Faction = wishList.Faction,
                PointCost = wishList.PointCost,
                BuildState = BuildState.unBuilt,
                UserId = userId
            };

            _context.Entry(miniModel).State = EntityState.Added;
            _context.Entry(wishList).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }

    }
}
