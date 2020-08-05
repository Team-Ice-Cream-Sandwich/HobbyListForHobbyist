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
        Task<MiniWishListDTO> Create(MiniWishListDTO wishListDto, string email);

        // GetAllMiniModels
        Task<MiniWishListDTO> GetMiniModelInWishList(int id, string email);

        // GetAMiniModel
        Task<List<MiniWishListDTO>> GetAllMiniModelsInWishList(string email);

        // UpdateAMiniModel
        Task<MiniWishListDTO> Update(MiniWishListDTO wishListDto, int id);
        // DeleteAMiniModel
        Task Delete(int id);

        // add wishlist to model
        Task AddMiniWishListToMiniModel(string email, int id);

    }
}
