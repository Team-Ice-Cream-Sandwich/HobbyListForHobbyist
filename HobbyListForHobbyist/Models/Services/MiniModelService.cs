using HobbyListForHobbyist.Data;
using HobbyListForHobbyist.Models.DTOs;
using HobbyListForHobbyist.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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
        private IPaint _paint;
        private ISupply _supply;

        public MiniModelService(HobbyListDbContext context, IPaint paint, ISupply supply)
        {
            _context = context;
            _paint = paint;
            _supply = supply;
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
        public async Task<MiniModelDTO> GetMiniModel(int id)
        {
            MiniModel miniModel = await _context.MiniModels.FindAsync(id);

            var paintList = await _context.MinisToPaint.Where(x => x.MiniModelId == id)
                                                        .ToListAsync();

            var suppliesList = await _context.MinisToSupply.Where(x => x.MiniModelId == id)
                                                            .ToListAsync();

            // ============ TODO: Needs Testing =============
            List<PaintDTO> paints = new List<PaintDTO>();
            List<SupplyDTO> supplies = new List<SupplyDTO>();
            foreach (var item in paintList)
            {
                paints.Add(await _paint.GetPaint(item.Paint.Id));
            }

            foreach (var item in suppliesList)
            {
                supplies.Add(await _supply.GetSupply(item.Supply.Id));
            }


            MiniModelDTO miniDto = new MiniModelDTO()
            {
                Id = miniModel.Id,
                Name = miniModel.Name,
                Manufacturer = miniModel.Manufacturer,
                Faction = miniModel.Faction,
                PointCost = miniModel.PointCost,
                BuildState = miniModel.BuildState.ToString(),
                Paints = paints,
                Supplies = supplies
            };

            return miniDto;
        }
        // GetAllMiniModelsOfState
        public async Task<List<MiniModelDTO>> GetAMiniModelOfState(BuildState buildState)
        {
            List<MiniModel> miniList = await _context.MiniModels.Where(x => x.BuildState == buildState)
                                                                .ToListAsync();
            List<MiniModelDTO> miniDTOList = new List<MiniModelDTO>();

            foreach (var mini in miniList)
            {
                var paintList = await _context.MinisToPaint.Where(x => x.MiniModelId == mini.Id)
                                                        .ToListAsync();

                var suppliesList = await _context.MinisToSupply.Where(x => x.MiniModelId == mini.Id)
                                                                .ToListAsync();

                // ============ TODO: Needs Testing =============
                List<PaintDTO> paints = new List<PaintDTO>();
                List<SupplyDTO> supplies = new List<SupplyDTO>();
                foreach (var item in paintList)
                {
                    paints.Add(await _paint.GetPaint(item.Paint.Id));
                }

                foreach (var item in suppliesList)
                {
                    supplies.Add(await _supply.GetSupply(item.Supply.Id));
                }

                miniDTOList.Add(new MiniModelDTO
                {
                    Id = mini.Id,
                    Name = mini.Name,
                    Manufacturer = mini.Manufacturer,
                    Faction = mini.Faction,
                    PointCost = mini.PointCost,
                    BuildState = mini.BuildState.ToString(),
                    Paints = paints,
                    Supplies = supplies
                }
                );
            }

            return miniDTOList;

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
