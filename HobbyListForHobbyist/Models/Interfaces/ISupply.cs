using HobbyListForHobbyist.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyListForHobbyist.Models.Interfaces
{
    public interface ISupply
    {
        // ================== TODO ===========================
        //CreateAllSupplies
        Task<SupplyDTO> Create(SupplyDTO supplyName);
        // GetAllSupplies
        Task<List<SupplyDTO>> GetSupplies();
        // GetASupply
        Task<SupplyDTO> GetSupply(int supplyId);
        // UpdateASupply
        Task Update(int supplyId, SupplyDTO supplyName);
        // DeleteASupply
        Task Delete(int supplyId);
    }
}
