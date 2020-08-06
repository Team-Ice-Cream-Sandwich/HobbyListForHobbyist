using HobbyListForHobbyist.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyListForHobbyist.Models.Interfaces
{
    public interface IMiniModel
    {
        // CreateAMiniModel
        /// <summary>
        /// The below method allows one to create an minimodel to be stored within MiniModel
        /// </summary>
        /// <param name="supplyName">the name of the minimodel item</param>
        /// <returns>the newly added minimodel item</returns>
        Task<MiniModelDTO> Create(MiniModelDTO miniModel, string email);

        // GetAMiniModel
        /// <summary>
        /// the below method allows one to seach for a particular minimodel item
        /// </summary>
        /// <param name="email">this is the email associated with the current user (ensures they have access to minimodel item)</param>
        /// <returns>the minimodel item in question</returns>
        Task<MiniModelDTO> GetMiniModel(int id, string email);

        // GetAllMiniModelsOfState
        /// <summary>
        /// the below method brings up to the user all minimodels oh a sepcified buildstate items currently in their table
        /// </summary>
        /// <param name="buildState">takes a buildstate enum</param>
        /// <param name="email">a string for the the email</param>
        /// <returns></returns>
        Task<List<MiniModelDTO>> GetAMiniModelOfState(BuildState buildState, string email);

        // GetAllMiniModels
        /// <summary>
        /// the below method brings up to the user all minimodels items currently in their table
        /// </summary>
        /// <param name="supplyId">the id number of each particular minimodel item (the method checks for them all)</param>
        /// <param name="email">authenticates the user's access level for the minimodel items</param>
        /// <returns>the minimodels items in the database</returns>
        Task<List<MiniModelDTO>> GetAllMiniModels(string email);

        // UpdateAMiniModel
        /// <summary>
        /// the below method updates a particular minimodel item in the database
        /// </summary>
        /// <param name="supplyDTO">this selects the minimodel DTO (what parameters are shown to user)</param>
        /// <param name="email">checks to see if user has authorization for selected minimodel item</param>
        /// <returns>the minimodel dto with the updated minimodel item</returns>
        Task<MiniModelDTO> Update(MiniModelDTO miniModel, int id, string email);
        
        // DeleteAMiniModel
        /// <summary>
        /// the below method deletes a minimodel item from the database
        /// </summary>
        /// <param name="supplyId">the minimodel item to be deleted</param>
        /// <returns>nothing, the item is deleted</returns>
        Task Delete(int id);

        // add a paint to a model
        Task AddAPaintToAModel(int miniModelId, int paintId);
        // remove a paint from a model
        Task RemoveAPaintToAModel(int miniModelId, int paintId);

        // add a supply to a model
        Task AddASupplytToAModel(int miniModelId, int supplyId);
        // remove a supply from a model
        Task RemoveASupplyToAModel(int miniModelId, int supplyId);
    }
}
