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
        Task<SupplyDTO> Create(SupplyDTO supplyName);
        // GetAllSupplies
        Task<List<SupplyDTO>> GetSupplies(string email);
        // GetASupply
        Task<SupplyDTO> GetSupply(int supplyId, string email);
        // UpdateASupply
        Task<SupplyDTO> Update(SupplyDTO supplyDTO);
        // DeleteASupply
        Task Delete(int supplyId);
    }
}
