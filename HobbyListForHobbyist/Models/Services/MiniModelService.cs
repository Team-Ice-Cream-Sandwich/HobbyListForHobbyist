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
    public class MiniModelService : IMiniModel
    {
        private HobbyListDbContext _context;

        public MiniModelService(HobbyListDbContext context)
        {
            _context = context;
        }
        // ================== TODO ===========================
        // CreateAMiniModel
        public async Task<MiniModelDTO> Create(MiniModelDTO miniModel)
        {
            Enum.TryParse(miniModel.BuildState, out BuildState buildState);

            MiniModel entity = new MiniModel()
            {
                Name = miniModel.Name,
                Manufacturer = miniModel.Manufacturer,
                PartNumber = miniModel.PartNumber,
                Faction = miniModel.Faction,
                PointCost = miniModel.PointCost,
                BuildState = buildState
            };

            //TODO get User ID and attach it to "entity"

            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return miniModel;
        }

        // GetAllMiniModels
        Task<MiniModelDTO> GetMiniModel(int id)
        {

        }
        // GetAllMiniModelsOfState
        Task<List<MiniModelDTO>> GetAMiniModelOfState(BuildState buildState)
        {

        }
        // GetAMiniModel
        Task<List<MiniModel>> GetAllMiniModels()
        {

        }
        // UpdateAMiniModel
        Task<MiniModelDTO> Update(MiniModelDTO miniModel, int id)
        {

        }
        // DeleteAMiniModel
        Task Delete(int id)
        {

        }
    }
}
