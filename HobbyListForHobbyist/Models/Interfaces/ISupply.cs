using HobbyListForHobbyist.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyListForHobbyist.Models.Interfaces
{
    public interface ISupply
    {
        //CreateAllSupplies
        // CreateASupply
        /// <summary>
        /// The below method allows one to create an item to be stored within Supply
        /// </summary>
        /// <param name="supplyName">the name of the supply item</param>
        /// <param name="email">the email for the user</param>
        /// <returns>the newly added supply item</returns>
        Task<SupplyDTO> Create(SupplyDTO supplyName, string email);
        // GetAllSupplies
        // GetAllSupplies
        /// <summary>
        /// the below method allows one to seach for a particular supply item
        /// </summary>
        /// <param name="email">this is the email associated with the current user (ensures they have access to supply item)</param>
        /// <returns>the supply item in question</returns>
        Task<List<SupplyDTO>> GetSupplies(string email);
        // GetASupply
        // GetASupply
        /// <summary>
        /// the below method brings up to the user all supply items currently in their table
        /// </summary>
        /// <param name="supplyId">the id number of each particular supply item (the method checks for them all)</param>
        /// <param name="email">authenticates the user's access level for the supply items</param>
        /// <returns>the suppply items in the database</returns>
        Task<SupplyDTO> GetSupply(int supplyId, string email);
        // UpdateASupply
        // UpdateASupply
        /// <summary>
        /// the below method updates a particular supply item in the database
        /// </summary>
        /// <param name="supplyDTO">this selects the supply DTO (what parameters are shown to user)</param>
        /// <param name="email">checks to see if user has authorization for selected supply item</param>
        /// <returns>the supply dto with the updated supply item</returns>
        Task<SupplyDTO> Update(SupplyDTO supplyDTO, string email);
        // DeleteASupply
        // DeleteASupply
        /// <summary>
        /// the below method deletes a supply item from the database
        /// </summary>
        /// <param name="supplyId">the supply item to be deleted</param>
        /// <returns>nothing, the item is deleted</returns>
        Task Delete(int supplyId);
    }
}
