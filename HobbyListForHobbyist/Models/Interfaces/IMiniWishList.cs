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
        /// <summary>
        /// Creates a miniWishList and adds it to the db
        /// </summary>
        /// <param name="wishListDto"> dto object</param>
        /// <param name="email"> user email</param>
        /// <returns> a wishlistdto </returns>
        Task<MiniWishListDTO> Create(MiniWishListDTO wishListDto, string email);

        // GetAMiniModel
        /// <summary>
        /// Gets a single miniModel in the wishlist
        /// </summary>
        /// <param name="id"> integer for id</param>
        /// <param name="email">users email</param>
        /// <returns> a single wishlistdto object <returns>
        Task<MiniWishListDTO> GetMiniModelInWishList(int id, string email);

        // GetAllMiniModels
        /// <summary>
        /// Gets all miniModels in the wishList
        /// </summary>
        /// <param name="email">users email</param>
        /// <returns> all wishlist object</returns>
        Task<List<MiniWishListDTO>> GetAllMiniModelsInWishList(string email);

        // UpdateAMiniModel
        /// <summary>
        /// Updates wishlistdto and saves it to the db
        /// </summary>
        /// <param name="wishListDto">object</param>
        /// <param name="id"> integer for id </param>
        /// <param name="email"> users email </param>
        /// <returns> wishlistdto object </returns>
        Task<MiniWishListDTO> Update(MiniWishListDTO wishListDto, int id, string email);

        // DeleteAMiniModel
        /// <summary>
        /// Deletes a miniModel from wishlist and db
        /// </summary>
        /// <param name="id">integer for id</param>
        /// <returns> task completion </returns>
        Task Delete(int id);

        // add wishlist to model
        /// <summary>
        /// adds the mini from the wishlist to MiniModel
        /// </summary>
        /// <param name="email">user email</param>
        /// <param name="id">integer for id</param>
        /// <returns> task completion </returns>
        Task AddMiniWishListToMiniModel(string email, int id);

    }
}
