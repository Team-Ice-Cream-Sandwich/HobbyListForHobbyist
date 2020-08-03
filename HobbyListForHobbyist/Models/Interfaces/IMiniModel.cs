using HobbyListForHobbyist.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyListForHobbyist.Models.Interfaces
{
    interface IMiniModel
    {
        // ================== TODO ===========================
        // CreateAMiniModel
        Task<MiniModelDTO> Create(MiniModelDTO miniModel);
        // GetAllMiniModels
        Task<MiniModelDTO> GetMiniModel(int id);
        // GetAllMiniModelsOfState
        Task<List<MiniModelDTO>> GetAMiniModelOfState(BuildState buildState);
        // GetAMiniModel
        Task<List<MiniModel>> GetAllMiniModels();
        // UpdateAMiniModel
        Task<MiniModelDTO> Update(MiniModelDTO miniModel, int id);
        // DeleteAMiniModel
        Task Delete(int id);
    }
}
