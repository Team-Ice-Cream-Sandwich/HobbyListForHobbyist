using HobbyListForHobbyist.Data;
using HobbyListForHobbyist.Models.DTOs;
using HobbyListForHobbyist.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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

        // CreateAMiniModel
        public async Task<MiniModelDTO> Create(MiniModelDTO miniModel, string userId)
        {
            //========================= TODO Test user ID =========================
            Enum.TryParse(miniModel.BuildState, out BuildState buildState);

            MiniModel entity = new MiniModel()
            {
                Name = miniModel.Name,
                Manufacturer = miniModel.Manufacturer,
                PartNumber = miniModel.PartNumber,
                Faction = miniModel.Faction,
                PointCost = miniModel.PointCost,
                BuildState = buildState,
                UserId = userId
            };


            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return miniModel;
        }

        // GetAMiniModel
        public async Task<MiniModelDTO> GetMiniModel(int id, string userId)
        {
            MiniModel miniModel = await _context.MiniModels.Where(x=>x.UserId == userId)
                                                           .FirstOrDefaultAsync(x=>x.Id == id);

            var paintList = await _context.MinisToPaint.Where(x => x.MiniModelId == id)
                                                       .Include(x=>x.Paint)
                                                       .ToListAsync();

            var suppliesList = await _context.MinisToSupply.Where(x => x.MiniModelId == id)
                                                           .Include(x=>x.Supply)
                                                           .ToListAsync();

            // ============ TODO: Needs Testing =============
            List<PaintDTO> paints = new List<PaintDTO>();
            List<SupplyDTO> supplies = new List<SupplyDTO>();
            foreach (var item in paintList)
            {
                paints.Add(await _paint.GetPaint(item.Paint.Id, userId));
            }

            foreach (var item in suppliesList)
            {
                supplies.Add(await _supply.GetSupply(item.Supply.Id, userId));
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
        public async Task<List<MiniModelDTO>> GetAMiniModelOfState(BuildState buildState, string userId)
        {
            List<MiniModel> miniList = await _context.MiniModels.Where(x => x.BuildState == buildState && x.UserId == userId)
                                                                .ToListAsync();

            List<MiniModelDTO> miniDTOList = new List<MiniModelDTO>();

            foreach (var mini in miniList)
            {
                var paintList = await _context.MinisToPaint.Where(x => x.MiniModelId == mini.Id)
                                                           .ToListAsync();

                var suppliesList = await _context.MinisToSupply.Where(x => x.MiniModelId == mini.Id)
                                                               .ToListAsync();

                List<PaintDTO> paints = new List<PaintDTO>();
                List<SupplyDTO> supplies = new List<SupplyDTO>();
                foreach (var item in paintList)
                {
                    paints.Add(await _paint.GetPaint(item.Paint.Id, userId));
                }

                foreach (var item in suppliesList)
                {
                    supplies.Add(await _supply.GetSupply(item.Supply.Id, userId));
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

        // GetAllMiniModels
        public async Task<List<MiniModelDTO>> GetAllMiniModels(string userId)
        {
            List<MiniModel> miniList = await _context.MiniModels.Where(x=>x.UserId==userId)
                                                                .ToListAsync();

            List<MiniModelDTO> miniDTOList = new List<MiniModelDTO>();

            foreach (var mini in miniList)
            {
                var paintList = await _context.MinisToPaint.Where(x => x.MiniModelId == mini.Id)
                                                        .ToListAsync();

                var suppliesList = await _context.MinisToSupply.Where(x => x.MiniModelId == mini.Id)
                                                                .ToListAsync();

             
                List<PaintDTO> paints = new List<PaintDTO>();
                List<SupplyDTO> supplies = new List<SupplyDTO>();
                foreach (var item in paintList)
                {
                    paints.Add(await _paint.GetPaint(item.Paint.Id, userId));
                }

                foreach (var item in suppliesList)
                {
                    supplies.Add(await _supply.GetSupply(item.Supply.Id, userId));
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
        // UpdateAMiniModel
        public async Task<MiniModelDTO> Update(MiniModelDTO miniModel, int id)
        {
            Enum.TryParse(miniModel.BuildState, out BuildState buildState);

            MiniModel updatedMiniModel = new MiniModel()
            {
                Id = miniModel.Id,
                Name = miniModel.Name,
                Manufacturer = miniModel.Manufacturer,
                Faction = miniModel.Faction,
                PointCost = miniModel.PointCost,
                BuildState = buildState
            };

            _context.Entry(updatedMiniModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return miniModel;
        }

        // DeleteAMiniModel
        public async Task Delete(int id)
        {
            MiniModel miniModel = await _context.MiniModels.FindAsync(id);
            _context.Entry(miniModel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        // add a paint to a model
        public async Task AddAPaintToAModel(int miniModelId, int paintId)
        {
            // ================== TODO Check for UserId ==========================
            MiniToPaint miniPaint = new MiniToPaint()
            {
                MiniModelId = miniModelId,
                PaintId = paintId
            };

            _context.Entry(miniPaint).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
        // remove a paint from a model
        public async Task RemoveAPaintToAModel(int miniModelId, int paintId)
        {
            // ================== TODO Check for UserId ==========================
            var result = await _context.MinisToPaint.FirstOrDefaultAsync(x => x.MiniModelId == miniModelId && x.PaintId == paintId);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        // add a supply to a model
        public async Task AddASupplytToAModel(int miniModelId, int supplyId)
        {
            // ================== TODO Check for UserId ==========================
            MiniToSupply miniSupply = new MiniToSupply()
            {
                MiniModelId = miniModelId,
                SupplyId = supplyId
            };

            _context.Entry(miniSupply).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
        // remove a supply from a model
        public async Task RemoveASupplyToAModel(int miniModelId, int supplyId)
        {
            // ================== TODO Check for UserId ==========================
            var result = await _context.MinisToSupply.FirstOrDefaultAsync(x => x.MiniModelId == miniModelId && x.SupplyId == supplyId);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }     
    }
}
