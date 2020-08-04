using HobbyListForHobbyist.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyListForHobbyist.Models.Interfaces
{
    public interface IMiniWishList
    {
        // CreateAMiniWishList
        Task<MiniWishListDTO> Create(MiniWishListDTO wishListDto, string userId);

        // GetAllMiniModels
        Task<MiniWishListDTO> GetMiniModelInWishList(int id, string userId);

        // GetAMiniModel
        Task<List<MiniWishListDTO>> GetAllMiniModelsInWishList(string userId);

        // UpdateAMiniModel
        Task<MiniWishListDTO> Update(MiniWishListDTO wishListDto, int id);
        // DeleteAMiniModel
        Task Delete(int id);

        // add wishlist to model
        Task AddMiniWishListToMiniModel(string userId, MiniWishListDTO wishListDto);

    }
}
