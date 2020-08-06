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
        /// <summary>
        /// injects the db into the class
        /// </summary>
        /// <param name="context"> Database</param>
        public MiniWishListService(HobbyListDbContext context)
        {
            _context = context;
           
        }

        /// <summary>
        /// Creates a miniWishList and adds it to the db
        /// </summary>
        /// <param name="wishListDto"> dto object</param>
        /// <param name="email"> user email</param>
        /// <returns> a wishlistdto </returns>
        public async Task<MiniWishListDTO> Create(MiniWishListDTO wishListDto, string email)
        {
            MiniWishList wishList = new MiniWishList()
            {
                Name = wishListDto.Name,
                Manufacturer = wishListDto.Manufacturer,
                PartNumber = wishListDto.PartNumber,
                Faction = wishListDto.Faction,
                PointCost = wishListDto.PointCost,
                Price = wishListDto.Price,
                Email = email
            };

            _context.Entry(wishList).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return wishListDto;
        }


        /// <summary>
        /// Gets a single miniModel in the wishlist
        /// </summary>
        /// <param name="id"> integer for id</param>
        /// <param name="email">users email</param>
        /// <returns> a single wishlistdto object <returns>
        public async Task<MiniWishListDTO> GetMiniModelInWishList(int id, string email)
        {
            MiniWishList wishList = await _context.MiniWishLists.Where(x => x.Email == email)
                                                   .FirstOrDefaultAsync(x => x.Id == id);


          

            MiniWishListDTO wishListDto = new MiniWishListDTO()
            {
                Id = wishList.Id,
                Name = wishList.Name,
                Manufacturer = wishList.Manufacturer,
                PartNumber = wishList.PartNumber,
                Faction = wishList.Faction,
                PointCost = wishList.PointCost,
                Price = wishList.Price,

            };

            return wishListDto;

        }

        /// <summary>
        /// Gets all miniModels in the wishList
        /// </summary>
        /// <param name="email">users email</param>
        /// <returns> all wishlist object</returns>
        public async Task<List<MiniWishListDTO>> GetAllMiniModelsInWishList(string email)
        {
            List<MiniWishList> wishList = await _context.MiniWishLists.Where(x => x.Email == email)
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

        /// <summary>
        /// Updates wishlistdto and saves it to the db
        /// </summary>
        /// <param name="wishListDto">object</param>
        /// <param name="id"> integer for id </param>
        /// <param name="email"> users email </param>
        /// <returns> wishlistdto object </returns>
        public async Task<MiniWishListDTO> Update(MiniWishListDTO wishListDto, int id, string email)
        {
            MiniWishList wishList = new MiniWishList()
            {
                Id = id,
                Name = wishListDto.Name,
                Manufacturer = wishListDto.Manufacturer,
                Faction = wishListDto.Faction,
                PartNumber = wishListDto.PartNumber,
                PointCost = wishListDto.PointCost,
                Price = wishListDto.Price,
                Email = email
                 
            };

            _context.Entry(wishList).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return wishListDto;
        }

        // DeleteAMiniModel
        /// <summary>
        /// Deletes a miniModel from wishlist and db
        /// </summary>
        /// <param name="id">integer for id</param>
        /// <returns> task completion </returns>
        public async Task Delete(int id)
        {
            MiniWishList wishList = await _context.MiniWishLists.FindAsync(id);
            _context.Entry(wishList).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// adds the mini from the wishlist to MiniModel
        /// </summary>
        /// <param name="email">user email</param>
        /// <param name="id">integer for id</param>
        /// <returns> task completion </returns>
        public async Task AddMiniWishListToMiniModel(string email,int id)
        {
          var wishList = await  _context.MiniWishLists.Where(x => x.Email == email)
                                        .FirstOrDefaultAsync(x => x.Id == id);
            MiniModel miniModel = new MiniModel()
            {
                Name = wishList.Name,
                Manufacturer = wishList.Manufacturer,
                PartNumber = wishList.PartNumber,
                Faction = wishList.Faction,
                PointCost = wishList.PointCost,
                BuildState = BuildState.unBuilt,
                Email = email
            };

            _context.Entry(miniModel).State = EntityState.Added;
            _context.Entry(wishList).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }

    }
}
