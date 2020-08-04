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
        Task<MiniModelDTO> Create(MiniModelDTO miniModel, string userId);
        // GetAllMiniModels
        Task<MiniModelDTO> GetMiniModel(int id, string userId);
        // GetAllMiniModelsOfState
        Task<List<MiniModelDTO>> GetAMiniModelOfState(BuildState buildState, string userId);
        // GetAMiniModel
        Task<List<MiniModelDTO>> GetAllMiniModels(string userId);
        // UpdateAMiniModel
        Task<MiniModelDTO> Update(MiniModelDTO miniModel, int id);
        // DeleteAMiniModel
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
